namespace BusinessTier
{
    using System;
    using System.Collections;

    public class TLoanSharkingSheet
    {
        private ArrayList m_loansList = new ArrayList();

        public int GetCeiling(int ownerRight)
        {
            int num2 = (((3 * ownerRight) / 20) * 20) - this.NotAlsoAmount;
            if (num2 < 20)
            {
                num2 = 0;
            }
            return num2;
        }

        public TLoanSharking GetLoanSharking(string paymentTime)
        {
            TLoanSharking sharking = null;
            for (int i = 0; i < this.m_loansList.Count; i++)
            {
                if (paymentTime == ((TLoanSharking) this.m_loansList[i]).PaymentTime)
                {
                    sharking = (TLoanSharking) this.m_loansList[i];
                }
            }
            return sharking;
        }

        public TLoanSharking[] GetNotAlsoLoansList()
        {
            TLoanSharking[] sharkingArray;
            ArrayList list = new ArrayList();
            for (int i = 0; i < this.m_loansList.Count; i++)
            {
                if (!((TLoanSharking) this.m_loansList[i]).Flag)
                {
                    list.Add(this.m_loansList[i]);
                }
            }
            if (list.Count == 0)
            {
                sharkingArray = null;
            }
            else
            {
                TLoanSharking[] sharkingArray2 = new TLoanSharking[list.Count];
                int index = 0;
                while (true)
                {
                    if (index >= sharkingArray2.Length)
                    {
                        sharkingArray = sharkingArray2;
                        break;
                    }
                    sharkingArray2[index] = (TLoanSharking) list[index];
                    index++;
                }
            }
            return sharkingArray;
        }

        public string GetPaymentTime(Year year, Quarter quarter)
        {
            string str = "";
            switch (year)
            {
                case Year.第1年:
                    if (quarter == Quarter.第1季)
                    {
                        str = Year.第2年.ToString() + Quarter.第1季.ToString();
                    }
                    else if (quarter == Quarter.第2季)
                    {
                        str = Year.第2年.ToString() + Quarter.第2季.ToString();
                    }
                    else if (quarter == Quarter.第3季)
                    {
                        str = Year.第2年.ToString() + Quarter.第3季.ToString();
                    }
                    else if (quarter == Quarter.第4季)
                    {
                        str = Year.第2年.ToString() + Quarter.第4季.ToString();
                    }
                    break;

                case Year.第2年:
                    if (quarter == Quarter.第1季)
                    {
                        str = Year.第3年.ToString() + Quarter.第1季.ToString();
                    }
                    else if (quarter == Quarter.第2季)
                    {
                        str = Year.第3年.ToString() + Quarter.第2季.ToString();
                    }
                    else if (quarter == Quarter.第3季)
                    {
                        str = Year.第3年.ToString() + Quarter.第3季.ToString();
                    }
                    else if (quarter == Quarter.第4季)
                    {
                        str = Year.第3年.ToString() + Quarter.第4季.ToString();
                    }
                    break;

                case Year.第3年:
                    if (quarter == Quarter.第1季)
                    {
                        str = Year.第4年.ToString() + Quarter.第1季.ToString();
                    }
                    else if (quarter == Quarter.第2季)
                    {
                        str = Year.第4年.ToString() + Quarter.第2季.ToString();
                    }
                    else if (quarter == Quarter.第3季)
                    {
                        str = Year.第4年.ToString() + Quarter.第3季.ToString();
                    }
                    else if (quarter == Quarter.第4季)
                    {
                        str = Year.第4年.ToString() + Quarter.第4季.ToString();
                    }
                    break;

                case Year.第4年:
                    if (quarter == Quarter.第1季)
                    {
                        str = Year.第5年.ToString() + Quarter.第1季.ToString();
                    }
                    else if (quarter == Quarter.第2季)
                    {
                        str = Year.第5年.ToString() + Quarter.第2季.ToString();
                    }
                    else if (quarter == Quarter.第3季)
                    {
                        str = Year.第5年.ToString() + Quarter.第3季.ToString();
                    }
                    else if (quarter == Quarter.第4季)
                    {
                        str = Year.第5年.ToString() + Quarter.第4季.ToString();
                    }
                    break;

                case Year.第5年:
                    if (quarter == Quarter.第1季)
                    {
                        str = Year.第6年.ToString() + Quarter.第1季.ToString();
                    }
                    else if (quarter == Quarter.第2季)
                    {
                        str = Year.第6年.ToString() + Quarter.第2季.ToString();
                    }
                    else if (quarter == Quarter.第3季)
                    {
                        str = Year.第6年.ToString() + Quarter.第3季.ToString();
                    }
                    else if (quarter == Quarter.第4季)
                    {
                        str = Year.第6年.ToString() + Quarter.第4季.ToString();
                    }
                    break;

                case Year.第6年:
                    if (quarter == Quarter.第1季)
                    {
                        str = Year.第7年.ToString() + Quarter.第1季.ToString();
                    }
                    else if (quarter == Quarter.第2季)
                    {
                        str = Year.第7年.ToString() + Quarter.第2季.ToString();
                    }
                    else if (quarter == Quarter.第3季)
                    {
                        str = Year.第7年.ToString() + Quarter.第3季.ToString();
                    }
                    else if (quarter == Quarter.第4季)
                    {
                        str = Year.第7年.ToString() + Quarter.第4季.ToString();
                    }
                    break;

                default:
                    break;
            }
            return str;
        }

        public void Loan(TLoanSharking loans)
        {
            if (loans == null)
            {
                throw new Exception("传入loans为null");
            }
            this.m_loansList.Add(loans);
        }

        public string Payment(string paymentTime)
        {
            string str = "";
            for (int i = 0; i < this.m_loansList.Count; i++)
            {
                if ((paymentTime == ((TLoanSharking) this.m_loansList[i]).PaymentTime) && !((TLoanSharking) this.m_loansList[i]).Flag)
                {
                    ((TLoanSharking) this.m_loansList[i]).Flag = true;
                    TLoanSharking sharking = (TLoanSharking) this.m_loansList[i];
                    string[] strArray = new string[] { sharking.LoanTime, "所贷的", sharking.LoanAmount.ToString(), "已归还,本息共计:", sharking.PaymentAmount.ToString() };
                    str = string.Concat(strArray);
                }
            }
            return str;
        }

        public void UndoPayment(string paymentTime)
        {
            for (int i = 0; i < this.m_loansList.Count; i++)
            {
                if (paymentTime == ((TLoanSharking) this.m_loansList[i]).PaymentTime)
                {
                    ((TLoanSharking) this.m_loansList[i]).Flag = false;
                }
            }
        }

        public int NotAlsoAmount
        {
            get
            {
                int num;
                TLoanSharking[] notAlsoLoansList = this.GetNotAlsoLoansList();
                if (notAlsoLoansList == null)
                {
                    num = 0;
                }
                else
                {
                    int num2 = 0;
                    int index = 0;
                    while (true)
                    {
                        if (index >= notAlsoLoansList.Length)
                        {
                            num = num2;
                            break;
                        }
                        num2 += notAlsoLoansList[index].LoanAmount;
                        index++;
                    }
                }
                return num;
            }
        }

        public int UsuriousLoans
        {
            get
            {
                int num = 0;
                for (int i = 0; i < this.m_loansList.Count; i++)
                {
                    num += ((TLoanSharking) this.m_loansList[i]).LoanAmount;
                }
                return num;
            }
        }
    }
}

