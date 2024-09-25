using Microsoft.EntityFrameworkCore;
using PO.Infrastructure;
using PO.MigrationService;

var builder = Host.CreateApplicationBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddHostedService<Worker>();

builder.Services.AddOpenTelemetry()
    .WithTracing(tracing => tracing.AddSource(Worker.ActivitySourceName));

builder.AddSqlServerDbContext<PirateOdysseyContext>("pirates-odyssey", configureDbContextOptions: options =>
{
    options.UseSqlServer(
        serverOptions =>
        {
            serverOptions.MigrationsAssembly("PO.MigrationService");
            serverOptions.EnableRetryOnFailure();
        });
});

var host = builder.Build();
host.Run();