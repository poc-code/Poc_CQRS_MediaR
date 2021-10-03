using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using PocCQRSMediatorPattern.Library.Data;
using PocCQRSMediatorPattern.Library.Interface;
using System;
using System.Diagnostics.CodeAnalysis;

namespace PocCQRSMediatorPattern.CoreTest.Factory
{
    [ExcludeFromCodeCoverage]
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup>
        where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(
                services =>
                {
                    InitializeServiceProvider(services);
                });
        }

        private static IServiceProvider InitializeServiceProvider(IServiceCollection services)
        {

            services.AddScoped<IDataAccess, DataAccess>();
            services.AddMediatR(typeof(DataAccess).Assembly);

            return services.BuildServiceProvider();
        }
    }
}
