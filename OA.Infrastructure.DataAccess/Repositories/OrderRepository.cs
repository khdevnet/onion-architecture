using OA.Domain.Entities;
using OA.Domain.Extensibility.Repositories;
using OA.Infrastructure.DataAccess.Database;

namespace OA.Infrastructure.DataAccess.Repositories
{
    internal class OrderRepository : CrudRepository<Order, int>, IOrderRepository
    {
        public OrderRepository(ShopDbContext db) : base(db)
        {
        }
    }
}
