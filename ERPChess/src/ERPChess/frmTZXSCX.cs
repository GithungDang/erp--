namespace ERPChess
{
    using BusinessTier;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmTZXSCX : Form
    {
        private IContainer components;
        private Button buttonCancel;
        private Button buttonOK;
        private TabPage tabPage6;
        private DataGridView dataGridViewZTSCX;
        private TabPage tabPage1;
        private DataGridView dataGridViewTZXSCX;
        private GroupBox groupBox1;
        private RichTextBox richTextBox2;
        private Button buttonSC;
        private Button buttonZJ;
        private Label label6;
        private Label label3;
        private Label label5;
        private ComboBox comboBoxSSCF;
        private ComboBox comboBoxXSCXLX;
        private ComboBox comboBoxSCCPLX;
        private TabControl tabControl1;
        private TabPage tabPage2;
        private DataGridView dataGridViewZCSCX;
        private Label label1;
        private DataGridViewCheckBoxColumn 再投选择项;
        private DataGridViewTextBoxColumn 再投生产线编号;
        private DataGridViewTextBoxColumn 再投所属厂房;
        private DataGridViewTextBoxColumn 再投生产线类型;
        private DataGridViewTextBoxColumn 再投产品类型;
        private DataGridViewTextBoxColumn 累计投资额;
        private DataGridViewTextBoxColumn 剩余建设时间;
        private DataGridViewTextBoxColumn 编号;
        private DataGridViewTextBoxColumn 厂房;
        private DataGridViewTextBoxColumn 新生产线类型;
        private DataGridViewTextBoxColumn 生产产品;
        private DataGridViewCheckBoxColumn 选择项;
        private DataGridViewTextBoxColumn 生产线编号;
        private DataGridViewTextBoxColumn 所属厂房;
        private DataGridViewTextBoxColumn 生产线类型;
        private DataGridViewTextBoxColumn 产品类型;
        private DataGridViewTextBoxColumn 转产周期;
        private DataGridViewComboBoxColumn 转产类型;

        public frmTZXSCX()
        {
            this.InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.TZXZCXOK();
            this.ZCSCXOK();
            this.ZTSCXOK();
        }

        private void buttonSC_Click(object sender, EventArgs e)
        {
            if (this.dataGridViewTZXSCX.Rows.Count != 0)
            {
                this.dataGridViewTZXSCX.Rows.Remove(this.dataGridViewTZXSCX.SelectedRows[0]);
            }
        }

        private void buttonZJ_Click(object sender, EventArgs e)
        {
            string str = this.comboBoxSSCF.SelectedItem.ToString();
            string str2 = this.comboBoxXSCXLX.SelectedItem.ToString();
            string str3 = this.comboBoxSCCPLX.SelectedItem.ToString();
            string str4 = str;
            if (str4 != null)
            {
                if (str4 == "工厂A")
                {
                    if (TGlobals.currentActor.PlantA.PL1.PLAttribute == ProductLineAttribute.无)
                    {
                        bool flag5 = false;
                        int num5 = 0;
                        while (true)
                        {
                            if (num5 >= this.dataGridViewTZXSCX.Rows.Count)
                            {
                                if (flag5)
                                {
                                    break;
                                }
                                this.dataGridViewTZXSCX.Rows.Add();
                                this.dataGridViewTZXSCX.Rows[this.dataGridViewTZXSCX.Rows.Count - 1].Cells["编号"].Value = "PL1";
                                this.dataGridViewTZXSCX.Rows[this.dataGridViewTZXSCX.Rows.Count - 1].Cells["厂房"].Value = str;
                                this.dataGridViewTZXSCX.Rows[this.dataGridViewTZXSCX.Rows.Count - 1].Cells["新生产线类型"].Value = str2;
                                this.dataGridViewTZXSCX.Rows[this.dataGridViewTZXSCX.Rows.Count - 1].Cells["生产产品"].Value = str3;
                                return;
                            }
                            if (this.dataGridViewTZXSCX.Rows[num5].Cells["编号"].Value.ToString() == "PL1")
                            {
                                flag5 = true;
                            }
                            num5++;
                        }
                    }
                    if (TGlobals.currentActor.PlantA.PL2.PLAttribute == ProductLineAttribute.无)
                    {
                        bool flag6 = false;
                        int num6 = 0;
                        while (true)
                        {
                            if (num6 >= this.dataGridViewTZXSCX.Rows.Count)
                            {
                                if (flag6)
                                {
                                    break;
                                }
                                this.dataGridViewTZXSCX.Rows.Add();
                                this.dataGridViewTZXSCX.Rows[this.dataGridViewTZXSCX.Rows.Count - 1].Cells["编号"].Value = "PL2";
                                this.dataGridViewTZXSCX.Rows[this.dataGridViewTZXSCX.Rows.Count - 1].Cells["厂房"].Value = str;
                                this.dataGridViewTZXSCX.Rows[this.dataGridViewTZXSCX.Rows.Count - 1].Cells["新生产线类型"].Value = str2;
                                this.dataGridViewTZXSCX.Rows[this.dataGridViewTZXSCX.Rows.Count - 1].Cells["生产产品"].Value = str3;
                                return;
                            }
                            if (this.dataGridViewTZXSCX.Rows[num6].Cells["编号"].Value.ToString() == "PL2")
                            {
                                flag6 = true;
                            }
                            num6++;
                        }
                    }
                    if (TGlobals.currentActor.PlantA.PL3.PLAttribute == ProductLineAttribute.无)
                    {
                        bool flag7 = false;
                        int num7 = 0;
                        while (true)
                        {
                            if (num7 >= this.dataGridViewTZXSCX.Rows.Count)
                            {
                                if (flag7)
                                {
                                    break;
                                }
                                this.dataGridViewTZXSCX.Rows.Add();
                                this.dataGridViewTZXSCX.Rows[this.dataGridViewTZXSCX.Rows.Count - 1].Cells["编号"].Value = "PL3";
                                this.dataGridViewTZXSCX.Rows[this.dataGridViewTZXSCX.Rows.Count - 1].Cells["厂房"].Value = str;
                                this.dataGridViewTZXSCX.Rows[this.dataGridViewTZXSCX.Rows.Count - 1].Cells["新生产线类型"].Value = str2;
                                this.dataGridViewTZXSCX.Rows[this.dataGridViewTZXSCX.Rows.Count - 1].Cells["生产产品"].Value = str3;
                                return;
                            }
                            if (this.dataGridViewTZXSCX.Rows[num7].Cells["编号"].Value.ToString() == "PL3")
                            {
                                flag7 = true;
                            }
                            num7++;
                        }
                    }
                    if (TGlobals.currentActor.PlantA.PL4.PLAttribute == ProductLineAttribute.无)
                    {
                        bool flag8 = false;
                        int num8 = 0;
                        while (true)
                        {
                            if (num8 >= this.dataGridViewTZXSCX.Rows.Count)
                            {
                                if (flag8)
                                {
                                    break;
                                }
                                this.dataGridViewTZXSCX.Rows.Add();
                                this.dataGridViewTZXSCX.Rows[this.dataGridViewTZXSCX.Rows.Count - 1].Cells["编号"].Value = "PL4";
                                this.dataGridViewTZXSCX.Rows[this.dataGridViewTZXSCX.Rows.Count - 1].Cells["厂房"].Value = str;
                                this.dataGridViewTZXSCX.Rows[this.dataGridViewTZXSCX.Rows.Count - 1].Cells["新生产线类型"].Value = str2;
                                this.dataGridViewTZXSCX.Rows[this.dataGridViewTZXSCX.Rows.Count - 1].Cells["生产产品"].Value = str3;
                                return;
                            }
                            if (this.dataGridViewTZXSCX.Rows[num8].Cells["编号"].Value.ToString() == "PL4")
                            {
                                flag8 = true;
                            }
                            num8++;
                        }
                    }
                    MessageBox.Show("A厂房可装配生产线的条数已满  ", "特别提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else if (str4 == "工厂B")
                {
                    if (TGlobals.currentActor.PlantB.PL5.PLAttribute == ProductLineAttribute.无)
                    {
                        bool flag2 = false;
                        int num2 = 0;
                        while (true)
                        {
                            if (num2 >= this.dataGridViewTZXSCX.Rows.Count)
                            {
                                if (flag2)
                                {
                                    break;
                                }
                                this.dataGridViewTZXSCX.Rows.Add();
                                this.dataGridViewTZXSCX.Rows[this.dataGridViewTZXSCX.Rows.Count - 1].Cells["编号"].Value = "PL5";
                                this.dataGridViewTZXSCX.Rows[this.dataGridViewTZXSCX.Rows.Count - 1].Cells["厂房"].Value = str;
                                this.dataGridViewTZXSCX.Rows[this.dataGridViewTZXSCX.Rows.Count - 1].Cells["新生产线类型"].Value = str2;
                                this.dataGridViewTZXSCX.Rows[this.dataGridViewTZXSCX.Rows.Count - 1].Cells["生产产品"].Value = str3;
                                return;
                            }
                            if (this.dataGridViewTZXSCX.Rows[num2].Cells["编号"].Value.ToString() == "PL5")
                            {
                                flag2 = true;
                            }
                            num2++;
                        }
                    }
                    if (TGlobals.currentActor.PlantB.PL6.PLAttribute == ProductLineAttribute.无)
                    {
                        bool flag3 = false;
                        int num3 = 0;
                        while (true)
                        {
                            if (num3 >= this.dataGridViewTZXSCX.Rows.Count)
                            {
                                if (flag3)
                                {
                                    break;
                                }
                                this.dataGridViewTZXSCX.Rows.Add();
                                this.dataGridViewTZXSCX.Rows[this.dataGridViewTZXSCX.Rows.Count - 1].Cells["编号"].Value = "PL6";
                                this.dataGridViewTZXSCX.Rows[this.dataGridViewTZXSCX.Rows.Count - 1].Cells["厂房"].Value = str;
                                this.dataGridViewTZXSCX.Rows[this.dataGridViewTZXSCX.Rows.Count - 1].Cells["新生产线类型"].Value = str2;
                                this.dataGridViewTZXSCX.Rows[this.dataGridViewTZXSCX.Rows.Count - 1].Cells["生产产品"].Value = str3;
                                return;
                            }
                            if (this.dataGridViewTZXSCX.Rows[num3].Cells["编号"].Value.ToString() == "PL6")
                            {
                                flag3 = true;
                            }
                            num3++;
                        }
                    }
                    if (TGlobals.currentActor.PlantB.PL7.PLAttribute == ProductLineAttribute.无)
                    {
                        bool flag4 = false;
                        int num4 = 0;
                        while (true)
                        {
                            if (num4 >= this.dataGridViewTZXSCX.Rows.Count)
                            {
                                if (flag4)
                                {
                                    break;
                                }
                                this.dataGridViewTZXSCX.Rows.Add();
                                this.dataGridViewTZXSCX.Rows[this.dataGridViewTZXSCX.Rows.Count - 1].Cells["编号"].Value = "PL7";
                                this.dataGridViewTZXSCX.Rows[this.dataGridViewTZXSCX.Rows.Count - 1].Cells["厂房"].Value = str;
                                this.dataGridViewTZXSCX.Rows[this.dataGridViewTZXSCX.Rows.Count - 1].Cells["新生产线类型"].Value = str2;
                                this.dataGridViewTZXSCX.Rows[this.dataGridViewTZXSCX.Rows.Count - 1].Cells["生产产品"].Value = str3;
                                return;
                            }
                            if (this.dataGridViewTZXSCX.Rows[num4].Cells["编号"].Value.ToString() == "PL7")
                            {
                                flag4 = true;
                            }
                            num4++;
                        }
                    }
                    MessageBox.Show("B厂房可装配生产线的条数已满  ", "特别提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else if (str4 == "工厂C")
                {
                    if (TGlobals.currentActor.PlantC.PL8.PLAttribute == ProductLineAttribute.无)
                    {
                        bool flag = false;
                        int num = 0;
                        while (true)
                        {
                            if (num >= this.dataGridViewTZXSCX.Rows.Count)
                            {
                                if (flag)
                                {
                                    break;
                                }
                                this.dataGridViewTZXSCX.Rows.Add();
                                this.dataGridViewTZXSCX.Rows[this.dataGridViewTZXSCX.Rows.Count - 1].Cells["编号"].Value = "PL8";
                                this.dataGridViewTZXSCX.Rows[this.dataGridViewTZXSCX.Rows.Count - 1].Cells["厂房"].Value = str;
                                this.dataGridViewTZXSCX.Rows[this.dataGridViewTZXSCX.Rows.Count - 1].Cells["新生产线类型"].Value = str2;
                                this.dataGridViewTZXSCX.Rows[this.dataGridViewTZXSCX.Rows.Count - 1].Cells["生产产品"].Value = str3;
                                return;
                            }
                            if (this.dataGridViewTZXSCX.Rows[num].Cells["编号"].Value.ToString() == "PL8")
                            {
                                flag = true;
                            }
                            num++;
                        }
                    }
                    MessageBox.Show("C厂房可装配生产线的条数已满  ", "特别提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }

        private void comboBoxXSCXLX_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = this.comboBoxXSCXLX.SelectedItem.ToString();
            if (str != null)
            {
                if (str == "手工")
                {
                    this.comboBoxSCCPLX.Items.Clear();
                    this.comboBoxSCCPLX.Items.Add("所有许可产品");
                    this.comboBoxSCCPLX.SelectedIndex = 0;
                }
                else if ((str == "半自动") || (str == "全自动"))
                {
                    this.comboBoxSCCPLX.Items.Clear();
                    this.comboBoxSCCPLX.Items.Add(ProductAttribute.P1);
                    this.comboBoxSCCPLX.Items.Add(ProductAttribute.P2);
                    this.comboBoxSCCPLX.Items.Add(ProductAttribute.P3);
                    this.comboBoxSCCPLX.Items.Add(ProductAttribute.P4);
                    this.comboBoxSCCPLX.SelectedIndex = 0;
                }
                else if (str == "柔性")
                {
                    this.comboBoxSCCPLX.Items.Clear();
                    this.comboBoxSCCPLX.Items.Add("所有许可产品");
                    this.comboBoxSCCPLX.SelectedIndex = 0;
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void frmTZXSCX_Load(object sender, EventArgs e)
        {
            this.ZCSCX();
            this.TZXSCX();
            this.ZTSCX();
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
            DataGridViewCellStyle style16 = new DataGridViewCellStyle();
            DataGridViewCellStyle style17 = new DataGridViewCellStyle();
            DataGridViewCellStyle style18 = new DataGridViewCellStyle();
            DataGridViewCellStyle style19 = new DataGridViewCellStyle();
            DataGridViewCellStyle style20 = new DataGridViewCellStyle();
            DataGridViewCellStyle style21 = new DataGridViewCellStyle();
            DataGridViewCellStyle style22 = new DataGridViewCellStyle();
            DataGridViewCellStyle style23 = new DataGridViewCellStyle();
            this.buttonCancel = new Button();
            this.buttonOK = new Button();
            this.tabPage6 = new TabPage();
            this.dataGridViewZTSCX = new DataGridView();
            this.再投选择项 = new DataGridViewCheckBoxColumn();
            this.再投生产线编号 = new DataGridViewTextBoxColumn();
            this.再投所属厂房 = new DataGridViewTextBoxColumn();
            this.再投生产线类型 = new DataGridViewTextBoxColumn();
            this.再投产品类型 = new DataGridViewTextBoxColumn();
            this.累计投资额 = new DataGridViewTextBoxColumn();
            this.剩余建设时间 = new DataGridViewTextBoxColumn();
            this.tabPage1 = new TabPage();
            this.label1 = new Label();
            this.dataGridViewTZXSCX = new DataGridView();
            this.编号 = new DataGridViewTextBoxColumn();
            this.厂房 = new DataGridViewTextBoxColumn();
            this.新生产线类型 = new DataGridViewTextBoxColumn();
            this.生产产品 = new DataGridViewTextBoxColumn();
            this.groupBox1 = new GroupBox();
            this.richTextBox2 = new RichTextBox();
            this.buttonSC = new Button();
            this.buttonZJ = new Button();
            this.label6 = new Label();
            this.label3 = new Label();
            this.label5 = new Label();
            this.comboBoxSSCF = new ComboBox();
            this.comboBoxXSCXLX = new ComboBox();
            this.comboBoxSCCPLX = new ComboBox();
            this.tabControl1 = new TabControl();
            this.tabPage2 = new TabPage();
            this.dataGridViewZCSCX = new DataGridView();
            this.选择项 = new DataGridViewCheckBoxColumn();
            this.生产线编号 = new DataGridViewTextBoxColumn();
            this.所属厂房 = new DataGridViewTextBoxColumn();
            this.生产线类型 = new DataGridViewTextBoxColumn();
            this.产品类型 = new DataGridViewTextBoxColumn();
            this.转产周期 = new DataGridViewTextBoxColumn();
            this.转产类型 = new DataGridViewComboBoxColumn();
            this.tabPage6.SuspendLayout();
            ((ISupportInitialize) this.dataGridViewZTSCX).BeginInit();
            this.tabPage1.SuspendLayout();
            ((ISupportInitialize) this.dataGridViewTZXSCX).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((ISupportInitialize) this.dataGridViewZCSCX).BeginInit();
            base.SuspendLayout();
            this.buttonCancel.DialogResult = DialogResult.Cancel;
            this.buttonCancel.Location = new Point(0x24a, 0x12a);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new Size(0x4b, 0x17);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonOK.DialogResult = DialogResult.OK;
            this.buttonOK.Location = new Point(0x1f9, 0x12a);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new Size(0x4b, 0x17);
            this.buttonOK.TabIndex = 1;
            this.buttonOK.Text = "确定";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new EventHandler(this.buttonOK_Click);
            this.tabPage6.Controls.Add(this.dataGridViewZTSCX);
            this.tabPage6.Location = new Point(4, 0x15);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new Padding(3);
            this.tabPage6.Size = new Size(0x291, 0x10b);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "再投生产线";
            this.tabPage6.UseVisualStyleBackColor = true;
            this.dataGridViewZTSCX.AllowUserToAddRows = false;
            this.dataGridViewZTSCX.AllowUserToDeleteRows = false;
            this.dataGridViewZTSCX.AllowUserToResizeRows = false;
            this.dataGridViewZTSCX.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridViewColumn[] dataGridViewColumns = new DataGridViewColumn[] { this.再投选择项, this.再投生产线编号, this.再投所属厂房, this.再投生产线类型, this.再投产品类型, this.累计投资额, this.剩余建设时间 };
            this.dataGridViewZTSCX.Columns.AddRange(dataGridViewColumns);
            style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            style.BackColor = SystemColors.Window;
            style.Font = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            style.ForeColor = SystemColors.ControlText;
            style.SelectionBackColor = SystemColors.Highlight;
            style.SelectionForeColor = SystemColors.HighlightText;
            style.WrapMode = DataGridViewTriState.False;
            this.dataGridViewZTSCX.DefaultCellStyle = style;
            this.dataGridViewZTSCX.Dock = DockStyle.Fill;
            this.dataGridViewZTSCX.Location = new Point(3, 3);
            this.dataGridViewZTSCX.MultiSelect = false;
            this.dataGridViewZTSCX.Name = "dataGridViewZTSCX";
            this.dataGridViewZTSCX.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            style2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            style2.BackColor = SystemColors.Control;
            style2.Font = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            style2.ForeColor = SystemColors.WindowText;
            style2.SelectionBackColor = SystemColors.Highlight;
            style2.SelectionForeColor = SystemColors.HighlightText;
            style2.WrapMode = DataGridViewTriState.True;
            this.dataGridViewZTSCX.RowHeadersDefaultCellStyle = style2;
            this.dataGridViewZTSCX.RowHeadersVisible = false;
            style3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewZTSCX.RowsDefaultCellStyle = style3;
            this.dataGridViewZTSCX.RowTemplate.Height = 0x17;
            this.dataGridViewZTSCX.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewZTSCX.Size = new Size(0x28b, 0x105);
            this.dataGridViewZTSCX.TabIndex = 0x4a;
            this.再投选择项.HeaderText = "选择项";
            this.再投选择项.Name = "再投选择项";
            this.再投选择项.Resizable = DataGridViewTriState.False;
            this.再投选择项.Width = 70;
            style4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.再投生产线编号.DefaultCellStyle = style4;
            this.再投生产线编号.HeaderText = "生产线编号";
            this.再投生产线编号.Name = "再投生产线编号";
            this.再投生产线编号.ReadOnly = true;
            this.再投生产线编号.Resizable = DataGridViewTriState.False;
            this.再投生产线编号.SortMode = DataGridViewColumnSortMode.NotSortable;
            this.再投生产线编号.Width = 0x4b;
            style5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.再投所属厂房.DefaultCellStyle = style5;
            this.再投所属厂房.HeaderText = "所属厂房";
            this.再投所属厂房.Name = "再投所属厂房";
            this.再投所属厂房.ReadOnly = true;
            this.再投所属厂房.Resizable = DataGridViewTriState.False;
            this.再投所属厂房.SortMode = DataGridViewColumnSortMode.NotSortable;
            this.再投所属厂房.Width = 70;
            style6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.再投生产线类型.DefaultCellStyle = style6;
            this.再投生产线类型.HeaderText = "生产线类型";
            this.再投生产线类型.Name = "再投生产线类型";
            this.再投生产线类型.ReadOnly = true;
            this.再投生产线类型.Resizable = DataGridViewTriState.False;
            this.再投生产线类型.SortMode = DataGridViewColumnSortMode.NotSortable;
            this.再投生产线类型.Width = 0x4b;
            style7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.再投产品类型.DefaultCellStyle = style7;
            this.再投产品类型.HeaderText = "产品类型";
            this.再投产品类型.Name = "再投产品类型";
            this.再投产品类型.ReadOnly = true;
            this.再投产品类型.Resizable = DataGridViewTriState.False;
            this.再投产品类型.SortMode = DataGridViewColumnSortMode.NotSortable;
            this.再投产品类型.Width = 70;
            style8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.累计投资额.DefaultCellStyle = style8;
            this.累计投资额.HeaderText = "累计投资额";
            this.累计投资额.Name = "累计投资额";
            this.累计投资额.ReadOnly = true;
            this.累计投资额.Resizable = DataGridViewTriState.False;
            this.累计投资额.SortMode = DataGridViewColumnSortMode.NotSortable;
            this.累计投资额.Width = 0x4b;
            style9.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.剩余建设时间.DefaultCellStyle = style9;
            this.剩余建设时间.HeaderText = "剩余建设时间";
            this.剩余建设时间.Name = "剩余建设时间";
            this.剩余建设时间.ReadOnly = true;
            this.剩余建设时间.Resizable = DataGridViewTriState.False;
            this.剩余建设时间.SortMode = DataGridViewColumnSortMode.NotSortable;
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.dataGridViewTZXSCX);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.buttonSC);
            this.tabPage1.Controls.Add(this.buttonZJ);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.comboBoxSSCF);
            this.tabPage1.Controls.Add(this.comboBoxXSCXLX);
            this.tabPage1.Controls.Add(this.comboBoxSCCPLX);
            this.tabPage1.Location = new Point(4, 0x15);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new Padding(3);
            this.tabPage1.Size = new Size(0x291, 0x10b);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "投资新生产线";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.label1.AutoSize = true;
            this.label1.Location = new Point(0x138, 0xf3);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x29, 12);
            this.label1.TabIndex = 0x49;
            this.label1.Text = "label1";
            this.dataGridViewTZXSCX.AllowUserToAddRows = false;
            this.dataGridViewTZXSCX.AllowUserToDeleteRows = false;
            this.dataGridViewTZXSCX.AllowUserToResizeRows = false;
            style10.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTZXSCX.AlternatingRowsDefaultCellStyle = style10;
            this.dataGridViewTZXSCX.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridViewColumn[] columnArray2 = new DataGridViewColumn[] { this.编号, this.厂房, this.新生产线类型, this.生产产品 };
            this.dataGridViewTZXSCX.Columns.AddRange(columnArray2);
            this.dataGridViewTZXSCX.Location = new Point(0x138, 14);
            this.dataGridViewTZXSCX.MultiSelect = false;
            this.dataGridViewTZXSCX.Name = "dataGridViewTZXSCX";
            this.dataGridViewTZXSCX.ReadOnly = true;
            this.dataGridViewTZXSCX.RowHeadersVisible = false;
            this.dataGridViewTZXSCX.RowTemplate.Height = 0x17;
            this.dataGridViewTZXSCX.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTZXSCX.Size = new Size(0x150, 0xd6);
            this.dataGridViewTZXSCX.TabIndex = 0x48;
            style11.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.编号.DefaultCellStyle = style11;
            this.编号.HeaderText = "编号";
            this.编号.Name = "编号";
            this.编号.ReadOnly = true;
            this.编号.Resizable = DataGridViewTriState.False;
            this.编号.Width = 0x36;
            style12.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.厂房.DefaultCellStyle = style12;
            this.厂房.HeaderText = "所属厂房";
            this.厂房.Name = "厂房";
            this.厂房.ReadOnly = true;
            this.厂房.Resizable = DataGridViewTriState.False;
            this.厂房.Width = 90;
            style13.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.新生产线类型.DefaultCellStyle = style13;
            this.新生产线类型.HeaderText = "生产线类型";
            this.新生产线类型.Name = "新生产线类型";
            this.新生产线类型.ReadOnly = true;
            this.新生产线类型.Resizable = DataGridViewTriState.False;
            this.新生产线类型.Width = 90;
            style14.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.生产产品.DefaultCellStyle = style14;
            this.生产产品.HeaderText = "生产产品";
            this.生产产品.Name = "生产产品";
            this.生产产品.ReadOnly = true;
            this.生产产品.Resizable = DataGridViewTriState.False;
            this.生产产品.Width = 90;
            this.groupBox1.Controls.Add(this.richTextBox2);
            this.groupBox1.Location = new Point(13, 0x4e);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x125, 0xb6);
            this.groupBox1.TabIndex = 0x47;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "说明";
            this.richTextBox2.BackColor = SystemColors.Window;
            this.richTextBox2.BorderStyle = BorderStyle.None;
            this.richTextBox2.Dock = DockStyle.Fill;
            this.richTextBox2.Font = new Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.richTextBox2.Location = new Point(3, 0x11);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.Size = new Size(0x11f, 0xa2);
            this.richTextBox2.TabIndex = 1;
            this.richTextBox2.Text = "    一个设备供应商将在某生产线上安装新的设备。被更换的生产线必须被清空方可开始安装。这意味着旧的生产线设备必须被移走后，新的安装方可开始，旧设备可以按其残值变现。在旧的设备售出时其残值以现金方式收回。\n    投资于生产线的支付不一定需要持续，也即你可以在支付过程中停顿。如果你停顿支付，那么整体的生产线完工时间也将延长。";
            this.buttonSC.Location = new Point(0x21e, 0xee);
            this.buttonSC.Name = "buttonSC";
            this.buttonSC.Size = new Size(50, 0x17);
            this.buttonSC.TabIndex = 70;
            this.buttonSC.Text = "删除";
            this.buttonSC.UseVisualStyleBackColor = true;
            this.buttonSC.Click += new EventHandler(this.buttonSC_Click);
            this.buttonZJ.Location = new Point(0x256, 0xef);
            this.buttonZJ.Name = "buttonZJ";
            this.buttonZJ.Size = new Size(50, 0x17);
            this.buttonZJ.TabIndex = 0x45;
            this.buttonZJ.Text = "追加";
            this.buttonZJ.UseVisualStyleBackColor = true;
            this.buttonZJ.Click += new EventHandler(this.buttonZJ_Click);
            this.label6.BorderStyle = BorderStyle.FixedSingle;
            this.label6.Location = new Point(13, 0x34);
            this.label6.Name = "label6";
            this.label6.Size = new Size(100, 20);
            this.label6.TabIndex = 0x40;
            this.label6.Text = "生产产品类型";
            this.label6.TextAlign = ContentAlignment.MiddleCenter;
            this.label3.BorderStyle = BorderStyle.FixedSingle;
            this.label3.Location = new Point(13, 0x21);
            this.label3.Name = "label3";
            this.label3.Size = new Size(100, 20);
            this.label3.TabIndex = 0x3f;
            this.label3.Text = "新生产线类型";
            this.label3.TextAlign = ContentAlignment.MiddleCenter;
            this.label5.BorderStyle = BorderStyle.FixedSingle;
            this.label5.Location = new Point(13, 14);
            this.label5.Name = "label5";
            this.label5.Size = new Size(100, 20);
            this.label5.TabIndex = 0x3e;
            this.label5.Text = "所属厂房";
            this.label5.TextAlign = ContentAlignment.MiddleCenter;
            this.comboBoxSSCF.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxSSCF.FormattingEnabled = true;
            object[] items = new object[] { "A厂房", "B厂房", "C厂房" };
            this.comboBoxSSCF.Items.AddRange(items);
            this.comboBoxSSCF.Location = new Point(0x70, 14);
            this.comboBoxSSCF.Name = "comboBoxSSCF";
            this.comboBoxSSCF.Size = new Size(0xc2, 20);
            this.comboBoxSSCF.TabIndex = 0x41;
            this.comboBoxXSCXLX.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxXSCXLX.FormattingEnabled = true;
            object[] objArray2 = new object[] { "手工生产线", "半自动生产线", "全自动生产线", "柔性生产线" };
            this.comboBoxXSCXLX.Items.AddRange(objArray2);
            this.comboBoxXSCXLX.Location = new Point(0x70, 0x21);
            this.comboBoxXSCXLX.Name = "comboBoxXSCXLX";
            this.comboBoxXSCXLX.Size = new Size(0xc2, 20);
            this.comboBoxXSCXLX.TabIndex = 0x42;
            this.comboBoxXSCXLX.SelectedIndexChanged += new EventHandler(this.comboBoxXSCXLX_SelectedIndexChanged);
            this.comboBoxSCCPLX.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxSCCPLX.FormattingEnabled = true;
            object[] objArray3 = new object[] { "P1", "P2", "P3", "P4" };
            this.comboBoxSCCPLX.Items.AddRange(objArray3);
            this.comboBoxSCCPLX.Location = new Point(0x70, 0x34);
            this.comboBoxSCCPLX.Name = "comboBoxSCCPLX";
            this.comboBoxSCCPLX.Size = new Size(0xc2, 20);
            this.comboBoxSCCPLX.TabIndex = 0x43;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = DockStyle.Top;
            this.tabControl1.Location = new Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new Size(0x299, 0x124);
            this.tabControl1.TabIndex = 11;
            this.tabPage2.Controls.Add(this.dataGridViewZCSCX);
            this.tabPage2.Location = new Point(4, 0x15);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new Size(0x291, 0x10b);
            this.tabPage2.TabIndex = 6;
            this.tabPage2.Text = "生产线转产";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.dataGridViewZCSCX.AllowUserToAddRows = false;
            this.dataGridViewZCSCX.AllowUserToDeleteRows = false;
            this.dataGridViewZCSCX.AllowUserToResizeRows = false;
            style15.Alignment = DataGridViewContentAlignment.MiddleCenter;
            style15.BackColor = SystemColors.Control;
            style15.Font = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            style15.ForeColor = SystemColors.WindowText;
            style15.SelectionBackColor = SystemColors.Highlight;
            style15.SelectionForeColor = SystemColors.HighlightText;
            style15.WrapMode = DataGridViewTriState.True;
            this.dataGridViewZCSCX.ColumnHeadersDefaultCellStyle = style15;
            this.dataGridViewZCSCX.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridViewColumn[] columnArray3 = new DataGridViewColumn[] { this.选择项, this.生产线编号, this.所属厂房, this.生产线类型, this.产品类型, this.转产周期, this.转产类型 };
            this.dataGridViewZCSCX.Columns.AddRange(columnArray3);
            style16.Alignment = DataGridViewContentAlignment.MiddleCenter;
            style16.BackColor = SystemColors.Window;
            style16.Font = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            style16.ForeColor = SystemColors.ControlText;
            style16.SelectionBackColor = SystemColors.Highlight;
            style16.SelectionForeColor = SystemColors.HighlightText;
            style16.WrapMode = DataGridViewTriState.False;
            this.dataGridViewZCSCX.DefaultCellStyle = style16;
            this.dataGridViewZCSCX.Dock = DockStyle.Fill;
            this.dataGridViewZCSCX.Location = new Point(0, 0);
            this.dataGridViewZCSCX.MultiSelect = false;
            this.dataGridViewZCSCX.Name = "dataGridViewZCSCX";
            this.dataGridViewZCSCX.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            style17.Alignment = DataGridViewContentAlignment.MiddleCenter;
            style17.BackColor = SystemColors.Control;
            style17.Font = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            style17.ForeColor = SystemColors.WindowText;
            style17.SelectionBackColor = SystemColors.Highlight;
            style17.SelectionForeColor = SystemColors.HighlightText;
            style17.WrapMode = DataGridViewTriState.True;
            this.dataGridViewZCSCX.RowHeadersDefaultCellStyle = style17;
            this.dataGridViewZCSCX.RowHeadersVisible = false;
            style18.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewZCSCX.RowsDefaultCellStyle = style18;
            this.dataGridViewZCSCX.RowTemplate.Height = 0x17;
            this.dataGridViewZCSCX.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewZCSCX.Size = new Size(0x291, 0x10b);
            this.dataGridViewZCSCX.TabIndex = 0x4b;
            this.选择项.HeaderText = "选择项";
            this.选择项.Name = "选择项";
            this.选择项.Resizable = DataGridViewTriState.False;
            this.选择项.Width = 70;
            style19.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.生产线编号.DefaultCellStyle = style19;
            this.生产线编号.HeaderText = "生产线编号";
            this.生产线编号.Name = "生产线编号";
            this.生产线编号.ReadOnly = true;
            this.生产线编号.Resizable = DataGridViewTriState.False;
            this.生产线编号.SortMode = DataGridViewColumnSortMode.NotSortable;
            this.生产线编号.Width = 0x55;
            style20.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.所属厂房.DefaultCellStyle = style20;
            this.所属厂房.HeaderText = "所属厂房";
            this.所属厂房.Name = "所属厂房";
            this.所属厂房.ReadOnly = true;
            this.所属厂房.Resizable = DataGridViewTriState.False;
            this.所属厂房.SortMode = DataGridViewColumnSortMode.NotSortable;
            this.所属厂房.Width = 70;
            style21.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.生产线类型.DefaultCellStyle = style21;
            this.生产线类型.HeaderText = "生产线类型";
            this.生产线类型.Name = "生产线类型";
            this.生产线类型.ReadOnly = true;
            this.生产线类型.Resizable = DataGridViewTriState.False;
            this.生产线类型.SortMode = DataGridViewColumnSortMode.NotSortable;
            this.生产线类型.Width = 70;
            style22.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.产品类型.DefaultCellStyle = style22;
            this.产品类型.HeaderText = "产品类型";
            this.产品类型.Name = "产品类型";
            this.产品类型.ReadOnly = true;
            this.产品类型.Resizable = DataGridViewTriState.False;
            this.产品类型.SortMode = DataGridViewColumnSortMode.NotSortable;
            this.产品类型.Width = 70;
            style23.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.转产周期.DefaultCellStyle = style23;
            this.转产周期.HeaderText = "转产周期";
            this.转产周期.Name = "转产周期";
            this.转产周期.ReadOnly = true;
            this.转产周期.Resizable = DataGridViewTriState.False;
            this.转产周期.SortMode = DataGridViewColumnSortMode.NotSortable;
            this.转产周期.Width = 70;
            this.转产类型.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            this.转产类型.HeaderText = "转产类型";
            object[] objArray4 = new object[] { "P1", "P2", "P3", "P4" };
            this.转产类型.Items.AddRange(objArray4);
            this.转产类型.Name = "转产类型";
            this.转产类型.Resizable = DataGridViewTriState.False;
            this.转产类型.Width = 0x5f;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.CancelButton = this.buttonCancel;
            base.ClientSize = new Size(0x299, 0x149);
            base.Controls.Add(this.buttonCancel);
            base.Controls.Add(this.buttonOK);
            base.Controls.Add(this.tabControl1);
            base.FormBorderStyle = FormBorderStyle.FixedDialog;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "frmTZXSCX";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "frmTZXSCX";
            base.Load += new EventHandler(this.frmTZXSCX_Load);
            this.tabPage6.ResumeLayout(false);
            ((ISupportInitialize) this.dataGridViewZTSCX).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((ISupportInitialize) this.dataGridViewTZXSCX).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((ISupportInitialize) this.dataGridViewZCSCX).EndInit();
            base.ResumeLayout(false);
        }

        private void TZXSCX()
        {
            this.comboBoxSSCF.Items.Clear();
            this.comboBoxXSCXLX.Items.Clear();
            this.comboBoxSCCPLX.Items.Clear();
            bool flag = false;
            if (TGlobals.currentActor.PlantA.PlantAttribute == PlantAttribute.无)
            {
                this.comboBoxSSCF.Items.Add(PlantName.工厂A);
                flag = true;
            }
            else if ((TGlobals.currentActor.PlantA.PL1.PLAttribute == ProductLineAttribute.无) || ((TGlobals.currentActor.PlantA.PL2.PLAttribute == ProductLineAttribute.无) || ((TGlobals.currentActor.PlantA.PL3.PLAttribute == ProductLineAttribute.无) || (TGlobals.currentActor.PlantA.PL4.PLAttribute == ProductLineAttribute.无))))
            {
                this.comboBoxSSCF.Items.Add(PlantName.工厂A);
                flag = true;
            }
            if (TGlobals.currentActor.PlantB.PlantAttribute == PlantAttribute.无)
            {
                this.comboBoxSSCF.Items.Add(PlantName.工厂B);
                flag = true;
            }
            else if ((TGlobals.currentActor.PlantB.PL5.PLAttribute == ProductLineAttribute.无) || ((TGlobals.currentActor.PlantB.PL6.PLAttribute == ProductLineAttribute.无) || (TGlobals.currentActor.PlantB.PL7.PLAttribute == ProductLineAttribute.无)))
            {
                this.comboBoxSSCF.Items.Add(PlantName.工厂B);
                flag = true;
            }
            if (TGlobals.currentActor.PlantC.PlantAttribute == PlantAttribute.无)
            {
                this.comboBoxSSCF.Items.Add(PlantName.工厂C);
                flag = true;
            }
            else if (TGlobals.currentActor.PlantC.PL8.PLAttribute == ProductLineAttribute.无)
            {
                this.comboBoxSSCF.Items.Add(PlantName.工厂C);
                flag = true;
            }
            if (!flag)
            {
                this.label1.Text = "所有厂房都已装满生产线";
                this.buttonSC.Enabled = false;
                this.buttonZJ.Enabled = false;
            }
            else
            {
                this.comboBoxSSCF.SelectedIndex = 0;
                this.label1.Text = "";
                this.buttonZJ.Enabled = true;
                this.buttonSC.Enabled = true;
                this.comboBoxXSCXLX.Items.Add(ProductLineAttribute.手工);
                this.comboBoxXSCXLX.Items.Add(ProductLineAttribute.半自动);
                this.comboBoxXSCXLX.Items.Add(ProductLineAttribute.全自动);
                this.comboBoxXSCXLX.Items.Add(ProductLineAttribute.柔性);
                this.comboBoxXSCXLX.SelectedIndex = 0;
            }
        }

        private void TZXZCXOK()
        {
            for (int i = 0; i < this.dataGridViewTZXSCX.Rows.Count; i++)
            {
                string str = this.dataGridViewTZXSCX.Rows[i].Cells["厂房"].Value.ToString();
                string str2 = this.dataGridViewTZXSCX.Rows[i].Cells["编号"].Value.ToString();
                string str3 = this.dataGridViewTZXSCX.Rows[i].Cells["新生产线类型"].Value.ToString();
                ProductLineAttribute pla = ProductLineAttribute.无;
                string str4 = str3;
                if (str4 != null)
                {
                    if (str4 == "手工")
                    {
                        pla = ProductLineAttribute.手工;
                    }
                    else if (str4 == "半自动")
                    {
                        pla = ProductLineAttribute.半自动;
                    }
                    else if (str4 == "全自动")
                    {
                        pla = ProductLineAttribute.全自动;
                    }
                    else if (str4 == "柔性")
                    {
                        pla = ProductLineAttribute.柔性;
                    }
                }
                ProductAttribute pda = ProductAttribute.无;
                str4 = this.dataGridViewTZXSCX.Rows[i].Cells["生产产品"].Value.ToString();
                if (str4 != null)
                {
                    if (str4 == "P1")
                    {
                        pda = ProductAttribute.P1;
                    }
                    else if (str4 == "P2")
                    {
                        pda = ProductAttribute.P2;
                    }
                    else if (str4 == "P3")
                    {
                        pda = ProductAttribute.P3;
                    }
                    else if (str4 == "P4")
                    {
                        pda = ProductAttribute.P4;
                    }
                    else if (str4 == "所有许可产品")
                    {
                        pda = ProductAttribute.全部;
                    }
                }
                str4 = str;
                if (str4 != null)
                {
                    if (str4 == "工厂A")
                    {
                        if (TGlobals.currentActor.PlantA.PlantAttribute == PlantAttribute.无)
                        {
                            TGlobals.currentActor.PlantA.PlantAttribute = PlantAttribute.租赁;
                        }
                        if (str2 == "PL1")
                        {
                            TGlobals.currentActor.PlantA.SetUpProductLine(ProductLineName.PL1, pla, pda);
                            if (pla == ProductLineAttribute.手工)
                            {
                                TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.CurrentCash -= TGlobals.currentActor.PlantA.PL1.ByeCost;
                                TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.Equipment += TGlobals.currentActor.PlantA.PL1.ByeCost;
                            }
                            else
                            {
                                TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.CurrentCash -= TGlobals.currentActor.PlantA.PL1.InstallPerCost;
                                TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.Construction += TGlobals.currentActor.PlantA.PL1.InstallPerCost;
                            }
                            TGlobals.currentActor.PlantA.PL1.AlreadyInstallationCycle = 1;
                        }
                        else if (str2 == "PL2")
                        {
                            TGlobals.currentActor.PlantA.SetUpProductLine(ProductLineName.PL2, pla, pda);
                            if (pla == ProductLineAttribute.手工)
                            {
                                TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.CurrentCash -= TGlobals.currentActor.PlantA.PL2.ByeCost;
                                TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.Equipment += TGlobals.currentActor.PlantA.PL2.ByeCost;
                            }
                            else
                            {
                                TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.CurrentCash -= TGlobals.currentActor.PlantA.PL2.InstallPerCost;
                                TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.Construction += TGlobals.currentActor.PlantA.PL2.InstallPerCost;
                            }
                            TGlobals.currentActor.PlantA.PL2.AlreadyInstallationCycle = 1;
                        }
                        else if (str2 == "PL3")
                        {
                            TGlobals.currentActor.PlantA.SetUpProductLine(ProductLineName.PL3, pla, pda);
                            if (pla == ProductLineAttribute.手工)
                            {
                                TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.CurrentCash -= TGlobals.currentActor.PlantA.PL3.ByeCost;
                                TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.Equipment += TGlobals.currentActor.PlantA.PL3.ByeCost;
                            }
                            else
                            {
                                TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.CurrentCash -= TGlobals.currentActor.PlantA.PL3.InstallPerCost;
                                TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.Construction += TGlobals.currentActor.PlantA.PL3.InstallPerCost;
                            }
                            TGlobals.currentActor.PlantA.PL3.AlreadyInstallationCycle = 1;
                        }
                        else if (str2 == "PL4")
                        {
                            TGlobals.currentActor.PlantA.SetUpProductLine(ProductLineName.PL4, pla, pda);
                            if (pla == ProductLineAttribute.手工)
                            {
                                TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.CurrentCash -= TGlobals.currentActor.PlantA.PL4.ByeCost;
                                TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.Equipment += TGlobals.currentActor.PlantA.PL4.ByeCost;
                            }
                            else
                            {
                                TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.CurrentCash -= TGlobals.currentActor.PlantA.PL4.InstallPerCost;
                                TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.Construction += TGlobals.currentActor.PlantA.PL4.InstallPerCost;
                            }
                            TGlobals.currentActor.PlantA.PL4.AlreadyInstallationCycle = 1;
                        }
                    }
                    else if (str4 != "工厂B")
                    {
                        if (str4 == "工厂C")
                        {
                            if (TGlobals.currentActor.PlantC.PlantAttribute == PlantAttribute.无)
                            {
                                TGlobals.currentActor.PlantC.PlantAttribute = PlantAttribute.租赁;
                            }
                            if (str2 == "PL8")
                            {
                                TGlobals.currentActor.PlantC.SetUpProductLine(ProductLineName.PL8, pla, pda);
                                if (pla == ProductLineAttribute.手工)
                                {
                                    TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.CurrentCash -= TGlobals.currentActor.PlantC.PL8.ByeCost;
                                    TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.Equipment += TGlobals.currentActor.PlantC.PL8.ByeCost;
                                }
                                else
                                {
                                    TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.CurrentCash -= TGlobals.currentActor.PlantC.PL8.InstallPerCost;
                                    TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.Construction += TGlobals.currentActor.PlantC.PL8.InstallPerCost;
                                }
                                TGlobals.currentActor.PlantC.PL8.AlreadyInstallationCycle = 1;
                            }
                        }
                    }
                    else
                    {
                        if (TGlobals.currentActor.PlantB.PlantAttribute == PlantAttribute.无)
                        {
                            TGlobals.currentActor.PlantB.PlantAttribute = PlantAttribute.租赁;
                        }
                        if (str2 == "PL5")
                        {
                            TGlobals.currentActor.PlantB.SetUpProductLine(ProductLineName.PL5, pla, pda);
                            if (pla == ProductLineAttribute.手工)
                            {
                                TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.CurrentCash -= TGlobals.currentActor.PlantB.PL5.ByeCost;
                                TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.Equipment += TGlobals.currentActor.PlantB.PL5.ByeCost;
                            }
                            else
                            {
                                TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.CurrentCash -= TGlobals.currentActor.PlantB.PL5.InstallPerCost;
                                TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.Construction += TGlobals.currentActor.PlantB.PL5.InstallPerCost;
                            }
                            TGlobals.currentActor.PlantB.PL5.AlreadyInstallationCycle = 1;
                        }
                        else if (str2 == "PL6")
                        {
                            TGlobals.currentActor.PlantB.SetUpProductLine(ProductLineName.PL6, pla, pda);
                            if (pla == ProductLineAttribute.手工)
                            {
                                TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.CurrentCash -= TGlobals.currentActor.PlantB.PL6.ByeCost;
                                TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.Equipment += TGlobals.currentActor.PlantB.PL6.ByeCost;
                            }
                            else
                            {
                                TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.CurrentCash -= TGlobals.currentActor.PlantB.PL6.InstallPerCost;
                                TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.Construction += TGlobals.currentActor.PlantB.PL6.InstallPerCost;
                            }
                            TGlobals.currentActor.PlantB.PL6.AlreadyInstallationCycle = 1;
                        }
                        else if (str2 == "PL7")
                        {
                            TGlobals.currentActor.PlantB.SetUpProductLine(ProductLineName.PL7, pla, pda);
                            if (pla == ProductLineAttribute.手工)
                            {
                                TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.CurrentCash -= TGlobals.currentActor.PlantB.PL7.ByeCost;
                                TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.Equipment += TGlobals.currentActor.PlantB.PL7.ByeCost;
                            }
                            else
                            {
                                TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.CurrentCash -= TGlobals.currentActor.PlantB.PL7.InstallPerCost;
                                TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.Construction += TGlobals.currentActor.PlantB.PL7.InstallPerCost;
                            }
                            TGlobals.currentActor.PlantB.PL7.AlreadyInstallationCycle = 1;
                        }
                    }
                }
            }
        }

        private void ZCSCX()
        {
            int transferringProductLineCount = TGlobals.currentActor.PlantA.GetTransferringProductLineCount(PlantName.工厂A);
            int num2 = TGlobals.currentActor.PlantB.GetTransferringProductLineCount(PlantName.工厂B);
            int num3 = TGlobals.currentActor.PlantC.GetTransferringProductLineCount(PlantName.工厂C);
            int num4 = (transferringProductLineCount + num2) + num3;
            this.dataGridViewZCSCX.Rows.Clear();
            this.dataGridViewZCSCX.RowCount = num4;
            TProductLine[] transferringProductLine = TGlobals.currentActor.PlantA.GetTransferringProductLine(PlantName.工厂A);
            TProductLine[] lineArray2 = TGlobals.currentActor.PlantB.GetTransferringProductLine(PlantName.工厂B);
            TProductLine[] lineArray3 = TGlobals.currentActor.PlantC.GetTransferringProductLine(PlantName.工厂C);
            if (transferringProductLineCount != 0)
            {
                for (int i = 0; i < transferringProductLine.Length; i++)
                {
                    ((DataGridViewComboBoxCell) this.dataGridViewZCSCX.Rows[i].Cells["转产类型"]).Items.Clear();
                    if (transferringProductLine[i].CanManufacturedProductAttribute != ProductAttribute.P1)
                    {
                        ((DataGridViewComboBoxCell) this.dataGridViewZCSCX.Rows[i].Cells["转产类型"]).Items.Add(ProductAttribute.P1.ToString());
                    }
                    if (transferringProductLine[i].CanManufacturedProductAttribute != ProductAttribute.P2)
                    {
                        ((DataGridViewComboBoxCell) this.dataGridViewZCSCX.Rows[i].Cells["转产类型"]).Items.Add(ProductAttribute.P2.ToString());
                    }
                    if (transferringProductLine[i].CanManufacturedProductAttribute != ProductAttribute.P3)
                    {
                        ((DataGridViewComboBoxCell) this.dataGridViewZCSCX.Rows[i].Cells["转产类型"]).Items.Add(ProductAttribute.P3.ToString());
                    }
                    if (transferringProductLine[i].CanManufacturedProductAttribute != ProductAttribute.P4)
                    {
                        ((DataGridViewComboBoxCell) this.dataGridViewZCSCX.Rows[i].Cells["转产类型"]).Items.Add(ProductAttribute.P4.ToString());
                    }
                    ((DataGridViewComboBoxCell) this.dataGridViewZCSCX.Rows[i].Cells["转产类型"]).Value = ((DataGridViewComboBoxCell) this.dataGridViewZCSCX.Rows[i].Cells["转产类型"]).Items[0];
                    this.dataGridViewZCSCX.Rows[i].Cells["选择项"].Value = false;
                    this.dataGridViewZCSCX.Rows[i].Cells["生产线编号"].Value = transferringProductLine[i].PLName;
                    this.dataGridViewZCSCX.Rows[i].Cells["所属厂房"].Value = "厂房A";
                    this.dataGridViewZCSCX.Rows[i].Cells["生产线类型"].Value = transferringProductLine[i].PLAttribute;
                    this.dataGridViewZCSCX.Rows[i].Cells["产品类型"].Value = transferringProductLine[i].CanManufacturedProductAttribute;
                    this.dataGridViewZCSCX.Rows[i].Cells["转产周期"].Value = transferringProductLine[i].TransferringCycle;
                }
            }
            if (num2 != 0)
            {
                for (int i = 0; i < lineArray2.Length; i++)
                {
                    ((DataGridViewComboBoxCell) this.dataGridViewZCSCX.Rows[transferringProductLineCount + i].Cells["转产类型"]).Items.Clear();
                    if (lineArray2[i].CanManufacturedProductAttribute != ProductAttribute.P1)
                    {
                        ((DataGridViewComboBoxCell) this.dataGridViewZCSCX.Rows[transferringProductLineCount + i].Cells["转产类型"]).Items.Add(ProductAttribute.P1.ToString());
                    }
                    if (lineArray2[i].CanManufacturedProductAttribute != ProductAttribute.P2)
                    {
                        ((DataGridViewComboBoxCell) this.dataGridViewZCSCX.Rows[transferringProductLineCount + i].Cells["转产类型"]).Items.Add(ProductAttribute.P2.ToString());
                    }
                    if (lineArray2[i].CanManufacturedProductAttribute != ProductAttribute.P3)
                    {
                        ((DataGridViewComboBoxCell) this.dataGridViewZCSCX.Rows[transferringProductLineCount + i].Cells["转产类型"]).Items.Add(ProductAttribute.P3.ToString());
                    }
                    if (lineArray2[i].CanManufacturedProductAttribute != ProductAttribute.P4)
                    {
                        ((DataGridViewComboBoxCell) this.dataGridViewZCSCX.Rows[transferringProductLineCount + i].Cells["转产类型"]).Items.Add(ProductAttribute.P4.ToString());
                    }
                    ((DataGridViewComboBoxCell) this.dataGridViewZCSCX.Rows[transferringProductLineCount + i].Cells["转产类型"]).Value = ((DataGridViewComboBoxCell) this.dataGridViewZCSCX.Rows[transferringProductLineCount + i].Cells["转产类型"]).Items[0];
                    this.dataGridViewZCSCX.Rows[transferringProductLineCount + i].Cells["选择项"].Value = false;
                    this.dataGridViewZCSCX.Rows[transferringProductLineCount + i].Cells["生产线编号"].Value = lineArray2[i].PLName;
                    this.dataGridViewZCSCX.Rows[transferringProductLineCount + i].Cells["所属厂房"].Value = "厂房B";
                    this.dataGridViewZCSCX.Rows[transferringProductLineCount + i].Cells["生产线类型"].Value = lineArray2[i].PLAttribute;
                    this.dataGridViewZCSCX.Rows[transferringProductLineCount + i].Cells["产品类型"].Value = lineArray2[i].CanManufacturedProductAttribute;
                    this.dataGridViewZCSCX.Rows[transferringProductLineCount + i].Cells["转产周期"].Value = lineArray2[i].TransferringCycle;
                }
            }
            if (num3 != 0)
            {
                for (int i = 0; i < lineArray3.Length; i++)
                {
                    ((DataGridViewComboBoxCell) this.dataGridViewZCSCX.Rows[(transferringProductLineCount + num2) + i].Cells["转产类型"]).Items.Clear();
                    if (lineArray3[i].CanManufacturedProductAttribute != ProductAttribute.P1)
                    {
                        ((DataGridViewComboBoxCell) this.dataGridViewZCSCX.Rows[(transferringProductLineCount + num2) + i].Cells["转产类型"]).Items.Add(ProductAttribute.P1.ToString());
                    }
                    if (lineArray3[i].CanManufacturedProductAttribute != ProductAttribute.P2)
                    {
                        ((DataGridViewComboBoxCell) this.dataGridViewZCSCX.Rows[(transferringProductLineCount + num2) + i].Cells["转产类型"]).Items.Add(ProductAttribute.P2.ToString());
                    }
                    if (lineArray3[i].CanManufacturedProductAttribute != ProductAttribute.P3)
                    {
                        ((DataGridViewComboBoxCell) this.dataGridViewZCSCX.Rows[(transferringProductLineCount + num2) + i].Cells["转产类型"]).Items.Add(ProductAttribute.P3.ToString());
                    }
                    if (lineArray3[i].CanManufacturedProductAttribute != ProductAttribute.P4)
                    {
                        ((DataGridViewComboBoxCell) this.dataGridViewZCSCX.Rows[(transferringProductLineCount + num2) + i].Cells["转产类型"]).Items.Add(ProductAttribute.P4.ToString());
                    }
                    ((DataGridViewComboBoxCell) this.dataGridViewZCSCX.Rows[(transferringProductLineCount + num2) + i].Cells["转产类型"]).Value = ((DataGridViewComboBoxCell) this.dataGridViewZCSCX.Rows[(transferringProductLineCount + num2) + i].Cells["转产类型"]).Items[0];
                    this.dataGridViewZCSCX.Rows[(transferringProductLineCount + num2) + i].Cells["选择项"].Value = false;
                    this.dataGridViewZCSCX.Rows[(transferringProductLineCount + num2) + i].Cells["生产线编号"].Value = lineArray3[i].PLName;
                    this.dataGridViewZCSCX.Rows[(transferringProductLineCount + num2) + i].Cells["所属厂房"].Value = "厂房C";
                    this.dataGridViewZCSCX.Rows[(transferringProductLineCount + num2) + i].Cells["生产线类型"].Value = lineArray3[i].PLAttribute;
                    this.dataGridViewZCSCX.Rows[(transferringProductLineCount + num2) + i].Cells["产品类型"].Value = lineArray3[i].CanManufacturedProductAttribute;
                    this.dataGridViewZCSCX.Rows[(transferringProductLineCount + num2) + i].Cells["转产周期"].Value = lineArray3[i].TransferringCycle;
                }
            }
        }

        private void ZCSCXOK()
        {
            if (TGlobals.currentActor.PlantA.PL1.RemainTransferringCycle >= 1)
            {
                TProductLine line1 = TGlobals.currentActor.PlantA.PL1;
                line1.AlreadyTransferringCycle++;
            }
            if (TGlobals.currentActor.PlantA.PL2.RemainInstallationCycle >= 1)
            {
                TProductLine line2 = TGlobals.currentActor.PlantA.PL2;
                line2.AlreadyTransferringCycle++;
            }
            if (TGlobals.currentActor.PlantA.PL3.RemainTransferringCycle >= 1)
            {
                TProductLine line3 = TGlobals.currentActor.PlantA.PL3;
                line3.AlreadyTransferringCycle++;
            }
            if (TGlobals.currentActor.PlantA.PL4.RemainTransferringCycle >= 1)
            {
                TProductLine line4 = TGlobals.currentActor.PlantA.PL4;
                line4.AlreadyTransferringCycle++;
            }
            if (TGlobals.currentActor.PlantB.PL5.RemainTransferringCycle >= 1)
            {
                TProductLine line5 = TGlobals.currentActor.PlantB.PL5;
                line5.AlreadyTransferringCycle++;
            }
            if (TGlobals.currentActor.PlantB.PL6.RemainTransferringCycle >= 1)
            {
                TProductLine line6 = TGlobals.currentActor.PlantB.PL6;
                line6.AlreadyTransferringCycle++;
            }
            if (TGlobals.currentActor.PlantB.PL7.RemainTransferringCycle >= 1)
            {
                TProductLine line7 = TGlobals.currentActor.PlantB.PL7;
                line7.AlreadyTransferringCycle++;
            }
            if (TGlobals.currentActor.PlantC.PL8.RemainTransferringCycle >= 1)
            {
                TProductLine line8 = TGlobals.currentActor.PlantC.PL8;
                line8.AlreadyTransferringCycle++;
            }
            for (int i = 0; i < this.dataGridViewZCSCX.Rows.Count; i++)
            {
                if ((bool) this.dataGridViewZCSCX.Rows[i].Cells["选择项"].Value)
                {
                    string str = this.dataGridViewZCSCX.Rows[i].Cells["生产线编号"].Value.ToString();
                    ProductAttribute pda = ProductAttribute.无;
                    string str3 = this.dataGridViewZCSCX.Rows[i].Cells["转产类型"].Value.ToString();
                    if (str3 != null)
                    {
                        if (str3 == "P1")
                        {
                            pda = ProductAttribute.P1;
                        }
                        else if (str3 == "P2")
                        {
                            pda = ProductAttribute.P2;
                        }
                        else if (str3 == "P3")
                        {
                            pda = ProductAttribute.P3;
                        }
                        else if (str3 == "P4")
                        {
                            pda = ProductAttribute.P4;
                        }
                    }
                    string key = str;
                    if (key != null)
                    {
                        int num2;
                        if (<PrivateImplementationDetails>{FAF84281-B764-49BB-8026-1DA8F9FEA525}.$$method0x60000e2-1 == null)
                        {
                            Dictionary<string, int> dictionary1 = new Dictionary<string, int>(8);
                            dictionary1.Add("PL1", 0);
                            dictionary1.Add("PL2", 1);
                            dictionary1.Add("PL3", 2);
                            dictionary1.Add("PL4", 3);
                            dictionary1.Add("PL5", 4);
                            dictionary1.Add("PL6", 5);
                            dictionary1.Add("PL7", 6);
                            dictionary1.Add("PL8", 7);
                            <PrivateImplementationDetails>{FAF84281-B764-49BB-8026-1DA8F9FEA525}.$$method0x60000e2-1 = dictionary1;
                        }
                        if (<PrivateImplementationDetails>{FAF84281-B764-49BB-8026-1DA8F9FEA525}.$$method0x60000e2-1.TryGetValue(key, out num2))
                        {
                            switch (num2)
                            {
                                case 0:
                                    TGlobals.currentActor.PlantA.TransferringProductLine(ProductLineName.PL1, pda);
                                    TGlobals.currentActor.PlantA.PL1.AlreadyTransferringCycle = 0;
                                    break;

                                case 1:
                                    TGlobals.currentActor.PlantA.TransferringProductLine(ProductLineName.PL2, pda);
                                    TGlobals.currentActor.PlantA.PL2.AlreadyTransferringCycle = 0;
                                    break;

                                case 2:
                                    TGlobals.currentActor.PlantA.TransferringProductLine(ProductLineName.PL3, pda);
                                    TGlobals.currentActor.PlantA.PL3.AlreadyTransferringCycle = 0;
                                    break;

                                case 3:
                                    TGlobals.currentActor.PlantA.TransferringProductLine(ProductLineName.PL4, pda);
                                    TGlobals.currentActor.PlantA.PL4.AlreadyTransferringCycle = 0;
                                    break;

                                case 4:
                                    TGlobals.currentActor.PlantB.TransferringProductLine(ProductLineName.PL5, pda);
                                    TGlobals.currentActor.PlantB.PL5.AlreadyTransferringCycle = 0;
                                    break;

                                case 5:
                                    TGlobals.currentActor.PlantB.TransferringProductLine(ProductLineName.PL6, pda);
                                    TGlobals.currentActor.PlantB.PL6.AlreadyTransferringCycle = 0;
                                    break;

                                case 6:
                                    TGlobals.currentActor.PlantB.TransferringProductLine(ProductLineName.PL7, pda);
                                    TGlobals.currentActor.PlantB.PL7.AlreadyTransferringCycle = 0;
                                    break;

                                case 7:
                                    TGlobals.currentActor.PlantC.TransferringProductLine(ProductLineName.PL8, pda);
                                    TGlobals.currentActor.PlantC.PL8.AlreadyTransferringCycle = 0;
                                    break;

                                default:
                                    break;
                            }
                        }
                    }
                }
            }
        }

        private void ZTSCX()
        {
            int investmentAgainPLCount = TGlobals.currentActor.PlantA.GetInvestmentAgainPLCount(PlantName.工厂A);
            int num2 = TGlobals.currentActor.PlantB.GetInvestmentAgainPLCount(PlantName.工厂B);
            int num3 = TGlobals.currentActor.PlantC.GetInvestmentAgainPLCount(PlantName.工厂C);
            int num4 = (investmentAgainPLCount + num2) + num3;
            this.dataGridViewZTSCX.Rows.Clear();
            this.dataGridViewZTSCX.RowCount = num4;
            TProductLine[] investmentAgainPL = TGlobals.currentActor.PlantA.GetInvestmentAgainPL(PlantName.工厂A);
            TProductLine[] lineArray2 = TGlobals.currentActor.PlantB.GetInvestmentAgainPL(PlantName.工厂B);
            TProductLine[] lineArray3 = TGlobals.currentActor.PlantC.GetInvestmentAgainPL(PlantName.工厂C);
            if (investmentAgainPLCount != 0)
            {
                for (int i = 0; i < investmentAgainPL.Length; i++)
                {
                    this.dataGridViewZTSCX.Rows[i].Cells["再投选择项"].Value = false;
                    this.dataGridViewZTSCX.Rows[i].Cells["再投生产线编号"].Value = investmentAgainPL[i].PLName;
                    this.dataGridViewZTSCX.Rows[i].Cells["再投所属厂房"].Value = "厂房A";
                    this.dataGridViewZTSCX.Rows[i].Cells["再投生产线类型"].Value = investmentAgainPL[i].PLAttribute;
                    this.dataGridViewZTSCX.Rows[i].Cells["再投产品类型"].Value = investmentAgainPL[i].CanManufacturedProductAttribute;
                    this.dataGridViewZTSCX.Rows[i].Cells["累计投资额"].Value = investmentAgainPL[i].AlreadyInstallationCycle * investmentAgainPL[i].InstallPerCost;
                    this.dataGridViewZTSCX.Rows[i].Cells["剩余建设时间"].Value = investmentAgainPL[i].RemainInstallationCycle;
                }
            }
            if (num2 != 0)
            {
                for (int i = 0; i < lineArray2.Length; i++)
                {
                    this.dataGridViewZTSCX.Rows[investmentAgainPLCount + i].Cells["再投选择项"].Value = false;
                    this.dataGridViewZTSCX.Rows[investmentAgainPLCount + i].Cells["再投生产线编号"].Value = lineArray2[i].PLName;
                    this.dataGridViewZTSCX.Rows[investmentAgainPLCount + i].Cells["再投所属厂房"].Value = "厂房B";
                    this.dataGridViewZTSCX.Rows[investmentAgainPLCount + i].Cells["再投生产线类型"].Value = lineArray2[i].PLAttribute;
                    this.dataGridViewZTSCX.Rows[investmentAgainPLCount + i].Cells["再投产品类型"].Value = lineArray2[i].CanManufacturedProductAttribute;
                    this.dataGridViewZTSCX.Rows[investmentAgainPLCount + i].Cells["累计投资额"].Value = lineArray2[i].AlreadyInstallationCycle * lineArray2[i].InstallPerCost;
                    this.dataGridViewZTSCX.Rows[investmentAgainPLCount + i].Cells["剩余建设时间"].Value = lineArray2[i].RemainInstallationCycle;
                }
            }
            if (num3 != 0)
            {
                for (int i = 0; i < lineArray3.Length; i++)
                {
                    this.dataGridViewZTSCX.Rows[(investmentAgainPLCount + num2) + i].Cells["再投选择项"].Value = false;
                    this.dataGridViewZTSCX.Rows[(investmentAgainPLCount + num2) + i].Cells["再投生产线编号"].Value = lineArray3[i].PLName;
                    this.dataGridViewZTSCX.Rows[(investmentAgainPLCount + num2) + i].Cells["再投所属厂房"].Value = "厂房C";
                    this.dataGridViewZTSCX.Rows[(investmentAgainPLCount + num2) + i].Cells["再投生产线类型"].Value = lineArray3[i].PLAttribute;
                    this.dataGridViewZTSCX.Rows[(investmentAgainPLCount + num2) + i].Cells["再投产品类型"].Value = lineArray3[i].CanManufacturedProductAttribute;
                    this.dataGridViewZTSCX.Rows[(investmentAgainPLCount + num2) + i].Cells["累计投资额"].Value = lineArray3[i].AlreadyInstallationCycle * lineArray3[i].InstallPerCost;
                    this.dataGridViewZTSCX.Rows[(investmentAgainPLCount + num2) + i].Cells["剩余建设时间"].Value = lineArray3[i].RemainInstallationCycle;
                }
            }
        }

        private void ZTSCXOK()
        {
            for (int i = 0; i < this.dataGridViewZTSCX.Rows.Count; i++)
            {
                string str3;
                bool flag = (bool) this.dataGridViewZTSCX.Rows[i].Cells["再投选择项"].Value;
                if (flag && ((str3 = this.dataGridViewZTSCX.Rows[i].Cells["再投生产线编号"].Value.ToString()) != null))
                {
                    int num2;
                    if (<PrivateImplementationDetails>{FAF84281-B764-49BB-8026-1DA8F9FEA525}.$$method0x60000e1-1 == null)
                    {
                        Dictionary<string, int> dictionary1 = new Dictionary<string, int>(8);
                        dictionary1.Add("PL1", 0);
                        dictionary1.Add("PL2", 1);
                        dictionary1.Add("PL3", 2);
                        dictionary1.Add("PL4", 3);
                        dictionary1.Add("PL5", 4);
                        dictionary1.Add("PL6", 5);
                        dictionary1.Add("PL7", 6);
                        dictionary1.Add("PL8", 7);
                        <PrivateImplementationDetails>{FAF84281-B764-49BB-8026-1DA8F9FEA525}.$$method0x60000e1-1 = dictionary1;
                    }
                    if (<PrivateImplementationDetails>{FAF84281-B764-49BB-8026-1DA8F9FEA525}.$$method0x60000e1-1.TryGetValue(str3, out num2))
                    {
                        switch (num2)
                        {
                            case 0:
                            {
                                TOperatingSheet operatingSheet = TGlobals.currentActor.CurrBusinessConditions.OperatingSheet;
                                operatingSheet.CurrentCash -= TGlobals.currentActor.PlantA.PL1.InstallPerCost;
                                TOperatingSheet sheet2 = TGlobals.currentActor.CurrBusinessConditions.OperatingSheet;
                                sheet2.Construction += TGlobals.currentActor.PlantA.PL1.InstallPerCost;
                                if (TGlobals.currentActor.PlantA.PL1.RemainInstallationCycle == 1)
                                {
                                    TOperatingSheet sheet3 = TGlobals.currentActor.CurrBusinessConditions.OperatingSheet;
                                    sheet3.Construction -= TGlobals.currentActor.PlantA.PL1.ByeCost;
                                    TOperatingSheet sheet4 = TGlobals.currentActor.CurrBusinessConditions.OperatingSheet;
                                    sheet4.Equipment += TGlobals.currentActor.PlantA.PL1.ByeCost;
                                }
                                TGlobals.currentActor.PlantA.PL1.AlreadyInstallationCycle++;
                                break;
                            }
                            case 1:
                                TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.CurrentCash -= TGlobals.currentActor.PlantA.PL2.InstallPerCost;
                                TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.Construction += TGlobals.currentActor.PlantA.PL2.InstallPerCost;
                                if (TGlobals.currentActor.PlantA.PL2.RemainInstallationCycle == 1)
                                {
                                    TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.Construction -= TGlobals.currentActor.PlantA.PL2.ByeCost;
                                    TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.Equipment += TGlobals.currentActor.PlantA.PL2.ByeCost;
                                }
                                TGlobals.currentActor.PlantA.PL2.AlreadyInstallationCycle++;
                                break;

                            case 2:
                                TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.CurrentCash -= TGlobals.currentActor.PlantA.PL3.InstallPerCost;
                                TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.Construction += TGlobals.currentActor.PlantA.PL3.InstallPerCost;
                                if (TGlobals.currentActor.PlantA.PL3.RemainInstallationCycle == 1)
                                {
                                    TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.Construction -= TGlobals.currentActor.PlantA.PL3.ByeCost;
                                    TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.Equipment += TGlobals.currentActor.PlantA.PL3.ByeCost;
                                }
                                TGlobals.currentActor.PlantA.PL3.AlreadyInstallationCycle++;
                                break;

                            case 3:
                                TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.CurrentCash -= TGlobals.currentActor.PlantA.PL4.InstallPerCost;
                                TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.Construction += TGlobals.currentActor.PlantA.PL4.InstallPerCost;
                                if (TGlobals.currentActor.PlantA.PL4.RemainInstallationCycle == 1)
                                {
                                    TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.Construction -= TGlobals.currentActor.PlantA.PL4.ByeCost;
                                    TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.Equipment += TGlobals.currentActor.PlantA.PL4.ByeCost;
                                }
                                TGlobals.currentActor.PlantA.PL4.AlreadyInstallationCycle++;
                                break;

                            case 4:
                                TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.CurrentCash -= TGlobals.currentActor.PlantB.PL5.InstallPerCost;
                                TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.Construction += TGlobals.currentActor.PlantB.PL5.InstallPerCost;
                                if (TGlobals.currentActor.PlantB.PL5.RemainInstallationCycle == 1)
                                {
                                    TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.Construction -= TGlobals.currentActor.PlantB.PL5.ByeCost;
                                    TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.Equipment += TGlobals.currentActor.PlantB.PL5.ByeCost;
                                }
                                TGlobals.currentActor.PlantB.PL5.AlreadyInstallationCycle++;
                                break;

                            case 5:
                                TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.CurrentCash -= TGlobals.currentActor.PlantB.PL6.InstallPerCost;
                                TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.Construction += TGlobals.currentActor.PlantB.PL6.InstallPerCost;
                                if (TGlobals.currentActor.PlantB.PL6.RemainInstallationCycle == 1)
                                {
                                    TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.Construction -= TGlobals.currentActor.PlantB.PL6.ByeCost;
                                    TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.Equipment += TGlobals.currentActor.PlantB.PL6.ByeCost;
                                }
                                TGlobals.currentActor.PlantB.PL6.AlreadyInstallationCycle++;
                                break;

                            case 6:
                                TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.CurrentCash -= TGlobals.currentActor.PlantB.PL7.InstallPerCost;
                                TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.Construction += TGlobals.currentActor.PlantB.PL7.InstallPerCost;
                                if (TGlobals.currentActor.PlantB.PL7.RemainInstallationCycle == 1)
                                {
                                    TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.Construction -= TGlobals.currentActor.PlantB.PL7.ByeCost;
                                    TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.Equipment += TGlobals.currentActor.PlantB.PL7.ByeCost;
                                }
                                TGlobals.currentActor.PlantB.PL7.AlreadyInstallationCycle++;
                                break;

                            case 7:
                                TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.CurrentCash -= TGlobals.currentActor.PlantC.PL8.InstallPerCost;
                                TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.Construction += TGlobals.currentActor.PlantC.PL8.InstallPerCost;
                                if (TGlobals.currentActor.PlantC.PL8.RemainInstallationCycle == 1)
                                {
                                    TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.Construction -= TGlobals.currentActor.PlantC.PL8.ByeCost;
                                    TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.Equipment += TGlobals.currentActor.PlantC.PL8.ByeCost;
                                }
                                TGlobals.currentActor.PlantC.PL8.AlreadyInstallationCycle++;
                                break;

                            default:
                                break;
                        }
                    }
                }
            }
        }
    }
}

