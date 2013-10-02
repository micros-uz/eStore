using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;
using eStore.Core;
using eStore.Interfaces.Services;
using eStore.Web.UI.Areas.Admin.ViewModels;

namespace eStore.Web.UI.Areas.Admin.Controllers
{   
    [Authorize]
    public class SqlController : Controller
    {
        private readonly IAdminService _service;

        public SqlController(IAdminService service)
        {
            _service = service;
        }

        [AllowAnonymous]
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
        [AllowAnonymous]
        public ActionResult Exec(ExecSqlModel model)
        {
            var res = new GridDataModel();

            try
            {
                res.Data = _service.Exec(model.Query);
            }
            catch (CoreServiceException ex)
            {
                model.Result = ex.Message;
                return RedirectToAction("Index", model);
            }

            return View(res);
        }

        public ActionResult DbInit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DbInit(string st)
        {
            var errMsg = string.Empty;

            try
            {
                ViewBag.InitResult = _service.DbInit();
            }
            catch (CoreServiceException ex)
            {
                ViewBag.InitError = ex.Message;
            }

            return View();
        }

        [AllowAnonymous]
        public ActionResult Migrations()
        {
            var migrations = _service.GetMigrationsInfo();

            return View(new MigrationsModel
                {
                    Database = migrations.Item1,
                    Local = migrations.Item2,
                    Pending = migrations.Item3,
                });
        }
    }
}
