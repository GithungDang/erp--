namespace ERPChess
{
    using BusinessTier;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmZFSBXLF : Form
    {
        private IContainer components;
        private Button buttonOK;
        private Button buttonCancel;
        private GroupBox groupBox2;
        private RichTextBox richTextBox2;

        public frmZFSBXLF()
        {
            this.InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            int xYWXSCXCount = TGlobals.currentActor.PlantC.GetXYWXSCXCount(PlantName.工厂C);
            int num4 = (TGlobals.currentActor.PlantA.GetXYWXSCXCount(PlantName.工厂A) + TGlobals.currentActor.PlantB.GetXYWXSCXCount(PlantName.工厂B)) + xYWXSCXCount;
            TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.CurrentCash -= num4;
            TGlobals.currentActor.CurrBusinessConditions.ComprehensiveCostSheet.EquipmentMaintenance += num4;
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
            this.buttonOK.Location = new Point(0x17d, 0xbf);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new Size(0x4b, 0x17);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "确定";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new EventHandler(this.buttonOK_Click);
            this.buttonCancel.DialogResult = DialogResult.Cancel;
            this.buttonCancel.Location = new Point(0x1ce, 0xbf);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new Size(0x4b, 0x17);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.groupBox2.Controls.Add(this.richTextBox2);
            this.groupBox2.Location = new Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(0x20d, 0xad);
            this.groupBox2.TabIndex = 0x4c;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "说明";
            this.richTextBox2.BackColor = SystemColors.Window;
            this.richTextBox2.BorderStyle = BorderStyle.None;
            this.richTextBox2.Dock = DockStyle.Fill;
            this.richTextBox2.Font = new Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.richTextBox2.Location = new Point(3, 0x11);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.Size = new Size(0x207, 0x99);
            this.richTextBox2.TabIndex = 1;
            this.richTextBox2.Text = "    任务清单上的这项工作是支付用于机器设备等等的维护/修理等费用。每条生产线的该费用为1M。只要年末厂房中有已经使用的生产线你必须支付维修费。\n\n    本步系统自动完成。";
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.CancelButton = this.buttonCancel;
            base.ClientSize = new Size(550, 0xe0);
            base.Controls.Add(this.groupBox2);
            base.Controls.Add(this.buttonCancel);
            base.Controls.Add(this.buttonOK);
            base.FormBorderStyle = FormBorderStyle.FixedDialog;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "frmZFSBXLF";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "frmZFSBXLF";
            this.groupBox2.ResumeLayout(false);
            base.ResumeLayout(false);
        }
    }
}

