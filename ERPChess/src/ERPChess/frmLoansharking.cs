namespace ERPChess
{
    using BusinessTier;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmLoansharking : Form
    {
        private IContainer components;
        private Button buttonOK;
        private Button buttonCancel;
        private GroupBox groupBox3;
        private DataGridView dataGridViewCJDHH;
        private DataGridViewTextBoxColumn 贷款时间;
        private DataGridViewTextBoxColumn 还款时间;
        private DataGridViewTextBoxColumn 贷款金额;
        private DataGridViewTextBoxColumn 支付利息;
        private GroupBox groupBox4;
        private Label labelQY;
        private Label label4;
        private Label labelWHDK;
        private Label label6;
        private Label labelZGXE;
        private Label label7;
        private Label label8;
        private ComboBox comboBoxDKE;
        private Label labelGXGLDK;
        private GroupBox groupBox5;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label18;
        private Label label19;
        private Label label1;
        private Label label2;
        private Label label5;
        private Label label3;

        public frmLoansharking()
        {
            this.InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            string paymentTime = TGlobals.currentActor.RunningYear.ToString() + TGlobals.currentActor.RunningQuarter.ToString();
            TGlobals.currentActor.LoanSharkingConditions.UndoPayment(paymentTime);
            this.labelGXGLDK.Text = "";
            base.Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            int loanAmount = Convert.ToInt16(this.comboBoxDKE.SelectedItem);
            Year runningYear = TGlobals.currentActor.RunningYear;
            Quarter runningQuarter = TGlobals.currentActor.RunningQuarter;
            string paymentTime = runningYear.ToString() + runningQuarter.ToString();
            TLoanSharking loanSharking = TGlobals.currentActor.LoanSharkingConditions.GetLoanSharking(paymentTime);
            if (loanSharking != null)
            {
                TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.CurrentCash -= loanSharking.PaymentAmount;
                TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.LoanSharking -= loanSharking.LoanAmount;
                TGlobals.currentActor.CurrBusinessConditions.FinancialSheet.Interest += loanSharking.Interest;
            }
            if (loanAmount != 0)
            {
                TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.CurrentCash += loanAmount;
                TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.LoanSharking += loanAmount;
                TLoanSharking loans = new TLoanSharking(paymentTime, TGlobals.currentActor.ShortTermLoanConditions.GetPaymentTime(runningYear, runningQuarter), loanAmount);
                TGlobals.currentActor.LoanSharkingConditions.Loan(loans);
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

        private void frmLoansharking_Load(object sender, EventArgs e)
        {
            this.labelGXGLDK.Text = "";
            string paymentTime = TGlobals.currentActor.RunningYear.ToString() + TGlobals.currentActor.RunningQuarter.ToString();
            this.labelGXGLDK.Text = TGlobals.currentActor.LoanSharkingConditions.Payment(paymentTime);
            int ownerRight = TGlobals.currentActor.CurrBusinessConditions.BalanceSheet.OwnerRight;
            this.labelQY.Text = ownerRight.ToString();
            this.labelWHDK.Text = TGlobals.currentActor.LoanSharkingConditions.NotAlsoAmount.ToString();
            int ceiling = TGlobals.currentActor.LoanSharkingConditions.GetCeiling(ownerRight);
            this.labelZGXE.Text = ceiling.ToString();
            this.comboBoxDKE.Items.Clear();
            for (int i = 0; i <= ceiling; i += 20)
            {
                this.comboBoxDKE.Items.Add(i.ToString());
            }
            this.comboBoxDKE.SelectedIndex = 0;
            TLoanSharking[] notAlsoLoansList = TGlobals.currentActor.LoanSharkingConditions.GetNotAlsoLoansList();
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
            this.buttonOK = new Button();
            this.buttonCancel = new Button();
            this.groupBox3 = new GroupBox();
            this.dataGridViewCJDHH = new DataGridView();
            this.贷款时间 = new DataGridViewTextBoxColumn();
            this.还款时间 = new DataGridViewTextBoxColumn();
            this.贷款金额 = new DataGridViewTextBoxColumn();
            this.支付利息 = new DataGridViewTextBoxColumn();
            this.groupBox4 = new GroupBox();
            this.labelQY = new Label();
            this.label4 = new Label();
            this.labelWHDK = new Label();
            this.label6 = new Label();
            this.labelZGXE = new Label();
            this.label7 = new Label();
            this.label8 = new Label();
            this.comboBoxDKE = new ComboBox();
            this.labelGXGLDK = new Label();
            this.groupBox5 = new GroupBox();
            this.label5 = new Label();
            this.label3 = new Label();
            this.label1 = new Label();
            this.label2 = new Label();
            this.label9 = new Label();
            this.label10 = new Label();
            this.label11 = new Label();
            this.label12 = new Label();
            this.label13 = new Label();
            this.label14 = new Label();
            this.label18 = new Label();
            this.label19 = new Label();
            this.groupBox3.SuspendLayout();
            ((ISupportInitialize) this.dataGridViewCJDHH).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            base.SuspendLayout();
            this.buttonOK.DialogResult = DialogResult.OK;
            this.buttonOK.Location = new Point(0x1aa, 0x13f);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new Size(0x4b, 0x17);
            this.buttonOK.TabIndex = 5;
            this.buttonOK.Text = "确定";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new EventHandler(this.buttonOK_Click);
            this.buttonCancel.DialogResult = DialogResult.Cancel;
            this.buttonCancel.Location = new Point(0x1fb, 0x13f);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new Size(0x4b, 0x17);
            this.buttonCancel.TabIndex = 8;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new EventHandler(this.buttonCancel_Click);
            this.groupBox3.Controls.Add(this.dataGridViewCJDHH);
            this.groupBox3.Location = new Point(14, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new Size(0x160, 0xb7);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "高利贷款明细";
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
            this.groupBox4.Controls.Add(this.labelQY);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.labelWHDK);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.labelZGXE);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.comboBoxDKE);
            this.groupBox4.Location = new Point(0x174, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new Size(0xde, 0xb7);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "申请高利贷款";
            this.labelQY.BorderStyle = BorderStyle.FixedSingle;
            this.labelQY.Location = new Point(0x6d, 0x33);
            this.labelQY.Name = "labelQY";
            this.labelQY.Size = new Size(100, 0x15);
            this.labelQY.TabIndex = 0x2d;
            this.labelQY.Text = "6";
            this.labelQY.TextAlign = ContentAlignment.MiddleCenter;
            this.label4.BorderStyle = BorderStyle.FixedSingle;
            this.label4.Location = new Point(10, 0x33);
            this.label4.Name = "label4";
            this.label4.Size = new Size(100, 0x15);
            this.label4.TabIndex = 0x2c;
            this.label4.Text = "上一年权益";
            this.label4.TextAlign = ContentAlignment.MiddleCenter;
            this.labelWHDK.BorderStyle = BorderStyle.FixedSingle;
            this.labelWHDK.Location = new Point(0x6d, 0x47);
            this.labelWHDK.Name = "labelWHDK";
            this.labelWHDK.Size = new Size(100, 0x15);
            this.labelWHDK.TabIndex = 0x2b;
            this.labelWHDK.Text = "-1";
            this.labelWHDK.TextAlign = ContentAlignment.MiddleCenter;
            this.label6.BorderStyle = BorderStyle.FixedSingle;
            this.label6.Location = new Point(10, 0x47);
            this.label6.Name = "label6";
            this.label6.Size = new Size(100, 0x15);
            this.label6.TabIndex = 0x2a;
            this.label6.Text = "未还高利贷款";
            this.label6.TextAlign = ContentAlignment.MiddleCenter;
            this.labelZGXE.BorderStyle = BorderStyle.FixedSingle;
            this.labelZGXE.Location = new Point(0x6d, 0x5b);
            this.labelZGXE.Name = "labelZGXE";
            this.labelZGXE.Size = new Size(100, 0x15);
            this.labelZGXE.TabIndex = 0x29;
            this.labelZGXE.Text = "0";
            this.labelZGXE.TextAlign = ContentAlignment.MiddleCenter;
            this.label7.BorderStyle = BorderStyle.FixedSingle;
            this.label7.Location = new Point(10, 0x5b);
            this.label7.Name = "label7";
            this.label7.Size = new Size(100, 0x15);
            this.label7.TabIndex = 40;
            this.label7.Text = "最高贷款限额";
            this.label7.TextAlign = ContentAlignment.MiddleCenter;
            this.label8.BorderStyle = BorderStyle.FixedSingle;
            this.label8.Location = new Point(10, 0x6f);
            this.label8.Name = "label8";
            this.label8.Size = new Size(100, 20);
            this.label8.TabIndex = 0x21;
            this.label8.Text = "需贷款额";
            this.label8.TextAlign = ContentAlignment.MiddleCenter;
            this.comboBoxDKE.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxDKE.FormattingEnabled = true;
            object[] items = new object[] { "0", "20", "40", "60", "80" };
            this.comboBoxDKE.Items.AddRange(items);
            this.comboBoxDKE.Location = new Point(0x6d, 0x6f);
            this.comboBoxDKE.Name = "comboBoxDKE";
            this.comboBoxDKE.RightToLeft = RightToLeft.No;
            this.comboBoxDKE.Size = new Size(100, 20);
            this.comboBoxDKE.TabIndex = 0x22;
            this.labelGXGLDK.AutoSize = true;
            this.labelGXGLDK.Location = new Point(10, 0x144);
            this.labelGXGLDK.Name = "labelGXGLDK";
            this.labelGXGLDK.Size = new Size(0x47, 12);
            this.labelGXGLDK.TabIndex = 0x10;
            this.labelGXGLDK.Text = "labelGXGLDK";
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Controls.Add(this.label18);
            this.groupBox5.Controls.Add(this.label19);
            this.groupBox5.Location = new Point(14, 0xc9);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new Size(580, 0x70);
            this.groupBox5.TabIndex = 15;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "说明";
            this.label5.AutoSize = true;
            this.label5.ForeColor = Color.Red;
            this.label5.Location = new Point(6, 0x5d);
            this.label5.Name = "label5";
            this.label5.Size = new Size(0x113, 12);
            this.label5.TabIndex = 0x2e;
            this.label5.Text = "若第六年底仍有未还贷款每1M企业发展得分扣1分。";
            this.label3.AutoSize = true;
            this.label3.ForeColor = Color.Red;
            this.label3.Location = new Point(6, 0x4a);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x161, 12);
            this.label3.TabIndex = 0x2d;
            this.label3.Text = "贷款只能是20的倍数，每借20M的高利贷款，企业发展得分扣5分。";
            this.label1.BorderStyle = BorderStyle.FixedSingle;
            this.label1.Location = new Point(80, 0x2b);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x4b, 0x15);
            this.label1.TabIndex = 0x2c;
            this.label1.Text = "1年";
            this.label1.TextAlign = ContentAlignment.MiddleCenter;
            this.label2.BorderStyle = BorderStyle.FixedSingle;
            this.label2.Location = new Point(80, 0x17);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x4b, 0x15);
            this.label2.TabIndex = 0x2b;
            this.label2.Text = "贷款期限";
            this.label2.TextAlign = ContentAlignment.MiddleCenter;
            this.label9.BorderStyle = BorderStyle.FixedSingle;
            this.label9.Location = new Point(0x9a, 0x2b);
            this.label9.Name = "label9";
            this.label9.Size = new Size(100, 0x15);
            this.label9.TabIndex = 0x2a;
            this.label9.Text = "上年权益的3倍";
            this.label9.TextAlign = ContentAlignment.MiddleCenter;
            this.label10.BorderStyle = BorderStyle.FixedSingle;
            this.label10.Location = new Point(0xfd, 0x2b);
            this.label10.Name = "label10";
            this.label10.Size = new Size(0x36, 0x15);
            this.label10.TabIndex = 0x29;
            this.label10.Text = "20%";
            this.label10.TextAlign = ContentAlignment.MiddleCenter;
            this.label11.BorderStyle = BorderStyle.FixedSingle;
            this.label11.Location = new Point(0x132, 0x2b);
            this.label11.Name = "label11";
            this.label11.Size = new Size(0xc1, 0x15);
            this.label11.TabIndex = 40;
            this.label11.Text = "到期一次还本付息(系统自动扣除)";
            this.label11.TextAlign = ContentAlignment.MiddleCenter;
            this.label12.BorderStyle = BorderStyle.FixedSingle;
            this.label12.Location = new Point(6, 0x2b);
            this.label12.Name = "label12";
            this.label12.Size = new Size(0x4b, 0x15);
            this.label12.TabIndex = 0x27;
            this.label12.Text = "每季度初";
            this.label12.TextAlign = ContentAlignment.MiddleCenter;
            this.label13.BorderStyle = BorderStyle.FixedSingle;
            this.label13.Location = new Point(0x9a, 0x17);
            this.label13.Name = "label13";
            this.label13.Size = new Size(100, 0x15);
            this.label13.TabIndex = 0x26;
            this.label13.Text = "贷款额度";
            this.label13.TextAlign = ContentAlignment.MiddleCenter;
            this.label14.BorderStyle = BorderStyle.FixedSingle;
            this.label14.Location = new Point(0xfd, 0x17);
            this.label14.Name = "label14";
            this.label14.Size = new Size(0x36, 0x15);
            this.label14.TabIndex = 0x25;
            this.label14.Text = "年利率";
            this.label14.TextAlign = ContentAlignment.MiddleCenter;
            this.label18.BorderStyle = BorderStyle.FixedSingle;
            this.label18.Location = new Point(0x132, 0x17);
            this.label18.Name = "label18";
            this.label18.Size = new Size(0xc1, 0x15);
            this.label18.TabIndex = 0x24;
            this.label18.Text = "还款方式";
            this.label18.TextAlign = ContentAlignment.MiddleCenter;
            this.label19.BorderStyle = BorderStyle.FixedSingle;
            this.label19.Location = new Point(6, 0x17);
            this.label19.Name = "label19";
            this.label19.Size = new Size(0x4b, 0x15);
            this.label19.TabIndex = 0x23;
            this.label19.Text = "贷款时间";
            this.label19.TextAlign = ContentAlignment.MiddleCenter;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.CancelButton = this.buttonCancel;
            base.ClientSize = new Size(610, 0x15f);
            base.Controls.Add(this.labelGXGLDK);
            base.Controls.Add(this.groupBox5);
            base.Controls.Add(this.groupBox3);
            base.Controls.Add(this.groupBox4);
            base.Controls.Add(this.buttonCancel);
            base.Controls.Add(this.buttonOK);
            base.FormBorderStyle = FormBorderStyle.FixedDialog;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "frmLoansharking";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "高利贷借款";
            base.Load += new EventHandler(this.frmLoansharking_Load);
            this.groupBox3.ResumeLayout(false);
            ((ISupportInitialize) this.dataGridViewCJDHH).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            base.ResumeLayout(false);
            base.PerformLayout();
        }
    }
}

