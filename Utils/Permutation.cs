namespace Playground.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Permutation
    {
        ////Returns all permutations of length 'n' for a string of lenght 'n'.
        public static string[] Permutations(string s)
        {
            var hash = new Dictionary<string, string[]>();
            var perms = Permutations(s, hash);
            return perms;
        }

        ////Returns all permutations of a string.
        public static string[] AllPermutations(string s)
        {
            var hash = new Dictionary<string, string[]>();
            var perms = Permutations(s, hash);
            var allPerms = hash.SelectMany(key => key.Value).ToArray();
            return allPerms;
        }

        ////Returns all permutations of a string.
        ////E.g. "ab" -> ["a", "b", "ab", "ba"]
        ////The dictionary captures permutations for choices 1, 2, ... n. The return array captures for 'n' choices.
        private static string[] Permutations(string s, Dictionary<string, string[]> hash)
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

            if (length == 1)
            {
                hash.Add(s, new string[] { s });
                return hash[s];
            }

            var pPermutations = new List<string>();
            for (var c = 0; c < length; c++)
            {
                var cPermutations = Permutations(s.Remove(c, 1), hash);
                cPermutations = cPermutations.Select(perm => string.Concat(s[c], perm)).ToArray();
                pPermutations.AddRange(cPermutations);
            }

            var result = pPermutations.ToArray();
            hash.Add(s, result);
            return result;
        }
    }
}