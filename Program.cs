namespace Playground
{
    using System;
    using System.Collections.Generic;
    using Playground.Extensions;
    public static class Program
    {
        public static void Main()
        {
            Test(new int[] { 1, 0, 3, 4, 5, 7, 8 }, new int[] { 9, 9 });
            Test(new int[] { }, new int[] { 1 });
            Test(new int[] { 9, 9 }, new int[] { 9, 9, 9, 9, 9 });
            Test(new int[] { 9, 9, 9, 9, 9 }, new int[] { 9, 9 });
            Test(new int[] { }, new int[] { });
        }

        private static void Test(IEnumerable<int> op1, IEnumerable<int> op2)
        {
            var op1List = new LinkedList<int>(op1);
            var op2List = new LinkedList<int>(op2);
            Console.WriteLine();
            Console.WriteLine("Operand 1: ");
            op1List.Print();
            Console.WriteLine("Operand 2: ");
            op2List.Print();
            var sum = op1List.SumLists(op2List);
            Console.WriteLine("Sum of both operands: ");
            sum.Print();
            Console.WriteLine();
        }
    }
}