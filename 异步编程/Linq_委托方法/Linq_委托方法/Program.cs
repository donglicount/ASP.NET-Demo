using System;

namespace Linq_委托方法
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //使用Action委托
            Action a1 = F1;
            a1();
            a1 = F2;
            a1();
            //有传参和返回值的委托
            Func<int, int,int> d2 = Add;
            int addResult = d2(2, 3);
            //有传参无返回值的委托
            Action<int,string> d3 = F3;
            d3(3, "ss");
            Console.WriteLine("addResult:" + addResult);
        }
        static void Main1(string[] args)
        {
            //自定义委托
            D1 d = F1;
            d();
            d = F2;
            d();
            D2 d2 = Add;
            int addResult= d2(2, 3);
            Console.WriteLine("addResult:"+addResult);
        }

        static void F1()
        {
            Console.WriteLine("F1方法");
        }
        static void F2()
        {
            Console.WriteLine("F2方法");
        }

        static int Add(int i, int i2)
        {
            return i + i2;
        }

        static void F3(int i, string j)
        {
            Console.WriteLine(i+j);
        }
        delegate void D1();
        delegate int D2(int i, int j);
    }
}
 