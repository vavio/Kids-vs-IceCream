using System;
using System.Drawing;

namespace Kids_vs_IceCream
{
    public class Vector2D
    {
        public int X { get; set; }

        public int Y { get; set; }

        public Vector2D(Vector2D vec)
        {
            this.X = vec.X;
            this.Y = vec.Y;
        }

        public Vector2D()
        {
        }

        public Vector2D(Point point)
        {
            this.X = point.X;
            this.Y = point.Y;
        }

        public Vector2D(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public Vector2D(float x, float y)
        {
            this.X = (int)x;
            this.Y = (int)y;
        }

        public static Vector2D operator +(Vector2D c1, Vector2D c2)
        {
            return new Vector2D(c1.X + c2.X, c1.Y + c2.Y);
        }

        public static Vector2D operator -(Vector2D c1, Vector2D c2)
        {
            return new Vector2D(c1.X - c2.X, c1.Y - c2.Y);
        }

        public static int operator *(Vector2D c1, Vector2D c2)
        {
            return c1.X * c2.X + c1.Y + c2.Y;
        }

        public static Vector2D operator *(float u, Vector2D c2)
        {
            return new Vector2D(u * c2.X, u + c2.Y);
        }

        public float module()
        {
            return (float)Math.Sqrt(this.X * this.X + this.Y * this.Y);
        }

        public Vector2D norm()
        {
            return new Vector2D((int)(this.X / module()), (int)(this.Y / module()));
        }

        public float distance(Vector2D v2)
        {
            return (new Vector2D(this - v2)).module();
        }

        public float getAngle(Vector2D v2)
        {
            return (float)Math.Acos((double)((this * v2) / (this.module() * v2.module())));
        }

        public Point toPoint()
        {
            return new Point(this.X, this.Y);
        }
    }
}