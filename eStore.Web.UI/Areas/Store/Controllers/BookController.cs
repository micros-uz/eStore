using System.Collections.Generic;
using System.Web.Mvc;
using eStore.Domain;
using eStore.Interfaces.Services;
using eStore.Web.Infrastructure;
using eStore.Web.Infrastructure.ObjectMapper;
using eStore.Web.UI.Areas.Store.ViewModels;
using eStore.Web.UI.Logic;

namespace eStore.Web.UI.Areas.Store.Controllers
{
    public class BookController : BaseDisposeController
    {
        private readonly IStoreService _service;
        private readonly IObjectMapper _objMapper;
        private readonly IFileService _fileService;

        public BookController(IStoreService service, IObjectMapper objMapper,
            IFileService fileService)
            : base(service)
        {
            _service = service;
            _objMapper = objMapper;
            _fileService = fileService;
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

        public ActionResult Image(string fileName)
        {
            var data = _fileService.GetImage(fileName);

            return data != null ? File(data.Item1, data.Item2) : null;
        }

        public ActionResult Edit(int id)
        {
            var book = _service.GetBookById(id);

            var model = _objMapper.Map<Book, BookFullModel>(book);

            FillDicts();

            return View("Create", new AddEditBookModel
                {
                    Action = "Edit",
                    Book = model,
                    OldImageFile = book.ImageFile.HasValue ?
                        book.ImageFile.Value.ToString() : string.Empty
                });
        }

        [HttpPost]
        public ActionResult Edit(AddEditBookModel model)
        {
            if (ModelState.IsValid)
            {
                var book = _objMapper.Map<BookFullModel, Book>(model.Book);

                book.ImageFile = _fileService.SaveImage(model.Book.Image, model.OldImageFile, model.IsImageChanged);

                _service.Update(book);

                return RedirectToAction("Index", new
                {
                    id = model.Book.GenreId
                });
            }
            else
            {
                FillDicts();

                ModelState.AddModelError("", "There Are errors");

                return View("Create", model);
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

            FillDicts();

            return View(new AddEditBookModel
            {
                Action = "Create",
                Book = model
            });
        }

        [HttpPost]
        public ActionResult Create(AddEditBookModel model)
        {
            if (ModelState.IsValid)
            {
                var book = _objMapper.Map<BookFullModel, Book>(model.Book);

                book.ImageFile = _fileService.SaveImage(model.Book.Image, null, model.IsImageChanged);

                _service.Add(book);

                return RedirectToAction("Index", new
                {
                    id = model.Book.GenreId
                });
            }
            else
            {
                FillDicts();

                return View(model);
            }
        }

        private void FillDicts()
        {
            ViewBag.Genres = new SelectList(_service.GetGenres(), "GenreId", "Title");
            ViewBag.Authors = new SelectList(_service.GetAuthors(), "AuthorId", "Name");
        }
    }
}
