namespace eStore.Web.UI.Areas.Store.ViewModels
{
    public class CartItemModel
    {
        public int CartItemId { get; set; }

        public int BookId
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

        public int Count
        {
            get;
            set;
        }
    }
}