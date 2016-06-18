namespace Playground
{
    using System;
    using Playground.Problems;

    public static class Program
    {
        public static void Main()
        {
            var binaryString = "111101111010010110111";
            var n = Convert.ToInt32(binaryString, 2);
            var result = FlipBit.GetLongestSequenceOfOnesWithSingleFlip(n);
        }
    }
}