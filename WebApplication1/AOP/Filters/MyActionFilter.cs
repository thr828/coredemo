using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApplication1.AOP.Filters
{
    public class MyActionFilter : IAsyncActionFilter
    {
        /// <summary>
        /// </summary>
        /// <param name="context"></param>
        /// <param name="next">委托指向下一个 ActionFilter并执行</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            Console.WriteLine("--------MyActionFilter 第一次执行-------------");
            ActionExecutedContext r = await next();
            if (r.Exception == null)
            {
                Console.WriteLine("--------MyActionFilter 第二次执行-------------");
            }
            else
            {
                Console.WriteLine("--------MyActionFilter 第二次执行--上一次执行异常-----------");
            }
        }
    }
}
