using DinExApi.Infrastructure.DB.Data;
using DinExApi.Persistence.Interfaces;
using DinExApi.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DinExApi.API.Configurations
{
    public static class DIP
    {
        public static IServiceCollection DependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            //
            services.AddSingleton(configuration);

            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            return services;
        }
    }
}
