using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApplication1.AOP.Filters
{
    public class MyActionFilter3 : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("--------MyActionFilter3 第二次执行-------------");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("--------MyActionFilter3 第一次执行-------------");
        }
    }
}
