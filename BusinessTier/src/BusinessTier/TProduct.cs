namespace BusinessTier
{
    using System;

    public class TProduct
    {
        private int m_Cost;
        private ProductAttribute m_pAttribute;

        public TProduct(ProductAttribute pAttribute)
        {
            this.m_pAttribute = pAttribute;
            switch (pAttribute)
            {
                case ProductAttribute.P1:
                    this.m_Cost = 2;
                    return;

                case ProductAttribute.P2:
                    this.m_Cost = 3;
                    return;

                case ProductAttribute.P3:
                    this.m_Cost = 4;
                    return;

                case ProductAttribute.P4:
                    this.m_Cost = 5;
                    return;
            }
        }

        public int Cost
        {
            get => 
                this.m_Cost;
            set => 
                this.m_Cost = value;
        }

        public ProductAttribute PAttribute
        {
            get => 
                this.m_pAttribute;
            set => 
                this.m_pAttribute = value;
        }
    }
}

