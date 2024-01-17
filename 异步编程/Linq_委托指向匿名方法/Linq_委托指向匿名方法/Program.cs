using System;
using System.Diagnostics.CodeAnalysis;

namespace Linq_委托指向匿名方法
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action f1 = delegate()
            {
                Console.WriteLine("无参数无返回值");
            };
            f1();
            Action<string,string> f2 = delegate(string i, string j)
            {
                Console.WriteLine(i+j);
            };
            f2("ss", "yy");

            //有传参有返回值
            Func<int, int, int> f3 = delegate(int i, int j)
            {
                return i + j;
            };
            Console.WriteLine(f3(1,2));

            //匿名方法可以省略delegate，使用=>代替,即所谓lambda表达式
            Func<int, int, int> f4 = (int i, int j) =>
            {
                return i + j;
            };
            Console.WriteLine(f4(2,3));
            //可以省略数据类型来简化lambda表达式
            Func<int, int, int> f5 = (i, j) =>
            {
                return i + j;
            };
            Console.WriteLine(f5(4,5));

            //如果委托没有返回值，且方法体只有一行代码，可省略{}
            Action f6 = () => Console.WriteLine("1111");
            f6();

            //如果=>之后的方法体中只有一行代码，且方法有返回值，那么可以省略方法体的{}以及return
            Func<int, int, int> f7 = (i, j) => i + j;
            Console.WriteLine(f7(7, 8));

            //如果只有一个参数，参数的()可以省略
            Action<int> f8 = (i) => Console.WriteLine(i);
            f8(8);
            Action<int> f9 = i => Console.WriteLine(i);
            f9(8);
            Func<int, int> f10 = delegate(int i)
            {
                return i;
            };
            Console.WriteLine(f10(10));
            Func<int,int> f11=i=> i;
            Console.WriteLine(f11(11));


            Action<string> f12 = delegate(string s)
            {
                Console.WriteLine(s);
            };
            Func<int, bool> f13 = delegate(int i)
            {
                return i > 5;
            };
        }
    }
}
