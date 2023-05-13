namespace RibbonStyle
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Windows.Forms.VisualStyles;

    internal class TabStripSystemRenderer : ToolStripSystemRenderer
    {
        protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
        {
            TabStrip toolStrip = e.ToolStrip as TabStrip;
            RibbonStyle.Tab item = e.Item as RibbonStyle.Tab;
            Rectangle bounds = new Rectangle(Point.Empty, e.Item.Size);
            if ((item == null) || (toolStrip == null))
            {
                base.OnRenderButtonBackground(e);
            }
            else
            {
                TabItemState normal = TabItemState.Normal;
                if (item.Checked)
                {
                    normal |= TabItemState.Selected;
                }
                if (item.Selected)
                {
                    normal |= TabItemState.Hot;
                }
                TabRenderer.DrawTabItem(e.Graphics, bounds, normal);
            }
        }

        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            base.OnRenderItemText(e);
            RibbonStyle.Tab item = e.Item as RibbonStyle.Tab;
            if ((item != null) && item.Checked)
            {
                Rectangle textRectangle = e.TextRectangle;
                ControlPaint.DrawFocusRectangle(e.Graphics, textRectangle);
            }
        }
    }
}

