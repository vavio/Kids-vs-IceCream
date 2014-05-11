using System;
using System.Windows.Forms;

namespace Kids_vs_IceCream
{
    public class GameWindow : Form
    {
        private Form1 startingBackground;
        
        private Random rnd = new Random((int)DateTime.Now.Ticks);

        public GameWindow(Form form)
        {
            startingBackground = (Form1)form;
            hideButtons();
            MoveCar();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.DoubleBuffered = true;
        }

        void timerMouseDown_Tick(object sender, EventArgs e)
        {
            MessageBox.Show("Test");
        }

        private void hideButtons()
        {
            startingBackground.btnHowToPlay.Hide();
            startingBackground.btnNewGame.Hide();
            startingBackground.btnHighScore.Hide();
        }

        private void startMovingHouses()
        {
        }

        private void MoveCar()
        {
            startingBackground.CarItems.MoveToEnd();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // GameWindow
            // 
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Name = "GameWindow";
            this.ResumeLayout(false);
        }

    }
}