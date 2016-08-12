namespace Playground
{
    using System;

    public static class Program
    {
        public static void Main()
        {
            var list = new Leetcode.EnhancedList<int>(
                new int[] { 1, 10, 3, 4, 5, 7, 8, 10, 123, 14, 1, 5, 5, 3, 15, 1 });
            list.Add(90);
            list.Add(3);
            Console.WriteLine("List after inserts: ");
            list.Print();
            list.Remove(3);
            list.Print();
            list.Remove(90);
            list.Print();
            list.Remove(3);
            list.Print();
            list.Clear();
            Console.WriteLine(list.Contains(1));
            list.AddRange(new int[] { 0, 2, 3, 4, 5, 11, 4, 92, 3, -30, 14, -14, 1111, 3 });
            list.Print();
            Console.WriteLine(list.Contains(-30));
            for (var i = 0; i < list.Count; i++)
            {
                Console.Write(list.GetRandom() + ", ");
            }

            Console.WriteLine();
        }
    }
}