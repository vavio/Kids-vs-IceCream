using System;
using System.Collections.Generic;
using System.Drawing;

namespace Kids_vs_IceCream
{
    public class CloudsDoc
    {
        private List<Cloud> Clouds;
        private Random Rand;

        public CloudsDoc(int Width, int Height)
        {
            Clouds = new List<Cloud>();
            Rand = new Random((int)DateTime.Now.Ticks);

            Clouds.Add(new Cloud(Width - 100, Rand.Next(0, Height - 300), 0.5f));
            Clouds.Add(new Cloud(Width - 500, Rand.Next(0, Height - 300), 0.5f));
            Clouds.Add(new Cloud(Width - 700, Rand.Next(0, Height - 300), 0.5f));
            Clouds.Add(new Cloud(Width - 400, Rand.Next(0, Height - 300), 0.5f));

            removeOverlap(Width);
        }

        public void AddCloud(Cloud c)
        {
            Clouds.Add(c);
        }

        public void MoveClouds()
        {
            foreach (Cloud iter in Clouds)
            {
                iter.Move();
            }
        }

        public void DrawClouds(Graphics g)
        {
            foreach (Cloud iter in Clouds)
            {
                iter.Draw(g);
            }
        }

        public void removeOverlap(int Width)
        {
            for (int i = this.Clouds.Count - 1; i >= 0; --i)
            {
                for (int j = i - 1; j >= 0; --j)
                {
                    //if (this.Clouds[i].X > Width && this.Clouds[j].X > Width)
                    {
                        if (this.Clouds[i].intersect(this.Clouds[j]))
                        {
                            Clouds.RemoveAt(j);
                            break;
                        }
                    }
                }
            }
        }
    }
}