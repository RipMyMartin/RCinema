using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace RCinema_db.FrontEnd
{
    public class DefaultBorderRadius
    {
        public static Region CreateRoundedRegion(int containerWidth, int containerHeight, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(containerWidth - radius, 0, radius, radius, 270, 90);
            path.AddArc(containerWidth - radius, containerHeight - radius, radius, radius, 0, 90);
            path.AddArc(0, containerHeight - radius, radius, radius, 90, 90);
            path.CloseFigure();

            return new Region(path);
        }
    }
}
