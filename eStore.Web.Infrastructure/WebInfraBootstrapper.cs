using eStore.Interfaces.Services;
using eStore.Web.Infrastructure.ObjectMapper;
using WrapIoC;

[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(eStore.Web.Infrastructure.WebInfraBootstrapper), "Init")]

namespace eStore.Web.Infrastructure
{
    public static class WebInfraBootstrapper
    {
        public static void Init()
        {
            IoC.Current.Register<IAuthenticationProvider, AuthenticationProvider>();
            IoC.Current.Register<IObjectMapper, eStore.Web.Infrastructure.ObjectMapper.ObjectMapper>();
            IoC.Current.Register<IFileService, FileService>();
        }
    }
}
