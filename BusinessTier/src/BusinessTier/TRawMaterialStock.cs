namespace BusinessTier
{
    using System;

    public class TRawMaterialStock
    {
        private TRawMaterialOrder m_theLastOrder = new TRawMaterialOrder(0, 0, 0, 0);
        private TRawMaterialOrder m_statisticsOrder = new TRawMaterialOrder(0, 0, 0, 0);

        public void IntoStock()
        {
            this.m_statisticsOrder.R1.Amount += this.m_theLastOrder.R1.Amount;
            this.m_statisticsOrder.R2.Amount += this.m_theLastOrder.R2.Amount;
            this.m_statisticsOrder.R3.Amount += this.m_theLastOrder.R3.Amount;
            this.m_statisticsOrder.R4.Amount += this.m_theLastOrder.R4.Amount;
            this.m_theLastOrder.R1.Amount = 0;
            this.m_theLastOrder.R2.Amount = 0;
            this.m_theLastOrder.R3.Amount = 0;
            this.m_theLastOrder.R4.Amount = 0;
        }

        public void UnderOrder(int r1Amount, int r2Amount, int r3Amount, int r4Amount)
        {
            this.m_theLastOrder.R1.Amount = r1Amount;
            this.m_theLastOrder.R2.Amount = r2Amount;
            this.m_theLastOrder.R3.Amount = r3Amount;
            this.m_theLastOrder.R4.Amount = r4Amount;
        }

        public TRawMaterialOrder TheLastOrder =>
            this.m_theLastOrder;

        public TRawMaterialOrder StatisticsOrder =>
            this.m_statisticsOrder;
    }
}

