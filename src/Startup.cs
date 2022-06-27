using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using LHMS.SystemReports.Helpers;
using LHMS.SystemReports.Services;
using System;

namespace LHMS.SystemReports
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
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.AddSwaggerGen();
            services.AddDbContext<DatabaseContext>();
            services.AddScoped<IStatusService, StatusService>();
            services.AddScoped<ISystemReportService, SystemReportService>();
            services.AddScoped<ISystemReportStatusService, SystemReportStatusService>();
            services.AddScoped<ISystemNameService, SystemNameService>();

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
                Serilog.Log.Information("Running in production.");
                app.UseExceptionHandler("/Error");
            }
            else
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "SystemReports V1")
                );

                try
                {
                    Serilog.Log.Information("Attempting to migrate database.");
                    context.Database.Migrate();
                    Serilog.Log.Information("Database migrated successfully!");
                } 
                catch (Npgsql.NpgsqlException ex)
                {
                    Serilog.Log.Error("Migration failed!");
                    Serilog.Log.Error(ex.ToString());
                    return;
                }
            }

            app.UseRouting();

            app.UseCors(x => x
            .AllowAnyMethod()
            .AllowAnyHeader()
            .SetIsOriginAllowed(origin => true)
            .AllowCredentials());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                ///Adding this caused the app to crash on startup. Need to investigate
                //endpoints.MapHealthChecks("/health");
                endpoints.MapControllers();
            });
        }
    }
}
