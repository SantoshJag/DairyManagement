using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using Microsoft.Extensions.Logging;

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

                secretName = "Not Empty";
                if (!string.IsNullOrWhiteSpace(secretName))
                {
                    Console.WriteLine("Calling code connection string.");
                    // Fetch from secret store, here you can add actual AWS or Azure Key Vault logic
                    // connectionString = SecretStore.GetSecretString(secretName);
                    // connectionString = $"Host=localhost;Port=5433;Database=dairy_management;Username=postgres;Password=postgres;";
                    connectionString = $"Host=db;Port=5432;Database=dairy_management;Username=postgres;Password=postgres;";
                }
                else
                {
                    Console.WriteLine("Calling app setting connection string.");
                    // connectionString = configuration.GetConnectionString("DairyDb");
                }
                Console.WriteLine($"String: {connectionString}");
                options.UseNpgsql(connectionString);
                // options.UseNpgsql(connectionString)
                //         .LogTo(Console.WriteLine, LogLevel.Information)
                //         .EnableSensitiveDataLogging();
            });

            return services;
        }
    }
}
