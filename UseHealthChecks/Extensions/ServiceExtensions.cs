

using Microsoft.Extensions.Diagnostics.HealthChecks;
using MyUseHealthChecks.Data;
using MyUseHealthChecks.services;

namespace MyUseHealthChecks.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services,
         WebApplicationBuilder builder)
        {
            //add db context
            var connection = builder.Configuration.GetConnectionString("DefultConnection");
            services.AddDbContext<ApplicationDBContext>(
                 op => op.UseSqlServer(connection));

            // add services
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //add health check
            builder.Services.AddHealthChecks()
                .AddSqlServer(
                connectionString:connection,
                healthQuery:"select * from employees",
                name:"sql server check",
                failureStatus:HealthStatus.Unhealthy,
                tags: new[] {"sql","sqlserver","healthchecks"})
                .AddCheck<ChuckNorrisHealthCheck>("Chuck Norris Api");



            return services;
        }
    }
}
