using System.Collections.Generic;
using System.Web.Mvc;
using eStore.Domain;
using eStore.Interfaces.Services;
using eStore.Web.Infrastructure.ObjectMapper;
using eStore.Web.UI.Areas.Store.ViewModels;

namespace eStore.Web.UI.Areas.Store.Controllers
{
    public class SearchController : BaseStoreController
    {

        public SearchController(IStoreService service, IObjectMapper mapper)
            :base(service, mapper)
        {
        }

        [ChildActionOnly]
        public ActionResult Search()
        {
            return PartialView("_Search");
        }

        public ActionResult Go(string searchqry)
        {
            var books = Service.SearchBooks(searchqry);

            var models = Mapper.Map<IEnumerable<Book>, IEnumerable<BookFullModel>>(books);

            return View(models);
        }
    }
}