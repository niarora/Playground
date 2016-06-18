namespace Playground.Problems
{
    using System;

    public static class FlipBit
    {
        public static int GetLongestSequenceOfOnesWithSingleFlip(int n)
        {
            return FlipBit.GetLongestSequenceOfOnesWithSingleFlip((uint)n);
        }
        
        // If we try to right shift a signed integer the high order empty bits are signed to the sign bit.
        // i.e. -1 >> 1 == -1. Thus it is better to cast to uint before right shifting, if the desired behaviour
        // is to fill the high order bits with zeroes.
        public static int GetLongestSequenceOfOnesWithSingleFlip(uint n)
        {
            if (n == 0)
            {
                return 1;
            }

            var max1s = 1;
            var cur1s = 0;
            var postZero1s = 0;
            while (n != 0)
            {
                if ((n & 1) == 1)
                {
                    cur1s++;
                    postZero1s++;
                    max1s = Math.Max(cur1s, max1s);
                }
                else
                {
                    cur1s = postZero1s + 1;
                    postZero1s = 0;
                    max1s = Math.Max(cur1s, max1s);
                }

                n >>= 1;
            }

            return max1s;
        }
    }
}