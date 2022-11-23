using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace PhotoExchangeApi.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<PostExchangeDbContext>(options => { options.UseSqlServer(connectionString); });
        return services;
    }
}