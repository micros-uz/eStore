using eStore.Interfaces.IoC;
using eStore.Interfaces.Services;

namespace eStore.Web.Infrastructure
{
    public static class WebInfraBootstrapper
    {
        public static void Init(IIoC ioc)
        {
            ioc.Register<IAuthenticationProvider, AuthenticationProvider>();
        }
    }
}
