using DinExApi.Business.Interfaces;
using DinExApi.Business.Services;
using DinExApi.Infrastructure.DB.Seeders;
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

            #region Seeders
            services.AddScoped<SeederBaseService>();
            #endregion

            #region Services
            services.AddScoped<IUserService, UserService>();
            #endregion

            #region Repositories
            services.AddScoped<IUserRepository, UserRepository>();
            #endregion

            return services;
        }
    }
}
