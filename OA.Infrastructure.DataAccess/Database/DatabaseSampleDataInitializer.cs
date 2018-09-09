using OA.Core.Extensibility;

namespace OA.Infrastructure.DataAccess.Database
{
    internal class DatabaseSampleDataInitializer : IInitializer
    {
        public void Init()
        {
            System.Data.Entity.Database.SetInitializer(new SampleData());
        }
    }
}
