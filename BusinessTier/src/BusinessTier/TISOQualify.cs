namespace BusinessTier
{
    using System;

    public class TISOQualify
    {
        private int mTime;
        private int mCost;

        public TISOQualify(int time, int cost)
        {
            this.mCost = cost;
            this.mTime = time;
        }

        public int Time
        {
            get => 
                this.mTime;
            set => 
                this.mTime = value;
        }

        public int Cost
        {
            get => 
                this.mCost;
            set => 
                this.mCost = value;
        }
    }
}

