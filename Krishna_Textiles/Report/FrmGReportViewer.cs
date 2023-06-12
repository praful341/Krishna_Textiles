using DevExpress.Data;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Global = Krishna_Textiles.Class.Global;

namespace Krishna_Textiles.Report
{
    public partial class FrmGReportViewer : DevExpress.XtraEditors.XtraForm
    {
        #region "Data Member"
        BLL.FormEvents objBOFormEvents = new BLL.FormEvents();
        BLL.Validation Val = new BLL.Validation();
        BLL.FormPer ObjPer = new BLL.FormPer();

        Excel.Application myExcelApplication;
        Excel.Workbook myExcelWorkbook;
        Excel.Worksheet myExcelWorkSheet;

        string MergeOnStr = string.Empty;
        string MergeOn = string.Empty;
        Boolean ISFilter = false;

        Double DouIssueExpCarat = 0;
        Double DouReadyExpCarat = 0;
        Double DouConsumeCarat = 0;
        Double DouPerConsumeCarat = 0;
        Double DouReadyCarat = 0;
        Double DouIssueCarat = 0;
        Double DouConsumeExpCarat = 0;
        Double DouOSCarat = 0;
        Double DouOSExpCarat = 0;
        #endregion

        #region "Property Settings"

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

        private string _Remark;

        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }
        //--------------------
        #endregion

        #region "Constructor"

        public FrmGReportViewer()
        {
            InitializeComponent();
        }

        public FrmGReportViewer(DataTable pDTab, string pStrOrderBy, string pStrGroupBy, string pStrReportName, int pIntReportCode)
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

            AttachFormEvents();
            lblReportHeader.Text = ReportHeaderName;
            if (Group_By_Text == null || Group_By_Text == "")
            {
                lblGroupBy.Visible = false;
                labelControl1.Visible = false;
            }
            else
            {
                lblGroupBy.Visible = true;
                labelControl1.Visible = true;
                lblGroupBy.Text = Group_By_Text;
                lblGroupBy.Tag = Group_By_Tag;
            }
            lblFilter.Text = FilterBy;
            this.Text = lblReportHeader.Text;
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

        #region "Events"
        private void FrmGReportViewer_Load(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString("dd/MMM/yyyy hh:mm:ss tt");
            FillGrid();

        }
        public void Link_CreateMarginalHeaderArea(object sender, CreateAreaEventArgs e)
        {
            // ' For Report Title
            TextBrick BrickTitle = e.Graph.DrawString(lblReportHeader.Text, Color.Black, new RectangleF(0, 0, 500, 20), BorderSide.None);
            BrickTitle.Font = new Font("Tahoma", 15);
            BrickTitle.HorzAlignment = DevExpress.Utils.HorzAlignment.Near;
            BrickTitle.VertAlignment = DevExpress.Utils.VertAlignment.Center;
            // ' For Filter 
            TextBrick BrickFilter = e.Graph.DrawString("Filter : " + lblFilter.Text, Color.Black, new RectangleF(2, 22, 1000, 15), BorderSide.None);
            BrickFilter.Font = new Font("Tahoma", 8);
            BrickFilter.HorzAlignment = DevExpress.Utils.HorzAlignment.Near;
            BrickFilter.VertAlignment = DevExpress.Utils.VertAlignment.Center;

            // ' For Filter 
            TextBrick BrickGroup = e.Graph.DrawString("Group : " + lblGroupBy.Text, Color.Black, new RectangleF(2, 40, 1000, 15), BorderSide.None);
            BrickGroup.Font = new Font("Tahoma", 8);
            BrickGroup.HorzAlignment = DevExpress.Utils.HorzAlignment.Near;
            BrickGroup.VertAlignment = DevExpress.Utils.VertAlignment.Center;
        }
        public void Link_CreateMarginalFooterArea(object sender, CreateAreaEventArgs e)
        {
            // ' for Page No
            PageInfoBrick BrickPageNo = e.Graph.DrawPageInfo(PageInfo.NumberOfTotal, "", Color.Black, new RectangleF(0, 0, 100, 15), BorderSide.None);
            BrickPageNo.LineAlignment = BrickAlignment.Center;
            BrickPageNo.Alignment = BrickAlignment.Near;
            BrickPageNo.AutoWidth = true;
            BrickPageNo.Font = new Font("Tahoma", 8);
            // ' For date 
            PageInfoBrick BrickDate = e.Graph.DrawPageInfo(PageInfo.DateTime, "", Color.Black, new RectangleF(0, 0, 100, 20), BorderSide.None);
            BrickDate.LineAlignment = BrickAlignment.Center;
            BrickDate.Alignment = BrickAlignment.Far;
            BrickDate.AutoWidth = true;
            BrickDate.Font = new Font("Tahoma", 8);
        }
        private void PrintToolStripMenuItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DevExpress.XtraPrinting.PrintingSystem PrintSystem = new DevExpress.XtraPrinting.PrintingSystem();

            PrintableComponentLink link = new PrintableComponentLink(PrintSystem);

            link.Component = GridControl1;

            link.Margins.Left = 20;
            link.Margins.Right = 20;
            link.Margins.Bottom = 40;
            link.Margins.Top = 80;
            link.CreateMarginalHeaderArea += new CreateAreaEventHandler(Link_CreateMarginalHeaderArea);
            link.CreateMarginalFooterArea += new CreateAreaEventHandler(Link_CreateMarginalFooterArea);
            link.CreateDocument();
            link.ShowPreview();
            link.PrintDlg();
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

                if (Global.Confirm("Export Done\n\nYou Want To Open Excel File ?", "Krishna_Textiles", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(Filepath);
                }
            }
            catch (Exception ex)
            {
                Global.Message(ex.Message.ToString());
            }
        }

        private void ToExcel_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Export("xls", "Export to Excel", "Excel files (*.xls)|*.xls|All files (*.*)|*.*");
            Export("xlsx", GridView1);
        }

        private void ToText_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Export("txt", "Export to Text", "Text files (*.txt)|*.txt|All files (*.*)|*.*");
        }

        private void ToHTML_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Export("html", "Export to HTML", "Html files (*.html)|*.html|Htm files (*.htm)|*.htm");
        }

        private void ToRTF_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Export("rtf", "Export to RTF", "Word (*.doc) |*.doc;*.rtf|(*.txt) |*.txt|(*.*) |*.*");
        }

        private void ToPDF_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Export("pdf", "Export Report to PDF", "PDF (*.PDF)|*.PDF");
        }

        private void MNUExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void Collapse_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GridView1.CollapseAllGroups();
        }

        private void AToolStripMenuItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GridView1.BestFitColumns();
        }

        private void ExpandTool_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GridView1.ExpandAllGroups();
        }

        private void MNGroupEnableDisable_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MNRemoveGroup.Caption == "Disable Groups")
            {
                while (GridView1.GroupedColumns.Count != 0)
                {
                    GridView1.GroupedColumns[GridView1.GroupedColumns.Count - 1].UnGroup();
                }
                MNRemoveGroup.Caption = "Enable Groups";
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
                MNRemoveGroup.Caption = "Disable Groups";
            }
            ExpandTool_ItemClick(null, null);
        }

        private void MNFilter_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GridView1.BeginUpdate();
            if (ISFilter == true)
            {
                ISFilter = false;
                MNFilter.Caption = "Add Filter";
                GridView1.OptionsView.ShowAutoFilterRow = false;
            }
            else
            {
                ISFilter = true;
                MNFilter.Caption = "Remove Filter";
                GridView1.OptionsView.ShowAutoFilterRow = true;
            }
            GridView1.EndUpdate();
        }

        #region "Grid Events"
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
                if (e.DisplayText == "0.00" || e.DisplayText == "0" || e.DisplayText == "0.000")
                {
                    e.DisplayText = String.Empty;
                }
                e.Column.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void GridView1_StartGrouping(object sender, EventArgs e)
        {
            GridView1.BestFitColumns();
        }
        #endregion

        #endregion

        #region "Data Member"
        public void FillGrid()
        {
            int IntError = 0;
            try
            {
                GridControl1.DataSource = mDTDetail;
                GridView1.OptionsView.AllowCellMerge = false;

                if (ReportHeaderName.ToString() == "Item Purchase" || ReportHeaderName.ToString() == "Item Purchase Return" || ReportHeaderName.ToString() == "Item Sale" || ReportHeaderName.ToString() == "Item Sale Return")
                {
                    GridView1.Columns["SGST_Amt"].Summary.Add(SummaryItemType.Sum, "SGST_Amt");
                    GridView1.GroupSummary.Add(SummaryItemType.Sum, "SGST_Amt", GridView1.Columns["SGST_Amt"]);
                    GridView1.Columns["CGST_Amt"].Summary.Add(SummaryItemType.Sum, "CGST_Amt");
                    GridView1.GroupSummary.Add(SummaryItemType.Sum, "CGST_Amt", GridView1.Columns["CGST_Amt"]);
                    GridView1.Columns["IGST_Amt"].Summary.Add(SummaryItemType.Sum, "IGST_Amt");
                    GridView1.GroupSummary.Add(SummaryItemType.Sum, "IGST_Amt", GridView1.Columns["IGST_Amt"]);
                    GridView1.Columns["NetAmount"].Summary.Add(SummaryItemType.Sum, "NetAmount");
                    GridView1.GroupSummary.Add(SummaryItemType.Sum, "NetAmount", GridView1.Columns["NetAmount"]);
                    GridView1.Columns["Gross_Amt"].Summary.Add(SummaryItemType.Sum, "Gross_Amt");
                    GridView1.GroupSummary.Add(SummaryItemType.Sum, "Gross_Amt", GridView1.Columns["Gross_Amt"]);
                }
                GridView1.ExpandAllGroups();
                GridView1.BestFitColumns();
            }
            catch (Exception Ex)
            {
                Global.Confirm("Error In Column Index : " + IntError.ToString() + "    " + Ex.Message);
            }
        }
        private void Export(string format, string dlgHeader, string dlgFilter)
        {
            GridView1.OptionsPrint.ExpandAllDetails = true;

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
                            //GridView1.OptionsPrint.PageSettings.Landscape = true;
                            //GridView1.OptionsPrint.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A3;
                            GridView1.ExportToPdf(Filepath);
                            break;
                        case "xls":
                            GridView1.ExportToXls(Filepath);
                            break;
                        case "xlsx":
                            GridView1.ExportToXlsx(Filepath);
                            break;
                        case "rtf":
                            GridView1.ExportToRtf(Filepath);
                            break;
                        case "txt":
                            GridView1.ExportToText(Filepath);
                            break;
                        case "html":
                            GridView1.ExportToHtml(Filepath);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Global.Confirm(ex.Message.ToString(), "Error in Export");
            }
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
        private void GridView1_CustomSummaryCalculate(object sender, CustomSummaryEventArgs e)
        {
            GridView view = sender as GridView;

            #region OUTSIDE_RECEIPT_TOTAL_ROUGH_TRANSFER

            if (ReportHeaderName == "Party OutStanding" || ReportHeaderName == "Rough Transfer")
            {

                if (e.SummaryProcess == CustomSummaryProcess.Start)
                {
                    DouPerConsumeCarat = 0;
                    DouConsumeCarat = 0;
                    DouIssueCarat = 0;
                    DouConsumeExpCarat = 0;
                    DouIssueExpCarat = 0;
                    DouReadyCarat = 0;
                    DouReadyExpCarat = 0;
                    DouOSCarat = 0;
                    DouOSExpCarat = 0;
                }
                else if (e.SummaryProcess == CustomSummaryProcess.Calculate)
                {

                    DouIssueCarat = DouIssueCarat + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "ISSUE_CARAT"));
                    DouConsumeCarat = DouConsumeCarat + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "CONSUME_CARAT"));
                    DouPerConsumeCarat = DouPerConsumeCarat + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "PER_CONSUME_CARAT"));
                    DouReadyCarat = DouReadyCarat + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "READY_CARAT"));
                    DouOSCarat = DouOSCarat + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "OUTSTAND_CARAT"));
                    DouOSExpCarat = DouOSExpCarat + (Val.Val(GridView1.GetRowCellValue(e.RowHandle, "OUTSTAND_CARAT")) * Val.Val(GridView1.GetRowCellValue(e.RowHandle, "OUTSTAND_EXP_PER")) / 100);
                    DouIssueExpCarat = DouIssueExpCarat + (Val.Val(GridView1.GetRowCellValue(e.RowHandle, "ISSUE_CARAT")) * Val.Val(GridView1.GetRowCellValue(e.RowHandle, "EXP_ISS_PER")) / 100);
                    DouConsumeExpCarat = DouConsumeExpCarat + (Val.Val(GridView1.GetRowCellValue(e.RowHandle, "CONSUME_CARAT")) * Val.Val(GridView1.GetRowCellValue(e.RowHandle, "EXP_CONS_PER")) / 100);
                    DouReadyExpCarat = DouReadyExpCarat + (Val.Val(GridView1.GetRowCellValue(e.RowHandle, "READY_CARAT")) * Val.Val(GridView1.GetRowCellValue(e.RowHandle, "EXP_REC_PER")) / 100);
                }

                else if (e.SummaryProcess == CustomSummaryProcess.Finalize)
                {
                    if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("EXP_ISS_PER") == 0)
                    {
                        if (DouIssueCarat != 0)
                        {
                            e.TotalValue = Math.Round((DouIssueExpCarat / DouIssueCarat) * 100, 3);
                        }
                    }
                    if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("OUTSTAND_EXP_PER") == 0)
                    {
                        if (DouOSCarat != 0)
                        {
                            e.TotalValue = Math.Round((DouOSExpCarat / DouOSCarat) * 100, 3);
                        }
                    }
                    else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("EXP_CONS_PER") == 0)
                    {
                        if (DouConsumeCarat != 0)
                        {
                            e.TotalValue = Math.Round((DouConsumeExpCarat / DouConsumeCarat) * 100, 3);
                        }
                    }

                    else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("EXP_REC_PER") == 0)
                    {
                        if (DouPerConsumeCarat != 0)
                        {
                            e.TotalValue = Math.Round((DouReadyCarat / DouPerConsumeCarat) * 100, 3);
                        }
                    }
                    else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("ISSUE_EXP_DIFF") == 0)
                    {
                        if (e.GroupLevel < 0)
                        {
                            double ExpConsPer = Val.Val(view.Columns["EXP_CONS_PER"].SummaryText);
                            double ExpRecPer = Val.Val(view.Columns["EXP_REC_PER"].SummaryText);
                            e.TotalValue = ExpConsPer - ExpRecPer;
                        }
                        else
                        {
                            double ExpConsPer = Val.Val(view.GetGroupSummaryValue(e.GroupRowHandle, (GridGroupSummaryItem)view.GroupSummary[GetGroupSummryIndex("EXP_CONS_PER")]));
                            double ExpRecPer = Val.Val(view.GetGroupSummaryValue(e.GroupRowHandle, (GridGroupSummaryItem)view.GroupSummary[GetGroupSummryIndex("EXP_REC_PER")]));
                            e.TotalValue = ExpConsPer - ExpRecPer;
                        }
                    }
                }
            }

            #endregion

            #region LABOUR_PERFORMANCE_INSPECTION 

            else if (ReportHeaderName == "Party Transfer")
            {
                if (e.SummaryProcess == CustomSummaryProcess.Start)
                {
                    DouPerConsumeCarat = 0;
                    DouConsumeCarat = 0;
                    DouIssueExpCarat = 0;
                    DouReadyCarat = 0;
                    DouReadyExpCarat = 0;
                }
                else if (e.SummaryProcess == CustomSummaryProcess.Calculate)
                {
                    DouPerConsumeCarat = DouPerConsumeCarat + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "PER_CONSUME_CARAT"));
                    DouConsumeCarat = DouConsumeCarat + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "CONSUME_CARAT"));
                    DouReadyCarat = DouReadyCarat + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "READY_CARAT"));
                    DouIssueExpCarat = DouIssueExpCarat + (Val.Val(GridView1.GetRowCellValue(e.RowHandle, "CONSUME_CARAT")) * Val.Val(GridView1.GetRowCellValue(e.RowHandle, "EXP_ISS_PER")) / 100);
                    DouReadyExpCarat = DouReadyExpCarat + (Val.Val(GridView1.GetRowCellValue(e.RowHandle, "READY_CARAT")) * Val.Val(GridView1.GetRowCellValue(e.RowHandle, "EXP_REC_PER")) / 100);
                }

                else if (e.SummaryProcess == CustomSummaryProcess.Finalize)
                {
                    if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("EXP_ISS_PER") == 0)
                    {
                        if (DouConsumeCarat != 0)
                        {
                            double DouExpIssPer = Math.Round((DouIssueExpCarat / DouConsumeCarat) * 100, 3);
                            e.TotalValue = DouExpIssPer;
                        }
                    }
                    else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("EXP_REC_PER") == 0)
                    {
                        if (DouPerConsumeCarat != 0)
                        {
                            double DouExpRecPer = Math.Round((DouReadyCarat / DouPerConsumeCarat) * 100, 3);
                            e.TotalValue = DouExpRecPer;
                        }
                    }

                    else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("REC_DIFF") == 0)
                    {
                        if (e.GroupLevel < 0)
                        {
                            double DMPer = Val.Val(view.Columns["EXP_ISS_PER"].SummaryText);
                            double ExpRecPer = Val.Val(view.Columns["EXP_REC_PER"].SummaryText);
                            e.TotalValue = Math.Round(ExpRecPer - DMPer, 3);
                        }
                        else
                        {
                            double DMPer = Val.Val(view.GetGroupSummaryValue(e.GroupRowHandle, (GridGroupSummaryItem)view.GroupSummary[GetGroupSummryIndex("EXP_ISS_PER")]));
                            double ExpRecPer = Val.Val(view.GetGroupSummaryValue(e.GroupRowHandle, (GridGroupSummaryItem)view.GroupSummary[GetGroupSummryIndex("EXP_REC_PER")]));
                            e.TotalValue = Math.Round(ExpRecPer - DMPer, 3);
                        }
                    }
                }
            }
            #endregion
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
        private void GridView1_RowStyle(object sender, RowStyleEventArgs e)
        {
            if (Remark != null)
            {
                if (Remark.ToUpper().Equals("ACTIVITY_SIZE"))
                {
                    DataRow DRow = GridView1.GetDataRow(e.RowHandle);
                    if ((DRow["HOUR"].Equals(string.Empty) && !DRow["SIZE"].Equals(string.Empty)) || DRow["SIZE"].ToString().Contains("----"))
                    {
                        e.Appearance.Font = new Font(GridView1.Appearance.Row.Font, FontStyle.Bold);
                    }
                }
            }
        }
        #endregion

        private void barStaticItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}
