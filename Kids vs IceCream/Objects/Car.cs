using System.Drawing;

namespace Kids_vs_IceCream
{
    //TODO DA se sredi
    public class Car : IMovingObject
    {
        private Bitmap imageWheelNotMoving;
        private Bitmap imageWheelMoving;
        public static int SpeedOfWeapon = 400;

        public Car(float x, float y, float velocity)
            : base(x, y, velocity)
        {
            imageWheelNotMoving = Properties.Resources.trkalceNeSeDvizi;
            imageWheelMoving = Properties.Resources.trkalceSeDvizi1;
            image = Properties.Resources.prvakola;
        }

        override public void Draw(Graphics g)
        {
            g.DrawImage(image, X, Y);
        }

        override public void Move()
        {
            if (!(this.X > 460))
            {
                X += velocity;
            }
        }
    }
}