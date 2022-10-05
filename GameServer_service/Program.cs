using GameServer_service.Data;
using GameServer_service.Interfaces;
using GameServer_service.Repositories;
using Microsoft.EntityFrameworkCore;
using Server_service.Services;

var builder = WebApplication.CreateBuilder(args);

IConfigurationRoot connection = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddJsonFile("appsettings.json").Build();
builder.Services.AddDbContext<ServiceDbContext>(options => options.UseSqlServer(connection.GetConnectionString("LocalConnection")));

builder.Services.AddTransient<IServer, ServerRepository>();

builder.Services.AddGrpc();


var app = builder.Build();

app.MapGrpcService<GameToServerService>();

app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
