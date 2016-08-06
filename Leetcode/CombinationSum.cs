namespace Playground.Leetcode
{
    using System.Collections.Generic;

    public static class CombinationSum
    {
        // Problem number 377. https://leetcode.com/problems/combination-sum-iv/
        public static int CombinationSum4(int[] nums, int target)
        {
            var count = 0;
            var countOfInterimSums = new Dictionary<int, int>();
            count = Helper(nums, target, countOfInterimSums);
            return count;
        }


        private static int Helper(
            int[] nums,
            int target,
            Dictionary<int, int> cache)
        {
            if (target == 0)
            {
                return 1;
            }

            if (cache.ContainsKey(target))
            {
                return cache[target];
            }

            var count = 0;
            foreach (var n in nums)
            {
                if (n > target)
                {
                }
                else
                {
                    var innerCount = Helper(nums, target - n, cache);
                    if (innerCount != 0)
                    {
                        count += innerCount;
                    }
                }
            }

            cache[target] = count;

            return count;
        }
    }
}