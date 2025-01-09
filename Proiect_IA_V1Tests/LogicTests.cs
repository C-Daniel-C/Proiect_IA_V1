using Microsoft.VisualStudio.TestTools.UnitTesting;
using Proiect_IA_V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_IA_V1.Tests
{
    [TestClass()]
    public class LogicTests
    {
        [TestMethod()]
        public void HorizontalWinTest()
        {
            Board testBoard = new Board();
            testBoard.grid[5, 0] = 0;
            testBoard.grid[5, 1] = 0;
            testBoard.grid[5, 2] = 0;
            testBoard.grid[5, 3] = 0;

            List<(int, int)> res = testBoard.CheckWin();

            Assert.IsNotNull(res);

            Assert.AreEqual(res[0].Item1, 5);
            Assert.AreEqual(res[1].Item1, 5);
            Assert.AreEqual(res[2].Item1, 5);
            Assert.AreEqual(res[3].Item1, 5);

            Assert.AreEqual(res[0].Item2, 0);
            Assert.AreEqual(res[1].Item2, 1);
            Assert.AreEqual(res[2].Item2, 2);
            Assert.AreEqual(res[3].Item2, 3);
        }

        [TestMethod()]
        public void VerticalWinTest()
        {
            Board testBoard = new Board();
            testBoard.grid[5, 0] = 0;
            testBoard.grid[4, 0] = 0;
            testBoard.grid[3, 0] = 0;
            testBoard.grid[2, 0] = 0;

            List<(int, int)> res = testBoard.CheckWin();

            Assert.IsNotNull(res);

            Assert.AreEqual(res[0].Item1, 2);
            Assert.AreEqual(res[1].Item1, 3);
            Assert.AreEqual(res[2].Item1, 4);
            Assert.AreEqual(res[3].Item1, 5);

            Assert.AreEqual(res[0].Item2, 0);
            Assert.AreEqual(res[1].Item2, 0);
            Assert.AreEqual(res[2].Item2, 0);
            Assert.AreEqual(res[3].Item2, 0);
        }
        [TestMethod()]
        public void Diagonal1WinTest()
        {
            Board testBoard = new Board();
            testBoard.grid[5, 0] = 0;
            testBoard.grid[4, 1] = 0;
            testBoard.grid[3, 2] = 0;
            testBoard.grid[2, 3] = 0;

            List<(int, int)> res = testBoard.CheckWin();

            Assert.IsNotNull(res);

            Assert.AreEqual(res[0].Item1, 5);
            Assert.AreEqual(res[1].Item1, 4);
            Assert.AreEqual(res[2].Item1, 3);
            Assert.AreEqual(res[3].Item1, 2);

            Assert.AreEqual(res[0].Item2, 0);
            Assert.AreEqual(res[1].Item2, 1);
            Assert.AreEqual(res[2].Item2, 2);
            Assert.AreEqual(res[3].Item2, 3);
        }
        [TestMethod()]
        public void Diagonal2WinTest()
        {
            Board testBoard = new Board();
            testBoard.grid[2, 0] = 0;
            testBoard.grid[3, 1] = 0;
            testBoard.grid[4, 2] = 0;
            testBoard.grid[5, 3] = 0;

            List<(int, int)> res = testBoard.CheckWin();

            Assert.IsNotNull(res);

            Assert.AreEqual(res[0].Item1, 2);
            Assert.AreEqual(res[1].Item1, 3);
            Assert.AreEqual(res[2].Item1, 4);
            Assert.AreEqual(res[3].Item1, 5);

            Assert.AreEqual(res[0].Item2, 0);
            Assert.AreEqual(res[1].Item2, 1);
            Assert.AreEqual(res[2].Item2, 2);
            Assert.AreEqual(res[3].Item2, 3);
        }

        [TestMethod()]
        public void CheckDrawTest()
        {
            Form1 form = new Form1();


            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    int xJustAdded = 5 - form.board.heights[j];
                    int yJustAdded = j;
                    form.board.grid[xJustAdded, yJustAdded] = form.board.playerTurn;
                    form.board.heights[j]++;
                }
            }
            Assert.IsTrue(form.board.CheckDraw());
        }

      

        [TestMethod()]
        public void SmartMoveTest()
        {
            Form1 form = new Form1();
            Board testBoard = new Board();
            testBoard.grid[5, 2] = 0;
            testBoard.grid[5, 3] = 0;
            testBoard.grid[5, 4] = 0;
            testBoard.grid[5, 5] = 2;

            testBoard.grid[4, 3] = 1;
            testBoard.grid[4, 4] = 1;

            testBoard.grid[3, 3] = 2;
            testBoard.grid[3, 4] = 2;

            testBoard.heights[2] = 1;
            testBoard.heights[3] = 3;
            testBoard.heights[4] = 3;
            testBoard.heights[5] = 1;

            Board board = Minimax.Minimax2L(testBoard, 0, -999, 999, 1);
            Console.WriteLine(board);
            Assert.AreEqual(board.grid[5, 1], 1);

        }
    }
}