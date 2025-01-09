using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect_IA_V1
{
    public partial class Form1 : Form
    {
        private static bool stopGame = false;
        List<Bitmap> images;
        List<Button> buttons = new List<Button>();
        PictureBox[,] pictures = new PictureBox[6, 7];
        List<Color> teamColors = new List<Color>();
        Board board = new Board();
        const int imgSize = 90;
        public Form1()
        {
            InitializeComponent();
            images = new List<Bitmap>();
            images.Add(new Bitmap(Properties.Resources.redPiece90));
            images.Add(new Bitmap(Properties.Resources.yellowPiece90));
            images.Add(new Bitmap(Properties.Resources.bluePiece90));
            buttons.Add(buttonCol0);
            buttons.Add(buttonCol1);
            buttons.Add(buttonCol2);
            buttons.Add(buttonCol3);
            buttons.Add(buttonCol4);
            buttons.Add(buttonCol5);
            buttons.Add(buttonCol6);
            teamColors.Add(Color.Red);
            teamColors.Add(Color.Yellow);
            teamColors.Add(Color.Blue);
        }


        public void ComputeAndDraw()
        {



            board = Minimax.Minimax2L(board, 0, -999, 999, board.playerTurn);
            int i = board.newPiecePos.Item1;
            int j = board.newPiecePos.Item2;

            PictureBox pictureBox1 = new PictureBox();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            Bitmap MyImage = images[board.playerTurn];
            pictureBox1.ClientSize = new Size(imgSize, imgSize);
            pictureBox1.Image = (Image)MyImage;
            pictureBox1.BackColor = Color.Transparent;
            this.Controls.Add(pictureBox1);
            Button senderBtn = buttons[j];
            Point btnPos = buttons[j].Location;
            int posX = btnPos.X + (senderBtn.Width - imgSize) / 2;
            int posY = btnPos.Y + senderBtn.Height - imgSize * (board.heights[j]) - 5;
            pictureBox1.BringToFront();
            pictureBox1.Location = new Point(posX, posY);
            pictures[i, j] = pictureBox1;

            var winningPiecesPositions = board.CheckWin();
            if (winningPiecesPositions != null)
            {
                stopGame = true;
                labelTurn.Text = $" {Board.names[board.playerTurn]} won";
                foreach (Button btn in buttons)
                {
                    btn.Enabled = false;
                }
                foreach ((int, int) pos in winningPiecesPositions)
                {
                    pictures[pos.Item1, pos.Item2].BackColor = teamColors[board.playerTurn];
                }
                return;
            }
            else
            {
                board.NextTurn();
                board.PrintGrid();
                //Console.WriteLine(board.pieces[xJustAdded, yJustAdded]);

                labelTurn.Text = $" {Board.names[board.playerTurn]} Turn ";
            }

            if (CheckDraw() == true)
            {
                labelTurn.Text = "Draw!";
                return;
            }
        }
        private bool CheckDraw()
        {
            for (int i = 0; i < 6; i++)
            {
                if (board.heights[i] != 6) return false;
            }
            return true;
        }
        public void AddPiece(object sender, EventArgs e)
        {
            Button senderBtn = ((Button)sender);

            int columnNr = int.Parse(senderBtn.Name.Last().ToString());
            if (board.heights[columnNr] >= 6) return;
            int xJustAdded = 5 - board.heights[columnNr];
            int yJustAdded = columnNr;

            board.grid[xJustAdded, yJustAdded] = board.playerTurn;
            board.heights[columnNr]++;

            //UI stuff
            PictureBox pictureBox1 = new PictureBox();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            Bitmap MyImage = images[board.playerTurn];
            pictureBox1.ClientSize = new Size(imgSize, imgSize);
            pictureBox1.Image = (Image)MyImage;
            pictureBox1.BackColor = Color.Transparent;
            this.Controls.Add(pictureBox1);
            Point btnPos = senderBtn.Location;
            int posX = btnPos.X + (senderBtn.Width - imgSize) / 2;
            int posY = btnPos.Y + senderBtn.Height - imgSize * (board.heights[columnNr]) - 5;
            pictureBox1.BringToFront();
            pictureBox1.Location = new Point(posX, posY);

            pictures[xJustAdded, yJustAdded] = pictureBox1;

            //end UI stuff
            var winningPiecesPositions = board.CheckWin();
            if (winningPiecesPositions != null)
            {
                stopGame = true;
                labelTurn.Text = $" {Board.names[board.playerTurn]} won";
                foreach (Button btn in buttons)
                {
                    btn.Enabled = false;
                }
                foreach ((int, int) pos in winningPiecesPositions)
                {
                    pictures[pos.Item1, pos.Item2].BackColor = teamColors[board.playerTurn];

                }
                return;
            }


            board.PrintGrid();

            board.NextTurn();

            labelTurn.Text = $" {Board.names[board.playerTurn]} Turn ";

            foreach (Button btn in buttons)
            {
                btn.Enabled = false;
            }


            timer1.Start();


        }

        private void labelTurn_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            ComputeAndDraw();
            if (!stopGame)
            {
                timer2.Start();
            }
            timer1.Stop();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

            ComputeAndDraw();
            timer2.Stop();
            if (!stopGame)
            {
                foreach (Button btn in buttons)
                {
                    btn.Enabled = true;
                }
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void nivel1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dificultateToolStripMenuItem.Text = "AI level: 1";
            Minimax.setDifficulty(1);
        }

        private void level2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dificultateToolStripMenuItem.Text = "AI level: 2";
            Minimax.setDifficulty(2);

        }

        private void levelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dificultateToolStripMenuItem.Text = "AI level: 3";
            Minimax.setDifficulty(3);

        }

        private void level4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dificultateToolStripMenuItem.Text = "AI level: 4";
            Minimax.setDifficulty(4);

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
