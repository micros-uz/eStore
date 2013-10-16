using System.Collections.Generic;
using System.Linq;
using eStore.Domain.Store;
using eStore.Interfaces.Repositories;
using eStore.Interfaces.Services;

namespace eStore.Core.Services
{
    internal class StoreService : BaseUoWService, IStoreService
    {
        public StoreService(IUnitOfWork uow)
            : base(uow)
        {
        }

        #region IStoreService

        IEnumerable<Genre> IStoreService.GetGenres()
        {
            return UoW.GetRepository<Genre>().GetAll();
        }

        IEnumerable<Author> IStoreService.GetAuthors()
        {
            return UoW.GetRepository<Author>().GetAll();
        }

        IEnumerable<Book> IStoreService.GetBooksByGenre(int genreId)
        {
            return UoW.GetRepository<Book>().Find(x => x.GenreId == genreId).OrderBy(x => x.Title);
        }

        IEnumerable<Book> IStoreService.GetBooksByAuthor(int authorId)
        {
            return UoW.GetRepository<Book>().Find(x => x.AuthorId == authorId).OrderBy(x => x.Title);
        }

        Book IStoreService.GetBookById(int bookId)
        {
            return UoW.GetRepository<Book>().GetById(bookId);
        }

        void IStoreService.Update(Book book)
        {
            UoW.GetRepository<Book>().Update(book);
            UoW.Save();
        }

        void IStoreService.Delete(Book book)
        {
            UoW.GetRepository<Book>().Delete(book);
            UoW.Save();
        }

        void IStoreService.Add(Genre genre)
        {
            UoW.GetRepository<Genre>().Add(genre);
            UoW.Save();
        }

        void IStoreService.Add(Author author)
        {
            UoW.GetRepository<Author>().Add(author);
            UoW.Save();
        }

        void IStoreService.Add(Book book)
        {
            UoW.GetRepository<Book>().Add(book);
            UoW.Save();
        }

        Genre IStoreService.GetGenreById(int genreId)
        {
            return UoW.GetRepository<Genre>().GetById(genreId);
        }

        Author IStoreService.GetAuthorById(int authorId)
        {
            return UoW.GetRepository<Author>().GetById(authorId);
        }

        void IStoreService.Update(Genre genre)
        {
            UoW.GetRepository<Genre>().Update(genre);
            UoW.Save();
        }

        void IStoreService.DeleteGenreById(int id)
        {
            UoW.GetRepository<Genre>().Delete(id);
            UoW.Save();
        }

        IEnumerable<Book> IStoreService.SearchBooks(string searchqry)
        {
            return UoW.GetRepository<Book>().Find(x => x.Title.Contains(searchqry));
        }

        #endregion

    }
}
