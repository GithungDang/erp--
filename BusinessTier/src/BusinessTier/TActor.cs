namespace BusinessTier
{
    using System;
    using System.Collections;

    public class TActor
    {

        //*初始变量声明
        // 角色ID
        private int m_actorID = 6;
        // 角色名字
        private string m_actorName;
        // 公司名字
        private string m_companyName;
        // 当前季度
        private Quarter m_runningQuarter;
        // 当前年份
        private Year m_runningYear;
        // YFP2成本
        private int m_YFP2Cost;
        // YFP3成本
        private int m_YFP3Cost;
        // YFP4成本
        private int m_YFP4Cost;
        // 机器器械成本
        private int m_jrQYCost;
        // 机器功能成本
        private int m_jrGNCost;
        // 机器原材料成本
        private int m_jrYZCost;
        // 机器工具成本
        private int m_jrGJCost;
        // ISO9000认证成本
        private int m_tzISO9000Cost;
        // ISO14000认证成本
        private int m_tzISO14000Cost;
        // 是否是本地市场领导者
        private bool m_isLocalMarketLeader;
        // 是否是区域市场领导者
        private bool m_isRegionalMarketLeader;
        // 是否是国内市场领导者
        private bool m_isDomesticMarketLeader;
        // 是否是亚洲市场领导者
        private bool m_isAsiaMarketLeader;
        // 是否是国际市场领导者
        private bool m_isInternationalMarketLeader;
        // 年份和市场的广告成本
        private int[,] m_advCostOfYearAndMarket;
        // ISO认证的广告成本
        private int[] m_advCostISO;
        // 本地市场的广告成本
        private int m_advCostLocalMarket;
        // 区域市场的广告成本
        private int m_advCostRegionalMarket;
        // 国内市场的广告成本
        private int m_advCostDomesticMarket;
        // 亚洲市场的广告成本
        private int m_advCostAsiaMarket;
        // 国际市场的广告成本
        private int m_advCostInternationalMarket;
        // ISO9000认证的广告成本
        private int m_advCostISO9000;
        // ISO14000认证的广告成本
        private int m_advCostISO14000;
        // 承诺订单列表
        private ArrayList m_promisedOrderList = new ArrayList();
        // 违约订单列表
        private ArrayList m_breakPromisedOrderList = new ArrayList();
        // 商业条件数组
        private TBusinessConditions[] m_businessConditions;
        // 当前商业条件
        private TBusinessConditions m_currBusinessConditions;
        // 短期贷款表
        private TShortTermLoansSheet m_shortTermLoanConditions;
        // 长期贷款表
        private TLongTermLoansSheet m_longTermLoanConditions;
        // 放高利贷表
        private TLoanSharkingSheet m_loanSharkingConditions;
        // 原材料库存
        private TRawMaterialStock m_rawMaterialStock;
        // 工厂A
        private TPlant m_plantA;
        // 工厂B
        private TPlant m_plantB;
        // 工厂C
        private TPlant m_plantC;
        // 产品1仓库
        private TProductWarehouse m_p1Warehouse;
        // 产品2仓库
        private TProductWarehouse m_p2Warehouse;
        // 产品3仓库
        private TProductWarehouse m_p3Warehouse;
        // 产品4仓库
        private TProductWarehouse m_p4Warehouse;


//创建一个TActor 类的构造函数。
//它接受两个参数 actorName 、 companyName，并初始化类的各个成员变量。
//首先，它将 m_actorName 和 m_companyName 成员变量分别设置为 
//actorName 和 companyName 参数的值。

//接下来，它使用长度为 7 的 TBusinessConditions 对象数组初始化，
//并将第一个元素分配给新的 TBusinessConditions 对象。它还将其他各种成员变量设置为 0 
//或 false，并初始化广告成本和 ISO 认证成本的数组。

//然后，它创建各种其他类的实例，包括 TShortTermLoansSheet、TLongTermLoansSheet、
//TLoanSharkingSheet、TRawMaterialStock、TPlant 和 TProductWarehouse。
//最后，它将 m_runningYear 和 m_runningQuarter 成员变量设置为第一年和第一季度，
//分别将 m_currBusinessConditions 设置为 m_businessConditions 数组的第一个元素的克隆。
        public TActor(string actorName, string companyName)
        {
            this.m_actorName = actorName;
            this.m_companyName = companyName;
            this.m_businessConditions = new TBusinessConditions[7];
            this.m_businessConditions[0] = new TBusinessConditions();
            this.m_YFP2Cost = 0;
            this.m_YFP3Cost = 0;
            this.m_YFP4Cost = 0;
            this.m_jrGNCost = 0;
            this.m_jrQYCost = 0;
            this.m_jrYZCost = 0;
            this.m_jrGJCost = 0;
            this.m_tzISO9000Cost = 0;
            this.m_tzISO14000Cost = 0;
            this.m_isLocalMarketLeader = false;
            this.m_isRegionalMarketLeader = false;
            this.m_isDomesticMarketLeader = false;
            this.m_isAsiaMarketLeader = false;
            this.m_isInternationalMarketLeader = false;
            this.m_advCostLocalMarket = 0;
            this.m_advCostRegionalMarket = 0;
            this.m_advCostDomesticMarket = 0;
            this.m_advCostAsiaMarket = 0;
            this.m_advCostInternationalMarket = 0;
            this.m_advCostOfYearAndMarket = new int[6, 5];
            int num = 0;
            while (num < 6)
            {
                int num2 = 0;
                while (true)
                {
                    if (num2 >= 5)
                    {
                        num++;
                        break;
                    }
                    this.m_advCostOfYearAndMarket[num, num2] = 0;
                    num2++;
                }
            }
            this.m_advCostISO = new int[6];
            for (int i = 0; i < 6; i++)
            {
                this.m_advCostISO[i] = 0;
            }
            this.m_shortTermLoanConditions = new TShortTermLoansSheet();
            this.m_longTermLoanConditions = new TLongTermLoansSheet();
            this.m_loanSharkingConditions = new TLoanSharkingSheet();
            this.m_rawMaterialStock = new TRawMaterialStock();
            this.m_plantA = new TPlant(PlantAttribute.无, PlantName.工厂A);
            this.m_plantB = new TPlant(PlantAttribute.无, PlantName.工厂B);
            this.m_plantC = new TPlant(PlantAttribute.无, PlantName.工厂C);
            this.m_p1Warehouse = new TProductWarehouse(0);
            this.m_p2Warehouse = new TProductWarehouse(0);
            this.m_p3Warehouse = new TProductWarehouse(0);
            this.m_p4Warehouse = new TProductWarehouse(0);
            this.m_runningYear = Year.第1年;
            this.m_runningQuarter = Quarter.第1季;
            this.m_currBusinessConditions = this.m_businessConditions[0].Clone();
        }

        public void AddOrderToBreakPromisedList(TOrder order)
        {
            if (order == null)
            {
                throw new Exception("传入order为null");
            }
            switch (this.m_runningYear)
            {
                case Year.第1年:
                    order.CHWYYear = Year.第2年;
                    order.BreakPromise = true;
                    order.ISJH = false;
                    break;

                case Year.第2年:
                    order.CHWYYear = Year.第3年;
                    order.BreakPromise = true;
                    order.ISJH = false;
                    break;

                case Year.第3年:
                    order.CHWYYear = Year.第4年;
                    order.BreakPromise = true;
                    order.ISJH = false;
                    break;

                case Year.第4年:
                    order.CHWYYear = Year.第5年;
                    order.BreakPromise = true;
                    order.ISJH = false;
                    break;

                case Year.第5年:
                    order.CHWYYear = Year.第6年;
                    order.BreakPromise = true;
                    order.ISJH = false;
                    break;

                case Year.第6年:
                    order.CHWYYear = Year.第7年;
                    order.BreakPromise = true;
                    order.ISJH = false;
                    break;

                default:
                    break;
            }
            this.m_breakPromisedOrderList.Add(order);
        }

        public void AddOrderToPromisedList(TOrder order)
        {
            if (order == null)
            {
                throw new Exception("传入order为null");
            }
            this.m_promisedOrderList.Add(order);
        }

        public void CalculationOfTheFinancialStatements()
        {
            this.CurrBusinessConditions.CashFlowSheet.Sales = (this.CurrBusinessConditions.PromisedOrderSheet.TotalAmount + this.CurrBusinessConditions.NotPromisedOrderSheet.TotalAmount) - this.CurrBusinessConditions.NotPromisedOrderSheet.TotalBreakPromiseCost;
            this.CurrBusinessConditions.CashFlowSheet.DirectCost = this.CurrBusinessConditions.PromisedOrderSheet.TotalDirectCost + this.CurrBusinessConditions.NotPromisedOrderSheet.TotalDirectCost;
            this.CurrBusinessConditions.CashFlowSheet.ComprehensiveCost = this.CurrBusinessConditions.ComprehensiveCostSheet.Total;
            this.CurrBusinessConditions.CashFlowSheet.Depreciation = this.CurrBusinessConditions.FinancialSheet.Depreciation;
            this.CurrBusinessConditions.CashFlowSheet.FinancialExpenditure = this.CurrBusinessConditions.FinancialSheet.Interest + this.CurrBusinessConditions.FinancialSheet.Discount;
            this.CurrBusinessConditions.CashFlowSheet.AdditionalRevenue = this.CurrBusinessConditions.FinancialSheet.AdditionalRevenue;
            this.CurrBusinessConditions.CashFlowSheet.AdditionalExpenditure = this.CurrBusinessConditions.FinancialSheet.AdditionalExpenditure;
            this.CurrBusinessConditions.BalanceSheet.LandAndBuildings = this.CurrBusinessConditions.OperatingSheet.Plant;
            this.CurrBusinessConditions.BalanceSheet.EquipmentAndConstruction = this.CurrBusinessConditions.OperatingSheet.EquipmentAndConstruction;
            this.CurrBusinessConditions.BalanceSheet.CurrentCash = this.CurrBusinessConditions.OperatingSheet.CurrentCash;
            this.CurrBusinessConditions.BalanceSheet.ReceivableAccounts = this.CurrBusinessConditions.OperatingSheet.ReceivableAccounts;
            this.CurrBusinessConditions.BalanceSheet.AreProducts = this.CurrBusinessConditions.OperatingSheet.AreProducts;
            this.CurrBusinessConditions.BalanceSheet.FinishedProduct = this.CurrBusinessConditions.OperatingSheet.FinishedProduct;
            this.CurrBusinessConditions.BalanceSheet.RawMaterials = this.CurrBusinessConditions.OperatingSheet.RawMaterials;
            this.CurrBusinessConditions.BalanceSheet.LongtermLiabilities = this.CurrBusinessConditions.OperatingSheet.LongTermLoans;
            this.CurrBusinessConditions.BalanceSheet.shortTermLiabilities = this.CurrBusinessConditions.OperatingSheet.ShortTermLoans + this.CurrBusinessConditions.OperatingSheet.LoanSharking;
            this.CurrBusinessConditions.BalanceSheet.CapitalShareholders = this.CurrBusinessConditions.BalanceSheet.CapitalShareholders;
            this.CurrBusinessConditions.BalanceSheet.RetainedProfits += this.CurrBusinessConditions.BalanceSheet.NetProfit;
            this.CurrBusinessConditions.CashFlowSheet.IncomeTax = (((this.CurrBusinessConditions.BalanceSheet.RetainedProfits + this.CurrBusinessConditions.CashFlowSheet.NetProfit) <= 0) || (this.CurrBusinessConditions.CashFlowSheet.PretaxProfit <= 0)) ? 0 : ((this.CurrBusinessConditions.BalanceSheet.RetainedProfits >= 0) ? Convert.ToInt16(Math.Round((double) (this.CurrBusinessConditions.CashFlowSheet.PretaxProfit * 0.25), 0)) : Convert.ToInt16(Math.Round((double) ((this.CurrBusinessConditions.BalanceSheet.RetainedProfits + this.CurrBusinessConditions.CashFlowSheet.NetProfit) * 0.25), 0)));
            this.CurrBusinessConditions.BalanceSheet.Taxes = this.CurrBusinessConditions.CashFlowSheet.IncomeTax;
            this.CurrBusinessConditions.BalanceSheet.NetProfit = this.CurrBusinessConditions.CashFlowSheet.NetProfit;
        }

        public void CheckOutAtEndOfYear()
        {
            switch (this.m_runningYear)
            {
                case Year.第1年:
                    this.m_businessConditions[1] = this.m_currBusinessConditions;
                    this.m_currBusinessConditions = this.m_businessConditions[1].Clone();
                    this.m_currBusinessConditions.NotPromisedOrderSheet.OrderSet = this.GetBreakPromisedOrder(Year.第2年);
                    return;

                case Year.第2年:
                    this.m_businessConditions[2] = this.m_currBusinessConditions;
                    this.m_currBusinessConditions = this.m_businessConditions[2].Clone();
                    this.m_currBusinessConditions.NotPromisedOrderSheet.OrderSet = this.GetBreakPromisedOrder(Year.第3年);
                    return;

                case Year.第3年:
                    this.m_businessConditions[3] = this.m_currBusinessConditions;
                    this.m_currBusinessConditions = this.m_businessConditions[3].Clone();
                    this.m_currBusinessConditions.NotPromisedOrderSheet.OrderSet = this.GetBreakPromisedOrder(Year.第4年);
                    return;

                case Year.第4年:
                    this.m_businessConditions[4] = this.m_currBusinessConditions;
                    this.m_currBusinessConditions = this.m_businessConditions[4].Clone();
                    this.m_currBusinessConditions.NotPromisedOrderSheet.OrderSet = this.GetBreakPromisedOrder(Year.第5年);
                    return;

                case Year.第5年:
                    this.m_businessConditions[5] = this.m_currBusinessConditions;
                    this.m_currBusinessConditions = this.m_businessConditions[5].Clone();
                    this.m_currBusinessConditions.NotPromisedOrderSheet.OrderSet = this.GetBreakPromisedOrder(Year.第6年);
                    return;

                case Year.第6年:
                    this.m_businessConditions[6] = this.m_currBusinessConditions;
                    this.m_currBusinessConditions = this.m_businessConditions[6].Clone();
                    this.m_currBusinessConditions.NotPromisedOrderSheet.OrderSet = this.GetBreakPromisedOrder(Year.第7年);
                    return;
            }
        }

        private int GetAccreditationScore()
        {
            int num = 0;
            if (this.IsEnterRegionalMarket)
            {
                num += 10;
            }
            if (this.IsEnterDomesticMarket)
            {
                num += 15;
            }
            if (this.IsEnterAsiaMarket)
            {
                num += 20;
            }
            if (this.IsEnterInternationalMarket)
            {
                num += 0x19;
            }
            if (this.IsCertified9000)
            {
                num += 10;
            }
            if (this.IsCertified14000)
            {
                num += 15;
            }
            if (this.HasP2Capacity)
            {
                num += 5;
            }
            if (this.HasP3Capacity)
            {
                num += 10;
            }
            if (this.HasP4Capacity)
            {
                num += 15;
            }
            return num;
        }

        public int GetAdvCostOfYearAndMarket(Year year, Market market)
        {
            int num3;
            int num = this.LocateYearID(year);
            int num2 = this.LocateMarketID(market);
            try
            {
                num3 = this.m_advCostOfYearAndMarket[num, num2];
            }
            catch
            {
                throw new Exception("输入的年份和市场有误！");
            }
            return num3;
        }

        public int GetAdvTatalCostOfYear(Year year)
        {
            int index = this.LocateYearID(year);
            int num2 = 0;
            for (int i = 0; i < 5; i++)
            {
                num2 += this.m_advCostOfYearAndMarket[index, i];
            }
            return (num2 + this.m_advCostISO[index]);
        }

        public TOrder[] GetBreakPromisedOrder(Year year)
        {
            TOrder[] orderArray;
            ArrayList list = new ArrayList();
            for (int i = 0; i < this.m_breakPromisedOrderList.Count; i++)
            {
                Year cHWYYear = ((TOrder) this.m_breakPromisedOrderList[i]).CHWYYear;
                if (year == cHWYYear)
                {
                    list.Add(this.m_breakPromisedOrderList[i]);
                }
            }
            if (list.Count == 0)
            {
                orderArray = null;
            }
            else
            {
                TOrder[] orderArray2 = new TOrder[list.Count];
                int index = 0;
                while (true)
                {
                    if (index >= orderArray2.Length)
                    {
                        orderArray = orderArray2;
                        break;
                    }
                    orderArray2[index] = (TOrder) list[index];
                    index++;
                }
            }
            return orderArray;
        }

        public TOrder[] GetBreakPromisedWHOrder(Year year)
        {
            TOrder[] orderArray;
            ArrayList list = new ArrayList();
            for (int i = 0; i < this.m_breakPromisedOrderList.Count; i++)
            {
                Year cHWYYear = ((TOrder) this.m_breakPromisedOrderList[i]).CHWYYear;
                bool iSJH = ((TOrder) this.m_breakPromisedOrderList[i]).ISJH;
                if ((year == cHWYYear) && !iSJH)
                {
                    list.Add(this.m_breakPromisedOrderList[i]);
                }
            }
            if (list.Count == 0)
            {
                orderArray = null;
            }
            else
            {
                TOrder[] orderArray2 = new TOrder[list.Count];
                int index = 0;
                while (true)
                {
                    if (index >= orderArray2.Length)
                    {
                        orderArray = orderArray2;
                        break;
                    }
                    orderArray2[index] = (TOrder) list[index];
                    index++;
                }
            }
            return orderArray;
        }

        public TBusinessConditions GetBusinessConditions(Year year)
        {
            TBusinessConditions conditions;
            switch (year)
            {
                case Year.第0年:
                    conditions = this.m_businessConditions[0];
                    break;

                case Year.第1年:
                    conditions = this.m_businessConditions[1];
                    break;

                case Year.第2年:
                    conditions = this.m_businessConditions[2];
                    break;

                case Year.第3年:
                    conditions = this.m_businessConditions[3];
                    break;

                case Year.第4年:
                    conditions = this.m_businessConditions[4];
                    break;

                case Year.第5年:
                    conditions = this.m_businessConditions[5];
                    break;

                case Year.第6年:
                    conditions = this.m_businessConditions[6];
                    break;

                case Year.第7年:
                    conditions = this.m_businessConditions[6];
                    break;

                default:
                    conditions = null;
                    break;
            }
            return conditions;
        }

        public double GetFinalScore()
        {
            double num = ((((((((((((((((((((0.0 + this.GetPlantScore()) + this.GetProductLineScore(this.PlantA.PL1)) + this.GetProductLineScore(this.PlantA.PL2)) + this.GetProductLineScore(this.PlantA.PL3)) + this.GetProductLineScore(this.PlantA.PL4)) + this.GetProductLineScore(this.PlantB.PL5)) + this.GetProductLineScore(this.PlantB.PL6)) + this.GetProductLineScore(this.PlantB.PL7)) + this.GetProductLineScore(this.PlantC.PL8)) + this.GetAccreditationScore()) + this.CurrBusinessConditions.BalanceSheet.CurrentCash) + this.CurrBusinessConditions.BalanceSheet.ReceivableAccounts) + this.CurrBusinessConditions.BalanceSheet.AreProducts) + this.CurrBusinessConditions.BalanceSheet.FinishedProduct) + this.CurrBusinessConditions.BalanceSheet.RawMaterials) + this.GetMarketPositionScore()) + (this.LoanSharkingConditions.UsuriousLoans / 20)) - this.LoanSharkingConditions.NotAlsoAmount) - this.ShortTermLoanConditions.NotAlsoAmount) - this.LongTermLoanConditions.NotAlsoAmount) + 40.0;
            return Math.Round((double) (this.CurrBusinessConditions.BalanceSheet.OwnerRight * (1.0 + (num * 0.01))), 2);
        }

        public int GetISO14000SYQS() => 
            4 - this.m_tzISO14000Cost;

        public int GetISO9000SYQS() => 
            2 - this.m_tzISO9000Cost;

        public int GetJRGJSYQS() => 
            4 - this.m_jrGJCost;

        public int GetJRGNSYQS() => 
            2 - this.m_jrGNCost;

        public int GetJRQYSYQS() => 
            1 - this.m_jrQYCost;

        public int GetJRYZSYQS() => 
            3 - this.m_jrYZCost;

        private int GetMarketPositionScore()
        {
            int num = 0;
            if (this.IsLocalMarkertLeader)
            {
                num += 20;
            }
            if (this.IsRegionalMarketLeader)
            {
                num += 20;
            }
            if (this.IsDomesticMarketLeader)
            {
                num += 20;
            }
            if (this.IsAsiaMarketLeader)
            {
                num += 20;
            }
            if (this.IsInternationalMarketLeader)
            {
                num += 20;
            }
            return num;
        }

        private int GetPlantScore()
        {
            int num = 0;
            if (this.PlantA.PlantAttribute == PlantAttribute.购买)
            {
                num += 15;
            }
            if (this.PlantB.PlantAttribute == PlantAttribute.购买)
            {
                num += 10;
            }
            if (this.PlantC.PlantAttribute == PlantAttribute.购买)
            {
                num += 5;
            }
            return num;
        }

        private int GetProductLineScore(TProductLine pl)
        {
            int num = 0;
            switch (pl.PLAttribute)
            {
                case ProductLineAttribute.手工:
                    num += 5;
                    break;

                case ProductLineAttribute.全自动:
                    num += 15;
                    break;

                case ProductLineAttribute.半自动:
                    num += 10;
                    break;

                case ProductLineAttribute.柔性:
                    num += 20;
                    break;

                default:
                    break;
            }
            return num;
        }

        public int GetPromidOrderAmount(Year year, Market market)
        {
            int num;
            TOrder[] promisedOrderList = this.GetPromisedOrderList(year);
            if (promisedOrderList == null)
            {
                num = -1;
            }
            else
            {
                int num2 = 0;
                int index = 0;
                while (true)
                {
                    if (index >= promisedOrderList.Length)
                    {
                        num = num2;
                        break;
                    }
                    if (promisedOrderList[index].Market == market)
                    {
                        num2 += promisedOrderList[index].Amount;
                    }
                    index++;
                }
            }
            return num;
        }

        public TOrder[] GetPromisedMJHOrderList(Year year)
        {
            TOrder[] orderArray;
            ArrayList list = new ArrayList();
            for (int i = 0; i < this.m_promisedOrderList.Count; i++)
            {
                Year year2 = ((TOrder) this.m_promisedOrderList[i]).Year;
                bool iSJH = ((TOrder) this.m_promisedOrderList[i]).ISJH;
                if ((year == year2) && !iSJH)
                {
                    list.Add(this.m_promisedOrderList[i]);
                }
            }
            if (list.Count == 0)
            {
                orderArray = null;
            }
            else
            {
                TOrder[] orderArray2 = new TOrder[list.Count];
                int index = 0;
                while (true)
                {
                    if (index >= orderArray2.Length)
                    {
                        orderArray = orderArray2;
                        break;
                    }
                    orderArray2[index] = (TOrder) list[index];
                    index++;
                }
            }
            return orderArray;
        }

        public TOrder[] GetPromisedOrderList(Year year)
        {
            TOrder[] orderArray;
            ArrayList list = new ArrayList();
            for (int i = 0; i < this.m_promisedOrderList.Count; i++)
            {
                Year year2 = ((TOrder) this.m_promisedOrderList[i]).Year;
                if (year == year2)
                {
                    list.Add(this.m_promisedOrderList[i]);
                }
            }
            if (list.Count == 0)
            {
                orderArray = null;
            }
            else
            {
                TOrder[] orderArray2 = new TOrder[list.Count];
                int index = 0;
                while (true)
                {
                    if (index >= orderArray2.Length)
                    {
                        orderArray = orderArray2;
                        break;
                    }
                    orderArray2[index] = (TOrder) list[index];
                    index++;
                }
            }
            return orderArray;
        }

        public int GetYFP2SYQS() => 
            6 - this.m_YFP2Cost;

        public int GetYFP3SYQS() => 
            6 - (this.m_YFP3Cost / 2);

        public int GetYFP4SYQS() => 
            6 - (this.m_YFP4Cost / 3);

        public void JFBNWWYDD(Year year, string id, ProductAttribute pda)
        {
            for (int i = 0; i < this.m_promisedOrderList.Count; i++)
            {
                Year year2 = ((TOrder) this.m_promisedOrderList[i]).Year;
                string orderID = ((TOrder) this.m_promisedOrderList[i]).OrderID;
                ProductAttribute productName = ((TOrder) this.m_promisedOrderList[i]).ProductName;
                if ((year2 == year) && ((orderID == id) && (productName == pda)))
                {
                    ((TOrder) this.m_promisedOrderList[i]).ISJH = true;
                }
            }
        }

        public void JFWYDD(Year year, string id, ProductAttribute pda)
        {
            for (int i = 0; i < this.m_breakPromisedOrderList.Count; i++)
            {
                Year cHWYYear = ((TOrder) this.m_breakPromisedOrderList[i]).CHWYYear;
                string orderID = ((TOrder) this.m_breakPromisedOrderList[i]).OrderID;
                ProductAttribute productName = ((TOrder) this.m_breakPromisedOrderList[i]).ProductName;
                if ((cHWYYear == year) && ((orderID == id) && (productName == pda)))
                {
                    ((TOrder) this.m_breakPromisedOrderList[i]).ISJH = true;
                }
            }
            for (int j = 0; j < this.CurrBusinessConditions.NotPromisedOrderSheet.OrderSet.Length; j++)
            {
                Year cHWYYear = this.CurrBusinessConditions.NotPromisedOrderSheet.OrderSet[j].CHWYYear;
                string orderID = this.CurrBusinessConditions.NotPromisedOrderSheet.OrderSet[j].OrderID;
                ProductAttribute productName = this.CurrBusinessConditions.NotPromisedOrderSheet.OrderSet[j].ProductName;
                if ((cHWYYear == year) && ((orderID == id) && (productName == pda)))
                {
                    this.CurrBusinessConditions.NotPromisedOrderSheet.OrderSet[j].ISJH = true;
                }
            }
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

        private int LocateYearID(Year year)
        {
            int num = -1;
            switch (year)
            {
                case Year.第1年:
                    num = 0;
                    break;

                case Year.第2年:
                    num = 1;
                    break;

                case Year.第3年:
                    num = 2;
                    break;

                case Year.第4年:
                    num = 3;
                    break;

                case Year.第5年:
                    num = 4;
                    break;

                case Year.第6年:
                    num = 5;
                    break;

                default:
                    break;
            }
            return num;
        }

        private void SetAdvCostISO(Year year, int cost)
        {
            int index = this.LocateYearID(year);
            try
            {
                this.m_advCostISO[index] += cost;
            }
            catch
            {
                throw new Exception("输入的年份有误！");
            }
        }

        private void SetAdvCostOfYearAndMarket(Year year, Market market, int cost)
        {
            int num = this.LocateYearID(year);
            int num2 = this.LocateMarketID(market);
            try
            {
                this.m_advCostOfYearAndMarket[num, num2] = cost;
            }
            catch
            {
                throw new Exception("输入的年份和市场有误！");
            }
        }

        public void UndoCalculationOfTheFinancialStatements()
        {
            TBusinessConditions businessConditions = null;
            switch (this.RunningYear)
            {
                case Year.第1年:
                    businessConditions = this.GetBusinessConditions(Year.第0年);
                    break;

                case Year.第2年:
                    businessConditions = this.GetBusinessConditions(Year.第1年);
                    break;

                case Year.第3年:
                    businessConditions = this.GetBusinessConditions(Year.第2年);
                    break;

                case Year.第4年:
                    businessConditions = this.GetBusinessConditions(Year.第3年);
                    break;

                case Year.第5年:
                    businessConditions = this.GetBusinessConditions(Year.第4年);
                    break;

                case Year.第6年:
                    businessConditions = this.GetBusinessConditions(Year.第5年);
                    break;

                default:
                    break;
            }
            this.CurrBusinessConditions.CashFlowSheet.Sales = businessConditions.CashFlowSheet.Sales;
            this.CurrBusinessConditions.CashFlowSheet.DirectCost = businessConditions.CashFlowSheet.DirectCost;
            this.CurrBusinessConditions.CashFlowSheet.ComprehensiveCost = businessConditions.CashFlowSheet.ComprehensiveCost;
            this.CurrBusinessConditions.CashFlowSheet.Depreciation = businessConditions.CashFlowSheet.Depreciation;
            this.CurrBusinessConditions.CashFlowSheet.FinancialExpenditure = businessConditions.CashFlowSheet.FinancialExpenditure;
            this.CurrBusinessConditions.CashFlowSheet.AdditionalRevenue = businessConditions.CashFlowSheet.AdditionalRevenue;
            this.CurrBusinessConditions.CashFlowSheet.AdditionalExpenditure = businessConditions.CashFlowSheet.AdditionalExpenditure;
            this.CurrBusinessConditions.BalanceSheet.LandAndBuildings = businessConditions.BalanceSheet.LandAndBuildings;
            this.CurrBusinessConditions.BalanceSheet.EquipmentAndConstruction = businessConditions.BalanceSheet.EquipmentAndConstruction;
            this.CurrBusinessConditions.BalanceSheet.CurrentCash = businessConditions.BalanceSheet.CurrentCash;
            this.CurrBusinessConditions.BalanceSheet.ReceivableAccounts = businessConditions.BalanceSheet.ReceivableAccounts;
            this.CurrBusinessConditions.BalanceSheet.AreProducts = businessConditions.BalanceSheet.AreProducts;
            this.CurrBusinessConditions.BalanceSheet.FinishedProduct = businessConditions.BalanceSheet.FinishedProduct;
            this.CurrBusinessConditions.BalanceSheet.RawMaterials = businessConditions.BalanceSheet.RawMaterials;
            this.CurrBusinessConditions.BalanceSheet.LongtermLiabilities = businessConditions.BalanceSheet.LongtermLiabilities;
            this.CurrBusinessConditions.BalanceSheet.shortTermLiabilities = businessConditions.BalanceSheet.shortTermLiabilities;
            this.CurrBusinessConditions.BalanceSheet.CapitalShareholders = businessConditions.BalanceSheet.CapitalShareholders;
            this.CurrBusinessConditions.BalanceSheet.RetainedProfits = businessConditions.BalanceSheet.RetainedProfits;
            this.CurrBusinessConditions.CashFlowSheet.IncomeTax = businessConditions.CashFlowSheet.IncomeTax;
            this.CurrBusinessConditions.BalanceSheet.Taxes = businessConditions.BalanceSheet.Taxes;
            this.CurrBusinessConditions.BalanceSheet.NetProfit = businessConditions.BalanceSheet.NetProfit;
        }

        public int ActorID =>
            this.m_actorID;

        public string ActorName =>
            this.m_actorName;

        public string CompanyName =>
            this.m_companyName;

        public Quarter RunningQuarter
        {
            get => 
                this.m_runningQuarter;
            set => 
                this.m_runningQuarter = value;
        }

        public Year RunningYear
        {
            get => 
                this.m_runningYear;
            set => 
                this.m_runningYear = value;
        }

        public string RunningTime =>
            this.m_runningYear.ToString() + this.m_runningQuarter.ToString();

        public bool HasP1Capacity =>
            true;

        public bool HasP2Capacity =>
            this.m_YFP2Cost >= 6;

        public int YFP2Cost
        {
            get => 
                this.m_YFP2Cost;
            set => 
                this.m_YFP2Cost = value;
        }

        public bool HasP3Capacity =>
            this.m_YFP3Cost >= 12;

        public int YFP3Cost
        {
            get => 
                this.m_YFP3Cost;
            set => 
                this.m_YFP3Cost = value;
        }

        public bool HasP4Capacity =>
            this.m_YFP4Cost >= 0x12;

        public int YFP4Cost
        {
            get => 
                this.m_YFP4Cost;
            set => 
                this.m_YFP4Cost = value;
        }

        public bool IsEnterLocalMarket =>
            true;

        public int JRQYCost
        {
            get => 
                this.m_jrQYCost;
            set => 
                this.m_jrQYCost = value;
        }

        public bool IsEnterRegionalMarket =>
            this.m_jrQYCost >= 1;

        public int JRGNCost
        {
            get => 
                this.m_jrGNCost;
            set => 
                this.m_jrGNCost = value;
        }

        public bool IsEnterDomesticMarket =>
            this.m_jrGNCost >= 2;

        public int JRYZCost
        {
            get => 
                this.m_jrYZCost;
            set => 
                this.m_jrYZCost = value;
        }

        public bool IsEnterAsiaMarket =>
            this.m_jrYZCost >= 3;

        public int JRGJCost
        {
            get => 
                this.m_jrGJCost;
            set => 
                this.m_jrGJCost = value;
        }

        public bool IsEnterInternationalMarket =>
            this.m_jrGJCost >= 4;

        public int TZISO9000Cost
        {
            get => 
                this.m_tzISO9000Cost;
            set => 
                this.m_tzISO9000Cost = value;
        }

        public bool IsCertified9000 =>
            this.m_tzISO9000Cost >= 2;

        public int TZISO14000Cost
        {
            get => 
                this.m_tzISO14000Cost;
            set => 
                this.m_tzISO14000Cost = value;
        }

        public bool IsCertified14000 =>
            this.m_tzISO14000Cost >= 4;

        public bool IsLocalMarkertLeader
        {
            get => 
                this.m_isLocalMarketLeader;
            set => 
                this.m_isLocalMarketLeader = value;
        }

        public bool IsRegionalMarketLeader
        {
            get => 
                this.m_isRegionalMarketLeader;
            set => 
                this.m_isRegionalMarketLeader = value;
        }

        public bool IsDomesticMarketLeader
        {
            get => 
                this.m_isDomesticMarketLeader;
            set => 
                this.m_isDomesticMarketLeader = value;
        }

        public bool IsAsiaMarketLeader
        {
            get => 
                this.m_isAsiaMarketLeader;
            set => 
                this.m_isAsiaMarketLeader = value;
        }

        public bool IsInternationalMarketLeader
        {
            get => 
                this.m_isInternationalMarketLeader;
            set => 
                this.m_isInternationalMarketLeader = value;
        }

        public int AdvCostLocalMarket
        {
            get => 
                this.m_advCostLocalMarket;
            set
            {
                this.m_advCostLocalMarket = value;
                this.SetAdvCostOfYearAndMarket(this.m_runningYear, Market.本地, this.m_advCostLocalMarket);
            }
        }

        public int AdvCostRegionalMarket
        {
            get => 
                this.m_advCostRegionalMarket;
            set
            {
                this.m_advCostRegionalMarket = value;
                this.SetAdvCostOfYearAndMarket(this.m_runningYear, Market.区域, this.m_advCostRegionalMarket);
            }
        }

        public int AdvCostDomesticMarket
        {
            get => 
                this.m_advCostDomesticMarket;
            set
            {
                this.m_advCostDomesticMarket = value;
                this.SetAdvCostOfYearAndMarket(this.m_runningYear, Market.国内, this.m_advCostDomesticMarket);
            }
        }

        public int AdvCostAsiaMarket
        {
            get => 
                this.m_advCostAsiaMarket;
            set
            {
                this.m_advCostAsiaMarket = value;
                this.SetAdvCostOfYearAndMarket(this.m_runningYear, Market.亚洲, this.m_advCostAsiaMarket);
            }
        }

        public int AdvCostInternationalMarket
        {
            get => 
                this.m_advCostInternationalMarket;
            set
            {
                this.m_advCostInternationalMarket = value;
                this.SetAdvCostOfYearAndMarket(this.m_runningYear, Market.国际, this.m_advCostInternationalMarket);
            }
        }

        public int AdvCostISO9000
        {
            get => 
                this.m_advCostISO9000;
            set
            {
                this.m_advCostISO9000 = value;
                this.SetAdvCostISO(this.RunningYear, this.m_advCostISO9000);
            }
        }

        public int AdvCostISO14000
        {
            get => 
                this.m_advCostISO14000;
            set
            {
                this.m_advCostISO14000 = value;
                this.SetAdvCostISO(this.RunningYear, this.m_advCostISO14000);
            }
        }

        public TBusinessConditions CurrBusinessConditions
        {
            get => 
                this.m_currBusinessConditions;
            set => 
                this.m_currBusinessConditions = value;
        }

        public TLoanSharkingSheet LoanSharkingConditions
        {
            get => 
                this.m_loanSharkingConditions;
            set => 
                this.m_loanSharkingConditions = value;
        }

        public TShortTermLoansSheet ShortTermLoanConditions
        {
            get => 
                this.m_shortTermLoanConditions;
            set => 
                this.m_shortTermLoanConditions = value;
        }

        public TLongTermLoansSheet LongTermLoanConditions
        {
            get => 
                this.m_longTermLoanConditions;
            set => 
                this.m_longTermLoanConditions = value;
        }

        public TRawMaterialStock RawMaterialStock
        {
            get => 
                this.m_rawMaterialStock;
            set => 
                this.m_rawMaterialStock = value;
        }

        public TPlant PlantA
        {
            get => 
                this.m_plantA;
            set => 
                this.m_plantA = value;
        }

        public TPlant PlantB
        {
            get => 
                this.m_plantB;
            set => 
                this.m_plantB = value;
        }

        public TPlant PlantC
        {
            get => 
                this.m_plantC;
            set => 
                this.m_plantC = value;
        }

        public TProductWarehouse P1Warehouse
        {
            get => 
                this.m_p1Warehouse;
            set => 
                this.m_p1Warehouse = value;
        }

        public TProductWarehouse P2Warehouse
        {
            get => 
                this.m_p2Warehouse;
            set => 
                this.m_p2Warehouse = value;
        }

        public TProductWarehouse P3Warehouse
        {
            get => 
                this.m_p3Warehouse;
            set => 
                this.m_p3Warehouse = value;
        }

        public TProductWarehouse P4Warehouse
        {
            get => 
                this.m_p4Warehouse;
            set => 
                this.m_p4Warehouse = value;
        }
    }
}

