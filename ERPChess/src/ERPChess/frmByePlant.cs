namespace ERPChess
{
    using BusinessTier;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmByePlant : Form
    {
        private IContainer components;
        private GroupBox groupBox1;
        private Label label16;
        private Label label15;
        private Label label14;
        private Label label4;
        private Label label9;
        private Label label13;
        private Label label12;
        private Label label11;
        private Label label10;
        private CheckBox checkBoxPC;
        private CheckBox checkBoxPB;
        private CheckBox checkBoxPA;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label5;
        private Label label17;
        private Label label18;
        private Label label19;
        private Label label20;
        private Button buttonOK;
        private GroupBox groupBox2;
        private RichTextBox richTextBox2;
        private Button buttonCancel;

        public frmByePlant()
        {
            this.InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (this.checkBoxPA.Checked)
            {
                TGlobals.currentActor.PlantA.PlantAttribute = PlantAttribute.购买;
                TOperatingSheet operatingSheet = TGlobals.currentActor.CurrBusinessConditions.OperatingSheet;
                operatingSheet.CurrentCash -= TGlobals.currentActor.PlantA.PurchasePrice;
                TOperatingSheet sheet2 = TGlobals.currentActor.CurrBusinessConditions.OperatingSheet;
                sheet2.Plant += TGlobals.currentActor.PlantA.PurchasePrice;
            }
            if (this.checkBoxPB.Checked)
            {
                TGlobals.currentActor.PlantB.PlantAttribute = PlantAttribute.购买;
                TOperatingSheet operatingSheet = TGlobals.currentActor.CurrBusinessConditions.OperatingSheet;
                operatingSheet.CurrentCash -= TGlobals.currentActor.PlantB.PurchasePrice;
                TOperatingSheet sheet4 = TGlobals.currentActor.CurrBusinessConditions.OperatingSheet;
                sheet4.Plant += TGlobals.currentActor.PlantB.PurchasePrice;
            }
            if (this.checkBoxPC.Checked)
            {
                TGlobals.currentActor.PlantC.PlantAttribute = PlantAttribute.购买;
                TOperatingSheet operatingSheet = TGlobals.currentActor.CurrBusinessConditions.OperatingSheet;
                operatingSheet.CurrentCash -= TGlobals.currentActor.PlantC.PurchasePrice;
                TOperatingSheet sheet6 = TGlobals.currentActor.CurrBusinessConditions.OperatingSheet;
                sheet6.Plant += TGlobals.currentActor.PlantC.PurchasePrice;
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

        private void frmByePlant_Load(object sender, EventArgs e)
        {
            if (TGlobals.currentActor.PlantA.PlantAttribute == PlantAttribute.购买)
            {
                this.checkBoxPA.Enabled = false;
            }
            if (TGlobals.currentActor.PlantB.PlantAttribute == PlantAttribute.购买)
            {
                this.checkBoxPB.Enabled = false;
            }
            if (TGlobals.currentActor.PlantC.PlantAttribute == PlantAttribute.购买)
            {
                this.checkBoxPC.Enabled = false;
            }
        }

        private void InitializeComponent()
        {
            this.groupBox1 = new GroupBox();
            this.label17 = new Label();
            this.label18 = new Label();
            this.label19 = new Label();
            this.label20 = new Label();
            this.label16 = new Label();
            this.label15 = new Label();
            this.label14 = new Label();
            this.label4 = new Label();
            this.label9 = new Label();
            this.label13 = new Label();
            this.label12 = new Label();
            this.label11 = new Label();
            this.label10 = new Label();
            this.checkBoxPC = new CheckBox();
            this.checkBoxPB = new CheckBox();
            this.checkBoxPA = new CheckBox();
            this.label8 = new Label();
            this.label7 = new Label();
            this.label6 = new Label();
            this.label3 = new Label();
            this.label2 = new Label();
            this.label1 = new Label();
            this.label5 = new Label();
            this.buttonOK = new Button();
            this.groupBox2 = new GroupBox();
            this.richTextBox2 = new RichTextBox();
            this.buttonCancel = new Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            base.SuspendLayout();
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.checkBoxPC);
            this.groupBox1.Controls.Add(this.checkBoxPB);
            this.groupBox1.Controls.Add(this.checkBoxPA);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x215, 0x75);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "选择要购买的厂房";
            this.label17.BorderStyle = BorderStyle.FixedSingle;
            this.label17.Location = new Point(0x1a1, 0x4e);
            this.label17.Name = "label17";
            this.label17.Size = new Size(100, 20);
            this.label17.TabIndex = 0x6a;
            this.label17.Text = "1条生产线";
            this.label17.TextAlign = ContentAlignment.MiddleCenter;
            this.label18.BorderStyle = BorderStyle.FixedSingle;
            this.label18.Location = new Point(0x1a1, 0x3b);
            this.label18.Name = "label18";
            this.label18.Size = new Size(100, 20);
            this.label18.TabIndex = 0x69;
            this.label18.Text = "3条生产线";
            this.label18.TextAlign = ContentAlignment.MiddleCenter;
            this.label19.BorderStyle = BorderStyle.FixedSingle;
            this.label19.Location = new Point(0x1a1, 40);
            this.label19.Name = "label19";
            this.label19.Size = new Size(100, 20);
            this.label19.TabIndex = 0x68;
            this.label19.Text = "4条生产线";
            this.label19.TextAlign = ContentAlignment.MiddleCenter;
            this.label20.BorderStyle = BorderStyle.FixedSingle;
            this.label20.Location = new Point(0x1a1, 0x15);
            this.label20.Name = "label20";
            this.label20.Size = new Size(100, 20);
            this.label20.TabIndex = 0x67;
            this.label20.Text = "容量";
            this.label20.TextAlign = ContentAlignment.MiddleCenter;
            this.label16.BorderStyle = BorderStyle.FixedSingle;
            this.label16.Location = new Point(0x13e, 0x4e);
            this.label16.Name = "label16";
            this.label16.Size = new Size(100, 20);
            this.label16.TabIndex = 0x66;
            this.label16.Text = "2M/年";
            this.label16.TextAlign = ContentAlignment.MiddleCenter;
            this.label15.BorderStyle = BorderStyle.FixedSingle;
            this.label15.Location = new Point(0x13e, 0x3b);
            this.label15.Name = "label15";
            this.label15.Size = new Size(100, 20);
            this.label15.TabIndex = 0x65;
            this.label15.Text = "3M/年";
            this.label15.TextAlign = ContentAlignment.MiddleCenter;
            this.label14.BorderStyle = BorderStyle.FixedSingle;
            this.label14.Location = new Point(0x13e, 40);
            this.label14.Name = "label14";
            this.label14.Size = new Size(100, 20);
            this.label14.TabIndex = 100;
            this.label14.Text = "4M/年";
            this.label14.TextAlign = ContentAlignment.MiddleCenter;
            this.label4.BorderStyle = BorderStyle.FixedSingle;
            this.label4.Location = new Point(0xdb, 0x4e);
            this.label4.Name = "label4";
            this.label4.Size = new Size(100, 20);
            this.label4.TabIndex = 0x63;
            this.label4.Text = "12M";
            this.label4.TextAlign = ContentAlignment.MiddleCenter;
            this.label9.BorderStyle = BorderStyle.FixedSingle;
            this.label9.Location = new Point(0xdb, 0x3b);
            this.label9.Name = "label9";
            this.label9.Size = new Size(100, 20);
            this.label9.TabIndex = 0x62;
            this.label9.Text = "24M";
            this.label9.TextAlign = ContentAlignment.MiddleCenter;
            this.label13.BorderStyle = BorderStyle.FixedSingle;
            this.label13.Location = new Point(0xdb, 40);
            this.label13.Name = "label13";
            this.label13.Size = new Size(100, 20);
            this.label13.TabIndex = 0x61;
            this.label13.Text = "32M";
            this.label13.TextAlign = ContentAlignment.MiddleCenter;
            this.label12.BorderStyle = BorderStyle.FixedSingle;
            this.label12.Location = new Point(120, 0x4e);
            this.label12.Name = "label12";
            this.label12.Size = new Size(100, 20);
            this.label12.TabIndex = 0x60;
            this.label12.Text = "厂房C";
            this.label12.TextAlign = ContentAlignment.MiddleCenter;
            this.label11.BorderStyle = BorderStyle.FixedSingle;
            this.label11.Location = new Point(120, 0x3b);
            this.label11.Name = "label11";
            this.label11.Size = new Size(100, 20);
            this.label11.TabIndex = 0x5f;
            this.label11.Text = "厂房B";
            this.label11.TextAlign = ContentAlignment.MiddleCenter;
            this.label10.BorderStyle = BorderStyle.FixedSingle;
            this.label10.Location = new Point(120, 40);
            this.label10.Name = "label10";
            this.label10.Size = new Size(100, 20);
            this.label10.TabIndex = 0x5e;
            this.label10.Text = "厂房A";
            this.label10.TextAlign = ContentAlignment.MiddleCenter;
            this.checkBoxPC.AutoSize = true;
            this.checkBoxPC.Location = new Point(0x3f, 0x52);
            this.checkBoxPC.Name = "checkBoxPC";
            this.checkBoxPC.Size = new Size(15, 14);
            this.checkBoxPC.TabIndex = 0x5d;
            this.checkBoxPC.UseVisualStyleBackColor = true;
            this.checkBoxPB.AutoSize = true;
            this.checkBoxPB.Location = new Point(0x3f, 0x3f);
            this.checkBoxPB.Name = "checkBoxPB";
            this.checkBoxPB.Size = new Size(15, 14);
            this.checkBoxPB.TabIndex = 0x5c;
            this.checkBoxPB.UseVisualStyleBackColor = true;
            this.checkBoxPA.AutoSize = true;
            this.checkBoxPA.Location = new Point(0x3f, 0x2c);
            this.checkBoxPA.Name = "checkBoxPA";
            this.checkBoxPA.Size = new Size(15, 14);
            this.checkBoxPA.TabIndex = 0x5b;
            this.checkBoxPA.UseVisualStyleBackColor = true;
            this.label8.BorderStyle = BorderStyle.FixedSingle;
            this.label8.Location = new Point(0x15, 40);
            this.label8.Name = "label8";
            this.label8.Size = new Size(100, 20);
            this.label8.TabIndex = 90;
            this.label8.TextAlign = ContentAlignment.MiddleCenter;
            this.label7.BorderStyle = BorderStyle.FixedSingle;
            this.label7.Location = new Point(0x15, 0x3b);
            this.label7.Name = "label7";
            this.label7.Size = new Size(100, 20);
            this.label7.TabIndex = 0x59;
            this.label7.TextAlign = ContentAlignment.MiddleCenter;
            this.label6.BorderStyle = BorderStyle.FixedSingle;
            this.label6.Location = new Point(0x15, 0x4e);
            this.label6.Name = "label6";
            this.label6.Size = new Size(100, 20);
            this.label6.TabIndex = 0x58;
            this.label6.TextAlign = ContentAlignment.MiddleCenter;
            this.label3.BorderStyle = BorderStyle.FixedSingle;
            this.label3.Location = new Point(0x13e, 0x15);
            this.label3.Name = "label3";
            this.label3.Size = new Size(100, 20);
            this.label3.TabIndex = 0x57;
            this.label3.Text = "租凭价格";
            this.label3.TextAlign = ContentAlignment.MiddleCenter;
            this.label2.BorderStyle = BorderStyle.FixedSingle;
            this.label2.Location = new Point(0xdb, 0x15);
            this.label2.Name = "label2";
            this.label2.Size = new Size(100, 20);
            this.label2.TabIndex = 0x56;
            this.label2.Text = "购买价格";
            this.label2.TextAlign = ContentAlignment.MiddleCenter;
            this.label1.BorderStyle = BorderStyle.FixedSingle;
            this.label1.Location = new Point(120, 0x15);
            this.label1.Name = "label1";
            this.label1.Size = new Size(100, 20);
            this.label1.TabIndex = 0x55;
            this.label1.Text = "厂房名称";
            this.label1.TextAlign = ContentAlignment.MiddleCenter;
            this.label5.BorderStyle = BorderStyle.FixedSingle;
            this.label5.Location = new Point(0x15, 0x15);
            this.label5.Name = "label5";
            this.label5.Size = new Size(100, 20);
            this.label5.TabIndex = 0x54;
            this.label5.Text = "操作项目";
            this.label5.TextAlign = ContentAlignment.MiddleCenter;
            this.buttonOK.DialogResult = DialogResult.OK;
            this.buttonOK.Location = new Point(0x180, 0xd8);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new Size(0x4b, 0x17);
            this.buttonOK.TabIndex = 1;
            this.buttonOK.Text = "确定";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new EventHandler(this.buttonOK_Click);
            this.groupBox2.Controls.Add(this.richTextBox2);
            this.groupBox2.Location = new Point(12, 0x87);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(0x215, 70);
            this.groupBox2.TabIndex = 0x4e;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "说明";
            this.richTextBox2.BackColor = SystemColors.Window;
            this.richTextBox2.BorderStyle = BorderStyle.None;
            this.richTextBox2.Dock = DockStyle.Fill;
            this.richTextBox2.Font = new Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.richTextBox2.Location = new Point(3, 0x11);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.Size = new Size(0x20f, 50);
            this.richTextBox2.TabIndex = 0x17;
            this.richTextBox2.Text = "    购买厂房时，将按上表购买价格支付所选中厂房的费用。拥有厂房后年末免交该厂房租金。";
            this.buttonCancel.DialogResult = DialogResult.Cancel;
            this.buttonCancel.Location = new Point(470, 0xd8);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new Size(0x4b, 0x17);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.CancelButton = this.buttonCancel;
            base.ClientSize = new Size(0x235, 0xfb);
            base.Controls.Add(this.buttonCancel);
            base.Controls.Add(this.groupBox2);
            base.Controls.Add(this.buttonOK);
            base.Controls.Add(this.groupBox1);
            base.FormBorderStyle = FormBorderStyle.FixedDialog;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "frmByePlant";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "购买厂房";
            base.Load += new EventHandler(this.frmByePlant_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            base.ResumeLayout(false);
        }
    }
}

