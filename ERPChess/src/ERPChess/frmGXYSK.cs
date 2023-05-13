namespace ERPChess
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmGXYSK : Form
    {
        private IContainer components;
        private Button buttonOK;
        private Button buttonCancel;
        private GroupBox groupBox1;
        private RichTextBox richTextBox2;

        public frmGXYSK()
        {
            this.InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.CurrentCash += TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.ReceivableAccountsQ1;
            TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.ReceivableAccountsQ1 = TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.ReceivableAccountsQ2;
            TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.ReceivableAccountsQ2 = TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.ReceivableAccountsQ3;
            TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.ReceivableAccountsQ3 = TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.ReceivableAccountsQ4;
            TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.ReceivableAccountsQ4 = 0;
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
            this.groupBox1 = new GroupBox();
            this.richTextBox2 = new RichTextBox();
            this.groupBox1.SuspendLayout();
            base.SuspendLayout();
            this.buttonOK.DialogResult = DialogResult.OK;
            this.buttonOK.Location = new Point(360, 0x91);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new Size(0x4b, 0x17);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "确定";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new EventHandler(this.buttonOK_Click);
            this.buttonCancel.DialogResult = DialogResult.Cancel;
            this.buttonCancel.Location = new Point(0x1bb, 0x91);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new Size(0x4b, 0x17);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new EventHandler(this.buttonCancel_Click);
            this.groupBox1.Controls.Add(this.richTextBox2);
            this.groupBox1.Location = new Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x1fa, 0x7f);
            this.groupBox1.TabIndex = 0x48;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "说明";
            this.richTextBox2.BackColor = SystemColors.Window;
            this.richTextBox2.BorderStyle = BorderStyle.None;
            this.richTextBox2.Dock = DockStyle.Fill;
            this.richTextBox2.Font = new Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.richTextBox2.Location = new Point(3, 0x11);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.Size = new Size(500, 0x6b);
            this.richTextBox2.TabIndex = 1;
            this.richTextBox2.Text = "    这项工作针对一年中的应收款。这一部分是先前已经交货的价值。当你更新应收账期时，将所有的应收款向现金区移动。当进入现金区表明应收款已经收到。\n\n    本步系统自动完成。";
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.CancelButton = this.buttonCancel;
            base.ClientSize = new Size(530, 0xb1);
            base.Controls.Add(this.groupBox1);
            base.Controls.Add(this.buttonCancel);
            base.Controls.Add(this.buttonOK);
            base.FormBorderStyle = FormBorderStyle.FixedDialog;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "frmGXYSK";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "frmGXYSK";
            this.groupBox1.ResumeLayout(false);
            base.ResumeLayout(false);
        }
    }
}

