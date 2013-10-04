using eStore.Interfaces;
using System;
using System.Web.Mvc;
using WrapIoC;

namespace eStore.Web.Infrastructure.Filters.Mvc
{
    public class DbVersionAttribute : ActionFilterAttribute
    {
        private readonly int _dbVersion;

        public DbVersionAttribute(string dbVersion)
        {
            if (!int.TryParse(dbVersion, out _dbVersion))
            {
                new Exception("Invalid Db Version");
            }
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var version = IoC.Current.Get<IDbVersionProvider>().GetVersion();
            int nVer;

            if (int.TryParse(version, out nVer))
            {
                if (nVer < _dbVersion)
                {
                    filterContext.Result = new RedirectResult("~/store/home/dbversioninvalid");
                }
            }
        }
    }
}
