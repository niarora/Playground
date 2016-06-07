namespace Playground
{
    using System;
    using System.Collections.Generic;

    using Playground.Extensions;

    public static class Program
    {
        public static void Main()
        {
            var list = new LinkedList<int>(new[] { 3, 10, 1, 5, 6, 5, 4 });
            list.Partition(5);
            list.WriteLine();
            list = new LinkedList<int>(new int[] { 1 });
            list.Partition(5);
            list.WriteLine();
            list = new LinkedList<int>(new int[] { 10, 5, 4 });
            list.Partition(5);
            list.WriteLine();
        }
    }
}