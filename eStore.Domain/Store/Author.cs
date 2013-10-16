using System.Collections.Generic;

namespace eStore.Domain.Store
{
    public class Author
    {
        public int AuthorId
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public virtual ICollection<Book> Books
        {
            get;
            set;
        }
    }
}
