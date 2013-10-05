using eStore.Interfaces.Repositories;
using eStore.Interfaces.Services;
using eStore.Web.Infrastructure.Authentication;
using eStore.Web.Infrastructure.ObjectMapper;
using WrapIoC;

// Order parameter does not work across assemblies so we
// need to use Pre or place it into global.asax...
//[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(eStore.Web.Infrastructure.WebInfraBootstrapper), "Init")]

namespace eStore.Web.Infrastructure
{
    public static class WebInfraBootstrapper
    {
        public static void Init()
        {
            IoC.Current.Register<IAuthenticationProvider, AuthenticationProvider>();
            IoC.Current.Register<IObjectMapper, eStore.Web.Infrastructure.ObjectMapper.ObjectMapper>();
            IoC.Current.Register<IFileService, FileService>();
            IoC.Current.Register<ISeedActionProvider, DatabaseSeedActionManager>();
        }
    }
}
