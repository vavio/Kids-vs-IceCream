using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kids_vs_IceCream
{
    class HowToPlayWindow : Form
    {
        Graphics g;
        public Timer timer;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private myButtonObject myButtonObject1;
        Bitmap bm;


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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
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
            this.myButtonObject1 = new Kids_vs_IceCream.myButtonObject();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.label1.Font = new System.Drawing.Font("Tempus Sans ITC", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(141, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 68);
            this.label1.TabIndex = 0;
            this.label1.Text = "The object of the game is to splatter kids with ice cream before get to your truc" +
    "k";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.label2.Font = new System.Drawing.Font("Tempus Sans ITC", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(141, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 38);
            this.label2.TabIndex = 1;
            this.label2.Text = "To shoot ice cream, simply click the mouse";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.label3.Font = new System.Drawing.Font("Tempus Sans ITC", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(27, 191);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 35);
            this.label3.TabIndex = 2;
            this.label3.Text = "Thanks for playing and enjoy!!";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.label4.Font = new System.Drawing.Font("Tempus Sans ITC", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(149, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 22);
            this.label4.TabIndex = 3;
            this.label4.Text = "How to play";
            // 
            // myButtonObject1
            // 
            this.myButtonObject1.BackColor = System.Drawing.Color.LemonChiffon;
            this.myButtonObject1.Location = new System.Drawing.Point(173, 161);
            this.myButtonObject1.Name = "myButtonObject1";
            this.myButtonObject1.Size = new System.Drawing.Size(79, 85);
            this.myButtonObject1.TabIndex = 4;
            this.myButtonObject1.Text = "Main menu";
            this.myButtonObject1.UseVisualStyleBackColor = false;
            this.myButtonObject1.Click += new System.EventHandler(this.myButtonObject1_Click);
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
            this.ResumeLayout(false);

        }

        private void myButtonObject1_Click(object sender, EventArgs e)
        {
            timer.Stop();
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
