using System.Runtime.Intrinsics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add OpenApi services for two different versions
builder.Services.AddOpenApi("v1");
builder.Services.AddOpenApi("v2");

// Add API versioning services
builder.Services.AddApiVersioning();

var app = builder.Build();

var v1 = app.NewVersionedApi().HasApiVersion(1, 0);
var v2 = app.NewVersionedApi().HasApiVersion(2, 0);

v1.MapGet("hello", () => "Hello world").WithName("Hello");

v2.MapGet("hello", () => "Hello world v2").WithName("Hello");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.Run();
