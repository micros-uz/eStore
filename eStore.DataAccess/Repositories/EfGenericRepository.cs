using eStore.Interfaces.Repositories;
using eStore.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;

namespace eStore.DataAccess.Repositories
{
    public class EfGenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly IDbSet<T> _dbSet;

        public EfGenericRepository(IDbSet<T> dbSet)
        {
            _dbSet = dbSet;
        }

        #region IGenericRepository<T>

        public IEnumerable<T> GetAll()
        {
            //return _dbSet;

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
                Description = x.Field<string>("Description")
            }).OfType<T>();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        #endregion
    }
}
