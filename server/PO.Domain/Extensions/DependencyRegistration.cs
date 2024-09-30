using PO.Domain.Mappers;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;

namespace PO.Domain.Extensions
{
    public static class DependencyRegistration
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services
                
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