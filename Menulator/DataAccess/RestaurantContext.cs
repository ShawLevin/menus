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

        public DbSet<Hours> Hours { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemTag> ItemTags { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Preference> Preferences { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<RestaurantTag> RestaurantTags { get; set; }
        public DbSet<UserLocation> UserLocations { get; set; }

    }
}