using Data;
using Microsoft.Extensions.DependencyInjection;

namespace IOC
{
    public static class DIContainer
    {
        public static void RegisterDependencies(this IServiceCollection serviceContainer)
        {
            serviceContainer.AddScoped<MyContext>();
        }
    }
}