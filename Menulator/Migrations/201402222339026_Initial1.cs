namespace Menulator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "MenuID", c => c.Int(nullable: false));
            AddColumn("dbo.Items", "CategoryID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Items", "CategoryID");
            DropColumn("dbo.Categories", "MenuID");
        }
    }
}
