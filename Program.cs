namespace Playground
{
    using System;

    public static class Program
    {
        public static void Main()
        {
            var input = new[] { 10, 2, -1, -2, 0, 3, -1, -10, 11, 5 };
            var result = DynamicProgramming.MaxContiguousSubSequence.FindSequence(input);
            for (var i = result.Start; i <= result.End; i++)
			{
				Console.Write("{0}, ", input[i]);
			}
			
			Console.WriteLine();
        }
    }
}