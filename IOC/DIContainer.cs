using AutoMapper;
using Data;
using Data.Repository;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace IOC
{
    public static class DIContainer
    {
        public static void RegisterDependencies(this IServiceCollection serviceContainer)
        {
            serviceContainer.AddScoped<MyContext>();
            serviceContainer.AddTransient<IMapper,Mapper>();
            serviceContainer.AddTransient<IArticleRepository, ArtcleRepository>();
            serviceContainer.AddTransient<IArtcleService, ArtcleService>();
        }
    }
}