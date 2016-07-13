using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class OrderAndServies
    {
        //Заказ
        public OrderModific order { get; set; }

        //Список номеров
        public List<list_add_serviecsModific> ListServirecs { get; set; }

        //Список услугов
        public List<list_numberModifc> ListNumber { get; set; }
        //public List<list_number> ListNumber { get; set; }

    }
}