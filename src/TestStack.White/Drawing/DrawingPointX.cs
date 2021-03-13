using System.Drawing;

namespace TestStack.White.Drawing
{
    public static class DrawingPointX
    {
        public static Point ConvertToWindowsPoint(this Point point)
        {
            return new Point(point.X, point.Y);
        }
    }
}