namespace BusinessTier
{
    using System;

    public class TOrder
    {
        private BusinessTier.Year m_year;
        private BusinessTier.Market m_market;
        private string m_orderID;
        private ProductAttribute m_productName;
        private int m_productNumber;
        private int m_unitPrice;
        private int m_accountPeriod;
        private ISOQualify m_iSOQualify;
        private int m_DirectCost;
        private bool m_breakPromise;
        private BusinessTier.Year m_chwyYear;
        private bool m_iSJH;

        public TOrder(BusinessTier.Year year, BusinessTier.Market market, string orderid, ProductAttribute productname, int number, int unitprice, int accountperiod, ISOQualify isoqulify)
        {
            this.m_year = year;
            this.m_market = market;
            this.m_orderID = orderid;
            this.m_productName = productname;
            this.m_productNumber = number;
            this.m_unitPrice = unitprice;
            this.m_accountPeriod = accountperiod;
            this.m_iSOQualify = isoqulify;
            this.m_breakPromise = false;
            this.m_chwyYear = BusinessTier.Year.第0年;
            this.m_iSJH = false;
            if (this.m_productName == ProductAttribute.P1)
            {
                this.m_DirectCost = 2 * this.m_productNumber;
            }
            else if (this.m_productName == ProductAttribute.P2)
            {
                this.m_DirectCost = 3 * this.m_productNumber;
            }
            else if (this.m_productName == ProductAttribute.P3)
            {
                this.m_DirectCost = 4 * this.m_productNumber;
            }
            else if (this.m_productName == ProductAttribute.P4)
            {
                this.m_DirectCost = 5 * this.m_productNumber;
            }
        }

        public BusinessTier.Year Year =>
            this.m_year;

        public BusinessTier.Market Market =>
            this.m_market;

        public string OrderID =>
            this.m_orderID;

        public ProductAttribute ProductName =>
            this.m_productName;

        public int ProductNumber =>
            this.m_productNumber;

        public int UnitPrice =>
            this.m_unitPrice;

        public int AccountPeriod =>
            this.m_accountPeriod;

        public ISOQualify ISOQulify =>
            this.m_iSOQualify;

        public int Amount =>
            this.m_unitPrice * this.m_productNumber;

        public int DirectCost =>
            this.m_DirectCost;

        public int GrossProfit =>
            this.Amount - this.m_DirectCost;

        public bool BreakPromise
        {
            get => 
                this.m_breakPromise;
            set => 
                this.m_breakPromise = value;
        }

        public int BreakPromiseCost =>
            !this.m_breakPromise ? 0 : ((int) (this.Amount * 0.2));

        public BusinessTier.Year CHWYYear
        {
            get => 
                this.m_chwyYear;
            set => 
                this.m_chwyYear = value;
        }

        public bool ISJH
        {
            get => 
                this.m_iSJH;
            set => 
                this.m_iSJH = value;
        }
    }
}

