using Ninject;
using Ninject.Web.Mvc;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace OA.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            IKernel kernel = CreateKernel();

            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));

            Bootstraper.Start(kernel);
        }

        private IKernel CreateKernel()
        {
            var kernel = new StandardKernel();

            kernel.Load("OA*.dll");
            return kernel;
        }
    }
}
