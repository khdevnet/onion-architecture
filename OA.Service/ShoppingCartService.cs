using OA.Domain.Entities;
using OA.Domain.Extensibility.Repositories;
using OA.Service.Extensibility;
using OA.Web.Extensibility;
using System;
using System.Collections.Generic;

namespace OA.Service
{
    internal class ShoppingCartService : IShoppingCartService
    {
        private readonly ICurrentUserProvider currentUserProvider;
        private readonly ICartRepository cartRepository;

        private string cartId => currentUserProvider.GetCartId();

        public ShoppingCartService(ICurrentUserProvider currentUserProvider, ICartRepository cartRepository)
        {
            this.currentUserProvider = currentUserProvider;
            this.cartRepository = cartRepository;
        }

        public void AddToCart(int albumId)
        {
            Cart cartItem = cartRepository.GetCartItem(cartId, albumId);

            if (cartItem == null)
            {
                cartItem = new Cart
                {
                    AlbumId = albumId,
                    CartId = cartId,
                    Count = 1,
                    DateCreated = DateTime.Now
                };

                cartRepository.Add(cartItem);
            }
            else
            {
                cartRepository.AddItemCount(cartItem.Id, ++cartItem.Count);
            }
        }

        public void EmptyCart()
            => cartRepository.EmptyCart(cartId);

        public IEnumerable<Cart> GetCartItems()
            => cartRepository.GetCartItems(cartId);

        public int GetCount() => cartRepository.GetCount(cartId);

        public decimal GetTotal() => cartRepository.GetTotal(cartId);

        public int RemoveCartRecord(int recordId) => cartRepository.RemoveCartRecord(cartId, recordId);

        public Cart GetCartRecord(int recordId) => cartRepository.GetByRecordId(cartId, recordId);
    }
}
