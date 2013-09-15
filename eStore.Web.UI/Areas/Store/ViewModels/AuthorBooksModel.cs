using System.Collections.Generic;

namespace eStore.Web.UI.Areas.Store.ViewModels
{
    public class AuthorBooksModel
    {
        public AuthorModel Author { get; set; }
        public IEnumerable<BookFullModel> Books { get; set; }
    }
}