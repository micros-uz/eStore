using System.Data.Entity;

namespace eStore.DataAccess.Repositories.Ef
{
    internal static class EfInitializer
    {
        internal static void Init()
        {
            Database.SetInitializer(new EfDatabaseInitializer());
        }
    }
}
