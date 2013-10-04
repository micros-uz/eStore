using System.Data.Entity;
using eStore.Domain;
using eStore.DataAccess.Configurations;
using eStore.DataAccess.Configurations.Security;
using System.Diagnostics;

namespace eStore.DataAccess.Repositories.Ef.BoundedContexts
{
    internal class CatalogContext : BaseContext
    {
        public CatalogContext()
            : base()
        {
        }

        public CatalogContext(string connStr)
            : base(connStr)
        {
        }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Author> Authors  { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Series> Series { get; set; }
    }
}
