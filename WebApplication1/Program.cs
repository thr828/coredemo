using Autofac;
using Autofac.Extensions.DependencyInjection;
using Data;
using DotNetCore.CAP;
using IOC;
using Mapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using System.Globalization;
using System.Reflection;
using System.Resources;
using WebApplication1.Extensions;
using WebApplication1.MiddleWare;

var builder = WebApplication.CreateBuilder(args);
Console.WriteLine(builder.Environment.EnvironmentName);

// Add services to the container.

string a = builder.Configuration.GetConnectionString("Conn").ToString();

//更改服务提供工厂，使用autofac服务工厂
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());


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
builder.Services.AddSingleton<ISingletonService, SingletonService>();
builder.Services.AddTransient<ITransientService, TransientService>();
builder.Services.AddScoped<IScopedService, ScopedService>();
builder.Services.AddMvc();

var provider=builder.Services.BuildServiceProvider();

//builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => {
//    Assembly assembly = Assembly.Load("Data.dll");
//    containerBuilder.RegisterAssemblyTypes(assembly)
//    .AsImplementedInterfaces()
//    .InstancePerDependency()
//   // .AsSelf()
//    .PropertiesAutowired()
//    ;
//});


//builder.Services.TryAdd(new ServiceDescriptor(typeof(ISingletonService), ServiceLifetime.Singleton));

builder.Services.AddTransient<YouMiddleWarecs>();

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


var supportedCultures = new[]
{
    new CultureInfo("zh"),
    new CultureInfo("en"),
};

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.DefaultRequestCulture = new RequestCulture("en");
    // Formatting numbers, dates, etc.
    options.SupportedCultures = supportedCultures;
    // UI strings that we have localized.
    options.SupportedUICultures = supportedCultures;
});

// 告诉国际化引擎，所有的国际化资源文件都在 Resources 目录
builder.Services.AddJsonLocalization(setupAction => {
    setupAction.ResourcesPath = "Resources";
});

builder.Services.AddTransient<IStartupFilter, FirstStartupFilter>();


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

// 将国际化的配置添加到应用程序上
app.UseRequestLocalization();

app.Use(async (context, next) =>
{
    // 下一个中间件处理之前的操作
    Console.WriteLine("Use Begin");

    await next();

    // 下一个中间件处理完成后的操作
    Console.WriteLine("Use End");
});
//不过，一般不推荐直接使用UseMiddleware，而是将其封装到扩展方法中
//app.UseMiddleware<MyMiddleware>();
app.MyUse();
app.YouUse();

app.Use(async (context, next) =>
{
    Console.WriteLine("第四个");
    await next();
    Console.WriteLine("第五个");
});

app.UseWhen(context => context.Request.Path.StartsWithSegments("/WeatherForecast"), app =>
{
    app.Use(async (context, next) =>
    {
        Console.WriteLine("UseWhen:Use");
        await next();
    });
});

// 访问 /get 时会进入该管道分支
// 访问 /get/xxx 时会进入该管道分支
app.Map("/get", app =>
{
    app.Use(async (context, next) =>
    {
        Console.WriteLine("Map get: Use");
        Console.WriteLine($"Request Path: {context.Request.Path}");
        Console.WriteLine($"Request PathBase: {context.Request.PathBase}");

        await next();
    });

    app.Run(async context =>
    {
        Console.WriteLine("Map get: Run");

        await context.Response.WriteAsync("Hello World!");
    });

});

// /get 或 /get/xxx 都会进入该管道分支
//app.MapWhen(context => context.Request.Path.StartsWithSegments("/weatherforecast"), app =>
//{
//    app.MapWhen(context => context.Request.Path.ToString().Contains("user"), app =>
//    {
//        app.Use(async (context, next) =>
//        {
//            Console.WriteLine("MapWhen get user: Use");

//            await next();
//        });
//    });

//    app.Use(async (context, next) =>
//    {
//        Console.WriteLine("MapWhen get: Use");

//        await next();
//    });

//    app.Run(async context =>
//    {
//        Console.WriteLine("MapWhen get: Run");

//        await context.Response.WriteAsync("Hello World!");
//    });
//});



app.Run();



