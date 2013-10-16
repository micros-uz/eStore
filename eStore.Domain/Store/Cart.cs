using System.Collections.Generic;

namespace eStore.Domain.Store
{
    public class Cart
    {
        public IEnumerable<CartItem> Items
        {
            get;
            set;
        }
    }
}
