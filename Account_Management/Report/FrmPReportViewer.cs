using BLL.FunctionClasses.Report;
using BLL.PropertyClasses.Report;
using DevExpress.LookAndFeel;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrintingLinks;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Global = Account_Management.Class.Global;

namespace Account_Management.Report
{
    public partial class FrmPReportViewer : DevExpress.XtraEditors.XtraForm
    {
        Excel.Application myExcelApplication;
        Excel.Workbook myExcelWorkbook;
        Excel.Worksheet myExcelWorkSheet;


        BLL.FormEvents objBOFormEvents = new BLL.FormEvents();
        BLL.Validation Val = new BLL.Validation();
        public New_Report_DetailProperty ObjReportDetailProperty = new New_Report_DetailProperty();
        New_Report_SettingsProperty ObjNeweportSettings = new New_Report_SettingsProperty();
        NewReportMaster ObjNewReport = new NewReportMaster();
        BLL.FormPer ObjPer = new BLL.FormPer();


        string MergeOnStr = string.Empty;
        string MergeOn = string.Empty;

        #region Propert Settings

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

        private string _Report_Type;

        public string Report_Type
        {
            get { return _Report_Type; }
            set { _Report_Type = value; }
        }

        private int _Report_Code;

        public int Report_Code
        {
            get { return _Report_Code; }
            set { _Report_Code = value; }
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

        public bool IS_Local { get; set; }
        public bool IS_Purchase { get; set; }
        public bool IS_Dollar { get; set; }

        #endregion

        #region Constructor

        public FrmPReportViewer()
        {
            InitializeComponent();
        }

        public void ShowForm()
        {
            ObjPer.Report_Code = Report_Code;

            AttachFormEvents();
            lblReportHeader.Text = ReportHeaderName;
            lblFilter.Text = FilterBy;
            lblGroupBy.Text = Group_By_Text;
            lblGroupBy.Tag = Group_By_Tag;
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
        public void Export(string format, DevExpress.XtraPivotGrid.PivotGridControl gvExportGrid)
        {
            try
            {
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
                            gvExportGrid.ExportToPdf(Filepath);
                            break;
                        case "xls":
                            gvExportGrid.ExportToXls(Filepath);
                            break;
                        case "xlsx":
                            DevExpress.XtraPrinting.XlsxExportOptionsEx opx = new DevExpress.XtraPrinting.XlsxExportOptionsEx();
                            opx.ExportType = DevExpress.Export.ExportType.WYSIWYG;
                            gvExportGrid.ExportToXlsx(Filepath, opx);
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
                    }
                    myExcelApplication = null;

                    myExcelApplication = new Excel.Application(); // create Excell App
                    myExcelApplication.DisplayAlerts = false; // turn off alerts


                    myExcelWorkbook = (Excel.Workbook)(myExcelApplication.Workbooks._Open(Filepath, System.Reflection.Missing.Value,
                       System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value,
                       System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value,
                       System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value,
                       System.Reflection.Missing.Value, System.Reflection.Missing.Value)); // open the existing excel file

                    int numberOfWorkbooks = myExcelApplication.Workbooks.Count; // get number of workbooks (optional)
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
                                                       System.Reflection.Missing.Value, System.Reflection.Missing.Value); // Save data in excel


                        myExcelWorkbook.Close(true, Filepath, System.Reflection.Missing.Value); // close the worksheet


                    }
                    finally
                    {
                        if (myExcelApplication != null)
                        {
                            myExcelApplication.Quit(); // close the excel application
                        }
                    }

                    if (Global.Confirm("Export Done\n\nYou Want To Open Excel File ?", "Account_Management", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(Filepath);
                    }
                }
            }
            catch (Exception ex)
            {
                Global.Message(ex.Message.ToString());
            }
        }
        private void ToExcel_Click(object sender, EventArgs e)
        {
            Export("xlsx", DgvPivot);
        }

        private void ToText_Click(object sender, EventArgs e)
        {
            Global.Export("txt", DgvPivot);
        }

        private void ToHTML_Click(object sender, EventArgs e)
        {
            Global.Export("html", DgvPivot);
        }

        private void ToRTF_Click(object sender, EventArgs e)
        {
            Global.Export("rtf", DgvPivot);
        }

        private void ToPDF_Click(object sender, EventArgs e)
        {
            //Global.Export("pdf", DgvPivot);
            Export("pdf", "Export Report to PDF", "PDF (*.PDF)|*.PDF");
        }

        private void AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DgvPivot.BestFit();
        }

        private void ExpandTool_Click(object sender, EventArgs e)
        {
            DgvPivot.ExpandAll();
        }

        private void Collapse_Click(object sender, EventArgs e)
        {
            DgvPivot.CollapseAll();
        }

        private void PrintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintableComponentLink link = new PrintableComponentLink(new PrintingSystem());
            link.Component = DgvPivot;

            if (Val.ToString(cmbOrientation.SelectedItem) == "Landscape")
            {
                link.Landscape = true;
            }

            link.Margins.Left = 20;
            link.Margins.Right = 20;
            link.Margins.Bottom = 40;
            link.Margins.Top = 80;
            link.CreateMarginalHeaderArea += new CreateAreaEventHandler(Link_CreateMarginalHeaderArea);
            link.CreateMarginalFooterArea += new CreateAreaEventHandler(Link_CreateMarginalFooterArea);
            link.CreateDocument();
            link.ShowPreview();
        }
        private void MNRemoveGroup_Click(object sender, EventArgs e)
        {
            if (MNRemoveGroup.Text == "Disable Groups")
            {
                while (DgvPivot.Groups.Count != 0)
                {
                    // DgvPivot.Groups[DgvPivot.Groups.Count - 1].Remove();
                }
                MNRemoveGroup.Text = "Enable Groups";

            }
            else
            {
                foreach (string Str in Val.ToString(Group_By_Tag).Split(','))
                {
                    if (Str != "")
                    {
                        //DgvPivot.[Str].Group();
                    }
                }
                MNRemoveGroup.Text = "Disable Groups";
            }
            ExpandTool_Click(null, null);
        }

        #endregion

        #region Events
        private void FrmPReportViewer_Load(object sender, EventArgs e)
        {
            PictureActivator.Visible = true;
            PictureActivator.BringToFront();
            lblDateTime.Text = DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss tt");
            FillGrid();
            PictureActivator.Visible = false;
        }

        #endregion

        #region Operation

        void PreviewPrintableComponent(IPrintable component, UserLookAndFeel lookAndFeel, string Filepath)
        {

            PrintableComponentLinkBase link = new PrintableComponentLinkBase()
            {
                PrintingSystemBase = new PrintingSystemBase(),
                Component = component,
                Landscape = true

            };
            // Show the report.

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
            DgvPivot.OptionsPrint.PageSettings.Landscape = true;
            DgvPivot.OptionsPrint.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A3;
            link.ExportToPdf(Filepath);
        }

        private void Export(string format, string dlgHeader, string dlgFilter)
        {

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
                            PreviewPrintableComponent_PDF(DgvPivot, DgvPivot.LookAndFeel, Filepath);
                            //DgvPivot.ExportToPdf(Filepath);
                            break;
                        case "xls":
                            PreviewPrintableComponent(DgvPivot, DgvPivot.LookAndFeel, Filepath);
                            break;
                        case "rtf":
                            DgvPivot.ExportToRtf(Filepath);
                            break;
                        case "txt":
                            DgvPivot.ExportToText(Filepath);
                            break;
                        case "html":
                            DgvPivot.ExportToHtml(Filepath);
                            break;
                    }
                    if (Global.Confirm("Export Done\n\nYou Want To Open PDF File ?", "Account_Management", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
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

        private void FillGrid()
        {

            int IntError = 0;
            try
            {
                DgvPivot.BeginUpdate();

                foreach (DataRow DRow in mDTDetail.Rows)
                {
                    IntError++;
                    if (Val.ToBooleanToInt(DRow["IS_ROW_AREA"].ToString()) == 1)
                    {
                        PivotGridField Field = new PivotGridField(DRow["FIELD_NAME"].ToString(), DevExpress.XtraPivotGrid.PivotArea.RowArea);
                        Field.Caption = DRow["COLUMN_NAME"].ToString();

                        bool IsExists = false;
                        foreach (string Str in Group_By_Tag.Split(','))
                        {
                            if (Str == DRow["FIELD_NAME"].ToString())
                            {
                                IsExists = true;
                                break;
                            }
                        }

                        if (IsExists == true)
                        {
                            if (Val.ToString(DRow["ORDER_BY"]) != "")
                            {
                                Field.SortBySummaryInfo.FieldName = Val.ToString(DRow["ORDER_BY"]);
                            }
                            Field.Options.AllowExpand = DevExpress.Utils.DefaultBoolean.False;
                            Field.Visible = IsExists;
                            Field.BestFit();


                            if (DRow["ORDER_BY"].ToString() == "ASC")
                            {
                                Field.SortOrder = PivotSortOrder.Ascending;
                            }
                            if (DRow["ORDER_BY"].ToString() == "DESC")
                            {
                                Field.SortOrder = PivotSortOrder.Descending;
                            }

                            DgvPivot.Fields.Add(Field);
                        }

                    }
                    if (Val.ToBooleanToInt(DRow["IS_COLUMN_AREA"].ToString()) == 1)
                    {
                        PivotGridField Field = new PivotGridField(DRow["FIELD_NAME"].ToString(), DevExpress.XtraPivotGrid.PivotArea.ColumnArea);
                        Field.Caption = DRow["COLUMN_NAME"].ToString();
                        Field.AreaIndex = IntError;

                        bool IsExists = false;
                        foreach (string Str in Group_By_Tag.Split(','))
                        {
                            if (Str == DRow["FIELD_NAME"].ToString())
                            {
                                IsExists = true;
                                break;
                            }
                        }

                        if (Val.ToString(DRow["ORDER_BY"]) != "")
                        {
                            Field.SortBySummaryInfo.FieldName = Val.ToString(DRow["ORDER_BY"]);
                        }
                        if (IsExists == true)
                        {
                            Field.BestFit();
                            Field.Visible = Val.ToBooleanToInt(DRow["VISIBLE"]) == 1 ? true : false;
                            Field.Appearance.Header.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                            Field.Appearance.Value.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

                            if (DRow["ORDER_BY"].ToString() == "ASC")
                            {
                                Field.SortOrder = PivotSortOrder.Ascending;
                            }
                            if (DRow["ORDER_BY"].ToString() == "DESC")
                            {
                                Field.SortOrder = PivotSortOrder.Descending;
                            }
                            DgvPivot.Fields.Add(Field);
                        }
                    }

                    if (Val.ToBooleanToInt(DRow["IS_DATA_AREA"].ToString()) == 1)
                    {

                        PivotGridField Field = new PivotGridField(DRow["FIELD_NAME"].ToString(), PivotArea.DataArea);
                        Field.Caption = DRow["COLUMN_NAME"].ToString();

                        if (Val.ToString(DRow["TYPE"].ToString()) == "S")
                        {
                            Field.CellFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                            Field.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Max;
                            Field.CellFormat.FormatString = "S";
                        }
                        else
                        {
                            Field.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                            Field.CellFormat.FormatString = "0.000";
                        }

                        Field.Width = 60;
                        DgvPivot.Fields.Add(Field);
                        if (ObjReportDetailProperty.Remark != null &&
                            ObjReportDetailProperty.Remark.ToUpper().Equals("NKD_MIS_REPORT"))
                        {
                            Field.Options.ShowGrandTotal = false;
                            Field.Options.ShowTotals = false;
                            Field.RunningTotal = false;
                        }
                        else
                        {
                            Field.Options.ShowGrandTotal = true;
                            Field.Options.ShowTotals = true;
                            Field.RunningTotal = true;
                        }

                        if (ObjReportDetailProperty.Remark.ToUpper().Equals("EMPLOYEE PERFORMANCE WISE"))
                        {
                            Field.Options.ShowGrandTotal = false;
                            Field.Options.ShowTotals = false;
                            Field.RunningTotal = false;
                        }

                        //Check For Data Type And Assign Value Of Decimal
                        if (Val.ToString(DRow["TYPE"].ToString()) == "I")
                        {
                            DgvPivot.Fields[DRow["FIELD_NAME"].ToString()].CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                            DgvPivot.Fields[DRow["FIELD_NAME"].ToString()].CellFormat.FormatString = "{0:N0}";
                        }
                        else if (Val.ToString(DRow["TYPE"].ToString()) == "F")
                        {
                            DgvPivot.Fields[DRow["FIELD_NAME"].ToString()].CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;

                            string StrFormat = "N3";
                            if (!Val.ToString(DRow["FORMAT"]).Trim().Equals(string.Empty))
                                StrFormat = Val.ToString(DRow["FORMAT"]);
                            DgvPivot.Fields[DRow["FIELD_NAME"].ToString()].CellFormat.FormatString = "{0:" + StrFormat + "}";

                        }
                        ///Check For Summary'''
                    }
                }

                DgvPivot.DataSource = DTab;
                IntError = 0;
                foreach (DataRow DRow in mDTDetail.Rows)
                {
                    IntError++;
                    bool iBool = false;
                    foreach (DataColumn DCol in DTab.Columns)
                    {
                        if (DCol.ColumnName == DRow["FIELD_NAME"].ToString())
                        {
                            iBool = true;
                            break;
                        }
                    }

                    //foreach (DataRow Dr in DTab.Rows)
                    //{
                    //    if(Val.ToInt(Dr["confirm_different_days"]) == 4)
                    //    {
                    //        DgvPivot.
                    //    }
                    //}

                    if (iBool == false)
                    {
                        continue;
                    }

                    if (Val.ToBooleanToInt(DRow["VISIBLE"].ToString()) == 0)
                    {
                        continue;
                    }

                    if (Val.ToBooleanToInt(DRow["VISIBLE"].ToString()) == 0)
                    {
                        DTab.Columns.Remove(DRow["FIELD_NAME"].ToString());
                        continue;
                    }
                    else
                    {
                        if (DRow["MERGEON"].ToString() != "")
                        {
                            MergeOn = DRow["MERGEON"].ToString();

                            if (MergeOnStr == "")
                            {
                                MergeOnStr = DRow["MERGEON"].ToString();
                            }
                            else
                            {
                                MergeOnStr = MergeOnStr + "," + DRow["FIELD_NAME"].ToString();
                            }
                        }
                    }

                    if (Val.ToString(DRow["AGGREGATE"].ToString()) == "SUM")
                    {
                        DgvPivot.Fields[DRow["FIELD_NAME"].ToString()].SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Sum;
                    }
                    else if (Val.ToString(DRow["AGGREGATE"].ToString()) == "AVG")
                    {
                        DgvPivot.Fields[DRow["FIELD_NAME"].ToString()].SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Average;
                    }
                    else if (Val.ToString(DRow["AGGREGATE"].ToString()) == "COUNT")
                    {
                        DgvPivot.Fields[DRow["FIELD_NAME"].ToString()].SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
                    }
                    else if (Val.ToString(DRow["AGGREGATE"].ToString()) == "MAX")
                    {
                        DgvPivot.Fields[DRow["FIELD_NAME"].ToString()].SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Max;
                    }
                    else if (Val.ToString(DRow["AGGREGATE"].ToString()) == "MIN")
                    {
                        DgvPivot.Fields[DRow["FIELD_NAME"].ToString()].SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Min;
                    }
                    else if (Val.ToString(DRow["AGGREGATE"].ToString()) == "CUSTOME")
                    {
                        DgvPivot.Fields[DRow["FIELD_NAME"].ToString()].SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Custom;
                    }
                }

                DgvPivot.Appearance.FieldValue.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                DgvPivot.Appearance.FieldHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

                DgvPivot.Appearance.FieldValue.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                DgvPivot.Appearance.FieldHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;

                DgvPivot.Appearance.FieldValue.Font = new Font(ObjReportDetailProperty.Font_Name, float.Parse(Val.ToString(ObjReportDetailProperty.Font_Size)), FontStyle.Bold);
                DgvPivot.AppearancePrint.FieldValue.Font = new Font(ObjReportDetailProperty.Font_Name, float.Parse(Val.ToString(ObjReportDetailProperty.Font_Size)), FontStyle.Bold);

                DgvPivot.Appearance.FieldHeader.Font = new Font(ObjReportDetailProperty.Font_Name, float.Parse(Val.ToString(ObjReportDetailProperty.Font_Size)), FontStyle.Bold);
                DgvPivot.AppearancePrint.FieldHeader.Font = new Font(ObjReportDetailProperty.Font_Name, float.Parse(Val.ToString(ObjReportDetailProperty.Font_Size)), FontStyle.Bold);

                DgvPivot.Appearance.ColumnHeaderArea.Font = new Font(ObjReportDetailProperty.Font_Name, float.Parse(Val.ToString(ObjReportDetailProperty.Font_Size)), FontStyle.Bold);
                DgvPivot.Appearance.DataHeaderArea.Font = new Font(ObjReportDetailProperty.Font_Name, float.Parse(Val.ToString(ObjReportDetailProperty.Font_Size)), FontStyle.Bold);
                DgvPivot.Appearance.FilterHeaderArea.Font = new Font(ObjReportDetailProperty.Font_Name, float.Parse(Val.ToString(ObjReportDetailProperty.Font_Size)), FontStyle.Bold);
                DgvPivot.Appearance.HeaderArea.Font = new Font(ObjReportDetailProperty.Font_Name, float.Parse(Val.ToString(ObjReportDetailProperty.Font_Size)), FontStyle.Bold);

                DgvPivot.Appearance.FieldValueGrandTotal.Font = new Font(ObjReportDetailProperty.Font_Name, float.Parse(Val.ToString(ObjReportDetailProperty.Font_Size)), FontStyle.Bold);
                DgvPivot.AppearancePrint.FieldValueGrandTotal.Font = new Font(ObjReportDetailProperty.Font_Name, float.Parse(Val.ToString(ObjReportDetailProperty.Font_Size)), FontStyle.Bold);

                DgvPivot.Appearance.FieldValueTotal.Font = new Font(ObjReportDetailProperty.Font_Name, float.Parse(Val.ToString(ObjReportDetailProperty.Font_Size)), FontStyle.Bold);
                DgvPivot.AppearancePrint.FieldValueTotal.Font = new Font(ObjReportDetailProperty.Font_Name, float.Parse(Val.ToString(ObjReportDetailProperty.Font_Size)), FontStyle.Bold);

                DgvPivot.Appearance.GrandTotalCell.Font = new Font(ObjReportDetailProperty.Font_Name, float.Parse(Val.ToString(ObjReportDetailProperty.Font_Size)), FontStyle.Bold);
                DgvPivot.AppearancePrint.GrandTotalCell.Font = new Font(ObjReportDetailProperty.Font_Name, float.Parse(Val.ToString(ObjReportDetailProperty.Font_Size)), FontStyle.Bold);

                DgvPivot.Appearance.TotalCell.Font = new Font(ObjReportDetailProperty.Font_Name, float.Parse(Val.ToString(ObjReportDetailProperty.Font_Size)), FontStyle.Bold);
                DgvPivot.AppearancePrint.TotalCell.Font = new Font(ObjReportDetailProperty.Font_Name, float.Parse(Val.ToString(ObjReportDetailProperty.Font_Size)), FontStyle.Bold);

                DgvPivot.OptionsPrint.UsePrintAppearance = true;

                cmbOrientation.SelectedItem = ObjReportDetailProperty.Page_Orientation;

                DgvPivot.EndUpdate();
                DgvPivot.BestFit();

                //if (
                //       ObjReportDetailProperty.Remark == "PREM_DETAIL" ||
                //       ObjReportDetailProperty.Remark == "PREM_SUMMARY" ||
                //       ObjReportDetailProperty.Remark == "PURCHASE_PIVOT" ||
                //       ObjReportDetailProperty.Remark == "PURCHASE_OS_PIVOT" ||
                //       ObjReportDetailProperty.Remark == "BRANCH_TRF_SUMM" ||
                //       ObjReportDetailProperty.Remark == "BRANCH_TRF_DET" ||
                //       ObjReportDetailProperty.Remark == "PUR_OUTSTANDING" ||
                //       ObjReportDetailProperty.Remark == "TEAM_TRANSFER" ||
                //       ObjReportDetailProperty.Remark == "SALES_EXPORT"
                //       )
                //{
                //    foreach (PivotGridField field in DgvPivot.Fields)
                //    {
                //        if (IS_Dollar == false && field.FieldName.ToUpper().Contains("DOLLAR"))
                //        {
                //            field.Visible = false;
                //        }
                //        if (IS_Local == false && field.FieldName.ToUpper().Contains("LOCAL"))
                //        {
                //            field.Visible = false;
                //        }
                //        if (IS_Purchase == false && field.FieldName.ToUpper().Contains("PURCHASE"))
                //        {
                //            field.Visible = false;
                //        }
                //    }
                //}
            }
            catch (Exception ex)
            {
                Global.Message("Error In Column Index : " + IntError.ToString() + "    " + ex.Message);
            }
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
            //// ' For Report Title
            //TextBrick BrickTitle = e.Graph.DrawString(lblReportHeader.Text, Color.Black, new RectangleF(0, 0, 500, 20), BorderSide.None);
            //BrickTitle.Font = new Font("Tahoma", 15);
            //BrickTitle.HorzAlignment = DevExpress.Utils.HorzAlignment.Near;
            //BrickTitle.VertAlignment = DevExpress.Utils.VertAlignment.Center;
            //// ' For Filter 
            //TextBrick BrickFilter = e.Graph.DrawString("Filter : " + lblFilter.Text, Color.Black, new RectangleF(2, 22, 1000, 15), BorderSide.None);
            //BrickFilter.Font = new Font("Tahoma", 8);
            //BrickFilter.HorzAlignment = DevExpress.Utils.HorzAlignment.Near;
            //BrickFilter.VertAlignment = DevExpress.Utils.VertAlignment.Center;

            //// ' For Group 
            //TextBrick BrickGroup = e.Graph.DrawString("Group : " + lblGroupBy.Text, Color.Black, new RectangleF(2, 40, 1000, 15), BorderSide.None);
            //BrickGroup.Font = new Font("Tahoma", 8);
            //BrickGroup.HorzAlignment = DevExpress.Utils.HorzAlignment.Near;
            //BrickGroup.VertAlignment = DevExpress.Utils.VertAlignment.Center;
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

        #endregion

        #region Pivot Grid Events

        private void DgvPivot_CustomDrawCell(object sender, PivotCustomDrawCellEventArgs e)
        {
            try
            {
                //Rectangle r;
                //if (ObjReportDetailProperty.Remark.ToUpper() == "EMPLOYEE PERFORMANCE WISE")
                //{
                //    DgvPivot.Appearance.ColumnHeaderArea.BackColor = System.Drawing.Color.Yellow;
                //    DgvPivot.Appearance.RowHeaderArea.BackColor = System.Drawing.Color.DarkBlue;
                //    Brush backBrush;
                //    r = e.Bounds;
                //    for (int i = 0; i < DTab.Rows.Count; i++)
                //    {
                //        if (DTab.Rows[i]["color_days"].ToString() == "")
                //        {
                //            continue;
                //        }

                //        if (DTab.Rows[i]["color_days"].ToString() == "RED")
                //        {
                //            string Display_Name = Val.ToString(DTab.Rows[i]["achieve_rough_cut_no"].ToString());
                //            if (e.DisplayText == Display_Name && DTab.Rows[i]["color_days"].ToString() == "RED")
                //            // Initializes the brush used to paint the focused cell. 
                //            {
                //                backBrush = e.GraphicsCache.GetSolidBrush(Color.Red);
                //                //    else
                //                //if (e.Selected)
                //                //        // Initializes the brush used to paint selected cells. 
                //                //        backBrush = e.GraphicsCache.GetSolidBrush(Color.Blue);
                //                //    else
                //                //        // Initializes the brush used to paint data cells. 
                //                //        backBrush = e.GraphicsCache.GetSolidBrush(Color.LawnGreen);

                //                e.GraphicsCache.DrawRectangle(new Pen(new SolidBrush(Color.DimGray), 1), r);
                //                r.Inflate(-1, -1);
                //                e.GraphicsCache.FillRectangle(backBrush, r);
                //                e.Appearance.DrawString(e.GraphicsCache, e.DisplayText, r);

                //                e.Handled = true;
                //            }
                //        }
                //        if (DTab.Rows[i]["color_days"].ToString() == "GREEN")
                //        {
                //            string Display_Name = Val.ToString(DTab.Rows[i]["achieve_rough_cut_no"].ToString());
                //            if (e.DisplayText == Display_Name)
                //            // Initializes the brush used to paint the focused cell. 
                //            {
                //                backBrush = e.GraphicsCache.GetSolidBrush(Color.Green);
                //                //    else
                //                //if (e.Selected)
                //                //        // Initializes the brush used to paint selected cells. 
                //                //        backBrush = e.GraphicsCache.GetSolidBrush(Color.Blue);
                //                //    else
                //                //        // Initializes the brush used to paint data cells. 
                //                //        backBrush = e.GraphicsCache.GetSolidBrush(Color.LawnGreen);

                //                e.GraphicsCache.DrawRectangle(new Pen(new SolidBrush(Color.DimGray), 1), r);
                //                r.Inflate(-1, -1);
                //                e.GraphicsCache.FillRectangle(backBrush, r);
                //                e.Appearance.DrawString(e.GraphicsCache, e.DisplayText, r);

                //                e.Handled = true;
                //            }
                //        }
                //    }
                //}
                //for (int i = 0; i < DTab.Rows.Count; i++)
                //{
                //    DgvPivot.Appearance.ColumnHeaderArea.BackColor = System.Drawing.Color.Yellow;
                //    DgvPivot.Appearance.RowHeaderArea.BackColor = System.Drawing.Color.DarkBlue;
                //    if (DTab.Rows[i]["color_days"].ToString() == "")
                //    {
                //        continue;
                //    }
                //    if (DTab.Rows[i]["color_days"].ToString() == "RED")
                //    {
                //        //string Display_Name = Val.ToString(DTab.Rows[i]["achieve_rough_cut_no"].ToString());
                //        //if (e.DisplayText == Display_Name)
                //        //{
                //        //    e.Appearance.BackColor = System.Drawing.Color.Red;
                //        //}
                //    }
                //    if (DTab.Rows[i]["color_days"].ToString() == "ORANGE")
                //    {
                //        string Display_Name = Val.ToString(DTab.Rows[i]["achieve_rough_cut_no"].ToString());
                //        if (e.DisplayText == Display_Name)
                //        {
                //            e.Appearance.BackColor = System.Drawing.Color.Orange;
                //        }
                //    }
                //    if (DTab.Rows[i]["color_days"].ToString() == "GREEN")
                //    {
                //        string Display_Name = Val.ToString(DTab.Rows[i]["achieve_rough_cut_no"].ToString());
                //        if (e.DisplayText == Display_Name)
                //        {
                //            e.Appearance.BackColor = System.Drawing.Color.Green;
                //        }
                //    }
                //}
                //}
                //if (e.DisplayText == "4" || e.DisplayText == "A1-96" || e.DisplayText == "0.000")
                //{
                //    e.Appearance.BackColor = System.Drawing.Color.Red;
                //}
                //if (ObjReportDetailProperty.Remark.ToUpper() == "EMPLOYEE PERFORMANCE WISE")
                //{
                //    if (e.DisplayText == "color_days")
                //    {

                //    }
                //}
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        private void EmailToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (ObjPer.AllowEMail == false)
            {
                Global.Message(BLL.GlobalDec.gStrPermissionEMailMsg);
                return;
            }

            string StrFile = Global.DataGridExportToExcel(DgvPivot, "Report");

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

        private void DgvPivot_CellClick(object sender, PivotCellEventArgs e)
        {
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DgvPivot_CustomCellDisplayText(object sender, PivotCellDisplayTextEventArgs e)
        {
            if (e.DisplayText == "0.00" || e.DisplayText == "0" || e.DisplayText == "0.000")
            {
                e.DisplayText = String.Empty;
            }
        }
        private void DgvPivot_CustomSummary(object sender, PivotGridCustomSummaryEventArgs e)
        {
            #region Assortment Summary Pivot Report

            if (ObjReportDetailProperty.Remark.ToUpper() == "ASSORT_PARAMETER")
            {

                if (e.ColumnField == null) return;

                DataView dtview = DTab.Copy().DefaultView;
                dtview.RowFilter = " ROUGH_NAME = '" + Val.ToString(e.ColumnFieldValue) + "'";
                double TotalCarats = Val.Val(dtview.ToTable().Compute("Sum(CARATS)", ""));
                double TotalAmount = Val.Val(dtview.ToTable().Compute("Sum(AMOUNT)", ""));

                if (e.DataField.FieldName == "PER")
                {
                    PivotDrillDownDataSource ds = e.CreateDrillDownDataSource();

                    int i = 0;
                    double DouPer = 0;
                    for (i = 0; i <= ds.RowCount - 1; i++)
                    {
                        PivotDrillDownDataRow row = ds[i];
                        // Get the order's total sum.
                        if (TotalCarats > 0)
                        {
                            DouPer = DouPer + Val.Val(row["CARATS"]);
                        }
                    }

                    // Calculate the percentage.
                    if (ds.RowCount > 0)
                    {
                        e.CustomValue = Math.Round((Val.Val(DouPer) / TotalCarats) * 100, 2);
                    }
                    //PivotGridField[] rowFields = e.DataField
                }
                else if (e.DataField.FieldName == "RATE" || e.DataField.FieldName == "AVG_SIZE")
                {
                    PivotDrillDownDataSource ds = e.CreateDrillDownDataSource();
                    int IntPcs = 0;
                    int i = 0;
                    double DouCarat = 0;
                    double DouAmount = 0;
                    for (i = 0; i <= ds.RowCount - 1; i++)
                    {
                        PivotDrillDownDataRow row = ds[i];
                        // Get the order's total sum.
                        if (TotalCarats > 0)
                        {
                            IntPcs = IntPcs + Val.ToInt(row["PCS"]);
                            DouCarat = DouCarat + Val.Val(row["CARATS"]);
                            DouAmount = DouAmount + Val.Val(row["AMOUNT"]);
                        }
                    }

                    // Calculate the Rate.
                    if (ds.RowCount > 0)
                    {
                        if (e.DataField.FieldName == "RATE")
                        {
                            e.CustomValue = DouCarat != 0 ? Math.Round(DouAmount / DouCarat, 2) : 0.00;
                        }
                        if (e.DataField.FieldName == "AVG_SIZE")
                        {
                            e.CustomValue = DouCarat != 0 ? Math.Round(IntPcs / DouCarat, 2) : 0.00;
                        }
                    }
                }
            }
            else if (ObjReportDetailProperty.Remark.ToUpper() == "SIEVE_WISE")
            {
                if (e.ColumnField == null) return;

                DataView dtview = DTab.Copy().DefaultView;
                //dtview.RowFilter = " ROUGH_NAME = '" + Val.ToString(e.ColumnFieldValue) + "'";
                double TotalAmount = Val.Val(dtview.ToTable().Compute("Sum(total_amount)", ""));
                double Totalcarat = Val.Val(dtview.ToTable().Compute("Sum(total_carat)", ""));
                // if(e.ty is )
                //MessageBox.Show(e.DataField.FieldName.ToString());
                if (e.DataField.FieldName == "rate")
                {
                    PivotDrillDownDataSource ds = e.CreateDrillDownDataSource();
                    int IntPcs = 0;
                    int i = 0;
                    double DouCarat = 0;
                    double DouAmount = 0;
                    for (i = 0; i <= ds.RowCount - 1; i++)
                    {
                        PivotDrillDownDataRow row = ds[i];
                        // Get the order's total sum.
                        if (TotalAmount > 0)
                        {
                            //IntPcs = IntPcs + Val.ToInt(row["PCS"]);
                            DouCarat = DouCarat + Val.Val(row["total_carat"]);
                            DouAmount = DouAmount + Val.Val(row["total_amount"]);

                            //if (e.DataField.FieldName == "rate")
                            //{
                            //    e.CustomValue = DouCarat != 0 ? Math.Round(DouAmount / DouCarat, 2) : 0.00;
                            //}
                        }
                    }


                    //if (CustomSummaryHelper.ShouldCalculateCustomValue(fieldType, e))
                    //{
                    //    var groupedDataSource =
                    //        e.CreateDrillDownDataSource().Cast<PivotDrillDownDataRow>().GroupBy(r => r[fieldType]);
                    //    decimal incomeSummary = CustomSummaryHelper.GetGroupSummary(groupedDataSource, "Income", e.FieldName);
                    //    decimal outlaySummary = CustomSummaryHelper.GetGroupSummary(groupedDataSource, "Outlay", e.FieldName);
                    //    e.CustomValue = incomeSummary - outlaySummary;
                    //}
                    //else
                    //{
                    //    e.CustomValue = e.SummaryValue.Summary;
                    //}

                    // Calculate the Rate.
                    if (ds.RowCount > 0)
                    {
                        if (e.DataField.FieldName == "rate")
                        {
                            e.CustomValue = DouCarat != 0 ? Math.Round(DouAmount / DouCarat, 2) : 0.00;
                        }
                        //            If e.DataField Is pivotGridField5 Then
                        //    Dim summaryValue = pivotGridControl1.GetCellValue(Nothing, Nothing, pivotGridField2)
                        //    e.Value = CDec(e.GetCellValue(pivotGridField3)) / CDec(summaryValue)
                        //End If
                        if (e.DataField.FieldName == "AVG_SIZE")
                        {
                            e.CustomValue = DouCarat != 0 ? Math.Round(IntPcs / DouCarat, 2) : 0.00;
                        }

                    }
                }
            }
            #endregion
        }

        private void DgvPivot_CustomAppearance(object sender, PivotCustomAppearanceEventArgs e)
        {
            if (ObjReportDetailProperty.Remark.ToUpper() == "EMPLOYEE PERFORMANCE WISE")
            {
                for (int i = 0; i < DTab.Rows.Count; i++)
                {
                    if (DTab.Rows[i]["color_days"].ToString() == "")
                    {
                        continue;
                    }

                    if (DTab.Rows[i]["color_days"].ToString() == "RED")
                    {
                        string Display_Name = Val.ToString(DTab.Rows[i]["achieve_rough_cut_no"].ToString());
                        PivotGridField Field = new PivotGridField("achieve_rough_cut_no", PivotArea.RowArea);

                        if (DTab.Rows[i]["color_days"].ToString() == "RED" && e.ColumnValueType == PivotGridValueType.Value && e.RowValueType == PivotGridValueType.Value)
                        {
                            if (e.Value != null && e.DataField.ToString() == "Achivement" && Val.ToString(e.Value) == Display_Name.ToString())
                            {
                                e.Appearance.BackColor = Color.FromArgb(255, 51, 51);
                                e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
                            }
                        }
                    }
                    if (DTab.Rows[i]["color_days"].ToString() == "GREEN")
                    {
                        string Display_Name = Val.ToString(DTab.Rows[i]["achieve_rough_cut_no"].ToString());
                        PivotGridField Field = new PivotGridField("achieve_rough_cut_no", PivotArea.RowArea);

                        if (DTab.Rows[i]["color_days"].ToString() == "GREEN" && e.ColumnValueType == PivotGridValueType.Value && e.RowValueType == PivotGridValueType.Value)
                        {
                            if (e.Value != null && e.DataField.ToString() == "Achivement" && Val.ToString(e.Value) == Display_Name.ToString())
                            {
                                e.Appearance.BackColor = Color.FromArgb(144, 238, 144);
                                e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
                            }
                        }
                    }
                    if (DTab.Rows[i]["color_days"].ToString() == "ORANGE")
                    {
                        string Display_Name = Val.ToString(DTab.Rows[i]["achieve_rough_cut_no"].ToString());
                        PivotGridField Field = new PivotGridField("achieve_rough_cut_no", PivotArea.RowArea);

                        if (DTab.Rows[i]["color_days"].ToString() == "ORANGE" && e.ColumnValueType == PivotGridValueType.Value && e.RowValueType == PivotGridValueType.Value)
                        {
                            if (e.Value != null && e.DataField.ToString() == "Achivement" && Val.ToString(e.Value) == Display_Name.ToString())
                            {
                                e.Appearance.BackColor = Color.FromArgb(255, 160, 122);
                                e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
                            }
                        }
                    }
                }
            }
        }
    }
}
