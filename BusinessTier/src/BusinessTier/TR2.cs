namespace BusinessTier
{
    using System;

    public class TR2 : TRawMaterial
    {
        public TR2(int amount)
        {
            base.m_price = 1;
            base.Amount = amount;
        }

        public int Price =>
            base.m_price;
    }
}

