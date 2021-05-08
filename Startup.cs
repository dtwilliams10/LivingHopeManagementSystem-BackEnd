using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using LHMSAPI.Helpers;
using LHMSAPI.Services;
using System;

namespace LHMSAPI
{
    public class Startup
    {
        private readonly IConfiguration Configuration;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DatabaseContext>();
            services.AddScoped<IStatusService, StatusService>();
            services.AddScoped<ISystemReportService, SystemReportService>();
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            services.AddCors();
            services.AddControllers();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DatabaseContext context)
        {
            //Environment check
            if (env.IsProduction())
            {
                app.UseExceptionHandler("/Error");
            }
            else
            {
                //app.UseDeveloperExceptionPage();
                var migrated = true;
                try
                {
                    Serilog.Log.Information("Attempting to migrate database.");
                    context.Database.Migrate();
                } catch (Npgsql.NpgsqlException ex)
                {
                    migrated = false;
                    Serilog.Log.Error("Migration failed!");
                    Serilog.Log.Error(ex.ToString());
                }

                if (migrated)
                Serilog.Log.Information("Database migrated successfully!");
            }

            app.UseRouting();
            app.UseCors(x => x
            .AllowAnyMethod()
            .AllowAnyHeader()
            .SetIsOriginAllowed(origin => true)
            .AllowCredentials());
            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}