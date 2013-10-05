using System.Data.Entity;
using eStore.DataAccess.Repositories.Ef;

namespace eStore.DataAccess
{
    internal static class OrmInitializer
    {
        /// <summary>
        /// Initializes ORM (EF or NHibernate)
        /// </summary>
        internal static void Init()
        {
            EfInitializer.Init();
        }
    }
}
