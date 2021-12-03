using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Solutions
{
    internal class Day1
    {
        public static void a()
        {
            var input = File.ReadAllLines("solutions/day1/input.txt");
            var count = 0;

            for (var i = 1; i < input.Length; i++)
            {
                if (int.Parse(input[i]) > int.Parse(input[i - 1])) { count++; }
            }

            Console.WriteLine($"Total increasing readings is {count}");
        }

        public static void b()
        {
            var input = File.ReadAllLines("solutions/day1/input.txt");
            var count = 0;

            for (var i = 3; i < input.Length; i++)
            {
                if (int.Parse(input[i]) + int.Parse(input[i-1]) + int.Parse(input[i-2]) > 
                    int.Parse(input[i-1]) + int.Parse(input[i-2]) + int.Parse(input[i-3])) 
                { 
                    count++; 
                }
            }

            Console.WriteLine($"Total increasing grouped readings is {count}");
        }
    }
}
