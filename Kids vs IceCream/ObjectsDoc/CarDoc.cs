using System;
using System.Collections.Generic;
using System.Drawing;

namespace Kids_vs_IceCream.Objects
{
    public class CarDoc
    {
        public List<IMovingObject> CarItems { get; set; }

        public readonly int WHEEL1 = 0;
        public readonly int WHEEL2 = 1;
        public readonly int BODY = 2;
        public readonly int WEAPON = 3;

        public CarDoc()
        {
            CarItems = new List<IMovingObject>();

            CarItems.Add(new Wheels(340, 250, 0, false));
            CarItems.Add(new Wheels(420, 250, 0, false));
            CarItems.Add(new Car(340, 250, 0));
            CarItems.Add(new Weapon(390, 300, 0, Properties.Resources.weapon_1));
        }

        public void rotateWeapon(Point cursorPosition)
        {
            int n = CarItems.Count;
            float oldX = CarItems[WEAPON].X;
            float oldY = CarItems[WEAPON].Y;
            float oldV = CarItems[WEAPON].velocity;

            Bitmap img = new Bitmap(Properties.Resources.weapon_1);

            float midX = oldX + img.Width / 2;
            float midY = oldY + img.Height / 2;

            CarItems.RemoveAt(WEAPON);
            float angle = (float)Math.Atan2(midY - cursorPosition.Y, midX - cursorPosition.X);
            angle *= (float)(180 / Math.PI);
            Bitmap rotatedImage = VMath.rotateImage(Properties.Resources.weapon_1, angle);
            CarItems.Add(new Weapon(oldX, oldY, oldV, rotatedImage));
        }

        public void Move()
        {
            foreach (IMovingObject iter in CarItems)
            {
                iter.Move();
            }
        }

        public void Draw(Graphics g)
        {
            foreach (IMovingObject iter in CarItems)
            {
                iter.Draw(g);
            }
        }

        public void MoveToEnd()
        {
            CarItems[WHEEL1] = new Wheels(440, 374, 10, true);
            CarItems[WHEEL2] = new Wheels(520, 374, 10, true);
            CarItems[BODY].velocity = 10;
            CarItems[WEAPON].velocity = 10;
        }

        public void MoveToStart()
        {
            CarItems[WHEEL1].X = 340;
            CarItems[WHEEL1].Y = 250;
            ((Wheels)CarItems[WHEEL1]).seDvizi = false;
            CarItems[WHEEL1].image = Properties.Resources.trkalceNeSeDvizi;

            CarItems[WHEEL2].X = 420;
            CarItems[WHEEL2].Y = 250;
            CarItems[WHEEL2].image = Properties.Resources.trkalceNeSeDvizi;
            ((Wheels)CarItems[WHEEL2]).seDvizi = false;

            CarItems[BODY].X = 340;
            CarItems[BODY].Y = 250;
            CarItems[BODY].velocity = 0;

            CarItems[WEAPON].X = 390;
            CarItems[WEAPON].Y = 300;
            CarItems[WEAPON].velocity = 0;
        }
    }
}