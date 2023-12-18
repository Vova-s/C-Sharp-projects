using System.IO;
using System;
using static System.Console;

namespace MaterialCubeAnalyzer
{
    class Program
    {

        struct cube
        {
            private byte size;
            private string colour;
            private string material;

            public cube(byte size, string colour, string material)
            {
                this.size = size;
                this.colour = colour;
                this.material = material;
            }

            public byte getSize => size;
            public string getcolour => colour;
            public string getMaterial => material;
            public void printCube()
            {
                Write($"{size,3}");
                Write($"{colour,10}");
                WriteLine($"{material,10}");
            }

            public void PrintCube(StreamWriter file)
            {
                file.Write($"{size,3}");
                file.Write($"{colour,10}");
                file.WriteLine($"{material,10}");
            }
        }

        static StreamReader DataFile;
        static StreamWriter MyFileA, MyFileB;
        static int s;
        static int s_1;
        static void Main(string[] args)
        {
            try
            {
                DataFile = new StreamReader("DataFile.txt");
                MyFileA = new StreamWriter("Rez_a.txt");
                MyFileB = new StreamWriter("Rez_b.txt");

            }
            catch (Exception e)
            {
                WriteLine(e.Message);
                return;
            }
            checkDataLines();
            DataFile.Close();
            MyFileA.Close();
            MyFileB.Close();
        }
        static void checkDataLines()
        {
            byte s1;
            double v1;
            byte s2;
            double v2;
            byte s3;
            double v3;
            byte s4;
            double v4;
            v1 = 0;
            s1 = 0;
            v2 = 0;
            s2 = 0;
            v3 = 0;
            s3 = 0;
            v4 = 0;
            s4 = 0;
            while (!DataFile.EndOfStream)
            {
                string[] List = DataFile.ReadLine().Split(' ');
                cube c = new cube(byte.Parse(List[0]), List[1], List[2]);
                c.printCube();
                if (c.getcolour == "blue")
                {

                    s1++;
                    v1 += Math.Pow(c.getSize, 3);




                }
                else if (c.getcolour == "orange")
                {


                    s2++;
                    v2 += Math.Pow(c.getSize, 3);



                }
                else if (c.getcolour == "green")
                {


                    s3++;
                    v3 += Math.Pow(c.getSize, 3);



                }
                else
                {

                    s4++;
                    v4 += Math.Pow(c.getSize, 3);


                }

                B(c);

            }
            MyFileA.WriteLine("summ of blue : " + s1 + ";  their capacity : " + v1);
            MyFileA.WriteLine("summ of orange : " + s2 + ";  their capacity : " + v2);
            MyFileA.WriteLine("summ of green : " + s3 + ";  their capacity : " + v3);
            MyFileA.WriteLine("summ of red : " + s4 + ";  their capacity : " + v4);
            MyFileB.WriteLine("summ 1) : " + s);
            MyFileB.WriteLine("summ 2) : " + s_1);

        }
        static void B(cube c)
        {
            if (c.getSize == 3 && c.getMaterial == "Woody")
            {
                s++;
            }
            else if (c.getSize > 5 && c.getMaterial == "metalic")
            {
                s_1++;

            }

        }
    }
}