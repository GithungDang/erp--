namespace BusinessTier
{
    using System;

    public class TFinancialSheet
    {
        private int m_depreciation = 0;
        private int m_interest = 0;
        private int m_discount = 0;
        private int m_taxes = 0;
        private int m_additionalRevenue = 0;
        private int m_additionalExpenditure = 0;

        public TFinancialSheet Clone() => 
            new TFinancialSheet { 
                Depreciation = 0,
                Discount = 0,
                Interest = 0,
                Taxes = 0,
                m_additionalRevenue = 0,
                m_additionalExpenditure = 0
            };

        public int Depreciation
        {
            get => 
                this.m_depreciation;
            set => 
                this.m_depreciation = value;
        }

        public int Interest
        {
            get => 
                this.m_interest;
            set => 
                this.m_interest = value;
        }

        public int Discount
        {
            get => 
                this.m_discount;
            set => 
                this.m_discount = value;
        }

        public int Taxes
        {
            get => 
                this.m_taxes;
            set => 
                this.m_taxes = value;
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
    }
}

