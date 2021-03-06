using System;
using DotNetCodeChallenge.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace DotNetCodeChallenge.Infra
{
    public static class CustomConfigurations
    {
        public static IServiceCollection AddSwaggerHowTo(this IServiceCollection services)
        {
            services.AddSwaggerGen(options => {
                options.SwaggerDoc(name: "v1", new OpenApiInfo
                {
                    Title = "How to Use Products API",
                    Version = "1"
                });
            });

            return services;
        }

        public static IServiceCollection AddScopes(this IServiceCollection services)
        {
            services.AddScoped<ICheckBeerStatusService, CheckBeerStatusService>();
            services.AddScoped<IGetSensorTemperatureService, GetSensorTemperatureService>();
            return services;
        }
    }
}
