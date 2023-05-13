namespace BusinessTier
{
    using System;

    public class TProductLine
    {
        private int m_maintenanceCosts;
        private ProductLineName m_plName;
        private int m_ByeCost;
        private int m_SaleCost;
        private int m_alreadyTransferringCycle;
        private int m_transferringCycle;
        private int m_alreadyInstallationCycle;
        private int m_installationCycle;
        private int m_alreadyProduceCycle;
        private int m_produceCycle;
        private ProductLineAttribute m_pla;
        private TProduct m_manufacturedProduct;
        private ProductAttribute m_canManufacturedProductAttribute;

        public TProductLine(ProductLineName pln, ProductLineAttribute pla, ProductAttribute pa)
        {
            this.m_plName = pln;
            this.m_pla = pla;
            this.m_alreadyProduceCycle = 0;
            this.m_alreadyInstallationCycle = 0;
            this.m_alreadyTransferringCycle = 0;
            this.m_canManufacturedProductAttribute = pa;
            switch (pla)
            {
                case ProductLineAttribute.手工:
                    this.m_ByeCost = 5;
                    this.m_installationCycle = 0;
                    this.m_produceCycle = 3;
                    this.m_transferringCycle = 0;
                    this.m_maintenanceCosts = 1;
                    this.m_SaleCost = 1;
                    return;

                case ProductLineAttribute.全自动:
                    this.m_ByeCost = 0x10;
                    this.m_installationCycle = 4;
                    this.m_produceCycle = 1;
                    this.m_transferringCycle = 2;
                    this.m_maintenanceCosts = 1;
                    this.m_SaleCost = 4;
                    return;

                case ProductLineAttribute.半自动:
                    this.m_ByeCost = 8;
                    this.m_installationCycle = 2;
                    this.m_produceCycle = 2;
                    this.m_transferringCycle = 1;
                    this.m_maintenanceCosts = 1;
                    this.m_SaleCost = 2;
                    return;

                case ProductLineAttribute.柔性:
                    this.m_ByeCost = 0x18;
                    this.m_installationCycle = 4;
                    this.m_produceCycle = 1;
                    this.m_transferringCycle = 0;
                    this.m_maintenanceCosts = 1;
                    this.m_SaleCost = 6;
                    return;

                case ProductLineAttribute.无:
                    this.m_ByeCost = 0;
                    this.m_installationCycle = 0;
                    this.m_produceCycle = 0;
                    this.m_transferringCycle = 0;
                    this.m_maintenanceCosts = 0;
                    this.m_SaleCost = 0;
                    return;
            }
        }

        public override string ToString()
        {
            string str = "";
            if (this.PLAttribute == ProductLineAttribute.无)
            {
                str = "没有安装生产线!";
            }
            else
            {
                str = str + "生产线类型:  " + this.PLAttribute.ToString() + "\n";
                str = (this.RemainProduceCycle < 1) ? ((this.RemainInstallationCycle < 1) ? ((this.RemainTransferringCycle < 1) ? ((str + "可制品类型:  " + this.CanManufacturedProductAttribute.ToString() + "\n") + "生产线空闲  \n") : (str + "转产剩余期数:" + this.RemainTransferringCycle.ToString() + "Q\n")) : ((str + "可制品类型:  " + this.CanManufacturedProductAttribute.ToString() + "\n") + "安装剩余期数:" + this.RemainInstallationCycle.ToString() + "Q\n")) : ((str + "在制品类型:  " + this.ManufacturedProduct.PAttribute.ToString() + "\n") + "产品剩余期数:" + this.RemainProduceCycle.ToString() + "Q\n");
            }
            return str;
        }

        public int MaintenanceCosts
        {
            get => 
                this.m_maintenanceCosts;
            set => 
                this.m_maintenanceCosts = value;
        }

        public ProductLineName PLName =>
            this.m_plName;

        public int ByeCost
        {
            get => 
                this.m_ByeCost;
            set => 
                this.m_ByeCost = value;
        }

        public int InstallPerCost =>
            (this.InstallationCycle != 0) ? (this.ByeCost / this.InstallationCycle) : 0;

        public int SaleCost
        {
            get => 
                this.m_SaleCost;
            set => 
                this.m_SaleCost = value;
        }

        public int RemainTransferringCycle =>
            (this.m_transferringCycle != 0) ? (this.m_transferringCycle - this.m_alreadyTransferringCycle) : -1;

        public int AlreadyTransferringCycle
        {
            get => 
                this.m_alreadyTransferringCycle;
            set => 
                this.m_alreadyTransferringCycle = value;
        }

        public int TransferringCycle
        {
            get => 
                this.m_transferringCycle;
            set => 
                this.m_transferringCycle = value;
        }

        public int RemainInstallationCycle =>
            (this.m_installationCycle != 0) ? (this.m_installationCycle - this.m_alreadyInstallationCycle) : -1;

        public int AlreadyInstallationCycle
        {
            get => 
                this.m_alreadyInstallationCycle;
            set => 
                this.m_alreadyInstallationCycle = value;
        }

        public int InstallationCycle
        {
            get => 
                this.m_installationCycle;
            set => 
                this.m_installationCycle = value;
        }

        public int RemainProduceCycle =>
            this.m_produceCycle - this.m_alreadyProduceCycle;

        public int AlreadyProduceCycle
        {
            get => 
                this.m_alreadyProduceCycle;
            set => 
                this.m_alreadyProduceCycle = value;
        }

        public int ProdceCycle
        {
            get => 
                this.m_produceCycle;
            set => 
                this.m_produceCycle = value;
        }

        public ProductLineAttribute PLAttribute
        {
            get => 
                this.m_pla;
            set => 
                this.m_pla = value;
        }

        public TProduct ManufacturedProduct
        {
            get => 
                this.m_manufacturedProduct;
            set => 
                this.m_manufacturedProduct = value;
        }

        public ProductAttribute CanManufacturedProductAttribute
        {
            get => 
                this.m_canManufacturedProductAttribute;
            set => 
                this.m_canManufacturedProductAttribute = value;
        }
    }
}

