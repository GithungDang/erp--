namespace RibbonStyle
{
    using System;
    using System.ComponentModel;
    using System.Windows.Forms;

    [DesignerCategory("Code"), ToolboxItem(false), Docking(DockingBehavior.Never)]
    public class TabStripPage : RibbonPanel
    {
        public void Activate()
        {
            TabPageSwitcher parent = base.Parent as TabPageSwitcher;
            if (parent != null)
            {
                parent.SelectedTabStripPage = this;
                try
                {
                    int x = parent.TabStrip.SelectedTab.Bounds.Location.X;
                    parent.SelectedTabStripPage.LinePos(x, parent.TabStrip.SelectedTab.Bounds.Right, true);
                }
                catch
                {
                }
            }
        }
    }
}

