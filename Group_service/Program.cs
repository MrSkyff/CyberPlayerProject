using Group_service.Data;
using Group_service.Interfaces;
using Group_service.Repositories;
using Group_service.Services;
using Microsoft.EntityFrameworkCore;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

IConfigurationRoot connection = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddJsonFile("appsettings.json").Build();
builder.Services.AddDbContext<ServiceDbContext>(options => options.UseSqlServer(connection.GetConnectionString("LocalConnection")));

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("https://localhost:44369", "https://localhost:44360", "https://localhost:7241", "https://localhost:7194");
                      });
});

builder.Services.AddTransient<IGameGroup, GameGroupRepository>();
builder.Services.AddTransient<IGroupRelationship, GroupRelationshipRepository>();

builder.Services.AddGrpc();



var app = builder.Build();

app.UseCors(MyAllowSpecificOrigins);

app.MapGrpcService<GameToGroupService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
