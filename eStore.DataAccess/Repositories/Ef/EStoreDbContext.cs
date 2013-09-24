using System.Data.Entity;
using eStore.Domain;

namespace eStore.DataAccess.Repositories.Ef
{
    internal class EStoreDbContext : DbContext
    {
        public EStoreDbContext()
            : base(new ConnectionStringProvider().ConnectionString)
        {
        }

        public EStoreDbContext(string connStr)
            : base(connStr)
        {
        }

        public DbSet<Genre> Genres
        {
            get;
            set;
        }

        public DbSet<Author> Authors
        {
            get;
            set;
        }

        public DbSet<Book> Books
        {
            get;
            set;
        }

        public DbSet<Series> Series
        {
            get;
            set;
        }

        public DbSet<User> Users
        {
            get;
            set;
        }

        public DbSet<Role> Roles
        {
            get;
            set;
        }
    }
}
