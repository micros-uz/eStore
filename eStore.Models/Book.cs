﻿namespace eStore.Models
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
    }
}
