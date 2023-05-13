﻿namespace ERPChess
{
    using BusinessTier;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmZFZJ : Form
    {
        private IContainer components;
        private Button buttonOK;
        private Button buttonCancel;
        private GroupBox groupBox2;
        private RichTextBox richTextBox2;

        public frmZFZJ()
        {
            this.InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            int num = 0;
            if (TGlobals.currentActor.PlantA.PlantAttribute == PlantAttribute.租赁)
            {
                num += TGlobals.currentActor.PlantA.LeasingPrice;
            }
            if (TGlobals.currentActor.PlantB.PlantAttribute == PlantAttribute.租赁)
            {
                num += TGlobals.currentActor.PlantB.LeasingPrice;
            }
            if (TGlobals.currentActor.PlantC.PlantAttribute == PlantAttribute.租赁)
            {
                num += TGlobals.currentActor.PlantC.LeasingPrice;
            }
            TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.CurrentCash -= num;
            TGlobals.currentActor.CurrBusinessConditions.ComprehensiveCostSheet.RentPlant += num;
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
            this.buttonOK.Location = new Point(0x14e, 0xc7);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new Size(0x4b, 0x17);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "确定";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new EventHandler(this.buttonOK_Click);
            this.buttonCancel.DialogResult = DialogResult.Cancel;
            this.buttonCancel.Location = new Point(0x19f, 0xc7);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new Size(0x4b, 0x17);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.groupBox2.Controls.Add(this.richTextBox2);
            this.groupBox2.Location = new Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(0x1de, 0xb5);
            this.groupBox2.TabIndex = 0x4d;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "说明";
            this.richTextBox2.BackColor = SystemColors.Window;
            this.richTextBox2.BorderStyle = BorderStyle.None;
            this.richTextBox2.Dock = DockStyle.Fill;
            this.richTextBox2.Font = new Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.richTextBox2.Location = new Point(3, 0x11);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.Size = new Size(0x1d8, 0xa1);
            this.richTextBox2.TabIndex = 1;
            this.richTextBox2.Text = "    执行此项目的时候，如果没有厂房的所有权，则按下列条件支付租金。\n\n    建筑\t租\n    建筑A\t4M/年\n    建筑B\t3M/年\n    建筑C\t2M/年\n\n    本步系统自动完成。";
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.CancelButton = this.buttonCancel;
            base.ClientSize = new Size(0x1f6, 0xe5);
            base.Controls.Add(this.groupBox2);
            base.Controls.Add(this.buttonCancel);
            base.Controls.Add(this.buttonOK);
            base.FormBorderStyle = FormBorderStyle.FixedDialog;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "frmZFZJ";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "frmZFZJ";
            this.groupBox2.ResumeLayout(false);
            base.ResumeLayout(false);
        }
    }
}

