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
            return IoC.Current.Get<IController>(controllerName.ToLowerInvariant());
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