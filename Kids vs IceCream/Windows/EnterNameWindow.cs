using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kids_vs_IceCream.Forms
{
    public partial class EnterNameWindow : Form
    {
        public String Name { get; set; }

        public EnterNameWindow()
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.DoubleBuffered = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.Name = textBox1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void EnterNameWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Name = textBox1.Text;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
