using System.Collections.Generic;

namespace eStore.Web.UI.Areas.Store.ViewModels
{
    public class HomeModel
    {
        public IEnumerable<BookFullModel> BestSellers
        {
            get;
            set;
        }

        public IEnumerable<BookFullModel> NewBooks
        {
            get;
            set;
        }
    }
}