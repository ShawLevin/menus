using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Menulator.Models
{
    public class MenulatorContext : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}