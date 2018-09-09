using OA.Domain.Entities;
using OA.Domain.Extensibility.Repositories;
using OA.Infrastructure.DataAccess.Database;
using System.Collections.Generic;
using System.Linq;

namespace OA.Infrastructure.DataAccess.Repositories
{
    internal class AlbumRepository : CrudRepository<Album, int>, IAlbumRepository
    {
        public AlbumRepository(ShopDbContext db) : base(db)
        {
        }

        public IEnumerable<Album> GetTopSelling(int count)
        {
            // Group the order details by album and return
            // the albums with the highest count

            return db.Albums
                .OrderByDescending(a => a.OrderDetails.Count())
                .Take(count)
                .ToList();
        }
    }
}
