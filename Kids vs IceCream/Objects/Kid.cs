using System;
using System.Drawing;

namespace Kids_vs_IceCream
{
    public class Kid : IMovingObject, IComparable<Kid>
    {
        public int Lives { get; set; }

        public int Up { get; set; }

        public Bitmap[] Images { get; set; }

        public int Counter { get; set; }

        public Kid(float x, float y, float velocity, Bitmap img1, Bitmap img2, int health)
            : base(x, y, velocity)
        {
            this.image = img1;
            this.Images = new Bitmap[2];
            this.Images[0] = img1;
            this.Images[1] = img2;
            this.Lives = health;
            this.Up = 1;
            this.Counter = 0;
        }

        public static Kid getKid1()
        {
            return new Kid(-30, 330, 5, Properties.Resources.enemy_1_1, Properties.Resources.enemy_1_2, 1);
        }

        public static Kid getKid2()
        {
            return new Kid(-30, 330, 6, Properties.Resources.enemy_2_1, Properties.Resources.enemy_2_2, 3);
        }

        public static Kid getKid3()
        {
            return new Kid(-30, 330, 7, Properties.Resources.enemy_3_1, Properties.Resources.enemy_3_2, 5);
        }

        public override void Draw(System.Drawing.Graphics g)
        {
            g.DrawImage(this.Images[this.Counter], X, Y);
            this.Counter++;
            this.Counter %= 2;
        }

        public override void Move()
        {
            X += velocity;
            Y += Up;
            Up *= (-1);
        }

        public bool Hit(Bullet b)
        {
            bool ret = false;

            Point a1 = b.LastPoint;
            Point a2 = new Point((int)b.X, (int)b.Y);

            Vector2D topLeft = new Vector2D(this.X, this.Y);

            if (VMath.intersectSegmentSegment(a1, a2, topLeft.toPoint(), (topLeft + (new Vector2D(this.image.Width, 0))).toPoint()))
                ret = true;

            if (VMath.intersectSegmentSegment(a1, a2, topLeft.toPoint(), (topLeft + (new Vector2D(0, this.image.Height))).toPoint()))
                ret = true;

            Vector2D bottomRight = topLeft + (new Vector2D(this.image.Width, this.image.Height));

            if (VMath.intersectSegmentSegment(a1, a2, bottomRight.toPoint(), (bottomRight - (new Vector2D(this.image.Width, 0))).toPoint()))
                ret = true;

            if (VMath.intersectSegmentSegment(a1, a2, bottomRight.toPoint(), (bottomRight - (new Vector2D(0, this.image.Height))).toPoint()))
                ret = true;

            if (ret)
                LowerLife();
            return ret;
        }

        public int CompareTo(Kid other)
        {
            return (int)((this.X - other.X) * 100);
        }

        private void LowerLife()
        {
            this.Lives--;
        }

        public bool isDead()
        {
            return this.Lives == 0;
        }
    }
}