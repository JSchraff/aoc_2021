using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;

namespace d1_t2
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputfile = "input.txt";
            string path = Path.Combine(Environment.CurrentDirectory, inputfile);
            string[] lines = File.ReadAllLines(path);

            int[] numbers = lines[0].Split(',').Select(x => Int32.Parse(x)).ToArray();

            List<string> board_src = lines.ToList();
            board_src.RemoveAt(0);

            List<int[,]> boards = parseBoards(board_src);
            try
            {
                foreach (int drawn in numbers)
                {
                    List<Bingo> bingos = new List<Bingo>();
                    foreach (int[,] board in boards)
                    {
                        try
                        {
                            fillBoard(board, drawn);
                        }catch(Bingo bingo)
                        {
                            if(boards.Count > bingos.Count+1)
                            {
                                bingos.Add(bingo);
                            }
                            else
                            {
                                throw bingo;
                            }
                        }
                    }
                    foreach( Bingo bingo in bingos)
                    {
                        boards.Remove(bingo.getBoard());
                    }
                }
            }
            catch (Bingo bingo)
            {
                Console.WriteLine(getTotal(bingo.getBoard()) * bingo.getLastDrawn());
            }
            Thread.Sleep(10000);

        }

        private static int getTotal(int[,] board)
        {
            int total = 0;
            for (int i = 0; i < board.GetLength(0); i++)
                for (int j = 0; j < board.GetLength(1); j++)
                    if (board[i, j] != -1)
                        total += board[i, j];
            return total;
        }

        private class Bingo : Exception
        {

            private int[,] board;
            private int last_drawn;

            public Bingo(int[,] board, int last_drawn)
            {
                this.board = board;
                this.last_drawn = last_drawn;
            }

            public int[,] getBoard()
            {
                return board;
            }

            public int getLastDrawn()
            {
                return last_drawn;
            }
        }

        private static void fillBoard(int[,] board, int drawn)
        {
            for (int i = 0; i < board.GetLength(0); i++)
                for (int j = 0; j < board.GetLength(1); j++)
                    if (board[i, j] == drawn)
                        board[i, j] = -1;
            checkBoard(board, drawn);
        }

        private static void checkBoard(int[,] board, int drawn)
        {
            bool found = true;
            //check rows
            for (int i = 0; i < board.GetLength(0); i++)
            {
                found = true;
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] != -1)
                    {
                        found = false;
                        break;
                    }
                }
                if (found)
                {
                    throw new Bingo(board, drawn);

                }


            }
            // check comuns
            for (int i = 0; i < board.GetLength(0); i++)
            {
                found = true;
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[j, i] != -1)
                    {
                        found = false;
                        break;
                    }
                }
                if (found)
                {
                    throw new Bingo(board, drawn);

                }


            }


            // check diagonals
            found = true;
            for (int i = 0; i < board.GetLength(0); i++)
            {
                if (board[i, i] != -1)
                {
                    found = false;
                    break;
                }
            }
            if (found)
            {
                throw new Bingo(board, drawn);

            }
            found = true;
            for (int i = 0; i < board.GetLength(0); i++)
            {
                if (board[i, board.GetLength(0) - i - 1] != -1)
                {
                    found = false;
                    break;
                }
            }
            if (found)
            {
                throw new Bingo(board, drawn);

            }
        }

        private static List<int[,]> parseBoards(List<string> all_board_lines)
        {
            if (all_board_lines.Count == 0)
            {
                return new List<int[,]>(); ;
            }
            List<string> board_lines = all_board_lines.GetRange(0, 6);
            all_board_lines.RemoveRange(0, 6);
            board_lines.RemoveAt(0);

            int[,] board = new int[5, 5];

            for (int i = 0; i < 5; i++)
            {
                Regex reg = new Regex(@"\s*(\d+)\s+(\d+)\s+(\d+)\s+(\d+)\s+(\d+)");
                Match m = reg.Match(board_lines[i]);
                for (int j = 0; j < 5; j++)
                {


                    board[i, j] = Int32.Parse(m.Groups[j + 1].ToString());
                }
            }

            List<int[,]> all_boards = parseBoards(all_board_lines);
            all_boards.Add(board);
            return all_boards;
        }
    }
}
