namespace BusinessTier
{
    using System;

    public class TAdvCostOfPlayer
    {
        private int m_advCost;
        private int m_playerID;

        public TAdvCostOfPlayer(int playerID, int advCost)
        {
            this.m_advCost = advCost;
            this.m_playerID = playerID;
        }

        public int AdvCost
        {
            get => 
                this.m_advCost;
            set => 
                this.m_advCost = value;
        }

        public int PlayerID
        {
            get => 
                this.m_playerID;
            set => 
                this.m_playerID = value;
        }
    }
}

