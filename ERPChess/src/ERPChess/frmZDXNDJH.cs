namespace ERPChess
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmZDXNDJH : Form
    {
        private IContainer components;
        private Button buttonOK;
        private Button buttonCancel;
        private GroupBox groupBox3;
        private RichTextBox richTextBox2;

        public frmZDXNDJH()
        {
            this.InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
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

        private void InitializeComponent()
        {
            ComponentResourceManager manager = new ComponentResourceManager(typeof(frmZDXNDJH));
            this.buttonOK = new Button();
            this.buttonCancel = new Button();
            this.groupBox3 = new GroupBox();
            this.richTextBox2 = new RichTextBox();
            this.groupBox3.SuspendLayout();
            base.SuspendLayout();
            this.buttonOK.DialogResult = DialogResult.OK;
            this.buttonOK.Location = new Point(0x152, 0x1b6);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new Size(0x4b, 0x17);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "确定";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonCancel.DialogResult = DialogResult.Cancel;
            this.buttonCancel.Location = new Point(0x1a3, 0x1b6);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new Size(0x4b, 0x17);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new EventHandler(this.buttonCancel_Click);
            this.groupBox3.Controls.Add(this.richTextBox2);
            this.groupBox3.Location = new Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new Size(0x1e2, 420);
            this.groupBox3.TabIndex = 60;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "请您思考";
            this.richTextBox2.BackColor = SystemColors.Window;
            this.richTextBox2.BorderStyle = BorderStyle.None;
            this.richTextBox2.Dock = DockStyle.Fill;
            this.richTextBox2.Font = new Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.richTextBox2.Location = new Point(3, 0x11);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.Size = new Size(0x1dc, 400);
            this.richTextBox2.TabIndex = 2;
            this.richTextBox2.Text = manager.GetString("richTextBox2.Text");
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.CancelButton = this.buttonCancel;
            base.ClientSize = new Size(0x1fa, 0x1d9);
            base.Controls.Add(this.groupBox3);
            base.Controls.Add(this.buttonCancel);
            base.Controls.Add(this.buttonOK);
            base.FormBorderStyle = FormBorderStyle.FixedDialog;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "frmZDXNDJH";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "frmZDXNDJH";
            this.groupBox3.ResumeLayout(false);
            base.ResumeLayout(false);
        }
    }
}

