using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cinema.Shows.Booking.Repository.Factory;
using Cinema.Shows.Booking.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Cinema.Shows.Booking.Api
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureDatabase(services);
            services.AddMvc();

            services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "API",
                Version = "1.0.0",
                Description = ""
            }));

            //IOC
            services.AddScoped<ICommandFactory, CommandFactory>();
            services.AddScoped<IQueryFactory, QueryFactory>();
            services.AddScoped<IBookingService, BookingService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.UseCors("CorsPolicy");
            app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers().RequireCors("CorsPolicy");
                }
            );

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            ApplyMigrations(app);
        }

        private void ConfigureDatabase(IServiceCollection services)
        {
            var dbCon = Environment.GetEnvironmentVariable("db_con");
            var connectionString = dbCon;
            services.AddDbContext<CinemaDbContext>(
                options => options.UseSqlServer(connectionString));
        }

        /// <summary>
        /// This method to apply automatically appply migration
        /// It should not be used in production env
        /// Here it is only for test display so as not to make the application overloaded
        /// </summary>
        /// <param name="app"></param>
        private void ApplyMigrations(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices
            .GetRequiredService<IServiceScopeFactory>()
            .CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<CinemaDbContext>())
                {
                    context.Database.Migrate();
                }
            }
        }
    }
}
