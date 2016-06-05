namespace Playground
{
    using Playground.Extensions;

    using System;

    public static class Program
    {
        public static void Main()
        {
            var s = "lmnA";
            var permutations = Playground.Utils.Permutation.Permutations(s);
        }
    }
}