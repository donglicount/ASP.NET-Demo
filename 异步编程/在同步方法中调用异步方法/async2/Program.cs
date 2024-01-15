using System;
using System.IO;

namespace async2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //使用result来手动获取返回值
           string s= File.ReadAllTextAsync(@"d:\a\1.txt").Result;

           //对于没有返回值的方法：使用wait等待异步方法完成结束
           File.WriteAllTextAsync(@"d:\a\1.txt", "aaaaaaaaaaa").Wait();

           //尽量不要使用Result和Wait这种省略await的写法，可能会发生死锁等问题
        }


    }
}
