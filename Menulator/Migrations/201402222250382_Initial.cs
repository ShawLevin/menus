namespace Menulator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        ParentCategoryID = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Hours",
                c => new
                    {
                        HoursID = c.Int(nullable: false, identity: true),
                        LocationID = c.Int(nullable: false),
                        Day = c.String(),
                        Open = c.DateTime(nullable: false),
                        Close = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.HoursID);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ItemID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ItemID);
            
            CreateTable(
                "dbo.ItemTags",
                c => new
                    {
                        ItemTagID = c.Int(nullable: false, identity: true),
                        ItemID = c.Int(nullable: false),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.ItemTagID);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        LocationID = c.Int(nullable: false, identity: true),
                        RestaurantID = c.Int(nullable: false),
                        Title = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                        Longitude = c.Double(nullable: false),
                        Latitude = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.LocationID);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        MemberID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Phone = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MemberID);
            
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        MenuID = c.Int(nullable: false, identity: true),
                        RestaurantID = c.Int(nullable: false),
                        Title = c.String(),
                        Starting = c.DateTime(nullable: false),
                        Ending = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MenuID);
            
            CreateTable(
                "dbo.Options",
                c => new
                    {
                        OptionID = c.Int(nullable: false, identity: true),
                        ItemID = c.Int(nullable: false),
                        Cost = c.Double(nullable: false),
                        Description = c.String(),
                        Max = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OptionID);
            
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        OrderItemID = c.Int(nullable: false, identity: true),
                        OrderID = c.Int(nullable: false),
                        ItemID = c.Int(nullable: false),
                        Cost = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.OrderItemID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        MemberID = c.Int(nullable: false),
                        MenuID = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OrderID);
            
            CreateTable(
                "dbo.Preferences",
                c => new
                    {
                        PreferenceID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        ItemTagValue = c.String(),
                        Flag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PreferenceID);
            
            CreateTable(
                "dbo.Restaurants",
                c => new
                    {
                        RestaurantID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Contact = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RestaurantID);
            
            CreateTable(
                "dbo.RestaurantTags",
                c => new
                    {
                        RestaurantTagID = c.Int(nullable: false, identity: true),
                        RestaurantID = c.Int(nullable: false),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.RestaurantTagID);
            
            CreateTable(
                "dbo.UserLocations",
                c => new
                    {
                        UserLocationID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        Title = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.UserLocationID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserLocations");
            DropTable("dbo.RestaurantTags");
            DropTable("dbo.Restaurants");
            DropTable("dbo.Preferences");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderItems");
            DropTable("dbo.Options");
            DropTable("dbo.Menus");
            DropTable("dbo.Members");
            DropTable("dbo.Locations");
            DropTable("dbo.ItemTags");
            DropTable("dbo.Items");
            DropTable("dbo.Hours");
            DropTable("dbo.Categories");
        }
    }
}
