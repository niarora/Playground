namespace Playground.Extensions
{
    using System;
    using System.Collections.Generic;

    public static class LinkedListExtension
    {

        public static void RemoveDuplicates<T>(this LinkedList<T> sortedList) where T : IEquatable<T>
        {
            LinkedListNode<T> current;
            if (sortedList == null || (current = sortedList.First) == null || current.Next == null)
            {
                return;
            }

            while (current.Next != null)
            {
                if (current.Value.Equals(current.Next.Value))
                {
                    sortedList.Remove(current.Next); // Equivalent to current.Next = current.Next.Next.
                }
                else
                {
                    current = current.Next;
                }
            }
        }

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

        private static void SwapValue<T>(LinkedListNode<T> node1, LinkedListNode<T> node2)
        {
            var value1 = node1.Value;
            node1.Value = node2.Value;
            node2.Value = value1;
        }
    }
}