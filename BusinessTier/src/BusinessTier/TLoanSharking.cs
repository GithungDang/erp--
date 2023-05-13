namespace BusinessTier
{
    using System;

    public class TLoanSharking
    {
        private string m_loanTime;
        private string m_paymentTime;
        private int m_loanAmount;
        private bool m_flag;

        public TLoanSharking(string loanTime, string paymentTime, int loanAmount)
        {
            this.m_loanAmount = loanAmount;
            this.m_loanTime = loanTime;
            this.m_paymentTime = paymentTime;
            this.m_flag = false;
        }

        public string LoanTime
        {
            get => 
                this.m_loanTime;
            set => 
                this.m_loanTime = value;
        }

        public string PaymentTime
        {
            get => 
                this.m_paymentTime;
            set => 
                this.m_paymentTime = value;
        }

        public int LoanAmount
        {
            get => 
                this.m_loanAmount;
            set => 
                this.m_loanAmount = value;
        }

        public int Interest =>
            (int) (this.m_loanAmount * 0.2);

        public int PaymentAmount =>
            this.Interest + this.m_loanAmount;

        public bool Flag
        {
            get => 
                this.m_flag;
            set => 
                this.m_flag = value;
        }
    }
}

