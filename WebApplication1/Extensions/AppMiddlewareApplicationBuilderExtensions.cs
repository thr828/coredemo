using WebApplication1.MiddleWare;

namespace WebApplication1.Extensions
{
    public static class AppMiddlewareApplicationBuilderExtensions
    {
        public static IApplicationBuilder MyUse(this IApplicationBuilder app)
        {
            return app.UseMiddleware<MyMiddleware>();
        }

        public static IApplicationBuilder YouUse(this IApplicationBuilder app)
        {
            return app.UseMiddleware<YouMiddleWarecs>();
        }
    }
}
