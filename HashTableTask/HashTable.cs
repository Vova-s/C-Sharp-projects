using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableTask
{
    public class HashTable<Key, Value>
    {
        public Entry<Key, Value>[] table;

        public int loadness;
        public int size;

        public HashTable()
        {
            size = 7;
            table = new Entry<Key, Value>[size];
        }

        public void InsertEntry(Key key, Value value)
        {
            long pos = GetHash(key);
            if (table[pos] == null)
                loadness++;
            table[pos] = new Entry<Key, Value>(key, value);

            Rehashing();
        }

        public void RemoveEntry(Key key)
        {
            table[GetHash(key)].Deleted = true;
            loadness--;
        }

        public Entry<Key, Value> FindEntry(Key key)
        {
            Entry<Key, Value> entry = table[GetHash(key)];
            if (entry != null && entry.Deleted)
                return null;
            else
                return entry;
        }

        private void Rehashing()
        {
            if ((double)loadness / (double)size < 0.5)
                return;

            int newSize = size * 2 + 1;
            while (!IsPrime(newSize))
                newSize = newSize + 1;

            size = newSize;

            var previousTable = table;
            table = new Entry<Key, Value>[newSize];
            for (int i = 0; i < previousTable.Length; i++)
                if (previousTable[i] != null && !previousTable[i].Deleted)
                {
                    table[GetHash(previousTable[i].key)] = previousTable[i];
                }

            bool IsPrime(int number)
            {
                if (number == 2) return true;
                if (number % 2 == 0) return false;
                for (int i = 3; i <= Math.Sqrt(number); i += 2)
                    if (number % i == 0)
                        return false;
                return true;
            }
        }

        public long HashCode(Key key)
        {
            long hashcode = 0;
            if (key is User)
            {
                for (int i = 0; i < (key as User).username.Length; i++)
                    hashcode += (key as User).username[i];
                hashcode += (key as User).password;
            }
            else if (key is AgeGroup)
                for (int i = 0; i < (key as AgeGroup).ageCategory.Length; i++)
                    hashcode += (key as AgeGroup).ageCategory[i];

            return hashcode % size;
        }

        public long GetHash(Key key)
        {
            long pos = HashCode(key), i = 1, first_deleted = -1;
            Entry<Key, Value> entry = table[pos];
            do
            {
                if (entry != null)
                {
                    if (!entry.Deleted && first_deleted == -1)
                        first_deleted = pos;
                    if (entry.key.Equals(key) && !entry.Deleted)
                        return pos;
                }
                pos += 2 * i - 1;
                pos %= size;
                i++;
                entry = table[pos];

            } while (entry != null);
            return pos;
        }
    }
}
