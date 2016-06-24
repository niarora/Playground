namespace Playground
{
    using System;
    using Playground.Problems;

    public static class Program
    {
        public static void Main()
        {
            bool loop = true;
            int y = 2, x1 = 0, x2 = 3;
            // This loop is simply helful in debugging as Visual Studio Code debugger 
            // doesn't allow to move the executing statement.
            while (loop)
            {
                var screen = new ScreenRenderer(240, 24);

                screen.DrawLine(y, x1, x2);
            }
        }
    }
}