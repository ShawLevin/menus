namespace Menulator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ColumnFixes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Preferences", "MemberID", c => c.Int(nullable: false));
            DropColumn("dbo.Preferences", "UserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Preferences", "UserID", c => c.Int(nullable: false));
            DropColumn("dbo.Preferences", "MemberID");
        }
    }
}
