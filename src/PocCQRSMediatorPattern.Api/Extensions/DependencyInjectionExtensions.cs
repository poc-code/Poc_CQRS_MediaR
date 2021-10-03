using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PocCQRSMediatorPattern.Library.Data;
using PocCQRSMediatorPattern.Library.Interface;
using System;
using System.Diagnostics.CodeAnalysis;

namespace PocCQRSMediatorPattern.Api.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class DependencyInjection
    {
        public static void ConfigureIoC(this IServiceCollection services, IConfiguration Configuration)
        {
            AddInfraConfigurations(services, Configuration);
            AddServices(services);
            AddRepositories(services);
            AddFluentValidations(services);
        }

        private static void AddFluentValidations(IServiceCollection services)
        {
        }

        private static void AddRepositories(IServiceCollection services)
        {
        }

        private static void AddServices(IServiceCollection services)
        {
        }

        private static void AddInfraConfigurations(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IDataAccess, DataAccess>();
            services.AddMediatR(typeof(DataAccess).Assembly);
        }
    }
}
