using eStore.Interfaces.Repositories;
using System.Data.Entity;

namespace eStore.DataAccess.Repositories.Ef
{
    internal interface IRepositoryFactory
    {
        IGenericRepository<T> GetRepository<T>(DbContext context) where T : class;

    }
}
