using System.Configuration;
using eStore.Interfaces.Repositories;

namespace eStore.DataAccess
{
    internal class ConnectionStringProvider : IConnectionStringProvider
    {
        public string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings[ConnectionStringName].ConnectionString;
            }
        }

        public string ConnectionStringName
        {
            get
            {
                return "ESTORE_CONN_STR";
            }
        }
    }
}
