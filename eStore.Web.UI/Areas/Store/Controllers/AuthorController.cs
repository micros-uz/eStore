using System.Linq;
using eStore.Domain;
using eStore.Interfaces.Services;
using eStore.Web.Infrastructure.ObjectMapper;
using eStore.Web.UI.Areas.Store.ViewModels;
using eStore.Web.UI.Logic;
using System.Collections.Generic;
using System.Web.Mvc;

namespace eStore.Web.UI.Areas.Store.Controllers
{
    public class AuthorController : BaseStoreController
    {
        public AuthorController(IStoreService service, IObjectMapper mapper)
            :base(service, mapper)
        {
        }

        public ActionResult Index()
        {
            var authors = Service.GetAuthors();

            var models = Mapper.Map<IEnumerable<Author>, IEnumerable<AuthorModel>>(authors);

            return View(models);
        }

        public ActionResult Books(int id)
        {
            return View();
        }

        public ActionResult Top()
        {
            var authors = Service.GetAuthors().Take(5);

            var models = Mapper.Map<IEnumerable<Author>, IEnumerable<AuthorModel>>(authors);

            return PartialView(models);
        }
    }
}
