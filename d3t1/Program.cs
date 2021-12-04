using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;

namespace d1_t1
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputfile = "input.txt";
            string path = Path.Combine(Environment.CurrentDirectory, inputfile);
            string[] lines = File.ReadAllLines(path);

            int inputs = lines.Length;
            int input_length = lines[0].Length;


            int[] ones = new int[input_length];

            foreach (string line in lines)
            {
                for (int j = 0; j < input_length; j++)
                {
                    char c = line.ToCharArray()[j];
                    if (c == '1')
                    {
                        ones[j]++;
                    }
                }
            }

            string output = "";
            foreach (int count in ones)
            {
                if (count > inputs / 2)
                {
                    output += "1";
                }
                else
                {
                    output += "0";
                }
            }

            uint gamma = Convert.ToUInt32(output, 2);
            uint epsilon = Convert.ToUInt32(new String(output.Select(x => x == '1' ? '0' : '1').ToArray()), 2);

            Console.WriteLine(gamma * epsilon);
            Thread.Sleep(10000);

        }
    }
}
