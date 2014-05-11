using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kids_vs_IceCream
{
        public class RoundButton : Button
        {
            // Draw the new button. 
            protected override void OnPaint(PaintEventArgs e)
            {
                GraphicsPath grPath = new GraphicsPath();
                grPath.AddEllipse(10, 10, 60, 60);
                this.Region = new System.Drawing.Region(grPath);
                base.OnPaint(e);
            }
        }
  
}
