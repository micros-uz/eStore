using System.Data.Entity;
using eStore.Domain.Forum;

namespace eStore.DataAccess.Repositories.Ef.BoundedContexts
{
    internal class ForumContext : BaseContext
    {
        public ForumContext()
            : base()
        {
        }

        public ForumContext(string connStr)
            : base(connStr)
        {
        }

        public DbSet<TopicCategory> TopicCategories { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}
