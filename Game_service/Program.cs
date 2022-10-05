using Game_service.Data;
using Game_service.Interfaces;
using Game_service.Repositories;
using Game_service.Services;
using Game_service.Services.Mapper;
using Microsoft.EntityFrameworkCore;

//var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IGame, GameRepository>();
builder.Services.AddTransient<Mapper>();

IConfigurationRoot connection = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddJsonFile("appsettings.json").Build();
builder.Services.AddDbContext<ServiceDbContext>(options => options.UseSqlServer(connection.GetConnectionString("LocalConnection")));


// Add services to the container.
builder.Services.AddGrpc();

var app = builder.Build();


// Configure the HTTP request pipeline.
app.MapGrpcService<GameService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
