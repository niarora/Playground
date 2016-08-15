namespace Playground
{
    using System;
    using Playground.Extensions;
    public static class Program
    {
        public static void Main()
        {
            var items = new int[] { 10, -90, 4, 6, 957, 317, 195619, 2, 5, 1, 15, 0 };
            for (var i = 1; i <= items.Length; i++)
            {
                Test(items, i);
                items = new int[] { 10, -90, 4, 6, 957, 317, 195619, 2, 5, 1, 15, 0 };
            }
        }

        private static void Test(int[] items, int kth)
        {
            var kthLargest = items.KthLargest(kth);
            Console.WriteLine("Input List:");
            items.Print();
            Console.WriteLine("{0}st/th Largest element: {1}", kth, kthLargest);
        }
    }
}