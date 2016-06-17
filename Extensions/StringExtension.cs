namespace Playground.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class StringExtension
    {
        public static string Compress(this string s)
        {
            var length = 0;
            if (s == null || (length = s.Length) <= 1)
            {
                return s;
            }

            var builder = new StringBuilder();
            builder.Append(s[0]);
            var occurence = 1;
            var i = 1;

            //// Break if builder will be at least length of 's - 1' in this loop. 
            for (; builder.Length < length - 1 && i < length; i++)
            {
                if (s[i] == s[i - 1])
                {
                    occurence++;
                }
                else
                {
                    builder.Append(occurence);
                    builder.Append(s[i]);
                    occurence = 1;
                }
            }

            builder.Append(occurence);

            return builder.Length < length ? builder.ToString() : s;
        }
    }
}