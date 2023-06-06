using Data;
using DotNetCore.CAP;
using IOC;
using Mapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;


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

builder.Services.AddCap(x => {
    x.UseEntityFramework<MyContext>();
    // 如果你使用的Dapper，你需要添加如下配置：
    //x.UseSqlServer("数据库连接字符串");
    x.UseRabbitMQ(config => { 
            config.HostName = "localhost";
            config.UserName = "admin";
            config.Password= "admin";
    });
    //如果你使用的 Kafka 作为MQ，你需要添加如下配置：
    //x.UseKafka("localhost：9092");
    x.UseDashboard();
    //默认分组名，此值不配置时，默认值为当前程序集的名称
    //x.DefaultGroup = "m";
    //失败后的重试次数，默认50次；在FailedRetryInterval默认60秒的情况下，即默认重试50*60秒(50分钟)之后放弃失败重试
    //x.FailedRetryCount = 10;

    //失败后的重拾间隔，默认60秒
    //x.FailedRetryInterval = 30;

    //设置成功信息的删除时间默认24*3600秒
    //x.SucceedMessageExpiredAfter = 60 * 60;

    //这里通过发邮件、短信等信息通知人工处理，系统不能自动搞定了
    x.FailedThresholdCallback = AsyncCallback =>
    {
        Console.WriteLine("需要人工处理了");
    };
   // 设置发送消息的线程数据，大于1之后，不保证消息顺序 / a ProducerThreadCount = 1:/ 成功消息保存的时间，以秒为单位，默认是1天 / a.SucceedMessageExpiredAfter = 12 * 3600;
});

builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
    //option.DocInclusionPredicate((docName, description) => true);

    //// Define the BearerAuth scheme that's in use
    //option.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme()
    //{
    //    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
    //    Name = "Authorization",
    //    In = ParameterLocation.Header,
    //    Type = SecuritySchemeType.ApiKey
    //});

});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.UseSwagger();

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    //options.SwaggerEndpoint(builder.Configuration["App:ServerRootAddress"].EndsWith('/') + "swagger/v1/swagger.json", "DEMO API V1");
    //options.IndexStream = () => System.Reflection.Assembly.GetExecutingAssembly()
    //    .GetManifestResourceStream("WebApplication1.wwwroot.swagger.ui.index.html");
});

app.Run();
