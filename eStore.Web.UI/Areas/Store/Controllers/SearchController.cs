using System.Collections.Generic;
using System.Web.Mvc;
using eStore.Domain;
using eStore.Interfaces.Services;
using eStore.Web.Infrastructure.ObjectMapper;
using eStore.Web.UI.Areas.Store.ViewModels;

namespace eStore.Web.UI.Areas.Store.Controllers
{
    public class SearchController : Controller
    {
        private readonly IStoreService _service;
        private readonly IObjectMapper _mapper;

        public SearchController(IStoreService service, IObjectMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [ChildActionOnly]
        public ActionResult Search()
        {
            return PartialView("_Search");
        }

        public ActionResult Go(string searchqry)
        {
            var books = _service.SearchBooks(searchqry);

            var models = _mapper.Map<IEnumerable<Book>, IEnumerable<BookFullModel>>(books);

            return View(models);
        }
    }
}