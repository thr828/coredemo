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
