using System.Collections.Generic;
using eStore.Domain;

namespace eStore.Interfaces.Services
{
    public interface IStoreService
    {
        IEnumerable<Genre> GetGenres();

        IEnumerable<Genre> GetBooksByGenre(int genreId);
    }
}
