using System;
using System.Globalization;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace CancellationToken方法
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            CancellationTokenSource cts = new CancellationTokenSource();

            CancellationToken cToken = cts.Token;
            await DownloadAsync3("http://www.youzack.com", 2, cToken);

            //通过用户条件进行取消
            while (Console.ReadLine() != "q")
            {

            }
            cts.Cancel();
            Console.ReadLine();
        }


        static async Task Main1(string[] args)
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            cts.CancelAfter(2000);
            //5秒还没结束就终止请求
            CancellationToken cToken=cts.Token;
            await DownloadAsync3("http://www.youzack.com",100,cToken);
        }

        static async Task DownloadAsync(string url, int n)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                for (int i = 0; i < n; i++)
                {
                    string html = await httpClient.GetStringAsync(url);
                    Console.WriteLine($"{DateTime.Now}{html}");
                }
            }
        }

        static async Task DownloadAsync2(string url, int n,CancellationToken cancellationToken)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                for (int i = 0; i < n; i++)
                {
                    string html = await httpClient.GetStringAsync(url);
                    Console.WriteLine($"{DateTime.Now}{html}");

                    //手动响应取消
                    //if (cancellationToken.IsCancellationRequested)
                    //{
                    //    Console.WriteLine("请求取消");
                    //    break;
                    //}

                    //如果响应被取消，则抛出异常，但是不能在方法内处理异常的响应
                    cancellationToken.ThrowIfCancellationRequested();


                }
            }
        }

        static async Task DownloadAsync3(string url, int n, CancellationToken cancellationToken)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                for (int i = 0; i < n; i++)
                {
                    var resp = await httpClient.GetAsync(url, cancellationToken);
                    string html=await resp.Content.ReadAsStringAsync();

                    //这种抛出异常的方式会比DownloadAsync2的速度更快，但是不能通过异常进行异常的处理
                }
            }
        }


    }
}
