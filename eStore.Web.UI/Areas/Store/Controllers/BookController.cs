using System;
using System.Collections.Generic;
using System.Web.Mvc;
using eStore.Domain.Store;
using eStore.Interfaces.Services;
using eStore.Web.Infrastructure;
using eStore.Web.Infrastructure.ObjectMapper;
using eStore.Web.UI.Areas.Store.ViewModels;

namespace eStore.Web.UI.Areas.Store.Controllers
{
    public class BookController : BaseStoreController
    {
        private readonly IFileService _fileService;

        public BookController(IStoreService service, IObjectMapper objMapper,
            IFileService fileService)
            : base(service, objMapper)
        {
            _fileService = fileService;
        }

        public ActionResult Index(int id)
        {
            var books = Service.GetBooksByGenre(id);
            var bookModels = Mapper.Map<IEnumerable<Book>, IEnumerable<BookFullModel>>(books);

            return View(new BookListModel
                {
                    Books = bookModels,
                    GenreId = id
                });
        }

        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            var book = Service.GetBookById(id);

            return CheckResource(book, () =>
                {
                    var bookModel = Mapper.Map<Book, BookFullModel>(book);

                    return View(bookModel);
                });
        }

        public ActionResult Image(string fileName)
        {
            var data = _fileService.GetImage(fileName);

            return data != null ? File(data.Item1, data.Item2) : null;
        }

        public ActionResult Edit(int id)
        {
            var book = Service.GetBookById(id);

            return CheckResource(book, () =>
            {
                var model = Mapper.Map<Book, BookFullModel>(book);

                FillDicts();

                return View("CreateEdit", new AddEditBookModel
                    {
                        Action = "Edit",
                        Book = model,
                        OldImageFile = book.ImageFile.HasValue ?
                            book.ImageFile.Value.ToString() : string.Empty
                    });
            });
        }

        [HttpPost]
        public ActionResult Edit(AddEditBookModel model)
        {
            if (ModelState.IsValid)
            {
                var book = Mapper.Map<BookFullModel, Book>(model.Book);

                var newFile = _fileService.SaveImage(model.Book.Image, model.OldImageFile, model.IsImageChanged);

                book.ImageFile = newFile.HasValue
                    ? newFile
                    : string.IsNullOrEmpty(model.Book.ImageFile)
                        ? (Guid?)null : new Guid(model.Book.ImageFile);

                Service.Update(book);

                return RedirectToAction("Index", new
                {
                    id = model.Book.GenreId
                });
            }
            else
            {
                FillDicts();

                ModelState.AddModelError("", "There Are errors");

                return View("CreateEdit", model);
            }
        }

        //  bad idea - GET requests should not change data
        public ActionResult Delete(int id, int genreId)
        {
            var book = Service.GetBookById(id);

            Service.Delete(book);

            return RedirectToAction("Index", new
            {
                id = genreId
            });
        }

        public ActionResult Create(int? genreId, int? authorId)
        {
            var model = new BookFullModel
            {
                GenreId = genreId.HasValue ? genreId.Value : 0,
                AuthorId = authorId.HasValue ? authorId.Value : 0,
            };

            FillDicts();

            return View("CreateEdit", new AddEditBookModel
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
                var book = Mapper.Map<BookFullModel, Book>(model.Book);

                book.ImageFile = _fileService.SaveImage(model.Book.Image, null, model.IsImageChanged);

                Service.Add(book);

                return RedirectToAction("Index", new
                {
                    id = model.Book.GenreId
                });
            }
            else
            {
                FillDicts();

                return View("CreateEdit", model);
            }
        }

        private void FillDicts()
        {
            ViewBag.Genres = new SelectList(Service.GetGenres(), "GenreId", "Title");
            ViewBag.Authors = new SelectList(Service.GetAuthors(), "AuthorId", "Name");
        }
    }
}
