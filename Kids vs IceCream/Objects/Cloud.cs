using System.Drawing;

namespace Kids_vs_IceCream
{
    public class Cloud : IMovingObject
    {
        public Cloud(float x, float y, float velocity)
            : base(x, y, velocity)
        {
            image = new Bitmap(Properties.Resources.oblace);
            image = new Bitmap(image, new Size(100, 100));
        }

        override public void Draw(Graphics g)
        {
            g.DrawImage(image, X, Y);
        }

        override public void Move()
        {
            X -= velocity;
        }

        public bool intersect(Cloud other)
        {
            return VMath.intersectAABB(this, other);
        }
    }
}