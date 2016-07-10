namespace Playground.Problems
{
    using System;
    using System.Collections;

    public class BitParity
    {
        // Saves values for parity for first 2^16 numbers;
        private BitArray parityHash;

        public void Init()
        {
            var hashSize = UInt16.MaxValue + 1;
            this.parityHash = new BitArray(hashSize);
            for (var i = 0; i < hashSize; i++)
            {
                this.parityHash[i] = this.IsParityEven(i);
            }
        }

        public bool IsParityEvenFromCache(ulong n)
        {
            var even = true;
            while (n != 0)
            {
                var parity = this.parityHash[(int)n & UInt16.MaxValue];
                even = even == parity;
                n >>= 16;
            }

            return even;
        }

        public bool IsParityEven(long n)
        {
            return this.IsParityEven((ulong)n);
        }

        public bool IsParityEven(ulong n)
        {
            var even = true;
            while (n != 0)
            {
                if ((n & 1) == 1)
                {
                    even = !even;
                }

                n >>= 1;
            }

            return even;
        }
    }
}