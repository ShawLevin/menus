namespace Menulator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Street = c.String(),
                        State = c.String(),
                        ZipCode = c.String(),
                        SuiteNum = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Hours",
                c => new
                    {
                        HoursID = c.Int(nullable: false, identity: true),
                        RestaurantID = c.Int(nullable: false),
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
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                        RestaurantID = c.Int(nullable: false),
                        HourID = c.Int(nullable: false),
                        MenuID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        LocationID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
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
                        cost = c.Double(nullable: false),
                        Description = c.String(),
                        Max = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OptionID);
            
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OrderID = c.Int(nullable: false),
                        MemberID = c.Int(nullable: false),
                        ItemID = c.Int(nullable: false),
                        Cost = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MemberID = c.Int(nullable: false),
                        OrderItemID = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
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
            
            AddColumn("dbo.Restaurants", "Contact", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Restaurants", "Contact");
            DropTable("dbo.UserLocations");
            DropTable("dbo.RestaurantTags");
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
            DropTable("dbo.Addresses");
        }
    }
}
