using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace WebApplication1.AOP.Filters
{
    public class LogExceptionFilter : IAsyncExceptionFilter
    {
        public Task OnExceptionAsync(ExceptionContext context)
        {
            Debug.WriteLine("------------异常日志保存----------");
            return File.AppendAllTextAsync("D:/err.log", context.Exception.ToString());
        }
    }
}
