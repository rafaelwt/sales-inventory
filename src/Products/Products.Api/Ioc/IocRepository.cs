using Products.Application.Interfaces.IRepositories;
using Products.Infrastructure.Repositories;

namespace Products.Api.Ioc
{
    public static class IocRepository
    {
        public static IServiceCollection AddDependency(this IServiceCollection services)
        {
            
            services.AddTransient<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
