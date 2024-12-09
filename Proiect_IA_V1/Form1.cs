using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect_IA_V1
{
    public partial class Form1 : Form
    {
        List<Bitmap> images;
        public Form1()
        {
            InitializeComponent();
            Manager.GameManagerInit();
            images = new List<Bitmap>();
            images.Add(new Bitmap(Properties.Resources.redPiece50));
            images.Add(new Bitmap(Properties.Resources.yellowPiece50));
            images.Add(new Bitmap(Properties.Resources.bluePiece50));
        }



        private void AddPiece(object sender, EventArgs e)
        {
            Button senderBtn = ((Button)sender);

            int columnNr = int.Parse(senderBtn.Name.Last().ToString());
            if (Manager.heights[columnNr] >= 6) return;

            Manager.grid[5-Manager.heights[columnNr], columnNr] = Manager.playerTurn;
            Manager.heights[columnNr]++;

            //UI stuff
            PictureBox pictureBox1 = new PictureBox();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            Bitmap MyImage = images[Manager.playerTurn];
            pictureBox1.ClientSize = new Size(50, 50);
            pictureBox1.Image = (Image)MyImage;
            pictureBox1.BackColor = Color.Transparent;
            this.Controls.Add(pictureBox1);
            Point btnPos = senderBtn.Location;
            int posX = btnPos.X + (senderBtn.Width - 50) / 2;
            int posY = btnPos.Y + senderBtn.Height - 50 * (Manager.heights[columnNr]) - 5;
            pictureBox1.Location = new Point(posX, posY);
            pictureBox1.BringToFront();
            //end UI stuff
            
            Manager.NextTurn();
            labelTurn.Text = $" {Manager.names[Manager.playerTurn]} Turn ";

        }
    }
}
