using System.Collections.Generic;

namespace eStore.Domain.Forum
{
    public class Topic
    {
        public int TopicId { get; set; }
        public string Title { get; set; }

        public virtual IEnumerable<Post>  Posts { get; set; }
    }
}
