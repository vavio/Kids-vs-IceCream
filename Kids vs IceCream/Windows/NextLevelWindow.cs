using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kids_vs_IceCream
{
    public partial class NextLevelWindow : Form
    {

        Graphics g;
        public Timer timer;
        Bitmap bm;

        public NextLevelWindow()
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
            btnNext.BackColor = Color.LemonChiffon;
        }

        private void timer_tick(object sender, EventArgs e)
        {
            Graphics g1 = Graphics.FromImage(bm);
            g1.Clear(Color.Violet);
            g1.DrawImage(Properties.Resources.pozadina, 0, 0);
            g.DrawImageUnscaled(bm, 0, 0);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void NextLevelWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Stop();
        }

        private void btnNext_MouseEnter(object sender, EventArgs e)
        {
            btnNext.BackColor = Color.White;
        }

        private void btnNext_MouseLeave(object sender, EventArgs e)
        {
            btnNext.BackColor = Color.LemonChiffon;
        }
    }
}
