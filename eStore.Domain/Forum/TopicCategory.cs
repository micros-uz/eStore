﻿using System.Collections.Generic;

namespace eStore.Domain.Forum
{
    public class TopicCategory
    {
        public TopicCategory()
        {
            Topics = new List<Topic>();
        }

        public int TopicCategoryId { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }

        public virtual ICollection<Topic> Topics { get; set; }

    }
}
