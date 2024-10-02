var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");

var sql = builder.AddSqlServer("sql-server");
var sqldb = sql.AddDatabase("pirate-s-odyssey-db");

var apiService = builder.AddProject<Projects.PO_Api>("apiservice")
    .WithReference(sqldb);

builder.AddProject<Projects.PO_MigrationService>("migrations")
    .WithReference(sqldb);

builder.AddNpmApp("pirate-s-odyssey", "../web/pirate-s-odyssey")
    .WithReference(cache)
    .WithReference(apiService)
    .WithHttpEndpoint(env: "PORT")
    .WithExternalHttpEndpoints()
    .PublishAsDockerFile();

builder.AddNpmApp("back-office", "../web/back-office")
    .WithReference(cache)
    .WithReference(apiService)
    .WithHttpEndpoint(env: "PORT")
    .WithExternalHttpEndpoints()
    .PublishAsDockerFile();

builder.Build().Run();
