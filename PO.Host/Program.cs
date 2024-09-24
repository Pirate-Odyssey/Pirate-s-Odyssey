var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");

var apiService = builder.AddProject<Projects.PO_Api>("apiservice");

builder.AddNpmApp("webfrontend", "../web/pirate-s-odyssey")
    .WithReference(cache)
    .WithReference(apiService)
    .WithHttpEndpoint(port:4200, env: "PORT")
    .WithExternalHttpEndpoints()
    .PublishAsDockerFile();

builder.Build().Run();
