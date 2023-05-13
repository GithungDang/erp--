namespace ERPChess
{
    using BusinessTier;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmDiscount : Form
    {
        private IContainer components;
        private GroupBox groupBox1;
        private Label label2;
        private Label label1;
        private Label label5;
        private Label label7;
        private Label label6;
        private Label label4;
        private Label label3;
        private Label labelQ2;
        private Label labelQ4;
        private Label labelQ3;
        private Label labelQ1;
        private GroupBox groupBox2;
        private RichTextBox richTextBox2;
        private ComboBox comboBoxTXE;
        private Button buttonCancel;
        private Button buttonOK;

        public frmDiscount()
        {
            this.InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            int num = Convert.ToInt16(this.comboBoxTXE.SelectedItem);
            int num2 = num / 7;
            int num1 = TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.ReceivableAccountsQ1;
            int num3 = TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.ReceivableAccountsQ2;
            int num4 = TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.ReceivableAccountsQ3;
            int num5 = TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.ReceivableAccountsQ4;
            TFinancialSheet financialSheet = TGlobals.currentActor.CurrBusinessConditions.FinancialSheet;
            financialSheet.Discount += num2;
            TOperatingSheet operatingSheet = TGlobals.currentActor.CurrBusinessConditions.OperatingSheet;
            operatingSheet.CurrentCash += num - num2;
            TOperatingSheet sheet3 = TGlobals.currentActor.CurrBusinessConditions.OperatingSheet;
            sheet3.ReceivableAccountsQ4 -= num;
            if (TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.ReceivableAccountsQ4 < 0)
            {
                num = -TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.ReceivableAccountsQ4;
                TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.ReceivableAccountsQ4 = 0;
                TOperatingSheet sheet4 = TGlobals.currentActor.CurrBusinessConditions.OperatingSheet;
                sheet4.ReceivableAccountsQ3 -= num;
                if (TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.ReceivableAccountsQ3 < 0)
                {
                    num = -TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.ReceivableAccountsQ3;
                    TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.ReceivableAccountsQ3 = 0;
                    TOperatingSheet sheet5 = TGlobals.currentActor.CurrBusinessConditions.OperatingSheet;
                    sheet5.ReceivableAccountsQ2 -= num;
                    if (TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.ReceivableAccountsQ2 < 0)
                    {
                        num = -TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.ReceivableAccountsQ2;
                        TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.ReceivableAccountsQ2 = 0;
                        TOperatingSheet sheet6 = TGlobals.currentActor.CurrBusinessConditions.OperatingSheet;
                        sheet6.ReceivableAccountsQ1 -= num;
                    }
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void frmDiscount_Load(object sender, EventArgs e)
        {
            this.labelQ1.Text = TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.ReceivableAccountsQ1.ToString();
            this.labelQ2.Text = TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.ReceivableAccountsQ2.ToString();
            this.labelQ3.Text = TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.ReceivableAccountsQ3.ToString();
            this.labelQ4.Text = TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.ReceivableAccountsQ4.ToString();
            int receivableAccounts = TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.ReceivableAccounts;
            this.comboBoxTXE.Items.Clear();
            for (int i = 0; i <= receivableAccounts; i += 7)
            {
                this.comboBoxTXE.Items.Add(i.ToString());
            }
            this.comboBoxTXE.SelectedIndex = 0;
        }

        private void InitializeComponent()
        {
            this.groupBox1 = new GroupBox();
            this.comboBoxTXE = new ComboBox();
            this.labelQ2 = new Label();
            this.labelQ4 = new Label();
            this.labelQ3 = new Label();
            this.labelQ1 = new Label();
            this.label7 = new Label();
            this.label6 = new Label();
            this.label4 = new Label();
            this.label3 = new Label();
            this.label2 = new Label();
            this.label1 = new Label();
            this.label5 = new Label();
            this.groupBox2 = new GroupBox();
            this.richTextBox2 = new RichTextBox();
            this.buttonCancel = new Button();
            this.buttonOK = new Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            base.SuspendLayout();
            this.groupBox1.Controls.Add(this.comboBoxTXE);
            this.groupBox1.Controls.Add(this.labelQ2);
            this.groupBox1.Controls.Add(this.labelQ4);
            this.groupBox1.Controls.Add(this.labelQ3);
            this.groupBox1.Controls.Add(this.labelQ1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0xea, 200);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "贴现";
            this.comboBoxTXE.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxTXE.FormattingEnabled = true;
            object[] items = new object[] { "0", "20", "40", "60", "80" };
            this.comboBoxTXE.Items.AddRange(items);
            this.comboBoxTXE.Location = new Point(0x69, 0x94);
            this.comboBoxTXE.Name = "comboBoxTXE";
            this.comboBoxTXE.RightToLeft = RightToLeft.No;
            this.comboBoxTXE.Size = new Size(100, 20);
            this.comboBoxTXE.TabIndex = 0x23;
            this.labelQ2.BorderStyle = BorderStyle.FixedSingle;
            this.labelQ2.Location = new Point(0x69, 70);
            this.labelQ2.Name = "labelQ2";
            this.labelQ2.Size = new Size(100, 0x15);
            this.labelQ2.TabIndex = 0x29;
            this.labelQ2.Text = "-1";
            this.labelQ2.TextAlign = ContentAlignment.MiddleCenter;
            this.labelQ4.BorderStyle = BorderStyle.FixedSingle;
            this.labelQ4.Location = new Point(0x69, 110);
            this.labelQ4.Name = "labelQ4";
            this.labelQ4.Size = new Size(100, 0x15);
            this.labelQ4.TabIndex = 40;
            this.labelQ4.Text = "-1";
            this.labelQ4.TextAlign = ContentAlignment.MiddleCenter;
            this.labelQ3.BorderStyle = BorderStyle.FixedSingle;
            this.labelQ3.Location = new Point(0x69, 90);
            this.labelQ3.Name = "labelQ3";
            this.labelQ3.Size = new Size(100, 0x15);
            this.labelQ3.TabIndex = 0x27;
            this.labelQ3.Text = "-1";
            this.labelQ3.TextAlign = ContentAlignment.MiddleCenter;
            this.labelQ1.BorderStyle = BorderStyle.FixedSingle;
            this.labelQ1.Location = new Point(0x69, 50);
            this.labelQ1.Name = "labelQ1";
            this.labelQ1.Size = new Size(100, 0x15);
            this.labelQ1.TabIndex = 0x26;
            this.labelQ1.Text = "-1";
            this.labelQ1.TextAlign = ContentAlignment.MiddleCenter;
            this.label7.BorderStyle = BorderStyle.FixedSingle;
            this.label7.Location = new Point(6, 70);
            this.label7.Name = "label7";
            this.label7.Size = new Size(100, 0x15);
            this.label7.TabIndex = 0x25;
            this.label7.Text = "第二期";
            this.label7.TextAlign = ContentAlignment.MiddleCenter;
            this.label6.BorderStyle = BorderStyle.FixedSingle;
            this.label6.Location = new Point(6, 110);
            this.label6.Name = "label6";
            this.label6.Size = new Size(100, 0x15);
            this.label6.TabIndex = 0x24;
            this.label6.Text = "第四期";
            this.label6.TextAlign = ContentAlignment.MiddleCenter;
            this.label4.AutoSize = true;
            this.label4.Location = new Point(0x22, 0x97);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x41, 12);
            this.label4.TabIndex = 0x23;
            this.label4.Text = "贴现金额：";
            this.label3.BorderStyle = BorderStyle.FixedSingle;
            this.label3.Location = new Point(6, 90);
            this.label3.Name = "label3";
            this.label3.Size = new Size(100, 0x15);
            this.label3.TabIndex = 0x22;
            this.label3.Text = "第三期";
            this.label3.TextAlign = ContentAlignment.MiddleCenter;
            this.label2.BorderStyle = BorderStyle.FixedSingle;
            this.label2.Location = new Point(0x69, 30);
            this.label2.Name = "label2";
            this.label2.Size = new Size(100, 0x15);
            this.label2.TabIndex = 0x21;
            this.label2.Text = "应收账款数额";
            this.label2.TextAlign = ContentAlignment.MiddleCenter;
            this.label1.BorderStyle = BorderStyle.FixedSingle;
            this.label1.Location = new Point(6, 50);
            this.label1.Name = "label1";
            this.label1.Size = new Size(100, 0x15);
            this.label1.TabIndex = 0x20;
            this.label1.Text = "第一期";
            this.label1.TextAlign = ContentAlignment.MiddleCenter;
            this.label5.BorderStyle = BorderStyle.FixedSingle;
            this.label5.Location = new Point(6, 30);
            this.label5.Name = "label5";
            this.label5.Size = new Size(100, 0x15);
            this.label5.TabIndex = 30;
            this.label5.Text = "贴现期";
            this.label5.TextAlign = ContentAlignment.MiddleCenter;
            this.groupBox2.Controls.Add(this.richTextBox2);
            this.groupBox2.Location = new Point(0xfc, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(0x1ba, 200);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "说明";
            this.richTextBox2.BackColor = SystemColors.Window;
            this.richTextBox2.BorderStyle = BorderStyle.None;
            this.richTextBox2.Dock = DockStyle.Fill;
            this.richTextBox2.Font = new Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.richTextBox2.Location = new Point(3, 0x11);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.Size = new Size(0x1b4, 180);
            this.richTextBox2.TabIndex = 3;
            this.richTextBox2.Text = "    如果你急需现金，你可以将未来支付的应收账款卖给金融公司，这些金融公司将要等待客户的付款，而不是你，当然你需要支付贴现费。在我们的模拟中，从应收款中取出7M放入6M现金，剩余1M作为贴现费用。贴现可以在任何时候，金额是7的倍数。不论应收款账期长短，贴现费用一直为1M。\n    贴现规则：\n    如果实施贴现，自动从高账期到低账期减少应收账款数额，同时按7：1的比例扣除贴现息。";
            this.buttonCancel.DialogResult = DialogResult.Cancel;
            this.buttonCancel.Location = new Point(0x26a, 220);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new Size(0x4b, 0x17);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonOK.DialogResult = DialogResult.OK;
            this.buttonOK.Location = new Point(0x214, 220);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new Size(0x4b, 0x17);
            this.buttonOK.TabIndex = 1;
            this.buttonOK.Text = "确定";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new EventHandler(this.buttonOK_Click);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.CancelButton = this.buttonCancel;
            base.ClientSize = new Size(710, 0xff);
            base.Controls.Add(this.buttonCancel);
            base.Controls.Add(this.buttonOK);
            base.Controls.Add(this.groupBox2);
            base.Controls.Add(this.groupBox1);
            base.FormBorderStyle = FormBorderStyle.FixedDialog;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "frmDiscount";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "申请贴现";
            base.Load += new EventHandler(this.frmDiscount_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            base.ResumeLayout(false);
        }
    }
}

