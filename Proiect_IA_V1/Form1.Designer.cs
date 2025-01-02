
namespace Proiect_IA_V1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonCol0 = new System.Windows.Forms.Button();
            this.buttonCol1 = new System.Windows.Forms.Button();
            this.buttonCol2 = new System.Windows.Forms.Button();
            this.buttonCol3 = new System.Windows.Forms.Button();
            this.buttonCol4 = new System.Windows.Forms.Button();
            this.buttonCol5 = new System.Windows.Forms.Button();
            this.buttonCol6 = new System.Windows.Forms.Button();
            this.labelTurn = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // buttonCol0
            // 
            this.buttonCol0.BackColor = System.Drawing.Color.Transparent;
            this.buttonCol0.Location = new System.Drawing.Point(149, 122);
            this.buttonCol0.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonCol0.Name = "buttonCol0";
            this.buttonCol0.Size = new System.Drawing.Size(128, 570);
            this.buttonCol0.TabIndex = 0;
            this.buttonCol0.TabStop = false;
            this.buttonCol0.UseVisualStyleBackColor = false;
            this.buttonCol0.Click += new System.EventHandler(this.AddPiece);
            // 
            // buttonCol1
            // 
            this.buttonCol1.BackColor = System.Drawing.Color.Transparent;
            this.buttonCol1.Location = new System.Drawing.Point(282, 122);
            this.buttonCol1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonCol1.Name = "buttonCol1";
            this.buttonCol1.Size = new System.Drawing.Size(128, 570);
            this.buttonCol1.TabIndex = 1;
            this.buttonCol1.TabStop = false;
            this.buttonCol1.UseVisualStyleBackColor = false;
            this.buttonCol1.Click += new System.EventHandler(this.AddPiece);
            // 
            // buttonCol2
            // 
            this.buttonCol2.BackColor = System.Drawing.Color.Transparent;
            this.buttonCol2.Location = new System.Drawing.Point(416, 122);
            this.buttonCol2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonCol2.Name = "buttonCol2";
            this.buttonCol2.Size = new System.Drawing.Size(128, 570);
            this.buttonCol2.TabIndex = 2;
            this.buttonCol2.TabStop = false;
            this.buttonCol2.UseVisualStyleBackColor = false;
            this.buttonCol2.Click += new System.EventHandler(this.AddPiece);
            // 
            // buttonCol3
            // 
            this.buttonCol3.BackColor = System.Drawing.Color.Transparent;
            this.buttonCol3.Location = new System.Drawing.Point(552, 122);
            this.buttonCol3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonCol3.Name = "buttonCol3";
            this.buttonCol3.Size = new System.Drawing.Size(128, 570);
            this.buttonCol3.TabIndex = 3;
            this.buttonCol3.TabStop = false;
            this.buttonCol3.UseVisualStyleBackColor = false;
            this.buttonCol3.Click += new System.EventHandler(this.AddPiece);
            // 
            // buttonCol4
            // 
            this.buttonCol4.BackColor = System.Drawing.Color.Transparent;
            this.buttonCol4.Location = new System.Drawing.Point(686, 122);
            this.buttonCol4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonCol4.Name = "buttonCol4";
            this.buttonCol4.Size = new System.Drawing.Size(128, 570);
            this.buttonCol4.TabIndex = 4;
            this.buttonCol4.TabStop = false;
            this.buttonCol4.UseVisualStyleBackColor = false;
            this.buttonCol4.Click += new System.EventHandler(this.AddPiece);
            // 
            // buttonCol5
            // 
            this.buttonCol5.BackColor = System.Drawing.Color.Transparent;
            this.buttonCol5.Location = new System.Drawing.Point(820, 122);
            this.buttonCol5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonCol5.Name = "buttonCol5";
            this.buttonCol5.Size = new System.Drawing.Size(128, 570);
            this.buttonCol5.TabIndex = 5;
            this.buttonCol5.TabStop = false;
            this.buttonCol5.UseVisualStyleBackColor = false;
            this.buttonCol5.Click += new System.EventHandler(this.AddPiece);
            // 
            // buttonCol6
            // 
            this.buttonCol6.BackColor = System.Drawing.Color.Transparent;
            this.buttonCol6.Location = new System.Drawing.Point(953, 122);
            this.buttonCol6.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonCol6.Name = "buttonCol6";
            this.buttonCol6.Size = new System.Drawing.Size(128, 570);
            this.buttonCol6.TabIndex = 6;
            this.buttonCol6.TabStop = false;
            this.buttonCol6.UseVisualStyleBackColor = false;
            this.buttonCol6.Click += new System.EventHandler(this.AddPiece);
            // 
            // labelTurn
            // 
            this.labelTurn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.14286F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTurn.Location = new System.Drawing.Point(502, 42);
            this.labelTurn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTurn.Name = "labelTurn";
            this.labelTurn.Size = new System.Drawing.Size(222, 57);
            this.labelTurn.TabIndex = 7;
            this.labelTurn.Text = "Player Turn";
            this.labelTurn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelTurn.Click += new System.EventHandler(this.labelTurn_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 400;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 600;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1225, 729);
            this.Controls.Add(this.labelTurn);
            this.Controls.Add(this.buttonCol6);
            this.Controls.Add(this.buttonCol5);
            this.Controls.Add(this.buttonCol0);
            this.Controls.Add(this.buttonCol4);
            this.Controls.Add(this.buttonCol1);
            this.Controls.Add(this.buttonCol3);
            this.Controls.Add(this.buttonCol2);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Connect 43";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCol0;
        private System.Windows.Forms.Button buttonCol6;
        private System.Windows.Forms.Button buttonCol5;
        private System.Windows.Forms.Button buttonCol4;
        private System.Windows.Forms.Button buttonCol3;
        private System.Windows.Forms.Button buttonCol2;
        private System.Windows.Forms.Button buttonCol1;
        private System.Windows.Forms.Label labelTurn;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
    }
}

