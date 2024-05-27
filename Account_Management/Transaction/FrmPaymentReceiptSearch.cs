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
    public partial class FrmPaymentReceiptSearch : DevExpress.XtraEditors.XtraForm
    {
        #region Declaration

        Validation Val = new Validation();
        public DataTable DTab = new DataTable();
        public DataTable DTab_Payment_Receipt_Data = new DataTable();
        PaymentReceipt objPaymentReceipt = new PaymentReceipt();
        FormEvents objBOFormEvents = new FormEvents();
        public FrmPaymentReceipt FrmPaymentReceipt = new FrmPaymentReceipt();
        //FrmSearch FrmSearch;
        FrmSearchNew FrmSearchNew;
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
            //this.Text = "Payment Receipt";
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
                objPaymentReceipt = new PaymentReceipt();
                DTab_Payment_Receipt_Data = objPaymentReceipt.PaymentReceipt_Search_GetData(Val.ToInt64(lblLedgerID.Text), Val.ToString(""));

                if (DTab_Payment_Receipt_Data.Rows.Count > 0)
                {
                    MainGrid.DataSource = DTab_Payment_Receipt_Data;
                    //GrdDet.FocusedColumn = GrdDet.Columns["method"];
                    //GrdDet.ShowEditor();
                }
                else
                {
                    MainGrid.DataSource = DTab;
                    //GrdDet.FocusedColumn = GrdDet.Columns["method"];
                    //GrdDet.ShowEditor();
                }

                RepMethod.Items.Add("Adjustment");
                RepMethod.Items.Add("New Ref.");

                //GrdDet.FocusedRowHandle = GrdDet.DataRowCount - 1;
                GrdDet.PostEditor();
                GrdDet.FocusedRowHandle = 1;
                GrdDet.FocusedColumn = GrdDet.Columns["method"];
                GrdDet.ShowEditor();

                //GrdDet.PostEditor();
                //GrdDet.FocusedColumn = GrdDet.Columns["method"];
                //GrdDet.ShowEditor();
                //RepMethod.AllowFocused = true;
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
            if (FormName == "FrmPaymentReceipt")
            {
                decimal Payment_Rec_Amount = Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue);
                if (Payment_Rec_Amount != Val.ToDecimal(lblAmount.Text))
                {
                    Global.Message("Total Amount Not Equal To Payment Receive Amount");
                    return;
                }
                DataTable DTab_Select = (DataTable)MainGrid.DataSource;
                for (int i = 0; i < DTab_Select.Rows.Count; i++)
                {
                    if (Val.ToString(DTab_Select.Rows[i]["method"]) == "Adjustment" && Val.ToString(DTab_Select.Rows[i]["ref_order_no"]) == "")
                    {
                        Global.Message("Please Select Refrence No.. Contact to Administrator");
                        return;
                    }
                }
                DialogResult result = MessageBox.Show("Do you want to save data?", "Confirmation", MessageBoxButtons.YesNoCancel);
                if (result != DialogResult.Yes)
                {
                    return;
                }

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
            try
            {
                string Method = Val.ToString(GrdDet.GetRowCellValue(GrdDet.FocusedRowHandle, "method"));

                if (GrdDet.FocusedColumn.FieldName.ToUpper() == "REF_ORDER_NO" && Method == "Adjustment")
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


                    DataTable dt = new DataTable();
                    DataTable DTab_Data = new DataTable();

                    DTab_Data = (DataTable)MainGrid.DataSource;
                    DTab_Data.AcceptChanges();
                    string strOrderNo = string.Empty;

                    foreach (DataRow item in DTab_Data.Rows)
                    {
                        if (Val.ToString(item["ref_order_no"]) != "")
                        {
                            if (strOrderNo == string.Empty)
                            {
                                strOrderNo += Val.ToString(item["ref_order_no"]);
                            }
                            else
                            {
                                strOrderNo += "," + Val.ToString(item["ref_order_no"]);
                            }
                        }
                    }


                    FrmSearchNew = new Search.FrmSearchNew();
                    FrmSearchNew.SearchText = e.KeyChar.ToString();
                    dt = objPaymentReceipt.Sale_Invoice_Search_GetData(Val.ToInt64(lblLedgerID.Text), strOrderNo);

                    FrmSearchNew.DTab = dt;
                    FrmSearchNew.SearchField = "order_no,invoice_id";

                    FrmSearchNew.ShowDialog();
                    e.Handled = true;
                    if (FrmSearchNew.DTab != null)
                    {
                        if (FrmSearchNew.DRow != null)
                        {
                            GrdDet.SetFocusedRowCellValue("ref_order_no", Val.ToString(FrmSearchNew.DRow["order_no"]));
                            GrdDet.SetFocusedRowCellValue("due_date", Val.ToString(FrmSearchNew.DRow["due_date"]));
                            GrdDet.SetFocusedRowCellValue("amount", Val.ToDecimal(0));

                            DataTable DTab = (DataTable)MainGrid.DataSource;
                            object sumObject;
                            sumObject = DTab.Compute("Sum(amount)", string.Empty);
                            decimal Total_Amt = Val.ToDecimal(sumObject);

                            if (Val.ToDecimal(lblAmount.Text) < Val.ToDecimal(FrmSearchNew.DRow["os_amount"]))
                            {
                                GrdDet.SetFocusedRowCellValue("amount", Val.ToDecimal(lblAmount.Text) - Total_Amt);
                            }
                            else
                            {
                                GrdDet.SetFocusedRowCellValue("amount", Val.ToString(FrmSearchNew.DRow["os_amount"]));
                            }
                            GrdDet.SetFocusedRowCellValue("invoice_id", Val.ToString(FrmSearchNew.DRow["invoice_id"]));
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
            if (((e.KeyCode == Keys.Enter && GrdDet.IsLastRow) && Val.ToString(GrdDet.GetRowCellValue(GrdDet.FocusedRowHandle, "method")) != "") || ((e.KeyCode == Keys.Tab && GrdDet.IsLastRow) && Val.ToString(GrdDet.GetRowCellValue(GrdDet.FocusedRowHandle, "method")) != ""))
            {
                int flag = 0;

                e.Handled = true;

                DataTable DTab = (DataTable)MainGrid.DataSource;
                object sumObject;
                sumObject = DTab.Compute("Sum(amount)", string.Empty);
                decimal Total_Amt = Val.ToDecimal(sumObject);

                DataRow dtRow = DTab.NewRow();
                GrdDet.SetRowCellValue(GrdDet.DataRowCount - 1, "sr_no", GrdDet.GetRowCellValue(GrdDet.FocusedRowHandle, "sr_no"));
                int sr_no = Val.ToInt32(GrdDet.GetRowCellValue(GrdDet.FocusedRowHandle, "sr_no"));
                dtRow["sr_no"] = sr_no + 1;
                decimal Rec_Amt = Val.ToDecimal(GrdDet.GetRowCellValue(GrdDet.FocusedRowHandle, "amount"));
                if (Total_Amt != Val.ToDecimal(lblAmount.Text))
                {
                    dtRow["amount"] = Val.ToDecimal(lblAmount.Text) - Total_Amt;
                    DTab.Rows.Add(dtRow);
                    flag = 1;
                }
                else
                {
                    dtRow["amount"] = 0;
                    DTab.Rows.Add(dtRow);
                    flag = 0;
                }
                //GrdDet.PostEditor();
                decimal Total_Amount = Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue);

                if (Total_Amount == Val.ToDecimal(lblAmount.Text))
                {
                    if (flag == 1)
                    {
                        GrdDet.FocusedRowHandle = GrdDet.DataRowCount - 1;
                        GrdDet.FocusedColumn = GrdDet.Columns["method"];
                        GrdDet.ShowEditor();
                    }
                    else
                    {
                        BtnSave.Focus();
                    }
                }
            }
        }

        private void RepDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (Global.Confirm("Are you sure delete selected row?", "Account Management", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                GrdDet.DeleteRow(GrdDet.GetRowHandle(GrdDet.FocusedRowHandle));
                DTab.AcceptChanges();
            }
        }
    }
}