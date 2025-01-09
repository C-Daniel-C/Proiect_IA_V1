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
    public class FunctionaltyTests
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
    }
}