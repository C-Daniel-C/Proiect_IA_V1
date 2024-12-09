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

        public static void GameManagerInit()
        {
            names.Add(0, "Player");
            names.Add(1, "AI 1");
            names.Add(2, "AI 2");
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
        private static void PrintGrid()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (grid[i, j] == -1)
                        Console.Write($"X ");
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
        private static bool CheckColumn(int col)
        {
            //for(int 0)
            return true;
        }
        private static bool inRange(int val, bool column = true)
        {
            if (column) //verificam daca o valoare e in range pentru coloana
            {
                if (val >= 0 && val < 6)
                    return true;
                else
                    return false;
            }
            else //verificam daca o valoare e in range pentru rand
            {
                if (val >= 0 && val < 7)
                    return true;
                else
                    return false;
            }



        }
        public static int NextTurn()
        {
            PrintGrid();

            Console.WriteLine(CheckWin());
            playerTurn++;
            if (playerTurn >= 3) playerTurn = 0;
            return playerTurn;
        }
    }
}
