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

        // Given a positive integer, calculate the next largest and smallest number with same 
        // number of bits set to  '1'. E.g. 9, i.e. 1001, returns:
        // Largest: 1010, Smallest: 0011. 
        public static Tuple<int, int> NextSmallestAndLargestWithSameOneBits(int n)
        {
            if (n < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(n), "The value must be greater than or equal to 1.");
            }

            int largest = 0, smallest = 0;
            if (n == 1) // Special case where the smallest value with a 
            {            // single bit as 1 is int.MinValue.
                largest = 2;
                smallest = int.MinValue;
            }
            else
            {
                var m = n;
                var firstOneIndex = GetIndexOfNextBitFromRight(n, 0, true);
                if (firstOneIndex == 30)
                {
                    throw new InvalidOperationException(
                        string.Format(
                            "No number larger than {0} exists with only one bit set to '1'.",
                            n));
                }

                // Set first '1' bit from right to '0'.                
                m &= (~(1 << firstOneIndex));
                var nextZeroIndex = GetIndexOfNextBitFromRight(n, firstOneIndex + 1, false);
                // Set the zero after the first '1' bit from the right to 1.
                m |= (1 << nextZeroIndex);
                largest = m;

                m = n;
                var firstZeroIndex = GetIndexOfNextBitFromRight(n, 0, false);
                // Set the first '0' bit to '1'.
                m |= 1 << firstZeroIndex;
                var nextOneIndex = GetIndexOfNextBitFromRight(n, firstZeroIndex + 1, true);
                // Set the next '1' bit to '0'.
                m &= (~(1 << nextOneIndex));
                smallest = m;
            }

            return Tuple.Create(largest, smallest);
        }

        // Throws an exception if the bit can't be find in position 0..30.
        // The 31st index is the position of the signed bit.  
        private static int GetIndexOfNextBitFromRight(int num, int start, bool findOne)
        {
            var i = start;
            if (findOne)
            {
                for (; i < 31; i++)
                {
                    var leftShiftedMask = 1 << i;
                    if ((leftShiftedMask & num) > 0)
                    {
                        break;
                    }
                }
            }
            else
            {
                for (; i < 31; i++)
                {
                    var leftShiftedMask = 1 << i;
                    if ((leftShiftedMask & num) == 0)
                    {
                        break;
                    }
                }
            }

            if (i == 31)
            {
                throw new InvalidOperationException(
                    string.Format(
                        "Couldn't find bit: {0}, in: {1}, starting at position {2}.",
                        Convert.ToInt32(findOne),
                        num,
                        start));
            }

            return i;
        }
    }
}