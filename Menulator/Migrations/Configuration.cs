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
            context.Restaurants.Add(new Restaurant { ID = 0, Name = "Drexel Pizza", Description = "Pizza!" });
        }
    }
}
