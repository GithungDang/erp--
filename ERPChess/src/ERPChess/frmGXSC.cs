namespace ERPChess
{
    using BusinessTier;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmGXSC : Form
    {
        private IContainer components;
        private Button buttonOK;
        private Button buttonCancel;
        private GroupBox groupBox2;
        private RichTextBox richTextBox2;

        public frmGXSC()
        {
            this.InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (TGlobals.currentActor.PlantA.PlantAttribute != PlantAttribute.无)
            {
                if (TGlobals.currentActor.PlantA.PL1.PLAttribute != ProductLineAttribute.无)
                {
                    TProductLine pLine = TGlobals.currentActor.PlantA.PL1;
                    if (pLine.RemainProduceCycle == 1)
                    {
                        this.IntoWarehouse(pLine);
                    }
                    pLine.AlreadyProduceCycle++;
                }
                if (TGlobals.currentActor.PlantA.PL2.PLAttribute != ProductLineAttribute.无)
                {
                    TProductLine pLine = TGlobals.currentActor.PlantA.PL2;
                    if (pLine.RemainProduceCycle == 1)
                    {
                        this.IntoWarehouse(pLine);
                    }
                    pLine.AlreadyProduceCycle++;
                }
                if (TGlobals.currentActor.PlantA.PL3.PLAttribute != ProductLineAttribute.无)
                {
                    TProductLine pLine = TGlobals.currentActor.PlantA.PL3;
                    if (pLine.RemainProduceCycle == 1)
                    {
                        this.IntoWarehouse(pLine);
                    }
                    pLine.AlreadyProduceCycle++;
                }
                if (TGlobals.currentActor.PlantA.PL4.PLAttribute != ProductLineAttribute.无)
                {
                    TProductLine pLine = TGlobals.currentActor.PlantA.PL4;
                    if (pLine.RemainProduceCycle == 1)
                    {
                        this.IntoWarehouse(pLine);
                    }
                    pLine.AlreadyProduceCycle++;
                }
            }
            if (TGlobals.currentActor.PlantB.PlantAttribute != PlantAttribute.无)
            {
                if (TGlobals.currentActor.PlantB.PL5.PLAttribute != ProductLineAttribute.无)
                {
                    TProductLine pLine = TGlobals.currentActor.PlantB.PL5;
                    if (pLine.RemainProduceCycle == 1)
                    {
                        this.IntoWarehouse(pLine);
                    }
                    pLine.AlreadyProduceCycle++;
                }
                if (TGlobals.currentActor.PlantB.PL6.PLAttribute != ProductLineAttribute.无)
                {
                    TProductLine pLine = TGlobals.currentActor.PlantB.PL6;
                    if (pLine.RemainProduceCycle == 1)
                    {
                        this.IntoWarehouse(pLine);
                    }
                    pLine.AlreadyProduceCycle++;
                }
                if (TGlobals.currentActor.PlantB.PL7.PLAttribute != ProductLineAttribute.无)
                {
                    TProductLine pLine = TGlobals.currentActor.PlantB.PL7;
                    if (pLine.RemainProduceCycle == 1)
                    {
                        this.IntoWarehouse(pLine);
                    }
                    pLine.AlreadyProduceCycle++;
                }
            }
            if ((TGlobals.currentActor.PlantC.PlantAttribute != PlantAttribute.无) && (TGlobals.currentActor.PlantC.PL8.PLAttribute != ProductLineAttribute.无))
            {
                TProductLine pLine = TGlobals.currentActor.PlantC.PL8;
                if (pLine.RemainProduceCycle == 1)
                {
                    this.IntoWarehouse(pLine);
                }
                pLine.AlreadyProduceCycle++;
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

        private void InitializeComponent()
        {
            this.buttonOK = new Button();
            this.buttonCancel = new Button();
            this.groupBox2 = new GroupBox();
            this.richTextBox2 = new RichTextBox();
            this.groupBox2.SuspendLayout();
            base.SuspendLayout();
            this.buttonOK.DialogResult = DialogResult.OK;
            this.buttonOK.Location = new Point(0x11b, 0x90);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new Size(0x4b, 0x17);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "确定";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new EventHandler(this.buttonOK_Click);
            this.buttonCancel.DialogResult = DialogResult.Cancel;
            this.buttonCancel.Location = new Point(0x16c, 0x90);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new Size(0x4b, 0x17);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new EventHandler(this.buttonCancel_Click);
            this.groupBox2.Controls.Add(this.richTextBox2);
            this.groupBox2.Location = new Point(0x17, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(0x1a0, 0x7e);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "说明";
            this.richTextBox2.BackColor = SystemColors.Window;
            this.richTextBox2.BorderStyle = BorderStyle.None;
            this.richTextBox2.Dock = DockStyle.Fill;
            this.richTextBox2.Font = new Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.richTextBox2.Location = new Point(3, 0x11);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.Size = new Size(410, 0x6a);
            this.richTextBox2.TabIndex = 4;
            this.richTextBox2.Text = "    所有生产线上的在产品，都向前移动一步。如果产品已完工，它将移到相应产成品库中。\n\n    本步系统自动完成(各厂房生产线的详细信息请查看台面)。";
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.CancelButton = this.buttonCancel;
            base.ClientSize = new Size(460, 0xb3);
            base.Controls.Add(this.groupBox2);
            base.Controls.Add(this.buttonCancel);
            base.Controls.Add(this.buttonOK);
            base.FormBorderStyle = FormBorderStyle.FixedDialog;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "frmGXSC";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "frmGXSC";
            this.groupBox2.ResumeLayout(false);
            base.ResumeLayout(false);
        }

        private void IntoWarehouse(TProductLine pLine)
        {
            TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.AreProducts -= pLine.ManufacturedProduct.Cost;
            TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.FinishedProduct += pLine.ManufacturedProduct.Cost;
            switch (pLine.ManufacturedProduct.PAttribute)
            {
                case ProductAttribute.P1:
                    TGlobals.currentActor.P1Warehouse.InventoryAmount += pLine.ManufacturedProduct.Cost;
                    return;

                case ProductAttribute.P2:
                    TGlobals.currentActor.P2Warehouse.InventoryAmount += pLine.ManufacturedProduct.Cost;
                    return;

                case ProductAttribute.P3:
                    TGlobals.currentActor.P3Warehouse.InventoryAmount += pLine.ManufacturedProduct.Cost;
                    return;

                case ProductAttribute.P4:
                    TGlobals.currentActor.P4Warehouse.InventoryAmount += pLine.ManufacturedProduct.Cost;
                    return;
            }
        }
    }
}

