using Ninject;
using OA.Core.Extensibility;
using System.Linq;

namespace OA.Web
{
    public static class Bootstraper
    {
        public static void Start(IKernel kernel)
        {
            kernel.GetAll<IInitializer>()
                .ToList()
                .ForEach(initializer => initializer.Init());
        }
    }
}
