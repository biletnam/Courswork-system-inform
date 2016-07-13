using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class Client
    {
        private DateTime DEFAULT_DATE = new DateTime(1991, 04, 11);

        public Client()
        {
            birthday = DEFAULT_DATE;
        }

        [ScaffoldColumn(false)]
        [DisplayName("Id")]
        public int id { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите имя задачи")]
        [DisplayName("ФИО")]
        public string FIO { get; set; }

        [Required(ErrorMessage = "Укажите дату корректно")]
        [DisplayName("Дата дня рождения")]
        public DateTime birthday { get; set; }
        
        [Required(ErrorMessage = "Укажите пол")]
        [DisplayName("Пол")]
        public string pol { get; set; }

        [Required(ErrorMessage = "Укажите идентификационый код")]
        [DisplayName("Идентификационый код")]
        public int identif { get; set; }

        [Required(ErrorMessage = "Укажите номер и серия паспорта")]
        [DisplayName("Паспорт")]
        public string passport { get; set; }

        [Required(ErrorMessage = "Укажите адрес")]
        [DisplayName("Адрес")]
        public string address { get; set; }

        [Required(ErrorMessage = "Укажите телефон")]
        [DisplayName("Номер телефона")]
        public string phone { get; set; }
    }
}