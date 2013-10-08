using System.Web;
using eStore.Interfaces.Services;

namespace eStore.Web.Infrastructure
{
    internal class WebEnvironmentProvider : IEnvironmentProvider
    {
        #region IEnvironmentProvider

        string IEnvironmentProvider.BasePath
        {
            get 
            {
                return HttpRuntime.AppDomainAppPath;
            }
        }

        #endregion
    }
}
