using System.Collections.Generic;
using System.Linq.Expressions;
using System;

namespace eStore.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        
        void Add(T entity);

        //T Save(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
