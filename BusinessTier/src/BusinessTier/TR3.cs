namespace BusinessTier
{
    using System;

    public class TR3 : TRawMaterial
    {
        public TR3(int amount)
        {
            base.m_price = 1;
            base.Amount = amount;
        }

        public int Price =>
            base.m_price;
    }
}

