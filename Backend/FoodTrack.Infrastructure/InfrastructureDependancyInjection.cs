using FoodTrack.Application.Interfaces;
using FoodTrack.Infrastructure.ApplicationContext;
using FoodTrack.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FoodTrack.Infrastructure.HttpClients;
using FoodTrack.Infrastructure.Repositories;

namespace FoodTrack.Infrastructure
{
    public static class InfrastructureDependancyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ProductTrackDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("FoodTrackConnectionString")));

            services.AddScoped<IStockRepository, StockRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<OpenFoodFactClient>(sp =>
            {
                var httpClient = new HttpClient
                {
                    BaseAddress = new Uri(OpenFoodFactClient.StagingUrl)
                };

                return new OpenFoodFactClient(httpClient);
            });

            services.AddScoped<IExternalProductProvider, ExternalProductProvider>();
            return services;
        }
    }
}
