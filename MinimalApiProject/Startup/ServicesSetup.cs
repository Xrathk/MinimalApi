using DataAccessLayer.DbAccess;
using Domain.Converters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

namespace MinimalApiProject.Startup
{
    /// <summary>
    /// Sets up necessary services for the AkisApi application via dependency injection.
    /// </summary>
    public static class ServicesSetup
    {
        /// <summary>
        /// Adds basic services to the AkisApi service container.
        /// </summary>
        /// <param name="services">Application service container</param>
        /// <returns>The new service container</returns>
        public static IServiceCollection RegisterBasicServices(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();

            // Return new service container
            return services;
        }

        /// <summary>
        /// Configures extra JsonSerialization options for the AkisApi application.
        /// </summary>
        /// <param name="services">Application service container</param>
        /// <returns>The new service container</returns>
        public static IServiceCollection ConfigureJsonOptions(this IServiceCollection services)
        {
            services.Configure<JsonOptions>(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter());

            });

            // Return new service container
            return services;
        }

        /// <summary>
        /// Configures swagger for the AkisApi application.
        /// </summary>
        /// <param name="services">Application service container</param>
        /// <returns>The new service container</returns>
        public static IServiceCollection ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen();
            // Extra swagger config for properties
            services.AddSwaggerGen(options =>
                options.MapType<DateOnly>(() => new OpenApiSchema
                {
                    Type = "string",
                    Format = "date",
                    Example = new OpenApiString("2022-01-01")
                })
            );

            // Return new service container
            return services;
        }

        /// <summary>
        /// Adds repositories and data access service to the AkisApi service container.
        /// </summary>
        /// <param name="services">Application service container</param>
        /// <returns>The new service container</returns>
        public static IServiceCollection RegisterDataAccess(this IServiceCollection services)
        {
            // Basic data access
            services.AddSingleton<ISqlDataAccess, SqlDataAccess>();

            // Repositories
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IUserAdditionalInfoRepository, UserAdditionalInfoRepository>();
            services.AddSingleton<IPlanetRepository, PlanetRepository>();
            services.AddSingleton<IJobSectorRepository, JobSectorRepository>();
            services.AddSingleton<IUserJobRepository, UserJobRepository>();
            services.AddSingleton<IUserAddressRepository, UserAddressRepository>();

            // Return new service container
            return services;
        }

    }
}