using eStore.Web.Areas.Admin.ViewModels;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
using System.Web.Mvc;
using WebMatrix.Data;

namespace eStore.Web.Areas.Admin.Controllers
{
    public class SqlController : Controller
    {
        public ActionResult Index(ExecSqlModel model)
        {
            //model.User = "sa";
            //model.Password = "dev1234";
            //model.Server = ".";
            //model.DataBase = "Orygin";
            //model.Query = "select * from PluginMapping";

            model.Server = "058e3204-8872-4364-b041-a20f00dbd586.sqlserver.sequelizer.com";
            model.DataBase = "db058e320488724364b041a20f00dbd586";
            model.User = "uqdvuhwlzvfhhjgs";
            model.Password = "8yqBAvd7s6kWPwGnjznFapt6NedrV4iZaf3WoDrBKjEZfgUEsahZiSRSesVwrUjw";
            model.Query = "";

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
            //Server=058e3204-8872-4364-b041-a20f00dbd586.sqlserver.sequelizer.com;Database=db058e320488724364b041a20f00dbd586;User ID=uqdvuhwlzvfhhjgs;Password=8yqBAvd7s6kWPwGnjznFapt6NedrV4iZaf3WoDrBKjEZfgUEsahZiSRSesVwrUjw;
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

                if (reader.HasRows)
                {
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

                        res.Data = result;
                    }
                }
                else if (reader.RecordsAffected > -1)
                {
                    var obj = (IDictionary<string, object>)new ExpandoObject();
                    obj.Add("Row(s) affected", reader.RecordsAffected);

                    res.Data = new List<dynamic>() { obj };
                }
            }
            catch(Exception ex)
            {
                model.Result = ex.Message;
                return RedirectToAction("Index", model);
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
