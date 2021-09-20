using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

using Recipe.Sonar.Auth;
using Recipe.Logic.Services;
using Recipe.Data;
using Recipe.Data.Repositories;

namespace Recipe.Sonar
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors
            (
                options =>
                {
                    options.AddPolicy
                    (
                        "AllowSpecificOrigin",
                        builder =>
                        {
                            builder
                            .WithOrigins("http://localhost:4200")
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials();
                        }
                    );
                }
            );

            var domain = Configuration["Auth0:Domain"];
            var audience = Configuration["Auth0:Audience"];
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer
            (
                options =>
                {
                    options.Authority = domain;
                    options.Audience = audience;
                    // If the access token does not have a `sub` claim, `User.Identity.Name` will be `null`. Map it to a different claim by setting the NameClaimType below.
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = domain,
                        ValidateAudience = true,
                        ValidAudience = audience,
                        NameClaimType = ClaimTypes.NameIdentifier
                    };
                }
            );

            services.AddAuthorization(options =>
            {
                options.AddPolicy("create:users", policy => policy.Requirements.Add(new HasScopeRequirement("create:users", domain)));
                options.AddPolicy("read:users", policy => policy.Requirements.Add(new HasScopeRequirement("read:users", domain)));
                options.AddPolicy("update:users", policy => policy.Requirements.Add(new HasScopeRequirement("update:users", domain)));
                options.AddPolicy("delete:users", policy => policy.Requirements.Add(new HasScopeRequirement("delete:users", domain)));
            });

            services.AddControllers();

            services.AddSingleton<IAuthorizationHandler, HasScopeHandler>();

            // Services
            services.AddTransient<IUserService, UserService>();
            
            // Repositories
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IUserRepository, UserRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors("AllowSpecificOrigin");
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
