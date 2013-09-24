using System.Data.Entity.Migrations;
using eStore.DataAccess.Repositories.Ef;
using eStore.Interfaces.Repositories;
using WrapIoC;

namespace eStore.DataAccess.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<EStoreDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(EStoreDbContext context)
        {
            var seedActionsProvider = IoC.Current.Get<ISeedActionProvider>();

            if (seedActionsProvider != null)
            {
                seedActionsProvider.Action();
            }
        }
    }
}
