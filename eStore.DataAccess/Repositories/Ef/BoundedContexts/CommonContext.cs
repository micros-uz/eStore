using eStore.DataAccess.Configurations;
using eStore.Domain.Security;
using eStore.Domain.Store;
using System.Data.Entity;
using eStore.Domain.Blog;
using eStore.Domain.Forum;

namespace eStore.DataAccess.Repositories.Ef.BoundedContexts
{
    internal class CommonContext : BaseContext
    {
        public CommonContext()
            : base()
        {
        }

        public CommonContext(string connStr)
            : base(connStr)
        {
        }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Series> Series { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<OAuthMembership> OAuthMemberships { get; set; }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Post> Posts { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            CatalogModelsConfigurator.OnModelCreating(modelBuilder);
            SecurityModelsConfigurator.OnModelCreating(modelBuilder);
            BlogModelsConfigurator.OnModelCreating(modelBuilder);
            ForumModelsConfigurator.OnModelCreating(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
    }
}
