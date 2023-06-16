namespace WebApplication1.MiddleWare
{
    public class TransientService : ITransientService,IDisposable
    {
        public void Dispose()
        {
            Console.WriteLine("DI容器自动释放TransientService");
        }

        public void Say(string text)
        {
            Console.WriteLine(text);
        }
    }
}
