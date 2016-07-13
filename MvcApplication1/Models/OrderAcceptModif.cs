using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class OrderAcceptModif
    {
        [ScaffoldColumn(false)]
        [DisplayName("id_OrderAccept")]
        public int? id_OrderAccept { get; set; }

        [ScaffoldColumn(false)]
        [DisplayName("id_OrderAccept")]
        public int? Id_client { get; set; }

        [ScaffoldColumn(false)]
        [DisplayName("id_OrderAccept")]
        public int? Id_pool { get; set; }

        [ScaffoldColumn(false)]
        [DisplayName("id_OrderAccept")]
        public int? Id { get; set; }

        [ScaffoldColumn(false)]
        [DisplayName("id_OrderAccept")]
        public int? Id_number { get; set; }

        [ScaffoldColumn(false)]
        [DisplayName("id_OrderAccept")]
        public int? col { get; set; }

        [Required(ErrorMessage = "Укажите дату заселения")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DisplayName("begin_date")]
        public DateTime? begin_date { get; set; }

        [Required(ErrorMessage = "Чтоб принять время, необходимо нажимать два раза левой кнопкой мыши")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "0")]
        public DateTime? begin_time { get; set; }

        [Required(ErrorMessage = "Укажите дату выселения")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DisplayName("end_date")]
        public DateTime? end_date { get; set; }

        [Required(ErrorMessage = "Чтоб принять время, необходимо нажимать два раза левой кнопкой мыши")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:hh:mm tt}")]
        public DateTime? end_time { get; set; }

        [DisplayName("payment")]
        public bool? payment { get; set; }

        [DisplayName("price")]
        public int? price { get; set; }

        [ScaffoldColumn(false)]
        [DisplayName("id_OrderAccept")]
        public int? id_list_add_servies { get; set; }
    }

    //int? Id_client, int? Id_pool, int? Id, int? Id_number, int? col
}