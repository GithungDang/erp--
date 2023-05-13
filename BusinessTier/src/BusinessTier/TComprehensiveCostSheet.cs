namespace BusinessTier
{
    using System;

    public class TComprehensiveCostSheet
    {
        private int m_administration;
        private int m_advertisement;
        private int m_equipmentMaintenance;
        private int m_rentPlant;
        private int m_marketDevelopment;
        private int m_isoCertification;
        private int m_productDevelopment;
        private int m_others;

        public TComprehensiveCostSheet()
        {
            this.Administration = 0;
            this.Advertisement = 0;
            this.EquipmentMaintenance = 0;
            this.RentPlant = 0;
            this.m_marketDevelopment = 0;
            this.m_isoCertification = 0;
            this.m_productDevelopment = 0;
            this.m_others = 0;
        }

        public TComprehensiveCostSheet Clone() => 
            new TComprehensiveCostSheet { 
                Administration = 0,
                Advertisement = 0,
                EquipmentMaintenance = 0,
                IsoCertification = 0,
                MarketDevelopment = 0,
                Others = 0,
                ProductDevelopment = 0,
                RentPlant = 0
            };

        public int Administration
        {
            get => 
                this.m_administration;
            set => 
                this.m_administration = value;
        }

        public int Advertisement
        {
            get => 
                this.m_advertisement;
            set => 
                this.m_advertisement = value;
        }

        public int EquipmentMaintenance
        {
            get => 
                this.m_equipmentMaintenance;
            set => 
                this.m_equipmentMaintenance = value;
        }

        public int RentPlant
        {
            get => 
                this.m_rentPlant;
            set => 
                this.m_rentPlant = value;
        }

        public int MarketDevelopment
        {
            get => 
                this.m_marketDevelopment;
            set => 
                this.m_marketDevelopment = value;
        }

        public int IsoCertification
        {
            get => 
                this.m_isoCertification;
            set => 
                this.m_isoCertification = value;
        }

        public int ProductDevelopment
        {
            get => 
                this.m_productDevelopment;
            set => 
                this.m_productDevelopment = value;
        }

        public int Others
        {
            get => 
                this.m_others;
            set => 
                this.m_others = value;
        }

        public int Total =>
            ((((((this.m_administration + this.m_advertisement) + this.m_equipmentMaintenance) + this.m_isoCertification) + this.m_marketDevelopment) + this.m_others) + this.m_productDevelopment) + this.m_rentPlant;
    }
}

