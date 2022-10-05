using Microsoft.EntityFrameworkCore;
using News_service.Data;
using News_service.Interfaces;
using News_service.Repositories;
using News_service.Services;
using News_service.Services.Mapper;
using News_service.Services.Paginator;

var builder = WebApplication.CreateBuilder(args);

IConfigurationRoot connection = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddJsonFile("appsettings.json").Build();
builder.Services.AddDbContext<ServiceDbContext>(options => options.UseSqlServer(connection.GetConnectionString("LocalConnection")));

// Add services to the container.
builder.Services.AddGrpc();

builder.Services.AddTransient<INews, NewsRepository>();
builder.Services.AddTransient<Mapper>();
//builder.Services.AddTransient<PagedList>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<NewsService>();

app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
