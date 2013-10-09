using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
using System.IO;
using System.Reflection;
using eStore.Interfaces.Repositories;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using WrapIoC;
using System.Data.Entity.Migrations;
using System;
using eStore.DataAccess.Repositories.Ef;

namespace eStore.DataAccess
{
    public static class DatabaseHelper
    {
        public static int Init()
        {
            var connStr = IoC.Current.Get<IConnectionStringProvider>().ConnectionString;
            var res = -1;
            Action<Exception> exHandler = (Exception ex) =>
                {
                    throw new DataAccessException("Database custom initialization failed", ex);
                };

            try
            {
                string script = string.Empty;
                var asm = Assembly.GetExecutingAssembly();

                using (var stream = asm.GetManifestResourceStream("eStore.DataAccess.Scripts.Data.sql"))
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
                exHandler(ex);
            }
            catch(SmoException ex)
            {
                exHandler(ex);
            }
            catch(SqlServerManagementException ex)
            {
                exHandler(ex);
            }

            return res;
        }

        public static IEnumerable<dynamic> Exec(string query)
        {
            IEnumerable<dynamic> res = null;
            var connStr = IoC.Current.Get<IConnectionStringProvider>().ConnectionString;
            Action<Exception> exHandler = (Exception ex) =>
            {
                throw new DataAccessException("Query execution failed", ex);
            };

            try
            {
                using (var conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    var cmd = new SqlCommand(query, conn);
                    var reader = cmd.ExecuteReader();

                    res = reader.HasRows
                        ? ReadFromTable(reader)
                        : SetEmptyResult(reader);
                }
            }
            catch (SqlException ex)
            {
                exHandler(ex);
            }
            catch(InvalidOperationException ex)
            {
                exHandler(ex);
            }

            return res;
        }

        private static IEnumerable<dynamic> SetEmptyResult(SqlDataReader reader)
        {
            var obj = (IDictionary<string, object>)new ExpandoObject();
            obj.Add("Row(s) affected", reader.RecordsAffected);

            return new List<dynamic>() { obj };
        }

        private static IEnumerable<dynamic> ReadFromTable(SqlDataReader reader)
        {
            IEnumerable<dynamic> res = null;
            DataTable dt = new DataTable();
            dt.Load(reader);

            if (dt.Rows.Count > 0)
            {
                var result = new List<dynamic>();
                foreach (DataRow row in dt.Rows)
                {
                    var obj = (IDictionary<string, object>)new ExpandoObject();
                    foreach (DataColumn col in dt.Columns)
                    {
                        obj.Add(col.ColumnName, row[col.ColumnName]);
                    }
                    result.Add(obj);
                }

                res = result;
            }

            return res;
        }

        public static int Exec2(string query)
        {
            var connStr = IoC.Current.Get<IConnectionStringProvider>().ConnectionString;

            using (var connection = new SqlConnection(connStr))
            {
                Server server = new Server(new ServerConnection(connection));
                return server.ConnectionContext.ExecuteNonQuery(query);
            }
        }

        public static Tuple<IEnumerable<string>, IEnumerable<string>, IEnumerable<string>> GetMigrationsInfo()
        {
            return EfHelper.GetMigrationsInfo();
        }

        public static void Migrate(string target, bool isDowngrade)
        {
            EfHelper.Migrate(target, isDowngrade);
        }
    }
}
