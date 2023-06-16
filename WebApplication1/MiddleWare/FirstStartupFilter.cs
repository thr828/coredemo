namespace WebApplication1.MiddleWare
{
    public class FirstStartupFilter : IStartupFilter
    {
        
        
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return app =>
            {
                Console.WriteLine("First");
                next(app);

            };
        }
    }
}
