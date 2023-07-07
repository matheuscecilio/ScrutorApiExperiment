using ScrutorApiExperiment.Interfaces;
using ScrutorApiExperiment.Services;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSingleton<IConnectionMultiplexer>(x =>
    ConnectionMultiplexer.Connect(configuration.GetValue<string>("RedisConnection")!)
);

builder.Services.AddScoped<ICacheService, RedisCacheService>();

builder.Services.AddScoped<ICompanyInformationService, CompanyInformationService>();
builder.Services.Decorate<ICompanyInformationService, CachedCompanyInformationService>();

builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
