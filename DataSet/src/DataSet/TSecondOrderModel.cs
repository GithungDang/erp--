namespace DataSet
{
    using BusinessTier;
    using System;

    public class TSecondOrderModel : IOrderModel
    {
        private TOrder[] m_AllOrders;

        public void CreateOrderModel()
        {
            this.m_AllOrders = new TOrder[0xf3];
            this.m_AllOrders[0] = new TOrder(Year.第1年, Market.本地, "BD-1/6", ProductAttribute.P1, 1, 6, 1, ISOQualify.无);
            this.m_AllOrders[1] = new TOrder(Year.第1年, Market.本地, "BD-2/6", ProductAttribute.P1, 2, 5, 2, ISOQualify.无);
            this.m_AllOrders[2] = new TOrder(Year.第1年, Market.本地, "BD-3/6", ProductAttribute.P1, 7, 5, 4, ISOQualify.无);
            this.m_AllOrders[3] = new TOrder(Year.第1年, Market.本地, "BD-4/6", ProductAttribute.P1, 5, 6, 4, ISOQualify.无);
            this.m_AllOrders[4] = new TOrder(Year.第1年, Market.本地, "BD-5/6", ProductAttribute.P1, 3, 6, 3, ISOQualify.无);
            this.m_AllOrders[5] = new TOrder(Year.第1年, Market.本地, "BD-6/6", ProductAttribute.P1, 2, 6, 2, ISOQualify.无);
            this.m_AllOrders[6] = new TOrder(Year.第2年, Market.本地, "BD-1/7", ProductAttribute.P1, 1, 5, 1, ISOQualify.无);
            this.m_AllOrders[7] = new TOrder(Year.第2年, Market.本地, "BD-2/7", ProductAttribute.P1, 4, 5, 3, ISOQualify.无);
            this.m_AllOrders[8] = new TOrder(Year.第2年, Market.本地, "BD-3/7", ProductAttribute.P1, 5, 5, 2, ISOQualify.无);
            this.m_AllOrders[9] = new TOrder(Year.第2年, Market.本地, "BD-4/7", ProductAttribute.P1, 2, 5, 3, ISOQualify.无);
            this.m_AllOrders[10] = new TOrder(Year.第2年, Market.本地, "BD-5/7", ProductAttribute.P1, 4, 5, 1, ISOQualify.无);
            this.m_AllOrders[11] = new TOrder(Year.第2年, Market.本地, "BD-6/7", ProductAttribute.P1, 3, 5, 3, ISOQualify.无);
            this.m_AllOrders[12] = new TOrder(Year.第2年, Market.本地, "BD-7/7", ProductAttribute.P1, 2, 5, 2, ISOQualify.无);
            this.m_AllOrders[13] = new TOrder(Year.第2年, Market.区域, "QY-1/7", ProductAttribute.P1, 2, 5, 2, ISOQualify.无);
            this.m_AllOrders[14] = new TOrder(Year.第2年, Market.区域, "QY-2/7", ProductAttribute.P1, 3, 5, 3, ISOQualify.无);
            this.m_AllOrders[15] = new TOrder(Year.第2年, Market.区域, "QY-3/7", ProductAttribute.P1, 1, 5, 1, ISOQualify.无);
            this.m_AllOrders[0xef] = new TOrder(Year.第2年, Market.区域, "QY-4/7", ProductAttribute.P1, 2, 6, 2, ISOQualify.无);
            this.m_AllOrders[240] = new TOrder(Year.第2年, Market.区域, "QY-5/7", ProductAttribute.P1, 1, 6, 4, ISOQualify.无);
            this.m_AllOrders[0xf1] = new TOrder(Year.第2年, Market.区域, "QY-6/7", ProductAttribute.P1, 7, 5, 2, ISOQualify.无);
            this.m_AllOrders[0xf2] = new TOrder(Year.第2年, Market.区域, "QY-7/7", ProductAttribute.P1, 3, 5, 1, ISOQualify.无);
            this.m_AllOrders[0x10] = new TOrder(Year.第3年, Market.本地, "BD-1/5", ProductAttribute.P1, 2, 5, 2, ISOQualify.无);
            this.m_AllOrders[0x11] = new TOrder(Year.第3年, Market.本地, "BD-2/5", ProductAttribute.P1, 6, 4, 3, ISOQualify.无);
            this.m_AllOrders[0x12] = new TOrder(Year.第3年, Market.本地, "BD-3/5", ProductAttribute.P1, 3, 5, 2, ISOQualify.无);
            this.m_AllOrders[0x13] = new TOrder(Year.第3年, Market.本地, "BD-4/5", ProductAttribute.P1, 4, 5, 1, ISOQualify.无);
            this.m_AllOrders[20] = new TOrder(Year.第3年, Market.本地, "BD-5/5", ProductAttribute.P1, 3, 5, 2, ISOQualify.无);
            this.m_AllOrders[0x15] = new TOrder(Year.第3年, Market.本地, "BD-01/5", ProductAttribute.P2, 3, 8, 3, ISOQualify.无);
            this.m_AllOrders[0x16] = new TOrder(Year.第3年, Market.本地, "BD-02/5", ProductAttribute.P2, 4, 8, 2, ISOQualify.无);
            this.m_AllOrders[0x17] = new TOrder(Year.第3年, Market.本地, "BD-03/5", ProductAttribute.P2, 2, 9, 1, ISOQualify.无);
            this.m_AllOrders[0x18] = new TOrder(Year.第3年, Market.本地, "BD-04/5", ProductAttribute.P2, 3, 8, 1, ISOQualify.无);
            this.m_AllOrders[0x19] = new TOrder(Year.第3年, Market.本地, "BD-05/5", ProductAttribute.P2, 2, 9, 3, ISOQualify.无);
            this.m_AllOrders[0x1a] = new TOrder(Year.第3年, Market.本地, "BD-1/3", ProductAttribute.P3, 2, 9, 3, ISOQualify.无);
            this.m_AllOrders[0x1b] = new TOrder(Year.第3年, Market.本地, "BD-2/3", ProductAttribute.P3, 4, 8, 2, ISOQualify.无);
            this.m_AllOrders[0x1c] = new TOrder(Year.第3年, Market.本地, "BD-3/3", ProductAttribute.P3, 1, 10, 2, ISOQualify.ISO9000);
            this.m_AllOrders[0x1d] = new TOrder(Year.第3年, Market.区域, "QY-1/3", ProductAttribute.P1, 2, 5, 3, ISOQualify.无);
            this.m_AllOrders[30] = new TOrder(Year.第3年, Market.区域, "QY-2/3", ProductAttribute.P1, 1, 5, 1, ISOQualify.无);
            this.m_AllOrders[0x1f] = new TOrder(Year.第3年, Market.区域, "QY-3/3", ProductAttribute.P1, 3, 5, 2, ISOQualify.无);
            this.m_AllOrders[0x20] = new TOrder(Year.第3年, Market.区域, "QY-1/4", ProductAttribute.P2, 4, 8, 2, ISOQualify.无);
            this.m_AllOrders[0x21] = new TOrder(Year.第3年, Market.区域, "QY-2/4", ProductAttribute.P2, 2, 8, 1, ISOQualify.无);
            this.m_AllOrders[0x22] = new TOrder(Year.第3年, Market.区域, "QY-3/4", ProductAttribute.P2, 3, 8, 2, ISOQualify.无);
            this.m_AllOrders[0x23] = new TOrder(Year.第3年, Market.区域, "QY-4/4", ProductAttribute.P2, 2, 9, 3, ISOQualify.无);
            this.m_AllOrders[0x24] = new TOrder(Year.第3年, Market.区域, "QY-01/3", ProductAttribute.P3, 1, 9, 1, ISOQualify.无);
            this.m_AllOrders[0x25] = new TOrder(Year.第3年, Market.区域, "QY-02/3", ProductAttribute.P3, 3, 8, 3, ISOQualify.无);
            this.m_AllOrders[0x26] = new TOrder(Year.第3年, Market.区域, "QY-03/3", ProductAttribute.P3, 2, 8, 2, ISOQualify.无);
            this.m_AllOrders[0x27] = new TOrder(Year.第3年, Market.区域, "QY-1/1", ProductAttribute.P4, 2, 8, 1, ISOQualify.无);
            this.m_AllOrders[40] = new TOrder(Year.第3年, Market.国内, "GN-1/5", ProductAttribute.P1, 3, 5, 3, ISOQualify.无);
            this.m_AllOrders[0x29] = new TOrder(Year.第3年, Market.国内, "GN-2/5", ProductAttribute.P1, 3, 4, 2, ISOQualify.无);
            this.m_AllOrders[0x2a] = new TOrder(Year.第3年, Market.国内, "GN-3/5", ProductAttribute.P1, 4, 5, 2, ISOQualify.无);
            this.m_AllOrders[0x2b] = new TOrder(Year.第3年, Market.国内, "GN-4/5", ProductAttribute.P1, 3, 5, 2, ISOQualify.无);
            this.m_AllOrders[0x2c] = new TOrder(Year.第3年, Market.国内, "GN-5/5", ProductAttribute.P1, 1, 6, 1, ISOQualify.无);
            this.m_AllOrders[0x2d] = new TOrder(Year.第3年, Market.国内, "GN-01/5", ProductAttribute.P2, 2, 9, 2, ISOQualify.无);
            this.m_AllOrders[0x2e] = new TOrder(Year.第3年, Market.国内, "GN-02/5", ProductAttribute.P2, 4, 8, 2, ISOQualify.无);
            this.m_AllOrders[0x2f] = new TOrder(Year.第3年, Market.国内, "GN-03/5", ProductAttribute.P2, 1, 9, 2, ISOQualify.无);
            this.m_AllOrders[0x30] = new TOrder(Year.第3年, Market.国内, "GN-04/5", ProductAttribute.P2, 2, 8, 2, ISOQualify.无);
            this.m_AllOrders[0x31] = new TOrder(Year.第3年, Market.国内, "GN-05/5", ProductAttribute.P2, 3, 8, 3, ISOQualify.无);
            this.m_AllOrders[50] = new TOrder(Year.第3年, Market.国内, "GN-1/2", ProductAttribute.P3, 2, 8, 2, ISOQualify.无);
            this.m_AllOrders[0x33] = new TOrder(Year.第3年, Market.国内, "GN-2/2", ProductAttribute.P3, 3, 8, 3, ISOQualify.无);
            this.m_AllOrders[0x34] = new TOrder(Year.第4年, Market.本地, "BD-1/6", ProductAttribute.P1, 1, 5, 3, ISOQualify.无);
            this.m_AllOrders[0x35] = new TOrder(Year.第4年, Market.本地, "BD-2/6", ProductAttribute.P1, 3, 4, 1, ISOQualify.无);
            this.m_AllOrders[0x36] = new TOrder(Year.第4年, Market.本地, "BD-3/6", ProductAttribute.P1, 2, 5, 2, ISOQualify.无);
            this.m_AllOrders[0x37] = new TOrder(Year.第4年, Market.本地, "BD-4/6", ProductAttribute.P1, 3, 5, 3, ISOQualify.无);
            this.m_AllOrders[0x38] = new TOrder(Year.第4年, Market.本地, "BD-5/6", ProductAttribute.P1, 5, 4, 3, ISOQualify.无);
            this.m_AllOrders[0x39] = new TOrder(Year.第4年, Market.本地, "BD-6/6", ProductAttribute.P1, 1, 4, 1, ISOQualify.无);
            this.m_AllOrders[0x3a] = new TOrder(Year.第4年, Market.本地, "BD-01/6", ProductAttribute.P2, 3, 9, 2, ISOQualify.无);
            this.m_AllOrders[0x3b] = new TOrder(Year.第4年, Market.本地, "BD-02/6", ProductAttribute.P2, 2, 10, 3, ISOQualify.无);
            this.m_AllOrders[60] = new TOrder(Year.第4年, Market.本地, "BD-03/6", ProductAttribute.P2, 3, 8, 2, ISOQualify.无);
            this.m_AllOrders[0x3d] = new TOrder(Year.第4年, Market.本地, "BD-04/6", ProductAttribute.P2, 2, 9, 2, ISOQualify.无);
            this.m_AllOrders[0x3e] = new TOrder(Year.第4年, Market.本地, "BD-05/6", ProductAttribute.P2, 5, 8, 3, ISOQualify.无);
            this.m_AllOrders[0x3f] = new TOrder(Year.第4年, Market.本地, "BD-06/6", ProductAttribute.P2, 1, 10, 1, ISOQualify.无);
            this.m_AllOrders[0x40] = new TOrder(Year.第4年, Market.本地, "BD-1/3", ProductAttribute.P3, 2, 9, 2, ISOQualify.无);
            this.m_AllOrders[0x41] = new TOrder(Year.第4年, Market.本地, "BD-2/3", ProductAttribute.P3, 4, 8, 3, ISOQualify.无);
            this.m_AllOrders[0x42] = new TOrder(Year.第4年, Market.本地, "BD-3/3", ProductAttribute.P3, 2, 10, 2, ISOQualify.ISO9000);
            this.m_AllOrders[0x43] = new TOrder(Year.第4年, Market.本地, "BD-1/1", ProductAttribute.P4, 2, 9, 2, ISOQualify.无);
            this.m_AllOrders[0x44] = new TOrder(Year.第4年, Market.区域, "QY-1/2", ProductAttribute.P1, 2, 5, 1, ISOQualify.无);
            this.m_AllOrders[0x45] = new TOrder(Year.第4年, Market.区域, "QY-2/2", ProductAttribute.P1, 3, 5, 3, ISOQualify.ISO9000);
            this.m_AllOrders[70] = new TOrder(Year.第4年, Market.区域, "QY-1/3", ProductAttribute.P2, 4, 8, 2, ISOQualify.无);
            this.m_AllOrders[0x47] = new TOrder(Year.第4年, Market.区域, "QY-2/3", ProductAttribute.P2, 2, 8, 1, ISOQualify.无);
            this.m_AllOrders[0x48] = new TOrder(Year.第4年, Market.区域, "QY-3/3", ProductAttribute.P2, 5, 7, 3, ISOQualify.无);
            this.m_AllOrders[0x49] = new TOrder(Year.第4年, Market.区域, "QY-1/4", ProductAttribute.P3, 1, 9, 1, ISOQualify.无);
            this.m_AllOrders[0x4a] = new TOrder(Year.第4年, Market.区域, "QY-2/4", ProductAttribute.P3, 2, 9, 2, ISOQualify.ISO9000);
            this.m_AllOrders[0x4b] = new TOrder(Year.第4年, Market.区域, "QY-3/4", ProductAttribute.P3, 3, 8, 2, ISOQualify.无);
            this.m_AllOrders[0x4c] = new TOrder(Year.第4年, Market.区域, "QY-4/4", ProductAttribute.P3, 2, 9, 3, ISOQualify.无);
            this.m_AllOrders[0x4d] = new TOrder(Year.第4年, Market.区域, "QY-01/2", ProductAttribute.P4, 2, 9, 2, ISOQualify.无);
            this.m_AllOrders[0x4e] = new TOrder(Year.第4年, Market.区域, "QY-02/2", ProductAttribute.P4, 3, 8, 3, ISOQualify.无);
            this.m_AllOrders[0x4f] = new TOrder(Year.第4年, Market.国内, "GN-1/4", ProductAttribute.P1, 5, 4, 1, ISOQualify.无);
            this.m_AllOrders[80] = new TOrder(Year.第4年, Market.国内, "GN-2/4", ProductAttribute.P1, 3, 5, 3, ISOQualify.无);
            this.m_AllOrders[0x51] = new TOrder(Year.第4年, Market.国内, "GN-3/4", ProductAttribute.P1, 2, 5, 3, ISOQualify.无);
            this.m_AllOrders[0x52] = new TOrder(Year.第4年, Market.国内, "GN-4/4", ProductAttribute.P1, 3, 4, 2, ISOQualify.无);
            this.m_AllOrders[0x53] = new TOrder(Year.第4年, Market.国内, "GN-01/4", ProductAttribute.P2, 3, 8, 2, ISOQualify.无);
            this.m_AllOrders[0x54] = new TOrder(Year.第4年, Market.国内, "GN-02/4", ProductAttribute.P2, 1, 9, 1, ISOQualify.无);
            this.m_AllOrders[0x55] = new TOrder(Year.第4年, Market.国内, "GN-03/4", ProductAttribute.P2, 3, 9, 3, ISOQualify.无);
            this.m_AllOrders[0x56] = new TOrder(Year.第4年, Market.国内, "GN-04/4", ProductAttribute.P2, 5, 8, 3, ISOQualify.无);
            this.m_AllOrders[0x57] = new TOrder(Year.第4年, Market.国内, "GN-1/3", ProductAttribute.P3, 2, 9, 1, ISOQualify.无);
            this.m_AllOrders[0x58] = new TOrder(Year.第4年, Market.国内, "GN-2/3", ProductAttribute.P3, 3, 8, 3, ISOQualify.无);
            this.m_AllOrders[0x59] = new TOrder(Year.第4年, Market.国内, "GN-3/3", ProductAttribute.P3, 2, 8, 2, ISOQualify.无);
            this.m_AllOrders[90] = new TOrder(Year.第4年, Market.亚洲, "YZ-1/6", ProductAttribute.P1, 2, 4, 1, ISOQualify.无);
            this.m_AllOrders[0x5b] = new TOrder(Year.第4年, Market.亚洲, "YZ-2/6", ProductAttribute.P1, 2, 4, 2, ISOQualify.无);
            this.m_AllOrders[0x5c] = new TOrder(Year.第4年, Market.亚洲, "YZ-3/6", ProductAttribute.P1, 1, 5, 1, ISOQualify.无);
            this.m_AllOrders[0x5d] = new TOrder(Year.第4年, Market.亚洲, "YZ-4/6", ProductAttribute.P1, 5, 5, 1, ISOQualify.无);
            this.m_AllOrders[0x5e] = new TOrder(Year.第4年, Market.亚洲, "YZ-5/6", ProductAttribute.P1, 4, 5, 1, ISOQualify.无);
            this.m_AllOrders[0x5f] = new TOrder(Year.第4年, Market.亚洲, "YZ-6/6", ProductAttribute.P1, 1, 5, 2, ISOQualify.无);
            this.m_AllOrders[0x60] = new TOrder(Year.第4年, Market.亚洲, "YZ-1/4", ProductAttribute.P2, 5, 6, 2, ISOQualify.无);
            this.m_AllOrders[0x61] = new TOrder(Year.第4年, Market.亚洲, "YZ-2/4", ProductAttribute.P2, 3, 7, 2, ISOQualify.ISO9000);
            this.m_AllOrders[0x62] = new TOrder(Year.第4年, Market.亚洲, "YZ-3/4", ProductAttribute.P2, 2, 7, 1, ISOQualify.无);
            this.m_AllOrders[0x63] = new TOrder(Year.第4年, Market.亚洲, "YZ-4/4", ProductAttribute.P2, 3, 6, 3, ISOQualify.无);
            this.m_AllOrders[100] = new TOrder(Year.第4年, Market.亚洲, "YZ-1/3", ProductAttribute.P3, 2, 9, 1, ISOQualify.无);
            this.m_AllOrders[0x65] = new TOrder(Year.第4年, Market.亚洲, "YZ-2/3", ProductAttribute.P3, 2, 9, 2, ISOQualify.无);
            this.m_AllOrders[0x66] = new TOrder(Year.第4年, Market.亚洲, "YZ-3/3", ProductAttribute.P3, 4, 9, 3, ISOQualify.ISO9000);
            this.m_AllOrders[0x67] = new TOrder(Year.第5年, Market.本地, "BD-1/4", ProductAttribute.P1, 2, 4, 1, ISOQualify.无);
            this.m_AllOrders[0x68] = new TOrder(Year.第5年, Market.本地, "BD-2/4", ProductAttribute.P1, 2, 5, 3, ISOQualify.无);
            this.m_AllOrders[0x69] = new TOrder(Year.第5年, Market.本地, "BD-3/4", ProductAttribute.P1, 3, 4, 2, ISOQualify.无);
            this.m_AllOrders[0x6a] = new TOrder(Year.第5年, Market.本地, "BD-4/4", ProductAttribute.P1, 4, 4, 2, ISOQualify.无);
            this.m_AllOrders[0x6b] = new TOrder(Year.第5年, Market.本地, "BD-1/5", ProductAttribute.P2, 4, 8, 3, ISOQualify.无);
            this.m_AllOrders[0x6c] = new TOrder(Year.第5年, Market.本地, "BD-2/5", ProductAttribute.P2, 3, 8, 2, ISOQualify.无);
            this.m_AllOrders[0x6d] = new TOrder(Year.第5年, Market.本地, "BD-3/5", ProductAttribute.P2, 2, 9, 1, ISOQualify.无);
            this.m_AllOrders[110] = new TOrder(Year.第5年, Market.本地, "BD-4/5", ProductAttribute.P2, 2, 9, 3, ISOQualify.无);
            this.m_AllOrders[0x6f] = new TOrder(Year.第5年, Market.本地, "BD-5/5", ProductAttribute.P2, 4, 8, 2, ISOQualify.无);
            this.m_AllOrders[0x70] = new TOrder(Year.第5年, Market.本地, "BD-01/5", ProductAttribute.P3, 4, 10, 3, ISOQualify.ISO9000);
            this.m_AllOrders[0x71] = new TOrder(Year.第5年, Market.本地, "BD-02/5", ProductAttribute.P3, 3, 8, 4, ISOQualify.无);
            this.m_AllOrders[0x72] = new TOrder(Year.第5年, Market.本地, "BD-03/5", ProductAttribute.P3, 2, 9, 1, ISOQualify.无);
            this.m_AllOrders[0x73] = new TOrder(Year.第5年, Market.本地, "BD-04/5", ProductAttribute.P3, 1, 10, 2, ISOQualify.ISO9000);
            this.m_AllOrders[0x74] = new TOrder(Year.第5年, Market.本地, "BD-05/5", ProductAttribute.P3, 2, 9, 2, ISOQualify.无);
            this.m_AllOrders[0x75] = new TOrder(Year.第5年, Market.本地, "BD-1/2", ProductAttribute.P4, 2, 9, 2, ISOQualify.无);
            this.m_AllOrders[0x76] = new TOrder(Year.第5年, Market.本地, "BD-2/2", ProductAttribute.P4, 2, 10, 3, ISOQualify.ISO9000);
            this.m_AllOrders[0x77] = new TOrder(Year.第5年, Market.区域, "QY-1/3", ProductAttribute.P1, 2, 5, 2, ISOQualify.无);
            this.m_AllOrders[120] = new TOrder(Year.第5年, Market.区域, "QY-2/3", ProductAttribute.P1, 2, 5, 3, ISOQualify.无);
            this.m_AllOrders[0x79] = new TOrder(Year.第5年, Market.区域, "QY-3/3", ProductAttribute.P1, 1, 5, 1, ISOQualify.无);
            this.m_AllOrders[0x7a] = new TOrder(Year.第5年, Market.区域, "QY-01/3", ProductAttribute.P2, 2, 8, 2, ISOQualify.ISO9000);
            this.m_AllOrders[0x7b] = new TOrder(Year.第5年, Market.区域, "QY-02/3", ProductAttribute.P2, 2, 7, 1, ISOQualify.无);
            this.m_AllOrders[0x7c] = new TOrder(Year.第5年, Market.区域, "QY-03/3", ProductAttribute.P2, 4, 6, 3, ISOQualify.无);
            this.m_AllOrders[0x7d] = new TOrder(Year.第5年, Market.区域, "QY-1/4", ProductAttribute.P3, 2, 9, 3, ISOQualify.无);
            this.m_AllOrders[0x7e] = new TOrder(Year.第5年, Market.区域, "QY-2/4", ProductAttribute.P3, 2, 10, 2, ISOQualify.ISO9000);
            this.m_AllOrders[0x7f] = new TOrder(Year.第5年, Market.区域, "QY-3/4", ProductAttribute.P3, 2, 9, 1, ISOQualify.无);
            this.m_AllOrders[0x80] = new TOrder(Year.第5年, Market.区域, "QY-4/4", ProductAttribute.P3, 3, 9, 2, ISOQualify.ISO9000);
            this.m_AllOrders[0x81] = new TOrder(Year.第5年, Market.区域, "QY-001/3", ProductAttribute.P4, 2, 10, 3, ISOQualify.ISO14000);
            this.m_AllOrders[130] = new TOrder(Year.第5年, Market.区域, "QY-002/3", ProductAttribute.P4, 3, 9, 1, ISOQualify.ISO9000);
            this.m_AllOrders[0x83] = new TOrder(Year.第5年, Market.区域, "QY-003/3", ProductAttribute.P4, 1, 10, 2, ISOQualify.ISO9000);
            this.m_AllOrders[0x84] = new TOrder(Year.第5年, Market.国内, "GN-1/4", ProductAttribute.P1, 3, 4, 3, ISOQualify.无);
            this.m_AllOrders[0x85] = new TOrder(Year.第5年, Market.国内, "GN-2/4", ProductAttribute.P1, 2, 5, 2, ISOQualify.无);
            this.m_AllOrders[0x86] = new TOrder(Year.第5年, Market.国内, "GN-3/4", ProductAttribute.P1, 4, 4, 2, ISOQualify.无);
            this.m_AllOrders[0x87] = new TOrder(Year.第5年, Market.国内, "GN-4/4", ProductAttribute.P1, 1, 5, 1, ISOQualify.无);
            this.m_AllOrders[0x88] = new TOrder(Year.第5年, Market.国内, "GN-01/4", ProductAttribute.P2, 2, 7, 2, ISOQualify.无);
            this.m_AllOrders[0x89] = new TOrder(Year.第5年, Market.国内, "GN-02/4", ProductAttribute.P2, 2, 8, 2, ISOQualify.无);
            this.m_AllOrders[0x8a] = new TOrder(Year.第5年, Market.国内, "GN-03/4", ProductAttribute.P2, 3, 7, 2, ISOQualify.无);
            this.m_AllOrders[0x8b] = new TOrder(Year.第5年, Market.国内, "GN-04/4", ProductAttribute.P2, 4, 7, 3, ISOQualify.无);
            this.m_AllOrders[140] = new TOrder(Year.第5年, Market.国内, "GN-001/4", ProductAttribute.P3, 3, 9, 2, ISOQualify.ISO9000);
            this.m_AllOrders[0x8d] = new TOrder(Year.第5年, Market.国内, "GN-002/4", ProductAttribute.P3, 1, 9, 1, ISOQualify.无);
            this.m_AllOrders[0x8e] = new TOrder(Year.第5年, Market.国内, "GN-003/4", ProductAttribute.P3, 2, 8, 2, ISOQualify.无);
            this.m_AllOrders[0x8f] = new TOrder(Year.第5年, Market.国内, "GN-004/4", ProductAttribute.P3, 3, 8, 3, ISOQualify.无);
            this.m_AllOrders[0x90] = new TOrder(Year.第5年, Market.国内, "GN-1/1", ProductAttribute.P4, 2, 9, 2, ISOQualify.无);
            this.m_AllOrders[0x91] = new TOrder(Year.第5年, Market.亚洲, "YZ-1/5", ProductAttribute.P1, 4, 4, 2, ISOQualify.ISO9000);
            this.m_AllOrders[0x92] = new TOrder(Year.第5年, Market.亚洲, "YZ-2/5", ProductAttribute.P1, 1, 4, 1, ISOQualify.无);
            this.m_AllOrders[0x93] = new TOrder(Year.第5年, Market.亚洲, "YZ-3/5", ProductAttribute.P1, 3, 4, 3, ISOQualify.无);
            this.m_AllOrders[0x94] = new TOrder(Year.第5年, Market.亚洲, "YZ-4/5", ProductAttribute.P1, 2, 4, 2, ISOQualify.无);
            this.m_AllOrders[0x95] = new TOrder(Year.第5年, Market.亚洲, "YZ-5/5", ProductAttribute.P1, 2, 3, 2, ISOQualify.无);
            this.m_AllOrders[150] = new TOrder(Year.第5年, Market.亚洲, "YZ-1/4", ProductAttribute.P2, 2, 7, 2, ISOQualify.ISO9000);
            this.m_AllOrders[0x97] = new TOrder(Year.第5年, Market.亚洲, "YZ-2/4", ProductAttribute.P2, 3, 7, 3, ISOQualify.ISO14000);
            this.m_AllOrders[0x98] = new TOrder(Year.第5年, Market.亚洲, "YZ-3/4", ProductAttribute.P2, 2, 6, 1, ISOQualify.无);
            this.m_AllOrders[0x99] = new TOrder(Year.第5年, Market.亚洲, "YZ-4/4", ProductAttribute.P2, 4, 6, 2, ISOQualify.ISO9000);
            this.m_AllOrders[0x9a] = new TOrder(Year.第5年, Market.亚洲, "YZ-1/3", ProductAttribute.P3, 3, 9, 2, ISOQualify.ISO9000);
            this.m_AllOrders[0x9b] = new TOrder(Year.第5年, Market.亚洲, "YZ-2/3", ProductAttribute.P3, 2, 10, 1, ISOQualify.无);
            this.m_AllOrders[0x9c] = new TOrder(Year.第5年, Market.亚洲, "YZ-3/3", ProductAttribute.P3, 4, 9, 3, ISOQualify.无);
            this.m_AllOrders[0x9d] = new TOrder(Year.第5年, Market.亚洲, "YZ-1/2", ProductAttribute.P4, 1, 11, 2, ISOQualify.ISO14000);
            this.m_AllOrders[0x9e] = new TOrder(Year.第5年, Market.亚洲, "YZ-2/2", ProductAttribute.P4, 3, 9, 3, ISOQualify.ISO9000);
            this.m_AllOrders[0x9f] = new TOrder(Year.第5年, Market.国际, "GJ-1/6", ProductAttribute.P1, 2, 6, 3, ISOQualify.无);
            this.m_AllOrders[160] = new TOrder(Year.第5年, Market.国际, "GJ-2/6", ProductAttribute.P1, 6, 5, 2, ISOQualify.无);
            this.m_AllOrders[0xa1] = new TOrder(Year.第5年, Market.国际, "GJ-3/6", ProductAttribute.P1, 4, 6, 2, ISOQualify.无);
            this.m_AllOrders[0xa2] = new TOrder(Year.第5年, Market.国际, "GJ-4/6", ProductAttribute.P1, 2, 6, 3, ISOQualify.无);
            this.m_AllOrders[0xa3] = new TOrder(Year.第5年, Market.国际, "GJ-5/6", ProductAttribute.P1, 3, 5, 2, ISOQualify.无);
            this.m_AllOrders[0xa4] = new TOrder(Year.第5年, Market.国际, "GJ-6/6", ProductAttribute.P1, 1, 6, 1, ISOQualify.无);
            this.m_AllOrders[0xa5] = new TOrder(Year.第5年, Market.国际, "GJ-1/3", ProductAttribute.P2, 2, 7, 3, ISOQualify.ISO9000);
            this.m_AllOrders[0xa6] = new TOrder(Year.第5年, Market.国际, "GJ-2/3", ProductAttribute.P2, 3, 6, 2, ISOQualify.无);
            this.m_AllOrders[0xa7] = new TOrder(Year.第5年, Market.国际, "GJ-3/3", ProductAttribute.P2, 1, 7, 1, ISOQualify.无);
            this.m_AllOrders[0xa8] = new TOrder(Year.第6年, Market.本地, "BD-1/3", ProductAttribute.P1, 2, 4, 2, ISOQualify.无);
            this.m_AllOrders[0xa9] = new TOrder(Year.第6年, Market.本地, "BD-2/3", ProductAttribute.P1, 3, 3, 1, ISOQualify.无);
            this.m_AllOrders[170] = new TOrder(Year.第6年, Market.本地, "BD-3/3", ProductAttribute.P1, 3, 4, 3, ISOQualify.无);
            this.m_AllOrders[0xab] = new TOrder(Year.第6年, Market.本地, "BD-1/5", ProductAttribute.P2, 3, 6, 1, ISOQualify.无);
            this.m_AllOrders[0xac] = new TOrder(Year.第6年, Market.本地, "BD-2/5", ProductAttribute.P2, 2, 6, 4, ISOQualify.无);
            this.m_AllOrders[0xad] = new TOrder(Year.第6年, Market.本地, "BD-3/5", ProductAttribute.P2, 1, 7, 1, ISOQualify.无);
            this.m_AllOrders[0xae] = new TOrder(Year.第6年, Market.本地, "BD-4/5", ProductAttribute.P2, 2, 6, 3, ISOQualify.无);
            this.m_AllOrders[0xaf] = new TOrder(Year.第6年, Market.本地, "BD-5/5", ProductAttribute.P2, 3, 7, 2, ISOQualify.ISO9000);
            this.m_AllOrders[0xb0] = new TOrder(Year.第6年, Market.本地, "BD-01/5", ProductAttribute.P3, 3, 9, 1, ISOQualify.ISO9000);
            this.m_AllOrders[0xb1] = new TOrder(Year.第6年, Market.本地, "BD-02/5", ProductAttribute.P3, 5, 9, 2, ISOQualify.无);
            this.m_AllOrders[0xb2] = new TOrder(Year.第6年, Market.本地, "BD-03/5", ProductAttribute.P3, 4, 9, 3, ISOQualify.ISO9000);
            this.m_AllOrders[0xb3] = new TOrder(Year.第6年, Market.本地, "BD-04/5", ProductAttribute.P3, 2, 9, 2, ISOQualify.无);
            this.m_AllOrders[180] = new TOrder(Year.第6年, Market.本地, "BD-05/5", ProductAttribute.P3, 3, 10, 3, ISOQualify.ISO9000);
            this.m_AllOrders[0xb5] = new TOrder(Year.第6年, Market.本地, "BD-1/4", ProductAttribute.P4, 2, 10, 3, ISOQualify.无);
            this.m_AllOrders[0xb6] = new TOrder(Year.第6年, Market.本地, "BD-2/4", ProductAttribute.P4, 1, 11, 1, ISOQualify.ISO14000);
            this.m_AllOrders[0xb7] = new TOrder(Year.第6年, Market.本地, "BD-3/4", ProductAttribute.P4, 3, 9, 2, ISOQualify.无);
            this.m_AllOrders[0xb8] = new TOrder(Year.第6年, Market.本地, "BD-4/4", ProductAttribute.P4, 2, 9, 2, ISOQualify.无);
            this.m_AllOrders[0xb9] = new TOrder(Year.第6年, Market.区域, "QY-1/3", ProductAttribute.P1, 1, 5, 1, ISOQualify.无);
            this.m_AllOrders[0xba] = new TOrder(Year.第6年, Market.区域, "QY-2/3", ProductAttribute.P1, 2, 4, 2, ISOQualify.无);
            this.m_AllOrders[0xbb] = new TOrder(Year.第6年, Market.区域, "QY-3/3", ProductAttribute.P1, 1, 5, 3, ISOQualify.无);
            this.m_AllOrders[0xbc] = new TOrder(Year.第6年, Market.区域, "QY-01/3", ProductAttribute.P2, 2, 6, 2, ISOQualify.ISO9000);
            this.m_AllOrders[0xbd] = new TOrder(Year.第6年, Market.区域, "QY-02/3", ProductAttribute.P2, 1, 6, 1, ISOQualify.无);
            this.m_AllOrders[190] = new TOrder(Year.第6年, Market.区域, "QY-03/3", ProductAttribute.P2, 3, 6, 3, ISOQualify.ISO9000);
            this.m_AllOrders[0xbf] = new TOrder(Year.第6年, Market.区域, "QY-1/4", ProductAttribute.P3, 3, 9, 2, ISOQualify.无);
            this.m_AllOrders[0xc0] = new TOrder(Year.第6年, Market.区域, "QY-2/4", ProductAttribute.P3, 2, 9, 3, ISOQualify.无);
            this.m_AllOrders[0xc1] = new TOrder(Year.第6年, Market.区域, "QY-3/4", ProductAttribute.P3, 4, 9, 2, ISOQualify.ISO14000);
            this.m_AllOrders[0xc2] = new TOrder(Year.第6年, Market.区域, "QY-4/4", ProductAttribute.P3, 1, 10, 1, ISOQualify.ISO9000);
            this.m_AllOrders[0xc3] = new TOrder(Year.第6年, Market.区域, "QY-01/4", ProductAttribute.P4, 2, 9, 2, ISOQualify.ISO9000);
            this.m_AllOrders[0xc4] = new TOrder(Year.第6年, Market.区域, "QY-02/4", ProductAttribute.P4, 2, 10, 1, ISOQualify.无);
            this.m_AllOrders[0xc5] = new TOrder(Year.第6年, Market.区域, "QY-03/4", ProductAttribute.P4, 4, 9, 3, ISOQualify.ISO9000);
            this.m_AllOrders[0xc6] = new TOrder(Year.第6年, Market.区域, "QY-04/4", ProductAttribute.P4, 1, 11, 2, ISOQualify.ISO14000);
            this.m_AllOrders[0xc7] = new TOrder(Year.第6年, Market.国内, "GN-1/4", ProductAttribute.P1, 2, 4, 1, ISOQualify.无);
            this.m_AllOrders[200] = new TOrder(Year.第6年, Market.国内, "GN-2/4", ProductAttribute.P1, 3, 3, 2, ISOQualify.无);
            this.m_AllOrders[0xc9] = new TOrder(Year.第6年, Market.国内, "GN-3/4", ProductAttribute.P1, 1, 4, 3, ISOQualify.无);
            this.m_AllOrders[0xca] = new TOrder(Year.第6年, Market.国内, "GN-4/4", ProductAttribute.P1, 2, 4, 2, ISOQualify.无);
            this.m_AllOrders[0xcb] = new TOrder(Year.第6年, Market.国内, "GN-01/4", ProductAttribute.P2, 3, 6, 3, ISOQualify.无);
            this.m_AllOrders[0xcc] = new TOrder(Year.第6年, Market.国内, "GN-02/4", ProductAttribute.P2, 3, 6, 2, ISOQualify.无);
            this.m_AllOrders[0xcd] = new TOrder(Year.第6年, Market.国内, "GN-03/4", ProductAttribute.P2, 1, 6, 1, ISOQualify.无);
            this.m_AllOrders[0xce] = new TOrder(Year.第6年, Market.国内, "GN-04/4", ProductAttribute.P2, 2, 6, 2, ISOQualify.无);
            this.m_AllOrders[0xcf] = new TOrder(Year.第6年, Market.国内, "GN-001/4", ProductAttribute.P3, 4, 8, 2, ISOQualify.无);
            this.m_AllOrders[0xd0] = new TOrder(Year.第6年, Market.国内, "GN-002/4", ProductAttribute.P3, 2, 10, 2, ISOQualify.ISO9000);
            this.m_AllOrders[0xd1] = new TOrder(Year.第6年, Market.国内, "GN-003/4", ProductAttribute.P3, 3, 9, 3, ISOQualify.ISO14000);
            this.m_AllOrders[210] = new TOrder(Year.第6年, Market.国内, "GN-004/4", ProductAttribute.P3, 1, 10, 1, ISOQualify.ISO9000);
            this.m_AllOrders[0xd3] = new TOrder(Year.第6年, Market.国内, "GN-1/2", ProductAttribute.P4, 2, 8, 2, ISOQualify.无);
            this.m_AllOrders[0xd4] = new TOrder(Year.第6年, Market.国内, "GN-2/2", ProductAttribute.P4, 3, 10, 2, ISOQualify.ISO9000);
            this.m_AllOrders[0xd5] = new TOrder(Year.第6年, Market.亚洲, "YZ-1/3", ProductAttribute.P1, 3, 3, 1, ISOQualify.无);
            this.m_AllOrders[0xd6] = new TOrder(Year.第6年, Market.亚洲, "YZ-2/3", ProductAttribute.P1, 2, 3, 2, ISOQualify.ISO9000);
            this.m_AllOrders[0xd7] = new TOrder(Year.第6年, Market.亚洲, "YZ-3/3", ProductAttribute.P1, 4, 3, 3, ISOQualify.ISO9000);
            this.m_AllOrders[0xd8] = new TOrder(Year.第6年, Market.亚洲, "YZ-1/4", ProductAttribute.P2, 2, 6, 1, ISOQualify.ISO9000);
            this.m_AllOrders[0xd9] = new TOrder(Year.第6年, Market.亚洲, "YZ-2/4", ProductAttribute.P2, 3, 7, 3, ISOQualify.ISO14000);
            this.m_AllOrders[0xda] = new TOrder(Year.第6年, Market.亚洲, "YZ-3/4", ProductAttribute.P2, 3, 6, 2, ISOQualify.无);
            this.m_AllOrders[0xdb] = new TOrder(Year.第6年, Market.亚洲, "YZ-4/4", ProductAttribute.P2, 1, 6, 2, ISOQualify.无);
            this.m_AllOrders[220] = new TOrder(Year.第6年, Market.亚洲, "YZ-01/4", ProductAttribute.P3, 2, 11, 1, ISOQualify.ISO14000);
            this.m_AllOrders[0xdd] = new TOrder(Year.第6年, Market.亚洲, "YZ-02/4", ProductAttribute.P3, 3, 10, 3, ISOQualify.ISO9000);
            this.m_AllOrders[0xde] = new TOrder(Year.第6年, Market.亚洲, "YZ-03/4", ProductAttribute.P3, 4, 9, 4, ISOQualify.无);
            this.m_AllOrders[0xdf] = new TOrder(Year.第6年, Market.亚洲, "YZ-04/4", ProductAttribute.P3, 2, 10, 2, ISOQualify.ISO9000);
            this.m_AllOrders[0xe0] = new TOrder(Year.第6年, Market.亚洲, "YZ-01/3", ProductAttribute.P4, 2, 10, 1, ISOQualify.ISO9000);
            this.m_AllOrders[0xe1] = new TOrder(Year.第6年, Market.亚洲, "YZ-02/3", ProductAttribute.P4, 1, 11, 2, ISOQualify.无);
            this.m_AllOrders[0xe2] = new TOrder(Year.第6年, Market.亚洲, "YZ-03/3", ProductAttribute.P4, 3, 10, 3, ISOQualify.ISO9000);
            this.m_AllOrders[0xe3] = new TOrder(Year.第6年, Market.国际, "GJ-1/6", ProductAttribute.P1, 3, 6, 3, ISOQualify.无);
            this.m_AllOrders[0xe4] = new TOrder(Year.第6年, Market.国际, "GJ-2/6", ProductAttribute.P1, 2, 6, 2, ISOQualify.无);
            this.m_AllOrders[0xe5] = new TOrder(Year.第6年, Market.国际, "GJ-3/6", ProductAttribute.P1, 5, 6, 3, ISOQualify.无);
            this.m_AllOrders[230] = new TOrder(Year.第6年, Market.国际, "GJ-4/6", ProductAttribute.P1, 3, 6, 2, ISOQualify.无);
            this.m_AllOrders[0xe7] = new TOrder(Year.第6年, Market.国际, "GJ-5/6", ProductAttribute.P1, 2, 6, 1, ISOQualify.无);
            this.m_AllOrders[0xe8] = new TOrder(Year.第6年, Market.国际, "GJ-6/6", ProductAttribute.P1, 1, 6, 1, ISOQualify.无);
            this.m_AllOrders[0xe9] = new TOrder(Year.第6年, Market.国际, "GJ-1/4", ProductAttribute.P2, 1, 8, 2, ISOQualify.无);
            this.m_AllOrders[0xea] = new TOrder(Year.第6年, Market.国际, "GJ-2/4", ProductAttribute.P2, 2, 6, 2, ISOQualify.无);
            this.m_AllOrders[0xeb] = new TOrder(Year.第6年, Market.国际, "GJ-3/4", ProductAttribute.P2, 4, 7, 3, ISOQualify.无);
            this.m_AllOrders[0xec] = new TOrder(Year.第6年, Market.国际, "GJ-4/4", ProductAttribute.P2, 2, 7, 1, ISOQualify.ISO9000);
            this.m_AllOrders[0xed] = new TOrder(Year.第6年, Market.国际, "GJ-1/2", ProductAttribute.P3, 2, 8, 3, ISOQualify.无);
            this.m_AllOrders[0xee] = new TOrder(Year.第6年, Market.国际, "GJ-2/2", ProductAttribute.P3, 2, 8, 2, ISOQualify.无);
        }

        public TOrder[] GetOrders(Year year, Market market)
        {
            int num = 0;
            for (int i = 0; i < this.m_AllOrders.Length; i++)
            {
                if ((this.m_AllOrders[i].Year == year) && (this.m_AllOrders[i].Market == market))
                {
                    num++;
                }
            }
            if (num == 0)
            {
                throw new Exception(year.ToString() + market + "市场没有开放！");
            }
            TOrder[] orderArray = new TOrder[num];
            int index = 0;
            for (int j = 0; j < this.m_AllOrders.Length; j++)
            {
                if ((this.m_AllOrders[j].Year == year) && (this.m_AllOrders[j].Market == market))
                {
                    orderArray[index] = this.m_AllOrders[j];
                    index++;
                }
            }
            return orderArray;
        }
    }
}

