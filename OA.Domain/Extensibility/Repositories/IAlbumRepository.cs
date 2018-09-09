using OA.Domain.Entities;
using System.Collections.Generic;

namespace OA.Domain.Extensibility.Repositories
{
    public interface IAlbumRepository : ICrudRepository<Album, int>
    {
        IEnumerable<Album> GetTopSelling(int count);
    }
}
