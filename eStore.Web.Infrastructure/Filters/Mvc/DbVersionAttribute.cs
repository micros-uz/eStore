    using eStore.Interfaces;
using System;
using System.Web.Mvc;
using WrapIoC;

namespace eStore.Web.Infrastructure.Filters.Mvc
{
    public class DbVersionAttribute : ActionFilterAttribute
    {
        private readonly int _dbVersion;

        public DbVersionAttribute(int dbVersion)
        {
            _dbVersion = dbVersion;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var version = IoC.Current.Get<IDbVersionProvider>().GetVersion();

            if (version < 0 || version < _dbVersion)
            {
                filterContext.Result = new RedirectResult("~/error/dbversioninvalid");
            }
        }
    }
}
