using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class InputController : Controller
    {
        //
        // GET: /Input/

        public ActionResult Index(int IdOrder)
        {
            ViewBag.IdOrder = IdOrder;

            List<type_servies> fff = FromDB<type_servies>("SELECT * FROM [type_servies]");

            return View(fff);
        }

        public ActionResult InputSevies(ListServies serv)
        { 
            return View();
        }

        private List<T> FromDB<T>(string query)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            var typeservies = db.ExecuteQuery<T>(query).ToList<T>();

            return typeservies;
        }
    }
}