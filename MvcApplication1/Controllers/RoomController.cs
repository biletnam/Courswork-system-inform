using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class RoomController : Controller
    {
        //
        // GET: /Room/

        public ActionResult ListRoom()
        {
            ComplexModelClientAndServies list = new ComplexModelClientAndServies();

            //List<TypeNumberModifString> roomFromDB = FromDB<TypeNumberModifString>(@"SELECT [type_number].[Id_number] AS nn, [type_number].[name], [type_number].[col], [type_pool].[type], [type_number].[Free] FROM [type_number], [type_pool] WHERE [type_number].[id_pool] = [type_pool].[Id_pool]");

            List<TypeNumberModifString> roomFromDB = FromDB<TypeNumberModifString>(@"SELECT [type_number].[Id_number] AS nn, [type_number].[name], [type_number].[col], [type_pool].[type], [type_number].[Free] FROM [type_number], [type_pool] WHERE [type_number].[id_pool] = [type_pool].[Id_pool]");

            return View(roomFromDB);
        }

        private List<T> FromDB<T>(string query)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            var typeservies = db.ExecuteQuery<T>(query).ToList<T>();

            return typeservies;
        }
    }
}
