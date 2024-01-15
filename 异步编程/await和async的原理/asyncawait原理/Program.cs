using System;
using System.IO;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace asyncawait原理
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            using (HttpClient httpClient=new HttpClient())
            {
                string html = await httpClient.GetStringAsync("http://www.taobao.com");
                Console.WriteLine(html);
            }

            string txt = "hello";
            string filename = @"d:\a\1.txt";
            await File.WriteAllTextAsync(filename, txt);
            Console.WriteLine("写入成功！");
            string s = await File.ReadAllTextAsync(filename);
            Console.WriteLine("读取："+s);


            //await async 是语法糖,最终会编译成状态机模式，await的方法会被编译成一个类，根据调用切分
            //为多个状态，对async方法的调用会被拆分为对MoveNext的调用。
            //用await看似是”等待“，经过编译后，其实没有”await“
        }
    }
}
