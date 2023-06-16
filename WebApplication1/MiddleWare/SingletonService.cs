namespace WebApplication1.MiddleWare
{
    public class SingletonService : ISingletonService,IDisposable
    {
        public void Dispose()
        {
            Console.WriteLine("DI容器自动释放SingletonService");
        }

        public void Say(string text)
        {
            System.Console.WriteLine(text);
        }
    }
}
