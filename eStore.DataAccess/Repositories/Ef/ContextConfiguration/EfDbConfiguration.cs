using System.Data.Entity;

namespace eStore.DataAccess.Repositories.Ef.ContextConfiguration
{
    public class EfDbConfiguration : DbConfiguration
    {
        public EfDbConfiguration()
        {
            SetDatabaseLogFormatter(
                (context, writeAction) => new OneLineFormatter(context, writeAction));
        }
    }
}
