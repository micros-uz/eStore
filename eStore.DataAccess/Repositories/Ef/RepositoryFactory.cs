using eStore.Interfaces.Repositories;
using System.Data.Entity;

namespace eStore.DataAccess.Repositories.Ef
{
    internal class RepositoryFactory : IRepositoryFactory
    {
        public IGenericRepository<T> GetRepository<T>(DbContext context) where T:class
        {

            return new EfGenericRepository<T>(context.Set<T>());
        }

    }
}
