namespace ERPChess
{
    using BusinessTier;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmKSXDSC : Form
    {
        private IContainer components;
        private Button buttonOK;
        private Button buttonCancel;
        private GroupBox groupBox2;
        private RichTextBox richTextBox2;
        private DataGridView dataGridViewKSXDSC;
        private Label label1;
        private Label labelR1;
        private Label label3;
        private Label labelR2;
        private Label label5;
        private Label labelR3;
        private Label label7;
        private Label labelR4;
        private DataGridViewCheckBoxColumn 选择项;
        private DataGridViewTextBoxColumn 生产线编号;
        private DataGridViewTextBoxColumn 生产线类型;
        private DataGridViewTextBoxColumn 所属厂房;
        private DataGridViewComboBoxColumn 生产产品;

        public frmKSXDSC()
        {
            this.InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            int num = 0;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            for (int i = 0; i < this.dataGridViewKSXDSC.Rows.Count; i++)
            {
                if ((bool) this.dataGridViewKSXDSC.Rows[i].Cells["选择项"].Value)
                {
                    string str2 = ((DataGridViewComboBoxCell) this.dataGridViewKSXDSC.Rows[i].Cells["生产产品"]).Value.ToString();
                    if (str2 != null)
                    {
                        if (str2 == "P1")
                        {
                            num++;
                        }
                        else if (str2 == "P2")
                        {
                            num++;
                            num2++;
                        }
                        else if (str2 == "P3")
                        {
                            num2 += 2;
                            num3++;
                        }
                        else if (str2 == "P4")
                        {
                            num2++;
                            num3++;
                            num4 += 2;
                        }
                    }
                }
            }
            if (TGlobals.currentActor.RawMaterialStock.StatisticsOrder.R1.Amount < num)
            {
                MessageBox.Show("原料R1不足,不能进行产品的生产!", "重要提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (TGlobals.currentActor.RawMaterialStock.StatisticsOrder.R2.Amount < num2)
            {
                MessageBox.Show("原料R2不足,不能进行产品的生产!", "重要提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (TGlobals.currentActor.RawMaterialStock.StatisticsOrder.R3.Amount < num3)
            {
                MessageBox.Show("原料R3不足,不能进行产品的生产!", "重要提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (TGlobals.currentActor.RawMaterialStock.StatisticsOrder.R4.Amount < num4)
            {
                MessageBox.Show("原料R4不足,不能进行产品的生产!", "重要提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                int num6 = 0;
                for (int j = 0; j < this.dataGridViewKSXDSC.Rows.Count; j++)
                {
                    if ((bool) this.dataGridViewKSXDSC.Rows[j].Cells["选择项"].Value)
                    {
                        num6++;
                    }
                }
                if (TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.CurrentCash < num6)
                {
                    MessageBox.Show("现金不能够满足生产的加工费用!", "重要提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    for (int k = 0; k < this.dataGridViewKSXDSC.Rows.Count; k++)
                    {
                        if ((bool) this.dataGridViewKSXDSC.Rows[k].Cells["选择项"].Value)
                        {
                            string str3 = this.dataGridViewKSXDSC.Rows[k].Cells["生产线编号"].Value.ToString();
                            TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.CurrentCash--;
                            ProductAttribute pda = ProductAttribute.无;
                            string str5 = this.dataGridViewKSXDSC.Rows[k].Cells["生产产品"].Value.ToString();
                            if (str5 != null)
                            {
                                if (str5 == "P1")
                                {
                                    pda = ProductAttribute.P1;
                                    TGlobals.currentActor.RawMaterialStock.StatisticsOrder.R1.Amount--;
                                    TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.RawMaterials--;
                                    TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.AreProducts += 2;
                                }
                                else if (str5 == "P2")
                                {
                                    pda = ProductAttribute.P2;
                                    TGlobals.currentActor.RawMaterialStock.StatisticsOrder.R1.Amount--;
                                    TGlobals.currentActor.RawMaterialStock.StatisticsOrder.R2.Amount--;
                                    TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.RawMaterials -= 2;
                                    TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.AreProducts += 3;
                                }
                                else if (str5 == "P3")
                                {
                                    pda = ProductAttribute.P3;
                                    TGlobals.currentActor.RawMaterialStock.StatisticsOrder.R2.Amount -= 2;
                                    TGlobals.currentActor.RawMaterialStock.StatisticsOrder.R3.Amount--;
                                    TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.RawMaterials -= 3;
                                    TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.AreProducts += 4;
                                }
                                else if (str5 == "P4")
                                {
                                    pda = ProductAttribute.P4;
                                    TGlobals.currentActor.RawMaterialStock.StatisticsOrder.R2.Amount--;
                                    TGlobals.currentActor.RawMaterialStock.StatisticsOrder.R3.Amount--;
                                    TGlobals.currentActor.RawMaterialStock.StatisticsOrder.R4.Amount -= 2;
                                    TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.RawMaterials -= 4;
                                    TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.AreProducts += 5;
                                }
                            }
                            string key = str3;
                            if (key != null)
                            {
                                int num9;
                                if (<PrivateImplementationDetails>{FAF84281-B764-49BB-8026-1DA8F9FEA525}.$$method0x600008a-1 == null)
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
                                    <PrivateImplementationDetails>{FAF84281-B764-49BB-8026-1DA8F9FEA525}.$$method0x600008a-1 = dictionary1;
                                }
                                if (<PrivateImplementationDetails>{FAF84281-B764-49BB-8026-1DA8F9FEA525}.$$method0x600008a-1.TryGetValue(key, out num9))
                                {
                                    switch (num9)
                                    {
                                        case 0:
                                            TGlobals.currentActor.PlantA.StartNewProduce(ProductLineName.PL1, pda);
                                            TGlobals.currentActor.PlantA.PL1.AlreadyProduceCycle = 0;
                                            break;

                                        case 1:
                                            TGlobals.currentActor.PlantA.StartNewProduce(ProductLineName.PL2, pda);
                                            TGlobals.currentActor.PlantA.PL2.AlreadyProduceCycle = 0;
                                            break;

                                        case 2:
                                            TGlobals.currentActor.PlantA.StartNewProduce(ProductLineName.PL3, pda);
                                            TGlobals.currentActor.PlantA.PL3.AlreadyProduceCycle = 0;
                                            break;

                                        case 3:
                                            TGlobals.currentActor.PlantA.StartNewProduce(ProductLineName.PL4, pda);
                                            TGlobals.currentActor.PlantA.PL4.AlreadyProduceCycle = 0;
                                            break;

                                        case 4:
                                            TGlobals.currentActor.PlantB.StartNewProduce(ProductLineName.PL5, pda);
                                            TGlobals.currentActor.PlantB.PL5.AlreadyProduceCycle = 0;
                                            break;

                                        case 5:
                                            TGlobals.currentActor.PlantB.StartNewProduce(ProductLineName.PL6, pda);
                                            TGlobals.currentActor.PlantB.PL6.AlreadyProduceCycle = 0;
                                            break;

                                        case 6:
                                            TGlobals.currentActor.PlantB.StartNewProduce(ProductLineName.PL7, pda);
                                            TGlobals.currentActor.PlantB.PL7.AlreadyProduceCycle = 0;
                                            break;

                                        case 7:
                                            TGlobals.currentActor.PlantC.StartNewProduce(ProductLineName.PL8, pda);
                                            TGlobals.currentActor.PlantC.PL8.AlreadyProduceCycle = 0;
                                            break;

                                        default:
                                            break;
                                    }
                                }
                            }
                        }
                    }
                    base.DialogResult = DialogResult.OK;
                    base.Close();
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

        private void frmKSXDSC_Load(object sender, EventArgs e)
        {
            this.labelR1.Text = TGlobals.currentActor.RawMaterialStock.StatisticsOrder.R1.Amount.ToString();
            this.labelR2.Text = TGlobals.currentActor.RawMaterialStock.StatisticsOrder.R2.Amount.ToString();
            this.labelR3.Text = TGlobals.currentActor.RawMaterialStock.StatisticsOrder.R3.Amount.ToString();
            this.labelR4.Text = TGlobals.currentActor.RawMaterialStock.StatisticsOrder.R4.Amount.ToString();
            bool flag = TGlobals.currentActor.HasP2Capacity;
            bool flag2 = TGlobals.currentActor.HasP3Capacity;
            bool flag3 = TGlobals.currentActor.HasP4Capacity;
            int num = TGlobals.currentActor.PlantA.GetCanProduceProduceLineCount(PlantName.工厂A, flag, flag2, flag3);
            int num2 = TGlobals.currentActor.PlantB.GetCanProduceProduceLineCount(PlantName.工厂B, flag, flag2, flag3);
            int num3 = TGlobals.currentActor.PlantC.GetCanProduceProduceLineCount(PlantName.工厂C, flag, flag2, flag3);
            int num4 = (num + num2) + num3;
            this.dataGridViewKSXDSC.Rows.Clear();
            this.dataGridViewKSXDSC.RowCount = num4;
            TProductLine[] lineArray = TGlobals.currentActor.PlantA.GetCanProduceProduceLine(PlantName.工厂A, flag, flag2, flag3);
            TProductLine[] lineArray2 = TGlobals.currentActor.PlantB.GetCanProduceProduceLine(PlantName.工厂B, flag, flag2, flag3);
            TProductLine[] lineArray3 = TGlobals.currentActor.PlantC.GetCanProduceProduceLine(PlantName.工厂C, flag, flag2, flag3);
            if (num != 0)
            {
                for (int i = 0; i < lineArray.Length; i++)
                {
                    this.dataGridViewKSXDSC.Rows[i].Cells["选择项"].Value = false;
                    this.dataGridViewKSXDSC.Rows[i].Cells["生产线编号"].Value = lineArray[i].PLName;
                    this.dataGridViewKSXDSC.Rows[i].Cells["生产线类型"].Value = lineArray[i].PLAttribute;
                    this.dataGridViewKSXDSC.Rows[i].Cells["所属厂房"].Value = "厂房A";
                    if ((lineArray[i].PLAttribute != ProductLineAttribute.手工) && (lineArray[i].PLAttribute != ProductLineAttribute.柔性))
                    {
                        ((DataGridViewComboBoxCell) this.dataGridViewKSXDSC.Rows[i].Cells["生产产品"]).Items.Clear();
                        ((DataGridViewComboBoxCell) this.dataGridViewKSXDSC.Rows[i].Cells["生产产品"]).Items.Add(lineArray[i].CanManufacturedProductAttribute.ToString());
                        ((DataGridViewComboBoxCell) this.dataGridViewKSXDSC.Rows[i].Cells["生产产品"]).Value = ((DataGridViewComboBoxCell) this.dataGridViewKSXDSC.Rows[i].Cells["生产产品"]).Items[0];
                    }
                    else
                    {
                        ((DataGridViewComboBoxCell) this.dataGridViewKSXDSC.Rows[i].Cells["生产产品"]).Items.Clear();
                        if (TGlobals.currentActor.HasP1Capacity)
                        {
                            ((DataGridViewComboBoxCell) this.dataGridViewKSXDSC.Rows[i].Cells["生产产品"]).Items.Add(ProductAttribute.P1.ToString());
                        }
                        if (TGlobals.currentActor.HasP2Capacity)
                        {
                            ((DataGridViewComboBoxCell) this.dataGridViewKSXDSC.Rows[i].Cells["生产产品"]).Items.Add(ProductAttribute.P2.ToString());
                        }
                        if (TGlobals.currentActor.HasP3Capacity)
                        {
                            ((DataGridViewComboBoxCell) this.dataGridViewKSXDSC.Rows[i].Cells["生产产品"]).Items.Add(ProductAttribute.P3.ToString());
                        }
                        if (TGlobals.currentActor.HasP4Capacity)
                        {
                            ((DataGridViewComboBoxCell) this.dataGridViewKSXDSC.Rows[i].Cells["生产产品"]).Items.Add(ProductAttribute.P4.ToString());
                        }
                        ((DataGridViewComboBoxCell) this.dataGridViewKSXDSC.Rows[i].Cells["生产产品"]).Value = ((DataGridViewComboBoxCell) this.dataGridViewKSXDSC.Rows[i].Cells["生产产品"]).Items[0];
                    }
                }
            }
            if (num2 != 0)
            {
                for (int i = 0; i < lineArray2.Length; i++)
                {
                    this.dataGridViewKSXDSC.Rows[num + i].Cells["选择项"].Value = false;
                    this.dataGridViewKSXDSC.Rows[num + i].Cells["生产线编号"].Value = lineArray2[i].PLName;
                    this.dataGridViewKSXDSC.Rows[num + i].Cells["生产线类型"].Value = lineArray2[i].PLAttribute;
                    this.dataGridViewKSXDSC.Rows[num + i].Cells["所属厂房"].Value = "厂房B";
                    if ((lineArray2[i].PLAttribute != ProductLineAttribute.手工) && (lineArray2[i].PLAttribute != ProductLineAttribute.柔性))
                    {
                        ((DataGridViewComboBoxCell) this.dataGridViewKSXDSC.Rows[num + i].Cells["生产产品"]).Items.Clear();
                        ((DataGridViewComboBoxCell) this.dataGridViewKSXDSC.Rows[num + i].Cells["生产产品"]).Items.Add(lineArray2[i].CanManufacturedProductAttribute.ToString());
                        ((DataGridViewComboBoxCell) this.dataGridViewKSXDSC.Rows[num + i].Cells["生产产品"]).Value = ((DataGridViewComboBoxCell) this.dataGridViewKSXDSC.Rows[num + i].Cells["生产产品"]).Items[0];
                    }
                    else
                    {
                        ((DataGridViewComboBoxCell) this.dataGridViewKSXDSC.Rows[num + i].Cells["生产产品"]).Items.Clear();
                        if (TGlobals.currentActor.HasP1Capacity)
                        {
                            ((DataGridViewComboBoxCell) this.dataGridViewKSXDSC.Rows[num + i].Cells["生产产品"]).Items.Add(ProductAttribute.P1.ToString());
                        }
                        if (TGlobals.currentActor.HasP2Capacity)
                        {
                            ((DataGridViewComboBoxCell) this.dataGridViewKSXDSC.Rows[num + i].Cells["生产产品"]).Items.Add(ProductAttribute.P2.ToString());
                        }
                        if (TGlobals.currentActor.HasP3Capacity)
                        {
                            ((DataGridViewComboBoxCell) this.dataGridViewKSXDSC.Rows[num + i].Cells["生产产品"]).Items.Add(ProductAttribute.P3.ToString());
                        }
                        if (TGlobals.currentActor.HasP4Capacity)
                        {
                            ((DataGridViewComboBoxCell) this.dataGridViewKSXDSC.Rows[num + i].Cells["生产产品"]).Items.Add(ProductAttribute.P4.ToString());
                        }
                        ((DataGridViewComboBoxCell) this.dataGridViewKSXDSC.Rows[num + i].Cells["生产产品"]).Value = ((DataGridViewComboBoxCell) this.dataGridViewKSXDSC.Rows[num + i].Cells["生产产品"]).Items[0];
                    }
                }
            }
            if (num3 != 0)
            {
                for (int i = 0; i < lineArray3.Length; i++)
                {
                    this.dataGridViewKSXDSC.Rows[(num + num2) + i].Cells["选择项"].Value = false;
                    this.dataGridViewKSXDSC.Rows[(num + num2) + i].Cells["生产线编号"].Value = lineArray3[i].PLName;
                    this.dataGridViewKSXDSC.Rows[(num + num2) + i].Cells["生产线类型"].Value = lineArray3[i].PLAttribute;
                    this.dataGridViewKSXDSC.Rows[(num + num2) + i].Cells["所属厂房"].Value = "厂房C";
                    if ((lineArray3[i].PLAttribute != ProductLineAttribute.手工) && (lineArray3[i].PLAttribute != ProductLineAttribute.柔性))
                    {
                        ((DataGridViewComboBoxCell) this.dataGridViewKSXDSC.Rows[(num + num2) + i].Cells["生产产品"]).Items.Clear();
                        ((DataGridViewComboBoxCell) this.dataGridViewKSXDSC.Rows[(num + num2) + i].Cells["生产产品"]).Items.Add(lineArray3[i].CanManufacturedProductAttribute.ToString());
                        ((DataGridViewComboBoxCell) this.dataGridViewKSXDSC.Rows[(num + num2) + i].Cells["生产产品"]).Value = ((DataGridViewComboBoxCell) this.dataGridViewKSXDSC.Rows[(num + num2) + i].Cells["生产产品"]).Items[0];
                    }
                    else
                    {
                        ((DataGridViewComboBoxCell) this.dataGridViewKSXDSC.Rows[(num + num2) + i].Cells["生产产品"]).Items.Clear();
                        if (TGlobals.currentActor.HasP1Capacity)
                        {
                            ((DataGridViewComboBoxCell) this.dataGridViewKSXDSC.Rows[(num + num2) + i].Cells["生产产品"]).Items.Add(ProductAttribute.P1.ToString());
                        }
                        if (TGlobals.currentActor.HasP2Capacity)
                        {
                            ((DataGridViewComboBoxCell) this.dataGridViewKSXDSC.Rows[(num + num2) + i].Cells["生产产品"]).Items.Add(ProductAttribute.P2.ToString());
                        }
                        if (TGlobals.currentActor.HasP3Capacity)
                        {
                            ((DataGridViewComboBoxCell) this.dataGridViewKSXDSC.Rows[(num + num2) + i].Cells["生产产品"]).Items.Add(ProductAttribute.P3.ToString());
                        }
                        if (TGlobals.currentActor.HasP4Capacity)
                        {
                            ((DataGridViewComboBoxCell) this.dataGridViewKSXDSC.Rows[(num + num2) + i].Cells["生产产品"]).Items.Add(ProductAttribute.P4.ToString());
                        }
                        ((DataGridViewComboBoxCell) this.dataGridViewKSXDSC.Rows[(num + num2) + i].Cells["生产产品"]).Value = ((DataGridViewComboBoxCell) this.dataGridViewKSXDSC.Rows[(num + num2) + i].Cells["生产产品"]).Items[0];
                    }
                }
            }
        }

        private void InitializeComponent()
        {
            ComponentResourceManager manager = new ComponentResourceManager(typeof(frmKSXDSC));
            this.buttonOK = new Button();
            this.buttonCancel = new Button();
            this.groupBox2 = new GroupBox();
            this.richTextBox2 = new RichTextBox();
            this.dataGridViewKSXDSC = new DataGridView();
            this.选择项 = new DataGridViewCheckBoxColumn();
            this.生产线编号 = new DataGridViewTextBoxColumn();
            this.生产线类型 = new DataGridViewTextBoxColumn();
            this.所属厂房 = new DataGridViewTextBoxColumn();
            this.生产产品 = new DataGridViewComboBoxColumn();
            this.label1 = new Label();
            this.labelR1 = new Label();
            this.label3 = new Label();
            this.labelR2 = new Label();
            this.label5 = new Label();
            this.labelR3 = new Label();
            this.label7 = new Label();
            this.labelR4 = new Label();
            this.groupBox2.SuspendLayout();
            ((ISupportInitialize) this.dataGridViewKSXDSC).BeginInit();
            base.SuspendLayout();
            this.buttonOK.Location = new Point(0x21e, 0x11e);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new Size(0x4b, 0x17);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "确定";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new EventHandler(this.buttonOK_Click);
            this.buttonCancel.DialogResult = DialogResult.Cancel;
            this.buttonCancel.Location = new Point(0x26f, 0x11e);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new Size(0x4b, 0x17);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.groupBox2.Controls.Add(this.richTextBox2);
            this.groupBox2.Location = new Point(0x18f, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(0x12e, 0x110);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "说明";
            this.richTextBox2.BackColor = SystemColors.Window;
            this.richTextBox2.BorderStyle = BorderStyle.None;
            this.richTextBox2.Dock = DockStyle.Fill;
            this.richTextBox2.Font = new Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.richTextBox2.Location = new Point(3, 0x11);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.Size = new Size(0x128, 0xfc);
            this.richTextBox2.TabIndex = 4;
            this.richTextBox2.Text = manager.GetString("richTextBox2.Text");
            this.dataGridViewKSXDSC.AllowUserToAddRows = false;
            this.dataGridViewKSXDSC.AllowUserToDeleteRows = false;
            this.dataGridViewKSXDSC.AllowUserToResizeRows = false;
            this.dataGridViewKSXDSC.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridViewColumn[] dataGridViewColumns = new DataGridViewColumn[] { this.选择项, this.生产线编号, this.生产线类型, this.所属厂房, this.生产产品 };
            this.dataGridViewKSXDSC.Columns.AddRange(dataGridViewColumns);
            this.dataGridViewKSXDSC.Location = new Point(8, 8);
            this.dataGridViewKSXDSC.MultiSelect = false;
            this.dataGridViewKSXDSC.Name = "dataGridViewKSXDSC";
            this.dataGridViewKSXDSC.RowHeadersVisible = false;
            this.dataGridViewKSXDSC.RowTemplate.Height = 0x17;
            this.dataGridViewKSXDSC.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewKSXDSC.Size = new Size(0x181, 0x110);
            this.dataGridViewKSXDSC.TabIndex = 0x4b;
            this.选择项.HeaderText = "选择项";
            this.选择项.Name = "选择项";
            this.选择项.Resizable = DataGridViewTriState.False;
            this.选择项.Width = 70;
            this.生产线编号.HeaderText = "生产线编号";
            this.生产线编号.Name = "生产线编号";
            this.生产线编号.ReadOnly = true;
            this.生产线编号.Resizable = DataGridViewTriState.False;
            this.生产线编号.SortMode = DataGridViewColumnSortMode.NotSortable;
            this.生产线编号.Width = 0x4b;
            this.生产线类型.HeaderText = "生产线类型";
            this.生产线类型.Name = "生产线类型";
            this.生产线类型.ReadOnly = true;
            this.生产线类型.Resizable = DataGridViewTriState.False;
            this.生产线类型.SortMode = DataGridViewColumnSortMode.NotSortable;
            this.生产线类型.Width = 0x4b;
            this.所属厂房.HeaderText = "所属厂房";
            this.所属厂房.Name = "所属厂房";
            this.所属厂房.ReadOnly = true;
            this.所属厂房.Resizable = DataGridViewTriState.False;
            this.所属厂房.SortMode = DataGridViewColumnSortMode.NotSortable;
            this.所属厂房.Width = 0x4b;
            this.生产产品.HeaderText = "生产产品";
            this.生产产品.Name = "生产产品";
            this.生产产品.Resizable = DataGridViewTriState.False;
            this.生产产品.Width = 0x4b;
            this.label1.AutoSize = true;
            this.label1.Location = new Point(6, 0x123);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x47, 12);
            this.label1.TabIndex = 0x4c;
            this.label1.Text = "原料R1库存:";
            this.labelR1.AutoSize = true;
            this.labelR1.Location = new Point(0x49, 0x123);
            this.labelR1.Name = "labelR1";
            this.labelR1.Size = new Size(0x11, 12);
            this.labelR1.TabIndex = 0x4d;
            this.labelR1.Text = "-1";
            this.label3.AutoSize = true;
            this.label3.Location = new Point(0x6a, 0x123);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x47, 12);
            this.label3.TabIndex = 0x4e;
            this.label3.Text = "原料R2库存:";
            this.labelR2.AutoSize = true;
            this.labelR2.Location = new Point(0xac, 0x123);
            this.labelR2.Name = "labelR2";
            this.labelR2.Size = new Size(0x11, 12);
            this.labelR2.TabIndex = 0x4f;
            this.labelR2.Text = "-1";
            this.label5.AutoSize = true;
            this.label5.Location = new Point(0xce, 0x123);
            this.label5.Name = "label5";
            this.label5.Size = new Size(0x47, 12);
            this.label5.TabIndex = 80;
            this.label5.Text = "原料R3库存:";
            this.labelR3.AutoSize = true;
            this.labelR3.Location = new Point(0x110, 0x123);
            this.labelR3.Name = "labelR3";
            this.labelR3.Size = new Size(0x11, 12);
            this.labelR3.TabIndex = 0x51;
            this.labelR3.Text = "-1";
            this.label7.AutoSize = true;
            this.label7.Location = new Point(0x132, 0x123);
            this.label7.Name = "label7";
            this.label7.Size = new Size(0x47, 12);
            this.label7.TabIndex = 0x52;
            this.label7.Text = "原料R4库存:";
            this.labelR4.AutoSize = true;
            this.labelR4.Location = new Point(0x174, 0x123);
            this.labelR4.Name = "labelR4";
            this.labelR4.Size = new Size(0x11, 12);
            this.labelR4.TabIndex = 0x53;
            this.labelR4.Text = "-1";
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.CancelButton = this.buttonCancel;
            base.ClientSize = new Size(0x2c7, 0x13f);
            base.Controls.Add(this.labelR4);
            base.Controls.Add(this.label7);
            base.Controls.Add(this.labelR3);
            base.Controls.Add(this.label5);
            base.Controls.Add(this.labelR2);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.labelR1);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.dataGridViewKSXDSC);
            base.Controls.Add(this.groupBox2);
            base.Controls.Add(this.buttonCancel);
            base.Controls.Add(this.buttonOK);
            base.FormBorderStyle = FormBorderStyle.FixedDialog;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "frmKSXDSC";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "frmKSXDSC";
            base.Load += new EventHandler(this.frmKSXDSC_Load);
            this.groupBox2.ResumeLayout(false);
            ((ISupportInitialize) this.dataGridViewKSXDSC).EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }
    }
}

