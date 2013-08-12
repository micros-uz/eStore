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

        public ActionResult Index()
        {
            var genres = _Service.GetGenres();

            Mapper.CreateMap<Genre, GenreModel>();

            var genreModels = Mapper.Map<IEnumerable<Genre>, IEnumerable<GenreModel>>(genres);

            return View(genreModels);
        }

        [HttpGet]
        public ActionResult Browse(int id)
        {
            var books = _Service.GetBooksByGenre(id);
            Mapper.CreateMap<Book, BookModel>().ForMember(x => x.Author, x => x.MapFrom(w => w.Author.Name));
            var bookModels = Mapper.Map<IEnumerable<Book>, IEnumerable<BookModel>>(books);

            return View(bookModels);
        }

        public ActionResult Details(int id)
        {
            var book = _Service.GetBookById(id);

            Mapper.CreateMap<Book, BookFullModel>().ForMember(x => x.Author, x => x.MapFrom(w => w.Author.Name));
            var bookModel = Mapper.Map<Book, BookFullModel>(book);

            return View(bookModel);
        }
    }
}
