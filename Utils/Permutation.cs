namespace Playground.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Permutation
    {
        ////Returns all permutations of a string.
        public static string[] Permutations(string s)
        {
            int ops = 0;
            var hash = new Dictionary<string, string[]>();
            var perms = Permutations(s, ref ops, hash);
            //Extensions.StringExtension.WriteLine(perms);
            Console.WriteLine(perms.Length);
            Console.WriteLine("operations: {0}", ops);
            return perms;
        }

        ////Returns all permutations of a string of length p and less.
        private static string[] Permutations(string s, ref int ops, Dictionary<string, string[]> hash)
        {
            if (s == null)
            {
                throw new ArgumentNullException(nameof(s));
            }
            
            if (hash.ContainsKey(s))
            {
                return hash[s];
            }
            
            var length = (uint)s.Length;
            // if (length < p)
            // {
            //     throw new InvalidOperationException(string.Format("Can't chose {0} from {1} total items.", p, length));
            // }

            // if (length == 0)
            // {
            //     ops++;
            //     return new string[] { string.Empty };
            // }

            if (length == 1)
            {
                ops++;
                hash.Add(s, new string[] { s });
                return hash[s];
            }

            var pPermutations = new List<string>();
            // for (uint i = 1; i <= p; i++)
            // {
            for (var c = 0; c < length; c++)
            {
                ops++;
                var cPermutations = Permutations(s.Remove(c, 1), ref ops, hash);
                cPermutations = cPermutations.Select(perm => string.Concat(s[c], perm)).ToArray();
                ops += cPermutations.Length;
                pPermutations.AddRange(cPermutations);
            }
            // }

            var result = pPermutations.ToArray();
            hash.Add(s, result);
            return result;
        }
    }
}