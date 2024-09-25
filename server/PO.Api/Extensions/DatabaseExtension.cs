using Microsoft.EntityFrameworkCore;
using PO.Infrastructure;

namespace PO.Api.Extensions
{
    public static class DatabaseExtensions
    {
        public static IServiceCollection AddPOContext(this IServiceCollection services, string connectionString)
        {
            return services
                .AddDbContext<PirateOdysseyContext>(options =>
                {
                    options.UseSqlServer(connectionString,
                        serverOptions =>
                        {
                            serverOptions.MigrationsAssembly("PO.Migrations");
                        });
                });
        }
    }
}
