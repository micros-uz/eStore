using System.Data.Entity;
using eStore.DataAccess.Repositories.Ef;
using eStore.DataAccess.Repositories.Ef.BoundedContexts;

namespace eStore.Tests.DataAccess
{
    internal static class ContextHelper
    {
        internal static ForumContext GetForumContext()
        {
            Database.SetInitializer<ForumContext>(new CustomInitializer());

            return new ForumContext("eStoreTest");
        }
    }
}
