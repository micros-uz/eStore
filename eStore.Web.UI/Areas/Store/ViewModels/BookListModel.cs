using System.Collections.Generic;

namespace eStore.Web.UI.Areas.Store.ViewModels
{
    public class BookListModel
    {
        public IEnumerable<BookFullModel> Books { get; set; }

        public int? GenreId { get; set; }

        public int? AuthorId { get; set; }
    }
}