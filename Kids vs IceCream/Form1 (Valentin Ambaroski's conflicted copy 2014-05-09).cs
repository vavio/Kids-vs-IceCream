using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Kids_vs_IceCream
{
    public partial class Form1 : Form
    {
        private Timer timerForDrawing;
        private Timer timerForNewCloud;
        public Timer timerForNewHouse;

        public List<MovingStuff> movingStuff { get; set; }

        public List<MovingStuff> car;

        public KidsDoc Kids;
        public BulletsDoc Bullets;

        private Point cursorPosition;

        private Graphics graphics;
        private Bitmap doubleBuffer;
        private Random rand = new Random((int)DateTime.Now.Ticks);
        private static readonly int FRAMES_PER_SECOND = 30;
        private Bitmap imageWheel = Properties.Resources.trkalceSeDvizi1;

        private bool gameStarted;

        public Form1()
        {
            InitializeComponent();
            StartWindow();
            this.DoubleBuffered = true;
            this.gameStarted = false;
            //this.ControlBox = false;

            Bullets = new BulletsDoc();
            Kids = new KidsDoc();
        }

        private void timerMouseDown_Tick(object sender, EventArgs e)
        {
            Bullets.AddBullet(new Bullet(580, 350, 5, 5, cursorPosition));
        }

        public void StartWindow()
        {
            doubleBuffer = new Bitmap(Width, Height);
            if(graphics==null)
            {
            graphics = CreateGraphics();
            }
            //Show();
            timerForDrawing = new Timer();
            timerForDrawing.Tick += new EventHandler(timer_Tick);
            timerForDrawing.Interval = 1000/FRAMES_PER_SECOND;
            timerForDrawing.Start();

            timerForNewCloud = new Timer();
            timerForNewCloud.Tick += new EventHandler(timerforNewCloud_Tick);
            timerForNewCloud.Interval = rand.Next(7000, 10000);
            timerForNewCloud.Start();

            timerForNewHouse = new Timer();
            timerForNewHouse.Tick += new EventHandler(timerForNewHouse_tick);
            timerForNewHouse.Interval = rand.Next(0, 100);
        }
        private void timerForNewHouse_tick(object sender, EventArgs e)
        {
            timerForNewHouse.Interval = rand.Next(1400, 2000);
            movingStuff.Add(new House(ClientRectangle.Width, 0, 5));

        }

        public void drawStartingHousesClouds()
        {
            movingStuff = new List<MovingStuff>();
            car = new List<MovingStuff>();

            movingStuff.Add(new Cloud(this.ClientRectangle.Width - 100, rand.Next(0, this.ClientRectangle.Height - 300), 0.5f));
            movingStuff.Add(new Cloud(this.ClientRectangle.Width - 500, rand.Next(0, this.ClientRectangle.Height - 300), 0.5f));
            movingStuff.Add(new Cloud(this.ClientRectangle.Width - 700, rand.Next(0, this.ClientRectangle.Height - 300), 0.5f));
            movingStuff.Add(new Cloud(this.ClientRectangle.Width - 400, rand.Next(0, this.ClientRectangle.Height - 300), 0.5f));
            movingStuff.Add(new House(this.ClientRectangle.Width - 700, 0, 0f));
            movingStuff.Add(new House(this.ClientRectangle.Width - 500, 0, 0f));
            movingStuff.Add(new House(this.ClientRectangle.Width - 300, 0, 0f));
            movingStuff.Add(new House(this.ClientRectangle.Width - 150, 0, 0f));

            car.Add(new Wheels(340, 250, 0, false));
            car.Add(new Wheels(420, 250, 0, false));
            car.Add(new Car(340, 250, 0));
            car.Add(new Weapon(390, 300, 0, Properties.Resources.weapon_1));
        }

        private void timerforNewCloud_Tick(object sender, EventArgs e)
        {
            timerForNewCloud.Interval = rand.Next(7000, 10000);
            movingStuff.Insert(0,new Cloud(this.ClientRectangle.Width, rand.Next(0, this.ClientRectangle.Height - 300), 0.5f));
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromImage(doubleBuffer);
            g.Clear(Color.Aqua);
            g.DrawImage(Properties.Resources.pozadina, 0, 0);
            if(gameStarted)
            {
                moveEverything(g);
                timerForNewHouse.Start();
                graphics.DrawImageUnscaled(doubleBuffer, 0, 0);
                if (Kids.isOver((Car)car[2]))
                {
                    
                    timerForNewHouse.Stop();
                    timerForNewCloud.Stop();
                    timerForDrawing.Stop();
                    GameOverWindow gameOver = new GameOverWindow();
                    if(gameOver.ShowDialog()==DialogResult.OK)
                    {
                        
                        Kids = new KidsDoc();
                        gameStarted = true;
                        StartWindow();
                    }
                    else
                    {
                        //main menu
                            timerForNewHouse.Stop();
                            Kids = new KidsDoc();
                            showButtons();
                            moveCarToStart();
                            manageHouses();
                            gameStarted = false;
                            StartWindow();
                    }
                    
                }
                
            }
            else
            {

                moveClouds(g); 
                graphics.DrawImageUnscaled(doubleBuffer, 0, 0);
            }

          

        }
        private void manageHouses()
        {

            for(int i = movingStuff.Count-1;i>=0;i--)
            {
                if(movingStuff[i] is House)
                {
                    movingStuff.RemoveAt(i);
                }
            }
            movingStuff.Add(new House(this.ClientRectangle.Width - 700, 0, 0f));
            movingStuff.Add(new House(this.ClientRectangle.Width - 500, 0, 0f));
            movingStuff.Add(new House(this.ClientRectangle.Width - 300, 0, 0f));
            movingStuff.Add(new House(this.ClientRectangle.Width - 150, 0, 0f));
        }
        private void moveCarToStart()
        {
            ((Wheels)car[0]).seDvizi = false;
            car[0].image = Properties.Resources.trkalceNeSeDvizi;
            car[1].image = Properties.Resources.trkalceNeSeDvizi;
            ((Wheels)car[1]).seDvizi = false;
            car[0].X = 340;
            car[0].Y = 250;
            car[1].X = 420;
            car[1].Y = 250;
            car[2].X = 340;
            car[2].Y = 250;
            car[3].X = 390;
            car[3].Y = 300;
        }
        private void showButtons()
        {
            btnHowToPlay.Show();
            btnNewGame.Show();
            btnUpgrade.Show();
        }
        private void moveClouds(Graphics g)
        {
            for (int i = 0; i < movingStuff.Count; i++)
            {
                if (movingStuff[i].X + 200 <= this.ClientRectangle.Left)
                {
                    movingStuff.Remove(movingStuff[i]);
                }
                movingStuff[i].Draw(g);
                if(movingStuff[i] is Cloud)
                {
                movingStuff[i].Move();
                }
            }
            foreach (MovingStuff carPart in car)
            {
                carPart.Draw(g);
                
            }
        }
        private void moveEverything(Graphics g)
        {
            for (int i = 0; i < movingStuff.Count; i++)
            {
                if (movingStuff[i].X + 200 <= this.ClientRectangle.Left)
                {
                    movingStuff.Remove(movingStuff[i]);
                }
                movingStuff[i].Draw(g);
                movingStuff[i].Move();
            }
            foreach (MovingStuff carPart in car)
            {
                carPart.Draw(g);
                carPart.Move();
            }
            Bullets.DrawBullets(g);
            Bullets.MoveBullets(this.Width, this.Height);
            Kids.Hit(Bullets);

            Kids.DrawKids(g);
            Kids.MoveKids(this.Width, this.Height, (Car)car[2]);
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
        }

        private void btnUpgrade_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Clicked2");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.drawStartingHousesClouds();

            //cursor
            PictureBox pb = new PictureBox() { Image = Properties.Resources.cursor };
            this.Cursor = new Cursor(((Bitmap)pb.Image).GetHicon());

            timerMouseDown.Interval = ((Car)car[2]).SpeedOfWeapon;
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

        private Bitmap rotateImage(Bitmap b, float angle)
        {
            //create a new empty bitmap to hold rotated image
            Bitmap returnBitmap = new Bitmap(b.Width, b.Height);
            //make a graphics object from the empty bitmap
            Graphics g = Graphics.FromImage(returnBitmap);
            //move rotation point to center of image
            g.TranslateTransform((float)b.Width / 2, (float)b.Height / 2);
            //rotate
            g.RotateTransform(angle);
            //move image back
            g.TranslateTransform(-(float)b.Width / 2, -(float)b.Height / 2);
            //draw passed in image onto graphics object
            g.DrawImage(b, new Point(0, 0));
            return returnBitmap;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            cursorPosition = new Point(e.X, e.Y);

            //rotate weapon
            int n=car.Count;
            float oldX = car[n - 1].X;
            float oldY = car[n - 1].Y;
            float oldV = car[n - 1].velocity;

            Bitmap img = new Bitmap(Properties.Resources.weapon_1);

            float midX = oldX + img.Width / 2;
            float midY = oldY + img.Height / 2;

            car.RemoveAt(car.Count - 1);
            float angle = (float)Math.Atan2(midY - cursorPosition.Y, midX - cursorPosition.X);
            angle *= (float)(180 / Math.PI);
            Bitmap rotatedImage = rotateImage(Properties.Resources.weapon_1, angle);
            car.Add(new Weapon(oldX, oldY, oldV, rotatedImage));
        }

        private void timerNextKid_Tick(object sender, EventArgs e)
        {
            if (gameStarted)
            {
                Kids.AddKid(new Kid(-30, 330, 5, Properties.Resources.enemy_1_1, Properties.Resources.enemy_1_2, 5));
            }
        }
    }
}