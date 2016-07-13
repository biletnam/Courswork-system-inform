using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class ComplexModelClientAndServies
    {
        public List<MvcApplication1.Client> ListClient { get; set; }  // Клиенты
        public List<type_pool> ListTypePool { get; set; }             // Тип команты (люкс, стандарт, эконом-класс)
        public List<nametyperoom> ListNameTypeRoom { get; set; }      // Количество мест (одноместная, двухместная, трехместная)
        public List<type_number> ListNumber { get; set; }             // Номер комнаты (101, 102, 103, 104)

        public List<type_servies> ListTypeServies { get; set; }       // Типы услуги (бар, дискотека, сауна, салон красоты)

        //список заказанных усоуг
        public List<type_servies> AddOrderServies { get; set; }

        //public List<list_number> llll { get; set; }
        public List<list_numberModifc> llll { get; set; }
        
        public List<list_add_serviecsModific> add_llll { get; set; }

        public OrderAcceptModif CurrentOrder1 { get; set; }

        public list_add_services CurrentOrder2 { get; set; }
        public list_add_serviecsModific CurrentOrder3 { get; set; }
        public type_servies CurrentOrder4 { get; set; }

        public int BigPrice { get; set; }
    }
}