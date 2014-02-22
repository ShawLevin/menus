using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Menulator.Models
{
    public class Order
    {
        public int ID { get; set; }
        public int MemberID { get; set; }
        public int OrderItemID { get; set; }
        public DateTime Date { get; set; }
    
    }

}