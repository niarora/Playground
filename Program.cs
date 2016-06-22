namespace Playground
{
    using System;
    using Playground.Problems;

    public static class Program
    {
        public static void Main()
        {
            var binaryString = "111101111010010110111";
            bool loop = true;
            while (loop)
            {
                var n = Convert.ToInt32(binaryString, 2);
                var result = FlipBit.NextSmallestAndLargestWithSameOneBits(n);
                var nextLargest = result.Item1;
                var nextSmallest = result.Item2;
                Console.WriteLine(n);
                Console.WriteLine(Convert.ToString(n, 2));
                Console.WriteLine(nextLargest);
                Console.WriteLine(Convert.ToString(nextLargest, 2));
                Console.WriteLine(nextSmallest);
                Console.WriteLine(Convert.ToString(nextSmallest, 2));
            }
        }
    }
}