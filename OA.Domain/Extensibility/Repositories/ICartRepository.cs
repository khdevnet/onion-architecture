using OA.Domain.Entities;
using System.Collections.Generic;

namespace OA.Domain.Extensibility.Repositories
{
    public interface ICartRepository : ICrudRepository<Cart, string>
    {
        Cart GetCartItem(string cartId, int albumId);

        Cart GetByRecordId(string cartId, int recordId);

        Cart AddItemCount(int recordId, int count);

        int RemoveCartRecord(string cartId, int recordId);

        void EmptyCart(string cartId);

        IEnumerable<Cart> GetCartItems(string cartId);

        int GetCount(string cartId);

        decimal GetTotal(string cartId);
    }
}
