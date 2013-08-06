using eStore.Web.Areas.Admin.Controllers;
using eStore.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;

namespace eStore.Logic
{
    internal class ControllerFactory : IControllerFactory
    {
        #region IControllerFactory

        IController IControllerFactory.CreateController(RequestContext requestContext, string controllerName)
        {
            IController res = null;

            switch(controllerName)
            {
                case "Home":
                    res = new HomeController();
                    break;
                case "Store":
                    res = new StoreController();
                    break;  
                case "Sql":
                    res = new SqlController();
                    break;
            }

            return res;
        }

        SessionStateBehavior IControllerFactory.GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
        {
            return SessionStateBehavior.Disabled;
        }

        void IControllerFactory.ReleaseController(IController controller)
        {
            
        }

        #endregion
    }
}