using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models.ForReport
{
    public class ComplexModels
    {
        //List
        public List<type_servies> listServiecs { get; set; }    // Список имен услуги с тарифом
        public List<type_pool> listNumber { get; set; }         // Список типов номера с тарифом
        public List<Orders> listOrders { get; set; }            // Список заказов
        public List<Client> listClient { get; set; }            // Список заказов

        public List<MvcApplication1.Client> listClientConst { get; set; }       // Список постоянных клиентов
        public List<MvcApplication1.Client> listClientNotPayment { get; set; }  // Список уклоняющих клиентов



        //Digital
        public int GeneralOrdersCount { get; set; }             // Количетсво общих заказов
        public int GeneralOrdersSum { get; set; }               // Сумма общих заказов
        public int? CurrentOrdersCount { get; set; }            // Количество текущих заказов
        public int? CurrentOrdersSum { get; set; }              // Сумма текущих заказов
        public int? EndOrdersCount { get; set; }                // Количество завершающих заказов
        public int? EndOrdersSum { get; set; }                  // Сумма завершающих заказов
        public int? OrdersCountNotPayment { get; set; }         // Количество неоплачиваемых
        public int? OrdersSumNotPayment { get; set; }           // Сумма неоплачиваемых
        public int? OrdersCountPayment { get; set; }            // Количество оплачиваемых
        public int? OrdersSumPayment { get; set; }              // Сумма оплачиваемых

        public int? ServiecsOnInOrderCount { get; set; }        // Предоставили услуг в заказе
        public int? GeneralServiecs { get; set; }               // Общий количество услуг
        public int? ServiecsSum { get; set; }                   // Сумма всего услуг

        public int? ClientCount { get; set; }                   // Количество регистрационных клиентов
        public int? ClientConstCount { get; set; }              // "Постоянные" клиенты (5 и более заказов): 
        public int? ClientNotPaymentCount { get; set; }                   // Клиенты-халявчики

    }
}