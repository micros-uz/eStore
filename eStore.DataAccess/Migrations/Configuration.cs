using System.Data.Entity.Migrations;
using System.Linq;
using eStore.DataAccess.Repositories.Ef;
using eStore.Interfaces.Repositories;
using WrapIoC;

namespace eStore.DataAccess.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<EStoreDbContext>
    {
        private readonly bool _pending;

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            //AutomaticMigrationDataLossAllowed = true;

            var migrator = new DbMigrator(this);
            _pending = migrator.GetPendingMigrations().Any();
        }

        protected override void Seed(EStoreDbContext context)
        {
            if (_pending)
            {
                var seedActionsProvider = IoC.Current.Get<ISeedActionProvider>();

                if (seedActionsProvider != null)
                {
                    seedActionsProvider.Action();
                }
            }
        }
    }
}
