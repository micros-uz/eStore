using eStore.DataAccess.Repositories.Ef.BoundedContexts;
using eStore.Interfaces.Repositories;

namespace eStore.DataAccess.Repositories.Ef
{
    internal class RepositoryFactory : IRepositoryFactory
    {
        public IGenericRepository<T> GetRepository<T>(IBaseContext context) where T:class
        {
            return new EfGenericRepository<T>(context);
        }

    }
}
