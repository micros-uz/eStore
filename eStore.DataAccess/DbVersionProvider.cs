using System.Linq;
using eStore.DataAccess.Migrations;
using eStore.Interfaces;
using System.Data.Entity.Migrations;

namespace eStore.DataAccess
{
    internal class DbVersionProvider : IDbVersionProvider
    {
        #region IDbVersionProvider

        int IDbVersionProvider.GetVersion()
        {
            var migrator = new DbMigrator(new Configuration());

            return migrator.GetDatabaseMigrations().Count();
        }

        #endregion
    }
}
