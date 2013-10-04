using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using eStore.Interfaces.Repositories;
using eStore.DataAccess.Repositories.Ef.BoundedContexts;

namespace eStore.DataAccess.Repositories.Ef
{
    /// <summary>
    /// IEnumerable vs IQueryable?
    /// http://codetunnel.com/blog/post/should-you-return-iqueryablet-from-your-repositories
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EfGenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly IDbSet<T> _dbSet;

        public EfGenericRepository(IBaseContext context)
        {
            _dbSet = (IDbSet<T>)((BaseContext)context).Set<T>();
        }

        #region IGenericRepository<T>

        public virtual IEnumerable<T> GetAll()
        {
            return _dbSet;//.ToList();
            /*
            var connStr = ConfigurationManager.ConnectionStrings["ESTORE_CONN_STR"];
            var conn = new SqlConnection(connStr.ConnectionString);
            DataTable t = null;

            try
            {
                conn.Open();
                var cmd = new SqlCommand("select * from Genres", conn);
                var rd = cmd.ExecuteReader();
                t = new DataTable();
                t.Load(rd);
            }
            catch (SqlException)
            {

            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

            return t.Select().Select(x => new Genre
            {
                GenreId = x.Field<int>("GenreId"),
                Title = x.Field<string>("Title"),
                Description = x.Field<string>("Desc")
            }).OfType<T>();
             * */
        }

        public virtual T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);//.ToList();
        }

        public virtual IEnumerable<T> GetByPage(int page, int itemsPerPage)
        {
            return _dbSet.Skip(itemsPerPage * (page - 1)).Take(itemsPerPage).ToList();
        }

        public virtual void Add(T entity)
        {
           // var entry = _dbSet.
            _dbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            _dbSet.AddOrUpdate(entity);
            //_dbSet.Attach(entity);
            //_dbSet.Entry(entity).State = EntityState.Modified;

        }

        public virtual void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public virtual void Delete(int id)
        {
            var entity = _dbSet.Find(id);

            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
        }

        #endregion
    }
}
