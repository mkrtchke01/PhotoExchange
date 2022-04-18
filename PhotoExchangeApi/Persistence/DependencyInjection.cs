using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<PostExchangeDbContext>(options =>
            {
                options.UseSqlServer(connectionString, b=>b.MigrationsAssembly("PhotoExchangeApi"));
            });
            return services;
        }
    }
}
