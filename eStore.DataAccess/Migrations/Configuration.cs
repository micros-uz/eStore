using System.Data.Entity.Migrations;
using System.Linq;
using eStore.DataAccess.Repositories.Ef;
using eStore.Interfaces.Repositories;
using WrapIoC;
using eStore.DataAccess.Repositories.Ef.BoundedContexts;

namespace eStore.DataAccess.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<CommonContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = true;
        }
        
        protected override void Seed(CommonContext context)
        {

        }
    }
}
