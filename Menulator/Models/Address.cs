using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Menulator.Models
{
    public class Address
    {
        public int ID { get; set; }
        
        public string Street { get; set; }
        
        public string State { get; set; }
    
        public string ZipCode { get; set; }

        public string SuiteNum { get; set; }
    
    }
}