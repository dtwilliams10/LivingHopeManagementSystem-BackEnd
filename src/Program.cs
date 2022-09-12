using System;
using System.Threading;
using LHMS.SystemReports.Helpers;
using LHMS.SystemReports.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddSwaggerGen();
    builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
    builder.Services.AddDbContext<DatabaseContext>();
    builder.Services.AddScoped<IStatusService, StatusService>();
    builder.Services.AddScoped<ISystemReportService, SystemReportService>();
    builder.Services.AddScoped<ISystemReportStatusService, SystemReportStatusService>();
    builder.Services.AddScoped<ISystemNameService, SystemNameService>();
    builder.Services.AddCors();
    builder.Services.AddControllers();
    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    builder.Host.UseSerilog((context, config) =>
    {
        config.MinimumLevel.Debug()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
            .MinimumLevel.Override("System", LogEventLevel.Warning)
            .MinimumLevel.Override("Microsoft.AspNetCore.Authentication", LogEventLevel.Information)
            .Enrich.FromLogContext()
            .WriteTo.File("logs/SystemReports.log", rollingInterval: RollingInterval.Day)
            .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}", theme: AnsiConsoleTheme.Literate);
    });

    var app = builder.Build();

    Log.Information("Starting System Reports Service!");

    if (app.Environment.IsProduction())
    {
        Serilog.Log.Information("Running in production.");
        app.UseExceptionHandler("/Error");
    }
    else
    {
        /*
        if(app.Environment.IsStaging())
        {
            while (!System.Diagnostics.Debugger.IsAttached)
            {
                Thread.Sleep(100); //Or Task.Delay()
            }

        }
        */

        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "SystemReports V1")
        );

        try
        {
            Log.Information("Attempting to migrate database.");
            using (var context = app.Services.CreateScope())
            {
                var databaseContext = context.ServiceProvider.GetRequiredService<DatabaseContext>();
                databaseContext.Database.Migrate();
            }
            Log.Information("Database migrated successfully!");
        }
        catch (Exception ex)
        {
            Log.Error("Migration failed!");
            Log.Error(ex.ToString());
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

    app.UseSerilogRequestLogging();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Unhandled Exception");
}
finally
{
    Log.Information("Shut down complete!");
    Log.CloseAndFlush();
}