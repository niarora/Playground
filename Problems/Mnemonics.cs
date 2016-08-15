namespace Playground.Problems
{
    using System.Collections.Generic;
    using System.Linq;

    public class Mnemonics
    {
        private static Dictionary<char, IEnumerable<string>> MnemonicsSet;

        static Mnemonics()
        {
            MnemonicsSet = new Dictionary<char, IEnumerable<string>>
            {
                {'2', new [] {"A", "B", "C"}},
                {'3', new [] {"D", "E", "F"}},
                {'4', new [] {"G", "H", "I"}},
                {'5', new [] {"J", "K", "L"}},
                {'6', new [] {"M", "N", "O"}},
                {'7', new [] {"P", "Q", "R", "S"}},
                {'8', new [] {"T", "U", "V"}},
                {'9', new [] {"W", "X", "Y", "Z"}}
            };
        }

        // Assumes string with valid digits including and between 2 - 9  only.
        public IEnumerable<string> ComputeMnemonics(string digits)
        {
            if (digits.Length == 0)
            {
                return Enumerable.Empty<string>();
            }

            if (digits.Length == 1)
            {
                return Mnemonics.MnemonicsSet[digits[0]];
            }

            var skipFirst = digits.Substring(1);
            return Mnemonics.MnemonicsSet[digits[0]]
            .SelectMany(s => this.ComputeMnemonics(skipFirst).Select(c => s + c));
        }
    }
}