namespace RibbonStyle
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    [ToolboxItem(false), DesignerCategory("code"), Designer(typeof(TabPageSwitcherDesigner)), Docking(DockingBehavior.AutoDock)]
    public class TabPageSwitcher : ContainerControl
    {
        private TabStripPage selectedTabStripPage;
        private RibbonStyle.TabStrip tabStrip;

        public event EventHandler Load
        {
            [MethodImpl(MethodImplOptions.Synchronized)] add
            {
                this.Load += value;
            }
            [MethodImpl(MethodImplOptions.Synchronized)] remove
            {
                this.Load -= value;
            }
        }

        public event EventHandler SelectedTabStripPageChanged
        {
            [MethodImpl(MethodImplOptions.Synchronized)] add
            {
                this.SelectedTabStripPageChanged += value;
            }
            [MethodImpl(MethodImplOptions.Synchronized)] remove
            {
                this.SelectedTabStripPageChanged -= value;
            }
        }

        public TabPageSwitcher()
        {
            this.ResetBackColor();
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            e.Control.Dock = DockStyle.Fill;
            base.OnControlAdded(e);
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            if (!base.RecreatingHandle)
            {
                this.OnLoad(EventArgs.Empty);
            }
        }

        protected virtual void OnLoad(EventArgs e)
        {
            if (!base.DesignMode)
            {
                this.TabStrip.SelectedTab = (Tab) this.TabStrip.Items[0];
                ((Tab) this.TabStrip.Items[0]).b_active = true;
            }
        }

        protected virtual void OnSelectedTabStripPageChanged(EventArgs e)
        {
            MessageBox.Show("未修改代码执行");
        }

        public override void ResetBackColor()
        {
            this.BackColor = Color.FromArgb(0xbf, 0xdb, 0xff);
        }

        private bool ShouldSerializeBackColor() => 
            this.BackColor != Color.FromArgb(0xbf, 0xdb, 0xff);

        protected override Size DefaultSize =>
            new Size(60, 60);

        protected override Padding DefaultPadding =>
            new Padding(4, 0, 4, 2);

        public RibbonStyle.TabStrip TabStrip
        {
            get => 
                this.tabStrip;
            set => 
                this.tabStrip = value;
        }

        public TabStripPage SelectedTabStripPage
        {
            get => 
                this.selectedTabStripPage;
            set
            {
                if (!ReferenceEquals(this.selectedTabStripPage, value))
                {
                    this.selectedTabStripPage = value;
                    if (this.selectedTabStripPage != null)
                    {
                        if (!base.Controls.Contains(value))
                        {
                            base.Controls.Add(this.selectedTabStripPage);
                        }
                        else
                        {
                            this.selectedTabStripPage.BringToFront();
                        }
                    }
                }
            }
        }
    }
}

