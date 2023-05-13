namespace ERPChess
{
    using BusinessTier;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmBMSCX : Form
    {
        private IContainer components;
        private GroupBox groupBox1;
        private DataGridView dataGridViewBMSCX;
        private Button button1;
        private Button buttonCancel;
        private DataGridViewCheckBoxColumn 选择项;
        private DataGridViewTextBoxColumn 生产线编号;
        private DataGridViewTextBoxColumn 所属厂房;
        private DataGridViewTextBoxColumn 生产线类型;
        private DataGridViewTextBoxColumn 产品类型;
        private DataGridViewTextBoxColumn 残值;

        public frmBMSCX()
        {
            this.InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.dataGridViewBMSCX.Rows.Count; i++)
            {
                if ((bool) this.dataGridViewBMSCX.Rows[i].Cells["选择项"].Value)
                {
                    int num2 = (int) this.dataGridViewBMSCX.Rows[i].Cells["残值"].Value;
                    TOperatingSheet operatingSheet = TGlobals.currentActor.CurrBusinessConditions.OperatingSheet;
                    operatingSheet.CurrentCash += num2;
                    TOperatingSheet sheet2 = TGlobals.currentActor.CurrBusinessConditions.OperatingSheet;
                    sheet2.Equipment -= num2;
                    switch (((ProductLineName) this.dataGridViewBMSCX.Rows[i].Cells["生产线编号"].Value))
                    {
                        case ProductLineName.PL1:
                            TGlobals.currentActor.PlantA.PL1.PLAttribute = ProductLineAttribute.无;
                            break;

                        case ProductLineName.PL2:
                            TGlobals.currentActor.PlantA.PL2.PLAttribute = ProductLineAttribute.无;
                            break;

                        case ProductLineName.PL3:
                            TGlobals.currentActor.PlantA.PL3.PLAttribute = ProductLineAttribute.无;
                            break;

                        case ProductLineName.PL4:
                            TGlobals.currentActor.PlantA.PL4.PLAttribute = ProductLineAttribute.无;
                            break;

                        case ProductLineName.PL5:
                            TGlobals.currentActor.PlantB.PL5.PLAttribute = ProductLineAttribute.无;
                            break;

                        case ProductLineName.PL6:
                            TGlobals.currentActor.PlantB.PL6.PLAttribute = ProductLineAttribute.无;
                            break;

                        case ProductLineName.PL7:
                            TGlobals.currentActor.PlantB.PL7.PLAttribute = ProductLineAttribute.无;
                            break;

                        case ProductLineName.PL8:
                            TGlobals.currentActor.PlantC.PL8.PLAttribute = ProductLineAttribute.无;
                            break;

                        default:
                            break;
                    }
                }
            }
            bool flag = false;
            if (TGlobals.currentActor.PlantA.PL1.PLAttribute != ProductLineAttribute.无)
            {
                flag = true;
            }
            if (TGlobals.currentActor.PlantA.PL2.PLAttribute != ProductLineAttribute.无)
            {
                flag = true;
            }
            if (TGlobals.currentActor.PlantA.PL3.PLAttribute != ProductLineAttribute.无)
            {
                flag = true;
            }
            if (TGlobals.currentActor.PlantA.PL4.PLAttribute != ProductLineAttribute.无)
            {
                flag = true;
            }
            if (TGlobals.currentActor.PlantB.PL5.PLAttribute != ProductLineAttribute.无)
            {
                flag = true;
            }
            if (TGlobals.currentActor.PlantB.PL6.PLAttribute != ProductLineAttribute.无)
            {
                flag = true;
            }
            if (TGlobals.currentActor.PlantB.PL7.PLAttribute != ProductLineAttribute.无)
            {
                flag = true;
            }
            if (TGlobals.currentActor.PlantC.PL8.PLAttribute != ProductLineAttribute.无)
            {
                flag = true;
            }
            int equipment = TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.Equipment;
            if (!flag && (equipment > 0))
            {
                TGlobals.currentActor.CurrBusinessConditions.FinancialSheet.AdditionalExpenditure = equipment;
                TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.Equipment = 0;
            }
            if (equipment < 0)
            {
                TFinancialSheet financialSheet = TGlobals.currentActor.CurrBusinessConditions.FinancialSheet;
                financialSheet.AdditionalRevenue += -equipment;
                TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.Equipment = 0;
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

        private void frmBMSCX_Load(object sender, EventArgs e)
        {
            int canSaleProductLineCount = TGlobals.currentActor.PlantA.GetCanSaleProductLineCount(PlantName.工厂A);
            int num2 = TGlobals.currentActor.PlantB.GetCanSaleProductLineCount(PlantName.工厂B);
            int num3 = TGlobals.currentActor.PlantC.GetCanSaleProductLineCount(PlantName.工厂C);
            int num4 = (canSaleProductLineCount + num2) + num3;
            this.dataGridViewBMSCX.Rows.Clear();
            this.dataGridViewBMSCX.RowCount = num4;
            TProductLine[] canSaleProductLine = TGlobals.currentActor.PlantA.GetCanSaleProductLine(PlantName.工厂A);
            TProductLine[] lineArray2 = TGlobals.currentActor.PlantB.GetCanSaleProductLine(PlantName.工厂B);
            TProductLine[] lineArray3 = TGlobals.currentActor.PlantC.GetCanSaleProductLine(PlantName.工厂C);
            if (canSaleProductLineCount != 0)
            {
                for (int i = 0; i < canSaleProductLine.Length; i++)
                {
                    this.dataGridViewBMSCX.Rows[i].Cells["选择项"].Value = false;
                    this.dataGridViewBMSCX.Rows[i].Cells["生产线编号"].Value = canSaleProductLine[i].PLName;
                    this.dataGridViewBMSCX.Rows[i].Cells["所属厂房"].Value = "厂房A";
                    this.dataGridViewBMSCX.Rows[i].Cells["生产线类型"].Value = canSaleProductLine[i].PLAttribute;
                    this.dataGridViewBMSCX.Rows[i].Cells["产品类型"].Value = canSaleProductLine[i].CanManufacturedProductAttribute;
                    this.dataGridViewBMSCX.Rows[i].Cells["残值"].Value = canSaleProductLine[i].SaleCost;
                }
            }
            if (num2 != 0)
            {
                for (int i = 0; i < lineArray2.Length; i++)
                {
                    this.dataGridViewBMSCX.Rows[canSaleProductLineCount + i].Cells["选择项"].Value = false;
                    this.dataGridViewBMSCX.Rows[canSaleProductLineCount + i].Cells["生产线编号"].Value = lineArray2[i].PLName;
                    this.dataGridViewBMSCX.Rows[canSaleProductLineCount + i].Cells["所属厂房"].Value = "厂房B";
                    this.dataGridViewBMSCX.Rows[canSaleProductLineCount + i].Cells["生产线类型"].Value = lineArray2[i].PLAttribute;
                    this.dataGridViewBMSCX.Rows[canSaleProductLineCount + i].Cells["产品类型"].Value = lineArray2[i].CanManufacturedProductAttribute;
                    this.dataGridViewBMSCX.Rows[canSaleProductLineCount + i].Cells["残值"].Value = lineArray2[i].SaleCost;
                }
            }
            if (num3 != 0)
            {
                for (int i = 0; i < lineArray3.Length; i++)
                {
                    this.dataGridViewBMSCX.Rows[(canSaleProductLineCount + num2) + i].Cells["选择项"].Value = false;
                    this.dataGridViewBMSCX.Rows[(canSaleProductLineCount + num2) + i].Cells["生产线编号"].Value = lineArray3[i].PLName;
                    this.dataGridViewBMSCX.Rows[(canSaleProductLineCount + num2) + i].Cells["所属厂房"].Value = "厂房C";
                    this.dataGridViewBMSCX.Rows[(canSaleProductLineCount + num2) + i].Cells["生产线类型"].Value = lineArray3[i].PLAttribute;
                    this.dataGridViewBMSCX.Rows[(canSaleProductLineCount + num2) + i].Cells["产品类型"].Value = lineArray3[i].CanManufacturedProductAttribute;
                    this.dataGridViewBMSCX.Rows[(canSaleProductLineCount + num2) + i].Cells["残值"].Value = lineArray3[i].SaleCost;
                }
            }
        }

        private void InitializeComponent()
        {
            this.groupBox1 = new GroupBox();
            this.dataGridViewBMSCX = new DataGridView();
            this.选择项 = new DataGridViewCheckBoxColumn();
            this.生产线编号 = new DataGridViewTextBoxColumn();
            this.所属厂房 = new DataGridViewTextBoxColumn();
            this.生产线类型 = new DataGridViewTextBoxColumn();
            this.产品类型 = new DataGridViewTextBoxColumn();
            this.残值 = new DataGridViewTextBoxColumn();
            this.button1 = new Button();
            this.buttonCancel = new Button();
            this.groupBox1.SuspendLayout();
            ((ISupportInitialize) this.dataGridViewBMSCX).BeginInit();
            base.SuspendLayout();
            this.groupBox1.Controls.Add(this.dataGridViewBMSCX);
            this.groupBox1.Location = new Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(480, 0xfe);
            this.groupBox1.TabIndex = 0x4b;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "选则要变卖的生产线";
            this.dataGridViewBMSCX.AllowUserToAddRows = false;
            this.dataGridViewBMSCX.AllowUserToDeleteRows = false;
            this.dataGridViewBMSCX.AllowUserToResizeRows = false;
            this.dataGridViewBMSCX.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridViewColumn[] dataGridViewColumns = new DataGridViewColumn[] { this.选择项, this.生产线编号, this.所属厂房, this.生产线类型, this.产品类型, this.残值 };
            this.dataGridViewBMSCX.Columns.AddRange(dataGridViewColumns);
            this.dataGridViewBMSCX.Dock = DockStyle.Fill;
            this.dataGridViewBMSCX.Location = new Point(3, 0x11);
            this.dataGridViewBMSCX.MultiSelect = false;
            this.dataGridViewBMSCX.Name = "dataGridViewBMSCX";
            this.dataGridViewBMSCX.RowHeadersVisible = false;
            this.dataGridViewBMSCX.RowTemplate.Height = 0x17;
            this.dataGridViewBMSCX.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewBMSCX.Size = new Size(0x1da, 0xea);
            this.dataGridViewBMSCX.TabIndex = 0x4b;
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
            this.所属厂房.HeaderText = "所属厂房";
            this.所属厂房.Name = "所属厂房";
            this.所属厂房.ReadOnly = true;
            this.所属厂房.Resizable = DataGridViewTriState.False;
            this.所属厂房.SortMode = DataGridViewColumnSortMode.NotSortable;
            this.所属厂房.Width = 70;
            this.生产线类型.HeaderText = "生产线类型";
            this.生产线类型.Name = "生产线类型";
            this.生产线类型.ReadOnly = true;
            this.生产线类型.Resizable = DataGridViewTriState.False;
            this.生产线类型.SortMode = DataGridViewColumnSortMode.NotSortable;
            this.生产线类型.Width = 0x4b;
            this.产品类型.HeaderText = "产品类型";
            this.产品类型.Name = "产品类型";
            this.产品类型.ReadOnly = true;
            this.产品类型.Resizable = DataGridViewTriState.False;
            this.产品类型.SortMode = DataGridViewColumnSortMode.NotSortable;
            this.产品类型.Width = 70;
            this.残值.HeaderText = "残值";
            this.残值.Name = "残值";
            this.残值.ReadOnly = true;
            this.残值.Resizable = DataGridViewTriState.False;
            this.button1.DialogResult = DialogResult.OK;
            this.button1.Location = new Point(0x14d, 0x110);
            this.button1.Name = "button1";
            this.button1.Size = new Size(0x4b, 0x17);
            this.button1.TabIndex = 1;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click);
            this.buttonCancel.DialogResult = DialogResult.Cancel;
            this.buttonCancel.Location = new Point(0x19e, 0x110);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new Size(0x4b, 0x17);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.CancelButton = this.buttonCancel;
            base.ClientSize = new Size(0x1f6, 300);
            base.Controls.Add(this.buttonCancel);
            base.Controls.Add(this.button1);
            base.Controls.Add(this.groupBox1);
            base.FormBorderStyle = FormBorderStyle.FixedDialog;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "frmBMSCX";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "frmBMSCX";
            base.Load += new EventHandler(this.frmBMSCX_Load);
            this.groupBox1.ResumeLayout(false);
            ((ISupportInitialize) this.dataGridViewBMSCX).EndInit();
            base.ResumeLayout(false);
        }
    }
}

