namespace Playground
{
    using System;
    using System.Collections.Generic;
    using Playground.Extensions;
    using Playground.DynamicProgramming;

    public static class Program
    {
        public static void Main()
        {
            var inputSet = new[] {1,2,3,4,5,6,7,60,-6,-5,-4,-3,-2,-1};
            var subSet = new SubSetSum();
            var sum = 10;
            subSet.SubSetWithSum(inputSet, sum).WriteLine();
        }
    }
}