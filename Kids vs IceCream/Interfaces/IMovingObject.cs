using System.Drawing;

namespace Kids_vs_IceCream
{
    public abstract class IMovingObject
    {
        public float X { get; set; }

        public float Y { get; set; }

        public float velocity { get; set; }

        public Bitmap image { get; set; }

        public IMovingObject(float x, float y, float velocity)
        {
            this.X = x;
            this.Y = y;
            this.velocity = velocity;
        }

        public abstract void Draw(Graphics g);

        public abstract void Move();
    }
}