using System;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace eStore.Controllers
{
    public class SqlController : Controller
    {
        public string Index()
        {
            var res = "Res";

            var connectionString = new SqlConnectionStringBuilder
            {
                DataSource = "058e3204-8872-4364-b041-a20f00dbd586.sqlserver.sequelizer.com",
                InitialCatalog = "master",
                UserID = "uqdvuhwlzvfhhjgs",
                Password = "8yqBAvd7s6kWPwGnjznFapt6NedrV4iZaf3WoDrBKjEZfgUEsahZiSRSesVwrUjw",
            }.ConnectionString;

            var conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                res = conn.ToString();
            }
            catch (Exception ex)
            {
                res = ex.ToString();
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                    res = "CLOSED  " + res;
                }
            }

            return res;
        }

    }
}
