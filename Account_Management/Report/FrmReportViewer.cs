using Account_Management.Class;
using BLL;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Data;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Account_Management.Report
{
    public partial class FrmReportViewer : DevExpress.XtraEditors.XtraForm
    {
        Validation Val = new Validation();
        private DataSet _DS = new DataSet();

        PrinterSettings printerSettings = new PrinterSettings();
        public DataSet DS
        {
            get { return _DS; }
            set { _DS = value; }
        }
        public string mStrRefreshFormType = "";

        public enum ReportFolder
        {

            NONE = 0,
            JANGED = 1,
            EMP = 2,
            PURCHASE_ROUGH = 3,
            MIX = 4,
            HRACTS = 5,
            HR_REPORT = 6,
            ACCOUNT = 7,
            SALE_INVOICE = 8,
            SALE_RETURN = 9
        }

        public string RepHead = string.Empty;
        public string RepName = string.Empty;
        public string PROCESS = string.Empty;
        public string RepPara = string.Empty;
        public string RepType = string.Empty;

        public string AddressType = string.Empty;

        public string GroupBy = string.Empty;
        public string FromDate = string.Empty;
        public string ToDate = string.Empty;

        public string Address = string.Empty;
        public string PhoneNo = string.Empty;

        public double DollarRate = 0.000;
        public double ProcessCost = 0.000;
        public double OverHead = 0.000;
        public bool IsPrintDate = false;

        /// <summary>
        /// Property For Set Dynamic Grouping Formulas
        /// </summary>
        public bool AllowSetFormula = false;
        public FrmReportViewer()
        {
            InitializeComponent();
        }
        public void ShowForm(string pStrRPTName, int pIntZoom = 120, ReportFolder pEnumReportFolder = ReportFolder.NONE)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                string StrPath = Application.StartupPath + "\\RPT\\";

                StrPath = StrPath + pEnumReportFolder.ToString() + "\\";

                StrPath = StrPath + pStrRPTName + ".rpt";

                RepDoc.Load(StrPath);

                if (DS != null)
                {
                    if (DS.Tables.Count > 0)
                        RepDoc.SetDataSource(DS.Tables[0]);
                }
                //TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
                //TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
                //ConnectionInfo crConnectionInfo = new ConnectionInfo();

                for (int IntI = 0; IntI < RepDoc.Subreports.Count; IntI++)
                {
                    RepDoc.Subreports[IntI].SetDataSource(DS.Tables[IntI + 1]);
                }
                CryViewer.ReportSource = RepDoc;

                CryViewer.ShowParameterPanelButton = false;
                CryViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;

                CryViewer.Refresh();
                CryViewer.Zoom(pIntZoom);

                SetParaMeter();
                this.Cursor = Cursors.Default;
                this.Show();
            }
            catch (Exception Ex)
            {
                this.Cursor = Cursors.Default;
                Global.Confirm(Ex.ToString());
            }
        }
        public void ShowForm_SubReport(string pStrRPTName, int pIntZoom = 120, ReportFolder pEnumReportFolder = ReportFolder.NONE)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                string StrPath = Application.StartupPath + "\\RPT\\";

                StrPath = StrPath + pEnumReportFolder.ToString() + "\\";

                StrPath = StrPath + pStrRPTName + ".rpt";


                RepDoc.Load(StrPath);


                //SetFormula(); 
                if (DS != null)
                {
                    if (DS.Tables.Count > 0)
                    {
                        RepDoc.Subreports[0].SetDataSource(DS.Tables[0]);
                        RepDoc.Subreports[1].SetDataSource(DS.Tables[0]);
                    }
                }

                //TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
                //TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
                //ConnectionInfo crConnectionInfo = new ConnectionInfo();

                RepDoc.SetDatabaseLogon(Global.gStrStrUserName, Global.gStrStrPasssword);
                CryViewer.ReportSource = RepDoc;

                CryViewer.ShowParameterPanelButton = false;
                CryViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;

                CryViewer.Refresh();
                CryViewer.Zoom(pIntZoom);

                //SetParaMeter();
                //MessageBox.Show("hello123");
                this.Cursor = Cursors.Default;
                this.Show();
            }
            catch (Exception Ex)
            {
                this.Cursor = Cursors.Default;
                Global.Confirm(Ex.ToString());
            }
        }

        public void ShowForm_New(string pStrRPTName, int pIntZoom = 120, ReportFolder pEnumReportFolder = ReportFolder.NONE, string[,] Formulas = null)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                string StrPath = Application.StartupPath + "\\RPT\\";

                StrPath = StrPath + pEnumReportFolder.ToString() + "\\";

                StrPath = StrPath + pStrRPTName + ".rpt";

                RepDoc.Load(StrPath);

                if (DS != null)
                {
                    RepDoc.SetDataSource(DS.Tables[0]);
                }
                TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
                TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
                ConnectionInfo crConnectionInfo = new ConnectionInfo();

                if (Formulas != null)
                {
                    for (int x = 0; x < Formulas.GetLength(0); x++)
                    {
                        RepDoc.DataDefinition.FormulaFields[Formulas[x, 0].ToString()].Text = " '" + Formulas[x, 1].ToString() + "'";
                    }
                }
                for (int IntI = 0; IntI < RepDoc.Subreports.Count; IntI++)
                {
                    RepDoc.Subreports[IntI].SetDataSource(DS.Tables[IntI]);
                }

                CryViewer.ReportSource = RepDoc;
                CryViewer.ShowParameterPanelButton = false;
                CryViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
                CryViewer.Refresh();
                CryViewer.Zoom(pIntZoom);
                SetParaMeter();
                this.Cursor = Cursors.Default;
                this.Show();
            }
            catch (Exception Ex)
            {
                this.Cursor = Cursors.Default;
                Global.Confirm(Ex.ToString());
            }
        }
        private void SetFormula()
        {
            if (AllowSetFormula == false)
            {
                return;
            }
            FormulaFieldDefinitions FormulaFieldDefs;
            FormulaFieldDefs = RepDoc.DataDefinition.FormulaFields;

            int IntFormula = 0;

            string[] splitStr = GroupBy.Split(',');

            foreach (string Str in splitStr)
            {
                if (Str != "")
                {
                    IntFormula++;
                    FormulaFieldDefs["Grp" + IntFormula.ToString()].Text = "{MIX_MACHINE_WORKDOWN." + Str + "}";
                    FormulaFieldDefs["Str" + IntFormula.ToString()].Text = "{MIX_MACHINE_WORKDOWN." + Str + "}";
                }
            }

            IntFormula = 0;
            for (int IntI = 0; IntI < splitStr.Length; IntI++)
            {
                IntFormula++;
                FormulaFieldDefs["showGroup" + IntFormula.ToString()].Text = "0";
            }

            for (int IntI = splitStr.Length; IntI > 1; IntI--)
            {
                FormulaFieldDefs["showGroup" + IntI.ToString()].Text = "1";
            }

            IntFormula = 0;
            foreach (string Str in splitStr)
            {
                if (Str != "")
                {
                    IntFormula++;
                }
            }
        }

        private void SetParaMeter()
        {
            RepDoc.DataDefinition.ParameterFields.Reset();
            ParameterFieldDefinitions ParamFieldDefs;
            ParameterValues ParamValues = new ParameterValues();
            ParameterDiscreteValue ParamDisValue;
            ParamFieldDefs = RepDoc.DataDefinition.ParameterFields;
            ParamDisValue = new ParameterDiscreteValue();

            foreach (ParameterFieldDefinition ParamFieldDef in ParamFieldDefs)
            {
                switch (ParamFieldDef.ParameterFieldName.ToUpper())
                {
                    case "REPHEAD":
                        if (Val.Val(RepHead.Length) != 0)
                        {
                            ParamDisValue.Value = RepHead;
                        }
                        else
                        {
                            ParamDisValue.Value = "  ";
                        }
                        break;
                    case "REPNAME":
                        if (Val.Val(RepName.Length) != 0)
                        {
                            ParamDisValue.Value = RepName;
                        }
                        else
                        {
                            ParamDisValue.Value = "  ";
                        }
                        break;
                    case "REPPARA":
                        if (Val.Val(RepPara.Length) != 0)
                        {
                            ParamDisValue.Value = RepPara;
                        }
                        else
                        {
                            ParamDisValue.Value = "  ";
                        }
                        break;
                    case "FROMDATE":
                        if (Val.Val(FromDate.Length) != 0)
                        {
                            ParamDisValue.Value = FromDate;
                        }
                        else
                        {
                            ParamDisValue.Value = "  ";
                        }
                        break;
                    case "TODATE":
                        if (Val.Val(ToDate.Length) != 0)
                        {
                            ParamDisValue.Value = ToDate;
                        }
                        else
                        {
                            ParamDisValue.Value = "  ";
                        }
                        break;
                    case "PROCESS":
                        if (Val.Val(ToDate.Length) != 0)
                        {
                            ParamDisValue.Value = PROCESS;
                        }
                        else
                        {
                            ParamDisValue.Value = "  ";
                        }
                        break;
                    case "DOLLARRATE":
                        if (Val.Val(DollarRate) != 0)
                        {
                            ParamDisValue.Value = DollarRate;
                        }
                        else
                        {
                            ParamDisValue.Value = "  ";
                        }
                        break;

                    case "COMPANYNAME":
                        if (Val.Val(CompanyName.Length) != 0)
                        {
                            ParamDisValue.Value = CompanyName;
                        }
                        else
                        {
                            ParamDisValue.Value = "  ";
                        }
                        break;
                    case "ADDRESS":
                        if (Val.Val(Address.Length) != 0)
                        {
                            ParamDisValue.Value = Address;
                        }
                        else
                        {
                            ParamDisValue.Value = "  ";
                        }
                        break;
                    case "PHONENO":
                        if (Val.Val(PhoneNo.Length) != 0)
                        {
                            ParamDisValue.Value = PhoneNo;
                        }
                        else
                        {
                            ParamDisValue.Value = "  ";
                        }
                        break;
                    case "REPTYPE":
                        if (Val.Val(RepType.Length) != 0)
                        {
                            ParamDisValue.Value = RepType;
                        }
                        else
                        {
                            ParamDisValue.Value = "  ";
                        }
                        break;

                    case "ADDRESSTYPE":
                        if (Val.Val(AddressType.Length) != 0)
                        {
                            ParamDisValue.Value = AddressType;
                        }
                        else
                        {
                            ParamDisValue.Value = "  ";
                        }
                        break;
                    case "ISPRINTDATE":
                        ParamDisValue.Value = IsPrintDate;
                        break;
                }
                if (Val.Left(ParamFieldDef.ParameterFieldName.ToUpper(), 1) != "@")
                {
                    ParamValues.Add(ParamDisValue);
                    ParamFieldDef.ApplyCurrentValues(ParamValues);
                }
            }
        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            CryViewer.PrintReport();
        }
        private void FrmReportViewer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                this.Close();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.PrinterSettings = printerSettings;
            printDialog.AllowPrintToFile = false;
            printDialog.AllowSomePages = true;
            printDialog.UseEXDialog = true;
            printDialog.AllowSelection = true;
            printDialog.AllowCurrentPage = true;
            DialogResult result = printDialog.ShowDialog();

            if (result == DialogResult.Cancel)
            {
                return;
            }
            RepDoc.PrintOptions.PrinterName = printerSettings.PrinterName;
            RepDoc.PrintToPrinter(printerSettings.Copies, false, printerSettings.FromPage, printerSettings.ToPage);
        }

        private void FrmReportViewer_Load(object sender, EventArgs e)
        {
            if (mStrRefreshFormType != "")
            {
                BtnRefresh.Visible = true;
            }
            else
            {
                BtnRefresh.Visible = false;
            }
            CryViewer.Refresh();
        }
    }
}
