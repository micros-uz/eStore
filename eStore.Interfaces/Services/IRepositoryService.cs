using eStore.Interfaces.Repositories;

namespace eStore.Interfaces.Services
{
    public interface IRepositoryService
    {
        IGenericRepository<T> GetRepository<T>() where T : class;
    }
}
