using eStore.Interfaces.IoC;
using eStore.Interfaces.Services;
using eStore.Web.Infrastructure.ObjectMapper;

namespace eStore.Web.Infrastructure
{
    public static class WebInfraBootstrapper
    {
        public static void Init(IIoC ioc)
        {
            ioc.Register<IAuthenticationProvider, AuthenticationProvider>();
            ioc.Register<IObjectMapper, eStore.Web.Infrastructure.ObjectMapper.ObjectMapper>();
        }
    }
}
