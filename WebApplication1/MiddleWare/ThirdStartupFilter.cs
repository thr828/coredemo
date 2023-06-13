namespace WebApplication1.MiddleWare
{
    public class ThirdStartupFilter : IStartupFilter
    {
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return app =>
            {
                app.Use((context, next) =>
                {
                    Console.WriteLine("Third");
                    return next();
                });
                next(app);
            };
        }
    }
}
