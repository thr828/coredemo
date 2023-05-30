using Data;
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

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
