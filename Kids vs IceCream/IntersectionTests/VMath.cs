using System;
using System.Drawing;

namespace Kids_vs_IceCream
{
    ///<summary>
    /// This class contains collection of functions for collision detection and other vector calculations
    ///</summary>
    /// <remarks>
    /// The functions orientation, doIntersect and onSegment are taken from the reference given
    /// Reference: http://www.geeksforgeeks.org/check-if-two-given-line-segments-intersect/
    /// </remarks>
    public class VMath
    {
        /// To find orientation of ordered triplet (p, q, r).
        /// The function returns following values
        /// 0 --> p, q and r are colinear
        /// 1 --> Clockwise
        /// 2 --> Counterclockwise
        private static int orientation(Point p, Point q, Point r)
        {
            // See 10th slides from following link for derivation of the formula
            // http://www.dcs.gla.ac.uk/~pat/52233/slides/Geometry1x1.pdf
            int val = (q.Y - p.Y) * (r.X - q.X) -
                      (q.X - p.X) * (r.Y - q.Y);

            if (val == 0) return 0;  // colinear

            return (val > 0) ? 1 : 2; // clock or counterclock wise
        }

        // The main function that returns true if line segment 'p1q1'
        // and 'p2q2' intersect.
        public static bool intersectSegmentSegment(Point p1, Point q1, Point p2, Point q2)
        {
            // Find the four orientations needed for general and
            // special cases
            int o1 = orientation(p1, q1, p2);
            int o2 = orientation(p1, q1, q2);
            int o3 = orientation(p2, q2, p1);
            int o4 = orientation(p2, q2, q1);

            // General case
            if (o1 != o2 && o3 != o4)
                return true;

            // Special Cases
            // p1, q1 and p2 are colinear and p2 lies on segment p1q1
            if (o1 == 0 && onSegment(p1, p2, q1)) return true;

            // p1, q1 and p2 are colinear and q2 lies on segment p1q1
            if (o2 == 0 && onSegment(p1, q2, q1)) return true;

            // p2, q2 and p1 are colinear and p1 lies on segment p2q2
            if (o3 == 0 && onSegment(p2, p1, q2)) return true;

            // p2, q2 and q1 are colinear and q1 lies on segment p2q2
            if (o4 == 0 && onSegment(p2, q1, q2)) return true;

            return false; // Doesn't fall in any of the above cases
        }

        private static bool onSegment(Point p, Point q, Point r)
        {
            if (q.X <= Math.Max(p.X, r.X) && q.X >= Math.Min(p.X, r.X) &&
                q.Y <= Math.Max(p.Y, r.Y) && q.Y >= Math.Min(p.Y, r.Y))
                return true;

            return false;
        }

        public static bool intersectAABB(IMovingObject obj1, IMovingObject obj2)
        {
            Point obj1Min = new Point((int)obj1.X, (int)obj1.Y);
            Point obj1Max = new Point((int)obj1.X + obj1.image.Width, (int)obj1.Y + obj1.image.Height);
            Point obj2Min = new Point((int)obj2.X, (int)obj2.Y);
            Point obj2Max = new Point((int)obj2.X + obj2.image.Width, (int)obj2.Y + obj2.image.Height);
            if (obj1Max.X < obj2Min.X ||
                obj1Max.Y < obj2Min.Y ||
                obj1Min.X > obj2Max.X ||
                obj1Min.Y > obj2Max.Y)
            {
                return false;
            }
            return true;
        }

        public static Bitmap rotateImage(Bitmap b, float angle)
        {
            //create a new empty bitmap to hold rotated image
            Bitmap returnBitmap = new Bitmap(b.Width, b.Height);
            //make a graphics object from the empty bitmap
            Graphics g = Graphics.FromImage(returnBitmap);
            //move rotation point to center of image
            g.TranslateTransform((float)b.Width / 2, (float)b.Height / 2);
            //rotate
            g.RotateTransform(angle);
            //move image back
            g.TranslateTransform(-(float)b.Width / 2, -(float)b.Height / 2);
            //draw passed in image onto graphics object
            g.DrawImage(b, new Point(0, 0));
            return returnBitmap;
        }
    }
}