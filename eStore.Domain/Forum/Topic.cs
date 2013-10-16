using System;
using System.Collections.Generic;

namespace eStore.Domain.Forum
{
    public class Topic
    {
        public int TopicId { get; set; }
        public string Theme { get; set; }
        public int ViewsCount { get; set; }

        public virtual IEnumerable<Post>  Posts { get; set; }
    }
}
