using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models.ForReport;

namespace MvcApplication1.Controllers
{
    public class ReportController : Controller
    {
        //
        // GET: /Report/

        public ActionResult Report()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            ComplexModels list = new ComplexModels();

            var listTariffServiecs = db.ExecuteQuery<type_servies>(@"SELECT * FROM [type_servies]").ToList<type_servies>();
            var listTariffNumber = db.ExecuteQuery<type_pool>(@"SELECT * FROM [type_pool]").ToList<type_pool>();
            var listOrders = db.ExecuteQuery<Orders>(@"SELECT * FROM [Orders]").ToList<Orders>();

            //Тарификация услуг
            list.listServiecs = listTariffServiecs;

            //Тарификация номеров
            list.listNumber = listTariffNumber;

            //Колиечство заказов
            list.GeneralOrdersCount = listOrders.Count;

            //Сумма общих заказов
            list.GeneralOrdersSum = db.ExecuteQuery<int>(@"SELECT SUM([Orders].[BigPrice]) FROM [Orders]").Single();

            //Текущие заказы
            list.CurrentOrdersCount = db.ExecuteQuery<int>(@"SELECT COUNT([Orders].[Id_order]) AS 'Id_order' FROM [Orders] WHERE [Orders].[Done] = 'false'").Single();

            //Сумма текущих заказов
            list.CurrentOrdersSum = db.ExecuteQuery<int>(@"SELECT SUM([Orders].[Id_order]) AS 'Id_order' FROM [Orders] WHERE [Orders].[Done] = 'false'").Single();

            //Завершающие заказы
            list.EndOrdersCount = db.ExecuteQuery<int>(@"SELECT COUNT([Orders].[Id_order]) AS 'Id_order' FROM [Orders] WHERE [Orders].[Done] = 'true'").Single();

            //Сумма завершающих заказов
            list.EndOrdersSum = db.ExecuteQuery<int>(@"SELECT SUM([Orders].[Id_order]) AS 'Id_order' FROM [Orders] WHERE [Orders].[Done] = 'true'").Single();

            //Количество неоплачивающих
            list.OrdersCountNotPayment = db.ExecuteQuery<int>(@"SELECT COUNT([Orders].[Id_order]) AS 'Id_order' FROM [Orders] WHERE [Orders].[payment] = 'false'").Single();

            //Неоплачивающие суммы
            list.OrdersSumNotPayment = db.ExecuteQuery<int>(@"SELECT SUM([Orders].[Id_order]) AS 'Id_order' FROM [Orders] WHERE [Orders].[payment] = 'false'").Single();

            //Количество оплачивающих
            list.OrdersCountPayment = db.ExecuteQuery<int>(@"SELECT COUNT([Orders].[Id_order]) AS 'Id_order' FROM [Orders] WHERE [Orders].[payment] = 'true'").Single();

            //Оплачивающие суммы
            list.OrdersSumPayment = db.ExecuteQuery<int>(@"SELECT SUM([Orders].[Id_order]) AS 'Id_order' FROM [Orders] WHERE [Orders].[payment] = 'true'").Single();

            //-----------------

            //Предоставили услуг в заказе
            var lll = db.ExecuteQuery<StatusServiecs>(@"SELECT [Orders].[Id_order], COUNT(*) AS 'ttt' FROM [Orders], [list_add_services] WHERE [Orders].[Id_order] = [list_add_services].[id_order] GROUP BY [Orders].[Id_order]").ToList<StatusServiecs>();
            list.ServiecsOnInOrderCount = lll.Count();

            //Общий количество услуг
            int inc = 0;
            foreach (var item in lll)
            {
                inc += item.ttt;
            }
            list.GeneralServiecs = inc;

            //Сумма всего услуг
            var temp = db.ExecuteQuery<StatusServiecs>("SELECT SUM([list_add_services].[price]) AS 'ttt' FROM [list_add_services], [type_servies] WHERE [list_add_services].[id_servies] = [type_servies].[Id_servies] GROUP BY	[list_add_services].[Id_order]").ToList<StatusServiecs>();
            int sum = 0;
            foreach (var item in temp)
            {
                sum += item.ttt;
            }
            list.ServiecsSum = sum;


            // Количество регистрационных клиентов
            var listClient = db.ExecuteQuery<Client>("SELECT * FROM [Client]").ToList<Client>();
            list.ClientCount = listClient.Count();

            // "Постоянные" клиенты (5 и более заказов)
            var temp2 = db.ExecuteQuery<Client>("SELECT [Client].[Id_client], [Client].[FIO],	COUNT([Orders].[Id_order]) FROM	[Orders], [Client] WHERE [Orders].[id_client] = [Client].[Id_client] AND [Orders].[payment] = 'true' GROUP BY [Client].[Id_client], [Client].[FIO] HAVING  (COUNT([Orders].[Id_order])) >= 2").ToList<Client>();
            list.ClientConstCount = temp2.Count();
            list.listClientConst = temp2;

            // Клиенты-халявчики
            var temp3 = db.ExecuteQuery<Client>("SELECT [Client].[Id_client], [Client].[FIO] FROM [Orders], [Client] WHERE [Orders].[id_client] = [Client].[Id_client] AND [Orders].[payment] = 'false' GROUP BY [Client].[Id_client], [Client].[FIO]").ToList<Client>();
            list.ClientNotPaymentCount = temp3.Count();
            list.listClientNotPayment = temp3;


            return View(list);
        }

        public ActionResult ReportOut()
        {
            string[][] RaschetCount = new string[4][];
            string[][] RaschetSum = new string[4][];

            

            DataClasses1DataContext db = new DataClasses1DataContext();
            Calculations calcDB = new Calculations();

            var listTariffServiecs = db.ExecuteQuery<type_servies>(@"SELECT * FROM [type_servies]").ToList<type_servies>();

            //тут все весна
            //DateTime Do = new DateTime(2016, 04, 01, 0, 0, 0);
            //DateTime To = new DateTime(2016, 06, 30, 23, 59, 59);
            string Do = "2016-04-01T00:00:00.000";
            string To = "2016-06-30T23:59:59.997";

            
            for (int i = 0; i < RaschetCount.Length; i++)
            {
                RaschetCount[i] = new string[4];
                RaschetSum[i] = new string[4];

                int sum = 0, count = 0;
                for (int j = 0; j < RaschetCount[i].Length; j++)
                {
                    RaschetCount[i][j] = FromQueryCount(db, j + 1, i + 1, Do, To).ToString();
                    //RaschetSum[i][j] = FromQuerySum(db, i, j, Do, To).ToString();
                    RaschetSum[i][j] = (Convert.ToInt32(listTariffServiecs[i].tariff) * Convert.ToInt32(RaschetCount[i][j])).ToString();
                    
                    count += int.Parse(RaschetCount[i][j]);
                    sum += int.Parse(RaschetSum[i][j]);
                }
                RaschetCount[i][3] = count.ToString();
                RaschetSum[i][3] = sum.ToString();
            }


            //RaschetSum[RaschetSum.Length][RaschetSum[RaschetSum[RaschetSum.Length]]] = 

            { }
            /*
           

            // тут типы номеров
            int Econom = 3;
            int Standart = 2;
            int Lux = 1;

            //тут дополнительные услуги
            int dicko = 1;
            int bar = 2;
            int beauty = 3;
            int beach = 4;
            



            //Эконом класс
            //Дискотека
            calcDB.EconomDiscoCount = FromQueryCount(db, Econom, dicko, Do, To);
            calcDB.EconomDiscoSum = FromQuerySum(db, Econom, dicko, Do, To);

            
            //Бар
            calcDB.EconomBarCount = FromQueryCount(db, Econom, bar, Do, To);
            calcDB.EconomBarSum = FromQuerySum(db, Econom, bar, Do, To);

            //Салон красоты
            calcDB.EconomBeautyCount = FromQueryCount(db, Econom, beauty, Do, To);
            calcDB.EconomBeautySum = FromQuerySum(db, Econom, beauty, Do, To);

            //Пляж
            calcDB.EconomBeachCount = FromQueryCount(db, Econom, beach, Do, To);
            calcDB.EconomBeachSum = FromQuerySum(db, Econom, beach, Do, To);

            //Итоги
            calcDB.itogiEconomCount = calcDB.EconomDiscoCount + calcDB.EconomBarCount + calcDB.EconomBeautyCount + calcDB.EconomBeachCount;
            calcDB.itogiEconomSum = calcDB.EconomDiscoSum + calcDB.EconomBarSum + calcDB.EconomBeachSum + calcDB.EconomBeachSum;




            //Стандарт
            //Дискотека
            calcDB.StandartDiscoCount = FromQueryCount(db, Standart, dicko, Do, To);
            calcDB.StandartDiscoSum = FromQuerySum(db, Standart, dicko, Do, To);

            //Бар
            calcDB.StandartBarCount = FromQueryCount(db, Standart, bar, Do, To);
            calcDB.StandartBarSum = FromQuerySum(db, Standart, bar, Do, To);

            //Салон красоты
            calcDB.StandartBeautyCount = FromQueryCount(db, Standart, beauty, Do, To);
            calcDB.StandartBeautySum = FromQuerySum(db, Standart, beauty, Do, To);

            //Пляж
            calcDB.StandartBeachCount = FromQueryCount(db, Standart, beach, Do, To);
            calcDB.StandartBeachSum = FromQuerySum(db, Standart, beach, Do, To);

            //Итоги
            calcDB.itogiStandartCount = calcDB.StandartDiscoCount + calcDB.StandartBarCount + calcDB.StandartBeautyCount + calcDB.StandartBeachCount;
            calcDB.itogiStandartSum = calcDB.StandartDiscoSum + calcDB.StandartBarSum + calcDB.StandartBeautySum + calcDB.StandartBeachSum;



            
            //Люкс
            //Дискотека
            calcDB.LuxDiscoCount = FromQueryCount(db, Lux, dicko, Do, To);
            calcDB.LuxDiscoSum = FromQuerySum(db, Lux, dicko, Do, To);

            //Бар
            calcDB.LuxBarCount = FromQueryCount(db, Lux, bar, Do, To);
            calcDB.LuxBarSum = FromQuerySum(db, Lux, bar, Do, To);

            //Салон красоты
            calcDB.LuxBeautyCount = FromQueryCount(db, Lux, beauty, Do, To);
            calcDB.LuxBeautySum = FromQuerySum(db, Lux, beauty, Do, To);

            //Пляж
            calcDB.LuxBeachCount = FromQueryCount(db, Lux, beach, Do, To);
            calcDB.LuxBeachSum = FromQuerySum(db, Lux, beach, Do, To);

            //Итоги
            calcDB.itogiLuxCount = calcDB.LuxDiscoCount + calcDB.LuxBarCount + calcDB.LuxBeautyCount + calcDB.LuxBeachCount;
            calcDB.itogiLuxSum = calcDB.LuxDiscoSum + calcDB.LuxBarSum + calcDB.LuxBeautySum + calcDB.LuxBeachSum;

            */
            //
            //Люкс
            //calcDB.itogiBarLuxCount = 

            //return View(calcDB);

            ReportString fff = new ReportString();
            fff.RRR = RaschetSum;
            fff.TTT = RaschetCount;
            
            //return View(RaschetSum);

            return View(fff);
        }

        private static int FromQueryCount(DataClasses1DataContext db, int type_room111, int type_serviec111, string Do, string To)
        {
            return db.ExecuteQuery<int>(@"SELECT Count([list_add_services].[Id_list_add_services]) FROM	[list_add_services], [Orders], [list_number], [type_pool], [type_servies] WHERE [list_add_services].[id_order] = [Orders].[Id_order] AND [list_number].[id_order] = [Orders].[Id_order] AND [list_number].[id_type_room] = [type_pool].[id_pool] AND [list_add_services].[id_servies] = [type_servies].[Id_servies] AND	[list_add_services].[DateUse] BETWEEN CONVERT(datetime,'" + Do + "') AND CONVERT(datetime, '" + To + "') AND [list_number].[id_type_room] = '" + type_room111 + "' AND [list_add_services].[id_servies] = '" + type_serviec111 + "'").Single<int>();
            //calcDB.EconomBarSum = db.ExecuteQuery<int>(@"SELECT	ISNULL(SUM( ([type_servies].[tariff]) * ([list_add_services].[col])), 0) FROM [list_add_services], [Orders], [list_number], [type_pool], [type_servies] WHERE [list_add_services].[id_order] = [Orders].[Id_order] AND [list_number].[id_order] = [Orders].[Id_order] AND [list_number].[id_type_room] = [type_pool].[id_pool] AND [list_add_services].[id_servies] = [type_servies].[Id_servies] AND	[list_add_services].[DateUse] BETWEEN CONVERT(datetime,'" + Do + "') AND CONVERT(datetime,'" + To + "') AND [list_number].[id_type_room] = '" + type_room111 + "' AND [list_add_services].[id_servies] = '" + type_serviec111 + "'").Single<int>();
        }

        private static int FromQuerySum(DataClasses1DataContext db, int type_room111, int type_serviec111, string Do, string To)
        {
            //return db.ExecuteQuery<int>(@"SELECT	ISNULL(SUM( ([type_servies].[tariff]) * ([list_add_services].[col])), 0) FROM [list_add_services], [Orders], [list_number], [type_pool], [type_servies] WHERE [list_add_services].[id_order] = [Orders].[Id_order] AND [list_number].[id_order] = [Orders].[Id_order] AND [list_number].[id_type_room] = [type_pool].[id_pool] AND [list_add_services].[id_servies] = [type_servies].[Id_servies] AND	[list_add_services].[DateUse] BETWEEN CONVERT(datetime,'" + Do + "') AND CONVERT(datetime,'" + To + "') AND [list_number].[id_type_room] = '" + type_room111 + "' AND [list_add_services].[id_servies] = '" + type_serviec111 + "'").Single<int>();
            return db.ExecuteQuery<int>(@"SELECT	ISNULL(SUM([type_servies].[tariff]),0) FROM [list_add_services], [Orders], [list_number], [type_pool], [type_servies] WHERE [list_add_services].[id_order] = [Orders].[Id_order] AND [list_number].[id_order] = [Orders].[Id_order] AND [list_number].[id_type_room] = [type_pool].[id_pool] AND [list_add_services].[id_servies] = [type_servies].[Id_servies] AND	[list_add_services].[DateUse] BETWEEN CONVERT(datetime,'" + Do + "') AND CONVERT(datetime,'" + To + "') AND [list_number].[id_type_room] = '" + type_room111 + "' AND [list_add_services].[id_servies] = '" + type_serviec111 + "'").Single<int>();
        }



    }

    class StatusServiecs
    {
        public int ttt;

    }
}
