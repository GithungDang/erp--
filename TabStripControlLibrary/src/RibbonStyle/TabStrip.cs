namespace RibbonStyle
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    [ToolboxItem(typeof(TabStripToolboxItem))]
    public class TabStrip : ToolStrip
    {
        private const int EXTRA_PADDING = 0;
        private Font boldFont = new Font(SystemFonts.MenuFont, FontStyle.Bold);
        private Tab currentSelection;
        private int tabOverlap;

        public TabStrip()
        {
            base.Renderer = new TabStripProfessionalRenderer();
            base.Padding = new Padding(60, 3, 30, 0);
            this.AutoSize = false;
            base.Size = new Size(base.Width, 0x1a);
            base.BackColor = Color.FromArgb(0xbf, 0xdb, 0xff);
            base.GripStyle = ToolStripGripStyle.Hidden;
            base.ShowItemToolTips = false;
        }

        protected override ToolStripItem CreateDefaultItem(string text, Image image, EventHandler onClick) => 
            new Tab(text, image, onClick);

        public override Size GetPreferredSize(Size proposedSize)
        {
            Size empty = Size.Empty;
            proposedSize -= base.Padding.Size;
            foreach (ToolStripItem item in this.Items)
            {
                Padding padding = item.Padding;
                empty = LayoutUtils.UnionSizes(empty, item.GetPreferredSize(proposedSize) + padding.Size);
            }
            return (empty + base.Padding.Size);
        }

        protected override void OnItemClicked(ToolStripItemClickedEventArgs e)
        {
            for (int i = 0; i < this.Items.Count; i++)
            {
                Tab objA = this.Items[i] as Tab;
                base.SuspendLayout();
                if (objA != null)
                {
                    if (ReferenceEquals(objA, e.ClickedItem))
                    {
                        objA.b_active = true;
                    }
                    else
                    {
                        objA.Checked = false;
                        objA.Font = this.Font;
                        objA.b_active = false;
                    }
                }
                base.ResumeLayout();
            }
            this.SelectedTab = e.ClickedItem as Tab;
            base.OnItemClicked(e);
        }

        protected override void SetDisplayedItems()
        {
            base.SetDisplayedItems();
            for (int i = 0; i < this.DisplayedItems.Count; i++)
            {
                if (ReferenceEquals(this.DisplayedItems[i], this.SelectedTab))
                {
                    this.DisplayedItems.Add(this.SelectedTab);
                    return;
                }
            }
        }

        protected override Padding DefaultPadding
        {
            get
            {
                Padding defaultPadding = base.DefaultPadding;
                defaultPadding.Top = defaultPadding.Top;
                defaultPadding.Bottom = defaultPadding.Bottom;
                return defaultPadding;
            }
        }

        public Tab SelectedTab
        {
            get => 
                this.currentSelection;
            set
            {
                if (!ReferenceEquals(this.currentSelection, value))
                {
                    this.currentSelection = value;
                    if (this.currentSelection != null)
                    {
                        base.PerformLayout();
                        if (this.currentSelection.TabStripPage != null)
                        {
                            this.currentSelection.TabStripPage.Activate();
                        }
                    }
                }
            }
        }

        protected override Size DefaultSize =>
            base.DefaultSize;

        [DefaultValue(10)]
        public int TabOverlap
        {
            get => 
                this.tabOverlap;
            set
            {
                if (this.tabOverlap != value)
                {
                    this.tabOverlap = value;
                    base.PerformLayout();
                }
            }
        }
    }
}

