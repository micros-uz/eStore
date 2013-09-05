using System.Collections.Generic;
using System.Web.Mvc;
using eStore.Domain;
using eStore.Interfaces.Services;
using eStore.Web.Infrastructure.ObjectMapper;
using eStore.Web.UI.Areas.Store.ViewModels;
using eStore.Web.UI.Logic;

namespace eStore.Web.UI.Areas.Store.Controllers
{
    public class BookController : BaseDisposeController
    {
        private readonly IStoreService _service;
        private readonly IObjectMapper _objMapper;
        public BookController(IStoreService service, IObjectMapper objMapper)
            : base(service)
        {
            _service = service;
            _objMapper = objMapper;
        }

        public ActionResult Index(int id)
        {
            var books = _service.GetBooksByGenre(id);
            var bookModels = _objMapper.Map<IEnumerable<Book>, IEnumerable<BookModel>>(books);

            return View(new GenreBooksModel
                {
                    Books = bookModels,
                    GenreId = id
                });
        }

        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            var book = _service.GetBookById(id);

            var bookModel = _objMapper.Map<Book, BookFullModel>(book);

            return View(bookModel);
        }

        public ActionResult Edit(int id)
        {
            var book = _service.GetBookById(id);

            var model = _objMapper.Map<Book, BookFullModel>(book);

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(BookFullModel model)
        {
            if (ModelState.IsValid)
            {
                var book = _objMapper.Map<BookFullModel, Book>(model);

                _service.Update(book);

                return RedirectToAction("Index", new
                {
                    id = model.GenreId
                });
            }
            else
            {
                ModelState.AddModelError("", "There Are errors");

                return View(model);
            }
        }

        //  bad idea - GET requests should not change data
        public ActionResult Delete(int id, int genreId)
        {
            var book = _service.GetBookById(id);

            _service.Delete(book);

            return RedirectToAction("Index", new
            {
                id = genreId
            });
        }

        public ActionResult Create(int id)
        {
            var model = new BookFullModel
            {
                GenreId = id
            };

            FillGenres();

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(BookFullModel model)
        {
            if (ModelState.IsValid)
            {
                var book = _objMapper.Map<BookFullModel, Book>(model);

                byte[] imageData = null;

                if (model.Image != null && model.Image.ContentLength > 0 &&
                    model.Image.ContentType == "image/jpeg")
                {
                    imageData = new byte[model.Image.ContentLength];
                    model.Image.InputStream.Read(imageData, 0, model.Image.ContentLength);
                }

                _service.Add(book, imageData, HttpContext.Request.PhysicalApplicationPath);
            }

            return RedirectToAction("Index", new
            {
                id = model.GenreId
            });
        }

        private void FillGenres()
        {
            ViewBag.Genres = new SelectList(_service.GetGenres(), "GenreId", "Title");
            ViewBag.Authors = new SelectList(_service.GetAuthors(), "AuthorId", "Name");
        }
    }
}
