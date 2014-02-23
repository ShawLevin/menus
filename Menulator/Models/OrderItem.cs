﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Menulator.Models
{
    public class OrderItem
    {
        public int ID { get; set; }

        public int OrderID { get; set; }

        public int MemberID { get; set; }

        public int ItemID { get; set; }
        
        public double Cost { get; set; }
    }
}