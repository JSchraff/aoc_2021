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

            string[] o2 = lines;
            string[] co2 = lines;

            for (int i = 0; i < lines[0].Length; i++)
            {
                o2 = filter(o2, i, true);
                co2 = filter(co2, i, false);
            }

            uint o2_value = Convert.ToUInt32(o2[0], 2);
            uint co2_value = Convert.ToUInt32(co2[0], 2);
            Console.WriteLine(o2_value * co2_value);
            Thread.Sleep(10000);

        }

        private static string[] filter(string[] input, int position, bool higher)
        {
            if (input.Length == 1)
                return input;
            int ones = 0;
            foreach (string line in input)
            {
                if (line[position] == '1')
                {
                    ones++;
                }
            }
            char value = ((ones >= (input.Length / 2)) == higher) ? '1' : '0';
            return input.Where(x=>x[position]==value).ToArray();
        }
    }
}
