using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using LHMSAPI.Repository;
using Microsoft.AspNetCore.Identity;
using System;
using Serilog;

namespace LHMSAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected enum environment { DEV, STAGING, PRODUCTION }
        protected environment envmnt {get; set; }

        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<StatusRepository>();
            services.Configure<IdentityOptions>(options =>
            {
                //Password settings
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 10;
                options.Password.RequiredUniqueChars = 1;

                //Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.AllowedForNewUsers = true;

                //User settings
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ01234567890-._@+";
                options.User.RequireUniqueEmail = true;
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
                if(envmnt.Equals(environment.PRODUCTION))
                {
                    options.LoginPath = "https://lhms.dtwilliams10.com/login";
                    options.AccessDeniedPath = "https://lhms.dtwillaims10.com/loginDenied";
                }
                else if(envmnt.Equals(environment.STAGING))
                {
                    options.LoginPath = "https://test.lhms.dtwilliams10.com/login";
                    options.AccessDeniedPath = "https://test.lhms.dtwillaims10.com/loginDenied";
                }
                else if(envmnt.Equals(environment.DEV))
                {
                    options.LoginPath = "https://localhost:3000/login";
                    options.AccessDeniedPath = "https://localhost:3000/loginDenied";
                }
                options.SlidingExpiration = true;
            });

            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("PostgreSQL"));
            });
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
            {
                builder.WithOrigins("http://localhost:3000", "https://*.dtwilliams10.com")
                                    .AllowAnyHeader()
                                    .AllowAnyMethod()
                                    .SetIsOriginAllowedToAllowWildcardSubdomains();
            });
            });
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            //Environment check
            if (env.IsProduction())
            {
                app.UseExceptionHandler("/Error");
                envmnt = environment.PRODUCTION;
                Log.Information("Environment set to Production");
            }
            else
            {
                app.UseDeveloperExceptionPage();
                if (env.IsStaging())
                {
                    envmnt = environment.STAGING;
                    Log.Information("Environment set to Staging");
                }
                else if (env.IsDevelopment())
                {
                    envmnt = environment.DEV;
                    Log.Information("Environment set to Development");
                }
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors(MyAllowSpecificOrigins);
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapDefaultControllerRoute(); });
        }
    }
}