using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Menulator.Models
{
    public class Option
    {
        public int OptionID { get; set; }
        public int ItemID { get; set; }
        public double cost { get; set; }
        public string Description { get; set; }
        public int Max { get; set; }
    }
}