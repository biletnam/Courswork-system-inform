using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class OrderOperationController : Controller
    {
        //
        // GET: /OrderOperation/
        ComplexModelClientAndServies Complexlist = new ComplexModelClientAndServies();

        public OrderOperationController()
        {
            //Заказ
            //Тип комнаты
            ViewBag.flagTypeRoom = false;

            //

        }

        public ActionResult CreateOrder()
        {
            Complexlist.ListClient = FromDB<Client>("SELECT * FROM [Client]");
            return View(Complexlist);
        }

        public ActionResult ProcessingOrder(Order order)
        {
            Complexlist.ListClient = FromDB<Client>("SELECT * FROM [Client]");

            //Клиенты
            if (order.id_client == null)
            {
                ViewBag.flagTypeRoom = true;
                ViewBag.Id_client = order.id_client;
                ViewBag.NameClient = (from p in Complexlist.ListClient where p.Id_client == order.id_client select p.FIO).First();
            }

            if (ViewBag.flagTypeRoom)
            {
                //Тип комнаты
                Complexlist.ListTypePool = FromDB<type_pool>("SELECT * FROM [type_pool]");
            }
            



            return View("CreateOrder", Complexlist);
        }

        private List<T> FromDB<T>(string query)
        {
            return new DataClasses1DataContext().ExecuteQuery<T>(query).ToList<T>();
        }
    }
}
