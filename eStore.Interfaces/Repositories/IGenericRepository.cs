using System.Collections.Generic;
using System.Linq.Expressions;
using System;

namespace eStore.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
    }
}
