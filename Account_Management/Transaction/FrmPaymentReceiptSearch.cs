using Account_Management.Class;
using BLL;
using BLL.FunctionClasses.Account;
using System;
using System.Data;
using System.Windows.Forms;
using static Account_Management.Class.Global;

namespace Account_Management.Transaction
{
    public partial class FrmPaymentReceiptSearch : DevExpress.XtraEditors.XtraForm
    {
        #region Declaration

        Validation Val = new Validation();
        public DataTable DTab = new DataTable();
        PaymentReceipt objPaymentReceipt = new PaymentReceipt();
        FormEvents objBOFormEvents = new FormEvents();
        public FrmPaymentReceipt FrmPaymentReceipt = new FrmPaymentReceipt();
        string FormName = "";

        #endregion

        #region Constructor
        public FrmPaymentReceiptSearch()
        {
            InitializeComponent();
        }

        public void ShowForm(FrmPaymentReceipt ObjForm, Int64 Ledger_ID, string Ledger_Name, decimal Amount)
        {
            FrmPaymentReceipt = new FrmPaymentReceipt();
            FrmPaymentReceipt = ObjForm;
            lblLedger.Text = Ledger_Name;
            lblLedgerID.Text = Ledger_ID.ToString();
            lblAmount.Text = Amount.ToString();
            FormName = "FrmPaymentReceipt";
            Val.frmGenSetForPopup(this);
            AttachFormEvents();
            this.Text = "Payment Receipt";
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
        private void FrmJangedConfirm_Load(object sender, EventArgs e)
        {
            try
            {
                MainGrid.DataSource = DTab;

                RepMethod.Items.Add("Adjusment");
                RepMethod.Items.Add("New Ref.");

                GrdDet.PostEditor();
                GrdDet.FocusedRowHandle = GrdDet.DataRowCount;
                GrdDet.FocusedColumn = GrdDet.Columns["method"];
                RepMethod.AllowFocused = true;

            }
            catch (Exception ex)
            {
                Global.ErrorMessage(ex.Message);
            }
        }
        private void FrmJangedConfirm_KeyDown(object sender, KeyEventArgs e)
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
            if (FormName == "FrmPaymentReceipt")
            {
                decimal Payment_Rec_Amount = Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue);
                if (Payment_Rec_Amount > Val.ToDecimal(lblAmount.Text))
                {
                    Global.Message("Total Amount Not Greater Then Payment Receive Amount");
                    return;
                }
                DialogResult result = MessageBox.Show("Do you want to save data?", "Confirmation", MessageBoxButtons.YesNoCancel);
                if (result != DialogResult.Yes)
                {
                    return;
                }
                DataTable DTab_Select = (DataTable)MainGrid.DataSource;
                this.Close();
                FrmPaymentReceipt.GetPaymentReceiptData(DTab_Select);
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
            int sr_no = Val.ToInt32(GrdDet.GetRowCellValue(GrdDet.FocusedRowHandle, "sr_no"));

            DataTable DTab_SaleInvoice = objPaymentReceipt.Sale_Invoice_Search_GetData(Val.ToInt64(lblLedgerID.Text));

            if (DTab_SaleInvoice.Rows.Count > 0)
            {
                FrmSaleInvoiceSearch frmSaleInvoiceSearch = new FrmSaleInvoiceSearch();
                frmSaleInvoiceSearch.FrmPaymentReceiptSearch = this;
                frmSaleInvoiceSearch.DTab = DTab_SaleInvoice;
                frmSaleInvoiceSearch.ShowForm(this);
            }
            else
            {
                Global.Message(lblLedger.Text + " Ledger Data Not Found In Sale Invoice");
                return;
            }
        }

        private void RepDueDate_KeyDown(object sender, KeyEventArgs e)
        {
            GrdDet.CloseEditor();
            if (e.KeyCode == Keys.Enter && GrdDet.IsLastRow)
            {
                DataRow dtRow = DTab.NewRow();
                e.Handled = true;
                GrdDet.SetRowCellValue(GrdDet.DataRowCount - 1, "sr_no", GrdDet.GetRowCellValue(GrdDet.FocusedRowHandle, "sr_no"));
                int sr_no = Val.ToInt32(GrdDet.GetRowCellValue(GrdDet.FocusedRowHandle, "sr_no"));
                dtRow["sr_no"] = sr_no + 1;

                DTab.Rows.Add(dtRow);
                GrdDet.PostEditor();
                GrdDet.FocusedRowHandle = GrdDet.DataRowCount - 1;
                GrdDet.FocusedColumn = GrdDet.Columns["method"];

            }
            //else if (e.KeyCode == Keys.Enter)
            //{
            //    GrdDet.PostEditor();

            //    if (!GrdDet.GetRowCellValue(GrdDet.FocusedRowHandle, "CARAT").ToString().Trim().Equals(string.Empty) &&
            //                                        !GrdDet.GetRowCellValue(GrdDet.FocusedRowHandle, "SIEVE_NAME").ToString().Trim().Equals(string.Empty))
            //    {
            //        MainGrid.Refresh();
            //        GrdDet.SetRowCellValue(GrdDet.DataRowCount - 1, "ROUGH_NAME", GrdDet.GetRowCellValue(GrdDet.FocusedRowHandle, "ROUGH_NAME"));
            //        GrdDet.SetRowCellValue(GrdDet.DataRowCount - 1, "SIEVE_NAME", GrdDet.GetRowCellValue(GrdDet.FocusedRowHandle, "SIEVE_NAME"));
            //        GrdDet.SetRowCellValue(GrdDet.DataRowCount - 1, "SIEVE_CODE", GrdDet.GetRowCellValue(GrdDet.FocusedRowHandle, "SIEVE_CODE"));
            //    }
            //}
        }
    }
}