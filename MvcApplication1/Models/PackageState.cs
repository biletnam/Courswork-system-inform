using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Models
{
    public class PackageState
    {
        private PackageState(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public static PackageState Received = new PackageState(1, "Received");
        public static PackageState Processing = new PackageState(2, "Processing");
        public static PackageState Complete = new PackageState(3, "Complete");
    }
}