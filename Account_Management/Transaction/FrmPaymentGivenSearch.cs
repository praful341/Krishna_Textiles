using Account_Management.Class;
using Account_Management.Search;
using BLL;
using BLL.FunctionClasses.Account;
using System;
using System.Data;
using System.Windows.Forms;
using static Account_Management.Class.Global;

namespace Account_Management.Transaction
{
    public partial class FrmPaymentGivenSearch : DevExpress.XtraEditors.XtraForm
    {
        #region Declaration

        Validation Val = new Validation();
        public DataTable DTab = new DataTable();
        PaymentGiven objPaymentGiven = new PaymentGiven();
        FormEvents objBOFormEvents = new FormEvents();
        public FrmPaymentGiven FrmPaymentGiven = new FrmPaymentGiven();
        //FrmSearch FrmSearch;
        FrmSearchNew FrmSearchNew;
        string FormName = "";

        #endregion

        #region Constructor
        public FrmPaymentGivenSearch()
        {
            InitializeComponent();
        }

        public void ShowForm(FrmPaymentGiven ObjForm, Int64 Ledger_ID, string Ledger_Name, decimal Amount)
        {
            FrmPaymentGiven = new FrmPaymentGiven();
            FrmPaymentGiven = ObjForm;
            lblLedger.Text = Ledger_Name;
            lblLedgerID.Text = Ledger_ID.ToString();
            lblAmount.Text = Amount.ToString();
            FormName = "FrmPaymentGiven";
            Val.frmGenSetForPopup(this);
            AttachFormEvents();
            //this.Text = "Payment Given";
            this.ShowDialog();
        }
        private void AttachFormEvents()
        {
            objBOFormEvents.CurForm = this;
            objBOFormEvents.FormKeyPress = true;
            objBOFormEvents.FormResize = true;
            objBOFormEvents.FormClosing = true;
            objBOFormEvents.ObjToDispose.Add(Val);
            objBOFormEvents.ObjToDispose.Add(objBOFormEvents);
        }
        #endregion

        #region Form Events
        private void FrmPaymentReceiptSearch_Load(object sender, EventArgs e)
        {
            try
            {
                MainGrid.DataSource = DTab;
                GrdDet.PostEditor();
                GrdDet.FocusedRowHandle = GrdDet.DataRowCount - 1;
                GrdDet.FocusedColumn = GrdDet.Columns["method"];
                RepMethod.AllowFocused = true;

                RepMethod.Items.Add("Adjustment");
                RepMethod.Items.Add("New Ref.");
            }
            catch (Exception ex)
            {
                Global.ErrorMessage(ex.Message);
            }
        }
        private void FrmPaymentReceiptSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Other Function       
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
                            GrdDet.ExportToPdf(Filepath);
                            break;
                        case "xls":
                            GrdDet.ExportToXls(Filepath);
                            break;
                        case "xlsx":
                            GrdDet.ExportToXlsx(Filepath);
                            break;
                        case "rtf":
                            GrdDet.ExportToRtf(Filepath);
                            break;
                        case "txt":
                            GrdDet.ExportToText(Filepath);
                            break;
                        case "html":
                            GrdDet.ExportToHtml(Filepath);
                            break;
                        case "csv":
                            GrdDet.ExportToCsv(Filepath);
                            break;
                    }
                    if (format.Equals(Exports.xlsx.ToString()))
                    {
                        if (Global.Confirm("Export Done\n\nYou Want To Open Excel File ?", "DERP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start(Filepath);
                        }
                    }
                    else if (format.Equals(Exports.pdf.ToString()))
                    {
                        if (Global.Confirm("Export Done\n\nYou Want To Open PDF File ?", "DERP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start(Filepath);
                        }
                    }
                    else
                    {
                        if (Global.Confirm("Export Done\n\nYou Want To Open File ?", "DERP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start(Filepath);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Global.Message(ex.Message.ToString(), "Error in Export");
            }
        }
        #endregion

        #region Repository Events
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (FormName == "FrmPaymentGiven")
            {
                decimal Payment_Rec_Amount = Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue);
                if (Payment_Rec_Amount != Val.ToDecimal(lblAmount.Text))
                {
                    Global.Message("Total Amount Not Equal To Payment Given Amount");
                    return;
                }
                DialogResult result = MessageBox.Show("Do you want to save data?", "Confirmation", MessageBoxButtons.YesNoCancel);
                if (result != DialogResult.Yes)
                {
                    return;
                }
                DataTable DTab_Select = (DataTable)MainGrid.DataSource;
                this.Close();
                FrmPaymentGiven.GetPaymentGivenData(DTab_Select);
            }
        }
        #endregion

        #region Export Grid
        private void MNExportExcel_Click(object sender, EventArgs e)
        {
            Export("xlsx", "Export to Excel", "Excel files 97-2003 (Excel files 2007(*.xlsx)|*.xlsx|All files (*.*)|*.*");
        }
        private void MNExportPDF_Click(object sender, EventArgs e)
        {
            Export("pdf", "Export Report to PDF", "PDF (*.PDF)|*.PDF");
        }
        private void MNExportTEXT_Click(object sender, EventArgs e)
        {
            Export("txt", "Export to Text", "Text files (*.txt)|*.txt|All files (*.*)|*.*");
        }
        private void MNExportHTML_Click(object sender, EventArgs e)
        {
            Export("html", "Export to HTML", "Html files (*.html)|*.html|Htm files (*.htm)|*.htm");
        }
        private void MNExportRTF_Click(object sender, EventArgs e)
        {
            Export("rtf", "Export to RTF", "Word (*.doc) |*.doc;*.rtf|(*.txt) |*.txt|(*.*) |*.*");
        }
        private void MNExportCSV_Click(object sender, EventArgs e)
        {
            Export("csv", "Export Report to CSVB", "csv (*.csv)|*.csv");
        }

        #endregion

        private void RepOrderNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                string Method = Val.ToString(GrdDet.GetRowCellValue(GrdDet.FocusedRowHandle, "method"));

                if (GrdDet.FocusedColumn.FieldName.ToUpper() == "PURCHASE_BILL_NO" && Method == "Adjustment")
                {
                    //FrmSearch = new Search.FrmSearch();
                    //FrmSearch._FrmSearchProperty = new Class.FrmSearchProperty();
                    //FrmSearch._FrmSearchProperty.dtTable = objPaymentReceipt.Sale_Invoice_Search_GetData(Val.ToInt64(lblLedgerID.Text));
                    ////FrmSearch.txtSearch.Text = e.KeyChar.ToString();
                    //FrmSearch._FrmSearchProperty.SearchField = "ref_order_no";

                    //FrmSearch.ShowDialog();
                    //e.Handled = true;
                    //if (FrmSearch._FrmSearchProperty.dtrow != null)
                    //{
                    //    GrdDet.SetFocusedRowCellValue("ref_order_no", Val.ToString(FrmSearch._FrmSearchProperty.dtrow.Cells["order_no"].Value));
                    //    GrdDet.SetFocusedRowCellValue("due_date", Val.ToString(FrmSearch._FrmSearchProperty.dtrow.Cells["due_date"].Value));
                    //    GrdDet.SetFocusedRowCellValue("amount", Val.ToString(FrmSearch._FrmSearchProperty.dtrow.Cells["os_amount"].Value));
                    //    GrdDet.SetFocusedRowCellValue("invoice_id", Val.ToString(FrmSearch._FrmSearchProperty.dtrow.Cells["invoice_id"].Value));
                    //    GrdDet.PostEditor();
                    //}

                    //FrmSearch.Hide();
                    //FrmSearch.Dispose();
                    //FrmSearch = null;

                    FrmSearchNew = new Search.FrmSearchNew();
                    FrmSearchNew.SearchText = e.KeyChar.ToString();
                    FrmSearchNew.DTab = objPaymentGiven.Sale_Invoice_Search_GetData(Val.ToInt64(lblLedgerID.Text));

                    FrmSearchNew.SearchField = "purchase_bill_no";

                    FrmSearchNew.ShowDialog();
                    e.Handled = true;
                    if (FrmSearchNew.DTab != null)
                    {
                        if (FrmSearchNew.DRow != null)
                        {
                            GrdDet.SetFocusedRowCellValue("purchase_bill_no", Val.ToString(FrmSearchNew.DRow["purchase_bill_no"]));
                            GrdDet.SetFocusedRowCellValue("due_date", Val.ToString(FrmSearchNew.DRow["due_date"]));
                            GrdDet.SetFocusedRowCellValue("amount", Val.ToString(FrmSearchNew.DRow["os_amount"]));
                            GrdDet.SetFocusedRowCellValue("purchase_id", Val.ToString(FrmSearchNew.DRow["purchase_id"]));
                            GrdDet.PostEditor();
                        }
                    }
                    FrmSearchNew.Hide();
                    FrmSearchNew.Dispose();
                    FrmSearchNew = null;
                }
            }
            catch (Exception Ex)
            {
                Global.Message(Ex.ToString());
                return;
            }
        }
        private void RepDueDate_KeyDown(object sender, KeyEventArgs e)
        {
            //GrdDet.CloseEditor();
            if (e.KeyCode == Keys.Enter && GrdDet.IsLastRow)
            {
                DataRow dtRow = DTab.NewRow();
                e.Handled = true;
                GrdDet.SetRowCellValue(GrdDet.DataRowCount - 1, "sr_no", GrdDet.GetRowCellValue(GrdDet.FocusedRowHandle, "sr_no"));
                int sr_no = Val.ToInt32(GrdDet.GetRowCellValue(GrdDet.FocusedRowHandle, "sr_no"));
                dtRow["sr_no"] = sr_no + 1;

                //decimal Amt = Val.ToDecimal(GrdDet.GetRowCellValue(GrdDet.FocusedRowHandle, "amount"));
                DTab.Rows.Add(dtRow);
                GrdDet.PostEditor();
                GrdDet.FocusedRowHandle = GrdDet.DataRowCount - 1;
                GrdDet.FocusedColumn = GrdDet.Columns["method"];

                decimal Total_Amount = Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue);

                if (Total_Amount == Val.ToDecimal(lblAmount.Text))
                {
                    BtnSave.Focus();
                }
            }
        }
    }
}