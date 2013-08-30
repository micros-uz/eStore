using System.Collections.Generic;
using eStore.Domain;
using System;

namespace eStore.Interfaces.Services
{
    public interface IStoreService : IDisposable
    {
        IEnumerable<Genre> GetGenres();

        IEnumerable<Book> GetBooksByGenre(int genreId);

        Book GetBookById(int id);

        void Update(Book book);

        void Delete(Book book);

        void Add(Genre genre);
        void Add(Book book);

        Genre GetGenreById(int id);

        void Update(Genre genre);

        void DeleteGenreById(int id);
    }
}
