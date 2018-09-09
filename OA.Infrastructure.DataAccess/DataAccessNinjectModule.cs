using Ninject.Modules;
using OA.Core.Extensibility;
using OA.Domain.Extensibility.Repositories;
using OA.Infrastructure.DataAccess.Database;
using OA.Infrastructure.DataAccess.Repositories;

namespace OA.Infrastructure.DataAccess
{
    public class DataAccessNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ShopDbContext>().ToSelf().InSingletonScope();
            Bind<IInitializer>().To<DatabaseSampleDataInitializer>();

            Bind(typeof(ICrudRepository<,>)).To(typeof(CrudRepository<,>));
            Bind<IAlbumRepository>().To<AlbumRepository>();
            Bind<ICartRepository>().To<CartRepository>();
            Bind<IOrderRepository>().To<OrderRepository>();
        }
    }
}
