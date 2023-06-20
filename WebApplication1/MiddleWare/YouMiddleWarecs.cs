namespace WebApplication1.MiddleWare
{
    public class YouMiddleWarecs:IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            // 下一个中间件处理之前的操作
            Console.WriteLine("YourMiddleware Begin");
            await next(context);
            // 下一个中间件处理完成后的操作
            Console.WriteLine("YourMiddleware End");
        }
    }
}
