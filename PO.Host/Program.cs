var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");

var sql = builder.AddSqlServer("sql-server");
var sqlDb = sql.AddDatabase("pirate-s-odyssey-db");
var sqlAuthDb = sql.AddDatabase("auth-db");
var sqlUserDb = sql.AddDatabase("user-db");

var apiService = builder.AddProject<Projects.PO_Api>("api-service")
    .WithReference(sqlUserDb);

builder.AddProject<Projects.PO_IdentityServer>("identityServer")
    .WithReference(sqlAuthDb);

builder.AddProject<Projects.PO_User_Api>("user-service")
    .WithReference(sqlAuthDb);

builder.AddProject<Projects.PO_MigrationService>("migrations")
    .WithReference(sqlDb)
    .WithReference(sqlAuthDb);

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
