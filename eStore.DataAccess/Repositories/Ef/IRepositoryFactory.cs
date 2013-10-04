using eStore.DataAccess.Repositories.Ef.BoundedContexts;
using eStore.Interfaces.Repositories;

namespace eStore.DataAccess.Repositories.Ef
{
    internal interface IRepositoryFactory
    {
        IGenericRepository<T> GetRepository<T>(IBaseContext context) where T : class;
    }
}
