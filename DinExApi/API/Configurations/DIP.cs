using DinExApi.API.Configurations.Profiles;
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

            #region AutoMappers
            services.AddAutoMapper(typeof(LaunchProfile));
            services.AddAutoMapper(typeof(CategoryProfile));
            #endregion

            #region Seeders
            services.AddScoped<SeederBaseService>();
            #endregion

            #region Services
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<ICategoryUserService, CategoryUserService>();
            services.AddTransient<ILaunchService, LaunchService>();
            #endregion

            #region Repositories
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ICategoryUserRepository, CategoryUserRepository>();
            services.AddTransient<ILaunchRepository, LaunchRepository>();
            #endregion

            return services;
        }
    }
}
