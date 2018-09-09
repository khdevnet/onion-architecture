using Ninject.Modules;
using OA.Service.Extensibility;

namespace OA.Service
{
    public class ServiceNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IShoppingCartService>().To<ShoppingCartService>();
            Bind<IOrderService>().To<OrderService>();
        }
    }
}
