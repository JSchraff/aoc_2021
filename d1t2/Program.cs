using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace d1t2
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputfile = "input.txt";
            string path = Path.Combine(Environment.CurrentDirectory, inputfile);
            int[] measurements = File.ReadAllLines(path).Select(x => Int32.Parse(x)).ToArray();
            int count = 0;
            for(int i = 0; i < measurements.Length - 3; i++)
            {
                if (measurements[i] < measurements[i + 3])
                    count++;
            }

            Console.WriteLine(count);
            Thread.Sleep(2000);

        }
    }
}
