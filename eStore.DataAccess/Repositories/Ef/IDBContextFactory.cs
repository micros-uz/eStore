using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eStore.DataAccess.Repositories.Ef
{
    internal interface IDBContextFactory
    {
        EStoreDbContext Get();
    }
}
