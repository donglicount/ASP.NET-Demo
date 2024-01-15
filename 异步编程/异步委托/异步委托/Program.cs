using System;
using System.IO;
using System.Threading;

namespace 异步委托
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ThreadPool.QueueUserWorkItem(async (obj) =>
            {
                while (true)
                {
                   await File.WriteAllTextAsync(@"d:\a\1.txt","aaaaaaaaaaaaaaaaa");
                   Console.WriteLine("xxxxx");
                }
            });
            Console.Read();

            //在lamad表达式中使用异步方法，只需要在前面加上async关键字
        }
    }
}
