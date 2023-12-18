using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableTask
{
    public class Entry<Key, Value>
    {
        public Key key;
        public Value value;
        public bool Deleted;

        public Entry(Key key, Value value)
        {
            this.key = key;
            this.value = value;
        }
    }
}
