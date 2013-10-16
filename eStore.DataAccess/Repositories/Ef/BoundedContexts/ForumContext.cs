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

        DbSet<Topic> Topics { get; set; }
        DbSet<Post> Posts { get; set; }
    }
}
