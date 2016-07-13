using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;
using System.Data;
using System.Data.SqlTypes;

namespace MvcApplication1.Controllers
{
    public class HomeController : Controller
    {
        int number_ordr_current;
        //List<OrderAcceptModif> listNumberOrder = new List<OrderAcceptModif>();
        List<type_pool> Type_Room;

        public ActionResult Index()
        {
            return View();
        }

       // private bool flagTypeRoom = false, flagColMest = false, flagNumber = false;


        

        public HomeController()
        {

            Type_Room = FromDB<type_pool>("SELECT * FROM [type_pool]");

            ViewBag.flagTypeRoom = false;
            ViewBag.flagColMest = false;
            ViewBag.flagNumber = false;
            ViewBag.flagCol = false;
            ViewBag.flagDateBegin = false;
            ViewBag.flagTimeBegin = false;
            ViewBag.flagDateEnd = false;
            ViewBag.flagTimeEnd = false;
            ViewBag.flagPrice = false;
            ViewBag.flagSmallButton = false;
            ViewBag.flagBigButton = false;

            

            ViewBag.Id_client = null;
            ViewBag.Name_client = null;
            ViewBag.Id_pool = null;
            ViewBag.Id_number = null;
            ViewBag.Col = null;
            ViewBag.DateBegin = null;
            ViewBag.TimeBegin = null;
            ViewBag.DateEnd = null;
            ViewBag.TimeEnd = null;
            ViewBag.Price = null;

            //

            ViewBag.flagServiesDate = false;
            ViewBag.flagTimeUse = false;
            ViewBag.flagColUse = false;
            ViewBag.flagPriceServies = false;
            ViewBag.flagServiesButton = false;

            ViewBag.IDServies = null;
            ViewBag.ServiesDate = null;
            ViewBag.TimeUse = null;
            ViewBag.ColUse = null;
            ViewBag.PriceServies = null;


            //
            //ViewBag.BigPrice = null;
        }

        public ActionResult Details(int id)
        {
            /*
            DataClasses1DataContext db = new DataClasses1DataContext();

            OrderAndServies orderservies = new OrderAndServies();
            List<ListServiesModif> listServies = new List<ListServiesModif>();

            //var ttt = db.ExecuteQuery<OrderModific>(@"SELECT [Orders].[Id_order], [Orders].[date], [Orders].[begin], [Orders].[end], [Orders].[payment], [Client].[FIO] FROM [Orders], [Client] WHERE Orders.Id_order = '" + id + "'  AND Orders.id_client = Client.Id_client;").ToList<OrderModific>().First();
            var ttt = db.ExecuteQuery<OrderModific>(@"SELECT [Orders].[Id_order], [Orders].[date], [Orders].[begin], [Orders].[end], [Orders].[payment], [Orders].[BigPrice], [Client].[FIO] FROM [Orders], [Client] WHERE Orders.Id_order = '" + id + "'  AND Orders.id_client = Client.Id_client").ToList<OrderModific>().First();

             
            listServies = db.ExecuteQuery<ListServiesModif>(@"SELECT [list_add_services].[Id_list_add_services], [list_add_services].[id_order], CAST([type_servies].[name] AS NVARCHAR(100)) AS 'name' FROM [list_add_services], [type_servies], [Orders] WHERE [list_add_services].[id_servies] = [type_servies].[Id_servies] AND [list_add_services].[id_order] = '" + id + "' GROUP BY [list_add_services].[Id_list_add_services],	[list_add_services].[Id_order],	CAST([type_servies].[name] AS NVARCHAR(100));").ToList<ListServiesModif>();
            //listServies = db.ExecuteQuery<ListServiesModif>(@"SELECT [list_add_services].[Id_list_add_services], [list_add_services].[id_order], CAST([type_servies].[name] AS NVARCHAR(100)) AS 'name' FROM [list_add_services], [type_servies], [Orders] WHERE [list_add_services].[id_servies] = [type_servies].[Id_servies] AND [list_add_services].[id_order] = '" + id + "' GROUP BY [list_add_services].[Id_list_add_services],	[list_add_services].[Id_order],	CAST([type_servies].[name] AS NVARCHAR(100));").ToList<ListServiesModif>();


            orderservies.order = ttt;
            orderservies.list = listServies;

            */

            DataClasses1DataContext db = new DataClasses1DataContext();

            OrderAndServies orderservies = new OrderAndServies();

            var order = db.ExecuteQuery<OrderModific>(@"SELECT [Orders].[Id_order], [Orders].[date], [Orders].[begin], [Orders].[end], [Orders].[payment], [Orders].[BigPrice], [Client].[FIO] FROM [Orders], [Client] WHERE Orders.Id_order = '" + id + "'  AND Orders.id_client = Client.Id_client").ToList<OrderModific>().First();
            List<list_add_serviecsModific> listServies = FromDB<list_add_serviecsModific>(@"SELECT [list_add_services].*, [type_servies].[name] AS name_servies FROM [list_add_services], [type_servies] WHERE [list_add_services].[id_order] = " + id + " AND [list_add_services].id_servies = [type_servies].[Id_servies] ");
            //List<list_number> listNumber = FromDB<list_number>(@"SELECT * FROM [list_number] WHERE [list_number].[id_order] = " + id);

            //List<list_numberModifc> listNumber = FromDB<list_numberModifc>(@"SELECT [type_number].[name] AS 'number_room', [list_number].[settlement_date], [list_number].[eviction_date], [type_pool].[type] AS 'type_room', [list_number].[price] FROM [list_number], [type_pool], [type_number] WHERE [list_number].[id_order] = " + id + " AND [list_number].[id_number_room] = [type_number].[id_number] AND [list_number].[id_type_room] = [type_pool].Id_pool GROUP BY [type_number].[name], [list_number].[settlement_date], [list_number].[eviction_date], [type_pool].[type], [list_number].[price]");
            List<list_numberModifc> listNumber = FromDB<list_numberModifc>(@"SELECT CAST([type_number].[name] AS NVARCHAR(MAX)) AS 'number_room', [list_number].[settlement_date], [list_number].[eviction_date], CAST([type_pool].[type] AS NVARCHAR(MAX)) AS 'type_room', CAST([nametyperoom].[name] AS NVARCHAR(MAX)) AS 'col_in_room', CAST([list_number].[price] AS NVARCHAR(MAX)) AS 'price' FROM [list_number], [type_pool], [type_number], [nametyperoom] WHERE [list_number].[id_order] =  " + id + "  AND [list_number].[id_number_room] = [type_number].[id_number] AND [list_number].[id_type_room] = [type_pool].Id_pool AND [list_number].[id_col_in_room] = [nametyperoom].[Id] GROUP BY CAST([type_number].[name] AS NVARCHAR(MAX)), [list_number].[settlement_date], [list_number].[eviction_date], CAST([type_pool].[type] AS NVARCHAR(MAX)), CAST([nametyperoom].[name] AS NVARCHAR(MAX)), CAST([list_number].[price] AS NVARCHAR(MAX))");

            orderservies.order = order;
            orderservies.ListServirecs = listServies;
            orderservies.ListNumber = listNumber;

            return View(orderservies);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Страница описания приложения.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Страница контактов.";

            return View();
        }

        public ActionResult CreateOrder(Orders order)
        {
            var date = DateTime.Now;
            { }
            //Создание новый заказ
            DataClasses1DataContext db = new DataClasses1DataContext();
            Orders item = new Orders()
            {
                id_client = Convert.ToInt32(order.id_client),
                date = DateTime.Now,
                Done = false,
                Hide = false
            };

            db.Orders.InsertOnSubmit(item);
            db.SubmitChanges();

            List<Orders> fff = FromDB<Orders>(@"SELECT [Orders].[Id_order] FROM [Orders]");
            string fff222 = fff.Select(it => it.Id_order).Max().ToString();
            ViewBag.IdOrder = fff222;


            List<Client> clientFromDB = FromDB<Client>(@"SELECT [Client].[id_client], [Client].[FIO] FROM [Client]");

            ViewBag.flagTypeRoom = true;
            ViewBag.Id_client = order.id_client;
            ViewBag.Name_client = (from p in clientFromDB where p.Id_client == order.id_client select p.FIO).First();


            ComplexModelClientAndServies list = new ComplexModelClientAndServies();

            /*
            List<Client> clientFromDB = FromDBClient(@"SELECT [Client].[id_client], [Client].[FIO] FROM [Client]");
            List<type_servies> TypeServiesFromDB = FromDBListTypeServiecs(@"SELECT * FROM [type_servies]");
            */

            //List<Client> clientFromDB = FromDB<Client>(@"SELECT [Client].[id_client], [Client].[FIO] FROM [Client]");
            List<type_servies> TypeServiesFromDB = FromDB<type_servies>(@"SELECT * FROM [type_servies]");

            //1
            //List<type_pool> TypePoolFromDB = FromDBTypePool(@"SELECT * FROM [type_pool]");
            List<type_pool> TypePoolFromDB = FromDB<type_pool>(@"SELECT * FROM [type_pool]");

            //2
            //List<nametyperoom> NameTypeRoomFromDB = FromDBNameTypeRoom(@"SELECT * FROM [nametyperoom]");
            List<nametyperoom> NameTypeRoomFromDB = FromDB<nametyperoom>(@"SELECT * FROM [nametyperoom]");

            //3
            //List<type_number> NumberFromDB = FromDBNumber<type_number>(@"SELECT * FROM [type_number]");
            List<type_number> NumberFromDB = FromDB<type_number>(@"SELECT * FROM [type_number] WHERE [type_number].[Free] = 1");

            //Список подзаказов номеров
            //List<list_number> listNumberOrder = FromDB<list_number>(@"SELECT * FROM [list_number] WHERE [list_number].[id_order] = " + ViewBag.IdOrder);
            //List<list_numberModifc> listNumberOrder = FromDB<list_numberModifc>(@"SELECT [type_number].[name] AS 'number_room', [list_number].[settlement_date], [list_number].[eviction_date], [type_pool].[type] AS 'type_room', [list_number].[price] FROM [list_number], [type_pool], [type_number] WHERE [list_number].[id_order] = " + ViewBag.IdOrder + " AND [list_number].[id_number_room] = [type_number].[id_number] AND [list_number].[id_type_room] = [type_pool].Id_pool GROUP BY [type_number].[name], [list_number].[settlement_date], [list_number].[eviction_date], [type_pool].[type], [list_number].[price]");
            List<list_numberModifc> listNumberOrder = FromDB<list_numberModifc>(@"SELECT CAST([type_number].[name] AS NVARCHAR(MAX)) AS 'number_room', [list_number].[settlement_date], [list_number].[eviction_date], CAST([type_pool].[type] AS NVARCHAR(MAX)) AS 'type_room', CAST([nametyperoom].[name] AS NVARCHAR(MAX)) AS 'col_in_room', CAST([list_number].[price] AS NVARCHAR(MAX)) AS 'price' FROM [list_number], [type_pool], [type_number], [nametyperoom] WHERE [list_number].[id_order] =  " + ViewBag.IdOrder + "  AND [list_number].[id_number_room] = [type_number].[id_number] AND [list_number].[id_type_room] = [type_pool].Id_pool AND [list_number].[id_col_in_room] = [nametyperoom].[Id] GROUP BY CAST([type_number].[name] AS NVARCHAR(MAX)), [list_number].[settlement_date], [list_number].[eviction_date], CAST([type_pool].[type] AS NVARCHAR(MAX)), CAST([nametyperoom].[name] AS NVARCHAR(MAX)), CAST([list_number].[price] AS NVARCHAR(MAX))");

            //Список услугов
            //List<list_add_services> listAddServiesOrder = FromDB<list_add_services>(@"SELECT * FROM [list_add_services] WHERE [list_add_services].[id_order] = " + ViewBag.IdOrder);
            List<list_add_serviecsModific> listAddServiesOrder = FromDB<list_add_serviecsModific>(@"SELECT [list_add_services].*, [type_servies].[name] AS name_servies FROM [list_add_services], [type_servies] WHERE [list_add_services].[id_order] = " + ViewBag.IdOrder + " AND [list_add_services].id_servies = [type_servies].[Id_servies] ");





            list.ListClient = clientFromDB;
            list.ListTypePool = TypePoolFromDB;
            list.ListNameTypeRoom = NameTypeRoomFromDB;
            list.ListNumber = NumberFromDB;

            list.ListTypeServies = TypeServiesFromDB;

            list.llll = listNumberOrder;
            list.add_llll = listAddServiesOrder;
            { }

            return View("Create", list);
        }

        public ActionResult Create()
        {
            ComplexModelClientAndServies list = new ComplexModelClientAndServies();
            list.ListClient = FromDB<Client>(@"SELECT [Client].[id_client], [Client].[FIO] FROM [Client]"); ;
            return View(list);
        }


        public ActionResult ChoiceClient(int Id_client)
        {
            int Id_client111 = Id_client;

            var date = DateTime.Now;
            { }
            //Создание новый заказ
            DataClasses1DataContext db = new DataClasses1DataContext();
            Orders item = new Orders()
            {
                id_client = Convert.ToInt32(Id_client111),
                date = DateTime.Now,
                Done = false,
                Hide = false
            };

            db.Orders.InsertOnSubmit(item);
            db.SubmitChanges();

            List<Orders> fff = FromDB<Orders>(@"SELECT [Orders].[Id_order] FROM [Orders]");
            string fff222 = fff.Select(it => it.Id_order).Max().ToString();
            ViewBag.IdOrder = fff222;



            ViewBag.flagTypeRoom = true;
            ViewBag.Id_client = Id_client111;

            ComplexModelClientAndServies list = new ComplexModelClientAndServies();

            /*
            List<Client> clientFromDB = FromDBClient(@"SELECT [Client].[id_client], [Client].[FIO] FROM [Client]");
            List<type_servies> TypeServiesFromDB = FromDBListTypeServiecs(@"SELECT * FROM [type_servies]");
            */

            List<Client> clientFromDB = FromDB<Client>(@"SELECT [Client].[id_client], [Client].[FIO] FROM [Client]");

            ViewBag.Name_client = (from p in clientFromDB where p.Id_client == Id_client111 select p.FIO).First();

            List<type_servies> TypeServiesFromDB = FromDB<type_servies>(@"SELECT * FROM [type_servies]");

            //1
            List<type_pool> TypePoolFromDB = FromDB<type_pool>(@"SELECT * FROM [type_pool]");
            ;
            //2
            List<nametyperoom> NameTypeRoomFromDB = FromDB<nametyperoom>(@"SELECT * FROM [nametyperoom]");

            //Список подзаказов номеров
            //List<list_number> listNumberOrder = FromDB<list_number>(@"SELECT * FROM [list_number] WHERE [list_number].[id_order] = " + ViewBag.IdOrder);
            //List<list_numberModifc> listNumberOrder = FromDB<list_numberModifc>(@"SELECT [type_number].[name] AS 'number_room', [list_number].[settlement_date], [list_number].[eviction_date], [type_pool].[type] AS 'type_room', [list_number].[price] FROM [list_number], [type_pool], [type_number] WHERE [list_number].[id_order] = " + ViewBag.IdOrder + " AND [list_number].[id_number_room] = [type_number].[id_number] AND [list_number].[id_type_room] = [type_pool].Id_pool GROUP BY [type_number].[name], [list_number].[settlement_date], [list_number].[eviction_date], [type_pool].[type], [list_number].[price]");
            List<list_numberModifc> listNumberOrder = FromDB<list_numberModifc>(@"SELECT CAST([type_number].[name] AS NVARCHAR(MAX)) AS 'number_room', [list_number].[settlement_date], [list_number].[eviction_date], CAST([type_pool].[type] AS NVARCHAR(MAX)) AS 'type_room', CAST([nametyperoom].[name] AS NVARCHAR(MAX)) AS 'col_in_room', CAST([list_number].[price] AS NVARCHAR(MAX)) AS 'price' FROM [list_number], [type_pool], [type_number], [nametyperoom] WHERE [list_number].[id_order] =  " + ViewBag.IdOrder + "  AND [list_number].[id_number_room] = [type_number].[id_number] AND [list_number].[id_type_room] = [type_pool].Id_pool AND [list_number].[id_col_in_room] = [nametyperoom].[Id] GROUP BY CAST([type_number].[name] AS NVARCHAR(MAX)), [list_number].[settlement_date], [list_number].[eviction_date], CAST([type_pool].[type] AS NVARCHAR(MAX)), CAST([nametyperoom].[name] AS NVARCHAR(MAX)), CAST([list_number].[price] AS NVARCHAR(MAX))");
            
            //Список услугов
            //List<list_add_services> listAddServiesOrder = FromDB<list_add_services>(@"SELECT * FROM [list_add_services] WHERE [list_add_services].[id_order] = " + ViewBag.IdOrder);
            List<list_add_serviecsModific> listAddServiesOrder = FromDB<list_add_serviecsModific>(@"SELECT [list_add_services].*, [type_servies].[name]  AS name_servies FROM [list_add_services], [type_servies] WHERE [list_add_services].[id_order] = '" + ViewBag.IdOrder + "' AND [list_add_services].[id_servies] = [type_servies].[Id_servies] ");


            list.ListClient = clientFromDB;
            list.ListTypePool = TypePoolFromDB;
            list.ListNameTypeRoom = NameTypeRoomFromDB;
            list.ListTypeServies = TypeServiesFromDB;

            list.llll = listNumberOrder;
            list.add_llll = listAddServiesOrder;





            return View("Create", list);
        }

        //public ActionResult ProcessingOrder(OrderAcceptModif order, int? IdOrder111 )
        public ActionResult ProcessingOrder(OrderServiesModific order, int? IdOrder111 )
        {


            ViewBag.IdOrder = IdOrder111;

            ComplexModelClientAndServies list = new ComplexModelClientAndServies();

            /*
            List<Client> clientFromDB = FromDBClient(@"SELECT [Client].[id_client], [Client].[FIO] FROM [Client]");
            List<type_servies> TypeServiesFromDB = FromDBListTypeServiecs(@"SELECT * FROM [type_servies]");
            */

            List<Client> clientFromDB = FromDB<Client>(@"SELECT [Client].[id_client], [Client].[FIO] FROM [Client]");

            ViewBag.Name_client = (from p in clientFromDB where p.Id_client == order.Id_client select p.FIO).First();

            List<type_servies> TypeServiesFromDB = FromDB<type_servies>(@"SELECT * FROM [type_servies]");

            //1
            List<type_pool> TypePoolFromDB = FromDB<type_pool>(@"SELECT * FROM [type_pool]");

            //2
            List<nametyperoom> NameTypeRoomFromDB = FromDB<nametyperoom>(@"SELECT * FROM [nametyperoom]");

            //Список подзаказов номеров
            //List<list_number> listNumberOrder = FromDB<list_number>(@"SELECT * FROM [list_number] WHERE [list_number].[id_order] = " + IdOrder111);
            //List<list_numberModifc> listNumberOrder = FromDB<list_numberModifc>(@"SELECT [type_number].[name] AS 'number_room', [list_number].[settlement_date], [list_number].[eviction_date], [type_pool].[type] AS 'type_room', [list_number].[price] FROM [list_number], [type_pool], [type_number] WHERE [list_number].[id_order] = " + ViewBag.IdOrder + " AND [list_number].[id_number_room] = [type_number].[id_number] AND [list_number].[id_type_room] = [type_pool].Id_pool GROUP BY [type_number].[name], [list_number].[settlement_date], [list_number].[eviction_date], [type_pool].[type], [list_number].[price]");
            //List<list_numberModifc> listNumberOrder = FromDB<list_numberModifc>(@"SELECT CAST([type_number].[name] AS NVARCHAR(MAX)) AS 'number_room', [list_number].[settlement_date], [list_number].[eviction_date], CAST([type_pool].[type] AS NVARCHAR(MAX)) AS 'type_room', CAST([nametyperoom].[name] AS NVARCHAR(MAX)), CAST([list_number].[price] AS NVARCHAR(MAX)) FROM [list_number], [type_pool], [type_number], [nametyperoom] WHERE [list_number].[id_order] =  " + ViewBag.IdOrder + "  AND [list_number].[id_number_room] = [type_number].[id_number] AND [list_number].[id_type_room] = [type_pool].Id_pool AND [list_number].[id_col_in_room] = [nametyperoom].[Id] GROUP BY CAST([type_number].[name] AS NVARCHAR(MAX)), [list_number].[settlement_date], [list_number].[eviction_date], CAST([type_pool].[type] AS NVARCHAR(MAX)), CAST([nametyperoom].[name] AS NVARCHAR(MAX)), CAST([list_number].[price] AS NVARCHAR(MAX))");
            List<list_numberModifc> listNumberOrder = FromDB<list_numberModifc>(@"SELECT CAST([type_number].[name] AS NVARCHAR(MAX)) AS 'number_room', [list_number].[settlement_date], [list_number].[eviction_date], CAST([type_pool].[type] AS NVARCHAR(MAX)) AS 'type_room', CAST([nametyperoom].[name] AS NVARCHAR(MAX)) AS 'col_in_room', CAST([list_number].[price] AS NVARCHAR(MAX)) AS 'price' FROM [list_number], [type_pool], [type_number], [nametyperoom] WHERE [list_number].[id_order] =  " + ViewBag.IdOrder + "  AND [list_number].[id_number_room] = [type_number].[id_number] AND [list_number].[id_type_room] = [type_pool].Id_pool AND [list_number].[id_col_in_room] = [nametyperoom].[Id] GROUP BY CAST([type_number].[name] AS NVARCHAR(MAX)), [list_number].[settlement_date], [list_number].[eviction_date], CAST([type_pool].[type] AS NVARCHAR(MAX)), CAST([nametyperoom].[name] AS NVARCHAR(MAX)), CAST([list_number].[price] AS NVARCHAR(MAX))");

            //Список услугов
            //List<list_add_services> listAddServiesOrder = FromDB<list_add_services>(@"SELECT * FROM [list_add_services] WHERE [list_add_services].[id_order] = " + IdOrder111);
            List<list_add_serviecsModific> listAddServiesOrder = FromDB<list_add_serviecsModific>(@"SELECT [list_add_services].*, [type_servies].[name]  AS name_servies FROM [list_add_services], [type_servies] WHERE [list_add_services].[id_order] = " + IdOrder111 + " AND [list_add_services].id_servies = [type_servies].[Id_servies] ");

            list.ListClient = clientFromDB;
            list.ListTypePool = TypePoolFromDB;
            list.ListNameTypeRoom = NameTypeRoomFromDB;

            list.ListTypeServies = TypeServiesFromDB;
            list.llll = listNumberOrder;
            list.add_llll = listAddServiesOrder;

            if (order.Id_client != null)
            {
                ViewBag.flagTypeRoom = true;
                ViewBag.Id_client = order.Id_client;

                ViewBag.Name_client = (from p in clientFromDB where p.Id_client == order.Id_client select p.FIO).First();
            }


            if (order.Id_pool != null)
            {
                ViewBag.flagColMest = true;
                ViewBag.Id_pool = order.Id_pool;
            }

            if (order.Id != null)
            {
                ViewBag.flagNumber = true;
                ViewBag.Id = order.Id;

                //3
                //List<type_number> NumberFromDB = FromDBNumber<type_number>(@"SELECT * FROM [type_number] WHERE [type_number].[id_pool] = " + Id);
                //List<type_number> NumberFromDB = FromDB<type_number>(@"SELECT * FROM [type_number] WHERE [type_number].[id_pool] = " + order.Id_pool + " AND [type_number].[col]=" + order.Id);
                List<type_number> NumberFromDB = FromDB<type_number>(@"SELECT * FROM [type_number] WHERE [type_number].[id_pool] = " + order.Id_pool + " AND [type_number].[col]=" + order.Id + " AND [type_number].[Free] = '1'");
                list.ListNumber = NumberFromDB;
                //return View("Create", list);
            }

            if (order.Id_number != null)
            {
                /*
                ViewBag.flagCol = true;
                ViewBag.Col = order.col;
                */
                ViewBag.flagDateBegin = true;
                ViewBag.Begin = order.begin_date;
            }

            /*
            if (order.col != null)
            {
                ViewBag.flagBegin = true;
                ViewBag.Begin = order.begin_date;
            }
            */

            if (order.begin_date != null)
            {
                /*
                ViewBag.flagDateBegin = true;
                ViewBag.DateBegin = order.begin_date;
                */
                ViewBag.flagTimeBegin = true;
                ViewBag.TimeBegin = order.begin_date.Value.TimeOfDay;
            }

            if (order.begin_time != null)
            {
                ViewBag.flagDateEnd = true;
                ViewBag.DateEnd = order.end_date;

                order.begin_date = new DateTime(order.begin_date.Value.Year, order.begin_date.Value.Month, order.begin_date.Value.Day, order.begin_time.Value.Hour, order.begin_time.Value.Minute, order.begin_time.Value.Second);
            }

            if (order.end_date != null)
            {
                ViewBag.flagTimeEnd = true;
                ViewBag.TimeEnd = order.end_time;
            }


            int price;
            int tariff;

            if (order.end_time != null)
            {
                order.end_date = new DateTime(order.end_date.Value.Year, order.end_date.Value.Month, order.end_date.Value.Day, order.end_time.Value.Hour, order.end_time.Value.Minute, order.end_time.Value.Second);

                //Тип комнаты
                var ddd333 = Type_Room.Where(el => el.Id_pool == order.Id_pool).FirstOrDefault();


                tariff = Convert.ToInt32(ddd333.tariff);
                var fff = Type_Room;
                { }

                //Количество человека

                //Дней
                DateTime data1 = Convert.ToDateTime(order.begin_date);
                DateTime data2 = Convert.ToDateTime(order.end_date);

                if (data2 > data1)
                {
                    order.begin_date = data2;
                    order.end_date = data1;
                }


                var date5 = data2 - data1;
                int day = date5.Days;
                if (day == 0) day = 1;
                // int day = order.end_date - order.begin_date;

                ViewBag.flagPrice = true;
                ViewBag.Price = tariff * day;

                order.price = tariff * day;

                ViewBag.flagSmallButton = true;
            }

            // приянть подзаказы
            if (Request.Form["submitbutton21"] != null)
            {


                DataClasses1DataContext db = new DataClasses1DataContext();

                var item = new list_number()
                {
                    id_order = Convert.ToInt32(IdOrder111),
                    id_type_room = Convert.ToInt32(order.Id_pool),
                    id_col_in_room = Convert.ToInt32(order.Id),
                    id_number_room = Convert.ToInt32(order.Id_number),
                    settlement_date = Convert.ToDateTime(order.begin_date),
                    eviction_date = Convert.ToDateTime(order.end_date),
                    price = Convert.ToInt32(order.price)
                };


                { }
                db.list_number.InsertOnSubmit(item);
                db.SubmitChanges();

                type_number item22 = db.type_number.Single(e => e.Id_number == order.Id_number);


                //if (item22.Free) item22.Free = false;

                var item2 = new type_number()
                {
                    id_pool = order.Id_number,
                    Free = !item22.Free
                };

                //!!****!!!!      db.SubmitChanges();




                { }



                //ViewBag.flagTypeRoom = false;
                ViewBag.flagColMest = false;
                ViewBag.flagNumber = false;
                ViewBag.flagCol = false;
                ViewBag.flagDateBegin = false;
                ViewBag.flagTimeBegin = false;
                ViewBag.flagDateEnd = false;
                ViewBag.flagTimeEnd = false;
                ViewBag.flagPrice = false;
                ViewBag.flagSmallButton = false;

                //ViewBag.Id_client = null;
                //ViewBag.Name_client = null;
                ViewBag.Id_pool = null;
                ViewBag.Id_number = null;
                ViewBag.Col = null;
                ViewBag.DateBegin = null;
                ViewBag.TimeBegin = null;
                ViewBag.DateEnd = null;
                ViewBag.TimeEnd = null;
                ViewBag.Price = null;



                //listNumberOrder = FromDB<list_numberModifc>(@"SELECT [type_number].[name] AS 'number_room', [list_number].[settlement_date], [list_number].[eviction_date], [type_pool].[type] AS 'type_room', [list_number].[price] FROM [list_number], [type_pool], [type_number] WHERE [list_number].[id_order] = " + IdOrder111 + " AND [list_number].[id_number_room] = [type_number].[id_number] AND [list_number].[id_type_room] = [type_pool].Id_pool GROUP BY [type_number].[name], [list_number].[settlement_date], [list_number].[eviction_date], [type_pool].[type], [list_number].[price]");
                //listNumberOrder = FromDB<list_numberModifc>(@"SELECT CAST([type_number].[name] AS NVARCHAR(MAX)) AS 'number_room', [list_number].[settlement_date], [list_number].[eviction_date], CAST([type_pool].[type] AS NVARCHAR(MAX)) AS 'type_room', CAST([nametyperoom].[name] AS NVARCHAR(MAX)), CAST([list_number].[price] AS NVARCHAR(MAX)) AS 'price' FROM [list_number], [type_pool], [type_number], [nametyperoom] WHERE [list_number].[id_order] = " + IdOrder111 + " AND [list_number].[id_number_room] = [type_number].[id_number] AND [list_number].[id_type_room] = [type_pool].Id_pool AND [list_number].[id_col_in_room] = [nametyperoom].[Id] GROUP BY CAST([type_number].[name] AS NVARCHAR(MAX)), [list_number].[settlement_date], [list_number].[eviction_date], CAST([type_pool].[type] AS NVARCHAR(MAX)), CAST([nametyperoom].[name] AS NVARCHAR(MAX)), CAST([list_number].[price] AS NVARCHAR(MAX))");
                listNumberOrder = FromDB<list_numberModifc>(@"SELECT CAST([type_number].[name] AS NVARCHAR(MAX)) AS 'number_room', [list_number].[settlement_date], [list_number].[eviction_date], CAST([type_pool].[type] AS NVARCHAR(MAX)) AS 'type_room', CAST([nametyperoom].[name] AS NVARCHAR(MAX)) AS 'col_in_room', CAST([list_number].[price] AS NVARCHAR(MAX)) AS 'price' FROM [list_number], [type_pool], [type_number], [nametyperoom] WHERE [list_number].[id_order] =  " + IdOrder111 + "  AND [list_number].[id_number_room] = [type_number].[id_number] AND [list_number].[id_type_room] = [type_pool].Id_pool AND [list_number].[id_col_in_room] = [nametyperoom].[Id] GROUP BY CAST([type_number].[name] AS NVARCHAR(MAX)), [list_number].[settlement_date], [list_number].[eviction_date], CAST([type_pool].[type] AS NVARCHAR(MAX)), CAST([nametyperoom].[name] AS NVARCHAR(MAX)), CAST([list_number].[price] AS NVARCHAR(MAX))");
                list.llll = listNumberOrder;

                //Список услугов
                //listAddServiesOrder = FromDB<list_add_services>(@"SELECT * FROM [list_add_services] WHERE [list_add_services].[id_order] = " + IdOrder111);
                listAddServiesOrder = FromDB<list_add_serviecsModific>(@"SELECT [list_add_services].*, [type_servies].[name] AS name_servies FROM [list_add_services], [type_servies] WHERE [list_add_services].[id_order] = " + IdOrder111 + " AND [list_add_services].id_servies = [type_servies].[Id_servies] ");

                list.add_llll = listAddServiesOrder;

                //order = null;

                order.Id_pool = null;
                order.Id = null;
                order.Id_number = null;

                ViewBag.Titles = " --- Виберите --- ";

                int priceAllOrder = FromDBOne(@"SELECT SUM([list_number].[price]) FROM [list_number] WHERE [list_number].[id_order] =" + IdOrder111);
                int priceAllServiecs = FromDBOne(@"SELECT SUM([list_add_services].[price]) FROM [list_add_services] WHERE [list_add_services].[id_order] = " + IdOrder111);

                list.BigPrice = priceAllOrder + priceAllServiecs;
                ViewBag.BigPrice = priceAllOrder + priceAllServiecs;

                return View("Create", list);
            }

            //принять дпо. услуги
            if (order.id_servies != null)
            {
                ViewBag.flagServiesDate = true;
                ViewBag.IDServies = order.id_servies;
            }

            if (order.dateUse != null)
            {
                ViewBag.flagTimeUse = true;
                ViewBag.dateUse = order.dateUse;
            }

            if (order.timeUse != null)
            {
                ViewBag.flagColUse = true;
                ViewBag.timeUse = order.timeUse;
                order.dateUse = new DateTime(order.dateUse.Value.Year, order.dateUse.Value.Month, order.dateUse.Value.Day, order.timeUse.Value.Hour, order.timeUse.Value.Minute, order.timeUse.Value.Second);
            }

            if (order.colServ != null)
            {
                ViewBag.flagPriceServies = true;
                ViewBag.flagServiesButton = true;

                ViewBag.ColUse = order.colServ;

                var ttt = list.ListTypeServies;

                //                var ddd333 = Type_Room.Where(el => el.Id_pool == order.Id_pool).FirstOrDefault();
                var temp = ttt.Where(el => el.Id_servies == order.id_servies).FirstOrDefault();
                int tarrif = Convert.ToInt32(temp.tariff);

                order.priceServies = order.colServ * tarrif;
                ViewBag.PriceServies = order.priceServies;
            }

            
            // полній заказ с услугами
            if (Request.Form["submitbuttonServies"] != null)
            {
                

                var fff = order;

                DataClasses1DataContext db = new DataClasses1DataContext();

                //DateTime dtm = new DateTime(order.dateUse.Value.Year, order.dateUse.Value.Month, order.dateUse.Value.Day, order.timeUse.Value.Hour, order.timeUse.Value.Minute, order.timeUse.Value.Second); 

                list_add_services item = new list_add_services()
                {
                    id_order = Convert.ToInt32(IdOrder111),
                    id_servies = Convert.ToInt32(order.id_servies),
                    DateUse = Convert.ToDateTime(order.dateUse),
                    col = order.colServ,
                    price = order.priceServies
                };


                { }
                db.list_add_services.InsertOnSubmit(item);
                db.SubmitChanges();



                ViewBag.flagServiesDate = false;
                ViewBag.flagTimeUse = false;
                ViewBag.flagColUse = false;
                ViewBag.flagPriceServies = false;
                ViewBag.flagServiesButton = false;

                ViewBag.IDServies = null;
                ViewBag.ServiesDate = null;
                ViewBag.TimeUse = null;
                ViewBag.ColUse = null;
                ViewBag.PriceServies = null;

                list.add_llll = FromDB<list_add_serviecsModific>(@"SELECT [list_add_services].*, [type_servies].[name]  AS name_servies FROM [list_add_services], [type_servies] WHERE [list_add_services].[id_order] = " + ViewBag.IdOrder + " AND [list_add_services].id_servies = [type_servies].[Id_servies] "); ;
                //return View("Index");
                order.id_servies = null;

                int priceAllOrder = FromDBOne(@"SELECT SUM([list_number].[price]) FROM [list_number] WHERE [list_number].[id_order] =" + IdOrder111);
                int priceAllServiecs = FromDBOne(@"SELECT SUM([list_add_services].[price]) FROM [list_add_services] WHERE [list_add_services].[id_order] = " + IdOrder111);

                list.BigPrice = priceAllOrder + priceAllServiecs;
                ViewBag.BigPrice = priceAllOrder + priceAllServiecs;
            }

           
            { }

            if (Request.Form["submitbuttonBigOrder"] != null)
            {
                
                int BigPrice = list.BigPrice;

                DataClasses1DataContext db = new DataClasses1DataContext();

                

                List<DateTime> trempDateTime = new List<DateTime>();

                if (list.llll.Count != 0)
                {
                    foreach (var item in list.llll)
                    {
                        trempDateTime.Add(item.settlement_date);
                        trempDateTime.Add(item.eviction_date);
                    }

                    DateTime minDate = DateTime.MaxValue;
                    DateTime maxDate = DateTime.MinValue;

                    foreach (DateTime dateString in trempDateTime)
                    {
                        DateTime date = dateString;
                        if (date < minDate)
                            minDate = date;
                        if (date > maxDate)
                            maxDate = date;
                    }

                    int priceAllOrder = FromDBOne(@"SELECT SUM([list_number].[price]) FROM [list_number] WHERE [list_number].[id_order] =" + IdOrder111);
                    int priceAllServiecs = FromDBOne(@"SELECT SUM([list_add_services].[price]) FROM [list_add_services] WHERE [list_add_services].[id_order] = " + IdOrder111);

                    //list.BigPrice = priceAllOrder + priceAllServiecs;
                    int bigPriceeee = priceAllOrder + priceAllServiecs;



                    Orders item22 = db.Orders.Single(e => e.Id_order == IdOrder111);

                    item22.payment = order.payment;
                    item22.begin = minDate;
                    item22.end = maxDate;
                    item22.BigPrice = bigPriceeee;
                }
                else
                {
                    Orders item22 = db.Orders.Single(e => e.Id_order == IdOrder111);
                    item22.begin = null;
                    item22.end = null;
                }

                db.SubmitChanges();




                db = new DataClasses1DataContext();

                List<Order> orders = new List<Order>();
                List<list_add_services> servies = new List<list_add_services>();

                orders = db.ExecuteQuery<Order>(@"SELECT * FROM Orders").ToList<Order>();
                var ttt = db.ExecuteQuery<OrderModific>(@"SELECT [Orders].[Id_order], [Orders].[date], [Orders].[begin], [Orders].[end], [Orders].[payment], [Orders].[BigPrice],[Client].[FIO] FROM [Orders], [Client] WHERE Orders.id_client = Client.Id_client;").ToList<OrderModific>();

                //return View("ShowOrder", ttt);
                return Redirect("/Home/Index");
                
            }

            return View("Create", list);

        }

        



        public ActionResult AddSusseced(Client client)
        {
            return View();
        }

        public ActionResult Report()
        {

            return View();
        }

        public ActionResult ReportRaschet(int fromTime, int ToTime)
        {

            return View();
        }

        public ActionResult ShowOrder()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();

            //Очистка Null
            SerachClearNull(db, "SELECT * FROM [Orders] WHERE [Orders].[begin] IS NULL");
            /*
            SerachClearNull(db, "SELECT * FROM [Orders] WHERE [Orders].[end] IS NULL");
            SerachClearNull(db, "SELECT * FROM [Orders] WHERE [Orders].[payment] IS NULL");
            SerachClearNull(db, "SELECT * FROM [Orders] WHERE [Orders].[BigPrice] IS NULL");
            */
            //Поулчить список
            List<list_add_services> servies = new List<list_add_services>();
            List<Order> orders = new List<Order>();

            //orders = db.ExecuteQuery<Order>(@"SELECT * FROM Orders").ToList<Order>();
            var ttt = db.ExecuteQuery<OrderModific>(@"SELECT [Orders].[Id_order], [Orders].[date], [Orders].[begin], [Orders].[end], [Orders].[payment], [Orders].[BigPrice],[Client].[FIO] FROM [Orders], [Client] WHERE Orders.id_client = Client.Id_client AND [Orders].[Done] = 'false'").ToList<OrderModific>();



            return View(ttt);
        }

        private static void SerachClearNull(DataClasses1DataContext db, string query)
        {
            var orders111Begin = db.ExecuteQuery<OrderModific>(query).ToList<OrderModific>();

            foreach (var elem in orders111Begin)
            {
                var item = db.Orders.Single(e => e.Id_order == elem.id_order);

                db.Orders.DeleteOnSubmit(item);
                db.SubmitChanges();
            }
        }

        public ActionResult CreateClient()
        {
            return View();
        }

        public ActionResult AddClient(ClientModif client)
        {
            if (!ModelState.IsValid)
                return View("CreateClient");
            else
            {
                DataClasses1DataContext db = new DataClasses1DataContext();
                Client item = new Client
                {
                    FIO = client.FIO,
                    birthday = client.birthday,
                    address = client.address,
                    identif = client.identif,
                    passport = client.passport,
                    phone = client.phone,
                    pol = client.pol
                };

                db.Client.InsertOnSubmit(item);
                db.SubmitChanges();

                return View("Index");
            }
        }

        public ActionResult Input()
        {
            return View();
        }

        public ActionResult AddInput(Client client)
        {
            if (!ModelState.IsValid)
                return View("Input");
            else
            {

                return View("Index");
            }
        }

        public ActionResult Hide(int id)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();

            var item = db.Orders.Single(e => e.Id_order == id);

            item.Done = true;

            db.SubmitChanges();

            return View("Index");
        }

        public ActionResult PaymentTrue(int? idOrder111)
        {
            return View("Index");
        }
        
        private List<T> FromDB<T>(string query)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            var typeservies = db.ExecuteQuery<T>(query).ToList<T>();

            return typeservies;
        }

        private int FromDBOne(string query)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            var typeservies = db.ExecuteQuery<int?>(query).First<int?>();
            if (typeservies == null) typeservies = 0;

            return Convert.ToInt32(typeservies);
        }
        

        private string FromDBID<T>(string query)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            string id = db.ExecuteQuery<T>(query).First().ToString();
              
            return id;
        }

        private ComplexModelClientAndServies UpDateData()
        {
            ComplexModelClientAndServies BigList = new ComplexModelClientAndServies();

            return BigList;
        }
    }
}
