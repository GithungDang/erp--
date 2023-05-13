namespace ERPChess
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmCPYFTZ : Form
    {
        private IContainer components;
        private Button buttonOK;
        private Button buttonCancel;
        private Label label5;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label6;
        private Label label7;
        private Label label8;
        private CheckBox checkBoxP2;
        private CheckBox checkBoxP3;
        private CheckBox checkBoxP4;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label4;
        private Label label9;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label16;
        private GroupBox groupBox1;
        private RichTextBox richTextBox2;
        private Label labelP4;
        private Label labelP3;
        private Label labelP2;
        private Label label20;

        public frmCPYFTZ()
        {
            this.InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            int num = 0;
            int num2 = 0;
            int num3 = 0;
            if (this.checkBoxP2.Checked)
            {
                num = 1;
                TGlobals.currentActor.YFP2Cost += num;
            }
            if (this.checkBoxP3.Checked)
            {
                num2 = 2;
                TGlobals.currentActor.YFP3Cost += num2;
            }
            if (this.checkBoxP4.Checked)
            {
                num3 = 3;
                TGlobals.currentActor.YFP4Cost += num3;
            }
            TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.CurrentCash -= (num + num2) + num3;
            TGlobals.currentActor.CurrBusinessConditions.ComprehensiveCostSheet.ProductDevelopment += (num + num2) + num3;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void frmCPYFTZ_Load(object sender, EventArgs e)
        {
            if (TGlobals.currentActor.HasP2Capacity)
            {
                this.checkBoxP2.Enabled = false;
                this.labelP2.Text = "P2开发完毕";
            }
            else
            {
                this.checkBoxP2.Enabled = true;
                this.labelP2.Text = TGlobals.currentActor.GetYFP2SYQS().ToString() + "季";
            }
            if (TGlobals.currentActor.HasP3Capacity)
            {
                this.checkBoxP3.Enabled = false;
                this.labelP3.Text = "P3开发完毕";
            }
            else
            {
                this.checkBoxP3.Enabled = true;
                this.labelP3.Text = TGlobals.currentActor.GetYFP3SYQS().ToString() + "季";
            }
            if (TGlobals.currentActor.HasP4Capacity)
            {
                this.checkBoxP4.Enabled = false;
                this.labelP4.Text = "P4开发完毕";
            }
            else
            {
                this.checkBoxP4.Enabled = true;
                this.labelP4.Text = TGlobals.currentActor.GetYFP4SYQS().ToString() + "季";
            }
        }

        private void InitializeComponent()
        {
            this.buttonOK = new Button();
            this.buttonCancel = new Button();
            this.label5 = new Label();
            this.label1 = new Label();
            this.label2 = new Label();
            this.label3 = new Label();
            this.label6 = new Label();
            this.label7 = new Label();
            this.label8 = new Label();
            this.checkBoxP2 = new CheckBox();
            this.checkBoxP3 = new CheckBox();
            this.checkBoxP4 = new CheckBox();
            this.label10 = new Label();
            this.label11 = new Label();
            this.label12 = new Label();
            this.label4 = new Label();
            this.label9 = new Label();
            this.label13 = new Label();
            this.label14 = new Label();
            this.label15 = new Label();
            this.label16 = new Label();
            this.groupBox1 = new GroupBox();
            this.richTextBox2 = new RichTextBox();
            this.labelP4 = new Label();
            this.labelP3 = new Label();
            this.labelP2 = new Label();
            this.label20 = new Label();
            this.groupBox1.SuspendLayout();
            base.SuspendLayout();
            this.buttonOK.DialogResult = DialogResult.OK;
            this.buttonOK.Location = new Point(0x15f, 0xb3);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new Size(0x4b, 0x17);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "确定";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new EventHandler(this.buttonOK_Click);
            this.buttonCancel.DialogResult = DialogResult.Cancel;
            this.buttonCancel.Location = new Point(0x1b0, 0xb3);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new Size(0x4b, 0x17);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.label5.BorderStyle = BorderStyle.FixedSingle;
            this.label5.Location = new Point(14, 14);
            this.label5.Name = "label5";
            this.label5.Size = new Size(100, 20);
            this.label5.TabIndex = 0x3f;
            this.label5.Text = "操作项目";
            this.label5.TextAlign = ContentAlignment.MiddleCenter;
            this.label1.BorderStyle = BorderStyle.FixedSingle;
            this.label1.Location = new Point(0x71, 14);
            this.label1.Name = "label1";
            this.label1.Size = new Size(100, 20);
            this.label1.TabIndex = 0x40;
            this.label1.Text = "产品";
            this.label1.TextAlign = ContentAlignment.MiddleCenter;
            this.label2.BorderStyle = BorderStyle.FixedSingle;
            this.label2.Location = new Point(0xd4, 14);
            this.label2.Name = "label2";
            this.label2.Size = new Size(100, 20);
            this.label2.TabIndex = 0x41;
            this.label2.Text = "投资总金额";
            this.label2.TextAlign = ContentAlignment.MiddleCenter;
            this.label3.BorderStyle = BorderStyle.FixedSingle;
            this.label3.Location = new Point(0x137, 14);
            this.label3.Name = "label3";
            this.label3.Size = new Size(100, 20);
            this.label3.TabIndex = 0x42;
            this.label3.Text = "投资总时间";
            this.label3.TextAlign = ContentAlignment.MiddleCenter;
            this.label6.BorderStyle = BorderStyle.FixedSingle;
            this.label6.Location = new Point(14, 0x47);
            this.label6.Name = "label6";
            this.label6.Size = new Size(100, 20);
            this.label6.TabIndex = 0x44;
            this.label6.TextAlign = ContentAlignment.MiddleCenter;
            this.label7.BorderStyle = BorderStyle.FixedSingle;
            this.label7.Location = new Point(14, 0x34);
            this.label7.Name = "label7";
            this.label7.Size = new Size(100, 20);
            this.label7.TabIndex = 0x45;
            this.label7.TextAlign = ContentAlignment.MiddleCenter;
            this.label8.BorderStyle = BorderStyle.FixedSingle;
            this.label8.Location = new Point(14, 0x21);
            this.label8.Name = "label8";
            this.label8.Size = new Size(100, 20);
            this.label8.TabIndex = 70;
            this.label8.TextAlign = ContentAlignment.MiddleCenter;
            this.checkBoxP2.AutoSize = true;
            this.checkBoxP2.Location = new Point(0x38, 0x25);
            this.checkBoxP2.Name = "checkBoxP2";
            this.checkBoxP2.Size = new Size(15, 14);
            this.checkBoxP2.TabIndex = 0x47;
            this.checkBoxP2.UseVisualStyleBackColor = true;
            this.checkBoxP3.AutoSize = true;
            this.checkBoxP3.Location = new Point(0x38, 0x38);
            this.checkBoxP3.Name = "checkBoxP3";
            this.checkBoxP3.Size = new Size(15, 14);
            this.checkBoxP3.TabIndex = 0x48;
            this.checkBoxP3.UseVisualStyleBackColor = true;
            this.checkBoxP4.AutoSize = true;
            this.checkBoxP4.Location = new Point(0x38, 0x4b);
            this.checkBoxP4.Name = "checkBoxP4";
            this.checkBoxP4.Size = new Size(15, 14);
            this.checkBoxP4.TabIndex = 0x49;
            this.checkBoxP4.UseVisualStyleBackColor = true;
            this.label10.BorderStyle = BorderStyle.FixedSingle;
            this.label10.Location = new Point(0x71, 0x21);
            this.label10.Name = "label10";
            this.label10.Size = new Size(100, 20);
            this.label10.TabIndex = 0x4b;
            this.label10.Text = "P2";
            this.label10.TextAlign = ContentAlignment.MiddleCenter;
            this.label11.BorderStyle = BorderStyle.FixedSingle;
            this.label11.Location = new Point(0x71, 0x34);
            this.label11.Name = "label11";
            this.label11.Size = new Size(100, 20);
            this.label11.TabIndex = 0x4c;
            this.label11.Text = "P3";
            this.label11.TextAlign = ContentAlignment.MiddleCenter;
            this.label12.BorderStyle = BorderStyle.FixedSingle;
            this.label12.Location = new Point(0x71, 0x47);
            this.label12.Name = "label12";
            this.label12.Size = new Size(100, 20);
            this.label12.TabIndex = 0x4d;
            this.label12.Text = "P4";
            this.label12.TextAlign = ContentAlignment.MiddleCenter;
            this.label4.BorderStyle = BorderStyle.FixedSingle;
            this.label4.Location = new Point(0xd4, 0x47);
            this.label4.Name = "label4";
            this.label4.Size = new Size(100, 20);
            this.label4.TabIndex = 80;
            this.label4.Text = "18";
            this.label4.TextAlign = ContentAlignment.MiddleCenter;
            this.label9.BorderStyle = BorderStyle.FixedSingle;
            this.label9.Location = new Point(0xd4, 0x34);
            this.label9.Name = "label9";
            this.label9.Size = new Size(100, 20);
            this.label9.TabIndex = 0x4f;
            this.label9.Text = "12";
            this.label9.TextAlign = ContentAlignment.MiddleCenter;
            this.label13.BorderStyle = BorderStyle.FixedSingle;
            this.label13.Location = new Point(0xd4, 0x21);
            this.label13.Name = "label13";
            this.label13.Size = new Size(100, 20);
            this.label13.TabIndex = 0x4e;
            this.label13.Text = "6";
            this.label13.TextAlign = ContentAlignment.MiddleCenter;
            this.label14.BorderStyle = BorderStyle.FixedSingle;
            this.label14.Location = new Point(0x137, 0x21);
            this.label14.Name = "label14";
            this.label14.Size = new Size(100, 20);
            this.label14.TabIndex = 0x51;
            this.label14.Text = "6季";
            this.label14.TextAlign = ContentAlignment.MiddleCenter;
            this.label15.BorderStyle = BorderStyle.FixedSingle;
            this.label15.Location = new Point(0x137, 0x34);
            this.label15.Name = "label15";
            this.label15.Size = new Size(100, 20);
            this.label15.TabIndex = 0x52;
            this.label15.Text = "6季";
            this.label15.TextAlign = ContentAlignment.MiddleCenter;
            this.label16.BorderStyle = BorderStyle.FixedSingle;
            this.label16.Location = new Point(0x137, 0x47);
            this.label16.Name = "label16";
            this.label16.Size = new Size(100, 20);
            this.label16.TabIndex = 0x53;
            this.label16.Text = "6季";
            this.label16.TextAlign = ContentAlignment.MiddleCenter;
            this.groupBox1.Controls.Add(this.richTextBox2);
            this.groupBox1.Location = new Point(14, 0x5f);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x1f0, 0x4e);
            this.groupBox1.TabIndex = 0x54;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "说明";
            this.richTextBox2.BackColor = SystemColors.Window;
            this.richTextBox2.BorderStyle = BorderStyle.None;
            this.richTextBox2.Dock = DockStyle.Fill;
            this.richTextBox2.Font = new Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.richTextBox2.Location = new Point(3, 0x11);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.Size = new Size(490, 0x3a);
            this.richTextBox2.TabIndex = 1;
            this.richTextBox2.Text = "    产品开发方式是每季度P2放入1M，P3放入2M，P4放入3M，直到全部的开发成本被付清，即拥有该产品的生产资格证。";
            this.labelP4.BorderStyle = BorderStyle.FixedSingle;
            this.labelP4.Location = new Point(410, 0x47);
            this.labelP4.Name = "labelP4";
            this.labelP4.Size = new Size(100, 20);
            this.labelP4.TabIndex = 0x58;
            this.labelP4.Text = "6季度";
            this.labelP4.TextAlign = ContentAlignment.MiddleCenter;
            this.labelP3.BorderStyle = BorderStyle.FixedSingle;
            this.labelP3.Location = new Point(410, 0x34);
            this.labelP3.Name = "labelP3";
            this.labelP3.Size = new Size(100, 20);
            this.labelP3.TabIndex = 0x57;
            this.labelP3.Text = "6季度";
            this.labelP3.TextAlign = ContentAlignment.MiddleCenter;
            this.labelP2.BorderStyle = BorderStyle.FixedSingle;
            this.labelP2.Location = new Point(410, 0x21);
            this.labelP2.Name = "labelP2";
            this.labelP2.Size = new Size(100, 20);
            this.labelP2.TabIndex = 0x56;
            this.labelP2.Text = "6季度";
            this.labelP2.TextAlign = ContentAlignment.MiddleCenter;
            this.label20.BorderStyle = BorderStyle.FixedSingle;
            this.label20.Location = new Point(410, 14);
            this.label20.Name = "label20";
            this.label20.Size = new Size(100, 20);
            this.label20.TabIndex = 0x55;
            this.label20.Text = "剩余投资时间";
            this.label20.TextAlign = ContentAlignment.MiddleCenter;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.CancelButton = this.buttonCancel;
            base.ClientSize = new Size(0x210, 0xcf);
            base.Controls.Add(this.labelP4);
            base.Controls.Add(this.labelP3);
            base.Controls.Add(this.labelP2);
            base.Controls.Add(this.label20);
            base.Controls.Add(this.groupBox1);
            base.Controls.Add(this.label16);
            base.Controls.Add(this.label15);
            base.Controls.Add(this.label14);
            base.Controls.Add(this.label4);
            base.Controls.Add(this.label9);
            base.Controls.Add(this.label13);
            base.Controls.Add(this.label12);
            base.Controls.Add(this.label11);
            base.Controls.Add(this.label10);
            base.Controls.Add(this.checkBoxP4);
            base.Controls.Add(this.checkBoxP3);
            base.Controls.Add(this.checkBoxP2);
            base.Controls.Add(this.label8);
            base.Controls.Add(this.label7);
            base.Controls.Add(this.label6);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.label5);
            base.Controls.Add(this.buttonCancel);
            base.Controls.Add(this.buttonOK);
            base.FormBorderStyle = FormBorderStyle.FixedDialog;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "frmCPYFTZ";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "frmCPYFTZ";
            base.Load += new EventHandler(this.frmCPYFTZ_Load);
            this.groupBox1.ResumeLayout(false);
            base.ResumeLayout(false);
            base.PerformLayout();
        }
    }
}

