using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_IA_V1
{
    class Board
    {
        /*
      -1 = camp nepopulat,
      0 = id player,
      1 = id AI 1
      2 = id AI 2
       */
        public static Dictionary<int, string> names = new Dictionary<int, string>();
        public int playerTurn = 0;
        public int F = 0;
        public (int, int) newPiecePos;
        /// <summary>
        ///  un joc normal are 6 randuri si 7 coloane
        /// </summary>
        public int[,] grid = new int[6, 7];

        /// <summary>
        /// vector ce contine inaltimile pentru fiecare coloana
        /// </summary>
        public int[] heights = new int[7];
        public bool win=false;

        /// <summary>
        /// lista pieseolor din joc
        /// </summary>

        public Board(Board otherObj)
        {
            this.playerTurn = otherObj.playerTurn;
            for (int j = 0; j < 7; j++)
            {
                for (int i = 0; i < 6; i++)
                {
                    this.grid[i, j] = otherObj.grid[i, j];
                   
                }
                this.heights[j]= otherObj.heights[j];
            }
        }
        public Board()
        {
            if (names.Count == 0)
            {
                names.Add(0, "Player");
                names.Add(1, "AI 1");
                names.Add(2, "AI 2");
            }
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    grid[i, j] = -1;
                }
            }
        }

        public void PrintGrid()
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

        public int NextTurn()
        {
            playerTurn++;
            if (playerTurn >= 3) playerTurn = 0;
            return playerTurn;
        }
    }
}
