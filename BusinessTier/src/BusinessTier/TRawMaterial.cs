namespace BusinessTier
{
    using System;

    public abstract class TRawMaterial
    {
        protected int m_price;
        private int m_amount;

        protected TRawMaterial()
        {
        }

        public int Amount
        {
            get => 
                this.m_amount;
            set => 
                this.m_amount = value;
        }

        public int TotalPrice =>
            this.m_price * this.m_amount;
    }
}

