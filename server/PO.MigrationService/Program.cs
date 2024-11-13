using Microsoft.EntityFrameworkCore;
using PO.Infrastructure;
using PO.MigrationService;

var builder = Host.CreateApplicationBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddHostedService<Worker>();

builder.Services.AddOpenTelemetry()
    .WithTracing(tracing => tracing.AddSource(Worker.ActivitySourceName));

builder.AddSqlServerDbContext<PirateOdysseyContext>("pirate-s-odyssey-db", configureDbContextOptions: options =>
{
    options.UseSqlServer(
        serverOptions =>
        {
            serverOptions.MigrationsAssembly("PO.MigrationService");
            serverOptions.EnableRetryOnFailure();
        });
});

var connectionString = builder.Configuration.GetConnectionString("auth-db");
builder.Services.AddIdentityServer(options =>
{
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
});

var host = builder.Build();
host.Run();