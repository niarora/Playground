namespace Playground.Problems
{
    using System;
    using System.Linq;
    using System.Text;

    public class ScreenRenderer
    {
        // The screen is monochrome, a bit represents a pixel.
        // With X coordinate increasing going left to right.
        // Y coordinate increases going top to bottom.
        // **C# shift operations happen as if the bit representation is BigEndian.**
        private byte[] screen; // stores the screen bit vector as bytes array.

        private int width; // Number of bits.

        public ScreenRenderer(int totalBits, int widthInBits)
        {
            // TODO: Check Argument range for totalBits & widthInBits.
            if (widthInBits % 8 != 0)
            {
                throw new InvalidOperationException(
                    string.Format("Width: {0} is not a multiple of 8.", widthInBits));
            }

            this.width = widthInBits;
            this.screen = new byte[totalBits / 8];
        }

        // y is y-coordinate from the top.
        // x1 & x2 are coordinates along the x-axis.
        public void DrawLine(int y, int x1, int x2)
        {
            var widthInBytes = this.width / 8;
            var screenHeight = this.screen.Length / widthInBytes;
            CheckPixelRange(nameof(y), y, screenHeight);
            CheckPixelRange(nameof(x1), x1, this.width);
            CheckPixelRange(nameof(x2), x2, this.width);

            if (x2 < x1)
            {
                throw new InvalidOperationException(
                    string.Format("End coordinate: {0} is greater than start: {1}", x2, x1));
            }

            var x1mod8 = x1 % 8;
            var x2mod8 = x2 % 8;
            var x1by8 = x1 / 8;
            var x2by8 = x2 / 8;
            int startX = x1by8, endX = x2by8;

            // Check the offsets of where the full bytes start and end.
            if (x1mod8 != 0)
            {
                startX++;
            }
            if (x2mod8 != 7)
            {
                endX--;
            }

            var yOffset = y * widthInBytes;
            // Loop to set all the full bytes between bit x1 and bit x2.
            for (var i = startX; i <= endX; i++)
            {
                screen[yOffset + i] = 0xFF;
            }

            // If there were intermediate full bytes, set the remaining bits at start and end.
            if (endX >= startX)
            {
                // If x1%8 was 0, it was set as part of the full byte loop.
                if (x1mod8 != 0)
                {
                    // C# shift operators shift as if the bit representation for a byte was in Big-Endian.
                    // i.e. << left shift inserts 0 in low order bits.
                    // Thus we shift << to only have x1mod8 bits and higher set to 1. 
                    screen[yOffset + x1by8] = (byte)(0xFF << x1mod8);
                }
                // If x2%8 was 7, it was set as part of the full byte loop.
                if (x2mod8 != 7)
                {
                    screen[yOffset + x2by8] = (byte)(0xFF >> (7 - x2mod8));
                }
            }
            else // Loop setting bits from x1 to x2;
            {
                // This loop can also be optimized.
                for (var i = x1; i <= x2; i++)
                {
                    screen[yOffset + i / 8] |= (byte)(1 << (i % 8));
                }
            }

            // Printing the output.
            for (var j = 0; j < screenHeight; j++)
            {
                var builder = new StringBuilder();
                for (var i = 0; i < widthInBytes; i++)
                {
                    var s = new string(
                        Convert
                        .ToString(screen[j * widthInBytes + i], 2)
                        .PadLeft(8, '0')
                        .Reverse() // Convert.ToString prints in BigEndian order.
                        .ToArray());
                    builder.Append(s + " ");
                }

                var row = builder.ToString().Trim();
                Console.WriteLine("Line {0}: {1}", j, row);
            }
        }

        private static void CheckPixelRange(string argumentName, int p, int max)
        {
            if (p < 0 || p >= max)
            {
                throw new ArgumentOutOfRangeException(
                    argumentName,
                    string.Format("Valid range: 0 - {0}", max - 1));
            }
        }
    }
}