namespace Playground.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class EnumerableExtension
    {
        public static void Print<T>(this IEnumerable<T> items)
        {
            if (items == null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            var sb = new StringBuilder();
            foreach (var i in items)
            {
                sb.AppendFormat("{0}, ", i);
            }

            var print = sb.ToString().TrimEnd(new []{',', ' '});
            Console.WriteLine(print);
        }
    }
}