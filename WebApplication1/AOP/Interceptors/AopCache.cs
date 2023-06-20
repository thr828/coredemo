using Castle.DynamicProxy;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Nest;
using IInterceptor = Castle.DynamicProxy.IInterceptor;

namespace WebApplication1.AOP.Interceptors
{
    public class AopCache : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine($"拦截器被调用,方法名为{invocation.Method.Name}");
            invocation.Proceed(); //是执行被拦截的方法
            Console.WriteLine($"拦截器调用完成，返回结果为{invocation.ReturnValue}");//invocation.ReturnValue是方法的返回值
        }
    }
}
