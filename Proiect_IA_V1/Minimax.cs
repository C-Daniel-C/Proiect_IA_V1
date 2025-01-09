using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;


namespace Proiect_IA_V1
{
    public class Minimax
    {

        //DIFFICULTY

        public const int EASY = 1;
        public const int MEDIUM = 2;
        public const int HARD = 3;
        public const int EXTREME = 4;

        public static int DIFFICULTY = EASY;

        private static int MAX_DEPTH = 2 + DIFFICULTY;
        private static Random _rand = new Random();


        public static void setDifficulty(int value)
        {
            DIFFICULTY = value;
            MAX_DEPTH = 2 + DIFFICULTY;

        }
        public static Board Minimax2L(Board table, int depth, int alpha, int beta, int ai)
        {

            if (depth == MAX_DEPTH)
            {
                EvaluateBoard(table, ai);
                return table;
            }
            else
            {
                List<Board> validMove = new List<Board>();

                for (int i = 0; i < table.heights.Length; i++)
                {
                    if (table.heights[i] != 6)
                    {
                        Board newManager = new Board(table);
                        var cursorX = 5 - table.heights[i];
                        newManager.grid[cursorX, i] = table.playerTurn;
                        newManager.newPiecePos.Item1 = cursorX;
                        newManager.newPiecePos.Item2 = i;
                        newManager.heights[i]++;
                        validMove.Add(newManager);
                    }
                }
                Board nextBoard = new Board();
                if (depth % 3 == 0)
                {
                    nextBoard.F = -999;
                    foreach (Board move in validMove)
                    {
                        move.NextTurn();
                        var tryNextBoard = Minimax2L(move, depth + 1, alpha, beta, ai);
                        if (tryNextBoard.F > nextBoard.F)
                        {
                            if (depth == 0)
                                nextBoard = move;
                            nextBoard.F = tryNextBoard.F;
                        }
                        else if (tryNextBoard.F == nextBoard.F && _rand.Next(100) < 50)
                        {
                            if (depth == 0)
                                nextBoard = move;
                            nextBoard.F = tryNextBoard.F;
                        }
                        alpha = Math.Max(alpha, nextBoard.F);
                        if (alpha >= beta)
                            break;
                    }
                }
                else
                {
                    nextBoard.F = 999;
                    foreach (Board move in validMove)
                    {
                        move.NextTurn();
                        var tryNextBoard = Minimax2L(move, depth + 1, alpha, beta, ai);
                        if (nextBoard.F > tryNextBoard.F)
                        {
                            nextBoard.F = tryNextBoard.F;
                        }
                        else if (tryNextBoard.F == nextBoard.F && _rand.Next(100) < 50)
                        {
                            nextBoard.F = tryNextBoard.F;
                        }
                        beta = Math.Min(beta, nextBoard.F);
                        if (alpha >= beta)
                            break;
                    }
                }
                nextBoard.playerTurn = ai;
                return nextBoard;
            }
        }

        public static void EvaluateBoard(Board board, int ai)
        {
            // Center Column
            for (int i = 0; i < 6; i++)
            {
                if (board.grid[i, 4] == ai)
                {
                    board.F += 3;
                }
            }

            // Score Horizontal positions
            for (int i = 0; i < 6; i++)
            {
                List<int> row_array = new List<int>();
                for (int j = 0; j < 7; j++)
                {
                    row_array.Add(board.grid[i, j]);
                }
                for (int j = 0; j < 4; j++)
                {
                    List<int> window = new List<int>();
                    for (int k = j; k < j + 4; k++)
                    {
                        window.Add(row_array[k]);
                    }
                    board.F += EvaluateLine(window, ai);
                }
            }

            // Score Vertical Positions

            for (int j = 0; j < 7; j++)
            {
                List<int> column_array = new List<int>();
                for (int i = 0; i < 6; i++)
                {
                    column_array.Add(board.grid[i, j]);
                }
                for (int i = 0; i < 3; i++)
                {
                    List<int> window = new List<int>();
                    for (int k = i; k < i + 4; k++)
                    {
                        window.Add(column_array[k]);
                    }
                    board.F += EvaluateLine(window, ai);
                }
            }
            // Score positive diagonals
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    List<int> window = new List<int>();
                    for (int k = 0; k < 4; k++)
                    {
                        window.Add(board.grid[i + k, j + k]);
                    }
                    board.F += EvaluateLine(window, ai);
                }
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    List<int> window = new List<int>();
                    for (int k = 0; k < 4; k++)
                    {
                        window.Add(board.grid[i + 3 - k, j + k]);
                    }
                    board.F += EvaluateLine(window, ai);
                }
            }


        }
        public static int EvaluateLine(List<int> line, int ai)
        {
            Dictionary<int, int> enemy_pieces = new Dictionary<int, int>();
            int my_pieces = 0;
            int empty = 0;
            int score = 0;
            int i = 0;

            //P
            while(i < 3) //C1
            {
                if (i != ai) //C2
                {
                    //P0
                    enemy_pieces.Add(i, 0); //A0
                }
                //P1
                i++; //A1
            }
            //P2
            i = 0; //A2
            //P3
            while(i < line.Count) //C3
            {

                if (line[i] == ai) //C4
                {
                    //P4
                    my_pieces++; //A3
                }
                else if (line[i] == -1) //C5
                {
                    //P5
                    empty++; //A4
                }
                else 
                {
                    //P6
                    enemy_pieces[line[i]]++; //A5
                }
                //P7
                i++; //A6
            }


            if (my_pieces == 4) //C6
            {
                //P8
                score += 100; //A7

            }
            else if (my_pieces == 3 && empty == 1) //C7
            {
                //P9
                score += 3; //A8
            }
            else if (my_pieces == 2 && empty == 2) //C8
            {
                //P10
                score += 2; //A9
            }
            //P11
            foreach (int j in enemy_pieces.Keys) //C9
            {
                if (enemy_pieces[j] == 3 && empty == 1) //C10
                {
                    //P12
                    score -= (4 * DIFFICULTY); //A10
                }
                else if (enemy_pieces[j] == 4) //C11
                {
                    //P13
                    score -= (5 * DIFFICULTY); //A11
                }
            }
            //P14
            return score; //A12

        }

    }
}
