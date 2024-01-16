using System;
using System.IO;
using System.IO.Enumeration;
using System.Linq;
using System.Threading.Tasks;

namespace WhenAll
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            // Task<string> t1 = File.ReadAllTextAsync(@"F:\a\1.txt");
            // Task<string> t2 = File.ReadAllTextAsync(@"F:\a\2.txt");
            // Task<string> t3 = File.ReadAllTextAsync(@"F:\a\3.txt");
            //
            // string[] strs=await Task.WhenAll(t1, t2, t3);
            // string s1 = strs[0];
            // string s2 = strs[1];
            // string s3 = strs[2];
            // Console.WriteLine(s1);
            // Console.WriteLine(s2); 
            // Console.WriteLine(s3);
            string[] files = Directory.GetFiles(@"F:\a");
            Task<int>[] countTasks=new Task<int>[files.Length];
            for (int i = 0; i < files.Length; i++)
            {
                string filename = files[i];
                Task<int> t = ReadCharCount(filename);
                countTasks[i] = t;
            }

            int[] counts= await Task.WhenAll(countTasks);
            int c = counts.Sum();
            Console.WriteLine(c);
        }

        static async Task<int> ReadCharCount(string fielname)
        {
            string s =await File.ReadAllTextAsync(fielname);
            return s.Length;
        }
    }
}
