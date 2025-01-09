using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_IA_V1
{
    public class Board
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


        public Board(Board otherObj)
        {
            this.playerTurn = otherObj.playerTurn;
            for (int j = 0; j < 7; j++)
            {
                for (int i = 0; i < 6; i++)
                {
                    this.grid[i, j] = otherObj.grid[i, j];

                }
                this.heights[j] = otherObj.heights[j];
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
            playerTurn = 0;
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    grid[i, j] = -1;
                }
            }
        }
        public override string ToString()
        {
            string res = "";
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (grid[i, j] == -1)
                        res+=($". ");
                    else
                        res+=($"{grid[i, j]} ");

                }
                res+=("\n");
            }
            for (int i = 0; i < 7; i++)
                res +=($"- ");
            res += ("\n");

            for (int i = 0; i < 7; i++)
                res += ($"{heights[i]} ");
            res += ("<- Heights");

            res += ("\n");
            return res;
        }
        public void PrintGrid()
        {
            Console.WriteLine(this);


        }
        public bool CheckDraw()
        {
            for (int i = 0; i < 6; i++)
            {
                if (heights[i] != 6) return false;
            }
            return true;
        }
        public List<(int, int)> CheckWin()
        {
            List<(int, int)> winningPiecesPositions = new List<(int, int)>();

            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 6; i++)
                {

                    if (grid[i, j] == playerTurn && grid[i, j + 1] == playerTurn && grid[i, j + 2] == playerTurn && grid[i, j + 3] == playerTurn)
                    {
                        winningPiecesPositions.Add((i, j));
                        winningPiecesPositions.Add((i, j + 1));
                        winningPiecesPositions.Add((i, j + 2));
                        winningPiecesPositions.Add((i, j + 3));
                        return winningPiecesPositions;
                    }
                }
            }
            for (int j = 0; j < 7; j++)
            {
                for (int i = 0; i < 3; i++)
                {

                    if (grid[i, j] == playerTurn && grid[i + 1, j] == playerTurn && grid[i + 2, j] == playerTurn && grid[i + 3, j] == playerTurn)
                    {
                        winningPiecesPositions.Add((i, j));
                        winningPiecesPositions.Add((i + 1, j));
                        winningPiecesPositions.Add((i + 2, j));
                        winningPiecesPositions.Add((i + 3, j));
                        return winningPiecesPositions;
                    }
                }

            }
            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 3; i++)
                {

                    if (grid[i, j] == playerTurn && grid[i + 1, j + 1] == playerTurn && grid[i + 2, j + 2] == playerTurn && grid[i + 3, j + 3] == playerTurn)
                    {
                        winningPiecesPositions.Add((i, j));
                        winningPiecesPositions.Add((i + 1, j + 1));
                        winningPiecesPositions.Add((i + 2, j + 2));
                        winningPiecesPositions.Add((i + 3, j + 3));
                        return winningPiecesPositions;
                    }
                }

            }
            for (int j = 0; j < 4; j++)
            {
                for (int i = 3; i < 6; i++)
                {

                    if (grid[i, j] == playerTurn && grid[i - 1, j + 1] == playerTurn && grid[i - 2, j + 2] == playerTurn && grid[i - 3, j + 3] == playerTurn)
                    {
                        winningPiecesPositions.Add((i, j));
                        winningPiecesPositions.Add((i - 1, j + 1));
                        winningPiecesPositions.Add((i - 2, j + 2));
                        winningPiecesPositions.Add((i - 3, j + 3));
                        return winningPiecesPositions;
                    }
                }

            }

            return null;
        }

        public int NextTurn()
        {
            playerTurn++;
            if (playerTurn >= 3) playerTurn = 0;
            return playerTurn;
        }
    }
}
