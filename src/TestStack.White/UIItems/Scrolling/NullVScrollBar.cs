using System.Drawing;
using System.Windows;

namespace TestStack.White.UIItems.Scrolling
{
    //BUG: Add LogStatements to make sure that the logging is not happening in NullScrollBar
    public class NullVScrollBar : NullScrollBar, IVScrollBar
    {
        public virtual void ScrollUp() {}

        public virtual void ScrollDown() {}

        public virtual void ScrollUpLarge() {}

        public virtual void ScrollDownLarge() {}

        public virtual bool IsScrollable
        {
            get { return false; }
        }

        public virtual bool IsNotMinimum
        {
            get { return false; }
        }

        public virtual Rectangle Bounds
        {
            get { return Rectangle.Empty; }
        }
    }
}