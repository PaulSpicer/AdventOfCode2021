using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Solutions
{
    internal class Day4
    {
        public static void a()
        {
            var input = File.ReadAllLines("solutions/day4/input.txt");
            var callouts = input[0].Split(',');
            var boardRow = 0;

            var boards = new List<string[,]>();
            var currentBoard = new string[5,5];

            string[,] winningBoard = new string[5,5];
            int winningCall = -1; 
            
            for(int i = 2; i < input.Length; i++)
            {
                if (input[i] == "") { 
                    currentBoard = new string[5, 5];
                    boardRow = 0;
                    continue;
                }

                var rowValues = input[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (var j = 0; j < 5; j++)
                {
                    currentBoard[boardRow, j] = rowValues[j];
                }

                if (boardRow == 4) 
                { 
                    boards.Add(currentBoard); 
                }

                boardRow++;
            }

            foreach (var call in callouts)
            {
                foreach(var board in boards)
                {
                    for (var i = 0; i < 5; i++)
                    {
                        for (var j = 0; j < 5; j++)
                        {
                            if (board[i,j] == call)
                            {
                                board[i, j] = "*";

                                var winCol = true;
                                var winRow = true;

                                for (var k = 0; k < 5; k++)
                                {
                                    if (board[i,k] != "*") { winRow = false; }
                                    if (board[k,j] != "*") { winCol = false; }
                                }

                                if (winRow || winCol)
                                {
                                    winningCall = Convert.ToInt32(call);
                                    winningBoard = board;
                                    goto Complete;
                                }
                            }
                        }
                    }
                }
            }

        Complete:;
            int unmarkedSum = 0;

            for (var i = 0; i < 5; i++)
            {
                for (var j = 0; j < 5; j++)
                {
                    if (winningBoard[i,j] != "*")
                    {
                        unmarkedSum += int.Parse(winningBoard[i, j]);
                    }
                }
            }
            Console.WriteLine($"Winning Call: {winningCall}");
            Console.WriteLine($"Final Score: {winningCall * unmarkedSum}");

        }

        public static void b()
        {
            var input = File.ReadAllLines("solutions/day4/input.txt");
            var callouts = input[0].Split(',');
            var boardRow = 0;

            var boards = new List<string[,]>();
            var currentBoard = new string[5, 5];

            string[,] winningBoard = new string[5, 5];
            int winningCall = -1;

            for (int i = 2; i < input.Length; i++)
            {
                if (input[i] == "")
                {
                    currentBoard = new string[5, 5];
                    boardRow = 0;
                    continue;
                }

                var rowValues = input[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (var j = 0; j < 5; j++)
                {
                    currentBoard[boardRow, j] = rowValues[j];
                }

                if (boardRow == 4)
                {
                    boards.Add(currentBoard);
                }

                boardRow++;
            }

            var winCount = 0;

            foreach (var call in callouts)
            {            
                foreach (var board in boards)
                {
                    if (board[0, 0] == "win") {
                        continue;
                    }

                    for (var i = 0; i < 5; i++)
                    {
                        for (var j = 0; j < 5; j++)
                        {
                            if (board[i, j] == call)
                            {
                                board[i, j] = "*";

                                var winCol = true;
                                var winRow = true;

                                for (var k = 0; k < 5; k++)
                                {
                                    if (board[i, k] != "*") { winRow = false; }
                                    if (board[k, j] != "*") { winCol = false; }
                                }

                                if (winRow || winCol)
                                {
                                    winningCall = Convert.ToInt32(call);
                                    winningBoard = board;
                                    winCount++;
                                    if (winCount == 100) { goto Complete; }
                                    board[0, 0] = "win";
                                }
                            }
                        }
                    }
                }
            }

        Complete:;
            int unmarkedSum = 0;

            for (var i = 0; i < 5; i++)
            {
                for (var j = 0; j < 5; j++)
                {
                    if (winningBoard[i, j] != "*")
                    {
                        unmarkedSum += int.Parse(winningBoard[i, j]);
                    }
                }
            }
            Console.WriteLine($"Winning Call: {winningCall}");
            Console.WriteLine($"Final Score: {winningCall * unmarkedSum}");

        }
    }
}
