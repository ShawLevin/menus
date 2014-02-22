using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Menulator.Models;

namespace Menulator.DataAccess
{
    public class RestaurantContext : DbContext
    {
        public RestaurantContext()
            : base("RestaurantContext")
        { }
        public DbSet<Restaurant> Restaurants { get; set;}
    }
}