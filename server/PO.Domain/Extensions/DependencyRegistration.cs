using Microsoft.Extensions.DependencyInjection;
using PO.Domain.Mappers;
using System.Reflection;

namespace PO.Domain.Extensions
{
    public static class DependencyRegistration
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services
                .AddScoped<IItemService, ItemService>()
                .AddScoped<IItemStatService, ItemStatService>()
                .AddScoped<IWeaponService, WeaponService>()
                .AddScoped<IEquipmentService, EquipmentService>()
                .AddScoped<IShipService, ShipService>()
                .AddScoped<ICrewService, CrewService>()
                .AddScoped<ICrewMemberService, CrewMemberService>()
            ;
        }

        public static IServiceCollection AddMappers(this IServiceCollection services)
        {
            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.AddProfile<POProfile>();
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }

        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            return services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}