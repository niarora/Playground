namespace Playground
{
    using Playground.Extensions;

    public static class Program
    {
        public static void Main()
        {
            var s = "nice";
            var permutations = Playground.Utils.Permutation.Permutations(s);
            permutations.WriteLine();
        }
    }
}