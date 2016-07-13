using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MvcApplication1.Models;

namespace MvcApplication1.Models
{
    public class List125
    {
        public IEnumerable<Order> order { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите свое имя")]
        public Order ddd;
    }
}