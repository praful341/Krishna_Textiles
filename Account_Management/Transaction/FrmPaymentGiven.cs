﻿using Account_Management.Class;
using BLL;
using BLL.FunctionClasses.Account;
using BLL.FunctionClasses.Master;
using BLL.PropertyClasses.Master;
using BLL.PropertyClasses.Transaction;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Account_Management.Transaction
{
    public partial class FrmPaymentGiven : DevExpress.XtraEditors.XtraForm
    {
        BLL.FormPer ObjPer = new BLL.FormPer();
        BLL.BeginTranConnection Conn;
        BLL.FormEvents objBOFormEvents = new BLL.FormEvents();
        BLL.Validation Val = new BLL.Validation();
        public delegate void SetControlValueCallback(Control oControl, string propName, object propValue);

        Control _NextEnteredControl;
        private List<Control> _tabControls;

        PaymentGiven objPaymentGiven = new PaymentGiven();
        DataTable m_dtbCurrencyType = new DataTable();
        DataTable DtControlSettings = new DataTable();
        DataTable DtPaymentGiven = new DataTable();
        Int64 IntRes;
        int m_numForm_id = 0;
        public FrmPaymentGiven()
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
        private void AttachFormEvents()
        {
            objBOFormEvents.CurForm = this;
            objBOFormEvents.FormKeyPress = true;
            objBOFormEvents.FormKeyDown = true;
            objBOFormEvents.FormResize = true;
            objBOFormEvents.FormClosing = true;
            objBOFormEvents.ObjToDispose.Add(objPaymentGiven);
            objBOFormEvents.ObjToDispose.Add(Val);
            objBOFormEvents.ObjToDispose.Add(objBOFormEvents);
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            LueLedger.EditValue = null;
            lueBank.EditValue = null;
            LueCashBank.EditValue = null;
            txtRemark.Text = "";
            txtAmount.Text = "";
            CmbTransactionType.SelectedIndex = 0;
            DTPEntryDate.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
            DTPEntryDate.Properties.Mask.EditMask = "dd-MM-yyyy";
            DTPEntryDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            DTPEntryDate.Properties.CharacterCasing = CharacterCasing.Upper;
            DTPEntryDate.EditValue = DateTime.Now;

            objPaymentGiven = new PaymentGiven();
            txtVoucherNo.Text = objPaymentGiven.FindNewID().ToString();

            DTPEntryDate.Focus();
        }
        #region Validation

        private bool ValidateDetails()
        {
            bool blnFocus = false;
            List<ListError> lstError = new List<ListError>();
            try
            {
                if (LueLedger.ItemIndex < 0)
                {
                    lstError.Add(new ListError(12, "Ledger"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                        LueLedger.Focus();
                    }
                }
                if (LueCashBank.ItemIndex < 0)
                {
                    lstError.Add(new ListError(12, "Cash / Bank"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                        LueCashBank.Focus();
                    }
                }
                if (txtAmount.Text.Length == 0 || txtAmount.Text == "")
                {
                    lstError.Add(new ListError(5, "Amount"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                        txtAmount.Focus();
                    }
                }
                if (DTPEntryDate.Text == string.Empty)
                {
                    lstError.Add(new ListError(13, "Entry Date"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                        DTPEntryDate.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                lstError.Add(new ListError(ex));
            }
            return (!(BLL.General.ShowErrors(lstError)));
        }

        #endregion

        #region Events       
        private void lueBank_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmBankMaster frmBank = new FrmBankMaster();
                frmBank.ShowDialog();
                Global.LOOKUPBank(lueBank);
            }
        }
        #endregion

        #region Functions

        #endregion

        private void FrmIncomeEntry_Load(object sender, EventArgs e)
        {

        }
        #region Dynamic Tab Setting
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
            if (!((Control)sender).Name.ToString().Trim().Equals(string.Empty))
            {
                _NextEnteredControl = (Control)sender;
                if ((Control)sender is LookUpEdit)
                {
                    if (e.KeyChar == Convert.ToChar(Keys.Enter))
                    {
                        SendKeys.Send("{TAB}");
                    }
                }
                if ((Control)sender is CheckedComboBoxEdit)
                {
                    if (e.KeyChar == Convert.ToChar(Keys.Enter))
                    {
                        SendKeys.Send("{TAB}");
                    }
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
        #endregion
        private void CmbTransactionType_EditValueChanged(object sender, EventArgs e)
        {
        }
        private void LueLedger_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmLedgerMaster frmCnt = new FrmLedgerMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPLedger(LueLedger);
            }
        }
        private void txtAmount_Validated(object sender, EventArgs e)
        {
            //if (txtAmount.Text != "")
            //{
            //    if (!ValidateDetails())
            //    {
            //        return;
            //    }

            //    DtPaymentReceipt = new DataTable();
            //    DtPaymentReceipt.Columns.Add("sr_no", typeof(int));
            //    DtPaymentReceipt.Columns.Add("method", typeof(string));
            //    DtPaymentReceipt.Columns.Add("ref_order_no", typeof(string));
            //    DtPaymentReceipt.Columns.Add("amount", typeof(decimal));
            //    DtPaymentReceipt.Columns.Add("due_date", typeof(string));
            //    DtPaymentReceipt.Columns.Add("invoice_id", typeof(Int64));
            //    DtPaymentReceipt.Rows.Add(1, "", "", 0, "");

            //    FrmPaymentReceiptSearch FrmPaymentReceiptSearch = new FrmPaymentReceiptSearch();
            //    FrmPaymentReceiptSearch.FrmPaymentReceipt = this;
            //    FrmPaymentReceiptSearch.DTab = DtPaymentReceipt;
            //    FrmPaymentReceiptSearch.ShowForm(this, Val.ToInt64(LueLedger.EditValue), Val.ToString(LueLedger.Text), Val.ToDecimal(txtAmount.Text));
            //}
        }
        public void GetPaymentGivenData(DataTable Payment_Given_Data)
        {
            try
            {
                IntRes = 0;
                PaymentGiven_Property paymentGiven_Property = new PaymentGiven_Property();
                Int64 Union_ID = 0;
                Conn = new BeginTranConnection(true, false);

                for (int i = 0; i < Payment_Given_Data.Rows.Count; i++)
                {
                    if (Val.ToString(Payment_Given_Data.Rows[i]["method"]) != "")
                    {
                        paymentGiven_Property.payment_id = Val.ToInt64(Payment_Given_Data.Rows[i]["payment_id"]);
                        paymentGiven_Property.union_id = Val.ToInt64(Union_ID);
                        paymentGiven_Property.payment_date = Val.DBDate(DTPEntryDate.Text);
                        paymentGiven_Property.payment_type = Val.ToString(CmbTransactionType.Text);
                        paymentGiven_Property.sr_no = Val.ToInt32(Payment_Given_Data.Rows[i]["sr_no"]);
                        paymentGiven_Property.method = Val.ToString(Payment_Given_Data.Rows[i]["method"]);
                        paymentGiven_Property.purchase_id = Val.ToInt64(Payment_Given_Data.Rows[i]["purchase_id"]);
                        paymentGiven_Property.sale_return_id = Val.ToInt64(0);
                        paymentGiven_Property.reference = Val.ToString(Payment_Given_Data.Rows[i]["purchase_bill_no"]);
                        paymentGiven_Property.bank_id = Val.ToInt64(lueBank.EditValue);
                        paymentGiven_Property.ledger_id = Val.ToInt64(LueLedger.EditValue);
                        paymentGiven_Property.credit_amount = Val.ToDecimal(Payment_Given_Data.Rows[i]["amount"]);
                        paymentGiven_Property.debit_amount = Val.ToDecimal(Payment_Given_Data.Rows[i]["amount"]);
                        paymentGiven_Property.remarks = Val.ToString(txtRemark.Text);
                        paymentGiven_Property.form_id = m_numForm_id;
                        paymentGiven_Property.voucher_no = Val.ToInt64(txtVoucherNo.Text);

                        //Int64 Against_Ledger_Id_Cash = objPaymentReceipt.ISLadgerName_GetData("CASH BALANCE");
                        //Int64 Against_Ledger_Id_Bank = objPaymentReceipt.ISLadgerName_GetData("BANK BALANCE");

                        //if (Against_Ledger_Id_Cash == 0 || Against_Ledger_Id_Bank == 0)
                        //{
                        //    Global.Message("Cash Balance Or Bank Balance Leger Not Set ");
                        //    return;
                        //}

                        //if (Val.ToString(CmbTransactionType.EditValue) == "CASH")
                        //{
                        //    PaymentReceiptProperty.against_ledger_id = Val.ToInt64(Against_Ledger_Id_Cash);
                        //}
                        //else if (Val.ToString(CmbTransactionType.EditValue) == "BANK")
                        //{
                        //    PaymentReceiptProperty.against_ledger_id = Val.ToInt64(Against_Ledger_Id_Bank);
                        //}
                        paymentGiven_Property.against_ledger_id = Val.ToInt64(LueCashBank.EditValue);
                        paymentGiven_Property = objPaymentGiven.PaymentGiven_Save(paymentGiven_Property, DLL.GlobalDec.EnumTran.Continue, Conn);

                        Union_ID = paymentGiven_Property.union_id;
                    }
                }
                Conn.Inter1.Commit();

                if (IntRes == -1)
                {
                    Global.Confirm("Error In Payment Given");
                    DTPEntryDate.Focus();
                }
                else
                {
                    Global.Confirm("Data Save Successfully");
                    btnClear_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                Global.Message(ex.ToString());
            }
        }
        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (txtAmount.Text != "")
                {
                    if (!ValidateDetails())
                    {
                        return;
                    }
                    DtPaymentGiven = new DataTable();
                    DtPaymentGiven.Columns.Add("sr_no", typeof(int));
                    DtPaymentGiven.Columns.Add("method", typeof(string));
                    DtPaymentGiven.Columns.Add("purchase_bill_no", typeof(string));
                    DtPaymentGiven.Columns.Add("amount", typeof(decimal));
                    DtPaymentGiven.Columns.Add("purchase_id", typeof(Int64));
                    DtPaymentGiven.Columns.Add("due_date", typeof(string));
                    DtPaymentGiven.Rows.Add(1, "", "", 0, 0, "");

                    FrmPaymentGivenSearch FrmPaymentGivenSearch = new FrmPaymentGivenSearch();
                    FrmPaymentGivenSearch.FrmPaymentGiven = this;
                    FrmPaymentGivenSearch.DTab = DtPaymentGiven;
                    FrmPaymentGivenSearch.ShowForm(this, Val.ToInt64(LueLedger.EditValue), Val.ToString(LueLedger.Text), Val.ToDecimal(txtAmount.Text));
                }
            }
        }
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (LueLedger.ItemIndex < 0)
            {
                Global.Message("Please Select Ledger");
                LueLedger.Focus();
                return;
            }
            RepMethod.Items.Clear();
            RepMethod.Items.Add("Adjustment");
            RepMethod.Items.Add("New Ref.");

            DataTable DTab_Invoice_Data = objPaymentGiven.PaymentGiven_Search_GetData(Val.ToInt64(LueLedger.EditValue), Val.ToString("Invoice"));

            RepOrderNo.DataSource = DTab_Invoice_Data;
            RepOrderNo.ValueMember = "invoice_id";
            RepOrderNo.DisplayMember = "order_no";

            objPaymentGiven = new PaymentGiven();
            DataTable DTab_Payment_Given_Data = objPaymentGiven.PaymentGiven_Search_GetData(Val.ToInt64(LueLedger.EditValue), Val.ToString(""));

            if (DTab_Payment_Given_Data.Rows.Count > 0)
            {
                PnlSearchData.Visible = true;
                MainGrid.Visible = true;
                BtnUpdate.Visible = true;
                MainGrid.DataSource = DTab_Payment_Given_Data;

                GrdDet.PostEditor();
                GrdDet.FocusedRowHandle = GrdDet.DataRowCount;
                GrdDet.FocusedColumn = GrdDet.Columns["method"];
                RepMethod.AllowFocused = true;
            }
            else
            {
                Global.Message("Ledger New Ref. Data Not Found");
                MainGrid.DataSource = null;
                MainGrid.Visible = false;
                BtnUpdate.Visible = false;
                PnlSearchData.Visible = false;
            }
        }
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                IntRes = 0;
                PaymentGiven_Property PaymentGivenProperty = new PaymentGiven_Property();
                Conn = new BeginTranConnection(true, false);

                DataTable Payment_Given_Data = (DataTable)MainGrid.DataSource;

                for (int i = 0; i < Payment_Given_Data.Rows.Count; i++)
                {
                    if (Val.ToString(Payment_Given_Data.Rows[i]["method"]) != "" && Val.ToString(Payment_Given_Data.Rows[i]["invoice_id"]) != "")
                    {
                        PaymentGivenProperty.payment_id = Val.ToInt64(Payment_Given_Data.Rows[i]["payment_id"]);
                        PaymentGivenProperty.method = Val.ToString(Payment_Given_Data.Rows[i]["method"]);
                        PaymentGivenProperty.purchase_id = Val.ToInt64(Payment_Given_Data.Rows[i]["purchase_id"]);
                        IntRes = objPaymentGiven.Ref_PaymentGiven_Update(PaymentGivenProperty, DLL.GlobalDec.EnumTran.Continue, Conn);
                    }
                }
                Conn.Inter1.Commit();

                if (IntRes == -1)
                {
                    Global.Confirm("Error In Payment Given");
                    DTPEntryDate.Focus();
                }
                else
                {
                    Global.Confirm("Data Update Successfully");
                    MainGrid.DataSource = null;
                    MainGrid.Visible = false;
                    BtnUpdate.Visible = false;
                    btnClear_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                Global.Message(ex.ToString());
            }
        }

        private void FrmPaymentGiven_Load(object sender, EventArgs e)
        {
            Global.LOOKUPCashBankLedger(LueCashBank);
            Global.LOOKUPBank(lueBank);
            Global.LOOKUPLedger(LueLedger);
            DTPEntryDate.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
            DTPEntryDate.Properties.Mask.EditMask = "dd-MM-yyyy";
            DTPEntryDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            DTPEntryDate.Properties.CharacterCasing = CharacterCasing.Upper;
            DTPEntryDate.EditValue = DateTime.Now;
            btnClear_Click(btnClear, null);
        }
    }
}