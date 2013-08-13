using System.Collections.Generic;
using System.Web.Mvc;

using eStore.Domain;
using eStore.Interfaces.Services;
using eStore.Web.UI.Areas.Store.ViewModels;
using eStore.Web.Infrastructure.ObjectMapper;

namespace eStore.Web.UI.Areas.Store.Controllers
{
    [Authorize]
    public class StoreController : Controller
    {
        private readonly IStoreService _service;
        private readonly IObjectMapper _objMapper;

        public StoreController(IStoreService service, IObjectMapper objMapper)
        {
            _service = service;
            _objMapper = objMapper;
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            var genres = _service.GetGenres();

            //var genreModels = Mapper.Map<IEnumerable<Genre>, IEnumerable<GenreModel>>(genres);
            var genreModels = _objMapper.Map<IEnumerable<Genre>, IEnumerable<GenreModel>>(genres);

            return View(genreModels);
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Browse(int id)
        {
            var books = _service.GetBooksByGenre(id);
            var bookModels = _objMapper.Map<IEnumerable<Book>, IEnumerable<BookModel>>(books);

            return View(bookModels);
        }

        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            var book = _service.GetBookById(id);

            var bookModel = _objMapper.Map<Book, BookFullModel>(book);

            return View(bookModel);
        }
    }
}
