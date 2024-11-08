using Intranet.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using PO.Api.Extensions;
using PO.Api.Hubs;
using PO.Domain.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire components.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddProblemDetails();

// Add Newtonsoft.json to make json response
builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.Converters.Add(new StringEnumConverter());
        options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        options.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.None;
        options.SerializerSettings.FloatParseHandling = FloatParseHandling.Double;
    });

builder.Services.AddPOContext(builder.Configuration.GetConnectionString("pirate-s-odyssey-db"));

// Add AutoMapper PO Profile
builder.Services.AddMappers();

// Add Validators
builder.Services.AddValidators();

// Add PO Domaine Services
builder.Services.AddServices();

// Add PO Infrastructur Repositories
builder.Services.AddRepositories();

// Add Swagger
builder.Services.AddPOSwagger("po-swagger");

// Add SignalR
builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler();
    app.UseHttpsRedirection();

    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/po-swagger/swagger.json", "Pirate's Odyssey - API");

        // To serve the Swagger UI at the app's root :
        options.RoutePrefix = string.Empty;
    });
}

app.MapControllers();

app.MapHub<TestHub>("/hub/test");

app.Run();
