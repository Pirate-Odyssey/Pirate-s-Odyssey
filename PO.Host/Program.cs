var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");

var sql = builder.AddSqlServer("sql");
var sqldb = sql.AddDatabase("pirates-odyssey");

var apiService = builder.AddProject<Projects.PO_Api>("apiservice")
    .WithReference(sqldb);

builder.AddProject<Projects.PO_MigrationService>("migrations")
    .WithReference(sqldb);

builder.AddNpmApp("webfrontend", "../web/pirate-s-odyssey")
    .WithReference(cache)
    .WithReference(apiService)
    .WithHttpEndpoint(env: "PORT")
    .WithExternalHttpEndpoints()
    .PublishAsDockerFile();

builder.Build().Run();
