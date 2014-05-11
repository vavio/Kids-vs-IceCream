using System;
using System.Drawing;

namespace Kids_vs_IceCream
{
    public class House : IMovingObject
    {
        private Random rnd = new Random((int)DateTime.Now.Ticks);
        private readonly float[] AvailablePositions = { 172, 152, 118, 177 };

        private readonly Bitmap[] AvailableImages = {   Properties.Resources._1,
                                                        Properties.Resources._2,
                                                        Properties.Resources._3,
                                                        Properties.Resources._4};

        public House(float x, float y, float velocity)
            : base(x, y, velocity)
        {
            int number = rnd.Next(AvailableImages.Length);
            image = new Bitmap(AvailableImages[number]);
            this.Y = AvailablePositions[number];
        }

        override public void Draw(Graphics g)
        {
            g.DrawImage(image, X, Y);
        }

        override public void Move()
        {
            X -= velocity;
        }

        public bool intersect(House other)
        {
            return VMath.intersectAABB(this, other);
        }
    }
}