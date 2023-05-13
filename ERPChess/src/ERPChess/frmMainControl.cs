namespace ERPChess
{
    using BusinessTier;
    using DataSet;
    using ERPChess.Properties;
    using RibbonStyle;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmMainControl : Form
    {
        private IContainer components;
        private Panel panel1;
        private Panel panel4;
        private TabPageSwitcher tabPageSwitcher1;
        private TabStripPage tabStripPage1;
        private TabStripPage tabStripPage3;
        private TabStripPage tabStripPage2;
        private TabStrip tabStrip1;
        private Tab tab1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel5;
        private Panel panel6;
        private Panel panel7;
        private Label label36;
        private Label label35;
        private Label label34;
        private Label label33;
        private Label labelGZ;
        private Label labelXSCZR;
        private CheckBox chckBox058;
        private CheckBox chckBox057;
        private Label labelJTZJ;
        private Label labelZFZJ;
        private CheckBox chckBox056;
        private CheckBox chckBox055;
        private Label labelZFSBXLF;
        private CheckBox chckBox054;
        private Label labelGXCQDK;
        private CheckBox chckBox053;
        private Label labelZFXZGLFY;
        private CheckBox chckBox016;
        private CheckBox chckBox052;
        private CheckBox chckBox040;
        private CheckBox chckBox028;
        private Label labelCPYFTZ;
        private CheckBox chckBox015;
        private CheckBox chckBox051;
        private CheckBox chckBox039;
        private CheckBox chckBox027;
        private Label labelJHGKH;
        private CheckBox chckBox014;
        private CheckBox chckBox050;
        private CheckBox chckBox038;
        private CheckBox chckBox026;
        private Label labelGXYSK;
        private CheckBox chckBox013;
        private CheckBox chckBox049;
        private CheckBox chckBox037;
        private CheckBox chckBox025;
        private Label labelKSXDSC;
        private CheckBox chckBox012;
        private CheckBox chckBox048;
        private CheckBox chckBox036;
        private CheckBox chckBox024;
        private CheckBox chckBox010;
        private CheckBox chckBox046;
        private CheckBox chckBox034;
        private CheckBox chckBox022;
        private Label labelTZXSCX;
        private CheckBox chckBox009;
        private CheckBox chckBox045;
        private CheckBox chckBox033;
        private CheckBox chckBox021;
        private Label labelGXSC;
        private CheckBox chckBox008;
        private CheckBox chckBox044;
        private CheckBox chckBox032;
        private CheckBox chckBox020;
        private Label labelXYLDD;
        private CheckBox chckBox007;
        private CheckBox chckBox043;
        private CheckBox chckBox031;
        private CheckBox chckBox019;
        private Label labelYCLRK;
        private CheckBox chckBox006;
        private CheckBox chckBox042;
        private CheckBox chckBox030;
        private CheckBox chckBox018;
        private Label labelGXDQDK;
        private Label labelZFYFS;
        private Label labelZDXNDJH;
        private Label labelCJDHH;
        private CheckBox chckBox004;
        private CheckBox chckBox003;
        private CheckBox chckBox002;
        private CheckBox chckBox001;
        private Label labelXNNDGHHY;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label labelJD1;
        private Panel panel8;
        private GroupBox groupBox5;
        private Label label18;
        private Label labelCompany;
        private Label label31;
        private Label labelRunningTime;
        private GroupBox groupBox4;
        private Label labelP4Capacity;
        private Label labelP3Capacity;
        private Label labelP2Capacity;
        private Label labelP1Capacity;
        private GroupBox groupBox3;
        private Label labelCertified14000;
        private Label labelCertified9000;
        private GroupBox groupBox2;
        private Label labelEnterInternationalMarket;
        private Label labelEnterAsiaMarket;
        private Label labelEnterDomesticMarket;
        private Label labelEnterRegionalMarket;
        private Label labelEnterLocalMarket;
        private GroupBox groupBox1;
        private Label labelLoanSharking;
        private Label label5;
        private Label labelReceivableAccounts;
        private Label labelShortTermLoans;
        private Label labelLongTermLoans;
        private Label label51;
        private Label label49;
        private Label label48;
        private Label labelCurrentCash;
        private Label label20;
        private TabPanel tabPanel1;
        private RibbonButton ribbonButton1;
        private RibbonButton ribbonButton3;
        private RibbonButton ribbonButton4;
        private TabPanel tabPanel3;
        private TabPanel tabPanel2;
        private RibbonButton ribbonButton5;
        private RibbonButton ribbonButton6;
        private RibbonButton ribbonButton7;
        private Label label6;
        private Label labelActor;
        private TabPanel tabPanel4;
        private RibbonButton ribbonButtonMCCF;
        private RibbonButton ribbonButtonYS;
        private RibbonButton ribbonButtonMRCF;
        private TabPanel tabPanel5;
        private RibbonButton ribbonButton10;
        private RibbonButton ribbonButton11;
        private RibbonButton ribbonButton12;
        private RibbonButton ribbonButton13;
        private CheckBox chckBox011;
        private CheckBox chckBox047;
        private CheckBox chckBox035;
        private CheckBox chckBox023;
        private Label labelBMSCX;
        private Label labelTSDK;
        private CheckBox chckBox005;
        private CheckBox chckBox041;
        private CheckBox chckBox029;
        private CheckBox chckBox017;
        private RibbonButton ribbonButton2;
        private CheckBox[] chkBoxArry;

        public frmMainControl()
        {
            this.InitializeComponent();
        }

        private bool CheckBYZQY()
        {
            bool flag;
            for (int i = 0; i < TGlobals.computerPlayers.Length; i++)
            {
                if (!TGlobals.computerPlayers[i].IsLiving(TGlobals.currentActor.RunningYear) && !TGlobals.computerPlayers[i].IsBankruptcyNotice)
                {
                    TGlobals.computerPlayers[i].IsBankruptcyNotice = true;
                    MessageBox.Show(TGlobals.computerPlayers[i].ComputerPlayerName + "已经破产,特此公告!", "特别提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            if (TGlobals.currentActor.CurrBusinessConditions.BalanceSheet.OwnerRight >= 0)
            {
                flag = false;
            }
            else
            {
                new frmOver { 
                    label1 = { Text = "非常遗憾！权益为负判断为失败！" },
                    label2 = { Text = "没关系的，请继续努力！" }
                }.ShowDialog();
                this.ribbonButtonYS.Enabled = false;
                this.ribbonButtonMCCF.Enabled = false;
                this.ribbonButtonMRCF.Enabled = false;
                flag = true;
            }
            return flag;
        }

        private bool CheckXJ()
        {
            bool flag;
            if (TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.CurrentCash >= 0)
            {
                flag = false;
            }
            else
            {
                new frmOver { 
                    label1 = { Text = "非常遗憾！现金为负判断为失败！" },
                    label2 = { Text = "没关系的，请继续努力！" }
                }.ShowDialog();
                this.ribbonButtonYS.Enabled = false;
                this.ribbonButtonMCCF.Enabled = false;
                this.ribbonButtonMRCF.Enabled = false;
                flag = true;
            }
            return flag;
        }

        private void chkBox_Click(object sender, EventArgs e)
        {
            int index = Convert.ToInt16(((CheckBox) sender).Tag);
            switch (index)
            {
                case 1:
                {
                    frmXNNGHHY mxnnghhy = new frmXNNGHHY {
                        Text = $"步骤{index.ToString()}:{this.labelXNNDGHHY.Text}({TGlobals.currentActor.RunningYear.ToString()})"
                    };
                    if (DialogResult.OK != mxnnghhy.ShowDialog())
                    {
                        this.chkBoxArry[index].Checked = false;
                        return;
                    }
                    this.chkBoxArry[index].Enabled = false;
                    this.chkBoxArry[index + 1].Enabled = true;
                    return;
                }
                case 2:
                {
                    this.XJTX();
                    frmCJDHH mcjdhh = new frmCJDHH {
                        Text = $"步骤{index.ToString()}:{this.labelCJDHH.Text}({TGlobals.currentActor.RunningYear.ToString()})"
                    };
                    if (DialogResult.OK != mcjdhh.ShowDialog())
                    {
                        this.chkBoxArry[index].Checked = false;
                        return;
                    }
                    this.InitActorInfor();
                    if (TGlobals.currentActor.CurrBusinessConditions.ComprehensiveCostSheet.Advertisement != 0)
                    {
                        TGlobals.step2 = true;
                    }
                    this.chkBoxArry[index].Enabled = false;
                    this.chkBoxArry[index + 1].Enabled = true;
                    if (!this.CheckXJ())
                    {
                        break;
                    }
                    this.chkBoxArry[index + 1].Enabled = false;
                    return;
                }
                case 3:
                {
                    frmZDXNDJH mzdxndjh = new frmZDXNDJH {
                        Text = $"步骤{index.ToString()}:{this.labelZDXNDJH.Text}({TGlobals.currentActor.RunningYear.ToString()})"
                    };
                    if (DialogResult.OK != mzdxndjh.ShowDialog())
                    {
                        this.chkBoxArry[index].Checked = false;
                        return;
                    }
                    this.chkBoxArry[index].Enabled = false;
                    this.chkBoxArry[index + 1].Enabled = true;
                    return;
                }
                case 4:
                {
                    this.XJTX();
                    frmZFYFS mzfyfs = new frmZFYFS {
                        Text = $"步骤{index.ToString()}:{this.labelZFYFS.Text}({TGlobals.currentActor.RunningYear.ToString()})"
                    };
                    if (DialogResult.OK != mzfyfs.ShowDialog())
                    {
                        this.chkBoxArry[index].Checked = false;
                        return;
                    }
                    this.InitActorInfor();
                    if (TGlobals.currentActor.CurrBusinessConditions.BalanceSheet.Taxes != 0)
                    {
                        TGlobals.step4 = true;
                    }
                    this.chkBoxArry[index].Enabled = false;
                    this.chkBoxArry[index + 1].Enabled = true;
                    if (!this.CheckXJ())
                    {
                        break;
                    }
                    this.chkBoxArry[index + 1].Enabled = false;
                    return;
                }
                case 5:
                case 0x11:
                case 0x1d:
                case 0x29:
                {
                    this.XJTX();
                    frmLoansharking loansharking = new frmLoansharking {
                        Text = $"步骤{index.ToString()}:{this.labelTSDK.Text}({TGlobals.currentActor.RunningTime})"
                    };
                    if (DialogResult.OK != loansharking.ShowDialog())
                    {
                        this.chkBoxArry[index].Checked = false;
                        return;
                    }
                    this.InitActorInfor();
                    this.chkBoxArry[index].Enabled = false;
                    this.chkBoxArry[index + 1].Enabled = true;
                    if (!this.CheckXJ())
                    {
                        break;
                    }
                    this.chkBoxArry[index + 1].Enabled = false;
                    return;
                }
                case 6:
                case 0x12:
                case 30:
                case 0x2a:
                {
                    this.XJTX();
                    frmGXDQDK mgxdqdk = new frmGXDQDK {
                        Text = $"步骤{index.ToString()}:{this.labelGXDQDK.Text}({TGlobals.currentActor.RunningTime})"
                    };
                    if (DialogResult.OK != mgxdqdk.ShowDialog())
                    {
                        this.chkBoxArry[index].Checked = false;
                        return;
                    }
                    this.InitActorInfor();
                    if (TGlobals.currentActor.CurrBusinessConditions.FinancialSheet.Interest != 0)
                    {
                        TGlobals.step5 = true;
                    }
                    this.chkBoxArry[index].Enabled = false;
                    this.chkBoxArry[index + 1].Enabled = true;
                    if (!this.CheckXJ())
                    {
                        break;
                    }
                    this.chkBoxArry[index + 1].Enabled = false;
                    return;
                }
                case 7:
                case 0x13:
                case 0x1f:
                case 0x2b:
                {
                    this.XJTX();
                    frmYCLRK myclrk = new frmYCLRK {
                        Text = $"步骤{index.ToString()}:{this.labelYCLRK.Text}({TGlobals.currentActor.RunningTime})"
                    };
                    if (DialogResult.OK != myclrk.ShowDialog())
                    {
                        this.chkBoxArry[index].Checked = false;
                        return;
                    }
                    this.InitActorInfor();
                    this.chkBoxArry[index].Enabled = false;
                    this.chkBoxArry[index + 1].Enabled = true;
                    if (!this.CheckXJ())
                    {
                        break;
                    }
                    this.chkBoxArry[index + 1].Enabled = false;
                    return;
                }
                case 8:
                case 20:
                case 0x20:
                case 0x2c:
                {
                    frmXYLDD mxyldd = new frmXYLDD {
                        Text = $"步骤{index.ToString()}:{this.labelXYLDD.Text}({TGlobals.currentActor.RunningTime})"
                    };
                    if (DialogResult.OK != mxyldd.ShowDialog())
                    {
                        this.chkBoxArry[index].Checked = false;
                        return;
                    }
                    this.InitActorInfor();
                    this.chkBoxArry[index].Enabled = false;
                    this.chkBoxArry[index + 1].Enabled = true;
                    return;
                }
                case 9:
                case 0x15:
                case 0x21:
                case 0x2d:
                {
                    frmGXSC mgxsc = new frmGXSC {
                        Text = $"步骤{index.ToString()}:{this.labelGXSC.Text}({TGlobals.currentActor.RunningTime})"
                    };
                    if (DialogResult.OK != mgxsc.ShowDialog())
                    {
                        this.chkBoxArry[index].Checked = false;
                        return;
                    }
                    this.chkBoxArry[index].Enabled = false;
                    this.chkBoxArry[index + 1].Enabled = true;
                    return;
                }
                case 10:
                case 0x16:
                case 0x22:
                case 0x2e:
                {
                    frmBMSCX mbmscx = new frmBMSCX {
                        Text = $"步骤{index.ToString()}:{this.labelBMSCX.Text}({TGlobals.currentActor.RunningTime})"
                    };
                    if (DialogResult.OK != mbmscx.ShowDialog())
                    {
                        this.chkBoxArry[index].Checked = false;
                        return;
                    }
                    this.InitActorInfor();
                    this.chkBoxArry[index].Enabled = false;
                    this.chkBoxArry[index + 1].Enabled = true;
                    return;
                }
                case 11:
                case 0x17:
                case 0x23:
                case 0x2f:
                {
                    this.XJTX();
                    frmTZXSCX mtzxscx = new frmTZXSCX {
                        Text = $"步骤{index.ToString()}:{this.labelTZXSCX.Text}({TGlobals.currentActor.RunningTime})"
                    };
                    if (DialogResult.OK != mtzxscx.ShowDialog())
                    {
                        this.chkBoxArry[index].Checked = false;
                        return;
                    }
                    this.InitActorInfor();
                    this.chkBoxArry[index].Enabled = false;
                    this.chkBoxArry[index + 1].Enabled = true;
                    if (!this.CheckXJ())
                    {
                        break;
                    }
                    this.chkBoxArry[index + 1].Enabled = false;
                    return;
                }
                case 12:
                case 0x18:
                case 0x24:
                case 0x30:
                {
                    this.XJTX();
                    frmKSXDSC mksxdsc = new frmKSXDSC {
                        Text = $"步骤{index.ToString()}:{this.labelKSXDSC.Text}({TGlobals.currentActor.RunningTime})"
                    };
                    if (DialogResult.OK != mksxdsc.ShowDialog())
                    {
                        this.chkBoxArry[index].Checked = false;
                        return;
                    }
                    this.InitActorInfor();
                    this.chkBoxArry[index].Enabled = false;
                    this.chkBoxArry[index + 1].Enabled = true;
                    if (!this.CheckXJ())
                    {
                        break;
                    }
                    this.chkBoxArry[index + 1].Enabled = false;
                    return;
                }
                case 13:
                case 0x19:
                case 0x25:
                case 0x31:
                {
                    frmGXYSK mgxysk = new frmGXYSK {
                        Text = $"步骤{index.ToString()}:{this.labelGXYSK.Text}({TGlobals.currentActor.RunningTime})"
                    };
                    if (DialogResult.OK != mgxysk.ShowDialog())
                    {
                        this.chkBoxArry[index].Checked = false;
                        return;
                    }
                    this.InitActorInfor();
                    this.chkBoxArry[index].Enabled = false;
                    this.chkBoxArry[index + 1].Enabled = true;
                    return;
                }
                case 14:
                case 0x1a:
                case 0x26:
                case 50:
                {
                    frmJHGKH mjhgkh = new frmJHGKH {
                        Text = $"步骤{index.ToString()}:{this.labelJHGKH.Text}({TGlobals.currentActor.RunningTime})"
                    };
                    if (DialogResult.OK != mjhgkh.ShowDialog())
                    {
                        this.chkBoxArry[index].Checked = false;
                        return;
                    }
                    this.InitActorInfor();
                    this.chkBoxArry[index].Enabled = false;
                    this.chkBoxArry[index + 1].Enabled = true;
                    return;
                }
                case 15:
                case 0x1b:
                case 0x27:
                case 0x33:
                {
                    this.XJTX();
                    frmCPYFTZ mcpyftz = new frmCPYFTZ {
                        Text = $"步骤{index.ToString()}:{this.labelCPYFTZ.Text}({TGlobals.currentActor.RunningTime})"
                    };
                    if (DialogResult.OK != mcpyftz.ShowDialog())
                    {
                        this.chkBoxArry[index].Checked = false;
                        return;
                    }
                    this.InitActorInfor();
                    if (TGlobals.currentActor.CurrBusinessConditions.ComprehensiveCostSheet.ProductDevelopment != 0)
                    {
                        TGlobals.step14 = true;
                    }
                    this.chkBoxArry[index].Enabled = false;
                    this.chkBoxArry[index + 1].Enabled = true;
                    if (!this.CheckXJ())
                    {
                        break;
                    }
                    this.chkBoxArry[index + 1].Enabled = false;
                    return;
                }
                case 0x10:
                case 0x1c:
                case 40:
                case 0x34:
                {
                    this.XJTX();
                    frmZFXZGLFY mzfxzglfy = new frmZFXZGLFY {
                        Text = $"步骤{index.ToString()}:{this.labelZFXZGLFY.Text}({TGlobals.currentActor.RunningTime})"
                    };
                    if (DialogResult.OK != mzfxzglfy.ShowDialog())
                    {
                        this.chkBoxArry[index].Checked = false;
                        return;
                    }
                    this.InitActorInfor();
                    if (TGlobals.currentActor.CurrBusinessConditions.ComprehensiveCostSheet.Administration != 0)
                    {
                        TGlobals.step15 = true;
                    }
                    this.chkBoxArry[index].Enabled = false;
                    this.chkBoxArry[index + 1].Enabled = true;
                    if (this.CheckXJ())
                    {
                        this.chkBoxArry[index + 1].Enabled = false;
                    }
                    int num2 = index;
                    if (num2 == 0x10)
                    {
                        TGlobals.currentActor.RunningQuarter = Quarter.第2季;
                        return;
                    }
                    if (num2 == 0x1c)
                    {
                        TGlobals.currentActor.RunningQuarter = Quarter.第3季;
                        return;
                    }
                    if (num2 != 40)
                    {
                        break;
                    }
                    TGlobals.currentActor.RunningQuarter = Quarter.第4季;
                    return;
                }
                case 0x35:
                {
                    this.XJTX();
                    frmGXCQDK mgxcqdk = new frmGXCQDK {
                        Text = $"步骤{index.ToString()}:{this.labelGXCQDK.Text}({TGlobals.currentActor.RunningYear.ToString()})"
                    };
                    if (DialogResult.OK != mgxcqdk.ShowDialog())
                    {
                        this.chkBoxArry[index].Checked = false;
                        return;
                    }
                    this.InitActorInfor();
                    if (TGlobals.currentActor.CurrBusinessConditions.FinancialSheet.Interest != 0)
                    {
                        TGlobals.step5 = true;
                    }
                    this.chkBoxArry[index].Enabled = false;
                    this.chkBoxArry[index + 1].Enabled = true;
                    if (!this.CheckXJ())
                    {
                        break;
                    }
                    this.chkBoxArry[index + 1].Enabled = false;
                    return;
                }
                case 0x36:
                {
                    this.XJTX();
                    frmZFSBXLF mzfsbxlf = new frmZFSBXLF {
                        Text = $"步骤{index.ToString()}:{this.labelZFSBXLF.Text}({TGlobals.currentActor.RunningYear.ToString()})"
                    };
                    if (DialogResult.OK != mzfsbxlf.ShowDialog())
                    {
                        this.chkBoxArry[index].Checked = false;
                        return;
                    }
                    this.InitActorInfor();
                    if (TGlobals.currentActor.CurrBusinessConditions.ComprehensiveCostSheet.EquipmentMaintenance != 0)
                    {
                        TGlobals.step50 = true;
                    }
                    this.chkBoxArry[index].Enabled = false;
                    this.chkBoxArry[index + 1].Enabled = true;
                    if (!this.CheckXJ())
                    {
                        break;
                    }
                    this.chkBoxArry[index + 1].Enabled = false;
                    return;
                }
                case 0x37:
                {
                    this.XJTX();
                    frmZFZJ mzfzj = new frmZFZJ {
                        Text = $"步骤{index.ToString()}:{this.labelZFZJ.Text}({TGlobals.currentActor.RunningYear.ToString()})"
                    };
                    if (DialogResult.OK != mzfzj.ShowDialog())
                    {
                        this.chkBoxArry[index].Checked = false;
                        return;
                    }
                    this.InitActorInfor();
                    if (TGlobals.currentActor.CurrBusinessConditions.ComprehensiveCostSheet.RentPlant != 0)
                    {
                        TGlobals.step51 = true;
                    }
                    this.chkBoxArry[index].Enabled = false;
                    this.chkBoxArry[index + 1].Enabled = true;
                    if (!this.CheckXJ())
                    {
                        break;
                    }
                    this.chkBoxArry[index + 1].Enabled = false;
                    return;
                }
                case 0x38:
                {
                    this.XJTX();
                    frmJTZJ mjtzj = new frmJTZJ {
                        Text = $"步骤{index.ToString()}:{this.labelJTZJ.Text}({TGlobals.currentActor.RunningYear.ToString()})"
                    };
                    if (DialogResult.OK != mjtzj.ShowDialog())
                    {
                        this.chkBoxArry[index].Checked = false;
                        return;
                    }
                    this.InitActorInfor();
                    if (TGlobals.currentActor.CurrBusinessConditions.FinancialSheet.Depreciation != 0)
                    {
                        TGlobals.step52 = true;
                    }
                    this.chkBoxArry[index].Enabled = false;
                    this.chkBoxArry[index + 1].Enabled = true;
                    if (!this.CheckXJ())
                    {
                        break;
                    }
                    this.chkBoxArry[index + 1].Enabled = false;
                    return;
                }
                case 0x39:
                {
                    this.XJTX();
                    frmXSCZR mxsczr = new frmXSCZR {
                        Text = $"步骤{index.ToString()}:{this.labelXSCZR.Text}({TGlobals.currentActor.RunningYear.ToString()})"
                    };
                    if (DialogResult.OK != mxsczr.ShowDialog())
                    {
                        this.chkBoxArry[index].Checked = false;
                        return;
                    }
                    this.InitActorInfor();
                    this.chkBoxArry[index].Enabled = false;
                    this.chkBoxArry[index + 1].Enabled = true;
                    if (!this.CheckXJ())
                    {
                        break;
                    }
                    this.chkBoxArry[index + 1].Enabled = false;
                    return;
                }
                case 0x3a:
                {
                    frmGZ mgz = new frmGZ {
                        Text = $"步骤{index.ToString()}:{this.labelGZ.Text}({TGlobals.currentActor.RunningYear.ToString()})"
                    };
                    if (DialogResult.OK != mgz.ShowDialog())
                    {
                        this.chkBoxArry[index].Checked = false;
                        break;
                    }
                    if (TGlobals.currentActor.RunningYear == Year.第1年)
                    {
                        TGlobals.currentActor.RunningYear = Year.第2年;
                        TGlobals.currentActor.RunningQuarter = Quarter.第1季;
                        int num3 = index;
                        while (true)
                        {
                            if (num3 <= 0)
                            {
                                this.chkBoxArry[index].Enabled = false;
                                this.chkBoxArry[1].Enabled = true;
                                break;
                            }
                            this.chkBoxArry[num3].Checked = false;
                            num3--;
                        }
                    }
                    else if (TGlobals.currentActor.RunningYear == Year.第2年)
                    {
                        TGlobals.currentActor.RunningYear = Year.第3年;
                        TGlobals.currentActor.RunningQuarter = Quarter.第1季;
                        int num4 = index;
                        while (true)
                        {
                            if (num4 <= 0)
                            {
                                this.chkBoxArry[index].Enabled = false;
                                this.chkBoxArry[1].Enabled = true;
                                break;
                            }
                            this.chkBoxArry[num4].Checked = false;
                            num4--;
                        }
                    }
                    else if (TGlobals.currentActor.RunningYear == Year.第3年)
                    {
                        TGlobals.currentActor.RunningYear = Year.第4年;
                        TGlobals.currentActor.RunningQuarter = Quarter.第1季;
                        int num5 = index;
                        while (true)
                        {
                            if (num5 <= 0)
                            {
                                this.chkBoxArry[index].Enabled = false;
                                this.chkBoxArry[1].Enabled = true;
                                break;
                            }
                            this.chkBoxArry[num5].Checked = false;
                            num5--;
                        }
                    }
                    else if (TGlobals.currentActor.RunningYear == Year.第4年)
                    {
                        TGlobals.currentActor.RunningYear = Year.第5年;
                        TGlobals.currentActor.RunningQuarter = Quarter.第1季;
                        int num6 = index;
                        while (true)
                        {
                            if (num6 <= 0)
                            {
                                this.chkBoxArry[index].Enabled = false;
                                this.chkBoxArry[1].Enabled = true;
                                break;
                            }
                            this.chkBoxArry[num6].Checked = false;
                            num6--;
                        }
                    }
                    else if (TGlobals.currentActor.RunningYear == Year.第5年)
                    {
                        TGlobals.currentActor.RunningYear = Year.第6年;
                        TGlobals.currentActor.RunningQuarter = Quarter.第1季;
                        int num7 = index;
                        while (true)
                        {
                            if (num7 <= 0)
                            {
                                this.chkBoxArry[index].Enabled = false;
                                this.chkBoxArry[1].Enabled = true;
                                break;
                            }
                            this.chkBoxArry[num7].Checked = false;
                            num7--;
                        }
                    }
                    else if (TGlobals.currentActor.RunningYear == Year.第6年)
                    {
                        TGlobals.currentActor.RunningYear = Year.第7年;
                        TGlobals.currentActor.RunningQuarter = Quarter.第1季;
                        this.chkBoxArry[index].Enabled = false;
                        new frmSuccess().ShowDialog();
                        double finalScore = TGlobals.currentActor.GetFinalScore();
                        DateTime now = DateTime.Now;
                        TScoreRecord sr = new TScoreRecord(TGlobals.currentActor.ActorName, finalScore, now);
                        TGlobals.dbControl.UpdateHeroList(sr, "记录");
                        for (int i = 0; i < TGlobals.computerPlayers.Length; i++)
                        {
                            string computerPlayerName = TGlobals.computerPlayers[i].ComputerPlayerName;
                            double maxScore = Convert.ToDouble(TGlobals.computerPlayers[i].GetScore(Year.第7年));
                            TScoreRecord record2 = new TScoreRecord(computerPlayerName, maxScore, now);
                            TGlobals.dbControl.UpdateHeroList(record2, "记录");
                        }
                    }
                    this.InitActorInfor();
                    if (this.CheckBYZQY())
                    {
                        this.chkBoxArry[index].Enabled = false;
                        this.chkBoxArry[1].Enabled = false;
                    }
                    if (!TGlobals.IsRegistration)
                    {
                        if (new frmRegistration().ShowDialog() != DialogResult.OK)
                        {
                            this.chkBoxArry[index].Enabled = false;
                            this.chkBoxArry[1].Enabled = false;
                        }
                        else
                        {
                            this.Text = TGlobals.ApplicationText;
                            this.chkBoxArry[index].Enabled = false;
                            this.chkBoxArry[1].Enabled = true;
                        }
                    }
                    TGlobals.step2 = false;
                    TGlobals.step4 = false;
                    TGlobals.step5 = false;
                    TGlobals.step14 = false;
                    TGlobals.step15 = false;
                    TGlobals.step50 = false;
                    TGlobals.step51 = false;
                    TGlobals.step52 = false;
                    return;
                }
                default:
                    return;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void frmMainControl_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("确定要退出系统！", "系统消息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                TGlobals.logInForm.Close();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void frmMainControl_Load(object sender, EventArgs e)
        {
            this.InitTaskList();
            this.SetStyle("Canela");
            this.InitGlobal();
            this.InitActorInfor();
        }

        private void InitActorInfor()
        {
            TOperatingSheet operatingSheet = TGlobals.currentActor.CurrBusinessConditions.OperatingSheet;
            this.labelCompany.Text = TGlobals.currentActor.CompanyName;
            this.labelActor.Text = TGlobals.currentActor.ActorName;
            this.labelRunningTime.Text = TGlobals.currentActor.RunningTime;
            this.labelCurrentCash.Text = operatingSheet.CurrentCash + "M";
            this.labelLongTermLoans.Text = operatingSheet.LongTermLoans + "M";
            this.labelShortTermLoans.Text = operatingSheet.ShortTermLoans + "M";
            this.labelReceivableAccounts.Text = operatingSheet.ReceivableAccounts + "M";
            this.labelLoanSharking.Text = operatingSheet.LoanSharking + "M";
            this.labelP1Capacity.Enabled = TGlobals.currentActor.HasP1Capacity;
            this.labelP2Capacity.Enabled = TGlobals.currentActor.HasP2Capacity;
            this.labelP3Capacity.Enabled = TGlobals.currentActor.HasP3Capacity;
            this.labelP4Capacity.Enabled = TGlobals.currentActor.HasP4Capacity;
            this.labelEnterLocalMarket.Enabled = TGlobals.currentActor.IsEnterLocalMarket;
            this.labelEnterRegionalMarket.Enabled = TGlobals.currentActor.IsEnterRegionalMarket;
            this.labelEnterDomesticMarket.Enabled = TGlobals.currentActor.IsEnterDomesticMarket;
            this.labelEnterAsiaMarket.Enabled = TGlobals.currentActor.IsEnterAsiaMarket;
            this.labelEnterInternationalMarket.Enabled = TGlobals.currentActor.IsEnterInternationalMarket;
            this.labelCertified9000.Enabled = TGlobals.currentActor.IsCertified9000;
            if (TGlobals.currentActor.IsCertified14000)
            {
                this.labelCertified14000.Enabled = true;
            }
            else
            {
                this.labelCertified14000.Enabled = false;
            }
        }

        private void InitGlobal()
        {
            Random random = new Random();
            switch (random.Next(1, 6))
            {
                case 1:
                    TGlobals.orderModel = new TFirstOrderModel();
                    break;

                case 2:
                    TGlobals.orderModel = new TSecondOrderModel();
                    break;

                case 3:
                    TGlobals.orderModel = new TThirdOrderModel();
                    break;

                case 4:
                    TGlobals.orderModel = new TFourthOrderModel();
                    break;

                case 5:
                    TGlobals.orderModel = new TFifthOrderModel();
                    break;

                default:
                    break;
            }
            TGlobals.orderModel.CreateOrderModel();
            switch (random.Next(1, 0x12))
            {
                case 1:
                    TGlobals.computerPlayerModel = new TFirstComputerPlayerModel();
                    break;

                case 2:
                    TGlobals.computerPlayerModel = new TSecondComputerPlayerModel();
                    break;

                case 3:
                    TGlobals.computerPlayerModel = new TThirdComputerPlayerModel();
                    break;

                case 4:
                    TGlobals.computerPlayerModel = new TFourthComputerPlayerModel();
                    break;

                case 5:
                    TGlobals.computerPlayerModel = new TFifthComputerPlayerModel();
                    break;

                case 6:
                    TGlobals.computerPlayerModel = new TSixthComputerPlayerModel();
                    break;

                case 7:
                    TGlobals.computerPlayerModel = new TSeventhComputerPlayerModel();
                    break;

                case 8:
                    TGlobals.computerPlayerModel = new TEighthComputerPlayerModel();
                    break;

                case 9:
                    TGlobals.computerPlayerModel = new TNinthComputerPlayerModel();
                    break;

                case 10:
                    TGlobals.computerPlayerModel = new TTenthComputerPlayerModel();
                    break;

                case 11:
                    TGlobals.computerPlayerModel = new TElevenComputerPlayerModel();
                    break;

                case 12:
                    TGlobals.computerPlayerModel = new TTwelveComputerPlayerModel();
                    break;

                case 13:
                    TGlobals.computerPlayerModel = new TThirteenComputerPlayerModel();
                    break;

                case 14:
                    TGlobals.computerPlayerModel = new TFourteenComputerPlayerModel();
                    break;

                case 15:
                    TGlobals.computerPlayerModel = new TFifteenComputerPlayerModel();
                    break;

                case 0x10:
                    TGlobals.computerPlayerModel = new TSixteenComputerPlayerModel();
                    break;

                case 0x11:
                    TGlobals.computerPlayerModel = new TSeventeenComputerPlayerModel();
                    break;

                default:
                    break;
            }
            TGlobals.computerPlayerModel.CreateModel();
            TGlobals.computerPlayers = TGlobals.computerPlayerModel.GetCompterPlayers();
        }

        private void InitializeComponent()
        {
            ComponentResourceManager manager = new ComponentResourceManager(typeof(frmMainControl));
            this.panel1 = new Panel();
            this.tabPageSwitcher1 = new TabPageSwitcher();
            this.tabStripPage1 = new TabStripPage();
            this.tabPanel5 = new TabPanel();
            this.ribbonButton2 = new RibbonButton();
            this.ribbonButton11 = new RibbonButton();
            this.ribbonButton10 = new RibbonButton();
            this.tabPanel4 = new TabPanel();
            this.ribbonButtonMCCF = new RibbonButton();
            this.ribbonButtonYS = new RibbonButton();
            this.ribbonButtonMRCF = new RibbonButton();
            this.tabPanel3 = new TabPanel();
            this.ribbonButton13 = new RibbonButton();
            this.ribbonButton12 = new RibbonButton();
            this.ribbonButton5 = new RibbonButton();
            this.ribbonButton6 = new RibbonButton();
            this.tabStripPage2 = new TabStripPage();
            this.tabPanel2 = new TabPanel();
            this.ribbonButton7 = new RibbonButton();
            this.tabPanel1 = new TabPanel();
            this.ribbonButton4 = new RibbonButton();
            this.ribbonButton3 = new RibbonButton();
            this.ribbonButton1 = new RibbonButton();
            this.tabStripPage3 = new TabStripPage();
            this.tabStrip1 = new TabStrip();
            this.tab1 = new Tab();
            this.panel4 = new Panel();
            this.panel2 = new Panel();
            this.panel3 = new Panel();
            this.chckBox005 = new CheckBox();
            this.chckBox041 = new CheckBox();
            this.chckBox029 = new CheckBox();
            this.chckBox017 = new CheckBox();
            this.labelTSDK = new Label();
            this.chckBox011 = new CheckBox();
            this.chckBox047 = new CheckBox();
            this.chckBox035 = new CheckBox();
            this.chckBox023 = new CheckBox();
            this.labelBMSCX = new Label();
            this.panel5 = new Panel();
            this.panel6 = new Panel();
            this.panel7 = new Panel();
            this.label36 = new Label();
            this.label35 = new Label();
            this.label34 = new Label();
            this.label33 = new Label();
            this.labelGZ = new Label();
            this.labelXSCZR = new Label();
            this.chckBox058 = new CheckBox();
            this.chckBox057 = new CheckBox();
            this.labelJTZJ = new Label();
            this.labelZFZJ = new Label();
            this.chckBox056 = new CheckBox();
            this.chckBox055 = new CheckBox();
            this.labelZFSBXLF = new Label();
            this.chckBox054 = new CheckBox();
            this.labelGXCQDK = new Label();
            this.chckBox053 = new CheckBox();
            this.labelZFXZGLFY = new Label();
            this.chckBox016 = new CheckBox();
            this.chckBox052 = new CheckBox();
            this.chckBox040 = new CheckBox();
            this.chckBox028 = new CheckBox();
            this.labelCPYFTZ = new Label();
            this.chckBox015 = new CheckBox();
            this.chckBox051 = new CheckBox();
            this.chckBox039 = new CheckBox();
            this.chckBox027 = new CheckBox();
            this.labelJHGKH = new Label();
            this.chckBox014 = new CheckBox();
            this.chckBox050 = new CheckBox();
            this.chckBox038 = new CheckBox();
            this.chckBox026 = new CheckBox();
            this.labelGXYSK = new Label();
            this.chckBox013 = new CheckBox();
            this.chckBox049 = new CheckBox();
            this.chckBox037 = new CheckBox();
            this.chckBox025 = new CheckBox();
            this.labelKSXDSC = new Label();
            this.chckBox012 = new CheckBox();
            this.chckBox048 = new CheckBox();
            this.chckBox036 = new CheckBox();
            this.chckBox024 = new CheckBox();
            this.chckBox010 = new CheckBox();
            this.chckBox046 = new CheckBox();
            this.chckBox034 = new CheckBox();
            this.chckBox022 = new CheckBox();
            this.labelTZXSCX = new Label();
            this.chckBox009 = new CheckBox();
            this.chckBox045 = new CheckBox();
            this.chckBox033 = new CheckBox();
            this.chckBox021 = new CheckBox();
            this.labelGXSC = new Label();
            this.chckBox008 = new CheckBox();
            this.chckBox044 = new CheckBox();
            this.chckBox032 = new CheckBox();
            this.chckBox020 = new CheckBox();
            this.labelXYLDD = new Label();
            this.chckBox007 = new CheckBox();
            this.chckBox043 = new CheckBox();
            this.chckBox031 = new CheckBox();
            this.chckBox019 = new CheckBox();
            this.labelYCLRK = new Label();
            this.chckBox006 = new CheckBox();
            this.chckBox042 = new CheckBox();
            this.chckBox030 = new CheckBox();
            this.chckBox018 = new CheckBox();
            this.labelGXDQDK = new Label();
            this.labelZFYFS = new Label();
            this.labelZDXNDJH = new Label();
            this.labelCJDHH = new Label();
            this.chckBox004 = new CheckBox();
            this.chckBox003 = new CheckBox();
            this.chckBox002 = new CheckBox();
            this.chckBox001 = new CheckBox();
            this.labelXNNDGHHY = new Label();
            this.label4 = new Label();
            this.label3 = new Label();
            this.label2 = new Label();
            this.labelJD1 = new Label();
            this.panel8 = new Panel();
            this.groupBox5 = new GroupBox();
            this.labelActor = new Label();
            this.label6 = new Label();
            this.label18 = new Label();
            this.labelCompany = new Label();
            this.label31 = new Label();
            this.labelRunningTime = new Label();
            this.groupBox4 = new GroupBox();
            this.labelP4Capacity = new Label();
            this.labelP3Capacity = new Label();
            this.labelP2Capacity = new Label();
            this.labelP1Capacity = new Label();
            this.groupBox3 = new GroupBox();
            this.labelCertified14000 = new Label();
            this.labelCertified9000 = new Label();
            this.groupBox2 = new GroupBox();
            this.labelEnterInternationalMarket = new Label();
            this.labelEnterAsiaMarket = new Label();
            this.labelEnterDomesticMarket = new Label();
            this.labelEnterRegionalMarket = new Label();
            this.labelEnterLocalMarket = new Label();
            this.groupBox1 = new GroupBox();
            this.labelLoanSharking = new Label();
            this.label5 = new Label();
            this.labelReceivableAccounts = new Label();
            this.labelShortTermLoans = new Label();
            this.labelLongTermLoans = new Label();
            this.label51 = new Label();
            this.label49 = new Label();
            this.label48 = new Label();
            this.labelCurrentCash = new Label();
            this.label20 = new Label();
            this.panel1.SuspendLayout();
            this.tabPageSwitcher1.SuspendLayout();
            this.tabStripPage1.SuspendLayout();
            this.tabPanel5.SuspendLayout();
            this.tabPanel4.SuspendLayout();
            this.tabPanel3.SuspendLayout();
            this.tabStripPage2.SuspendLayout();
            this.tabPanel2.SuspendLayout();
            this.tabPanel1.SuspendLayout();
            this.tabStrip1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel8.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            base.SuspendLayout();
            this.panel1.Controls.Add(this.tabPageSwitcher1);
            this.panel1.Controls.Add(this.tabStrip1);
            this.panel1.Dock = DockStyle.Top;
            this.panel1.Location = new Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(0x318, 0x73);
            this.panel1.TabIndex = 3;
            this.tabPageSwitcher1.BackColor = Color.FromArgb(0xbf, 0xdb, 0xff);
            this.tabPageSwitcher1.Controls.Add(this.tabStripPage1);
            this.tabPageSwitcher1.Controls.Add(this.tabStripPage2);
            this.tabPageSwitcher1.Controls.Add(this.tabStripPage3);
            this.tabPageSwitcher1.Dock = DockStyle.Fill;
            this.tabPageSwitcher1.Location = new Point(0, 0x1a);
            this.tabPageSwitcher1.Name = "tabPageSwitcher1";
            this.tabPageSwitcher1.SelectedTabStripPage = this.tabStripPage1;
            this.tabPageSwitcher1.Size = new Size(0x318, 0x59);
            this.tabPageSwitcher1.TabIndex = 1;
            this.tabPageSwitcher1.TabStrip = this.tabStrip1;
            this.tabPageSwitcher1.Text = "tabPageSwitcher1";
            this.tabStripPage1.BaseColor = Color.FromArgb(0xd7, 0xe3, 0xf2);
            this.tabStripPage1.BaseColorOn = Color.FromArgb(0xd7, 0xe3, 0xf2);
            this.tabStripPage1.Caption = "";
            this.tabStripPage1.Controls.Add(this.tabPanel5);
            this.tabStripPage1.Controls.Add(this.tabPanel4);
            this.tabStripPage1.Controls.Add(this.tabPanel3);
            this.tabStripPage1.Dock = DockStyle.Fill;
            this.tabStripPage1.Location = new Point(4, 0);
            this.tabStripPage1.Name = "tabStripPage1";
            this.tabStripPage1.Opacity = 0xff;
            this.tabStripPage1.Padding = new Padding(0, 3, 0, 0);
            this.tabStripPage1.Size = new Size(0x310, 0x57);
            this.tabStripPage1.Speed = 8;
            this.tabStripPage1.TabIndex = 0;
            this.tabPanel5.BaseColor = Color.FromArgb(0xd7, 0xe3, 0xf2);
            this.tabPanel5.BaseColorOn = Color.FromArgb(0xd7, 0xe3, 0xf2);
            this.tabPanel5.Caption = "";
            this.tabPanel5.Controls.Add(this.ribbonButton2);
            this.tabPanel5.Controls.Add(this.ribbonButton11);
            this.tabPanel5.Controls.Add(this.ribbonButton10);
            this.tabPanel5.Dock = DockStyle.Fill;
            this.tabPanel5.Location = new Point(0x1f3, 3);
            this.tabPanel5.Name = "tabPanel5";
            this.tabPanel5.Opacity = 0xff;
            this.tabPanel5.Size = new Size(0x11d, 0x54);
            this.tabPanel5.Speed = 1;
            this.tabPanel5.TabIndex = 3;
            this.ribbonButton2.BackColor = Color.Transparent;
            this.ribbonButton2.BackgroundImageLayout = ImageLayout.Stretch;
            this.ribbonButton2.filename = null;
            this.ribbonButton2.FlatAppearance.BorderColor = Color.FromArgb(100, 0xff, 0xff, 0xff);
            this.ribbonButton2.FlatAppearance.BorderSize = 0;
            this.ribbonButton2.FlatAppearance.MouseDownBackColor = Color.FromArgb(100, 0xff, 0xff, 0xff);
            this.ribbonButton2.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, 0xff, 0xff, 0xff);
            this.ribbonButton2.FlatStyle = FlatStyle.Flat;
            this.ribbonButton2.folder = null;
            this.ribbonButton2.Image = Resources.Connection;
            this.ribbonButton2.ImageAlign = ContentAlignment.TopCenter;
            this.ribbonButton2.img = Resources.Connection;
            this.ribbonButton2.img_back = null;
            this.ribbonButton2.img_click = Resources.B_click;
            this.ribbonButton2.img_on = Resources.B_on;
            this.ribbonButton2.InfoColor = Color.FromArgb(0xc9, 0xd9, 0xef);
            this.ribbonButton2.InfoComment = "";
            this.ribbonButton2.InfoImage = "";
            this.ribbonButton2.InfoTitle = "系统注册";
            this.ribbonButton2.Location = new Point(0x59, 7);
            this.ribbonButton2.Name = "ribbonButton2";
            this.ribbonButton2.Size = new Size(60, 60);
            this.ribbonButton2.TabIndex = 8;
            this.ribbonButton2.Tag = "33";
            this.ribbonButton2.TextAlign = ContentAlignment.BottomCenter;
            this.ribbonButton2.UseVisualStyleBackColor = true;
            this.ribbonButton2.Click += new EventHandler(this.ribbonButton_Click);
            this.ribbonButton11.BackColor = Color.Transparent;
            this.ribbonButton11.BackgroundImageLayout = ImageLayout.Stretch;
            this.ribbonButton11.filename = null;
            this.ribbonButton11.FlatAppearance.BorderColor = Color.FromArgb(100, 0xff, 0xff, 0xff);
            this.ribbonButton11.FlatAppearance.BorderSize = 0;
            this.ribbonButton11.FlatAppearance.MouseDownBackColor = Color.FromArgb(100, 0xff, 0xff, 0xff);
            this.ribbonButton11.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, 0xff, 0xff, 0xff);
            this.ribbonButton11.FlatStyle = FlatStyle.Flat;
            this.ribbonButton11.folder = null;
            this.ribbonButton11.Image = Resources.help;
            this.ribbonButton11.ImageAlign = ContentAlignment.TopCenter;
            this.ribbonButton11.img = Resources.help;
            this.ribbonButton11.img_back = null;
            this.ribbonButton11.img_click = Resources.B_click;
            this.ribbonButton11.img_on = Resources.B_on;
            this.ribbonButton11.InfoColor = Color.FromArgb(0xc9, 0xd9, 0xef);
            this.ribbonButton11.InfoComment = "";
            this.ribbonButton11.InfoImage = "";
            this.ribbonButton11.InfoTitle = "关于";
            this.ribbonButton11.Location = new Point(15, 7);
            this.ribbonButton11.Name = "ribbonButton11";
            this.ribbonButton11.Size = new Size(60, 60);
            this.ribbonButton11.TabIndex = 7;
            this.ribbonButton11.Tag = "32";
            this.ribbonButton11.TextAlign = ContentAlignment.BottomCenter;
            this.ribbonButton11.UseVisualStyleBackColor = true;
            this.ribbonButton11.Click += new EventHandler(this.ribbonButton_Click);
            this.ribbonButton10.BackColor = Color.Transparent;
            this.ribbonButton10.BackgroundImageLayout = ImageLayout.Stretch;
            this.ribbonButton10.filename = null;
            this.ribbonButton10.FlatAppearance.BorderColor = Color.FromArgb(100, 0xff, 0xff, 0xff);
            this.ribbonButton10.FlatAppearance.BorderSize = 0;
            this.ribbonButton10.FlatAppearance.MouseDownBackColor = Color.FromArgb(100, 0xff, 0xff, 0xff);
            this.ribbonButton10.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, 0xff, 0xff, 0xff);
            this.ribbonButton10.FlatStyle = FlatStyle.Flat;
            this.ribbonButton10.folder = null;
            this.ribbonButton10.Image = Resources.png0013;
            this.ribbonButton10.ImageAlign = ContentAlignment.TopCenter;
            this.ribbonButton10.img = Resources.png0013;
            this.ribbonButton10.img_back = null;
            this.ribbonButton10.img_click = Resources.B_click;
            this.ribbonButton10.img_on = Resources.B_on;
            this.ribbonButton10.InfoColor = Color.FromArgb(0xc9, 0xd9, 0xef);
            this.ribbonButton10.InfoComment = "";
            this.ribbonButton10.InfoImage = "";
            this.ribbonButton10.InfoTitle = "系统退出";
            this.ribbonButton10.Location = new Point(0x9b, 7);
            this.ribbonButton10.Name = "ribbonButton10";
            this.ribbonButton10.Size = new Size(60, 60);
            this.ribbonButton10.TabIndex = 6;
            this.ribbonButton10.Tag = "31";
            this.ribbonButton10.TextAlign = ContentAlignment.BottomCenter;
            this.ribbonButton10.UseVisualStyleBackColor = true;
            this.ribbonButton10.Click += new EventHandler(this.ribbonButton_Click);
            this.tabPanel4.BaseColor = Color.FromArgb(0xd7, 0xe3, 0xf2);
            this.tabPanel4.BaseColorOn = Color.FromArgb(0xd7, 0xe3, 0xf2);
            this.tabPanel4.Caption = "";
            this.tabPanel4.Controls.Add(this.ribbonButtonMCCF);
            this.tabPanel4.Controls.Add(this.ribbonButtonYS);
            this.tabPanel4.Controls.Add(this.ribbonButtonMRCF);
            this.tabPanel4.Dock = DockStyle.Left;
            this.tabPanel4.Location = new Point(0x119, 3);
            this.tabPanel4.Name = "tabPanel4";
            this.tabPanel4.Opacity = 0xff;
            this.tabPanel4.Size = new Size(0xda, 0x54);
            this.tabPanel4.Speed = 1;
            this.tabPanel4.TabIndex = 2;
            this.ribbonButtonMCCF.BackColor = Color.Transparent;
            this.ribbonButtonMCCF.BackgroundImageLayout = ImageLayout.Stretch;
            this.ribbonButtonMCCF.filename = null;
            this.ribbonButtonMCCF.FlatAppearance.BorderColor = Color.FromArgb(100, 0xff, 0xff, 0xff);
            this.ribbonButtonMCCF.FlatAppearance.BorderSize = 0;
            this.ribbonButtonMCCF.FlatAppearance.MouseDownBackColor = Color.FromArgb(100, 0xff, 0xff, 0xff);
            this.ribbonButtonMCCF.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, 0xff, 0xff, 0xff);
            this.ribbonButtonMCCF.FlatStyle = FlatStyle.Flat;
            this.ribbonButtonMCCF.folder = null;
            this.ribbonButtonMCCF.Image = Resources.MCCF;
            this.ribbonButtonMCCF.ImageAlign = ContentAlignment.TopCenter;
            this.ribbonButtonMCCF.img = Resources.MCCF;
            this.ribbonButtonMCCF.img_back = null;
            this.ribbonButtonMCCF.img_click = Resources.B_click;
            this.ribbonButtonMCCF.img_on = Resources.B_on;
            this.ribbonButtonMCCF.InfoColor = Color.FromArgb(0xc9, 0xd9, 0xef);
            this.ribbonButtonMCCF.InfoComment = "";
            this.ribbonButtonMCCF.InfoImage = "";
            this.ribbonButtonMCCF.InfoTitle = "卖厂房";
            this.ribbonButtonMCCF.Location = new Point(0x8d, 7);
            this.ribbonButtonMCCF.Name = "ribbonButtonMCCF";
            this.ribbonButtonMCCF.Size = new Size(60, 60);
            this.ribbonButtonMCCF.TabIndex = 5;
            this.ribbonButtonMCCF.Tag = "23";
            this.ribbonButtonMCCF.TextAlign = ContentAlignment.BottomCenter;
            this.ribbonButtonMCCF.UseVisualStyleBackColor = true;
            this.ribbonButtonMCCF.Click += new EventHandler(this.ribbonButton_Click);
            this.ribbonButtonYS.BackColor = Color.Transparent;
            this.ribbonButtonYS.BackgroundImageLayout = ImageLayout.Stretch;
            this.ribbonButtonYS.filename = null;
            this.ribbonButtonYS.FlatAppearance.BorderColor = Color.FromArgb(100, 0xff, 0xff, 0xff);
            this.ribbonButtonYS.FlatAppearance.BorderSize = 0;
            this.ribbonButtonYS.FlatAppearance.MouseDownBackColor = Color.FromArgb(100, 0xff, 0xff, 0xff);
            this.ribbonButtonYS.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, 0xff, 0xff, 0xff);
            this.ribbonButtonYS.FlatStyle = FlatStyle.Flat;
            this.ribbonButtonYS.folder = null;
            this.ribbonButtonYS.Image = Resources.png0223;
            this.ribbonButtonYS.ImageAlign = ContentAlignment.TopCenter;
            this.ribbonButtonYS.img = Resources.png0223;
            this.ribbonButtonYS.img_back = null;
            this.ribbonButtonYS.img_click = Resources.B_click;
            this.ribbonButtonYS.img_on = Resources.B_on;
            this.ribbonButtonYS.InfoColor = Color.FromArgb(0xc9, 0xd9, 0xef);
            this.ribbonButtonYS.InfoComment = "";
            this.ribbonButtonYS.InfoImage = "";
            this.ribbonButtonYS.InfoTitle = "贴现";
            this.ribbonButtonYS.Location = new Point(11, 7);
            this.ribbonButtonYS.Name = "ribbonButtonYS";
            this.ribbonButtonYS.Size = new Size(60, 60);
            this.ribbonButtonYS.TabIndex = 4;
            this.ribbonButtonYS.Tag = "21";
            this.ribbonButtonYS.TextAlign = ContentAlignment.BottomCenter;
            this.ribbonButtonYS.UseVisualStyleBackColor = true;
            this.ribbonButtonYS.Click += new EventHandler(this.ribbonButton_Click);
            this.ribbonButtonMRCF.BackColor = Color.Transparent;
            this.ribbonButtonMRCF.BackgroundImageLayout = ImageLayout.Stretch;
            this.ribbonButtonMRCF.filename = null;
            this.ribbonButtonMRCF.FlatAppearance.BorderColor = Color.FromArgb(100, 0xff, 0xff, 0xff);
            this.ribbonButtonMRCF.FlatAppearance.BorderSize = 0;
            this.ribbonButtonMRCF.FlatAppearance.MouseDownBackColor = Color.FromArgb(100, 0xff, 0xff, 0xff);
            this.ribbonButtonMRCF.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, 0xff, 0xff, 0xff);
            this.ribbonButtonMRCF.FlatStyle = FlatStyle.Flat;
            this.ribbonButtonMRCF.folder = null;
            this.ribbonButtonMRCF.Image = Resources.MRCF;
            this.ribbonButtonMRCF.ImageAlign = ContentAlignment.TopCenter;
            this.ribbonButtonMRCF.img = Resources.MRCF;
            this.ribbonButtonMRCF.img_back = null;
            this.ribbonButtonMRCF.img_click = Resources.B_click;
            this.ribbonButtonMRCF.img_on = Resources.B_on;
            this.ribbonButtonMRCF.InfoColor = Color.FromArgb(0xc9, 0xd9, 0xef);
            this.ribbonButtonMRCF.InfoComment = "";
            this.ribbonButtonMRCF.InfoImage = "";
            this.ribbonButtonMRCF.InfoTitle = "买厂房";
            this.ribbonButtonMRCF.Location = new Point(0x4d, 7);
            this.ribbonButtonMRCF.Name = "ribbonButtonMRCF";
            this.ribbonButtonMRCF.Size = new Size(60, 60);
            this.ribbonButtonMRCF.TabIndex = 3;
            this.ribbonButtonMRCF.Tag = "22";
            this.ribbonButtonMRCF.TextAlign = ContentAlignment.BottomCenter;
            this.ribbonButtonMRCF.UseVisualStyleBackColor = true;
            this.ribbonButtonMRCF.Click += new EventHandler(this.ribbonButton_Click);
            this.tabPanel3.BaseColor = Color.FromArgb(0xd7, 0xe3, 0xf2);
            this.tabPanel3.BaseColorOn = Color.FromArgb(0xd7, 0xe3, 0xf2);
            this.tabPanel3.Caption = "";
            this.tabPanel3.Controls.Add(this.ribbonButton13);
            this.tabPanel3.Controls.Add(this.ribbonButton12);
            this.tabPanel3.Controls.Add(this.ribbonButton5);
            this.tabPanel3.Controls.Add(this.ribbonButton6);
            this.tabPanel3.Dock = DockStyle.Left;
            this.tabPanel3.Location = new Point(0, 3);
            this.tabPanel3.Name = "tabPanel3";
            this.tabPanel3.Opacity = 0xff;
            this.tabPanel3.Size = new Size(0x119, 0x54);
            this.tabPanel3.Speed = 1;
            this.tabPanel3.TabIndex = 0;
            this.ribbonButton13.BackColor = Color.Transparent;
            this.ribbonButton13.BackgroundImageLayout = ImageLayout.Stretch;
            this.ribbonButton13.filename = null;
            this.ribbonButton13.FlatAppearance.BorderColor = Color.FromArgb(100, 0xff, 0xff, 0xff);
            this.ribbonButton13.FlatAppearance.BorderSize = 0;
            this.ribbonButton13.FlatAppearance.MouseDownBackColor = Color.FromArgb(100, 0xff, 0xff, 0xff);
            this.ribbonButton13.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, 0xff, 0xff, 0xff);
            this.ribbonButton13.FlatStyle = FlatStyle.Flat;
            this.ribbonButton13.folder = null;
            this.ribbonButton13.Image = Resources.png0058;
            this.ribbonButton13.ImageAlign = ContentAlignment.TopCenter;
            this.ribbonButton13.img = Resources.png0058;
            this.ribbonButton13.img_back = null;
            this.ribbonButton13.img_click = Resources.B_click;
            this.ribbonButton13.img_on = Resources.B_on;
            this.ribbonButton13.InfoColor = Color.FromArgb(0xc9, 0xd9, 0xef);
            this.ribbonButton13.InfoComment = "";
            this.ribbonButton13.InfoImage = "";
            this.ribbonButton13.InfoTitle = "查看英雄榜";
            this.ribbonButton13.Location = new Point(0xcd, 7);
            this.ribbonButton13.Name = "ribbonButton13";
            this.ribbonButton13.Size = new Size(60, 60);
            this.ribbonButton13.TabIndex = 8;
            this.ribbonButton13.Tag = "14";
            this.ribbonButton13.TextAlign = ContentAlignment.BottomCenter;
            this.ribbonButton13.UseVisualStyleBackColor = true;
            this.ribbonButton13.Click += new EventHandler(this.ribbonButton_Click);
            this.ribbonButton12.BackColor = Color.Transparent;
            this.ribbonButton12.BackgroundImageLayout = ImageLayout.Stretch;
            this.ribbonButton12.filename = null;
            this.ribbonButton12.FlatAppearance.BorderColor = Color.FromArgb(100, 0xff, 0xff, 0xff);
            this.ribbonButton12.FlatAppearance.BorderSize = 0;
            this.ribbonButton12.FlatAppearance.MouseDownBackColor = Color.FromArgb(100, 0xff, 0xff, 0xff);
            this.ribbonButton12.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, 0xff, 0xff, 0xff);
            this.ribbonButton12.FlatStyle = FlatStyle.Flat;
            this.ribbonButton12.folder = null;
            this.ribbonButton12.Image = Resources.File_28;
            this.ribbonButton12.ImageAlign = ContentAlignment.TopCenter;
            this.ribbonButton12.img = Resources.File_28;
            this.ribbonButton12.img_back = null;
            this.ribbonButton12.img_click = Resources.B_click;
            this.ribbonButton12.img_on = Resources.B_on;
            this.ribbonButton12.InfoColor = Color.FromArgb(0xc9, 0xd9, 0xef);
            this.ribbonButton12.InfoComment = "";
            this.ribbonButton12.InfoImage = "";
            this.ribbonButton12.InfoTitle = "查看经营业绩排名";
            this.ribbonButton12.Location = new Point(0x8b, 7);
            this.ribbonButton12.Name = "ribbonButton12";
            this.ribbonButton12.Size = new Size(60, 60);
            this.ribbonButton12.TabIndex = 8;
            this.ribbonButton12.Tag = "13";
            this.ribbonButton12.TextAlign = ContentAlignment.BottomCenter;
            this.ribbonButton12.UseVisualStyleBackColor = true;
            this.ribbonButton12.Click += new EventHandler(this.ribbonButton_Click);
            this.ribbonButton5.BackColor = Color.Transparent;
            this.ribbonButton5.BackgroundImageLayout = ImageLayout.Stretch;
            this.ribbonButton5.filename = null;
            this.ribbonButton5.FlatAppearance.BorderColor = Color.FromArgb(100, 0xff, 0xff, 0xff);
            this.ribbonButton5.FlatAppearance.BorderSize = 0;
            this.ribbonButton5.FlatAppearance.MouseDownBackColor = Color.FromArgb(100, 0xff, 0xff, 0xff);
            this.ribbonButton5.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, 0xff, 0xff, 0xff);
            this.ribbonButton5.FlatStyle = FlatStyle.Flat;
            this.ribbonButton5.folder = null;
            this.ribbonButton5.Image = Resources.png0241;
            this.ribbonButton5.ImageAlign = ContentAlignment.TopCenter;
            this.ribbonButton5.img = Resources.png0241;
            this.ribbonButton5.img_back = null;
            this.ribbonButton5.img_click = Resources.B_click;
            this.ribbonButton5.img_on = Resources.B_on;
            this.ribbonButton5.InfoColor = Color.FromArgb(0xc9, 0xd9, 0xef);
            this.ribbonButton5.InfoComment = "";
            this.ribbonButton5.InfoImage = "";
            this.ribbonButton5.InfoTitle = "查看台面";
            this.ribbonButton5.Location = new Point(11, 7);
            this.ribbonButton5.Name = "ribbonButton5";
            this.ribbonButton5.Size = new Size(60, 60);
            this.ribbonButton5.TabIndex = 6;
            this.ribbonButton5.Tag = "11";
            this.ribbonButton5.TextAlign = ContentAlignment.BottomCenter;
            this.ribbonButton5.UseVisualStyleBackColor = true;
            this.ribbonButton5.Click += new EventHandler(this.ribbonButton_Click);
            this.ribbonButton6.BackColor = Color.Transparent;
            this.ribbonButton6.BackgroundImageLayout = ImageLayout.Stretch;
            this.ribbonButton6.filename = null;
            this.ribbonButton6.FlatAppearance.BorderColor = Color.FromArgb(100, 0xff, 0xff, 0xff);
            this.ribbonButton6.FlatAppearance.BorderSize = 0;
            this.ribbonButton6.FlatAppearance.MouseDownBackColor = Color.FromArgb(100, 0xff, 0xff, 0xff);
            this.ribbonButton6.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, 0xff, 0xff, 0xff);
            this.ribbonButton6.FlatStyle = FlatStyle.Flat;
            this.ribbonButton6.folder = null;
            this.ribbonButton6.Image = Resources.png0234;
            this.ribbonButton6.ImageAlign = ContentAlignment.TopCenter;
            this.ribbonButton6.img = Resources.png0234;
            this.ribbonButton6.img_back = null;
            this.ribbonButton6.img_click = Resources.B_click;
            this.ribbonButton6.img_on = Resources.B_on;
            this.ribbonButton6.InfoColor = Color.FromArgb(0xc9, 0xd9, 0xef);
            this.ribbonButton6.InfoComment = "";
            this.ribbonButton6.InfoImage = "";
            this.ribbonButton6.InfoTitle = "查看经营结果";
            this.ribbonButton6.Location = new Point(0x4d, 7);
            this.ribbonButton6.Name = "ribbonButton6";
            this.ribbonButton6.Size = new Size(60, 60);
            this.ribbonButton6.TabIndex = 5;
            this.ribbonButton6.Tag = "12";
            this.ribbonButton6.TextAlign = ContentAlignment.BottomCenter;
            this.ribbonButton6.UseVisualStyleBackColor = true;
            this.ribbonButton6.Click += new EventHandler(this.ribbonButton_Click);
            this.tabStripPage2.BaseColor = Color.FromArgb(0xd7, 0xe3, 0xf2);
            this.tabStripPage2.BaseColorOn = Color.FromArgb(0xd7, 0xe3, 0xf2);
            this.tabStripPage2.Caption = "";
            this.tabStripPage2.Controls.Add(this.tabPanel2);
            this.tabStripPage2.Controls.Add(this.tabPanel1);
            this.tabStripPage2.Dock = DockStyle.Fill;
            this.tabStripPage2.Location = new Point(4, 0);
            this.tabStripPage2.Name = "tabStripPage2";
            this.tabStripPage2.Opacity = 0xff;
            this.tabStripPage2.Padding = new Padding(0, 3, 0, 0);
            this.tabStripPage2.Size = new Size(0x310, 0x57);
            this.tabStripPage2.Speed = 8;
            this.tabStripPage2.TabIndex = 1;
            this.tabPanel2.BaseColor = Color.FromArgb(0xd7, 0xe3, 0xf2);
            this.tabPanel2.BaseColorOn = Color.FromArgb(0xd7, 0xe3, 0xf2);
            this.tabPanel2.Caption = "";
            this.tabPanel2.Controls.Add(this.ribbonButton7);
            this.tabPanel2.Dock = DockStyle.Fill;
            this.tabPanel2.Location = new Point(0xe2, 3);
            this.tabPanel2.Name = "tabPanel2";
            this.tabPanel2.Opacity = 0xff;
            this.tabPanel2.Size = new Size(0x22e, 0x54);
            this.tabPanel2.Speed = 1;
            this.tabPanel2.TabIndex = 2;
            this.ribbonButton7.BackColor = Color.Transparent;
            this.ribbonButton7.BackgroundImageLayout = ImageLayout.Stretch;
            this.ribbonButton7.filename = null;
            this.ribbonButton7.FlatAppearance.BorderColor = Color.FromArgb(100, 0xff, 0xff, 0xff);
            this.ribbonButton7.FlatAppearance.BorderSize = 0;
            this.ribbonButton7.FlatAppearance.MouseDownBackColor = Color.FromArgb(100, 0xff, 0xff, 0xff);
            this.ribbonButton7.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, 0xff, 0xff, 0xff);
            this.ribbonButton7.FlatStyle = FlatStyle.Flat;
            this.ribbonButton7.folder = null;
            this.ribbonButton7.Image = Resources.png0013;
            this.ribbonButton7.ImageAlign = ContentAlignment.TopCenter;
            this.ribbonButton7.img = Resources.png0013;
            this.ribbonButton7.img_back = null;
            this.ribbonButton7.img_click = Resources.B_click;
            this.ribbonButton7.img_on = Resources.B_on;
            this.ribbonButton7.InfoColor = Color.FromArgb(0xc9, 0xd9, 0xef);
            this.ribbonButton7.InfoComment = "";
            this.ribbonButton7.InfoImage = "";
            this.ribbonButton7.InfoTitle = "退出";
            this.ribbonButton7.Location = new Point(7, 7);
            this.ribbonButton7.Name = "ribbonButton7";
            this.ribbonButton7.Size = new Size(60, 60);
            this.ribbonButton7.TabIndex = 6;
            this.ribbonButton7.TextAlign = ContentAlignment.BottomCenter;
            this.ribbonButton7.UseVisualStyleBackColor = true;
            this.tabPanel1.BaseColor = Color.FromArgb(0xd7, 0xe3, 0xf2);
            this.tabPanel1.BaseColorOn = Color.FromArgb(0xd7, 0xe3, 0xf2);
            this.tabPanel1.Caption = "";
            this.tabPanel1.Controls.Add(this.ribbonButton4);
            this.tabPanel1.Controls.Add(this.ribbonButton3);
            this.tabPanel1.Controls.Add(this.ribbonButton1);
            this.tabPanel1.Dock = DockStyle.Left;
            this.tabPanel1.Location = new Point(0, 3);
            this.tabPanel1.Name = "tabPanel1";
            this.tabPanel1.Opacity = 0xff;
            this.tabPanel1.Size = new Size(0xe2, 0x54);
            this.tabPanel1.Speed = 1;
            this.tabPanel1.TabIndex = 1;
            this.ribbonButton4.BackColor = Color.Transparent;
            this.ribbonButton4.BackgroundImageLayout = ImageLayout.Stretch;
            this.ribbonButton4.filename = null;
            this.ribbonButton4.FlatAppearance.BorderColor = Color.FromArgb(100, 0xff, 0xff, 0xff);
            this.ribbonButton4.FlatAppearance.BorderSize = 0;
            this.ribbonButton4.FlatAppearance.MouseDownBackColor = Color.FromArgb(100, 0xff, 0xff, 0xff);
            this.ribbonButton4.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, 0xff, 0xff, 0xff);
            this.ribbonButton4.FlatStyle = FlatStyle.Flat;
            this.ribbonButton4.folder = null;
            this.ribbonButton4.Image = Resources.png0505;
            this.ribbonButton4.ImageAlign = ContentAlignment.TopCenter;
            this.ribbonButton4.img = Resources.png0505;
            this.ribbonButton4.img_back = null;
            this.ribbonButton4.img_click = Resources.B_click;
            this.ribbonButton4.img_on = Resources.B_on;
            this.ribbonButton4.InfoColor = Color.FromArgb(0xc9, 0xd9, 0xef);
            this.ribbonButton4.InfoComment = "";
            this.ribbonButton4.InfoImage = "";
            this.ribbonButton4.InfoTitle = "新建厂房";
            this.ribbonButton4.Location = new Point(0x8d, 7);
            this.ribbonButton4.Name = "ribbonButton4";
            this.ribbonButton4.Size = new Size(60, 60);
            this.ribbonButton4.TabIndex = 5;
            this.ribbonButton4.TextAlign = ContentAlignment.BottomCenter;
            this.ribbonButton4.UseVisualStyleBackColor = true;
            this.ribbonButton3.BackColor = Color.Transparent;
            this.ribbonButton3.BackgroundImageLayout = ImageLayout.Stretch;
            this.ribbonButton3.filename = null;
            this.ribbonButton3.FlatAppearance.BorderColor = Color.FromArgb(100, 0xff, 0xff, 0xff);
            this.ribbonButton3.FlatAppearance.BorderSize = 0;
            this.ribbonButton3.FlatAppearance.MouseDownBackColor = Color.FromArgb(100, 0xff, 0xff, 0xff);
            this.ribbonButton3.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, 0xff, 0xff, 0xff);
            this.ribbonButton3.FlatStyle = FlatStyle.Flat;
            this.ribbonButton3.folder = null;
            this.ribbonButton3.Image = Resources.png0223;
            this.ribbonButton3.ImageAlign = ContentAlignment.TopCenter;
            this.ribbonButton3.img = Resources.png0223;
            this.ribbonButton3.img_back = null;
            this.ribbonButton3.img_click = Resources.B_click;
            this.ribbonButton3.img_on = Resources.B_on;
            this.ribbonButton3.InfoColor = Color.FromArgb(0xc9, 0xd9, 0xef);
            this.ribbonButton3.InfoComment = "";
            this.ribbonButton3.InfoImage = "";
            this.ribbonButton3.InfoTitle = "贴现";
            this.ribbonButton3.Location = new Point(11, 7);
            this.ribbonButton3.Name = "ribbonButton3";
            this.ribbonButton3.Size = new Size(60, 60);
            this.ribbonButton3.TabIndex = 4;
            this.ribbonButton3.TextAlign = ContentAlignment.BottomCenter;
            this.ribbonButton3.UseVisualStyleBackColor = true;
            this.ribbonButton1.BackColor = Color.Transparent;
            this.ribbonButton1.BackgroundImageLayout = ImageLayout.Stretch;
            this.ribbonButton1.filename = null;
            this.ribbonButton1.FlatAppearance.BorderColor = Color.FromArgb(100, 0xff, 0xff, 0xff);
            this.ribbonButton1.FlatAppearance.BorderSize = 0;
            this.ribbonButton1.FlatAppearance.MouseDownBackColor = Color.FromArgb(100, 0xff, 0xff, 0xff);
            this.ribbonButton1.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, 0xff, 0xff, 0xff);
            this.ribbonButton1.FlatStyle = FlatStyle.Flat;
            this.ribbonButton1.folder = null;
            this.ribbonButton1.Image = Resources.png0566;
            this.ribbonButton1.ImageAlign = ContentAlignment.TopCenter;
            this.ribbonButton1.img = Resources.png0566;
            this.ribbonButton1.img_back = null;
            this.ribbonButton1.img_click = Resources.B_click;
            this.ribbonButton1.img_on = Resources.B_on;
            this.ribbonButton1.InfoColor = Color.FromArgb(0xc9, 0xd9, 0xef);
            this.ribbonButton1.InfoComment = "";
            this.ribbonButton1.InfoImage = "";
            this.ribbonButton1.InfoTitle = "借高利贷";
            this.ribbonButton1.Location = new Point(0x4d, 7);
            this.ribbonButton1.Name = "ribbonButton1";
            this.ribbonButton1.Size = new Size(60, 60);
            this.ribbonButton1.TabIndex = 3;
            this.ribbonButton1.TextAlign = ContentAlignment.BottomCenter;
            this.ribbonButton1.UseVisualStyleBackColor = true;
            this.tabStripPage3.BaseColor = Color.FromArgb(0xd7, 0xe3, 0xf2);
            this.tabStripPage3.BaseColorOn = Color.FromArgb(0xd7, 0xe3, 0xf2);
            this.tabStripPage3.Caption = "";
            this.tabStripPage3.Dock = DockStyle.Fill;
            this.tabStripPage3.Location = new Point(4, 0);
            this.tabStripPage3.Name = "tabStripPage3";
            this.tabStripPage3.Opacity = 0xff;
            this.tabStripPage3.Padding = new Padding(0, 3, 0, 0);
            this.tabStripPage3.Size = new Size(0x310, 0x57);
            this.tabStripPage3.Speed = 8;
            this.tabStripPage3.TabIndex = 2;
            this.tabStrip1.AutoSize = false;
            this.tabStrip1.BackColor = Color.FromArgb(0xbf, 0xdb, 0xff);
            this.tabStrip1.GripStyle = ToolStripGripStyle.Hidden;
            ToolStripItem[] toolStripItems = new ToolStripItem[] { this.tab1 };
            this.tabStrip1.Items.AddRange(toolStripItems);
            this.tabStrip1.Location = new Point(0, 0);
            this.tabStrip1.Name = "tabStrip1";
            this.tabStrip1.Padding = new Padding(60, 3, 30, 0);
            this.tabStrip1.SelectedTab = null;
            this.tabStrip1.ShowItemToolTips = false;
            this.tabStrip1.Size = new Size(0x318, 0x1a);
            this.tabStrip1.TabIndex = 0;
            this.tabStrip1.TabOverlap = 0;
            this.tabStrip1.Text = "tabStrip1";
            this.tab1.AutoSize = false;
            this.tab1.Checked = true;
            this.tab1.CheckState = CheckState.Checked;
            this.tab1.Font = new Font("Microsoft Sans Serif", 9f);
            this.tab1.ForeColor = Color.FromArgb(0x2c, 90, 0x9a);
            this.tab1.Margin = new Padding(6, 1, 0, 2);
            this.tab1.Name = "tab1";
            this.tab1.Size = new Size(0x39, 0x17);
            this.tab1.TabStripPage = this.tabStripPage1;
            this.tab1.Text = "系统";
            this.panel4.Controls.Add(this.panel2);
            this.panel4.Dock = DockStyle.Fill;
            this.panel4.Location = new Point(0, 0x73);
            this.panel4.Name = "panel4";
            this.panel4.Size = new Size(0x318, 0x206);
            this.panel4.TabIndex = 4;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.panel8);
            this.panel2.Dock = DockStyle.Fill;
            this.panel2.Location = new Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new Size(0x318, 0x206);
            this.panel2.TabIndex = 0;
            this.panel3.AutoScroll = true;
            this.panel3.Controls.Add(this.chckBox005);
            this.panel3.Controls.Add(this.chckBox041);
            this.panel3.Controls.Add(this.chckBox029);
            this.panel3.Controls.Add(this.chckBox017);
            this.panel3.Controls.Add(this.labelTSDK);
            this.panel3.Controls.Add(this.chckBox011);
            this.panel3.Controls.Add(this.chckBox047);
            this.panel3.Controls.Add(this.chckBox035);
            this.panel3.Controls.Add(this.chckBox023);
            this.panel3.Controls.Add(this.labelBMSCX);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Controls.Add(this.panel7);
            this.panel3.Controls.Add(this.label36);
            this.panel3.Controls.Add(this.label35);
            this.panel3.Controls.Add(this.label34);
            this.panel3.Controls.Add(this.label33);
            this.panel3.Controls.Add(this.labelGZ);
            this.panel3.Controls.Add(this.labelXSCZR);
            this.panel3.Controls.Add(this.chckBox058);
            this.panel3.Controls.Add(this.chckBox057);
            this.panel3.Controls.Add(this.labelJTZJ);
            this.panel3.Controls.Add(this.labelZFZJ);
            this.panel3.Controls.Add(this.chckBox056);
            this.panel3.Controls.Add(this.chckBox055);
            this.panel3.Controls.Add(this.labelZFSBXLF);
            this.panel3.Controls.Add(this.chckBox054);
            this.panel3.Controls.Add(this.labelGXCQDK);
            this.panel3.Controls.Add(this.chckBox053);
            this.panel3.Controls.Add(this.labelZFXZGLFY);
            this.panel3.Controls.Add(this.chckBox016);
            this.panel3.Controls.Add(this.chckBox052);
            this.panel3.Controls.Add(this.chckBox040);
            this.panel3.Controls.Add(this.chckBox028);
            this.panel3.Controls.Add(this.labelCPYFTZ);
            this.panel3.Controls.Add(this.chckBox015);
            this.panel3.Controls.Add(this.chckBox051);
            this.panel3.Controls.Add(this.chckBox039);
            this.panel3.Controls.Add(this.chckBox027);
            this.panel3.Controls.Add(this.labelJHGKH);
            this.panel3.Controls.Add(this.chckBox014);
            this.panel3.Controls.Add(this.chckBox050);
            this.panel3.Controls.Add(this.chckBox038);
            this.panel3.Controls.Add(this.chckBox026);
            this.panel3.Controls.Add(this.labelGXYSK);
            this.panel3.Controls.Add(this.chckBox013);
            this.panel3.Controls.Add(this.chckBox049);
            this.panel3.Controls.Add(this.chckBox037);
            this.panel3.Controls.Add(this.chckBox025);
            this.panel3.Controls.Add(this.labelKSXDSC);
            this.panel3.Controls.Add(this.chckBox012);
            this.panel3.Controls.Add(this.chckBox048);
            this.panel3.Controls.Add(this.chckBox036);
            this.panel3.Controls.Add(this.chckBox024);
            this.panel3.Controls.Add(this.chckBox010);
            this.panel3.Controls.Add(this.chckBox046);
            this.panel3.Controls.Add(this.chckBox034);
            this.panel3.Controls.Add(this.chckBox022);
            this.panel3.Controls.Add(this.labelTZXSCX);
            this.panel3.Controls.Add(this.chckBox009);
            this.panel3.Controls.Add(this.chckBox045);
            this.panel3.Controls.Add(this.chckBox033);
            this.panel3.Controls.Add(this.chckBox021);
            this.panel3.Controls.Add(this.labelGXSC);
            this.panel3.Controls.Add(this.chckBox008);
            this.panel3.Controls.Add(this.chckBox044);
            this.panel3.Controls.Add(this.chckBox032);
            this.panel3.Controls.Add(this.chckBox020);
            this.panel3.Controls.Add(this.labelXYLDD);
            this.panel3.Controls.Add(this.chckBox007);
            this.panel3.Controls.Add(this.chckBox043);
            this.panel3.Controls.Add(this.chckBox031);
            this.panel3.Controls.Add(this.chckBox019);
            this.panel3.Controls.Add(this.labelYCLRK);
            this.panel3.Controls.Add(this.chckBox006);
            this.panel3.Controls.Add(this.chckBox042);
            this.panel3.Controls.Add(this.chckBox030);
            this.panel3.Controls.Add(this.chckBox018);
            this.panel3.Controls.Add(this.labelGXDQDK);
            this.panel3.Controls.Add(this.labelZFYFS);
            this.panel3.Controls.Add(this.labelZDXNDJH);
            this.panel3.Controls.Add(this.labelCJDHH);
            this.panel3.Controls.Add(this.chckBox004);
            this.panel3.Controls.Add(this.chckBox003);
            this.panel3.Controls.Add(this.chckBox002);
            this.panel3.Controls.Add(this.chckBox001);
            this.panel3.Controls.Add(this.labelXNNDGHHY);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.labelJD1);
            this.panel3.Dock = DockStyle.Fill;
            this.panel3.Location = new Point(0xf1, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new Size(0x227, 0x206);
            this.panel3.TabIndex = 3;
            this.chckBox005.AutoSize = true;
            this.chckBox005.Location = new Point(0x12e, 140);
            this.chckBox005.Name = "chckBox005";
            this.chckBox005.Size = new Size(15, 14);
            this.chckBox005.TabIndex = 0xda;
            this.chckBox005.Tag = "5";
            this.chckBox005.UseVisualStyleBackColor = true;
            this.chckBox005.Click += new EventHandler(this.chkBox_Click);
            this.chckBox041.AutoSize = true;
            this.chckBox041.Location = new Point(0x1bb, 140);
            this.chckBox041.Name = "chckBox041";
            this.chckBox041.Size = new Size(15, 14);
            this.chckBox041.TabIndex = 0xd9;
            this.chckBox041.Tag = "41";
            this.chckBox041.UseVisualStyleBackColor = true;
            this.chckBox041.Click += new EventHandler(this.chkBox_Click);
            this.chckBox029.AutoSize = true;
            this.chckBox029.Location = new Point(0x18c, 140);
            this.chckBox029.Name = "chckBox029";
            this.chckBox029.Size = new Size(15, 14);
            this.chckBox029.TabIndex = 0xd8;
            this.chckBox029.Tag = "29";
            this.chckBox029.UseVisualStyleBackColor = true;
            this.chckBox029.Click += new EventHandler(this.chkBox_Click);
            this.chckBox017.AutoSize = true;
            this.chckBox017.Location = new Point(0x15d, 140);
            this.chckBox017.Name = "chckBox017";
            this.chckBox017.Size = new Size(15, 14);
            this.chckBox017.TabIndex = 0xd7;
            this.chckBox017.Tag = "17";
            this.chckBox017.UseVisualStyleBackColor = true;
            this.chckBox017.Click += new EventHandler(this.chkBox_Click);
            this.labelTSDK.AutoSize = true;
            this.labelTSDK.Location = new Point(0x3f, 0x8e);
            this.labelTSDK.Name = "labelTSDK";
            this.labelTSDK.Size = new Size(0x71, 12);
            this.labelTSDK.TabIndex = 0xd6;
            this.labelTSDK.Text = "特殊贷款(高利贷款)";
            this.chckBox011.AutoSize = true;
            this.chckBox011.Location = new Point(0x12e, 260);
            this.chckBox011.Name = "chckBox011";
            this.chckBox011.Size = new Size(15, 14);
            this.chckBox011.TabIndex = 0xd5;
            this.chckBox011.Tag = "11";
            this.chckBox011.UseVisualStyleBackColor = true;
            this.chckBox011.Click += new EventHandler(this.chkBox_Click);
            this.chckBox047.AutoSize = true;
            this.chckBox047.Location = new Point(0x1bb, 260);
            this.chckBox047.Name = "chckBox047";
            this.chckBox047.Size = new Size(15, 14);
            this.chckBox047.TabIndex = 0xd4;
            this.chckBox047.Tag = "47";
            this.chckBox047.UseVisualStyleBackColor = true;
            this.chckBox047.Click += new EventHandler(this.chkBox_Click);
            this.chckBox035.AutoSize = true;
            this.chckBox035.Location = new Point(0x18c, 260);
            this.chckBox035.Name = "chckBox035";
            this.chckBox035.Size = new Size(15, 14);
            this.chckBox035.TabIndex = 0xd3;
            this.chckBox035.Tag = "35";
            this.chckBox035.UseVisualStyleBackColor = true;
            this.chckBox035.Click += new EventHandler(this.chkBox_Click);
            this.chckBox023.AutoSize = true;
            this.chckBox023.Location = new Point(0x15d, 260);
            this.chckBox023.Name = "chckBox023";
            this.chckBox023.Size = new Size(15, 14);
            this.chckBox023.TabIndex = 210;
            this.chckBox023.Tag = "23";
            this.chckBox023.UseVisualStyleBackColor = true;
            this.chckBox023.Click += new EventHandler(this.chkBox_Click);
            this.labelBMSCX.AutoSize = true;
            this.labelBMSCX.Location = new Point(0x3f, 0xf2);
            this.labelBMSCX.Name = "labelBMSCX";
            this.labelBMSCX.Size = new Size(0x41, 12);
            this.labelBMSCX.TabIndex = 0xd1;
            this.labelBMSCX.Text = "变卖生产线";
            this.panel5.BackColor = Color.Gainsboro;
            this.panel5.Location = new Point(0x2f, 0x17e);
            this.panel5.Name = "panel5";
            this.panel5.Size = new Size(0x1ca, 10);
            this.panel5.TabIndex = 0xd0;
            this.panel6.BackColor = Color.Gainsboro;
            this.panel6.Location = new Point(0x33, 0x7e);
            this.panel6.Name = "panel6";
            this.panel6.Size = new Size(0x1ca, 10);
            this.panel6.TabIndex = 0xcf;
            this.panel7.BackColor = Color.Gainsboro;
            this.panel7.Location = new Point(0x33, 13);
            this.panel7.Name = "panel7";
            this.panel7.Size = new Size(0x1ca, 10);
            this.panel7.TabIndex = 0xce;
            this.label36.AutoSize = true;
            this.label36.Location = new Point(0x1dc, 0x1e1);
            this.label36.Name = "label36";
            this.label36.Size = new Size(0x11, 12);
            this.label36.TabIndex = 0xcd;
            this.label36.Text = "终";
            this.label35.AutoSize = true;
            this.label35.Location = new Point(0x1dc, 0x1b9);
            this.label35.Name = "label35";
            this.label35.Size = new Size(0x11, 12);
            this.label35.TabIndex = 0xcc;
            this.label35.Text = "年";
            this.label34.AutoSize = true;
            this.label34.Location = new Point(480, 0x59);
            this.label34.Name = "label34";
            this.label34.Size = new Size(0x11, 12);
            this.label34.TabIndex = 0xcb;
            this.label34.Text = "初";
            this.label33.AutoSize = true;
            this.label33.Location = new Point(480, 0x31);
            this.label33.Name = "label33";
            this.label33.Size = new Size(0x11, 12);
            this.label33.TabIndex = 0xca;
            this.label33.Text = "年";
            this.labelGZ.AutoSize = true;
            this.labelGZ.Location = new Point(0x3f, 0x1f2);
            this.labelGZ.Name = "labelGZ";
            this.labelGZ.Size = new Size(0x1d, 12);
            this.labelGZ.TabIndex = 0xc9;
            this.labelGZ.Text = "关帐";
            this.labelXSCZR.AutoSize = true;
            this.labelXSCZR.Location = new Point(0x3f, 0x1de);
            this.labelXSCZR.Name = "labelXSCZR";
            this.labelXSCZR.Size = new Size(0xad, 12);
            this.labelXSCZR.TabIndex = 200;
            this.labelXSCZR.Text = "新市场准入/ISO资格认证的投资";
            this.chckBox058.AutoSize = true;
            this.chckBox058.Location = new Point(0x1bb, 0x1f0);
            this.chckBox058.Name = "chckBox058";
            this.chckBox058.Size = new Size(15, 14);
            this.chckBox058.TabIndex = 0xc7;
            this.chckBox058.Tag = "58";
            this.chckBox058.UseVisualStyleBackColor = true;
            this.chckBox058.Click += new EventHandler(this.chkBox_Click);
            this.chckBox057.AutoSize = true;
            this.chckBox057.Location = new Point(0x1bb, 0x1dc);
            this.chckBox057.Name = "chckBox057";
            this.chckBox057.Size = new Size(15, 14);
            this.chckBox057.TabIndex = 0xc6;
            this.chckBox057.Tag = "57";
            this.chckBox057.UseVisualStyleBackColor = true;
            this.chckBox057.Click += new EventHandler(this.chkBox_Click);
            this.labelJTZJ.AutoSize = true;
            this.labelJTZJ.Location = new Point(0x3f, 0x1ca);
            this.labelJTZJ.Name = "labelJTZJ";
            this.labelJTZJ.Size = new Size(0x35, 12);
            this.labelJTZJ.TabIndex = 0xc5;
            this.labelJTZJ.Text = "计提折旧";
            this.labelZFZJ.AutoSize = true;
            this.labelZFZJ.Location = new Point(0x3f, 0x1b6);
            this.labelZFZJ.Name = "labelZFZJ";
            this.labelZFZJ.Size = new Size(0x35, 12);
            this.labelZFZJ.TabIndex = 0xc4;
            this.labelZFZJ.Text = "支付租金";
            this.chckBox056.AutoSize = true;
            this.chckBox056.Location = new Point(0x1bb, 0x1c8);
            this.chckBox056.Name = "chckBox056";
            this.chckBox056.Size = new Size(15, 14);
            this.chckBox056.TabIndex = 0xc3;
            this.chckBox056.Tag = "56";
            this.chckBox056.UseVisualStyleBackColor = true;
            this.chckBox056.Click += new EventHandler(this.chkBox_Click);
            this.chckBox055.AutoSize = true;
            this.chckBox055.Location = new Point(0x1bb, 0x1b4);
            this.chckBox055.Name = "chckBox055";
            this.chckBox055.Size = new Size(15, 14);
            this.chckBox055.TabIndex = 0xc2;
            this.chckBox055.Tag = "55";
            this.chckBox055.UseVisualStyleBackColor = true;
            this.chckBox055.Click += new EventHandler(this.chkBox_Click);
            this.labelZFSBXLF.AutoSize = true;
            this.labelZFSBXLF.Location = new Point(0x3f, 0x1a2);
            this.labelZFSBXLF.Name = "labelZFSBXLF";
            this.labelZFSBXLF.Size = new Size(0x59, 12);
            this.labelZFSBXLF.TabIndex = 0xc1;
            this.labelZFSBXLF.Text = "支付设备维修费";
            this.chckBox054.AutoSize = true;
            this.chckBox054.Location = new Point(0x1bb, 0x1a0);
            this.chckBox054.Name = "chckBox054";
            this.chckBox054.Size = new Size(15, 14);
            this.chckBox054.TabIndex = 0xc0;
            this.chckBox054.Tag = "54";
            this.chckBox054.UseVisualStyleBackColor = true;
            this.chckBox054.Click += new EventHandler(this.chkBox_Click);
            this.labelGXCQDK.AutoSize = true;
            this.labelGXCQDK.Location = new Point(0x3f, 0x18e);
            this.labelGXCQDK.Name = "labelGXCQDK";
            this.labelGXCQDK.Size = new Size(0xd1, 12);
            this.labelGXCQDK.TabIndex = 0xbf;
            this.labelGXCQDK.Text = "更新长期贷款/支付利息/获得新的贷款";
            this.chckBox053.AutoSize = true;
            this.chckBox053.Location = new Point(0x1bb, 0x18c);
            this.chckBox053.Name = "chckBox053";
            this.chckBox053.Size = new Size(15, 14);
            this.chckBox053.TabIndex = 190;
            this.chckBox053.Tag = "53";
            this.chckBox053.UseVisualStyleBackColor = true;
            this.chckBox053.Click += new EventHandler(this.chkBox_Click);
            this.labelZFXZGLFY.AutoSize = true;
            this.labelZFXZGLFY.Location = new Point(0x3f, 0x16a);
            this.labelZFXZGLFY.Name = "labelZFXZGLFY";
            this.labelZFXZGLFY.Size = new Size(0x65, 12);
            this.labelZFXZGLFY.TabIndex = 0xbd;
            this.labelZFXZGLFY.Tag = "15";
            this.labelZFXZGLFY.Text = "支付行政管理费用";
            this.chckBox016.AutoSize = true;
            this.chckBox016.Location = new Point(0x12e, 360);
            this.chckBox016.Name = "chckBox016";
            this.chckBox016.Size = new Size(15, 14);
            this.chckBox016.TabIndex = 0xbc;
            this.chckBox016.Tag = "16";
            this.chckBox016.UseVisualStyleBackColor = true;
            this.chckBox016.Click += new EventHandler(this.chkBox_Click);
            this.chckBox052.AutoSize = true;
            this.chckBox052.Location = new Point(0x1bb, 360);
            this.chckBox052.Name = "chckBox052";
            this.chckBox052.Size = new Size(15, 14);
            this.chckBox052.TabIndex = 0xbb;
            this.chckBox052.Tag = "52";
            this.chckBox052.UseVisualStyleBackColor = true;
            this.chckBox052.Click += new EventHandler(this.chkBox_Click);
            this.chckBox040.AutoSize = true;
            this.chckBox040.Location = new Point(0x18c, 360);
            this.chckBox040.Name = "chckBox040";
            this.chckBox040.Size = new Size(15, 14);
            this.chckBox040.TabIndex = 0xba;
            this.chckBox040.Tag = "40";
            this.chckBox040.UseVisualStyleBackColor = true;
            this.chckBox040.Click += new EventHandler(this.chkBox_Click);
            this.chckBox028.AutoSize = true;
            this.chckBox028.Location = new Point(0x15d, 360);
            this.chckBox028.Name = "chckBox028";
            this.chckBox028.Size = new Size(15, 14);
            this.chckBox028.TabIndex = 0xb9;
            this.chckBox028.Tag = "28";
            this.chckBox028.UseVisualStyleBackColor = true;
            this.chckBox028.Click += new EventHandler(this.chkBox_Click);
            this.labelCPYFTZ.AutoSize = true;
            this.labelCPYFTZ.Location = new Point(0x3f, 0x156);
            this.labelCPYFTZ.Name = "labelCPYFTZ";
            this.labelCPYFTZ.Size = new Size(0x4d, 12);
            this.labelCPYFTZ.TabIndex = 0xb8;
            this.labelCPYFTZ.Text = "产品研发投资";
            this.chckBox015.AutoSize = true;
            this.chckBox015.Location = new Point(0x12e, 340);
            this.chckBox015.Name = "chckBox015";
            this.chckBox015.Size = new Size(15, 14);
            this.chckBox015.TabIndex = 0xb7;
            this.chckBox015.Tag = "15";
            this.chckBox015.UseVisualStyleBackColor = true;
            this.chckBox015.Click += new EventHandler(this.chkBox_Click);
            this.chckBox051.AutoSize = true;
            this.chckBox051.Location = new Point(0x1bb, 340);
            this.chckBox051.Name = "chckBox051";
            this.chckBox051.Size = new Size(15, 14);
            this.chckBox051.TabIndex = 0xb6;
            this.chckBox051.Tag = "51";
            this.chckBox051.UseVisualStyleBackColor = true;
            this.chckBox051.Click += new EventHandler(this.chkBox_Click);
            this.chckBox039.AutoSize = true;
            this.chckBox039.Location = new Point(0x18c, 340);
            this.chckBox039.Name = "chckBox039";
            this.chckBox039.Size = new Size(15, 14);
            this.chckBox039.TabIndex = 0xb5;
            this.chckBox039.Tag = "39";
            this.chckBox039.UseVisualStyleBackColor = true;
            this.chckBox039.Click += new EventHandler(this.chkBox_Click);
            this.chckBox027.AutoSize = true;
            this.chckBox027.Location = new Point(0x15d, 340);
            this.chckBox027.Name = "chckBox027";
            this.chckBox027.Size = new Size(15, 14);
            this.chckBox027.TabIndex = 180;
            this.chckBox027.Tag = "27";
            this.chckBox027.UseVisualStyleBackColor = true;
            this.chckBox027.Click += new EventHandler(this.chkBox_Click);
            this.labelJHGKH.AutoSize = true;
            this.labelJHGKH.Location = new Point(0x3f, 0x142);
            this.labelJHGKH.Name = "labelJHGKH";
            this.labelJHGKH.Size = new Size(0x41, 12);
            this.labelJHGKH.TabIndex = 0xb3;
            this.labelJHGKH.Text = "交货给客户";
            this.chckBox014.AutoSize = true;
            this.chckBox014.Location = new Point(0x12e, 320);
            this.chckBox014.Name = "chckBox014";
            this.chckBox014.Size = new Size(15, 14);
            this.chckBox014.TabIndex = 0xb2;
            this.chckBox014.Tag = "14";
            this.chckBox014.UseVisualStyleBackColor = true;
            this.chckBox014.Click += new EventHandler(this.chkBox_Click);
            this.chckBox050.AutoSize = true;
            this.chckBox050.Location = new Point(0x1bb, 320);
            this.chckBox050.Name = "chckBox050";
            this.chckBox050.Size = new Size(15, 14);
            this.chckBox050.TabIndex = 0xb1;
            this.chckBox050.Tag = "50";
            this.chckBox050.UseVisualStyleBackColor = true;
            this.chckBox050.Click += new EventHandler(this.chkBox_Click);
            this.chckBox038.AutoSize = true;
            this.chckBox038.Location = new Point(0x18c, 320);
            this.chckBox038.Name = "chckBox038";
            this.chckBox038.Size = new Size(15, 14);
            this.chckBox038.TabIndex = 0xb0;
            this.chckBox038.Tag = "38";
            this.chckBox038.UseVisualStyleBackColor = true;
            this.chckBox038.Click += new EventHandler(this.chkBox_Click);
            this.chckBox026.AutoSize = true;
            this.chckBox026.Location = new Point(0x15d, 320);
            this.chckBox026.Name = "chckBox026";
            this.chckBox026.Size = new Size(15, 14);
            this.chckBox026.TabIndex = 0xaf;
            this.chckBox026.Tag = "26";
            this.chckBox026.UseVisualStyleBackColor = true;
            this.chckBox026.Click += new EventHandler(this.chkBox_Click);
            this.labelGXYSK.AutoSize = true;
            this.labelGXYSK.Location = new Point(0x3f, 0x12e);
            this.labelGXYSK.Name = "labelGXYSK";
            this.labelGXYSK.Size = new Size(0x83, 12);
            this.labelGXYSK.TabIndex = 0xa9;
            this.labelGXYSK.Text = "更新应收款/应收款收现";
            this.chckBox013.AutoSize = true;
            this.chckBox013.Location = new Point(0x12e, 300);
            this.chckBox013.Name = "chckBox013";
            this.chckBox013.Size = new Size(15, 14);
            this.chckBox013.TabIndex = 0xa8;
            this.chckBox013.Tag = "13";
            this.chckBox013.UseVisualStyleBackColor = true;
            this.chckBox013.Click += new EventHandler(this.chkBox_Click);
            this.chckBox049.AutoSize = true;
            this.chckBox049.Location = new Point(0x1bb, 300);
            this.chckBox049.Name = "chckBox049";
            this.chckBox049.Size = new Size(15, 14);
            this.chckBox049.TabIndex = 0xa7;
            this.chckBox049.Tag = "49";
            this.chckBox049.UseVisualStyleBackColor = true;
            this.chckBox049.Click += new EventHandler(this.chkBox_Click);
            this.chckBox037.AutoSize = true;
            this.chckBox037.Location = new Point(0x18c, 300);
            this.chckBox037.Name = "chckBox037";
            this.chckBox037.Size = new Size(15, 14);
            this.chckBox037.TabIndex = 0xa6;
            this.chckBox037.Tag = "37";
            this.chckBox037.UseVisualStyleBackColor = true;
            this.chckBox037.Click += new EventHandler(this.chkBox_Click);
            this.chckBox025.AutoSize = true;
            this.chckBox025.Location = new Point(0x15d, 300);
            this.chckBox025.Name = "chckBox025";
            this.chckBox025.Size = new Size(15, 14);
            this.chckBox025.TabIndex = 0xa5;
            this.chckBox025.Tag = "25";
            this.chckBox025.UseVisualStyleBackColor = true;
            this.chckBox025.Click += new EventHandler(this.chkBox_Click);
            this.labelKSXDSC.AutoSize = true;
            this.labelKSXDSC.Location = new Point(0x3f, 0x11a);
            this.labelKSXDSC.Name = "labelKSXDSC";
            this.labelKSXDSC.Size = new Size(0x4d, 12);
            this.labelKSXDSC.TabIndex = 0xa4;
            this.labelKSXDSC.Text = "开始新的生产";
            this.chckBox012.AutoSize = true;
            this.chckBox012.Location = new Point(0x12e, 280);
            this.chckBox012.Name = "chckBox012";
            this.chckBox012.Size = new Size(15, 14);
            this.chckBox012.TabIndex = 0xa3;
            this.chckBox012.Tag = "12";
            this.chckBox012.UseVisualStyleBackColor = true;
            this.chckBox012.Click += new EventHandler(this.chkBox_Click);
            this.chckBox048.AutoSize = true;
            this.chckBox048.Location = new Point(0x1bb, 280);
            this.chckBox048.Name = "chckBox048";
            this.chckBox048.Size = new Size(15, 14);
            this.chckBox048.TabIndex = 0xa2;
            this.chckBox048.Tag = "48";
            this.chckBox048.UseVisualStyleBackColor = true;
            this.chckBox048.Click += new EventHandler(this.chkBox_Click);
            this.chckBox036.AutoSize = true;
            this.chckBox036.Location = new Point(0x18c, 280);
            this.chckBox036.Name = "chckBox036";
            this.chckBox036.Size = new Size(15, 14);
            this.chckBox036.TabIndex = 0xa1;
            this.chckBox036.Tag = "36";
            this.chckBox036.UseVisualStyleBackColor = true;
            this.chckBox036.Click += new EventHandler(this.chkBox_Click);
            this.chckBox024.AutoSize = true;
            this.chckBox024.Location = new Point(0x15d, 280);
            this.chckBox024.Name = "chckBox024";
            this.chckBox024.Size = new Size(15, 14);
            this.chckBox024.TabIndex = 160;
            this.chckBox024.Tag = "24";
            this.chckBox024.UseVisualStyleBackColor = true;
            this.chckBox024.Click += new EventHandler(this.chkBox_Click);
            this.chckBox010.AutoSize = true;
            this.chckBox010.Location = new Point(0x12e, 240);
            this.chckBox010.Name = "chckBox010";
            this.chckBox010.Size = new Size(15, 14);
            this.chckBox010.TabIndex = 0x9f;
            this.chckBox010.Tag = "10";
            this.chckBox010.UseVisualStyleBackColor = true;
            this.chckBox010.Click += new EventHandler(this.chkBox_Click);
            this.chckBox046.AutoSize = true;
            this.chckBox046.Location = new Point(0x1bb, 240);
            this.chckBox046.Name = "chckBox046";
            this.chckBox046.Size = new Size(15, 14);
            this.chckBox046.TabIndex = 0x9e;
            this.chckBox046.Tag = "46";
            this.chckBox046.UseVisualStyleBackColor = true;
            this.chckBox046.Click += new EventHandler(this.chkBox_Click);
            this.chckBox034.AutoSize = true;
            this.chckBox034.Location = new Point(0x18c, 240);
            this.chckBox034.Name = "chckBox034";
            this.chckBox034.Size = new Size(15, 14);
            this.chckBox034.TabIndex = 0x9d;
            this.chckBox034.Tag = "34";
            this.chckBox034.UseVisualStyleBackColor = true;
            this.chckBox034.Click += new EventHandler(this.chkBox_Click);
            this.chckBox022.AutoSize = true;
            this.chckBox022.Location = new Point(0x15d, 240);
            this.chckBox022.Name = "chckBox022";
            this.chckBox022.Size = new Size(15, 14);
            this.chckBox022.TabIndex = 0x9c;
            this.chckBox022.Tag = "22";
            this.chckBox022.UseVisualStyleBackColor = true;
            this.chckBox022.Click += new EventHandler(this.chkBox_Click);
            this.labelTZXSCX.AutoSize = true;
            this.labelTZXSCX.Location = new Point(0x3f, 260);
            this.labelTZXSCX.Name = "labelTZXSCX";
            this.labelTZXSCX.Size = new Size(0xd1, 12);
            this.labelTZXSCX.TabIndex = 0x9b;
            this.labelTZXSCX.Text = "投资新生产线/再投生产线/生产线转产";
            this.chckBox009.AutoSize = true;
            this.chckBox009.Location = new Point(0x12e, 220);
            this.chckBox009.Name = "chckBox009";
            this.chckBox009.Size = new Size(15, 14);
            this.chckBox009.TabIndex = 0x9a;
            this.chckBox009.Tag = "9";
            this.chckBox009.UseVisualStyleBackColor = true;
            this.chckBox009.Click += new EventHandler(this.chkBox_Click);
            this.chckBox045.AutoSize = true;
            this.chckBox045.Location = new Point(0x1bb, 220);
            this.chckBox045.Name = "chckBox045";
            this.chckBox045.Size = new Size(15, 14);
            this.chckBox045.TabIndex = 0x99;
            this.chckBox045.Tag = "45";
            this.chckBox045.UseVisualStyleBackColor = true;
            this.chckBox045.Click += new EventHandler(this.chkBox_Click);
            this.chckBox033.AutoSize = true;
            this.chckBox033.Location = new Point(0x18c, 220);
            this.chckBox033.Name = "chckBox033";
            this.chckBox033.Size = new Size(15, 14);
            this.chckBox033.TabIndex = 0x98;
            this.chckBox033.Tag = "33";
            this.chckBox033.UseVisualStyleBackColor = true;
            this.chckBox033.Click += new EventHandler(this.chkBox_Click);
            this.chckBox021.AutoSize = true;
            this.chckBox021.Location = new Point(0x15d, 220);
            this.chckBox021.Name = "chckBox021";
            this.chckBox021.Size = new Size(15, 14);
            this.chckBox021.TabIndex = 0x97;
            this.chckBox021.Tag = "21";
            this.chckBox021.UseVisualStyleBackColor = true;
            this.chckBox021.Click += new EventHandler(this.chkBox_Click);
            this.labelGXSC.AutoSize = true;
            this.labelGXSC.Location = new Point(0x3f, 0xde);
            this.labelGXSC.Name = "labelGXSC";
            this.labelGXSC.Size = new Size(0x6b, 12);
            this.labelGXSC.TabIndex = 150;
            this.labelGXSC.Text = "更新生产/完工入库";
            this.chckBox008.AutoSize = true;
            this.chckBox008.Location = new Point(0x12e, 200);
            this.chckBox008.Name = "chckBox008";
            this.chckBox008.Size = new Size(15, 14);
            this.chckBox008.TabIndex = 0x95;
            this.chckBox008.Tag = "8";
            this.chckBox008.UseVisualStyleBackColor = true;
            this.chckBox008.Click += new EventHandler(this.chkBox_Click);
            this.chckBox044.AutoSize = true;
            this.chckBox044.Location = new Point(0x1bb, 200);
            this.chckBox044.Name = "chckBox044";
            this.chckBox044.Size = new Size(15, 14);
            this.chckBox044.TabIndex = 0x94;
            this.chckBox044.Tag = "44";
            this.chckBox044.UseVisualStyleBackColor = true;
            this.chckBox044.Click += new EventHandler(this.chkBox_Click);
            this.chckBox032.AutoSize = true;
            this.chckBox032.Location = new Point(0x18c, 200);
            this.chckBox032.Name = "chckBox032";
            this.chckBox032.Size = new Size(15, 14);
            this.chckBox032.TabIndex = 0x93;
            this.chckBox032.Tag = "32";
            this.chckBox032.UseVisualStyleBackColor = true;
            this.chckBox032.Click += new EventHandler(this.chkBox_Click);
            this.chckBox020.AutoSize = true;
            this.chckBox020.Location = new Point(0x15d, 200);
            this.chckBox020.Name = "chckBox020";
            this.chckBox020.Size = new Size(15, 14);
            this.chckBox020.TabIndex = 0x92;
            this.chckBox020.Tag = "20";
            this.chckBox020.UseVisualStyleBackColor = true;
            this.chckBox020.Click += new EventHandler(this.chkBox_Click);
            this.labelXYLDD.AutoSize = true;
            this.labelXYLDD.Location = new Point(0x3f, 0xca);
            this.labelXYLDD.Name = "labelXYLDD";
            this.labelXYLDD.Size = new Size(0x41, 12);
            this.labelXYLDD.TabIndex = 0x91;
            this.labelXYLDD.Text = "下原料订单";
            this.chckBox007.AutoSize = true;
            this.chckBox007.Location = new Point(0x12e, 180);
            this.chckBox007.Name = "chckBox007";
            this.chckBox007.Size = new Size(15, 14);
            this.chckBox007.TabIndex = 0x90;
            this.chckBox007.Tag = "7";
            this.chckBox007.UseVisualStyleBackColor = true;
            this.chckBox007.Click += new EventHandler(this.chkBox_Click);
            this.chckBox043.AutoSize = true;
            this.chckBox043.Location = new Point(0x1bb, 180);
            this.chckBox043.Name = "chckBox043";
            this.chckBox043.Size = new Size(15, 14);
            this.chckBox043.TabIndex = 0x8f;
            this.chckBox043.Tag = "43";
            this.chckBox043.UseVisualStyleBackColor = true;
            this.chckBox043.Click += new EventHandler(this.chkBox_Click);
            this.chckBox031.AutoSize = true;
            this.chckBox031.Location = new Point(0x18c, 180);
            this.chckBox031.Name = "chckBox031";
            this.chckBox031.Size = new Size(15, 14);
            this.chckBox031.TabIndex = 0x8e;
            this.chckBox031.Tag = "31";
            this.chckBox031.UseVisualStyleBackColor = true;
            this.chckBox031.Click += new EventHandler(this.chkBox_Click);
            this.chckBox019.AutoSize = true;
            this.chckBox019.Location = new Point(0x15d, 180);
            this.chckBox019.Name = "chckBox019";
            this.chckBox019.Size = new Size(15, 14);
            this.chckBox019.TabIndex = 0x8d;
            this.chckBox019.Tag = "19";
            this.chckBox019.UseVisualStyleBackColor = true;
            this.chckBox019.Click += new EventHandler(this.chkBox_Click);
            this.labelYCLRK.AutoSize = true;
            this.labelYCLRK.Location = new Point(0x3f, 0xb6);
            this.labelYCLRK.Name = "labelYCLRK";
            this.labelYCLRK.Size = new Size(0x8f, 12);
            this.labelYCLRK.TabIndex = 140;
            this.labelYCLRK.Text = "原材料入库/更新原料订单";
            this.chckBox006.AutoSize = true;
            this.chckBox006.Location = new Point(0x12e, 160);
            this.chckBox006.Name = "chckBox006";
            this.chckBox006.Size = new Size(15, 14);
            this.chckBox006.TabIndex = 0x8b;
            this.chckBox006.Tag = "6";
            this.chckBox006.UseVisualStyleBackColor = true;
            this.chckBox006.Click += new EventHandler(this.chkBox_Click);
            this.chckBox042.AutoSize = true;
            this.chckBox042.Location = new Point(0x1bb, 160);
            this.chckBox042.Name = "chckBox042";
            this.chckBox042.Size = new Size(15, 14);
            this.chckBox042.TabIndex = 0x8a;
            this.chckBox042.Tag = "42";
            this.chckBox042.UseVisualStyleBackColor = true;
            this.chckBox042.Click += new EventHandler(this.chkBox_Click);
            this.chckBox030.AutoSize = true;
            this.chckBox030.Location = new Point(0x18c, 160);
            this.chckBox030.Name = "chckBox030";
            this.chckBox030.Size = new Size(15, 14);
            this.chckBox030.TabIndex = 0x89;
            this.chckBox030.Tag = "30";
            this.chckBox030.UseVisualStyleBackColor = true;
            this.chckBox030.Click += new EventHandler(this.chkBox_Click);
            this.chckBox018.AutoSize = true;
            this.chckBox018.Location = new Point(0x15d, 160);
            this.chckBox018.Name = "chckBox018";
            this.chckBox018.Size = new Size(15, 14);
            this.chckBox018.TabIndex = 0x88;
            this.chckBox018.Tag = "18";
            this.chckBox018.UseVisualStyleBackColor = true;
            this.chckBox018.Click += new EventHandler(this.chkBox_Click);
            this.labelGXDQDK.AutoSize = true;
            this.labelGXDQDK.Location = new Point(0x3f, 0xa2);
            this.labelGXDQDK.Name = "labelGXDQDK";
            this.labelGXDQDK.Size = new Size(0xd1, 12);
            this.labelGXDQDK.TabIndex = 0x87;
            this.labelGXDQDK.Text = "更新短期贷款/支付利息/获得新的贷款";
            this.labelZFYFS.AutoSize = true;
            this.labelZFYFS.Location = new Point(0x3f, 0x59);
            this.labelZFYFS.Name = "labelZFYFS";
            this.labelZFYFS.Size = new Size(0x41, 12);
            this.labelZFYFS.TabIndex = 0x86;
            this.labelZFYFS.Text = "支付应付税";
            this.labelZDXNDJH.AutoSize = true;
            this.labelZDXNDJH.Location = new Point(0x3f, 0x45);
            this.labelZDXNDJH.Name = "labelZDXNDJH";
            this.labelZDXNDJH.Size = new Size(0x59, 12);
            this.labelZDXNDJH.TabIndex = 0x85;
            this.labelZDXNDJH.Text = "制定新年度计划";
            this.labelCJDHH.AutoSize = true;
            this.labelCJDHH.Location = new Point(0x3f, 0x31);
            this.labelCJDHH.Name = "labelCJDHH";
            this.labelCJDHH.Size = new Size(0x8f, 12);
            this.labelCJDHH.TabIndex = 0x84;
            this.labelCJDHH.Text = "参加订货会/登记销售订单";
            this.chckBox004.AutoSize = true;
            this.chckBox004.Location = new Point(0x12e, 0x57);
            this.chckBox004.Name = "chckBox004";
            this.chckBox004.Size = new Size(15, 14);
            this.chckBox004.TabIndex = 0x7e;
            this.chckBox004.Tag = "4";
            this.chckBox004.UseVisualStyleBackColor = true;
            this.chckBox004.Click += new EventHandler(this.chkBox_Click);
            this.chckBox003.AutoSize = true;
            this.chckBox003.Location = new Point(0x12e, 0x43);
            this.chckBox003.Name = "chckBox003";
            this.chckBox003.Size = new Size(15, 14);
            this.chckBox003.TabIndex = 0x7d;
            this.chckBox003.Tag = "3";
            this.chckBox003.UseVisualStyleBackColor = true;
            this.chckBox003.Click += new EventHandler(this.chkBox_Click);
            this.chckBox002.AutoSize = true;
            this.chckBox002.Location = new Point(0x12e, 0x2f);
            this.chckBox002.Name = "chckBox002";
            this.chckBox002.Size = new Size(15, 14);
            this.chckBox002.TabIndex = 0x7c;
            this.chckBox002.Tag = "2";
            this.chckBox002.UseVisualStyleBackColor = true;
            this.chckBox002.Click += new EventHandler(this.chkBox_Click);
            this.chckBox001.AutoSize = true;
            this.chckBox001.Location = new Point(0x12e, 0x1b);
            this.chckBox001.Name = "chckBox001";
            this.chckBox001.Size = new Size(15, 14);
            this.chckBox001.TabIndex = 0x7b;
            this.chckBox001.Tag = "1";
            this.chckBox001.UseVisualStyleBackColor = true;
            this.chckBox001.Click += new EventHandler(this.chkBox_Click);
            this.labelXNNDGHHY.AutoSize = true;
            this.labelXNNDGHHY.Location = new Point(0x3f, 0x1d);
            this.labelXNNDGHHY.Name = "labelXNNDGHHY";
            this.labelXNNDGHHY.Size = new Size(0x59, 12);
            this.labelXNNDGHHY.TabIndex = 0x83;
            this.labelXNNDGHHY.Text = "新年度规划会议";
            this.label4.AutoSize = true;
            this.label4.Location = new Point(0x1af, 0x6f);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x29, 12);
            this.label4.TabIndex = 130;
            this.label4.Text = "四季度";
            this.label3.AutoSize = true;
            this.label3.Location = new Point(0x17f, 0x6f);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x29, 12);
            this.label3.TabIndex = 0x81;
            this.label3.Text = "三季度";
            this.label2.AutoSize = true;
            this.label2.Location = new Point(0x150, 0x6f);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x29, 12);
            this.label2.TabIndex = 0x80;
            this.label2.Text = "二季度";
            this.labelJD1.AutoSize = true;
            this.labelJD1.Location = new Point(290, 0x6f);
            this.labelJD1.Name = "labelJD1";
            this.labelJD1.Size = new Size(0x29, 12);
            this.labelJD1.TabIndex = 0x7f;
            this.labelJD1.Text = "一季度";
            this.panel8.AutoScroll = true;
            this.panel8.Controls.Add(this.groupBox5);
            this.panel8.Controls.Add(this.groupBox4);
            this.panel8.Controls.Add(this.groupBox3);
            this.panel8.Controls.Add(this.groupBox2);
            this.panel8.Controls.Add(this.groupBox1);
            this.panel8.Dock = DockStyle.Left;
            this.panel8.Location = new Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new Size(0xf1, 0x206);
            this.panel8.TabIndex = 2;
            this.groupBox5.Controls.Add(this.labelActor);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.label18);
            this.groupBox5.Controls.Add(this.labelCompany);
            this.groupBox5.Controls.Add(this.label31);
            this.groupBox5.Controls.Add(this.labelRunningTime);
            this.groupBox5.Location = new Point(0x17, 9);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new Size(200, 0x55);
            this.groupBox5.TabIndex = 13;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "系统信息";
            this.labelActor.AutoSize = true;
            this.labelActor.Location = new Point(0x4d, 40);
            this.labelActor.Name = "labelActor";
            this.labelActor.Size = new Size(0x23, 12);
            this.labelActor.TabIndex = 15;
            this.labelActor.Text = "Actor";
            this.label6.AutoSize = true;
            this.label6.Location = new Point(0x12, 40);
            this.label6.Name = "label6";
            this.label6.Size = new Size(0x35, 12);
            this.label6.TabIndex = 14;
            this.label6.Text = "决策者：";
            this.label18.AutoSize = true;
            this.label18.Location = new Point(6, 20);
            this.label18.Name = "label18";
            this.label18.Size = new Size(0x41, 12);
            this.label18.TabIndex = 11;
            this.label18.Text = "公司名称：";
            this.labelCompany.AutoSize = true;
            this.labelCompany.Location = new Point(0x4d, 20);
            this.labelCompany.Name = "labelCompany";
            this.labelCompany.Size = new Size(0x2f, 12);
            this.labelCompany.TabIndex = 10;
            this.labelCompany.Text = "Company";
            this.label31.AutoSize = true;
            this.label31.Location = new Point(6, 60);
            this.label31.Name = "label31";
            this.label31.Size = new Size(0x41, 12);
            this.label31.TabIndex = 9;
            this.label31.Text = "当前时间：";
            this.labelRunningTime.AutoSize = true;
            this.labelRunningTime.ForeColor = SystemColors.ControlText;
            this.labelRunningTime.Location = new Point(0x4d, 60);
            this.labelRunningTime.Name = "labelRunningTime";
            this.labelRunningTime.Size = new Size(0x59, 12);
            this.labelRunningTime.TabIndex = 8;
            this.labelRunningTime.Text = "第一年第一季度";
            this.groupBox4.Controls.Add(this.labelP4Capacity);
            this.groupBox4.Controls.Add(this.labelP3Capacity);
            this.groupBox4.Controls.Add(this.labelP2Capacity);
            this.groupBox4.Controls.Add(this.labelP1Capacity);
            this.groupBox4.Location = new Point(0x17, 230);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new Size(200, 100);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "生产资格";
            this.labelP4Capacity.AutoSize = true;
            this.labelP4Capacity.Enabled = false;
            this.labelP4Capacity.Location = new Point(6, 80);
            this.labelP4Capacity.Name = "labelP4Capacity";
            this.labelP4Capacity.Size = new Size(0x65, 12);
            this.labelP4Capacity.TabIndex = 4;
            this.labelP4Capacity.Text = "已具备P4生产能力";
            this.labelP3Capacity.AutoSize = true;
            this.labelP3Capacity.Enabled = false;
            this.labelP3Capacity.Location = new Point(6, 60);
            this.labelP3Capacity.Name = "labelP3Capacity";
            this.labelP3Capacity.Size = new Size(0x65, 12);
            this.labelP3Capacity.TabIndex = 3;
            this.labelP3Capacity.Text = "已具备P3生产能力";
            this.labelP2Capacity.AutoSize = true;
            this.labelP2Capacity.Enabled = false;
            this.labelP2Capacity.Location = new Point(6, 40);
            this.labelP2Capacity.Name = "labelP2Capacity";
            this.labelP2Capacity.Size = new Size(0x65, 12);
            this.labelP2Capacity.TabIndex = 2;
            this.labelP2Capacity.Text = "已具备P2生产能力";
            this.labelP1Capacity.AutoSize = true;
            this.labelP1Capacity.Location = new Point(6, 0x16);
            this.labelP1Capacity.Name = "labelP1Capacity";
            this.labelP1Capacity.Size = new Size(0x65, 12);
            this.labelP1Capacity.TabIndex = 1;
            this.labelP1Capacity.Text = "已具备P1生产能力";
            this.groupBox3.Controls.Add(this.labelCertified14000);
            this.groupBox3.Controls.Add(this.labelCertified9000);
            this.groupBox3.Location = new Point(0x17, 0x1ab);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new Size(200, 0x3f);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "ISO认证";
            this.labelCertified14000.AutoSize = true;
            this.labelCertified14000.Enabled = false;
            this.labelCertified14000.Location = new Point(6, 40);
            this.labelCertified14000.Name = "labelCertified14000";
            this.labelCertified14000.Size = new Size(0x71, 12);
            this.labelCertified14000.TabIndex = 3;
            this.labelCertified14000.Text = "已取得ISO14000认证";
            this.labelCertified9000.AutoSize = true;
            this.labelCertified9000.Enabled = false;
            this.labelCertified9000.Location = new Point(6, 20);
            this.labelCertified9000.Name = "labelCertified9000";
            this.labelCertified9000.Size = new Size(0x6b, 12);
            this.labelCertified9000.TabIndex = 2;
            this.labelCertified9000.Text = "已取得ISO9000认证";
            this.groupBox2.Controls.Add(this.labelEnterInternationalMarket);
            this.groupBox2.Controls.Add(this.labelEnterAsiaMarket);
            this.groupBox2.Controls.Add(this.labelEnterDomesticMarket);
            this.groupBox2.Controls.Add(this.labelEnterRegionalMarket);
            this.groupBox2.Controls.Add(this.labelEnterLocalMarket);
            this.groupBox2.Location = new Point(20, 0x150);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(200, 0x55);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "市场准入";
            this.labelEnterInternationalMarket.AutoSize = true;
            this.labelEnterInternationalMarket.Enabled = false;
            this.labelEnterInternationalMarket.Location = new Point(6, 0x3e);
            this.labelEnterInternationalMarket.Name = "labelEnterInternationalMarket";
            this.labelEnterInternationalMarket.Size = new Size(0x59, 12);
            this.labelEnterInternationalMarket.TabIndex = 4;
            this.labelEnterInternationalMarket.Text = "已进入国际市场";
            this.labelEnterAsiaMarket.AutoSize = true;
            this.labelEnterAsiaMarket.Enabled = false;
            this.labelEnterAsiaMarket.Location = new Point(0x69, 0x2a);
            this.labelEnterAsiaMarket.Name = "labelEnterAsiaMarket";
            this.labelEnterAsiaMarket.Size = new Size(0x59, 12);
            this.labelEnterAsiaMarket.TabIndex = 3;
            this.labelEnterAsiaMarket.Text = "已进入亚洲市场";
            this.labelEnterDomesticMarket.AutoSize = true;
            this.labelEnterDomesticMarket.Enabled = false;
            this.labelEnterDomesticMarket.Location = new Point(6, 0x2a);
            this.labelEnterDomesticMarket.Name = "labelEnterDomesticMarket";
            this.labelEnterDomesticMarket.Size = new Size(0x59, 12);
            this.labelEnterDomesticMarket.TabIndex = 2;
            this.labelEnterDomesticMarket.Text = "已进入国内市场";
            this.labelEnterRegionalMarket.AutoSize = true;
            this.labelEnterRegionalMarket.Enabled = false;
            this.labelEnterRegionalMarket.Location = new Point(0x69, 0x16);
            this.labelEnterRegionalMarket.Name = "labelEnterRegionalMarket";
            this.labelEnterRegionalMarket.Size = new Size(0x59, 12);
            this.labelEnterRegionalMarket.TabIndex = 1;
            this.labelEnterRegionalMarket.Text = "已进入区域市场";
            this.labelEnterLocalMarket.AutoSize = true;
            this.labelEnterLocalMarket.Location = new Point(6, 0x16);
            this.labelEnterLocalMarket.Name = "labelEnterLocalMarket";
            this.labelEnterLocalMarket.Size = new Size(0x59, 12);
            this.labelEnterLocalMarket.TabIndex = 0;
            this.labelEnterLocalMarket.Text = "已进入本地市场";
            this.groupBox1.Controls.Add(this.labelLoanSharking);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.labelReceivableAccounts);
            this.groupBox1.Controls.Add(this.labelShortTermLoans);
            this.groupBox1.Controls.Add(this.labelLongTermLoans);
            this.groupBox1.Controls.Add(this.label51);
            this.groupBox1.Controls.Add(this.label49);
            this.groupBox1.Controls.Add(this.label48);
            this.groupBox1.Controls.Add(this.labelCurrentCash);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Location = new Point(0x17, 100);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(200, 0x7c);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "财务信息";
            this.labelLoanSharking.AutoSize = true;
            this.labelLoanSharking.Location = new Point(0x4d, 100);
            this.labelLoanSharking.Name = "labelLoanSharking";
            this.labelLoanSharking.Size = new Size(0x11, 12);
            this.labelLoanSharking.TabIndex = 13;
            this.labelLoanSharking.Text = "0M";
            this.label5.AutoSize = true;
            this.label5.Location = new Point(6, 100);
            this.label5.Name = "label5";
            this.label5.Size = new Size(0x41, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "高利贷款：";
            this.labelReceivableAccounts.AutoSize = true;
            this.labelReceivableAccounts.Location = new Point(0x4d, 80);
            this.labelReceivableAccounts.Name = "labelReceivableAccounts";
            this.labelReceivableAccounts.Size = new Size(0x17, 12);
            this.labelReceivableAccounts.TabIndex = 11;
            this.labelReceivableAccounts.Text = "18M";
            this.labelShortTermLoans.AutoSize = true;
            this.labelShortTermLoans.Location = new Point(0x4d, 60);
            this.labelShortTermLoans.Name = "labelShortTermLoans";
            this.labelShortTermLoans.Size = new Size(0x11, 12);
            this.labelShortTermLoans.TabIndex = 10;
            this.labelShortTermLoans.Text = "0M";
            this.labelLongTermLoans.AutoSize = true;
            this.labelLongTermLoans.Location = new Point(0x4d, 40);
            this.labelLongTermLoans.Name = "labelLongTermLoans";
            this.labelLongTermLoans.Size = new Size(0x17, 12);
            this.labelLongTermLoans.TabIndex = 9;
            this.labelLongTermLoans.Text = "40M";
            this.label51.AutoSize = true;
            this.label51.Location = new Point(6, 80);
            this.label51.Name = "label51";
            this.label51.Size = new Size(0x41, 12);
            this.label51.TabIndex = 8;
            this.label51.Text = "应收帐款：";
            this.label49.AutoSize = true;
            this.label49.Location = new Point(6, 60);
            this.label49.Name = "label49";
            this.label49.Size = new Size(0x41, 12);
            this.label49.TabIndex = 6;
            this.label49.Text = "短期贷款：";
            this.label48.AutoSize = true;
            this.label48.Location = new Point(6, 40);
            this.label48.Name = "label48";
            this.label48.Size = new Size(0x41, 12);
            this.label48.TabIndex = 5;
            this.label48.Text = "长期贷款：";
            this.labelCurrentCash.AutoSize = true;
            this.labelCurrentCash.Location = new Point(0x4d, 20);
            this.labelCurrentCash.Name = "labelCurrentCash";
            this.labelCurrentCash.Size = new Size(0x17, 12);
            this.labelCurrentCash.TabIndex = 3;
            this.labelCurrentCash.Text = "20M";
            this.label20.AutoSize = true;
            this.label20.Location = new Point(6, 20);
            this.label20.Name = "label20";
            this.label20.Size = new Size(0x41, 12);
            this.label20.TabIndex = 2;
            this.label20.Text = "当前现金：";
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x318, 0x279);
            base.Controls.Add(this.panel4);
            base.Controls.Add(this.panel1);
            base.Icon = (Icon) manager.GetObject("$this.Icon");
            this.MaximumSize = new Size(800, 0x29b);
            this.MinimumSize = new Size(800, 100);
            base.Name = "frmMainControl";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "企业沙盘模拟决策人机对抗系统创业版1.1 --840599405@qq.com";
            base.Load += new EventHandler(this.frmMainControl_Load);
            base.FormClosing += new FormClosingEventHandler(this.frmMainControl_FormClosing);
            this.panel1.ResumeLayout(false);
            this.tabPageSwitcher1.ResumeLayout(false);
            this.tabStripPage1.ResumeLayout(false);
            this.tabPanel5.ResumeLayout(false);
            this.tabPanel4.ResumeLayout(false);
            this.tabPanel3.ResumeLayout(false);
            this.tabStripPage2.ResumeLayout(false);
            this.tabPanel2.ResumeLayout(false);
            this.tabPanel1.ResumeLayout(false);
            this.tabStrip1.ResumeLayout(false);
            this.tabStrip1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            base.ResumeLayout(false);
        }

        private void InitTaskList()
        {
            this.chkBoxArry = new CheckBox[0x3b];
            this.chkBoxArry[1] = this.chckBox001;
            this.chkBoxArry[2] = this.chckBox002;
            this.chkBoxArry[3] = this.chckBox003;
            this.chkBoxArry[4] = this.chckBox004;
            this.chkBoxArry[5] = this.chckBox005;
            this.chkBoxArry[6] = this.chckBox006;
            this.chkBoxArry[7] = this.chckBox007;
            this.chkBoxArry[8] = this.chckBox008;
            this.chkBoxArry[9] = this.chckBox009;
            this.chkBoxArry[10] = this.chckBox010;
            this.chkBoxArry[11] = this.chckBox011;
            this.chkBoxArry[12] = this.chckBox012;
            this.chkBoxArry[13] = this.chckBox013;
            this.chkBoxArry[14] = this.chckBox014;
            this.chkBoxArry[15] = this.chckBox015;
            this.chkBoxArry[0x10] = this.chckBox016;
            this.chkBoxArry[0x11] = this.chckBox017;
            this.chkBoxArry[0x12] = this.chckBox018;
            this.chkBoxArry[0x13] = this.chckBox019;
            this.chkBoxArry[20] = this.chckBox020;
            this.chkBoxArry[0x15] = this.chckBox021;
            this.chkBoxArry[0x16] = this.chckBox022;
            this.chkBoxArry[0x17] = this.chckBox023;
            this.chkBoxArry[0x18] = this.chckBox024;
            this.chkBoxArry[0x19] = this.chckBox025;
            this.chkBoxArry[0x1a] = this.chckBox026;
            this.chkBoxArry[0x1b] = this.chckBox027;
            this.chkBoxArry[0x1c] = this.chckBox028;
            this.chkBoxArry[0x1d] = this.chckBox029;
            this.chkBoxArry[30] = this.chckBox030;
            this.chkBoxArry[0x1f] = this.chckBox031;
            this.chkBoxArry[0x20] = this.chckBox032;
            this.chkBoxArry[0x21] = this.chckBox033;
            this.chkBoxArry[0x22] = this.chckBox034;
            this.chkBoxArry[0x23] = this.chckBox035;
            this.chkBoxArry[0x24] = this.chckBox036;
            this.chkBoxArry[0x25] = this.chckBox037;
            this.chkBoxArry[0x26] = this.chckBox038;
            this.chkBoxArry[0x27] = this.chckBox039;
            this.chkBoxArry[40] = this.chckBox040;
            this.chkBoxArry[0x29] = this.chckBox041;
            this.chkBoxArry[0x2a] = this.chckBox042;
            this.chkBoxArry[0x2b] = this.chckBox043;
            this.chkBoxArry[0x2c] = this.chckBox044;
            this.chkBoxArry[0x2d] = this.chckBox045;
            this.chkBoxArry[0x2e] = this.chckBox046;
            this.chkBoxArry[0x2f] = this.chckBox047;
            this.chkBoxArry[0x30] = this.chckBox048;
            this.chkBoxArry[0x31] = this.chckBox049;
            this.chkBoxArry[50] = this.chckBox050;
            this.chkBoxArry[0x33] = this.chckBox051;
            this.chkBoxArry[0x34] = this.chckBox052;
            this.chkBoxArry[0x35] = this.chckBox053;
            this.chkBoxArry[0x36] = this.chckBox054;
            this.chkBoxArry[0x37] = this.chckBox055;
            this.chkBoxArry[0x38] = this.chckBox056;
            this.chkBoxArry[0x39] = this.chckBox057;
            this.chkBoxArry[0x3a] = this.chckBox058;
            for (int i = 1; i < this.chkBoxArry.Length; i++)
            {
                this.chkBoxArry[i].Checked = false;
                this.chkBoxArry[i].Enabled = false;
            }
            this.chkBoxArry[1].Enabled = true;
        }

        private void ribbonButton_Click(object sender, EventArgs e)
        {
            int num2 = Convert.ToInt16(((RibbonButton) sender).Tag);
            switch (num2)
            {
                case 11:
                    new frmShowTableInfor().ShowDialog();
                    return;

                case 12:
                    new frmShowBusinessResult().ShowDialog();
                    return;

                case 13:
                    new frmShowBusinessPerformanceRanking().ShowDialog();
                    return;

                case 14:
                    new frmShowheroeslist().ShowDialog();
                    return;

                case 15:
                case 0x10:
                case 0x11:
                case 0x12:
                case 0x13:
                case 20:
                    break;

                case 0x15:
                    if (DialogResult.OK != new frmDiscount().ShowDialog())
                    {
                        break;
                    }
                    this.InitActorInfor();
                    return;

                case 0x16:
                    if (DialogResult.OK != new frmByePlant().ShowDialog())
                    {
                        break;
                    }
                    this.InitActorInfor();
                    return;

                case 0x17:
                    if (DialogResult.OK != new frmSalePlant().ShowDialog())
                    {
                        break;
                    }
                    this.InitActorInfor();
                    return;

                default:
                    switch (num2)
                    {
                        case 0x1f:
                            base.Close();
                            return;

                        case 0x20:
                            new frmHelp().ShowDialog();
                            return;

                        case 0x21:
                            if (new frmRegistration().ShowDialog() == DialogResult.OK)
                            {
                                bool flag = false;
                                this.Text = TGlobals.ApplicationText;
                                int index = 1;
                                while (true)
                                {
                                    if (index < this.chkBoxArry.Length)
                                    {
                                        if (!this.chkBoxArry[index].Enabled)
                                        {
                                            index++;
                                            continue;
                                        }
                                        flag = true;
                                    }
                                    if (!flag && ((TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.CurrentCash >= 0) && (TGlobals.currentActor.CurrBusinessConditions.BalanceSheet.OwnerRight >= 0)))
                                    {
                                        this.chkBoxArry[1].Enabled = true;
                                    }
                                    break;
                                }
                            }
                            break;

                        default:
                            return;
                    }
                    break;
            }
        }

        public void SetBase(int R, int G, int B, Color HaloColor)
        {
            base.SuspendLayout();
            foreach (Control control in this.panel1.Controls)
            {
                if (ReferenceEquals(typeof(TabStrip), control.GetType()))
                {
                    ((TabStripProfessionalRenderer) ((TabStrip) control).Renderer).HaloColor = HaloColor;
                    ((TabStripProfessionalRenderer) ((TabStrip) control).Renderer).BaseColor = Color.FromArgb(R + 4, G + 3, B + 3);
                    int num = 0;
                    while (true)
                    {
                        if (num >= ((TabStrip) control).Items.Count)
                        {
                            control.BackColor = Color.FromArgb(R - 0x18, G - 8, B + 12);
                            break;
                        }
                        Tab tab = (Tab) ((TabStrip) control).Items[num];
                        Color color = Color.FromArgb(R, G, B);
                        if (color.GetBrightness() < 0.5)
                        {
                            try
                            {
                                tab.ForeColor = Color.FromArgb(R + 0x4c, G + 0x47, B + 0x42);
                            }
                            catch
                            {
                                tab.ForeColor = Color.FromArgb(250, 250, 250);
                            }
                        }
                        else
                        {
                            try
                            {
                                tab.ForeColor = Color.FromArgb(R - 0x60, G - 0x5b, B - 0x56);
                            }
                            catch
                            {
                                tab.ForeColor = Color.FromArgb(10, 10, 10);
                            }
                        }
                        num++;
                    }
                }
                if (ReferenceEquals(typeof(TabPageSwitcher), control.GetType()))
                {
                    control.BackColor = Color.FromArgb(R - 0x18, G - 8, B + 12);
                    foreach (Control control2 in control.Controls)
                    {
                        if (ReferenceEquals(typeof(TabStripPage), control2.GetType()))
                        {
                            ((TabStripPage) control2).BaseColor = Color.FromArgb(R, G, B);
                            ((TabStripPage) control2).BaseColorOn = Color.FromArgb(R, G, B);
                            foreach (Control control3 in control2.Controls)
                            {
                                if (ReferenceEquals(typeof(TabPanel), control3.GetType()))
                                {
                                    if (Color.FromArgb(R, G, B).GetBrightness() < 0.5)
                                    {
                                        try
                                        {
                                            control3.ForeColor = Color.FromArgb(R + 0x4c, G + 0x47, B + 0x42);
                                        }
                                        catch
                                        {
                                            control3.ForeColor = Color.FromArgb(250, 250, 250);
                                        }
                                    }
                                    else
                                    {
                                        try
                                        {
                                            control3.ForeColor = Color.FromArgb(R - 0x60, G - 0x5b, B - 0x56);
                                        }
                                        catch
                                        {
                                            control3.ForeColor = Color.FromArgb(10, 10, 10);
                                        }
                                    }
                                    ((TabPanel) control3).BaseColor = Color.FromArgb(R, G, B);
                                    ((TabPanel) control3).BaseColorOn = Color.FromArgb(R + 0x10, G + 11, B + 6);
                                    foreach (Control control4 in control3.Controls)
                                    {
                                        if (ReferenceEquals(typeof(RibbonButton), control4.GetType()))
                                        {
                                            ((RibbonButton) control4).InfoColor = Color.FromArgb(R, G, B);
                                            RibbonButton button = (RibbonButton) control4;
                                            if (Color.FromArgb(R, G, B).GetBrightness() < 0.5)
                                            {
                                                try
                                                {
                                                    button.ForeColor = Color.FromArgb(R + 0x4c, G + 0x47, B + 0x42);
                                                }
                                                catch
                                                {
                                                    button.ForeColor = Color.FromArgb(250, 250, 250);
                                                }
                                                continue;
                                            }
                                            try
                                            {
                                                button.ForeColor = Color.FromArgb(R - 0x60, G - 0x5b, B - 0x56);
                                            }
                                            catch
                                            {
                                                button.ForeColor = Color.FromArgb(10, 10, 10);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            base.ResumeLayout(false);
        }

        public void SetStyle(string Name)
        {
            Color white = Color.White;
            string key = Name;
            if (key != null)
            {
                int num;
                if (<PrivateImplementationDetails>{FAF84281-B764-49BB-8026-1DA8F9FEA525}.$$method0x6000098-1 == null)
                {
                    Dictionary<string, int> dictionary1 = new Dictionary<string, int>(10);
                    dictionary1.Add("Dark", 0);
                    dictionary1.Add("Nature", 1);
                    dictionary1.Add("Dawn", 2);
                    dictionary1.Add("Corn", 3);
                    dictionary1.Add("Chocolate", 4);
                    dictionary1.Add("Navy", 5);
                    dictionary1.Add("Ice", 6);
                    dictionary1.Add("Vanilla", 7);
                    dictionary1.Add("Canela", 8);
                    dictionary1.Add("Cake", 9);
                    <PrivateImplementationDetails>{FAF84281-B764-49BB-8026-1DA8F9FEA525}.$$method0x6000098-1 = dictionary1;
                }
                if (<PrivateImplementationDetails>{FAF84281-B764-49BB-8026-1DA8F9FEA525}.$$method0x6000098-1.TryGetValue(key, out num))
                {
                    switch (num)
                    {
                        case 0:
                            this.BackColor = Color.FromArgb(0x58, 0x4d, 0x45);
                            white = Color.FromArgb(200, 200, 200);
                            this.SetBase(0x57, 0x3d, 0x35, white);
                            return;

                        case 1:
                            this.BackColor = Color.FromArgb(0x4e, 0x7f, 0x34);
                            white = Color.FromArgb(0xfe, 0xd1, 0x5e);
                            this.SetBase(0x49, 0x76, 0x2e, white);
                            return;

                        case 2:
                            this.BackColor = Color.FromArgb(0xb1, 0x6c, 0x2d);
                            this.SetBase(0xac, 0x63, 0x27, Color.FromArgb(0xfe, 0xd1, 0x5e));
                            return;

                        case 3:
                            this.BackColor = Color.FromArgb(230, 0xc1, 0x6a);
                            this.SetBase(0xe1, 0xb8, 100, Color.FromArgb(0xbf, 0xdb, 0xff));
                            return;

                        case 4:
                            this.BackColor = Color.FromArgb(0x57, 0x36, 0x22);
                            this.SetBase(0x52, 0x2d, 0x1c, Color.FromArgb(0xe8, 80, 90));
                            return;

                        case 5:
                            this.BackColor = Color.FromArgb(0x58, 0x79, 0xa9);
                            this.SetBase(0x54, 0x70, 0xa3, Color.FromArgb(0xfe, 0xd1, 0x5e));
                            return;

                        case 6:
                            this.BackColor = Color.FromArgb(0xeb, 0xf3, 0xec);
                            this.SetBase(0xe4, 0xea, 230, Color.FromArgb(0xfe, 0xd1, 0x5e));
                            return;

                        case 7:
                            this.BackColor = Color.FromArgb(0xe9, 0xf3, 0xd5);
                            this.SetBase(0xe4, 0xea, 0xcf, Color.FromArgb(0xfe, 0xd1, 0x5e));
                            return;

                        case 8:
                            this.BackColor = Color.FromArgb(0xeb, 0xf3, 0xec);
                            this.SetBase(0xe4, 0xd9, 0xbf, Color.FromArgb(0xfe, 0xd1, 0x5e));
                            return;

                        case 9:
                            this.BackColor = Color.FromArgb(0xeb, 0xd5, 0xc5);
                            this.SetBase(0xe4, 0xcc, 0xc6, Color.FromArgb(0xfe, 0xd1, 0x5e));
                            return;

                        default:
                            break;
                    }
                }
            }
            this.BackColor = Color.FromArgb(0xeb, 0xf3, 0xec);
            this.SetBase(0xd7, 0xe3, 0xf2, Color.FromArgb(0xfe, 0xd1, 0x5e));
        }

        private void XJTX()
        {
            if (TGlobals.currentActor.CurrBusinessConditions.OperatingSheet.CurrentCash < 5)
            {
                new frmArm().ShowDialog();
            }
        }
    }
}

