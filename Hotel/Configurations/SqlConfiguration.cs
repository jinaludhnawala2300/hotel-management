using Hotel.DataLayer;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Configurations;

public static class SqlServerConfiguration
{
    public static void AddSqlServer(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration["ConnectionStrings:Default"];

        services.AddDbContext<HotelContext>(options =>
        {
            options.EnableSensitiveDataLogging();

            options.UseSqlServer(connectionString, x =>
            {
                x.MigrationsAssembly("Hotel.DataLayer");
                x.EnableRetryOnFailure(10, TimeSpan.FromSeconds(30), null);
            });
        });

    }
}