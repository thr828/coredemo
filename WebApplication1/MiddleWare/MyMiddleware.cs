namespace WebApplication1.MiddleWare
{
    public class MyMiddleware
    {
        // 用于调用管道中的下一个中间件
        private readonly RequestDelegate _next;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="next"></param>
        /// <param name="transientService"></param>
        /// <param name="singletonService"></param>
        public MyMiddleware(RequestDelegate next,
            ITransientService transientService,
            ISingletonService singletonService)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context,
            ITransientService transientService,
            IScopedService scopedService,
            ISingletonService singletonService)
        {
            // 下一个中间件处理之前的操作
            Console.WriteLine("MyMiddleware Begin");

            await _next(context);

            // 下一个中间件处理完成后的操作
            Console.WriteLine("MyMiddleware End");
        }
    }
}
