using DinExApi.API.Configurations.Profiles;
using DinExApi.API.Validations;
using DinExApi.Business.Interfaces;
using DinExApi.Business.Services;
using DinExApi.Infrastructure.DB.Data;
using DinExApi.Infrastructure.DB.Seeders;
using DinExApi.Persistence.Interfaces;
using DinExApi.Persistence.Repositories;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DinExApi.API.Configurations
{
    public static class DIP
    {
        public static IServiceCollection DependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            #region General Settings with descriptions
            // add all configurations to a implementation singleton
            services.AddSingleton(configuration);

            // SQLite Connection using context
            services.AddEntityFrameworkSqlite().AddDbContext<DinExApiContext>();

            // add filters to be validated before any controller to be called
            services.AddMvc(
                options =>
                {
                    options.Filters.Add(new DTOStateFilter());
                }
            ).AddFluentValidation(
                options =>
                {
                    options.RegisterValidatorsFromAssemblyContaining<Startup>();
                }
            );
            #endregion

            #region AutoMappers
            services.AddAutoMapper(typeof(LaunchProfile));
            services.AddAutoMapper(typeof(CategoryProfile));
            services.AddAutoMapper(typeof(UserProfile));
            #endregion

            #region Seeders
            services.AddScoped<SeederBaseService>();
            #endregion

            #region Services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICategoryUserService, CategoryUserService>();
            services.AddScoped<ILaunchService, LaunchService>();
            #endregion

            #region Repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryUserRepository, CategoryUserRepository>();
            services.AddScoped<ILaunchRepository, LaunchRepository>();
            #endregion

            return services;
        }
    }

}
