using System.Configuration;
using System.Data.Entity;
using eStore.Domain;

namespace eStore.DataAccess
{
    internal class EStoreDbContext : DbContext
    {
        public EStoreDbContext()
            : base(ConfigurationManager.ConnectionStrings["ESTORE_CONN_STR"].ConnectionString)
        {

        }

        public EStoreDbContext(string connStr)
            : base(connStr)
        {

        }

        internal DbSet<Genre> Genres
        {
            get;
            set;
        }

        internal DbSet<Book> Books
        {
            get;
            set;
        }

        internal DbSet<Author> Authors
        {
            get;
            set;
        }
    }
}
