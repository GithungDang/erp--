namespace BusinessTier
{
    using System;

    public class TPlant
    {
        protected int m_purchasePrice;
        protected int m_leasingPrice;
        private BusinessTier.PlantAttribute m_plantAttribute;
        private BusinessTier.PlantName m_PlantName;
        private TProductLine m_pL1;
        private TProductLine m_pL2;
        private TProductLine m_pL3;
        private TProductLine m_pL4;
        private TProductLine m_pL5;
        private TProductLine m_pL6;
        private TProductLine m_pL7;
        private TProductLine m_pL8;

        public TPlant(BusinessTier.PlantAttribute plantAttribute, BusinessTier.PlantName plName)
        {
            this.m_PlantName = plName;
            switch (plName)
            {
                case BusinessTier.PlantName.工厂A:
                    this.m_purchasePrice = 0x20;
                    this.m_leasingPrice = 4;
                    this.m_plantAttribute = plantAttribute;
                    this.m_pL1 = new TProductLine(ProductLineName.PL1, ProductLineAttribute.无, ProductAttribute.无);
                    this.m_pL2 = new TProductLine(ProductLineName.PL2, ProductLineAttribute.无, ProductAttribute.无);
                    this.m_pL3 = new TProductLine(ProductLineName.PL3, ProductLineAttribute.无, ProductAttribute.无);
                    this.m_pL4 = new TProductLine(ProductLineName.PL4, ProductLineAttribute.无, ProductAttribute.无);
                    return;

                case BusinessTier.PlantName.工厂B:
                    this.m_purchasePrice = 0x18;
                    this.m_leasingPrice = 3;
                    this.PlantAttribute = plantAttribute;
                    this.m_pL5 = new TProductLine(ProductLineName.PL5, ProductLineAttribute.无, ProductAttribute.无);
                    this.m_pL6 = new TProductLine(ProductLineName.PL6, ProductLineAttribute.无, ProductAttribute.无);
                    this.m_pL7 = new TProductLine(ProductLineName.PL7, ProductLineAttribute.无, ProductAttribute.无);
                    return;

                case BusinessTier.PlantName.工厂C:
                    this.m_purchasePrice = 12;
                    this.m_leasingPrice = 2;
                    this.PlantAttribute = plantAttribute;
                    this.m_pL8 = new TProductLine(ProductLineName.PL8, ProductLineAttribute.无, ProductAttribute.无);
                    return;
            }
        }

        public TProductLine[] GetCanProduceProduceLine(BusinessTier.PlantName plName, bool hasP2, bool hasP3, bool hasP4)
        {
            TProductLine[] lineArray;
            int num = this.GetCanProduceProduceLineCount(plName, hasP2, hasP3, hasP4);
            if (num == 0)
            {
                lineArray = null;
            }
            else
            {
                lineArray = new TProductLine[num];
                int index = 0;
                switch (plName)
                {
                    case BusinessTier.PlantName.工厂A:
                        if ((this.m_pL1.PLAttribute != ProductLineAttribute.无) && ((this.m_pL1.RemainProduceCycle < 1) && ((this.m_pL1.RemainInstallationCycle < 1) && (this.m_pL1.RemainTransferringCycle < 1))))
                        {
                            bool flag = false;
                            if (this.m_pL1.CanManufacturedProductAttribute == ProductAttribute.全部)
                            {
                                flag = true;
                            }
                            if (this.m_pL1.CanManufacturedProductAttribute == ProductAttribute.P1)
                            {
                                flag = true;
                            }
                            if (hasP2 && (this.m_pL1.CanManufacturedProductAttribute == ProductAttribute.P2))
                            {
                                flag = true;
                            }
                            if (hasP3 && (this.m_pL1.CanManufacturedProductAttribute == ProductAttribute.P3))
                            {
                                flag = true;
                            }
                            if (hasP4 && (this.m_pL1.CanManufacturedProductAttribute == ProductAttribute.P4))
                            {
                                flag = true;
                            }
                            if (flag)
                            {
                                lineArray[index] = this.m_pL1;
                                index++;
                            }
                        }
                        if ((this.m_pL2.PLAttribute != ProductLineAttribute.无) && ((this.m_pL2.RemainProduceCycle < 1) && ((this.m_pL2.RemainInstallationCycle < 1) && (this.m_pL2.RemainTransferringCycle < 1))))
                        {
                            bool flag2 = false;
                            if (this.m_pL2.CanManufacturedProductAttribute == ProductAttribute.全部)
                            {
                                flag2 = true;
                            }
                            if (this.m_pL2.CanManufacturedProductAttribute == ProductAttribute.P1)
                            {
                                flag2 = true;
                            }
                            if (hasP2 && (this.m_pL2.CanManufacturedProductAttribute == ProductAttribute.P2))
                            {
                                flag2 = true;
                            }
                            if (hasP3 && (this.m_pL2.CanManufacturedProductAttribute == ProductAttribute.P3))
                            {
                                flag2 = true;
                            }
                            if (hasP4 && (this.m_pL2.CanManufacturedProductAttribute == ProductAttribute.P4))
                            {
                                flag2 = true;
                            }
                            if (flag2)
                            {
                                lineArray[index] = this.m_pL2;
                                index++;
                            }
                        }
                        if ((this.m_pL3.PLAttribute != ProductLineAttribute.无) && ((this.m_pL3.RemainProduceCycle < 1) && ((this.m_pL3.RemainInstallationCycle < 1) && (this.m_pL3.RemainTransferringCycle < 1))))
                        {
                            bool flag3 = false;
                            if (this.m_pL3.CanManufacturedProductAttribute == ProductAttribute.全部)
                            {
                                flag3 = true;
                            }
                            if (this.m_pL3.CanManufacturedProductAttribute == ProductAttribute.P1)
                            {
                                flag3 = true;
                            }
                            if (hasP2 && (this.m_pL3.CanManufacturedProductAttribute == ProductAttribute.P2))
                            {
                                flag3 = true;
                            }
                            if (hasP3 && (this.m_pL3.CanManufacturedProductAttribute == ProductAttribute.P3))
                            {
                                flag3 = true;
                            }
                            if (hasP4 && (this.m_pL3.CanManufacturedProductAttribute == ProductAttribute.P4))
                            {
                                flag3 = true;
                            }
                            if (flag3)
                            {
                                lineArray[index] = this.m_pL3;
                                index++;
                            }
                        }
                        if ((this.m_pL4.PLAttribute != ProductLineAttribute.无) && ((this.m_pL4.RemainProduceCycle < 1) && ((this.m_pL4.RemainInstallationCycle < 1) && (this.m_pL4.RemainTransferringCycle < 1))))
                        {
                            bool flag4 = false;
                            if (this.m_pL4.CanManufacturedProductAttribute == ProductAttribute.全部)
                            {
                                flag4 = true;
                            }
                            if (this.m_pL4.CanManufacturedProductAttribute == ProductAttribute.P1)
                            {
                                flag4 = true;
                            }
                            if (hasP2 && (this.m_pL4.CanManufacturedProductAttribute == ProductAttribute.P2))
                            {
                                flag4 = true;
                            }
                            if (hasP3 && (this.m_pL4.CanManufacturedProductAttribute == ProductAttribute.P3))
                            {
                                flag4 = true;
                            }
                            if (hasP4 && (this.m_pL4.CanManufacturedProductAttribute == ProductAttribute.P4))
                            {
                                flag4 = true;
                            }
                            if (flag4)
                            {
                                lineArray[index] = this.m_pL4;
                                index++;
                            }
                        }
                        break;

                    case BusinessTier.PlantName.工厂B:
                        if ((this.m_pL5.PLAttribute != ProductLineAttribute.无) && ((this.m_pL5.RemainProduceCycle < 1) && ((this.m_pL5.RemainInstallationCycle < 1) && (this.m_pL5.RemainTransferringCycle < 1))))
                        {
                            bool flag5 = false;
                            if (this.m_pL5.CanManufacturedProductAttribute == ProductAttribute.全部)
                            {
                                flag5 = true;
                            }
                            if (this.m_pL5.CanManufacturedProductAttribute == ProductAttribute.P1)
                            {
                                flag5 = true;
                            }
                            if (hasP2 && (this.m_pL5.CanManufacturedProductAttribute == ProductAttribute.P2))
                            {
                                flag5 = true;
                            }
                            if (hasP3 && (this.m_pL5.CanManufacturedProductAttribute == ProductAttribute.P3))
                            {
                                flag5 = true;
                            }
                            if (hasP4 && (this.m_pL5.CanManufacturedProductAttribute == ProductAttribute.P4))
                            {
                                flag5 = true;
                            }
                            if (flag5)
                            {
                                lineArray[index] = this.m_pL5;
                                index++;
                            }
                        }
                        if ((this.m_pL6.PLAttribute != ProductLineAttribute.无) && ((this.m_pL6.RemainProduceCycle < 1) && ((this.m_pL6.RemainInstallationCycle < 1) && (this.m_pL6.RemainTransferringCycle < 1))))
                        {
                            bool flag6 = false;
                            if (this.m_pL6.CanManufacturedProductAttribute == ProductAttribute.全部)
                            {
                                flag6 = true;
                            }
                            if (this.m_pL6.CanManufacturedProductAttribute == ProductAttribute.P1)
                            {
                                flag6 = true;
                            }
                            if (hasP2 && (this.m_pL6.CanManufacturedProductAttribute == ProductAttribute.P2))
                            {
                                flag6 = true;
                            }
                            if (hasP3 && (this.m_pL6.CanManufacturedProductAttribute == ProductAttribute.P3))
                            {
                                flag6 = true;
                            }
                            if (hasP4 && (this.m_pL6.CanManufacturedProductAttribute == ProductAttribute.P4))
                            {
                                flag6 = true;
                            }
                            if (flag6)
                            {
                                lineArray[index] = this.m_pL6;
                                index++;
                            }
                        }
                        if ((this.m_pL7.PLAttribute != ProductLineAttribute.无) && ((this.m_pL7.RemainProduceCycle < 1) && ((this.m_pL7.RemainInstallationCycle < 1) && (this.m_pL7.RemainTransferringCycle < 1))))
                        {
                            bool flag7 = false;
                            if (this.m_pL7.CanManufacturedProductAttribute == ProductAttribute.全部)
                            {
                                flag7 = true;
                            }
                            if (this.m_pL7.CanManufacturedProductAttribute == ProductAttribute.P1)
                            {
                                flag7 = true;
                            }
                            if (hasP2 && (this.m_pL7.CanManufacturedProductAttribute == ProductAttribute.P2))
                            {
                                flag7 = true;
                            }
                            if (hasP3 && (this.m_pL7.CanManufacturedProductAttribute == ProductAttribute.P3))
                            {
                                flag7 = true;
                            }
                            if (hasP4 && (this.m_pL7.CanManufacturedProductAttribute == ProductAttribute.P4))
                            {
                                flag7 = true;
                            }
                            if (flag7)
                            {
                                lineArray[index] = this.m_pL7;
                                index++;
                            }
                        }
                        break;

                    case BusinessTier.PlantName.工厂C:
                        if ((this.m_pL8.PLAttribute != ProductLineAttribute.无) && ((this.m_pL8.RemainProduceCycle < 1) && ((this.m_pL8.RemainInstallationCycle < 1) && (this.m_pL8.RemainTransferringCycle < 1))))
                        {
                            bool flag8 = false;
                            if (this.m_pL8.CanManufacturedProductAttribute == ProductAttribute.全部)
                            {
                                flag8 = true;
                            }
                            if (this.m_pL8.CanManufacturedProductAttribute == ProductAttribute.P1)
                            {
                                flag8 = true;
                            }
                            if (hasP2 && (this.m_pL8.CanManufacturedProductAttribute == ProductAttribute.P2))
                            {
                                flag8 = true;
                            }
                            if (hasP3 && (this.m_pL8.CanManufacturedProductAttribute == ProductAttribute.P3))
                            {
                                flag8 = true;
                            }
                            if (hasP4 && (this.m_pL8.CanManufacturedProductAttribute == ProductAttribute.P4))
                            {
                                flag8 = true;
                            }
                            if (flag8)
                            {
                                lineArray[index] = this.m_pL8;
                                index++;
                            }
                        }
                        break;

                    default:
                        break;
                }
            }
            return lineArray;
        }

        public int GetCanProduceProduceLineCount(BusinessTier.PlantName plName, bool hasP2, bool hasP3, bool hasP4)
        {
            int num = 0;
            switch (plName)
            {
                case BusinessTier.PlantName.工厂A:
                    if ((this.m_pL1.PLAttribute != ProductLineAttribute.无) && ((this.m_pL1.RemainProduceCycle < 1) && ((this.m_pL1.RemainInstallationCycle < 1) && (this.m_pL1.RemainTransferringCycle < 1))))
                    {
                        bool flag = false;
                        if (this.m_pL1.CanManufacturedProductAttribute == ProductAttribute.全部)
                        {
                            flag = true;
                        }
                        if (this.m_pL1.CanManufacturedProductAttribute == ProductAttribute.P1)
                        {
                            flag = true;
                        }
                        if (hasP2 && (this.m_pL1.CanManufacturedProductAttribute == ProductAttribute.P2))
                        {
                            flag = true;
                        }
                        if (hasP3 && (this.m_pL1.CanManufacturedProductAttribute == ProductAttribute.P3))
                        {
                            flag = true;
                        }
                        if (hasP4 && (this.m_pL1.CanManufacturedProductAttribute == ProductAttribute.P4))
                        {
                            flag = true;
                        }
                        if (flag)
                        {
                            num++;
                        }
                    }
                    if ((this.m_pL2.PLAttribute != ProductLineAttribute.无) && ((this.m_pL2.RemainProduceCycle < 1) && ((this.m_pL2.RemainInstallationCycle < 1) && (this.m_pL2.RemainTransferringCycle < 1))))
                    {
                        bool flag2 = false;
                        if (this.m_pL2.CanManufacturedProductAttribute == ProductAttribute.全部)
                        {
                            flag2 = true;
                        }
                        if (this.m_pL2.CanManufacturedProductAttribute == ProductAttribute.P1)
                        {
                            flag2 = true;
                        }
                        if (hasP2 && (this.m_pL2.CanManufacturedProductAttribute == ProductAttribute.P2))
                        {
                            flag2 = true;
                        }
                        if (hasP3 && (this.m_pL2.CanManufacturedProductAttribute == ProductAttribute.P3))
                        {
                            flag2 = true;
                        }
                        if (hasP4 && (this.m_pL2.CanManufacturedProductAttribute == ProductAttribute.P4))
                        {
                            flag2 = true;
                        }
                        if (flag2)
                        {
                            num++;
                        }
                    }
                    if ((this.m_pL3.PLAttribute != ProductLineAttribute.无) && ((this.m_pL3.RemainProduceCycle < 1) && ((this.m_pL3.RemainInstallationCycle < 1) && (this.m_pL3.RemainTransferringCycle < 1))))
                    {
                        bool flag3 = false;
                        if (this.m_pL3.CanManufacturedProductAttribute == ProductAttribute.全部)
                        {
                            flag3 = true;
                        }
                        if (this.m_pL3.CanManufacturedProductAttribute == ProductAttribute.P1)
                        {
                            flag3 = true;
                        }
                        if (hasP2 && (this.m_pL3.CanManufacturedProductAttribute == ProductAttribute.P2))
                        {
                            flag3 = true;
                        }
                        if (hasP3 && (this.m_pL3.CanManufacturedProductAttribute == ProductAttribute.P3))
                        {
                            flag3 = true;
                        }
                        if (hasP4 && (this.m_pL3.CanManufacturedProductAttribute == ProductAttribute.P4))
                        {
                            flag3 = true;
                        }
                        if (flag3)
                        {
                            num++;
                        }
                    }
                    if ((this.m_pL4.PLAttribute != ProductLineAttribute.无) && ((this.m_pL4.RemainProduceCycle < 1) && ((this.m_pL4.RemainInstallationCycle < 1) && (this.m_pL4.RemainTransferringCycle < 1))))
                    {
                        bool flag4 = false;
                        if (this.m_pL4.CanManufacturedProductAttribute == ProductAttribute.全部)
                        {
                            flag4 = true;
                        }
                        if (this.m_pL4.CanManufacturedProductAttribute == ProductAttribute.P1)
                        {
                            flag4 = true;
                        }
                        if (hasP2 && (this.m_pL4.CanManufacturedProductAttribute == ProductAttribute.P2))
                        {
                            flag4 = true;
                        }
                        if (hasP3 && (this.m_pL4.CanManufacturedProductAttribute == ProductAttribute.P3))
                        {
                            flag4 = true;
                        }
                        if (hasP4 && (this.m_pL4.CanManufacturedProductAttribute == ProductAttribute.P4))
                        {
                            flag4 = true;
                        }
                        if (flag4)
                        {
                            num++;
                        }
                    }
                    break;

                case BusinessTier.PlantName.工厂B:
                    if ((this.m_pL5.PLAttribute != ProductLineAttribute.无) && ((this.m_pL5.RemainProduceCycle < 1) && ((this.m_pL5.RemainInstallationCycle < 1) && (this.m_pL5.RemainTransferringCycle < 1))))
                    {
                        bool flag5 = false;
                        if (this.m_pL5.CanManufacturedProductAttribute == ProductAttribute.全部)
                        {
                            flag5 = true;
                        }
                        if (this.m_pL5.CanManufacturedProductAttribute == ProductAttribute.P1)
                        {
                            flag5 = true;
                        }
                        if (hasP2 && (this.m_pL5.CanManufacturedProductAttribute == ProductAttribute.P2))
                        {
                            flag5 = true;
                        }
                        if (hasP3 && (this.m_pL5.CanManufacturedProductAttribute == ProductAttribute.P3))
                        {
                            flag5 = true;
                        }
                        if (hasP4 && (this.m_pL5.CanManufacturedProductAttribute == ProductAttribute.P4))
                        {
                            flag5 = true;
                        }
                        if (flag5)
                        {
                            num++;
                        }
                    }
                    if ((this.m_pL6.PLAttribute != ProductLineAttribute.无) && ((this.m_pL6.RemainProduceCycle < 1) && ((this.m_pL6.RemainInstallationCycle < 1) && (this.m_pL6.RemainTransferringCycle < 1))))
                    {
                        bool flag6 = false;
                        if (this.m_pL6.CanManufacturedProductAttribute == ProductAttribute.全部)
                        {
                            flag6 = true;
                        }
                        if (this.m_pL6.CanManufacturedProductAttribute == ProductAttribute.P1)
                        {
                            flag6 = true;
                        }
                        if (hasP2 && (this.m_pL6.CanManufacturedProductAttribute == ProductAttribute.P2))
                        {
                            flag6 = true;
                        }
                        if (hasP3 && (this.m_pL6.CanManufacturedProductAttribute == ProductAttribute.P3))
                        {
                            flag6 = true;
                        }
                        if (hasP4 && (this.m_pL6.CanManufacturedProductAttribute == ProductAttribute.P4))
                        {
                            flag6 = true;
                        }
                        if (flag6)
                        {
                            num++;
                        }
                    }
                    if ((this.m_pL7.PLAttribute != ProductLineAttribute.无) && ((this.m_pL7.RemainProduceCycle < 1) && ((this.m_pL7.RemainInstallationCycle < 1) && (this.m_pL7.RemainTransferringCycle < 1))))
                    {
                        bool flag7 = false;
                        if (this.m_pL7.CanManufacturedProductAttribute == ProductAttribute.全部)
                        {
                            flag7 = true;
                        }
                        if (this.m_pL7.CanManufacturedProductAttribute == ProductAttribute.P1)
                        {
                            flag7 = true;
                        }
                        if (hasP2 && (this.m_pL7.CanManufacturedProductAttribute == ProductAttribute.P2))
                        {
                            flag7 = true;
                        }
                        if (hasP3 && (this.m_pL7.CanManufacturedProductAttribute == ProductAttribute.P3))
                        {
                            flag7 = true;
                        }
                        if (hasP4 && (this.m_pL7.CanManufacturedProductAttribute == ProductAttribute.P4))
                        {
                            flag7 = true;
                        }
                        if (flag7)
                        {
                            num++;
                        }
                    }
                    break;

                case BusinessTier.PlantName.工厂C:
                    if ((this.m_pL8.PLAttribute != ProductLineAttribute.无) && ((this.m_pL8.RemainProduceCycle < 1) && ((this.m_pL8.RemainInstallationCycle < 1) && (this.m_pL8.RemainTransferringCycle < 1))))
                    {
                        bool flag8 = false;
                        if (this.m_pL8.CanManufacturedProductAttribute == ProductAttribute.全部)
                        {
                            flag8 = true;
                        }
                        if (this.m_pL8.CanManufacturedProductAttribute == ProductAttribute.P1)
                        {
                            flag8 = true;
                        }
                        if (hasP2 && (this.m_pL8.CanManufacturedProductAttribute == ProductAttribute.P2))
                        {
                            flag8 = true;
                        }
                        if (hasP3 && (this.m_pL8.CanManufacturedProductAttribute == ProductAttribute.P3))
                        {
                            flag8 = true;
                        }
                        if (hasP4 && (this.m_pL8.CanManufacturedProductAttribute == ProductAttribute.P4))
                        {
                            flag8 = true;
                        }
                        if (flag8)
                        {
                            num++;
                        }
                    }
                    break;

                default:
                    break;
            }
            return num;
        }

        public TProductLine[] GetCanSaleProductLine(BusinessTier.PlantName plName)
        {
            TProductLine[] lineArray;
            int canSaleProductLineCount = this.GetCanSaleProductLineCount(plName);
            if (canSaleProductLineCount == 0)
            {
                lineArray = null;
            }
            else
            {
                lineArray = new TProductLine[canSaleProductLineCount];
                int index = 0;
                switch (plName)
                {
                    case BusinessTier.PlantName.工厂A:
                        if ((this.m_pL1.PLAttribute != ProductLineAttribute.无) && ((this.m_pL1.RemainProduceCycle < 1) && ((this.m_pL1.RemainInstallationCycle < 1) && (this.m_pL1.RemainTransferringCycle < 1))))
                        {
                            lineArray[index] = this.m_pL1;
                            index++;
                        }
                        if ((this.m_pL2.PLAttribute != ProductLineAttribute.无) && ((this.m_pL2.RemainProduceCycle < 1) && ((this.m_pL2.RemainInstallationCycle < 1) && (this.m_pL2.RemainTransferringCycle < 1))))
                        {
                            lineArray[index] = this.m_pL2;
                            index++;
                        }
                        if ((this.m_pL3.PLAttribute != ProductLineAttribute.无) && ((this.m_pL3.RemainProduceCycle < 1) && ((this.m_pL3.RemainInstallationCycle < 1) && (this.m_pL3.RemainTransferringCycle < 1))))
                        {
                            lineArray[index] = this.m_pL3;
                            index++;
                        }
                        if ((this.m_pL4.PLAttribute != ProductLineAttribute.无) && ((this.m_pL4.RemainProduceCycle < 1) && ((this.m_pL4.RemainInstallationCycle < 1) && (this.m_pL4.RemainTransferringCycle < 1))))
                        {
                            lineArray[index] = this.m_pL4;
                            index++;
                        }
                        break;

                    case BusinessTier.PlantName.工厂B:
                        if ((this.m_pL5.PLAttribute != ProductLineAttribute.无) && ((this.m_pL5.RemainProduceCycle < 1) && ((this.m_pL5.RemainInstallationCycle < 1) && (this.m_pL5.RemainTransferringCycle < 1))))
                        {
                            lineArray[index] = this.m_pL5;
                            index++;
                        }
                        if ((this.m_pL6.PLAttribute != ProductLineAttribute.无) && ((this.m_pL6.RemainProduceCycle < 1) && ((this.m_pL6.RemainInstallationCycle < 1) && (this.m_pL6.RemainTransferringCycle < 1))))
                        {
                            lineArray[index] = this.m_pL6;
                            index++;
                        }
                        if ((this.m_pL7.PLAttribute != ProductLineAttribute.无) && ((this.m_pL7.RemainProduceCycle < 1) && ((this.m_pL7.RemainInstallationCycle < 1) && (this.m_pL7.RemainTransferringCycle < 1))))
                        {
                            lineArray[index] = this.m_pL7;
                            index++;
                        }
                        break;

                    case BusinessTier.PlantName.工厂C:
                        if ((this.m_pL8.PLAttribute != ProductLineAttribute.无) && ((this.m_pL8.RemainProduceCycle < 1) && ((this.m_pL8.RemainInstallationCycle < 1) && (this.m_pL8.RemainTransferringCycle < 1))))
                        {
                            lineArray[index] = this.m_pL8;
                            index++;
                        }
                        break;

                    default:
                        break;
                }
            }
            return lineArray;
        }

        public int GetCanSaleProductLineCount(BusinessTier.PlantName plName)
        {
            int num = 0;
            switch (plName)
            {
                case BusinessTier.PlantName.工厂A:
                    if ((this.m_pL1.PLAttribute != ProductLineAttribute.无) && ((this.m_pL1.RemainProduceCycle < 1) && ((this.m_pL1.RemainInstallationCycle < 1) && (this.m_pL1.RemainTransferringCycle < 1))))
                    {
                        num++;
                    }
                    if ((this.m_pL2.PLAttribute != ProductLineAttribute.无) && ((this.m_pL2.RemainProduceCycle < 1) && ((this.m_pL2.RemainInstallationCycle < 1) && (this.m_pL2.RemainTransferringCycle < 1))))
                    {
                        num++;
                    }
                    if ((this.m_pL3.PLAttribute != ProductLineAttribute.无) && ((this.m_pL3.RemainProduceCycle < 1) && ((this.m_pL3.RemainInstallationCycle < 1) && (this.m_pL3.RemainTransferringCycle < 1))))
                    {
                        num++;
                    }
                    if ((this.m_pL4.PLAttribute != ProductLineAttribute.无) && ((this.m_pL4.RemainProduceCycle < 1) && ((this.m_pL4.RemainInstallationCycle < 1) && (this.m_pL4.RemainTransferringCycle < 1))))
                    {
                        num++;
                    }
                    break;

                case BusinessTier.PlantName.工厂B:
                    if ((this.m_pL5.PLAttribute != ProductLineAttribute.无) && ((this.m_pL5.RemainProduceCycle < 1) && ((this.m_pL5.RemainInstallationCycle < 1) && (this.m_pL5.RemainTransferringCycle < 1))))
                    {
                        num++;
                    }
                    if ((this.m_pL6.PLAttribute != ProductLineAttribute.无) && ((this.m_pL6.RemainProduceCycle < 1) && ((this.m_pL6.RemainInstallationCycle < 1) && (this.m_pL6.RemainTransferringCycle < 1))))
                    {
                        num++;
                    }
                    if ((this.m_pL7.PLAttribute != ProductLineAttribute.无) && ((this.m_pL7.RemainProduceCycle < 1) && ((this.m_pL7.RemainInstallationCycle < 1) && (this.m_pL7.RemainTransferringCycle < 1))))
                    {
                        num++;
                    }
                    break;

                case BusinessTier.PlantName.工厂C:
                    if ((this.m_pL8.PLAttribute != ProductLineAttribute.无) && ((this.m_pL8.RemainProduceCycle < 1) && ((this.m_pL8.RemainInstallationCycle < 1) && (this.m_pL8.RemainTransferringCycle < 1))))
                    {
                        num++;
                    }
                    break;

                default:
                    break;
            }
            return num;
        }

        public TProductLine[] GetInvestmentAgainPL(BusinessTier.PlantName plName)
        {
            TProductLine[] lineArray;
            int investmentAgainPLCount = this.GetInvestmentAgainPLCount(plName);
            if (investmentAgainPLCount == 0)
            {
                lineArray = null;
            }
            else
            {
                lineArray = new TProductLine[investmentAgainPLCount];
                int index = 0;
                switch (plName)
                {
                    case BusinessTier.PlantName.工厂A:
                        if ((this.m_pL1.PLAttribute != ProductLineAttribute.无) && ((this.m_pL1.RemainProduceCycle < 1) && ((this.m_pL1.RemainTransferringCycle < 1) && (this.m_pL1.RemainInstallationCycle >= 1))))
                        {
                            lineArray[index] = this.m_pL1;
                            index++;
                        }
                        if ((this.m_pL2.PLAttribute != ProductLineAttribute.无) && ((this.m_pL2.RemainProduceCycle < 1) && ((this.m_pL2.RemainTransferringCycle < 1) && (this.m_pL2.RemainInstallationCycle >= 1))))
                        {
                            lineArray[index] = this.m_pL2;
                            index++;
                        }
                        if ((this.m_pL3.PLAttribute != ProductLineAttribute.无) && ((this.m_pL3.RemainProduceCycle < 1) && ((this.m_pL3.RemainTransferringCycle < 1) && (this.m_pL3.RemainInstallationCycle >= 1))))
                        {
                            lineArray[index] = this.m_pL3;
                            index++;
                        }
                        if ((this.m_pL4.PLAttribute != ProductLineAttribute.无) && ((this.m_pL4.RemainProduceCycle < 1) && ((this.m_pL4.RemainTransferringCycle < 1) && (this.m_pL4.RemainInstallationCycle >= 1))))
                        {
                            lineArray[index] = this.m_pL4;
                            index++;
                        }
                        break;

                    case BusinessTier.PlantName.工厂B:
                        if ((this.m_pL5.PLAttribute != ProductLineAttribute.无) && ((this.m_pL5.RemainProduceCycle < 1) && ((this.m_pL5.RemainTransferringCycle < 1) && (this.m_pL5.RemainInstallationCycle >= 1))))
                        {
                            lineArray[index] = this.m_pL5;
                            index++;
                        }
                        if ((this.m_pL6.PLAttribute != ProductLineAttribute.无) && ((this.m_pL6.RemainProduceCycle < 1) && ((this.m_pL6.RemainTransferringCycle < 1) && (this.m_pL6.RemainInstallationCycle >= 1))))
                        {
                            lineArray[index] = this.m_pL6;
                            index++;
                        }
                        if ((this.m_pL7.PLAttribute != ProductLineAttribute.无) && ((this.m_pL7.RemainProduceCycle < 1) && ((this.m_pL7.RemainTransferringCycle < 1) && (this.m_pL7.RemainInstallationCycle >= 1))))
                        {
                            lineArray[index] = this.m_pL7;
                            index++;
                        }
                        break;

                    case BusinessTier.PlantName.工厂C:
                        if ((this.m_pL8.PLAttribute != ProductLineAttribute.无) && ((this.m_pL8.RemainProduceCycle < 1) && ((this.m_pL8.RemainTransferringCycle < 1) && (this.m_pL8.RemainInstallationCycle >= 1))))
                        {
                            lineArray[index] = this.m_pL8;
                            index++;
                        }
                        break;

                    default:
                        break;
                }
            }
            return lineArray;
        }

        public int GetInvestmentAgainPLCount(BusinessTier.PlantName plName)
        {
            int num = 0;
            switch (plName)
            {
                case BusinessTier.PlantName.工厂A:
                    if ((this.m_pL1.PLAttribute != ProductLineAttribute.无) && ((this.m_pL1.RemainProduceCycle < 1) && ((this.m_pL1.RemainTransferringCycle < 1) && (this.m_pL1.RemainInstallationCycle >= 1))))
                    {
                        num++;
                    }
                    if ((this.m_pL2.PLAttribute != ProductLineAttribute.无) && ((this.m_pL2.RemainProduceCycle < 1) && ((this.m_pL2.RemainTransferringCycle < 1) && (this.m_pL2.RemainInstallationCycle >= 1))))
                    {
                        num++;
                    }
                    if ((this.m_pL3.PLAttribute != ProductLineAttribute.无) && ((this.m_pL3.RemainProduceCycle < 1) && ((this.m_pL3.RemainTransferringCycle < 1) && (this.m_pL3.RemainInstallationCycle >= 1))))
                    {
                        num++;
                    }
                    if ((this.m_pL4.PLAttribute != ProductLineAttribute.无) && ((this.m_pL4.RemainProduceCycle < 1) && ((this.m_pL4.RemainTransferringCycle < 1) && (this.m_pL4.RemainInstallationCycle >= 1))))
                    {
                        num++;
                    }
                    break;

                case BusinessTier.PlantName.工厂B:
                    if ((this.m_pL5.PLAttribute != ProductLineAttribute.无) && ((this.m_pL5.RemainProduceCycle < 1) && ((this.m_pL5.RemainTransferringCycle < 1) && (this.m_pL5.RemainInstallationCycle >= 1))))
                    {
                        num++;
                    }
                    if ((this.m_pL6.PLAttribute != ProductLineAttribute.无) && ((this.m_pL6.RemainProduceCycle < 1) && ((this.m_pL6.RemainTransferringCycle < 1) && (this.m_pL6.RemainInstallationCycle >= 1))))
                    {
                        num++;
                    }
                    if ((this.m_pL7.PLAttribute != ProductLineAttribute.无) && ((this.m_pL7.RemainProduceCycle < 1) && ((this.m_pL7.RemainTransferringCycle < 1) && (this.m_pL7.RemainInstallationCycle >= 1))))
                    {
                        num++;
                    }
                    break;

                case BusinessTier.PlantName.工厂C:
                    if ((this.m_pL8.PLAttribute != ProductLineAttribute.无) && ((this.m_pL8.RemainProduceCycle < 1) && ((this.m_pL8.RemainTransferringCycle < 1) && (this.m_pL8.RemainInstallationCycle >= 1))))
                    {
                        num++;
                    }
                    break;

                default:
                    break;
            }
            return num;
        }

        public TProductLine[] GetTransferringProductLine(BusinessTier.PlantName plName)
        {
            TProductLine[] lineArray;
            int transferringProductLineCount = this.GetTransferringProductLineCount(plName);
            if (transferringProductLineCount == 0)
            {
                lineArray = null;
            }
            else
            {
                lineArray = new TProductLine[transferringProductLineCount];
                int index = 0;
                switch (plName)
                {
                    case BusinessTier.PlantName.工厂A:
                        if ((this.m_pL1.PLAttribute != ProductLineAttribute.无) && ((this.m_pL1.RemainProduceCycle < 1) && ((this.m_pL1.PLAttribute != ProductLineAttribute.手工) && ((this.m_pL1.PLAttribute != ProductLineAttribute.柔性) && ((this.m_pL1.RemainInstallationCycle < 1) && (this.m_pL1.RemainTransferringCycle < 1))))))
                        {
                            lineArray[index] = this.m_pL1;
                            index++;
                        }
                        if ((this.m_pL2.PLAttribute != ProductLineAttribute.无) && ((this.m_pL2.RemainProduceCycle < 1) && ((this.m_pL2.PLAttribute != ProductLineAttribute.手工) && ((this.m_pL2.PLAttribute != ProductLineAttribute.柔性) && ((this.m_pL2.RemainInstallationCycle < 1) && (this.m_pL2.RemainTransferringCycle < 1))))))
                        {
                            lineArray[index] = this.m_pL2;
                            index++;
                        }
                        if ((this.m_pL3.PLAttribute != ProductLineAttribute.无) && ((this.m_pL3.RemainProduceCycle < 1) && ((this.m_pL3.PLAttribute != ProductLineAttribute.手工) && ((this.m_pL3.PLAttribute != ProductLineAttribute.柔性) && ((this.m_pL3.RemainInstallationCycle < 1) && (this.m_pL3.RemainTransferringCycle < 1))))))
                        {
                            lineArray[index] = this.m_pL3;
                            index++;
                        }
                        if ((this.m_pL4.PLAttribute != ProductLineAttribute.无) && ((this.m_pL4.RemainProduceCycle < 1) && ((this.m_pL4.PLAttribute != ProductLineAttribute.手工) && ((this.m_pL4.PLAttribute != ProductLineAttribute.柔性) && ((this.m_pL4.RemainInstallationCycle < 1) && (this.m_pL4.RemainTransferringCycle < 1))))))
                        {
                            lineArray[index] = this.m_pL4;
                            index++;
                        }
                        break;

                    case BusinessTier.PlantName.工厂B:
                        if ((this.m_pL5.PLAttribute != ProductLineAttribute.无) && ((this.m_pL5.RemainProduceCycle < 1) && ((this.m_pL5.PLAttribute != ProductLineAttribute.手工) && ((this.m_pL5.PLAttribute != ProductLineAttribute.柔性) && ((this.m_pL5.RemainInstallationCycle < 1) && (this.m_pL5.RemainTransferringCycle < 1))))))
                        {
                            lineArray[index] = this.m_pL5;
                            index++;
                        }
                        if ((this.m_pL6.PLAttribute != ProductLineAttribute.无) && ((this.m_pL6.RemainProduceCycle < 1) && ((this.m_pL6.PLAttribute != ProductLineAttribute.手工) && ((this.m_pL6.PLAttribute != ProductLineAttribute.柔性) && ((this.m_pL6.RemainInstallationCycle < 1) && (this.m_pL6.RemainTransferringCycle < 1))))))
                        {
                            lineArray[index] = this.m_pL6;
                            index++;
                        }
                        if ((this.m_pL7.PLAttribute != ProductLineAttribute.无) && ((this.m_pL7.RemainProduceCycle < 1) && ((this.m_pL7.PLAttribute != ProductLineAttribute.手工) && ((this.m_pL7.PLAttribute != ProductLineAttribute.柔性) && ((this.m_pL7.RemainInstallationCycle < 1) && (this.m_pL7.RemainTransferringCycle < 1))))))
                        {
                            lineArray[index] = this.m_pL7;
                            index++;
                        }
                        break;

                    case BusinessTier.PlantName.工厂C:
                        if ((this.m_pL8.PLAttribute != ProductLineAttribute.无) && ((this.m_pL8.RemainProduceCycle < 1) && ((this.m_pL8.PLAttribute != ProductLineAttribute.手工) && ((this.m_pL8.PLAttribute != ProductLineAttribute.柔性) && ((this.m_pL8.RemainInstallationCycle < 1) && (this.m_pL8.RemainTransferringCycle < 1))))))
                        {
                            lineArray[index] = this.m_pL8;
                            index++;
                        }
                        break;

                    default:
                        break;
                }
            }
            return lineArray;
        }

        public int GetTransferringProductLineCount(BusinessTier.PlantName plName)
        {
            int num = 0;
            switch (plName)
            {
                case BusinessTier.PlantName.工厂A:
                    if ((this.m_pL1.PLAttribute != ProductLineAttribute.无) && ((this.m_pL1.RemainProduceCycle < 1) && ((this.m_pL1.PLAttribute != ProductLineAttribute.手工) && ((this.m_pL1.PLAttribute != ProductLineAttribute.柔性) && ((this.m_pL1.RemainInstallationCycle < 1) && (this.m_pL1.RemainTransferringCycle < 1))))))
                    {
                        num++;
                    }
                    if ((this.m_pL2.PLAttribute != ProductLineAttribute.无) && ((this.m_pL2.RemainProduceCycle < 1) && ((this.m_pL2.PLAttribute != ProductLineAttribute.手工) && ((this.m_pL2.PLAttribute != ProductLineAttribute.柔性) && ((this.m_pL2.RemainInstallationCycle < 1) && (this.m_pL2.RemainTransferringCycle < 1))))))
                    {
                        num++;
                    }
                    if ((this.m_pL3.PLAttribute != ProductLineAttribute.无) && ((this.m_pL3.RemainProduceCycle < 1) && ((this.m_pL3.PLAttribute != ProductLineAttribute.手工) && ((this.m_pL3.PLAttribute != ProductLineAttribute.柔性) && ((this.m_pL3.RemainInstallationCycle < 1) && (this.m_pL3.RemainTransferringCycle < 1))))))
                    {
                        num++;
                    }
                    if ((this.m_pL4.PLAttribute != ProductLineAttribute.无) && ((this.m_pL4.RemainProduceCycle < 1) && ((this.m_pL4.PLAttribute != ProductLineAttribute.手工) && ((this.m_pL4.PLAttribute != ProductLineAttribute.柔性) && ((this.m_pL4.RemainInstallationCycle < 1) && (this.m_pL4.RemainTransferringCycle < 1))))))
                    {
                        num++;
                    }
                    break;

                case BusinessTier.PlantName.工厂B:
                    if ((this.m_pL5.PLAttribute != ProductLineAttribute.无) && ((this.m_pL5.RemainProduceCycle < 1) && ((this.m_pL5.PLAttribute != ProductLineAttribute.手工) && ((this.m_pL5.PLAttribute != ProductLineAttribute.柔性) && ((this.m_pL5.RemainInstallationCycle < 1) && (this.m_pL5.RemainTransferringCycle < 1))))))
                    {
                        num++;
                    }
                    if ((this.m_pL6.PLAttribute != ProductLineAttribute.无) && ((this.m_pL6.RemainProduceCycle < 1) && ((this.m_pL6.PLAttribute != ProductLineAttribute.手工) && ((this.m_pL6.PLAttribute != ProductLineAttribute.柔性) && ((this.m_pL6.RemainInstallationCycle < 1) && (this.m_pL6.RemainTransferringCycle < 1))))))
                    {
                        num++;
                    }
                    if ((this.m_pL7.PLAttribute != ProductLineAttribute.无) && ((this.m_pL7.RemainProduceCycle < 1) && ((this.m_pL7.PLAttribute != ProductLineAttribute.手工) && ((this.m_pL7.PLAttribute != ProductLineAttribute.柔性) && ((this.m_pL7.RemainInstallationCycle < 1) && (this.m_pL7.RemainTransferringCycle < 1))))))
                    {
                        num++;
                    }
                    break;

                case BusinessTier.PlantName.工厂C:
                    if ((this.m_pL8.PLAttribute != ProductLineAttribute.无) && ((this.m_pL8.RemainProduceCycle < 1) && ((this.m_pL8.PLAttribute != ProductLineAttribute.手工) && ((this.m_pL8.PLAttribute != ProductLineAttribute.柔性) && ((this.m_pL8.RemainInstallationCycle < 1) && (this.m_pL8.RemainTransferringCycle < 1))))))
                    {
                        num++;
                    }
                    break;

                default:
                    break;
            }
            return num;
        }

        public int GetXYWXSCXCount(BusinessTier.PlantName plName)
        {
            int num = 0;
            switch (plName)
            {
                case BusinessTier.PlantName.工厂A:
                    if ((this.m_pL1.PLAttribute != ProductLineAttribute.无) && ((this.m_pL1.RemainInstallationCycle < 1) && (this.m_pL1.RemainTransferringCycle < 1)))
                    {
                        num++;
                    }
                    if ((this.m_pL2.PLAttribute != ProductLineAttribute.无) && ((this.m_pL2.RemainInstallationCycle < 1) && (this.m_pL2.RemainTransferringCycle < 1)))
                    {
                        num++;
                    }
                    if ((this.m_pL3.PLAttribute != ProductLineAttribute.无) && ((this.m_pL3.RemainInstallationCycle < 1) && (this.m_pL3.RemainTransferringCycle < 1)))
                    {
                        num++;
                    }
                    if ((this.m_pL4.PLAttribute != ProductLineAttribute.无) && ((this.m_pL4.RemainInstallationCycle < 1) && (this.m_pL4.RemainTransferringCycle < 1)))
                    {
                        num++;
                    }
                    break;

                case BusinessTier.PlantName.工厂B:
                    if ((this.m_pL5.PLAttribute != ProductLineAttribute.无) && ((this.m_pL5.RemainInstallationCycle < 1) && (this.m_pL5.RemainTransferringCycle < 1)))
                    {
                        num++;
                    }
                    if ((this.m_pL6.PLAttribute != ProductLineAttribute.无) && ((this.m_pL6.RemainInstallationCycle < 1) && (this.m_pL6.RemainTransferringCycle < 1)))
                    {
                        num++;
                    }
                    if ((this.m_pL7.PLAttribute != ProductLineAttribute.无) && ((this.m_pL7.RemainInstallationCycle < 1) && (this.m_pL7.RemainTransferringCycle < 1)))
                    {
                        num++;
                    }
                    break;

                case BusinessTier.PlantName.工厂C:
                    if ((this.m_pL8.PLAttribute != ProductLineAttribute.无) && ((this.m_pL8.RemainInstallationCycle < 1) && (this.m_pL8.RemainTransferringCycle < 1)))
                    {
                        num++;
                    }
                    break;

                default:
                    break;
            }
            return num;
        }

        private void SetProductLineWhenSetUp(TProductLine pl, ProductLineAttribute pla, ProductAttribute pda)
        {
            pl.PLAttribute = pla;
            pl.CanManufacturedProductAttribute = pda;
            pl.AlreadyInstallationCycle = 1;
            pl.AlreadyProduceCycle = 0x206;
            pl.AlreadyTransferringCycle = 0x206;
            switch (pla)
            {
                case ProductLineAttribute.手工:
                    pl.ByeCost = 5;
                    pl.InstallationCycle = 0;
                    pl.ProdceCycle = 3;
                    pl.TransferringCycle = 0;
                    pl.MaintenanceCosts = 1;
                    pl.SaleCost = 1;
                    return;

                case ProductLineAttribute.全自动:
                    pl.ByeCost = 0x10;
                    pl.InstallationCycle = 4;
                    pl.ProdceCycle = 1;
                    pl.TransferringCycle = 2;
                    pl.MaintenanceCosts = 1;
                    pl.SaleCost = 4;
                    return;

                case ProductLineAttribute.半自动:
                    pl.ByeCost = 8;
                    pl.InstallationCycle = 2;
                    pl.ProdceCycle = 2;
                    pl.TransferringCycle = 1;
                    pl.MaintenanceCosts = 1;
                    pl.SaleCost = 2;
                    return;

                case ProductLineAttribute.柔性:
                    pl.ByeCost = 0x18;
                    pl.InstallationCycle = 4;
                    pl.ProdceCycle = 1;
                    pl.TransferringCycle = 0;
                    pl.MaintenanceCosts = 1;
                    pl.SaleCost = 6;
                    return;

                case ProductLineAttribute.无:
                    pl.ByeCost = 0;
                    pl.InstallationCycle = 0;
                    pl.ProdceCycle = 0;
                    pl.TransferringCycle = 0;
                    pl.MaintenanceCosts = 0;
                    pl.SaleCost = 0;
                    return;
            }
        }

        private void SetProductLineWhenStartNewProduce(TProductLine pl, ProductAttribute pda)
        {
            pl.AlreadyTransferringCycle = 0x206;
            pl.AlreadyInstallationCycle = 0x206;
            pl.AlreadyProduceCycle = 0;
            pl.ManufacturedProduct = new TProduct(pda);
        }

        private void SetProductLineWhenTansferring(TProductLine pl, ProductAttribute pda)
        {
            pl.AlreadyTransferringCycle = 0;
            pl.AlreadyInstallationCycle = 0x206;
            pl.AlreadyProduceCycle = 0x206;
            pl.CanManufacturedProductAttribute = pda;
        }

        public void SetUpProductLine(ProductLineName plName, ProductLineAttribute pla, ProductAttribute pda)
        {
            switch (plName)
            {
                case ProductLineName.PL1:
                    this.SetProductLineWhenSetUp(this.PL1, pla, pda);
                    return;

                case ProductLineName.PL2:
                    this.SetProductLineWhenSetUp(this.PL2, pla, pda);
                    return;

                case ProductLineName.PL3:
                    this.SetProductLineWhenSetUp(this.PL3, pla, pda);
                    return;

                case ProductLineName.PL4:
                    this.SetProductLineWhenSetUp(this.PL4, pla, pda);
                    return;

                case ProductLineName.PL5:
                    this.SetProductLineWhenSetUp(this.PL5, pla, pda);
                    return;

                case ProductLineName.PL6:
                    this.SetProductLineWhenSetUp(this.PL6, pla, pda);
                    return;

                case ProductLineName.PL7:
                    this.SetProductLineWhenSetUp(this.PL7, pla, pda);
                    return;

                case ProductLineName.PL8:
                    this.SetProductLineWhenSetUp(this.PL8, pla, pda);
                    return;
            }
        }

        public void StartNewProduce(ProductLineName plName, ProductAttribute pda)
        {
            switch (plName)
            {
                case ProductLineName.PL1:
                    this.SetProductLineWhenStartNewProduce(this.PL1, pda);
                    return;

                case ProductLineName.PL2:
                    this.SetProductLineWhenStartNewProduce(this.PL2, pda);
                    return;

                case ProductLineName.PL3:
                    this.SetProductLineWhenStartNewProduce(this.PL3, pda);
                    return;

                case ProductLineName.PL4:
                    this.SetProductLineWhenStartNewProduce(this.PL4, pda);
                    return;

                case ProductLineName.PL5:
                    this.SetProductLineWhenStartNewProduce(this.PL5, pda);
                    return;

                case ProductLineName.PL6:
                    this.SetProductLineWhenStartNewProduce(this.PL6, pda);
                    return;

                case ProductLineName.PL7:
                    this.SetProductLineWhenStartNewProduce(this.PL7, pda);
                    return;

                case ProductLineName.PL8:
                    this.SetProductLineWhenStartNewProduce(this.PL8, pda);
                    return;
            }
        }

        public void TransferringProductLine(ProductLineName plName, ProductAttribute pda)
        {
            switch (plName)
            {
                case ProductLineName.PL1:
                    this.SetProductLineWhenTansferring(this.PL1, pda);
                    return;

                case ProductLineName.PL2:
                    this.SetProductLineWhenTansferring(this.PL2, pda);
                    return;

                case ProductLineName.PL3:
                    this.SetProductLineWhenTansferring(this.PL3, pda);
                    return;

                case ProductLineName.PL4:
                    this.SetProductLineWhenTansferring(this.PL4, pda);
                    return;

                case ProductLineName.PL5:
                    this.SetProductLineWhenTansferring(this.PL5, pda);
                    return;

                case ProductLineName.PL6:
                    this.SetProductLineWhenTansferring(this.PL6, pda);
                    return;

                case ProductLineName.PL7:
                    this.SetProductLineWhenTansferring(this.PL7, pda);
                    return;

                case ProductLineName.PL8:
                    this.SetProductLineWhenTansferring(this.PL8, pda);
                    return;
            }
        }

        public int PurchasePrice =>
            this.m_purchasePrice;

        public int LeasingPrice =>
            this.m_leasingPrice;

        public BusinessTier.PlantAttribute PlantAttribute
        {
            get => 
                this.m_plantAttribute;
            set => 
                this.m_plantAttribute = value;
        }

        public BusinessTier.PlantName PlantName =>
            this.m_PlantName;

        public TProductLine PL1
        {
            get => 
                this.m_pL1;
            set => 
                this.m_pL1 = value;
        }

        public TProductLine PL2
        {
            get => 
                this.m_pL2;
            set => 
                this.m_pL2 = value;
        }

        public TProductLine PL3
        {
            get => 
                this.m_pL3;
            set => 
                this.m_pL3 = value;
        }

        public TProductLine PL4
        {
            get => 
                this.m_pL4;
            set => 
                this.m_pL4 = value;
        }

        public TProductLine PL5
        {
            get => 
                this.m_pL5;
            set => 
                this.m_pL5 = value;
        }

        public TProductLine PL6
        {
            get => 
                this.m_pL6;
            set => 
                this.m_pL6 = value;
        }

        public TProductLine PL7
        {
            get => 
                this.m_pL7;
            set => 
                this.m_pL7 = value;
        }

        public TProductLine PL8
        {
            get => 
                this.m_pL8;
            set => 
                this.m_pL8 = value;
        }
    }
}

