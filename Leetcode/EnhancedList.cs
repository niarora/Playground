namespace Playground.Leetcode
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Extensions;

    // 381. Insert Delete GetRandom O(1) - Duplicates allowed
    // https://leetcode.com/problems/insert-delete-getrandom-o1-duplicates-allowed/
    // Design a data structure that supports all following operations in average O(1) time.
    // Note: Duplicate elements are allowed.
    // Add(val): Inserts an item val to the collection.
    // Remove(val): Removes an item val from the collection if present.
    // GetRandom: Returns a random element from current collection of elements.
    //  The probability of each element being returned is linearly related to the number of same value the collection contains.

    // EnhancedList class allows for constant time Add / Remove and GetRandom.
    // Additionally implements all ICollection<T> operations. 
    public class EnhancedList<T> : ICollection<T> where T : IEquatable<T>
    {
        private static Random random = new Random();

        private List<T> list;
        private Dictionary<T, HashSet<int>> map;

        public EnhancedList()
        {
            this.list = new List<T>();
            this.map = new Dictionary<T, HashSet<int>>();
        }

        public EnhancedList(IEnumerable<T> items) : this()
        {
            this.AddRange(items);
        }
        public int Count
        {
            get
            {
                return list.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public void Add(T item)
        {
            if (!this.map.ContainsKey(item))
            {
                this.map[item] = new HashSet<int>();
            }

            this.AddLast(item);
        }

        public void AddRange(IEnumerable<T> items)
        {
            if (items != null)
            {
                foreach (var item in items)
                {
                    this.Add(item);
                }
            }
        }

        public void Clear()
        {
            this.map.Clear();
            this.list.Clear();
        }

        public bool Contains(T item)
        {
            return this.map.ContainsKey(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            list.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        public bool Remove(T item)
        {
            if (!this.map.ContainsKey(item))
            {
                return false;
            }

            var itemIndices = this.map[item];
            var lastItemIndex = this.Count - 1;
            var lastItem = this.list[lastItemIndex];


            if (lastItem.Equals(item))
            {
                itemIndices.Remove(lastItemIndex);
            }
            else
            {
                var lastItemIndices = this.map[lastItem];
                lastItemIndices.Remove(lastItemIndex);
                var firstItemIndex = itemIndices.First();
                lastItemIndices.Add(firstItemIndex);
                this.list[firstItemIndex] = lastItem;
                itemIndices.Remove(firstItemIndex);
            }

            this.list.RemoveAt(lastItemIndex);

            if (this.map[item].Count == 0)
            {
                this.map[item] = null;
                this.map.Remove(item);
            }

            return true;
        }

        public T GetRandom()
        {
            if (this.Count == 0)
            {
                return default(T); // Better to throw exception.
            }

            return this.list[random.Next(this.Count)];
        }

        public void Print()
        {
            this.list.Print();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return list.GetEnumerator();
        }

        private void AddLast(T item)
        {
            this.map[item].Add(this.Count);
            this.list.Add(item);
        }
    }
}