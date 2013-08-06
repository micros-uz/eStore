using System.Collections.Generic;
using eStore.Models;

namespace eStore.Interfaces.Services
{
    public interface IStoreService
    {
        IEnumerable<Genre> GetGenres();
    }
}
