using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace 没有返回值的异步方法
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string s =await ReadAsync(1);
            Console.WriteLine(s);
        }


        //正常写法
        /*static async Task<string> ReadAsync(int num)
        {
            if (num == 1)
            {
                string s = await File.ReadAllTextAsync(@"d:\a\1.txt");
                return s;
            }
            if (num == 2)
            {
                string s = await File.ReadAllTextAsync(@"d:\a\2.txt");
                return s;
            }
            else
            {
                return default;
            }
        }*/


        //没有async的方法，没有await的时候就可以没有async
        static  Task<string> ReadAsync(int num)
        {
            if (num == 1)
            {
                return File.ReadAllTextAsync(@"d:\a\1.txt");
            }
            if (num == 2)
            {
                return File.ReadAllTextAsync(@"d:\a\2.txt");

            }
            else
            {
                return default;
            }
        }

        //不是简单的转发操作，就不能使用没有async的写法了
        static async Task<string> ReadAsync2(int num)
        {
            if (num == 1)
            {
                string s=await File.ReadAllTextAsync(@"d:\a\1.txt");
                return s + "ssssss";
            }
            if (num == 1)
            {
                string s = await File.ReadAllTextAsync(@"d:\a\2.txt");
                return s + "ssssss";
            }
            else
            {
                return default;
            }
        }
        //async方法缺点：
        //1.异步方法会生成一个类，运行效率没有普通方法高；
        //2.可能会占用非常多的线程；
        //3.使用没有async的异步方法，避免先拆后装，可以提高性能，不会造成线程浪费

        //使用场景：1.返回值为Task的不一定都要标注async，标注async只是让我们可以更方便的await而已。
        //2.如果一个异步方法只是对别的异步方法调用的转发，并没有太多复杂的逻辑（比如等待A的结果，再调用B；把A调用的返回值拿到内部做一些处理再返回），那么就可以去掉async关键字。
    }
}
