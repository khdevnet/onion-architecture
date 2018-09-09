using Ninject.Modules;
using OA.Infrastructure.SessionDataAccess.Providers;
using OA.Web.Extensibility;

namespace OA.Infrastructure.SessionDataAccess
{
    public class SessionDataAccessNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ICurrentUserProvider>().To<CurrentUserProvider>();
        }
    }
}
