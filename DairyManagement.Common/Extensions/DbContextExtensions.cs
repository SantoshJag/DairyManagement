using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;

namespace DairyManagement.Common.Extensions
{
    public static class DbContextExtensions
    {
        public static IServiceCollection AddDairyDbContext<TDbContext>(this IServiceCollection services, IConfiguration configuration) where TDbContext : DbContext
        {
            services.AddDbContext<TDbContext>(options =>
            {
                var secretName = Environment.GetEnvironmentVariable("DBSecretName");

                // Example logic: retrieve from env or fallback to config
                string connectionString = string.Empty;

                if (!string.IsNullOrWhiteSpace(secretName))
                {
                    // Fetch from secret store, here you can add actual AWS or Azure Key Vault logic
                    // connectionString = SecretStore.GetSecretString(secretName);
                    connectionString = $"Host=localhost;Port=5433;Database=postgres;Username=postgres;Password=postgres;";
                }
                else
                {
                    connectionString = configuration.GetConnectionString("DairyDb");
                }

                options.UseNpgsql(connectionString);
            });

            return services;
        }
    }
}
