namespace Playground.DynamicProgramming
{
    using System;
    using Playground.Models;

    public static class MaxContiguousSubSequence
    {
        public static Indices FindSequence(int[] arr)
        {
            int n = 0;
            if (arr == null || (n = arr.Length) == 0)
            {
                throw new ArgumentException("Array doesn't exist or has no elements");
            }

            var maxIndices = new Indices();
            var maxSum = arr[0];
            uint i = 0;
            for (; maxSum < 0 && i < n; i++)
            {
                if (arr[i] > maxSum)
                {
                    maxSum = arr[i];
                    maxIndices.Start = i;
                    maxIndices.End = i;
                }
            }

            if (i == n)
            {
                Console.WriteLine("Array with only negative elements. Max sum is: {0}", maxSum);
                return maxIndices;
            }

            var currentIndices = new Indices();
            var currentSum = 0;
            for (i = 0; i < n;)
            {
                for (; arr[i] < 0; i++)
                { /* Discard negative elements at the beginning. */ }
                currentSum = 0;
                currentIndices.Start = i;

                while (currentSum >= 0 && i < n)
                {
                    currentSum += arr[i];
                    currentIndices.End = i++;
                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        maxIndices.Start = currentIndices.Start;
                        maxIndices.End = currentIndices.End;
                    }
                }
            }

            if (currentSum > maxSum)
            {
                maxSum = currentSum;
                maxIndices.Start = currentIndices.Start;
                maxIndices.End = currentIndices.End;
            }

            Console.WriteLine(
                "{0} Sum {1}",
                maxIndices,
                maxSum);
            return maxIndices;
        }
    }
}
