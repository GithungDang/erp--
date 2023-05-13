namespace BusinessTier
{
    using System;

    public class TWorkShop
    {
        private int mValue;
        private int mYearRent;
        private int mProductLineCount;

        public TWorkShop(int value, int yearRect, int productLineCount)
        {
            this.mValue = value;
            this.mYearRent = yearRect;
            this.mProductLineCount = productLineCount;
        }

        public int Value
        {
            get => 
                this.mValue;
            set => 
                this.mValue = value;
        }

        public int YearRent
        {
            get => 
                this.mYearRent;
            set => 
                this.mYearRent = value;
        }

        public int ProductLineCount
        {
            get => 
                this.mProductLineCount;
            set => 
                this.mProductLineCount = value;
        }
    }
}

