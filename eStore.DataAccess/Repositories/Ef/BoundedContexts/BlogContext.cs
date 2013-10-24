using System.Data.Entity;
using eStore.Domain.Blog;
namespace eStore.DataAccess.Repositories.Ef.BoundedContexts
{
    internal class BlogContext : BaseContext
    {
        public BlogContext()
            : base()
        {
        }

        public BlogContext(string connStr)
            : base(connStr)
        {
        }

        DbSet<Article> Articles { get; set; }
        DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
