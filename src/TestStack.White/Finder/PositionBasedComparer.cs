using System.Collections.Generic;
using System.Drawing;
using System.Windows;
using System.Windows.Automation;
using TestStack.White.UIItems;

namespace TestStack.White.Finder
{
    public class AutomationElementPositionComparer : PositionBasedComparer, IComparer<AutomationElement>
    {
        public virtual int Compare(AutomationElement x, AutomationElement y)
        {
            Rectangle rectX = x.Current.BoundingRectangle;
            Rectangle rectY = y.Current.BoundingRectangle;
            return Compare(rectX, rectY);
        }
    }

    public class UIItemPositionComparer : PositionBasedComparer, IComparer<IUIItem>
    {
        public virtual int Compare(IUIItem x, IUIItem y)
        {
            return Compare(x.Bounds, y.Bounds);
        }
    }

    public class PositionBasedComparer
    {
        protected static int Compare(Rectangle rectX, Rectangle rectY)
        {
            if (rectX.Top.Equals(rectY.Top)) return rectX.Left.CompareTo(rectY.Left);
            return rectX.Top.CompareTo(rectY.Top);
        }
    }
}