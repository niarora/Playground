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
            var nums = new int[] { 3,1,2,4,5,6,7,8,9,10};
            var sum = 32;
            var result = Leetcode.CombinationSum.CombinationSum4(nums, sum);            
            sw.Stop();
            Console.WriteLine("Result: {0}", result.ToString("#,#"));
            Console.WriteLine("Time ellapsed in ms: {0}", sw.ElapsedMilliseconds);                       
        }
    }
}