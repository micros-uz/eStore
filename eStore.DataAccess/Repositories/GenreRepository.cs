using System;
using System.Linq;
using System.Collections.Generic;
using eStore.Interfaces.Repositories;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using eStore.Models;

namespace eStore.DataAccess.Repositories
{
    public class GenreRepository : GenericRepository<Genre>, IGenreRepository
    {
        public GenreRepository(IDbContext context) : base(context)
        {

        }

        public GenreRepository()
            : base(new SimpleDbContext())
        {

        }


        #region IGenericRepository<eStore.Models.Genre>

        public IEnumerable<Genre> GetAll()
        {
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
            catch(SqlException)
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
                });
        }

        #endregion
    }
}
