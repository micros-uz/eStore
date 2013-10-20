using System;
using System.Collections;
using System.Collections.Generic;
using eStore.Domain.Forum;

namespace eStore.Interfaces.Services
{
    public interface IForumService : IDisposable
    {
        IEnumerable<TopicCategory> GetTopicCategories();
        IEnumerable<Topic> GetTopics();
        IEnumerable<Post> GetPosts();
    }
}
