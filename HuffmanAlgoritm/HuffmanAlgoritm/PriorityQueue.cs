using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PP1
{
    internal class PriorityQueue<T>
    {
        int size;
        SortedDictionary<int, Queue<T>> storage;

        public PriorityQueue() 
        {
            storage = new SortedDictionary<int, Queue<T>>();
            size = 0;
        }

        public int Get_size() => size;

        public void Enqueue(int priority, T item) 
        {
            if (!storage.ContainsKey(priority)) 
            {
                storage.Add(priority, new Queue<T>());
            }
            storage[priority].Enqueue(item);
            size++;
        }

        public T Dequeue() 
        {
            if (size == 0) 
            {
                throw new System.Exception("empty");
            }
            size--;
            foreach (Queue<T> q in storage.Values) 
            {
                if (q.Count > 0) 
                {
                    return q.Dequeue();
                }
            }
            throw new System.Exception("queue error");
        }
    }
}