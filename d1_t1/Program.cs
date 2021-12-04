using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace d1_t1
{
    class Program
    {
        static void Main(string[] args) {
            string inputfile = "input.txt";
            string path = Path.Combine(Environment.CurrentDirectory, inputfile);
            int[] measurements = File.ReadAllLines(path).Select(x=>Int32.Parse(x)).ToArray();
            int last_measurement = Int32.MaxValue;
            int count = 0;
            foreach (int value in measurements){
                if (value > last_measurement)
                {
                    count++;
                }
                last_measurement = value;
            }

            Console.WriteLine(count);
            Thread.Sleep(2000);
         
        }
    }
}
