using Data;
using IOC;
using Mapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

string a = builder.Configuration.GetConnectionString("Conn").ToString();

builder.Services.AddControllers();
builder.Services.AddDbContext<MyContext>(optionsaction => {
    optionsaction.UseSqlServer(builder.Configuration.GetConnectionString("Conn"))
    .LogTo(Console.WriteLine,LogLevel.Information)
    .EnableSensitiveDataLogging()
    .EnableDetailedErrors();
});

builder.Services.AddStackExchangeRedisCache(
    options => options.Configuration = 
        builder.Configuration.GetConnectionString("RedisConnectionStrings")
    );

builder.Services.AddAutoMapper(typeof(DataMappingProfile));
builder.Services.RegisterDependencies();//DI

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
