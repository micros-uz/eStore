using System.Collections.Generic;
using eStore.DataAccess.Repositories;
using eStore.Interfaces.Repositories;
using eStore.Interfaces.Services;
using eStore.Domain;

namespace eStore.Core
{
    public class StoreService : IStoreService
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

        IEnumerable<Genre> IStoreService.GetBooksByGenre(int genreId)
        {
            return null;//_genreRpstr.Find(x => x.GenreId == genreId);
        }

        #endregion
    }
}
