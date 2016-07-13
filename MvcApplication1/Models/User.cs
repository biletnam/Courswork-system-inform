using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{

    public class User
    {
        [ScaffoldColumn(false)]
        [DisplayName("Id:")]
        public int id { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите свое ФИО")]
        [DisplayName("ФИО:")]
        public string FIO { get; set; }

        [Required(ErrorMessage = "Пожалуйста, укажите дату корректно")]
        [DisplayName("Дата:")]
        public DateTime date { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите свой номер телефона")]
        [DisplayName("Телефон:")]
        public int phone { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите email")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Вы ввели некорректный email")]
        [DisplayName("E-mail:")]
        public string email { get; set; }
    }
}
