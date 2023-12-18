using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP1
{
    class Program
    {
        static void Main(string[] args) 
        {
            HuffmanAlg huffman = new HuffmanAlg();
            huffman.PackFile("DataFile.txt", "Rezult.txt");
        }
        
    }

    
}



