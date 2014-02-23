namespace Menulator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixingMember : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserLocations", "MemberID", c => c.Int(nullable: false));
            AlterColumn("dbo.Members", "Phone", c => c.String());
            DropColumn("dbo.Members", "LocationID");
            DropColumn("dbo.UserLocations", "UserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserLocations", "UserID", c => c.Int(nullable: false));
            AddColumn("dbo.Members", "LocationID", c => c.Int(nullable: false));
            AlterColumn("dbo.Members", "Phone", c => c.Int(nullable: false));
            DropColumn("dbo.UserLocations", "MemberID");
        }
    }
}
