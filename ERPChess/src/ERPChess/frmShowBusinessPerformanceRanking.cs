namespace ERPChess
{
    using BusinessTier;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmShowBusinessPerformanceRanking : Form
    {
        private IContainer components;
        private GroupBox groupBox1;
        private DataGridView dataGridViewCKJYYJPM;
        private Button button1;
        private GroupBox groupBox2;
        private RichTextBox richTextBox2;
        private DataGridViewTextBoxColumn 小组;
        private DataGridViewTextBoxColumn 初始权益;
        private DataGridViewTextBoxColumn 第1年;
        private DataGridViewTextBoxColumn 第2年;
        private DataGridViewTextBoxColumn 第3年;
        private DataGridViewTextBoxColumn 第4年;
        private DataGridViewTextBoxColumn 第5年;
        private DataGridViewTextBoxColumn 第6年;
        private DataGridViewTextBoxColumn 总分;
        private DataGridViewTextBoxColumn 名次;

        public frmShowBusinessPerformanceRanking()
        {
            this.InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void frmShowBusinessPerformanceRanking_Load(object sender, EventArgs e)
        {
            this.dataGridViewCKJYYJPM.RowCount = 6;
            for (int i = 0; i < (this.dataGridViewCKJYYJPM.RowCount - 1); i++)
            {
                this.dataGridViewCKJYYJPM.Rows[i].Cells["小组"].Value = TGlobals.computerPlayers[i].ComputerPlayerName;
                this.dataGridViewCKJYYJPM.Rows[i].Cells["初始权益"].Value = "60";
            }
            this.dataGridViewCKJYYJPM.Rows[5].Cells["小组"].Value = TGlobals.currentActor.ActorName;
            this.dataGridViewCKJYYJPM.Rows[5].Cells["初始权益"].Value = "60";
            int num2 = this.YearID(TGlobals.currentActor.RunningYear);
            if (num2 > 1)
            {
                int index = 0;
                while (true)
                {
                    if (index >= (this.dataGridViewCKJYYJPM.RowCount - 1))
                    {
                        TBusinessConditions businessConditions = TGlobals.currentActor.GetBusinessConditions(Year.第1年);
                        this.dataGridViewCKJYYJPM.Rows[5].Cells["第1年"].Value = businessConditions.BalanceSheet.OwnerRight.ToString() + "/" + businessConditions.BalanceSheet.NetProfit.ToString();
                        break;
                    }
                    this.dataGridViewCKJYYJPM.Rows[index].Cells["第1年"].Value = TGlobals.computerPlayers[index].GetScore(Year.第1年);
                    index++;
                }
            }
            if (num2 > 2)
            {
                int index = 0;
                while (true)
                {
                    if (index >= (this.dataGridViewCKJYYJPM.RowCount - 1))
                    {
                        TBusinessConditions businessConditions = TGlobals.currentActor.GetBusinessConditions(Year.第2年);
                        this.dataGridViewCKJYYJPM.Rows[5].Cells["第2年"].Value = businessConditions.BalanceSheet.OwnerRight.ToString() + "/" + businessConditions.BalanceSheet.NetProfit.ToString();
                        break;
                    }
                    this.dataGridViewCKJYYJPM.Rows[index].Cells["第2年"].Value = TGlobals.computerPlayers[index].GetScore(Year.第2年);
                    index++;
                }
            }
            if (num2 > 3)
            {
                int index = 0;
                while (true)
                {
                    if (index >= (this.dataGridViewCKJYYJPM.RowCount - 1))
                    {
                        TBusinessConditions businessConditions = TGlobals.currentActor.GetBusinessConditions(Year.第3年);
                        this.dataGridViewCKJYYJPM.Rows[5].Cells["第3年"].Value = businessConditions.BalanceSheet.OwnerRight.ToString() + "/" + businessConditions.BalanceSheet.NetProfit.ToString();
                        break;
                    }
                    this.dataGridViewCKJYYJPM.Rows[index].Cells["第3年"].Value = TGlobals.computerPlayers[index].GetScore(Year.第3年);
                    index++;
                }
            }
            if (num2 > 4)
            {
                int index = 0;
                while (true)
                {
                    if (index >= (this.dataGridViewCKJYYJPM.RowCount - 1))
                    {
                        TBusinessConditions businessConditions = TGlobals.currentActor.GetBusinessConditions(Year.第4年);
                        this.dataGridViewCKJYYJPM.Rows[5].Cells["第4年"].Value = businessConditions.BalanceSheet.OwnerRight.ToString() + "/" + businessConditions.BalanceSheet.NetProfit.ToString();
                        break;
                    }
                    this.dataGridViewCKJYYJPM.Rows[index].Cells["第4年"].Value = TGlobals.computerPlayers[index].GetScore(Year.第4年);
                    index++;
                }
            }
            if (num2 > 5)
            {
                int index = 0;
                while (true)
                {
                    if (index >= (this.dataGridViewCKJYYJPM.RowCount - 1))
                    {
                        TBusinessConditions businessConditions = TGlobals.currentActor.GetBusinessConditions(Year.第5年);
                        this.dataGridViewCKJYYJPM.Rows[5].Cells["第5年"].Value = businessConditions.BalanceSheet.OwnerRight.ToString() + "/" + businessConditions.BalanceSheet.NetProfit.ToString();
                        break;
                    }
                    this.dataGridViewCKJYYJPM.Rows[index].Cells["第5年"].Value = TGlobals.computerPlayers[index].GetScore(Year.第5年);
                    index++;
                }
            }
            if (num2 > 6)
            {
                int index = 0;
                while (true)
                {
                    if (index >= (this.dataGridViewCKJYYJPM.RowCount - 1))
                    {
                        TBusinessConditions businessConditions = TGlobals.currentActor.GetBusinessConditions(Year.第6年);
                        this.dataGridViewCKJYYJPM.Rows[5].Cells["第6年"].Value = businessConditions.BalanceSheet.OwnerRight.ToString() + "/" + businessConditions.BalanceSheet.NetProfit.ToString();
                        this.dataGridViewCKJYYJPM.Rows[5].Cells["总分"].Value = TGlobals.currentActor.GetFinalScore();
                        double[] scoreSet = new double[6];
                        int num21 = 0;
                        while (true)
                        {
                            if (num21 >= this.dataGridViewCKJYYJPM.RowCount)
                            {
                                for (int j = 0; j < this.dataGridViewCKJYYJPM.RowCount; j++)
                                {
                                    double score = Convert.ToDouble(this.dataGridViewCKJYYJPM.Rows[j].Cells["总分"].Value);
                                    this.dataGridViewCKJYYJPM.Rows[j].Cells["名次"].Value = "第" + this.GetPM(scoreSet, score).ToString() + "名";
                                }
                                break;
                            }
                            scoreSet[num21] = Convert.ToDouble(this.dataGridViewCKJYYJPM.Rows[num21].Cells["总分"].Value);
                            num21++;
                        }
                        break;
                    }
                    this.dataGridViewCKJYYJPM.Rows[index].Cells["第6年"].Value = TGlobals.computerPlayers[index].GetScore(Year.第6年);
                    this.dataGridViewCKJYYJPM.Rows[index].Cells["总分"].Value = TGlobals.computerPlayers[index].GetScore(Year.第7年);
                    index++;
                }
            }
        }

        private int GetPM(double[] scoreSet, double score)
        {
            int num = 1;
            for (int i = 0; i < scoreSet.Length; i++)
            {
                if (scoreSet[i] > score)
                {
                    num++;
                }
            }
            return num;
        }

        private void InitializeComponent()
        {
            ComponentResourceManager manager = new ComponentResourceManager(typeof(frmShowBusinessPerformanceRanking));
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            DataGridViewCellStyle style2 = new DataGridViewCellStyle();
            DataGridViewCellStyle style3 = new DataGridViewCellStyle();
            DataGridViewCellStyle style4 = new DataGridViewCellStyle();
            DataGridViewCellStyle style5 = new DataGridViewCellStyle();
            DataGridViewCellStyle style6 = new DataGridViewCellStyle();
            DataGridViewCellStyle style7 = new DataGridViewCellStyle();
            DataGridViewCellStyle style8 = new DataGridViewCellStyle();
            DataGridViewCellStyle style9 = new DataGridViewCellStyle();
            DataGridViewCellStyle style10 = new DataGridViewCellStyle();
            this.groupBox1 = new GroupBox();
            this.dataGridViewCKJYYJPM = new DataGridView();
            this.button1 = new Button();
            this.groupBox2 = new GroupBox();
            this.richTextBox2 = new RichTextBox();
            this.小组 = new DataGridViewTextBoxColumn();
            this.初始权益 = new DataGridViewTextBoxColumn();
            this.第1年 = new DataGridViewTextBoxColumn();
            this.第2年 = new DataGridViewTextBoxColumn();
            this.第3年 = new DataGridViewTextBoxColumn();
            this.第4年 = new DataGridViewTextBoxColumn();
            this.第5年 = new DataGridViewTextBoxColumn();
            this.第6年 = new DataGridViewTextBoxColumn();
            this.总分 = new DataGridViewTextBoxColumn();
            this.名次 = new DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((ISupportInitialize) this.dataGridViewCKJYYJPM).BeginInit();
            this.groupBox2.SuspendLayout();
            base.SuspendLayout();
            this.groupBox1.Controls.Add(this.dataGridViewCKJYYJPM);
            this.groupBox1.Location = new Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x2dd, 0xb9);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "经营业绩统计";
            this.dataGridViewCKJYYJPM.AllowUserToAddRows = false;
            this.dataGridViewCKJYYJPM.AllowUserToDeleteRows = false;
            this.dataGridViewCKJYYJPM.AllowUserToResizeRows = false;
            this.dataGridViewCKJYYJPM.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridViewColumn[] dataGridViewColumns = new DataGridViewColumn[] { this.小组, this.初始权益, this.第1年, this.第2年, this.第3年, this.第4年, this.第5年, this.第6年, this.总分 };
            dataGridViewColumns[9] = this.名次;
            this.dataGridViewCKJYYJPM.Columns.AddRange(dataGridViewColumns);
            this.dataGridViewCKJYYJPM.Location = new Point(20, 14);
            this.dataGridViewCKJYYJPM.MultiSelect = false;
            this.dataGridViewCKJYYJPM.Name = "dataGridViewCKJYYJPM";
            this.dataGridViewCKJYYJPM.ReadOnly = true;
            this.dataGridViewCKJYYJPM.RowHeadersVisible = false;
            this.dataGridViewCKJYYJPM.RowTemplate.Height = 0x17;
            this.dataGridViewCKJYYJPM.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCKJYYJPM.Size = new Size(0x2c3, 0xa5);
            this.dataGridViewCKJYYJPM.TabIndex = 0x4d;
            this.button1.DialogResult = DialogResult.OK;
            this.button1.Location = new Point(0x28b, 0x1e6);
            this.button1.Name = "button1";
            this.button1.Size = new Size(0x4b, 0x17);
            this.button1.TabIndex = 0;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click);
            this.groupBox2.Controls.Add(this.richTextBox2);
            this.groupBox2.Location = new Point(12, 0xcb);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(0x2dd, 0x115);
            this.groupBox2.TabIndex = 0x4a;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "说明";
            this.richTextBox2.BackColor = SystemColors.Control;
            this.richTextBox2.BorderStyle = BorderStyle.None;
            this.richTextBox2.Dock = DockStyle.Fill;
            this.richTextBox2.Font = new Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.richTextBox2.Location = new Point(3, 0x11);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.Size = new Size(0x2d7, 0x101);
            this.richTextBox2.TabIndex = 1;
            this.richTextBox2.Text = manager.GetString("richTextBox2.Text");
            style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.小组.DefaultCellStyle = style;
            this.小组.HeaderText = @"小组\年度";
            this.小组.Name = "小组";
            this.小组.ReadOnly = true;
            this.小组.SortMode = DataGridViewColumnSortMode.NotSortable;
            this.小组.Width = 90;
            style2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.初始权益.DefaultCellStyle = style2;
            this.初始权益.HeaderText = "初始权益";
            this.初始权益.Name = "初始权益";
            this.初始权益.ReadOnly = true;
            this.初始权益.Resizable = DataGridViewTriState.False;
            this.初始权益.SortMode = DataGridViewColumnSortMode.NotSortable;
            this.初始权益.Width = 0x55;
            style3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.第1年.DefaultCellStyle = style3;
            this.第1年.HeaderText = "第1年";
            this.第1年.Name = "第1年";
            this.第1年.ReadOnly = true;
            this.第1年.Resizable = DataGridViewTriState.False;
            this.第1年.SortMode = DataGridViewColumnSortMode.NotSortable;
            this.第1年.Width = 0x41;
            style4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.第2年.DefaultCellStyle = style4;
            this.第2年.HeaderText = "第2年";
            this.第2年.Name = "第2年";
            this.第2年.ReadOnly = true;
            this.第2年.Resizable = DataGridViewTriState.False;
            this.第2年.SortMode = DataGridViewColumnSortMode.NotSortable;
            this.第2年.Width = 0x41;
            style5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.第3年.DefaultCellStyle = style5;
            this.第3年.HeaderText = "第3年";
            this.第3年.Name = "第3年";
            this.第3年.ReadOnly = true;
            this.第3年.Resizable = DataGridViewTriState.False;
            this.第3年.SortMode = DataGridViewColumnSortMode.NotSortable;
            this.第3年.Width = 0x41;
            style6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.第4年.DefaultCellStyle = style6;
            this.第4年.HeaderText = "第4年";
            this.第4年.Name = "第4年";
            this.第4年.ReadOnly = true;
            this.第4年.Resizable = DataGridViewTriState.False;
            this.第4年.SortMode = DataGridViewColumnSortMode.NotSortable;
            this.第4年.Width = 0x41;
            style7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.第5年.DefaultCellStyle = style7;
            this.第5年.HeaderText = "第5年";
            this.第5年.Name = "第5年";
            this.第5年.ReadOnly = true;
            this.第5年.Resizable = DataGridViewTriState.False;
            this.第5年.SortMode = DataGridViewColumnSortMode.NotSortable;
            this.第5年.Width = 0x41;
            style8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.第6年.DefaultCellStyle = style8;
            this.第6年.HeaderText = "第6年";
            this.第6年.Name = "第6年";
            this.第6年.ReadOnly = true;
            this.第6年.Resizable = DataGridViewTriState.False;
            this.第6年.SortMode = DataGridViewColumnSortMode.NotSortable;
            this.第6年.Width = 0x41;
            style9.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.总分.DefaultCellStyle = style9;
            this.总分.HeaderText = "总分";
            this.总分.Name = "总分";
            this.总分.ReadOnly = true;
            this.总分.Resizable = DataGridViewTriState.False;
            this.总分.SortMode = DataGridViewColumnSortMode.NotSortable;
            this.总分.Width = 0x41;
            style10.Alignment = DataGridViewContentAlignment.MiddleCenter;
            style10.ForeColor = Color.Red;
            this.名次.DefaultCellStyle = style10;
            this.名次.HeaderText = "名次";
            this.名次.Name = "名次";
            this.名次.ReadOnly = true;
            this.名次.Resizable = DataGridViewTriState.False;
            this.名次.SortMode = DataGridViewColumnSortMode.NotSortable;
            this.名次.Width = 0x41;
            base.AcceptButton = this.button1;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x2f3, 0x207);
            base.Controls.Add(this.groupBox2);
            base.Controls.Add(this.button1);
            base.Controls.Add(this.groupBox1);
            base.FormBorderStyle = FormBorderStyle.FixedDialog;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "frmShowBusinessPerformanceRanking";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "查看经营业绩排名";
            base.Load += new EventHandler(this.frmShowBusinessPerformanceRanking_Load);
            this.groupBox1.ResumeLayout(false);
            ((ISupportInitialize) this.dataGridViewCKJYYJPM).EndInit();
            this.groupBox2.ResumeLayout(false);
            base.ResumeLayout(false);
        }

        private int YearID(Year year)
        {
            int num = 0;
            switch (year)
            {
                case Year.第1年:
                    num = 1;
                    break;

                case Year.第2年:
                    num = 2;
                    break;

                case Year.第3年:
                    num = 3;
                    break;

                case Year.第4年:
                    num = 4;
                    break;

                case Year.第5年:
                    num = 5;
                    break;

                case Year.第6年:
                    num = 6;
                    break;

                case Year.第7年:
                    num = 7;
                    break;

                default:
                    break;
            }
            return num;
        }
    }
}

