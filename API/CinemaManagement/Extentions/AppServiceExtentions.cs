using CinemaManagement.Data;
using CinemaManagement.Interfaces;
using CinemaManagement.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CinemaManagement.Extentions
{
    public static class AppServiceExtentions
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("Default"),
                    sqlServerOptionsAction: sqlOptions =>
                    {
                        sqlOptions.EnableRetryOnFailure(
                            maxRetryCount: 10,
                            maxRetryDelay: TimeSpan.FromSeconds(30),
                            errorNumbersToAdd: null);
                    });
            });
            services.AddCors();
            services.AddTransient<ITokenService, TokenService>();
            services.AddScoped<ISessionService, SessionService>();

            return services;
        }
    }
}
