using System.Collections.Generic;

namespace eStore.Web.UI.Areas.Store.ViewModels
{
    public class GenreBooksModel
    {
        public IEnumerable<BookModel> Books { get; set; }

        public int GenreId { get; set; }
    }
}