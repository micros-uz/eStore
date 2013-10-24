using System;
using System.Collections.Generic;

namespace eStore.Domain.Forum
{
    public class Topic
    {
        public Topic()
        {
            Posts = new List<Post>();
        }

        public int TopicId { get; set; }
        public int TopicCategoryId { get; set; }
        public string Theme { get; set; }
        public int ViewsCount { get; set; }

        public virtual TopicCategory Category { get; set; }
        public virtual ICollection<Post>  Posts { get; set; }
    }
}
