using eStore.Web.Areas.Admin.ViewModels;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
using System.Web.Mvc;

namespace eStore.Web.Areas.Admin.Controllers
{
    public class SqlController : Controller
    {
        public ActionResult Index(ExecSqlModel model)
        {
            model.User = "sa";
            model.Password = "dev1234";
            model.Server = ".";
            model.DataBase = "Orygin";
            model.Query = "select * from PluginMapping";

            return View(model);
        }

        public string CheckAppHarbor()
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

        [HttpPost]
        public ActionResult Exec(ExecSqlModel model)
        {
            var res = new GridDataModel();

            var connStr = new SqlConnectionStringBuilder()
            {
                DataSource = model.Server,
                InitialCatalog = model.DataBase,
                UserID = model.User,
                Password = model.Password
            };

            var conn = new SqlConnection(connStr.ConnectionString);

            try
            {
                conn.Open();
                var cmd = new SqlCommand(model.Query, conn);
                var reader = cmd.ExecuteReader();
                //DataTable dt = new DataTable();
                //dt.Load(reader);

                if (reader.HasRows)
                {
                    var t = reader.GetSchemaTable();

                    var cols = new List<string>();

                    for (int i = 0; i < 1; i++)
                    {
                        cols.Add(t.Rows[i][0].ToString());
                    }

                    res.Columns = cols;
                    res.Headers = new List<string>() { "FF" };

                    var data = new List<dynamic>();
                    
                    while (reader.Read())
                    {
                        var row = new { Id = reader.GetInt32(0) };
                        data.Add(row);
                    }

                    res.Data = data;
                }
            }
            catch(Exception ex)
            {
                model.Result = ex.Message;
                RedirectToAction("Index", model);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

            return View(res);
        }
    }
}
