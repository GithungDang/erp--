﻿namespace ERPChess
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmXYLDD : Form
    {
        private IContainer components;
        private Button buttonOK;
        private Button buttonCancel;
        private Label label2;
        private Label label1;
        private NumericUpDown numericUpDown1;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private NumericUpDown numericUpDown2;
        private NumericUpDown numericUpDown3;
        private NumericUpDown numericUpDown4;
        private GroupBox groupBox2;
        private RichTextBox richTextBox2;
        private Label label12;
        private Label label13;
        private Label labelr1;
        private Label labelr2;
        private Label label17;
        private Label labelr3;
        private Label label18;
        private Label labelr4;
        private Label label20;

        public frmXYLDD()
        {
            this.InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            int num = Convert.ToInt16(this.numericUpDown1.Value);
            TGlobals.currentActor.RawMaterialStock.UnderOrder(num, Convert.ToInt16(this.numericUpDown2.Value), Convert.ToInt16(this.numericUpDown3.Value), Convert.ToInt16(this.numericUpDown4.Value));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void frmXYLDD_Load(object sender, EventArgs e)
        {
            this.labelr1.Text = TGlobals.currentActor.RawMaterialStock.StatisticsOrder.R1.Amount.ToString();
            this.labelr2.Text = TGlobals.currentActor.RawMaterialStock.StatisticsOrder.R2.Amount.ToString();
            this.labelr3.Text = TGlobals.currentActor.RawMaterialStock.StatisticsOrder.R3.Amount.ToString();
            this.labelr4.Text = TGlobals.currentActor.RawMaterialStock.StatisticsOrder.R4.Amount.ToString();
        }

        private void InitializeComponent()
        {
            this.buttonOK = new Button();
            this.buttonCancel = new Button();
            this.label2 = new Label();
            this.label1 = new Label();
            this.numericUpDown1 = new NumericUpDown();
            this.label5 = new Label();
            this.label4 = new Label();
            this.label3 = new Label();
            this.label6 = new Label();
            this.label7 = new Label();
            this.label8 = new Label();
            this.label9 = new Label();
            this.label10 = new Label();
            this.label11 = new Label();
            this.numericUpDown2 = new NumericUpDown();
            this.numericUpDown3 = new NumericUpDown();
            this.numericUpDown4 = new NumericUpDown();
            this.groupBox2 = new GroupBox();
            this.richTextBox2 = new RichTextBox();
            this.label12 = new Label();
            this.label13 = new Label();
            this.labelr1 = new Label();
            this.labelr2 = new Label();
            this.label17 = new Label();
            this.labelr3 = new Label();
            this.label18 = new Label();
            this.labelr4 = new Label();
            this.label20 = new Label();
            this.numericUpDown1.BeginInit();
            this.numericUpDown2.BeginInit();
            this.numericUpDown3.BeginInit();
            this.numericUpDown4.BeginInit();
            this.groupBox2.SuspendLayout();
            base.SuspendLayout();
            this.buttonOK.DialogResult = DialogResult.OK;
            this.buttonOK.Location = new Point(530, 0x7e);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new Size(0x4b, 0x17);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "确定";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new EventHandler(this.buttonOK_Click);
            this.buttonCancel.DialogResult = DialogResult.Cancel;
            this.buttonCancel.Location = new Point(0x263, 0x7e);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new Size(0x4b, 0x17);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.label2.BorderStyle = BorderStyle.FixedSingle;
            this.label2.Location = new Point(12, 0x1d);
            this.label2.Name = "label2";
            this.label2.Size = new Size(100, 0x15);
            this.label2.TabIndex = 0x25;
            this.label2.Text = "R1";
            this.label2.TextAlign = ContentAlignment.MiddleCenter;
            this.label1.BorderStyle = BorderStyle.FixedSingle;
            this.label1.Location = new Point(0x6f, 9);
            this.label1.Name = "label1";
            this.label1.Size = new Size(100, 0x15);
            this.label1.TabIndex = 0x24;
            this.label1.Text = "价格";
            this.label1.TextAlign = ContentAlignment.MiddleCenter;
            this.numericUpDown1.Location = new Point(210, 0x1d);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.ReadOnly = true;
            this.numericUpDown1.Size = new Size(100, 0x15);
            this.numericUpDown1.TabIndex = 0x23;
            this.numericUpDown1.TextAlign = HorizontalAlignment.Center;
            this.label5.BorderStyle = BorderStyle.FixedSingle;
            this.label5.Location = new Point(12, 9);
            this.label5.Name = "label5";
            this.label5.Size = new Size(100, 0x15);
            this.label5.TabIndex = 0x22;
            this.label5.Text = "原料";
            this.label5.TextAlign = ContentAlignment.MiddleCenter;
            this.label4.BorderStyle = BorderStyle.FixedSingle;
            this.label4.Location = new Point(210, 9);
            this.label4.Name = "label4";
            this.label4.Size = new Size(100, 0x15);
            this.label4.TabIndex = 0x26;
            this.label4.Text = "订购量";
            this.label4.TextAlign = ContentAlignment.MiddleCenter;
            this.label3.BorderStyle = BorderStyle.FixedSingle;
            this.label3.Location = new Point(12, 0x31);
            this.label3.Name = "label3";
            this.label3.Size = new Size(100, 0x15);
            this.label3.TabIndex = 0x27;
            this.label3.Text = "R2";
            this.label3.TextAlign = ContentAlignment.MiddleCenter;
            this.label6.BorderStyle = BorderStyle.FixedSingle;
            this.label6.Location = new Point(12, 0x45);
            this.label6.Name = "label6";
            this.label6.Size = new Size(100, 0x15);
            this.label6.TabIndex = 40;
            this.label6.Text = "R3";
            this.label6.TextAlign = ContentAlignment.MiddleCenter;
            this.label7.BorderStyle = BorderStyle.FixedSingle;
            this.label7.Location = new Point(12, 0x59);
            this.label7.Name = "label7";
            this.label7.Size = new Size(100, 0x15);
            this.label7.TabIndex = 0x29;
            this.label7.Text = "R4";
            this.label7.TextAlign = ContentAlignment.MiddleCenter;
            this.label8.BorderStyle = BorderStyle.FixedSingle;
            this.label8.Location = new Point(0x6f, 0x1d);
            this.label8.Name = "label8";
            this.label8.Size = new Size(100, 0x15);
            this.label8.TabIndex = 0x2a;
            this.label8.Text = "1M";
            this.label8.TextAlign = ContentAlignment.MiddleCenter;
            this.label9.BorderStyle = BorderStyle.FixedSingle;
            this.label9.Location = new Point(0x6f, 0x59);
            this.label9.Name = "label9";
            this.label9.Size = new Size(100, 0x15);
            this.label9.TabIndex = 0x2b;
            this.label9.Text = "1M";
            this.label9.TextAlign = ContentAlignment.MiddleCenter;
            this.label10.BorderStyle = BorderStyle.FixedSingle;
            this.label10.Location = new Point(0x6f, 0x45);
            this.label10.Name = "label10";
            this.label10.Size = new Size(100, 0x15);
            this.label10.TabIndex = 0x2c;
            this.label10.Text = "1M";
            this.label10.TextAlign = ContentAlignment.MiddleCenter;
            this.label11.BorderStyle = BorderStyle.FixedSingle;
            this.label11.Location = new Point(0x6f, 0x31);
            this.label11.Name = "label11";
            this.label11.Size = new Size(100, 0x15);
            this.label11.TabIndex = 0x2d;
            this.label11.Text = "1M";
            this.label11.TextAlign = ContentAlignment.MiddleCenter;
            this.numericUpDown2.Location = new Point(210, 0x31);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.ReadOnly = true;
            this.numericUpDown2.Size = new Size(100, 0x15);
            this.numericUpDown2.TabIndex = 0x2e;
            this.numericUpDown2.TextAlign = HorizontalAlignment.Center;
            this.numericUpDown3.Location = new Point(210, 0x45);
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.ReadOnly = true;
            this.numericUpDown3.Size = new Size(100, 0x15);
            this.numericUpDown3.TabIndex = 0x2f;
            this.numericUpDown3.TextAlign = HorizontalAlignment.Center;
            this.numericUpDown4.Location = new Point(210, 0x59);
            this.numericUpDown4.Name = "numericUpDown4";
            this.numericUpDown4.ReadOnly = true;
            this.numericUpDown4.Size = new Size(100, 0x15);
            this.numericUpDown4.TabIndex = 0x30;
            this.numericUpDown4.TextAlign = HorizontalAlignment.Center;
            this.groupBox2.Controls.Add(this.richTextBox2);
            this.groupBox2.Location = new Point(0x145, 9);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(0x16f, 0x65);
            this.groupBox2.TabIndex = 0x31;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "说明";
            this.richTextBox2.BackColor = SystemColors.Window;
            this.richTextBox2.BorderStyle = BorderStyle.None;
            this.richTextBox2.Dock = DockStyle.Fill;
            this.richTextBox2.Font = new Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.richTextBox2.Location = new Point(3, 0x11);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.Size = new Size(0x169, 0x51);
            this.richTextBox2.TabIndex = 4;
            this.richTextBox2.Text = "  现在是订货时间，可根据所要生产的产品下原料订单。\n  P1产品需1个R1、P2产品需1个R1和1个R2、P3产品需2个R2和1个R3、P4 产品需1个R2、1个R3和2个R4\n  注意：在某产品研发结束之前，可订该产品的原料。";
            this.label12.AutoSize = true;
            this.label12.Location = new Point(12, 0x7e);
            this.label12.Name = "label12";
            this.label12.Size = new Size(0x35, 12);
            this.label12.TabIndex = 50;
            this.label12.Text = "库存情况";
            this.label13.AutoSize = true;
            this.label13.Location = new Point(0x47, 0x7e);
            this.label13.Name = "label13";
            this.label13.Size = new Size(0x2f, 12);
            this.label13.TabIndex = 0x33;
            this.label13.Text = "R1库存:";
            this.labelr1.AutoSize = true;
            this.labelr1.Location = new Point(0x71, 0x7e);
            this.labelr1.Name = "labelr1";
            this.labelr1.Size = new Size(0x11, 12);
            this.labelr1.TabIndex = 0x34;
            this.labelr1.Text = "10";
            this.labelr2.AutoSize = true;
            this.labelr2.Location = new Point(0xb2, 0x7e);
            this.labelr2.Name = "labelr2";
            this.labelr2.Size = new Size(0x11, 12);
            this.labelr2.TabIndex = 0x37;
            this.labelr2.Text = "10";
            this.label17.AutoSize = true;
            this.label17.Location = new Point(0x88, 0x7e);
            this.label17.Name = "label17";
            this.label17.Size = new Size(0x2f, 12);
            this.label17.TabIndex = 0x36;
            this.label17.Text = "R2库存:";
            this.labelr3.AutoSize = true;
            this.labelr3.Location = new Point(0xf3, 0x7e);
            this.labelr3.Name = "labelr3";
            this.labelr3.Size = new Size(0x11, 12);
            this.labelr3.TabIndex = 0x39;
            this.labelr3.Text = "10";
            this.label18.AutoSize = true;
            this.label18.Location = new Point(0xc9, 0x7e);
            this.label18.Name = "label18";
            this.label18.Size = new Size(0x2f, 12);
            this.label18.TabIndex = 0x38;
            this.label18.Text = "R3库存:";
            this.labelr4.AutoSize = true;
            this.labelr4.Location = new Point(0x134, 0x7e);
            this.labelr4.Name = "labelr4";
            this.labelr4.Size = new Size(0x11, 12);
            this.labelr4.TabIndex = 0x3b;
            this.labelr4.Text = "10";
            this.label20.AutoSize = true;
            this.label20.Location = new Point(0x10a, 0x7e);
            this.label20.Name = "label20";
            this.label20.Size = new Size(0x2f, 12);
            this.label20.TabIndex = 0x3a;
            this.label20.Text = "R4库存:";
            base.AcceptButton = this.buttonOK;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.CancelButton = this.buttonCancel;
            base.ClientSize = new Size(0x2c0, 0x9c);
            base.Controls.Add(this.labelr4);
            base.Controls.Add(this.label20);
            base.Controls.Add(this.labelr3);
            base.Controls.Add(this.label18);
            base.Controls.Add(this.labelr2);
            base.Controls.Add(this.label17);
            base.Controls.Add(this.labelr1);
            base.Controls.Add(this.label13);
            base.Controls.Add(this.label12);
            base.Controls.Add(this.groupBox2);
            base.Controls.Add(this.label11);
            base.Controls.Add(this.label10);
            base.Controls.Add(this.label9);
            base.Controls.Add(this.label8);
            base.Controls.Add(this.label7);
            base.Controls.Add(this.label6);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.label4);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.numericUpDown1);
            base.Controls.Add(this.label5);
            base.Controls.Add(this.buttonCancel);
            base.Controls.Add(this.buttonOK);
            base.Controls.Add(this.numericUpDown2);
            base.Controls.Add(this.numericUpDown3);
            base.Controls.Add(this.numericUpDown4);
            base.FormBorderStyle = FormBorderStyle.FixedDialog;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "frmXYLDD";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "frmXYLDD";
            base.Load += new EventHandler(this.frmXYLDD_Load);
            this.numericUpDown1.EndInit();
            this.numericUpDown2.EndInit();
            this.numericUpDown3.EndInit();
            this.numericUpDown4.EndInit();
            this.groupBox2.ResumeLayout(false);
            base.ResumeLayout(false);
            base.PerformLayout();
        }
    }
}
