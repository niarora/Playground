namespace Playground.Leetcode
{
    using System;
    using System.Collections.Generic;

    public static class CombinationSum
    {
        // Problem number 377. https://leetcode.com/problems/combination-sum-iv/
        public static int CombinationSum4(int[] nums, int target)
        {
            Array.Sort(nums);
            var count = 0;
            var countOfInterimSums = new Dictionary<int, int>();
            Helper(nums, target, 0, ref count, countOfInterimSums);
            return count;
        }


        private static void Helper(
            int[] array,
            int t,
            int sumSoFar,
            ref int count,
            Dictionary<int, int> countOfInterimSums)
        {
            if (countOfInterimSums.ContainsKey(sumSoFar))
            {
                count += countOfInterimSums[sumSoFar];
                return;
            }

            var countForSumSoFar = count;
            foreach (var n in array)
            {
                var sum = n + sumSoFar;

                if (sum == t)
                {
                    count++;
                    break;
                }

                else if (sum > t)
                {
                    break;
                }
                else
                {
                    Helper(array, t, sum, ref count, countOfInterimSums);
                }
            }

            if (!countOfInterimSums.ContainsKey(sumSoFar))
            {
                countOfInterimSums[sumSoFar] = count - countForSumSoFar;
            }
        }
    }
}