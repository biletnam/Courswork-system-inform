using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class ExpController : Controller
    {
        //
        // GET: /Exp/

        public ActionResult Exp()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();

            List<Order> orders = new List<Order>();
            List<list_add_services> servies = new List<list_add_services>();

            orders = db.ExecuteQuery<Order>(@"SELECT * FROM Orders").ToList<Order>();


            var ttt = db.ExecuteQuery<OrderModific>(@"SELECT [Orders].[Id_order], [Orders].[date], [Orders].[begin], [Orders].[end], [Client].[FIO] FROM [Orders], [Client] WHERE Orders.id_client = Client.Id_client;").ToList<OrderModific>();



            return View(ttt);
        }
        

        public ActionResult Details(int id)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();

            OrderAndServies orderservies = new OrderAndServies();
            List<ListServiesModif> listServies = new List<ListServiesModif>();
            

            /*
            List<list_add_services> servies = new List<list_add_services>();

            //var order = db.Orders.Where(item => item.Id_order == id);
              var order = db.ExecuteQuery<Order>(@"SELECT * FROM Orders WHERE Id_order = " + id + ";");
              Order ddd = order.First();
            */

            var ttt = db.ExecuteQuery<OrderModific>(@"SELECT [Orders].[Id_order], [Orders].[date], [Orders].[begin], [Orders].[end], [Client].[FIO] FROM [Orders], [Client] WHERE Orders.Id_order = '" + id + "'  AND Orders.id_client = Client.Id_client;").ToList<OrderModific>().First();

            //listServies = db.ExecuteQuery<ListServiesModif>(@"SELECT CAST([list_add_services].[Id_list_add_services] AS NVARCHAR(100)),	CAST([list_add_services].[id_order] AS NVARCHAR(100)),	CAST([type_servies].[name] AS NVARCHAR(100)) FROM [list_add_services], [type_servies], [Orders] WHERE [list_add_services].[id_servies] = [type_servies].[Id_servies] AND [list_add_services].[id_order] = '" + id + "'GROUP BY 	CAST([list_add_services].[Id_list_add_services] AS NVARCHAR(100)), CAST([list_add_services].[Id_order] AS NVARCHAR(100)), CAST([type_servies].[name] AS NVARCHAR(100));").ToList<ListServiesModif>();
            
            //listServies = db.ExecuteQuery<ListServiesModif>(@"SELECT CAST([list_add_services].[Id_list_add_services] AS NVARCHAR(100)),	CAST([list_add_services].[id_order] AS NVARCHAR(100)),	CAST([type_servies].[name] AS NVARCHAR(100)) FROM [list_add_services], [type_servies], [Orders] WHERE [list_add_services].[id_servies] = [type_servies].[Id_servies] AND [list_add_services].[id_order] = '" + id + "'GROUP BY 	CAST([list_add_services].[Id_list_add_services] AS NVARCHAR(100)), CAST([list_add_services].[Id_order] AS NVARCHAR(100)), CAST([type_servies].[name] AS NVARCHAR(100));").ToList<ListServiesModif>();

            //listServies = db.ExecuteQuery<ListServiesModif>(@"SELECT [list_add_services].[Id_list_add_services], [list_add_services].[id_order],	CAST([type_servies].[name] AS NVARCHAR(100)) AS 'name' FROM [list_add_services], [type_servies], [Orders] WHERE [list_add_services].[id_servies] = [type_servies].[Id_servies] AND [list_add_services].[id_order] = '" + id + "' GROUP BY [list_add_services].[Id_list_add_services],	[list_add_services].[Id_order],	CAST([type_servies].[name] AS NVARCHAR(100));").ToList<ListServiesModif>();

            /*
            orderservies.order = ttt;
            orderservies.ListServirecs = listServies;
            */
            return View(orderservies);
        }
        
    }
}
