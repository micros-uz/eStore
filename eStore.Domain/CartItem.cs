using System;

namespace eStore.Domain
{
    public class CartItem
    {
        public int CartItemId { get; set; }
        public Guid CartId { get; set; }
        public int BookId { get; set; }
        public int Count { get; set; }

        public virtual Book Book { get; set; }
    }
}
