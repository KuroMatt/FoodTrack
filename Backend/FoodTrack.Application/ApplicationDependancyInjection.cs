using Microsoft.Extensions.DependencyInjection;


namespace FoodTrack.Application
{
    public static class ApplicationDependancyInjection
    {
        public static IServiceCollection AddApplication(
           this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ApplicationAssemblyMarker).Assembly));

            return services;
        }
    }
}

