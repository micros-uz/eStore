using System;

namespace eStore.Domain.Forum
{
    public class Post
    {
        public int PostId { get; set; }
        public int AuthorId { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }

        public virtual Topic Topic { get; set; }
    }
}
