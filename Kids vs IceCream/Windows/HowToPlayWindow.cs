using System;
using System.Drawing;
using System.Windows.Forms;

namespace Kids_vs_IceCream
{
    internal class HowToPlayWindow : Form
    {
        private Graphics g;
        public Timer timer;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private RoundButton myButtonObject1;
        private Bitmap bm;

        public HowToPlayWindow()
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.myButtonObject1 = new Kids_vs_IceCream.RoundButton();
            this.SuspendLayout();
            //
            // label1
            //
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.label1.Font = new System.Drawing.Font("Tempus Sans ITC", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(105, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 98);
            this.label1.TabIndex = 0;
            this.label1.Text = "The object of the game is to splatter kids with ice cream before get to your truc" +
    "k.";
            //
            // label2
            //
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.label2.Font = new System.Drawing.Font("Tempus Sans ITC", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(105, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 65);
            this.label2.TabIndex = 1;
            this.label2.Text = "To shoot ice cream, simply click the mouse";
            //
            // label3
            //
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.label3.Font = new System.Drawing.Font("Tempus Sans ITC", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(12, 211);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 54);
            this.label3.TabIndex = 2;
            this.label3.Text = "Thanks for playing and enjoy!!";
            //
            // label4
            //
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.label4.Font = new System.Drawing.Font("Tempus Sans ITC", 15.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic)
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(109, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 32);
            this.label4.TabIndex = 3;
            this.label4.Text = "How to play";
            //
            // myButtonObject1
            //
            this.myButtonObject1.BackColor = System.Drawing.Color.LemonChiffon;
            this.myButtonObject1.Location = new System.Drawing.Point(194, 180);
            this.myButtonObject1.Name = "myButtonObject1";
            this.myButtonObject1.Size = new System.Drawing.Size(79, 85);
            this.myButtonObject1.TabIndex = 4;
            this.myButtonObject1.Text = "Main menu";
            this.myButtonObject1.UseVisualStyleBackColor = false;
            this.myButtonObject1.Click += new System.EventHandler(this.myButtonObject1_Click);
            this.myButtonObject1.MouseEnter += new System.EventHandler(this.myButtonObject1_MouseHover);
            this.myButtonObject1.MouseLeave += new System.EventHandler(this.myButtonObject1_MouseLeave);
            //
            // HowToPlayWindow
            //
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.myButtonObject1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "HowToPlayWindow";
            this.Text = "How to play";
            this.ResumeLayout(false);
        }

        private void myButtonObject1_Click(object sender, EventArgs e)
        {
            timer.Stop();
            this.DialogResult = DialogResult.Cancel;
        }

        private void myButtonObject1_MouseHover(object sender, EventArgs e)
        {
            myButtonObject1.BackColor = Color.White;
        }

        private void myButtonObject1_MouseLeave(object sender, EventArgs e)
        {
            myButtonObject1.BackColor = Color.LemonChiffon;
        }
    }
}