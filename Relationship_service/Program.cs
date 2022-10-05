using Microsoft.EntityFrameworkCore;
using Relationship_service.Data;
using Relationship_service.Interfaces;
using Relationship_service.Repositories;
using Relationship_service.Services;

var builder = WebApplication.CreateBuilder(args);

IConfigurationRoot connection = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddJsonFile("appsettings.json").Build();
builder.Services.AddDbContext<ServiceDbContext>(options => options.UseSqlServer(connection.GetConnectionString("LocalConnection")));

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

builder.Services.AddTransient<IGroupRelationship, GroupRelationshipRepository>();
// Add services to the container.
builder.Services.AddGrpc();


var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<GroupRelationshipService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
