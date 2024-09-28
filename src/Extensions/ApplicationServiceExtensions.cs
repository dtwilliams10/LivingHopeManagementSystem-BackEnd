using System;
using LHMS.SystemReports.Services;
using LHMS.SystemReports.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NodaTime.Serialization.SystemTextJson;
using NodaTime;

namespace LHMS.SystemReports.Extensions 
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddCors(options =>
                            {
                                options.AddPolicy("myAllowSpecificOrigins",
                                                policy =>
                                                {
                                                    policy
                                                        .WithOrigins("http://localhost:3001", "https://test.lhms.dtwilliams10.com", "https://lhms.dtwilliams10.com")
                                                        //.AllowAnyOrigin()
                                                        .SetIsOriginAllowedToAllowWildcardSubdomains()
                                                        .AllowAnyHeader()
                                                        .AllowAnyMethod()
                                                        .AllowCredentials();
                                                });
                            });
            services.AddSwaggerGen();
            services.Configure<AppSettings>(config.GetSection("AppSettings"));
            services.AddDbContext<DatabaseContext>();
            services.AddScoped<IStatusService, StatusService>();
            services.AddScoped<ISystemReportService, SystemReportService>();
            services.AddScoped<ISystemReportStatusService, SystemReportStatusService>();
            services.AddScoped<ISystemNameService, SystemNameService>();
            services.AddControllers().AddJsonOptions(options => {options.JsonSerializerOptions.ConfigureForNodaTime(DateTimeZoneProviders.Tzdb);});
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddHealthChecks().AddNpgSql(connectionString: config.GetConnectionString("SystemReports"), name: "Postgres Health Check", failureStatus: Microsoft.Extensions.Diagnostics.HealthChecks.HealthStatus.Unhealthy, tags: ["db", "sql", "postgres"]);
            services.AddHealthChecksUI(setupSettings: setup =>
            {
                setup.AddHealthCheckEndpoint("Postgres Health Check", $"http://{System.Net.Dns.GetHostName():5002}/health");
                setup.MaximumHistoryEntriesPerEndpoint(50);
            }).AddInMemoryStorage(databaseName: "HealthChecksUI");
            
            return services;
        } 
    }
}