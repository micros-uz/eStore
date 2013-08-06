using System.Collections.Generic;
using eStore.Interfaces.Services;
using eStore.Models;

namespace eStore.Services
{
    public class StoreService : IStoreService
    {
        #region IStoreService

        IEnumerable<Genre> IStoreService.GetGenres()
        {
            var list = new List<Genre>()
            {
                new Genre(){Title = "Romans"},
                new Genre(){Title = "Fixions"},
                new Genre(){Title = "Novells"}
            };

            return list;
        }

        #endregion
    }
}
