namespace Playground.DynamicProgramming
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SubSetSum
    {
        public IEnumerable<int> SubSetWithSum(int[] a, int sum)
        {
            var outSet = new List<int>();
            var maxPositive = 0;
            var minNegative = 0;
            foreach (var item in a)
            {
                if (item > 0)
                {
                    maxPositive += item;
                }
                else
                {
                    minNegative += item;
                }
            }

            // If sum is greater than all positive numbers added or lesser than all negative numbers combined, return;
            if (sum < minNegative || sum > maxPositive)
            {
                return outSet;
            }

            this.SubSetWithSumExists(a, sum, outSet);
            return outSet;
        }

        // Returns true if there's a sub set of elements within an array that add to a given sum.
        // outSet returns the collection of such  
        private bool SubSetWithSumExists(int[] a, int sum, ICollection<int> outSet)
        {
            if (a == null)
            {
                throw new ArgumentNullException(nameof(a));
            }

            var length = a.Length;
            if (length == 0)
            {
                return false;
            }

            if (length == 1)
            {
                if (a[0] == sum)
                {
                    outSet.Add(a[0]);
                    return true;
                }

                return false;
            }

            var last = a[length - 1];
            var skippedLast = a.Take(length - 1).ToArray();

            // The set without the last element in 'a' was valid.
            if (this.SubSetWithSumExists(skippedLast, sum, outSet))
            {
                return true;
            }

            // Check the last element skipped is itself equal to sum.
            if (last == sum)
            {
                outSet.Add(last);
                return true;
            }

            // Check if the last element is part of the solution of the set without the last element.
            if (this.SubSetWithSumExists(skippedLast, sum - last, outSet))
            {
                outSet.Add(last);
                return true;
            }

            return false;
        }
    }
}