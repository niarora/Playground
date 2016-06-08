namespace Playground.Extensions
{
    using System;
    using System.Collections.Generic;

    public static class LinkedListExtension
    {
        public static void Partition<T>(this LinkedList<T> list, T key) where T : IComparable<T>
        {
            var length = 0;
            if (list == null || (length = list.Count) == 0)
            {
                throw new ArgumentNullException(nameof(list));
            }

            if (length == 1)
            {
                return;
            }

            //// Guarantee that we'll start comparing with node >= key.
            var current = list.First;
            while (current != null && current.Value.CompareTo(key) < 0)
            {
                current = current.Next;
            }

            var i = current?.Next;
            for (; i != null; i = i.Next)
            {
                if (i.Value.CompareTo(key) < 0)
                {
                    LinkedListExtension.SwapValue(current, i);
                    current = current.Next;
                }
            }
        }

        public static void WriteLine<T>(this LinkedList<T> list)
        {
            if (list != null)
            {
                var current = list.First;
                while (current != null)
                {
                    Console.Write("{0}, ", current.Value);
                    current = current.Next;
                }
                
                Console.WriteLine();
            }
        }

        private static void SwapValue<T>(LinkedListNode<T> node1, LinkedListNode<T> node2)
        {
            var value1 = node1.Value;
            node1.Value = node2.Value;
            node2.Value = value1;
        }
    }
}