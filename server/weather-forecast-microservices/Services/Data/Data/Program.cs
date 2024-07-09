using Data.Consumer;
using Worker.Installers;
using Worker.Repository;
using Data.Service;
using RabbitMQ.Extensions;
using RabbitMQ.Services;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMessageBroker(builder.Configuration);
builder.Services.InstallerServiceInAssembly(builder.Configuration);
builder.Services.AddSingleton<IWeatherConsumerService, WeatherConsumerService>();
builder.Services.AddHostedService<ConsumerHostedService>();

builder.Services.AddSingleton<IRabbitMQService, RabbitMQService>();
builder.Services.AddSingleton<ICaching, Caching>();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSingleton<IConnectionMultiplexer>(sp =>
    ConnectionMultiplexer.Connect("localhost:6379"));
builder.Services.AddStackExchangeRedisCache(options =>
{
	options.Configuration = "localhost:6379";
	options.InstanceName = "SampleInstance"; // Optional instance name
});

var app = builder.Build();

app.Run();
