using Account_Management.Class;
using BLL;
using BLL.FunctionClasses.Transaction;
using BLL.PropertyClasses.Transaction;
using System;
using System.Data;
using System.Windows.Forms;
using static Account_Management.Class.Global;

namespace Account_Management.Transaction
{
    public partial class FrmJournalEntry : DevExpress.XtraEditors.XtraForm
    {
        #region Declaration

        BLL.BeginTranConnection Conn;
        BLL.FormPer ObjPer = new BLL.FormPer();
        Validation Val = new Validation();
        public DataTable DTab = new DataTable();
        JournalEntry objJournalEntry = new JournalEntry();
        FormEvents objBOFormEvents = new FormEvents();
        DataTable DtJournalEntry = new DataTable();
        int m_numForm_id = 0;
        int IntRes;
        Int64 Union_ID = 0;

        #endregion

        #region Constructor
        public FrmJournalEntry()
        {
            InitializeComponent();
            IntRes = 0;
        }
        public void ShowForm()
        {
            ObjPer.FormName = this.Name.ToUpper();
            m_numForm_id = ObjPer.form_id;
            if (ObjPer.CheckPermission() == false)
            {
                Global.Message(BLL.GlobalDec.gStrPermissionViwMsg);
                return;
            }
            Val.frmGenSet(this);
            AttachFormEvents();
            this.Show();
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
        private void FrmJournalEntry_Load(object sender, EventArgs e)
        {
            try
            {
                GrdDet.PostEditor();
                GrdDet.FocusedRowHandle = GrdDet.DataRowCount - 1;
                GrdDet.FocusedColumn = GrdDet.Columns["dc"];
                RepDC.Items.Add("D");
                RepDC.Items.Add("C");
                Global.LOOKUPLedgerRep(LueLedger);

                btnClear_Click(null, null);
            }
            catch (Exception ex)
            {
                Global.ErrorMessage(ex.Message);
            }
        }
        private void FrmJournalEntry_KeyDown(object sender, KeyEventArgs e)
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
            ObjPer.SetFormPer();
            btnSave.Enabled = false;

            decimal Credit_Amount = Val.ToDecimal(ClmCreditAmt.SummaryItem.SummaryValue);
            decimal Debit_Amount = Val.ToDecimal(ClmDebitAmt.SummaryItem.SummaryValue);

            if (Credit_Amount != Debit_Amount)
            {
                Global.Message("Credit And Debit Amount Not Match...Please Verify.");
                btnSave.Enabled = true;
                return;
            }

            DialogResult result = MessageBox.Show("Do you want to save data?", "Confirmation", MessageBoxButtons.YesNoCancel);
            if (result != DialogResult.Yes)
            {
                btnSave.Enabled = true;
                return;
            }
            DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = true;
            backgroundWorker_JournalEntry.RunWorkerAsync();
            btnSave.Enabled = true;
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
        private void btnAdd_Click(object sender, EventArgs e)
        {
            DtJournalEntry = new DataTable();
            DtJournalEntry.Columns.Add("sr_no", typeof(int));
            DtJournalEntry.Columns.Add("dc", typeof(string));
            DtJournalEntry.Columns.Add("ledger_name", typeof(string));
            DtJournalEntry.Columns.Add("ledger_id", typeof(Int64));
            DtJournalEntry.Columns.Add("debit_amount", typeof(decimal));
            DtJournalEntry.Columns.Add("credit_amount", typeof(decimal));
            DtJournalEntry.Columns.Add("remarks", typeof(string));
            DtJournalEntry.Rows.Add(1, "", "", 0, 0, 0, "");

            MainGrid.DataSource = DtJournalEntry;

            GrdDet.FocusedColumn = GrdDet.Columns["dc"];
            GrdDet.ShowEditor();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            dtpEntryDate.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
            dtpEntryDate.Properties.Mask.EditMask = "dd-MM-yyyy";
            dtpEntryDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            dtpEntryDate.Properties.CharacterCasing = CharacterCasing.Upper;
            dtpEntryDate.EditValue = DateTime.Now;
            btnAdd.Text = "&Add";
            Union_ID = 0;

            objJournalEntry = new JournalEntry();
            txtVoucherNo.Text = objJournalEntry.FindNewID().ToString();
            MainGrid.DataSource = null;
            dtpEntryDate.Focus();
        }
        private void RepRemarks_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && GrdDet.IsLastRow)
            {
                DataRow dtRow = DtJournalEntry.NewRow();
                e.Handled = true;
                GrdDet.SetRowCellValue(GrdDet.DataRowCount - 1, "sr_no", GrdDet.GetRowCellValue(GrdDet.FocusedRowHandle, "sr_no"));
                int sr_no = Val.ToInt32(GrdDet.GetRowCellValue(GrdDet.FocusedRowHandle, "sr_no"));

                dtRow["sr_no"] = sr_no + 1;

                DtJournalEntry.Rows.Add(dtRow);
                GrdDet.PostEditor();
                GrdDet.FocusedRowHandle = GrdDet.DataRowCount - 1;
                GrdDet.FocusedColumn = GrdDet.Columns["dc"];
            }
        }

        private void backgroundWorker_JournalEntry_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.Default;
                Conn = new BeginTranConnection(true, false);

                Journal_EntryProperty objJournalEntryProperty = new Journal_EntryProperty();
                JournalEntry objJournalEntry = new JournalEntry();
                try
                {
                    IntRes = 0;

                    foreach (DataRow drw in DtJournalEntry.Rows)
                    {
                        if (Val.ToInt64(drw["ledger_id"]) != 0)
                        {
                            objJournalEntryProperty = new Journal_EntryProperty();
                            objJournalEntryProperty.voucher_no = Val.ToInt32(txtVoucherNo.Text);
                            objJournalEntryProperty.company_id = Val.ToInt(GlobalDec.gEmployeeProperty.company_id);
                            objJournalEntryProperty.branch_id = Val.ToInt(GlobalDec.gEmployeeProperty.branch_id);
                            objJournalEntryProperty.location_id = Val.ToInt(GlobalDec.gEmployeeProperty.location_id);
                            objJournalEntryProperty.department_id = Val.ToInt(GlobalDec.gEmployeeProperty.department_id);
                            objJournalEntryProperty.Journal_date = Val.DBDate(dtpEntryDate.Text);
                            objJournalEntryProperty.form_id = m_numForm_id;

                            objJournalEntryProperty.union_id = Val.ToInt64(Union_ID);
                            objJournalEntryProperty.sr_no = Val.ToInt32(drw["sr_no"]);
                            objJournalEntryProperty.ledger_id = Val.ToInt64(drw["ledger_id"]);
                            objJournalEntryProperty.credit_amount = Val.ToDecimal(drw["credit_amount"]);
                            objJournalEntryProperty.debit_amount = Val.ToDecimal(drw["debit_amount"]);
                            objJournalEntryProperty.remarks = Val.ToString(drw["remarks"]);
                            objJournalEntryProperty.flag = Val.ToInt(drw["dc"]);

                            objJournalEntryProperty = objJournalEntry.Save(objJournalEntryProperty, DLL.GlobalDec.EnumTran.Continue, Conn);
                            Union_ID = objJournalEntryProperty.union_id;
                        }
                    }
                    Conn.Inter1.Commit();
                }
                catch (Exception ex)
                {
                    IntRes = -1;
                    Conn.Inter1.Rollback();
                    Conn = null;
                    General.ShowErrors(ex.ToString());
                    return;
                }
                finally
                {
                    objJournalEntryProperty = null;
                }
            }
            catch (Exception ex)
            {
                IntRes = -1;
                Conn.Inter1.Rollback();
                Conn = null;
                Global.Message(ex.ToString());
                if (ex.InnerException != null)
                {
                    Global.Message(ex.InnerException.ToString());
                }
            }
        }
        private void backgroundWorker_JournalEntry_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (Union_ID != 0)
                {
                    Global.Confirm("Journal Entry Data Save Successfully");
                    btnClear_Click(null, null);
                }
                else
                {
                    Global.Confirm("Error In Journal Entry");
                    txtVoucherNo.Focus();
                }
            }
            catch (Exception ex)
            {
                Global.Message(ex.ToString());
                Global.Message(ex.InnerException.ToString());
            }
        }

        private void RepDC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                GrdDet.SetRowCellValue(GrdDet.DataRowCount - 1, "sr_no", GrdDet.GetRowCellValue(GrdDet.FocusedRowHandle, "sr_no"));
                string DC = Val.ToString(GrdDet.GetRowCellValue(GrdDet.FocusedRowHandle, "dc"));

                if (DC == "C")
                {
                    GrdDet.Columns["credit_amount"].OptionsColumn.ReadOnly = true;
                    GrdDet.Columns["credit_amount"].OptionsColumn.AllowFocus = false;
                    GrdDet.Columns["debit_amount"].OptionsColumn.ReadOnly = false;
                    GrdDet.Columns["debit_amount"].OptionsColumn.AllowFocus = true;
                }
                else if (DC == "D")
                {
                    GrdDet.Columns["debit_amount"].OptionsColumn.ReadOnly = true;
                    GrdDet.Columns["debit_amount"].OptionsColumn.AllowFocus = false;
                    GrdDet.Columns["credit_amount"].OptionsColumn.ReadOnly = false;
                    GrdDet.Columns["credit_amount"].OptionsColumn.AllowFocus = true;
                }
                GrdDet.FocusedColumn = GrdDet.Columns["ledger_id"];
            }
        }
    }
}