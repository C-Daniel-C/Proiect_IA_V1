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
    public class FunctionalityTests
    {
        [TestMethod()]
        public void SetDifficultyTest1()
        {
            Minimax.setDifficulty(1);

            Assert.AreEqual(Minimax.DIFFICULTY, Minimax.EASY);
        }

        [TestMethod()]
        public void SetDifficultyTest2()
        {
            Minimax.setDifficulty(2);

            Assert.AreEqual(Minimax.DIFFICULTY, Minimax.MEDIUM);
        }

        [TestMethod()]
        public void AddPieceTest()
        {
            Form1 form = new Form1();
            int columnNr = 0;
            if (form.board.heights[columnNr] >= 6) return;
            int xJustAdded = 5 - form.board.heights[columnNr];
            int yJustAdded = columnNr;

            form.board.grid[xJustAdded, yJustAdded] = form.board.playerTurn;
            form.board.heights[columnNr]++;

            Assert.AreEqual(form.board.grid[5, 0], 0);
           
            
        }
    }
}