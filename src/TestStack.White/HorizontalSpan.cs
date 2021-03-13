using System.Drawing;
using System.Windows;

namespace TestStack.White
{
    public class HorizontalSpan : Span
    {
        public HorizontalSpan(Rectangle bounds) : base(bounds.Left, bounds.Right) {}

        public virtual bool IsOutside(Rectangle rect)
        {
            return DoesntContain(rect, rect.Left, rect.Right);
        }
    }
}