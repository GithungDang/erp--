namespace BusinessTier
{
    using System;

    public class TRawMaterialOrder
    {
        private TR1 m_r1;
        private TR2 m_r2;
        private TR3 m_r3;
        private TR4 m_r4;

        public TRawMaterialOrder(int r1Amount, int r2Amount, int r3Amount, int r4Amount)
        {
            this.m_r1 = new TR1(r1Amount);
            this.m_r2 = new TR2(r2Amount);
            this.m_r3 = new TR3(r3Amount);
            this.m_r4 = new TR4(r4Amount);
        }

        public TR1 R1
        {
            get => 
                this.m_r1;
            set => 
                this.m_r1 = value;
        }

        public TR2 R2
        {
            get => 
                this.m_r2;
            set => 
                this.m_r2 = value;
        }

        public TR3 R3
        {
            get => 
                this.m_r3;
            set => 
                this.m_r3 = value;
        }

        public TR4 R4
        {
            get => 
                this.m_r4;
            set => 
                this.m_r4 = value;
        }
    }
}

