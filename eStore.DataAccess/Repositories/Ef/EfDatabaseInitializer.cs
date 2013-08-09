using System.Data.Entity;

namespace eStore.DataAccess.Repositories.Ef
{
    internal class EfDatabaseInitializer : IDatabaseInitializer<EStoreDbContext>
    {
        #region IDatabaseInitializer<EStoreDbContext>

        void IDatabaseInitializer<EStoreDbContext>.InitializeDatabase(EStoreDbContext context)
        {
            if (context.Database.Exists())
            {
                context.Database.Delete();
            }

            context.Database.Create();
        }

        #endregion
    }
}
