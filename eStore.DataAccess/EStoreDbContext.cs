using System.Configuration;
using System.Data.Entity;
using eStore.Domain;

namespace eStore.DataAccess
{
    internal class EStoreDbContext : DbContext
    {
        public EStoreDbContext(string connStr)
            : base(connStr)
        {
        }

        public DbSet<Genre> Genres
        {
            get;
            set;
        }

        public DbSet<Book> Books
        {
            get;
            set;
        }

        public DbSet<Author> Authors
        {
            get;
            set;
        }

        public DbSet<Series> Series { get; set; }
    }
}
