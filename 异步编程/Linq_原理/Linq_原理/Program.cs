using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Linq_原理
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { 1, 2, 787, 453, 2, 32, 12, 8, 7 };

            IEnumerable<int> result = RelizeWhereByYield(nums, a => a > 10);
            foreach (var res in result)
            {
                Console.WriteLine(res);
            }
        }

        static void UseLinq()
        {
            int[] nums = new int[] { 1, 2, 787, 453, 2, 32, 12, 8, 7 };
            IEnumerable<int> result = nums.Where(a => a > 10);
            foreach (var res in result)
            {
                Console.WriteLine(res);
            }
        }

        static IEnumerable<int> RelizeWhere(IEnumerable<int> items,Func<int,bool> f)
        {
            List<int> result = new List<int>();
            foreach (var item in items)
            {
                if (f(item) == true)
                {
                    result.Add(item);
                }
            }
            return result;
        }

        static IEnumerable<int> RelizeWhereByYield(IEnumerable<int> items, Func<int, bool> f)
        {
            foreach (var item in items)
            {
                if (f(item) == true)
                {
                    Console.WriteLine("yield:"+item);
                    yield return item;
                }
            }
        }
    }
}
