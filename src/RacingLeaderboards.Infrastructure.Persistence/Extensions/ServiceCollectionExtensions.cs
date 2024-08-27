using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RacingLeaderboards.Infrastructure.Persistence.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<RacingLeaderboardsDbContext>(opt =>
        {
            var connectionString = configuration.GetConnectionString("SqlServer");
            opt.UseSqlServer(connectionString);
        });

        return services;
    }
}