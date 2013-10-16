using System;

namespace eStore.Domain.Store
{
    public class Book
    {
        public int BookId
        {
            get;
            set;
        }

        public int GenreId
        {
            get;
            set;
        }

        public int AuthorId
        {
            get;
            set;
        }

        public int? SeriesId
        {
            get;
            set;
        }

        public virtual Author Author
        {
            get;
            set;
        }

        public virtual Genre Genre
        {
            get;
            set;
        }

        public string Title
        {
            get;
            set;
        }

        public double Price
        {
            get;
            set;
        }

        public short Year
        {
            get;
            set;
        }

        public short Pages
        {
            get;
            set;
        }

        public string ISBN
        {
            get;
            set;
        }

        public string Desc
        {
            get;
            set;
        }

        public Guid? ImageFile
        {
            get;
            set;
        }

    }
}
