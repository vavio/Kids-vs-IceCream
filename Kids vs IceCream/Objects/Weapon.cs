﻿using System.Drawing;

namespace Kids_vs_IceCream
{
    public class Weapon : IMovingObject
    {
        private Bitmap Image;

        public Weapon(float x, float y, float velocity, Bitmap image)
            : base(x, y, velocity)
        {
            this.Image = image;
        }

        public override void Draw(Graphics g)
        {
            g.DrawImageUnscaled(Image, (int)X, (int)Y);
        }

        public override void Move()
        {
            if (!(this.X > 520))
            {
                X += velocity;
            }
        }
    }
}