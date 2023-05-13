namespace ERPChess
{
    using ERPChess.Properties;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmOver : Form
    {
        private IContainer components;
        private Button buttonOK;
        private PictureBox pictureBox1;
        public Label label2;
        public Label label1;

        public frmOver()
        {
            this.InitializeComponent();
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
            this.label2 = new Label();
            this.label1 = new Label();
            this.buttonOK = new Button();
            this.pictureBox1 = new PictureBox();
            ((ISupportInitialize) this.pictureBox1).BeginInit();
            base.SuspendLayout();
            this.label2.AutoSize = true;
            this.label2.Font = new Font("宋体", 18f, FontStyle.Bold, GraphicsUnit.Point, 0x86);
            this.label2.Location = new Point(180, 0x4b);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x11d, 0x18);
            this.label2.TabIndex = 7;
            this.label2.Text = "没关系的，请继续努力！";
            this.label1.AutoSize = true;
            this.label1.Font = new Font("宋体", 18f, FontStyle.Bold, GraphicsUnit.Point, 0x86);
            this.label1.Location = new Point(0x8f, 0x1b);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x181, 0x18);
            this.label1.TabIndex = 6;
            this.label1.Text = "非常遗憾！现金为负判断为失败！";
            this.buttonOK.DialogResult = DialogResult.OK;
            this.buttonOK.Location = new Point(0x1ba, 0x73);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new Size(0x4b, 0x17);
            this.buttonOK.TabIndex = 5;
            this.buttonOK.Text = "确定";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.pictureBox1.Image = Resources.png_0422;
            this.pictureBox1.Location = new Point(9, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Size(0x80, 0x80);
            this.pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            base.AcceptButton = this.buttonOK;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x20e, 0x95);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.buttonOK);
            base.Controls.Add(this.pictureBox1);
            base.FormBorderStyle = FormBorderStyle.FixedDialog;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "frmOver";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "特别提示";
            ((ISupportInitialize) this.pictureBox1).EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }
    }
}

