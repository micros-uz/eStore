using System.Data.Entity;
using eStore.DataAccess.Repositories.Ef.BoundedContexts;

namespace eStore.DataAccess.Repositories.Ef
{
    internal class CustomInitializer : DropCreateDatabaseAlways<BaseContext>
    {
        protected override void Seed(BaseContext context)
        {
            context.Database.ExecuteSqlCommand("alter table TopicCategories add constraint IX_TopicCategories_Title unique (Title)");
        }
    }
}
