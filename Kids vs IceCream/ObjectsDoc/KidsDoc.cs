using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Kids_vs_IceCream.Objects;

namespace Kids_vs_IceCream
{
    public class KidsDoc
    {
        public List<Kid> Kids { get; set; }

        public KidsDoc()
        {
            this.Kids = new List<Kid>();
        }

        public void AddKid(Kid kid)
        {
            this.Kids.Add(kid);
        }

        public void MoveKids(int width, int height)
        {
            foreach (Kid iter in this.Kids)
            {
                iter.Move();
            }

        }

        public bool isOver(CarDoc car)
        {
            IMovingObject tmp = car.CarItems[car.BODY];
            foreach(Kid k in Kids)
            {
                if (k.X - 50 > tmp.X)
                {
                    return true;
                }
            }
            return false;

        }

        public void DrawKids(Graphics g)
        {
            foreach (Kid iter in Kids)
            {
                iter.Draw(g);
            }
        }

        public int Hit(BulletsDoc bDoc)
        {
            int ret = 0;
            this.Kids.Sort();
            bDoc.Bullets.Sort();
            for (int i = this.Kids.Count - 1; i >= 0; --i)
            {
                bool flag = false;
                for (int j = bDoc.Bullets.Count - 1; j >= 0; --j )
                    if (this.Kids[i].Hit(bDoc.Bullets[j]))
                    {
                        bDoc.Bullets.RemoveAt(j);
                        flag = true;
                        Kids[i].X -= 20; //Pushback
                        break;
                    }
                if (flag)
                {
                    if(this.Kids[i].isDead())
                    {
                        this.Kids.RemoveAt(i);
                        ret++;
                    }
                }
            }
            return ret;
        }
    }
}