using OA.Domain.Entities;
using System.Collections.Generic;

namespace OA.Service.Extensibility
{
    public interface IShoppingCartService
    {
        void AddToCart(int albumId);

        int RemoveCartRecord(int recordId);

        void EmptyCart();

        IEnumerable<Cart> GetCartItems();

        Cart GetCartRecord(int recordId);

        int GetCount();

        decimal GetTotal();
    }
}
