namespace eStore.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _02_BlogForum : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        ArticleId = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Title = c.String(),
                        Text = c.String(),
                    })
                .PrimaryKey(t => t.ArticleId)
                .Index(x => x.Title, true);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        ArticleId = c.Int(nullable: false),
                        Text = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Articles", t => t.ArticleId, cascadeDelete: true)
                .Index(t => t.ArticleId);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostId = c.Int(nullable: false, identity: true),
                        TopicId = c.Int(nullable: false),
                        AuthorId = c.Int(nullable: false),
                        Text = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PostId)
                .ForeignKey("dbo.Topics", t => t.TopicId, cascadeDelete: true)
                .Index(t => t.TopicId);
            
            CreateTable(
                "dbo.Topics",
                c => new
                    {
                        TopicId = c.Int(nullable: false, identity: true),
                        TopicCategoryId = c.Int(nullable: false),
                        Theme = c.String(),
                        ViewsCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TopicId)
                .ForeignKey("dbo.TopicCategories", t => t.TopicCategoryId, cascadeDelete: true)
                .Index(t => t.TopicCategoryId)
                .Index(x => x.Theme, true);
            
            CreateTable(
                "dbo.TopicCategories",
                c => new
                    {
                        TopicCategoryId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Desc = c.String(),
                    })
                .PrimaryKey(t => t.TopicCategoryId)
                .Index(x => x.Title, true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Topics", "TopicCategoryId", "dbo.TopicCategories");
            DropForeignKey("dbo.Posts", "TopicId", "dbo.Topics");
            DropForeignKey("dbo.Comments", "ArticleId", "dbo.Articles");
            DropIndex("dbo.Topics", new[] { "TopicCategoryId" });
            DropIndex("dbo.Posts", new[] { "TopicId" });
            DropIndex("dbo.Comments", new[] { "ArticleId" });
            DropTable("dbo.TopicCategories");
            DropTable("dbo.Topics");
            DropTable("dbo.Posts");
            DropTable("dbo.Comments");
            DropTable("dbo.Articles");
        }
    }
}
