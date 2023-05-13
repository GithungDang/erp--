namespace ERPChess
{
    using BusinessTier;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmJHGKH : Form
    {
        private IContainer components;
        private Button buttonOK;
        private Button buttonCancel;
        private GroupBox groupBox2;
        private RichTextBox richTextBox2;
        private GroupBox groupBox1;
        private GroupBox groupBox3;
        private DataGridView dataGridViewBNDD;
        private DataGridView dataGridViewWYDD;
        private Label label1;
        private Label label01;
        private Label label02;
        private Label label4;
        private Label label03;
        private Label label6;
        private Label label04;
        private Label label8;
        private Label label9;
        private DataGridViewCheckBoxColumn 选择项;
        private DataGridViewTextBoxColumn 编号W;
        private DataGridViewTextBoxColumn 产品W;
        private DataGridViewTextBoxColumn 数量W;
        private DataGridViewTextBoxColumn 单价W;
        private DataGridViewTextBoxColumn 金额W;
        private DataGridViewTextBoxColumn 账期W;
        private DataGridViewTextBoxColumn 成本W;
        private DataGridViewTextBoxColumn 编号;
        private DataGridViewTextBoxColumn 产品;
        private DataGridViewTextBoxColumn 数量;
        private DataGridViewTextBoxColumn 单价;
        private DataGridViewTextBoxColumn 金额;
        private DataGridViewTextBoxColumn 账期;
        private DataGridViewTextBoxColumn 成本;
        private DataGridViewTextBoxColumn 罚款;

        public frmJHGKH()
        {
            this.InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            bool flag2;
            bool flag3;
            bool flag4;
            int num = 0;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            for (int i = 0; i < this.dataGridViewWYDD.RowCount; i++)
            {
                string str = this.dataGridViewWYDD.Rows[i].Cells["产品"].Value.ToString();
                int num6 = (int) this.dataGridViewWYDD.Rows[i].Cells["数量"].Value;
                string str2 = str;
                if (str2 != null)
                {
                    if (str2 == "P1")
                    {
                        num += num6 * 2;
                    }
                    else if (str2 == "P2")
                    {
                        num2 += num6 * 3;
                    }
                    else if (str2 == "P3")
                    {
                        num3 += num6 * 4;
                    }
                    else if (str2 == "P4")
                    {
                        num4 += num6 * 5;
                    }
                }
            }
            int num7 = 0;
            int num8 = 0;
            int num9 = 0;
            int num10 = 0;
            for (int j = 0; j < this.dataGridViewBNDD.RowCount; j++)
            {
                if ((bool) this.dataGridViewBNDD.Rows[j].Cells["选择项"].Value)
                {
                    int num12 = (int) this.dataGridViewBNDD.Rows[j].Cells["数量W"].Value;
                    string str4 = this.dataGridViewBNDD.Rows[j].Cells["产品W"].Value.ToString();
                    if (str4 != null)
                    {
                        if (str4 == "P1")
                        {
                            num7 += num12 * 2;
                        }
                        else if (str4 == "P2")
                        {
                            num8 += num12 * 3;
                        }
                        else if (str4 == "P3")
                        {
                            num9 += num12 * 4;
                        }
                        else if (str4 == "P4")
                        {
                            num10 += num12 * 5;
                        }
                    }
                }
            }
            bool flag5 = flag4 = flag3 = flag2 = false;
            bool flag6 = false;
            if (num <= TGlobals.currentActor.P1Warehouse.InventoryAmount)
            {
                flag4 = true;
            }
            if (num2 <= TGlobals.currentActor.P2Warehouse.InventoryAmount)
            {
                flag5 = true;
            }
            if (num3 <= TGlobals.currentActor.P3Warehouse.InventoryAmount)
            {
                flag3 = true;
            }
            if (num4 <= TGlobals.currentActor.P4Warehouse.InventoryAmount)
            {
                flag2 = true;
            }
            if (!flag4 && (!flag5 && (!flag3 && !flag2)))
            {
                MessageBox.Show("不能够交付任何违约订单,本操作不能进行!  ", "重要提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                flag6 = true;
            }
            if (!flag6)
            {
                if ((num7 != 0) && ((num + num7) > TGlobals.currentActor.P1Warehouse.InventoryAmount))
                {
                    MessageBox.Show("P1产品库存不够,请重新选择交货订单!  ", "重要提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                if ((num8 != 0) && ((num2 + num8) > TGlobals.currentActor.P2Warehouse.InventoryAmount))
                {
                    MessageBox.Show("P2产品库存不够,请重新选择交货订单!  ", "重要提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                if ((num9 != 0) && ((num3 + num9) > TGlobals.currentActor.P3Warehouse.InventoryAmount))
                {
                    MessageBox.Show("P3产品库存不够,请重新选择交货订单!  ", "重要提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                if ((num10 != 0) && ((num4 + num10) > TGlobals.currentActor.P4Warehouse.InventoryAmount))
                {
                    MessageBox.Show("P4产品库存不够,请重新选择交货订单!  ", "重要提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                int num13 = 0;
                while (true)
                {
                    if (num13 >= this.dataGridViewWYDD.RowCount)
                    {
                        for (int k = 0; k < this.dataGridViewBNDD.RowCount; k++)
                        {
                            if ((bool) this.dataGridViewBNDD.Rows[k].Cells["选择项"].Value)
                            {
                                string str8 = this.dataGridViewBNDD.Rows[k].Cells["编号W"].Value.ToString();
                                int num19 = (int) this.dataGridViewBNDD.Rows[k].Cells["成本W"].Value;
                                int num20 = (int) this.dataGridViewBNDD.Rows[k].Cells["金额W"].Value;
                                int num21 = (int) this.dataGridViewBNDD.Rows[k].Cells["账期W"].Value;
                                string str10 = this.dataGridViewBNDD.Rows[k].Cells["产品W"].Value.ToString();
                                if (str10 != null)
                                {
                                    if (str10 == "P1")
                                    {
                                        if (num19 <= TGlobals.currentActor.P1Warehouse.InventoryAmount)
                                        {
                                            this.JBNWWYDD(TGlobals.currentActor.RunningYear, str8, ProductAttribute.P1, num19, num20, num21);
                                        }
                                    }
                                    else if (str10 == "P2")
                                    {
                                        if (num19 <= TGlobals.currentActor.P2Warehouse.InventoryAmount)
                                        {
                                            this.JBNWWYDD(TGlobals.currentActor.RunningYear, str8, ProductAttribute.P2, num19, num20, num21);
                                        }
                                    }
                                    else if (str10 != "P3")
                                    {
                                        if ((str10 == "P4") && (num19 <= TGlobals.currentActor.P4Warehouse.InventoryAmount))
                                        {
                                            this.JBNWWYDD(TGlobals.currentActor.RunningYear, str8, ProductAttribute.P4, num19, num20, num21);
                                        }
                                    }
                                    else if (num19 <= TGlobals.currentActor.P3Warehouse.InventoryAmount)
                                    {
                                        this.JBNWWYDD(TGlobals.currentActor.RunningYear, str8, ProductAttribute.P3, num19, num20, num21);
                                    }
                                }
                            }
                        }
                        break;
                    }
                    string id = this.dataGridViewWYDD.Rows[num13].Cells["编号"].Value.ToString();
                    string str6 = this.dataGridViewWYDD.Rows[num13].Cells["产品"].Value.ToString();
                    int cB = (int) this.dataGridViewWYDD.Rows[num13].Cells["成本"].Value;
                    int jE = (int) this.dataGridViewWYDD.Rows[num13].Cells["金额"].Value;
                    int zQ = (int) this.dataGridViewWYDD.Rows[num13].Cells["账期"].Value;
                    int fK = (int) this.dataGridViewWYDD.Rows[num13].Cells["罚款"].Value;
                    string str7 = str6;
                    if (str7 != null)
                    {
                        if (str7 == "P1")
                        {
                            if (cB <= TGlobals.currentActor.P1Warehouse.InventoryAmount)
                            {
                                this.JFWYDD(TGlobals.currentActor.RunningYear, id, ProductAttribute.P1, cB, jE, zQ, fK);
                            }
                        }
                        else if (str7 == "P2")
                        {
                            if (cB <= TGlobals.currentActor.P2Warehouse.InventoryAmount)
                            {
                                this.JFWYDD(TGlobals.currentActor.RunningYear, id, ProductAttribute.P2, cB, jE, zQ, fK);
                            }
                        }
                        else if (str7 != "P3")
                        {
                            if ((str7 == "P4") && (cB <= TGlobals.currentActor.P4Warehouse.InventoryAmount))
                            {
                                this.JFWYDD(TGlobals.currentActor.RunningYear, id, ProductAttribute.P4, cB, jE, zQ, fK);
                            }
                        }
                        else if (cB <= TGlobals.currentActor.P3Warehouse.InventoryAmount)
                        {
                            this.JFWYDD(TGlobals.currentActor.RunningYear, id, ProductAttribute.P3, cB, jE, zQ, fK);
                        }
                    }
                    num13++;
                }
            }
            if (TGlobals.currentActor.RunningQuarter == Quarter.第4季)
            {
                this.initKC();
                this.initDNDD();
                this.SetWYDD();
            }
            base.DialogResult = DialogResult.OK;
            base.Close();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void frmJHGKH_Load(object sender, EventArgs e)
        {
            this.initKC();
            this.initDNDD();
        }

        private void initDNDD()
        {
            TOrder[] breakPromisedWHOrder = TGlobals.currentActor.GetBreakPromisedWHOrder(TGlobals.currentActor.RunningYear);
            TOrder[] promisedMJHOrderList = TGlobals.currentActor.GetPromisedMJHOrderList(TGlobals.currentActor.RunningYear);
            this.dataGridViewWYDD.Rows.Clear();
            if (breakPromisedWHOrder != null)
            {
                this.dataGridViewWYDD.RowCount = breakPromisedWHOrder.Length;
                for (int i = 0; i < breakPromisedWHOrder.Length; i++)
                {
                    this.dataGridViewWYDD.Rows[i].Cells["编号"].Value = breakPromisedWHOrder[i].OrderID;
                    this.dataGridViewWYDD.Rows[i].Cells["产品"].Value = breakPromisedWHOrder[i].ProductName;
                    this.dataGridViewWYDD.Rows[i].Cells["数量"].Value = breakPromisedWHOrder[i].ProductNumber;
                    this.dataGridViewWYDD.Rows[i].Cells["单价"].Value = breakPromisedWHOrder[i].UnitPrice;
                    this.dataGridViewWYDD.Rows[i].Cells["金额"].Value = breakPromisedWHOrder[i].Amount;
                    this.dataGridViewWYDD.Rows[i].Cells["账期"].Value = breakPromisedWHOrder[i].AccountPeriod;
                    this.dataGridViewWYDD.Rows[i].Cells["成本"].Value = breakPromisedWHOrder[i].DirectCost;
                    this.dataGridViewWYDD.Rows[i].Cells["罚款"].Value = breakPromisedWHOrder[i].BreakPromiseCost;
                }
            }
            this.dataGridViewBNDD.Rows.Clear();
            if (promisedMJHOrderList != null)
            {
                this.dataGridViewBNDD.RowCount = promisedMJHOrderList.Length;
                for (int i = 0; i < promisedMJHOrderList.Length; i++)
                {
                    this.dataGridViewBNDD.Rows[i].Cells["选择项"].Value = false;
                    this.dataGridViewBNDD.Rows[i].Cells["编号W"].Value = promisedMJHOrderList[i].OrderID;
                    this.dataGridViewBNDD.Rows[i].Cells["产品W"].Value = promisedMJHOrderList[i].ProductName;
                    this.dataGridViewBNDD.Rows[i].Cells["数量W"].Value = promisedMJHOrderList[i].ProductNumber;
                    this.dataGridViewBNDD.Rows[i].Cells["单价W"].Value = promisedMJHOrderList[i].UnitPrice;
                    this.dataGridViewBNDD.Rows[i].Cells["金额W"].Value = promisedMJHOrderList[i].Amount;
                    this.dataGridViewBNDD.Rows[i].Cells["账期W"].Value = promisedMJHOrderList[i].AccountPeriod;
                    this.dataGridViewBNDD.Rows[i].Cells["成本W"].Value = promisedMJHOrderList[i].DirectCost;
                }
            }
        }

        private void InitializeComponent()
        {
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
            DataGridViewCellStyle style11 = new DataGridViewCellStyle();
            DataGridViewCellStyle style12 = new DataGridViewCellStyle();
            DataGridViewCellStyle style13 = new DataGridViewCellStyle();
            DataGridViewCellStyle style14 = new DataGridViewCellStyle();
            DataGridViewCellStyle style15 = new DataGridViewCellStyle();
            this.buttonOK = new Button();
            this.buttonCancel = new Button();
            this.groupBox2 = new GroupBox();
            this.richTextBox2 = new RichTextBox();
            this.groupBox1 = new GroupBox();
            this.dataGridViewWYDD = new DataGridView();
            this.编号 = new DataGridViewTextBoxColumn();
            this.产品 = new DataGridViewTextBoxColumn();
            this.数量 = new DataGridViewTextBoxColumn();
            this.单价 = new DataGridViewTextBoxColumn();
            this.金额 = new DataGridViewTextBoxColumn();
            this.账期 = new DataGridViewTextBoxColumn();
            this.成本 = new DataGridViewTextBoxColumn();
            this.罚款 = new DataGridViewTextBoxColumn();
            this.groupBox3 = new GroupBox();
            this.dataGridViewBNDD = new DataGridView();
            this.选择项 = new DataGridViewCheckBoxColumn();
            this.编号W = new DataGridViewTextBoxColumn();
            this.产品W = new DataGridViewTextBoxColumn();
            this.数量W = new DataGridViewTextBoxColumn();
            this.单价W = new DataGridViewTextBoxColumn();
            this.金额W = new DataGridViewTextBoxColumn();
            this.账期W = new DataGridViewTextBoxColumn();
            this.成本W = new DataGridViewTextBoxColumn();
            this.label1 = new Label();
            this.label01 = new Label();
            this.label02 = new Label();
            this.label4 = new Label();
            this.label03 = new Label();
            this.label6 = new Label();
            this.label04 = new Label();
            this.label8 = new Label();
            this.label9 = new Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((ISupportInitialize) this.dataGridViewWYDD).BeginInit();
            this.groupBox3.SuspendLayout();
            ((ISupportInitialize) this.dataGridViewBNDD).BeginInit();
            base.SuspendLayout();
            this.buttonOK.Location = new Point(0x1b3, 0x1c6);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new Size(0x4b, 0x17);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "确定";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new EventHandler(this.buttonOK_Click);
            this.buttonCancel.DialogResult = DialogResult.Cancel;
            this.buttonCancel.Location = new Point(0x20c, 0x1c6);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new Size(0x4b, 0x17);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.groupBox2.Controls.Add(this.richTextBox2);
            this.groupBox2.Location = new Point(8, 0x13f);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(0x252, 0x81);
            this.groupBox2.TabIndex = 0x4a;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "说明";
            this.richTextBox2.BackColor = SystemColors.Window;
            this.richTextBox2.BorderStyle = BorderStyle.None;
            this.richTextBox2.Dock = DockStyle.Fill;
            this.richTextBox2.Font = new Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.richTextBox2.Location = new Point(3, 0x11);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.Size = new Size(0x24c, 0x6d);
            this.richTextBox2.TabIndex = 1;
            this.richTextBox2.Text = "    在此处进行本季度的交货。注意：只可交货一个完整的定单，不可分批。违约订单系统自动先进行交货。\n    延迟交货--如果一个定单交货时间太晚，将有以下后果：\n    ① 20%定单的罚金。（该定单的总价下降）\n    ② 市场地位丧失一级。因为延迟交货造成的不良商誉所致。\n    ③ 在当年财务报表中，销售额将转移到实际交货的那一年计算。";
            this.groupBox1.Controls.Add(this.dataGridViewWYDD);
            this.groupBox1.Location = new Point(8, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(600, 0x70);
            this.groupBox1.TabIndex = 0x4b;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "违约订单";
            this.dataGridViewWYDD.AllowUserToAddRows = false;
            this.dataGridViewWYDD.AllowUserToDeleteRows = false;
            this.dataGridViewWYDD.AllowUserToResizeRows = false;
            this.dataGridViewWYDD.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridViewColumn[] dataGridViewColumns = new DataGridViewColumn[] { this.编号, this.产品, this.数量, this.单价, this.金额, this.账期, this.成本, this.罚款 };
            this.dataGridViewWYDD.Columns.AddRange(dataGridViewColumns);
            this.dataGridViewWYDD.Dock = DockStyle.Fill;
            this.dataGridViewWYDD.Location = new Point(3, 0x11);
            this.dataGridViewWYDD.MultiSelect = false;
            this.dataGridViewWYDD.Name = "dataGridViewWYDD";
            this.dataGridViewWYDD.ReadOnly = true;
            this.dataGridViewWYDD.RowHeadersVisible = false;
            this.dataGridViewWYDD.RowTemplate.Height = 0x17;
            this.dataGridViewWYDD.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewWYDD.Size = new Size(0x252, 0x5c);
            this.dataGridViewWYDD.TabIndex = 0x4d;
            style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.编号.DefaultCellStyle = style;
            this.编号.HeaderText = "编号";
            this.编号.Name = "编号";
            this.编号.ReadOnly = true;
            this.编号.Resizable = DataGridViewTriState.False;
            this.编号.Width = 70;
            style2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.产品.DefaultCellStyle = style2;
            this.产品.HeaderText = "产品";
            this.产品.Name = "产品";
            this.产品.ReadOnly = true;
            this.产品.Resizable = DataGridViewTriState.False;
            this.产品.Width = 70;
            style3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.数量.DefaultCellStyle = style3;
            this.数量.HeaderText = "数量";
            this.数量.Name = "数量";
            this.数量.ReadOnly = true;
            this.数量.Resizable = DataGridViewTriState.False;
            this.数量.Width = 70;
            style4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.单价.DefaultCellStyle = style4;
            this.单价.HeaderText = "单价";
            this.单价.Name = "单价";
            this.单价.ReadOnly = true;
            this.单价.Resizable = DataGridViewTriState.False;
            this.单价.Width = 70;
            style5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.金额.DefaultCellStyle = style5;
            this.金额.HeaderText = "金额";
            this.金额.Name = "金额";
            this.金额.ReadOnly = true;
            this.金额.Resizable = DataGridViewTriState.False;
            this.金额.Width = 70;
            style6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.账期.DefaultCellStyle = style6;
            this.账期.HeaderText = "账期";
            this.账期.Name = "账期";
            this.账期.ReadOnly = true;
            this.账期.Resizable = DataGridViewTriState.False;
            this.账期.Width = 70;
            style7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.成本.DefaultCellStyle = style7;
            this.成本.HeaderText = "成本";
            this.成本.Name = "成本";
            this.成本.ReadOnly = true;
            this.成本.Resizable = DataGridViewTriState.False;
            this.成本.Width = 70;
            style8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.罚款.DefaultCellStyle = style8;
            this.罚款.HeaderText = "罚款";
            this.罚款.Name = "罚款";
            this.罚款.ReadOnly = true;
            this.罚款.Resizable = DataGridViewTriState.False;
            this.罚款.Width = 70;
            this.groupBox3.Controls.Add(this.dataGridViewBNDD);
            this.groupBox3.Location = new Point(8, 0x77);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new Size(0x255, 0xa3);
            this.groupBox3.TabIndex = 0x4e;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "本年订单";
            this.dataGridViewBNDD.AllowUserToAddRows = false;
            this.dataGridViewBNDD.AllowUserToDeleteRows = false;
            this.dataGridViewBNDD.AllowUserToResizeRows = false;
            this.dataGridViewBNDD.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridViewColumn[] columnArray2 = new DataGridViewColumn[] { this.选择项, this.编号W, this.产品W, this.数量W, this.单价W, this.金额W, this.账期W, this.成本W };
            this.dataGridViewBNDD.Columns.AddRange(columnArray2);
            this.dataGridViewBNDD.Dock = DockStyle.Fill;
            this.dataGridViewBNDD.Location = new Point(3, 0x11);
            this.dataGridViewBNDD.MultiSelect = false;
            this.dataGridViewBNDD.Name = "dataGridViewBNDD";
            this.dataGridViewBNDD.RowHeadersVisible = false;
            this.dataGridViewBNDD.RowTemplate.Height = 0x17;
            this.dataGridViewBNDD.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewBNDD.Size = new Size(0x24f, 0x8f);
            this.dataGridViewBNDD.TabIndex = 0x4d;
            this.选择项.HeaderText = "选择项";
            this.选择项.Name = "选择项";
            this.选择项.Resizable = DataGridViewTriState.False;
            this.选择项.Width = 70;
            style9.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.编号W.DefaultCellStyle = style9;
            this.编号W.HeaderText = "编号";
            this.编号W.Name = "编号W";
            this.编号W.ReadOnly = true;
            this.编号W.Resizable = DataGridViewTriState.False;
            this.编号W.Width = 70;
            style10.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.产品W.DefaultCellStyle = style10;
            this.产品W.HeaderText = "产品";
            this.产品W.Name = "产品W";
            this.产品W.ReadOnly = true;
            this.产品W.Resizable = DataGridViewTriState.False;
            this.产品W.Width = 70;
            style11.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.数量W.DefaultCellStyle = style11;
            this.数量W.HeaderText = "数量";
            this.数量W.Name = "数量W";
            this.数量W.ReadOnly = true;
            this.数量W.Resizable = DataGridViewTriState.False;
            this.数量W.Width = 70;
            style12.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.单价W.DefaultCellStyle = style12;
            this.单价W.HeaderText = "单价";
            this.单价W.Name = "单价W";
            this.单价W.ReadOnly = true;
            this.单价W.Resizable = DataGridViewTriState.False;
            this.单价W.Width = 70;
            style13.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.金额W.DefaultCellStyle = style13;
            this.金额W.HeaderText = "金额";
            this.金额W.Name = "金额W";
            this.金额W.ReadOnly = true;
            this.金额W.Resizable = DataGridViewTriState.False;
            this.金额W.Width = 70;
            style14.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.账期W.DefaultCellStyle = style14;
            this.账期W.HeaderText = "账期";
            this.账期W.Name = "账期W";
            this.账期W.ReadOnly = true;
            this.账期W.Resizable = DataGridViewTriState.False;
            this.账期W.Width = 70;
            style15.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.成本W.DefaultCellStyle = style15;
            this.成本W.HeaderText = "成本";
            this.成本W.Name = "成本W";
            this.成本W.ReadOnly = true;
            this.成本W.Resizable = DataGridViewTriState.False;
            this.成本W.Width = 70;
            this.label1.AutoSize = true;
            this.label1.Location = new Point(0x47, 0x126);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x2f, 12);
            this.label1.TabIndex = 0x4f;
            this.label1.Text = "P1库存:";
            this.label01.AutoSize = true;
            this.label01.Location = new Point(0x72, 0x126);
            this.label01.Name = "label01";
            this.label01.Size = new Size(0x17, 12);
            this.label01.TabIndex = 80;
            this.label01.Text = "-20";
            this.label02.AutoSize = true;
            this.label02.Location = new Point(0xba, 0x126);
            this.label02.Name = "label02";
            this.label02.Size = new Size(0x17, 12);
            this.label02.TabIndex = 0x52;
            this.label02.Text = "-20";
            this.label4.AutoSize = true;
            this.label4.Location = new Point(0x8f, 0x126);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x2f, 12);
            this.label4.TabIndex = 0x51;
            this.label4.Text = "P2库存:";
            this.label03.AutoSize = true;
            this.label03.Location = new Point(0x102, 0x126);
            this.label03.Name = "label03";
            this.label03.Size = new Size(0x17, 12);
            this.label03.TabIndex = 0x54;
            this.label03.Text = "-20";
            this.label6.AutoSize = true;
            this.label6.Location = new Point(0xd7, 0x126);
            this.label6.Name = "label6";
            this.label6.Size = new Size(0x2f, 12);
            this.label6.TabIndex = 0x53;
            this.label6.Text = "P3库存:";
            this.label04.AutoSize = true;
            this.label04.Location = new Point(330, 0x126);
            this.label04.Name = "label04";
            this.label04.Size = new Size(0x17, 12);
            this.label04.TabIndex = 0x56;
            this.label04.Text = "-20";
            this.label8.AutoSize = true;
            this.label8.Location = new Point(0x11f, 0x126);
            this.label8.Name = "label8";
            this.label8.Size = new Size(0x2f, 12);
            this.label8.TabIndex = 0x55;
            this.label8.Text = "P4库存:";
            this.label9.AutoSize = true;
            this.label9.Location = new Point(12, 0x126);
            this.label9.Name = "label9";
            this.label9.Size = new Size(0x35, 12);
            this.label9.TabIndex = 0x57;
            this.label9.Text = "库存情况";
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.CancelButton = this.buttonCancel;
            base.ClientSize = new Size(0x263, 0x1e5);
            base.Controls.Add(this.label9);
            base.Controls.Add(this.label04);
            base.Controls.Add(this.label8);
            base.Controls.Add(this.label03);
            base.Controls.Add(this.label6);
            base.Controls.Add(this.label02);
            base.Controls.Add(this.label4);
            base.Controls.Add(this.label01);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.groupBox3);
            base.Controls.Add(this.groupBox1);
            base.Controls.Add(this.groupBox2);
            base.Controls.Add(this.buttonCancel);
            base.Controls.Add(this.buttonOK);
            base.FormBorderStyle = FormBorderStyle.FixedDialog;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "frmJHGKH";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "frmJHGKH";
            base.Load += new EventHandler(this.frmJHGKH_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((ISupportInitialize) this.dataGridViewWYDD).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((ISupportInitialize) this.dataGridViewBNDD).EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void initKC()
        {
            this.label01.Text = (TGlobals.currentActor.P1Warehouse.InventoryAmount / 2).ToString();
            this.label02.Text = (TGlobals.currentActor.P2Warehouse.InventoryAmount / 3).ToString();
            this.label03.Text = (TGlobals.currentActor.P3Warehouse.InventoryAmount / 4).ToString();
            this.label04.Text = (TGlobals.currentActor.P4Warehouse.InventoryAmount / 5).ToString();
        }

        private void JBNWWYDD(Year year, string id, ProductAttribute pda, int CB, int JE, int ZQ)
        {
            TGlobals.currentActor.JFBNWWYDD(year, id, pda);
            switch (ZQ)
            {
                case 0:
                    TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.CurrentCash += JE;
                    break;

                case 1:
                    TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.ReceivableAccountsQ1 += JE;
                    break;

                case 2:
                    TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.ReceivableAccountsQ2 += JE;
                    break;

                case 3:
                    TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.ReceivableAccountsQ3 += JE;
                    break;

                case 4:
                    TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.ReceivableAccountsQ4 += JE;
                    break;

                default:
                    break;
            }
            switch (pda)
            {
                case ProductAttribute.P1:
                    TGlobals.currentActor.P1Warehouse.InventoryAmount -= CB;
                    TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.FinishedProduct -= CB;
                    return;

                case ProductAttribute.P2:
                    TGlobals.currentActor.P2Warehouse.InventoryAmount -= CB;
                    TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.FinishedProduct -= CB;
                    return;

                case ProductAttribute.P3:
                    TGlobals.currentActor.P3Warehouse.InventoryAmount -= CB;
                    TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.FinishedProduct -= CB;
                    return;

                case ProductAttribute.P4:
                    TGlobals.currentActor.P4Warehouse.InventoryAmount -= CB;
                    TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.FinishedProduct -= CB;
                    return;
            }
        }

        private void JFWYDD(Year year, string id, ProductAttribute pda, int CB, int JE, int ZQ, int FK)
        {
            TGlobals.currentActor.JFWYDD(year, id, pda);
            int num = JE - FK;
            switch (ZQ)
            {
                case 0:
                    TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.CurrentCash += num;
                    break;

                case 1:
                    TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.ReceivableAccountsQ1 += num;
                    break;

                case 2:
                    TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.ReceivableAccountsQ2 += num;
                    break;

                case 3:
                    TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.ReceivableAccountsQ3 += num;
                    break;

                case 4:
                    TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.ReceivableAccountsQ4 += num;
                    break;

                default:
                    break;
            }
            switch (pda)
            {
                case ProductAttribute.P1:
                    TGlobals.currentActor.P1Warehouse.InventoryAmount -= CB;
                    TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.FinishedProduct -= CB;
                    return;

                case ProductAttribute.P2:
                    TGlobals.currentActor.P2Warehouse.InventoryAmount -= CB;
                    TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.FinishedProduct -= CB;
                    return;

                case ProductAttribute.P3:
                    TGlobals.currentActor.P3Warehouse.InventoryAmount -= CB;
                    TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.FinishedProduct -= CB;
                    return;

                case ProductAttribute.P4:
                    TGlobals.currentActor.P4Warehouse.InventoryAmount -= CB;
                    TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.FinishedProduct -= CB;
                    return;
            }
        }

        private void SetWYDD()
        {
            bool flag = false;
            for (int i = 0; i < this.dataGridViewWYDD.RowCount; i++)
            {
                string orderid = this.dataGridViewWYDD.Rows[i].Cells["编号"].Value.ToString();
                string str2 = this.dataGridViewWYDD.Rows[i].Cells["产品"].Value.ToString();
                ProductAttribute productname = ProductAttribute.无;
                string str3 = str2;
                if (str3 != null)
                {
                    if (str3 == "P1")
                    {
                        productname = ProductAttribute.P1;
                    }
                    else if (str3 == "P2")
                    {
                        productname = ProductAttribute.P2;
                    }
                    else if (str3 == "P3")
                    {
                        productname = ProductAttribute.P3;
                    }
                    else if (str3 == "P4")
                    {
                        productname = ProductAttribute.P4;
                    }
                }
                TOrder order = new TOrder(Year.第0年, Market.本地, orderid, productname, (int) this.dataGridViewWYDD.Rows[i].Cells["数量"].Value, (int) this.dataGridViewWYDD.Rows[i].Cells["单价"].Value, (int) this.dataGridViewWYDD.Rows[i].Cells["账期"].Value, ISOQualify.无);
                TGlobals.currentActor.AddOrderToBreakPromisedList(order);
                flag = true;
            }
            for (int j = 0; j < this.dataGridViewBNDD.RowCount; j++)
            {
                string orderid = this.dataGridViewBNDD.Rows[j].Cells["编号W"].Value.ToString();
                string str5 = this.dataGridViewBNDD.Rows[j].Cells["产品W"].Value.ToString();
                ProductAttribute productname = ProductAttribute.无;
                string str6 = str5;
                if (str6 != null)
                {
                    if (str6 == "P1")
                    {
                        productname = ProductAttribute.P1;
                    }
                    else if (str6 == "P2")
                    {
                        productname = ProductAttribute.P2;
                    }
                    else if (str6 == "P3")
                    {
                        productname = ProductAttribute.P3;
                    }
                    else if (str6 == "P4")
                    {
                        productname = ProductAttribute.P4;
                    }
                }
                TOrder order = new TOrder(Year.第0年, Market.本地, orderid, productname, (int) this.dataGridViewBNDD.Rows[j].Cells["数量W"].Value, (int) this.dataGridViewBNDD.Rows[j].Cells["单价W"].Value, (int) this.dataGridViewBNDD.Rows[j].Cells["账期W"].Value, ISOQualify.无);
                TGlobals.currentActor.AddOrderToBreakPromisedList(order);
                flag = true;
            }
            if (flag)
            {
                TGlobals.currentActor.IsAsiaMarketLeader = false;
                TGlobals.currentActor.IsDomesticMarketLeader = false;
                TGlobals.currentActor.IsInternationalMarketLeader = false;
                TGlobals.currentActor.IsLocalMarkertLeader = false;
                TGlobals.currentActor.IsRegionalMarketLeader = false;
            }
        }
    }
}

