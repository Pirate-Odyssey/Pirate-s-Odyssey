using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using PO.Api.Extensions;
using PO.Api.Hubs;
using PO.Domain.Extensions;
using PO.Infrastructure;

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

builder.Services.AddPOContext(builder.Configuration.GetConnectionString("pirates-odyssey"));

// Add AutoMapper PO Profile
builder.Services.AddMappers();

// Add Validators
builder.Services.AddValidators();

// Add PO Domaine Services
builder.Services.AddServices();

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

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
});

app.MapControllers();

app.MapHub<TestHub>("/hub/test");

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
