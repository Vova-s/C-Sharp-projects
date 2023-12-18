using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PP1
{

    class HuffmanAlg
    {
        public void PackFile(string DataFile, string ArchFile) 
        {
            byte[] data = File.ReadAllBytes(DataFile);
            byte[] arch = CompressBytes(data);
        }

        private byte[] CompressBytes(byte[] data)
        {
            int[] frequency = CalculateFrequency(data);
            Branch root = CreateHuffmanTree(frequency);
            string[] code = CreateHuffmanElement(root,data);
            Decoding();
            return data;
        }
        Dictionary<char, string> dict = new Dictionary<char, string>();
        string encoded  = "";
        private string[] CreateHuffmanElement(Branch root, byte[] data)
        {
            string[] codes = new string[256];
            Next(root, "");
            void Next(Branch branch, string code)
            {
                if (branch.b0 == null)
                {
                    codes[branch.symbol] = code;
                    dict.Add((char)branch.symbol, codes[branch.symbol]);
                    
                }
                else 
                {
                    Next(branch.b0, code + "0");
                    Next(branch.b1, code + "1");
                }
            }
           
            foreach (var d in dict)
            {
                WriteLine($"Letter:{d.Key}. Code:{d.Value}");
            }
            for (int i = 0; i < data.Length; i++)
            {
                char code = (char) data[i];
                encoded += dict[(char)data[i]];
                Write(dict[code]);
                
            }
            
            return codes;
        }
        public void Decoding() 
        {
            string decodedText = "";
            string currentText = "";
            string codedText = encoded;
            for (int j = 0; j < codedText.Length; j++)
            {
                currentText += codedText[j];
                if (dict.ContainsValue(currentText))
                {
                    foreach (var el in dict)
                    {
                        if (el.Value == currentText)
                        {
                            currentText = "";
                            decodedText += el.Key;
                        }
                    }
                }
                
            }
            WriteLine();
            WriteLine(decodedText);
            
        }

        private Branch CreateHuffmanTree(int[] frequency)
        {
            PriorityQueue<Branch> priQ = new PriorityQueue<Branch>();
            for (int i = 0; i < 256; i++) 
            {
                if (frequency[i] > 0) 
                {
                    priQ.Enqueue(frequency[i], new Branch ((byte)i, frequency[i]));
                }
            }
            while (priQ.Get_size() > 1) 
            {
                Branch b0 = priQ.Dequeue();
                Branch b1 = priQ.Dequeue();
                int freq = b0.freqs + b1.freqs;
                Branch next = new Branch(freq, b0, b1);
                priQ.Enqueue(freq, next);
            }
            return priQ.Dequeue();

        }
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

        private int[] CalculateFrequency(byte[] data)
        {
            int[] freq = new int[256];
            foreach (byte b in data) 
            {
                freq[b]++;
            }
            return freq;
        }

        class Branch 
        {
            public readonly byte symbol;
            public readonly int freqs;
            public readonly Branch  b0;
            public readonly Branch  b1;

            public Branch(byte symbol, int freqs)
            {
                this.symbol = symbol;
                this.freqs = freqs;
            }

            public Branch(int freqs, Branch b0, Branch b1)
            {
                this.freqs = freqs;
                this.b0 = b0;
                this.b1 = b1;
            }
        }
    }
}