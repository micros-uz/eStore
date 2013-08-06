using System.Data;
using System.Data.Entity;
using System.Linq;
using eStore.Interfaces.Repositories;

namespace eStore.DataAccess
{
    internal class EStoreDbContext : DbContext, IDbContext
    {
        #region IDbContext

        IQueryable<TEntity> IDbContext.All<TEntity>(params System.Linq.Expressions.Expression<System.Func<TEntity, object>>[] includeProperties)
        {
            return Set<TEntity>();
        }

        TEntity IDbContext.Find<TEntity>(int id)
        {
            return Set<TEntity>().Find(id);
        }

        TEntity IDbContext.Create<TEntity>()
        {
            var entity = Set<TEntity>().Create();
            //entity.GetType().GetProperties().ToList().ForEach(pi =>
            //{
            //    if (pi.PropertyType.IsGenericType &&
            //        pi.PropertyType.GetGenericTypeDefinition() == typeof(ICollection<>) &&
            //        pi.PropertyType.GetGenericArguments().Count() == 1 &&
            //        pi.PropertyType.GetGenericArguments()[0].GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEntity<>)))
            //    {
            //        var navigateModel = pi.PropertyType.GetGenericArguments()[0];
            //        pi.SetValue(entity, Activator.CreateInstance(typeof(HashSet<>).MakeGenericType(navigateModel)), null);
            //    }
            //});
            return entity;
        }

        void IDbContext.Insert<TEntity>(TEntity entity)
        {
            Set<TEntity>().Add(entity);

            //when we make IEntity<int> return entity.Id;
        }

        void IDbContext.Update<TEntity>(TEntity entity)
        {
            Entry(entity).State = EntityState.Modified;
        }

        void IDbContext.Delete<TEntity>(int id)
        {
            Set<TEntity>().Remove(Set<TEntity>().Find(id));
        }

        int IDbContext.SaveChanges()
        {
            return SaveChanges();
        }

        #endregion
    }
}
