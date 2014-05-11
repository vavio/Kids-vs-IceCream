using System.Collections.Generic;
using System.Drawing;

namespace Kids_vs_IceCream
{
    public class HousesDoc
    {
        private List<House> Houses;

        public HousesDoc(int Width)
        {
            Houses = new List<House>();
            Houses.Add(new House(Width - 700, 0, 0f));
            Houses.Add(new House(Width - 500, 0, 0f));
            Houses.Add(new House(Width - 300, 0, 0f));
            Houses.Add(new House(Width - 150, 0, 0f));
        }

        public void addHouse(House h)
        {
            Houses.Add(h);
        }

        public void MoveHouses()
        {
            foreach (House iter in Houses)
            {
                iter.Move();
            }
        }

        public void DrawHouses(Graphics g)
        {
            foreach (House iter in Houses)
            {
                iter.Draw(g);
            }
        }

        public void removeOverlap()
        {
            int rem = -1;
            for (int i = Houses.Count - 1; i >= 0; i--)
            {
                for (int j = i - 1; j >= 0; j--)
                {
                    if (Houses[j].X + 150 > Houses[i].X)
                    {
                        rem = i;
                    }
                }
            }
            if (rem != -1)
            {
                Houses.RemoveAt(rem);
            }
        }

        public void removeOverlap(int Width)
        {
            for (int i = this.Houses.Count - 1; i >= 0; --i)
            {
                for (int j = i - 1; j >= 0; --j)
                    if (this.Houses[i].X > Width && this.Houses[j].X > Width)
                    {
                        if (this.Houses[i].intersect(this.Houses[j]))
                        {
                            Houses.RemoveAt(j);
                            break;
                        }
                    }
            }
        }

        public void startMoving()
        {
            Houses = new List<House>();
        }
    }
}