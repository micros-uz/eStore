using System.Collections.Generic;
using System.Linq;
using eStore.Domain;
using eStore.Interfaces.Repositories;
using eStore.Interfaces.Services;

namespace eStore.Core.Services
{
    internal class CartService : BaseUoWService, ICartService
    {
        public CartService(IUnitOfWork uow)
            : base(uow)
        {
        }

        #region ICartService

        Cart ICartService.GetCart()
        {
            return new Cart
                {
                    Items = new List<CartItem>
                    {
                        new CartItem
                        {
                            CartItemId = 9,
                            Book = UoW.BooksRepository.GetAll().ToList()[0],
                            Count = 2
                        },
                        new CartItem
                        {
                            CartItemId = 39,
                            Book = UoW.BooksRepository.GetAll().ToList()[3],
                            Count = 1
                        }
                    }
                };
        }

        #endregion
    }
}
