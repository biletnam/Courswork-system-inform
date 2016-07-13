using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class TariffController : Controller
    {
        //
        // GET: /Tariff/
        public TariffController()
        {
            ViewBag.OpenEditServiec = false;
            ViewBag.OpenEditRoom = false;
            
            ViewBag.OpenEditServiecId = null;
            ViewBag.OpenEditRoomId = null;

            ViewBag.OpenEditServiesValue = null;
            ViewBag.OpenEditRoomValue = null;
        }

        public ActionResult CreateTariff()
        {
            return View(ListDate());
        }

        private ComplexRoomsAndServiecs ListDate()
        {
            ComplexRoomsAndServiecs list = new ComplexRoomsAndServiecs();

            List<type_pool> TypeRoomFromDB = FromDB<type_pool>(@"SELECT * FROM [type_pool]");
            List<type_servies> TypeServiecFromDB = FromDB<type_servies>(@"SELECT * FROM [type_servies]");

            list.ListRoom = TypeRoomFromDB;
            list.ListServies = TypeServiecFromDB;
            return list;
        }

        public ActionResult EditServiecTariff(int id_serviec, int price)
        {
            ViewBag.OpenEditServiec = true;
            ViewBag.OpenEditServiecId = id_serviec;
            ViewBag.OpenEditServiesValue = price;

            return View("CreateTariff", ListDate());
        }

        public ActionResult EditRoomTariff(int Id_pool, int price)
        {
            ViewBag.OpenEditRoom = true;
            ViewBag.OpenEditRoomId = Id_pool;
            ViewBag.OpenEditRoomValue = price;

            return View("CreateTariff", ListDate());
        }

        public ActionResult EditServies1111(TypeServies serviec)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            type_servies item = db.type_servies.Single(e => e.Id_servies == serviec.id);
            item.tariff = serviec.tariff;
            db.SubmitChanges();
            return View("CreateTariff", ListDate());
        }

        public ActionResult EditRoom(type_pool room)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            type_pool item = db.type_pool.Single(e => e.Id_pool == room.Id_pool);
            item.tariff = room.tariff;
            db.SubmitChanges();
            return View("CreateTariff", ListDate());
        }

        private List<T> FromDB<T>(string query)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            var typeservies = db.ExecuteQuery<T>(query).ToList<T>();

            return typeservies;
        }
    }
}
