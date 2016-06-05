namespace Playground.Extensions
{
    using System;
    using System.Collections.Generic;

    public static class StringExtension
    {
        public static void WriteLine(this IEnumerable<string> strings)
        {
            foreach(var s in strings)
            {
                Console.WriteLine(s);
            }			
			
            Console.WriteLine();
        }
    }
}