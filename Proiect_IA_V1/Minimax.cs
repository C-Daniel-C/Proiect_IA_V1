﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Proiect_IA_V1
{
    class Minimax
    {
        private static int MAX_DEPTH = 3;
        public static Board Minimax2L(Board table, int depth, int ai)
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
                        newManager.pieces[cursorX, i] = new Piece(table.playerTurn, table.heights[i], i, table.grid);
                        newManager.newPiece = newManager.pieces[cursorX, i];
                        newManager.heights[i]++;
                        validMove.Add(newManager);
                    }
                }
                Board nextBoard = new Board();
                if (depth == 0)
                {
                    nextBoard.F = -999;
                    foreach (Board move in validMove)
                    {
                        move.NextTurn();
                        var newBoard = Minimax2L(move, depth + 1, ai);
                        if (newBoard.F > nextBoard.F)
                        {
                            nextBoard = move;
                            nextBoard.F = newBoard.F;
                        }
                    }
                }
                else
                {
                    nextBoard.F = 999;
                    foreach (Board move in validMove)
                    {
                        move.NextTurn();
                        var newBoard = Minimax2L(move, depth + 1, ai);
                        if (nextBoard.F < newBoard.F)
                        {
                            nextBoard.F = newBoard.F;
                        }

                    }
                }
                nextBoard.playerTurn = ai;
                return nextBoard;
            }
        }

        public static void EvaluateBoard(Board board, int ai)
        {
            if (ai == 1)
            {
                for (int i = 0; i < board.heights.Length; i++)
                {
                    var cursorX = 6 - board.heights[i];
                    if (board.heights[i] != 0)
                    {
                        if (board.grid[cursorX, i] == 1)
                        {
                            board.F += board.pieces[cursorX, i].power;
                        }
                        else
                        {
                            board.F -= board.pieces[cursorX, i].power;
                        }
                    }
                }
            }
            else if (ai == 2)
            {
                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 7; j++)
                    {
                        var cursorX = 6 - board.heights[i];
                        if (board.heights[i] != 0)
                        {
                            if (board.grid[cursorX, i] == 2)
                            {
                                board.F += board.pieces[cursorX, i].power;
                            }
                            else
                            {
                                board.F -= board.pieces[cursorX, i].power;
                            }
                        }
                    }
                }
            }
        }

    }
}
