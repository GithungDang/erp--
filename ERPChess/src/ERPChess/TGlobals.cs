namespace ERPChess
{
    using BusinessTier;
    using DataAccessTier;
    using DataSet;
    using System;
    using System.Windows.Forms;

    public class TGlobals
    {
        public static Form logInForm;
        public static TActor currentActor;
        public static TComputerPlayer[] computerPlayers = new TComputerPlayer[5];
        public static IOrderModel orderModel;
        public static IComputerPlayerModel computerPlayerModel;
        public static string databaseName = @".\ERPScore.erp";
        public static string databasePassword = "ERPChess";
        public static string strKey = "renHong463225047@qq.com";
        public static string ApplicationText = "ERP沙盘模拟人机对抗系统创业版V1.1        注册联系：840599405@qq.com";
        public static string UserID;
        public static string RegistrationID;
        public static TDbAccessControl dbControl;
        public static bool IsRegistration = false;
        public static bool step2 = false;
        public static bool step4 = false;
        public static bool step5 = false;
        public static bool step14 = false;
        public static bool step15 = false;
        public static bool step50 = false;
        public static bool step51 = false;
        public static bool step52 = false;
    }
}

