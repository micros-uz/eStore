using System.Data;
using System.Data.Entity;
using System.Linq;
using eStore.Interfaces.Repositories;
using eStore.Domain;
using System.Configuration;

namespace eStore.DataAccess
{
    internal class EStoreDbContext : DbContext
    {
        public EStoreDbContext(string connStr)
            : base(connStr)
        {

        }
        internal DbSet<Genre> Genres
        {
            get;
            set;
        }
    }
}
