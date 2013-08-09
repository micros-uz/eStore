using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Web.Mvc;
using eStore.Web.Areas.Admin.ViewModels;

namespace eStore.Web.Areas.Admin.Controllers
{
    public class SqlController : Controller
    {
        public ActionResult Index(ExecSqlModel model)
        {
            var connStr = ConfigurationManager.ConnectionStrings["ESTORE_CONN_STR"];

            if (connStr != null)
            {
                var bld = new SqlConnectionStringBuilder(connStr.ConnectionString);

                model.Server = bld.DataSource;
                model.DataBase = bld.InitialCatalog;
                model.User = bld.UserID;
                model.Password = bld.Password;
                model.Query = string.Empty;
            }

            return View(model);
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
                else //if (reader.RecordsAffected > -1)
                {
                    var obj = (IDictionary<string, object>)new ExpandoObject();
                    obj.Add("Row(s) affected", reader.RecordsAffected);

                    res.Data = new List<dynamic>() { obj };
                }
            }
            catch (Exception ex)
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
