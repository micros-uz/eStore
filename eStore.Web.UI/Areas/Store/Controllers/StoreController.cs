using System.Collections.Generic;
using System.Web.Mvc;
using eStore.Domain;
using eStore.Interfaces.Services;
using eStore.Web.UI.Areas.Store.ViewModels;
using eStore.Web.Infrastructure.ObjectMapper;
using eStore.Web.UI.Logic;

namespace eStore.Web.UI.Areas.Store.Controllers
{
    [Authorize]
    public class StoreController : BaseDisposeController
    {
        private readonly IStoreService _service;
        private readonly IObjectMapper _objMapper;

        public StoreController(IStoreService service, IObjectMapper objMapper)
            :base(service)
        {
            _service = service;
            _objMapper = objMapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Browse(int id)
        {
            var books = _service.GetBooksByGenre(id);
            var bookModels = _objMapper.Map<IEnumerable<Book>, IEnumerable<BookModelEx>>(books);

            return View(bookModels);
        }
    }
}
