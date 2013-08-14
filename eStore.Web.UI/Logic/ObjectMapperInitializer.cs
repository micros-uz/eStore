using eStore.Domain;
using eStore.Web.Infrastructure.ObjectMapper;
using eStore.Web.UI.Areas.Account.ViewModels;
using eStore.Web.UI.Areas.Store.ViewModels;

namespace eStore.Web.UI.Logic
{
    public static class ObjectMapperInitializer
    {
        public static void Init()
        {
            ObjectMapperConfigurator.Init(typeof(StoreViewModelProfile));
        }
    }
}