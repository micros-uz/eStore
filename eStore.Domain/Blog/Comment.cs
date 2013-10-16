using System;

namespace eStore.Domain.Blog
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int ArticleId { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }

        public virtual Article Article { get; set; }
    }
}
