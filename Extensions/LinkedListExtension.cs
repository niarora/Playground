namespace Playground.Extensions
{
    using System;
    using System.Collections.Generic;

    public static class LinkedListExtension
    {
        public static LinkedList<int> SumLists(this LinkedList<int> op1, LinkedList<int> op2)
        {
            if (op1 == null || op1.Count == 0)
            {
                return op2;
            }

            if (op2 == null || op2.Count == 0)
            {
                return op1;
            }

            var sum = new LinkedList<int>();
            var op1Node = op1.First;
            var op2Node = op2.First;
            var carry = 0;

            while (carry == 1 || (op1Node != null || op2Node != null))
            {
                var digit = carry
                + (op1Node?.Value ?? 0)
                + (op2Node?.Value ?? 0);
                carry = digit / 10;
                digit %= 10;
                sum.AddLast(digit);
                op1Node = op1Node?.Next;
                op2Node = op2Node?.Next;
            }

            return sum;
        }
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