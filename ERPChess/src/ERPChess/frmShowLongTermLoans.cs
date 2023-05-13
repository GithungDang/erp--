namespace ERPChess
{
    using BusinessTier;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmShowLongTermLoans : Form
    {
        private IContainer components;
        private GroupBox groupBox3;
        private DataGridView dataGridViewCQDK;
        private DataGridViewTextBoxColumn 贷款时间;
        private DataGridViewTextBoxColumn 还款时间;
        private DataGridViewTextBoxColumn 贷款金额;
        private DataGridViewTextBoxColumn 每年利息;
        private Button button1;
        private Label label17;
        private Label label16;

        public frmShowLongTermLoans()
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

        private void frmShowLongTermLoans_Load(object sender, EventArgs e)
        {
            TLongTermLoans[] notAlsoLoansList = TGlobals.currentActor.LongTermLoanConditions.GetNotAlsoLoansList();
            if (notAlsoLoansList == null)
            {
                this.dataGridViewCQDK.Rows.Clear();
            }
            else
            {
                this.dataGridViewCQDK.Rows.Clear();
                this.dataGridViewCQDK.RowCount = notAlsoLoansList.Length;
                for (int i = 0; i < notAlsoLoansList.Length; i++)
                {
                    this.dataGridViewCQDK.Rows[i].Cells["贷款时间"].Value = notAlsoLoansList[i].LoanYear;
                    this.dataGridViewCQDK.Rows[i].Cells["还款时间"].Value = notAlsoLoansList[i].PaymentYear.ToString() + "年底";
                    this.dataGridViewCQDK.Rows[i].Cells["贷款金额"].Value = notAlsoLoansList[i].LoanAmount;
                    this.dataGridViewCQDK.Rows[i].Cells["每年利息"].Value = notAlsoLoansList[i].Interest;
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
            this.groupBox3 = new GroupBox();
            this.dataGridViewCQDK = new DataGridView();
            this.贷款时间 = new DataGridViewTextBoxColumn();
            this.还款时间 = new DataGridViewTextBoxColumn();
            this.贷款金额 = new DataGridViewTextBoxColumn();
            this.每年利息 = new DataGridViewTextBoxColumn();
            this.button1 = new Button();
            this.label17 = new Label();
            this.label16 = new Label();
            this.groupBox3.SuspendLayout();
            ((ISupportInitialize) this.dataGridViewCQDK).BeginInit();
            base.SuspendLayout();
            this.groupBox3.Controls.Add(this.dataGridViewCQDK);
            this.groupBox3.Location = new Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new Size(0x16b, 0xb7);
            this.groupBox3.TabIndex = 14;
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
            this.button1.DialogResult = DialogResult.OK;
            this.button1.Location = new Point(0x11a, 220);
            this.button1.Name = "button1";
            this.button1.Size = new Size(0x4b, 0x17);
            this.button1.TabIndex = 0;
            this.button1.Text = "完成";
            this.button1.UseVisualStyleBackColor = true;
            this.label17.AutoSize = true;
            this.label17.ForeColor = Color.Red;
            this.label17.Location = new Point(10, 0xcd);
            this.label17.Name = "label17";
            this.label17.Size = new Size(0x16d, 12);
            this.label17.TabIndex = 0x36;
            this.label17.Text = "若第六年底仍有未还贷款，除去原先40M外每1M企业发展得分扣1分。";
            this.label16.AutoSize = true;
            this.label16.ForeColor = Color.Red;
            this.label16.Location = new Point(10, 0xe1);
            this.label16.Name = "label16";
            this.label16.Size = new Size(0xdd, 12);
            this.label16.TabIndex = 0x37;
            this.label16.Text = "若不足40M则每缺1M企业发展得分加1分。";
            base.AcceptButton = this.button1;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x182, 250);
            base.Controls.Add(this.label16);
            base.Controls.Add(this.label17);
            base.Controls.Add(this.button1);
            base.Controls.Add(this.groupBox3);
            base.FormBorderStyle = FormBorderStyle.FixedDialog;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "frmShowLongTermLoans";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "查看长期贷款明细";
            base.Load += new EventHandler(this.frmShowLongTermLoans_Load);
            this.groupBox3.ResumeLayout(false);
            ((ISupportInitialize) this.dataGridViewCQDK).EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }
    }
}

