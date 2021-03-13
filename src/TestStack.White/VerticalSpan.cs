using System.Drawing;
using System.Windows;

namespace TestStack.White
{
    public class VerticalSpan : Span
    {
        public VerticalSpan(Rectangle bounds) : base(bounds.Top, bounds.Bottom) {}

        public VerticalSpan(double start, double end) : base(start, end)
        {
        }

        public virtual bool DoesntContain(Rectangle rect)
        {
            return DoesntContain(rect, rect.Top, rect.Bottom);
        }

        public virtual bool Contains(Rectangle rect)
        {
            return !DoesntContain(rect);
        }

        public virtual VerticalSpan Union(Rectangle rect)
        {
            double newStart = rect.Top < start ? rect.Top : start;
            double newEnd = rect.Bottom > end ? rect.Bottom : end;
            return new VerticalSpan(newStart, newEnd);
        }

        public virtual VerticalSpan Minus(Rectangle rect)
        {
            if (rect.Top > start && rect.Top < end)
                return new VerticalSpan(start, rect.Top);
            return this;
        }
    }
}