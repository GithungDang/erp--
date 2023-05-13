namespace BusinessTier
{
    using System;

    public class TComputerPlayer
    {
        private bool m_isBankruptcyNotice = false;
        private string m_cplayerName;
        private int m_cplayerID;
        private bool[] m_isLiving;
        private string[] m_score;
        private int[,] m_advCostOfYearAndMarket;
        private int[,] m_getOrderCountOfYearAndMarket;
        private int m_localMarketAmount;
        private int m_RegionalMarketAmount;
        private int m_domesticMarketAmount;
        private int m_asiaMarketAmount;
        private int m_internationalMarketAmount;

        public TComputerPlayer(string computerPlayerName, int computerPlayerID, int[,] advCostOfYear, int[,] orderCountOfYear, bool[] isLiving, string[] score)
        {
            this.m_cplayerName = computerPlayerName;
            this.m_cplayerID = computerPlayerID;
            this.m_advCostOfYearAndMarket = advCostOfYear;
            this.m_getOrderCountOfYearAndMarket = orderCountOfYear;
            this.m_isLiving = isLiving;
            this.m_score = score;
            this.m_localMarketAmount = 0;
            this.m_RegionalMarketAmount = 0;
            this.m_domesticMarketAmount = 0;
            this.m_asiaMarketAmount = 0;
            this.m_internationalMarketAmount = 0;
        }

        public void ChangeOrderCont(Year year, Market market)
        {
            int num = this.LocateYearID(year);
            int num2 = this.LocateMarketID(market);
            this.m_getOrderCountOfYearAndMarket[num, num2]--;
        }

        public int GetAdvCost(Year year, Market market)
        {
            int num3;
            int num = this.LocateYearID(year);
            int num2 = this.LocateMarketID(market);
            try
            {
                num3 = this.m_advCostOfYearAndMarket[num, num2];
            }
            catch
            {
                throw new Exception("输入的年份和市场有误！");
            }
            return num3;
        }

        public int GetOrderCount(Year year, Market market)
        {
            int num3;
            int num = this.LocateYearID(year);
            int num2 = this.LocateMarketID(market);
            try
            {
                num3 = this.m_getOrderCountOfYearAndMarket[num, num2];
            }
            catch
            {
                throw new Exception("输入的年份和市场有误！");
            }
            return num3;
        }

        public string GetScore(Year year) => 
            this.m_score[this.LocateYearID(year)];

        public bool IsLiving(Year year) => 
            this.m_isLiving[this.LocateYearID(year)];

        private int LocateMarketID(Market market)
        {
            int num = -1;
            switch (market)
            {
                case Market.本地:
                    num = 0;
                    break;

                case Market.区域:
                    num = 1;
                    break;

                case Market.国内:
                    num = 2;
                    break;

                case Market.亚洲:
                    num = 3;
                    break;

                case Market.国际:
                    num = 4;
                    break;

                default:
                    break;
            }
            return num;
        }

        private int LocateYearID(Year year)
        {
            int num = -1;
            switch (year)
            {
                case Year.第1年:
                    num = 0;
                    break;

                case Year.第2年:
                    num = 1;
                    break;

                case Year.第3年:
                    num = 2;
                    break;

                case Year.第4年:
                    num = 3;
                    break;

                case Year.第5年:
                    num = 4;
                    break;

                case Year.第6年:
                    num = 5;
                    break;

                case Year.第7年:
                    num = 6;
                    break;

                default:
                    break;
            }
            return num;
        }

        public bool IsBankruptcyNotice
        {
            get => 
                this.m_isBankruptcyNotice;
            set => 
                this.m_isBankruptcyNotice = value;
        }

        public string ComputerPlayerName =>
            this.m_cplayerName;

        public int ComputerPlayerID =>
            this.m_cplayerID;

        public int LocalMarketAmount
        {
            get => 
                this.m_localMarketAmount;
            set => 
                this.m_localMarketAmount = value;
        }

        public int RegionalMarketAmount
        {
            get => 
                this.m_RegionalMarketAmount;
            set => 
                this.m_RegionalMarketAmount = value;
        }

        public int DomesticMarketAmount
        {
            get => 
                this.m_domesticMarketAmount;
            set => 
                this.m_domesticMarketAmount = value;
        }

        public int AsiaMarketAmount
        {
            get => 
                this.m_asiaMarketAmount;
            set => 
                this.m_asiaMarketAmount = value;
        }

        public int InternationalMarketAmount
        {
            get => 
                this.m_internationalMarketAmount;
            set => 
                this.m_internationalMarketAmount = value;
        }
    }
}

