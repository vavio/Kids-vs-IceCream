using System.Collections.Generic;
using System.Drawing;

namespace Kids_vs_IceCream
{
    public class BulletsDoc
    {
        public List<Bullet> Bullets { get; set; }

        public BulletsDoc()
        {
            this.Bullets = new List<Bullet>();
        }

        public void AddBullet(Bullet bullet)
        {
            this.Bullets.Add(bullet);
        }

        public void MoveBullets(int width, int height)
        {
            foreach (Bullet iter in this.Bullets)
            {
                iter.Move();
            }

            for (int i = Bullets.Count - 1; i >= 0; --i)
            {
                Bullet iter = Bullets[i];
                if (iter.X > width || iter.X < 0 || iter.Y > height || iter.Y < 0)
                    Bullets.RemoveAt(i);
            }
        }

        public void DrawBullets(Graphics g)
        {
            foreach (Bullet iter in Bullets)
            {
                iter.Draw(g);
            }
        }
    }
}