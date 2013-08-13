using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using eStore.Domain;
using eStore.Interfaces.Services;
using eStore.Web.UI.Areas.Store.ViewModels;

namespace eStore.Web.UI.Areas.Store.Controllers
{
    [Authorize]
    public class StoreController : Controller
    {
        private IStoreService _Service;

        public StoreController(IStoreService service)
        {
            _Service = service;
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            var genres = _Service.GetGenres();

            var genreModels = Mapper.Map<IEnumerable<Genre>, IEnumerable<GenreModel>>(genres);

            return View(genreModels);
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Browse(int id)
        {
            var books = _Service.GetBooksByGenre(id);
            var bookModels = Mapper.Map<IEnumerable<Book>, IEnumerable<BookModel>>(books);

            return View(bookModels);
        }

        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            var book = _Service.GetBookById(id);

            var bookModel = Mapper.Map<Book, BookFullModel>(book);

            return View(bookModel);
        }
    }
}
