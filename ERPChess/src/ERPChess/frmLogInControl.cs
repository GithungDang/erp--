namespace ERPChess
{
    using BusinessTier;
    using DataAccessTier;
    using ERPChess.Properties;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Threading;
    using System.Windows.Forms;

    public class frmLogInControl : Form
    {
        private IContainer components;
        private TextBox textBoxActor;
        private Button btnLogIn;
        private Button btnQuit;
        private TextBox textBoxCompany;
        private ProgressBar progressBar1;

        public frmLogInControl()
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
            ComponentResourceManager manager = new ComponentResourceManager(typeof(frmLogInControl));
            this.textBoxActor = new TextBox();
            this.btnLogIn = new Button();
            this.btnQuit = new Button();
            this.textBoxCompany = new TextBox();
            this.progressBar1 = new ProgressBar();
            base.SuspendLayout();
            this.textBoxActor.Location = new Point(290, 0xe5);
            this.textBoxActor.Name = "textBoxActor";
            this.textBoxActor.Size = new Size(140, 0x15);
            this.textBoxActor.TabIndex = 1;
            this.textBoxActor.Text = "Actor";
            this.btnLogIn.Cursor = Cursors.Default;
            this.btnLogIn.DialogResult = DialogResult.OK;
            this.btnLogIn.FlatStyle = FlatStyle.System;
            this.btnLogIn.Location = new Point(0x20d, 0xe3);
            this.btnLogIn.Name = "btnLogIn";
            this.btnLogIn.Size = new Size(0x4b, 0x17);
            this.btnLogIn.TabIndex = 6;
            this.btnLogIn.Tag = "1";
            this.btnLogIn.Text = "进入";
            this.btnLogIn.UseVisualStyleBackColor = true;
            this.btnLogIn.Click += new EventHandler(this.LoginForm_Control);
            this.btnQuit.DialogResult = DialogResult.Cancel;
            this.btnQuit.FlatStyle = FlatStyle.System;
            this.btnQuit.Location = new Point(0x25e, 0xe3);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new Size(0x4b, 0x17);
            this.btnQuit.TabIndex = 7;
            this.btnQuit.Tag = "2";
            this.btnQuit.Text = "取消";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new EventHandler(this.LoginForm_Control);
            this.textBoxCompany.Location = new Point(0x52, 0xe5);
            this.textBoxCompany.Name = "textBoxCompany";
            this.textBoxCompany.Size = new Size(140, 0x15);
            this.textBoxCompany.TabIndex = 0;
            this.textBoxCompany.Text = "Company";
            this.progressBar1.Dock = DockStyle.Bottom;
            this.progressBar1.Location = new Point(0, 0x107);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new Size(0x2ce, 0x17);
            this.progressBar1.TabIndex = 8;
            this.progressBar1.Visible = false;
            base.AcceptButton = this.btnLogIn;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackgroundImage = Resources._2002_04_02_23_30_35;
            base.CancelButton = this.btnQuit;
            base.ClientSize = new Size(0x2ce, 0x11e);
            base.Controls.Add(this.progressBar1);
            base.Controls.Add(this.textBoxCompany);
            base.Controls.Add(this.btnQuit);
            base.Controls.Add(this.btnLogIn);
            base.Controls.Add(this.textBoxActor);
            this.Cursor = Cursors.Default;
            base.FormBorderStyle = FormBorderStyle.None;
            base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "frmLogInControl";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void LoginForm_Control(object sender, EventArgs e)
        {
            switch (Convert.ToInt16(((Button) sender).Tag))
            {
                case 1:
                {
                    string actorName = this.textBoxActor.Text.Trim();
                    string companyName = this.textBoxCompany.Text.Trim();
                    if ((actorName == "") || (companyName == ""))
                    {
                        MessageBox.Show("请输入公司和决策者名称", "系统消息", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return;
                    }
                    this.Cursor = Cursors.WaitCursor;
                    this.progressBar1.Visible = true;
                    this.Refresh();
                    TGlobals.currentActor = new TActor(actorName, companyName);
                    frmMainControl control = new frmMainControl();
                    TGlobals.dbControl = new TDbAccessControl(TGlobals.databaseName, TGlobals.databasePassword);
                    TGlobals.UserID = TRegistration.GetUserID();
                    TGlobals.RegistrationID = TRegistration.Encryp(TGlobals.strKey, TGlobals.UserID);
                    string registrationID = TGlobals.dbControl.GetRegistrationID("注册");
                    if (TGlobals.RegistrationID != registrationID)
                    {
                        TGlobals.IsRegistration = false;
                        control.Text = TGlobals.ApplicationText + "(演示版)";
                    }
                    else
                    {
                        TGlobals.IsRegistration = true;
                        control.Text = TGlobals.ApplicationText;
                    }
                    for (int i = 0; i < this.progressBar1.Maximum; i += 15)
                    {
                        this.progressBar1.Value += 13;
                        Thread.Sleep(150);
                    }
                    control.Show();
                    base.Hide();
                    return;
                }
                case 2:
                    Application.Exit();
                    return;
            }
        }
    }
}

