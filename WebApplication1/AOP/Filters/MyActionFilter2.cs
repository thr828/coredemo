using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApplication1.AOP.Filters
{
    public class MyActionFilter2:IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            Console.WriteLine("--------MyActionFilter2 第一次执行-------------");
            ActionExecutedContext r = await next();
            if (r.Exception == null)
            {
                Console.WriteLine("--------MyActionFilter2 第二次执行-------------");
            }
            else
            {
                Console.WriteLine("--------MyActionFilter2 第二次执行--上一次执行异常-----------");
            }
        }
    }
}

