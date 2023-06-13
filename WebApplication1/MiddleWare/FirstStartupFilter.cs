namespace WebApplication1.MiddleWare
{
    public class FirstStartupFilter : IStartupFilter
    {
        
        
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return app =>
            {
              app.Use((context, next) =>
              {
                  Console.WriteLine("First");
                  return next();
              });
              next(app);
            };
        }
    }
}
