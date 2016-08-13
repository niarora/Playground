namespace Playground
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Playground.Extensions;
    public static class Program
    {
        public static void Main()
        {
            TestRemovingDuplicates(new int[] { 1, 10, 3, 4, 5, 7, 8, 10, 123, 14, 1, 5, 5, 3, 15, 1, 123 });
            TestRemovingDuplicates(new int[] { 1, 1, 2, 2 });
            TestRemovingDuplicates(new int[] { 2, 2, 2 });
            TestRemovingDuplicates(new int[] { });
            TestRemovingDuplicates(new int[] { 1 });
            TestRemovingDuplicates(new int[] { 1,1 });
        }

        private static void TestRemovingDuplicates<T>(IEnumerable<T> testInput) where T : IEquatable<T>
        {
            testInput = testInput.OrderBy(t => t);
            var linkedList = new LinkedList<T>(testInput);
            Console.WriteLine();
            Console.WriteLine("Before removing dups: ");
            linkedList.Print();
            linkedList.RemoveDuplicates();
            Console.WriteLine("After removing dups: ");
            linkedList.Print();
            Console.WriteLine();
        }
    }
}