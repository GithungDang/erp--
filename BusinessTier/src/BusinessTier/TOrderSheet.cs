namespace BusinessTier
{
    using System;

    public class TOrderSheet
    {
        private TOrder[] m_orderSet = null;

        public TOrder[] OrderSet
        {
            get => 
                this.m_orderSet;
            set => 
                this.m_orderSet = value;
        }

        public int TotalAmount
        {
            get
            {
                int num;
                if (this.m_orderSet == null)
                {
                    num = 0;
                }
                else
                {
                    int num2 = 0;
                    int index = 0;
                    while (true)
                    {
                        if (index >= this.m_orderSet.Length)
                        {
                            num = num2;
                            break;
                        }
                        if (this.m_orderSet[index].ISJH)
                        {
                            num2 += this.m_orderSet[index].Amount;
                        }
                        index++;
                    }
                }
                return num;
            }
        }

        public int TotalDirectCost
        {
            get
            {
                int num;
                if (this.m_orderSet == null)
                {
                    num = 0;
                }
                else
                {
                    int num2 = 0;
                    int index = 0;
                    while (true)
                    {
                        if (index >= this.m_orderSet.Length)
                        {
                            num = num2;
                            break;
                        }
                        if (this.m_orderSet[index].ISJH)
                        {
                            num2 += this.m_orderSet[index].DirectCost;
                        }
                        index++;
                    }
                }
                return num;
            }
        }

        public int TotalGrossProfit
        {
            get
            {
                int num;
                if (this.m_orderSet == null)
                {
                    num = 0;
                }
                else
                {
                    int num2 = 0;
                    int index = 0;
                    while (true)
                    {
                        if (index >= this.m_orderSet.Length)
                        {
                            num = num2;
                            break;
                        }
                        if (this.m_orderSet[index].ISJH)
                        {
                            num2 += this.m_orderSet[index].GrossProfit;
                        }
                        index++;
                    }
                }
                return num;
            }
        }

        public int TotalBreakPromiseCost
        {
            get
            {
                int num;
                if (this.m_orderSet == null)
                {
                    num = 0;
                }
                else
                {
                    int num2 = 0;
                    int index = 0;
                    while (true)
                    {
                        if (index >= this.m_orderSet.Length)
                        {
                            num = num2;
                            break;
                        }
                        if (this.m_orderSet[index].BreakPromise && this.m_orderSet[index].ISJH)
                        {
                            num2 += this.m_orderSet[index].BreakPromiseCost;
                        }
                        index++;
                    }
                }
                return num;
            }
        }
    }
}

