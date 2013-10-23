using eStore.Interfaces.Repositories;
using System.Data.Entity;
using System.Diagnostics;

namespace eStore.DataAccess.Repositories.Ef.BoundedContexts
{
    class BaseContext : DbContext, IBaseContext
    {
        public BaseContext()
            : base(new ConnectionStringProvider().ConnectionString)
        {
            Database.Log = s => Debug.WriteLine(s);
        }

        public BaseContext(string connStr)
            : base(connStr)
        {
            Database.Log = s => Debug.WriteLine(s);
        }
    }
}
