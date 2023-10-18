using Application.Services;
using Application.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;
namespace Application.Dependencies
{
    public static class DependencyInjector
    {
        public static void InjectApplicationDependencies(this IServiceCollection services)
        {
            AddServices(services);
        }

        public static void AddServices(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProductService, ProductService>();
        }
    }
}