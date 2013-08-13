using eStore.Domain;
using System.Linq;
using eStore.Interfaces.Repositories;
using eStore.Interfaces.Services;
using System.Collections.Generic;

namespace eStore.Core.Services
{
    internal class StoreService : IStoreService
    {
        private IUnitOfWork _uow;
        public StoreService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        #region IStoreService

        IEnumerable<Genre> IStoreService.GetGenres()
        {
            IEnumerable<Genre> list = new List<Genre>()
            {
                new Genre(){Title = "Romans"},
                new Genre(){Title = "Fixions"},
                new Genre(){Title = "Novells"}
            };

            list = _uow.GenreRepository.GetAll();

            return list;
        }

        IEnumerable<Book> IStoreService.GetBooksByGenre(int genreId)
        {
            return _uow.BooksRepository.Find(x => x.GenreId == genreId);
        }

        Book IStoreService.GetBookById(int bookId)
        {
            return _uow.BooksRepository.Find(x => x.BookId == bookId).FirstOrDefault();
        }

        #endregion
    }
}
