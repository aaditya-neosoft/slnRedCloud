﻿using RedCloud.Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Identity
{
    //public static class IdentityServiceExtensions
    //{
    //    public static void AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
    //    {
    //        services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
    //        services.AddDbContext<IdentityDbContext>(
    //            options => options.UseSqlServer(configuration.GetConnectionString("IdentityConnectionString"),
    //            b => b.MigrationsAssembly(typeof(IdentityDbContext).Assembly.FullName)));
    //        services.AddIdentity<ApplicationUser, IdentityRole>()
    //            .AddEntityFrameworkStores<IdentityDbContext>().AddDefaultTokenProvIders();

    //        services.AddTransient<IAuthenticationService, AuthenticationService>();
    //        services.AddAuthentication(options =>
    //        {
    //            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    //            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    //        })
    //            .AddJwtBearer(o =>
    //            {
    //                o.RequireHttpsMetadata = false;
    //                o.SaveToken = false;
    //                o.TokenValIdationParameters = new TokenValIdationParameters
    //                {
    //                    ValIdateIssuerSigningKey = true,
    //                    ValIdateIssuer = true,
    //                    ValIdateAudience = true,
    //                    ValIdateLifetime = true,
    //                    ClockSkew = TimeSpan.Zero,
    //                    ValIdIssuer = configuration["JwtSettings:Issuer"],
    //                    ValIdAudience = configuration["JwtSettings:Audience"],
    //                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]))
    //                };

    //                o.Events = new JwtBearerEvents()
    //                {
    //                    OnAuthenticationFailed = c =>
    //                    {
    //                        c.NoResult();
    //                        c.Response.StatusCode = 500;
    //                        c.Response.ContentType = "text/plain";
    //                        return c.Response.WriteAsync(c.Exception.ToString());
    //                    },
    //                    OnChallenge = context =>
    //                    {
    //                        context.HandleResponse();
    //                        context.Response.StatusCode = 401;
    //                        context.Response.ContentType = "application/json";
    //                        var result = JsonConvert.SerializeObject("401 Not authorized");
    //                        return context.Response.WriteAsync(result);
    //                    },
    //                    OnForbIdden = context =>
    //                    {
    //                        context.Response.StatusCode = 403;
    //                        context.Response.ContentType = "application/json";
    //                        var result = JsonConvert.SerializeObject("403 Not authorized");
    //                        return context.Response.WriteAsync(result);
    //                    },
    //                };
    //            });
    //    }
    //}
}
