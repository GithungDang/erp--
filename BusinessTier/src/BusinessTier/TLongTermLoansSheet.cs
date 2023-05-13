namespace BusinessTier
{
    using System;
    using System.Collections;

    public class TLongTermLoansSheet
    {
        private ArrayList m_loansList = new ArrayList();

        public TLongTermLoansSheet()
        {
            TLongTermLoans longTermLoans = new TLongTermLoans(Year.第0年, Year.第4年, 20);
            TLongTermLoans loans2 = new TLongTermLoans(Year.第0年, Year.第5年, 20);
            this.Loan(longTermLoans);
            this.Loan(loans2);
        }

        public int GetCeiling(int ownerRight)
        {
            int num2 = (((2 * ownerRight) / 20) * 20) - this.NotAlsoAmount;
            if (num2 < 20)
            {
                num2 = 0;
            }
            return num2;
        }

        public TLongTermLoans GetLongTermLoans(Year paymentYear)
        {
            TLongTermLoans loans = null;
            for (int i = 0; i < this.m_loansList.Count; i++)
            {
                if (paymentYear == ((TLongTermLoans) this.m_loansList[i]).PaymentYear)
                {
                    loans = (TLongTermLoans) this.m_loansList[i];
                }
            }
            return loans;
        }

        public TLongTermLoans[] GetNotAlsoLoansList()
        {
            TLongTermLoans[] loansArray;
            ArrayList list = new ArrayList();
            for (int i = 0; i < this.m_loansList.Count; i++)
            {
                if (!((TLongTermLoans) this.m_loansList[i]).Flag)
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
                TLongTermLoans[] loansArray2 = new TLongTermLoans[list.Count];
                int index = 0;
                while (true)
                {
                    if (index >= loansArray2.Length)
                    {
                        loansArray = loansArray2;
                        break;
                    }
                    loansArray2[index] = (TLongTermLoans) list[index];
                    index++;
                }
            }
            return loansArray;
        }

        public int GetPaymentLX(Year paymentYear)
        {
            int num = 0;
            for (int i = 0; i < this.m_loansList.Count; i++)
            {
                if (!((TLongTermLoans) this.m_loansList[i]).Flag)
                {
                    num += ((TLongTermLoans) this.m_loansList[i]).Interest;
                }
                if (paymentYear == ((TLongTermLoans) this.m_loansList[i]).PaymentYear)
                {
                    num += ((TLongTermLoans) this.m_loansList[i]).Interest;
                }
            }
            return num;
        }

        public Year GetPaymentYear(Year year)
        {
            Year year2 = Year.第0年;
            switch (year)
            {
                case Year.第1年:
                    year2 = Year.第6年;
                    break;

                case Year.第2年:
                    year2 = Year.第7年;
                    break;

                case Year.第3年:
                    year2 = Year.第8年;
                    break;

                case Year.第4年:
                    year2 = Year.第9年;
                    break;

                case Year.第5年:
                    year2 = Year.第10年;
                    break;

                case Year.第6年:
                    year2 = Year.第11年;
                    break;

                default:
                    break;
            }
            return year2;
        }

        public void Loan(TLongTermLoans longTermLoans)
        {
            if (longTermLoans == null)
            {
                throw new Exception("传入longTermLoans为null");
            }
            this.m_loansList.Add(longTermLoans);
        }

        public void PaymentBJ(Year paymentYear)
        {
            for (int i = 0; i < this.m_loansList.Count; i++)
            {
                if (paymentYear == ((TLongTermLoans) this.m_loansList[i]).PaymentYear)
                {
                    ((TLongTermLoans) this.m_loansList[i]).Flag ??= true;
                }
            }
        }

        public string PaymentToString(Year paymentYear)
        {
            int num = 0;
            for (int i = 0; i < this.m_loansList.Count; i++)
            {
                if (!((TLongTermLoans) this.m_loansList[i]).Flag)
                {
                    num += ((TLongTermLoans) this.m_loansList[i]).Interest;
                }
            }
            int loanAmount = 0;
            Year loanYear = Year.第0年;
            for (int j = 0; j < this.m_loansList.Count; j++)
            {
                if ((paymentYear == ((TLongTermLoans) this.m_loansList[j]).PaymentYear) && !((TLongTermLoans) this.m_loansList[j]).Flag)
                {
                    loanAmount = ((TLongTermLoans) this.m_loansList[j]).LoanAmount;
                    loanYear = ((TLongTermLoans) this.m_loansList[j]).LoanYear;
                }
            }
            string str = " ";
            if (num != 0)
            {
                str = str + "本年归还利息" + num.ToString() + "M";
            }
            if (loanAmount != 0)
            {
                string[] strArray = new string[] { str, ",归还", loanYear.ToString(), "贷的本金", loanAmount.ToString(), "M" };
                str = string.Concat(strArray);
            }
            return str;
        }

        public void UndoPaymentBJ(Year paymentYear)
        {
            for (int i = 0; i < this.m_loansList.Count; i++)
            {
                if (paymentYear == ((TLongTermLoans) this.m_loansList[i]).PaymentYear)
                {
                    ((TLongTermLoans) this.m_loansList[i]).Flag = false;
                }
            }
        }

        public int NotAlsoAmount
        {
            get
            {
                int num;
                TLongTermLoans[] notAlsoLoansList = this.GetNotAlsoLoansList();
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

