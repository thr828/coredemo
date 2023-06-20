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

//���ķ����ṩ������ʹ��autofac���񹤳�
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
    // �����ʹ�õ�Dapper������Ҫ����������ã�
    //x.UseSqlServer("���ݿ������ַ���");
    x.UseRabbitMQ(config => { 
            config.HostName = "localhost";
            config.UserName = "admin";
            config.Password= "admin";
    });
    //�����ʹ�õ� Kafka ��ΪMQ������Ҫ����������ã�
    //x.UseKafka("localhost��9092");
    x.UseDashboard();
    //Ĭ�Ϸ���������ֵ������ʱ��Ĭ��ֵΪ��ǰ���򼯵�����
    //x.DefaultGroup = "m";
    //ʧ�ܺ�����Դ�����Ĭ��50�Σ���FailedRetryIntervalĬ��60�������£���Ĭ������50*60��(50����)֮�����ʧ������
    //x.FailedRetryCount = 10;

    //ʧ�ܺ����ʰ�����Ĭ��60��
    //x.FailedRetryInterval = 30;

    //���óɹ���Ϣ��ɾ��ʱ��Ĭ��24*3600��
    //x.SucceedMessageExpiredAfter = 60 * 60;

    //����ͨ�����ʼ������ŵ���Ϣ֪ͨ�˹�����ϵͳ�����Զ��㶨��
    x.FailedThresholdCallback = AsyncCallback =>
    {
        Console.WriteLine("��Ҫ�˹�������");
    };
   // ���÷�����Ϣ���߳����ݣ�����1֮�󣬲���֤��Ϣ˳�� / a ProducerThreadCount = 1:/ �ɹ���Ϣ�����ʱ�䣬����Ϊ��λ��Ĭ����1�� / a.SucceedMessageExpiredAfter = 12 * 3600;
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

// ���߹��ʻ����棬���еĹ��ʻ���Դ�ļ����� Resources Ŀ¼
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

// �����ʻ���������ӵ�Ӧ�ó�����
app.UseRequestLocalization();

app.Use(async (context, next) =>
{
    // ��һ���м������֮ǰ�Ĳ���
    Console.WriteLine("Use Begin");

    await next();

    // ��һ���м��������ɺ�Ĳ���
    Console.WriteLine("Use End");
});
//������һ�㲻�Ƽ�ֱ��ʹ��UseMiddleware�����ǽ����װ����չ������
//app.UseMiddleware<MyMiddleware>();
app.MyUse();
app.YouUse();

app.Use(async (context, next) =>
{
    Console.WriteLine("���ĸ�");
    await next();
    Console.WriteLine("�����");
});

app.UseWhen(context => context.Request.Path.StartsWithSegments("/WeatherForecast"), app =>
{
    app.Use(async (context, next) =>
    {
        Console.WriteLine("UseWhen:Use");
        await next();
    });
});

// ���� /get ʱ�����ùܵ���֧
// ���� /get/xxx ʱ�����ùܵ���֧
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

// /get �� /get/xxx �������ùܵ���֧
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



