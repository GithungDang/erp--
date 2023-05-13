namespace ZedGraph
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Drawing.Printing;
    using System.IO;
    using System.Reflection;
    using System.Resources;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading;
    using System.Windows.Forms;

    public class ZedGraphControl : UserControl
    {
        private const double ZoomResolution = 1E-300;
        private const int _ScrollControlSpan = 0x7fffffff;
        private const int _ScrollSmallRatio = 10;
        private ContextMenuBuilderEventHandler ContextMenuBuilder;
        private ZoomEventHandler ZoomEvent;
        private ScrollDoneHandler ScrollDoneEvent;
        private ScrollProgressHandler ScrollProgressEvent;
        private ScrollEventHandler ScrollEvent;
        private PointEditHandler PointEditEvent;
        private PointValueHandler PointValueEvent;
        private CursorValueHandler CursorValueEvent;
        private ZedMouseEventHandler MouseDownEvent;
        private MouseEventHandler MouseDown;
        private MouseEventHandler MouseUp;
        private MouseEventHandler MouseMove;
        private ZedMouseEventHandler MouseUpEvent;
        private ZedMouseEventHandler MouseMoveEvent;
        private ZedMouseEventHandler DoubleClickEvent;
        private LinkEventHandler LinkEvent;
        private ZedGraph.MasterPane _masterPane;
        private bool _isShowPointValues;
        private bool _isShowCursorValues;
        private string _pointValueFormat = "G";
        private bool _isShowContextMenu = true;
        private bool _isShowCopyMessage = true;
        private System.Windows.Forms.SaveFileDialog _saveFileDialog = new System.Windows.Forms.SaveFileDialog();
        private bool _isPrintScaleAll = true;
        private bool _isPrintKeepAspectRatio = true;
        private bool _isPrintFillPage = true;
        private string _pointDateFormat = "g";
        private bool _isEnableVZoom = true;
        private bool _isEnableHZoom = true;
        private bool _isEnableWheelZoom = true;
        private bool _isEnableVEdit;
        private bool _isEnableHEdit;
        private bool _isEnableHPan = true;
        private bool _isEnableVPan = true;
        private bool _isEnableSelection;
        private double _zoomStepFraction = 0.1;
        private ScrollRange _xScrollRange;
        private ScrollRangeList _yScrollRangeList;
        private ScrollRangeList _y2ScrollRangeList;
        private bool _isShowHScrollBar;
        private bool _isShowVScrollBar;
        private bool _isAutoScrollRange;
        private double _scrollGrace;
        private bool _isSynchronizeXAxes;
        private bool _isSynchronizeYAxes;
        private bool _isZoomOnMouseCenter;
        private ResourceManager _resourceManager;
        private System.Drawing.Printing.PrintDocument _pdSave;
        private ZedGraph.Selection _selection = new ZedGraph.Selection();
        private MouseButtons _linkButtons = MouseButtons.Left;
        private Keys _linkModifierKeys = Keys.Alt;
        private MouseButtons _editButtons = MouseButtons.Right;
        private Keys _editModifierKeys = Keys.Alt;
        private MouseButtons _selectButtons = MouseButtons.Left;
        private Keys _selectModifierKeys = Keys.Shift;
        private Keys _selectAppendModifierKeys = (Keys.Control | Keys.Shift);
        private MouseButtons _zoomButtons = MouseButtons.Left;
        private Keys _zoomModifierKeys;
        private MouseButtons _zoomButtons2;
        private Keys _zoomModifierKeys2;
        private MouseButtons _panButtons = MouseButtons.Left;
        private Keys _panModifierKeys = Keys.Control;
        private MouseButtons _panButtons2 = MouseButtons.Middle;
        private Keys _panModifierKeys2;
        private bool _isZooming;
        private bool _isPanning;
        private bool _isEditing;
        private bool _isSelecting;
        private ZedGraph.GraphPane _dragPane;
        private Point _dragStartPt;
        private Point _dragEndPt;
        private int _dragIndex;
        private CurveItem _dragCurve;
        private PointPair _dragStartPair;
        private ZoomState _zoomState;
        private ZoomStateStack _zoomStateStack;
        internal Point _menuClickPt;
        private IContainer components;
        private VScrollBar vScrollBar1;
        private HScrollBar hScrollBar1;
        private ToolTip pointToolTip;
        private ContextMenuStrip contextMenuStrip1;

        [Description("Subscribe to this event to be able to modify the ZedGraph context menu"), Bindable(true), Category("Events")]
        public event ContextMenuBuilderEventHandler ContextMenuBuilder
        {
            [MethodImpl(MethodImplOptions.Synchronized)] add
            {
                this.ContextMenuBuilder += value;
            }
            [MethodImpl(MethodImplOptions.Synchronized)] remove
            {
                this.ContextMenuBuilder -= value;
            }
        }

        [Description("Subscribe to this event to provide custom-formatting for cursor value tooltips"), Bindable(true), Category("Events")]
        public event CursorValueHandler CursorValueEvent
        {
            [MethodImpl(MethodImplOptions.Synchronized)] add
            {
                this.CursorValueEvent += value;
            }
            [MethodImpl(MethodImplOptions.Synchronized)] remove
            {
                this.CursorValueEvent -= value;
            }
        }

        [Description("Subscribe to be notified when the left mouse button is double-clicked"), Bindable(true), Category("Events")]
        public event ZedMouseEventHandler DoubleClickEvent
        {
            [MethodImpl(MethodImplOptions.Synchronized)] add
            {
                this.DoubleClickEvent += value;
            }
            [MethodImpl(MethodImplOptions.Synchronized)] remove
            {
                this.DoubleClickEvent -= value;
            }
        }

        [Category("Events"), Bindable(true), Description("Subscribe to be notified when a link-enabled item is clicked")]
        public event LinkEventHandler LinkEvent
        {
            [MethodImpl(MethodImplOptions.Synchronized)] add
            {
                this.LinkEvent += value;
            }
            [MethodImpl(MethodImplOptions.Synchronized)] remove
            {
                this.LinkEvent -= value;
            }
        }

        [Browsable(false), Bindable(false)]
        public event MouseEventHandler MouseDown
        {
            [MethodImpl(MethodImplOptions.Synchronized)] add
            {
                this.MouseDown += value;
            }
            [MethodImpl(MethodImplOptions.Synchronized)] remove
            {
                this.MouseDown -= value;
            }
        }

        [Description("Subscribe to be notified when the left mouse button is clicked down"), Category("Events"), Bindable(true)]
        public event ZedMouseEventHandler MouseDownEvent
        {
            [MethodImpl(MethodImplOptions.Synchronized)] add
            {
                this.MouseDownEvent += value;
            }
            [MethodImpl(MethodImplOptions.Synchronized)] remove
            {
                this.MouseDownEvent -= value;
            }
        }

        [Browsable(false), Bindable(false)]
        private event MouseEventHandler MouseMove
        {
            [MethodImpl(MethodImplOptions.Synchronized)] add
            {
                this.MouseMove += value;
            }
            [MethodImpl(MethodImplOptions.Synchronized)] remove
            {
                this.MouseMove -= value;
            }
        }

        [Description("Subscribe to be notified when the mouse is moved inside the control"), Category("Events"), Bindable(true)]
        public event ZedMouseEventHandler MouseMoveEvent
        {
            [MethodImpl(MethodImplOptions.Synchronized)] add
            {
                this.MouseMoveEvent += value;
            }
            [MethodImpl(MethodImplOptions.Synchronized)] remove
            {
                this.MouseMoveEvent -= value;
            }
        }

        [Browsable(false), Bindable(false)]
        public event MouseEventHandler MouseUp
        {
            [MethodImpl(MethodImplOptions.Synchronized)] add
            {
                this.MouseUp += value;
            }
            [MethodImpl(MethodImplOptions.Synchronized)] remove
            {
                this.MouseUp -= value;
            }
        }

        [Description("Subscribe to be notified when the left mouse button is released"), Category("Events"), Bindable(true)]
        public event ZedMouseEventHandler MouseUpEvent
        {
            [MethodImpl(MethodImplOptions.Synchronized)] add
            {
                this.MouseUpEvent += value;
            }
            [MethodImpl(MethodImplOptions.Synchronized)] remove
            {
                this.MouseUpEvent -= value;
            }
        }

        [Category("Events"), Bindable(true), Description("Subscribe to this event to respond to data point edit actions")]
        public event PointEditHandler PointEditEvent
        {
            [MethodImpl(MethodImplOptions.Synchronized)] add
            {
                this.PointEditEvent += value;
            }
            [MethodImpl(MethodImplOptions.Synchronized)] remove
            {
                this.PointEditEvent -= value;
            }
        }

        [Description("Subscribe to this event to provide custom-formatting for data point tooltips"), Category("Events"), Bindable(true)]
        public event PointValueHandler PointValueEvent
        {
            [MethodImpl(MethodImplOptions.Synchronized)] add
            {
                this.PointValueEvent += value;
            }
            [MethodImpl(MethodImplOptions.Synchronized)] remove
            {
                this.PointValueEvent -= value;
            }
        }

        [Description("Subscribe this event to be notified when a scroll operation using the scrollbars is completed"), Bindable(true), Category("Events")]
        public event ScrollDoneHandler ScrollDoneEvent
        {
            [MethodImpl(MethodImplOptions.Synchronized)] add
            {
                this.ScrollDoneEvent += value;
            }
            [MethodImpl(MethodImplOptions.Synchronized)] remove
            {
                this.ScrollDoneEvent -= value;
            }
        }

        [Description("Subscribe this event to be notified of general scroll events"), Bindable(true), Category("Events")]
        public event ScrollEventHandler ScrollEvent
        {
            [MethodImpl(MethodImplOptions.Synchronized)] add
            {
                this.ScrollEvent += value;
            }
            [MethodImpl(MethodImplOptions.Synchronized)] remove
            {
                this.ScrollEvent -= value;
            }
        }

        [Bindable(true), Description("Subscribe this event to be notified continuously as a scroll operation is taking place"), Category("Events")]
        public event ScrollProgressHandler ScrollProgressEvent
        {
            [MethodImpl(MethodImplOptions.Synchronized)] add
            {
                this.ScrollProgressEvent += value;
            }
            [MethodImpl(MethodImplOptions.Synchronized)] remove
            {
                this.ScrollProgressEvent -= value;
            }
        }

        [Description("Subscribe to this event to be notified when the graph is zoomed or panned"), Bindable(true), Category("Events")]
        public event ZoomEventHandler ZoomEvent
        {
            [MethodImpl(MethodImplOptions.Synchronized)] add
            {
                this.ZoomEvent += value;
            }
            [MethodImpl(MethodImplOptions.Synchronized)] remove
            {
                this.ZoomEvent -= value;
            }
        }

        public ZedGraphControl()
        {
            this.InitializeComponent();
            base.MouseDown += new MouseEventHandler(this.ZedGraphControl_MouseDown);
            base.MouseUp += new MouseEventHandler(this.ZedGraphControl_MouseUp);
            base.MouseMove += new MouseEventHandler(this.ZedGraphControl_MouseMove);
            base.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
            base.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this._resourceManager = new ResourceManager("ZedGraph.ZedGraph.ZedGraphLocale", Assembly.GetExecutingAssembly());
            Rectangle paneRect = new Rectangle(0, 0, base.Size.Width, base.Size.Height);
            this._masterPane = new ZedGraph.MasterPane("", paneRect);
            this._masterPane.Margin.All = 0f;
            this._masterPane.Title.IsVisible = false;
            string title = this._resourceManager.GetString("title_def");
            ZedGraph.GraphPane pane = new ZedGraph.GraphPane(paneRect, title, this._resourceManager.GetString("x_title_def"), this._resourceManager.GetString("y_title_def"));
            using (Graphics graphics = base.CreateGraphics())
            {
                pane.AxisChange(graphics);
            }
            this._masterPane.Add(pane);
            this.hScrollBar1.Minimum = 0;
            this.hScrollBar1.Maximum = 100;
            this.hScrollBar1.Value = 0;
            this.vScrollBar1.Minimum = 0;
            this.vScrollBar1.Maximum = 100;
            this.vScrollBar1.Value = 0;
            this._xScrollRange = new ScrollRange(true);
            this._yScrollRangeList = new ScrollRangeList();
            this._y2ScrollRangeList = new ScrollRangeList();
            this._yScrollRangeList.Add(new ScrollRange(true));
            this._y2ScrollRangeList.Add(new ScrollRange(false));
            this._zoomState = null;
            this._zoomStateStack = new ZoomStateStack();
        }

        private void ApplyToAllPanes(ZedGraph.GraphPane primaryPane)
        {
            foreach (ZedGraph.GraphPane pane in this._masterPane._paneList)
            {
                if (!ReferenceEquals(pane, primaryPane))
                {
                    if (this._isSynchronizeXAxes)
                    {
                        this.Synchronize(primaryPane.XAxis, pane.XAxis);
                    }
                    if (this._isSynchronizeYAxes)
                    {
                        this.Synchronize(primaryPane.YAxis, pane.YAxis);
                    }
                }
            }
        }

        public virtual void AxisChange()
        {
            lock (this)
            {
                if (!this.BeenDisposed && (this._masterPane != null))
                {
                    using (Graphics graphics = base.CreateGraphics())
                    {
                        this._masterPane.AxisChange(graphics);
                    }
                    if (this._isAutoScrollRange)
                    {
                        this.SetScrollRangeFromData();
                    }
                }
            }
        }

        private PointF BoundPointToRect(Point mousePt, RectangleF rect)
        {
            PointF tf = new PointF((float) mousePt.X, (float) mousePt.Y);
            if (mousePt.X < rect.X)
            {
                tf.X = rect.X;
            }
            if (mousePt.X > rect.Right)
            {
                tf.X = rect.Right;
            }
            if (mousePt.Y < rect.Y)
            {
                tf.Y = rect.Y;
            }
            if (mousePt.Y > rect.Bottom)
            {
                tf.Y = rect.Bottom;
            }
            return tf;
        }

        private Rectangle CalcScreenRect(Point mousePt1, Point mousePt2)
        {
            Size size = new Size(mousePt2.X - mousePt1.X, mousePt2.Y - mousePt1.Y);
            Rectangle rectangle = new Rectangle(base.PointToScreen(mousePt1), size);
            if (this._isZooming)
            {
                Rectangle rectangle2 = Rectangle.Round(this._dragPane.Chart._rect);
                Point point2 = base.PointToScreen(rectangle2.Location);
                if (!this._isEnableVZoom)
                {
                    rectangle.Y = point2.Y;
                    rectangle.Height = rectangle2.Height + 1;
                }
                else if (!this._isEnableHZoom)
                {
                    rectangle.X = point2.X;
                    rectangle.Width = rectangle2.Width + 1;
                }
            }
            return rectangle;
        }

        private double CalcScrollGrace(double min, double max) => 
            (Math.Abs((double) (max - min)) >= 1E-30) ? ((max - min) * this._scrollGrace) : ((Math.Abs(max) >= 1E-30) ? (max * this._scrollGrace) : this._scrollGrace);

        private void ClipboardCopyThread()
        {
            Clipboard.SetDataObject(this.ImageRender(), true);
        }

        private void ClipboardCopyThreadEmf()
        {
            using (Graphics graphics = base.CreateGraphics())
            {
                IntPtr hdc = graphics.GetHdc();
                Metafile image = new Metafile(hdc, EmfType.EmfPlusOnly);
                graphics.ReleaseHdc(hdc);
                using (Graphics graphics2 = Graphics.FromImage(image))
                {
                    this._masterPane.Draw(graphics2);
                }
                ClipboardMetafileHelper.PutEnhMetafileOnClipboard(base.Handle, image);
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            ContextMenuStrip menuStrip = sender as ContextMenuStrip;
            ContextMenuObjectState objectState = this.GetObjectState();
            if ((this._masterPane != null) && (menuStrip != null))
            {
                menuStrip.Items.Clear();
                this._isZooming = false;
                this._isPanning = false;
                Cursor.Current = Cursors.Default;
                this._menuClickPt = base.PointToClient(Control.MousePosition);
                ZedGraph.GraphPane pane = this._masterPane.FindPane((PointF) this._menuClickPt);
                if (this._isShowContextMenu)
                {
                    string str = string.Empty;
                    ToolStripMenuItem item = new ToolStripMenuItem {
                        Name = "copy",
                        Tag = "copy",
                        Text = this._resourceManager.GetString("copy")
                    };
                    item.Click += new EventHandler(this.MenuClick_Copy);
                    menuStrip.Items.Add(item);
                    item = new ToolStripMenuItem {
                        Name = "save_as",
                        Tag = "save_as",
                        Text = this._resourceManager.GetString("save_as")
                    };
                    item.Click += new EventHandler(this.MenuClick_SaveAs);
                    menuStrip.Items.Add(item);
                    item = new ToolStripMenuItem {
                        Name = "page_setup",
                        Tag = "page_setup",
                        Text = this._resourceManager.GetString("page_setup")
                    };
                    item.Click += new EventHandler(this.MenuClick_PageSetup);
                    menuStrip.Items.Add(item);
                    item = new ToolStripMenuItem {
                        Name = "print",
                        Tag = "print",
                        Text = this._resourceManager.GetString("print")
                    };
                    item.Click += new EventHandler(this.MenuClick_Print);
                    menuStrip.Items.Add(item);
                    item = new ToolStripMenuItem {
                        Name = "show_val",
                        Tag = "show_val",
                        Text = this._resourceManager.GetString("show_val")
                    };
                    item.Click += new EventHandler(this.MenuClick_ShowValues);
                    item.Checked = this.IsShowPointValues;
                    menuStrip.Items.Add(item);
                    item = new ToolStripMenuItem {
                        Name = "unzoom",
                        Tag = "unzoom"
                    };
                    if ((pane == null) || pane.ZoomStack.IsEmpty)
                    {
                        str = this._resourceManager.GetString("unzoom");
                    }
                    else
                    {
                        switch (pane.ZoomStack.Top.Type)
                        {
                            case ZoomState.StateType.Zoom:
                            case ZoomState.StateType.WheelZoom:
                                str = this._resourceManager.GetString("unzoom");
                                break;

                            case ZoomState.StateType.Pan:
                                str = this._resourceManager.GetString("unpan");
                                break;

                            case ZoomState.StateType.Scroll:
                                str = this._resourceManager.GetString("unscroll");
                                break;

                            default:
                                break;
                        }
                    }
                    item.Text = str;
                    item.Click += new EventHandler(this.MenuClick_ZoomOut);
                    if ((pane == null) || pane.ZoomStack.IsEmpty)
                    {
                        item.Enabled = false;
                    }
                    menuStrip.Items.Add(item);
                    item = new ToolStripMenuItem {
                        Name = "undo_all",
                        Tag = "undo_all",
                        Text = this._resourceManager.GetString("undo_all")
                    };
                    item.Click += new EventHandler(this.MenuClick_ZoomOutAll);
                    if ((pane == null) || pane.ZoomStack.IsEmpty)
                    {
                        item.Enabled = false;
                    }
                    menuStrip.Items.Add(item);
                    item = new ToolStripMenuItem {
                        Name = "set_default",
                        Tag = "set_default",
                        Text = this._resourceManager.GetString("set_default")
                    };
                    item.Click += new EventHandler(this.MenuClick_RestoreScale);
                    if (pane == null)
                    {
                        item.Enabled = false;
                    }
                    menuStrip.Items.Add(item);
                    e.Cancel = false;
                    if (this.ContextMenuBuilder != null)
                    {
                        this.ContextMenuBuilder(this, menuStrip, this._menuClickPt, objectState);
                    }
                }
            }
        }

        public void Copy(bool isShowMessage)
        {
            if (this._masterPane != null)
            {
                Thread thread = new Thread(new ThreadStart(this.ClipboardCopyThread));
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
                thread.Join();
                if (isShowMessage)
                {
                    MessageBox.Show(this._resourceManager.GetString("copied_to_clip"));
                }
            }
        }

        public void CopyEmf(bool isShowMessage)
        {
            if (this._masterPane != null)
            {
                Thread thread = new Thread(new ThreadStart(this.ClipboardCopyThreadEmf));
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
                thread.Join();
                if (isShowMessage)
                {
                    MessageBox.Show(this._resourceManager.GetString("copied_to_clip"));
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            lock (this)
            {
                if (disposing && (this.components != null))
                {
                    this.components.Dispose();
                }
                base.Dispose(disposing);
                this._masterPane = null;
            }
        }

        public void DoPageSetup()
        {
            System.Drawing.Printing.PrintDocument printDocument = this.PrintDocument;
            try
            {
                if (printDocument != null)
                {
                    PageSetupDialog dialog = new PageSetupDialog {
                        Document = printDocument
                    };
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        printDocument.PrinterSettings = dialog.PrinterSettings;
                        printDocument.DefaultPageSettings = dialog.PageSettings;
                    }
                }
            }
            catch (Exception exception1)
            {
                MessageBox.Show(exception1.Message);
            }
        }

        public void DoPrint()
        {
            try
            {
                System.Drawing.Printing.PrintDocument printDocument = this.PrintDocument;
                if (printDocument != null)
                {
                    PrintDialog dialog = new PrintDialog {
                        Document = printDocument
                    };
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        printDocument.Print();
                    }
                }
            }
            catch (Exception exception1)
            {
                MessageBox.Show(exception1.Message);
            }
        }

        public void DoPrintPreview()
        {
            try
            {
                System.Drawing.Printing.PrintDocument printDocument = this.PrintDocument;
                if (printDocument != null)
                {
                    new PrintPreviewDialog { Document = printDocument }.Show(this);
                }
            }
            catch (Exception exception1)
            {
                MessageBox.Show(exception1.Message);
            }
        }

        [Bindable(false), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Image GetImage()
        {
            lock (this)
            {
                if (this.BeenDisposed || ((this._masterPane == null) || (this._masterPane[0] == null)))
                {
                    throw new ZedGraphException("The control has been disposed");
                }
                return this._masterPane.GetImage();
            }
        }

        private ContextMenuObjectState GetObjectState()
        {
            ContextMenuObjectState background = ContextMenuObjectState.Background;
            Point point = base.PointToClient(Control.MousePosition);
            using (Graphics graphics = base.CreateGraphics())
            {
                int num;
                ZedGraph.GraphPane pane;
                object obj2;
                if (this.MasterPane.FindNearestPaneObject((PointF) point, graphics, out pane, out obj2, out num))
                {
                    CurveItem item = obj2 as CurveItem;
                    if ((item != null) && (num >= 0))
                    {
                        background = !item.IsSelected ? ContextMenuObjectState.InactiveSelection : ContextMenuObjectState.ActiveSelection;
                    }
                }
            }
            return background;
        }

        private unsafe void Graph_PrintPage(object sender, PrintPageEventArgs e)
        {
            ZedGraph.MasterPane masterPane = this.MasterPane;
            bool[] flagArray = new bool[masterPane.PaneList.Count + 1];
            bool[] flagArray2 = new bool[] { masterPane.IsFontsScaled };
            flagArray[0] = masterPane.IsPenWidthScaled;
            for (int i = 0; i < masterPane.PaneList.Count; i++)
            {
                flagArray[i + 1] = masterPane[i].IsPenWidthScaled;
                flagArray2[i + 1] = masterPane[i].IsFontsScaled;
                if (this._isPrintScaleAll)
                {
                    masterPane[i].IsPenWidthScaled = true;
                    masterPane[i].IsFontsScaled = true;
                }
            }
            RectangleF rect = masterPane.Rect;
            SizeF size = masterPane.Rect.Size;
            if (!this._isPrintFillPage || !this._isPrintKeepAspectRatio)
            {
                if (this._isPrintFillPage)
                {
                    size = (SizeF) e.MarginBounds.Size;
                }
            }
            else
            {
                float num4 = Math.Min((float) (((float) e.MarginBounds.Width) / size.Width), (float) (((float) e.MarginBounds.Height) / size.Height));
                SizeF* efPtr1 = &size;
                efPtr1.Width *= num4;
                SizeF* efPtr2 = &size;
                efPtr2.Height *= num4;
            }
            masterPane.ReSize(e.Graphics, new RectangleF((float) e.MarginBounds.Left, (float) e.MarginBounds.Top, size.Width, size.Height));
            masterPane.Draw(e.Graphics);
            using (Graphics graphics = base.CreateGraphics())
            {
                masterPane.ReSize(graphics, rect);
            }
            masterPane.IsPenWidthScaled = flagArray[0];
            masterPane.IsFontsScaled = flagArray2[0];
            for (int j = 0; j < masterPane.PaneList.Count; j++)
            {
                masterPane[j].IsPenWidthScaled = flagArray[j + 1];
                masterPane[j].IsFontsScaled = flagArray2[j + 1];
            }
        }

        private Point HandleCursorValues(Point mousePt)
        {
            ZedGraph.GraphPane pane = this._masterPane.FindPane((PointF) mousePt);
            if ((pane == null) || !pane.Chart._rect.Contains((PointF) mousePt))
            {
                this.pointToolTip.Active = false;
            }
            else if (this.CursorValueEvent == null)
            {
                double num;
                double num2;
                double num3;
                double num4;
                pane.ReverseTransform((PointF) mousePt, out num, out num2, out num3, out num4);
                this.pointToolTip.SetToolTip(this, "( " + this.MakeValueLabel(pane.XAxis, num, -1, true) + ", " + this.MakeValueLabel(pane.YAxis, num3, -1, true) + ", " + this.MakeValueLabel(pane.Y2Axis, num4, -1, true) + " )");
                this.pointToolTip.Active = true;
            }
            else
            {
                string caption = this.CursorValueEvent(this, pane, mousePt);
                if ((caption == null) || (caption.Length <= 0))
                {
                    this.pointToolTip.Active = false;
                }
                else
                {
                    this.pointToolTip.SetToolTip(this, caption);
                    this.pointToolTip.Active = true;
                }
            }
            return mousePt;
        }

        private void HandleEditCancel()
        {
            if (this._isEditing)
            {
                IPointListEdit points = this._dragCurve.Points as IPointListEdit;
                if (points != null)
                {
                    points[this._dragIndex] = this._dragStartPair;
                }
                this._isEditing = false;
                this.Refresh();
            }
        }

        private void HandleEditDrag(Point mousePt)
        {
            double num;
            double num2;
            double num3;
            double num4;
            this._dragPane.ReverseTransform((PointF) mousePt, this._dragCurve.IsX2Axis, this._dragCurve.IsY2Axis, this._dragCurve.YAxisIndex, out num, out num2);
            this._dragPane.ReverseTransform((PointF) this._dragStartPt, this._dragCurve.IsX2Axis, this._dragCurve.IsY2Axis, this._dragCurve.YAxisIndex, out num3, out num4);
            PointPair pair = new PointPair(this._dragStartPair);
            Scale scale = this._dragCurve.GetXAxis(this._dragPane)._scale;
            if (this._isEnableHEdit)
            {
                pair.X = scale.DeLinearize((scale.Linearize(pair.X) + scale.Linearize(num)) - scale.Linearize(num3));
            }
            Scale scale2 = this._dragCurve.GetYAxis(this._dragPane)._scale;
            if (this._isEnableVEdit)
            {
                pair.Y = scale2.DeLinearize((scale2.Linearize(pair.Y) + scale2.Linearize(num2)) - scale2.Linearize(num4));
            }
            IPointListEdit points = this._dragCurve.Points as IPointListEdit;
            if (points != null)
            {
                points[this._dragIndex] = pair;
            }
            this.Refresh();
        }

        private void HandleEditFinish()
        {
            if (this.PointEditEvent != null)
            {
                this.PointEditEvent(this, this._dragPane, this._dragCurve, this._dragIndex);
            }
        }

        private void HandlePanCancel()
        {
            if (this._isPanning)
            {
                if ((this._zoomState != null) && this._zoomState.IsChanged(this._dragPane))
                {
                    this.ZoomStateRestore(this._dragPane);
                }
                this._isPanning = false;
                this.Refresh();
                this.ZoomStateClear();
            }
        }

        private Point HandlePanDrag(Point mousePt)
        {
            double num;
            double num2;
            double num3;
            double num4;
            double[] numArray;
            double[] numArray2;
            double[] numArray3;
            double[] numArray4;
            this._dragPane.ReverseTransform((PointF) this._dragStartPt, out num, out num3, out numArray, out numArray3);
            this._dragPane.ReverseTransform((PointF) mousePt, out num2, out num4, out numArray2, out numArray4);
            if (this._isEnableHPan)
            {
                this.PanScale(this._dragPane.XAxis, num, num2);
                this.PanScale(this._dragPane.X2Axis, num3, num4);
                this.SetScroll(this.hScrollBar1, this._dragPane.XAxis, this._xScrollRange.Min, this._xScrollRange.Max);
            }
            if (this._isEnableVPan)
            {
                int index = 0;
                while (true)
                {
                    if (index >= numArray.Length)
                    {
                        int num6 = 0;
                        while (true)
                        {
                            if (num6 >= numArray3.Length)
                            {
                                this.SetScroll(this.vScrollBar1, this._dragPane.YAxis, this._yScrollRangeList[0].Min, this._yScrollRangeList[0].Max);
                                break;
                            }
                            this.PanScale(this._dragPane.Y2AxisList[num6], numArray3[num6], numArray4[num6]);
                            num6++;
                        }
                        break;
                    }
                    this.PanScale(this._dragPane.YAxisList[index], numArray[index], numArray2[index]);
                    index++;
                }
            }
            this.ApplyToAllPanes(this._dragPane);
            this.Refresh();
            this._dragStartPt = mousePt;
            return mousePt;
        }

        private void HandlePanFinish()
        {
            if ((this._zoomState != null) && this._zoomState.IsChanged(this._dragPane))
            {
                this.ZoomStatePush(this._dragPane);
                if (this.ZoomEvent != null)
                {
                    this.ZoomEvent(this, this._zoomState, new ZoomState(this._dragPane, ZoomState.StateType.Pan));
                }
                this._zoomState = null;
            }
        }

        private Point HandlePointValues(Point mousePt)
        {
            using (Graphics graphics = base.CreateGraphics())
            {
                int num;
                ZedGraph.GraphPane pane;
                object obj2;
                if (!this._masterPane.FindNearestPaneObject((PointF) mousePt, graphics, out pane, out obj2, out num))
                {
                    this.pointToolTip.Active = false;
                }
                else if (!(obj2 is CurveItem) || (num < 0))
                {
                    this.pointToolTip.Active = false;
                }
                else
                {
                    CurveItem curve = (CurveItem) obj2;
                    if (this.PointValueEvent != null)
                    {
                        string caption = this.PointValueEvent(this, pane, curve, num);
                        if ((caption == null) || (caption.Length <= 0))
                        {
                            this.pointToolTip.Active = false;
                        }
                        else
                        {
                            this.pointToolTip.SetToolTip(this, caption);
                            this.pointToolTip.Active = true;
                        }
                    }
                    else
                    {
                        if (curve is PieItem)
                        {
                            this.pointToolTip.SetToolTip(this, ((PieItem) curve).Value.ToString(this._pointValueFormat));
                        }
                        else
                        {
                            PointPair pair = curve.Points[num];
                            if (pair.Tag is string)
                            {
                                this.pointToolTip.SetToolTip(this, (string) pair.Tag);
                            }
                            else
                            {
                                double num2;
                                double num3;
                                double num4;
                                ValueHandler handler = new ValueHandler(pane, false);
                                if (((curve is BarItem) || ((curve is ErrorBarItem) || (curve is HiLowBarItem))) && (pane.BarSettings.Base != BarBase.X))
                                {
                                    handler.GetValues(curve, num, out num3, out num4, out num2);
                                }
                                else
                                {
                                    handler.GetValues(curve, num, out num2, out num4, out num3);
                                }
                                this.pointToolTip.SetToolTip(this, "( " + this.MakeValueLabel(curve.GetXAxis(pane), num2, num, curve.IsOverrideOrdinal) + ", " + this.MakeValueLabel(curve.GetYAxis(pane), num3, num, curve.IsOverrideOrdinal) + " )");
                            }
                        }
                        this.pointToolTip.Active = true;
                    }
                }
            }
            return mousePt;
        }

        private void HandleScroll(Axis axis, int newValue, double scrollMin, double scrollMax, int largeChange, bool reverse)
        {
            if (axis != null)
            {
                if (scrollMin > axis._scale._min)
                {
                    scrollMin = axis._scale._min;
                }
                if (scrollMax < axis._scale._max)
                {
                    scrollMax = axis._scale._max;
                }
                int num = 0x7fffffff - largeChange;
                if (num > 0)
                {
                    if (reverse)
                    {
                        newValue = num - newValue;
                    }
                    Scale scale = axis._scale;
                    double num2 = scale._maxLinearized - scale._minLinearized;
                    double num3 = scale.Linearize(scrollMax) - num2;
                    scrollMin = scale.Linearize(scrollMin);
                    double num4 = scrollMin + ((((double) newValue) / ((double) num)) * (num3 - scrollMin));
                    scale._minLinearized = num4;
                    scale._maxLinearized = num4 + num2;
                    base.Invalidate();
                }
            }
        }

        private void HandleSelectionCancel()
        {
            this._isSelecting = false;
            this._selection.ClearSelection(this._masterPane);
            this.Refresh();
        }

        private void HandleSelectionFinish(object sender, MouseEventArgs e)
        {
            if (e.Button != this._selectButtons)
            {
                this.Refresh();
            }
            else
            {
                PointF ptF = this.BoundPointToRect(new Point(e.X, e.Y), this._dragPane.Chart._rect);
                PointF tf2 = this.BoundPointToRect(new Point(e.X, e.Y), this._dragPane.Rect);
                ((Control) sender).PointToScreen(Point.Round(tf2));
                if ((Math.Abs((float) (ptF.X - this._dragStartPt.X)) <= 4f) || (Math.Abs((float) (ptF.Y - this._dragStartPt.Y)) <= 4f))
                {
                    using (Graphics graphics = base.CreateGraphics())
                    {
                        int num13;
                        ZedGraph.GraphPane pane;
                        object obj2;
                        if (!this.MasterPane.FindNearestPaneObject(tf2, graphics, out pane, out obj2, out num13))
                        {
                            this._selection.ClearSelection(this._masterPane);
                        }
                        else
                        {
                            if (!(obj2 is CurveItem) || (num13 < 0))
                            {
                                this._selection.ClearSelection(this._masterPane);
                            }
                            else if (Control.ModifierKeys == this._selectAppendModifierKeys)
                            {
                                this._selection.AddToSelection(this._masterPane, obj2 as CurveItem);
                            }
                            else
                            {
                                this._selection.Select(this._masterPane, obj2 as CurveItem);
                            }
                            this.Refresh();
                        }
                    }
                }
                else
                {
                    double num;
                    double num2;
                    double num3;
                    double num4;
                    double[] numArray;
                    double[] numArray2;
                    double[] numArray3;
                    double[] numArray4;
                    ((Control) sender).PointToClient(new Point(Convert.ToInt32(this._dragPane.Rect.X), Convert.ToInt32(this._dragPane.Rect.Y)));
                    this._dragPane.ReverseTransform((PointF) this._dragStartPt, out num, out num3, out numArray, out numArray3);
                    this._dragPane.ReverseTransform(ptF, out num2, out num4, out numArray2, out numArray4);
                    CurveList containedObjs = new CurveList();
                    double num5 = Math.Min(num, num2);
                    double num6 = Math.Max(num, num2);
                    double num7 = 0.0;
                    double num8 = 0.0;
                    int index = 0;
                    while (true)
                    {
                        if (index >= numArray.Length)
                        {
                            int num10 = 0;
                            while (true)
                            {
                                if (num10 >= numArray3.Length)
                                {
                                    double num11 = num6 - num5;
                                    double num12 = num8 - num7;
                                    RectangleF rectF = new RectangleF((float) num5, (float) num7, (float) num11, (float) num12);
                                    this._dragPane.FindContainedObjects(rectF, base.CreateGraphics(), out containedObjs);
                                    if (Control.ModifierKeys == this._selectAppendModifierKeys)
                                    {
                                        this._selection.AddToSelection(this._masterPane, containedObjs);
                                    }
                                    else
                                    {
                                        this._selection.Select(this._masterPane, containedObjs);
                                    }
                                    break;
                                }
                                num8 = Math.Min(numArray3[num10], Math.Min(num8, numArray4[num10]));
                                num7 = Math.Max(numArray3[num10], Math.Max(num7, numArray4[num10]));
                                num10++;
                            }
                            break;
                        }
                        num8 = Math.Min(numArray[index], numArray2[index]);
                        num7 = Math.Max(numArray[index], numArray2[index]);
                        index++;
                    }
                }
                using (Graphics graphics2 = base.CreateGraphics())
                {
                    this._dragPane.AxisChange(graphics2);
                    foreach (ZedGraph.GraphPane pane2 in this._masterPane._paneList)
                    {
                        if (!ReferenceEquals(pane2, this._dragPane) && (this._isSynchronizeXAxes || this._isSynchronizeYAxes))
                        {
                            pane2.AxisChange(graphics2);
                        }
                    }
                }
                this.Refresh();
            }
        }

        private void HandleZoomCancel()
        {
            if (this._isZooming)
            {
                this._isZooming = false;
                this.Refresh();
                this.ZoomStateClear();
            }
        }

        private void HandleZoomDrag(Point mousePt)
        {
            ControlPaint.DrawReversibleFrame(this.CalcScreenRect(this._dragStartPt, this._dragEndPt), this.BackColor, FrameStyle.Dashed);
            this._dragEndPt = Point.Round(this.BoundPointToRect(mousePt, this._dragPane.Chart._rect));
            ControlPaint.DrawReversibleFrame(this.CalcScreenRect(this._dragStartPt, this._dragEndPt), this.BackColor, FrameStyle.Dashed);
        }

        private void HandleZoomFinish(object sender, MouseEventArgs e)
        {
            PointF ptF = this.BoundPointToRect(new Point(e.X, e.Y), this._dragPane.Chart._rect);
            if (((Math.Abs((float) (ptF.X - this._dragStartPt.X)) <= 4f) && this._isEnableHZoom) || ((Math.Abs((float) (ptF.Y - this._dragStartPt.Y)) <= 4f) && this._isEnableVZoom))
            {
                return;
            }
            else
            {
                double num;
                double num2;
                double num3;
                double num4;
                double[] numArray;
                double[] numArray2;
                double[] numArray3;
                double[] numArray4;
                this._dragPane.ReverseTransform((PointF) this._dragStartPt, out num, out num3, out numArray, out numArray3);
                this._dragPane.ReverseTransform(ptF, out num2, out num4, out numArray2, out numArray4);
                bool flag = false;
                if (this._isEnableHZoom)
                {
                    Math.Min(num, num2);
                    Math.Max(num, num2);
                    Math.Min(num3, num4);
                    Math.Max(num3, num4);
                    if ((Math.Abs((double) (num - num2)) < 1E-300) || (Math.Abs((double) (num3 - num4)) < 1E-300))
                    {
                        flag = true;
                    }
                }
                if (this._isEnableVZoom && !flag)
                {
                    int index = 0;
                    while (true)
                    {
                        if (index < numArray.Length)
                        {
                            if (Math.Abs((double) (numArray[index] - numArray2[index])) >= 1E-300)
                            {
                                index++;
                                continue;
                            }
                            flag = true;
                        }
                        for (int i = 0; i < numArray3.Length; i++)
                        {
                            if (Math.Abs((double) (numArray3[i] - numArray4[i])) < 1E-300)
                            {
                                flag = true;
                                break;
                            }
                        }
                        break;
                    }
                }
                if (!flag)
                {
                    this.ZoomStatePush(this._dragPane);
                    if (this._isEnableHZoom)
                    {
                        this._dragPane.XAxis._scale._min = Math.Min(num, num2);
                        this._dragPane.XAxis._scale._minAuto = false;
                        this._dragPane.XAxis._scale._max = Math.Max(num, num2);
                        this._dragPane.XAxis._scale._maxAuto = false;
                        this._dragPane.X2Axis._scale._min = Math.Min(num3, num4);
                        this._dragPane.X2Axis._scale._minAuto = false;
                        this._dragPane.X2Axis._scale._max = Math.Max(num3, num4);
                        this._dragPane.X2Axis._scale._maxAuto = false;
                    }
                    if (this._isEnableVZoom)
                    {
                        int index = 0;
                        while (true)
                        {
                            if (index >= numArray.Length)
                            {
                                for (int i = 0; i < numArray3.Length; i++)
                                {
                                    this._dragPane.Y2AxisList[i]._scale._min = Math.Min(numArray3[i], numArray4[i]);
                                    this._dragPane.Y2AxisList[i]._scale._max = Math.Max(numArray3[i], numArray4[i]);
                                    this._dragPane.Y2AxisList[i]._scale._minAuto = false;
                                    this._dragPane.Y2AxisList[i]._scale._maxAuto = false;
                                }
                                break;
                            }
                            this._dragPane.YAxisList[index]._scale._min = Math.Min(numArray[index], numArray2[index]);
                            this._dragPane.YAxisList[index]._scale._max = Math.Max(numArray[index], numArray2[index]);
                            this._dragPane.YAxisList[index]._scale._minAuto = false;
                            this._dragPane.YAxisList[index]._scale._maxAuto = false;
                            index++;
                        }
                    }
                    this.SetScroll(this.hScrollBar1, this._dragPane.XAxis, this._xScrollRange.Min, this._xScrollRange.Max);
                    this.SetScroll(this.vScrollBar1, this._dragPane.YAxis, this._yScrollRangeList[0].Min, this._yScrollRangeList[0].Max);
                    this.ApplyToAllPanes(this._dragPane);
                    if (this.ZoomEvent != null)
                    {
                        this.ZoomEvent(this, this._zoomState, new ZoomState(this._dragPane, ZoomState.StateType.Zoom));
                    }
                    using (Graphics graphics = base.CreateGraphics())
                    {
                        this._dragPane.AxisChange(graphics);
                        foreach (ZedGraph.GraphPane pane in this._masterPane._paneList)
                        {
                            if (!ReferenceEquals(pane, this._dragPane) && (this._isSynchronizeXAxes || this._isSynchronizeYAxes))
                            {
                                pane.AxisChange(graphics);
                            }
                        }
                    }
                }
            }
            this.Refresh();
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            if (this.GraphPane != null)
            {
                if (((e.Type != ScrollEventType.ThumbPosition) && (e.Type != ScrollEventType.ThumbTrack)) || ((e.Type == ScrollEventType.ThumbTrack) && (this._zoomState == null)))
                {
                    this.ZoomStateSave(this.GraphPane, ZoomState.StateType.Scroll);
                }
                this.HandleScroll(this.GraphPane.XAxis, e.NewValue, this._xScrollRange.Min, this._xScrollRange.Max, this.hScrollBar1.LargeChange, this.GraphPane.XAxis.Scale.IsReverse);
                this.ApplyToAllPanes(this.GraphPane);
                this.ProcessEventStuff(this.hScrollBar1, e);
            }
        }

        private Image ImageRender() => 
            this._masterPane.GetImage(this._masterPane.IsAntiAlias);

        private void InitializeComponent()
        {
            this.components = new Container();
            this.vScrollBar1 = new VScrollBar();
            this.hScrollBar1 = new HScrollBar();
            this.pointToolTip = new ToolTip(this.components);
            this.contextMenuStrip1 = new ContextMenuStrip(this.components);
            base.SuspendLayout();
            this.vScrollBar1.Location = new Point(0x80, 0);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new Size(0x11, 0x80);
            this.vScrollBar1.TabIndex = 0;
            this.vScrollBar1.Scroll += new ScrollEventHandler(this.vScrollBar1_Scroll);
            this.hScrollBar1.Location = new Point(0, 0x80);
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new Size(0x80, 0x11);
            this.hScrollBar1.TabIndex = 1;
            this.hScrollBar1.Scroll += new ScrollEventHandler(this.hScrollBar1_Scroll);
            this.pointToolTip.AutoPopDelay = 0x1388;
            this.pointToolTip.InitialDelay = 100;
            this.pointToolTip.ReshowDelay = 0;
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new Size(0x3d, 4);
            this.contextMenuStrip1.Opening += new CancelEventHandler(this.contextMenuStrip1_Opening);
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.ContextMenuStrip = this.contextMenuStrip1;
            base.Controls.Add(this.hScrollBar1);
            base.Controls.Add(this.vScrollBar1);
            base.Name = "ZedGraphControl";
            base.Resize += new EventHandler(this.ZedGraphControl_ReSize);
            base.KeyUp += new KeyEventHandler(this.ZedGraphControl_KeyUp);
            base.KeyDown += new KeyEventHandler(this.ZedGraphControl_KeyDown);
            base.MouseWheel += new MouseEventHandler(this.ZedGraphControl_MouseWheel);
            base.ResumeLayout(false);
        }

        protected string MakeValueLabel(Axis axis, double val, int iPt, bool isOverrideOrdinal)
        {
            if (axis == null)
            {
                return "";
            }
            if (axis.Scale.IsDate || (axis.Scale.Type == AxisType.DateAsOrdinal))
            {
                return XDate.ToString(val, this._pointDateFormat);
            }
            if (!axis._scale.IsText || (axis._scale._textLabels == null))
            {
                return ((!axis.Scale.IsAnyOrdinal || ((axis.Scale.Type == AxisType.LinearAsOrdinal) || isOverrideOrdinal)) ? val.ToString(this._pointValueFormat) : iPt.ToString(this._pointValueFormat));
            }
            int index = iPt;
            if (isOverrideOrdinal)
            {
                index = (int) (val - 0.5);
            }
            return (((index < 0) || (index >= axis._scale._textLabels.Length)) ? (index + 1).ToString() : axis._scale._textLabels[index]);
        }

        protected void MenuClick_Copy(object sender, EventArgs e)
        {
            this.Copy(this._isShowCopyMessage);
        }

        protected void MenuClick_PageSetup(object sender, EventArgs e)
        {
            this.DoPageSetup();
        }

        protected void MenuClick_Print(object sender, EventArgs e)
        {
            this.DoPrint();
        }

        protected void MenuClick_RestoreScale(object sender, EventArgs e)
        {
            if (this._masterPane != null)
            {
                ZedGraph.GraphPane primaryPane = this._masterPane.FindPane((PointF) this._menuClickPt);
                this.RestoreScale(primaryPane);
            }
        }

        protected void MenuClick_SaveAs(object sender, EventArgs e)
        {
            this.SaveAs();
        }

        protected void MenuClick_ShowValues(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item != null)
            {
                this.IsShowPointValues = !item.Checked;
            }
        }

        protected void MenuClick_ZoomOut(object sender, EventArgs e)
        {
            if (this._masterPane != null)
            {
                ZedGraph.GraphPane primaryPane = this._masterPane.FindPane((PointF) this._menuClickPt);
                this.ZoomOut(primaryPane);
            }
        }

        protected void MenuClick_ZoomOutAll(object sender, EventArgs e)
        {
            if (this._masterPane != null)
            {
                ZedGraph.GraphPane primaryPane = this._masterPane.FindPane((PointF) this._menuClickPt);
                this.ZoomOutAll(primaryPane);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            lock (this)
            {
                if ((!this.BeenDisposed && (this._masterPane != null)) && (this.GraphPane != null))
                {
                    if ((this.hScrollBar1 != null) && ((this.GraphPane != null) && ((this.vScrollBar1 != null) && (this._yScrollRangeList != null))))
                    {
                        this.SetScroll(this.hScrollBar1, this.GraphPane.XAxis, this._xScrollRange.Min, this._xScrollRange.Max);
                        this.SetScroll(this.vScrollBar1, this.GraphPane.YAxis, this._yScrollRangeList[0].Min, this._yScrollRangeList[0].Max);
                    }
                    base.OnPaint(e);
                    try
                    {
                        this._masterPane.Draw(e.Graphics);
                    }
                    catch
                    {
                    }
                }
            }
        }

        protected void PanScale(Axis axis, double startVal, double endVal)
        {
            if (axis != null)
            {
                Scale scale = axis._scale;
                double num = scale.Linearize(startVal) - scale.Linearize(endVal);
                scale._minLinearized += num;
                scale._maxLinearized += num;
                scale._minAuto = false;
                scale._maxAuto = false;
            }
        }

        private void ProcessEventStuff(ScrollBar scrollBar, ScrollEventArgs e)
        {
            if (e.Type == ScrollEventType.ThumbTrack)
            {
                if (this.ScrollProgressEvent != null)
                {
                    this.ScrollProgressEvent(this, this.hScrollBar1, this._zoomState, new ZoomState(this.GraphPane, ZoomState.StateType.Scroll));
                }
            }
            else if ((this._zoomState != null) && this._zoomState.IsChanged(this.GraphPane))
            {
                this.ZoomStatePush(this.GraphPane);
                if (this.ScrollDoneEvent != null)
                {
                    this.ScrollDoneEvent(this, this.hScrollBar1, this._zoomState, new ZoomState(this.GraphPane, ZoomState.StateType.Scroll));
                }
                this._zoomState = null;
            }
            if (this.ScrollEvent != null)
            {
                this.ScrollEvent(scrollBar, e);
            }
        }

        private void ResetAutoScale(ZedGraph.GraphPane pane, Graphics g)
        {
            pane.XAxis.ResetAutoScale(pane, g);
            pane.X2Axis.ResetAutoScale(pane, g);
            foreach (YAxis axis in pane.YAxisList)
            {
                axis.ResetAutoScale(pane, g);
            }
            foreach (Y2Axis axis2 in pane.Y2AxisList)
            {
                axis2.ResetAutoScale(pane, g);
            }
        }

        public void RestoreScale(ZedGraph.GraphPane primaryPane)
        {
            if (primaryPane != null)
            {
                ZoomState oldState = new ZoomState(primaryPane, ZoomState.StateType.Zoom);
                using (Graphics graphics = base.CreateGraphics())
                {
                    if (!this._isSynchronizeXAxes && !this._isSynchronizeYAxes)
                    {
                        primaryPane.ZoomStack.Push(primaryPane, ZoomState.StateType.Zoom);
                        this.ResetAutoScale(primaryPane, graphics);
                    }
                    else
                    {
                        foreach (ZedGraph.GraphPane pane in this._masterPane._paneList)
                        {
                            pane.ZoomStack.Push(pane, ZoomState.StateType.Zoom);
                            this.ResetAutoScale(pane, graphics);
                        }
                    }
                    if (this.ZoomEvent != null)
                    {
                        this.ZoomEvent(this, oldState, new ZoomState(primaryPane, ZoomState.StateType.Zoom));
                    }
                }
                this.Refresh();
            }
        }

        public void SaveAs()
        {
            this.SaveAs(null);
        }

        public string SaveAs(string DefaultFileName)
        {
            if (this._masterPane != null)
            {
                this._saveFileDialog.Filter = "Emf Format (*.emf)|*.emf|PNG Format (*.png)|*.png|Gif Format (*.gif)|*.gif|Jpeg Format (*.jpg)|*.jpg|Tiff Format (*.tif)|*.tif|Bmp Format (*.bmp)|*.bmp";
                if ((DefaultFileName != null) && (DefaultFileName.Length > 0))
                {
                    string str = Path.GetExtension(DefaultFileName).ToLower();
                    string key = str;
                    if (key != null)
                    {
                        int num;
                        if (<PrivateImplementationDetails>{F28C4C3A-A9AB-447C-B286-C57DAFAB4300}.$$method0x60000cf-1 == null)
                        {
                            Dictionary<string, int> dictionary1 = new Dictionary<string, int>(8);
                            dictionary1.Add(".emf", 0);
                            dictionary1.Add(".png", 1);
                            dictionary1.Add(".gif", 2);
                            dictionary1.Add(".jpeg", 3);
                            dictionary1.Add(".jpg", 4);
                            dictionary1.Add(".tiff", 5);
                            dictionary1.Add(".tif", 6);
                            dictionary1.Add(".bmp", 7);
                            <PrivateImplementationDetails>{F28C4C3A-A9AB-447C-B286-C57DAFAB4300}.$$method0x60000cf-1 = dictionary1;
                        }
                        if (<PrivateImplementationDetails>{F28C4C3A-A9AB-447C-B286-C57DAFAB4300}.$$method0x60000cf-1.TryGetValue(key, out num))
                        {
                            switch (num)
                            {
                                case 0:
                                    this._saveFileDialog.FilterIndex = 1;
                                    break;

                                case 1:
                                    this._saveFileDialog.FilterIndex = 2;
                                    break;

                                case 2:
                                    this._saveFileDialog.FilterIndex = 3;
                                    break;

                                case 3:
                                case 4:
                                    this._saveFileDialog.FilterIndex = 4;
                                    break;

                                case 5:
                                case 6:
                                    this._saveFileDialog.FilterIndex = 5;
                                    break;

                                case 7:
                                    this._saveFileDialog.FilterIndex = 6;
                                    break;

                                default:
                                    break;
                            }
                        }
                    }
                    if (DefaultFileName.Length > str.Length)
                    {
                        this._saveFileDialog.FileName = DefaultFileName;
                    }
                }
                if (this._saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Stream stream = this._saveFileDialog.OpenFile();
                    if (stream != null)
                    {
                        if (this._saveFileDialog.FilterIndex == 1)
                        {
                            stream.Close();
                            this.SaveEmfFile(this._saveFileDialog.FileName);
                        }
                        else
                        {
                            ImageFormat png = ImageFormat.Png;
                            switch (this._saveFileDialog.FilterIndex)
                            {
                                case 2:
                                    png = ImageFormat.Png;
                                    break;

                                case 3:
                                    png = ImageFormat.Gif;
                                    break;

                                case 4:
                                    png = ImageFormat.Jpeg;
                                    break;

                                case 5:
                                    png = ImageFormat.Tiff;
                                    break;

                                case 6:
                                    png = ImageFormat.Bmp;
                                    break;

                                default:
                                    break;
                            }
                            this.ImageRender().Save(stream, png);
                            stream.Close();
                        }
                        return this._saveFileDialog.FileName;
                    }
                }
            }
            return "";
        }

        public void SaveAsBitmap()
        {
            if (this._masterPane != null)
            {
                this._saveFileDialog.Filter = "PNG Format (*.png)|*.png|Gif Format (*.gif)|*.gif|Jpeg Format (*.jpg)|*.jpg|Tiff Format (*.tif)|*.tif|Bmp Format (*.bmp)|*.bmp";
                if (this._saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ImageFormat png = ImageFormat.Png;
                    if (this._saveFileDialog.FilterIndex == 2)
                    {
                        png = ImageFormat.Gif;
                    }
                    else if (this._saveFileDialog.FilterIndex == 3)
                    {
                        png = ImageFormat.Jpeg;
                    }
                    else if (this._saveFileDialog.FilterIndex == 4)
                    {
                        png = ImageFormat.Tiff;
                    }
                    else if (this._saveFileDialog.FilterIndex == 5)
                    {
                        png = ImageFormat.Bmp;
                    }
                    Stream stream = this._saveFileDialog.OpenFile();
                    if (stream != null)
                    {
                        this.ImageRender().Save(stream, png);
                        stream.Close();
                    }
                }
            }
        }

        public void SaveAsEmf()
        {
            if (this._masterPane != null)
            {
                this._saveFileDialog.Filter = "Emf Format (*.emf)|*.emf";
                if (this._saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Stream stream = this._saveFileDialog.OpenFile();
                    if (stream != null)
                    {
                        stream.Close();
                        this.SaveEmfFile(this._saveFileDialog.FileName);
                    }
                }
            }
        }

        internal void SaveEmfFile(string fileName)
        {
            using (Graphics graphics = base.CreateGraphics())
            {
                IntPtr hdc = graphics.GetHdc();
                Metafile image = new Metafile(hdc, EmfType.EmfPlusOnly);
                using (Graphics graphics2 = Graphics.FromImage(image))
                {
                    this._masterPane.Draw(graphics2);
                }
                ClipboardMetafileHelper.SaveEnhMetafileToFile(image, fileName);
                graphics.ReleaseHdc(hdc);
            }
        }

        protected void SetCursor()
        {
            this.SetCursor(base.PointToClient(Control.MousePosition));
        }

        protected void SetCursor(Point mousePt)
        {
            if (this._masterPane != null)
            {
                ZedGraph.GraphPane pane = this._masterPane.FindChartRect((PointF) mousePt);
                if (((this._isEnableHPan || this._isEnableVPan) && ((Control.ModifierKeys == Keys.Shift) || this._isPanning)) && ((pane != null) || this._isPanning))
                {
                    this.Cursor = Cursors.Hand;
                }
                else if ((this._isEnableVZoom || this._isEnableHZoom) && ((pane != null) || this._isZooming))
                {
                    this.Cursor = Cursors.Cross;
                }
                else if (this._isEnableSelection && ((pane != null) || this._isSelecting))
                {
                    this.Cursor = Cursors.Cross;
                }
                else
                {
                    this.Cursor = Cursors.Default;
                }
            }
        }

        private void SetScroll(ScrollBar scrollBar, Axis axis, double scrollMin, double scrollMax)
        {
            if ((scrollBar != null) && (axis != null))
            {
                scrollBar.Minimum = 0;
                scrollBar.Maximum = 0x7ffffffe;
                if (scrollMin > axis._scale._min)
                {
                    scrollMin = axis._scale._min;
                }
                if (scrollMax < axis._scale._max)
                {
                    scrollMax = axis._scale._max;
                }
                int minimum = 0;
                Scale scale = axis._scale;
                double num2 = scale._minLinearized;
                double num3 = scale._maxLinearized;
                scrollMin = scale.Linearize(scrollMin);
                scrollMax = scale.Linearize(scrollMax);
                double num4 = scrollMax - (num3 - num2);
                if (scrollMin >= num4)
                {
                    scrollBar.Enabled = false;
                    scrollBar.Value = 0;
                }
                else
                {
                    int num6 = (int) ((((num3 - num2) / (scrollMax - scrollMin)) * 2147483647.0) + 0.5);
                    if (num6 < 1)
                    {
                        num6 = 1;
                    }
                    scrollBar.LargeChange = num6;
                    int num7 = num6 / 10;
                    if (num7 < 1)
                    {
                        num7 = 1;
                    }
                    scrollBar.SmallChange = num7;
                    int num8 = 0x7fffffff - num6;
                    minimum = (int) ((((num2 - scrollMin) / (num4 - scrollMin)) * num8) + 0.5);
                    if (minimum < 0)
                    {
                        minimum = 0;
                    }
                    else if (minimum > num8)
                    {
                        minimum = num8;
                    }
                    if ((axis is XAxis) == axis.Scale.IsReverse)
                    {
                        minimum = num8 - minimum;
                    }
                    if (minimum < scrollBar.Minimum)
                    {
                        minimum = scrollBar.Minimum;
                    }
                    if (minimum > scrollBar.Maximum)
                    {
                        minimum = scrollBar.Maximum;
                    }
                    scrollBar.Value = minimum;
                    scrollBar.Enabled = true;
                }
            }
        }

        public void SetScrollRangeFromData()
        {
            if (this.GraphPane != null)
            {
                double num = this.CalcScrollGrace(this.GraphPane.XAxis.Scale._rangeMin, this.GraphPane.XAxis.Scale._rangeMax);
                this._xScrollRange.Min = this.GraphPane.XAxis.Scale._rangeMin - num;
                this._xScrollRange.Max = this.GraphPane.XAxis.Scale._rangeMax + num;
                this._xScrollRange.IsScrollable = true;
                int num2 = 0;
                while (true)
                {
                    if (num2 >= this.GraphPane.YAxisList.Count)
                    {
                        for (int i = 0; i < this.GraphPane.Y2AxisList.Count; i++)
                        {
                            Axis axis2 = this.GraphPane.Y2AxisList[i];
                            num = this.CalcScrollGrace(axis2.Scale._rangeMin, axis2.Scale._rangeMax);
                            ScrollRange range4 = this._y2ScrollRangeList[i];
                            ScrollRange range2 = new ScrollRange(axis2.Scale._rangeMin - num, axis2.Scale._rangeMax + num, range4.IsScrollable);
                            if (i >= this._y2ScrollRangeList.Count)
                            {
                                this._y2ScrollRangeList.Add(range2);
                            }
                            else
                            {
                                this._y2ScrollRangeList[i] = range2;
                            }
                        }
                        break;
                    }
                    Axis axis = this.GraphPane.YAxisList[num2];
                    num = this.CalcScrollGrace(axis.Scale._rangeMin, axis.Scale._rangeMax);
                    ScrollRange range3 = this._yScrollRangeList[num2];
                    ScrollRange item = new ScrollRange(axis.Scale._rangeMin - num, axis.Scale._rangeMax + num, range3.IsScrollable);
                    if (num2 >= this._yScrollRangeList.Count)
                    {
                        this._yScrollRangeList.Add(item);
                    }
                    else
                    {
                        this._yScrollRangeList[num2] = item;
                    }
                    num2++;
                }
            }
        }

        private void Synchronize(Axis source, Axis dest)
        {
            dest._scale._min = source._scale._min;
            dest._scale._max = source._scale._max;
            dest._scale._majorStep = source._scale._majorStep;
            dest._scale._minorStep = source._scale._minorStep;
            dest._scale._minAuto = source._scale._minAuto;
            dest._scale._maxAuto = source._scale._maxAuto;
            dest._scale._majorStepAuto = source._scale._majorStepAuto;
            dest._scale._minorStepAuto = source._scale._minorStepAuto;
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            if (this.GraphPane != null)
            {
                if (((e.Type != ScrollEventType.ThumbPosition) && (e.Type != ScrollEventType.ThumbTrack)) || ((e.Type == ScrollEventType.ThumbTrack) && (this._zoomState == null)))
                {
                    this.ZoomStateSave(this.GraphPane, ZoomState.StateType.Scroll);
                }
                int num = 0;
                while (true)
                {
                    if (num >= this.GraphPane.YAxisList.Count)
                    {
                        int num2 = 0;
                        while (true)
                        {
                            if (num2 >= this.GraphPane.Y2AxisList.Count)
                            {
                                this.ApplyToAllPanes(this.GraphPane);
                                this.ProcessEventStuff(this.vScrollBar1, e);
                                break;
                            }
                            ScrollRange range2 = this._y2ScrollRangeList[num2];
                            if (range2.IsScrollable)
                            {
                                Axis axis = this.GraphPane.Y2AxisList[num2];
                                this.HandleScroll(axis, e.NewValue, range2.Min, range2.Max, this.vScrollBar1.LargeChange, !axis.Scale.IsReverse);
                            }
                            num2++;
                        }
                        break;
                    }
                    ScrollRange range = this._yScrollRangeList[num];
                    if (range.IsScrollable)
                    {
                        Axis axis = this.GraphPane.YAxisList[num];
                        this.HandleScroll(axis, e.NewValue, range.Min, range.Max, this.vScrollBar1.LargeChange, !axis.Scale.IsReverse);
                    }
                    num++;
                }
            }
        }

        protected void ZedGraphControl_KeyDown(object sender, KeyEventArgs e)
        {
            this.SetCursor();
            if (e.KeyCode == Keys.Escape)
            {
                if (this._isPanning)
                {
                    this.HandlePanCancel();
                }
                if (this._isZooming)
                {
                    this.HandleZoomCancel();
                }
                if (this._isEditing)
                {
                    this.HandleEditCancel();
                }
                this.HandleSelectionCancel();
                this._isZooming = false;
                this._isPanning = false;
                this._isEditing = false;
                this._isSelecting = false;
                this.Refresh();
            }
        }

        protected void ZedGraphControl_KeyUp(object sender, KeyEventArgs e)
        {
            this.SetCursor();
        }

        protected void ZedGraphControl_MouseDown(object sender, MouseEventArgs e)
        {
            this._isPanning = false;
            this._isZooming = false;
            this._isEditing = false;
            this._isSelecting = false;
            this._dragPane = null;
            Point point = new Point(e.X, e.Y);
            if ((((this._masterPane == null) || ((e.Clicks <= 1) || ((this.DoubleClickEvent == null) || !this.DoubleClickEvent(this, e)))) && ((this._masterPane == null) || ((this.MouseDownEvent == null) || !this.MouseDownEvent(this, e)))) && ((e.Clicks <= 1) && (this._masterPane != null)))
            {
                ZedGraph.GraphPane pane = this.MasterPane.FindPane((PointF) point);
                if ((pane != null) && ((e.Button == this._linkButtons) && (Control.ModifierKeys == this._linkModifierKeys)))
                {
                    using (Graphics graphics = base.CreateGraphics())
                    {
                        object obj2;
                        ZedGraph.Link link;
                        int num;
                        if (pane.FindLinkableObject((PointF) point, graphics, pane.CalcScaleFactor(), out obj2, out link, out num))
                        {
                            if ((this.LinkEvent == null) || !this.LinkEvent(this, pane, obj2, link, num))
                            {
                                CurveItem curve = obj2 as CurveItem;
                                string fileName = (curve == null) ? link._url : link.MakeCurveItemUrl(pane, curve, num);
                                if (fileName != string.Empty)
                                {
                                    Process.Start(fileName);
                                    return;
                                }
                            }
                            else
                            {
                                return;
                            }
                        }
                    }
                }
                pane = this.MasterPane.FindChartRect((PointF) point);
                if (((pane != null) && (this._isEnableHPan || this._isEnableVPan)) && (((e.Button == this._panButtons) && (Control.ModifierKeys == this._panModifierKeys)) || ((e.Button == this._panButtons2) && (Control.ModifierKeys == this._panModifierKeys2))))
                {
                    this._isPanning = true;
                    this._dragStartPt = point;
                    this._dragPane = pane;
                    this.ZoomStateSave(this._dragPane, ZoomState.StateType.Pan);
                }
                else if (((pane != null) && (this._isEnableHZoom || this._isEnableVZoom)) && (((e.Button == this._zoomButtons) && (Control.ModifierKeys == this._zoomModifierKeys)) || ((e.Button == this._zoomButtons2) && (Control.ModifierKeys == this._zoomModifierKeys2))))
                {
                    this._isZooming = true;
                    this._dragStartPt = point;
                    this._dragEndPt = point;
                    this._dragEndPt.Offset(1, 1);
                    this._dragPane = pane;
                    this.ZoomStateSave(this._dragPane, ZoomState.StateType.Zoom);
                }
                else if ((pane != null) && (this._isEnableSelection && ((e.Button == this._selectButtons) && ((Control.ModifierKeys == this._selectModifierKeys) || (Control.ModifierKeys == this._selectAppendModifierKeys)))))
                {
                    this._isSelecting = true;
                    this._dragStartPt = point;
                    this._dragEndPt = point;
                    this._dragEndPt.Offset(1, 1);
                    this._dragPane = pane;
                }
                else if (((pane != null) && (this._isEnableHEdit || this._isEnableVEdit)) && ((e.Button == this.EditButtons) && ((Control.ModifierKeys == this.EditModifierKeys) && (pane.FindNearestPoint((PointF) point, out this._dragCurve, out this._dragIndex) && (this._dragCurve.Points is IPointListEdit)))))
                {
                    this._isEditing = true;
                    this._dragPane = pane;
                    this._dragStartPt = point;
                    this._dragStartPair = this._dragCurve[this._dragIndex];
                }
            }
        }

        protected void ZedGraphControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (this._masterPane != null)
            {
                Point mousePt = new Point(e.X, e.Y);
                if ((this.MouseMoveEvent == null) || !this.MouseMoveEvent(this, e))
                {
                    this.SetCursor(mousePt);
                    if (this._isZooming)
                    {
                        this.HandleZoomDrag(mousePt);
                    }
                    else if (this._isPanning)
                    {
                        this.HandlePanDrag(mousePt);
                    }
                    else if (this._isEditing)
                    {
                        this.HandleEditDrag(mousePt);
                    }
                    else if (this._isShowCursorValues)
                    {
                        this.HandleCursorValues(mousePt);
                    }
                    else if (this._isShowPointValues)
                    {
                        this.HandlePointValues(mousePt);
                    }
                    else if (this._isSelecting)
                    {
                        this.HandleZoomDrag(mousePt);
                    }
                }
            }
        }

        protected void ZedGraphControl_MouseUp(object sender, MouseEventArgs e)
        {
            if ((this._masterPane == null) || ((this.MouseUpEvent == null) || !this.MouseUpEvent(this, e)))
            {
                if ((this._masterPane != null) && (this._dragPane != null))
                {
                    if (this._isZooming)
                    {
                        this.HandleZoomFinish(sender, e);
                    }
                    else if (this._isPanning)
                    {
                        this.HandlePanFinish();
                    }
                    else if (this._isEditing)
                    {
                        this.HandleEditFinish();
                    }
                    else if (this._isSelecting)
                    {
                        this.HandleSelectionFinish(sender, e);
                    }
                }
                this._dragPane = null;
                this._isZooming = false;
                this._isPanning = false;
                this._isEditing = false;
                this._isSelecting = false;
                Cursor.Current = Cursors.Default;
            }
        }

        protected void ZedGraphControl_MouseWheel(object sender, MouseEventArgs e)
        {
            ZedGraph.GraphPane pane;
            ZoomState state;
            if ((!this._isEnableVZoom && !this._isEnableHZoom) || (!this._isEnableWheelZoom || (this._masterPane == null)))
            {
                return;
            }
            else
            {
                pane = this.MasterPane.FindChartRect(new PointF((float) e.X, (float) e.Y));
                if ((pane == null) || (e.Delta == 0))
                {
                    return;
                }
                else
                {
                    state = this.ZoomStateSave(pane, ZoomState.StateType.WheelZoom);
                    PointF centerPt = new PointF((float) e.X, (float) e.Y);
                    this.ZoomPane(pane, 1.0 + (((e.Delta < 0) ? 1.0 : -1.0) * this.ZoomStepFraction), centerPt, this._isZoomOnMouseCenter, false);
                    this.ApplyToAllPanes(pane);
                    using (Graphics graphics = base.CreateGraphics())
                    {
                        pane.AxisChange(graphics);
                        foreach (ZedGraph.GraphPane pane2 in this._masterPane._paneList)
                        {
                            if (!ReferenceEquals(pane2, pane) && (this._isSynchronizeXAxes || this._isSynchronizeYAxes))
                            {
                                pane2.AxisChange(graphics);
                            }
                        }
                    }
                }
            }
            this.ZoomStatePush(pane);
            if (this.ZoomEvent != null)
            {
                this.ZoomEvent(this, state, new ZoomState(pane, ZoomState.StateType.WheelZoom));
            }
            this.Refresh();
        }

        protected unsafe void ZedGraphControl_ReSize(object sender, EventArgs e)
        {
            lock (this)
            {
                if (!this.BeenDisposed && (this._masterPane != null))
                {
                    Size size = base.Size;
                    if (!this._isShowHScrollBar)
                    {
                        this.hScrollBar1.Visible = false;
                    }
                    else
                    {
                        this.hScrollBar1.Visible = true;
                        Size* sizePtr1 = &size;
                        sizePtr1.Height -= this.hScrollBar1.Size.Height;
                        this.hScrollBar1.Location = new Point(0, size.Height);
                        this.hScrollBar1.Size = new Size(size.Width, this.hScrollBar1.Height);
                    }
                    if (!this._isShowVScrollBar)
                    {
                        this.vScrollBar1.Visible = false;
                    }
                    else
                    {
                        this.vScrollBar1.Visible = true;
                        Size* sizePtr2 = &size;
                        sizePtr2.Width -= this.vScrollBar1.Size.Width;
                        this.vScrollBar1.Location = new Point(size.Width, 0);
                        this.vScrollBar1.Size = new Size(this.vScrollBar1.Width, size.Height);
                    }
                    using (Graphics graphics = base.CreateGraphics())
                    {
                        this._masterPane.ReSize(graphics, new RectangleF(0f, 0f, (float) size.Width, (float) size.Height));
                    }
                    base.Invalidate();
                }
            }
        }

        public void ZoomOut(ZedGraph.GraphPane primaryPane)
        {
            if ((primaryPane != null) && !primaryPane.ZoomStack.IsEmpty)
            {
                ZoomState.StateType type = primaryPane.ZoomStack.Top.Type;
                ZoomState oldState = new ZoomState(primaryPane, type);
                ZoomState newState = null;
                if (!this._isSynchronizeXAxes && !this._isSynchronizeYAxes)
                {
                    newState = primaryPane.ZoomStack.Pop(primaryPane);
                }
                else
                {
                    foreach (ZedGraph.GraphPane pane in this._masterPane._paneList)
                    {
                        ZoomState state3 = pane.ZoomStack.Pop(pane);
                        if (ReferenceEquals(pane, primaryPane))
                        {
                            newState = state3;
                        }
                    }
                }
                if (this.ZoomEvent != null)
                {
                    this.ZoomEvent(this, oldState, newState);
                }
                this.Refresh();
            }
        }

        public void ZoomOutAll(ZedGraph.GraphPane primaryPane)
        {
            if ((primaryPane != null) && !primaryPane.ZoomStack.IsEmpty)
            {
                ZoomState.StateType type = primaryPane.ZoomStack.Top.Type;
                ZoomState oldState = new ZoomState(primaryPane, type);
                ZoomState newState = null;
                if (!this._isSynchronizeXAxes && !this._isSynchronizeYAxes)
                {
                    newState = primaryPane.ZoomStack.PopAll(primaryPane);
                }
                else
                {
                    foreach (ZedGraph.GraphPane pane in this._masterPane._paneList)
                    {
                        ZoomState state3 = pane.ZoomStack.PopAll(pane);
                        if (ReferenceEquals(pane, primaryPane))
                        {
                            newState = state3;
                        }
                    }
                }
                if (this.ZoomEvent != null)
                {
                    this.ZoomEvent(this, oldState, newState);
                }
                this.Refresh();
            }
        }

        public void ZoomPane(ZedGraph.GraphPane pane, double zoomFraction, PointF centerPt, bool isZoomOnCenter)
        {
            this.ZoomPane(pane, zoomFraction, centerPt, isZoomOnCenter, true);
        }

        protected void ZoomPane(ZedGraph.GraphPane pane, double zoomFraction, PointF centerPt, bool isZoomOnCenter, bool isRefresh)
        {
            double num;
            double num2;
            double[] numArray;
            double[] numArray2;
            pane.ReverseTransform(centerPt, out num, out num2, out numArray, out numArray2);
            if (this._isEnableHZoom)
            {
                this.ZoomScale(pane.XAxis, zoomFraction, num, isZoomOnCenter);
                this.ZoomScale(pane.X2Axis, zoomFraction, num2, isZoomOnCenter);
            }
            if (this._isEnableVZoom)
            {
                int index = 0;
                while (true)
                {
                    if (index >= pane.YAxisList.Count)
                    {
                        for (int i = 0; i < pane.Y2AxisList.Count; i++)
                        {
                            this.ZoomScale(pane.Y2AxisList[i], zoomFraction, numArray2[i], isZoomOnCenter);
                        }
                        break;
                    }
                    this.ZoomScale(pane.YAxisList[index], zoomFraction, numArray[index], isZoomOnCenter);
                    index++;
                }
            }
            using (Graphics graphics = base.CreateGraphics())
            {
                pane.AxisChange(graphics);
            }
            this.SetScroll(this.hScrollBar1, pane.XAxis, this._xScrollRange.Min, this._xScrollRange.Max);
            this.SetScroll(this.vScrollBar1, pane.YAxis, this._yScrollRangeList[0].Min, this._yScrollRangeList[0].Max);
            if (isRefresh)
            {
                this.Refresh();
            }
        }

        protected void ZoomScale(Axis axis, double zoomFraction, double centerVal, bool isZoomOnCenter)
        {
            if ((axis != null) && ((zoomFraction > 0.0001) && (zoomFraction < 1000.0)))
            {
                Scale scale1 = axis._scale;
                double num = axis._scale._minLinearized;
                double num2 = axis._scale._maxLinearized;
                double num3 = ((num2 - num) * zoomFraction) / 2.0;
                if (!isZoomOnCenter)
                {
                    centerVal = (num2 + num) / 2.0;
                }
                axis._scale._minLinearized = centerVal - num3;
                axis._scale._maxLinearized = centerVal + num3;
                axis._scale._minAuto = false;
                axis._scale._maxAuto = false;
            }
        }

        private void ZoomStateClear()
        {
            this._zoomStateStack.Clear();
            this._zoomState = null;
        }

        private void ZoomStatePurge()
        {
            foreach (ZedGraph.GraphPane pane in this._masterPane._paneList)
            {
                pane.ZoomStack.Clear();
            }
        }

        private void ZoomStatePush(ZedGraph.GraphPane primaryPane)
        {
            if (!this._isSynchronizeXAxes && !this._isSynchronizeYAxes)
            {
                if (this._zoomState != null)
                {
                    primaryPane.ZoomStack.Add(this._zoomState);
                }
            }
            else
            {
                for (int i = 0; i < this._masterPane._paneList.Count; i++)
                {
                    if (i < this._zoomStateStack.Count)
                    {
                        this._masterPane._paneList[i].ZoomStack.Add(this._zoomStateStack[i]);
                    }
                }
            }
            this.ZoomStateClear();
        }

        private void ZoomStateRestore(ZedGraph.GraphPane primaryPane)
        {
            if (!this._isSynchronizeXAxes && !this._isSynchronizeYAxes)
            {
                if (this._zoomState != null)
                {
                    this._zoomState.ApplyState(primaryPane);
                }
            }
            else
            {
                for (int i = 0; i < this._masterPane._paneList.Count; i++)
                {
                    if (i < this._zoomStateStack.Count)
                    {
                        this._zoomStateStack[i].ApplyState(this._masterPane._paneList[i]);
                    }
                }
            }
            this.ZoomStateClear();
        }

        private ZoomState ZoomStateSave(ZedGraph.GraphPane primaryPane, ZoomState.StateType type)
        {
            this.ZoomStateClear();
            if (!this._isSynchronizeXAxes && !this._isSynchronizeYAxes)
            {
                this._zoomState = new ZoomState(primaryPane, type);
            }
            else
            {
                foreach (ZedGraph.GraphPane pane in this._masterPane._paneList)
                {
                    ZoomState item = new ZoomState(pane, type);
                    if (ReferenceEquals(pane, primaryPane))
                    {
                        this._zoomState = item;
                    }
                    this._zoomStateStack.Add(item);
                }
            }
            return this._zoomState;
        }

        [NotifyParentProperty(true), Bindable(true), Category("Display"), Description("Determines which mouse button is used as the primary for zooming"), DefaultValue(0x100000)]
        public MouseButtons ZoomButtons
        {
            get => 
                this._zoomButtons;
            set => 
                this._zoomButtons = value;
        }

        [Description("Determines which mouse button is used as the secondary for zooming"), NotifyParentProperty(true), Bindable(true), Category("Display"), DefaultValue(0)]
        public MouseButtons ZoomButtons2
        {
            get => 
                this._zoomButtons2;
            set => 
                this._zoomButtons2 = value;
        }

        [NotifyParentProperty(true), Bindable(true), Description("Determines which modifier key used as the primary for zooming"), Category("Display"), DefaultValue(0)]
        public Keys ZoomModifierKeys
        {
            get => 
                this._zoomModifierKeys;
            set => 
                this._zoomModifierKeys = value;
        }

        [Category("Display"), DefaultValue(0), NotifyParentProperty(true), Bindable(true), Description("Determines which modifier key used as the secondary for zooming")]
        public Keys ZoomModifierKeys2
        {
            get => 
                this._zoomModifierKeys2;
            set => 
                this._zoomModifierKeys2 = value;
        }

        [NotifyParentProperty(true), Bindable(true), Category("Display"), Description("Determines which mouse button is used as the primary for panning"), DefaultValue(0x100000)]
        public MouseButtons PanButtons
        {
            get => 
                this._panButtons;
            set => 
                this._panButtons = value;
        }

        [Description("Determines which mouse button is used as the secondary for panning"), Bindable(true), DefaultValue(0x400000), Category("Display"), NotifyParentProperty(true)]
        public MouseButtons PanButtons2
        {
            get => 
                this._panButtons2;
            set => 
                this._panButtons2 = value;
        }

        [DefaultValue(0x20000), Bindable(true), Category("Display"), NotifyParentProperty(true), Description("Determines which modifier key is used as the primary for panning")]
        public Keys PanModifierKeys
        {
            get => 
                this._panModifierKeys;
            set => 
                this._panModifierKeys = value;
        }

        [NotifyParentProperty(true), Bindable(true), DefaultValue(0), Category("Display"), Description("Determines which modifier key is used as the secondary for panning")]
        public Keys PanModifierKeys2
        {
            get => 
                this._panModifierKeys2;
            set => 
                this._panModifierKeys2 = value;
        }

        [Description("Specify mouse button for point editing"), Category("Display"), NotifyParentProperty(true), DefaultValue(0x200000), Bindable(true)]
        public MouseButtons EditButtons
        {
            get => 
                this._editButtons;
            set => 
                this._editButtons = value;
        }

        [Description("Specify modifier key for point editing"), Bindable(true), Category("Display"), NotifyParentProperty(true), DefaultValue(0x40000)]
        public Keys EditModifierKeys
        {
            get => 
                this._editModifierKeys;
            set => 
                this._editModifierKeys = value;
        }

        [Category("Display"), DefaultValue(0x100000), Description("Specify mouse button for curve selection"), Bindable(true), NotifyParentProperty(true)]
        public MouseButtons SelectButtons
        {
            get => 
                this._selectButtons;
            set => 
                this._selectButtons = value;
        }

        [Category("Display"), Bindable(true), Description("Specify modifier key for curve selection"), NotifyParentProperty(true), DefaultValue(0x10000)]
        public Keys SelectModifierKeys
        {
            get => 
                this._selectModifierKeys;
            set => 
                this._selectModifierKeys = value;
        }

        [Bindable(true), Category("Display"), NotifyParentProperty(true), Description("Specify modifier key for append curve selection"), DefaultValue(0x50000)]
        public Keys SelectAppendModifierKeys =>
            this._selectAppendModifierKeys;

        [Bindable(true), Description("Specify mouse button for clicking on linkable objects"), Category("Display"), NotifyParentProperty(true), DefaultValue(0x100000)]
        public MouseButtons LinkButtons
        {
            get => 
                this._linkButtons;
            set => 
                this._linkButtons = value;
        }

        [Category("Display"), DefaultValue(0x40000), Description("Specify modifier key for clicking on linkable objects"), Bindable(true), NotifyParentProperty(true)]
        public Keys LinkModifierKeys
        {
            get => 
                this._linkModifierKeys;
            set => 
                this._linkModifierKeys = value;
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Bindable(false)]
        public ZedGraph.MasterPane MasterPane
        {
            get
            {
                lock (this)
                {
                    return this._masterPane;
                }
            }
            set
            {
                lock (this)
                {
                    this._masterPane = value;
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Bindable(false), Browsable(false)]
        public ZedGraph.GraphPane GraphPane
        {
            get
            {
                lock (this)
                {
                    return (((this._masterPane == null) || (this._masterPane.PaneList.Count <= 0)) ? null : this._masterPane[0]);
                }
            }
            set
            {
                lock (this)
                {
                    if (this._masterPane != null)
                    {
                        this._masterPane.PaneList.Clear();
                        this._masterPane.Add(value);
                    }
                }
            }
        }

        [Category("Display"), Description("true to force all objects to be draw in anti-alias mode"), Bindable(true), NotifyParentProperty(true), DefaultValue(false)]
        public bool IsAntiAlias
        {
            get => 
                this._masterPane.IsAntiAlias;
            set => 
                this._masterPane.IsAntiAlias = value;
        }

        [Bindable(true), Category("Display"), NotifyParentProperty(true), DefaultValue(false), Description("true to display tooltips when the mouse hovers over data points")]
        public bool IsShowPointValues
        {
            get => 
                this._isShowPointValues;
            set => 
                this._isShowPointValues = value;
        }

        [NotifyParentProperty(true), Category("Display"), Bindable(true), DefaultValue(false), Description("true to display tooltips showing the current mouse position within the Chart area")]
        public bool IsShowCursorValues
        {
            get => 
                this._isShowCursorValues;
            set => 
                this._isShowCursorValues = value;
        }

        [Bindable(true), Category("Display"), NotifyParentProperty(true), DefaultValue(false), Description("true to allow horizontal editing by alt-left-click-drag")]
        public bool IsEnableHEdit
        {
            get => 
                this._isEnableHEdit;
            set => 
                this._isEnableHEdit = value;
        }

        [Bindable(true), Category("Display"), NotifyParentProperty(true), DefaultValue(false), Description("true to allow vertical editing by alt-left-click-drag")]
        public bool IsEnableVEdit
        {
            get => 
                this._isEnableVEdit;
            set => 
                this._isEnableVEdit = value;
        }

        [NotifyParentProperty(true), Bindable(true), Category("Display"), DefaultValue(true), Description("true to allow horizontal and vertical zooming by left-click-drag")]
        public bool IsEnableZoom
        {
            set
            {
                this._isEnableHZoom = value;
                this._isEnableVZoom = value;
            }
        }

        [Bindable(true), NotifyParentProperty(true), Description("true to allow horizontal zooming by left-click-drag"), Category("Display"), DefaultValue(true)]
        public bool IsEnableHZoom
        {
            get => 
                this._isEnableHZoom;
            set => 
                this._isEnableHZoom = value;
        }

        [DefaultValue(true), Category("Display"), NotifyParentProperty(true), Bindable(true), Description("true to allow vertical zooming by left-click-drag")]
        public bool IsEnableVZoom
        {
            get => 
                this._isEnableVZoom;
            set => 
                this._isEnableVZoom = value;
        }

        [DefaultValue(true), Description("true to allow zooming with the mouse wheel"), Bindable(true), NotifyParentProperty(true), Category("Display")]
        public bool IsEnableWheelZoom
        {
            get => 
                this._isEnableWheelZoom;
            set => 
                this._isEnableWheelZoom = value;
        }

        [Category("Display"), NotifyParentProperty(true), DefaultValue(true), Description("true to allow horizontal panning by middle-mouse-drag or shift-left-drag"), Bindable(true)]
        public bool IsEnableHPan
        {
            get => 
                this._isEnableHPan;
            set => 
                this._isEnableHPan = value;
        }

        [Category("Display"), NotifyParentProperty(true), Bindable(true), Description("true to allow vertical panning by middle-mouse-drag or shift-left-drag"), DefaultValue(true)]
        public bool IsEnableVPan
        {
            get => 
                this._isEnableVPan;
            set => 
                this._isEnableVPan = value;
        }

        [NotifyParentProperty(true), Description("true to enable the right mouse button context menu"), Category("Display"), Bindable(true), DefaultValue(true)]
        public bool IsShowContextMenu
        {
            get => 
                this._isShowContextMenu;
            set => 
                this._isShowContextMenu = value;
        }

        [Bindable(true), Description("true to show a message box after a 'Copy' context menu action completes"), Category("Display"), NotifyParentProperty(true), DefaultValue(true)]
        public bool IsShowCopyMessage
        {
            get => 
                this._isShowCopyMessage;
            set => 
                this._isShowCopyMessage = value;
        }

        [NotifyParentProperty(true), Description("Provides access to the SaveFileDialog for the 'Save As' menu item"), Bindable(true), DefaultValue(true), Category("Display")]
        public System.Windows.Forms.SaveFileDialog SaveFileDialog
        {
            get => 
                this._saveFileDialog;
            set => 
                this._saveFileDialog = value;
        }

        [NotifyParentProperty(true), Description("true to preserve the displayed aspect ratio when printing"), Category("Display"), DefaultValue(true), Bindable(true)]
        public bool IsPrintKeepAspectRatio
        {
            get => 
                this._isPrintKeepAspectRatio;
            set => 
                this._isPrintKeepAspectRatio = value;
        }

        [Category("Display"), Bindable(true), NotifyParentProperty(true), DefaultValue(true), Description("true to resize to fill the page when printing")]
        public bool IsPrintFillPage
        {
            get => 
                this._isPrintFillPage;
            set => 
                this._isPrintFillPage = value;
        }

        [Bindable(true), Category("Display"), NotifyParentProperty(true), DefaultValue(true), Description("true to force font and pen width scaling when printing")]
        public bool IsPrintScaleAll
        {
            get => 
                this._isPrintScaleAll;
            set => 
                this._isPrintScaleAll = value;
        }

        [Category("Display"), Bindable(true), Description("true to automatically set the scroll bar range to the actual data range"), NotifyParentProperty(true), DefaultValue(false)]
        public bool IsAutoScrollRange
        {
            get => 
                this._isAutoScrollRange;
            set => 
                this._isAutoScrollRange = value;
        }

        public double ScrollGrace
        {
            get => 
                this._scrollGrace;
            set => 
                this._scrollGrace = value;
        }

        [Bindable(true), Description("true to display the horizontal scroll bar"), Category("Display"), NotifyParentProperty(true), DefaultValue(false)]
        public bool IsShowHScrollBar
        {
            get => 
                this._isShowHScrollBar;
            set
            {
                this._isShowHScrollBar = value;
                this.ZedGraphControl_ReSize(this, new EventArgs());
            }
        }

        [Category("Display"), Description("true to display the vertical scroll bar"), Bindable(true), NotifyParentProperty(true), DefaultValue(false)]
        public bool IsShowVScrollBar
        {
            get => 
                this._isShowVScrollBar;
            set
            {
                this._isShowVScrollBar = value;
                this.ZedGraphControl_ReSize(this, new EventArgs());
            }
        }

        [Category("Display"), Bindable(true), Description("true to force the X axis ranges for all GraphPanes to match"), NotifyParentProperty(true), DefaultValue(false)]
        public bool IsSynchronizeXAxes
        {
            get => 
                this._isSynchronizeXAxes;
            set
            {
                if (this._isSynchronizeXAxes != value)
                {
                    this.ZoomStatePurge();
                }
                this._isSynchronizeXAxes = value;
            }
        }

        [Bindable(true), Description("true to force the Y axis ranges for all GraphPanes to match"), Category("Display"), NotifyParentProperty(true), DefaultValue(false)]
        public bool IsSynchronizeYAxes
        {
            get => 
                this._isSynchronizeYAxes;
            set
            {
                if (this._isSynchronizeYAxes != value)
                {
                    this.ZoomStatePurge();
                }
                this._isSynchronizeYAxes = value;
            }
        }

        [Bindable(true), Description("true to scroll the Y2 axis along with the Y axis"), Category("Display"), NotifyParentProperty(true), DefaultValue(false)]
        public bool IsScrollY2
        {
            get => 
                ((this._y2ScrollRangeList != null) && (this._y2ScrollRangeList.Count > 0)) && this._y2ScrollRangeList[0].IsScrollable;
            set
            {
                if ((this._y2ScrollRangeList != null) && (this._y2ScrollRangeList.Count > 0))
                {
                    ScrollRange range = this._y2ScrollRangeList[0];
                    range.IsScrollable = value;
                    this._y2ScrollRangeList[0] = range;
                }
            }
        }

        [Description("Sets the manual scroll bar ranges for the collection of Y axes"), Bindable(true), Category("Display"), NotifyParentProperty(true)]
        public ScrollRangeList YScrollRangeList =>
            this._yScrollRangeList;

        [Category("Display"), Bindable(true), Description("Sets the manual scroll bar ranges for the collection of Y2 axes"), NotifyParentProperty(true)]
        public ScrollRangeList Y2ScrollRangeList =>
            this._y2ScrollRangeList;

        [Description("Sets the manual scroll minimum value for the X axis"), Bindable(true), Category("Display"), NotifyParentProperty(true), DefaultValue(0)]
        public double ScrollMinX
        {
            get => 
                this._xScrollRange.Min;
            set => 
                this._xScrollRange.Min = value;
        }

        [Bindable(true), Description("Sets the manual scroll maximum value for the X axis"), Category("Display"), NotifyParentProperty(true), DefaultValue(0)]
        public double ScrollMaxX
        {
            get => 
                this._xScrollRange.Max;
            set => 
                this._xScrollRange.Max = value;
        }

        [Description("Sets the manual scroll minimum value for the Y axis"), Bindable(true), Category("Display"), NotifyParentProperty(true), DefaultValue(0)]
        public double ScrollMinY
        {
            get => 
                ((this._yScrollRangeList == null) || (this._yScrollRangeList.Count <= 0)) ? double.NaN : this._yScrollRangeList[0].Min;
            set
            {
                if ((this._yScrollRangeList != null) && (this._yScrollRangeList.Count > 0))
                {
                    ScrollRange range = this._yScrollRangeList[0];
                    range.Min = value;
                    this._yScrollRangeList[0] = range;
                }
            }
        }

        [Bindable(true), Description("Sets the manual scroll maximum value for the Y axis"), Category("Display"), NotifyParentProperty(true), DefaultValue(0)]
        public double ScrollMaxY
        {
            get => 
                ((this._yScrollRangeList == null) || (this._yScrollRangeList.Count <= 0)) ? double.NaN : this._yScrollRangeList[0].Max;
            set
            {
                if ((this._yScrollRangeList != null) && (this._yScrollRangeList.Count > 0))
                {
                    ScrollRange range = this._yScrollRangeList[0];
                    range.Max = value;
                    this._yScrollRangeList[0] = range;
                }
            }
        }

        [Category("Display"), Bindable(true), Description("Sets the manual scroll minimum value for the Y2 axis"), DefaultValue(0), NotifyParentProperty(true)]
        public double ScrollMinY2
        {
            get => 
                ((this._y2ScrollRangeList == null) || (this._y2ScrollRangeList.Count <= 0)) ? double.NaN : this._y2ScrollRangeList[0].Min;
            set
            {
                if ((this._y2ScrollRangeList != null) && (this._y2ScrollRangeList.Count > 0))
                {
                    ScrollRange range = this._y2ScrollRangeList[0];
                    range.Min = value;
                    this._y2ScrollRangeList[0] = range;
                }
            }
        }

        [DefaultValue(0), Description("Sets the manual scroll maximum value for the Y2 axis"), Bindable(true), Category("Display"), NotifyParentProperty(true)]
        public double ScrollMaxY2
        {
            get => 
                ((this._y2ScrollRangeList == null) || (this._y2ScrollRangeList.Count <= 0)) ? double.NaN : this._y2ScrollRangeList[0].Max;
            set
            {
                if ((this._y2ScrollRangeList != null) && (this._y2ScrollRangeList.Count > 0))
                {
                    ScrollRange range = this._y2ScrollRangeList[0];
                    range.Max = value;
                    this._y2ScrollRangeList[0] = range;
                }
            }
        }

        public bool IsScrolling =>
            (this.hScrollBar1 != null) && ((this.vScrollBar1 != null) && (this.hScrollBar1.Capture || this.vScrollBar1.Capture));

        [Bindable(true), Category("Display"), DefaultValue("G"), Description("Sets the numeric display format string for the point value tooltips"), NotifyParentProperty(true)]
        public string PointValueFormat
        {
            get => 
                this._pointValueFormat;
            set => 
                this._pointValueFormat = value;
        }

        [DefaultValue("g"), NotifyParentProperty(true), Description("Sets the date display format for the point value tooltips"), Bindable(true), Category("Display")]
        public string PointDateFormat
        {
            get => 
                this._pointDateFormat;
            set => 
                this._pointDateFormat = value;
        }

        [Description("Sets the step size fraction for zooming with the mouse wheel"), Bindable(true), Category("Display"), NotifyParentProperty(true), DefaultValue((double) 0.1)]
        public double ZoomStepFraction
        {
            get => 
                this._zoomStepFraction;
            set => 
                this._zoomStepFraction = value;
        }

        [Description("true to center the mouse wheel zoom at the current mouse location"), NotifyParentProperty(true), Bindable(true), DefaultValue(false), Category("Display")]
        public bool IsZoomOnMouseCenter
        {
            get => 
                this._isZoomOnMouseCenter;
            set => 
                this._isZoomOnMouseCenter = value;
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Bindable(false)]
        public bool BeenDisposed
        {
            get
            {
                lock (this)
                {
                    return ReferenceEquals(this._masterPane, null);
                }
            }
        }

        public ZedGraph.Selection Selection =>
            this._selection;

        [NotifyParentProperty(true), DefaultValue(false), Description("true to allow selecting Curves"), Category("Display"), Bindable(true)]
        public bool IsEnableSelection
        {
            get => 
                this._isEnableSelection;
            set => 
                this._isEnableSelection = value;
        }

        public System.Drawing.Printing.PrintDocument PrintDocument
        {
            get
            {
                try
                {
                    if (this._pdSave == null)
                    {
                        this._pdSave = new System.Drawing.Printing.PrintDocument();
                        this._pdSave.PrintPage += new PrintPageEventHandler(this.Graph_PrintPage);
                    }
                }
                catch (Exception exception1)
                {
                    MessageBox.Show(exception1.Message);
                }
                return this._pdSave;
            }
            set => 
                this._pdSave = value;
        }

        internal class ClipboardMetafileHelper
        {
            [DllImport("user32.dll")]
            private static extern bool CloseClipboard();
            [DllImport("gdi32.dll")]
            private static extern IntPtr CopyEnhMetaFile(IntPtr hemfSrc, StringBuilder hNULL);
            [DllImport("gdi32.dll")]
            private static extern bool DeleteEnhMetaFile(IntPtr hemf);
            [DllImport("user32.dll")]
            private static extern bool EmptyClipboard();
            [DllImport("user32.dll")]
            private static extern bool OpenClipboard(IntPtr hWndNewOwner);
            internal static bool PutEnhMetafileOnClipboard(IntPtr hWnd, Metafile mf)
            {
                bool flag = false;
                IntPtr henhmetafile = mf.GetHenhmetafile();
                if (!henhmetafile.Equals(new IntPtr(0)))
                {
                    IntPtr ptr2 = CopyEnhMetaFile(henhmetafile, null);
                    if (!ptr2.Equals(new IntPtr(0)) && (OpenClipboard(hWnd) && EmptyClipboard()))
                    {
                        flag = SetClipboardData(14, ptr2).Equals(ptr2);
                        CloseClipboard();
                    }
                    DeleteEnhMetaFile(henhmetafile);
                }
                return flag;
            }

            internal static bool SaveEnhMetafileToFile(Metafile mf)
            {
                IntPtr henhmetafile = mf.GetHenhmetafile();
                if (!henhmetafile.Equals(new IntPtr(0)))
                {
                    SaveFileDialog dialog = new SaveFileDialog {
                        Filter = "Extended Metafile (*.emf)|*.emf",
                        DefaultExt = ".emf"
                    };
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        CopyEnhMetaFile(henhmetafile, new StringBuilder(dialog.FileName));
                    }
                    DeleteEnhMetaFile(henhmetafile);
                }
                return false;
            }

            internal static bool SaveEnhMetafileToFile(Metafile mf, string fileName)
            {
                IntPtr henhmetafile = mf.GetHenhmetafile();
                if (!henhmetafile.Equals(new IntPtr(0)))
                {
                    CopyEnhMetaFile(henhmetafile, new StringBuilder(fileName));
                    DeleteEnhMetaFile(henhmetafile);
                }
                return false;
            }

            [DllImport("user32.dll")]
            private static extern IntPtr SetClipboardData(uint uFormat, IntPtr hMem);
        }

        public delegate void ContextMenuBuilderEventHandler(ZedGraphControl sender, ContextMenuStrip menuStrip, Point mousePt, ZedGraphControl.ContextMenuObjectState objState);

        public enum ContextMenuObjectState
        {
            InactiveSelection,
            ActiveSelection,
            Background
        }

        public delegate string CursorValueHandler(ZedGraphControl sender, GraphPane pane, Point mousePt);

        public delegate bool LinkEventHandler(ZedGraphControl sender, GraphPane pane, object source, ZedGraph.Link link, int index);

        public delegate string PointEditHandler(ZedGraphControl sender, GraphPane pane, CurveItem curve, int iPt);

        public delegate string PointValueHandler(ZedGraphControl sender, GraphPane pane, CurveItem curve, int iPt);

        public delegate void ScrollDoneHandler(ZedGraphControl sender, ScrollBar scrollBar, ZoomState oldState, ZoomState newState);

        public delegate void ScrollProgressHandler(ZedGraphControl sender, ScrollBar scrollBar, ZoomState oldState, ZoomState newState);

        public delegate bool ZedMouseEventHandler(ZedGraphControl sender, MouseEventArgs e);

        public delegate void ZoomEventHandler(ZedGraphControl sender, ZoomState oldState, ZoomState newState);
    }
}

