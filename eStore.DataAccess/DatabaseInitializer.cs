using System.Data;
using System.Data.SqlClient;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System.IO;
using System.Reflection;

namespace eStore.DataAccess
{
    public static class DatabaseInitializer
    {
        public static int Init()
        {
            var connStr = ConnectionStringFactory.ConnectionString;
            var res = -1;

            try
            {
                string script = string.Empty;
                var asm = Assembly.GetExecutingAssembly();

                using (var stream = asm.GetManifestResourceStream("eStore.DataAccess.Scripts.script.sql"))
                {
                    if (stream != null)
                    {
                        script = new StreamReader(stream).ReadToEnd(); 
                    }
                }

                SqlConnection connection = new SqlConnection(connStr);
                Server server = new Server(new ServerConnection(connection));
                res = server.ConnectionContext.ExecuteNonQuery(script);
            }
            catch (ConnectionException ex)
            {
            }

            return res;
        }
    }
}
