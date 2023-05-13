namespace BusinessTier
{
    using System;

    public class TOperatingSheet
    {
        private int m_plant = 0;
        private int m_equipment = 0;
        private int m_construction = 0;
        private int m_currentCash = 100;
        private int m_receivableAccountsQ1 = 0;
        private int m_receivableAccountsQ2 = 0;
        private int m_receivableAccountsQ3 = 0;
        private int m_receivableAccountsQ4 = 0;
        private int m_areProducts = 0;
        private int m_finishedProduct = 0;
        private int m_rawMaterials = 0;
        private int m_longTermLoans = 40;
        private int m_shortTermLoans = 0;
        private int m_loanSharking = 0;

        public TOperatingSheet Clone() => 
            new TOperatingSheet { 
                AreProducts = this.AreProducts,
                Equipment = this.Equipment,
                Construction = this.Construction,
                CurrentCash = this.CurrentCash,
                FinishedProduct = this.FinishedProduct,
                LoanSharking = this.LoanSharking,
                LongTermLoans = this.LongTermLoans,
                Plant = this.Plant,
                RawMaterials = this.RawMaterials,
                m_receivableAccountsQ1 = this.m_receivableAccountsQ1,
                m_receivableAccountsQ2 = this.m_receivableAccountsQ2,
                m_receivableAccountsQ3 = this.m_receivableAccountsQ3,
                m_receivableAccountsQ4 = this.m_receivableAccountsQ4,
                ShortTermLoans = this.ShortTermLoans
            };

        public int Plant
        {
            get => 
                this.m_plant;
            set => 
                this.m_plant = value;
        }

        public int EquipmentAndConstruction =>
            this.Equipment + this.Construction;

        public int Equipment
        {
            get => 
                this.m_equipment;
            set => 
                this.m_equipment = value;
        }

        public int Construction
        {
            get => 
                this.m_construction;
            set => 
                this.m_construction = value;
        }

        public int CurrentCash
        {
            get => 
                this.m_currentCash;
            set => 
                this.m_currentCash = value;
        }

        public int ReceivableAccounts =>
            ((this.m_receivableAccountsQ1 + this.m_receivableAccountsQ2) + this.m_receivableAccountsQ3) + this.m_receivableAccountsQ4;

        public int ReceivableAccountsQ1
        {
            get => 
                this.m_receivableAccountsQ1;
            set => 
                this.m_receivableAccountsQ1 = value;
        }

        public int ReceivableAccountsQ2
        {
            get => 
                this.m_receivableAccountsQ2;
            set => 
                this.m_receivableAccountsQ2 = value;
        }

        public int ReceivableAccountsQ3
        {
            get => 
                this.m_receivableAccountsQ3;
            set => 
                this.m_receivableAccountsQ3 = value;
        }

        public int ReceivableAccountsQ4
        {
            get => 
                this.m_receivableAccountsQ4;
            set => 
                this.m_receivableAccountsQ4 = value;
        }

        public int AreProducts
        {
            get => 
                this.m_areProducts;
            set => 
                this.m_areProducts = value;
        }

        public int FinishedProduct
        {
            get => 
                this.m_finishedProduct;
            set => 
                this.m_finishedProduct = value;
        }

        public int RawMaterials
        {
            get => 
                this.m_rawMaterials;
            set => 
                this.m_rawMaterials = value;
        }

        public int LongTermLoans
        {
            get => 
                this.m_longTermLoans;
            set => 
                this.m_longTermLoans = value;
        }

        public int ShortTermLoans
        {
            get => 
                this.m_shortTermLoans;
            set => 
                this.m_shortTermLoans = value;
        }

        public int LoanSharking
        {
            get => 
                this.m_loanSharking;
            set => 
                this.m_loanSharking = value;
        }
    }
}

