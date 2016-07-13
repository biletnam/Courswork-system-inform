using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class list_add_serviecsModific
    {
        public int Id_list_add_services { get; set; }
        public int? id_order { get; set; }
        public string name_servies { get; set; }
        public DateTime? DateUse { get; set; }
        public int? col { get; set; }
        public int? price { get; set; }
    }
}