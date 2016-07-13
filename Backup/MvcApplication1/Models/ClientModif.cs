using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class ClientModif
    {
        [ScaffoldColumn(false)]
        [DisplayName("Id:")]
        public int id { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите свое ФИО")]
        [DisplayName("ФИО:")]
        public string FIO { get; set; }

        /*
        [Required(ErrorMessage = "Пожалуйста, укажите дата Вашего рождения")]
        [DisplayName("Дата рождения:")]
        public DateTime birthday { get; set; }
        */

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{yyyy-MM-dd}")]
        public DateTime birthday { get; set; }

        [Required(ErrorMessage = "Пожалуйста, укажите пол")]
        [DisplayName("Пол:")]
        public string pol { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите идентификационный код")]
        [DisplayName("Идентификационный код:")]
        public int identif { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите номер и серию паспорта")]
        [DisplayName("Паспорт:")]
        public string passport { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите адрес")]
        [DisplayName("Адрес:")]
        public string address { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите телефон")]
        [DisplayName("Телефон:")]
        public int phone { get; set; }
    }
}