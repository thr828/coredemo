using Autofac.Extras.DynamicProxy;

namespace WebApplication1.AOP.Interceptors
{
    [Intercept(typeof(AopCache))]
    public class GetDataClass
    {
        public virtual  string GetTime()//使用virtual，才可以使用拦截器
        {
            return DateTime.Now.ToString("G");
        }
    }
}
