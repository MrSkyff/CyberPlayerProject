using Idenity_service.Data;
using Idenity_service.Interfaces;
using Idenity_service.Repositories;
using Idenity_service.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IUser, UserRepository>();

IConfigurationRoot connection = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddJsonFile("appsettings.json").Build();
builder.Services.AddDbContext<ServiceDbContext>(options => options.UseSqlServer(connection.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddGrpc();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<UserServices>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
