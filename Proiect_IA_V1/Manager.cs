using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_IA_V1
{
    class Manager
    {
        /*
      -1 = camp nepopulat,
      0 = id player,
      1 = id AI 1
      2 = id AI 2
       */
        public static Dictionary<int, string> names = new Dictionary<int, string>();
        public static int playerTurn = 0;

        /// <summary>
        ///  un joc normal are 6 randuri si 7 coloane
        /// </summary>
        public static int[,] grid = new int[6, 7];

        /// <summary>
        /// vector ce contine inaltimile pentru fiecare coloana
        /// </summary>
        public static int[] heights = new int[7];

        /// <summary>
        /// lista pieseolor din joc
        /// </summary>
        public static Piece[,] pieces = new Piece[6, 7];

        public static void GameManagerInit()
        {
            names.Add(0, "Player 1");
            names.Add(1, "Player 2");
            names.Add(2, "AI");
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    grid[i, j] = -1;
                }
            }
        }
        //TODO check win
        //TODO: make piece class 
        private static int CheckWin()
        {
            int streak = 1;
            for (int i = 1; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (grid[i, j] == grid[i - 1, j] && grid[i, j] != -1)
                    {
                        streak++;
                        if (streak == 4)
                        {
                            return grid[i, j];
                        }
                    }
                    else
                    {
                        streak = 1;
                    }
                }
            }
            return -1;

        }

        public static void PrintGrid()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (grid[i, j] == -1)
                        Console.Write($". ");
                    else
                        Console.Write($"{grid[i, j]} ");

                }
                Console.Write("\n");
            }
            for (int i = 0; i < 7; i++)
                Console.Write($"- ");
            Console.Write("\n");

            for (int i = 0; i < 7; i++)
                Console.Write($"{heights[i]} ");
            Console.Write("<- Heights");

            Console.Write("\n");


        }

        public static int NextTurn()
        {

            Console.WriteLine(CheckWin());
            playerTurn++;
            if (playerTurn >= 3) playerTurn = 0;
            return playerTurn;
        }
    }
}
