using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Kids_vs_IceCream.Forms;
using Kids_vs_IceCream.Objects;

namespace Kids_vs_IceCream
{
    public partial class Form1 : Form
    {
        private Timer timerDrawing;
        private Timer timerNewCloud;
        public Timer timerNewHouse;

        private List<Kid> CurrentLevel;

        private KidsDoc Kids;
        private BulletsDoc Bullets;
        private HousesDoc Houses;
        private CloudsDoc Clouds;
        private LevelsDoc Levels;
        public CarDoc CarItems;
        private PlayersDoc Players;

        private Point cursorPosition;

        private Graphics graphics;
        private Bitmap doubleBuffer;
        private Random rand = new Random((int)DateTime.Now.Ticks);
        private static readonly int FRAMES_PER_SECOND = 30;
        private Bitmap imageWheel = Properties.Resources.trkalceSeDvizi1;
        private Sounds Music;
        private int KidsKilled;

        private bool gameStarted;

        public Form1()
        {
            InitializeComponent();
            StartWindow();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.DoubleBuffered = true;
            this.gameStarted = false;

            Bullets = new BulletsDoc();
            Houses = new HousesDoc(this.Width);
            Kids = new KidsDoc();
            Clouds = new CloudsDoc(this.Width, this.Height);
            Music = new Sounds();
            Levels = new LevelsDoc();
            CurrentLevel = new List<Kid>();
            CarItems = new CarDoc();
            Players = new PlayersDoc();
            KidsKilled = 0;
        }

        private void StartWindow()
        {
            doubleBuffer = new Bitmap(Width, Height);
            if (graphics == null)
            {
                graphics = CreateGraphics();
            }
            //Show();
            timerDrawing = new Timer();
            timerDrawing.Tick += new EventHandler(timer_Tick);
            timerDrawing.Interval = 1000 / FRAMES_PER_SECOND;
            timerDrawing.Start();

            timerNewCloud = new Timer();
            timerNewCloud.Tick += new EventHandler(timerforNewCloud_Tick);
            timerNewCloud.Interval = rand.Next(7000, 10000);
            timerNewCloud.Start();

            timerNewHouse = new Timer();
            timerNewHouse.Tick += new EventHandler(timerForNewHouse_tick);
            timerNewHouse.Interval = rand.Next(50, 100);
        }

        private void timerForNewHouse_tick(object sender, EventArgs e)
        {
            if (gameStarted)
            {
                timerNewHouse.Interval = rand.Next(1400, 2000);
                Houses.addHouse(new House(ClientRectangle.Width, 0, 5));
            }
        }

        private void timerforNewCloud_Tick(object sender, EventArgs e)
        {
            timerNewCloud.Interval = rand.Next(7000, 10000);
            Clouds.AddCloud(new Cloud(this.ClientRectangle.Width, rand.Next(0, this.ClientRectangle.Height - 300), 1f));
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromImage(doubleBuffer);
            g.Clear(Color.Aqua);
            g.DrawImage(Properties.Resources.pozadina, 0, 0);
            updateStatusLabel();

            moveEverything(g);
            if (gameStarted)
            {
                levelFinished();
                timerNewHouse.Start();
                timerNewCloud.Start();
                graphics.DrawImageUnscaled(doubleBuffer, 0, 0);
                if (Kids.isOver(CarItems))
                {
                    //gameOver
                    gameOver();
                }
            }
            else
            {
                graphics.DrawImageUnscaled(doubleBuffer, 0, 0);
            }
        }

        private void gameOver()
        {
            timerNewHouse.Stop();
            timerDrawing.Stop();
            GameOverWindow gameOver = new GameOverWindow();
            writeToFile(gameOver.PlayerName, this.KidsKilled);
            this.KidsKilled = 0;
            if (gameOver.ShowDialog() == DialogResult.OK)
            {
                Kids = new KidsDoc();
                Bullets = new BulletsDoc();
                Levels = new LevelsDoc();
                Houses = new HousesDoc(this.Width);
                CurrentLevel = Levels.getNextLevel();
                gameStarted = true;
                Houses.startMoving();
                StartWindow();
            }
            else
            {
                gameOver = null;
                showMainMenu();
            }
        }

        private void writeToFile(String playerName, int score)
        {
            Players.AddPlayer(new Player(playerName, score));
        }

        private void showMainMenu()
        {
            timerNewHouse.Stop();
            Kids = new KidsDoc();
            Houses = new HousesDoc(this.Width);
            Levels = new LevelsDoc();
            Clouds = new CloudsDoc(this.Width, this.Height);
            Bullets = new BulletsDoc();
            showButtons();
            CarItems.MoveToStart();
            gameStarted = false;
            StartWindow();
        }

        private void updateStatusLabel()
        {
            levelLabel.Text = String.Format("Level: {0}", Levels.CurrentLevel);
            statusLabel.Text = String.Format("Remaining Kids: {0}", CurrentLevel.Count);
            kidsKilledLabel.Text = String.Format("Killed Kids: {0}", KidsKilled);
        }

        private void levelFinished()
        {
            if (Kids.Kids.Count == 0 && CurrentLevel.Count == 0)
            {
                //nextlevel
                timerNewHouse.Stop();
                timerNewCloud.Stop();
                timerDrawing.Stop();
                NextLevelWindow nextLevel = new NextLevelWindow();
                if (nextLevel.ShowDialog() == DialogResult.OK)
                {
                    Kids = new KidsDoc();
                    Bullets = new BulletsDoc();
                    Houses = new HousesDoc(this.Width);
                    CurrentLevel = Levels.getNextLevel();
                    gameStarted = true;
                    Houses.startMoving();
                    StartWindow();
                }
                else
                {
                    nextLevel = null;
                    gameOver();
                }
            }
        }

        private void showButtons()
        {
            btnHowToPlay.Show();
            btnNewGame.Show();
            btnHighScore.Show();
        }

        private void moveEverything(Graphics g)
        {
            //Moving Clouds
            Clouds.DrawClouds(g);
            Clouds.MoveClouds();

            //Moving Houses
            Houses.DrawHouses(g);
            Houses.MoveHouses();
            Houses.removeOverlap();

            //Moving Bullets
            Bullets.DrawBullets(g);
            Bullets.MoveBullets(this.Width, this.Height);

            //Moving Car
            CarItems.Draw(g);
            CarItems.Move();

            this.KidsKilled += Kids.Hit(Bullets);

            Kids.DrawKids(g);
            Kids.MoveKids(this.Width, this.Height);
        }

        private void btnHowToPlay_Click(object sender, EventArgs e)
        {
            HowToPlayWindow howToPlay = new HowToPlayWindow();
            if (howToPlay.ShowDialog() == DialogResult.Cancel)
            {
                howToPlay.timer.Stop();
            }
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            GameWindow prozor = new GameWindow(this);
            //nextKid
            timerNextKid.Interval = 1000;
            timerNextKid.Enabled = true;
            gameStarted = true;
            CurrentLevel = Levels.getNextLevel();
            Houses.startMoving();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //cursor
            PictureBox pb = new PictureBox() { Image = Properties.Resources.cursor };
            this.Cursor = new Cursor(((Bitmap)pb.Image).GetHicon());

            timerMouseDown.Interval = Car.SpeedOfWeapon;
            Music.playMusic();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (gameStarted)
            {
                Bullets.AddBullet(new Bullet(580, 350, 5, 5, cursorPosition));
                timerMouseDown.Enabled = true;
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            timerMouseDown.Enabled = false;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            cursorPosition = new Point(e.X, e.Y);
            CarItems.rotateWeapon(cursorPosition);
        }

        private void timerNextKid_Tick(object sender, EventArgs e)
        {
            if (gameStarted && CurrentLevel.Count != 0)
            {
                Kids.AddKid(CurrentLevel[0]);
                CurrentLevel.RemoveAt(0);
            }
        }

        private void timerMouseDown_Tick(object sender, EventArgs e)
        {
            if (gameStarted)
            {
                Bullets.AddBullet(new Bullet(580, 350, 5, 5, cursorPosition));
            }
        }

        private void btnNewGame_MouseHover(object sender, EventArgs e)
        {
            btnNewGame.BackColor = Color.White;
        }

        private void btnNewGame_MouseLeave(object sender, EventArgs e)
        {
            btnNewGame.BackColor = Color.Aquamarine;
        }

        private void btnUpgrade_MouseHover(object sender, EventArgs e)
        {
            btnHighScore.BackColor = Color.White;
        }

        private void btnUpgrade_MouseLeave(object sender, EventArgs e)
        {
            btnHighScore.BackColor = Color.BlanchedAlmond;
        }

        private void btnHowToPlay_MouseLeave(object sender, EventArgs e)
        {
            btnHowToPlay.BackColor = Color.Wheat;
        }

        private void btnHowToPlay_MouseHover(object sender, EventArgs e)
        {
            btnHowToPlay.BackColor = Color.White;
        }

        private void btnHighScore_Click(object sender, EventArgs e)
        {
            HighScoreWindow highScore = new HighScoreWindow(Players);
            highScore.ShowDialog();
        }
    }
}
