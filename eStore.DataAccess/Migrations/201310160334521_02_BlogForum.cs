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
                .PrimaryKey(t => t.ArticleId);
            
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
                        AuthorId = c.Int(nullable: false),
                        Text = c.String(),
                        Date = c.DateTime(nullable: false),
                        Topic_TopicId = c.Int(),
                    })
                .PrimaryKey(t => t.PostId)
                .ForeignKey("dbo.Topics", t => t.Topic_TopicId)
                .Index(t => t.Topic_TopicId);
            
            CreateTable(
                "dbo.Topics",
                c => new
                    {
                        TopicId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.TopicId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "Topic_TopicId", "dbo.Topics");
            DropForeignKey("dbo.Comments", "ArticleId", "dbo.Articles");
            DropIndex("dbo.Posts", new[] { "Topic_TopicId" });
            DropIndex("dbo.Comments", new[] { "ArticleId" });
            DropTable("dbo.Topics");
            DropTable("dbo.Posts");
            DropTable("dbo.Comments");
            DropTable("dbo.Articles");
        }
    }
}
