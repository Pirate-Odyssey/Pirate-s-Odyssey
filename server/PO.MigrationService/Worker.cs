using Duende.IdentityServer.EntityFramework.DbContexts;
using Duende.IdentityServer.EntityFramework.Mappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using PO.Infrastructure;
using PO.MigrationService.Data;
using System.Diagnostics;

namespace PO.MigrationService
{
    public class Worker(
       IServiceProvider serviceProvider,
       IHostApplicationLifetime hostApplicationLifetime) : BackgroundService
    {
        public const string ActivitySourceName = "Migrations";
        private static readonly ActivitySource s_activitySource = new(ActivitySourceName);

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            using var activity = s_activitySource.StartActivity("Migrating database", ActivityKind.Client);

            try
            {
                using var scope = serviceProvider.CreateScope();
                var apidbContext = scope.ServiceProvider.GetRequiredService<PirateOdysseyContext>();
                var grantContext = scope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>();
                var configContext = scope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();

                await EnsureDatabaseAsync(apidbContext, cancellationToken);
                await EnsureDatabaseAsync(grantContext, cancellationToken);
                await EnsureDatabaseAsync(configContext, cancellationToken);

                await RunMigrationAsync(apidbContext, cancellationToken);
                await RunMigrationAsync(grantContext, cancellationToken);
                await RunMigrationAsync(configContext, cancellationToken);

                await InitializeConfigDatabaseAsync(configContext, cancellationToken);
                await SeedApiDataAsync(apidbContext, cancellationToken);
            }
            catch (Exception ex)
            {
                activity?.AddException(ex);
                throw;
            }

            hostApplicationLifetime.StopApplication();
        }

        private static async Task EnsureDatabaseAsync(DbContext dbContext, CancellationToken cancellationToken)
        {
            var dbCreator = dbContext.GetService<IRelationalDatabaseCreator>();

            var strategy = dbContext.Database.CreateExecutionStrategy();
            await strategy.ExecuteAsync(async () =>
            {
                // Create the database if it does not exist.
                // Do this first so there is then a database to start a transaction against.
                if (!await dbCreator.ExistsAsync(cancellationToken))
                {
                    await dbCreator.CreateAsync(cancellationToken);
                }
            });
        }

        private static async Task RunMigrationAsync(DbContext dbContext, CancellationToken cancellationToken)
        {
            var strategy = dbContext.Database.CreateExecutionStrategy();
            await strategy.ExecuteAsync(async () =>
            {
                await dbContext.Database.MigrateAsync(cancellationToken);
            });
        }

        private static async Task SeedApiDataAsync(PirateOdysseyContext dbContext, CancellationToken cancellationToken)
        {
            var strategy = dbContext.Database.CreateExecutionStrategy();
            await strategy.ExecuteAsync(async () =>
            {
                // Seed the database
                await using var transaction = await dbContext.Database.BeginTransactionAsync(cancellationToken);

                await SeedDBSetAsync("Data/items.json", dbContext.Items, cancellationToken);
                await SeedDBSetAsync("Data/weapons.json", dbContext.Weapons, cancellationToken);
                await SeedDBSetAsync("Data/itemStats.json", dbContext.ItemStats, cancellationToken);
                await SeedDBSetAsync("Data/ships.json", dbContext.Ships, cancellationToken);
                await SeedDBSetAsync("Data/crews.json", dbContext.Crews, cancellationToken);
                await SeedDBSetAsync("Data/crewMembers.json", dbContext.CrewMembers, cancellationToken);

                await dbContext.SaveChangesAsync(cancellationToken);
                await transaction.CommitAsync(cancellationToken);
            });
        }

        public static async Task SeedDBSetAsync<T>(string file, DbSet<T> dbSet, CancellationToken cancellationToken) where T : class
        {
            using var reader = new StreamReader(file);
            var json = reader.ReadToEnd();
            var data = JsonConvert.DeserializeObject<T[]>(json);
            await dbSet.AddRangeAsync(data, cancellationToken);
        }

        public static async Task InitializeConfigDatabaseAsync(ConfigurationDbContext configContext, CancellationToken cancellationToken)
        {
            if (!configContext.Clients.Any())
            {
                foreach (var client in IdentityConfig.Clients)
                {
                    configContext.Clients.Add(client.ToEntity());
                }
                await configContext.SaveChangesAsync(cancellationToken);
            }

            if (!configContext.IdentityResources.Any())
            {
                foreach (var resource in IdentityConfig.IdentityResources)
                {
                    configContext.IdentityResources.Add(resource.ToEntity());
                }
                await configContext.SaveChangesAsync(cancellationToken);
            }

            if (!configContext.ApiScopes.Any())
            {
                foreach (var resource in IdentityConfig.ApiScopes)
                {
                    configContext.ApiScopes.Add(resource.ToEntity());
                }
                await configContext.SaveChangesAsync(cancellationToken);
            }
        }
    }
}