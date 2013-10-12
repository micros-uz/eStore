using eStore.Interfaces.Services;
using eStore.Web.Infrastructure.ObjectMapper;
using eStore.Web.UI.Logic;
using System.Web.Mvc;
using Antlr.Runtime.Misc;

namespace eStore.Web.UI.Areas.Store.Controllers
{
    public class BaseStoreController : BaseDisposeController
    {
        public BaseStoreController(IStoreService service, IObjectMapper mapper)
        {
            Service = service;
            Mapper = mapper;
        }

        protected IObjectMapper Mapper { get; private set; }

        protected IStoreService Service { get; private set; }

        protected ActionResult CheckResource(object resource, Func<ActionResult> func)
        {
            return resource == null
                ? RedirectToAction("NotFound", "Error")
                : func();
        }
    }
}
