using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using Worker;
using Worker.Services;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Workers>();
builder.Services.AddHttpClient();

builder.Services.AddDbContext<WorkerDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("Database")));
builder.Services.AddSingleton<ICaching, Caching>();
builder.Services.AddSingleton<IConnectionMultiplexer>(sp => ConnectionMultiplexer.Connect(builder.Configuration.GetConnectionString("Redis")));

var host = builder.Build();
host.Run();
