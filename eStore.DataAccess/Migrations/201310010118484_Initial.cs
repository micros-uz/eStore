namespace eStore.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        GenreId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 30),
                        Desc = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.GenreId);
            
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        AuthorId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.AuthorId);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        GenreId = c.Int(nullable: false),
                        AuthorId = c.Int(nullable: false),
                        SeriesId = c.Int(),
                        Title = c.String(maxLength: 200),
                        Price = c.Double(nullable: false),
                        Year = c.Short(nullable: false),
                        Pages = c.Short(nullable: false),
                        ISBN = c.String(maxLength: 20),
                        Desc = c.String(),
                        ImageFile = c.Guid(),
                    })
                .PrimaryKey(t => t.BookId)
                .ForeignKey("dbo.Authors", t => t.AuthorId, cascadeDelete: true)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .Index(t => t.AuthorId)
                .Index(t => t.GenreId);
            
            CreateTable(
                "dbo.Series",
                c => new
                    {
                        SeriesId = c.Int(nullable: false, identity: true),
                        GenreId = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 30),
                        Desc = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.SeriesId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 10),
                        Email = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.UserId);
        }
        
        public override void Down()
        {
            SecurityDropHelper.DropTables((x) => DropTable(x));

            DropIndex("dbo.Books", new[] { "GenreId" });
            DropIndex("dbo.Books", new[] { "AuthorId" });
            DropForeignKey("dbo.Books", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.Books", "AuthorId", "dbo.Authors");
            DropTable("dbo.Users");
            DropTable("dbo.Series");
            DropTable("dbo.Books");
            DropTable("dbo.Authors");
            DropTable("dbo.Genres");
        }
    }
}
