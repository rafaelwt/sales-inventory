using Sales.Application.Interfaces.IRepositories;
using Sales.Infrastructure.Repositories;

namespace Sales.Api.Ioc
{
    public static class IocRepository
    {
        public static IServiceCollection AddDependency(this IServiceCollection services)
        {
            services.AddTransient<ISaleRepository, SaleRepository>();
            services.AddTransient<ISaleDetailsRepository, SaleDetailsRepository>();


            return services;
        }
    }
}
