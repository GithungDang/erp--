namespace ERPChess
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmXSCZR : Form
    {
        private IContainer components;
        private Button buttonOK;
        private Button buttonCancel;
        private GroupBox groupBox1;
        private Label labelSCYZ;
        private Label labelSCGN;
        private Label labelSCQY;
        private Label label4;
        private Label label9;
        private Label label13;
        private Label label12;
        private Label label11;
        private Label label10;
        private CheckBox checkBoxSCYZ;
        private CheckBox checkBoxSCGN;
        private CheckBox checkBoxSCQY;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label5;
        private Label labelSCGJ;
        private Label label18;
        private Label label19;
        private CheckBox checkBoxSCGJ;
        private Label label20;
        private GroupBox groupBox2;
        private Label labelISO14;
        private Label labelISO9;
        private Label label23;
        private Label label24;
        private Label label25;
        private Label label26;
        private CheckBox checkBoxISO14;
        private CheckBox checkBoxISO9;
        private Label label27;
        private Label label28;
        private Label label29;
        private Label label30;
        private Label label31;
        private Label label32;
        private GroupBox groupBox3;
        private RichTextBox richTextBox2;
        private Label label33;
        private Label label35;
        private Label label34;
        private Label label36;
        private Label label37;
        private Label label38;
        private Label label39;
        private Label label40;

        public frmXSCZR()
        {
            this.InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            int num = 0;
            int num2 = 0;
            if (this.checkBoxSCQY.Checked)
            {
                num++;
                TGlobals.currentActor.JRQYCost++;
            }
            if (this.checkBoxSCGN.Checked)
            {
                num++;
                TGlobals.currentActor.JRGNCost++;
            }
            if (this.checkBoxSCYZ.Checked)
            {
                num++;
                TGlobals.currentActor.JRYZCost++;
            }
            if (this.checkBoxSCGJ.Checked)
            {
                num++;
                TGlobals.currentActor.JRGJCost++;
            }
            if (this.checkBoxISO9.Checked)
            {
                num2++;
                TGlobals.currentActor.TZISO9000Cost++;
            }
            if (this.checkBoxISO14.Checked)
            {
                num2++;
                TGlobals.currentActor.TZISO14000Cost++;
            }
            int num3 = num + num2;
            TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.CurrentCash -= num3;
            TGlobals.currentActor.CurrBusinessConditions.ComprehensiveCostSheet.MarketDevelopment += num;
            TGlobals.currentActor.CurrBusinessConditions.ComprehensiveCostSheet.IsoCertification += num2;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void frmXSCZR_Load(object sender, EventArgs e)
        {
            if (TGlobals.currentActor.IsEnterRegionalMarket)
            {
                this.checkBoxSCQY.Enabled = false;
                this.labelSCQY.Text = "开发完毕";
            }
            else
            {
                this.checkBoxSCQY.Enabled = true;
                this.labelSCQY.Text = TGlobals.currentActor.GetJRQYSYQS().ToString() + "年";
            }
            if (TGlobals.currentActor.IsEnterDomesticMarket)
            {
                this.checkBoxSCGN.Enabled = false;
                this.labelSCGN.Text = "开发完毕";
            }
            else
            {
                this.checkBoxSCGN.Enabled = true;
                this.labelSCGN.Text = TGlobals.currentActor.GetJRGNSYQS().ToString() + "年";
            }
            if (TGlobals.currentActor.IsEnterAsiaMarket)
            {
                this.checkBoxSCYZ.Enabled = false;
                this.labelSCYZ.Text = "开发完毕";
            }
            else
            {
                this.checkBoxSCYZ.Enabled = true;
                this.labelSCYZ.Text = TGlobals.currentActor.GetJRYZSYQS().ToString() + "年";
            }
            if (TGlobals.currentActor.IsEnterInternationalMarket)
            {
                this.checkBoxSCGJ.Enabled = false;
                this.labelSCGJ.Text = "开发完毕";
            }
            else
            {
                this.checkBoxSCGJ.Enabled = true;
                this.labelSCGJ.Text = TGlobals.currentActor.GetJRGJSYQS().ToString() + "年";
            }
            if (TGlobals.currentActor.IsCertified9000)
            {
                this.checkBoxISO9.Enabled = false;
                this.labelISO9.Text = "开发完毕";
            }
            else
            {
                this.checkBoxISO9.Enabled = true;
                this.labelISO9.Text = TGlobals.currentActor.GetISO9000SYQS().ToString() + "年";
            }
            if (TGlobals.currentActor.IsCertified14000)
            {
                this.checkBoxISO14.Enabled = false;
                this.labelISO14.Text = "开发完毕";
            }
            else
            {
                this.checkBoxISO14.Enabled = true;
                this.labelISO14.Text = TGlobals.currentActor.GetISO14000SYQS().ToString() + "年";
            }
        }

        private void InitializeComponent()
        {
            ComponentResourceManager manager = new ComponentResourceManager(typeof(frmXSCZR));
            this.buttonOK = new Button();
            this.buttonCancel = new Button();
            this.groupBox1 = new GroupBox();
            this.label36 = new Label();
            this.label37 = new Label();
            this.label38 = new Label();
            this.label39 = new Label();
            this.label40 = new Label();
            this.labelSCGJ = new Label();
            this.label18 = new Label();
            this.label19 = new Label();
            this.checkBoxSCGJ = new CheckBox();
            this.label20 = new Label();
            this.labelSCYZ = new Label();
            this.labelSCGN = new Label();
            this.labelSCQY = new Label();
            this.label4 = new Label();
            this.label9 = new Label();
            this.label13 = new Label();
            this.label12 = new Label();
            this.label11 = new Label();
            this.label10 = new Label();
            this.checkBoxSCYZ = new CheckBox();
            this.checkBoxSCGN = new CheckBox();
            this.checkBoxSCQY = new CheckBox();
            this.label8 = new Label();
            this.label7 = new Label();
            this.label6 = new Label();
            this.label3 = new Label();
            this.label2 = new Label();
            this.label1 = new Label();
            this.label5 = new Label();
            this.groupBox2 = new GroupBox();
            this.label35 = new Label();
            this.label34 = new Label();
            this.label33 = new Label();
            this.labelISO14 = new Label();
            this.label25 = new Label();
            this.labelISO9 = new Label();
            this.label23 = new Label();
            this.label26 = new Label();
            this.checkBoxISO14 = new CheckBox();
            this.label29 = new Label();
            this.checkBoxISO9 = new CheckBox();
            this.label24 = new Label();
            this.label27 = new Label();
            this.label28 = new Label();
            this.label30 = new Label();
            this.label31 = new Label();
            this.label32 = new Label();
            this.groupBox3 = new GroupBox();
            this.richTextBox2 = new RichTextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            base.SuspendLayout();
            this.buttonOK.DialogResult = DialogResult.OK;
            this.buttonOK.Location = new Point(0x256, 0x103);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new Size(0x4b, 0x17);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "确定";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new EventHandler(this.buttonOK_Click);
            this.buttonCancel.DialogResult = DialogResult.Cancel;
            this.buttonCancel.Location = new Point(0x2a7, 0x103);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new Size(0x4b, 0x17);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.groupBox1.Controls.Add(this.label36);
            this.groupBox1.Controls.Add(this.label37);
            this.groupBox1.Controls.Add(this.label38);
            this.groupBox1.Controls.Add(this.label39);
            this.groupBox1.Controls.Add(this.label40);
            this.groupBox1.Controls.Add(this.labelSCGJ);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.checkBoxSCGJ);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.labelSCYZ);
            this.groupBox1.Controls.Add(this.labelSCGN);
            this.groupBox1.Controls.Add(this.labelSCQY);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.checkBoxSCYZ);
            this.groupBox1.Controls.Add(this.checkBoxSCGN);
            this.groupBox1.Controls.Add(this.checkBoxSCQY);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x1bb, 0x81);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "市场开拓投资";
            this.label36.BorderStyle = BorderStyle.FixedSingle;
            this.label36.Location = new Point(0xb2, 0x61);
            this.label36.Name = "label36";
            this.label36.Size = new Size(0x54, 20);
            this.label36.TabIndex = 0x70;
            this.label36.Text = "4M";
            this.label36.TextAlign = ContentAlignment.MiddleCenter;
            this.label37.BorderStyle = BorderStyle.FixedSingle;
            this.label37.Location = new Point(0xb2, 0x4e);
            this.label37.Name = "label37";
            this.label37.Size = new Size(0x54, 20);
            this.label37.TabIndex = 0x6f;
            this.label37.Text = "3M";
            this.label37.TextAlign = ContentAlignment.MiddleCenter;
            this.label38.BorderStyle = BorderStyle.FixedSingle;
            this.label38.Location = new Point(0xb2, 0x3b);
            this.label38.Name = "label38";
            this.label38.Size = new Size(0x54, 20);
            this.label38.TabIndex = 110;
            this.label38.Text = "2M";
            this.label38.TextAlign = ContentAlignment.MiddleCenter;
            this.label39.BorderStyle = BorderStyle.FixedSingle;
            this.label39.Location = new Point(0xb2, 40);
            this.label39.Name = "label39";
            this.label39.Size = new Size(0x54, 20);
            this.label39.TabIndex = 0x6d;
            this.label39.Text = "1M";
            this.label39.TextAlign = ContentAlignment.MiddleCenter;
            this.label40.BorderStyle = BorderStyle.FixedSingle;
            this.label40.Location = new Point(0xb2, 0x15);
            this.label40.Name = "label40";
            this.label40.Size = new Size(0x54, 20);
            this.label40.TabIndex = 0x6c;
            this.label40.Text = "投资总金额";
            this.label40.TextAlign = ContentAlignment.MiddleCenter;
            this.labelSCGJ.BorderStyle = BorderStyle.FixedSingle;
            this.labelSCGJ.Location = new Point(0x158, 0x61);
            this.labelSCGJ.Name = "labelSCGJ";
            this.labelSCGJ.Size = new Size(0x54, 20);
            this.labelSCGJ.TabIndex = 0x6b;
            this.labelSCGJ.Text = "-1";
            this.labelSCGJ.TextAlign = ContentAlignment.MiddleCenter;
            this.label18.BorderStyle = BorderStyle.FixedSingle;
            this.label18.Location = new Point(0x105, 0x61);
            this.label18.Name = "label18";
            this.label18.Size = new Size(0x54, 20);
            this.label18.TabIndex = 0x6a;
            this.label18.Text = "4年";
            this.label18.TextAlign = ContentAlignment.MiddleCenter;
            this.label19.BorderStyle = BorderStyle.FixedSingle;
            this.label19.Location = new Point(0x5f, 0x61);
            this.label19.Name = "label19";
            this.label19.Size = new Size(0x54, 20);
            this.label19.TabIndex = 0x69;
            this.label19.Text = "国际市场";
            this.label19.TextAlign = ContentAlignment.MiddleCenter;
            this.checkBoxSCGJ.AutoSize = true;
            this.checkBoxSCGJ.Location = new Point(0x2e, 0x65);
            this.checkBoxSCGJ.Name = "checkBoxSCGJ";
            this.checkBoxSCGJ.Size = new Size(15, 14);
            this.checkBoxSCGJ.TabIndex = 0x68;
            this.checkBoxSCGJ.UseVisualStyleBackColor = true;
            this.label20.BorderStyle = BorderStyle.FixedSingle;
            this.label20.Location = new Point(12, 0x61);
            this.label20.Name = "label20";
            this.label20.Size = new Size(0x54, 20);
            this.label20.TabIndex = 0x67;
            this.label20.TextAlign = ContentAlignment.MiddleCenter;
            this.labelSCYZ.BorderStyle = BorderStyle.FixedSingle;
            this.labelSCYZ.Location = new Point(0x158, 0x4e);
            this.labelSCYZ.Name = "labelSCYZ";
            this.labelSCYZ.Size = new Size(0x54, 20);
            this.labelSCYZ.TabIndex = 0x66;
            this.labelSCYZ.Text = "-1";
            this.labelSCYZ.TextAlign = ContentAlignment.MiddleCenter;
            this.labelSCGN.BorderStyle = BorderStyle.FixedSingle;
            this.labelSCGN.Location = new Point(0x158, 0x3b);
            this.labelSCGN.Name = "labelSCGN";
            this.labelSCGN.Size = new Size(0x54, 20);
            this.labelSCGN.TabIndex = 0x65;
            this.labelSCGN.Text = "-1";
            this.labelSCGN.TextAlign = ContentAlignment.MiddleCenter;
            this.labelSCQY.BorderStyle = BorderStyle.FixedSingle;
            this.labelSCQY.Location = new Point(0x158, 40);
            this.labelSCQY.Name = "labelSCQY";
            this.labelSCQY.Size = new Size(0x54, 20);
            this.labelSCQY.TabIndex = 100;
            this.labelSCQY.Text = "-1";
            this.labelSCQY.TextAlign = ContentAlignment.MiddleCenter;
            this.label4.BorderStyle = BorderStyle.FixedSingle;
            this.label4.Location = new Point(0x105, 0x4e);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x54, 20);
            this.label4.TabIndex = 0x63;
            this.label4.Text = "3年";
            this.label4.TextAlign = ContentAlignment.MiddleCenter;
            this.label9.BorderStyle = BorderStyle.FixedSingle;
            this.label9.Location = new Point(0x105, 0x3b);
            this.label9.Name = "label9";
            this.label9.Size = new Size(0x54, 20);
            this.label9.TabIndex = 0x62;
            this.label9.Text = "2年";
            this.label9.TextAlign = ContentAlignment.MiddleCenter;
            this.label13.BorderStyle = BorderStyle.FixedSingle;
            this.label13.Location = new Point(0x105, 40);
            this.label13.Name = "label13";
            this.label13.Size = new Size(0x54, 20);
            this.label13.TabIndex = 0x61;
            this.label13.Text = "1年";
            this.label13.TextAlign = ContentAlignment.MiddleCenter;
            this.label12.BorderStyle = BorderStyle.FixedSingle;
            this.label12.Location = new Point(0x5f, 0x4e);
            this.label12.Name = "label12";
            this.label12.Size = new Size(0x54, 20);
            this.label12.TabIndex = 0x60;
            this.label12.Text = "亚洲市场";
            this.label12.TextAlign = ContentAlignment.MiddleCenter;
            this.label11.BorderStyle = BorderStyle.FixedSingle;
            this.label11.Location = new Point(0x5f, 0x3b);
            this.label11.Name = "label11";
            this.label11.Size = new Size(0x54, 20);
            this.label11.TabIndex = 0x5f;
            this.label11.Text = "国内市场";
            this.label11.TextAlign = ContentAlignment.MiddleCenter;
            this.label10.BorderStyle = BorderStyle.FixedSingle;
            this.label10.Location = new Point(0x5f, 40);
            this.label10.Name = "label10";
            this.label10.Size = new Size(0x54, 20);
            this.label10.TabIndex = 0x5e;
            this.label10.Text = "区域市场";
            this.label10.TextAlign = ContentAlignment.MiddleCenter;
            this.checkBoxSCYZ.AutoSize = true;
            this.checkBoxSCYZ.Location = new Point(0x2e, 0x52);
            this.checkBoxSCYZ.Name = "checkBoxSCYZ";
            this.checkBoxSCYZ.Size = new Size(15, 14);
            this.checkBoxSCYZ.TabIndex = 0x5d;
            this.checkBoxSCYZ.UseVisualStyleBackColor = true;
            this.checkBoxSCGN.AutoSize = true;
            this.checkBoxSCGN.Location = new Point(0x2e, 0x3f);
            this.checkBoxSCGN.Name = "checkBoxSCGN";
            this.checkBoxSCGN.Size = new Size(15, 14);
            this.checkBoxSCGN.TabIndex = 0x5c;
            this.checkBoxSCGN.UseVisualStyleBackColor = true;
            this.checkBoxSCQY.AutoSize = true;
            this.checkBoxSCQY.Location = new Point(0x2e, 0x2b);
            this.checkBoxSCQY.Name = "checkBoxSCQY";
            this.checkBoxSCQY.Size = new Size(15, 14);
            this.checkBoxSCQY.TabIndex = 0x5b;
            this.checkBoxSCQY.UseVisualStyleBackColor = true;
            this.label8.BorderStyle = BorderStyle.FixedSingle;
            this.label8.Location = new Point(12, 40);
            this.label8.Name = "label8";
            this.label8.Size = new Size(0x54, 20);
            this.label8.TabIndex = 90;
            this.label8.TextAlign = ContentAlignment.MiddleCenter;
            this.label7.BorderStyle = BorderStyle.FixedSingle;
            this.label7.Location = new Point(12, 0x3b);
            this.label7.Name = "label7";
            this.label7.Size = new Size(0x54, 20);
            this.label7.TabIndex = 0x59;
            this.label7.TextAlign = ContentAlignment.MiddleCenter;
            this.label6.BorderStyle = BorderStyle.FixedSingle;
            this.label6.Location = new Point(12, 0x4e);
            this.label6.Name = "label6";
            this.label6.Size = new Size(0x54, 20);
            this.label6.TabIndex = 0x58;
            this.label6.TextAlign = ContentAlignment.MiddleCenter;
            this.label3.BorderStyle = BorderStyle.FixedSingle;
            this.label3.Location = new Point(0x158, 0x15);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x54, 20);
            this.label3.TabIndex = 0x57;
            this.label3.Text = "剩余投资时间";
            this.label3.TextAlign = ContentAlignment.MiddleCenter;
            this.label2.BorderStyle = BorderStyle.FixedSingle;
            this.label2.Location = new Point(0x105, 0x15);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x54, 20);
            this.label2.TabIndex = 0x56;
            this.label2.Text = "投资总时间";
            this.label2.TextAlign = ContentAlignment.MiddleCenter;
            this.label1.BorderStyle = BorderStyle.FixedSingle;
            this.label1.Location = new Point(0x5f, 0x15);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x54, 20);
            this.label1.TabIndex = 0x55;
            this.label1.Text = "市场名称";
            this.label1.TextAlign = ContentAlignment.MiddleCenter;
            this.label5.BorderStyle = BorderStyle.FixedSingle;
            this.label5.Location = new Point(12, 0x15);
            this.label5.Name = "label5";
            this.label5.Size = new Size(0x54, 20);
            this.label5.TabIndex = 0x54;
            this.label5.Text = "操作项目";
            this.label5.TextAlign = ContentAlignment.MiddleCenter;
            this.groupBox2.Controls.Add(this.label35);
            this.groupBox2.Controls.Add(this.label34);
            this.groupBox2.Controls.Add(this.label33);
            this.groupBox2.Controls.Add(this.labelISO14);
            this.groupBox2.Controls.Add(this.label25);
            this.groupBox2.Controls.Add(this.labelISO9);
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Controls.Add(this.label26);
            this.groupBox2.Controls.Add(this.checkBoxISO14);
            this.groupBox2.Controls.Add(this.label29);
            this.groupBox2.Controls.Add(this.checkBoxISO9);
            this.groupBox2.Controls.Add(this.label24);
            this.groupBox2.Controls.Add(this.label27);
            this.groupBox2.Controls.Add(this.label28);
            this.groupBox2.Controls.Add(this.label30);
            this.groupBox2.Controls.Add(this.label31);
            this.groupBox2.Controls.Add(this.label32);
            this.groupBox2.Location = new Point(12, 0x93);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(0x1bb, 0x6a);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ISO认证投资";
            this.label35.BorderStyle = BorderStyle.FixedSingle;
            this.label35.Location = new Point(0xb2, 0x40);
            this.label35.Name = "label35";
            this.label35.Size = new Size(0x54, 20);
            this.label35.TabIndex = 0x76;
            this.label35.Text = "4M";
            this.label35.TextAlign = ContentAlignment.MiddleCenter;
            this.label34.BorderStyle = BorderStyle.FixedSingle;
            this.label34.Location = new Point(0xb2, 0x2d);
            this.label34.Name = "label34";
            this.label34.Size = new Size(0x54, 20);
            this.label34.TabIndex = 0x75;
            this.label34.Text = "2M";
            this.label34.TextAlign = ContentAlignment.MiddleCenter;
            this.label33.BorderStyle = BorderStyle.FixedSingle;
            this.label33.Location = new Point(0xb2, 0x1a);
            this.label33.Name = "label33";
            this.label33.Size = new Size(0x54, 20);
            this.label33.TabIndex = 0x74;
            this.label33.Text = "投资总金额";
            this.label33.TextAlign = ContentAlignment.MiddleCenter;
            this.labelISO14.BorderStyle = BorderStyle.FixedSingle;
            this.labelISO14.Location = new Point(0x158, 0x40);
            this.labelISO14.Name = "labelISO14";
            this.labelISO14.Size = new Size(0x54, 20);
            this.labelISO14.TabIndex = 0x73;
            this.labelISO14.Text = "4年";
            this.labelISO14.TextAlign = ContentAlignment.MiddleCenter;
            this.label25.BorderStyle = BorderStyle.FixedSingle;
            this.label25.Location = new Point(0x5f, 0x40);
            this.label25.Name = "label25";
            this.label25.Size = new Size(0x54, 20);
            this.label25.TabIndex = 0x6f;
            this.label25.Text = "ISO14000";
            this.label25.TextAlign = ContentAlignment.MiddleCenter;
            this.labelISO9.BorderStyle = BorderStyle.FixedSingle;
            this.labelISO9.Location = new Point(0x158, 0x2d);
            this.labelISO9.Name = "labelISO9";
            this.labelISO9.Size = new Size(0x54, 20);
            this.labelISO9.TabIndex = 0x72;
            this.labelISO9.Text = "2年";
            this.labelISO9.TextAlign = ContentAlignment.MiddleCenter;
            this.label23.BorderStyle = BorderStyle.FixedSingle;
            this.label23.Location = new Point(0x105, 0x40);
            this.label23.Name = "label23";
            this.label23.Size = new Size(0x54, 20);
            this.label23.TabIndex = 0x71;
            this.label23.Text = "4年";
            this.label23.TextAlign = ContentAlignment.MiddleCenter;
            this.label26.BorderStyle = BorderStyle.FixedSingle;
            this.label26.Location = new Point(0x5f, 0x2d);
            this.label26.Name = "label26";
            this.label26.Size = new Size(0x54, 20);
            this.label26.TabIndex = 110;
            this.label26.Text = "ISO9000";
            this.label26.TextAlign = ContentAlignment.MiddleCenter;
            this.checkBoxISO14.AutoSize = true;
            this.checkBoxISO14.Location = new Point(0x2e, 0x43);
            this.checkBoxISO14.Name = "checkBoxISO14";
            this.checkBoxISO14.Size = new Size(15, 14);
            this.checkBoxISO14.TabIndex = 0x6d;
            this.checkBoxISO14.UseVisualStyleBackColor = true;
            this.label29.BorderStyle = BorderStyle.FixedSingle;
            this.label29.Location = new Point(0x158, 0x1a);
            this.label29.Name = "label29";
            this.label29.Size = new Size(0x54, 20);
            this.label29.TabIndex = 0x69;
            this.label29.Text = "剩余投资时间";
            this.label29.TextAlign = ContentAlignment.MiddleCenter;
            this.checkBoxISO9.AutoSize = true;
            this.checkBoxISO9.Location = new Point(0x2e, 0x30);
            this.checkBoxISO9.Name = "checkBoxISO9";
            this.checkBoxISO9.Size = new Size(15, 14);
            this.checkBoxISO9.TabIndex = 0x6c;
            this.checkBoxISO9.UseVisualStyleBackColor = true;
            this.label24.BorderStyle = BorderStyle.FixedSingle;
            this.label24.Location = new Point(0x105, 0x2d);
            this.label24.Name = "label24";
            this.label24.Size = new Size(0x54, 20);
            this.label24.TabIndex = 0x70;
            this.label24.Text = "2年";
            this.label24.TextAlign = ContentAlignment.MiddleCenter;
            this.label27.BorderStyle = BorderStyle.FixedSingle;
            this.label27.Location = new Point(12, 0x2d);
            this.label27.Name = "label27";
            this.label27.Size = new Size(0x54, 20);
            this.label27.TabIndex = 0x6b;
            this.label27.TextAlign = ContentAlignment.MiddleCenter;
            this.label28.BorderStyle = BorderStyle.FixedSingle;
            this.label28.Location = new Point(12, 0x40);
            this.label28.Name = "label28";
            this.label28.Size = new Size(0x54, 20);
            this.label28.TabIndex = 0x6a;
            this.label28.TextAlign = ContentAlignment.MiddleCenter;
            this.label30.BorderStyle = BorderStyle.FixedSingle;
            this.label30.Location = new Point(0x105, 0x1a);
            this.label30.Name = "label30";
            this.label30.Size = new Size(0x54, 20);
            this.label30.TabIndex = 0x68;
            this.label30.Text = "投资总时间";
            this.label30.TextAlign = ContentAlignment.MiddleCenter;
            this.label31.BorderStyle = BorderStyle.FixedSingle;
            this.label31.Location = new Point(0x5f, 0x1a);
            this.label31.Name = "label31";
            this.label31.Size = new Size(0x54, 20);
            this.label31.TabIndex = 0x67;
            this.label31.Text = "ISO名称";
            this.label31.TextAlign = ContentAlignment.MiddleCenter;
            this.label32.BorderStyle = BorderStyle.FixedSingle;
            this.label32.Location = new Point(12, 0x1a);
            this.label32.Name = "label32";
            this.label32.Size = new Size(0x54, 20);
            this.label32.TabIndex = 0x66;
            this.label32.Text = "操作项目";
            this.label32.TextAlign = ContentAlignment.MiddleCenter;
            this.groupBox3.Controls.Add(this.richTextBox2);
            this.groupBox3.Location = new Point(0x1cd, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new Size(0x125, 0xf1);
            this.groupBox3.TabIndex = 0x49;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "说明";
            this.richTextBox2.BackColor = SystemColors.Window;
            this.richTextBox2.BorderStyle = BorderStyle.None;
            this.richTextBox2.Dock = DockStyle.Fill;
            this.richTextBox2.Font = new Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.richTextBox2.Location = new Point(3, 0x11);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.Size = new Size(0x11f, 0xdd);
            this.richTextBox2.TabIndex = 1;
            this.richTextBox2.Text = manager.GetString("richTextBox2.Text");
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.CancelButton = this.buttonCancel;
            base.ClientSize = new Size(0x2fc, 290);
            base.Controls.Add(this.groupBox3);
            base.Controls.Add(this.groupBox2);
            base.Controls.Add(this.groupBox1);
            base.Controls.Add(this.buttonCancel);
            base.Controls.Add(this.buttonOK);
            base.FormBorderStyle = FormBorderStyle.FixedDialog;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "frmXSCZR";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "frmXSCZR";
            base.Load += new EventHandler(this.frmXSCZR_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            base.ResumeLayout(false);
        }
    }
}

