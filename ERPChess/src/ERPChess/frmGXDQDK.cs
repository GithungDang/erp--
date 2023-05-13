namespace ERPChess
{
    using BusinessTier;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmGXDQDK : Form
    {
        private IContainer components;
        private Button buttonOK;
        private Button buttonCancel;
        private GroupBox groupBox1;
        private Label label2;
        private GroupBox groupBox2;
        private Label label8;
        private Label label9;
        private Label label6;
        private ComboBox comboBoxDKE;
        private Label label7;
        private Label label10;
        private Label label12;
        private Label labelZGXE;
        private Label label3;
        private Label labelWHDD;
        private Label label15;
        private Label labelQY;
        private Label label17;
        private GroupBox groupBox3;
        private DataGridView dataGridViewCJDHH;
        private Label labelGXDQDK;
        private DataGridViewTextBoxColumn 贷款时间;
        private DataGridViewTextBoxColumn 还款时间;
        private DataGridViewTextBoxColumn 贷款金额;
        private DataGridViewTextBoxColumn 支付利息;
        private Label label1;
        private Label label5;
        private Label label13;
        private Label label18;
        private Label label11;

        public frmGXDQDK()
        {
            this.InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            string paymentTime = TGlobals.currentActor.RunningYear.ToString() + TGlobals.currentActor.RunningQuarter.ToString();
            TGlobals.currentActor.ShortTermLoanConditions.UndoPayment(paymentTime);
            this.labelGXDQDK.Text = "";
            base.Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            int loanAmount = Convert.ToInt16(this.comboBoxDKE.SelectedItem);
            Year runningYear = TGlobals.currentActor.RunningYear;
            Quarter runningQuarter = TGlobals.currentActor.RunningQuarter;
            string paymentTime = runningYear.ToString() + runningQuarter.ToString();
            TShortTermLoans shortTermLoans = TGlobals.currentActor.ShortTermLoanConditions.GetShortTermLoans(paymentTime);
            if (shortTermLoans != null)
            {
                TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.CurrentCash -= shortTermLoans.PaymentAmount;
                TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.ShortTermLoans -= shortTermLoans.LoanAmount;
                TGlobals.currentActor.CurrBusinessConditions.FinancialSheet.Interest += shortTermLoans.Interest;
            }
            if (loanAmount != 0)
            {
                TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.CurrentCash += loanAmount;
                TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.ShortTermLoans += loanAmount;
                TShortTermLoans loans2 = new TShortTermLoans(paymentTime, TGlobals.currentActor.ShortTermLoanConditions.GetPaymentTime(runningYear, runningQuarter), loanAmount);
                TGlobals.currentActor.ShortTermLoanConditions.Loan(loans2);
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

        private void frmGXDQDK_Load(object sender, EventArgs e)
        {
            this.labelGXDQDK.Text = "";
            string paymentTime = TGlobals.currentActor.RunningYear.ToString() + TGlobals.currentActor.RunningQuarter.ToString();
            this.labelGXDQDK.Text = TGlobals.currentActor.ShortTermLoanConditions.Payment(paymentTime);
            int ownerRight = TGlobals.currentActor.CurrBusinessConditions.BalanceSheet.OwnerRight;
            this.labelQY.Text = ownerRight.ToString();
            this.labelWHDD.Text = TGlobals.currentActor.ShortTermLoanConditions.NotAlsoAmount.ToString();
            int ceiling = TGlobals.currentActor.ShortTermLoanConditions.GetCeiling(ownerRight);
            this.labelZGXE.Text = ceiling.ToString();
            this.comboBoxDKE.Items.Clear();
            for (int i = 0; i <= ceiling; i += 20)
            {
                this.comboBoxDKE.Items.Add(i.ToString());
            }
            this.comboBoxDKE.SelectedIndex = 0;
            TShortTermLoans[] notAlsoLoansList = TGlobals.currentActor.ShortTermLoanConditions.GetNotAlsoLoansList();
            if (notAlsoLoansList == null)
            {
                this.dataGridViewCJDHH.Rows.Clear();
            }
            else
            {
                this.dataGridViewCJDHH.Rows.Clear();
                this.dataGridViewCJDHH.RowCount = notAlsoLoansList.Length;
                for (int j = 0; j < notAlsoLoansList.Length; j++)
                {
                    this.dataGridViewCJDHH.Rows[j].Cells["贷款时间"].Value = notAlsoLoansList[j].LoanTime;
                    this.dataGridViewCJDHH.Rows[j].Cells["还款时间"].Value = notAlsoLoansList[j].PaymentTime;
                    this.dataGridViewCJDHH.Rows[j].Cells["贷款金额"].Value = notAlsoLoansList[j].LoanAmount;
                    this.dataGridViewCJDHH.Rows[j].Cells["支付利息"].Value = notAlsoLoansList[j].Interest;
                }
            }
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            DataGridViewCellStyle style2 = new DataGridViewCellStyle();
            DataGridViewCellStyle style3 = new DataGridViewCellStyle();
            DataGridViewCellStyle style4 = new DataGridViewCellStyle();
            DataGridViewCellStyle style5 = new DataGridViewCellStyle();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(frmGXDQDK));
            this.buttonOK = new Button();
            this.buttonCancel = new Button();
            this.groupBox1 = new GroupBox();
            this.labelQY = new Label();
            this.label17 = new Label();
            this.labelWHDD = new Label();
            this.label15 = new Label();
            this.labelZGXE = new Label();
            this.label3 = new Label();
            this.label2 = new Label();
            this.comboBoxDKE = new ComboBox();
            this.groupBox2 = new GroupBox();
            this.label11 = new Label();
            this.label13 = new Label();
            this.label1 = new Label();
            this.label18 = new Label();
            this.label5 = new Label();
            this.label7 = new Label();
            this.label10 = new Label();
            this.label12 = new Label();
            this.label8 = new Label();
            this.label9 = new Label();
            this.label6 = new Label();
            this.groupBox3 = new GroupBox();
            this.dataGridViewCJDHH = new DataGridView();
            this.贷款时间 = new DataGridViewTextBoxColumn();
            this.还款时间 = new DataGridViewTextBoxColumn();
            this.贷款金额 = new DataGridViewTextBoxColumn();
            this.支付利息 = new DataGridViewTextBoxColumn();
            this.labelGXDQDK = new Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((ISupportInitialize) this.dataGridViewCJDHH).BeginInit();
            base.SuspendLayout();
            this.buttonOK.DialogResult = DialogResult.OK;
            this.buttonOK.Location = new Point(0x1b4, 0x12e);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new Size(0x4b, 0x17);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "完成";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new EventHandler(this.buttonOK_Click);
            this.buttonCancel.DialogResult = DialogResult.Cancel;
            this.buttonCancel.Location = new Point(0x205, 0x12e);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new Size(0x4b, 0x17);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new EventHandler(this.buttonCancel_Click);
            this.groupBox1.Controls.Add(this.labelQY);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.labelWHDD);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.labelZGXE);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBoxDKE);
            this.groupBox1.Location = new Point(370, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0xde, 0xb7);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "申请短期贷款";
            this.labelQY.BorderStyle = BorderStyle.FixedSingle;
            this.labelQY.Location = new Point(0x6d, 0x33);
            this.labelQY.Name = "labelQY";
            this.labelQY.Size = new Size(100, 0x15);
            this.labelQY.TabIndex = 0x2d;
            this.labelQY.Text = "6";
            this.labelQY.TextAlign = ContentAlignment.MiddleCenter;
            this.label17.BorderStyle = BorderStyle.FixedSingle;
            this.label17.Location = new Point(10, 0x33);
            this.label17.Name = "label17";
            this.label17.Size = new Size(100, 0x15);
            this.label17.TabIndex = 0x2c;
            this.label17.Text = "上一年权益";
            this.label17.TextAlign = ContentAlignment.MiddleCenter;
            this.labelWHDD.BorderStyle = BorderStyle.FixedSingle;
            this.labelWHDD.Location = new Point(0x6d, 0x47);
            this.labelWHDD.Name = "labelWHDD";
            this.labelWHDD.Size = new Size(100, 0x15);
            this.labelWHDD.TabIndex = 0x2b;
            this.labelWHDD.Text = "-1";
            this.labelWHDD.TextAlign = ContentAlignment.MiddleCenter;
            this.label15.BorderStyle = BorderStyle.FixedSingle;
            this.label15.Location = new Point(10, 0x47);
            this.label15.Name = "label15";
            this.label15.Size = new Size(100, 0x15);
            this.label15.TabIndex = 0x2a;
            this.label15.Text = "未还短期贷款";
            this.label15.TextAlign = ContentAlignment.MiddleCenter;
            this.labelZGXE.BorderStyle = BorderStyle.FixedSingle;
            this.labelZGXE.Location = new Point(0x6d, 0x5b);
            this.labelZGXE.Name = "labelZGXE";
            this.labelZGXE.Size = new Size(100, 0x15);
            this.labelZGXE.TabIndex = 0x29;
            this.labelZGXE.Text = "0";
            this.labelZGXE.TextAlign = ContentAlignment.MiddleCenter;
            this.label3.BorderStyle = BorderStyle.FixedSingle;
            this.label3.Location = new Point(10, 0x5b);
            this.label3.Name = "label3";
            this.label3.Size = new Size(100, 0x15);
            this.label3.TabIndex = 40;
            this.label3.Text = "最高贷款限额";
            this.label3.TextAlign = ContentAlignment.MiddleCenter;
            this.label2.BorderStyle = BorderStyle.FixedSingle;
            this.label2.Location = new Point(10, 0x6f);
            this.label2.Name = "label2";
            this.label2.Size = new Size(100, 20);
            this.label2.TabIndex = 0x21;
            this.label2.Text = "需贷款额";
            this.label2.TextAlign = ContentAlignment.MiddleCenter;
            this.comboBoxDKE.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxDKE.FormattingEnabled = true;
            object[] items = new object[] { "0", "20", "40", "60", "80" };
            this.comboBoxDKE.Items.AddRange(items);
            this.comboBoxDKE.Location = new Point(0x6d, 0x6f);
            this.comboBoxDKE.Name = "comboBoxDKE";
            this.comboBoxDKE.RightToLeft = RightToLeft.No;
            this.comboBoxDKE.Size = new Size(100, 20);
            this.comboBoxDKE.TabIndex = 0x22;
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new Point(12, 0xc9);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(580, 0x5e);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "说明";
            this.label11.AutoSize = true;
            this.label11.ForeColor = Color.Red;
            this.label11.Location = new Point(9, 0x48);
            this.label11.Name = "label11";
            this.label11.Size = new Size(0x18b, 12);
            this.label11.TabIndex = 0x30;
            this.label11.Text = "贷款只能是20的倍数，若第六年底仍有未还贷款每1M企业发展得分扣1分。";
            this.label13.BorderStyle = BorderStyle.FixedSingle;
            this.label13.Location = new Point(0x137, 0x2b);
            this.label13.Name = "label13";
            this.label13.Size = new Size(0xc1, 0x15);
            this.label13.TabIndex = 0x2f;
            this.label13.Text = "到期一次还本付息(系统自动扣除)";
            this.label13.TextAlign = ContentAlignment.MiddleCenter;
            this.label1.BorderStyle = BorderStyle.FixedSingle;
            this.label1.Location = new Point(0x55, 0x2b);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x4b, 0x15);
            this.label1.TabIndex = 0x2e;
            this.label1.Text = "1年";
            this.label1.TextAlign = ContentAlignment.MiddleCenter;
            this.label18.BorderStyle = BorderStyle.FixedSingle;
            this.label18.Location = new Point(0x137, 0x17);
            this.label18.Name = "label18";
            this.label18.Size = new Size(0xc1, 0x15);
            this.label18.TabIndex = 0x2e;
            this.label18.Text = "还款方式";
            this.label18.TextAlign = ContentAlignment.MiddleCenter;
            this.label5.BorderStyle = BorderStyle.FixedSingle;
            this.label5.Location = new Point(0x55, 0x17);
            this.label5.Name = "label5";
            this.label5.Size = new Size(0x4b, 0x15);
            this.label5.TabIndex = 0x2d;
            this.label5.Text = "贷款期限";
            this.label5.TextAlign = ContentAlignment.MiddleCenter;
            this.label7.BorderStyle = BorderStyle.FixedSingle;
            this.label7.Location = new Point(0x9f, 0x2b);
            this.label7.Name = "label7";
            this.label7.Size = new Size(100, 0x15);
            this.label7.TabIndex = 0x2a;
            this.label7.Text = "上年权益的2倍";
            this.label7.TextAlign = ContentAlignment.MiddleCenter;
            this.label10.BorderStyle = BorderStyle.FixedSingle;
            this.label10.Location = new Point(0x102, 0x2b);
            this.label10.Name = "label10";
            this.label10.Size = new Size(0x36, 0x15);
            this.label10.TabIndex = 0x29;
            this.label10.Text = "5%";
            this.label10.TextAlign = ContentAlignment.MiddleCenter;
            this.label12.BorderStyle = BorderStyle.FixedSingle;
            this.label12.Location = new Point(11, 0x2b);
            this.label12.Name = "label12";
            this.label12.Size = new Size(0x4b, 0x15);
            this.label12.TabIndex = 0x27;
            this.label12.Text = "每季度初";
            this.label12.TextAlign = ContentAlignment.MiddleCenter;
            this.label8.BorderStyle = BorderStyle.FixedSingle;
            this.label8.Location = new Point(0x9f, 0x17);
            this.label8.Name = "label8";
            this.label8.Size = new Size(100, 0x15);
            this.label8.TabIndex = 0x26;
            this.label8.Text = "贷款额度";
            this.label8.TextAlign = ContentAlignment.MiddleCenter;
            this.label9.BorderStyle = BorderStyle.FixedSingle;
            this.label9.Location = new Point(0x102, 0x17);
            this.label9.Name = "label9";
            this.label9.Size = new Size(0x36, 0x15);
            this.label9.TabIndex = 0x25;
            this.label9.Text = "年利率";
            this.label9.TextAlign = ContentAlignment.MiddleCenter;
            this.label6.BorderStyle = BorderStyle.FixedSingle;
            this.label6.Location = new Point(11, 0x17);
            this.label6.Name = "label6";
            this.label6.Size = new Size(0x4b, 0x15);
            this.label6.TabIndex = 0x23;
            this.label6.Text = "贷款时间";
            this.label6.TextAlign = ContentAlignment.MiddleCenter;
            this.groupBox3.Controls.Add(this.dataGridViewCJDHH);
            this.groupBox3.Location = new Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new Size(0x160, 0xb7);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "短期贷款明细";
            this.dataGridViewCJDHH.AllowUserToAddRows = false;
            this.dataGridViewCJDHH.AllowUserToDeleteRows = false;
            this.dataGridViewCJDHH.AllowUserToResizeRows = false;
            this.dataGridViewCJDHH.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridViewCJDHH.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridViewColumn[] dataGridViewColumns = new DataGridViewColumn[] { this.贷款时间, this.还款时间, this.贷款金额, this.支付利息 };
            this.dataGridViewCJDHH.Columns.AddRange(dataGridViewColumns);
            style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            style.BackColor = SystemColors.Window;
            style.Font = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            style.ForeColor = SystemColors.ControlText;
            style.SelectionBackColor = SystemColors.Highlight;
            style.SelectionForeColor = SystemColors.HighlightText;
            style.WrapMode = DataGridViewTriState.False;
            this.dataGridViewCJDHH.DefaultCellStyle = style;
            this.dataGridViewCJDHH.Location = new Point(6, 20);
            this.dataGridViewCJDHH.MultiSelect = false;
            this.dataGridViewCJDHH.Name = "dataGridViewCJDHH";
            this.dataGridViewCJDHH.ReadOnly = true;
            this.dataGridViewCJDHH.RowHeadersVisible = false;
            this.dataGridViewCJDHH.RowTemplate.Height = 0x17;
            this.dataGridViewCJDHH.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCJDHH.Size = new Size(0x14d, 0x9d);
            this.dataGridViewCJDHH.TabIndex = 12;
            style2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.贷款时间.DefaultCellStyle = style2;
            this.贷款时间.HeaderText = "贷款时间";
            this.贷款时间.Name = "贷款时间";
            this.贷款时间.ReadOnly = true;
            this.贷款时间.Resizable = DataGridViewTriState.False;
            this.贷款时间.Width = 0x4e;
            style3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.还款时间.DefaultCellStyle = style3;
            this.还款时间.HeaderText = "还款时间";
            this.还款时间.Name = "还款时间";
            this.还款时间.ReadOnly = true;
            this.还款时间.Resizable = DataGridViewTriState.False;
            this.还款时间.Width = 0x4e;
            style4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.贷款金额.DefaultCellStyle = style4;
            this.贷款金额.HeaderText = "贷款金额";
            this.贷款金额.Name = "贷款金额";
            this.贷款金额.ReadOnly = true;
            this.贷款金额.Resizable = DataGridViewTriState.False;
            this.贷款金额.Width = 0x4e;
            style5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.支付利息.DefaultCellStyle = style5;
            this.支付利息.HeaderText = "支付利息";
            this.支付利息.Name = "支付利息";
            this.支付利息.ReadOnly = true;
            this.支付利息.Resizable = DataGridViewTriState.False;
            this.支付利息.Width = 0x4e;
            this.labelGXDQDK.AutoSize = true;
            this.labelGXDQDK.Location = new Point(0x10, 0x133);
            this.labelGXDQDK.Name = "labelGXDQDK";
            this.labelGXDQDK.Size = new Size(0x47, 12);
            this.labelGXDQDK.TabIndex = 13;
            this.labelGXDQDK.Text = "labelGXDQDK";
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.CancelButton = this.buttonCancel;
            base.ClientSize = new Size(0x259, 0x14b);
            base.Controls.Add(this.labelGXDQDK);
            base.Controls.Add(this.groupBox3);
            base.Controls.Add(this.groupBox2);
            base.Controls.Add(this.groupBox1);
            base.Controls.Add(this.buttonCancel);
            base.Controls.Add(this.buttonOK);
            base.FormBorderStyle = FormBorderStyle.FixedDialog;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "frmGXDQDK";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = manager.GetString("$this.Text");
            base.Load += new EventHandler(this.frmGXDQDK_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((ISupportInitialize) this.dataGridViewCJDHH).EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }
    }
}

