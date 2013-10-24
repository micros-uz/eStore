using System.Collections.Generic;
using eStore.Interfaces.Data;
using System.Linq;

namespace eStore.Core
{
    internal class PredefinedDataManager : IPredefinedDataManager
    {
        private IDictionary<string, IMigrationInitializer> _migrationInitializers;

        #region IPredefinedUsersManager

        void IPredefinedDataManager.Register(string targetMigration, IMigrationInitializer initializer)
        {
            if (_migrationInitializers == null)
            {
                _migrationInitializers = new Dictionary<string, IMigrationInitializer>();
            }

            _migrationInitializers.Add(targetMigration, initializer);
        }

        void IPredefinedDataManager.Run(string targetMigration)
        {
            var keyValuePair = _migrationInitializers.FirstOrDefault(x => targetMigration.Contains(x.Key));

            if (keyValuePair.Value != null)
            {
                keyValuePair.Value.Run();
            }
        }

        #endregion
    }
}
