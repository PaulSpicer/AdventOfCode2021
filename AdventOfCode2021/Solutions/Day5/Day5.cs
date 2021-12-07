using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Solutions
{
    internal class Day5
    {
        public static void a()
        {
            var input = File.ReadAllLines("solutions/day5/input.txt");
            var Lines = new List<GridLine>();
            int[,] grid;

            foreach (var line in input)
            {
                Lines.Add(new GridLine(line));
            }

            var BiggestX = Math.Max(Lines.Max(co => co.Start.X), Lines.Max(co => co.End.X));
            var BiggestY = Math.Max(Lines.Max(co => co.Start.Y), Lines.Max(co => co.End.Y));

            grid = new int[BiggestX, BiggestY];

            foreach (var line in Lines)
            {
                if (line.Start.X == line.End.X)
                {
                    var direction = line.End.Y > line.Start.Y ? 1 : -1; 
                    for (var i = line.Start.Y; i != line.End.Y + direction; i += direction)
                    {
                        grid[line.Start.X, i]++;
                    }
                }
                if (line.Start.Y == line.End.Y)
                {
                    var direction = line.End.X > line.Start.X ? 1 : -1;
                    for (var i = line.Start.X; i != line.End.X + direction; i += direction)
                    {
                        grid[i, line.Start.Y]++;
                    }
                }
            }

            var counter = 0;

            for (var i = 0; i < grid.GetLength(0); i++)
            {
                for (var j = 0; j < grid.GetLength(1); j++)
                {
                    if (grid[i,j] >= 2) 
                    { 
                        counter++; 
                    };
                }
            }
            Console.WriteLine($"Total coordinates with a count over 2: {counter}");   
        }

        public static void b()
        {
            var input = File.ReadAllLines("solutions/day5/input.txt");
            var Lines = new List<GridLine>();
            int[,] grid;

            foreach (var line in input)
            {
                Lines.Add(new GridLine(line));
            }

            var BiggestX = Math.Max(Lines.Max(co => co.Start.X), Lines.Max(co => co.End.X));
            var BiggestY = Math.Max(Lines.Max(co => co.Start.Y), Lines.Max(co => co.End.Y));

            grid = new int[BiggestX + 1, BiggestY + 1];

            foreach (var line in Lines)
            {
                if (line.Start.X == line.End.X)
                {
                    var direction = line.End.Y > line.Start.Y ? 1 : -1;
                    for (var i = line.Start.Y; i != line.End.Y + direction; i += direction)
                    {
                        grid[line.Start.X, i]++;
                    }
                }
                else if (line.Start.Y == line.End.Y)
                {
                    var direction = line.End.X > line.Start.X ? 1 : -1;
                    for (var i = line.Start.X; i != line.End.X + direction; i += direction)
                    {
                        grid[i, line.Start.Y]++;
                    }
                }
                else
                {
                    var xDir = line.End.X > line.Start.X ? 1 : -1;
                    var yDir = line.End.Y > line.Start.Y ? 1 : -1;
                    var steps = xDir == 1 ? line.End.X - line.Start.X : line.Start.X - line.End.X;

                    for (var i = 0; i <= steps; i++)
                    {
                        grid[line.Start.X + (i * xDir), line.Start.Y + (i * yDir)]++;
                    }

                }
            }

            var counter = 0;

            for (var i = 0; i < grid.GetLength(0); i++)
            {
                for (var j = 0; j < grid.GetLength(1); j++)
                {
                    if (grid[i, j] >= 2)
                    {
                        counter++;
                    };
                }
            }
            Console.WriteLine($"Total coordinates with a count over 2: {counter}");
        }
    }

    internal class GridLine {
        public Point Start { get; private set; }
        public Point End { get; private set; }

        public GridLine(string Line)
        {
            var rawCoords = new List<string>();
            var chopped = Line.Split(" -> ");

            foreach (var coords in chopped)
            {
                rawCoords.AddRange((coords.Split(",")));
            }

            Start= new Point(Convert.ToInt32(rawCoords[0]), Convert.ToInt32(rawCoords[1]));
            End = new Point(Convert.ToInt32(rawCoords[2]), Convert.ToInt32(rawCoords[3]));
        }
    }
}
