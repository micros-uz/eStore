namespace eStore.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _04_BookCount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "Count", c => c.Int(nullable: false));
            AddColumn("dbo.Topics", "Theme", c => c.String());
            AddColumn("dbo.Topics", "ViewsCount", c => c.Int(nullable: false));
            DropColumn("dbo.Topics", "Title");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Topics", "Title", c => c.String());
            DropColumn("dbo.Topics", "ViewsCount");
            DropColumn("dbo.Topics", "Theme");
            DropColumn("dbo.Books", "Count");
        }
    }
}
