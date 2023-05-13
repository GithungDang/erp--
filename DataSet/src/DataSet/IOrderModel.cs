namespace DataSet
{
    using BusinessTier;
    using System;

    public interface IOrderModel
    {
        void CreateOrderModel();
        TOrder[] GetOrders(Year year, Market market);
    }
}

