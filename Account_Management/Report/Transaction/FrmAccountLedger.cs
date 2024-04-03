using Account_Management.Transaction;
using BLL;
using BLL.FunctionClasses.Report;
using BLL.PropertyClasses.Report;
using DevExpress.Data;
using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
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
using System.Reflection;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Global = Account_Management.Class.Global;
namespace Account_Management.Report
{
    public partial class FrmAccountLedger : DevExpress.XtraEditors.XtraForm
    {
        #region Delcaration

        Excel.Application myExcelApplication;
        Excel.Workbook myExcelWorkbook;
        Excel.Worksheet myExcelWorkSheet;

        private DataSet _DS = new DataSet();
        public DataSet DS
        {
            get { return _DS; }
            set { _DS = value; }
        }

        public New_Report_DetailProperty ObjReportDetailProperty = new New_Report_DetailProperty();
        NewReportMaster ObjReport = new NewReportMaster();
        New_Report_MasterProperty ObjReportMasterProperty = new New_Report_MasterProperty();
        ReportParams_Property ReportParams_Property = new BLL.PropertyClasses.Report.ReportParams_Property();

        ReportParams ObjReportParams = new ReportParams();
        FillCombo ObjFillCombo = new FillCombo();

        BLL.FormEvents objBOFormEvents = new BLL.FormEvents();
        BLL.Validation Val = new BLL.Validation();
        BLL.FormPer ObjPer = new BLL.FormPer();

        string MergeOnStr = string.Empty;
        string MergeOn = string.Empty;
        Boolean ISFilter = false;
        public Boolean IsPivot = false;

        public string RepName = string.Empty;
        public string RepPara = string.Empty;
        public string GroupBy = string.Empty;
        public bool AllowSetFormula = false;

        public int ReceiptDays = 0;
        public double DouExpDiff = 0;
        public string BandConsumeCaption = "";
        public string BandConsumeWithProcessCaption = "";

        /// <summary>
        ////
        /// </summary>

        decimal DouTaliya = 0;
        decimal DouTaliyaCnt = 0;
        decimal DouMathala = 0;
        decimal DouMathalaCnt = 0;
        decimal DouPel = 0;
        decimal DouPelCnt = 0;
        decimal DouTable = 0;
        decimal DouTableCnt = 0;

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

        private DataSet _DTab_Set = new DataSet();

        public DataSet DTab_Set
        {
            get { return _DTab_Set; }
            set { _DTab_Set = value; }
        }

        private string _Group_By_Tag;

        public string Group_By_Tag
        {
            get { return _Group_By_Tag; }
            set { _Group_By_Tag = value; }
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

        public string R_Date;
        public string Shape_Name;
        public string Article_Name;
        public string MSize_Name;

        private string _Procedure_Name;

        public string Procedure_Name
        {
            get { return _Procedure_Name; }
            set { _Procedure_Name = value; }
        }
        private string _FilterByFormName;
        public string FilterByFormName
        {
            get { return _FilterByFormName; }
            set { _FilterByFormName = value; }
        }
        #endregion

        #endregion

        #region Constructor
        public FrmAccountLedger()
        {
            InitializeComponent();
        }
        public void ShowForm()
        {
            ObjPer.FormName = this.Name.ToUpper();
            if (ObjPer.CheckPermission() == false)
            {
                Global.Message(BLL.GlobalDec.gStrPermissionViwMsg);
                return;
            }
            if (Global.CheckDefault() == 0)
            {
                Global.Message("Please Check User Default Setting");
                this.Close();
                return;
            }
            Val.frmGenSet(this);
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
            Export("xls", DgvAccountLedger);
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
                            //op.ExportType = DevExpress.Export.ExportType.Default;
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
                            //opx.ExportType = DevExpress.Export.ExportType.Default;
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
                myExcelWorkSheet.Cells[1, 1] = "Report Name :- " + ReportHeaderName;
                //Excel.Range line1 = (Excel.Range)myExcelWorkSheet.Rows[2];
                //line1.Insert();
                ////myExcelWorkSheet.Cells[2, 1] = "Group :- " + lblGroupBy.Text;
                //Excel.Range line2 = (Excel.Range)myExcelWorkSheet.Rows[3];
                //line2.Insert();
                ////myExcelWorkSheet.Cells[3, 1] = "Parameters :- " + lblFilter.Text;
                Excel.Range line1 = (Excel.Range)myExcelWorkSheet.Rows[2];
                line1.Insert();
                myExcelWorkSheet.Cells[2, 1] = "Print Date :- " + System.DateTime.Now.ToString();

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

                if (Global.Confirm("Export Done\n\nYou Want To Open Excel File ?", "DERP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
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
            Export("xlsx", DgvAccountLedger);
        }
        private void ToText_Click(object sender, EventArgs e)
        {
            Global.Export("txt", DgvAccountLedger);
        }
        private void ToHTML_Click(object sender, EventArgs e)
        {
            Global.Export("html", DgvAccountLedger);
        }
        private void ToRTF_Click(object sender, EventArgs e)
        {
            Global.Export("rtf", DgvAccountLedger);
        }
        private void ToPDF_Click(object sender, EventArgs e)
        {
            //Global.Export("pdf", GridView1);
            Export("pdf", "Export Report to PDF", "PDF (*.PDF)|*.PDF");
        }
        private void AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DgvAccountLedger.BestFitColumns();
        }
        private void ExpandTool_Click(object sender, EventArgs e)
        {
            DgvAccountLedger.ExpandAllGroups();
        }
        private void Collapse_Click(object sender, EventArgs e)
        {
            DgvAccountLedger.CollapseAllGroups();
        }
        private void PrintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DevExpress.XtraPrinting.PrintingSystem PrintSystem = new DevExpress.XtraPrinting.PrintingSystem();

                PrinterSettingsUsing pst = new PrinterSettingsUsing();

                PrintSystem.PageSettings.AssignDefaultPrinterSettings(pst);


                PrintableComponentLink link = new PrintableComponentLink(PrintSystem);

                link.Component = GrdAccountLedger;

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
                    DgvAccountLedger.OptionsPrint.ExpandAllGroups = true;
                }
                else
                {
                    DgvAccountLedger.OptionsPrint.ExpandAllGroups = false;
                }

                DgvAccountLedger.OptionsPrint.AutoWidth = true;

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
            dtpFromDate.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
            dtpFromDate.Properties.Mask.EditMask = "dd-MM-yyyy";
            dtpFromDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            dtpFromDate.Properties.CharacterCasing = CharacterCasing.Upper;
            dtpFromDate.EditValue = DateTime.Now;
            DateTime now = DateTime.Now;
            dtpFromDate.EditValue = new DateTime(now.Year, now.Month, 1);

            dtpToDate.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
            dtpToDate.Properties.Mask.EditMask = "dd-MM-yyyy";
            dtpToDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            dtpToDate.Properties.CharacterCasing = CharacterCasing.Upper;
            dtpToDate.EditValue = DateTime.Now;

            Global.LOOKUPCashBankWithoutLedger(lueLedger);
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
            DgvAccountLedger.OptionsPrint.ExpandAllDetails = true;
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
                            PreviewPrintableComponent_PDF(GrdAccountLedger, GrdAccountLedger.LookAndFeel, Filepath);
                            // GridView1.ExportToPdf(Filepath);
                            break;
                        case "xls":
                            PreviewPrintableComponent(GrdAccountLedger, GrdAccountLedger.LookAndFeel, Filepath);
                            break;
                        case "xlsx":
                            PreviewPrintableComponent(GrdAccountLedger, GrdAccountLedger.LookAndFeel, Filepath);
                            break;
                        case "rtf":
                            DgvAccountLedger.ExportToRtf(Filepath);
                            break;
                        case "txt":
                            gvlink = (DevExpress.XtraGrid.Export.GridViewExportLink)DgvAccountLedger.CreateExportLink(new DevExpress.XtraExport.ExportTxtProvider(Filepath));

                            gvlink.ExportAll = true;
                            gvlink.ExpandAll = true;
                            gvlink.ExportDetails = true;
                            gvlink.ExportTo(true);
                            break;
                        case "html":

                            gvlink = (DevExpress.XtraGrid.Export.GridViewExportLink)DgvAccountLedger.CreateExportLink(new DevExpress.XtraExport.ExportHtmlProvider(Filepath));

                            gvlink.ExportAll = true;
                            gvlink.ExpandAll = true;
                            gvlink.ExportDetails = true;
                            gvlink.ExportTo(true);
                            break;
                    }
                    if (Global.Confirm("Export Done\n\nYou Want To Open PDF File ?", "DERP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(Filepath);
                    }
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
            GrdAccountLedger.DataSource = null;
            DgvAccountLedger.Columns.Clear();
            //DgvAccountLedger.Bands.Clear();
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

                GrdAccountLedger.DataSource = DTab;
                DgvAccountLedger.OptionsView.AllowCellMerge = true;

                // DgvAccountLedger.Bands.AddBand(ReportHeaderName);

                foreach (DataRow DRow in mDTDetail.Rows)
                {
                    if (Val.ToBoolean(DRow["visible"].ToString()) == true && Val.ToBoolean(DRow["is_unbound"]) == true)
                    {
                        DevExpress.XtraGrid.Columns.GridColumn unbColumn = DgvAccountLedger.Columns.AddField(Val.ToString(DRow["field_name"]));
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
                            DgvAccountLedger.Columns[DRow["field_name"].ToString()].Visible = false;
                            continue;
                        }

                        if (Val.ToBoolean(DRow["ismerge"].ToString()) == false)
                        {
                            DgvAccountLedger.Columns[DRow["field_name"].ToString()].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                        }
                        if (Val.ToInt64(DRow["width"].ToString()) != 0)
                        {
                            DgvAccountLedger.Columns[DRow["field_name"].ToString()].Width = Val.ToInt(DRow["width"].ToString());
                        }

                        //Set Column Caption
                        DgvAccountLedger.Columns[DRow["field_name"].ToString()].Caption = DRow["column_name"].ToString();
                        DgvAccountLedger.Columns[DRow["field_name"].ToString()].Tag = DRow["field_name"].ToString();
                        DgvAccountLedger.Columns[DRow["field_name"].ToString()].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
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
                                //StrFormat = "###################0.000";
                                StrFormat = "###################,##,###,0.000";
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
                            DgvAccountLedger.Columns[DRow["field_name"].ToString()].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                            break;
                        case "right":
                            DgvAccountLedger.Columns[DRow["field_name"].ToString()].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                            break;
                        case "center":
                            DgvAccountLedger.Columns[DRow["field_name"].ToString()].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                            break;
                        default:
                            DgvAccountLedger.Columns[DRow["field_name"].ToString()].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
                            break;
                    }

                    /* Set Order */
                    switch (DRow["order_by"].ToString().ToUpper())
                    {
                        case "ASC":
                            DgvAccountLedger.Columns[DRow["field_name"].ToString()].SortOrder = ColumnSortOrder.Ascending;
                            break;
                        case "DESC":
                            DgvAccountLedger.Columns[DRow["field_name"].ToString()].SortOrder = ColumnSortOrder.Descending;
                            break;
                        default:
                            DgvAccountLedger.Columns[DRow["field_name"].ToString()].SortOrder = ColumnSortOrder.None;
                            break;
                    }

                    DgvAccountLedger.Columns[DRow["field_name"].ToString()].OptionsColumn.AllowEdit = false;
                    DgvAccountLedger.Columns[DRow["field_name"].ToString()].DisplayFormat.FormatString = StrFormat;
                    DgvAccountLedger.Columns[DRow["field_name"].ToString()].VisibleIndex = Val.ToInt(DRow["sequence_no"]);

                    foreach (GridBand band in AL)
                    {
                        //if (band.Caption == Val.ToString(DRow["bands"]))
                        //{
                        //    DgvAccountLedger.Columns[DRow["field_name"].ToString()].OwnerBand = band;

                        //    bool ISExists = false;

                        //    foreach (GridBand band1 in DgvAccountLedger.Bands[0].Children)
                        //    {
                        //        if (band1.Caption == band.Caption)
                        //        {
                        //            ISExists = true;
                        //            break;
                        //        }
                        //    }

                        //    if (ISExists == false)
                        //    {
                        //        //DgvAccountLedger.Bands[0].Children.Add(band);
                        //        //DgvAccountLedger.Bands[0].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        //        //band.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        //        //DgvAccountLedger.Columns[DRow["field_name"].ToString()].OwnerBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        //    }
                        //    break;
                        //}
                    }

                    // Set Summry Field and group Summry Also

                    if (Val.ToBoolean(DRow["visible"].ToString()) == true && Val.ToBoolean(DRow["ismerge"].ToString()) == false)
                    {
                        switch (DRow["aggregate"].ToString().ToUpper())
                        {
                            case "SUM":
                                DgvAccountLedger.Columns[DRow["field_name"].ToString()].Summary.Add(SummaryItemType.Sum, DRow["field_name"].ToString(), StrSummryFormat);
                                DgvAccountLedger.GroupSummary.Add(SummaryItemType.Sum, DRow["field_name"].ToString(), DgvAccountLedger.Columns[DRow["field_name"].ToString()], StrSummryFormat);
                                break;
                            case "AVG":
                                DgvAccountLedger.Columns[DRow["field_name"].ToString()].Summary.Add(SummaryItemType.Average, DRow["field_name"].ToString(), StrSummryFormat);
                                DgvAccountLedger.GroupSummary.Add(SummaryItemType.Average, DRow["field_name"].ToString(), DgvAccountLedger.Columns[DRow["field_name"].ToString()], StrSummryFormat);
                                break;
                            case "COUNT":
                                DgvAccountLedger.Columns[DRow["field_name"].ToString()].Summary.Add(SummaryItemType.Count, DRow["field_name"].ToString(), StrSummryFormat);
                                DgvAccountLedger.GroupSummary.Add(SummaryItemType.Count, DRow["field_name"].ToString(), DgvAccountLedger.Columns[DRow["field_name"].ToString()], StrSummryFormat);
                                break;
                            case "MAX":
                                DgvAccountLedger.Columns[DRow["field_name"].ToString()].Summary.Add(SummaryItemType.Max, DRow["field_name"].ToString(), StrSummryFormat);
                                DgvAccountLedger.GroupSummary.Add(SummaryItemType.Max, DRow["field_name"].ToString(), DgvAccountLedger.Columns[DRow["field_name"].ToString()], StrSummryFormat);
                                break;
                            case "MIN":
                                DgvAccountLedger.Columns[DRow["field_name"].ToString()].Summary.Add(SummaryItemType.Min, DRow["field_name"].ToString(), StrSummryFormat);
                                DgvAccountLedger.GroupSummary.Add(SummaryItemType.Min, DRow["field_name"].ToString(), DgvAccountLedger.Columns[DRow["field_name"].ToString()], StrSummryFormat);
                                break;
                            case "WEI.AVG":
                                DgvAccountLedger.Columns[DRow["field_name"].ToString()].Summary.Add(SummaryItemType.Custom, DRow["field_name"].ToString(), StrSummryFormat);
                                DgvAccountLedger.GroupSummary.Add(SummaryItemType.Custom, DRow["field_name"].ToString(), DgvAccountLedger.Columns[DRow["field_name"].ToString()], StrSummryFormat);
                                break;
                            case "CUSTOME":
                                DgvAccountLedger.Columns[DRow["field_name"].ToString()].Summary.Add(SummaryItemType.Custom, DRow["field_name"].ToString(), StrSummryFormat);
                                DgvAccountLedger.GroupSummary.Add(SummaryItemType.Custom, DRow["field_name"].ToString(), DgvAccountLedger.Columns[DRow["field_name"].ToString()], StrSummryFormat);

                                break;
                            default:
                                break;
                        }
                    }
                }

                //Group By Setting
                DgvAccountLedger.ClearSorting();

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
                            DgvAccountLedger.Columns[StrGroupBy[IntI]].GroupIndex = IntI;
                            DgvAccountLedger.Columns[StrGroupBy[IntI]].Group();
                        }
                    }

                    if (Group_By_Tag == "")
                    {
                        foreach (string Str in Val.ToString(Order_By).Split(','))
                        {
                            if (Str != "")
                            {
                                DgvAccountLedger.Columns[Str].SortMode = DevExpress.XtraGrid.ColumnSortMode.Default;
                                DgvAccountLedger.Columns[Str].SortOrder = ColumnSortOrder.Ascending;
                            }
                        }
                    }
                }

                string[] StrCaption = BandConsumeCaption.Split(',');
                string[] StrCaptionValue = BandConsumeWithProcessCaption.Split(',');

                if (StrCaptionValue.Length == StrCaption.Length)
                {
                    //foreach (GridBand gridBand in DgvAccountLedger.Bands[0].Children)
                    //{
                    //    for (int IntI = 0; IntI < StrCaption.Length; IntI++)
                    //    {
                    //        if (StrCaption[IntI].ToUpper() == gridBand.Caption.ToUpper())
                    //        {
                    //            gridBand.Caption = StrCaptionValue[IntI];
                    //        }
                    //    }

                    //    if (BoolShowLabourRate == true)
                    //    {
                    //        if (gridBand.Caption.ToUpper() == "LABOUR")
                    //        {
                    //            gridBand.Visible = true;
                    //        }
                    //    }
                    //    else
                    //    {
                    //        if (gridBand.Caption.ToUpper() == "LABOUR")
                    //        {
                    //            gridBand.Visible = false;
                    //        }
                    //    }
                    //}
                }

                DgvAccountLedger.Appearance.Row.Font = new Font(ObjReportDetailProperty.Font_Name, float.Parse(Val.ToString(ObjReportDetailProperty.Font_Size)), FontStyle.Bold);
                DgvAccountLedger.AppearancePrint.Row.Font = new Font(ObjReportDetailProperty.Font_Name, float.Parse(Val.ToString(ObjReportDetailProperty.Font_Size)), FontStyle.Bold);

                //DgvAccountLedger.Appearance.BandPanel.Font = new Font(ObjReportDetailProperty.Font_Name, float.Parse(Val.ToString(ObjReportDetailProperty.Font_Size)), FontStyle.Bold);
                //DgvAccountLedger.AppearancePrint.BandPanel.Font = new Font(ObjReportDetailProperty.Font_Name, float.Parse(Val.ToString(ObjReportDetailProperty.Font_Size)), FontStyle.Bold);

                DgvAccountLedger.Appearance.HeaderPanel.Font = new Font(ObjReportDetailProperty.Font_Name, float.Parse(Val.ToString(ObjReportDetailProperty.Font_Size)), FontStyle.Bold);
                DgvAccountLedger.AppearancePrint.HeaderPanel.Font = new Font(ObjReportDetailProperty.Font_Name, float.Parse(Val.ToString(ObjReportDetailProperty.Font_Size)), FontStyle.Bold);

                DgvAccountLedger.Appearance.GroupRow.Font = new Font(ObjReportDetailProperty.Font_Name, float.Parse(Val.ToString(ObjReportDetailProperty.Font_Size)), FontStyle.Bold);
                DgvAccountLedger.AppearancePrint.GroupRow.Font = new Font(ObjReportDetailProperty.Font_Name, float.Parse(Val.ToString(ObjReportDetailProperty.Font_Size)), FontStyle.Bold);

                DgvAccountLedger.Appearance.GroupFooter.Font = new Font(ObjReportDetailProperty.Font_Name, float.Parse(Val.ToString(ObjReportDetailProperty.Font_Size - 1)), FontStyle.Bold);
                DgvAccountLedger.AppearancePrint.GroupFooter.Font = new Font(ObjReportDetailProperty.Font_Name, float.Parse(Val.ToString(ObjReportDetailProperty.Font_Size - 1)), FontStyle.Bold);

                DgvAccountLedger.Appearance.FooterPanel.Font = new Font(ObjReportDetailProperty.Font_Name, float.Parse(Val.ToString(ObjReportDetailProperty.Font_Size - 1)), FontStyle.Bold);
                DgvAccountLedger.AppearancePrint.FooterPanel.Font = new Font(ObjReportDetailProperty.Font_Name, float.Parse(Val.ToString(ObjReportDetailProperty.Font_Size - 1)), FontStyle.Bold);

                DgvAccountLedger.OptionsPrint.UsePrintStyles = true;
                DgvAccountLedger.OptionsSelection.MultiSelect = true;
                DgvAccountLedger.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CellSelect;
                cmbOrientation.SelectedItem = ObjReportDetailProperty.Page_Orientation;
                DgvAccountLedger.ExpandAllGroups();
                //GridView1.BestFitColumns();

                //if (RBtnType.Text == "PARTY WISE BALANCE SHEET DETAIL")
                //{
                //    GridView1.Columns["from_party"].Fixed = FixedStyle.Left;
                //    GridView1.ClearGrouping();
                //    GridView1.Columns["from_party"].GroupIndex = 0;
                //    GridView1.OptionsView.ShowGroupedColumns = false;
                //    GridView1.ExpandAllGroups();
                //}
            }
            catch (Exception Ex)
            {
                Global.Message("Error In Column Index : " + IntError.ToString() + "    " + Ex.Message);
            }
        }
        public void Link_CreateMarginalHeaderArea(object sender, CreateAreaEventArgs e)
        {
            // ' For Report Title
            TextBrick BrickTitle = e.Graph.DrawString(ReportHeaderName, System.Drawing.Color.Navy, new RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20), DevExpress.XtraPrinting.BorderSide.None);
            BrickTitle.Font = new Font("Tahoma", 12, FontStyle.Bold);
            BrickTitle.HorzAlignment = DevExpress.Utils.HorzAlignment.Center;
            BrickTitle.VertAlignment = DevExpress.Utils.VertAlignment.Center;

            //// ' For Group 
            //TextBrick BrickTitleseller = e.Graph.DrawString("Group :- " + lblGroupBy.Text, System.Drawing.Color.Navy, new RectangleF(0, 25, e.Graph.ClientPageSize.Width, 20), DevExpress.XtraPrinting.BorderSide.None);
            //BrickTitleseller.Font = new Font("Tahoma", 8, FontStyle.Bold);
            //BrickTitleseller.HorzAlignment = DevExpress.Utils.HorzAlignment.Near;
            //BrickTitleseller.VertAlignment = DevExpress.Utils.VertAlignment.Center;
            //BrickTitleseller.ForeColor = Color.Black;

            //// ' For Filter 
            //TextBrick BrickTitlesParam = e.Graph.DrawString("Parameters :- " + lblFilter.Text, System.Drawing.Color.Navy, new RectangleF(0, 40, e.Graph.ClientPageSize.Width, 60), DevExpress.XtraPrinting.BorderSide.None);
            //BrickTitlesParam.Font = new Font("Tahoma", 8, FontStyle.Bold);
            //BrickTitlesParam.HorzAlignment = DevExpress.Utils.HorzAlignment.Near;
            //BrickTitlesParam.VertAlignment = DevExpress.Utils.VertAlignment.Center;
            //BrickTitlesParam.ForeColor = Color.Black;

            int IntX = Convert.ToInt32(Math.Round(e.Graph.ClientPageSize.Width - 400, 0));
            TextBrick BrickTitledate = e.Graph.DrawString("Print Date :- " + System.DateTime.Now.ToString(), System.Drawing.Color.Navy, new RectangleF(IntX, 25, 400, 18), DevExpress.XtraPrinting.BorderSide.None);
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
        public int GetGroupSummryIndex(string pStrFieldName)
        {
            int IntIndex = 0;
            foreach (GridGroupSummaryItem item in DgvAccountLedger.GroupSummary)
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
            int groupRow = DgvAccountLedger.GetParentRowHandle(rowHandle);

            double part = 0;
            double total = 0;

            if (DgvAccountLedger.IsGroupRow(groupRow))
            {
                if (pStrFieldName == "RR_CARAT")
                {
                    part = Val.Val(DgvAccountLedger.GetRowCellValue(rowHandle, pStrFieldName));
                    total = Val.Val(DgvAccountLedger.GetRowCellValue(rowHandle, "CONSUME_CARAT"));
                    total += Val.Val(DgvAccountLedger.GetRowCellValue(rowHandle, pStrFieldName));
                }
                else if (pStrFieldName == "MAJOR_CARAT" || pStrFieldName == "MINOR_CARAT")
                {
                    part = Val.Val(DgvAccountLedger.GetRowCellValue(rowHandle, pStrFieldName));
                    total = Val.Val(DgvAccountLedger.GetGroupSummaryValue(groupRow, DgvAccountLedger.GroupSummary[GetGroupSummryIndex("CONSUME_CARAT")] as DevExpress.XtraGrid.GridGroupSummaryItem));
                }
                else
                {
                    total = Val.Val(DgvAccountLedger.GetGroupSummaryValue(groupRow, DgvAccountLedger.GroupSummary[IntIndex] as DevExpress.XtraGrid.GridGroupSummaryItem));
                    part = Val.Val(DgvAccountLedger.GetRowCellValue(rowHandle, pStrFieldName));
                }
            }
            else
            {
                if (pStrFieldName == "RR_CARAT")
                {
                    part = Val.Val(DgvAccountLedger.GetRowCellValue(rowHandle, pStrFieldName));
                    total = Val.Val(DgvAccountLedger.GetRowCellValue(rowHandle, "CONSUME_CARAT"));
                    total += Val.Val(DgvAccountLedger.GetRowCellValue(rowHandle, pStrFieldName));
                }
                else if (pStrFieldName == "MAJOR_CARAT" || pStrFieldName == "MINOR_CARAT")
                {
                    part = Val.Val(DgvAccountLedger.GetRowCellValue(rowHandle, pStrFieldName));
                    total = Val.Val(DgvAccountLedger.Columns["CONSUME_CARAT"].Summary[0].SummaryValue);
                }
                else
                {
                    total = Val.Val(DgvAccountLedger.Columns[pStrFieldName].Summary[0].SummaryValue);
                    part = Val.Val(DgvAccountLedger.GetRowCellValue(rowHandle, pStrFieldName));
                }
            }
            return (total == 0) ? 0 : (part / total) * 100;
        }
        public void FooterSummary()
        {
            try
            {
                DgvAccountLedger.PostEditor();
            }
            catch (Exception Ex)
            {
            }
        }

        #endregion

        #region Grid Events
        private void GridView1_CellMerge(object sender, DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs e)
        {
            if (MergeOnStr.Contains(e.Column.FieldName))
            {
                int val1 = Val.ToInt(DgvAccountLedger.GetRowCellValue(e.RowHandle1, DgvAccountLedger.Columns[MergeOn]));
                int val2 = Val.ToInt(DgvAccountLedger.GetRowCellValue(e.RowHandle2, DgvAccountLedger.Columns[MergeOn]));
                if (val1 == val2)
                    e.Merge = true;
                e.Handled = true;
            }
        }
        private void GridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            try
            {
                e.Column.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.Excel;

                //if (e.Column.Name == "colIS_Final")
                //{
                //    if (Val.ToInt(GridView1.GetRowCellValue(e.RowHandle, "IS_Final")) == 1)
                //    {
                //        //e.Appearance.BackColor = Color.LightPink;
                //        e.Appearance.Image = imageCollection1.Images[0];
                //    }
                //    else
                //    {
                //        //e.Appearance.BackColor = Color.LightPink;
                //        e.Appearance.Image = imageCollection1.Images[1];
                //    }
                //}

            }
            catch (Exception ex)
            {

            }
        }
        private void GridView1_RowStyle(object sender, RowStyleEventArgs e)
        {
            if (!Val.ToString(Remark).Trim().Equals(string.Empty))
            {
                if (Remark.ToUpper().Equals("EMP_DAILY_REPORT"))
                {
                    if (e.RowHandle >= 0)
                    {
                        for (int i = 0; i < DgvAccountLedger.Columns.Count; i++)
                        {
                            DgvAccountLedger.Columns[i].AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
                        }
                    }
                }
            }
        }
        private void GridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (Remark == null || Remark.ToString().Trim().Equals(string.Empty))
                return;
            DataRow DR = DgvAccountLedger.GetDataRow(e.RowHandle);
            if (DR == null)
                return;
        }
        private void GridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData == false)
            {
                return;
            }
        }
        private void GridView1_CustomSummaryCalculate(object sender, CustomSummaryEventArgs e)
        {
            GridView view = sender as GridView;

            #region  HR Daily Avg Report

            if (Val.ToString(ObjReportDetailProperty.Remark).ToUpper() == "DAILY_AVG_REPORT_EMPWISE")
            {
                if (e.SummaryProcess == CustomSummaryProcess.Start)
                {
                    DouTaliya = 0;
                    DouTaliyaCnt = 0;
                    DouPel = 0;
                    DouPelCnt = 0;
                    DouMathala = 0;
                    DouMathalaCnt = 0;
                    DouTable = 0;
                    DouTableCnt = 0;
                }
                else if (e.SummaryProcess == CustomSummaryProcess.Calculate)
                {
                    DouTaliya = DouTaliya + Val.ToDecimal(DgvAccountLedger.GetRowCellValue(e.RowHandle, "TALIYA"));
                    DouTaliyaCnt = DouTaliyaCnt + Val.ToDecimal(DgvAccountLedger.GetRowCellValue(e.RowHandle, "TALIYA_CNT"));
                    DouPel = DouPel + Val.ToDecimal(DgvAccountLedger.GetRowCellValue(e.RowHandle, "PEL"));
                    DouPelCnt = DouPelCnt + Val.ToDecimal(DgvAccountLedger.GetRowCellValue(e.RowHandle, "PEL_CNT"));
                    DouMathala = DouMathala + Val.ToDecimal(DgvAccountLedger.GetRowCellValue(e.RowHandle, "MATHALA"));
                    DouMathalaCnt = DouMathalaCnt + Val.ToDecimal(DgvAccountLedger.GetRowCellValue(e.RowHandle, "MATHALA_CNT"));
                    DouTable = DouTable + Val.ToDecimal(DgvAccountLedger.GetRowCellValue(e.RowHandle, "TABLE"));
                    DouTableCnt = DouTableCnt + Val.ToDecimal(DgvAccountLedger.GetRowCellValue(e.RowHandle, "TABLE_CNT"));
                }
                else if (e.SummaryProcess == CustomSummaryProcess.Finalize)
                {
                    if (((GridSummaryItem)e.Item).FieldName.CompareTo("TALIYA_AVG") == 0)
                    {
                        if (DouTaliyaCnt > 0)
                        {
                            e.TotalValue = Math.Round((DouTaliya / DouTaliyaCnt), 2);
                        }
                        else
                        {
                            e.TotalValue = 0;
                        }
                    }
                    if (((GridSummaryItem)e.Item).FieldName.CompareTo("PEL_AVG") == 0)
                    {
                        if (DouPelCnt > 0)
                        {
                            e.TotalValue = Math.Round((DouPel / DouPelCnt), 2);
                        }
                        else
                        {
                            e.TotalValue = 0;
                        }
                    }
                    if (((GridSummaryItem)e.Item).FieldName.CompareTo("MATHALA_AVG") == 0)
                    {
                        if (DouMathalaCnt > 0)
                        {
                            e.TotalValue = Math.Round((DouMathala / DouMathalaCnt), 2);
                        }
                        else
                        {
                            e.TotalValue = 0;
                        }
                    }
                    if (((GridSummaryItem)e.Item).FieldName.CompareTo("TABLE_AVG") == 0)
                    {
                        if (DouTableCnt > 0)
                        {
                            e.TotalValue = Math.Round((DouTable / DouTableCnt), 2);
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

        #endregion

        #region Events
        private void MNGroupEnableDisable_Click(object sender, EventArgs e)
        {
            if (MNRemoveGroup.Text == "Disable Groups")
            {
                while (DgvAccountLedger.GroupedColumns.Count != 0)
                {
                    DgvAccountLedger.GroupedColumns[DgvAccountLedger.GroupedColumns.Count - 1].UnGroup();
                }
                MNRemoveGroup.Text = "Enable Groups";
            }
            else
            {
                foreach (string Str in Val.ToString(Group_By_Tag).Split(','))
                {
                    if (Str != "")
                    {
                        DgvAccountLedger.Columns[Str].Group();
                    }
                }
                MNRemoveGroup.Text = "Disable Groups";
            }
            ExpandTool_Click(null, null);
        }
        private void MNFilter_Click(object sender, EventArgs e)
        {
            DgvAccountLedger.BeginUpdate();
            if (ISFilter == true)
            {
                ISFilter = false;
                MNFilter.Text = "Add Filter";
                DgvAccountLedger.OptionsView.ShowAutoFilterRow = false;
            }
            else
            {
                ISFilter = true;
                MNFilter.Text = "Remove Filter";
                DgvAccountLedger.OptionsView.ShowAutoFilterRow = true;
            }
            DgvAccountLedger.EndUpdate();
        }
        private void EmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ObjPer.AllowEMail == false)
            {
                Global.Message(BLL.GlobalDec.gStrPermissionEMailMsg);
                return;
            }

            string StrFile = Global.DataGridExportToExcel(DgvAccountLedger, "Report");

            Utility.FrmEmailSend FrmEmailSend = new Utility.FrmEmailSend();
            FrmEmailSend.mStrSubject = ReportHeaderName;
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
        private void BtnReset_Click(object sender, EventArgs e)
        {
            GrdAccountLedger.DataSource = null;
            lueLedger.EditValue = DBNull.Value;
            //DgvAccountLedger.Columns.Clear();

            dtpFromDate.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
            dtpFromDate.Properties.Mask.EditMask = "dd-MM-yyyy";
            dtpFromDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            dtpFromDate.Properties.CharacterCasing = CharacterCasing.Upper;
            dtpFromDate.EditValue = DateTime.Now;
            DateTime now = DateTime.Now;
            dtpFromDate.EditValue = new DateTime(now.Year, now.Month, 1);

            dtpToDate.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
            dtpToDate.Properties.Mask.EditMask = "dd-MM-yyyy";
            dtpToDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            dtpToDate.Properties.CharacterCasing = CharacterCasing.Upper;
            dtpToDate.EditValue = DateTime.Now;
        }
        private void BtnExport_Click(object sender, EventArgs e)
        {
            Export("xlsx", DgvAccountLedger);
        }
        private void BtnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                DevExpress.XtraPrinting.PrintingSystem PrintSystem = new DevExpress.XtraPrinting.PrintingSystem();

                PrinterSettingsUsing pst = new PrinterSettingsUsing();

                PrintSystem.PageSettings.AssignDefaultPrinterSettings(pst);

                PrintableComponentLink link = new PrintableComponentLink(PrintSystem);

                link.Component = GrdAccountLedger;

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
                    DgvAccountLedger.OptionsPrint.ExpandAllGroups = true;
                }
                else
                {
                    DgvAccountLedger.OptionsPrint.ExpandAllGroups = false;
                }

                DgvAccountLedger.OptionsPrint.AutoWidth = true;

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

        private static void SetLvlBackColor(DevExpress.XtraGrid.Views.Grid.GroupLevelStyleEventArgs e, Color lvlBackColor)
        {
            e.LevelAppearance.BackColor = lvlBackColor;
            e.LevelAppearance.ForeColor = Color.Black;
        }
        private void backgroundWorker_HRReport_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            DTab = ObjReportParams.GetAccountLedgerReport(ReportParams_Property, "RPT_PartyLedger");
        }
        private void backgroundWorker_HRReport_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            FrmAccountLedger FrmGReportViewer = new Report.FrmAccountLedger();

            FrmGReportViewer.ObjReportDetailProperty = ObjReportDetailProperty;
            FrmGReportViewer.mDTDetail = mDTDetail;
            FrmGReportViewer.Report_Code = ObjReportDetailProperty.Report_code;

            FrmGReportViewer.Remark = ObjReportDetailProperty.Remark;
            FrmGReportViewer.ReportParams_Property = ReportParams_Property;
            FrmGReportViewer.Procedure_Name = ObjReportDetailProperty.Procedure_Name;
            FrmGReportViewer.FilterByFormName = this.Name;

            FrmGReportViewer.Remark = "";

            ReportHeaderName = FrmGReportViewer.ReportHeaderName;
            FrmGReportViewer.DTab = DTab;
            if (FrmGReportViewer.DTab == null || FrmGReportViewer.DTab.Rows.Count == 0)
            {
                this.Cursor = Cursors.Default;
                FrmGReportViewer.Dispose();
                FrmGReportViewer = null;
                Global.Message("Data Not Found");
                GrdAccountLedger.DataSource = null;
                return;
            }
            this.Cursor = Cursors.Default;
            //ObjPer.Report_Code = Report_Code;
            decimal numBalance = 0;
            DTab.Columns.Add("balance_", typeof(string));
            foreach (DataRow Drw in DTab.Rows)
            {
                numBalance = numBalance + Val.ToDecimal(Drw["debit_amount"]) - Val.ToDecimal(Drw["credit_amount"]);

                Drw["balance_amount"] = numBalance;
                if (Val.ToDecimal(Drw["balance_amount"]) > 0)
                {
                    Drw["balance_"] = Val.ToString(Drw["balance_amount"]).Replace("-", "") + " Dr";
                }
                else
                {
                    Drw["balance_"] = Val.ToString(Drw["balance_amount"]).Replace("-", "") + " Cr";
                }
            }
            GrdAccountLedger.DataSource = DTab;

            //int IntIndex = 0;
            //int IntSelectedIndex = 0;
            //CmbPageKind.Items.Clear();
            //foreach (System.Drawing.Printing.PaperKind foo in Enum.GetValues(typeof(System.Drawing.Printing.PaperKind)))
            //{
            //    CmbPageKind.Items.Add(foo.ToString());

            //    IntIndex++;
            //}
            //CmbPageKind.SelectedIndex = IntSelectedIndex;

            //FillGrid();
            FooterSummary();
        }
        private bool ValidateDetails()
        {
            bool blnFocus = false;
            List<ListError> lstError = new List<ListError>();

            try
            {
                if (lueLedger.Text == "")
                {
                    lstError.Add(new ListError(13, "Ledger"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                        lueLedger.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                lstError.Add(new ListError(ex));
            }
            return (!(BLL.General.ShowErrors(lstError)));
        }
        private void BtnGenerateReport_Click(object sender, EventArgs e)
        {
            if (!ValidateDetails())
            {
                return;
            }
            ReportParams_Property.From_Date = Val.DBDate(dtpFromDate.Text);
            ReportParams_Property.To_Date = Val.DBDate(dtpToDate.Text);
            ReportParams_Property.ledger_id = Val.ToInt64(lueLedger.EditValue);

            if (this.backgroundWorker_HRReport.IsBusy)
            {
            }
            else
            {
                backgroundWorker_HRReport.RunWorkerAsync();
            }
        }
        private void DgvAccountLedger_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                Int64 Union_ID = Val.ToInt64(DgvAccountLedger.GetRowCellValue(DgvAccountLedger.FocusedRowHandle, "union_id"));
                string Type = Val.ToString(DgvAccountLedger.GetRowCellValue(DgvAccountLedger.FocusedRowHandle, "type"));
                Int64 Invoice_ID = Val.ToInt64(DgvAccountLedger.GetRowCellValue(DgvAccountLedger.FocusedRowHandle, "invoice_id"));
                Int64 Purchase_ID = Val.ToInt64(DgvAccountLedger.GetRowCellValue(DgvAccountLedger.FocusedRowHandle, "purchase_id"));

                if (Type == "Rcpt")
                {
                    FrmPaymentReceipt objPaymentReceipt = new FrmPaymentReceipt();
                    Assembly frmAssembly = Assembly.LoadFile(Application.ExecutablePath);

                    foreach (Type type in frmAssembly.GetTypes())
                    {
                        string type1 = type.Name.ToString().ToUpper();
                        if (type.BaseType == typeof(DevExpress.XtraEditors.XtraForm))
                        {
                            if (type.Name.ToString().ToUpper() == "FRMPAYMENTRECEIPT")
                            {
                                XtraForm frmShow = (XtraForm)frmAssembly.CreateInstance(type.ToString());
                                frmShow.MdiParent = Global.gMainFormRef;

                                frmShow.GetType().GetMethod("ShowForm_New").Invoke(frmShow, new object[] { Union_ID });
                                break;
                            }
                        }
                    }
                }
                else if (Type == "Sale")
                {
                    FrmSaleInvoice objSaleInvoice = new FrmSaleInvoice();
                    Assembly frmAssembly = Assembly.LoadFile(Application.ExecutablePath);

                    foreach (Type type in frmAssembly.GetTypes())
                    {
                        string type1 = type.Name.ToString().ToUpper();
                        if (type.BaseType == typeof(DevExpress.XtraEditors.XtraForm))
                        {
                            if (type.Name.ToString().ToUpper() == "FRMSALEINVOICE")
                            {
                                XtraForm frmShow = (XtraForm)frmAssembly.CreateInstance(type.ToString());
                                frmShow.MdiParent = Global.gMainFormRef;

                                frmShow.GetType().GetMethod("ShowForm_New").Invoke(frmShow, new object[] { Invoice_ID });
                                break;
                            }
                        }
                    }
                }
                else if (Type == "Purc")
                {
                    FrmPurchase objPurchase = new FrmPurchase();
                    Assembly frmAssembly = Assembly.LoadFile(Application.ExecutablePath);

                    foreach (Type type in frmAssembly.GetTypes())
                    {
                        string type1 = type.Name.ToString().ToUpper();
                        if (type.BaseType == typeof(DevExpress.XtraEditors.XtraForm))
                        {
                            if (type.Name.ToString().ToUpper() == "FRMPURCHASE")
                            {
                                XtraForm frmShow = (XtraForm)frmAssembly.CreateInstance(type.ToString());
                                frmShow.MdiParent = Global.gMainFormRef;

                                frmShow.GetType().GetMethod("ShowForm_New").Invoke(frmShow, new object[] { Purchase_ID });
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}
