namespace RibbonStyle
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    internal static class LayoutUtils
    {
        public static unsafe Rectangle DeflateRect(Rectangle rect, Padding padding)
        {
            Rectangle* rectanglePtr1 = &rect;
            rectanglePtr1.X += padding.Left;
            Rectangle* rectanglePtr2 = &rect;
            rectanglePtr2.Y += padding.Top;
            Rectangle* rectanglePtr3 = &rect;
            rectanglePtr3.Width -= padding.Horizontal;
            Rectangle* rectanglePtr4 = &rect;
            rectanglePtr4.Height -= padding.Vertical;
            return rect;
        }

        public static unsafe Rectangle InflateRect(Rectangle rect, Padding padding)
        {
            Rectangle* rectanglePtr1 = &rect;
            rectanglePtr1.X -= padding.Left;
            Rectangle* rectanglePtr2 = &rect;
            rectanglePtr2.Y -= padding.Top;
            Rectangle* rectanglePtr3 = &rect;
            rectanglePtr3.Width += padding.Horizontal;
            Rectangle* rectanglePtr4 = &rect;
            rectanglePtr4.Height += padding.Vertical;
            return rect;
        }

        public static Size UnionSizes(Size a, Size b) => 
            new Size(Math.Max(a.Width, b.Width), Math.Max(a.Height, b.Height));
    }
}

