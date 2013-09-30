using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace eStore.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);

        T GetById(int id);

        IEnumerable<T> GetByPage(int page, int itemsPerPage);

        void Add(T entity);

        //T Save(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(int id);
    }
}
