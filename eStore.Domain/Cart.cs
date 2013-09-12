using System.Collections.Generic;

namespace eStore.Domain
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
