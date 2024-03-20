using BLL.FunctionClasses.Report;
using BLL.PropertyClasses.Report;
using DevExpress.Data;
using DevExpress.LookAndFeel;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrintingLinks;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Global = Account_Management.Class.Global;
namespace Account_Management.Report
{
    public partial class FrmGReportViewerBand : DevExpress.XtraEditors.XtraForm
    {
        #region Delcaration


        Excel.Application myExcelApplication;
        Excel.Workbook myExcelWorkbook;
        Excel.Worksheet myExcelWorkSheet;

        Dictionary<int, double> dic = new Dictionary<int, double>();

        DataTable DTabDiscount = new DataTable();

        public New_Report_DetailProperty ObjReportDetailProperty = new New_Report_DetailProperty();
        NewReportMaster ObjReport = new NewReportMaster();

        ReportParams ObjReportParams = new ReportParams();

        BLL.FormEvents objBOFormEvents = new BLL.FormEvents();
        BLL.Validation Val = new BLL.Validation();
        BLL.FormPer ObjPer = new BLL.FormPer();

        string MergeOnStr = string.Empty;
        string MergeOn = string.Empty;
        Boolean ISFilter = false;
        public Boolean IsPivot = false;

        public int ReceiptDays = 0;
        public double DouExpDiff = 0;

        public string BandConsumeCaption = "";
        public string BandConsumeWithProcessCaption = "";

        /// <summary>
        ////
        /// </summary>

        decimal DouOpeningCarat = 0;
        decimal DouOpeningAmount = 0;
        decimal DouClosingCarat = 0;
        decimal DouClosingAmount = 0;
        decimal DouInCarat = 0;
        decimal DouInAmount = 0;
        decimal DouOutCarat = 0;
        decimal DouOutAmount = 0;
        decimal DouTotalCarat = 0;
        decimal DouTotalAmount = 0;
        decimal DouPrdAmount = 0;
        decimal DousaleCarat = 0;
        decimal DouSaleAmount = 0;
        decimal DouOnHandCarat = 0;
        decimal DouOnHandAmount = 0;
        decimal DouRealHandCarat = 0;
        decimal DouRealHandAmount = 0;
        decimal DouConfirmCarat = 0;
        decimal DouConfirmAmount = 0;
        decimal DouRapCarat = 0;
        decimal DouRapAmount = 0;
        decimal DouWeightLossCarat = 0;
        decimal DouWeightLossAmount = 0;
        decimal DouWeightPlusCarat = 0;
        decimal DouWeightPlusAmount = 0;
        decimal DouLostCarat = 0;
        decimal DouLostAmount = 0;
        decimal DouRejCarat = 0;
        decimal DouRejAmount = 0;

        decimal DouCurrentAmount = 0;

        #region Property Settings

        private DataTable _mDTDetail = new DataTable();

        public DataTable mDTDetail
        {
            get { return _mDTDetail; }
            set { _mDTDetail = value; }
        }

        private DataTable _DTab = new DataTable();

        public DataTable DTab
        {
            get { return _DTab; }
            set { _DTab = value; }
        }

        private string _Group_By_Tag;

        public string Group_By_Tag
        {
            get { return _Group_By_Tag; }
            set { _Group_By_Tag = value; }
        }

        private string _Group_By_Text;

        public string Group_By_Text
        {
            get { return _Group_By_Text; }
            set { _Group_By_Text = value; }
        }

        private bool _BoolShowLabourRate;

        public bool BoolShowLabourRate
        {
            get { return _BoolShowLabourRate; }
            set { _BoolShowLabourRate = value; }
        }

        private string _Order_By;

        public string Order_By
        {
            get { return _Order_By; }
            set { _Order_By = value; }
        }

        private string _ReportHeaderName;

        public string ReportHeaderName
        {
            get { return _ReportHeaderName; }
            set { _ReportHeaderName = value; }
        }

        private string _Remark;

        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }

        private int _Report_Code;

        public int Report_Code
        {
            get { return _Report_Code; }
            set { _Report_Code = value; }
        }

        private string _Report_Type;

        public string Report_Type
        {
            get { return _Report_Type; }
            set { _Report_Type = value; }
        }

        private string _FormToBeOpen;

        public string FormToBeOpen
        {
            get { return _FormToBeOpen; }
            set { _FormToBeOpen = value; }
        }

        private string _FilterBy;

        public string FilterBy
        {
            get { return _FilterBy; }
            set { _FilterBy = value; }
        }

        public string R_Date;
        public string Shape_Name;
        public string Article_Name;
        public string MSize_Name;

        private ReportParams_Property _ReportParams_Property;
        public ReportParams_Property ReportParams_Property
        {
            get { return _ReportParams_Property; }
            set { _ReportParams_Property = value; }
        }

        private string _Procedure_Name;

        public string Procedure_Name
        {
            get { return _Procedure_Name; }
            set { _Procedure_Name = value; }
        }

        private bool _ChkExportAsaCostingPattern;
        public bool ChkExportAsaCostingPattern
        {
            get { return _ChkExportAsaCostingPattern; }
            set { _ChkExportAsaCostingPattern = value; }
        }
        private string _FromIssue_Date;
        public string FromIssue_Date
        {
            get { return _FromIssue_Date; }
            set { _FromIssue_Date = value; }
        }
        private string _ToIssue_Date;
        public string ToIssue_Date
        {
            get { return _ToIssue_Date; }
            set { _ToIssue_Date = value; }
        }
        private string _FilterByFormName;
        public string FilterByFormName
        {
            get { return _FilterByFormName; }
            set { _FilterByFormName = value; }
        }
        #endregion

        public int Company_Code { get; set; }
        public int Branch_Code { get; set; }
        public int Location_Code { get; set; }
        public bool IS_Local { get; set; }
        public bool IS_Purchase { get; set; }
        public bool IS_Dollar { get; set; }

        #endregion

        #region Constructor
        public FrmGReportViewerBand()
        {
            InitializeComponent();

            DTabDiscount.Columns.Add("key");
            DTabDiscount.Columns.Add("value");
        }
        public FrmGReportViewerBand(DataTable pDTab, string pStrOrderBy, string pStrGroupBy, string pStrReportName, int pIntReportCode)
        {
            InitializeComponent();

            DTab = pDTab;
            Group_By_Tag = pStrGroupBy;
            Order_By = pStrOrderBy;
            ReportHeaderName = pStrReportName;
            Report_Code = pIntReportCode;
        }
        public void ShowForm()
        {
            ObjPer.Report_Code = Report_Code;
            AttachFormEvents();
            lblReportHeader.Text = ReportHeaderName;
            lblGroupBy.Text = Group_By_Text;

            if (lblGroupBy.Text == "")
            {
                label2.Visible = false;
            }
            else
            {
                label2.Visible = true;
            }
            lblGroupBy.Tag = Group_By_Tag;
            lblFilter.Text = FilterBy;
            this.Text = lblReportHeader.Text + " With Group : " + lblGroupBy.Text;
            this.Show();
        }
        private void AttachFormEvents()
        {
            objBOFormEvents.CurForm = this;
            objBOFormEvents.FormKeyPress = true;
            objBOFormEvents.FormClosing = true;
            objBOFormEvents.ObjToDispose.Add(Val);
            objBOFormEvents.ObjToDispose.Add(objBOFormEvents);
        }

        #endregion

        #region Menu Events

        private void MNUExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ToExcel_Click(object sender, EventArgs e)
        {
            Export("xls", GridView1);
        }

        public void Export(string format, GridView gvExportGrid, bool isHeaderPrint = true)
        {
            try
            {
                if (gvExportGrid.RowCount < 1)
                {
                    Global.Message("No Rows to Export");
                    return;
                }
                string dlgHeader = string.Empty;
                string dlgFilter = string.Empty;
                format = format.ToLower();
                if (format.Equals("xls"))
                {
                    dlgHeader = "Export to Excel";
                    dlgFilter = "Excel files 97-2003 (*.xls)|*.xls|Excel files 2007(*.xlsx)|*.xlsx|All files (*.*)|*.*";
                }
                else if (format.Equals("xlsx"))
                {
                    dlgHeader = "Export to XLSX";
                    dlgFilter = "Excel files 2007(*.xlsx)|*.xlsx|All files (*.*)|*.*";
                }
                gvExportGrid.OptionsPrint.AutoWidth = false;
                gvExportGrid.OptionsPrint.PrintHeader = isHeaderPrint;

                SaveFileDialog svDialog = new SaveFileDialog();
                svDialog.DefaultExt = format;
                svDialog.Title = dlgHeader;
                svDialog.FileName = "Report";
                svDialog.Filter = dlgFilter;
                string Filepath = string.Empty;
                if ((svDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK))
                {
                    Filepath = svDialog.FileName;

                    switch (format)
                    {
                        case "pdf":
                            gvExportGrid.ExportToPdf(Filepath);
                            break;
                        case "xls":
                            DevExpress.XtraPrinting.XlsExportOptionsEx op = new DevExpress.XtraPrinting.XlsExportOptionsEx();
                            op.ExportType = DevExpress.Export.ExportType.WYSIWYG;
                            gvExportGrid.OptionsPrint.UsePrintStyles = false;
                            gvExportGrid.ExportToXls(Filepath, op);
                            break;
                        case "rtf":
                            gvExportGrid.ExportToRtf(Filepath);
                            break;
                        case "txt":
                            gvExportGrid.ExportToText(Filepath);
                            break;
                        case "html":
                            gvExportGrid.ExportToHtml(Filepath);
                            break;
                        case "csv":
                            gvExportGrid.ExportToCsv(Filepath);
                            break;
                        case "xlsx":
                            DevExpress.XtraPrinting.XlsxExportOptionsEx opx = new DevExpress.XtraPrinting.XlsxExportOptionsEx();
                            opx.ExportType = DevExpress.Export.ExportType.WYSIWYG;
                            gvExportGrid.OptionsPrint.UsePrintStyles = false;
                            gvExportGrid.ExportToXlsx(Filepath, opx);
                            break;
                    }
                }

                myExcelApplication = null;

                myExcelApplication = new Excel.Application();
                myExcelApplication.DisplayAlerts = false;

                myExcelWorkbook = (Excel.Workbook)(myExcelApplication.Workbooks._Open(Filepath, System.Reflection.Missing.Value,
                   System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value,
                   System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value,
                   System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value,
                   System.Reflection.Missing.Value, System.Reflection.Missing.Value));

                int numberOfWorkbooks = myExcelApplication.Workbooks.Count;
                myExcelWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)myExcelWorkbook.Worksheets.get_Item(1);

                Excel.Range line = (Excel.Range)myExcelWorkSheet.Rows[1];
                line.Insert();
                myExcelWorkSheet.Cells[1, 1] = lblReportHeader.Text;
                Excel.Range line1 = (Excel.Range)myExcelWorkSheet.Rows[2];
                line1.Insert();
                myExcelWorkSheet.Cells[2, 1] = "Group :- " + lblGroupBy.Text;
                Excel.Range line2 = (Excel.Range)myExcelWorkSheet.Rows[3];
                line2.Insert();
                myExcelWorkSheet.Cells[3, 1] = "Parameters :- " + lblFilter.Text;
                Excel.Range line3 = (Excel.Range)myExcelWorkSheet.Rows[4];
                line3.Insert();
                myExcelWorkSheet.Cells[4, 1] = "Print Date :- " + lblDateTime.Text;

                myExcelWorkSheet.Range["A1"].WrapText = false;
                myExcelWorkSheet.Range["A2"].WrapText = false;
                myExcelWorkSheet.Range["A3"].WrapText = false;
                myExcelWorkSheet.Range["A4"].WrapText = false;

                try
                {
                    myExcelWorkbook.SaveAs(Filepath, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value,
                                                   System.Reflection.Missing.Value, System.Reflection.Missing.Value, Excel.XlSaveAsAccessMode.xlNoChange,
                                                   System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value,
                                                   System.Reflection.Missing.Value, System.Reflection.Missing.Value);

                    myExcelWorkbook.Close(true, Filepath, System.Reflection.Missing.Value);
                }
                finally
                {
                    if (myExcelApplication != null)
                    {
                        myExcelApplication.Quit();
                    }
                }

                if (Global.Confirm("Export Done\n\nYou Want To Open Excel File ?", "Account Management", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(Filepath);
                }
            }
            catch (Exception ex)
            {
                Global.Message(ex.Message.ToString());
            }
        }

        private void ToExcelx_Click(object sender, EventArgs e)
        {
            Export("xlsx", GridView1);
        }
        private void ToText_Click(object sender, EventArgs e)
        {
            Global.Export("txt", GridView1);
        }

        private void ToHTML_Click(object sender, EventArgs e)
        {
            Global.Export("html", GridView1);
        }

        private void ToRTF_Click(object sender, EventArgs e)
        {
            Global.Export("rtf", GridView1);
        }

        private void ToPDF_Click(object sender, EventArgs e)
        {
            //Global.Export("pdf", GridView1);
            Export("pdf", "Export Report to PDF", "PDF (*.PDF)|*.PDF");
        }

        private void AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GridView1.BestFitColumns();
        }

        private void ExpandTool_Click(object sender, EventArgs e)
        {
            GridView1.ExpandAllGroups();
        }

        private void Collapse_Click(object sender, EventArgs e)
        {
            GridView1.CollapseAllGroups();
        }

        private void PrintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DevExpress.XtraPrinting.PrintingSystem PrintSystem = new DevExpress.XtraPrinting.PrintingSystem();

                PrinterSettingsUsing pst = new PrinterSettingsUsing();

                PrintSystem.PageSettings.AssignDefaultPrinterSettings(pst);


                PrintableComponentLink link = new PrintableComponentLink(PrintSystem);

                link.Component = GridControl1;

                foreach (System.Drawing.Printing.PaperKind foo in Enum.GetValues(typeof(System.Drawing.Printing.PaperKind)))
                {
                    if (Val.ToString(CmbPageKind.SelectedItem) == foo.ToString())
                    {
                        link.PaperKind = foo;
                        link.PaperName = foo.ToString();

                    }
                }

                if (Val.ToString(cmbOrientation.SelectedItem) == "Landscape")
                {
                    link.Landscape = true;
                }
                if (Val.ToString(cmbExpand.SelectedItem) == "Yes")
                {
                    GridView1.OptionsPrint.ExpandAllGroups = true;
                }
                else
                {
                    GridView1.OptionsPrint.ExpandAllGroups = false;
                }

                GridView1.OptionsPrint.AutoWidth = true;

                link.Margins.Left = 40;
                link.Margins.Right = 40;
                link.Margins.Bottom = 40;
                link.Margins.Top = 130;
                link.CreateMarginalHeaderArea += new CreateAreaEventHandler(Link_CreateMarginalHeaderArea);
                link.CreateMarginalFooterArea += new CreateAreaEventHandler(Link_CreateMarginalFooterArea);
                link.CreateDocument();
                link.ShowPreview();
                link.PrintDlg();
            }
            catch (Exception EX)
            {
                Global.Message(EX.Message);
            }
        }

        #endregion

        #region Form Events
        private void FrmGReportViewer_Load(object sender, EventArgs e)
        {
            int IntIndex = 0;
            int IntSelectedIndex = 0;
            CmbPageKind.Items.Clear();
            foreach (System.Drawing.Printing.PaperKind foo in Enum.GetValues(typeof(System.Drawing.Printing.PaperKind)))
            {
                CmbPageKind.Items.Add(foo.ToString());

                IntIndex++;
            }
            CmbPageKind.SelectedIndex = IntSelectedIndex;
            lblDateTime.Text = DateTime.Now.ToString("dd/MMM/yyyy hh:mm:ss tt");
            FillGrid();


            FooterSummary();
            if (ObjReportDetailProperty.Remark == "POLISH_CONSUME_VALUATION")
            {
                TsmExportData.Visible = true;
            }
            if (FilterByFormName != null && !FilterByFormName.Trim().Equals(string.Empty))
            {
                if (
                    Val.ToString(FilterByFormName).Equals("FrmMixIssueReceiveFilterBy")
                    || Val.ToString(FilterByFormName).Equals("FrmMixIssueReceiveFilterByNew")
                   )
                {
                    pnlRefresh.Visible = true;
                }
            }
        }

        #endregion

        #region Other Function
        void PreviewPrintableComponent(IPrintable component, UserLookAndFeel lookAndFeel, string Filepath)
        {
            PrintableComponentLinkBase link = new PrintableComponentLinkBase()
            {
                PrintingSystemBase = new PrintingSystemBase(),
                Component = component,
                Landscape = true

            };

            link.CreateReportHeaderArea += new CreateAreaEventHandler(Link_CreateMarginalHeaderArea);

            link.ExportToXls(Filepath);
        }
        void PreviewPrintableComponent_PDF(IPrintable component, UserLookAndFeel lookAndFeel, string Filepath)
        {
            PrintableComponentLinkBase link = new PrintableComponentLinkBase()
            {
                PrintingSystemBase = new PrintingSystemBase(),
                Component = component,
                Landscape = true

            };

            link.CreateReportHeaderArea += new CreateAreaEventHandler(Link_CreateMarginalHeaderArea);

            link.ExportToPdf(Filepath);
        }
        private void Export(string format, string dlgHeader, string dlgFilter)
        {
            GridView1.OptionsPrint.ExpandAllDetails = true;
            DevExpress.XtraGrid.Export.GridViewExportLink gvlink;
            try
            {
                SaveFileDialog svDialog = new SaveFileDialog();
                svDialog.DefaultExt = format;
                svDialog.Title = dlgHeader;
                svDialog.FileName = "Report";
                svDialog.Filter = dlgFilter;
                if ((svDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK))
                {
                    string Filepath = svDialog.FileName;
                    switch (format)
                    {
                        case "pdf":
                            PreviewPrintableComponent_PDF(GridControl1, GridControl1.LookAndFeel, Filepath);
                            // GridView1.ExportToPdf(Filepath);

                            break;
                        case "xls":
                            PreviewPrintableComponent(GridControl1, GridControl1.LookAndFeel, Filepath);

                            break;
                        case "xlsx":

                            PreviewPrintableComponent(GridControl1, GridControl1.LookAndFeel, Filepath);
                            break;
                        case "rtf":
                            GridView1.ExportToRtf(Filepath);
                            break;
                        case "txt":

                            gvlink = (DevExpress.XtraGrid.Export.GridViewExportLink)GridView1.CreateExportLink(new DevExpress.XtraExport.ExportTxtProvider(Filepath));

                            gvlink.ExportAll = true;

                            gvlink.ExpandAll = true;

                            gvlink.ExportDetails = true;

                            gvlink.ExportTo(true);
                            break;
                        case "html":

                            gvlink = (DevExpress.XtraGrid.Export.GridViewExportLink)GridView1.CreateExportLink(new DevExpress.XtraExport.ExportHtmlProvider(Filepath));

                            gvlink.ExportAll = true;

                            gvlink.ExpandAll = true;

                            gvlink.ExportDetails = true;

                            gvlink.ExportTo(true);
                            break;
                    }
                    if (Global.Confirm("Export Done\n\nYou Want To Open PDF File ?", "Account Management", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(Filepath);
                    }
                    //if (Global.Confirm("Press Yes To Open the File.") == System.Windows.Forms.DialogResult.Yes)
                    //{
                    //    System.Diagnostics.Process.Start(Filepath, "CMD");
                    //}
                }
            }
            catch (Exception ex)
            {
                Global.Message(ex.Message.ToString(), "Error in Export");
            }
        }
        public void FillGrid()
        {
            int IntError = 0;

            try
            {
                DataView dv = new DataView(mDTDetail);
                dv.Sort = "Sequence_No";
                mDTDetail = dv.ToTable();

                foreach (DataRow DRow in mDTDetail.Rows)
                {
                    if (Val.ToBoolean(DRow["visible"].ToString()) == false)
                    {
                    }
                    else
                    {
                        if (DRow["mergeon"].ToString() != "")
                        {
                            MergeOn = DRow["mergeon"].ToString();

                            if (MergeOnStr == "")
                            {
                                MergeOnStr = DRow["mergeon"].ToString();
                            }
                            else
                            {
                                MergeOnStr = MergeOnStr + "," + DRow["field_name"].ToString();
                            }
                        }
                    }
                }
                List<GridBand> AL = new List<GridBand>();
                DataView view = new DataView(mDTDetail);
                DataTable distinctValues = view.ToTable(true, "bands");

                foreach (DataRow DRow in distinctValues.Rows)
                {
                    var gridBand = new GridBand();
                    gridBand.Caption = Val.ToString(DRow["bands"]);
                    gridBand.RowCount = 2;
                    AL.Add(gridBand);
                }

                GridControl1.DataSource = DTab;
                GridView1.OptionsView.AllowCellMerge = true;

                GridView1.Bands.AddBand(lblReportHeader.Text);

                foreach (DataRow DRow in mDTDetail.Rows)
                {
                    if (Val.ToBoolean(DRow["visible"].ToString()) == true && Val.ToBoolean(DRow["is_unbound"]) == true)
                    {
                        DevExpress.XtraGrid.Columns.GridColumn unbColumn = GridView1.Columns.AddField(Val.ToString(DRow["field_name"]));
                        unbColumn.VisibleIndex = Val.ToInt(DRow["sequence_no"]);
                        unbColumn.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
                        unbColumn.Caption = Val.ToString(DRow["column_name"]);
                        unbColumn.Tag = DRow["field_name"].ToString();
                        unbColumn.OptionsColumn.AllowEdit = false;

                        unbColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;

                        if (Val.ToString(DRow["format"]).ToUpper() == "N1")
                        {
                            unbColumn.DisplayFormat.FormatString = "###################0.0";
                        }
                        if (Val.ToString(DRow["format"]).ToUpper() == "N2")
                        {
                            unbColumn.DisplayFormat.FormatString = "###################0.00";
                        }
                        else if (Val.ToString(DRow["format"]).ToUpper() == "N3")
                        {
                            unbColumn.DisplayFormat.FormatString = "###################0.000";
                        }
                        else if (Val.ToString(DRow["format"]).ToUpper() == "N4")
                        {
                            unbColumn.DisplayFormat.FormatString = "###################0.0000";
                        }
                        unbColumn.UnboundExpression = Val.ToString(DRow["expression"]);
                        unbColumn.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                    }
                    else
                    {

                        bool iBool = false;
                        foreach (DataColumn DCol in DTab.Columns)
                        {
                            if (DCol.ColumnName == DRow["field_name"].ToString())
                            {
                                iBool = true;
                                break;
                            }
                        }

                        if (iBool == false)
                        {
                            continue;
                        }

                        if (Val.ToBoolean(DRow["visible"].ToString()) == false)
                        {
                            GridView1.Columns[DRow["field_name"].ToString()].Visible = false;
                            continue;
                        }

                        if (Val.ToBoolean(DRow["ismerge"].ToString()) == false)
                        {
                            GridView1.Columns[DRow["field_name"].ToString()].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                        }
                        if (Val.ToInt(DRow["width"].ToString()) != 0)
                        {
                            GridView1.Columns[DRow["field_name"].ToString()].Width = Val.ToInt(DRow["width"].ToString());
                        }

                        //Set Column Caption
                        GridView1.Columns[DRow["field_name"].ToString()].Caption = DRow["column_name"].ToString();
                        GridView1.Columns[DRow["field_name"].ToString()].Tag = DRow["field_name"].ToString();
                        GridView1.Columns[DRow["field_name"].ToString()].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;

                    }

                    string StrFormat = string.Empty;
                    string StrSummryFormat = string.Empty;

                    switch (DRow["type"].ToString().ToUpper())
                    {
                        case "I":
                            StrFormat = "###################0";
                            StrSummryFormat = "{0:N0}";

                            break;
                        case "F":
                            if (Val.ToString(DRow["format"]).ToUpper() == "N0")
                            {
                                StrFormat = "###################0";
                            }
                            if (Val.ToString(DRow["format"]).ToUpper() == "N1")
                            {
                                StrFormat = "###################0.0";
                            }
                            if (Val.ToString(DRow["format"]).ToUpper() == "N2")
                            {
                                StrFormat = "###################0.00";
                            }
                            else if (Val.ToString(DRow["format"]).ToUpper() == "N3")
                            {
                                StrFormat = "###################0.000";
                            }
                            else if (Val.ToString(DRow["format"]).ToUpper() == "N4")
                            {
                                StrFormat = "###################0.0000";
                            }
                            StrSummryFormat = "{0:" + Val.ToString(DRow["format"]).ToUpper() + "}";
                            break;
                        case "D":
                            StrFormat = "dd-MMM-yyyy";
                            break;
                        case "T":
                            StrFormat = "hh:mm tt";
                            break;
                        default:
                            StrFormat = "";
                            break;
                    }
                    /* Add Alignment */
                    switch (DRow["alignment"].ToString().ToUpper())
                    {
                        case "left":
                            GridView1.Columns[DRow["field_name"].ToString()].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                            break;
                        case "right":
                            GridView1.Columns[DRow["field_name"].ToString()].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                            break;
                        case "center":
                            GridView1.Columns[DRow["field_name"].ToString()].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                            break;
                        default:
                            GridView1.Columns[DRow["field_name"].ToString()].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
                            break;
                    }

                    /* Set Order */
                    switch (DRow["order_by"].ToString().ToUpper())
                    {
                        case "ASC":
                            GridView1.Columns[DRow["field_name"].ToString()].SortOrder = ColumnSortOrder.Ascending;
                            break;
                        case "DESC":
                            GridView1.Columns[DRow["field_name"].ToString()].SortOrder = ColumnSortOrder.Descending;
                            break;
                        default:
                            GridView1.Columns[DRow["field_name"].ToString()].SortOrder = ColumnSortOrder.None;
                            break;
                    }

                    GridView1.Columns[DRow["field_name"].ToString()].OptionsColumn.AllowEdit = false;
                    GridView1.Columns[DRow["field_name"].ToString()].DisplayFormat.FormatString = StrFormat;
                    GridView1.Columns[DRow["field_name"].ToString()].VisibleIndex = Val.ToInt(DRow["sequence_no"]);

                    foreach (GridBand band in AL)
                    {
                        if (band.Caption == Val.ToString(DRow["bands"]))
                        {
                            GridView1.Columns[DRow["field_name"].ToString()].OwnerBand = band;

                            bool ISExists = false;

                            foreach (GridBand band1 in GridView1.Bands[0].Children)
                            {
                                if (band1.Caption == band.Caption)
                                {
                                    ISExists = true;
                                    break;
                                }
                            }

                            if (ISExists == false)
                            {
                                GridView1.Bands[0].Children.Add(band);
                                GridView1.Bands[0].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                                band.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                                GridView1.Columns[DRow["field_name"].ToString()].OwnerBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                            }
                            break;
                        }
                    }

                    // Set Summry Field and group Summry Also

                    if (Val.ToBoolean(DRow["visible"].ToString()) == true && Val.ToBoolean(DRow["ismerge"].ToString()) == false)
                    {
                        switch (DRow["aggregate"].ToString().ToUpper())
                        {
                            case "SUM":
                                GridView1.Columns[DRow["field_name"].ToString()].Summary.Add(SummaryItemType.Sum, DRow["field_name"].ToString(), StrSummryFormat);
                                GridView1.GroupSummary.Add(SummaryItemType.Sum, DRow["field_name"].ToString(), GridView1.Columns[DRow["field_name"].ToString()], StrSummryFormat);
                                break;
                            case "AVG":
                                GridView1.Columns[DRow["field_name"].ToString()].Summary.Add(SummaryItemType.Average, DRow["field_name"].ToString(), StrSummryFormat);
                                GridView1.GroupSummary.Add(SummaryItemType.Average, DRow["field_name"].ToString(), GridView1.Columns[DRow["field_name"].ToString()], StrSummryFormat);
                                break;
                            case "COUNT":
                                GridView1.Columns[DRow["field_name"].ToString()].Summary.Add(SummaryItemType.Count, DRow["field_name"].ToString(), StrSummryFormat);
                                GridView1.GroupSummary.Add(SummaryItemType.Count, DRow["field_name"].ToString(), GridView1.Columns[DRow["field_name"].ToString()], StrSummryFormat);
                                break;
                            case "MAX":
                                GridView1.Columns[DRow["field_name"].ToString()].Summary.Add(SummaryItemType.Max, DRow["field_name"].ToString(), StrSummryFormat);
                                GridView1.GroupSummary.Add(SummaryItemType.Max, DRow["field_name"].ToString(), GridView1.Columns[DRow["field_name"].ToString()], StrSummryFormat);
                                break;
                            case "MIN":
                                GridView1.Columns[DRow["field_name"].ToString()].Summary.Add(SummaryItemType.Min, DRow["field_name"].ToString(), StrSummryFormat);
                                GridView1.GroupSummary.Add(SummaryItemType.Min, DRow["field_name"].ToString(), GridView1.Columns[DRow["field_name"].ToString()], StrSummryFormat);
                                break;
                            case "WEI.AVG":
                                GridView1.Columns[DRow["field_name"].ToString()].Summary.Add(SummaryItemType.Custom, DRow["field_name"].ToString(), StrSummryFormat);
                                GridView1.GroupSummary.Add(SummaryItemType.Custom, DRow["field_name"].ToString(), GridView1.Columns[DRow["field_name"].ToString()], StrSummryFormat);
                                break;
                            case "CUSTOME":
                                GridView1.Columns[DRow["field_name"].ToString()].Summary.Add(SummaryItemType.Custom, DRow["field_name"].ToString(), StrSummryFormat);
                                GridView1.GroupSummary.Add(SummaryItemType.Custom, DRow["field_name"].ToString(), GridView1.Columns[DRow["field_name"].ToString()], StrSummryFormat);

                                break;
                            default:
                                break;
                        }
                    }
                }

                //Group By Setting
                GridView1.ClearSorting();

                string[] StrGroupBy = new string[] { }; if (Group_By_Tag != null) StrGroupBy = Group_By_Tag.Split(',');

                int IntCount = 0;

                if (IsPivot == false)
                {
                    if (Val.ToString(Report_Type).ToUpper().Contains("SUMMARY"))
                    {
                        IntCount = StrGroupBy.Length - 1;
                    }
                    else
                    {
                        IntCount = StrGroupBy.Length;
                    }
                    for (int IntI = 0; IntI < IntCount; IntI++)
                    {
                        if (StrGroupBy[IntI] != "")
                        {
                            GridView1.Columns[StrGroupBy[IntI]].GroupIndex = IntI;
                            GridView1.Columns[StrGroupBy[IntI]].Group();
                        }
                    }

                    if (Group_By_Tag == "")
                    {
                        foreach (string Str in Val.ToString(Order_By).Split(','))
                        {
                            if (Str != "")
                            {
                                GridView1.Columns[Str].SortMode = DevExpress.XtraGrid.ColumnSortMode.Default;
                                GridView1.Columns[Str].SortOrder = ColumnSortOrder.Ascending;
                            }
                        }
                    }
                }

                string[] StrCaption = BandConsumeCaption.Split(',');
                string[] StrCaptionValue = BandConsumeWithProcessCaption.Split(',');

                if (StrCaptionValue.Length == StrCaption.Length)
                {
                    foreach (GridBand gridBand in GridView1.Bands[0].Children)
                    {
                        for (int IntI = 0; IntI < StrCaption.Length; IntI++)
                        {
                            if (StrCaption[IntI].ToUpper() == gridBand.Caption.ToUpper())
                            {
                                gridBand.Caption = StrCaptionValue[IntI];
                            }
                        }

                        if (BoolShowLabourRate == true)
                        {
                            if (gridBand.Caption.ToUpper() == "LABOUR")
                            {
                                gridBand.Visible = true;
                            }
                        }
                        else
                        {
                            if (gridBand.Caption.ToUpper() == "LABOUR")
                            {
                                gridBand.Visible = false;
                            }
                        }
                    }
                }

                GridView1.Appearance.Row.Font = new Font(ObjReportDetailProperty.Font_Name, float.Parse(Val.ToString(ObjReportDetailProperty.Font_Size)), FontStyle.Regular);
                GridView1.AppearancePrint.Row.Font = new Font(ObjReportDetailProperty.Font_Name, float.Parse(Val.ToString(ObjReportDetailProperty.Font_Size)), FontStyle.Regular);

                GridView1.Appearance.BandPanel.Font = new Font(ObjReportDetailProperty.Font_Name, float.Parse(Val.ToString(ObjReportDetailProperty.Font_Size)), FontStyle.Bold);
                GridView1.AppearancePrint.BandPanel.Font = new Font(ObjReportDetailProperty.Font_Name, float.Parse(Val.ToString(ObjReportDetailProperty.Font_Size)), FontStyle.Bold);

                GridView1.Appearance.HeaderPanel.Font = new Font(ObjReportDetailProperty.Font_Name, float.Parse(Val.ToString(ObjReportDetailProperty.Font_Size)), FontStyle.Bold);
                GridView1.AppearancePrint.HeaderPanel.Font = new Font(ObjReportDetailProperty.Font_Name, float.Parse(Val.ToString(ObjReportDetailProperty.Font_Size)), FontStyle.Bold);

                GridView1.Appearance.GroupRow.Font = new Font(ObjReportDetailProperty.Font_Name, float.Parse(Val.ToString(ObjReportDetailProperty.Font_Size)), FontStyle.Bold);
                GridView1.AppearancePrint.GroupRow.Font = new Font(ObjReportDetailProperty.Font_Name, float.Parse(Val.ToString(ObjReportDetailProperty.Font_Size)), FontStyle.Bold);

                GridView1.Appearance.GroupFooter.Font = new Font(ObjReportDetailProperty.Font_Name, float.Parse(Val.ToString(ObjReportDetailProperty.Font_Size - 1)), FontStyle.Bold);
                GridView1.AppearancePrint.GroupFooter.Font = new Font(ObjReportDetailProperty.Font_Name, float.Parse(Val.ToString(ObjReportDetailProperty.Font_Size - 1)), FontStyle.Bold);

                GridView1.Appearance.FooterPanel.Font = new Font(ObjReportDetailProperty.Font_Name, float.Parse(Val.ToString(ObjReportDetailProperty.Font_Size - 1)), FontStyle.Bold);
                GridView1.AppearancePrint.FooterPanel.Font = new Font(ObjReportDetailProperty.Font_Name, float.Parse(Val.ToString(ObjReportDetailProperty.Font_Size - 1)), FontStyle.Bold);

                GridView1.OptionsPrint.UsePrintStyles = true;
                GridView1.OptionsSelection.MultiSelect = true;
                GridView1.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CellSelect;
                cmbOrientation.SelectedItem = ObjReportDetailProperty.Page_Orientation;
                GridView1.ExpandAllGroups();
                // GridView1.BestFitColumns();
            }
            catch (Exception Ex)
            {
                Global.Message("Error In Column Index : " + IntError.ToString() + "    " + Ex.Message);
            }
        }
        private void SetGridBand(BandedGridView bandedView, string gridBandCaption, string[] columnNames)
        {
            var gridBand = new GridBand();
            gridBand.Caption = gridBandCaption;
            int nrOfColumns = columnNames.Length;
            BandedGridColumn[] bandedColumns = new BandedGridColumn[nrOfColumns];
            for (int i = 0; i < nrOfColumns; i++)
            {
                bandedColumns[i] = (BandedGridColumn)bandedView.Columns.AddField(columnNames[i]);
                bandedColumns[i].OwnerBand = gridBand;
                bandedColumns[i].Visible = true;
            }
            bandedView.Bands.Add(gridBand);
        }
        public void Link_CreateMarginalHeaderArea(object sender, CreateAreaEventArgs e)
        {
            // ' For Report Title
            TextBrick BrickTitle = e.Graph.DrawString(lblReportHeader.Text, System.Drawing.Color.Navy, new RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20), DevExpress.XtraPrinting.BorderSide.None);
            BrickTitle.Font = new Font("Tahoma", 12, FontStyle.Bold);
            BrickTitle.HorzAlignment = DevExpress.Utils.HorzAlignment.Center;
            BrickTitle.VertAlignment = DevExpress.Utils.VertAlignment.Center;

            // ' For Group 
            TextBrick BrickTitleseller = e.Graph.DrawString("Group :- " + lblGroupBy.Text, System.Drawing.Color.Navy, new RectangleF(0, 25, e.Graph.ClientPageSize.Width, 20), DevExpress.XtraPrinting.BorderSide.None);
            BrickTitleseller.Font = new Font("Tahoma", 8, FontStyle.Bold);
            BrickTitleseller.HorzAlignment = DevExpress.Utils.HorzAlignment.Near;
            BrickTitleseller.VertAlignment = DevExpress.Utils.VertAlignment.Center;
            BrickTitleseller.ForeColor = Color.Black;

            // ' For Filter 
            TextBrick BrickTitlesParam = e.Graph.DrawString("Parameters :- " + lblFilter.Text, System.Drawing.Color.Navy, new RectangleF(0, 40, e.Graph.ClientPageSize.Width, 60), DevExpress.XtraPrinting.BorderSide.None);
            BrickTitlesParam.Font = new Font("Tahoma", 8, FontStyle.Bold);
            BrickTitlesParam.HorzAlignment = DevExpress.Utils.HorzAlignment.Near;
            BrickTitlesParam.VertAlignment = DevExpress.Utils.VertAlignment.Center;
            BrickTitlesParam.ForeColor = Color.Black;

            int IntX = Convert.ToInt32(Math.Round(e.Graph.ClientPageSize.Width - 400, 0));
            TextBrick BrickTitledate = e.Graph.DrawString("Print Date :- " + lblDateTime.Text, System.Drawing.Color.Navy, new RectangleF(IntX, 25, 400, 18), DevExpress.XtraPrinting.BorderSide.None);
            BrickTitledate.Font = new Font("Tahoma", 8, FontStyle.Bold);
            BrickTitledate.HorzAlignment = DevExpress.Utils.HorzAlignment.Far;
            BrickTitledate.VertAlignment = DevExpress.Utils.VertAlignment.Center;
            BrickTitledate.ForeColor = Color.Black;
        }
        public void Link_CreateMarginalFooterArea(object sender, CreateAreaEventArgs e)
        {
            int IntX = Convert.ToInt32(Math.Round(e.Graph.ClientPageSize.Width - 100, 0));

            PageInfoBrick BrickPageNo = e.Graph.DrawPageInfo(PageInfo.NumberOfTotal, "Page {0} of {1}", System.Drawing.Color.Navy, new RectangleF(IntX, 0, 100, 15), DevExpress.XtraPrinting.BorderSide.None);
            BrickPageNo.LineAlignment = BrickAlignment.Far;
            BrickPageNo.Alignment = BrickAlignment.Far;
            BrickPageNo.Font = new Font("Tahoma", 8, FontStyle.Bold); ;
            BrickPageNo.HorzAlignment = DevExpress.Utils.HorzAlignment.Far;
            BrickPageNo.VertAlignment = DevExpress.Utils.VertAlignment.Center;
        }

        public double GenerateTimeFieldSummry(GridView view, string Field)
        {
            if (view == null) return 0;

            if (Val.ToString(Field) == "") return 0;

            GridColumn TimetCol = view.Columns[Field];

            if (TimetCol == null) return 0;

            try
            {
                double totalWeight = 0;

                for (int i = 0; i < view.DataRowCount; i++)
                {
                    if (view.IsNewItemRow(i)) continue;

                    object temp;

                    double weight;

                    if (view.IsGroupRow(i))
                    {
                        temp = view.GetRowCellValue(i, TimetCol);
                    }
                    else
                    {
                        temp = view.GetRowCellValue(i, TimetCol);
                    }
                    temp = view.GetRowCellValue(i, TimetCol);
                    weight = (temp == DBNull.Value || temp == null) ? 0 : Val.Val(temp);
                    totalWeight += weight;
                }

                if (totalWeight == 0) return 0;

                string[] parts = totalWeight.ToString().Split('.');
                int i1 = Val.ToInt(parts[0]);
                int i2 = Val.ToInt(parts[1]);

                while (i2 > 60)
                {
                    i1 = i1 + 1;
                    i2 = i2 - 60;
                }
                return Val.Val(i1.ToString() + "." + i2.ToString());
            }
            catch
            {
                return 0;
            }
        }
        public double GetWeightedAverage(GridView view, string weightField, string valueField)
        {
            if (view == null) return 0;

            if (Val.ToString(weightField) == "" || Val.ToString(valueField) == "") return 0;

            GridColumn weightCol = view.Columns[weightField];

            GridColumn valueCol = view.Columns[valueField];

            if (weightCol == null || valueCol == null) return 0;

            try
            {
                double totalWeight = 0, totalValue = 0;

                for (int i = 0; i < view.DataRowCount; i++)
                {

                    if (view.IsNewItemRow(i)) continue;

                    object temp;

                    double weight, val;

                    temp = view.GetRowCellValue(i, weightCol);
                    weight = (temp == DBNull.Value || temp == null) ? 0 : Val.Val(temp);
                    temp = view.GetRowCellValue(i, valueCol);
                    val = (temp == DBNull.Value || temp == null) ? 0 : Val.Val(temp);
                    totalWeight += weight;
                    totalValue += weight * val;
                }
                if (totalWeight == 0) return 0;
                return Val.Val(totalValue / totalWeight);
            }
            catch
            {
                return 0;
            }
        }
        private void SetColumnsOrder(DataTable table, params String[] columnNames)
        {
            try
            {
                int columnIndex = 0;
                foreach (var columnName in columnNames)
                {
                    if (table.Columns.Contains(columnName))
                    {
                        table.Columns[columnName].SetOrdinal(columnIndex);
                        columnIndex++;
                    }
                }
            }
            catch (Exception Ex)
            { }
        }
        public void GridOrderByData(ref DataTable Dt)
        {
            GridColumnSortInfoCollection str = GridView1.SortInfo;
            int i = 0;
            int Count = str.Count();
            String FilterValue = "";
            String OrderBy = "";

            foreach (GridColumnSortInfo col in str)
            {
                i++;

                OrderBy = col.Column.SortOrder.ToString().ToUpper() == "ASCENDING" ? " ASC" : " DESC";

                if (Count == i)
                {
                    FilterValue += col.Column.FieldName + OrderBy;
                }
                else
                {
                    FilterValue += col.Column.FieldName + OrderBy + ",";
                }
            }
            Dt.DefaultView.Sort = FilterValue;
            Dt = Dt.DefaultView.ToTable();
            Dt.AcceptChanges();
        }
        public void GetGridFooterValue(ref DataTable Dt1)
        {
            try
            {
                DataRow DRow = Dt1.NewRow();
                string Str1 = "";
                foreach (GridColumn Column in GridView1.VisibleColumns)
                {
                    if (GridView1.Columns[Column.FieldName].SummaryText.ToString() != "")
                    {
                        if (Dt1.Columns.Contains(Column.FieldName))
                        {
                            DRow[Column.FieldName] = GridView1.Columns[Column.FieldName].SummaryText;
                            Str1 += DRow[Column.FieldName].ToString();
                        }
                    }
                }
                Dt1.Rows.Add(DRow);
            }
            catch (Exception Ex)
            { }
        }
        private void GetActiveFilterAndApply(ref DataTable Dt)
        {
            try
            {
                String FilterData = "";
                Int32 ActiveCriteAriaCount = GridView1.ActiveFilter.Count;
                int i = 1;
                foreach (ViewColumnFilterInfo info in GridView1.ActiveFilter)
                {
                    if (i == ActiveCriteAriaCount)
                        FilterData += info.Column.FilterInfo.FilterCriteria.ToString();
                    else
                        FilterData += info.Column.FilterInfo.FilterCriteria.ToString() + " AND ";
                    i++;
                }

                Dt = Dt.Select(String.Format("{0}", FilterData)).CopyToDataTable();

                Dt.AcceptChanges();
            }
            catch (Exception Ex)
            {
            }
        }
        private DataTable ConvertDataTableDataType(DataTable Dt1, DataTable destTable)
        {
            DataTable DTab1 = destTable;
            try
            {
                Dt1.AsEnumerable().ToList().ForEach(row => DTab1.ImportRow(row));
            }
            catch (Exception Ex)
            {
            }
            return DTab1;
        }
        public int GetGroupSummryIndex(string pStrFieldName)
        {
            int IntIndex = 0;
            foreach (GridGroupSummaryItem item in GridView1.GroupSummary)
            {
                if (item.FieldName.ToUpper() == pStrFieldName)
                {
                    IntIndex = item.Index;
                    break;
                }
            }
            return IntIndex;
        }
        private double GetPercent(int rowHandle, string pStrFieldName)
        {
            int IntIndex = GetGroupSummryIndex(pStrFieldName);
            int groupRow = GridView1.GetParentRowHandle(rowHandle);

            double part = 0;
            double total = 0;

            if (GridView1.IsGroupRow(groupRow))
            {
                if (pStrFieldName == "RR_CARAT")
                {
                    part = Val.Val(GridView1.GetRowCellValue(rowHandle, pStrFieldName));
                    total = Val.Val(GridView1.GetRowCellValue(rowHandle, "CONSUME_CARAT"));
                    total += Val.Val(GridView1.GetRowCellValue(rowHandle, pStrFieldName));
                }
                else if (pStrFieldName == "MAJOR_CARAT" || pStrFieldName == "MINOR_CARAT")
                {
                    part = Val.Val(GridView1.GetRowCellValue(rowHandle, pStrFieldName));
                    total = Val.Val(GridView1.GetGroupSummaryValue(groupRow, GridView1.GroupSummary[GetGroupSummryIndex("CONSUME_CARAT")] as DevExpress.XtraGrid.GridGroupSummaryItem));
                }
                else
                {
                    total = Val.Val(GridView1.GetGroupSummaryValue(groupRow, GridView1.GroupSummary[IntIndex] as DevExpress.XtraGrid.GridGroupSummaryItem));
                    part = Val.Val(GridView1.GetRowCellValue(rowHandle, pStrFieldName));
                }
            }
            else
            {
                if (pStrFieldName == "RR_CARAT")
                {
                    part = Val.Val(GridView1.GetRowCellValue(rowHandle, pStrFieldName));
                    total = Val.Val(GridView1.GetRowCellValue(rowHandle, "CONSUME_CARAT"));
                    total += Val.Val(GridView1.GetRowCellValue(rowHandle, pStrFieldName));
                }
                else if (pStrFieldName == "MAJOR_CARAT" || pStrFieldName == "MINOR_CARAT")
                {
                    part = Val.Val(GridView1.GetRowCellValue(rowHandle, pStrFieldName));
                    total = Val.Val(GridView1.Columns["CONSUME_CARAT"].Summary[0].SummaryValue);
                }
                else
                {
                    total = Val.Val(GridView1.Columns[pStrFieldName].Summary[0].SummaryValue);
                    part = Val.Val(GridView1.GetRowCellValue(rowHandle, pStrFieldName));
                }
            }
            return (total == 0) ? 0 : (part / total) * 100;
        }
        public void GetGroupRowPercentage(object sender, CustomSummaryEventArgs e, string pStrFieldName)
        {
            GridView view = sender as GridView;
            int IntIndex = GetGroupSummryIndex(pStrFieldName);

            if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize)
            {
                int IntParentSummryRowHandle = 0;
                int IntCurrentGroupRowHandle = 0;
                double total = 0;
                double part = 0;

                if (e.GroupLevel == -1)
                {
                    if (pStrFieldName == "RR_CARAT")
                    {
                        part = Val.Val(view.Columns[pStrFieldName].Summary[0].SummaryValue);
                        total = Val.Val(view.Columns[pStrFieldName].Summary[0].SummaryValue);
                        total += Val.Val(view.Columns["CONSUME_CARAT"].Summary[0].SummaryValue);
                    }
                    else if (pStrFieldName == "MAJOR_CARAT" || pStrFieldName == "MINOR_CARAT")
                    {
                        part = Val.Val(view.Columns[pStrFieldName].Summary[0].SummaryValue);
                        total = Val.Val(view.Columns["CONSUME_CARAT"].Summary[0].SummaryValue);
                    }
                    else
                    {
                        part = Val.Val(view.Columns[pStrFieldName].Summary[0].SummaryValue);
                        total = Val.Val(view.Columns[pStrFieldName].Summary[0].SummaryValue);
                    }
                }

                else if (e.GroupLevel == 0)
                {
                    IntCurrentGroupRowHandle = e.GroupRowHandle;

                    if (pStrFieldName == "RR_CARAT")
                    {
                        part = Val.Val(view.GetGroupSummaryValue(IntCurrentGroupRowHandle, (GridGroupSummaryItem)view.GroupSummary[IntIndex]));
                        total = Val.Val(view.GetGroupSummaryValue(IntCurrentGroupRowHandle, (GridGroupSummaryItem)view.GroupSummary[IntIndex]));
                        IntIndex = GetGroupSummryIndex("CONSUME_CARAT");
                        total += Val.Val(view.GetGroupSummaryValue(IntCurrentGroupRowHandle, (GridGroupSummaryItem)view.GroupSummary[IntIndex]));
                    }
                    else if (pStrFieldName == "MAJOR_CARAT" || pStrFieldName == "MINOR_CARAT")
                    {
                        part = Val.Val(view.GetGroupSummaryValue(IntCurrentGroupRowHandle, (GridGroupSummaryItem)view.GroupSummary[IntIndex]));
                        total = Val.Val(view.Columns["CONSUME_CARAT"].Summary[0].SummaryValue);
                    }
                    else
                    {
                        part = Val.Val(view.GetGroupSummaryValue(IntCurrentGroupRowHandle, (GridGroupSummaryItem)view.GroupSummary[IntIndex]));
                        total = Val.Val(view.Columns[pStrFieldName].Summary[0].SummaryValue);
                    }
                }

                else if (e.GroupLevel >= 1)
                {
                    IntParentSummryRowHandle = view.GetParentRowHandle(view.GetParentRowHandle(e.RowHandle));
                    IntCurrentGroupRowHandle = view.GetParentRowHandle(e.RowHandle);

                    if (pStrFieldName == "RR_CARAT")
                    {
                        part = Val.Val(view.GetGroupSummaryValue(IntCurrentGroupRowHandle, (GridGroupSummaryItem)view.GroupSummary[IntIndex]));
                        total = Val.Val(view.GetGroupSummaryValue(IntCurrentGroupRowHandle, (GridGroupSummaryItem)view.GroupSummary[IntIndex]));
                        IntIndex = GetGroupSummryIndex("CONSUME_CARAT");
                        total += Val.Val(view.GetGroupSummaryValue(IntCurrentGroupRowHandle, (GridGroupSummaryItem)view.GroupSummary[IntIndex]));
                    }
                    else if (pStrFieldName == "MAJOR_CARAT" || pStrFieldName == "MINOR_CARAT")
                    {
                        part = Val.Val(view.GetGroupSummaryValue(IntCurrentGroupRowHandle, (GridGroupSummaryItem)view.GroupSummary[IntIndex]));
                        total = Val.Val(view.GetGroupSummaryValue(IntParentSummryRowHandle, (GridGroupSummaryItem)view.GroupSummary[GetGroupSummryIndex("CONSUME_CARAT")]));
                    }
                    else
                    {
                        part = Val.Val(view.GetGroupSummaryValue(IntCurrentGroupRowHandle, (GridGroupSummaryItem)view.GroupSummary[IntIndex]));
                        total = Val.Val(view.GetGroupSummaryValue(IntParentSummryRowHandle, (GridGroupSummaryItem)view.GroupSummary[IntIndex]));
                    }
                }
                e.TotalValue = (total == 0) ? 0 : (part / total) * 100;
            }
        }
        public void FooterSummary()
        {
            try
            {
                GridView1.PostEditor();
            }
            catch (Exception Ex)
            {
            }
        }
        private static List<string> ExtractFromString(string text, string startString, string endString)
        {
            List<string> matched = new List<string>();
            int indexStart = 0, indexEnd = 0;
            bool exit = false;
            String FinalString = text;
            while (!exit)
            {
                indexStart = text.IndexOf(startString);
                indexEnd = text.IndexOf(endString);
                if (indexStart != -1 && indexEnd != -1)
                {
                    matched.Add(text.Substring(indexStart + startString.Length,
                        indexEnd - indexStart - startString.Length));

                    text = text.Substring(indexEnd + endString.Length);
                }
                else
                    exit = true;
            }
            return matched;
        }

        #endregion

        #region Grid Events
        private void GridView1_CellMerge(object sender, DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs e)
        {
            if (MergeOnStr.Contains(e.Column.FieldName))
            {
                int val1 = Val.ToInt(GridView1.GetRowCellValue(e.RowHandle1, GridView1.Columns[MergeOn]));
                int val2 = Val.ToInt(GridView1.GetRowCellValue(e.RowHandle2, GridView1.Columns[MergeOn]));
                if (val1 == val2)
                    e.Merge = true;
                e.Handled = true;
            }
        }
        private void GridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
        }
        private void GridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            try
            {
                e.Column.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.Excel;
            }
            catch (Exception ex)
            {
            }
        }
        private void GridView1_CustomDrawFooterCell(object sender, FooterCellCustomDrawEventArgs e)
        {

        }
        private void GridView1_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            if (Val.ToString(Remark).ToUpper().Equals("LEDGER_TRANSACTION"))
            {
                if (e.Column.FieldName.ToUpper().Contains("CREDIT") || e.Column.FieldName.ToUpper().Contains("DEBIT") || e.Column.FieldName.ToUpper().Contains("AMOUNT"))
                {
                    e.DisplayText = Val.FormatWithSeperator(e.DisplayText);
                }
            }

            else if (!Val.ToString(Remark).ToUpper().Equals("HR_SALARY_REPORT"))
            {
                if (e.DisplayText == "0.00" || e.DisplayText == "0" || e.DisplayText == "0.000")
                {
                    e.DisplayText = String.Empty;

                }
            }
        }
        private void GridView1_StartGrouping(object sender, EventArgs e)
        {
            GridView1.BestFitColumns();
        }
        private void GridView1_ColumnFilterChanged(object sender, EventArgs e)
        {
            FooterSummary();
        }

        private void GridView1_RowStyle(object sender, RowStyleEventArgs e)
        {
            if (!Val.ToString(Remark).Trim().Equals(string.Empty))
            {
                if (Remark.ToUpper().Equals("EMP_DAILY_REPORT"))
                {
                    if (e.RowHandle >= 0)
                    {
                        for (int i = 0; i < GridView1.Columns.Count; i++)
                        {
                            GridView1.Columns[i].AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
                        }
                    }
                }
            }
        }
        private void GridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (Remark == null || Remark.ToString().Trim().Equals(string.Empty))
                return;
            DataRow DR = GridView1.GetDataRow(e.RowHandle);
            if (DR == null)
                return;
        }

        private void GridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData == false)
            {
                return;
            }

            if (Val.ToString(ObjReportDetailProperty.Remark).ToUpper() == "TOTAL_ROUGH_TRANSFER")
            {
                if (e.Column.FieldName == "RR_PER")
                {
                    e.Value = GetPercent(e.ListSourceRowIndex, "RR_CARAT");
                }

                if (e.Column.FieldName == "READY_PER")
                {
                    e.Value = GetPercent(e.ListSourceRowIndex, "READY_CARAT");
                }

                if (e.Column.FieldName == "READY_PER")
                {
                    e.Value = GetPercent(e.ListSourceRowIndex, "READY_CARAT");
                }
                if (e.Column.FieldName == "CONSUME_CARAT_PER")
                {
                    e.Value = GetPercent(e.ListSourceRowIndex, "CONSUME_CARAT");
                }
                if (e.Column.FieldName == "CONSUME_PCS_PER")
                {
                    e.Value = GetPercent(e.ListSourceRowIndex, "CONSUME_PCS");
                }
            }
        }

        private void GridView1_CustomSummaryCalculate(object sender, CustomSummaryEventArgs e)
        {
            GridView view = sender as GridView;

            #region Stock Ledger Detail Report

            if (Val.ToString(ObjReportDetailProperty.Remark).ToUpper() == "STOCK_LEDGER_DETAILS")
            {
                if (e.SummaryProcess == CustomSummaryProcess.Start)
                {
                    DouOpeningCarat = 0;
                    DouOpeningAmount = 0;
                    DouConfirmCarat = 0;
                    DouConfirmAmount = 0;
                    DousaleCarat = 0;
                    DouSaleAmount = 0;
                    DouRapCarat = 0;
                    DouRapAmount = 0;
                    DouOnHandCarat = 0;
                    DouOnHandAmount = 0;
                    DouRealHandCarat = 0;
                    DouRealHandAmount = 0;
                    DouWeightLossCarat = 0;
                    DouWeightLossAmount = 0;
                    DouWeightPlusCarat = 0;
                    DouWeightPlusAmount = 0;
                    DouLostCarat = 0;
                    DouLostAmount = 0;

                }
                else if (e.SummaryProcess == CustomSummaryProcess.Calculate)
                {
                    DouOpeningCarat = DouOpeningCarat + Val.ToDecimal(GridView1.GetRowCellValue(e.RowHandle, "opening_carat"));
                    DouOpeningAmount = DouOpeningAmount + Val.ToDecimal(GridView1.GetRowCellValue(e.RowHandle, "opening_amount"));
                    DouConfirmCarat = DouConfirmCarat + Val.ToDecimal(GridView1.GetRowCellValue(e.RowHandle, "confirm_carat"));
                    DouConfirmAmount = DouConfirmAmount + Val.ToDecimal(GridView1.GetRowCellValue(e.RowHandle, "confirm_amount"));
                    DousaleCarat = DousaleCarat + Val.ToDecimal(GridView1.GetRowCellValue(e.RowHandle, "sale_carat"));
                    DouSaleAmount = DouSaleAmount + Val.ToDecimal(GridView1.GetRowCellValue(e.RowHandle, "sale_amount"));
                    DouRapCarat = DouRapCarat + Val.ToDecimal(GridView1.GetRowCellValue(e.RowHandle, "rep_carat"));
                    DouRapAmount = DouRapAmount + Val.ToDecimal(GridView1.GetRowCellValue(e.RowHandle, "rep_amount"));
                    DouOnHandCarat = DouOnHandCarat + Val.ToDecimal(GridView1.GetRowCellValue(e.RowHandle, "onhand_carat"));
                    DouOnHandAmount = DouOnHandAmount + Val.ToDecimal(GridView1.GetRowCellValue(e.RowHandle, "onhand_amount"));
                    DouRealHandCarat = DouRealHandCarat + Val.ToDecimal(GridView1.GetRowCellValue(e.RowHandle, "realhand_carat"));
                    DouRealHandAmount = DouRealHandAmount + Val.ToDecimal(GridView1.GetRowCellValue(e.RowHandle, "realhand_amount"));
                    DouWeightLossCarat = DouWeightLossCarat + Val.ToDecimal(GridView1.GetRowCellValue(e.RowHandle, "weight_loss_carat"));
                    DouWeightLossAmount = DouWeightLossAmount + Val.ToDecimal(GridView1.GetRowCellValue(e.RowHandle, "weight_loss_amount"));
                    DouWeightPlusCarat = DouWeightPlusCarat + Val.ToDecimal(GridView1.GetRowCellValue(e.RowHandle, "weight_plus_carat"));
                    DouWeightPlusAmount = DouWeightPlusAmount + Val.ToDecimal(GridView1.GetRowCellValue(e.RowHandle, "weight_plus_amount"));
                    DouLostCarat = DouLostCarat + Val.ToDecimal(GridView1.GetRowCellValue(e.RowHandle, "lost_carat"));
                    DouLostAmount = DouLostAmount + Val.ToDecimal(GridView1.GetRowCellValue(e.RowHandle, "lost_amount"));

                }
                else if (e.SummaryProcess == CustomSummaryProcess.Finalize)
                {
                    if (((GridSummaryItem)e.Item).FieldName.CompareTo("opening_rate") == 0)
                    {
                        if (DouOpeningCarat != 0)
                        {
                            e.TotalValue = Math.Round(DouOpeningAmount / DouOpeningCarat, 2);
                        }
                        else
                        {
                            e.TotalValue = 0;
                        }
                    }
                    else if (((GridSummaryItem)e.Item).FieldName.CompareTo("confirm_rate") == 0)
                    {
                        if (DouConfirmCarat != 0)
                        {
                            e.TotalValue = Math.Round(DouConfirmAmount / DouConfirmCarat, 2);
                        }
                        else
                        {
                            e.TotalValue = 0;
                        }
                    }
                    else if (((GridSummaryItem)e.Item).FieldName.CompareTo("sale_rate") == 0)
                    {
                        if (DousaleCarat != 0)
                        {
                            e.TotalValue = Math.Round(DouSaleAmount / DousaleCarat, 2);
                        }
                        else
                        {
                            e.TotalValue = 0;
                        }
                    }
                    else if (((GridSummaryItem)e.Item).FieldName.CompareTo("rep_rate") == 0)
                    {
                        if (DouRapCarat != 0)
                        {
                            e.TotalValue = Math.Round(DouRapAmount / DouRapCarat, 2);
                        }
                        else
                        {
                            e.TotalValue = 0;
                        }
                    }
                    else if (((GridSummaryItem)e.Item).FieldName.CompareTo("onhand_rate") == 0)
                    {
                        if (DouOnHandCarat != 0)
                        {
                            e.TotalValue = Math.Round(DouOnHandAmount / DouOnHandCarat, 2);
                        }
                        else
                        {
                            e.TotalValue = 0;
                        }
                    }
                    else if (((GridSummaryItem)e.Item).FieldName.CompareTo("realhand_rate") == 0)
                    {
                        if (DouRealHandCarat != 0)
                        {
                            e.TotalValue = Math.Round(DouRealHandAmount / DouRealHandCarat, 2);
                        }
                        else
                        {
                            e.TotalValue = 0;
                        }
                    }
                    else if (((GridSummaryItem)e.Item).FieldName.CompareTo("weight_loss_rate") == 0)
                    {
                        if (DouWeightLossCarat != 0)
                        {
                            e.TotalValue = Math.Round(DouWeightLossAmount / DouWeightLossCarat, 2);
                        }
                        else
                        {
                            e.TotalValue = 0;
                        }
                    }
                    else if (((GridSummaryItem)e.Item).FieldName.CompareTo("weight_plus_rate") == 0)
                    {
                        if (DouWeightPlusCarat != 0)
                        {
                            e.TotalValue = Math.Round(DouWeightPlusAmount / DouWeightPlusCarat, 2);
                        }
                        else
                        {
                            e.TotalValue = 0;
                        }
                    }
                    else if (((GridSummaryItem)e.Item).FieldName.CompareTo("lost_rate") == 0)
                    {
                        if (DouLostCarat != 0)
                        {
                            e.TotalValue = Math.Round(DouLostAmount / DouLostCarat, 2);
                        }
                        else
                        {
                            e.TotalValue = 0;
                        }
                    }

                }
            }
            #endregion

            #region Live Stock Report

            if (Val.ToString(ObjReportDetailProperty.Remark).ToUpper() == "LIVE_STOCK_REPORT")
            {
                if (e.SummaryProcess == CustomSummaryProcess.Start)
                {
                    DouClosingAmount = 0;
                    DouClosingCarat = 0;
                }
                else if (e.SummaryProcess == CustomSummaryProcess.Calculate)
                {
                    DouClosingCarat = DouClosingCarat + Val.ToDecimal(GridView1.GetRowCellValue(e.RowHandle, "cl_carat"));
                    DouClosingAmount = DouClosingAmount + Val.ToDecimal(GridView1.GetRowCellValue(e.RowHandle, "cl_amount"));
                }
                else if (e.SummaryProcess == CustomSummaryProcess.Finalize)
                {
                    if (((GridSummaryItem)e.Item).FieldName.CompareTo("cl_rate") == 0)
                    {
                        if (DouClosingCarat > 0)
                        {
                            e.TotalValue = Math.Round(DouClosingAmount / DouClosingCarat, 2);
                        }
                        else
                        {
                            e.TotalValue = 0;
                        }
                    }
                }
            }
            #endregion

            #region Stock Ledger In Out Report

            if (Val.ToString(ObjReportDetailProperty.Remark).ToUpper() == "STOCK_LEDGER_IN_OUT")
            {
                if (e.SummaryProcess == CustomSummaryProcess.Start)
                {
                    DouOpeningCarat = 0;
                    DouOpeningAmount = 0;
                    DouInCarat = 0;
                    DouInAmount = 0;
                    DouOutCarat = 0;
                    DouOutAmount = 0;
                    DouClosingAmount = 0;
                    DouClosingCarat = 0;
                }
                else if (e.SummaryProcess == CustomSummaryProcess.Calculate)
                {
                    DouOpeningCarat = DouOpeningCarat + Val.ToDecimal(GridView1.GetRowCellValue(e.RowHandle, "opening_carat"));
                    DouOpeningAmount = DouOpeningAmount + Val.ToDecimal(GridView1.GetRowCellValue(e.RowHandle, "opening_amount"));
                    DouInCarat = DouInCarat + Val.ToDecimal(GridView1.GetRowCellValue(e.RowHandle, "in_carat"));
                    DouInAmount = DouInAmount + Val.ToDecimal(GridView1.GetRowCellValue(e.RowHandle, "in_amount"));
                    DouOutCarat = DouOutCarat + Val.ToDecimal(GridView1.GetRowCellValue(e.RowHandle, "out_carat"));
                    DouOutAmount = DouOutAmount + Val.ToDecimal(GridView1.GetRowCellValue(e.RowHandle, "out_amount"));
                    DouClosingCarat = DouClosingCarat + Val.ToDecimal(GridView1.GetRowCellValue(e.RowHandle, "closing_carat"));
                    DouClosingAmount = DouClosingAmount + Val.ToDecimal(GridView1.GetRowCellValue(e.RowHandle, "closing_amount"));
                }
                else if (e.SummaryProcess == CustomSummaryProcess.Finalize)
                {
                    if (((GridSummaryItem)e.Item).FieldName.CompareTo("opening_rate") == 0)
                    {
                        if (DouOpeningCarat > 0)
                        {
                            e.TotalValue = Math.Round(DouOpeningAmount / DouOpeningCarat, 2);
                        }
                        else
                        {
                            e.TotalValue = 0;
                        }
                    }
                    else if (((GridSummaryItem)e.Item).FieldName.CompareTo("in_rate") == 0)
                    {
                        if (DouInCarat > 0)
                        {
                            e.TotalValue = Math.Round(DouInAmount / DouInCarat, 2);
                        }
                        else
                        {
                            e.TotalValue = 0;
                        }
                    }
                    else if (((GridSummaryItem)e.Item).FieldName.CompareTo("out_rate") == 0)
                    {
                        if (DouOutCarat > 0)
                        {
                            e.TotalValue = Math.Round(DouOutAmount / DouOutCarat, 2);
                        }
                        else
                        {
                            e.TotalValue = 0;
                        }
                    }
                    else if (((GridSummaryItem)e.Item).FieldName.CompareTo("closing_rate") == 0)
                    {
                        if (DouClosingCarat > 0)
                        {
                            e.TotalValue = Math.Round(DouClosingAmount / DouClosingCarat, 2);
                        }
                        else
                        {
                            e.TotalValue = 0;
                        }
                    }
                }
            }
            #endregion

            #region Polish Sale Report

            if (Val.ToString(ObjReportDetailProperty.Remark).ToUpper() == "POLISH_SALE_SUM_REPORT")
            {
                if (e.SummaryProcess == CustomSummaryProcess.Start)
                {
                    DouTotalAmount = 0;
                    DouTotalCarat = 0;
                }
                else if (e.SummaryProcess == CustomSummaryProcess.Calculate)
                {
                    DouTotalCarat = DouTotalCarat + Val.ToDecimal(GridView1.GetRowCellValue(e.RowHandle, "total_carat"));
                    DouTotalAmount = DouTotalAmount + Val.ToDecimal(GridView1.GetRowCellValue(e.RowHandle, "total_amount"));
                }
                else if (e.SummaryProcess == CustomSummaryProcess.Finalize)
                {
                    if (((GridSummaryItem)e.Item).FieldName.CompareTo("total_rate") == 0)
                    {
                        if (DouTotalCarat > 0)
                        {
                            e.TotalValue = Math.Round(DouTotalAmount / DouTotalCarat, 2);
                        }
                        else
                        {
                            e.TotalValue = 0;
                        }
                    }
                }
            }
            if (Val.ToString(ObjReportDetailProperty.Remark).ToUpper() == "POLISH_SALE_DET_REPORT")
            {
                if (e.SummaryProcess == CustomSummaryProcess.Start)
                {
                    DouTotalAmount = 0;
                    DouTotalCarat = 0;
                    DouCurrentAmount = 0;
                }
                else if (e.SummaryProcess == CustomSummaryProcess.Calculate)
                {
                    DouTotalCarat = DouTotalCarat + Val.ToDecimal(GridView1.GetRowCellValue(e.RowHandle, "carat"));
                    DouTotalAmount = DouTotalAmount + Val.ToDecimal(GridView1.GetRowCellValue(e.RowHandle, "amount"));
                    DouCurrentAmount = DouCurrentAmount + Val.ToDecimal(GridView1.GetRowCellValue(e.RowHandle, "current_amount"));
                }
                else if (e.SummaryProcess == CustomSummaryProcess.Finalize)
                {
                    if (((GridSummaryItem)e.Item).FieldName.CompareTo("rate") == 0)
                    {
                        if (DouTotalCarat > 0)
                        {
                            e.TotalValue = Math.Round(DouTotalAmount / DouTotalCarat, 2);
                        }
                        else
                        {
                            e.TotalValue = 0;
                        }
                    }
                    else if (((GridSummaryItem)e.Item).FieldName.CompareTo("current_rate") == 0)
                    {
                        if (DouTotalCarat != 0)
                        {
                            e.TotalValue = Math.Round(DouCurrentAmount / DouTotalCarat, 2);
                        }
                        else
                        {
                            e.TotalValue = 0;
                        }
                    }
                    else if (((GridSummaryItem)e.Item).FieldName.CompareTo("profit_loss") == 0)
                    {
                        if (DouTotalCarat != 0)
                        {
                            decimal numDiff = Math.Round(DouTotalAmount - DouCurrentAmount);

                            e.TotalValue = Math.Round(Val.ToDecimal(numDiff / DouTotalAmount) * 100, 2);
                        }
                        else
                        {
                            e.TotalValue = 0;
                        }
                    }
                }
            }
            #endregion

            #region Polish Purchase Report

            if (Val.ToString(ObjReportDetailProperty.Remark).ToUpper() == "POLISH_PURCHASE_SUM_REPORT")
            {
                if (e.SummaryProcess == CustomSummaryProcess.Start)
                {
                    DouTotalAmount = 0;
                    DouTotalCarat = 0;
                }
                else if (e.SummaryProcess == CustomSummaryProcess.Calculate)
                {
                    DouTotalCarat = DouTotalCarat + Val.ToDecimal(GridView1.GetRowCellValue(e.RowHandle, "total_carat"));
                    DouTotalAmount = DouTotalAmount + Val.ToDecimal(GridView1.GetRowCellValue(e.RowHandle, "total_amount"));
                }
                else if (e.SummaryProcess == CustomSummaryProcess.Finalize)
                {
                    if (((GridSummaryItem)e.Item).FieldName.CompareTo("total_rate") == 0)
                    {
                        if (DouTotalCarat > 0)
                        {
                            e.TotalValue = Math.Round(DouTotalAmount / DouTotalCarat, 2);
                        }
                        else
                        {
                            e.TotalValue = 0;
                        }
                    }
                }
            }
            if (Val.ToString(ObjReportDetailProperty.Remark).ToUpper() == "POLISH_PURCHASE_DET_REPORT")
            {
                if (e.SummaryProcess == CustomSummaryProcess.Start)
                {
                    DouTotalAmount = 0;
                    DouTotalCarat = 0;
                }
                else if (e.SummaryProcess == CustomSummaryProcess.Calculate)
                {
                    DouTotalCarat = DouTotalCarat + Val.ToDecimal(GridView1.GetRowCellValue(e.RowHandle, "carat"));
                    DouTotalAmount = DouTotalAmount + Val.ToDecimal(GridView1.GetRowCellValue(e.RowHandle, "amount"));
                }
                else if (e.SummaryProcess == CustomSummaryProcess.Finalize)
                {
                    if (((GridSummaryItem)e.Item).FieldName.CompareTo("rate") == 0)
                    {
                        if (DouTotalCarat > 0)
                        {
                            e.TotalValue = Math.Round(DouTotalAmount / DouTotalCarat, 2);
                        }
                        else
                        {
                            e.TotalValue = 0;
                        }
                    }
                }
            }
            #endregion

            #region Branch Transfer Report

            if (Val.ToString(ObjReportDetailProperty.Remark).ToUpper() == "BRANCH_TRANSFER_DET_REPORT")
            {
                if (e.SummaryProcess == CustomSummaryProcess.Start)
                {
                    DouTotalAmount = 0;
                    DouTotalCarat = 0;
                }
                else if (e.SummaryProcess == CustomSummaryProcess.Calculate)
                {
                    DouTotalCarat = DouTotalCarat + Val.ToDecimal(GridView1.GetRowCellValue(e.RowHandle, "carat"));
                    DouTotalAmount = DouTotalAmount + Val.ToDecimal(GridView1.GetRowCellValue(e.RowHandle, "amount"));
                }
                else if (e.SummaryProcess == CustomSummaryProcess.Finalize)
                {
                    if (((GridSummaryItem)e.Item).FieldName.CompareTo("rate") == 0)
                    {
                        if (DouTotalCarat > 0)
                        {
                            e.TotalValue = Math.Round(DouTotalAmount / DouTotalCarat, 2);
                        }
                        else
                        {
                            e.TotalValue = 0;
                        }
                    }
                }
            }
            #endregion

            #region Branch Confirm Report

            if (Val.ToString(ObjReportDetailProperty.Remark).ToUpper() == "BRANCH_CONFIRM_DET_REPORT")
            {
                if (e.SummaryProcess == CustomSummaryProcess.Start)
                {
                    DouTotalAmount = 0;
                    DouTotalCarat = 0;
                }
                else if (e.SummaryProcess == CustomSummaryProcess.Calculate)
                {
                    DouTotalCarat = DouTotalCarat + Val.ToDecimal(GridView1.GetRowCellValue(e.RowHandle, "carat"));
                    DouTotalAmount = DouTotalAmount + Val.ToDecimal(GridView1.GetRowCellValue(e.RowHandle, "amount"));
                }
                else if (e.SummaryProcess == CustomSummaryProcess.Finalize)
                {
                    if (((GridSummaryItem)e.Item).FieldName.CompareTo("rate") == 0)
                    {
                        if (DouTotalCarat > 0)
                        {
                            e.TotalValue = Math.Round(DouTotalAmount / DouTotalCarat, 2);
                        }
                        else
                        {
                            e.TotalValue = 0;
                        }
                    }
                }
            }
            #endregion

            #region Demand Noting Report

            if (Val.ToString(ObjReportDetailProperty.Remark).ToUpper() == "DEMAND_NOTING_REPORT")
            {
                if (e.SummaryProcess == CustomSummaryProcess.Start)
                {
                    DouTotalAmount = 0;
                    DouTotalCarat = 0;
                }
                else if (e.SummaryProcess == CustomSummaryProcess.Calculate)
                {
                    DouTotalCarat = DouTotalCarat + Val.ToDecimal(GridView1.GetRowCellValue(e.RowHandle, "carat"));
                    DouTotalAmount = DouTotalAmount + Val.ToDecimal(GridView1.GetRowCellValue(e.RowHandle, "amount"));
                }
                else if (e.SummaryProcess == CustomSummaryProcess.Finalize)
                {
                    if (((GridSummaryItem)e.Item).FieldName.CompareTo("rate") == 0)
                    {
                        if (DouTotalCarat > 0)
                        {
                            e.TotalValue = Math.Round(DouTotalAmount / DouTotalCarat, 2);
                        }
                        else
                        {
                            e.TotalValue = 0;
                        }
                    }
                }
            }
            #endregion

            #region Memo Issue Report

            if (Val.ToString(ObjReportDetailProperty.Remark).ToUpper() == "MEMO_ISSUE_SUMMARY")
            {
                if (e.SummaryProcess == CustomSummaryProcess.Start)
                {
                    DouTotalAmount = 0;
                    DouTotalCarat = 0;
                }
                else if (e.SummaryProcess == CustomSummaryProcess.Calculate)
                {
                    DouTotalCarat = DouTotalCarat + Val.ToDecimal(GridView1.GetRowCellValue(e.RowHandle, "carat"));
                    DouTotalAmount = DouTotalAmount + Val.ToDecimal(GridView1.GetRowCellValue(e.RowHandle, "amount"));
                }
                else if (e.SummaryProcess == CustomSummaryProcess.Finalize)
                {
                    if (((GridSummaryItem)e.Item).FieldName.CompareTo("rate") == 0)
                    {
                        if (DouTotalCarat > 0)
                        {
                            e.TotalValue = Math.Round(DouTotalAmount / DouTotalCarat, 2);
                        }
                        else
                        {
                            e.TotalValue = 0;
                        }
                    }
                }
            }
            #endregion

            #region Memo Receive Report

            if (Val.ToString(ObjReportDetailProperty.Remark).ToUpper() == "MEMO_RECEIVE_SUM_REPORT")
            {
                if (e.SummaryProcess == CustomSummaryProcess.Start)
                {
                    DouTotalAmount = 0;
                    DouTotalCarat = 0;
                    DouLostCarat = 0;
                    DouLostAmount = 0;
                    DouRejCarat = 0;
                    DouRejAmount = 0;
                }
                else if (e.SummaryProcess == CustomSummaryProcess.Calculate)
                {
                    DouTotalCarat = DouTotalCarat + Val.ToDecimal(GridView1.GetRowCellValue(e.RowHandle, "carat"));
                    DouTotalAmount = DouTotalAmount + Val.ToDecimal(GridView1.GetRowCellValue(e.RowHandle, "amount"));
                    DouLostCarat = DouLostCarat + Val.ToDecimal(GridView1.GetRowCellValue(e.RowHandle, "lost_carat"));
                    DouLostAmount = DouLostAmount + Val.ToDecimal(GridView1.GetRowCellValue(e.RowHandle, "lost_amount"));
                    DouRejCarat = DouRejCarat + Val.ToDecimal(GridView1.GetRowCellValue(e.RowHandle, "rej_carat"));
                    DouRejAmount = DouRejAmount + Val.ToDecimal(GridView1.GetRowCellValue(e.RowHandle, "rej_amount"));
                }
                else if (e.SummaryProcess == CustomSummaryProcess.Finalize)
                {
                    if (((GridSummaryItem)e.Item).FieldName.CompareTo("rate") == 0)
                    {
                        if (DouTotalCarat > 0)
                        {
                            e.TotalValue = Math.Round(DouTotalAmount / DouTotalCarat, 2);
                        }
                        else
                        {
                            e.TotalValue = 0;
                        }
                    }
                    else if (((GridSummaryItem)e.Item).FieldName.CompareTo("lost_rate") == 0)
                    {
                        if (DouLostCarat > 0)
                        {
                            e.TotalValue = Math.Round(DouLostAmount / DouLostCarat, 2);
                        }
                        else
                        {
                            e.TotalValue = 0;
                        }
                    }
                    else if (((GridSummaryItem)e.Item).FieldName.CompareTo("rej_rate") == 0)
                    {
                        if (DouRejCarat > 0)
                        {
                            e.TotalValue = Math.Round(DouRejAmount / DouRejCarat, 2);
                        }
                        else
                        {
                            e.TotalValue = 0;
                        }
                    }
                }
            }
            #endregion

            #region Rough Purchase Report

            if (Val.ToString(ObjReportDetailProperty.Remark).ToUpper() == "PURCHASE_MFG_SUMMARY")
            {
                if (e.SummaryProcess == CustomSummaryProcess.Start)
                {
                    DouTotalAmount = 0;
                    DouTotalCarat = 0;
                }
                else if (e.SummaryProcess == CustomSummaryProcess.Calculate)
                {
                    DouTotalCarat = DouTotalCarat + Val.ToDecimal(GridView1.GetRowCellValue(e.RowHandle, "carat"));
                    DouTotalAmount = DouTotalAmount + Val.ToDecimal(GridView1.GetRowCellValue(e.RowHandle, "amount"));
                }
                else if (e.SummaryProcess == CustomSummaryProcess.Finalize)
                {
                    if (((GridSummaryItem)e.Item).FieldName.CompareTo("rate") == 0)
                    {
                        if (DouTotalCarat > 0)
                        {
                            e.TotalValue = Math.Round(DouTotalAmount / DouTotalCarat, 2);
                        }
                        else
                        {
                            e.TotalValue = 0;
                        }
                    }
                }
            }
            #endregion

            #region Kapan MFG Report

            if (Val.ToString(ObjReportDetailProperty.Remark).ToUpper() == "MFG_KAPAN_SUMMARY")
            {
                if (e.SummaryProcess == CustomSummaryProcess.Start)
                {
                    DouTotalAmount = 0;
                    DouTotalCarat = 0;
                }
                else if (e.SummaryProcess == CustomSummaryProcess.Calculate)
                {
                    DouTotalCarat = DouTotalCarat + Val.ToDecimal(GridView1.GetRowCellValue(e.RowHandle, "carat"));
                    DouTotalAmount = DouTotalAmount + Val.ToDecimal(GridView1.GetRowCellValue(e.RowHandle, "amount"));
                }
                else if (e.SummaryProcess == CustomSummaryProcess.Finalize)
                {
                    if (((GridSummaryItem)e.Item).FieldName.CompareTo("rate") == 0)
                    {
                        if (DouTotalCarat > 0)
                        {
                            e.TotalValue = Math.Round(DouTotalAmount / DouTotalCarat, 2);
                        }
                        else
                        {
                            e.TotalValue = 0;
                        }
                    }
                }
            }
            #endregion

            #region  Rough Cut Report

            if (Val.ToString(ObjReportDetailProperty.Remark).ToUpper() == "MFG_ROUGHCUT_SUMMARY")
            {
                if (e.SummaryProcess == CustomSummaryProcess.Start)
                {
                    DouTotalAmount = 0;
                    DouTotalCarat = 0;
                }
                else if (e.SummaryProcess == CustomSummaryProcess.Calculate)
                {
                    DouTotalCarat = DouTotalCarat + Val.ToDecimal(GridView1.GetRowCellValue(e.RowHandle, "carat"));
                    DouTotalAmount = DouTotalAmount + Val.ToDecimal(GridView1.GetRowCellValue(e.RowHandle, "amount"));
                }
                else if (e.SummaryProcess == CustomSummaryProcess.Finalize)
                {
                    if (((GridSummaryItem)e.Item).FieldName.CompareTo("rate") == 0)
                    {
                        if (DouTotalCarat > 0)
                        {
                            e.TotalValue = Math.Round(DouTotalAmount / DouTotalCarat, 2);
                        }
                        else
                        {
                            e.TotalValue = 0;
                        }
                    }
                }
            }
            #endregion

            #region  Rough Stock Report

            if (Val.ToString(ObjReportDetailProperty.Remark).ToUpper() == "MFG_ROUGHSTK_SUMMARY")
            {
                if (e.SummaryProcess == CustomSummaryProcess.Start)
                {
                    DouTotalAmount = 0;
                    DouTotalCarat = 0;
                }
                else if (e.SummaryProcess == CustomSummaryProcess.Calculate)
                {
                    DouTotalCarat = DouTotalCarat + Val.ToDecimal(GridView1.GetRowCellValue(e.RowHandle, "balance_carat"));
                    DouTotalAmount = DouTotalAmount + Val.ToDecimal(GridView1.GetRowCellValue(e.RowHandle, "amount"));
                }
                else if (e.SummaryProcess == CustomSummaryProcess.Finalize)
                {
                    if (((GridSummaryItem)e.Item).FieldName.CompareTo("rate") == 0)
                    {
                        if (DouTotalCarat > 0)
                        {
                            e.TotalValue = Math.Round(DouTotalAmount / DouTotalCarat, 2);
                        }
                        else
                        {
                            e.TotalValue = 0;
                        }
                    }
                }
            }
            #endregion

            #region  Process Receive Report

            if (Val.ToString(ObjReportDetailProperty.Remark).ToUpper() == "MFG_PROCESS_RECEIVE_SUMMARY")
            {
                if (e.SummaryProcess == CustomSummaryProcess.Start)
                {
                    DouTotalAmount = 0;
                    DouTotalCarat = 0;
                }
                else if (e.SummaryProcess == CustomSummaryProcess.Calculate)
                {
                    DouTotalCarat = DouTotalCarat + Val.ToDecimal(GridView1.GetRowCellValue(e.RowHandle, "carat"));
                    DouTotalAmount = DouTotalAmount + Val.ToDecimal(GridView1.GetRowCellValue(e.RowHandle, "amount"));
                }
                else if (e.SummaryProcess == CustomSummaryProcess.Finalize)
                {
                    if (((GridSummaryItem)e.Item).FieldName.CompareTo("rate") == 0)
                    {
                        if (DouTotalCarat > 0)
                        {
                            e.TotalValue = Math.Round(DouTotalAmount / DouTotalCarat, 2);
                        }
                        else
                        {
                            e.TotalValue = 0;
                        }
                    }
                }
            }
            #endregion

            #region Mix Split Report
            if (Val.ToString(ObjReportDetailProperty.Remark).ToUpper() == "MIX_SPLIT_REPORT_FORMAT1")
            {
                if (e.SummaryProcess == CustomSummaryProcess.Start)
                {
                    DouTotalAmount = 0;
                    DouTotalCarat = 0;
                }
                else if (e.SummaryProcess == CustomSummaryProcess.Calculate)
                {
                    DouTotalCarat = DouTotalCarat + Val.ToDecimal(GridView1.GetRowCellValue(e.RowHandle, "carat"));
                    DouTotalAmount = DouTotalAmount + Val.ToDecimal(GridView1.GetRowCellValue(e.RowHandle, "amount"));
                }
                else if (e.SummaryProcess == CustomSummaryProcess.Finalize)
                {
                    if (((GridSummaryItem)e.Item).FieldName.CompareTo("rate") == 0)
                    {
                        if (DouTotalCarat > 0)
                        {
                            e.TotalValue = Math.Round(DouTotalAmount / DouTotalCarat, 2);
                        }
                        else
                        {
                            e.TotalValue = 0;
                        }
                    }
                }
            }
            #endregion

            #region  MFG Stock Report

            if (Val.ToString(ObjReportDetailProperty.Remark).ToUpper() == "MFG_STOCK_SUMMARY")
            {
                if (e.SummaryProcess == CustomSummaryProcess.Start)
                {
                    DouTotalAmount = 0;
                    DouTotalCarat = 0;
                    DouPrdAmount = 0;
                }
                else if (e.SummaryProcess == CustomSummaryProcess.Calculate)
                {
                    DouTotalCarat = DouTotalCarat + Val.ToDecimal(GridView1.GetRowCellValue(e.RowHandle, "balance_carat"));
                    DouTotalAmount = DouTotalAmount + Val.ToDecimal(GridView1.GetRowCellValue(e.RowHandle, "amount"));
                    DouPrdAmount = DouPrdAmount + Val.ToDecimal(GridView1.GetRowCellValue(e.RowHandle, "prd_amount"));
                }
                else if (e.SummaryProcess == CustomSummaryProcess.Finalize)
                {
                    if (((GridSummaryItem)e.Item).FieldName.CompareTo("rate") == 0)
                    {
                        if (DouTotalCarat > 0)
                        {
                            e.TotalValue = Math.Round(DouTotalAmount / DouTotalCarat, 2);
                        }
                        else
                        {
                            e.TotalValue = 0;
                        }
                    }
                    if (((GridSummaryItem)e.Item).FieldName.CompareTo("prd_rate") == 0)
                    {
                        if (DouTotalCarat > 0)
                        {
                            e.TotalValue = Math.Round(DouPrdAmount / DouTotalCarat, 2);
                        }
                        else
                        {
                            e.TotalValue = 0;
                        }
                    }
                }
            }
            #endregion
            #region "Credit Debit Report"

            if (Val.ToString(ObjReportDetailProperty.Remark).ToUpper() == "CREDIT_DEBIT_REPORT")
            {
                if (e.SummaryProcess == CustomSummaryProcess.Start)
                {
                    DouTotalAmount = 0;
                }
                else if (e.SummaryProcess == CustomSummaryProcess.Calculate)
                {

                    DouTotalAmount = DouTotalAmount + Val.ToDecimal(GridView1.GetRowCellValue(e.RowHandle, "Credit_Amt")) - Val.ToDecimal(GridView1.GetRowCellValue(e.RowHandle, "Debit_Amt"));
                }
                else if (e.SummaryProcess == CustomSummaryProcess.Finalize)
                {
                    if (((GridSummaryItem)e.Item).FieldName.CompareTo("Balance") == 0)
                    {
                        if (DouTotalAmount > 0)
                        {
                            e.TotalValue = Math.Round(DouTotalAmount, 2);
                        }
                        else
                        {
                            e.TotalValue = 0;
                        }
                    }
                }
            }
            #endregion
        }
        #endregion

        #region Events
        private void MNGroupEnableDisable_Click(object sender, EventArgs e)
        {
            if (MNRemoveGroup.Text == "Disable Groups")
            {
                while (GridView1.GroupedColumns.Count != 0)
                {
                    GridView1.GroupedColumns[GridView1.GroupedColumns.Count - 1].UnGroup();
                }
                MNRemoveGroup.Text = "Enable Groups";
            }
            else
            {
                foreach (string Str in Val.ToString(Group_By_Tag).Split(','))
                {
                    if (Str != "")
                    {
                        GridView1.Columns[Str].Group();
                    }
                }
                MNRemoveGroup.Text = "Disable Groups";
            }
            ExpandTool_Click(null, null);
        }
        private void MNFilter_Click(object sender, EventArgs e)
        {
            GridView1.BeginUpdate();
            if (ISFilter == true)
            {
                ISFilter = false;
                MNFilter.Text = "Add Filter";
                GridView1.OptionsView.ShowAutoFilterRow = false;
            }
            else
            {
                ISFilter = true;
                MNFilter.Text = "Remove Filter";
                GridView1.OptionsView.ShowAutoFilterRow = true;
            }
            GridView1.EndUpdate();
        }
        private void MNColumnChooser_Click(object sender, EventArgs e)
        {
        }
        private void EmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ObjPer.AllowEMail == false)
            {
                Global.Message(BLL.GlobalDec.gStrPermissionEMailMsg);
                return;
            }

            string StrFile = Global.DataGridExportToExcel(GridView1, "Report");

            Utility.FrmEmailSend FrmEmailSend = new Utility.FrmEmailSend();
            FrmEmailSend.mStrSubject = lblReportHeader.Text;
            FrmEmailSend.mStrAttachments = StrFile;
            FrmEmailSend.ShowForm();
            FrmEmailSend = null;

            if (File.Exists(StrFile))
            {
                File.Delete(StrFile);
            }
            this.Focus();
        }
        private void TsmExportData_Click(object sender, EventArgs e)
        {
            if (Article_Name == "")
            {
                Global.Message("Enter Article Name For Export Data ...");
                return;
            }

            if (MSize_Name == "")
            {
                Global.Message("Enter MSize Name For Export Data ...");
                return;
            }
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            btnRefresh.Enabled = false;
            ReportParams ObjReportParams = new ReportParams();
            this.Cursor = Cursors.WaitCursor;
            btnRefresh.Enabled = false;
            decimal numBalance = 0;

            if (FilterByFormName.Equals("FrmStockReport"))
            {
                DTab = new DataTable();
                DTab = ObjReportParams.GetLiveStock(ReportParams_Property, ObjReportDetailProperty.Procedure_Name);
            }
            if (FilterByFormName.Equals("FrmProcessRecieveReport"))
            {
                DTab = new DataTable();
                DTab = ObjReportParams.GetIssuePendingStock(ReportParams_Property, ObjReportDetailProperty.Procedure_Name);
            }
            if (FilterByFormName.Equals("FrmDailyLedgerBook"))
            {
                DTab = new DataTable();
                DTab = ObjReportParams.Get_Transaction_View_Report(ReportParams_Property, ObjReportDetailProperty.Procedure_Name);

                if (Val.Trim(ReportParams_Property.ledger_id) != "")
                {
                    if (ObjReportDetailProperty.Remark == "Credit_Debit_Ledger_Book")
                    {
                        int count = DTab.Rows.Count;
                        foreach (DataRow Dr in DTab.Rows)
                        {
                            if (Val.ToDecimal(Dr["credit_amount"]) > 0 || Val.ToDecimal(Dr["debit_amount"]) > 0)
                            {
                            }
                            else
                            {
                                count--;
                                if (count > 0)
                                {
                                    Dr[0] = string.Empty;
                                    Dr.Delete();
                                }
                            }
                        }
                    }
                }
                if (Val.ToString(ObjReportDetailProperty.Remark) == "Payment_Pending_Remark")
                {
                    foreach (DataRow Drw in DTab.Rows)
                    {
                        numBalance = numBalance + Val.ToDecimal(Drw["opening_amount"]) + Val.ToDecimal(Drw["sale_amount"]) - Val.ToDecimal(Drw["receive_amount"]);
                        Drw["closing_amount"] = numBalance;
                    }
                }
            }
            GridControl1.DataSource = DTab;
            GridControl1.RefreshDataSource();
            GridControl1.Refresh();
            GridView1.RefreshData();

            this.Cursor = Cursors.Default;
            btnRefresh.Enabled = true;
        }

        #endregion

        private static void SetLvlBackColor(DevExpress.XtraGrid.Views.Grid.GroupLevelStyleEventArgs e, Color lvlBackColor)
        {
            e.LevelAppearance.BackColor = lvlBackColor;
            e.LevelAppearance.ForeColor = Color.Black;
        }

        private void GridView1_GroupLevelStyle(object sender, GroupLevelStyleEventArgs e)
        {
            var lvl = e.Level;
            switch (lvl)
            {
                case 0:
                    SetLvlBackColor(e, Color.FromArgb(163, 196, 188));
                    break;
                case 1:
                    SetLvlBackColor(e, Color.FromArgb(98, 146, 158));
                    break;
                case 2:
                    SetLvlBackColor(e, Color.FromArgb(88, 123, 127));
                    break;
                case 3:
                    SetLvlBackColor(e, Color.FromArgb(244, 247, 245));
                    break;
                case 4:
                    SetLvlBackColor(e, Color.FromArgb(207, 232, 239));
                    break;
                case 5:
                    SetLvlBackColor(e, Color.FromArgb(198, 224, 180));
                    break;
                case 6:
                    SetLvlBackColor(e, Color.FromArgb(248, 203, 173));
                    break;
                case 7:
                    SetLvlBackColor(e, Color.FromArgb(199, 157, 245));
                    break;
                case 8:
                    SetLvlBackColor(e, Color.FromArgb(150, 174, 252));
                    break;
                case 9:
                    SetLvlBackColor(e, Color.FromArgb(192, 181, 221));
                    break;
                case 10:
                    SetLvlBackColor(e, Color.FromArgb(225, 231, 171));
                    break;
            }
        }

        private void GridView1_PrintInitialize(object sender, PrintInitializeEventArgs e)
        {
            PrintingSystemBase pb = e.PrintingSystem as PrintingSystemBase;
            pb.PageSettings.Landscape = true;
            pb.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A3;
        }
    }
}
