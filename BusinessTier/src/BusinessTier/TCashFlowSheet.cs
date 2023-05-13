namespace BusinessTier
{
    using System;

    public class TCashFlowSheet
    {
        private int m_sales;
        private int m_DirectCost;
        private int m_comprehensiveCost;
        private int m_depreciation;
        private int m_financialExpenditure;
        private int m_additionalRevenue;
        private int m_additionalExpenditure;
        private int m_incomeTax;

        public TCashFlowSheet()
        {
            this.IncomeTax = 0;
            this.FinancialExpenditure = 0;
            this.Depreciation = 0;
            this.ComprehensiveCost = 0;
            this.DirectCost = 0;
            this.Sales = 0;
            this.m_additionalRevenue = 0;
            this.m_additionalExpenditure = 0;
        }

        public TCashFlowSheet Clone() => 
            new TCashFlowSheet { 
                ComprehensiveCost = 0,
                Depreciation = 0,
                DirectCost = 0,
                FinancialExpenditure = 0,
                IncomeTax = 0,
                Sales = 0,
                m_additionalRevenue = 0,
                m_additionalExpenditure = 0
            };

        public int Sales
        {
            get => 
                this.m_sales;
            set => 
                this.m_sales = value;
        }

        public int DirectCost
        {
            get => 
                this.m_DirectCost;
            set => 
                this.m_DirectCost = value;
        }

        public int GrossProfit =>
            this.m_sales - this.m_DirectCost;

        public int ComprehensiveCost
        {
            get => 
                this.m_comprehensiveCost;
            set => 
                this.m_comprehensiveCost = value;
        }

        public int ProfitBeforeDepreciation =>
            this.GrossProfit - this.m_comprehensiveCost;

        public int Depreciation
        {
            get => 
                this.m_depreciation;
            set => 
                this.m_depreciation = value;
        }

        public int ProfitBeforeInterestPayments =>
            this.ProfitBeforeDepreciation - this.m_depreciation;

        public int FinancialExpenditure
        {
            get => 
                this.m_financialExpenditure;
            set => 
                this.m_financialExpenditure = value;
        }

        public int AdditionalRevenue
        {
            get => 
                this.m_additionalRevenue;
            set => 
                this.m_additionalRevenue = value;
        }

        public int AdditionalExpenditure
        {
            get => 
                this.m_additionalExpenditure;
            set => 
                this.m_additionalExpenditure = value;
        }

        public int PretaxProfit =>
            ((this.ProfitBeforeInterestPayments - this.m_financialExpenditure) + this.AdditionalRevenue) - this.AdditionalExpenditure;

        public int IncomeTax
        {
            get => 
                this.m_incomeTax;
            set => 
                this.m_incomeTax = value;
        }

        public int NetProfit =>
            this.PretaxProfit - this.m_incomeTax;
    }
}

