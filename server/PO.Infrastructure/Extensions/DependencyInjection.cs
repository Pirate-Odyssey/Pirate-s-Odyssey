using Microsoft.Extensions.DependencyInjection;
using PO.Infrastructure.Repositories;

namespace Intranet.Infrastructure.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                .AddScoped<IItemRepository, ItemRepository>()
                .AddScoped<IWeaponRepository, WeaponRepository>()
                .AddScoped<IEquipmentRepository, EquipmentRepository>()
                .AddScoped<IItemStatRepository, ItemStatRepository>()
            ;
        }
    }
}