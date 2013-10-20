using System.Collections.Generic;
using eStore.Domain.Forum;
using eStore.Interfaces.Repositories;
using eStore.Interfaces.Services;

namespace eStore.Core.Services
{
    internal class ForumService : BaseUoWService, IForumService
    {
        public ForumService(IUnitOfWork uow)
            : base(uow)
        {
        }

        #region IForumService

        IEnumerable<TopicCategory> IForumService.GetTopicCategories()
        {
            return UoW.GetRepository<TopicCategory>().GetAll();
        }

        IEnumerable<Topic> IForumService.GetTopics()
        {
            return UoW.GetRepository<Topic>().GetAll();
        }

        IEnumerable<Post> IForumService.GetPosts()
        {
            return UoW.GetRepository<Post>().GetAll();
        }

        #endregion
    }
}
