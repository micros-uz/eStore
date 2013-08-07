using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace eStore.Interfaces.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private IDbContext _Context;

        public GenericRepository(IDbContext context)
        {
            _Context = context;
        }

        #region IGenericRepository<T>

        public IEnumerable<T> GetAll()
        {
            return _Context.All<T>();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _Context.All<T>().Where(predicate);
        }

        #endregion
    }
}
