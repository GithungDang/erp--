namespace BusinessTier
{
    using System;

    public class TR1 : TRawMaterial
    {
        public TR1(int amount)
        {
            base.m_price = 1;
            base.Amount = amount;
        }

        private int Price =>
            base.m_price;
    }
}

