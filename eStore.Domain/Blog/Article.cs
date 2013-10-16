using System;
using System.Collections.Generic;

namespace eStore.Domain.Blog
{
    public class Article
    {
        public int ArticleId { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public virtual IEnumerable<Comment> Comments { get; set; }
    }
}
