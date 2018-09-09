using AutoMapper;
using Ninject;
using Ninject.Modules;
using OA.Domain.Entities;
using OA.Web.ViewModels.Checkout;

namespace OA.Web
{
    public class AutoMapperNinjectModule : NinjectModule
    {
        public override void Load()
        {
            MapperConfiguration mapperConfiguration = CreateConfiguration();
            Bind<MapperConfiguration>().ToConstant(mapperConfiguration).InSingletonScope();

            // This teaches Ninject how to create automapper instances say if for instance
            // MyResolver has a constructor with a parameter that needs to be injected
            Bind<IMapper>().ToMethod(ctx => new Mapper(mapperConfiguration, type => ctx.Kernel.Get(type)));
        }

        private MapperConfiguration CreateConfiguration()
        {
            var config = new MapperConfiguration(cfg =>
            {
                // Add all profiles in current assembly
                cfg.AddProfiles(GetType().Assembly);
                cfg.CreateMap<OrderViewModel, Order>();
            });


            return config;
        }
    }
}
