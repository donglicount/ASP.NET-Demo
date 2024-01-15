using System;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 异步方法不等于多线程
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            decimal i= await CalcAsync(1000000);
            Console.WriteLine("CalcAsync.ThreadId2:" + Thread.CurrentThread.ManagedThreadId);
            Console.Read();
        }

        static async Task<decimal> CalcAsync(int n)
        {
            Console.WriteLine("CalcAsync.ThreadId:"+Thread.CurrentThread.ManagedThreadId);

            //执行耗时任务
            decimal result = 1;
            Random random = new Random();
            for (int i = 0; i < n*n; i++)
            {
                result = result + (decimal)random.NextDouble();
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 1000; i++)
            {
                sb.Append("hello");
            }
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);//ThreadId:1

            await File.WriteAllTextAsync(@"d:\a\1.txt", sb.ToString()); //这个方法会调用新的线程
            return result;  
        }


        //省略async的写法
        static  Task<decimal> CalcAsync2(int n)
        {
            return Task.Run(() =>
            {
                Console.WriteLine("CalcAsync.ThreadId:" + Thread.CurrentThread.ManagedThreadId);

                //执行耗时任务
                decimal result = 1;
                Random random = new Random();
                for (int i = 0; i < n * n; i++)
                {
                    result = result + (decimal)random.NextDouble();
                }

                return Task.FromResult(result);
            });
        }








        //异步方法的代码并不会自动在新线程中执行
        //，除非手动把代码放到新线程中执行,如Task.Run()
    }
}
