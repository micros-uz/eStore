using System.Configuration;
using System.Data.Entity;
using eStore.Domain;

namespace eStore.DataAccess
{
    internal class EStoreDbContext : DbContext
    {
        public EStoreDbContext()
            : this(ConfigurationManager.ConnectionStrings["ESTORE_CONN_STR"].ConnectionString)
        {

        }

        public EStoreDbContext(string connStr)
            : base(connStr)
        {
           // Database.Initialize(false);
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
    }
}
