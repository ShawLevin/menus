using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Menulator.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        public int MemberID { get; set; }
        public int MenuID { get; set; }
        public DateTime Date { get; set; }
    
    }

}