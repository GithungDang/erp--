namespace ERPChess
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmRegistration : Form
    {
        private IContainer components;
        private Label label1;
        private Label label2;
        private TextBox textBoxUserID;
        private TextBox textBoxRegistrationID;
        private Button buttonOK;
        private Button buttonCancel;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox textBox1;
        private PictureBox pictureBox1;
        private Label labelre;

        public frmRegistration()
        {
            this.InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (!TGlobals.IsRegistration)
            {
                string registrationID = TGlobals.RegistrationID;
                string str2 = this.textBoxRegistrationID.Text.Trim();
                if (string.IsNullOrEmpty(str2))
                {
                    MessageBox.Show("注册码不能为空！", "特别提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                if (registrationID != str2)
                {
                    MessageBox.Show("注册码不正确，请重新输入！", "特别提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.textBoxRegistrationID.Focus();
                    return;
                }
                TGlobals.dbControl.UpdateRegistrationID(registrationID, "注册");
                MessageBox.Show("注册成功！", "特别提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                TGlobals.IsRegistration = true;
            }
            base.DialogResult = DialogResult.OK;
            base.Close();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void frmRegistration_Load(object sender, EventArgs e)
        {
            this.textBoxUserID.Text = TGlobals.UserID;
            if (!TGlobals.IsRegistration)
            {
                this.textBoxRegistrationID.ReadOnly = false;
                this.labelre.Text = "未注册版本";
            }
            else
            {
                this.textBoxRegistrationID.Text = TGlobals.RegistrationID;
                this.textBoxRegistrationID.ReadOnly = true;
                this.labelre.Text = "已注册版本";
            }
        }

        private void InitializeComponent()
        {
            this.label1 = new Label();
            this.label2 = new Label();
            this.textBoxUserID = new TextBox();
            this.textBoxRegistrationID = new TextBox();
            this.buttonOK = new Button();
            this.buttonCancel = new Button();
            this.label3 = new Label();
            this.label4 = new Label();
            this.label5 = new Label();
            this.textBox1 = new TextBox();
            this.pictureBox1 = new PictureBox();
            this.labelre = new Label();
            ((ISupportInitialize) this.pictureBox1).BeginInit();
            base.SuspendLayout();
            this.label1.AutoSize = true;
            this.label1.Location = new Point(0x1b, 0x1d);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x3b, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户ID码:";
            this.label2.AutoSize = true;
            this.label2.Location = new Point(0x1b, 0x38);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x3b, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "注册号码:";
            this.textBoxUserID.Location = new Point(0x5c, 0x1a);
            this.textBoxUserID.Name = "textBoxUserID";
            this.textBoxUserID.ReadOnly = true;
            this.textBoxUserID.Size = new Size(0xf2, 0x15);
            this.textBoxUserID.TabIndex = 2;
            this.textBoxRegistrationID.Location = new Point(0x5c, 0x35);
            this.textBoxRegistrationID.Name = "textBoxRegistrationID";
            this.textBoxRegistrationID.Size = new Size(0xf2, 0x15);
            this.textBoxRegistrationID.TabIndex = 0;
            this.buttonOK.Location = new Point(0xb0, 0xb9);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new Size(0x4b, 0x17);
            this.buttonOK.TabIndex = 4;
            this.buttonOK.Text = "确定";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new EventHandler(this.buttonOK_Click);
            this.buttonCancel.DialogResult = DialogResult.Cancel;
            this.buttonCancel.Location = new Point(0x103, 0xb9);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new Size(0x4b, 0x17);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.label3.AutoSize = true;
            this.label3.Font = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label3.Location = new Point(0x9b, 90);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x83, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "联系人员:  rht";
            this.label3.Visible = false;
            this.label4.AutoSize = true;
            this.label4.Location = new Point(0x9b, 0x70);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x89, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "联系电话:  15281027962";
            this.label4.Visible = false;
            this.label5.AutoSize = true;
            this.label5.Location = new Point(0x9b, 0x88);
            this.label5.Name = "label5";
            this.label5.Size = new Size(0x3b, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "电子邮件:";
            this.label5.Visible = false;
            this.textBox1.BorderStyle = BorderStyle.None;
            this.textBox1.Font = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.textBox1.ForeColor = SystemColors.MenuHighlight;
            this.textBox1.Location = new Point(0xdf, 0x86);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new Size(100, 14);
            this.textBox1.TabIndex = 9;
            this.textBox1.Text = "463225047@qq.com";
            this.textBox1.Visible = false;
            this.pictureBox1.Location = new Point(0x22, 90);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Size(0x66, 0x66);
            this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            this.labelre.AutoSize = true;
            this.labelre.ForeColor = Color.Red;
            this.labelre.Location = new Point(0xba, 160);
            this.labelre.Name = "labelre";
            this.labelre.Size = new Size(0x41, 12);
            this.labelre.TabIndex = 11;
            this.labelre.Text = "未注册版本";
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.CancelButton = this.buttonCancel;
            base.ClientSize = new Size(0x16c, 220);
            base.Controls.Add(this.labelre);
            base.Controls.Add(this.pictureBox1);
            base.Controls.Add(this.textBox1);
            base.Controls.Add(this.label5);
            base.Controls.Add(this.label4);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.buttonCancel);
            base.Controls.Add(this.buttonOK);
            base.Controls.Add(this.textBoxRegistrationID);
            base.Controls.Add(this.textBoxUserID);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.label1);
            base.FormBorderStyle = FormBorderStyle.FixedDialog;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "frmRegistration";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "系统注册";
            base.Load += new EventHandler(this.frmRegistration_Load);
            ((ISupportInitialize) this.pictureBox1).EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }
    }
}

