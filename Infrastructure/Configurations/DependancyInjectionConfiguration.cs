using TUAApi.Repository.Product;
using TUAApi.Services.Product;

namespace TUAApi.Infrastructure.Configurations
{
    public static class DependancyInjectionConfiguration
    {
        public static void AddDIContainerService(this IServiceCollection services)
        {
            services.AddScoped<IProductRespository, ProductRespository>();
            services.AddScoped<IProductService, ProductService>();
        }
    }
}
