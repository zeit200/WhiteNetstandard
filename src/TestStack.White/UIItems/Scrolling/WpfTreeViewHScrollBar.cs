using Interop.UIAutomationClient;
using System.Drawing;
using System.Windows;
using System.Windows.Automation;
using TestStack.White.UIItems.Actions;

namespace TestStack.White.UIItems.Scrolling
{
    [PlatformSpecificItem(ReferAsType = typeof(IHScrollBar))]
    public class WpfTreeViewHScrollBar : WpfTreeViewScrollBar, IHScrollBar
    {
        private readonly IActionListener actionListener;

        public WpfTreeViewHScrollBar(AutomationElement parent, IActionListener actionListener)
            : base(parent)
        {
            this.actionListener = actionListener;
        }

        public override double Value
        {
            get { return ScrollPattern.Current.HorizontalScrollPercent; }
        }

        protected override double ScrollPercentage
        {
            get { return ScrollPattern.Current.HorizontalViewSize; }
        }

        public override Rectangle Bounds
        {
            get { return Rectangle.Empty; }
        }

        protected virtual void Scroll(ScrollAmount amount)
        {
            if (!IsScrollable) return;
            switch (amount)
            {
                case ScrollAmount.ScrollAmount_LargeDecrement:
                    ScrollPattern.SetScrollPercent(
                        ValidPercentage(ScrollPattern.Current.HorizontalScrollPercent - ScrollPercentage),
                        ScrollPattern.Current.VerticalScrollPercent);
                    break;
                case ScrollAmount.ScrollAmount_SmallDecrement:
                    ScrollPattern.SetScrollPercent(
                        ValidPercentage(ScrollPattern.Current.HorizontalScrollPercent - SmallPercentage()),
                        ScrollPattern.Current.VerticalScrollPercent);
                    break;
                case ScrollAmount.ScrollAmount_LargeIncrement:
                    ScrollPattern.SetScrollPercent(
                        ValidPercentage(ScrollPattern.Current.HorizontalScrollPercent + ScrollPercentage),
                        ScrollPattern.Current.VerticalScrollPercent);
                    break;
                case ScrollAmount.ScrollAmount_SmallIncrement:
                    ScrollPattern.SetScrollPercent(
                        ValidPercentage(ScrollPattern.Current.HorizontalScrollPercent + SmallPercentage()),
                        ScrollPattern.Current.VerticalScrollPercent);
                    break;
            }
            actionListener.ActionPerformed(Action.WindowMessage);
        }

        public virtual void ScrollLeft()
        {
            Scroll(ScrollAmount.ScrollAmount_SmallDecrement);
        }

        public virtual void ScrollRight()
        {
            Scroll(ScrollAmount.ScrollAmount_SmallIncrement);
        }

        public virtual void ScrollLeftLarge()
        {
            Scroll(ScrollAmount.ScrollAmount_LargeDecrement);
        }

        public virtual void ScrollRightLarge()
        {
            Scroll(ScrollAmount.ScrollAmount_LargeIncrement);
        }

        public virtual bool IsScrollable
        {
            get { return ScrollPattern.Current.HorizontallyScrollable; }
        }

        public override void SetToMinimum()
        {
            ScrollPattern.SetScrollPercent(0, ScrollPattern.Current.VerticalScrollPercent);
        }

        public override void SetToMaximum()
        {
            ScrollPattern.SetScrollPercent(100, ScrollPattern.Current.VerticalScrollPercent);
        }
    }
}