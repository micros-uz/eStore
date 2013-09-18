using System.Collections.Generic;

namespace eStore.Web.UI.Areas.Store.ViewModels
{
    public class CartModel
    {
        public string ReturnUrl { get; set; }

        public IEnumerable<CartItemModel> Items { get; set; }
    }
}