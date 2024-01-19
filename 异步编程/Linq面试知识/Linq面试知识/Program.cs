using System;
using System.Linq;

namespace Linq面试知识
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int i = 5;
            //int j = 6;
            //int k = 7;
            //int[] nums=new int[]{i,j,k};
            ////int max = nums.Max();
            //int maxjk = Math.Max(i, Math.Max(j, k));
            //int max2 = Math.Max(i, maxjk);
            //Console.WriteLine(max2);


            //面试时尽量避免使用Linq
            string s = "61,90,100,99,18,22,38,66,80,93,55,50,89";
            string[] origionS= s.Split(",");
            int i = 0;

            foreach (var s1 in origionS)
            {
                i+=Convert.ToInt32(s1);
            }
            int average=i/origionS.Length;

            double avg = s.Split(",").Select(s => Convert.ToInt32(s)).Average();
            Console.WriteLine("平均值：" + average);

            string s2 = "adasdfazxcwqSADSAsaSFAlhiozxc";
            var s3 = s2.ToUpper().ToArray();
            var result= s3.GroupBy(s => s).OrderByDescending(g => g.Count()).Where(g => g.Count() > 2)
                .Select(g => new { g.Key, Count = g.Count() });
            foreach (var r in result)
            {
                Console.WriteLine("单词："+r.Key+",频率"+r.Count);
            }



        }
    }
}
