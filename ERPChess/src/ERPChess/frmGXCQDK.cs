namespace ERPChess
{
    using BusinessTier;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmGXCQDK : Form
    {
        private IContainer components;
        private Button buttonOK;
        private Button buttonCancel;
        private GroupBox groupBox1;
        private Label label4;
        private Label label2;
        private Label label6;
        private ComboBox comboBoxDKE;
        private Label labelZGXE;
        private Label label3;
        private Label labelQY;
        private Label label7;
        private Label labelWHCD;
        private Label label9;
        private GroupBox groupBox3;
        private DataGridView dataGridViewCQDK;
        private Label labelGXDQDK;
        private GroupBox groupBox4;
        private Label label1;
        private Label label10;
        private Label label12;
        private Label label8;
        private Label label5;
        private Label label14;
        private DataGridViewTextBoxColumn 贷款时间;
        private DataGridViewTextBoxColumn 还款时间;
        private DataGridViewTextBoxColumn 贷款金额;
        private DataGridViewTextBoxColumn 每年利息;
        private Label label15;
        private Label label18;
        private Label label11;
        private Label label13;
        private Label label17;
        private Label label16;

        public frmGXCQDK()
        {
            this.InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            TGlobals.currentActor.LongTermLoanConditions.UndoPaymentBJ(TGlobals.currentActor.RunningYear);
            this.labelGXDQDK.Text = "";
            base.Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            int loanAmount = Convert.ToInt16(this.comboBoxDKE.SelectedItem);
            int paymentLX = TGlobals.currentActor.LongTermLoanConditions.GetPaymentLX(TGlobals.currentActor.RunningYear);
            TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.CurrentCash -= paymentLX;
            TGlobals.currentActor.CurrBusinessConditions.FinancialSheet.Interest += paymentLX;
            TLongTermLoans longTermLoans = TGlobals.currentActor.LongTermLoanConditions.GetLongTermLoans(TGlobals.currentActor.RunningYear);
            if (longTermLoans != null)
            {
                TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.CurrentCash -= longTermLoans.LoanAmount;
                TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.LongTermLoans -= longTermLoans.LoanAmount;
            }
            if (loanAmount != 0)
            {
                TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.CurrentCash += loanAmount;
                TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.LongTermLoans += loanAmount;
                Year paymentYear = TGlobals.currentActor.LongTermLoanConditions.GetPaymentYear(TGlobals.currentActor.RunningYear);
                TLongTermLoans loans2 = new TLongTermLoans(TGlobals.currentActor.RunningYear, paymentYear, loanAmount);
                TGlobals.currentActor.LongTermLoanConditions.Loan(loans2);
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

        private void frmGXCQDK_Load(object sender, EventArgs e)
        {
            this.labelGXDQDK.Text = "";
            TGlobals.currentActor.RunningYear.ToString();
            this.labelGXDQDK.Text = TGlobals.currentActor.LongTermLoanConditions.PaymentToString(TGlobals.currentActor.RunningYear);
            TGlobals.currentActor.LongTermLoanConditions.PaymentBJ(TGlobals.currentActor.RunningYear);
            int ownerRight = TGlobals.currentActor.CurrBusinessConditions.BalanceSheet.OwnerRight;
            this.labelQY.Text = ownerRight.ToString();
            this.labelWHCD.Text = TGlobals.currentActor.LongTermLoanConditions.NotAlsoAmount.ToString();
            int ceiling = TGlobals.currentActor.LongTermLoanConditions.GetCeiling(ownerRight);
            this.labelZGXE.Text = ceiling.ToString();
            this.comboBoxDKE.Items.Clear();
            for (int i = 0; i <= ceiling; i += 20)
            {
                this.comboBoxDKE.Items.Add(i.ToString());
            }
            this.comboBoxDKE.SelectedIndex = 0;
            TLongTermLoans[] notAlsoLoansList = TGlobals.currentActor.LongTermLoanConditions.GetNotAlsoLoansList();
            if (notAlsoLoansList == null)
            {
                this.dataGridViewCQDK.Rows.Clear();
            }
            else
            {
                this.dataGridViewCQDK.Rows.Clear();
                this.dataGridViewCQDK.RowCount = notAlsoLoansList.Length;
                for (int j = 0; j < notAlsoLoansList.Length; j++)
                {
                    this.dataGridViewCQDK.Rows[j].Cells["贷款时间"].Value = notAlsoLoansList[j].LoanYear;
                    this.dataGridViewCQDK.Rows[j].Cells["还款时间"].Value = notAlsoLoansList[j].PaymentYear.ToString() + "年底";
                    this.dataGridViewCQDK.Rows[j].Cells["贷款金额"].Value = notAlsoLoansList[j].LoanAmount;
                    this.dataGridViewCQDK.Rows[j].Cells["每年利息"].Value = notAlsoLoansList[j].Interest;
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
            this.groupBox1 = new GroupBox();
            this.comboBoxDKE = new ComboBox();
            this.labelQY = new Label();
            this.label7 = new Label();
            this.labelWHCD = new Label();
            this.label9 = new Label();
            this.labelZGXE = new Label();
            this.label3 = new Label();
            this.label6 = new Label();
            this.label2 = new Label();
            this.label4 = new Label();
            this.groupBox3 = new GroupBox();
            this.dataGridViewCQDK = new DataGridView();
            this.贷款时间 = new DataGridViewTextBoxColumn();
            this.还款时间 = new DataGridViewTextBoxColumn();
            this.贷款金额 = new DataGridViewTextBoxColumn();
            this.每年利息 = new DataGridViewTextBoxColumn();
            this.labelGXDQDK = new Label();
            this.groupBox4 = new GroupBox();
            this.label17 = new Label();
            this.label16 = new Label();
            this.label11 = new Label();
            this.label13 = new Label();
            this.label15 = new Label();
            this.label1 = new Label();
            this.label18 = new Label();
            this.label10 = new Label();
            this.label12 = new Label();
            this.label8 = new Label();
            this.label5 = new Label();
            this.label14 = new Label();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((ISupportInitialize) this.dataGridViewCQDK).BeginInit();
            this.groupBox4.SuspendLayout();
            base.SuspendLayout();
            this.buttonOK.DialogResult = DialogResult.OK;
            this.buttonOK.Location = new Point(0x1b4, 0x14b);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new Size(0x4b, 0x17);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "完成";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new EventHandler(this.buttonOK_Click);
            this.buttonCancel.DialogResult = DialogResult.Cancel;
            this.buttonCancel.Location = new Point(0x205, 0x14b);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new Size(0x4b, 0x17);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new EventHandler(this.buttonCancel_Click);
            this.groupBox1.Controls.Add(this.comboBoxDKE);
            this.groupBox1.Controls.Add(this.labelQY);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.labelWHCD);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.labelZGXE);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new Point(0x16d, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0xe3, 0xb7);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "申请长期贷款";
            this.comboBoxDKE.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxDKE.FormattingEnabled = true;
            object[] items = new object[] { "0", "20", "40", "60", "80" };
            this.comboBoxDKE.Items.AddRange(items);
            this.comboBoxDKE.Location = new Point(0x71, 0x7f);
            this.comboBoxDKE.Name = "comboBoxDKE";
            this.comboBoxDKE.Size = new Size(0x63, 20);
            this.comboBoxDKE.TabIndex = 0x25;
            this.labelQY.BorderStyle = BorderStyle.FixedSingle;
            this.labelQY.Location = new Point(0x70, 0x2f);
            this.labelQY.Name = "labelQY";
            this.labelQY.Size = new Size(100, 0x15);
            this.labelQY.TabIndex = 0x2b;
            this.labelQY.Text = "-1";
            this.labelQY.TextAlign = ContentAlignment.MiddleCenter;
            this.label7.BorderStyle = BorderStyle.FixedSingle;
            this.label7.Location = new Point(13, 0x2f);
            this.label7.Name = "label7";
            this.label7.Size = new Size(100, 0x15);
            this.label7.TabIndex = 0x2a;
            this.label7.Text = "上一年权益";
            this.label7.TextAlign = ContentAlignment.MiddleCenter;
            this.labelWHCD.BorderStyle = BorderStyle.FixedSingle;
            this.labelWHCD.Location = new Point(0x70, 0x43);
            this.labelWHCD.Name = "labelWHCD";
            this.labelWHCD.Size = new Size(100, 0x15);
            this.labelWHCD.TabIndex = 0x29;
            this.labelWHCD.Text = "-1";
            this.labelWHCD.TextAlign = ContentAlignment.MiddleCenter;
            this.label9.BorderStyle = BorderStyle.FixedSingle;
            this.label9.Location = new Point(13, 0x43);
            this.label9.Name = "label9";
            this.label9.Size = new Size(100, 0x15);
            this.label9.TabIndex = 40;
            this.label9.Text = "未还长期贷款";
            this.label9.TextAlign = ContentAlignment.MiddleCenter;
            this.labelZGXE.BorderStyle = BorderStyle.FixedSingle;
            this.labelZGXE.Location = new Point(0x70, 0x57);
            this.labelZGXE.Name = "labelZGXE";
            this.labelZGXE.Size = new Size(100, 0x15);
            this.labelZGXE.TabIndex = 0x27;
            this.labelZGXE.Text = "-1";
            this.labelZGXE.TextAlign = ContentAlignment.MiddleCenter;
            this.label3.BorderStyle = BorderStyle.FixedSingle;
            this.label3.Location = new Point(13, 0x57);
            this.label3.Name = "label3";
            this.label3.Size = new Size(100, 0x15);
            this.label3.TabIndex = 0x26;
            this.label3.Text = "最高贷款限额";
            this.label3.TextAlign = ContentAlignment.MiddleCenter;
            this.label6.BorderStyle = BorderStyle.FixedSingle;
            this.label6.Location = new Point(0x70, 0x6b);
            this.label6.Name = "label6";
            this.label6.Size = new Size(100, 0x15);
            this.label6.TabIndex = 0x24;
            this.label6.Text = "5年";
            this.label6.TextAlign = ContentAlignment.MiddleCenter;
            this.label2.BorderStyle = BorderStyle.FixedSingle;
            this.label2.Location = new Point(13, 0x6b);
            this.label2.Name = "label2";
            this.label2.Size = new Size(100, 0x15);
            this.label2.TabIndex = 0x21;
            this.label2.Text = "需贷款年限";
            this.label2.TextAlign = ContentAlignment.MiddleCenter;
            this.label4.BorderStyle = BorderStyle.FixedSingle;
            this.label4.Location = new Point(13, 0x7f);
            this.label4.Name = "label4";
            this.label4.Size = new Size(100, 20);
            this.label4.TabIndex = 0x23;
            this.label4.Text = "需贷款额";
            this.label4.TextAlign = ContentAlignment.MiddleCenter;
            this.groupBox3.Controls.Add(this.dataGridViewCQDK);
            this.groupBox3.Location = new Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new Size(0x15c, 0xb7);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "长期贷款明细";
            this.dataGridViewCQDK.AllowUserToAddRows = false;
            this.dataGridViewCQDK.AllowUserToDeleteRows = false;
            this.dataGridViewCQDK.AllowUserToResizeRows = false;
            this.dataGridViewCQDK.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridViewCQDK.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridViewColumn[] dataGridViewColumns = new DataGridViewColumn[] { this.贷款时间, this.还款时间, this.贷款金额, this.每年利息 };
            this.dataGridViewCQDK.Columns.AddRange(dataGridViewColumns);
            style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            style.BackColor = SystemColors.Window;
            style.Font = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            style.ForeColor = SystemColors.ControlText;
            style.SelectionBackColor = SystemColors.Highlight;
            style.SelectionForeColor = SystemColors.HighlightText;
            style.WrapMode = DataGridViewTriState.False;
            this.dataGridViewCQDK.DefaultCellStyle = style;
            this.dataGridViewCQDK.Location = new Point(6, 20);
            this.dataGridViewCQDK.MultiSelect = false;
            this.dataGridViewCQDK.Name = "dataGridViewCQDK";
            this.dataGridViewCQDK.ReadOnly = true;
            this.dataGridViewCQDK.RowHeadersVisible = false;
            this.dataGridViewCQDK.RowTemplate.Height = 0x17;
            this.dataGridViewCQDK.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCQDK.Size = new Size(0x14d, 0x9d);
            this.dataGridViewCQDK.TabIndex = 12;
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
            this.每年利息.DefaultCellStyle = style5;
            this.每年利息.HeaderText = "每年利息";
            this.每年利息.Name = "每年利息";
            this.每年利息.ReadOnly = true;
            this.每年利息.Resizable = DataGridViewTriState.False;
            this.每年利息.Width = 0x4e;
            this.labelGXDQDK.AutoSize = true;
            this.labelGXDQDK.Location = new Point(10, 0x14e);
            this.labelGXDQDK.Name = "labelGXDQDK";
            this.labelGXDQDK.Size = new Size(0x47, 12);
            this.labelGXDQDK.TabIndex = 14;
            this.labelGXDQDK.Text = "labelGXDQDK";
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Location = new Point(12, 0xc9);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new Size(580, 0x7c);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "说明";
            this.label17.AutoSize = true;
            this.label17.ForeColor = Color.Red;
            this.label17.Location = new Point(4, 0x56);
            this.label17.Name = "label17";
            this.label17.Size = new Size(0x1e5, 12);
            this.label17.TabIndex = 0x35;
            this.label17.Text = "贷款只能是20的倍数。若第六年底仍有未还贷款，除去原先40M外每1M企业发展得分扣1分，";
            this.label16.AutoSize = true;
            this.label16.ForeColor = Color.Red;
            this.label16.Location = new Point(4, 0x69);
            this.label16.Name = "label16";
            this.label16.Size = new Size(0xdd, 12);
            this.label16.TabIndex = 0x34;
            this.label16.Text = "若不足40M则每缺1M企业发展得分加1分。";
            this.label11.BorderStyle = BorderStyle.FixedSingle;
            this.label11.Location = new Point(80, 0x2b);
            this.label11.Name = "label11";
            this.label11.Size = new Size(0x4b, 0x21);
            this.label11.TabIndex = 0x33;
            this.label11.Text = "5年";
            this.label11.TextAlign = ContentAlignment.MiddleCenter;
            this.label13.BorderStyle = BorderStyle.FixedSingle;
            this.label13.Location = new Point(80, 0x17);
            this.label13.Name = "label13";
            this.label13.Size = new Size(0x4b, 0x15);
            this.label13.TabIndex = 50;
            this.label13.Text = "贷款期限";
            this.label13.TextAlign = ContentAlignment.MiddleCenter;
            this.label15.BorderStyle = BorderStyle.FixedSingle;
            this.label15.Location = new Point(0x132, 0x2b);
            this.label15.Name = "label15";
            this.label15.Size = new Size(0xc1, 0x21);
            this.label15.TabIndex = 0x31;
            this.label15.Text = "年底支付利息\r\n到期一次还本付息(系统自动扣除)";
            this.label15.TextAlign = ContentAlignment.MiddleCenter;
            this.label1.BorderStyle = BorderStyle.FixedSingle;
            this.label1.Location = new Point(0x9a, 0x2b);
            this.label1.Name = "label1";
            this.label1.Size = new Size(100, 0x21);
            this.label1.TabIndex = 0x2a;
            this.label1.Text = "上年权益的2倍";
            this.label1.TextAlign = ContentAlignment.MiddleCenter;
            this.label18.BorderStyle = BorderStyle.FixedSingle;
            this.label18.Location = new Point(0x132, 0x17);
            this.label18.Name = "label18";
            this.label18.Size = new Size(0xc1, 0x15);
            this.label18.TabIndex = 0x30;
            this.label18.Text = "还款方式";
            this.label18.TextAlign = ContentAlignment.MiddleCenter;
            this.label10.BorderStyle = BorderStyle.FixedSingle;
            this.label10.Location = new Point(0xfd, 0x2b);
            this.label10.Name = "label10";
            this.label10.Size = new Size(0x36, 0x21);
            this.label10.TabIndex = 0x29;
            this.label10.Text = "10%";
            this.label10.TextAlign = ContentAlignment.MiddleCenter;
            this.label12.BorderStyle = BorderStyle.FixedSingle;
            this.label12.Location = new Point(6, 0x2b);
            this.label12.Name = "label12";
            this.label12.Size = new Size(0x4b, 0x21);
            this.label12.TabIndex = 0x27;
            this.label12.Text = "每年年末";
            this.label12.TextAlign = ContentAlignment.MiddleCenter;
            this.label8.BorderStyle = BorderStyle.FixedSingle;
            this.label8.Location = new Point(0x9a, 0x17);
            this.label8.Name = "label8";
            this.label8.Size = new Size(100, 0x15);
            this.label8.TabIndex = 0x26;
            this.label8.Text = "贷款额度";
            this.label8.TextAlign = ContentAlignment.MiddleCenter;
            this.label5.BorderStyle = BorderStyle.FixedSingle;
            this.label5.Location = new Point(0xfd, 0x17);
            this.label5.Name = "label5";
            this.label5.Size = new Size(0x36, 0x15);
            this.label5.TabIndex = 0x25;
            this.label5.Text = "年利率";
            this.label5.TextAlign = ContentAlignment.MiddleCenter;
            this.label14.BorderStyle = BorderStyle.FixedSingle;
            this.label14.Location = new Point(6, 0x17);
            this.label14.Name = "label14";
            this.label14.Size = new Size(0x4b, 0x15);
            this.label14.TabIndex = 0x23;
            this.label14.Text = "贷款时间";
            this.label14.TextAlign = ContentAlignment.MiddleCenter;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.CancelButton = this.buttonCancel;
            base.ClientSize = new Size(0x268, 0x169);
            base.Controls.Add(this.groupBox4);
            base.Controls.Add(this.labelGXDQDK);
            base.Controls.Add(this.groupBox3);
            base.Controls.Add(this.groupBox1);
            base.Controls.Add(this.buttonCancel);
            base.Controls.Add(this.buttonOK);
            base.FormBorderStyle = FormBorderStyle.FixedDialog;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "frmGXCQDK";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "frmGXCQDK";
            base.Load += new EventHandler(this.frmGXCQDK_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((ISupportInitialize) this.dataGridViewCQDK).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            base.ResumeLayout(false);
            base.PerformLayout();
        }
    }
}

