using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class OrderModific
    {
        public int id_order { get; set; }
        public DateTime? date { get; set; }
        public DateTime? begin { get; set; }
        public DateTime? end { get; set; }
        //public bool? payment { set { if (value == null) value = false; } }
        //public bool? payment = false;
        public bool payment = false;
        public string FIO { get; set; }
        public int? id_number { get; set; }
        public int? id_list_add_servies { get; set; }

        public int? BigPrice { get; set; }

        public bool? done { get; set; }
        public bool? hide { get; set; }


    }
}