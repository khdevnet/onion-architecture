using OA.Domain.Entities;
using OA.Domain.Extensibility.Repositories;
using OA.Infrastructure.DataAccess.Database;
using System.Collections.Generic;
using System.Linq;

namespace OA.Infrastructure.DataAccess.Repositories
{
    internal class CartRepository : CrudRepository<Cart, string>, ICartRepository
    {
        public CartRepository(ShopDbContext db) : base(db)
        {

        }

        public Cart AddItemCount(int recordId, int count)
        {
            Cart cart = db.Carts.SingleOrDefault(c => c.Id == recordId);

            cart.Count = count;
            db.SaveChanges();
            return cart;
        }

        public Cart GetCartItem(string cartId, int albumId)
            => db.Carts.SingleOrDefault(c => c.CartId == cartId && c.AlbumId == albumId);

        public int RemoveCartRecord(string cartId, int recordId)
        {
            Cart cartItem = db.Carts.Single(cart => cart.CartId == cartId && cart.Id == recordId);

            int itemCount = 0;

            if (cartItem != null)
            {
                if (cartItem.Count > 1)
                {
                    cartItem.Count--;
                    itemCount = cartItem.Count;
                }
                else
                {
                    db.Carts.Remove(cartItem);
                }

                db.SaveChanges();
            }

            return itemCount;
        }

        public void EmptyCart(string cartId)
        {
            IEnumerable<Cart> cartItems = db.Carts.Where(cart => cart.CartId == cartId).ToList();

            foreach (Cart cartItem in cartItems)
            {
                db.Carts.Remove(cartItem);
            }

            db.SaveChanges();
        }

        public IEnumerable<Cart> GetCartItems(string cartId)
            => db.Carts.Where(cart => cart.CartId == cartId).ToList();

        public int GetCount(string cartId)
        {
            int? count = (from cartItems in db.Carts
                         where cartItems.CartId == cartId
                         select (int?)cartItems.Count).Sum();

            return count ?? 0;
        }

        public decimal GetTotal(string cartId)
        {
            decimal? total = (from cartItems in db.Carts
                              where cartItems.CartId == cartId
                              select (int?)cartItems.Count * cartItems.Album.Price).Sum();
            return total ?? decimal.Zero;
        }

        public Cart GetByRecordId(string cartId, int recordId)
            => db.Carts.Include(nameof(Album)).Single(item => item.CartId == cartId && item.Id == recordId);
    }
}
