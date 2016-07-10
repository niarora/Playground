namespace Playground
{
    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using Playground.Problems;

    public static class Program
    {
        public static void Main()
        {
            var rand = new Random();
            var numLongs = 100000000;
            var nums = new ulong[numLongs];
            var buf = new byte[8];

            var sw = new Stopwatch();
            sw.Start();
            while (numLongs > 0)
            {
                numLongs--;
                rand.NextBytes(buf);
                nums[numLongs] = BitConverter.ToUInt64(buf, 0);
            }
            sw.Stop();
            Console.WriteLine("Time taken to allocate in ms: {0}", sw.ElapsedMilliseconds);

            var parityCheck = new BitParity();
            sw.Restart();
            Parallel.For(0, nums.Length, (i) =>
            {
                parityCheck.IsParityEven(nums[i]);
            });
            sw.Stop();
            Console.WriteLine("Time taken to calculate individually in ms: {0}", sw.ElapsedMilliseconds);
            Console.WriteLine("Time: " + sw.Elapsed);
            Console.WriteLine("---------------------------------------");

            sw.Restart();
            parityCheck.Init();
            sw.Stop();
            Console.WriteLine("Time taken init hash in ms: {0}", sw.ElapsedMilliseconds);
            sw.Restart();
            Parallel.For(0, nums.Length, (i) =>
            {
                parityCheck.IsParityEvenFromCache(nums[i]);
            });
            sw.Stop();
            Console.WriteLine("Time taken to calculate from hash in ms: {0}", sw.ElapsedMilliseconds);
            Console.WriteLine("Time: " + sw.Elapsed);

            // Verifying code.
            // for (int i = 0; i < nums.Length; i++)
            // {
            //     if (parityCheck.IsParityEvenFromCache(nums[i])
            //     != parityCheck.IsParityEven(nums[i]))
            //     {
            //         Console.WriteLine("WARNING: {0} parity check doesn't match.", nums[i]);
            //         Console.WriteLine(
            //             "Calculated {0}. Hash: {1}.",
            //             parityCheck.IsParityEven(nums[i]),
            //             parityCheck.IsParityEvenFromCache(nums[i]));
            //     }
            // }
        }
    }
}