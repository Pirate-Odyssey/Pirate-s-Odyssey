using Microsoft.EntityFrameworkCore;
using Serilog;

namespace PO.IdentityServer;

internal static class HostingExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        // Add service defaults & Aspire components.
        builder.AddServiceDefaults();

        // comment if dont you want to add a UI
        builder.Services.AddRazorPages();

        var connectionString = builder.Configuration.GetConnectionString("auth-db");

        builder.Services.AddIdentityServer(options =>
            {
                // https://docs.duendesoftware.com/identityserver/v6/fundamentals/resources/api_scopes#authorization-based-on-scopes
                options.EmitStaticAudienceClaim = true;
                options.KeyManagement.Enabled = false;
            })
            .AddConfigurationStore(options =>
            {
                options.ConfigureDbContext = b => b.UseSqlServer(connectionString,
                    sql =>
                    {
                        sql.MigrationsAssembly("PO.MigrationService");
                        sql.EnableRetryOnFailure();
                    });
            })
            .AddOperationalStore(options =>
            {
                options.ConfigureDbContext = b => b.UseSqlServer(connectionString,
                    sql =>
                    {
                        sql.MigrationsAssembly("PO.MigrationService");
                        sql.EnableRetryOnFailure();
                    });
            })
            .AddTestUsers(TestUsers.Users);


        return builder.Build();
    }

    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        app.UseSerilogRequestLogging();

        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        // comment if dont you want to add a UI
        app.UseStaticFiles();
        app.UseRouting();

        app.UseIdentityServer();

        // comment if dont you want to add a UI
        app.UseAuthorization();
        app.MapRazorPages().RequireAuthorization();

        return app;
    }
}
