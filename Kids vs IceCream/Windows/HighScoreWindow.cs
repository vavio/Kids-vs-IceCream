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
    public partial class HighScoreWindow : Form
    {
        public HighScoreWindow(PlayersDoc players)
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.DoubleBuffered = true;
            players.Players.Sort();
            foreach (Player iter in players.Players)
            {
                lbPlayers.Items.Add(iter);   
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
