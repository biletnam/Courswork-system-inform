using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class Order
    {
        public int id_order { get; set; }

        [DisplayName("Дата добавления")]
        public DateTime? date { get; set; }

        [Required(ErrorMessage = "Укажите дату корректно")]
        [DisplayName("Начало заказа")]
        public DateTime? begin { get; set; }

        [Required(ErrorMessage = "Укажите дату корректно")]
        [DisplayName("Конец заказа")]
        public DateTime? end { get; set; }

        [DisplayName("Оплата")]
        public bool? payment { get; set; }

        [ScaffoldColumn(false)]
        [DisplayName("id_client")]
        public int id_client { get; set; }

        [ScaffoldColumn(false)]
        [DisplayName("id_number")]
        public int? id_number { get; set; }

        [ScaffoldColumn(false)]
        [DisplayName("id_list_add_servies")]
        public int? id_list_add_servies { get; set; }
    }
}