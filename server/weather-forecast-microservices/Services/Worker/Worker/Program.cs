using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using StackExchange.Redis;
using Worker;
using Worker.Repository;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Workers>();
builder.Services.AddHttpClient(); // Đăng ký IHttpClientFactory

builder.Services.AddSingleton<ICaching, Caching>();
builder.Services.AddMemoryCache();
builder.Services.AddSingleton<IDistributedCache, MemoryDistributedCache>();

builder.Services.AddDbContext<WorkerDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DataBase")));

builder.Services.AddSingleton<IConnectionMultiplexer>(sp =>
    ConnectionMultiplexer.Connect("localhost:6379"));
builder.Services.AddStackExchangeRedisCache(options =>
{
	options.Configuration = "localhost:6379";
	options.InstanceName = "SampleInstance"; // Optional instance name
});

var host = builder.Build();
host.Run();
