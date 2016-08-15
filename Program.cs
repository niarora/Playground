namespace Playground
{
    using System;
    using System.Linq;
    using Playground.Extensions;
    public static class Program
    {
        public static void Main()
        {
            Test("2");
            Test("97");
            Test("3236986237");
        }

        private static void Test(string digits)
        {
            var mnemonics = new Problems.Mnemonics();
            var result = mnemonics.ComputeMnemonics(digits);
            Console.WriteLine("Input digits:");
            digits.Print();
            Console.WriteLine("All Mnemonics: ");
            result.Print();
            Console.WriteLine("Total Mnemonics: {0}", result.Count());
        }
    }
}