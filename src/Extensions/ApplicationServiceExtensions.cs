using System;
using LHMS.SystemReports.Services;
using LHMS.SystemReports.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NodaTime.Serialization.SystemTextJson;
using NodaTime;

namespace SystemReports.Extensions
{
    public static class ApplicationServiceExtensions
    {
        private const string healthCheckName = "Postgres Health Check";
        private const string localUrl = "http://localhost:5002/health";
        private const string testUrl = "https://test.lhms.dtwilliams10.com/health";
        private const string productionUrl = "https://lhms.dtwilliams10.com/health";

        public static IServiceCollection AddApplicationServicesForDevelopment(this IServiceCollection services, IConfiguration config)
        {
            services.AddCors(options =>
                            {
                                options.AddPolicy("myAllowSpecificOrigins",
                                                policy =>
                                                {
                                                    policy.SetIsOriginAllowed(origin =>
                                                    {
                                                        var uri = new Uri(origin);
                                                        return uri.IsLoopback;
                                                    })
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
            services.AddControllers().AddJsonOptions(options => { options.JsonSerializerOptions.ConfigureForNodaTime(DateTimeZoneProviders.Tzdb); });
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddHealthChecks().AddNpgSql(connectionString: config.GetConnectionString("SystemReports"), name: healthCheckName, failureStatus: Microsoft.Extensions.Diagnostics.HealthChecks.HealthStatus.Unhealthy, tags: ["db", "sql", "postgres"]);
            services.AddHealthChecksUI(setupSettings: setup =>
            {
                setup.AddHealthCheckEndpoint(healthCheckName, localUrl);
                setup.MaximumHistoryEntriesPerEndpoint(50);
            }).AddInMemoryStorage(databaseName: "HealthChecksUI");

            return services;
        }
        public static IServiceCollection AddApplicationServicesForStaging(this IServiceCollection services, IConfiguration config)
        {
            services.AddCors(options =>
                            {
                                options.AddPolicy("myAllowSpecificOrigins",
                                                policy =>
                                                {
                                                    policy.WithOrigins("https://test.lhms.dtwilliams10.com")
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
            services.AddControllers().AddJsonOptions(options => { options.JsonSerializerOptions.ConfigureForNodaTime(DateTimeZoneProviders.Tzdb); });
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddHealthChecks().AddNpgSql(connectionString: config.GetConnectionString("SystemReports"), name: healthCheckName, failureStatus: Microsoft.Extensions.Diagnostics.HealthChecks.HealthStatus.Unhealthy, tags: ["db", "sql", "postgres"]);
            services.AddHealthChecksUI(setupSettings: setup =>
            {
                setup.AddHealthCheckEndpoint(healthCheckName, testUrl);
                setup.MaximumHistoryEntriesPerEndpoint(50);
            }).AddInMemoryStorage(databaseName: "HealthChecksUI");

            return services;
        }

        public static IServiceCollection AddApplicationServicesForProduction(this IServiceCollection services, IConfiguration config)
        {
            services.AddCors(options =>
                            {
                                options.AddPolicy("myAllowSpecificOrigins",
                                                policy =>
                                                {
                                                    policy.WithOrigins("https://lhms.dtwilliams10.com")
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
            services.AddControllers().AddJsonOptions(options => { options.JsonSerializerOptions.ConfigureForNodaTime(DateTimeZoneProviders.Tzdb); });
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddHealthChecks().AddNpgSql(connectionString: config.GetConnectionString("SystemReports"), name: healthCheckName, failureStatus: Microsoft.Extensions.Diagnostics.HealthChecks.HealthStatus.Unhealthy, tags: ["db", "sql", "postgres"]);
            services.AddHealthChecksUI(setupSettings: setup =>
            {
                setup.AddHealthCheckEndpoint(healthCheckName, productionUrl);
                setup.MaximumHistoryEntriesPerEndpoint(50);
            }).AddInMemoryStorage(databaseName: "HealthChecksUI");

            return services;
        }
    }
}