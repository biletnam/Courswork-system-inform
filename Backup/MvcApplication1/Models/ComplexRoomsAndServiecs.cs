using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class ComplexRoomsAndServiecs
    {
        public List<type_pool> ListRoom { get; set; }
        public List<type_servies> ListServies { get; set; }

        //public TypeNumberModifString TypePool { get; set; }
        public type_pool TypePool { get; set; }
        public TypeServies TypeServies { get; set; }
    }
}