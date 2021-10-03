using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PocCQRSMediatorPattern.Library.Data;
using PocCQRSMediatorPattern.Library.Interface;

namespace PocCQRSMediatorPattern.CoreTest.Services
{
    public static class DependencyInjection
    {
        public static ServiceProvider InitService()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IDataAccess, DataAccess>();
            serviceCollection.AddMediatR(typeof(DataAccess).Assembly);
            return serviceCollection.BuildServiceProvider();
        }
    }
}
