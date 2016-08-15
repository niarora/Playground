namespace Playground.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class EnumerableExtension
    {
        public delegate void RefSwap<T>(ref T arg1, ref T arg2);

        public static T KthLargest<T>(this T[] items, int k) where T : IComparable<T>
        {
            int count;
            if (k < 1 || k > (count = items.Length))
            {
                throw new InvalidOperationException("K must be between 1 and items count.");
            }

            return PartitionOnIndexK(items, count - k, 0, count - 1);
        }

        private static T PartitionOnIndexK<T>(T[] items, int k, int start, int end) where T : IComparable<T>
        {
            RefSwap<T> Swap = (ref T o1, ref T o2) =>
            {
                var temp = o1;
                o1 = o2;
                o2 = temp;
            };

            var kth = items[k];
            Swap(ref items[k], ref items[end]);
            var left = start;
            for (var i = start; i < end; i++) //items[end] holds the kth value.
            {
                if (items[i].CompareTo(kth) < 0)
                {
                    Swap(ref items[left++], ref items[i]);
                }
            }

            Swap(ref items[left], ref items[end]);

            return left == k ? items[k]
             : ((left < k) ? PartitionOnIndexK(items, k, left + 1, end)
             : PartitionOnIndexK(items, k, start, left - 1));
        }

        public static void Print<T>(this IEnumerable<T> items)
        {
            if (items == null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            var sb = new StringBuilder();
            foreach (var i in items)
            {
                sb.AppendFormat("{0}, ", i);
            }

            var print = sb.ToString().TrimEnd(new[] { ',', ' ' });
            Console.WriteLine(print);
        }
    }
}