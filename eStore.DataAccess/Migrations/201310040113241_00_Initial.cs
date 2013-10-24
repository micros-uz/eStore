namespace eStore.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _00_Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        AuthorId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.AuthorId)
                // do not allow!
                .Index(x => x.Name);

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
                .ForeignKey("dbo.Authors", t => t.AuthorId)
                .ForeignKey("dbo.Genres", t => t.GenreId)
                .Index(t => t.AuthorId)
                .Index(t => t.GenreId);

            // no the same books in the same genre for one author!
            CreateIndex("dbo.Books", new string[] { "GenreId", "AuthorId", "Title" });

            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        GenreId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 30),
                        Desc = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.GenreId)
                .Index(x => x.Title, true);

            CreateTable(
                "dbo.Series",
                c => new
                    {
                        SeriesId = c.Int(nullable: false, identity: true),
                        GenreId = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 30),
                        Desc = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.SeriesId)
                .Index(x => x.Title, true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.Books", "AuthorId", "dbo.Authors");
            DropIndex("dbo.Books", new[] { "GenreId" });
            DropIndex("dbo.Books", new[] { "AuthorId" });
            DropTable("dbo.Series");
            DropTable("dbo.Genres");
            DropTable("dbo.Books");
            DropTable("dbo.Authors");
        }
    }
}
