namespace Playground
{
    using System;
<<<<<<< HEAD
=======
    using System.Collections.Generic;

>>>>>>> master
    using Playground.Extensions;

    public static class Program
    {
        public static void Main()
        {
<<<<<<< HEAD
            var s = "nniiccc";
            var compressed = s.Compress();
            Console.WriteLine("Original: {0}, Compressed: {1}", s, compressed);
            Console.WriteLine("Original Length: {0}, Compressed Length: {1}", s.Length, compressed.Length);
=======
            var list = new LinkedList<int>(new[] { 3, 10, 1, 5, 6, 5, 4 });
            list.Partition(5);
            list.WriteLine();
            list = new LinkedList<int>(new int[] { 1 });
            list.Partition(5);
            list.WriteLine();
            list = new LinkedList<int>(new int[] { 10, 5, 4 });
            list.Partition(5);
            list.WriteLine();
>>>>>>> master
        }
    }
}