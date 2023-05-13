namespace ERPChess
{
    using BusinessTier;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmShowShortTermLoans : Form
    {
        private IContainer components;
        private GroupBox groupBox3;
        private DataGridView dataGridViewCJDHH;
        private DataGridViewTextBoxColumn 贷款时间;
        private DataGridViewTextBoxColumn 还款时间;
        private DataGridViewTextBoxColumn 贷款金额;
        private DataGridViewTextBoxColumn 支付利息;
        private Button button1;
        private Label label11;

        public frmShowShortTermLoans()
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

        private void frmShowShortTermLoans_Load(object sender, EventArgs e)
        {
            TShortTermLoans[] notAlsoLoansList = TGlobals.currentActor.ShortTermLoanConditions.GetNotAlsoLoansList();
            if (notAlsoLoansList == null)
            {
                this.dataGridViewCJDHH.Rows.Clear();
            }
            else
            {
                this.dataGridViewCJDHH.Rows.Clear();
                this.dataGridViewCJDHH.RowCount = notAlsoLoansList.Length;
                for (int i = 0; i < notAlsoLoansList.Length; i++)
                {
                    this.dataGridViewCJDHH.Rows[i].Cells["贷款时间"].Value = notAlsoLoansList[i].LoanTime;
                    this.dataGridViewCJDHH.Rows[i].Cells["还款时间"].Value = notAlsoLoansList[i].PaymentTime;
                    this.dataGridViewCJDHH.Rows[i].Cells["贷款金额"].Value = notAlsoLoansList[i].LoanAmount;
                    this.dataGridViewCJDHH.Rows[i].Cells["支付利息"].Value = notAlsoLoansList[i].Interest;
                }
            }
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            this.groupBox3 = new GroupBox();
            this.dataGridViewCJDHH = new DataGridView();
            this.贷款时间 = new DataGridViewTextBoxColumn();
            this.还款时间 = new DataGridViewTextBoxColumn();
            this.贷款金额 = new DataGridViewTextBoxColumn();
            this.支付利息 = new DataGridViewTextBoxColumn();
            this.button1 = new Button();
            this.label11 = new Label();
            this.groupBox3.SuspendLayout();
            ((ISupportInitialize) this.dataGridViewCJDHH).BeginInit();
            base.SuspendLayout();
            this.groupBox3.Controls.Add(this.dataGridViewCJDHH);
            this.groupBox3.Location = new Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new Size(0x164, 0xb7);
            this.groupBox3.TabIndex = 13;
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
            this.dataGridViewCJDHH.Location = new Point(7, 20);
            this.dataGridViewCJDHH.MultiSelect = false;
            this.dataGridViewCJDHH.Name = "dataGridViewCJDHH";
            this.dataGridViewCJDHH.ReadOnly = true;
            this.dataGridViewCJDHH.RowHeadersVisible = false;
            this.dataGridViewCJDHH.RowTemplate.Height = 0x17;
            this.dataGridViewCJDHH.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCJDHH.Size = new Size(0x157, 0x9d);
            this.dataGridViewCJDHH.TabIndex = 12;
            this.贷款时间.HeaderText = "贷款时间";
            this.贷款时间.Name = "贷款时间";
            this.贷款时间.ReadOnly = true;
            this.贷款时间.Width = 0x4e;
            this.还款时间.HeaderText = "还款时间";
            this.还款时间.Name = "还款时间";
            this.还款时间.ReadOnly = true;
            this.还款时间.Width = 0x4e;
            this.贷款金额.HeaderText = "贷款金额";
            this.贷款金额.Name = "贷款金额";
            this.贷款金额.ReadOnly = true;
            this.贷款金额.Width = 0x4e;
            this.支付利息.HeaderText = "支付利息";
            this.支付利息.Name = "支付利息";
            this.支付利息.ReadOnly = true;
            this.支付利息.Width = 0x4e;
            this.button1.DialogResult = DialogResult.OK;
            this.button1.Location = new Point(0x125, 0xc7);
            this.button1.Name = "button1";
            this.button1.Size = new Size(0x4b, 0x17);
            this.button1.TabIndex = 0;
            this.button1.Text = "完成";
            this.button1.UseVisualStyleBackColor = true;
            this.label11.AutoSize = true;
            this.label11.ForeColor = Color.Red;
            this.label11.Location = new Point(12, 0xcc);
            this.label11.Name = "label11";
            this.label11.Size = new Size(0x113, 12);
            this.label11.TabIndex = 0x31;
            this.label11.Text = "若第六年底仍有未还贷款每1M企业发展得分扣1分。";
            base.AcceptButton = this.button1;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x17d, 0xe4);
            base.Controls.Add(this.label11);
            base.Controls.Add(this.button1);
            base.Controls.Add(this.groupBox3);
            base.FormBorderStyle = FormBorderStyle.FixedDialog;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "frmShowShortTermLoans";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "查看短期贷款明细";
            base.Load += new EventHandler(this.frmShowShortTermLoans_Load);
            this.groupBox3.ResumeLayout(false);
            ((ISupportInitialize) this.dataGridViewCJDHH).EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }
    }
}

