namespace BusinessTier
{
    using System;

    public class TLongTermLoans
    {
        private Year m_loanYear;
        private Year m_paymentYear;
        private int m_loanAmount;
        private bool m_flag;

        public TLongTermLoans(Year loanYear, Year paymentYear, int loanAmount)
        {
            this.m_loanYear = loanYear;
            this.m_paymentYear = paymentYear;
            this.m_loanAmount = loanAmount;
            this.m_flag = false;
        }

        public Year LoanYear
        {
            get => 
                this.m_loanYear;
            set => 
                this.m_loanYear = value;
        }

        public Year PaymentYear
        {
            get => 
                this.m_paymentYear;
            set => 
                this.m_paymentYear = value;
        }

        public int LoanAmount
        {
            get => 
                this.m_loanAmount;
            set => 
                this.m_loanAmount = value;
        }

        public int Interest =>
            (int) (this.m_loanAmount * 0.1);

        public bool Flag
        {
            get => 
                this.m_flag;
            set => 
                this.m_flag = value;
        }
    }
}

