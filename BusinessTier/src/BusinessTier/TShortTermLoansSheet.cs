namespace BusinessTier
{
    using System;
    using System.Collections;

    public class TShortTermLoansSheet
    {
        private ArrayList m_loansList = new ArrayList();

        public int GetCeiling(int ownerRight)
        {
            int num2 = (((2 * ownerRight) / 20) * 20) - this.NotAlsoAmount;
            if (num2 < 20)
            {
                num2 = 0;
            }
            return num2;
        }

        public TShortTermLoans[] GetNotAlsoLoansList()
        {
            TShortTermLoans[] loansArray;
            ArrayList list = new ArrayList();
            for (int i = 0; i < this.m_loansList.Count; i++)
            {
                if (!((TShortTermLoans) this.m_loansList[i]).Flag)
                {
                    list.Add(this.m_loansList[i]);
                }
            }
            if (list.Count == 0)
            {
                loansArray = null;
            }
            else
            {
                TShortTermLoans[] loansArray2 = new TShortTermLoans[list.Count];
                int index = 0;
                while (true)
                {
                    if (index >= loansArray2.Length)
                    {
                        loansArray = loansArray2;
                        break;
                    }
                    loansArray2[index] = (TShortTermLoans) list[index];
                    index++;
                }
            }
            return loansArray;
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

        public TShortTermLoans GetShortTermLoans(string paymentTime)
        {
            TShortTermLoans loans = null;
            for (int i = 0; i < this.m_loansList.Count; i++)
            {
                if (paymentTime == ((TShortTermLoans) this.m_loansList[i]).PaymentTime)
                {
                    loans = (TShortTermLoans) this.m_loansList[i];
                }
            }
            return loans;
        }

        public void Loan(TShortTermLoans shortTermLoans)
        {
            if (shortTermLoans == null)
            {
                throw new Exception("传入shortTermLoans为null");
            }
            this.m_loansList.Add(shortTermLoans);
        }

        public string Payment(string paymentTime)
        {
            string str = "";
            for (int i = 0; i < this.m_loansList.Count; i++)
            {
                if ((paymentTime == ((TShortTermLoans) this.m_loansList[i]).PaymentTime) && !((TShortTermLoans) this.m_loansList[i]).Flag)
                {
                    ((TShortTermLoans) this.m_loansList[i]).Flag = true;
                    TShortTermLoans loans = (TShortTermLoans) this.m_loansList[i];
                    string[] strArray = new string[] { loans.LoanTime, "所贷的", loans.LoanAmount.ToString(), "已归还,本息共计:", loans.PaymentAmount.ToString() };
                    str = string.Concat(strArray);
                }
            }
            return str;
        }

        public void UndoPayment(string paymentTime)
        {
            for (int i = 0; i < this.m_loansList.Count; i++)
            {
                if (paymentTime == ((TShortTermLoans) this.m_loansList[i]).PaymentTime)
                {
                    ((TShortTermLoans) this.m_loansList[i]).Flag = false;
                }
            }
        }

        public int NotAlsoAmount
        {
            get
            {
                int num;
                TShortTermLoans[] notAlsoLoansList = this.GetNotAlsoLoansList();
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
    }
}

