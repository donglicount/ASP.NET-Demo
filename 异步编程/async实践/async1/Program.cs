using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace async1
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            int length= await DownloadHtmlAsync("http://www.youzack.com", @"d:\a\1.txt");
            Console.WriteLine("html长度："+length);
        }

        // static async Task DownloadHtmlAsync(string url,string filename)
        // {
        //     //using关键字：对于实现了IDisposable接口的需要使用using进行资源回收
        //     using (HttpClient client = new HttpClient())
        //     {
        //         string html=await client.GetStringAsync(url);
        //         File.WriteAllTextAsync(filename, html);
        //     }
        //
        // }
        static async Task<int> DownloadHtmlAsync(string url, string filename)
        {
            using (HttpClient client = new HttpClient())
            {
                string html = await client.GetStringAsync(url);
                File.WriteAllTextAsync(filename, html);
                return html.Length;
            }
        }
    }
}
