namespace Playground
{
    using System;
    using Playground.Extensions;

    public static class Program
    {
        public static void Main()
        {
            var s = "nniiccc";
            var compressed = s.Compress();
            Console.WriteLine("Original: {0}, Compressed: {1}", s, compressed);
            Console.WriteLine("Original Length: {0}, Compressed Length: {1}", s.Length, compressed.Length);
        }
    }
}