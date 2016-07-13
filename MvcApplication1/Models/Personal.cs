using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class Personal
    {
        public int id { get; set; }
        public string FIO { get; set; }
        public string dolgnost { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public bool admin { get; set; }
    }
}