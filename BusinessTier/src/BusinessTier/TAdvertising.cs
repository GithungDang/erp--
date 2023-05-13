namespace BusinessTier
{
    using System;

    public class TAdvertising
    {
        private bool m_eligibility;
        private int m_cost;

        public TAdvertising(bool eligibility, int cost)
        {
            this.m_eligibility = eligibility;
            this.m_cost = cost;
        }

        public bool Eligibility
        {
            get => 
                this.m_eligibility;
            set => 
                this.m_eligibility = value;
        }

        public int Cost
        {
            get => 
                this.m_cost;
            set => 
                this.m_cost = value;
        }
    }
}

