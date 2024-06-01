using Account_Management.Class;
using BLL;
using BLL.FunctionClasses.Master;
using BLL.FunctionClasses.Transaction;
using BLL.PropertyClasses.Master;
using BLL.PropertyClasses.Transaction;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
        Int64 Union_ID = 0;
        string Form_Clear = string.Empty;
        Control _NextEnteredControl;
        private List<Control> _tabControls;
        DataTable DtControlSettings;
        DataTable DtPaymentGiven = new DataTable();

        #endregion

        #region Constructor
        public FrmJournalEntry()
        {
            InitializeComponent();

            _NextEnteredControl = new Control();
            _tabControls = new List<Control>();
            DtControlSettings = new DataTable();
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

            if (Global.HideFormControls(Val.ToInt(ObjPer.form_id), this) != "")
            {
                Global.Message("Select First User Setting...Please Contact to Administrator...");
                return;
            }

            ControlSettingDT(Val.ToInt(ObjPer.form_id), this);
            AddGotFocusListener(this);
            AddKeyPressListener(this);
            this.KeyPreview = true;

            TabControlsToList(this.Controls);
            _tabControls = _tabControls.OrderBy(x => x.TabIndex).ToList();

            this.Show();
        }

        private void AddGotFocusListener(Control ctrl)
        {
            foreach (Control c in ctrl.Controls)
            {
                c.GotFocus += new EventHandler(Control_GotFocus);
                if (c.Controls.Count > 0)
                {
                    AddGotFocusListener(c);
                }
            }
        }
        private void Control_GotFocus(object sender, EventArgs e)
        {
            if (!((Control)sender).Name.ToString().Trim().Equals(string.Empty))
            {
                _NextEnteredControl = (Control)sender;
                if ((Control)sender is LookUpEdit)
                {
                    ((LookUpEdit)(Control)sender).ShowPopup();
                }
            }
        }
        private void TabControlsToList(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control.TabStop)
                    _tabControls.Add(control);
                if (control.HasChildren)
                    TabControlsToList(control.Controls);
            }
        }
        private void AddKeyPressListener(Control ctrl)
        {
            foreach (Control c in ctrl.Controls)
            {
                c.KeyPress += new KeyPressEventHandler(Control_KeyPress);
                if (c.Controls.Count > 0)
                {
                    AddKeyPressListener(c);
                }
            }
        }
        private void Control_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        private void ControlSettingDT(int FormCode, Form pForm)
        {
            BLL.Validation Val = new BLL.Validation();
            Single_Setting ObjSingleSettings = new Single_Setting();
            Single_SettingProperty Property = new Single_SettingProperty();

            Property.role_id = Val.ToInt(BLL.GlobalDec.gEmployeeProperty.role_id);
            Property.form_id = Val.ToInt(FormCode);
            DataTable DtColSetting = ObjSingleSettings.GetData(Property);

            DataTable DtFilterColSetting = (from DataRow dr in DtColSetting.Rows
                                            where Val.ToBooleanToInt(dr["is_control"]) == 1
                                            && dr["column_type"].ToString() != "LABEL"
                                            select dr).CopyToDataTable();
            DevExpress.XtraLayout.LayoutControl l = new DevExpress.XtraLayout.LayoutControl();
            l.OptionsFocus.EnableAutoTabOrder = false;

            if (DtFilterColSetting.Rows.Count > 0)
            {
                DtControlSettings = DtFilterColSetting;
                foreach (Control item1 in pForm.Controls)
                {
                    ControllSettings(item1, DtFilterColSetting);
                }
            }
        }
        private static void ControllSettings(Control item2, DataTable DTab)
        {
            BLL.Validation Val = new BLL.Validation();

            //else
            {
                var VarControlSetting = (from DataRow dr in DTab.Rows
                                         where dr["column_name"].ToString() == item2.Name.ToString()
                                         select dr);

                if (VarControlSetting.Count() > 0)
                {
                    DataRow DRow = VarControlSetting.CopyToDataTable().Rows[0];
                    if (item2.Name.ToString() == Val.ToString(DRow["column_name"]))
                    {
                        if (!(item2 is TextEdit))
                        {
                            if (!(item2 is DateTimePicker))
                            {
                                if (!(item2 is DevExpress.XtraEditors.TextEdit))
                                {
                                    item2.Text = (Val.ToBooleanToInt(DRow["is_compulsory"]).Equals(0) ? Val.ToString(DRow["caption"]) : "* " + Val.ToString(DRow["caption"]));
                                }
                            }
                        }
                        if (Val.ToInt(DRow["tab_index"]) >= 0)
                        {
                            if (item2.CanSelect)
                                item2.TabStop = true;
                        }
                        else
                            item2.TabStop = false;
                        if (Val.ToBooleanToInt(DRow["is_visible"]).Equals(1))
                        {
                            item2.Visible = true;
                            item2.TabStop = true;
                        }
                        else
                        {
                            item2.Visible = false;
                            item2.TabStop = false;
                        }

                        item2.TabIndex = Val.ToInt(DRow["tab_index"]);
                        if (item2.TabIndex == 1)
                        {
                            item2.Select();
                            item2.Focus();
                        }
                        if (Val.ToBooleanToInt(DRow["is_editable"]).Equals(1))
                        {
                            item2.Enabled = true;
                        }
                        else
                        {
                            item2.Enabled = false;
                        }
                    }
                }
                else
                {
                    item2.TabStop = false;
                }
            }
            if (item2.Controls.Count > 0)
            {
                foreach (Control item1 in item2.Controls)
                {
                    ControllSettings(item1, DTab);
                }
            }
        }

        public void ShowForm_New(Int64 Union_ID)
        {
            ObjPer.FormName = this.Name.ToUpper();
            if (ObjPer.CheckPermission() == false)
            {
                Global.Message(BLL.GlobalDec.gStrPermissionViwMsg);
                return;
            }
            Val.frmGenSet(this);
            AttachFormEvents();

            Form_Clear = "Journal Entry";
            this.Show();

            DtJournalEntry = objJournalEntry.GetData(Union_ID);

            if (DtJournalEntry.Rows.Count > 0)
            {
                txtVoucherNo.Text = Val.ToInt64(DtJournalEntry.Rows[0]["voucher_no"]).ToString();
                dtpEntryDate.Text = Val.DBDate(DtJournalEntry.Rows[0]["transaction_date"].ToString());
                lblUnionID.Text = Val.ToInt64(DtJournalEntry.Rows[0]["union_id"]).ToString();

                MainGrid.DataSource = DtJournalEntry;
            }
            else
            {
                Global.Message("Data Are Not Found");
                return;
            }
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

                if (Form_Clear != "Journal Entry")
                {
                    btnClear_Click(btnClear, null);
                }
                else
                {
                    dtpEntryDate.Focus();
                }
                Form_Clear = "";
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
            DtJournalEntry.Columns.Add("payment_id", typeof(Int64));
            DtJournalEntry.Columns.Add("sr_no", typeof(int));
            DtJournalEntry.Columns.Add("dc", typeof(string));
            DtJournalEntry.Columns.Add("ledger_name", typeof(string));
            DtJournalEntry.Columns.Add("ledger_id", typeof(Int64));
            DtJournalEntry.Columns.Add("debit_amount", typeof(decimal));
            DtJournalEntry.Columns.Add("credit_amount", typeof(decimal));
            DtJournalEntry.Columns.Add("remarks", typeof(string));
            DtJournalEntry.Columns.Add("id", typeof(Int64));
            DtJournalEntry.Columns.Add("type", typeof(string));

            DtJournalEntry.Rows.Add(0, 1, "", "", 0, 0, 0, "");
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
            lblUnionID.Text = "0";

            objJournalEntry = new JournalEntry();
            txtVoucherNo.Text = objJournalEntry.FindNewID().ToString();
            MainGrid.DataSource = null;
            dtpEntryDate.Focus();
        }
        private void RepRemarks_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) && Val.ToString(GrdDet.GetRowCellValue(GrdDet.FocusedRowHandle, "dc")) != "" && Val.ToString(GrdDet.GetRowCellValue(GrdDet.FocusedRowHandle, "ledger_id")) != "")
            {
                DataRow dtRow = DtJournalEntry.NewRow();
                e.Handled = true;
                GrdDet.SetRowCellValue(GrdDet.DataRowCount - 1, "sr_no", GrdDet.GetRowCellValue(GrdDet.FocusedRowHandle, "sr_no"));
                int sr_no = Val.ToInt32(GrdDet.GetRowCellValue(GrdDet.FocusedRowHandle, "sr_no"));

                dtRow["sr_no"] = sr_no + 1;

                if (Val.ToString(GrdDet.GetRowCellValue(GrdDet.FocusedRowHandle, "dc")) == "D" || Val.ToString(GrdDet.GetRowCellValue(GrdDet.FocusedRowHandle, "dc")) == "C")
                {
                    DtPaymentGiven = new DataTable();
                    DtPaymentGiven.Columns.Add("sr_no", typeof(int));
                    DtPaymentGiven.Columns.Add("method", typeof(string));
                    DtPaymentGiven.Columns.Add("order_no", typeof(string));
                    DtPaymentGiven.Columns.Add("amount", typeof(decimal));
                    DtPaymentGiven.Columns.Add("payment_date", typeof(string));
                    DtPaymentGiven.Columns.Add("payment_id", typeof(Int64));
                    DtPaymentGiven.Columns.Add("id", typeof(Int32));
                    DtPaymentGiven.Columns.Add("type", typeof(string));
                    DtPaymentGiven.Rows.Add(1, "", "", 0, "", 0, 0, "");

                    FrmJVSearch FrmJVSearch = new FrmJVSearch();
                    FrmJVSearch.FrmJournalEntry = this;
                    FrmJVSearch.DTab = DtPaymentGiven;
                    FrmJVSearch.ShowForm(this, Val.ToString(GrdDet.GetRowCellValue(GrdDet.FocusedRowHandle, "dc")), Val.ToInt64(GrdDet.GetRowCellValue(GrdDet.FocusedRowHandle, "ledger_id")), Val.ToDecimal(GrdDet.GetRowCellValue(GrdDet.FocusedRowHandle, "debit_amount")), Val.ToDecimal(GrdDet.GetRowCellValue(GrdDet.FocusedRowHandle, "credit_amount")));
                }

                DtJournalEntry.Rows.Add(dtRow);
                GrdDet.PostEditor();
                GrdDet.FocusedRowHandle = GrdDet.DataRowCount - 1;
                GrdDet.FocusedColumn = GrdDet.Columns["dc"];
            }
        }
        public void GetPaymentGivenData(DataTable Payment_Given_Data)
        {
            try
            {
                PaymentGiven_Property paymentGiven_Property = new PaymentGiven_Property();

                if (Val.ToString(Payment_Given_Data.Rows[0]["type"]) == "Sale")
                {
                    GrdDet.SetRowCellValue(GrdDet.DataRowCount - 1, "debit_amount", Val.ToInt64(Payment_Given_Data.Rows[0]["amount"]).ToString());
                    GrdDet.SetRowCellValue(GrdDet.DataRowCount - 1, "id", Val.ToInt64(Payment_Given_Data.Rows[0]["id"]).ToString());
                    GrdDet.SetRowCellValue(GrdDet.DataRowCount - 1, "type", Val.ToString(Payment_Given_Data.Rows[0]["type"]).ToString());
                }
                else if (Val.ToString(Payment_Given_Data.Rows[0]["type"]) == "Purchase")
                {
                    GrdDet.SetRowCellValue(GrdDet.DataRowCount - 1, "credit_amount", Val.ToInt64(Payment_Given_Data.Rows[0]["amount"]).ToString());
                    GrdDet.SetRowCellValue(GrdDet.DataRowCount - 1, "id", Val.ToInt64(Payment_Given_Data.Rows[0]["id"]).ToString());
                    GrdDet.SetRowCellValue(GrdDet.DataRowCount - 1, "type", Val.ToString(Payment_Given_Data.Rows[0]["type"]).ToString());
                }
            }
            catch (Exception ex)
            {
                Global.Message(ex.ToString());
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
                    Int64 Against_Ledger_Id = 0;
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

                            if (Val.ToString(drw["type"]) == "Sale")
                            {
                                objJournalEntryProperty.invoice_id = Val.ToInt64(drw["id"]);
                            }
                            else if (Val.ToString(drw["type"]) == "Purchase")
                            {
                                objJournalEntryProperty.purchase_id = Val.ToInt64(drw["id"]);
                            }
                            else if (Val.ToString(drw["type"]) == "Sale Ret.")
                            {
                                objJournalEntryProperty.sale_return_id = Val.ToInt64(drw["id"]);
                            }
                            else if (Val.ToString(drw["type"]) == "Purchase Ret.")
                            {
                                objJournalEntryProperty.purchase_return_id = Val.ToInt64(drw["id"]);
                            }

                            if (lblUnionID.Text != "0")
                            {
                                objJournalEntryProperty.union_id = Val.ToInt64(lblUnionID.Text);
                            }
                            else
                            {
                                objJournalEntryProperty.union_id = Val.ToInt64(Union_ID);
                            }
                            objJournalEntryProperty.payment_id = Val.ToInt64(drw["payment_id"]);
                            objJournalEntryProperty.sr_no = Val.ToInt32(drw["sr_no"]);
                            objJournalEntryProperty.ledger_id = Val.ToInt64(drw["ledger_id"]);
                            objJournalEntryProperty.credit_amount = Val.ToDecimal(drw["credit_amount"]);
                            objJournalEntryProperty.debit_amount = Val.ToDecimal(drw["debit_amount"]);
                            objJournalEntryProperty.remarks = Val.ToString(drw["remarks"]);
                            objJournalEntryProperty.flag = Val.ToString(drw["dc"]);

                            if (objJournalEntryProperty.flag == "D")
                            {
                                Against_Ledger_Id = Val.ToInt64(drw["ledger_id"]);
                            }
                            else if (objJournalEntryProperty.flag == "C")
                            {
                                objJournalEntryProperty.against_ledger_id = Against_Ledger_Id;
                            }

                            objJournalEntryProperty = objJournalEntry.Save(objJournalEntryProperty, DLL.GlobalDec.EnumTran.Continue, Conn);
                            Union_ID = objJournalEntryProperty.union_id;
                        }
                    }
                    Conn.Inter1.Commit();
                }
                catch (Exception ex)
                {
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
        private void CalculateGridAmount(int rowindex)
        {
            try
            {
                string DC = Val.ToString(GrdDet.GetRowCellValue(GrdDet.FocusedRowHandle, "dc"));

                if (DC == "C")
                {
                    GrdDet.Columns["credit_amount"].OptionsColumn.ReadOnly = false;
                    GrdDet.Columns["credit_amount"].OptionsColumn.AllowFocus = true;
                    //GrdDet.Columns["credit_amount"].AppearanceCell.BackColor = System.Drawing.Color.Black;
                    GrdDet.Columns["debit_amount"].OptionsColumn.ReadOnly = true;
                    GrdDet.Columns["debit_amount"].OptionsColumn.AllowFocus = false;
                }
                else if (DC == "D")
                {
                    GrdDet.Columns["debit_amount"].OptionsColumn.ReadOnly = false;
                    GrdDet.Columns["debit_amount"].OptionsColumn.AllowFocus = true;
                    GrdDet.Columns["credit_amount"].OptionsColumn.ReadOnly = true;
                    GrdDet.Columns["credit_amount"].OptionsColumn.AllowFocus = false;
                }
            }
            catch (Exception ex)
            {
            }
        }
        private void RepDC_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    e.Handled = true;
            //    GrdDet.SetRowCellValue(GrdDet.DataRowCount - 1, "sr_no", GrdDet.GetRowCellValue(GrdDet.FocusedRowHandle, "sr_no"));
            //    string DC = Val.ToString(GrdDet.GetRowCellValue(GrdDet.FocusedRowHandle, "dc"));

            //    if (DC == "C")
            //    {
            //        GrdDet.Columns["credit_amount"].OptionsColumn.ReadOnly = true;
            //        GrdDet.Columns["credit_amount"].OptionsColumn.AllowFocus = false;
            //        GrdDet.Columns["debit_amount"].OptionsColumn.ReadOnly = false;
            //        GrdDet.Columns["debit_amount"].OptionsColumn.AllowFocus = true;
            //    }
            //    else if (DC == "D")
            //    {
            //        GrdDet.Columns["debit_amount"].OptionsColumn.ReadOnly = true;
            //        GrdDet.Columns["debit_amount"].OptionsColumn.AllowFocus = false;
            //        GrdDet.Columns["credit_amount"].OptionsColumn.ReadOnly = false;
            //        GrdDet.Columns["credit_amount"].OptionsColumn.AllowFocus = true;
            //    }
            //    GrdDet.FocusedColumn = GrdDet.Columns["ledger_id"];
            //}
        }
        private void GrdDet_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            CalculateGridAmount(GrdDet.FocusedRowHandle);
        }
        private void GrdDet_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            CalculateGridAmount(e.PrevFocusedRowHandle);
        }
        private void GrdDet_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            CalculateGridAmount(GrdDet.FocusedRowHandle);
        }
    }
}