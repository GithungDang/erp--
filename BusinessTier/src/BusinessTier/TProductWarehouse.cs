namespace BusinessTier
{
    using System;

    public class TProductWarehouse
    {
        private int m_inventoryAmount;

        public TProductWarehouse(int inventoryAmount)
        {
            this.m_inventoryAmount = inventoryAmount;
        }

        public int InventoryAmount
        {
            get => 
                this.m_inventoryAmount;
            set => 
                this.m_inventoryAmount = value;
        }
    }
}

