namespace BusinessTier
{
    using System;

    public class TBusinessConditions
    {
        private TComprehensiveCostSheet m_comprehensiveCostSheet = new TComprehensiveCostSheet();
        private TFinancialSheet m_financialSheet = new TFinancialSheet();
        private TOperatingSheet m_operatingSheet = new TOperatingSheet();
        private TCashFlowSheet m_cashFlowSheet = new TCashFlowSheet();
        private TBalanceSheet m_balanceSheet = new TBalanceSheet();
        private TOrderSheet m_promisedOrderSheet = new TOrderSheet();
        private TOrderSheet m_notPromisedOrderSheet = new TOrderSheet();

        public TBusinessConditions Clone() => 
            new TBusinessConditions { 
                ComprehensiveCostSheet = this.ComprehensiveCostSheet.Clone(),
                FinancialSheet = this.FinancialSheet.Clone(),
                CashFlowSheet = this.CashFlowSheet.Clone(),
                BalanceSheet = this.BalanceSheet.Clone(),
                OperatingSheet = this.OperatingSheet.Clone(),
                PromisedOrderSheet = new TOrderSheet(),
                m_notPromisedOrderSheet = new TOrderSheet()
            };

        public TComprehensiveCostSheet ComprehensiveCostSheet
        {
            get => 
                this.m_comprehensiveCostSheet;
            set => 
                this.m_comprehensiveCostSheet = value;
        }

        public TFinancialSheet FinancialSheet
        {
            get => 
                this.m_financialSheet;
            set => 
                this.m_financialSheet = value;
        }

        public TOperatingSheet OperatingSheet
        {
            get => 
                this.m_operatingSheet;
            set => 
                this.m_operatingSheet = value;
        }

        public TCashFlowSheet CashFlowSheet
        {
            get => 
                this.m_cashFlowSheet;
            set => 
                this.m_cashFlowSheet = value;
        }

        public TBalanceSheet BalanceSheet
        {
            get => 
                this.m_balanceSheet;
            set => 
                this.m_balanceSheet = value;
        }

        public TOrderSheet PromisedOrderSheet
        {
            get => 
                this.m_promisedOrderSheet;
            set => 
                this.m_promisedOrderSheet = value;
        }

        public TOrderSheet NotPromisedOrderSheet
        {
            get => 
                this.m_notPromisedOrderSheet;
            set => 
                this.m_notPromisedOrderSheet = value;
        }
    }
}

