namespace BusinessTier
{
    using System;

    public class TR4 : TRawMaterial
    {
        public TR4(int amount)
        {
            base.m_price = 1;
            base.Amount = amount;
        }

        public int Price =>
            base.m_price;
    }
}

