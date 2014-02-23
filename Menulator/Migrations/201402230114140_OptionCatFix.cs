namespace Menulator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OptionCatFix : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Options", "OptionCategory", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Options", "OptionCategory");
        }
    }
}
