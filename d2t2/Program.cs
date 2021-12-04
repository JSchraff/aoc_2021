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
            int depth = 0;
            int pos = 0;
            int aim = 0;
            foreach (string line in lines)
            {
                string pat = @"(\w+)\s+(\d)";
                Regex r = new Regex(pat, RegexOptions.IgnoreCase);
                Match m = r.Match(line);
                string direction = m.Groups[1].Value;
                int amount = Int32.Parse(m.Groups[2].Value);
                switch (direction)
                {
                    case "forward":
                        pos += amount;
                        depth += aim * amount;
                        break;
                    case "down":
                        aim += amount;
                        break;
                    case "up":
                        aim -= amount;
                        break;
                    default:
                        throw new Exception("unknown dirction: " + direction);

                }
            }



            Console.WriteLine(depth * pos);
            Thread.Sleep(2000);

        }
    }
}
