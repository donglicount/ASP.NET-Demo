using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace awaitasync1
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            /*
            string filename = @"D:\a\1.text";
            File.WriteAllText(filename,"hello");
            string s = File.ReadAllText(filename);
            Console.WriteLine(s);
            */
            string filename = @"D:\a\1.text";
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 1000000; i++)
            {
                sb.AppendLine("hello000000000000000000000000");
            }
            await File.WriteAllTextAsync(filename, sb.ToString());
            /*
            Task<string> T = File.ReadAllTextAsync(filename);
            string s= await T;
            */
            string s =await File.ReadAllTextAsync(filename);//简化写法
            Console.WriteLine(s);

            //1.异步方法的返回值一般是Task<T>。惯例：异步方法以Async结尾
            //2.即使方法没有返回值，也最好把返回值声明为非泛型的Task
            //3.调用异步方法时，一般在方法前加上await，这样拿到的返回值就是泛型指定T类型，使用await可以等待异步方法结束后执行下一个指令
            //4.异步方法具有“传染性”：一个方法中如果有await调用，则这个方法也必须修饰为async
        }
    }
}
