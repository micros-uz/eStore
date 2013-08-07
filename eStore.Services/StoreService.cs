using System.Collections.Generic;
using eStore.DataAccess.Repositories;
using eStore.Interfaces.Repositories;
using eStore.Interfaces.Services;
using eStore.Models;

namespace eStore.Services
{
    public class StoreService : IStoreService
    {
        #region IStoreService

        IEnumerable<Genre> IStoreService.GetGenres()
        {
            IEnumerable<Genre> list = new List<Genre>()
            {
                new Genre(){Title = "Romans"},
                new Genre(){Title = "Fixions"},
                new Genre(){Title = "Novells"}
            };

            var rpstr = new GenreRepository();

            list = rpstr.GetAll();

            return list;
        }

        IEnumerable<Genre> IStoreService.GetBooksByGenre(int genreId)
        {
            IGenreRepository rpstr = new GenreRepository();

            return rpstr.Find(x => x.GenreId == genreId);
        }

        #endregion
    }
}
