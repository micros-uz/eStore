using System.Collections.Generic;

namespace eStore.Interfaces.Repositories
{
    internal class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private IDbContext _Context;

        internal GenericRepository(IDbContext context)
        {
            _Context = context;
        }

        #region IGenericRepository<T>

        public IEnumerable<T> GetAll()
        {
            return _Context.All<T>();
        }

        #endregion
    }
}
