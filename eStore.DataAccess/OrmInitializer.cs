using System.Data.Entity;
using eStore.DataAccess.Repositories.Ef;

namespace eStore.DataAccess
{
    internal static class OrmInitializer
    {
        public static void Init()
        {
            Database.SetInitializer(new EfDatabaseInitializer());
        }
    }
}
