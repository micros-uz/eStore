using System;
using System.Collections.Generic;
using eStore.Domain.Store;

namespace eStore.Interfaces.Services
{
    public interface IStoreService : IDisposable
    {
        IEnumerable<Genre> GetGenres();

        IEnumerable<Book> GetBooksByGenre(int genreId);
        IEnumerable<Book> GetBooksByAuthor(int authorId);

        Book GetBookById(int id);

        void Update(Book book);

        void Delete(Book book);

        void Add(Genre genre);
        void Add(Book book);

        Genre GetGenreById(int id);

        void Update(Genre genre);

        void DeleteGenreById(int id);

        IEnumerable<Author> GetAuthors();

        void Add(Author author);

        IEnumerable<Book> SearchBooks(string searchQry);

        Author GetAuthorById(int id);
    }
}
