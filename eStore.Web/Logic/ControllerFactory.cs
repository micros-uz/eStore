using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;
using eStore.Interfaces.IoC;

namespace eStore.Logic
{
    internal class ControllerFactory : IControllerFactory
    {
        #region IControllerFactory

        IController IControllerFactory.CreateController(RequestContext requestContext, string controllerName)
        {
            IController res = null;

            try
            {
                res = IoC.Current.Get<IController>(controllerName.ToLowerInvariant());
            }
            catch(IoCException)
            {
                
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