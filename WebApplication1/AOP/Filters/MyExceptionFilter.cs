using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;

namespace WebApplication1.AOP.Filters
{
    public class MyExceptionFilter : IAsyncExceptionFilter
    {
        private readonly IWebHostEnvironment  _webHostEnvironment;

        public MyExceptionFilter(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public Task OnExceptionAsync(ExceptionContext context)
        {
            string message=string.Empty;
            if (_webHostEnvironment.IsDevelopment())
            {
                message = context.Exception.Message;
            }
            else
            {
                message = context.Exception.ToString();
            }
            Debug.WriteLine("------------异常日志处理----------");
            ObjectResult result = new ObjectResult(new { code = 500, message = message });
            result.StatusCode = 500;
            ///IActionResult 设置浏览器响应的内容
            context.Result = result;
            //标记异常是否被处理，如果处理了true，就不会执行下一个异常Exception Filter
            context.ExceptionHandled = true;
            return Task.CompletedTask;
        }
    }
}
