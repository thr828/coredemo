namespace WebApplication1.MiddleWare
{
    public class ScopedService : IScopedService,IDisposable
    {
        public void Say(string text)
        {
            Console.WriteLine(text);
        }
        public void Dispose()
        {
            Console.WriteLine("DI容器自动释放ScopedService");
        }
    }
}
