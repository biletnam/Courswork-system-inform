using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class OrderAccept
    {

        public int? id_OrderAccept { get; set; }

        public int? Id_client { get; set; }
        public int? Id_pool { get; set; }
        public int? Id { get; set; }
        public int? Id_number { get; set; }
        public int? col { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{12:00 yyyy-MM-dd}")]
        public DateTime? begin_date { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{yyyy-MM-dd}")]
        public DateTime? end_date { get; set; }

        public bool? payment { get; set; }
        public int? id_list_add_servies { get; set; }
    }
}