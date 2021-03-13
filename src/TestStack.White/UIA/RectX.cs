using System.Drawing;
using System.Windows;

namespace TestStack.White.UIA
{
    public static class RectX
    {
        public static bool IsZeroSize(this Rectangle rect)
        {
            return rect.Height == 0 && rect.Width == 0;
        }

        public static Point Center(this Rectangle rect)
        {
            var topLeftX = rect.Left;
            var topRightX = rect.Right;
            return new Point((int)(topLeftX + (topRightX - topLeftX) / 2), (int)(rect.Top + (rect.Bottom - rect.Top) / 2));
        }

        public static Point North(this Rectangle rectangle, int by = 0)
        {
            return new Point(rectangle.Center().X, rectangle.Top + by);
        }

        public static Point East(this Rectangle rectangle, int by = 0)
        {
            return new Point((int)(rectangle.Right + by), rectangle.Center().Y);
        }

        public static Point South(this Rectangle rectangle, int by = 0)
        {
            return new Point(rectangle.Center().X, rectangle.Bottom + by);
        }

        public static Point West(this Rectangle rectangle, int by = 0)
        {
            return new Point((int)(rectangle.Left + by), rectangle.Center().Y);
        }

        public static Point ImmediateExteriorNorth(this Rectangle rectangle)
        {
            return North(rectangle, -1);
        }

        public static Point ImmediateInteriorNorth(this Rectangle rectangle)
        {
            return North(rectangle, 1);
        }

        public static Point ImmediateExteriorEast(this Rectangle rectangle)
        {
            return East(rectangle, 1);
        }

        public static Point ImmediateInteriorEast(this Rectangle rectangle)
        {
            return East(rectangle, -1);
        }

        public static Point ImmediateExteriorSouth(this Rectangle rectangle)
        {
            return South(rectangle, 1);
        }

        public static Point ImmediateInteriorSouth(this Rectangle rectangle)
        {
            return South(rectangle, -1);
        }

        public static Point ImmediateExteriorWest(this Rectangle rectangle)
        {
            return West(rectangle, -1);
        }

        public static Point ImmediateInteriorWest(this Rectangle rectangle)
        {
            return West(rectangle, 1);
        }

        public static readonly Point UnlikelyWindowPosition = new Point(-10000, -10000);
    }
}