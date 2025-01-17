using System;
using LHMS.SystemReports.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using HealthChecks.UI.Client;
using SystemReports.Extensions;

try
{
    var builder = WebApplication.CreateBuilder(args);

    // builder.Services.AddAuthorization(options =>
    // {
    // options.FallbackPolicy = new AuthorizationPolicyBuilder()
    //     .RequireAuthenticatedUser()
    //     .Build();
    // });
    builder.Host.UseSerilog((context, config) =>
    {
        config.MinimumLevel.Debug()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Debug)
            .MinimumLevel.Override("System", LogEventLevel.Debug)
            .MinimumLevel.Override("Microsoft.AspNetCore.Authentication", LogEventLevel.Debug)
            .Enrich.FromLogContext()
            .WriteTo.File("logs/SystemReports.log", rollingInterval: RollingInterval.Day, retainedFileCountLimit: 7)
            .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}", theme: AnsiConsoleTheme.Literate);
    });

    _ = builder.Environment.EnvironmentName switch
    {
        "Local" => builder.Services.AddApplicationServicesForDevelopment(builder.Configuration),
        "Development" => builder.Services.AddApplicationServicesForDevelopment(builder.Configuration),
        "Staging" => builder.Services.AddApplicationServicesForStaging(builder.Configuration),
        "Production" => builder.Services.AddApplicationServicesForProduction(builder.Configuration),
        _ => throw new InvalidOperationException($"Unknown environment: {builder.Environment.EnvironmentName}")
    };

    var app = builder.Build();
    app.UseStaticFiles();

    Log.Information("Starting System Reports Service");

    if (app.Environment.IsProduction())
    {
        Log.Information("Running in production.");
        app.UseExceptionHandler("/Error");
    }
    else
    {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c =>
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "SystemReports V1")
        );
    }

    try
    {
        Log.Information("Attempting to migrate database.");
        using (var context = app.Services.CreateScope())
        {
            var databaseContext = context.ServiceProvider.GetRequiredService<DatabaseContext>();
            await databaseContext.Database.MigrateAsync();
            await Models.Seed.SeedData(databaseContext);
        }
        Log.Information("Database migrated successfully!");
    }
    catch (Exception ex)
    {
        Log.Fatal(ex, "Migration failed!");
        return;
    }

    app.UseRouting();

    app.UseCors("myAllowSpecificOrigins");

    //app.UseAuthorization();

    app.MapControllers();

    app.MapHealthChecks("/health", new HealthCheckOptions
    {
        Predicate = _ => true,
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
    });

    app.MapHealthChecksUI(setup =>
    {
        setup.UIPath = "/health-ui";
        setup.AddCustomStylesheet("health-checks.css");
    });

    app.UseSerilogRequestLogging();
    await app.RunAsync();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Unhandled Exception");
}
finally
{
    Log.Information("Shut down complete!");
    await Log.CloseAndFlushAsync();
}