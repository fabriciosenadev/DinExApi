using DinExApi.Business.Interfaces;
using DinExApi.Business.Services;
using DinExApi.Infrastructure.DB.Data;
using DinExApi.Infrastructure.DB.Seeders;
using DinExApi.Persistence.Interfaces;
using DinExApi.Persistence.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DinExApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            
            // make works SQLite based on context - replace a standard constructor
            //using (var client = new DinExApiContext())
            //{
            //    client.Database.EnsureCreated();
            //}
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DinExApi", Version = "v1" });
            });

            // make SQLite works
            services.AddEntityFrameworkSqlite().AddDbContext<DinExApiContext>();

            //---Services---
            services.AddScoped<SeederBaseService>();

            //---necessary to migrate to dependecy after this is ready---
            #region Services
            services.AddScoped<IUserService, UserService>();
            #endregion
            #region Repositories
            services.AddScoped<IUserRepository, UserRepository>();
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, SeederBaseService seederBaseService)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                // propagations of base data in development env
                seederBaseService.Seed();

                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DinExApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
