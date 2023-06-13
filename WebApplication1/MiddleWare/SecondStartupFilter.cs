namespace WebApplication1.MiddleWare
{
    public class SecondStartupFilter : IStartupFilter
    {
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return app =>
            {
                app.Use((context, next) =>
                {
                    Console.WriteLine("Second");
                    return next();
                });
                next(app);
            };
        }
    }
}
