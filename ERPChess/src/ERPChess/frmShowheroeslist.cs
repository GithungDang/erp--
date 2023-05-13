namespace ERPChess
{
    using BusinessTier;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmShowheroeslist : Form
    {
        private IContainer components;
        private GroupBox groupBox1;
        private DataGridView dataGridViewCKYXB;
        private Button button1;
        private GroupBox groupBox2;
        private Label label1;
        private TextBox textBoxActor;
        private Label labelNO;
        private Button button2;
        private Label labelTime;
        private Label labelMaxRecord;
        private DataGridViewTextBoxColumn 名次;
        private DataGridViewTextBoxColumn 决策者;
        private DataGridViewTextBoxColumn 最高记录;
        private DataGridViewTextBoxColumn 创立时间;
        private Label labelActor;
        private TScoreRecord[] herolist;

        public frmShowheroeslist()
        {
            this.InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string str = this.textBoxActor.Text.Trim();
            if (string.IsNullOrEmpty(str))
            {
                MessageBox.Show("请输入决策者名称", "特别提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.textBoxActor.Focus();
            }
            else
            {
                string str2 = "";
                string str3 = "";
                string str4 = "";
                if (this.herolist != null)
                {
                    for (int i = 0; i < this.herolist.Length; i++)
                    {
                        if (str == this.herolist[i].Actor)
                        {
                            str2 = (i + 1).ToString();
                            str3 = this.herolist[i].MaxScore.ToString();
                            str4 = this.herolist[i].FinishedTime.ToShortDateString() + " " + this.herolist[i].FinishedTime.ToLongTimeString();
                            break;
                        }
                    }
                }
                if (str2 == "")
                {
                    MessageBox.Show(" 没有要查找的决策者记录 ", "特别提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    str = " ";
                }
                this.labelActor.Text = "决策者:  " + str;
                this.labelNO.Text = "所排名次:" + str2;
                this.labelMaxRecord.Text = "最高记录:" + str3;
                this.labelTime.Text = "创立时间:" + str4;
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

        private void frmShowheroeslist_Load(object sender, EventArgs e)
        {
            this.herolist = TGlobals.dbControl.GetHeroList("降序记录");
            if (this.herolist != null)
            {
                int length = this.herolist.Length;
                if (length <= 15)
                {
                    this.dataGridViewCKYXB.Rows.Clear();
                    this.dataGridViewCKYXB.RowCount = length;
                    for (int j = 0; j < length; j++)
                    {
                        this.dataGridViewCKYXB.Rows[j].Cells["名次"].Value = j + 1;
                        this.dataGridViewCKYXB.Rows[j].Cells["决策者"].Value = this.herolist[j].Actor;
                        this.dataGridViewCKYXB.Rows[j].Cells["最高记录"].Value = this.herolist[j].MaxScore;
                        this.dataGridViewCKYXB.Rows[j].Cells["创立时间"].Value = this.herolist[j].FinishedTime;
                    }
                }
                else
                {
                    this.dataGridViewCKYXB.Rows.Clear();
                    this.dataGridViewCKYXB.RowCount = 15;
                    for (int j = 0; j < 15; j++)
                    {
                        this.dataGridViewCKYXB.Rows[j].Cells["名次"].Value = j + 1;
                        this.dataGridViewCKYXB.Rows[j].Cells["决策者"].Value = this.herolist[j].Actor;
                        this.dataGridViewCKYXB.Rows[j].Cells["最高记录"].Value = this.herolist[j].MaxScore;
                        this.dataGridViewCKYXB.Rows[j].Cells["创立时间"].Value = this.herolist[j].FinishedTime;
                    }
                }
            }
            string actorName = TGlobals.currentActor.ActorName;
            for (int i = 0; i < this.dataGridViewCKYXB.RowCount; i++)
            {
                if (this.dataGridViewCKYXB.Rows[i].Cells["决策者"].Value.ToString() == actorName)
                {
                    this.dataGridViewCKYXB.Rows[i].Selected = true;
                }
            }
            string str2 = "";
            string str3 = "";
            string str4 = "";
            if (this.herolist != null)
            {
                for (int j = 0; j < this.herolist.Length; j++)
                {
                    if (actorName == this.herolist[j].Actor)
                    {
                        str2 = (j + 1).ToString();
                        str3 = this.herolist[j].MaxScore.ToString();
                        str4 = this.herolist[j].FinishedTime.ToShortDateString() + " " + this.herolist[j].FinishedTime.ToLongTimeString();
                        break;
                    }
                }
            }
            if (str2 == "")
            {
                actorName = " ";
            }
            this.labelActor.Text = "决策者:  " + actorName;
            this.labelNO.Text = "所排名次:" + str2;
            this.labelMaxRecord.Text = "最高记录:" + str3;
            this.labelTime.Text = "创立时间:" + str4;
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            DataGridViewCellStyle style2 = new DataGridViewCellStyle();
            DataGridViewCellStyle style3 = new DataGridViewCellStyle();
            DataGridViewCellStyle style4 = new DataGridViewCellStyle();
            this.groupBox1 = new GroupBox();
            this.dataGridViewCKYXB = new DataGridView();
            this.名次 = new DataGridViewTextBoxColumn();
            this.决策者 = new DataGridViewTextBoxColumn();
            this.最高记录 = new DataGridViewTextBoxColumn();
            this.创立时间 = new DataGridViewTextBoxColumn();
            this.button1 = new Button();
            this.groupBox2 = new GroupBox();
            this.labelActor = new Label();
            this.button2 = new Button();
            this.labelTime = new Label();
            this.labelMaxRecord = new Label();
            this.labelNO = new Label();
            this.textBoxActor = new TextBox();
            this.label1 = new Label();
            this.groupBox1.SuspendLayout();
            ((ISupportInitialize) this.dataGridViewCKYXB).BeginInit();
            this.groupBox2.SuspendLayout();
            base.SuspendLayout();
            this.groupBox1.Controls.Add(this.dataGridViewCKYXB);
            this.groupBox1.Location = new Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x1b2, 0x12e);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "英雄榜";
            this.dataGridViewCKYXB.AllowUserToAddRows = false;
            this.dataGridViewCKYXB.AllowUserToDeleteRows = false;
            this.dataGridViewCKYXB.AllowUserToResizeRows = false;
            this.dataGridViewCKYXB.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridViewColumn[] dataGridViewColumns = new DataGridViewColumn[] { this.名次, this.决策者, this.最高记录, this.创立时间 };
            this.dataGridViewCKYXB.Columns.AddRange(dataGridViewColumns);
            this.dataGridViewCKYXB.Dock = DockStyle.Fill;
            this.dataGridViewCKYXB.Location = new Point(3, 0x11);
            this.dataGridViewCKYXB.MultiSelect = false;
            this.dataGridViewCKYXB.Name = "dataGridViewCKYXB";
            this.dataGridViewCKYXB.ReadOnly = true;
            this.dataGridViewCKYXB.RowHeadersVisible = false;
            this.dataGridViewCKYXB.RowTemplate.Height = 0x17;
            this.dataGridViewCKYXB.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCKYXB.Size = new Size(0x1ac, 0x11a);
            this.dataGridViewCKYXB.TabIndex = 0x4e;
            style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.名次.DefaultCellStyle = style;
            this.名次.HeaderText = "名次";
            this.名次.Name = "名次";
            this.名次.ReadOnly = true;
            this.名次.Resizable = DataGridViewTriState.False;
            this.名次.Width = 70;
            style2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.决策者.DefaultCellStyle = style2;
            this.决策者.HeaderText = "决策者";
            this.决策者.Name = "决策者";
            this.决策者.ReadOnly = true;
            this.决策者.Resizable = DataGridViewTriState.False;
            this.决策者.Width = 0x4b;
            style3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.最高记录.DefaultCellStyle = style3;
            this.最高记录.HeaderText = "最高记录";
            this.最高记录.Name = "最高记录";
            this.最高记录.ReadOnly = true;
            this.最高记录.Resizable = DataGridViewTriState.False;
            style4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.创立时间.DefaultCellStyle = style4;
            this.创立时间.HeaderText = "创立时间";
            this.创立时间.Name = "创立时间";
            this.创立时间.ReadOnly = true;
            this.创立时间.Resizable = DataGridViewTriState.False;
            this.创立时间.Width = 150;
            this.button1.DialogResult = DialogResult.OK;
            this.button1.Location = new Point(0x236, 0x142);
            this.button1.Name = "button1";
            this.button1.Size = new Size(0x4b, 0x17);
            this.button1.TabIndex = 0;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.groupBox2.Controls.Add(this.labelActor);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.labelTime);
            this.groupBox2.Controls.Add(this.labelMaxRecord);
            this.groupBox2.Controls.Add(this.labelNO);
            this.groupBox2.Controls.Add(this.textBoxActor);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new Point(0x1c4, 0x11);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(210, 0x12b);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "决策者查询";
            this.labelActor.AutoSize = true;
            this.labelActor.Location = new Point(0x11, 0x6d);
            this.labelActor.Name = "labelActor";
            this.labelActor.Size = new Size(0x35, 12);
            this.labelActor.TabIndex = 5;
            this.labelActor.Text = " 决策者:";
            this.button2.Location = new Point(0x77, 0x47);
            this.button2.Name = "button2";
            this.button2.Size = new Size(0x4b, 0x17);
            this.button2.TabIndex = 3;
            this.button2.Text = "查询";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new EventHandler(this.button2_Click);
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new Point(0x11, 0xc9);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new Size(0x3b, 12);
            this.labelTime.TabIndex = 4;
            this.labelTime.Text = "创立时间:";
            this.labelMaxRecord.AutoSize = true;
            this.labelMaxRecord.Location = new Point(0x11, 170);
            this.labelMaxRecord.Name = "labelMaxRecord";
            this.labelMaxRecord.Size = new Size(0x3b, 12);
            this.labelMaxRecord.TabIndex = 3;
            this.labelMaxRecord.Text = "最高记录:";
            this.labelNO.AutoSize = true;
            this.labelNO.Location = new Point(0x11, 0x8d);
            this.labelNO.Name = "labelNO";
            this.labelNO.Size = new Size(0x3b, 12);
            this.labelNO.TabIndex = 2;
            this.labelNO.Text = "所排名次:";
            this.textBoxActor.Location = new Point(0x13, 0x2c);
            this.textBoxActor.Name = "textBoxActor";
            this.textBoxActor.Size = new Size(0xaf, 0x15);
            this.textBoxActor.TabIndex = 1;
            this.label1.AutoSize = true;
            this.label1.Location = new Point(0x11, 0x1d);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "决策者";
            base.AcceptButton = this.button1;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x2a6, 350);
            base.Controls.Add(this.groupBox2);
            base.Controls.Add(this.button1);
            base.Controls.Add(this.groupBox1);
            base.FormBorderStyle = FormBorderStyle.FixedDialog;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "frmShowheroeslist";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "查看英雄榜";
            base.Load += new EventHandler(this.frmShowheroeslist_Load);
            this.groupBox1.ResumeLayout(false);
            ((ISupportInitialize) this.dataGridViewCKYXB).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            base.ResumeLayout(false);
        }
    }
}

