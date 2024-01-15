using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace async背后的线程切换
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 1000; i++)
            {
                sb.Append("hello");
            }
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);//ThreadId:1

            await File.WriteAllTextAsync(@"d:\a\1.txt", sb.ToString());
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);//ThreadId:8
            Console.Read();
        }





        //await调用的等待期间，.net会把当前线程返回给线程池，
        //等异步方法调用执行完毕后，框架会从线程池再去一个线程执行后续的代码
        //如果异步调用耗时很短，将不会切换线程，调用前后线程Id一致
        //使用Thread.CurrentThread.ManagedThreadId获得当前线程Id.
        //验证：在耗时异步操作前后分别打印线程Id
    }
}
