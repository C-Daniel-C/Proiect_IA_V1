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
        Board board = new Board();
        public Form1()
        {
            InitializeComponent();
            images = new List<Bitmap>();
            images.Add(new Bitmap(Properties.Resources.redPiece50));
            images.Add(new Bitmap(Properties.Resources.yellowPiece50));
            images.Add(new Bitmap(Properties.Resources.bluePiece50));
            buttons.Add(buttonCol0);
            buttons.Add(buttonCol1);
            buttons.Add(buttonCol2);
            buttons.Add(buttonCol3);
            buttons.Add(buttonCol4);
            buttons.Add(buttonCol5);
            buttons.Add(buttonCol6);
        }


        public void ComputeAndRedraw()
        {



            board = Minimax.Minimax2L(board, 0, board.playerTurn);
            int i = board.newPiece.x;
            int j = board.newPiece.y;

            PictureBox pictureBox1 = new PictureBox();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            Bitmap MyImage = images[board.newPiece.team];
            pictureBox1.ClientSize = new Size(50, 50);
            pictureBox1.Image = (Image)MyImage;
            pictureBox1.BackColor = Color.Transparent;
            this.Controls.Add(pictureBox1);
            Button senderBtn = buttons[j];
            Point btnPos = buttons[j].Location;
            int posX = btnPos.X + (senderBtn.Width - 50) / 2;
            int posY = btnPos.Y + senderBtn.Height - 50 * (board.heights[j]) - 5;
            pictureBox1.Location = new Point(posX, posY);
            pictureBox1.BringToFront();

            if (checkWin(board, board.playerTurn))
            {
                stopGame = true;
                labelTurn.Text = $" {Board.names[board.playerTurn]} won";
                foreach (Button btn in buttons)
                {
                    btn.Enabled = false;
                }
            }
            else
            {
                board.NextTurn();
                board.PrintGrid();
                //Console.WriteLine(board.pieces[xJustAdded, yJustAdded]);

                labelTurn.Text = $" {Board.names[board.playerTurn]} Turn ";
            }
        }
        private void AddPiece(object sender, EventArgs e)
        {
            Button senderBtn = ((Button)sender);

            int columnNr = int.Parse(senderBtn.Name.Last().ToString());
            if (board.heights[columnNr] >= 6) return;
            int xJustAdded = 5 - board.heights[columnNr];
            int yJustAdded = columnNr;
            if (board.playerTurn == 0)
            {
                board.grid[xJustAdded, yJustAdded] = board.playerTurn;
                board.heights[columnNr]++;
                board.pieces[xJustAdded, yJustAdded] = new Piece(board.playerTurn, xJustAdded, yJustAdded, board.grid);
            }
            else
            {
                board = Minimax.Minimax2L(board, 0, board.playerTurn);

            }
            //UI stuff
            PictureBox pictureBox1 = new PictureBox();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            Bitmap MyImage = images[board.playerTurn];
            pictureBox1.ClientSize = new Size(50, 50);
            pictureBox1.Image = (Image)MyImage;
            pictureBox1.BackColor = Color.Transparent;
            this.Controls.Add(pictureBox1);
            Point btnPos = senderBtn.Location;
            int posX = btnPos.X + (senderBtn.Width - 50) / 2;
            int posY = btnPos.Y + senderBtn.Height - 50 * (board.heights[columnNr]) - 5;
            pictureBox1.Location = new Point(posX, posY);
            pictureBox1.BringToFront();
            //end UI stuff

            board.NextTurn();
            board.PrintGrid();
            Console.WriteLine(board.pieces[xJustAdded, yJustAdded]);

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
            
            ComputeAndRedraw();
            if (!stopGame)
            {
                timer2.Start();
            }
            timer1.Stop();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

            ComputeAndRedraw();
            timer2.Stop();
            if (!stopGame)
            {
                foreach (Button btn in buttons)
                {
                    btn.Enabled = true;
                }
            }
        }
        private bool checkWin(Board board,int playerTurn)
        {
            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 6; i++)
                {
                    if (board.grid[i, j] == playerTurn && board.grid[i, j + 1] == playerTurn && board.grid[i, j + 2] == playerTurn && board.grid[i, j + 3] == playerTurn)
                    {
                        return true;
                    }
                }
            }
            for (int j = 0; j < 7; j++)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (board.grid[i, j] == playerTurn && board.grid[i+1, j] == playerTurn && board.grid[i+2, j] == playerTurn && board.grid[i+3, j] == playerTurn)
                    {
                        return true;
                    }
                }
            }
            for(int j =0;j<4;j++)
            {
                for(int i=0;i<3;i++)
                {
                    if (board.grid[i, j] == playerTurn && board.grid[i + 1, j+1] == playerTurn && board.grid[i + 2, j+2] == playerTurn && board.grid[i + 3, j+3] == playerTurn)
                    {
                        return true;
                    }
                }
            }
            for (int j = 0; j < 4; j++)
            {
                for (int i = 3; i < 6; i++)
                {
                    if (board.grid[i, j] == playerTurn && board.grid[i - 1, j + 1] == playerTurn && board.grid[i - 2, j + 2] == playerTurn && board.grid[i - 3, j + 3] == playerTurn)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
