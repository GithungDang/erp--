namespace ERPChess
{
    using BusinessTier;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmCJDHH : Form
    {
        private IContainer components;
        private TabControl tabControl1;
        private TabPage tabPageTFGG;
        private TabPage tabPageSCJD;
        private Label label6;
        private Label label3;
        private Label label4;
        private Label labelAvalue;
        private Label label5;
        private Label label2;
        private Label label1;
        private NumericUpDown numericUpDown00;
        private NumericUpDown numericUpDown10;
        private NumericUpDown numericUpDown20;
        private NumericUpDown numericUpDown31;
        private NumericUpDown numericUpDown21;
        private NumericUpDown numericUpDown11;
        private NumericUpDown numericUpDown01;
        private NumericUpDown numericUpDown30;
        private NumericUpDown numericUpDown32;
        private NumericUpDown numericUpDown22;
        private NumericUpDown numericUpDown12;
        private NumericUpDown numericUpDown02;
        private Label label7;
        private NumericUpDown numericUpDown33;
        private NumericUpDown numericUpDown23;
        private NumericUpDown numericUpDown13;
        private NumericUpDown numericUpDown03;
        private Label label8;
        private NumericUpDown numericUpDown34;
        private NumericUpDown numericUpDown24;
        private NumericUpDown numericUpDown14;
        private NumericUpDown numericUpDown04;
        private Label label9;
        private Button buttonTFGG;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private NumericUpDown numericUpDown14000;
        private NumericUpDown numericUpDown9000;
        private GroupBox groupBox3;
        private Label label10;
        private RichTextBox richTextBox2;
        private Panel panel2;
        private Panel panel1;
        private GroupBox groupBox5;
        private Button buttonGiveUp;
        private Button buttonOK;
        private Button buttonInternational;
        private Button buttonAsia;
        private Button buttonDomestic;
        private Button buttonRegional;
        private Button buttonLocal;
        private RichTextBox richTextBoxMeetingInfor;
        private DataGridView dataGridViewCJDHH;
        private Button button8;
        private Button buttonFinish;
        private DataGridViewTextBoxColumn 编号;
        private DataGridViewTextBoxColumn 产品;
        private DataGridViewTextBoxColumn 数量;
        private DataGridViewTextBoxColumn 单价;
        private DataGridViewTextBoxColumn 金额;
        private DataGridViewTextBoxColumn 账期;
        private DataGridViewTextBoxColumn ISO;
        private DataGridViewTextBoxColumn 成本;
        private DataGridViewTextBoxColumn 利润;
        private Label labelGJNO1;
        private Label labelYZNO1;
        private Label labelGNNO1;
        private Label labelQYNO1;
        private Label labelBDNO1;
        private Label label11;
        private TAdvertising[,] advertisingTable = new TAdvertising[4, 5];
        private TAdvertising adv9000 = new TAdvertising(false, 0);
        private TAdvertising adv14000 = new TAdvertising(false, 0);
        private bool finish;
        private bool selectOrderFlag;
        private int startID;
        private Market currentMarket;
        private TOrder[] currentOrders;
        private int advCost;
        private bool isGiveup;
        private int TP1C;
        private int TP2C;
        private int TP3C;
        private int TP4C;
        private ArrayList LocalOrderBy = new ArrayList();
        private ArrayList RegionalOrderBy = new ArrayList();
        private ArrayList DomesticOrderBy = new ArrayList();
        private ArrayList AsiaOrderBy = new ArrayList();
        private ArrayList InternationalOrderBy = new ArrayList();

        public frmCJDHH()
        {
            this.InitializeComponent();
        }

        private unsafe void button_Click(object sender, EventArgs e)
        {
            string text = ((Button) sender).Text;
            if (text != null)
            {
                int num19;
                if (<PrivateImplementationDetails>{FAF84281-B764-49BB-8026-1DA8F9FEA525}.$$method0x6000048-1 == null)
                {
                    Dictionary<string, int> dictionary1 = new Dictionary<string, int>(10);
                    dictionary1.Add("确认投放", 0);
                    dictionary1.Add("本地市场竞单", 1);
                    dictionary1.Add("区域市场竞单", 2);
                    dictionary1.Add("国内市场竞单", 3);
                    dictionary1.Add("亚洲市场竞单", 4);
                    dictionary1.Add("国际市场竞单", 5);
                    dictionary1.Add("确定订单", 6);
                    dictionary1.Add("放弃订单", 7);
                    dictionary1.Add("放弃投放", 8);
                    dictionary1.Add("订货会结束", 9);
                    <PrivateImplementationDetails>{FAF84281-B764-49BB-8026-1DA8F9FEA525}.$$method0x6000048-1 = dictionary1;
                }
                if (<PrivateImplementationDetails>{FAF84281-B764-49BB-8026-1DA8F9FEA525}.$$method0x6000048-1.TryGetValue(text, out num19))
                {
                    switch (num19)
                    {
                        case 0:
                        {
                            bool flag = false;
                            bool flag2 = false;
                            bool flag3 = false;
                            bool flag4 = false;
                            bool flag5 = false;
                            bool flag6 = false;
                            bool[,] flagArray = new bool[4, 5];
                            int num = 0;
                            while (true)
                            {
                                if (num >= 4)
                                {
                                    if ((TGlobals.currentActor.RunningYear == Year.第1年) && (this.advertisingTable[0, 0].Cost == 0))
                                    {
                                        MessageBox.Show("第一年在本地市场必须投入广告！", "特别提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        return;
                                    }
                                    int[] numArray = new int[5];
                                    int index = 0;
                                    while (true)
                                    {
                                        if (index >= numArray.Length)
                                        {
                                            int num4 = 0;
                                            while (true)
                                            {
                                                if (num4 >= 5)
                                                {
                                                    int num6 = 0;
                                                    int num7 = 0;
                                                    while (true)
                                                    {
                                                        if (num7 >= numArray.Length)
                                                        {
                                                            if (((num6 + this.adv9000.Cost) + this.adv14000.Cost) > TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.CurrentCash)
                                                            {
                                                                MessageBox.Show("广告投入超出现金支付范围！", "重要提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                                                this.numericUpDown00.Focus();
                                                                return;
                                                            }
                                                            string str3 = "";
                                                            if (TGlobals.currentActor.IsEnterRegionalMarket && (numArray[1] == 0))
                                                            {
                                                                str3 = str3 + "具有进入区域市场的资格而未对其投入视为今后放弃该市场！\n";
                                                                flag = true;
                                                            }
                                                            if (TGlobals.currentActor.IsEnterDomesticMarket && (numArray[2] == 0))
                                                            {
                                                                str3 = str3 + "具有进入国内市场的资格而未对其投入视为今后放弃该市场！\n";
                                                                flag2 = true;
                                                            }
                                                            if (TGlobals.currentActor.IsEnterAsiaMarket && (numArray[3] == 0))
                                                            {
                                                                str3 = str3 + "具有进入亚洲市场的资格而未对其投入视为今后放弃该市场！\n";
                                                                flag3 = true;
                                                            }
                                                            if (TGlobals.currentActor.IsEnterInternationalMarket && (numArray[4] == 0))
                                                            {
                                                                str3 = str3 + "具有进入国际市场的资格而未对其投入视为今后放弃该市场！\n";
                                                                flag4 = true;
                                                            }
                                                            int i = 0;
                                                            while (true)
                                                            {
                                                                if (i >= 4)
                                                                {
                                                                    if (this.adv9000.Eligibility && (this.adv9000.Cost == 0))
                                                                    {
                                                                        str3 = str3 + "未为ISO9000投入广告，故今年不可选要求ISO9000的订单！\n";
                                                                        flag5 = true;
                                                                    }
                                                                    if (this.adv14000.Eligibility && (this.adv14000.Cost == 0))
                                                                    {
                                                                        str3 = str3 + "未为ISO14000投入广告，故今年不可选要求ISO14000的订单！\n";
                                                                        flag6 = true;
                                                                    }
                                                                    if (str3 == "")
                                                                    {
                                                                        this.tabControl1.TabPages.Remove(this.tabPageTFGG);
                                                                        this.tabControl1.TabPages.Add(this.tabPageSCJD);
                                                                        TGlobals.currentActor.AdvCostLocalMarket = numArray[0];
                                                                        TGlobals.currentActor.AdvCostRegionalMarket = numArray[1];
                                                                        TGlobals.currentActor.AdvCostDomesticMarket = numArray[2];
                                                                        TGlobals.currentActor.AdvCostAsiaMarket = numArray[3];
                                                                        TGlobals.currentActor.AdvCostInternationalMarket = numArray[4];
                                                                        TGlobals.currentActor.AdvCostISO9000 = this.adv9000.Cost;
                                                                        TGlobals.currentActor.AdvCostISO14000 = this.adv14000.Cost;
                                                                        TGlobals.currentActor.CurrBusinessConditions.ComprehensiveCostSheet.Advertisement = TGlobals.currentActor.GetAdvTatalCostOfYear(TGlobals.currentActor.RunningYear);
                                                                        TOperatingSheet sheet2 = TGlobals.currentActor.CurrBusinessConditions.OperatingSheet;
                                                                        sheet2.CurrentCash -= TGlobals.currentActor.GetAdvTatalCostOfYear(TGlobals.currentActor.RunningYear);
                                                                        this.SetLocalOrderBy();
                                                                        this.SetRegionalOrderBy();
                                                                        this.SetDomesticOrderBy();
                                                                        this.SetAsiaOrderBy();
                                                                        this.SetInternationalOrderBy();
                                                                        this.richTextBoxMeetingInfor.AppendText("\n点击\"各级市场竞单\"按钮开始竞单!");
                                                                        this.buttonLocal.Enabled = true;
                                                                        this.richTextBoxMeetingInfor.Focus();
                                                                        return;
                                                                    }
                                                                    if (MessageBox.Show(str3, "特别提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) != DialogResult.OK)
                                                                    {
                                                                        break;
                                                                    }
                                                                    if (flag)
                                                                    {
                                                                        TGlobals.currentActor.JRQYCost = 0;
                                                                    }
                                                                    if (flag2)
                                                                    {
                                                                        TGlobals.currentActor.JRGNCost = 0;
                                                                    }
                                                                    if (flag3)
                                                                    {
                                                                        TGlobals.currentActor.JRYZCost = 0;
                                                                    }
                                                                    if (flag4)
                                                                    {
                                                                        TGlobals.currentActor.JRGJCost = 0;
                                                                    }
                                                                    int num10 = 0;
                                                                    while (num10 < 4)
                                                                    {
                                                                        int num11 = 0;
                                                                        while (true)
                                                                        {
                                                                            if (num11 >= 5)
                                                                            {
                                                                                num10++;
                                                                                break;
                                                                            }
                                                                            if (flagArray[num10, num11])
                                                                            {
                                                                                this.advertisingTable[num10, num11].Eligibility = false;
                                                                            }
                                                                            num11++;
                                                                        }
                                                                    }
                                                                    if (flag5)
                                                                    {
                                                                        this.adv9000.Eligibility = false;
                                                                    }
                                                                    if (flag6)
                                                                    {
                                                                        this.adv14000.Eligibility = false;
                                                                    }
                                                                    this.tabControl1.TabPages.Remove(this.tabPageTFGG);
                                                                    this.tabControl1.TabPages.Add(this.tabPageSCJD);
                                                                    TGlobals.currentActor.AdvCostLocalMarket = numArray[0];
                                                                    TGlobals.currentActor.AdvCostRegionalMarket = numArray[1];
                                                                    TGlobals.currentActor.AdvCostDomesticMarket = numArray[2];
                                                                    TGlobals.currentActor.AdvCostAsiaMarket = numArray[3];
                                                                    TGlobals.currentActor.AdvCostInternationalMarket = numArray[4];
                                                                    TGlobals.currentActor.AdvCostISO9000 = this.adv9000.Cost;
                                                                    TGlobals.currentActor.AdvCostISO14000 = this.adv14000.Cost;
                                                                    TGlobals.currentActor.CurrBusinessConditions.ComprehensiveCostSheet.Advertisement = TGlobals.currentActor.GetAdvTatalCostOfYear(TGlobals.currentActor.RunningYear);
                                                                    TOperatingSheet operatingSheet = TGlobals.currentActor.CurrBusinessConditions.OperatingSheet;
                                                                    operatingSheet.CurrentCash -= TGlobals.currentActor.GetAdvTatalCostOfYear(TGlobals.currentActor.RunningYear);
                                                                    this.SetLocalOrderBy();
                                                                    this.SetRegionalOrderBy();
                                                                    this.SetDomesticOrderBy();
                                                                    this.SetAsiaOrderBy();
                                                                    this.SetInternationalOrderBy();
                                                                    this.richTextBoxMeetingInfor.AppendText("\n点击\"各级市场竞单\"按钮开始竞单!");
                                                                    this.buttonLocal.Enabled = true;
                                                                    this.richTextBoxMeetingInfor.Focus();
                                                                    return;
                                                                }
                                                                int j = 0;
                                                                while (true)
                                                                {
                                                                    if (j >= 5)
                                                                    {
                                                                        i++;
                                                                        break;
                                                                    }
                                                                    if (this.advertisingTable[i, j].Eligibility && (this.advertisingTable[i, j].Cost == 0))
                                                                    {
                                                                        str3 = str3 + this.GetEmptyAdvertisingInfor(i, j) + "\n";
                                                                        flagArray[i, j] = true;
                                                                    }
                                                                    j++;
                                                                }
                                                            }
                                                            break;
                                                        }
                                                        num6 += numArray[num7];
                                                        num7++;
                                                    }
                                                    break;
                                                }
                                                int num5 = 0;
                                                while (true)
                                                {
                                                    if (num5 >= 4)
                                                    {
                                                        num4++;
                                                        break;
                                                    }
                                                    int* numPtr1 = &(numArray[num4]);
                                                    numPtr1[0] += this.advertisingTable[num5, num4].Cost;
                                                    num5++;
                                                }
                                            }
                                            break;
                                        }
                                        numArray[index] = 0;
                                        index++;
                                    }
                                    break;
                                }
                                int num2 = 0;
                                while (true)
                                {
                                    if (num2 >= 5)
                                    {
                                        num++;
                                        break;
                                    }
                                    flagArray[num, num2] = false;
                                    num2++;
                                }
                            }
                            break;
                        }
                        case 1:
                            this.startID = 0;
                            this.currentMarket = Market.本地;
                            this.advCost = TGlobals.currentActor.AdvCostLocalMarket;
                            this.TP1C = this.advertisingTable[this.LocateProductID(ProductAttribute.P1), this.LocateMarketID(this.currentMarket)].Cost;
                            this.TP2C = this.advertisingTable[this.LocateProductID(ProductAttribute.P2), this.LocateMarketID(this.currentMarket)].Cost;
                            this.TP3C = this.advertisingTable[this.LocateProductID(ProductAttribute.P3), this.LocateMarketID(this.currentMarket)].Cost;
                            this.TP4C = this.advertisingTable[this.LocateProductID(ProductAttribute.P4), this.LocateMarketID(this.currentMarket)].Cost;
                            this.StartSelectOrder(this.currentMarket);
                            return;

                        case 2:
                            this.startID = 0;
                            this.currentMarket = Market.区域;
                            this.advCost = TGlobals.currentActor.AdvCostRegionalMarket;
                            this.GetOrders(TGlobals.currentActor.RunningYear, this.currentMarket);
                            this.TP1C = this.advertisingTable[this.LocateProductID(ProductAttribute.P1), this.LocateMarketID(this.currentMarket)].Cost;
                            this.TP2C = this.advertisingTable[this.LocateProductID(ProductAttribute.P2), this.LocateMarketID(this.currentMarket)].Cost;
                            this.TP3C = this.advertisingTable[this.LocateProductID(ProductAttribute.P3), this.LocateMarketID(this.currentMarket)].Cost;
                            this.TP4C = this.advertisingTable[this.LocateProductID(ProductAttribute.P4), this.LocateMarketID(this.currentMarket)].Cost;
                            this.StartSelectOrder(this.currentMarket);
                            return;

                        case 3:
                            this.startID = 0;
                            this.currentMarket = Market.国内;
                            this.advCost = TGlobals.currentActor.AdvCostDomesticMarket;
                            this.GetOrders(TGlobals.currentActor.RunningYear, this.currentMarket);
                            this.TP1C = this.advertisingTable[this.LocateProductID(ProductAttribute.P1), this.LocateMarketID(this.currentMarket)].Cost;
                            this.TP2C = this.advertisingTable[this.LocateProductID(ProductAttribute.P2), this.LocateMarketID(this.currentMarket)].Cost;
                            this.TP3C = this.advertisingTable[this.LocateProductID(ProductAttribute.P3), this.LocateMarketID(this.currentMarket)].Cost;
                            this.TP4C = this.advertisingTable[this.LocateProductID(ProductAttribute.P4), this.LocateMarketID(this.currentMarket)].Cost;
                            this.StartSelectOrder(this.currentMarket);
                            return;

                        case 4:
                            this.startID = 0;
                            this.currentMarket = Market.亚洲;
                            this.advCost = TGlobals.currentActor.AdvCostAsiaMarket;
                            this.GetOrders(TGlobals.currentActor.RunningYear, this.currentMarket);
                            this.TP1C = this.advertisingTable[this.LocateProductID(ProductAttribute.P1), this.LocateMarketID(this.currentMarket)].Cost;
                            this.TP2C = this.advertisingTable[this.LocateProductID(ProductAttribute.P2), this.LocateMarketID(this.currentMarket)].Cost;
                            this.TP3C = this.advertisingTable[this.LocateProductID(ProductAttribute.P3), this.LocateMarketID(this.currentMarket)].Cost;
                            this.TP4C = this.advertisingTable[this.LocateProductID(ProductAttribute.P4), this.LocateMarketID(this.currentMarket)].Cost;
                            this.StartSelectOrder(this.currentMarket);
                            return;

                        case 5:
                            this.startID = 0;
                            this.currentMarket = Market.国际;
                            this.advCost = TGlobals.currentActor.AdvCostInternationalMarket;
                            this.GetOrders(TGlobals.currentActor.RunningYear, this.currentMarket);
                            this.TP1C = this.advertisingTable[this.LocateProductID(ProductAttribute.P1), this.LocateMarketID(this.currentMarket)].Cost;
                            this.TP2C = this.advertisingTable[this.LocateProductID(ProductAttribute.P2), this.LocateMarketID(this.currentMarket)].Cost;
                            this.TP3C = this.advertisingTable[this.LocateProductID(ProductAttribute.P3), this.LocateMarketID(this.currentMarket)].Cost;
                            this.TP4C = this.advertisingTable[this.LocateProductID(ProductAttribute.P4), this.LocateMarketID(this.currentMarket)].Cost;
                            this.StartSelectOrder(this.currentMarket);
                            return;

                        case 6:
                        {
                            if (this.dataGridViewCJDHH.SelectedRows.Count == 0)
                            {
                                MessageBox.Show("在确认订单之前需要先选择订单!", "重要提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                return;
                            }
                            string str4 = this.dataGridViewCJDHH.SelectedRows[0].Cells["编号"].Value.ToString();
                            TOrder order = null;
                            int index = 0;
                            while (true)
                            {
                                if (index >= this.currentOrders.Length)
                                {
                                    Market market = order.Market;
                                    ProductAttribute productName = order.ProductName;
                                    ISOQualify iSOQulify = order.ISOQulify;
                                    if (!this.advertisingTable[this.LocateProductID(productName), this.LocateMarketID(market)].Eligibility)
                                    {
                                        MessageBox.Show("没有在" + market.ToString() + "市场,对" + productName.ToString() + "产品投放广告,故不能选择此订单!", "重要提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                        return;
                                    }
                                    if (iSOQulify != ISOQualify.无)
                                    {
                                        if ((iSOQulify == ISOQualify.ISO9000) && !this.adv9000.Eligibility)
                                        {
                                            MessageBox.Show("该订单需要ISO9000资格,但并未在此资格上投放广告,故不能选择此订单!", "重要提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                            return;
                                        }
                                        if ((iSOQulify == ISOQualify.ISO14000) && !this.adv14000.Eligibility)
                                        {
                                            MessageBox.Show("该订单需要ISO14000资格,但并未在此资格上投放广告,故不能选择此订单!", "重要提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                            return;
                                        }
                                    }
                                    if (this.advCost <= 0)
                                    {
                                        MessageBox.Show("投放广告的费用已经用完,选择\"放弃订单\"按钮放弃对该市场订单的选择", "重要提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                        this.buttonOK.Enabled = false;
                                        return;
                                    }
                                    object[] objArray = new object[] { "\n", TGlobals.currentActor.ActorName, "选择了编号为:", this.dataGridViewCJDHH.SelectedRows[0].Cells["编号"].Value, "的订单" };
                                    string str8 = string.Concat(objArray);
                                    object[] objArray2 = new object[] { "\n", TGlobals.currentActor.ActorName, "是否选择编号为:", this.dataGridViewCJDHH.SelectedRows[0].Cells["编号"].Value, "的订单?" };
                                    if (MessageBox.Show(string.Concat(objArray2), "重要提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                                    {
                                        break;
                                    }
                                    switch (productName)
                                    {
                                        case ProductAttribute.P1:
                                            if (this.TP1C < 1)
                                            {
                                                MessageBox.Show("对P1投放广告的费用已经用完,请选择其他订单!", "重要提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                                return;
                                            }
                                            if (this.TP1C == this.advertisingTable[this.LocateProductID(ProductAttribute.P1), this.LocateMarketID(this.currentMarket)].Cost)
                                            {
                                                this.TP1C--;
                                                this.advCost--;
                                            }
                                            else
                                            {
                                                if (this.TP1C == 1)
                                                {
                                                    MessageBox.Show("对P1投放广告的费用已经用完,请选择其他订单!", "重要提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                                    return;
                                                }
                                                this.TP1C -= 2;
                                                this.advCost -= 2;
                                            }
                                            break;

                                        case ProductAttribute.P2:
                                            if (this.TP2C < 1)
                                            {
                                                MessageBox.Show("对P2投放广告的费用已经用完,请选择其他订单!", "重要提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                                return;
                                            }
                                            if (this.TP2C == this.advertisingTable[this.LocateProductID(ProductAttribute.P2), this.LocateMarketID(this.currentMarket)].Cost)
                                            {
                                                this.TP2C--;
                                                this.advCost--;
                                            }
                                            else
                                            {
                                                if (this.TP2C == 1)
                                                {
                                                    MessageBox.Show("对P2投放广告的费用已经用完,请选择其他订单!", "重要提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                                    return;
                                                }
                                                this.TP2C -= 2;
                                                this.advCost -= 2;
                                            }
                                            break;

                                        case ProductAttribute.P3:
                                            if (this.TP3C < 1)
                                            {
                                                MessageBox.Show("对P3投放广告的费用已经用完,请选择其他订单!", "重要提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                                return;
                                            }
                                            if (this.TP3C == this.advertisingTable[this.LocateProductID(ProductAttribute.P3), this.LocateMarketID(this.currentMarket)].Cost)
                                            {
                                                this.TP3C--;
                                                this.advCost--;
                                            }
                                            else
                                            {
                                                if (this.TP3C == 1)
                                                {
                                                    MessageBox.Show("对P3投放广告的费用已经用完,请选择其他订单!", "重要提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                                    return;
                                                }
                                                this.TP3C -= 2;
                                                this.advCost -= 2;
                                            }
                                            break;

                                        case ProductAttribute.P4:
                                            if (this.TP4C < 1)
                                            {
                                                MessageBox.Show("对P4投放广告的费用已经用完,请选择其他订单!", "重要提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                                return;
                                            }
                                            if (this.TP4C == this.advertisingTable[this.LocateProductID(ProductAttribute.P4), this.LocateMarketID(this.currentMarket)].Cost)
                                            {
                                                this.TP4C--;
                                                this.advCost--;
                                            }
                                            else
                                            {
                                                if (this.TP4C == 1)
                                                {
                                                    MessageBox.Show("对P4投放广告的费用已经用完,请选择其他订单!", "重要提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                                    return;
                                                }
                                                this.TP4C -= 2;
                                                this.advCost -= 2;
                                            }
                                            break;

                                        default:
                                            break;
                                    }
                                    this.dataGridViewCJDHH.Rows.RemoveAt(this.dataGridViewCJDHH.SelectedRows[0].Index);
                                    this.richTextBoxMeetingInfor.AppendText(str8);
                                    this.richTextBoxMeetingInfor.Focus();
                                    this.buttonOK.Enabled = false;
                                    this.buttonGiveUp.Enabled = false;
                                    TGlobals.currentActor.AddOrderToPromisedList(order);
                                    this.StartSelectOrder(this.currentMarket);
                                    return;
                                }
                                if (this.currentOrders[index].OrderID == str4)
                                {
                                    order = this.currentOrders[index];
                                }
                                index++;
                            }
                            break;
                        }
                        case 7:
                            if (MessageBox.Show("放弃本次选单机会?", "重要提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                            {
                                break;
                            }
                            this.richTextBoxMeetingInfor.AppendText("\n" + TGlobals.currentActor.ActorName + "放弃本次选单");
                            this.isGiveup = true;
                            this.StartSelectOrder(this.currentMarket);
                            return;

                        case 8:
                            this.finish = true;
                            base.Close();
                            return;

                        case 9:
                        {
                            Year runningYear = TGlobals.currentActor.RunningYear;
                            int promidOrderAmount = TGlobals.currentActor.GetPromidOrderAmount(runningYear, Market.本地);
                            int num14 = TGlobals.currentActor.GetPromidOrderAmount(runningYear, Market.区域);
                            int num15 = TGlobals.currentActor.GetPromidOrderAmount(runningYear, Market.国内);
                            int num16 = TGlobals.currentActor.GetPromidOrderAmount(runningYear, Market.亚洲);
                            int num17 = TGlobals.currentActor.GetPromidOrderAmount(runningYear, Market.国际);
                            bool flag7 = true;
                            bool flag8 = true;
                            bool flag9 = true;
                            bool flag10 = true;
                            bool flag11 = true;
                            int index = 0;
                            while (true)
                            {
                                if (index >= TGlobals.computerPlayers.Length)
                                {
                                    TGlobals.currentActor.IsLocalMarkertLeader = flag7;
                                    TGlobals.currentActor.IsRegionalMarketLeader = flag8;
                                    TGlobals.currentActor.IsDomesticMarketLeader = flag9;
                                    TGlobals.currentActor.IsAsiaMarketLeader = flag10;
                                    TGlobals.currentActor.IsInternationalMarketLeader = flag11;
                                    if (TGlobals.currentActor.GetPromisedOrderList(TGlobals.currentActor.RunningYear) != null)
                                    {
                                        TGlobals.currentActor.CurrBusinessConditions.PromisedOrderSheet.OrderSet = TGlobals.currentActor.GetPromisedOrderList(TGlobals.currentActor.RunningYear);
                                    }
                                    this.finish = true;
                                    base.Close();
                                    break;
                                }
                                if (TGlobals.computerPlayers[index].IsLiving(runningYear))
                                {
                                    if (TGlobals.computerPlayers[index].LocalMarketAmount >= promidOrderAmount)
                                    {
                                        flag7 = false;
                                    }
                                    if (TGlobals.computerPlayers[index].RegionalMarketAmount >= num14)
                                    {
                                        flag8 = false;
                                    }
                                    if (TGlobals.computerPlayers[index].DomesticMarketAmount >= num15)
                                    {
                                        flag9 = false;
                                    }
                                    if (TGlobals.computerPlayers[index].AsiaMarketAmount >= num16)
                                    {
                                        flag10 = false;
                                    }
                                    if (TGlobals.computerPlayers[index].InternationalMarketAmount >= num17)
                                    {
                                        flag11 = false;
                                    }
                                }
                                index++;
                            }
                            break;
                        }
                        default:
                            return;
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

        private void frmCJDHH_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.finish)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void frmCJDHH_Load(object sender, EventArgs e)
        {
            this.labelBDNO1.Text = "";
            this.labelQYNO1.Text = "";
            this.labelGNNO1.Text = "";
            this.labelYZNO1.Text = "";
            this.labelGJNO1.Text = "";
            if (TGlobals.currentActor.IsEnterLocalMarket)
            {
                this.labelBDNO1.Text = "竞争者";
            }
            if (TGlobals.currentActor.IsEnterRegionalMarket)
            {
                this.labelQYNO1.Text = "竞争者";
            }
            if (TGlobals.currentActor.IsEnterDomesticMarket)
            {
                this.labelGNNO1.Text = "竞争者";
            }
            if (TGlobals.currentActor.IsEnterAsiaMarket)
            {
                this.labelYZNO1.Text = "竞争者";
            }
            if (TGlobals.currentActor.IsEnterInternationalMarket)
            {
                this.labelGJNO1.Text = "竞争者";
            }
            if (TGlobals.currentActor.IsLocalMarkertLeader)
            {
                this.labelBDNO1.Text = "领先者";
            }
            if (TGlobals.currentActor.IsRegionalMarketLeader)
            {
                this.labelQYNO1.Text = "领先者";
            }
            if (TGlobals.currentActor.IsDomesticMarketLeader)
            {
                this.labelGNNO1.Text = "领先者";
            }
            if (TGlobals.currentActor.IsAsiaMarketLeader)
            {
                this.labelYZNO1.Text = "领先者";
            }
            if (TGlobals.currentActor.IsInternationalMarketLeader)
            {
                this.labelGJNO1.Text = "领先者";
            }
            int num = 0;
            while (num < 4)
            {
                int num2 = 0;
                while (true)
                {
                    if (num2 >= 5)
                    {
                        num++;
                        break;
                    }
                    this.advertisingTable[num, num2] = new TAdvertising(false, 0);
                    num2++;
                }
            }
            this.IniNumericUpDown();
            this.tabControl1.TabPages.Remove(this.tabPageSCJD);
            string str = "";
            for (int i = 0; i < TGlobals.computerPlayers.Length; i++)
            {
                TGlobals.computerPlayers[i].LocalMarketAmount = 0;
                TGlobals.computerPlayers[i].RegionalMarketAmount = 0;
                TGlobals.computerPlayers[i].DomesticMarketAmount = 0;
                TGlobals.computerPlayers[i].AsiaMarketAmount = 0;
                TGlobals.computerPlayers[i].InternationalMarketAmount = 0;
                str = str + TGlobals.computerPlayers[i].ComputerPlayerName + "进入订单会场!\n";
            }
            this.richTextBoxMeetingInfor.Text = str;
            this.richTextBoxMeetingInfor.AppendText(TGlobals.currentActor.ActorName + "进入订单会场!");
            this.buttonLocal.Enabled = false;
            this.buttonRegional.Enabled = false;
            this.buttonDomestic.Enabled = false;
            this.buttonAsia.Enabled = false;
            this.buttonInternational.Enabled = false;
            this.buttonOK.Enabled = false;
            this.buttonGiveUp.Enabled = false;
            this.buttonFinish.Enabled = false;
            this.GetOrders(TGlobals.currentActor.RunningYear, Market.本地);
        }

        private string GetEmptyAdvertisingInfor(int i, int j)
        {
            string str = "";
            switch (i)
            {
                case 0:
                    str = "P1";
                    break;

                case 1:
                    str = "P2";
                    break;

                case 2:
                    str = "P3";
                    break;

                case 3:
                    str = "P4";
                    break;

                default:
                    break;
            }
            switch (j)
            {
                case 0:
                    str = str + "在本地市场广告投入为0，故今年不可在本地市场选单！";
                    break;

                case 1:
                    str = str + "在区域市场广告投入为0，故今年不可在区域市场选单！";
                    break;

                case 2:
                    str = str + "在国内市场广告投入为0，故今年不可在国内市场选单！";
                    break;

                case 3:
                    str = str + "在亚洲市场广告投入为0，故今年不可在亚洲市场选单！";
                    break;

                case 4:
                    str = str + "在国际市场广告投入为0，故今年不可在国际市场选单！";
                    break;

                default:
                    break;
            }
            return str;
        }

        private void GetOrders(Year year, Market market)
        {
            this.dataGridViewCJDHH.Rows.Clear();
            this.currentOrders = TGlobals.orderModel.GetOrders(year, market);
            this.dataGridViewCJDHH.RowCount = this.currentOrders.Length;
            for (int i = 0; i < this.currentOrders.Length; i++)
            {
                this.dataGridViewCJDHH.Rows[i].Cells["编号"].Value = this.currentOrders[i].OrderID;
                this.dataGridViewCJDHH.Rows[i].Cells["产品"].Value = this.currentOrders[i].ProductName;
                this.dataGridViewCJDHH.Rows[i].Cells["数量"].Value = this.currentOrders[i].ProductNumber;
                this.dataGridViewCJDHH.Rows[i].Cells["单价"].Value = this.currentOrders[i].UnitPrice;
                this.dataGridViewCJDHH.Rows[i].Cells["金额"].Value = this.currentOrders[i].Amount;
                this.dataGridViewCJDHH.Rows[i].Cells["账期"].Value = this.currentOrders[i].AccountPeriod;
                this.dataGridViewCJDHH.Rows[i].Cells["ISO"].Value = this.currentOrders[i].ISOQulify;
                this.dataGridViewCJDHH.Rows[i].Cells["成本"].Value = this.currentOrders[i].DirectCost;
                this.dataGridViewCJDHH.Rows[i].Cells["利润"].Value = this.currentOrders[i].GrossProfit;
            }
        }

        private bool HasAdvCost(Market market)
        {
            int[] numArray = new int[6];
            for (int i = 0; i < numArray.Length; i++)
            {
                numArray[i] = 0;
            }
            for (int j = 0; j < TGlobals.computerPlayers.Length; j++)
            {
                if (TGlobals.computerPlayers[j].IsLiving(TGlobals.currentActor.RunningYear))
                {
                    numArray[j] = TGlobals.computerPlayers[j].GetAdvCost(TGlobals.currentActor.RunningYear, market);
                }
            }
            switch (market)
            {
                case Market.本地:
                    numArray[5] = TGlobals.currentActor.AdvCostLocalMarket;
                    break;

                case Market.区域:
                    numArray[5] = TGlobals.currentActor.AdvCostRegionalMarket;
                    break;

                case Market.国内:
                    numArray[5] = TGlobals.currentActor.AdvCostDomesticMarket;
                    break;

                case Market.亚洲:
                    numArray[5] = TGlobals.currentActor.AdvCostAsiaMarket;
                    break;

                case Market.国际:
                    numArray[5] = TGlobals.currentActor.AdvCostInternationalMarket;
                    break;

                default:
                    break;
            }
            bool flag = false;
            for (int k = 0; k < numArray.Length; k++)
            {
                if (numArray[k] > 0)
                {
                    flag = true;
                }
            }
            return flag;
        }

        private void IniNumericUpDown()
        {
            if (!TGlobals.currentActor.IsEnterLocalMarket)
            {
                this.numericUpDown00.Enabled = false;
                this.numericUpDown10.Enabled = false;
                this.numericUpDown20.Enabled = false;
                this.numericUpDown30.Enabled = false;
            }
            else
            {
                if (TGlobals.currentActor.HasP1Capacity)
                {
                    this.numericUpDown00.Enabled = true;
                    this.advertisingTable[0, 0].Eligibility = true;
                }
                if (TGlobals.currentActor.HasP2Capacity)
                {
                    this.numericUpDown10.Enabled = true;
                    this.advertisingTable[1, 0].Eligibility = true;
                }
                if (TGlobals.currentActor.HasP3Capacity)
                {
                    this.numericUpDown20.Enabled = true;
                    this.advertisingTable[2, 0].Eligibility = true;
                }
                if (TGlobals.currentActor.HasP4Capacity)
                {
                    this.numericUpDown30.Enabled = true;
                    this.advertisingTable[3, 0].Eligibility = true;
                }
            }
            if (!TGlobals.currentActor.IsEnterRegionalMarket)
            {
                this.numericUpDown01.Enabled = false;
                this.numericUpDown11.Enabled = false;
                this.numericUpDown21.Enabled = false;
                this.numericUpDown31.Enabled = false;
            }
            else
            {
                if (TGlobals.currentActor.HasP1Capacity)
                {
                    this.numericUpDown01.Enabled = true;
                    this.advertisingTable[0, 1].Eligibility = true;
                }
                if (TGlobals.currentActor.HasP2Capacity)
                {
                    this.numericUpDown11.Enabled = true;
                    this.advertisingTable[1, 1].Eligibility = true;
                }
                if (TGlobals.currentActor.HasP3Capacity)
                {
                    this.numericUpDown21.Enabled = true;
                    this.advertisingTable[2, 1].Eligibility = true;
                }
                if (TGlobals.currentActor.HasP4Capacity)
                {
                    this.numericUpDown31.Enabled = true;
                    this.advertisingTable[3, 1].Eligibility = true;
                }
            }
            if (!TGlobals.currentActor.IsEnterDomesticMarket)
            {
                this.numericUpDown02.Enabled = false;
                this.numericUpDown12.Enabled = false;
                this.numericUpDown22.Enabled = false;
                this.numericUpDown32.Enabled = false;
            }
            else
            {
                if (TGlobals.currentActor.HasP1Capacity)
                {
                    this.numericUpDown02.Enabled = true;
                    this.advertisingTable[0, 2].Eligibility = true;
                }
                if (TGlobals.currentActor.HasP2Capacity)
                {
                    this.numericUpDown12.Enabled = true;
                    this.advertisingTable[1, 2].Eligibility = true;
                }
                if (TGlobals.currentActor.HasP3Capacity)
                {
                    this.numericUpDown22.Enabled = true;
                    this.advertisingTable[2, 2].Eligibility = true;
                }
                if (TGlobals.currentActor.HasP4Capacity)
                {
                    this.numericUpDown32.Enabled = true;
                    this.advertisingTable[3, 2].Eligibility = true;
                }
            }
            if (!TGlobals.currentActor.IsEnterAsiaMarket)
            {
                this.numericUpDown03.Enabled = false;
                this.numericUpDown13.Enabled = false;
                this.numericUpDown23.Enabled = false;
                this.numericUpDown33.Enabled = false;
            }
            else
            {
                if (TGlobals.currentActor.HasP1Capacity)
                {
                    this.numericUpDown03.Enabled = true;
                    this.advertisingTable[0, 3].Eligibility = true;
                }
                if (TGlobals.currentActor.HasP2Capacity)
                {
                    this.numericUpDown13.Enabled = true;
                    this.advertisingTable[1, 3].Eligibility = true;
                }
                if (TGlobals.currentActor.HasP3Capacity)
                {
                    this.numericUpDown23.Enabled = true;
                    this.advertisingTable[2, 3].Eligibility = true;
                }
                if (TGlobals.currentActor.HasP4Capacity)
                {
                    this.numericUpDown33.Enabled = true;
                    this.advertisingTable[3, 3].Eligibility = true;
                }
            }
            if (!TGlobals.currentActor.IsEnterInternationalMarket)
            {
                this.numericUpDown04.Enabled = false;
                this.numericUpDown14.Enabled = false;
                this.numericUpDown24.Enabled = false;
                this.numericUpDown34.Enabled = false;
            }
            else
            {
                if (TGlobals.currentActor.HasP1Capacity)
                {
                    this.numericUpDown04.Enabled = true;
                    this.advertisingTable[0, 4].Eligibility = true;
                }
                if (TGlobals.currentActor.HasP2Capacity)
                {
                    this.numericUpDown14.Enabled = true;
                    this.advertisingTable[1, 4].Eligibility = true;
                }
                if (TGlobals.currentActor.HasP3Capacity)
                {
                    this.numericUpDown24.Enabled = true;
                    this.advertisingTable[2, 4].Eligibility = true;
                }
                if (TGlobals.currentActor.HasP4Capacity)
                {
                    this.numericUpDown34.Enabled = true;
                    this.advertisingTable[3, 4].Eligibility = true;
                }
            }
            if (!TGlobals.currentActor.IsCertified9000)
            {
                this.numericUpDown9000.Enabled = false;
            }
            else
            {
                this.numericUpDown9000.Enabled = true;
                this.adv9000.Eligibility = true;
            }
            if (!TGlobals.currentActor.IsCertified14000)
            {
                this.numericUpDown14000.Enabled = false;
            }
            else
            {
                this.numericUpDown14000.Enabled = true;
                this.adv14000.Eligibility = true;
            }
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            this.tabControl1 = new TabControl();
            this.tabPageTFGG = new TabPage();
            this.label11 = new Label();
            this.labelGJNO1 = new Label();
            this.labelYZNO1 = new Label();
            this.labelGNNO1 = new Label();
            this.labelQYNO1 = new Label();
            this.labelBDNO1 = new Label();
            this.button8 = new Button();
            this.label10 = new Label();
            this.label6 = new Label();
            this.label3 = new Label();
            this.labelAvalue = new Label();
            this.label5 = new Label();
            this.groupBox3 = new GroupBox();
            this.richTextBox2 = new RichTextBox();
            this.groupBox2 = new GroupBox();
            this.numericUpDown14000 = new NumericUpDown();
            this.groupBox1 = new GroupBox();
            this.numericUpDown9000 = new NumericUpDown();
            this.buttonTFGG = new Button();
            this.numericUpDown34 = new NumericUpDown();
            this.numericUpDown24 = new NumericUpDown();
            this.numericUpDown14 = new NumericUpDown();
            this.numericUpDown04 = new NumericUpDown();
            this.label9 = new Label();
            this.numericUpDown33 = new NumericUpDown();
            this.numericUpDown23 = new NumericUpDown();
            this.numericUpDown13 = new NumericUpDown();
            this.numericUpDown03 = new NumericUpDown();
            this.label8 = new Label();
            this.numericUpDown32 = new NumericUpDown();
            this.numericUpDown22 = new NumericUpDown();
            this.numericUpDown12 = new NumericUpDown();
            this.numericUpDown02 = new NumericUpDown();
            this.label7 = new Label();
            this.numericUpDown31 = new NumericUpDown();
            this.numericUpDown21 = new NumericUpDown();
            this.numericUpDown11 = new NumericUpDown();
            this.numericUpDown01 = new NumericUpDown();
            this.label4 = new Label();
            this.label2 = new Label();
            this.label1 = new Label();
            this.numericUpDown00 = new NumericUpDown();
            this.numericUpDown10 = new NumericUpDown();
            this.numericUpDown20 = new NumericUpDown();
            this.numericUpDown30 = new NumericUpDown();
            this.tabPageSCJD = new TabPage();
            this.panel2 = new Panel();
            this.richTextBoxMeetingInfor = new RichTextBox();
            this.panel1 = new Panel();
            this.groupBox5 = new GroupBox();
            this.buttonFinish = new Button();
            this.dataGridViewCJDHH = new DataGridView();
            this.编号 = new DataGridViewTextBoxColumn();
            this.产品 = new DataGridViewTextBoxColumn();
            this.数量 = new DataGridViewTextBoxColumn();
            this.单价 = new DataGridViewTextBoxColumn();
            this.金额 = new DataGridViewTextBoxColumn();
            this.账期 = new DataGridViewTextBoxColumn();
            this.ISO = new DataGridViewTextBoxColumn();
            this.成本 = new DataGridViewTextBoxColumn();
            this.利润 = new DataGridViewTextBoxColumn();
            this.buttonGiveUp = new Button();
            this.buttonOK = new Button();
            this.buttonInternational = new Button();
            this.buttonAsia = new Button();
            this.buttonDomestic = new Button();
            this.buttonRegional = new Button();
            this.buttonLocal = new Button();
            this.tabControl1.SuspendLayout();
            this.tabPageTFGG.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.numericUpDown14000.BeginInit();
            this.groupBox1.SuspendLayout();
            this.numericUpDown9000.BeginInit();
            this.numericUpDown34.BeginInit();
            this.numericUpDown24.BeginInit();
            this.numericUpDown14.BeginInit();
            this.numericUpDown04.BeginInit();
            this.numericUpDown33.BeginInit();
            this.numericUpDown23.BeginInit();
            this.numericUpDown13.BeginInit();
            this.numericUpDown03.BeginInit();
            this.numericUpDown32.BeginInit();
            this.numericUpDown22.BeginInit();
            this.numericUpDown12.BeginInit();
            this.numericUpDown02.BeginInit();
            this.numericUpDown31.BeginInit();
            this.numericUpDown21.BeginInit();
            this.numericUpDown11.BeginInit();
            this.numericUpDown01.BeginInit();
            this.numericUpDown00.BeginInit();
            this.numericUpDown10.BeginInit();
            this.numericUpDown20.BeginInit();
            this.numericUpDown30.BeginInit();
            this.tabPageSCJD.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((ISupportInitialize) this.dataGridViewCJDHH).BeginInit();
            base.SuspendLayout();
            this.tabControl1.Controls.Add(this.tabPageTFGG);
            this.tabControl1.Controls.Add(this.tabPageSCJD);
            this.tabControl1.Dock = DockStyle.Fill;
            this.tabControl1.Location = new Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new Size(0x28c, 0x18f);
            this.tabControl1.TabIndex = 2;
            this.tabPageTFGG.Controls.Add(this.label11);
            this.tabPageTFGG.Controls.Add(this.labelGJNO1);
            this.tabPageTFGG.Controls.Add(this.labelYZNO1);
            this.tabPageTFGG.Controls.Add(this.labelGNNO1);
            this.tabPageTFGG.Controls.Add(this.labelQYNO1);
            this.tabPageTFGG.Controls.Add(this.labelBDNO1);
            this.tabPageTFGG.Controls.Add(this.button8);
            this.tabPageTFGG.Controls.Add(this.label10);
            this.tabPageTFGG.Controls.Add(this.label6);
            this.tabPageTFGG.Controls.Add(this.label3);
            this.tabPageTFGG.Controls.Add(this.labelAvalue);
            this.tabPageTFGG.Controls.Add(this.label5);
            this.tabPageTFGG.Controls.Add(this.groupBox3);
            this.tabPageTFGG.Controls.Add(this.groupBox2);
            this.tabPageTFGG.Controls.Add(this.groupBox1);
            this.tabPageTFGG.Controls.Add(this.buttonTFGG);
            this.tabPageTFGG.Controls.Add(this.numericUpDown34);
            this.tabPageTFGG.Controls.Add(this.numericUpDown24);
            this.tabPageTFGG.Controls.Add(this.numericUpDown14);
            this.tabPageTFGG.Controls.Add(this.numericUpDown04);
            this.tabPageTFGG.Controls.Add(this.label9);
            this.tabPageTFGG.Controls.Add(this.numericUpDown33);
            this.tabPageTFGG.Controls.Add(this.numericUpDown23);
            this.tabPageTFGG.Controls.Add(this.numericUpDown13);
            this.tabPageTFGG.Controls.Add(this.numericUpDown03);
            this.tabPageTFGG.Controls.Add(this.label8);
            this.tabPageTFGG.Controls.Add(this.numericUpDown32);
            this.tabPageTFGG.Controls.Add(this.numericUpDown22);
            this.tabPageTFGG.Controls.Add(this.numericUpDown12);
            this.tabPageTFGG.Controls.Add(this.numericUpDown02);
            this.tabPageTFGG.Controls.Add(this.label7);
            this.tabPageTFGG.Controls.Add(this.numericUpDown31);
            this.tabPageTFGG.Controls.Add(this.numericUpDown21);
            this.tabPageTFGG.Controls.Add(this.numericUpDown11);
            this.tabPageTFGG.Controls.Add(this.numericUpDown01);
            this.tabPageTFGG.Controls.Add(this.label4);
            this.tabPageTFGG.Controls.Add(this.label2);
            this.tabPageTFGG.Controls.Add(this.label1);
            this.tabPageTFGG.Controls.Add(this.numericUpDown00);
            this.tabPageTFGG.Controls.Add(this.numericUpDown10);
            this.tabPageTFGG.Controls.Add(this.numericUpDown20);
            this.tabPageTFGG.Controls.Add(this.numericUpDown30);
            this.tabPageTFGG.Location = new Point(4, 0x15);
            this.tabPageTFGG.Name = "tabPageTFGG";
            this.tabPageTFGG.Padding = new Padding(3);
            this.tabPageTFGG.Size = new Size(0x284, 0x176);
            this.tabPageTFGG.TabIndex = 0;
            this.tabPageTFGG.Text = "投放广告";
            this.tabPageTFGG.UseVisualStyleBackColor = true;
            this.tabPageTFGG.Click += new EventHandler(this.tabPageTFGG_Click);
            this.label11.ForeColor = Color.Red;
            this.label11.Location = new Point(0x11, 0x83);
            this.label11.Name = "label11";
            this.label11.Size = new Size(100, 0x15);
            this.label11.TabIndex = 0x45;
            this.label11.Text = "市场地位";
            this.label11.TextAlign = ContentAlignment.MiddleCenter;
            this.labelGJNO1.ForeColor = Color.Red;
            this.labelGJNO1.Location = new Point(0x200, 0x83);
            this.labelGJNO1.Name = "labelGJNO1";
            this.labelGJNO1.Size = new Size(100, 0x15);
            this.labelGJNO1.TabIndex = 0x44;
            this.labelGJNO1.Text = "本地第一";
            this.labelGJNO1.TextAlign = ContentAlignment.MiddleCenter;
            this.labelYZNO1.ForeColor = Color.Red;
            this.labelYZNO1.Location = new Point(0x19d, 0x83);
            this.labelYZNO1.Name = "labelYZNO1";
            this.labelYZNO1.Size = new Size(100, 0x15);
            this.labelYZNO1.TabIndex = 0x43;
            this.labelYZNO1.Text = "本地第一";
            this.labelYZNO1.TextAlign = ContentAlignment.MiddleCenter;
            this.labelGNNO1.ForeColor = Color.Red;
            this.labelGNNO1.Location = new Point(0x13a, 0x83);
            this.labelGNNO1.Name = "labelGNNO1";
            this.labelGNNO1.Size = new Size(100, 0x15);
            this.labelGNNO1.TabIndex = 0x42;
            this.labelGNNO1.Text = "本地第一";
            this.labelGNNO1.TextAlign = ContentAlignment.MiddleCenter;
            this.labelQYNO1.ForeColor = Color.Red;
            this.labelQYNO1.Location = new Point(0xd7, 0x83);
            this.labelQYNO1.Name = "labelQYNO1";
            this.labelQYNO1.Size = new Size(100, 0x15);
            this.labelQYNO1.TabIndex = 0x41;
            this.labelQYNO1.Text = "本地第一";
            this.labelQYNO1.TextAlign = ContentAlignment.MiddleCenter;
            this.labelBDNO1.ForeColor = Color.Red;
            this.labelBDNO1.Location = new Point(0x74, 0x83);
            this.labelBDNO1.Name = "labelBDNO1";
            this.labelBDNO1.Size = new Size(100, 0x15);
            this.labelBDNO1.TabIndex = 0x3f;
            this.labelBDNO1.Text = "本地第一";
            this.labelBDNO1.TextAlign = ContentAlignment.MiddleCenter;
            this.button8.Location = new Point(0x1c8, 0x157);
            this.button8.Name = "button8";
            this.button8.Size = new Size(0x4b, 0x17);
            this.button8.TabIndex = 0x3d;
            this.button8.Text = "放弃投放";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new EventHandler(this.button_Click);
            this.label10.AutoSize = true;
            this.label10.Location = new Point(0x20b, 9);
            this.label10.Name = "label10";
            this.label10.Size = new Size(0x4d, 12);
            this.label10.TabIndex = 60;
            this.label10.Text = "单位：百万元";
            this.label6.BorderStyle = BorderStyle.FixedSingle;
            this.label6.Location = new Point(0x11, 110);
            this.label6.Name = "label6";
            this.label6.Size = new Size(100, 0x15);
            this.label6.TabIndex = 0x1c;
            this.label6.Text = "P4";
            this.label6.TextAlign = ContentAlignment.MiddleCenter;
            this.label3.BorderStyle = BorderStyle.FixedSingle;
            this.label3.Location = new Point(0x11, 90);
            this.label3.Name = "label3";
            this.label3.Size = new Size(100, 0x15);
            this.label3.TabIndex = 0x1b;
            this.label3.Text = "P3";
            this.label3.TextAlign = ContentAlignment.MiddleCenter;
            this.labelAvalue.BorderStyle = BorderStyle.FixedSingle;
            this.labelAvalue.Location = new Point(0x11, 70);
            this.labelAvalue.Name = "labelAvalue";
            this.labelAvalue.Size = new Size(100, 0x15);
            this.labelAvalue.TabIndex = 0x15;
            this.labelAvalue.Text = "P2";
            this.labelAvalue.TextAlign = ContentAlignment.MiddleCenter;
            this.label5.BorderStyle = BorderStyle.FixedSingle;
            this.label5.Location = new Point(0x11, 50);
            this.label5.Name = "label5";
            this.label5.Size = new Size(100, 0x15);
            this.label5.TabIndex = 20;
            this.label5.Text = "P1";
            this.label5.TextAlign = ContentAlignment.MiddleCenter;
            this.groupBox3.Controls.Add(this.richTextBox2);
            this.groupBox3.Location = new Point(0xf2, 0x9a);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new Size(370, 0xb7);
            this.groupBox3.TabIndex = 0x3b;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "说明";
            this.richTextBox2.BackColor = SystemColors.Window;
            this.richTextBox2.BorderStyle = BorderStyle.None;
            this.richTextBox2.Dock = DockStyle.Fill;
            this.richTextBox2.Font = new Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.richTextBox2.Location = new Point(3, 0x11);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.Size = new Size(0x16c, 0xa3);
            this.richTextBox2.TabIndex = 2;
            this.richTextBox2.Text = "    每项产品能在市场上销售的条件是其市场投入为1M（在没有准备好市场投入前，无法接受该产品的订单），每项产品的需求反映在预测中，这些需求反映在一些订单卡中。\n    在销售会议中出现的订单数量由市场投入决定：第一张订单花费1M，其后每一个订单将花费2M。\n    注意：P2、P3、P4的订单在第三年才会出现，如果所选订单总额与机器相同，机器为市场老大。";
            this.groupBox2.Controls.Add(this.numericUpDown14000);
            this.groupBox2.Location = new Point(0x11, 260);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(200, 0x35);
            this.groupBox2.TabIndex = 0x3a;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ISO14000";
            this.numericUpDown14000.Enabled = false;
            this.numericUpDown14000.Location = new Point(0x33, 20);
            this.numericUpDown14000.Maximum = new decimal(new int[] { 1 });
            this.numericUpDown14000.Name = "numericUpDown14000";
            this.numericUpDown14000.ReadOnly = true;
            this.numericUpDown14000.Size = new Size(100, 0x15);
            this.numericUpDown14000.TabIndex = 0x38;
            this.numericUpDown14000.TextAlign = HorizontalAlignment.Center;
            this.numericUpDown14000.ValueChanged += new EventHandler(this.numericUpDown_ValueChanged);
            this.groupBox1.Controls.Add(this.numericUpDown9000);
            this.groupBox1.Location = new Point(0x10, 0xab);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(200, 0x35);
            this.groupBox1.TabIndex = 0x37;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ISO9000";
            this.numericUpDown9000.Enabled = false;
            this.numericUpDown9000.Location = new Point(0x33, 20);
            this.numericUpDown9000.Maximum = new decimal(new int[] { 1 });
            this.numericUpDown9000.Name = "numericUpDown9000";
            this.numericUpDown9000.ReadOnly = true;
            this.numericUpDown9000.Size = new Size(100, 0x15);
            this.numericUpDown9000.TabIndex = 0x38;
            this.numericUpDown9000.TextAlign = HorizontalAlignment.Center;
            this.numericUpDown9000.ValueChanged += new EventHandler(this.numericUpDown_ValueChanged);
            this.buttonTFGG.Location = new Point(0x219, 0x157);
            this.buttonTFGG.Name = "buttonTFGG";
            this.buttonTFGG.Size = new Size(0x4b, 0x17);
            this.buttonTFGG.TabIndex = 0x34;
            this.buttonTFGG.Text = "确认投放";
            this.buttonTFGG.UseVisualStyleBackColor = true;
            this.buttonTFGG.Click += new EventHandler(this.button_Click);
            this.numericUpDown34.Enabled = false;
            this.numericUpDown34.Location = new Point(0x200, 110);
            this.numericUpDown34.Name = "numericUpDown34";
            this.numericUpDown34.ReadOnly = true;
            this.numericUpDown34.Size = new Size(100, 0x15);
            this.numericUpDown34.TabIndex = 0x33;
            this.numericUpDown34.TextAlign = HorizontalAlignment.Center;
            this.numericUpDown34.ValueChanged += new EventHandler(this.numericUpDown_ValueChanged);
            this.numericUpDown24.Enabled = false;
            this.numericUpDown24.Location = new Point(0x200, 90);
            this.numericUpDown24.Name = "numericUpDown24";
            this.numericUpDown24.ReadOnly = true;
            this.numericUpDown24.Size = new Size(100, 0x15);
            this.numericUpDown24.TabIndex = 50;
            this.numericUpDown24.TextAlign = HorizontalAlignment.Center;
            this.numericUpDown24.ValueChanged += new EventHandler(this.numericUpDown_ValueChanged);
            this.numericUpDown14.Enabled = false;
            this.numericUpDown14.Location = new Point(0x200, 70);
            this.numericUpDown14.Name = "numericUpDown14";
            this.numericUpDown14.ReadOnly = true;
            this.numericUpDown14.Size = new Size(100, 0x15);
            this.numericUpDown14.TabIndex = 0x31;
            this.numericUpDown14.TextAlign = HorizontalAlignment.Center;
            this.numericUpDown14.ValueChanged += new EventHandler(this.numericUpDown_ValueChanged);
            this.numericUpDown04.Enabled = false;
            this.numericUpDown04.Location = new Point(0x200, 50);
            this.numericUpDown04.Name = "numericUpDown04";
            this.numericUpDown04.ReadOnly = true;
            this.numericUpDown04.Size = new Size(100, 0x15);
            this.numericUpDown04.TabIndex = 0x30;
            this.numericUpDown04.TextAlign = HorizontalAlignment.Center;
            this.numericUpDown04.ValueChanged += new EventHandler(this.numericUpDown_ValueChanged);
            this.label9.BorderStyle = BorderStyle.FixedSingle;
            this.label9.Location = new Point(0x200, 30);
            this.label9.Name = "label9";
            this.label9.Size = new Size(100, 0x15);
            this.label9.TabIndex = 0x2f;
            this.label9.Text = "国际";
            this.label9.TextAlign = ContentAlignment.MiddleCenter;
            this.numericUpDown33.Enabled = false;
            this.numericUpDown33.Location = new Point(0x19d, 110);
            this.numericUpDown33.Name = "numericUpDown33";
            this.numericUpDown33.ReadOnly = true;
            this.numericUpDown33.Size = new Size(100, 0x15);
            this.numericUpDown33.TabIndex = 0x2e;
            this.numericUpDown33.TextAlign = HorizontalAlignment.Center;
            this.numericUpDown33.ValueChanged += new EventHandler(this.numericUpDown_ValueChanged);
            this.numericUpDown23.Enabled = false;
            this.numericUpDown23.Location = new Point(0x19d, 90);
            this.numericUpDown23.Name = "numericUpDown23";
            this.numericUpDown23.ReadOnly = true;
            this.numericUpDown23.Size = new Size(100, 0x15);
            this.numericUpDown23.TabIndex = 0x2d;
            this.numericUpDown23.TextAlign = HorizontalAlignment.Center;
            this.numericUpDown23.ValueChanged += new EventHandler(this.numericUpDown_ValueChanged);
            this.numericUpDown13.Enabled = false;
            this.numericUpDown13.Location = new Point(0x19d, 70);
            this.numericUpDown13.Name = "numericUpDown13";
            this.numericUpDown13.ReadOnly = true;
            this.numericUpDown13.Size = new Size(100, 0x15);
            this.numericUpDown13.TabIndex = 0x2c;
            this.numericUpDown13.TextAlign = HorizontalAlignment.Center;
            this.numericUpDown13.ValueChanged += new EventHandler(this.numericUpDown_ValueChanged);
            this.numericUpDown03.Enabled = false;
            this.numericUpDown03.Location = new Point(0x19d, 50);
            this.numericUpDown03.Name = "numericUpDown03";
            this.numericUpDown03.ReadOnly = true;
            this.numericUpDown03.Size = new Size(100, 0x15);
            this.numericUpDown03.TabIndex = 0x2b;
            this.numericUpDown03.TextAlign = HorizontalAlignment.Center;
            this.numericUpDown03.ValueChanged += new EventHandler(this.numericUpDown_ValueChanged);
            this.label8.BorderStyle = BorderStyle.FixedSingle;
            this.label8.Location = new Point(0x19d, 30);
            this.label8.Name = "label8";
            this.label8.Size = new Size(100, 0x15);
            this.label8.TabIndex = 0x2a;
            this.label8.Text = "亚洲";
            this.label8.TextAlign = ContentAlignment.MiddleCenter;
            this.numericUpDown32.Enabled = false;
            this.numericUpDown32.Location = new Point(0x13a, 110);
            this.numericUpDown32.Name = "numericUpDown32";
            this.numericUpDown32.ReadOnly = true;
            this.numericUpDown32.Size = new Size(100, 0x15);
            this.numericUpDown32.TabIndex = 0x29;
            this.numericUpDown32.TextAlign = HorizontalAlignment.Center;
            this.numericUpDown32.ValueChanged += new EventHandler(this.numericUpDown_ValueChanged);
            this.numericUpDown22.Enabled = false;
            this.numericUpDown22.Location = new Point(0x13a, 90);
            this.numericUpDown22.Name = "numericUpDown22";
            this.numericUpDown22.ReadOnly = true;
            this.numericUpDown22.Size = new Size(100, 0x15);
            this.numericUpDown22.TabIndex = 40;
            this.numericUpDown22.TextAlign = HorizontalAlignment.Center;
            this.numericUpDown22.ValueChanged += new EventHandler(this.numericUpDown_ValueChanged);
            this.numericUpDown12.Enabled = false;
            this.numericUpDown12.Location = new Point(0x13a, 70);
            this.numericUpDown12.Name = "numericUpDown12";
            this.numericUpDown12.ReadOnly = true;
            this.numericUpDown12.Size = new Size(100, 0x15);
            this.numericUpDown12.TabIndex = 0x27;
            this.numericUpDown12.TextAlign = HorizontalAlignment.Center;
            this.numericUpDown12.ValueChanged += new EventHandler(this.numericUpDown_ValueChanged);
            this.numericUpDown02.Enabled = false;
            this.numericUpDown02.Location = new Point(0x13a, 50);
            this.numericUpDown02.Name = "numericUpDown02";
            this.numericUpDown02.ReadOnly = true;
            this.numericUpDown02.Size = new Size(100, 0x15);
            this.numericUpDown02.TabIndex = 0x26;
            this.numericUpDown02.TextAlign = HorizontalAlignment.Center;
            this.numericUpDown02.ValueChanged += new EventHandler(this.numericUpDown_ValueChanged);
            this.label7.BorderStyle = BorderStyle.FixedSingle;
            this.label7.Location = new Point(0x13a, 30);
            this.label7.Name = "label7";
            this.label7.Size = new Size(100, 0x15);
            this.label7.TabIndex = 0x25;
            this.label7.Text = "国内";
            this.label7.TextAlign = ContentAlignment.MiddleCenter;
            this.numericUpDown31.Enabled = false;
            this.numericUpDown31.Location = new Point(0xd7, 110);
            this.numericUpDown31.Name = "numericUpDown31";
            this.numericUpDown31.ReadOnly = true;
            this.numericUpDown31.Size = new Size(100, 0x15);
            this.numericUpDown31.TabIndex = 0x24;
            this.numericUpDown31.TextAlign = HorizontalAlignment.Center;
            this.numericUpDown31.ValueChanged += new EventHandler(this.numericUpDown_ValueChanged);
            this.numericUpDown21.Enabled = false;
            this.numericUpDown21.Location = new Point(0xd7, 90);
            this.numericUpDown21.Name = "numericUpDown21";
            this.numericUpDown21.ReadOnly = true;
            this.numericUpDown21.Size = new Size(100, 0x15);
            this.numericUpDown21.TabIndex = 0x23;
            this.numericUpDown21.TextAlign = HorizontalAlignment.Center;
            this.numericUpDown21.ValueChanged += new EventHandler(this.numericUpDown_ValueChanged);
            this.numericUpDown11.Enabled = false;
            this.numericUpDown11.Location = new Point(0xd7, 70);
            this.numericUpDown11.Name = "numericUpDown11";
            this.numericUpDown11.ReadOnly = true;
            this.numericUpDown11.Size = new Size(100, 0x15);
            this.numericUpDown11.TabIndex = 0x22;
            this.numericUpDown11.TextAlign = HorizontalAlignment.Center;
            this.numericUpDown11.ValueChanged += new EventHandler(this.numericUpDown_ValueChanged);
            this.numericUpDown01.Enabled = false;
            this.numericUpDown01.Location = new Point(0xd7, 50);
            this.numericUpDown01.Name = "numericUpDown01";
            this.numericUpDown01.ReadOnly = true;
            this.numericUpDown01.Size = new Size(100, 0x15);
            this.numericUpDown01.TabIndex = 0x21;
            this.numericUpDown01.TextAlign = HorizontalAlignment.Center;
            this.numericUpDown01.ValueChanged += new EventHandler(this.numericUpDown_ValueChanged);
            this.label4.BorderStyle = BorderStyle.FixedSingle;
            this.label4.Location = new Point(0xd7, 30);
            this.label4.Name = "label4";
            this.label4.Size = new Size(100, 0x15);
            this.label4.TabIndex = 0x16;
            this.label4.Text = "区域";
            this.label4.TextAlign = ContentAlignment.MiddleCenter;
            this.label2.BorderStyle = BorderStyle.FixedSingle;
            this.label2.Location = new Point(0x74, 30);
            this.label2.Name = "label2";
            this.label2.Size = new Size(100, 0x15);
            this.label2.TabIndex = 0x13;
            this.label2.Text = "本地";
            this.label2.TextAlign = ContentAlignment.MiddleCenter;
            this.label1.BorderStyle = BorderStyle.FixedSingle;
            this.label1.Location = new Point(0x11, 30);
            this.label1.Name = "label1";
            this.label1.Size = new Size(100, 0x15);
            this.label1.TabIndex = 0x12;
            this.label1.Text = "产品/市场";
            this.label1.TextAlign = ContentAlignment.MiddleCenter;
            this.numericUpDown00.Enabled = false;
            this.numericUpDown00.Location = new Point(0x74, 50);
            this.numericUpDown00.Name = "numericUpDown00";
            this.numericUpDown00.ReadOnly = true;
            this.numericUpDown00.Size = new Size(100, 0x15);
            this.numericUpDown00.TabIndex = 0x1d;
            this.numericUpDown00.TextAlign = HorizontalAlignment.Center;
            this.numericUpDown00.ValueChanged += new EventHandler(this.numericUpDown_ValueChanged);
            this.numericUpDown10.Enabled = false;
            this.numericUpDown10.Location = new Point(0x74, 70);
            this.numericUpDown10.Name = "numericUpDown10";
            this.numericUpDown10.ReadOnly = true;
            this.numericUpDown10.Size = new Size(100, 0x15);
            this.numericUpDown10.TabIndex = 30;
            this.numericUpDown10.TextAlign = HorizontalAlignment.Center;
            this.numericUpDown10.ValueChanged += new EventHandler(this.numericUpDown_ValueChanged);
            this.numericUpDown20.Enabled = false;
            this.numericUpDown20.Location = new Point(0x74, 90);
            this.numericUpDown20.Name = "numericUpDown20";
            this.numericUpDown20.ReadOnly = true;
            this.numericUpDown20.Size = new Size(100, 0x15);
            this.numericUpDown20.TabIndex = 0x1f;
            this.numericUpDown20.TextAlign = HorizontalAlignment.Center;
            this.numericUpDown20.ValueChanged += new EventHandler(this.numericUpDown_ValueChanged);
            this.numericUpDown30.Enabled = false;
            this.numericUpDown30.Location = new Point(0x74, 110);
            this.numericUpDown30.Name = "numericUpDown30";
            this.numericUpDown30.ReadOnly = true;
            this.numericUpDown30.Size = new Size(100, 0x15);
            this.numericUpDown30.TabIndex = 0x20;
            this.numericUpDown30.TextAlign = HorizontalAlignment.Center;
            this.numericUpDown30.ValueChanged += new EventHandler(this.numericUpDown_ValueChanged);
            this.tabPageSCJD.Controls.Add(this.panel2);
            this.tabPageSCJD.Controls.Add(this.panel1);
            this.tabPageSCJD.Location = new Point(4, 0x15);
            this.tabPageSCJD.Name = "tabPageSCJD";
            this.tabPageSCJD.Padding = new Padding(3);
            this.tabPageSCJD.Size = new Size(0x284, 0x176);
            this.tabPageSCJD.TabIndex = 1;
            this.tabPageSCJD.Text = "市场竞单";
            this.tabPageSCJD.UseVisualStyleBackColor = true;
            this.panel2.Controls.Add(this.richTextBoxMeetingInfor);
            this.panel2.Dock = DockStyle.Bottom;
            this.panel2.Location = new Point(3, 0x10f);
            this.panel2.Name = "panel2";
            this.panel2.Size = new Size(0x27e, 100);
            this.panel2.TabIndex = 13;
            this.richTextBoxMeetingInfor.BorderStyle = BorderStyle.FixedSingle;
            this.richTextBoxMeetingInfor.Dock = DockStyle.Fill;
            this.richTextBoxMeetingInfor.ForeColor = SystemColors.MenuHighlight;
            this.richTextBoxMeetingInfor.Location = new Point(0, 0);
            this.richTextBoxMeetingInfor.Name = "richTextBoxMeetingInfor";
            this.richTextBoxMeetingInfor.ReadOnly = true;
            this.richTextBoxMeetingInfor.Size = new Size(0x27e, 100);
            this.richTextBoxMeetingInfor.TabIndex = 12;
            this.richTextBoxMeetingInfor.Text = "";
            this.panel1.Controls.Add(this.groupBox5);
            this.panel1.Dock = DockStyle.Fill;
            this.panel1.Location = new Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(0x27e, 0x170);
            this.panel1.TabIndex = 12;
            this.groupBox5.Controls.Add(this.buttonFinish);
            this.groupBox5.Controls.Add(this.dataGridViewCJDHH);
            this.groupBox5.Controls.Add(this.buttonGiveUp);
            this.groupBox5.Controls.Add(this.buttonOK);
            this.groupBox5.Controls.Add(this.buttonInternational);
            this.groupBox5.Controls.Add(this.buttonAsia);
            this.groupBox5.Controls.Add(this.buttonDomestic);
            this.groupBox5.Controls.Add(this.buttonRegional);
            this.groupBox5.Controls.Add(this.buttonLocal);
            this.groupBox5.Dock = DockStyle.Fill;
            this.groupBox5.Location = new Point(0, 0);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new Size(0x27e, 0x170);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "参加订货会";
            this.buttonFinish.DialogResult = DialogResult.OK;
            this.buttonFinish.Location = new Point(0x220, 0xda);
            this.buttonFinish.Name = "buttonFinish";
            this.buttonFinish.Size = new Size(0x58, 0x17);
            this.buttonFinish.TabIndex = 11;
            this.buttonFinish.Text = "订货会结束";
            this.buttonFinish.UseVisualStyleBackColor = true;
            this.buttonFinish.Click += new EventHandler(this.button_Click);
            this.dataGridViewCJDHH.AllowUserToAddRows = false;
            this.dataGridViewCJDHH.AllowUserToDeleteRows = false;
            this.dataGridViewCJDHH.AllowUserToResizeRows = false;
            this.dataGridViewCJDHH.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridViewCJDHH.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridViewColumn[] dataGridViewColumns = new DataGridViewColumn[] { this.编号, this.产品, this.数量, this.单价, this.金额, this.账期, this.ISO, this.成本, this.利润 };
            this.dataGridViewCJDHH.Columns.AddRange(dataGridViewColumns);
            style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            style.BackColor = SystemColors.Window;
            style.Font = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            style.ForeColor = SystemColors.ControlText;
            style.SelectionBackColor = SystemColors.Highlight;
            style.SelectionForeColor = SystemColors.HighlightText;
            style.WrapMode = DataGridViewTriState.False;
            this.dataGridViewCJDHH.DefaultCellStyle = style;
            this.dataGridViewCJDHH.Location = new Point(5, 15);
            this.dataGridViewCJDHH.MultiSelect = false;
            this.dataGridViewCJDHH.Name = "dataGridViewCJDHH";
            this.dataGridViewCJDHH.ReadOnly = true;
            this.dataGridViewCJDHH.RowHeadersVisible = false;
            this.dataGridViewCJDHH.RowTemplate.Height = 0x17;
            this.dataGridViewCJDHH.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCJDHH.Size = new Size(0x214, 230);
            this.dataGridViewCJDHH.TabIndex = 10;
            this.编号.HeaderText = "编号";
            this.编号.Name = "编号";
            this.编号.ReadOnly = true;
            this.编号.Width = 0x36;
            this.产品.HeaderText = "产品";
            this.产品.Name = "产品";
            this.产品.ReadOnly = true;
            this.产品.Width = 0x36;
            this.数量.HeaderText = "数量";
            this.数量.Name = "数量";
            this.数量.ReadOnly = true;
            this.数量.Width = 0x36;
            this.单价.HeaderText = "单价";
            this.单价.Name = "单价";
            this.单价.ReadOnly = true;
            this.单价.Width = 0x36;
            this.金额.HeaderText = "金额";
            this.金额.Name = "金额";
            this.金额.ReadOnly = true;
            this.金额.Width = 0x36;
            this.账期.HeaderText = "账期";
            this.账期.Name = "账期";
            this.账期.ReadOnly = true;
            this.账期.Width = 0x36;
            this.ISO.HeaderText = "ISO";
            this.ISO.Name = "ISO";
            this.ISO.ReadOnly = true;
            this.ISO.Width = 0x30;
            this.成本.HeaderText = "成本";
            this.成本.Name = "成本";
            this.成本.ReadOnly = true;
            this.成本.Width = 0x36;
            this.利润.HeaderText = "利润";
            this.利润.Name = "利润";
            this.利润.ReadOnly = true;
            this.利润.Width = 0x36;
            this.buttonGiveUp.Enabled = false;
            this.buttonGiveUp.Location = new Point(0x220, 0xbd);
            this.buttonGiveUp.Name = "buttonGiveUp";
            this.buttonGiveUp.Size = new Size(0x58, 0x17);
            this.buttonGiveUp.TabIndex = 9;
            this.buttonGiveUp.Text = "放弃订单";
            this.buttonGiveUp.UseVisualStyleBackColor = true;
            this.buttonGiveUp.Click += new EventHandler(this.button_Click);
            this.buttonOK.Enabled = false;
            this.buttonOK.Location = new Point(0x21f, 160);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new Size(0x59, 0x17);
            this.buttonOK.TabIndex = 7;
            this.buttonOK.Text = "确定订单";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new EventHandler(this.button_Click);
            this.buttonInternational.Enabled = false;
            this.buttonInternational.Location = new Point(0x21f, 0x83);
            this.buttonInternational.Name = "buttonInternational";
            this.buttonInternational.Size = new Size(0x59, 0x17);
            this.buttonInternational.TabIndex = 6;
            this.buttonInternational.Text = "国际市场竞单";
            this.buttonInternational.UseVisualStyleBackColor = true;
            this.buttonInternational.Click += new EventHandler(this.button_Click);
            this.buttonAsia.Enabled = false;
            this.buttonAsia.Location = new Point(0x21f, 0x66);
            this.buttonAsia.Name = "buttonAsia";
            this.buttonAsia.Size = new Size(0x59, 0x17);
            this.buttonAsia.TabIndex = 5;
            this.buttonAsia.Text = "亚洲市场竞单";
            this.buttonAsia.UseVisualStyleBackColor = true;
            this.buttonAsia.Click += new EventHandler(this.button_Click);
            this.buttonDomestic.Enabled = false;
            this.buttonDomestic.Location = new Point(0x21f, 0x49);
            this.buttonDomestic.Name = "buttonDomestic";
            this.buttonDomestic.Size = new Size(0x59, 0x17);
            this.buttonDomestic.TabIndex = 4;
            this.buttonDomestic.Text = "国内市场竞单";
            this.buttonDomestic.UseVisualStyleBackColor = true;
            this.buttonDomestic.Click += new EventHandler(this.button_Click);
            this.buttonRegional.Enabled = false;
            this.buttonRegional.Location = new Point(0x21f, 0x2c);
            this.buttonRegional.Name = "buttonRegional";
            this.buttonRegional.Size = new Size(0x59, 0x17);
            this.buttonRegional.TabIndex = 3;
            this.buttonRegional.Text = "区域市场竞单";
            this.buttonRegional.UseVisualStyleBackColor = true;
            this.buttonRegional.Click += new EventHandler(this.button_Click);
            this.buttonLocal.Enabled = false;
            this.buttonLocal.Location = new Point(0x21f, 15);
            this.buttonLocal.Name = "buttonLocal";
            this.buttonLocal.Size = new Size(0x59, 0x17);
            this.buttonLocal.TabIndex = 2;
            this.buttonLocal.Text = "本地市场竞单";
            this.buttonLocal.UseVisualStyleBackColor = true;
            this.buttonLocal.Click += new EventHandler(this.button_Click);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x28c, 0x18f);
            base.Controls.Add(this.tabControl1);
            base.FormBorderStyle = FormBorderStyle.None;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "frmCJDHH";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "frmCJDHH";
            base.Load += new EventHandler(this.frmCJDHH_Load);
            base.FormClosing += new FormClosingEventHandler(this.frmCJDHH_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPageTFGG.ResumeLayout(false);
            this.tabPageTFGG.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.numericUpDown14000.EndInit();
            this.groupBox1.ResumeLayout(false);
            this.numericUpDown9000.EndInit();
            this.numericUpDown34.EndInit();
            this.numericUpDown24.EndInit();
            this.numericUpDown14.EndInit();
            this.numericUpDown04.EndInit();
            this.numericUpDown33.EndInit();
            this.numericUpDown23.EndInit();
            this.numericUpDown13.EndInit();
            this.numericUpDown03.EndInit();
            this.numericUpDown32.EndInit();
            this.numericUpDown22.EndInit();
            this.numericUpDown12.EndInit();
            this.numericUpDown02.EndInit();
            this.numericUpDown31.EndInit();
            this.numericUpDown21.EndInit();
            this.numericUpDown11.EndInit();
            this.numericUpDown01.EndInit();
            this.numericUpDown00.EndInit();
            this.numericUpDown10.EndInit();
            this.numericUpDown20.EndInit();
            this.numericUpDown30.EndInit();
            this.tabPageSCJD.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            ((ISupportInitialize) this.dataGridViewCJDHH).EndInit();
            base.ResumeLayout(false);
        }

        private int LocateMarketID(Market market)
        {
            int num = -1;
            switch (market)
            {
                case Market.本地:
                    num = 0;
                    break;

                case Market.区域:
                    num = 1;
                    break;

                case Market.国内:
                    num = 2;
                    break;

                case Market.亚洲:
                    num = 3;
                    break;

                case Market.国际:
                    num = 4;
                    break;

                default:
                    break;
            }
            return num;
        }

        private int LocateProductID(ProductAttribute product)
        {
            int num = -1;
            switch (product)
            {
                case ProductAttribute.P1:
                    num = 0;
                    break;

                case ProductAttribute.P2:
                    num = 1;
                    break;

                case ProductAttribute.P3:
                    num = 2;
                    break;

                case ProductAttribute.P4:
                    num = 3;
                    break;

                default:
                    break;
            }
            return num;
        }

        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            int num = Convert.ToUInt16(((NumericUpDown) sender).Value);
            string name = ((NumericUpDown) sender).Name;
            if (name != null)
            {
                int num2;
                if (<PrivateImplementationDetails>{FAF84281-B764-49BB-8026-1DA8F9FEA525}.$$method0x6000044-1 == null)
                {
                    Dictionary<string, int> dictionary1 = new Dictionary<string, int>(0x16);
                    dictionary1.Add("numericUpDown00", 0);
                    dictionary1.Add("numericUpDown01", 1);
                    dictionary1.Add("numericUpDown02", 2);
                    dictionary1.Add("numericUpDown03", 3);
                    dictionary1.Add("numericUpDown04", 4);
                    dictionary1.Add("numericUpDown10", 5);
                    dictionary1.Add("numericUpDown11", 6);
                    dictionary1.Add("numericUpDown12", 7);
                    dictionary1.Add("numericUpDown13", 8);
                    dictionary1.Add("numericUpDown14", 9);
                    dictionary1.Add("numericUpDown14000", 10);
                    dictionary1.Add("numericUpDown20", 11);
                    dictionary1.Add("numericUpDown21", 12);
                    dictionary1.Add("numericUpDown22", 13);
                    dictionary1.Add("numericUpDown23", 14);
                    dictionary1.Add("numericUpDown24", 15);
                    dictionary1.Add("numericUpDown30", 0x10);
                    dictionary1.Add("numericUpDown31", 0x11);
                    dictionary1.Add("numericUpDown32", 0x12);
                    dictionary1.Add("numericUpDown33", 0x13);
                    dictionary1.Add("numericUpDown34", 20);
                    dictionary1.Add("numericUpDown9000", 0x15);
                    <PrivateImplementationDetails>{FAF84281-B764-49BB-8026-1DA8F9FEA525}.$$method0x6000044-1 = dictionary1;
                }
                if (<PrivateImplementationDetails>{FAF84281-B764-49BB-8026-1DA8F9FEA525}.$$method0x6000044-1.TryGetValue(name, out num2))
                {
                    switch (num2)
                    {
                        case 0:
                            this.advertisingTable[0, 0].Cost = num;
                            return;

                        case 1:
                            this.advertisingTable[0, 1].Cost = num;
                            return;

                        case 2:
                            this.advertisingTable[0, 2].Cost = num;
                            return;

                        case 3:
                            this.advertisingTable[0, 3].Cost = num;
                            return;

                        case 4:
                            this.advertisingTable[0, 4].Cost = num;
                            return;

                        case 5:
                            this.advertisingTable[1, 0].Cost = num;
                            return;

                        case 6:
                            this.advertisingTable[1, 1].Cost = num;
                            return;

                        case 7:
                            this.advertisingTable[1, 2].Cost = num;
                            return;

                        case 8:
                            this.advertisingTable[1, 3].Cost = num;
                            return;

                        case 9:
                            this.advertisingTable[1, 4].Cost = num;
                            return;

                        case 10:
                            this.adv14000.Cost = num;
                            return;

                        case 11:
                            this.advertisingTable[2, 0].Cost = num;
                            return;

                        case 12:
                            this.advertisingTable[2, 1].Cost = num;
                            return;

                        case 13:
                            this.advertisingTable[2, 2].Cost = num;
                            return;

                        case 14:
                            this.advertisingTable[2, 3].Cost = num;
                            return;

                        case 15:
                            this.advertisingTable[2, 4].Cost = num;
                            return;

                        case 0x10:
                            this.advertisingTable[3, 0].Cost = num;
                            return;

                        case 0x11:
                            this.advertisingTable[3, 1].Cost = num;
                            return;

                        case 0x12:
                            this.advertisingTable[3, 2].Cost = num;
                            return;

                        case 0x13:
                            this.advertisingTable[3, 3].Cost = num;
                            return;

                        case 20:
                            this.advertisingTable[3, 4].Cost = num;
                            return;

                        case 0x15:
                            this.adv9000.Cost = num;
                            break;

                        default:
                            return;
                    }
                }
            }
        }

        private void SetAsiaOrderBy()
        {
            ArrayList list = new ArrayList();
            if (TGlobals.currentActor.AdvCostAsiaMarket != 0)
            {
                if (TGlobals.currentActor.IsAsiaMarketLeader)
                {
                    list.Add(new TAdvCostOfPlayer(TGlobals.currentActor.ActorID, 500));
                }
                else
                {
                    list.Add(new TAdvCostOfPlayer(TGlobals.currentActor.ActorID, TGlobals.currentActor.AdvCostAsiaMarket));
                }
            }
            for (int i = 0; i < TGlobals.computerPlayers.Length; i++)
            {
                if (TGlobals.computerPlayers[i].IsLiving(TGlobals.currentActor.RunningYear))
                {
                    int advCost = TGlobals.computerPlayers[i].GetAdvCost(TGlobals.currentActor.RunningYear, Market.亚洲);
                    if (advCost != 0)
                    {
                        list.Add(new TAdvCostOfPlayer(TGlobals.computerPlayers[i].ComputerPlayerID, advCost));
                    }
                }
            }
            if (list.Count != 0)
            {
                this.AsiaOrderBy.Insert(0, list[0]);
            }
            int num3 = 1;
            while (num3 < list.Count)
            {
                int advCost = ((TAdvCostOfPlayer) list[num3]).AdvCost;
                int index = 0;
                while (true)
                {
                    if (index < this.AsiaOrderBy.Count)
                    {
                        if (((TAdvCostOfPlayer) this.AsiaOrderBy[index]).AdvCost > advCost)
                        {
                            index++;
                            continue;
                        }
                    }
                    if (index == this.AsiaOrderBy.Count)
                    {
                        this.AsiaOrderBy.Add(list[num3]);
                    }
                    else
                    {
                        this.AsiaOrderBy.Insert(index, list[num3]);
                    }
                    num3++;
                    break;
                }
            }
        }

        private void SetDomesticOrderBy()
        {
            ArrayList list = new ArrayList();
            if (TGlobals.currentActor.AdvCostDomesticMarket != 0)
            {
                if (TGlobals.currentActor.IsDomesticMarketLeader)
                {
                    list.Add(new TAdvCostOfPlayer(TGlobals.currentActor.ActorID, 500));
                }
                else
                {
                    list.Add(new TAdvCostOfPlayer(TGlobals.currentActor.ActorID, TGlobals.currentActor.AdvCostDomesticMarket));
                }
            }
            for (int i = 0; i < TGlobals.computerPlayers.Length; i++)
            {
                if (TGlobals.computerPlayers[i].IsLiving(TGlobals.currentActor.RunningYear))
                {
                    int advCost = TGlobals.computerPlayers[i].GetAdvCost(TGlobals.currentActor.RunningYear, Market.国内);
                    if (advCost != 0)
                    {
                        list.Add(new TAdvCostOfPlayer(TGlobals.computerPlayers[i].ComputerPlayerID, advCost));
                    }
                }
            }
            if (list.Count != 0)
            {
                this.DomesticOrderBy.Insert(0, list[0]);
            }
            int num3 = 1;
            while (num3 < list.Count)
            {
                int advCost = ((TAdvCostOfPlayer) list[num3]).AdvCost;
                int index = 0;
                while (true)
                {
                    if (index < this.DomesticOrderBy.Count)
                    {
                        if (((TAdvCostOfPlayer) this.DomesticOrderBy[index]).AdvCost > advCost)
                        {
                            index++;
                            continue;
                        }
                    }
                    if (index == this.DomesticOrderBy.Count)
                    {
                        this.DomesticOrderBy.Add(list[num3]);
                    }
                    else
                    {
                        this.DomesticOrderBy.Insert(index, list[num3]);
                    }
                    num3++;
                    break;
                }
            }
        }

        private void SetInternationalOrderBy()
        {
            ArrayList list = new ArrayList();
            if (TGlobals.currentActor.AdvCostInternationalMarket != 0)
            {
                if (TGlobals.currentActor.IsInternationalMarketLeader)
                {
                    list.Add(new TAdvCostOfPlayer(TGlobals.currentActor.ActorID, 500));
                }
                else
                {
                    list.Add(new TAdvCostOfPlayer(TGlobals.currentActor.ActorID, TGlobals.currentActor.AdvCostInternationalMarket));
                }
            }
            for (int i = 0; i < TGlobals.computerPlayers.Length; i++)
            {
                if (TGlobals.computerPlayers[i].IsLiving(TGlobals.currentActor.RunningYear))
                {
                    int advCost = TGlobals.computerPlayers[i].GetAdvCost(TGlobals.currentActor.RunningYear, Market.国际);
                    if (advCost != 0)
                    {
                        list.Add(new TAdvCostOfPlayer(TGlobals.computerPlayers[i].ComputerPlayerID, advCost));
                    }
                }
            }
            if (list.Count != 0)
            {
                this.InternationalOrderBy.Insert(0, list[0]);
            }
            int num3 = 1;
            while (num3 < list.Count)
            {
                int advCost = ((TAdvCostOfPlayer) list[num3]).AdvCost;
                int index = 0;
                while (true)
                {
                    if (index < this.InternationalOrderBy.Count)
                    {
                        if (((TAdvCostOfPlayer) this.InternationalOrderBy[index]).AdvCost > advCost)
                        {
                            index++;
                            continue;
                        }
                    }
                    if (index == this.InternationalOrderBy.Count)
                    {
                        this.InternationalOrderBy.Add(list[num3]);
                    }
                    else
                    {
                        this.InternationalOrderBy.Insert(index, list[num3]);
                    }
                    this.InternationalOrderBy.Insert(index, list[num3]);
                    num3++;
                    break;
                }
            }
        }

        private void SetLocalOrderBy()
        {
            ArrayList list = new ArrayList();
            if (TGlobals.currentActor.AdvCostLocalMarket != 0)
            {
                if (TGlobals.currentActor.IsLocalMarkertLeader)
                {
                    list.Add(new TAdvCostOfPlayer(TGlobals.currentActor.ActorID, 500));
                }
                else
                {
                    list.Add(new TAdvCostOfPlayer(TGlobals.currentActor.ActorID, TGlobals.currentActor.AdvCostLocalMarket));
                }
            }
            for (int i = 0; i < TGlobals.computerPlayers.Length; i++)
            {
                if (TGlobals.computerPlayers[i].IsLiving(TGlobals.currentActor.RunningYear))
                {
                    int advCost = TGlobals.computerPlayers[i].GetAdvCost(TGlobals.currentActor.RunningYear, Market.本地);
                    if (advCost != 0)
                    {
                        list.Add(new TAdvCostOfPlayer(TGlobals.computerPlayers[i].ComputerPlayerID, advCost));
                    }
                }
            }
            if (list.Count != 0)
            {
                this.LocalOrderBy.Insert(0, list[0]);
            }
            int num3 = 1;
            while (num3 < list.Count)
            {
                int advCost = ((TAdvCostOfPlayer) list[num3]).AdvCost;
                int index = 0;
                while (true)
                {
                    if (index < this.LocalOrderBy.Count)
                    {
                        if (((TAdvCostOfPlayer) this.LocalOrderBy[index]).AdvCost > advCost)
                        {
                            index++;
                            continue;
                        }
                    }
                    if (index == this.LocalOrderBy.Count)
                    {
                        this.LocalOrderBy.Add(list[num3]);
                    }
                    else
                    {
                        this.LocalOrderBy.Insert(index, list[num3]);
                    }
                    num3++;
                    break;
                }
            }
        }

        private void SetRegionalOrderBy()
        {
            ArrayList list = new ArrayList();
            if (TGlobals.currentActor.AdvCostRegionalMarket != 0)
            {
                if (TGlobals.currentActor.IsRegionalMarketLeader)
                {
                    list.Add(new TAdvCostOfPlayer(TGlobals.currentActor.ActorID, 500));
                }
                else
                {
                    list.Add(new TAdvCostOfPlayer(TGlobals.currentActor.ActorID, TGlobals.currentActor.AdvCostRegionalMarket));
                }
            }
            for (int i = 0; i < TGlobals.computerPlayers.Length; i++)
            {
                if (TGlobals.computerPlayers[i].IsLiving(TGlobals.currentActor.RunningYear))
                {
                    int advCost = TGlobals.computerPlayers[i].GetAdvCost(TGlobals.currentActor.RunningYear, Market.区域);
                    if (advCost != 0)
                    {
                        list.Add(new TAdvCostOfPlayer(TGlobals.computerPlayers[i].ComputerPlayerID, advCost));
                    }
                }
            }
            if (list.Count != 0)
            {
                this.RegionalOrderBy.Insert(0, list[0]);
            }
            int num3 = 1;
            while (num3 < list.Count)
            {
                int advCost = ((TAdvCostOfPlayer) list[num3]).AdvCost;
                int index = 0;
                while (true)
                {
                    if (index < this.RegionalOrderBy.Count)
                    {
                        if (((TAdvCostOfPlayer) this.RegionalOrderBy[index]).AdvCost > advCost)
                        {
                            index++;
                            continue;
                        }
                    }
                    if (index == this.RegionalOrderBy.Count)
                    {
                        this.RegionalOrderBy.Add(list[num3]);
                    }
                    else
                    {
                        this.RegionalOrderBy.Insert(index, list[num3]);
                    }
                    num3++;
                    break;
                }
            }
        }

        private void StartSelectOrder(Market market)
        {
            if (!this.selectOrderFlag)
            {
                this.buttonLocal.Enabled = false;
                this.buttonRegional.Enabled = false;
                this.buttonDomestic.Enabled = false;
                this.buttonAsia.Enabled = false;
                this.buttonInternational.Enabled = false;
                this.richTextBoxMeetingInfor.AppendText("\n******************" + market.ToString() + "选单开始******************");
                this.richTextBoxMeetingInfor.AppendText("\n根据投放广告数额和市场地位确定竞单顺序......");
                this.richTextBoxMeetingInfor.Focus();
                this.selectOrderFlag = true;
            }
            ArrayList localOrderBy = new ArrayList();
            switch (market)
            {
                case Market.本地:
                    localOrderBy = this.LocalOrderBy;
                    break;

                case Market.区域:
                    localOrderBy = this.RegionalOrderBy;
                    break;

                case Market.国内:
                    localOrderBy = this.DomesticOrderBy;
                    break;

                case Market.亚洲:
                    localOrderBy = this.AsiaOrderBy;
                    break;

                case Market.国际:
                    localOrderBy = this.InternationalOrderBy;
                    break;

                default:
                    break;
            }
            int startID = this.startID;
            while (startID < localOrderBy.Count)
            {
                bool isGiveup = true;
                int index = 0;
                while (true)
                {
                    string str;
                    if (index < TGlobals.computerPlayers.Length)
                    {
                        if (!TGlobals.computerPlayers[index].IsLiving(TGlobals.currentActor.RunningYear) || (TGlobals.computerPlayers[index].GetOrderCount(TGlobals.currentActor.RunningYear, market) <= 0))
                        {
                            index++;
                            continue;
                        }
                        isGiveup = false;
                    }
                    if ((this.advCost > 0) && isGiveup)
                    {
                        isGiveup = this.isGiveup;
                    }
                    if ((this.dataGridViewCJDHH.Rows.Count == 0) || isGiveup)
                    {
                        switch (market)
                        {
                            case Market.本地:
                                if (this.HasAdvCost(Market.区域))
                                {
                                    this.richTextBoxMeetingInfor.AppendText("\n******************" + market.ToString() + "选单结束******************");
                                    this.richTextBoxMeetingInfor.Focus();
                                    this.selectOrderFlag = false;
                                    this.startID = 0;
                                    this.isGiveup = false;
                                    this.buttonRegional.Enabled = true;
                                    this.buttonOK.Enabled = false;
                                    this.buttonGiveUp.Enabled = false;
                                    return;
                                }
                                this.richTextBoxMeetingInfor.AppendText("\n*********************订货会结束*********************");
                                this.richTextBoxMeetingInfor.Focus();
                                this.selectOrderFlag = false;
                                this.startID = 0;
                                this.isGiveup = false;
                                this.buttonOK.Enabled = false;
                                this.buttonGiveUp.Enabled = false;
                                this.buttonFinish.Enabled = true;
                                return;

                            case Market.区域:
                                if (this.HasAdvCost(Market.国内))
                                {
                                    this.richTextBoxMeetingInfor.AppendText("\n******************" + market.ToString() + "选单结束******************");
                                    this.richTextBoxMeetingInfor.Focus();
                                    this.selectOrderFlag = false;
                                    this.startID = 0;
                                    this.isGiveup = false;
                                    this.buttonDomestic.Enabled = true;
                                    this.buttonOK.Enabled = false;
                                    this.buttonGiveUp.Enabled = false;
                                    return;
                                }
                                this.richTextBoxMeetingInfor.AppendText("\n*********************订货会结束*********************");
                                this.richTextBoxMeetingInfor.Focus();
                                this.selectOrderFlag = false;
                                this.startID = 0;
                                this.isGiveup = false;
                                this.buttonOK.Enabled = false;
                                this.buttonGiveUp.Enabled = false;
                                this.buttonFinish.Enabled = true;
                                return;

                            case Market.国内:
                                if (this.HasAdvCost(Market.亚洲))
                                {
                                    this.richTextBoxMeetingInfor.AppendText("\n******************" + market.ToString() + "选单结束******************");
                                    this.richTextBoxMeetingInfor.Focus();
                                    this.selectOrderFlag = false;
                                    this.startID = 0;
                                    this.isGiveup = false;
                                    this.buttonAsia.Enabled = true;
                                    this.buttonOK.Enabled = false;
                                    this.buttonGiveUp.Enabled = false;
                                    return;
                                }
                                this.richTextBoxMeetingInfor.AppendText("\n*********************订货会结束*********************");
                                this.richTextBoxMeetingInfor.Focus();
                                this.selectOrderFlag = false;
                                this.startID = 0;
                                this.isGiveup = false;
                                this.buttonOK.Enabled = false;
                                this.buttonGiveUp.Enabled = false;
                                this.buttonFinish.Enabled = true;
                                return;

                            case Market.亚洲:
                                if (this.HasAdvCost(Market.国际))
                                {
                                    this.richTextBoxMeetingInfor.AppendText("\n******************" + market.ToString() + "选单结束******************");
                                    this.richTextBoxMeetingInfor.Focus();
                                    this.selectOrderFlag = false;
                                    this.startID = 0;
                                    this.isGiveup = false;
                                    this.buttonInternational.Enabled = true;
                                    this.buttonOK.Enabled = false;
                                    this.buttonGiveUp.Enabled = false;
                                    return;
                                }
                                this.richTextBoxMeetingInfor.AppendText("\n*********************订货会结束*********************");
                                this.richTextBoxMeetingInfor.Focus();
                                this.selectOrderFlag = false;
                                this.startID = 0;
                                this.isGiveup = false;
                                this.buttonOK.Enabled = false;
                                this.buttonGiveUp.Enabled = false;
                                this.buttonFinish.Enabled = true;
                                return;

                            case Market.国际:
                                this.richTextBoxMeetingInfor.AppendText("\n*********************订货会结束*********************");
                                this.richTextBoxMeetingInfor.Focus();
                                this.selectOrderFlag = false;
                                this.startID = 0;
                                this.isGiveup = false;
                                this.buttonOK.Enabled = false;
                                this.buttonGiveUp.Enabled = false;
                                this.buttonFinish.Enabled = true;
                                return;

                            default:
                                break;
                        }
                    }
                    int playerID = ((TAdvCostOfPlayer) localOrderBy[startID]).PlayerID;
                    if (playerID == 6)
                    {
                        str = "\n" + TGlobals.currentActor.ActorName + "开始选单......";
                        this.richTextBoxMeetingInfor.AppendText(str);
                        MessageBox.Show(str, "重要提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        this.richTextBoxMeetingInfor.Focus();
                        this.startID = (startID != (localOrderBy.Count - 1)) ? (startID + 1) : 0;
                        this.buttonOK.Enabled = true;
                        this.buttonGiveUp.Enabled = true;
                        return;
                    }
                    if (TGlobals.computerPlayers[playerID].GetOrderCount(TGlobals.currentActor.RunningYear, market) > 0)
                    {
                        int num5 = 0;
                        int num6 = -1;
                        int num7 = 0;
                        while (true)
                        {
                            if (num7 >= this.dataGridViewCJDHH.RowCount)
                            {
                                this.dataGridViewCJDHH.Rows[num6].Selected = true;
                                object[] objArray = new object[] { "\n", TGlobals.computerPlayers[playerID].ComputerPlayerName, " 开始选单......\n", TGlobals.computerPlayers[playerID].ComputerPlayerName, " 选择了编号为:", this.dataGridViewCJDHH.Rows[num6].Cells["编号"].Value, "的订单" };
                                str = string.Concat(objArray);
                                this.richTextBoxMeetingInfor.AppendText(str);
                                MessageBox.Show(str, "重要提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                this.richTextBoxMeetingInfor.Focus();
                                switch (market)
                                {
                                    case Market.本地:
                                        TGlobals.computerPlayers[playerID].LocalMarketAmount += Convert.ToInt16(this.dataGridViewCJDHH.Rows[num6].Cells["金额"].Value);
                                        break;

                                    case Market.区域:
                                        TGlobals.computerPlayers[playerID].RegionalMarketAmount += Convert.ToInt16(this.dataGridViewCJDHH.Rows[num6].Cells["金额"].Value);
                                        break;

                                    case Market.国内:
                                        TGlobals.computerPlayers[playerID].DomesticMarketAmount += Convert.ToInt16(this.dataGridViewCJDHH.Rows[num6].Cells["金额"].Value);
                                        break;

                                    case Market.亚洲:
                                        TGlobals.computerPlayers[playerID].AsiaMarketAmount += Convert.ToInt16(this.dataGridViewCJDHH.Rows[num6].Cells["金额"].Value);
                                        break;

                                    case Market.国际:
                                        TGlobals.computerPlayers[playerID].InternationalMarketAmount += Convert.ToInt16(this.dataGridViewCJDHH.Rows[num6].Cells["金额"].Value);
                                        break;

                                    default:
                                        break;
                                }
                                this.dataGridViewCJDHH.Rows.RemoveAt(num6);
                                TGlobals.computerPlayers[playerID].ChangeOrderCont(TGlobals.currentActor.RunningYear, market);
                                break;
                            }
                            if (num5 < Convert.ToInt16(this.dataGridViewCJDHH.Rows[num7].Cells["金额"].Value))
                            {
                                num5 = Convert.ToInt16(this.dataGridViewCJDHH.Rows[num7].Cells["金额"].Value);
                                num6 = num7;
                            }
                            num7++;
                        }
                    }
                    startID++;
                    break;
                }
            }
            this.startID = 0;
            this.isGiveup = false;
            this.StartSelectOrder(market);
        }

        private void tabPageTFGG_Click(object sender, EventArgs e)
        {
        }
    }
}

