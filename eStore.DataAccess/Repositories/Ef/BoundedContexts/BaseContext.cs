using eStore.Interfaces.Repositories;
using System.Data.Entity;

namespace eStore.DataAccess.Repositories.Ef.BoundedContexts
{
    class BaseContext : DbContext, IBaseContext
    {
        public BaseContext()
            : base(new ConnectionStringProvider().ConnectionString)
        {
            
        }

        public BaseContext(string connStr)
            : base(connStr)
        {
        }
    }
}
