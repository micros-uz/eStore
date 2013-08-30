using System.Configuration;

namespace eStore.DataAccess
{
    internal static class ConnectionStringFactory
    {
        internal static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["ESTORE_CONN_STR"].ConnectionString;
            }
        }
    }
}
