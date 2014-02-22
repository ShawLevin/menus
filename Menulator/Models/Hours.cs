using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Menulator.Models
{
    public class Hours
    {
        public int HoursID { get; set; }
        public int LocationID { get; set; }
        public string Day { get; set; }
        public DateTime Open { get; set; }
        public DateTime Close { get; set; }
    }
}