namespace BusinessTier
{
    using System;

    public class TBalanceSheet
    {
        private int m_landAndBuildings;
        private int m_equipmentAndConstruction;
        private int m_currentCash;
        private int m_receivableAccounts;
        private int m_areProducts;
        private int m_finishedProduct;
        private int m_rawMaterials;
        private int m_longTermLiabilities;
        private int m_shortTermLiabilities;
        private int m_taxes;
        private int m_capitalShareholders;
        private int m_retainedProfits;
        private int m_netProfit;

        public TBalanceSheet()
        {
            this.LandAndBuildings = 0;
            this.EquipmentAndConstruction = 0;
            this.CurrentCash = 100;
            this.ReceivableAccounts = 0;
            this.AreProducts = 0;
            this.FinishedProduct = 0;
            this.RawMaterials = 0;
            this.LongtermLiabilities = 40;
            this.shortTermLiabilities = 0;
            this.Taxes = 0;
            this.CapitalShareholders = 60;
            this.NetProfit = 0;
            this.RetainedProfits = 0;
        }

        public TBalanceSheet Clone() => 
            new TBalanceSheet { 
                AreProducts = this.AreProducts,
                CapitalShareholders = this.CapitalShareholders,
                CurrentCash = this.CurrentCash,
                FinishedProduct = this.FinishedProduct,
                LandAndBuildings = this.LandAndBuildings,
                LongtermLiabilities = this.LongtermLiabilities,
                EquipmentAndConstruction = this.EquipmentAndConstruction,
                NetProfit = this.NetProfit,
                RawMaterials = this.RawMaterials,
                ReceivableAccounts = this.ReceivableAccounts,
                RetainedProfits = this.RetainedProfits,
                shortTermLiabilities = this.shortTermLiabilities,
                Taxes = this.Taxes
            };

        public int LandAndBuildings
        {
            get => 
                this.m_landAndBuildings;
            set => 
                this.m_landAndBuildings = value;
        }

        public int EquipmentAndConstruction
        {
            get => 
                this.m_equipmentAndConstruction;
            set => 
                this.m_equipmentAndConstruction = value;
        }

        public int TotalFixedAssets =>
            this.m_landAndBuildings + this.m_equipmentAndConstruction;

        public int CurrentCash
        {
            get => 
                this.m_currentCash;
            set => 
                this.m_currentCash = value;
        }

        public int ReceivableAccounts
        {
            get => 
                this.m_receivableAccounts;
            set => 
                this.m_receivableAccounts = value;
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

        public int TotalCurrentAssets =>
            (((this.m_currentCash + this.m_areProducts) + this.m_finishedProduct) + this.m_rawMaterials) + this.m_receivableAccounts;

        public int TotalAssets =>
            this.TotalCurrentAssets + this.TotalFixedAssets;

        public int LongtermLiabilities
        {
            get => 
                this.m_longTermLiabilities;
            set => 
                this.m_longTermLiabilities = value;
        }

        public int shortTermLiabilities
        {
            get => 
                this.m_shortTermLiabilities;
            set => 
                this.m_shortTermLiabilities = value;
        }

        public int Taxes
        {
            get => 
                this.m_taxes;
            set => 
                this.m_taxes = value;
        }

        public int TotalLiabilities =>
            (this.m_longTermLiabilities + this.m_shortTermLiabilities) + this.m_taxes;

        public int CapitalShareholders
        {
            get => 
                this.m_capitalShareholders;
            set => 
                this.m_capitalShareholders = value;
        }

        public int RetainedProfits
        {
            get => 
                this.m_retainedProfits;
            set => 
                this.m_retainedProfits = value;
        }

        public int NetProfit
        {
            get => 
                this.m_netProfit;
            set => 
                this.m_netProfit = value;
        }

        public int OwnerRight =>
            (this.m_retainedProfits + this.m_netProfit) + this.m_capitalShareholders;

        public int TotalLiabilitiesRights =>
            this.OwnerRight + this.TotalLiabilities;
    }
}

