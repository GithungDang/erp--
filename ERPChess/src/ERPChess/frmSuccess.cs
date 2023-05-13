namespace ERPChess
{
    using ERPChess.Properties;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmSuccess : Form
    {
        private IContainer components;
        private PictureBox pictureBox1;
        private Button buttonOK;
        private Label label1;
        private Label label2;

        public frmSuccess()
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
            this.pictureBox1 = new PictureBox();
            this.buttonOK = new Button();
            this.label1 = new Label();
            this.label2 = new Label();
            ((ISupportInitialize) this.pictureBox1).BeginInit();
            base.SuspendLayout();
            this.pictureBox1.Image = Resources.png_0441;
            this.pictureBox1.Location = new Point(12, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Size(0x80, 0x80);
            this.pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.buttonOK.DialogResult = DialogResult.OK;
            this.buttonOK.Location = new Point(0x1bd, 0x74);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new Size(0x4b, 0x17);
            this.buttonOK.TabIndex = 1;
            this.buttonOK.Text = "确定";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.label1.AutoSize = true;
            this.label1.Font = new Font("宋体", 18f, FontStyle.Bold, GraphicsUnit.Point, 0x86);
            this.label1.Location = new Point(0x92, 0x1c);
            this.label1.Name = "label1";
            this.label1.Size = new Size(410, 0x18);
            this.label1.TabIndex = 2;
            this.label1.Text = "太棒了！祝贺你顺利完成六年经营！";
            this.label2.AutoSize = true;
            this.label2.Font = new Font("宋体", 18f, FontStyle.Bold, GraphicsUnit.Point, 0x86);
            this.label2.Location = new Point(250, 0x4c);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0xb9, 0x18);
            this.label2.TabIndex = 3;
            this.label2.Text = "去查排行榜吧！";
            base.AcceptButton = this.buttonOK;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x228, 0x97);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.buttonOK);
            base.Controls.Add(this.pictureBox1);
            base.FormBorderStyle = FormBorderStyle.FixedDialog;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "frmSuccess";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "特别提示";
            ((ISupportInitialize) this.pictureBox1).EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }
    }
}

