namespace ERPChess
{
    using System;
    using System.Windows.Forms;

    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            TGlobals.logInForm = new frmLogInControl();
            Application.Run(TGlobals.logInForm);
        }
    }
}

