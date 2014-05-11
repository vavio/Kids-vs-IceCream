using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kids_vs_IceCream.Forms;

namespace Kids_vs_IceCream
{
    class GameOverWindow : Form
    {
        Graphics g;
        public Timer timer;
        private Label label1;
        private Label label2;
        private RoundButton btnNext;
        private RoundButton btnMain;
        private RoundButton btnExit;
        Bitmap bm;
        public String PlayerName { get; set; }


        public GameOverWindow()
        {
            InitializeComponent();
            g = CreateGraphics();
            bm = new Bitmap(500, 500);
            timer = new Timer();
            timer.Tick += new EventHandler(timer_tick);
            timer.Interval = 100;
            timer.Start();

            PictureBox pb = new PictureBox() { Image = Properties.Resources.cursor };
            this.Cursor = new Cursor(((Bitmap)pb.Image).GetHicon());

            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.DoubleBuffered = true;

            EnterNameWindow enterName = new EnterNameWindow();
            enterName.ShowDialog();
            PlayerName = enterName.Name;
        }

        private void timer_tick(object sender, EventArgs e)
        {
            Graphics g1 = Graphics.FromImage(bm);
            g1.Clear(Color.Violet);
            g1.DrawImage(Properties.Resources.pozadina, 0, 0);
            g.DrawImageUnscaled(bm, 0, 0);
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnMain = new Kids_vs_IceCream.RoundButton();
            this.btnNext = new Kids_vs_IceCream.RoundButton();
            this.btnExit = new Kids_vs_IceCream.RoundButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.label1.Font = new System.Drawing.Font("Tempus Sans ITC", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 196);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "You lost!!";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.label2.Font = new System.Drawing.Font("Tempus Sans ITC", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(118, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "Level Failed";
            // 
            // btnMain
            // 
            this.btnMain.BackColor = System.Drawing.Color.PaleGreen;
            this.btnMain.Location = new System.Drawing.Point(204, 123);
            this.btnMain.Name = "btnMain";
            this.btnMain.Size = new System.Drawing.Size(83, 88);
            this.btnMain.TabIndex = 3;
            this.btnMain.Text = "Main menu";
            this.btnMain.UseVisualStyleBackColor = false;
            this.btnMain.Click += new System.EventHandler(this.btnMain_Click);
            this.btnMain.MouseEnter += new System.EventHandler(this.btnMain_MouseHover);
            this.btnMain.MouseLeave += new System.EventHandler(this.btnMain_MouseLeave);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.MistyRose;
            this.btnNext.Location = new System.Drawing.Point(131, 90);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(82, 80);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = "Try Again";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnAgain_Click);
            this.btnNext.MouseEnter += new System.EventHandler(this.btnAgain_MouseHover);
            this.btnNext.MouseLeave += new System.EventHandler(this.btnAgain_MouseLeave);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnExit.Location = new System.Drawing.Point(146, 162);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(82, 79);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            this.btnExit.MouseEnter += new System.EventHandler(this.btnExit_MouseHover);
            this.btnExit.MouseLeave += new System.EventHandler(this.btnExit_MouseLeave);
            // 
            // GameOverWindow
            // 
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnMain);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "GameOverWindow";
            this.Text = "Game over";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GameOverWindow_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void btnMain_Click(object sender, EventArgs e)
        {
            timer.Stop();
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void GameOverWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Stop();
        }

        private void btnAgain_MouseHover(object sender, EventArgs e)
        {
            btnNext.BackColor = Color.White;
        }

        private void btnAgain_MouseLeave(object sender, EventArgs e)
        {
            btnNext.BackColor = Color.MistyRose;
        }

        private void btnMain_MouseHover(object sender, EventArgs e)
        {
            btnMain.BackColor = Color.White;
        }

        private void btnExit_MouseHover(object sender, EventArgs e)
        {
            btnExit.BackColor = Color.White;
        }

        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
            btnExit.BackColor = Color.LavenderBlush;
        }

        private void btnMain_MouseLeave(object sender, EventArgs e)
        {
            btnMain.BackColor = Color.PaleGreen;
        }

        private void btnAgain_Click(object sender, EventArgs e)
        {
            timer.Stop();
            this.DialogResult = DialogResult.OK;
        }

    }
}
