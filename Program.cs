namespace Playground
{
    using System;
    using System.Diagnostics;

    public static class Program
    {
        public static void Main()
        {
            var sw = new Stopwatch();
            sw.Start();
            var nums = new int[] { 2,3,5 };
            var sum = 40;
            var result = Leetcode.CombinationSum.CombinationSum4(nums, sum);            
            sw.Stop();
            Console.WriteLine("Result: {0}", result.ToString("#,#"));
            Console.WriteLine("Time ellapsed in ms: {0}", sw.ElapsedMilliseconds);                       
        }
    }
}