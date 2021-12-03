using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Solutions
{
    internal class Day2
    {
        public static void a()
        {
            var input = File.ReadAllLines("solutions/day2/input.txt");
            int xPos = 0, yPos = 0;

            foreach(string line in input)
            {
                var command = line.Split(' ');

                switch(command[0])
                {
                    case "forward":
                        xPos += int.Parse(command[1]);
                        break;
                    case "up":
                        yPos -= int.Parse(command[1]);
                        break;
                    case "down":
                        yPos += int.Parse(command[1]);
                        break;
                }
            }

            Console.WriteLine($"XPos: {xPos}, YPos: {yPos}, Product: {xPos * yPos}");
        }

        public static void b()
        {
            var input = File.ReadAllLines("solutions/day2/input.txt");
            int xPos = 0, yPos = 0, aim = 0;

            foreach (string line in input)
            {
                var command = line.Split(' ');

                switch (command[0])
                {
                    case "forward":
                        xPos += int.Parse(command[1]);
                        yPos += aim * int.Parse(command[1]);
                        break;
                    case "up":
                        aim -= int.Parse(command[1]);
                        break;
                    case "down":
                        aim += int.Parse(command[1]);
                        break;
                }
            }

            Console.WriteLine($"XPos: {xPos}, YPos: {yPos}, Product: {xPos * yPos}");
        }
    }
}
