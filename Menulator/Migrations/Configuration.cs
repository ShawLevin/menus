namespace Menulator.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Menulator.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Menulator.DataAccess.RestaurantContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Menulator.DataAccess.RestaurantContext context)
        {
            context.Restaurants.Add(new Restaurant { RestaurantID = 0, Name = "Drexel Pizza", Description = "Pizza!" });
            context.Locations.Add(new Location { Address = "1235 Street", LocationID = 0, Phone = "60928999667", Title = "Drexel Pizza", RestaurantID = 0, Latitude = 39.9590446, Longitude = -75.1911044 });
            context.Locations.Add(new Location { Address = "Key West Street", LocationID = 0, Phone = "1234567890", Title = "Blue Moon Cafe", RestaurantID = 0, Latitude = 24.5583574, Longitude = -81.7802537 });

        }
    }
}
