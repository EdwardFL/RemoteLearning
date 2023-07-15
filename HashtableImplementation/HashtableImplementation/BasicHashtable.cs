using System;

namespace HashtableImplementation
{
    public class BasicHashTable<TKey, TValue>
    {
        private class KeyValue<TKey, TValue>
        {
            public TKey Key { get; set; }
            public TValue Value { get; set; }
            public KeyValue<TKey, TValue> Next { get; set; }
        }

        private int index;
        private readonly int size;
        private int count;
        private KeyValue<TKey, TValue>[] table;

        public BasicHashTable(int size)
        {
            this.size = size;
            table = new KeyValue<TKey, TValue>[size];
        }

        public TValue this[TKey key]
        {
            get
            {
                index = GetHash(key);
                KeyValue<TKey, TValue> list = table[index];

                while (list != null)
                {
                    if (list.Key.Equals(key)) return list.Value;
                    list = list.Next;
                }

                throw new ArgumentNullException();
            }
            set
            {
                table[index] = new KeyValue<TKey, TValue>
                {
                    Key = key,
                    Value = value,
                    Next = table[index]
                };
                count++;
            }
        }

        public int GetHash(TKey key)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));

            int position = key.GetHashCode() % size;
            return Math.Abs(position);
        }

        public TValue Get(TKey key)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));

            int position = GetHash(key);
            KeyValue<TKey, TValue> list = table[position];

            while (list != null)
            {
                if (list.Key.Equals(key)) return list.Value;
                list = list.Next;
            }

            return default;
        }

        public void Put(TKey key, TValue value)
        {
            int position = GetHash(key);
            KeyValue<TKey, TValue> list = table[position];
            while (list != null)
            {
                if (list.Key.Equals(key)) break;
                list = list.Next;
            }

            if (list != null)
            {
                list.Value = value;
            }
            else
            {
                KeyValue<TKey, TValue> item = new KeyValue<TKey, TValue>()
                {
                    Key = key,
                    Value = value,
                    Next = table[position]
                };

                table[position] = item;
                count++;
            }
        }

        public void Remove(TKey key)
        {
            int position = GetHash(key);
            while (table[position] == null)
            {
                return;
            }

            if (table[position].Key.Equals(key))
            {
                table[position] = table[position].Next;
                count--;
                return;
            }

            KeyValue<TKey, TValue> previousList = table[position];
            KeyValue<TKey, TValue> currentList = previousList.Next;

            while (currentList != null && currentList.Key.Equals(key))
            {
                currentList = currentList.Next;
                previousList = currentList;
            }

            if (currentList != null)
            {
                previousList.Next = currentList.Next;
                count--;
            }
        }

        public bool ContainsKey(TKey key)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));

            int position = GetHash(key);
            KeyValue<TKey, TValue> list = table[position];
            while (list != null)
            {
                if (list.Key.Equals(key)) return true;
                list = list.Next;
            }

            return false;
        }

        public int Count()
        {
            return count;
        }
    }
}