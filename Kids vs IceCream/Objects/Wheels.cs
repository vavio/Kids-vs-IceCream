using System.Drawing;

namespace Kids_vs_IceCream
{
    public class Wheels : IMovingObject
    {
        private int countDistance;
        private Bitmap rotatedImage;
        public bool seDvizi { get; set; }

        public Wheels(float x, float y, float velocity, bool seDvizi)
            : base(x, y, velocity)
        {
            if (seDvizi)
            {
                image = Properties.Resources.trkalceSeDvizi1;
            }
            else
            {
                image = Properties.Resources.trkalceNeSeDvizi;
            }
            countDistance = 0;
            rotatedImage = image;
            this.seDvizi = seDvizi;
        }

        public override void Draw(Graphics g)
        {
            if (seDvizi)
            {
                rotatedImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
                g.DrawImage(rotatedImage, X, Y);
            }
            else
            {
                g.DrawImage(image, X, Y);
            }
        }

        public override void Move()
        {
            if (!(countDistance > 120))
            {
                X += velocity;
                countDistance += (int)velocity;
            }
        }
    }
}