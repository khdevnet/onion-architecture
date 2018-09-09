using System.Collections.Generic;

namespace OA.Domain.Extensibility.Repositories
{
    public interface ICrudRepository<TEntity, TId> where TEntity : class
    {
        TEntity GetById(TId id);

        TEntity Add(TEntity entity);

        IEnumerable<TEntity> Get(string path = null);
    }
}
