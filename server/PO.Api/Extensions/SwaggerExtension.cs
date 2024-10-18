using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

namespace PO.Api.Extensions
{
    public static class SwaggerExtension
    {
        public static IServiceCollection AddPOSwagger(this IServiceCollection services, string docName)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(docName, new OpenApiInfo
                {
                    Version = "0.1",
                    Title = "Pirate's Odyssey - API",
                    Description = "Swagger for Pirate's Odyssey API",
                });

                options.MapType<TimeSpan>(() => new OpenApiSchema
                {
                    Type = "string",
                    Example = new OpenApiString("00:00:00")
                });

                options.EnableAnnotations();
            });
            services.AddSwaggerGenNewtonsoftSupport();
            return services;
        }
    }
}
