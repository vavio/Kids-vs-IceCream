using System;
using System.Drawing;

namespace Kids_vs_IceCream
{
    public class Bullet : IMovingObject, IComparable<Bullet>
    {
        public static Random Rand = new Random((int)DateTime.Now.Ticks);

        public float Radius { get; set; }

        public Point A0 { get; set; }

        public float Angle { get; set; }

        public Point V { get; set; }

        public float t { get; set; }

        public Point LastPoint { get; set; }

        public Color Color { get; set; }

        public readonly Color[] AvailableColors = { Color.Aqua, Color.Beige, Color.PaleVioletRed, Color.LightSeaGreen };

        public Bullet(float x, float y, float velocity, int radius, Point endPoint)
            : base(x, y, velocity + 100)
        {
            this.Radius = radius;
            Angle = (float)(Math.Atan2(Y - endPoint.Y, X - endPoint.X));
            this.t = 0.5F;
            LastPoint = A0 = new Point((int)X, (int)Y);
            Color = AvailableColors[Rand.Next(AvailableColors.Length)];
        }

        public override void Draw(System.Drawing.Graphics g)
        {
            Brush bulletBrush = new SolidBrush(this.Color);
            g.FillEllipse(bulletBrush, X, Y - 10, 2 * Radius, 2 * Radius);
            //g.DrawLine(new Pen(bulletBrush), LastPoint, new Point((int)X, (int)Y)); //DEBUG
            bulletBrush.Dispose();
        }

        public override void Move()
        {
            LastPoint = new Point((int)X, (int)Y);
            X = A0.X - velocity * t * (float)Math.Cos(Angle);
            Y = A0.Y - (velocity * t * (float)Math.Sin(Angle) - 15F * t * t);
            t += 0.15F;
        }

        public int CompareTo(Bullet other)
        {
            return (int)((other.X - this.X) * 100);
        }
    }
}