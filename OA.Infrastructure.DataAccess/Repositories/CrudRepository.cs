using OA.Domain.Extensibility.Repositories;
using OA.Infrastructure.DataAccess.Database;
using System.Collections.Generic;
using System.Linq;

namespace OA.Infrastructure.DataAccess.Repositories
{
    internal class CrudRepository<TEntity, TId> : ICrudRepository<TEntity, TId> where TEntity : class
    {
        protected readonly ShopDbContext db;

        public CrudRepository(ShopDbContext db)
        {
            this.db = db;
        }

        public TEntity Add(TEntity entity)
        {
            TEntity added = db.Set<TEntity>().Add(entity);
            db.SaveChanges();
            return added;
        }

        public IEnumerable<TEntity> Get(string path = null)
        {
            return (string.IsNullOrEmpty(path)
                ? db.Set<TEntity>()
                : db.Set<TEntity>().Include(path))
                .ToList();
        }

        public TEntity GetById(TId id)
        {
            return db.Set<TEntity>().Find(id);
        }
    }
}
