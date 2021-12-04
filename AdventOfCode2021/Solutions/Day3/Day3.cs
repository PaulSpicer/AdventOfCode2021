using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Solutions
{
    internal class Day3
    {
        public static void a()
        {
            var input = File.ReadAllLines("solutions/day3/input.txt");
            var positiveBitCount = CountPostiveBits(input);

            var noOfLines = input.Length;
            var GammaRate = new StringBuilder();
            var EpsilonRate = new StringBuilder();

            foreach (var bit in positiveBitCount)
            {
                if (bit > noOfLines / 2)
                {
                    GammaRate.Append(1);
                    EpsilonRate.Append(0);
                }
                else
                {
                    GammaRate.Append(0);
                    EpsilonRate.Append(1);
                }
            }

            var answer = Convert.ToInt32(GammaRate.ToString(), 2) * Convert.ToInt32(EpsilonRate.ToString(), 2);

            Console.WriteLine($"Gamma: {GammaRate.ToString()}, Epsilon: {EpsilonRate.ToString()}");
            Console.WriteLine($"Answer: {answer}");
        }

        public static void b()
        {
            var input = File.ReadAllLines("solutions/day3/input.txt");

            var oxygenRating = CalculateRating(input, true);
            var scrubberRating = CalculateRating(input, false);

            Console.WriteLine($"Oxygen: {oxygenRating}, Scrubber: {scrubberRating}, Answer: {oxygenRating * scrubberRating}");
        }

        private static int[] CountPostiveBits(string[] input)
        {
            var noOfBits = input[0].Length;
            var positiveBitCount = new int[noOfBits];

            foreach (var line in input)
            {
                for (var i = 0; i < noOfBits; i++)
                {
                    if (line[i] == '1') { positiveBitCount[i]++; }
                }
            }

            return positiveBitCount;
        }

        private static int CalculateRating(string[] input, bool isMostCommon)
        {
            var remainingLines = input.ToList();
            var index = 0;
            char charToDelete;

            while (remainingLines.Count > 1)
            {
                var postiveBitCounter = 0;
            
                foreach (var line in remainingLines)
                {
                    if (line[index] == '1') { postiveBitCounter++; }
                }

                if ((float)postiveBitCounter >= remainingLines.Count / 2f)
                {
                    charToDelete = isMostCommon ? '0' : '1';
                }
                else
                {
                    charToDelete = isMostCommon ? '1' : '0';
                }

                for(int i = remainingLines.Count; i > 0; i--)
                {
                    if(remainingLines[i-1][index] == charToDelete) 
                    { 
                        remainingLines.RemoveAt(i - 1); 
                    }
                }

                index++;
            }

            return Convert.ToInt32(remainingLines[0], 2);
        }
    }
}
