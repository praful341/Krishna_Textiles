using Account_Management.Class;
using BLL;
using BLL.FunctionClasses.Account;
using BLL.FunctionClasses.Master;
using BLL.PropertyClasses.Master;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Account_Management.Transaction
{
    public partial class FrmSaleReturnPaymentGiven : DevExpress.XtraEditors.XtraForm
    {
        BLL.FormPer ObjPer = new BLL.FormPer();
        BLL.BeginTranConnection Conn;
        BLL.FormEvents objBOFormEvents = new BLL.FormEvents();
        BLL.Validation Val = new BLL.Validation();
        public delegate void SetControlValueCallback(Control oControl, string propName, object propValue);

        Control _NextEnteredControl;
        private List<Control> _tabControls;

        SaleReturnPaymentGiven objSaleReturnPaymentGiven = new SaleReturnPaymentGiven();
        DataTable m_dtbCurrencyType = new DataTable();
        DataTable DtControlSettings = new DataTable();
        DataTable DtPaymentGiven = new DataTable();
        Int64 IntRes;
        int m_numForm_id = 0;
        string Form_Clear = string.Empty;

        public FrmSaleReturnPaymentGiven()
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

        public void ShowForm_SaleReturnPaymentNew()
        {
            //ObjPer.FormName = this.Name.ToUpper();
            //if (ObjPer.CheckPermission() == false)
            //{
            //    Global.Message(BLL.GlobalDec.gStrPermissionViwMsg);
            //    return;
            //}
            Val.frmGenSet(this);
            AttachFormEvents();

            //if (Global.HideFormControls(Val.ToInt(ObjPer.form_id), this) != "")
            //{
            //    Global.Message("Select First User Setting...Please Contact to Administrator...");
            //    return;
            //}

            //ControlSettingDT(Val.ToInt(ObjPer.form_id), this);
            //AddGotFocusListener(this);
            //AddKeyPressListener(this);
            //this.KeyPreview = true;

            //TabControlsToList(this.Controls);
            //_tabControls = _tabControls.OrderBy(x => x.TabIndex).ToList();

            this.Show();
        }
        private void AttachFormEvents()
        {
            objBOFormEvents.CurForm = this;
            objBOFormEvents.FormKeyPress = true;
            objBOFormEvents.FormKeyDown = true;
            objBOFormEvents.FormResize = true;
            objBOFormEvents.FormClosing = true;
            objBOFormEvents.ObjToDispose.Add(objSaleReturnPaymentGiven);
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
            //lueBank.EditValue = null;
            LueCashBank.EditValue = null;
            txtRemark.Text = "";
            txtAmount.Text = "";
            //CmbTransactionType.SelectedIndex = 0;
            DTPEntryDate.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
            DTPEntryDate.Properties.Mask.EditMask = "dd-MM-yyyy";
            DTPEntryDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            DTPEntryDate.Properties.CharacterCasing = CharacterCasing.Upper;
            DTPEntryDate.EditValue = DateTime.Now;

            objSaleReturnPaymentGiven = new SaleReturnPaymentGiven();
            txtVoucherNo.Text = objSaleReturnPaymentGiven.FindNewID().ToString();

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
            //if (e.Button.Index == 1)
            //{
            //    FrmBankMaster frmBank = new FrmBankMaster();
            //    frmBank.ShowDialog();
            //    Global.LOOKUPBank(lueBank);
            //}
        }
        #endregion

        #region Functions

        #endregion

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
        //public void GetPaymentGivenData(string Entry_date, string Remark, Int64 Voucher_No, Int64 Cash_Bank, Int64 Ledger_ID, DataTable Payment_Given_Data)
        //{
        //    try
        //    {
        //        IntRes = 0;
        //        SaleReturnPaymentGiven_Property SaleReturnPaymentGiven_Property = new SaleReturnPaymentGiven_Property();
        //        Int64 Union_ID = 0;
        //        Conn = new BeginTranConnection(true, false);

        //        for (int i = 0; i < Payment_Given_Data.Rows.Count; i++)
        //        {
        //            if (Val.ToString(Payment_Given_Data.Rows[i]["method"]) != "")
        //            {
        //                SaleReturnPaymentGiven_Property.payment_id = Val.ToInt64(Payment_Given_Data.Rows[i]["payment_id"]);
        //                SaleReturnPaymentGiven_Property.union_id = Val.ToInt64(Union_ID);
        //                SaleReturnPaymentGiven_Property.payment_date = Val.DBDate(Entry_date);
        //                //SaleReturnPaymentGiven_Property.payment_type = Val.ToString(CmbTransactionType.Text);
        //                SaleReturnPaymentGiven_Property.sr_no = Val.ToInt32(Payment_Given_Data.Rows[i]["sr_no"]);
        //                SaleReturnPaymentGiven_Property.method = Val.ToString(Payment_Given_Data.Rows[i]["method"]);
        //                SaleReturnPaymentGiven_Property.purchase_id = Val.ToInt64(Payment_Given_Data.Rows[i]["purchase_id"]);
        //                SaleReturnPaymentGiven_Property.sale_return_id = Val.ToInt64(0);
        //                SaleReturnPaymentGiven_Property.reference = Val.ToString(Payment_Given_Data.Rows[i]["purchase_bill_no"]);
        //                //SaleReturnPaymentGiven_Property.bank_id = Val.ToInt64(lueBank.EditValue);
        //                SaleReturnPaymentGiven_Property.ledger_id = Val.ToInt64(Ledger_ID);
        //                SaleReturnPaymentGiven_Property.credit_amount = Val.ToDecimal(Payment_Given_Data.Rows[i]["amount"]);
        //                SaleReturnPaymentGiven_Property.debit_amount = Val.ToDecimal(Payment_Given_Data.Rows[i]["amount"]);
        //                SaleReturnPaymentGiven_Property.remarks = Val.ToString(Remark);
        //                SaleReturnPaymentGiven_Property.form_id = m_numForm_id;
        //                SaleReturnPaymentGiven_Property.voucher_no = Val.ToInt64(Voucher_No);

        //                SaleReturnPaymentGiven_Property.against_ledger_id = Val.ToInt64(Cash_Bank);
        //                SaleReturnPaymentGiven_Property = objSaleReturnPaymentGiven.PaymentGiven_Save(SaleReturnPaymentGiven_Property, DLL.GlobalDec.EnumTran.Continue, Conn);

        //                Union_ID = SaleReturnPaymentGiven_Property.union_id;
        //            }
        //        }

        //        Conn.Inter1.Commit();

        //        if (IntRes == -1)
        //        {
        //            Global.Confirm("Error In Payment Given");
        //            DTPEntryDate.Focus();
        //        }
        //        else
        //        {
        //            Global.Confirm("Data Save Successfully");
        //            btnClear_Click(null, null);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Global.Message(ex.ToString());
        //    }
        //}
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
                    DtPaymentGiven.Columns.Add("order_no", typeof(string));
                    DtPaymentGiven.Columns.Add("amount", typeof(decimal));
                    DtPaymentGiven.Columns.Add("purchase_id", typeof(Int64));
                    DtPaymentGiven.Columns.Add("payment_date", typeof(string));
                    DtPaymentGiven.Columns.Add("payment_id", typeof(Int64));
                    DtPaymentGiven.Rows.Add(1, "", "", 0, 0, "");

                    //FrmSaleReturnPaymentGivenSearch FrmSaleReturnPaymentGivenSearch = new FrmSaleReturnPaymentGivenSearch();
                    //FrmSaleReturnPaymentGivenSearch.FrmSaleReturnPaymentGiven = this;
                    //FrmSaleReturnPaymentGivenSearch.DTab = DtPaymentGiven;
                    //FrmSaleReturnPaymentGivenSearch.ShowForm(this, Val.DBDate(DTPEntryDate.Text), Val.ToString(txtRemark.Text), Val.ToInt64(txtVoucherNo.Text), Val.ToInt64(LueCashBank.Text), Val.ToInt64(LueLedger.EditValue), Val.ToString(LueLedger.Text), Val.ToDecimal(txtAmount.Text));
                }
            }
        }
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            //if (LueLedger.ItemIndex < 0)
            //{
            //    Global.Message("Please Select Ledger");
            //    LueLedger.Focus();
            //    return;
            //}
            //RepMethod.Items.Clear();
            //RepMethod.Items.Add("Adjustment");
            //RepMethod.Items.Add("New Ref.");

            //DataTable DTab_Invoice_Data = objSaleReturnPaymentGiven.PaymentGiven_Search_GetData(Val.ToInt64(LueLedger.EditValue), Val.ToString("Invoice"));

            //RepOrderNo.DataSource = DTab_Invoice_Data;
            //RepOrderNo.ValueMember = "invoice_id";
            //RepOrderNo.DisplayMember = "order_no";

            //objSaleReturnPaymentGiven = new SaleReturnPaymentGiven();
            //DataTable DTab_Payment_Given_Data = objSaleReturnPaymentGiven.PaymentGiven_Search_GetData(Val.ToInt64(LueLedger.EditValue), Val.ToString(""));

            //if (DTab_Payment_Given_Data.Rows.Count > 0)
            //{
            //    PnlSearchData.Visible = true;
            //    MainGrid.Visible = true;
            //    BtnUpdate.Visible = true;
            //    MainGrid.DataSource = DTab_Payment_Given_Data;

            //    GrdDet.PostEditor();
            //    GrdDet.FocusedRowHandle = GrdDet.DataRowCount;
            //    GrdDet.FocusedColumn = GrdDet.Columns["method"];
            //    RepMethod.AllowFocused = true;
            //}
            //else
            //{
            //    Global.Message("Ledger New Ref. Data Not Found");
            //    MainGrid.DataSource = null;
            //    MainGrid.Visible = false;
            //    BtnUpdate.Visible = false;
            //    PnlSearchData.Visible = false;
            //}
        }
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    IntRes = 0;
            //    SaleReturnPaymentGiven_Property SaleReturnPaymentGivenProperty = new SaleReturnPaymentGiven_Property();
            //    Conn = new BeginTranConnection(true, false);

            //    DataTable Payment_Given_Data = (DataTable)MainGrid.DataSource;

            //    for (int i = 0; i < Payment_Given_Data.Rows.Count; i++)
            //    {
            //        if (Val.ToString(Payment_Given_Data.Rows[i]["method"]) != "" && Val.ToString(Payment_Given_Data.Rows[i]["invoice_id"]) != "")
            //        {
            //            SaleReturnPaymentGivenProperty.payment_id = Val.ToInt64(Payment_Given_Data.Rows[i]["payment_id"]);
            //            SaleReturnPaymentGivenProperty.method = Val.ToString(Payment_Given_Data.Rows[i]["method"]);
            //            SaleReturnPaymentGivenProperty.purchase_id = Val.ToInt64(Payment_Given_Data.Rows[i]["purchase_id"]);
            //            IntRes = objSaleReturnPaymentGiven.Ref_PaymentGiven_Update(SaleReturnPaymentGivenProperty, DLL.GlobalDec.EnumTran.Continue, Conn);
            //        }
            //    }
            //    Conn.Inter1.Commit();

            //    if (IntRes == -1)
            //    {
            //        Global.Confirm("Error In Payment Given");
            //        DTPEntryDate.Focus();
            //    }
            //    else
            //    {
            //        Global.Confirm("Data Update Successfully");
            //        MainGrid.DataSource = null;
            //        MainGrid.Visible = false;
            //        BtnUpdate.Visible = false;
            //        btnClear_Click(null, null);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Global.Message(ex.ToString());
            //}
        }

        private void FrmPaymentGiven_Load(object sender, EventArgs e)
        {
            Global.LOOKUPCashBankLedger(LueCashBank);
            //Global.LOOKUPBank(lueBank);
            Global.LOOKUPLedger(LueLedger);
            DTPEntryDate.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
            DTPEntryDate.Properties.Mask.EditMask = "dd-MM-yyyy";
            DTPEntryDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            DTPEntryDate.Properties.CharacterCasing = CharacterCasing.Upper;
            DTPEntryDate.EditValue = DateTime.Now;
            btnClear_Click(btnClear, null);
        }

        private void FrmSaleReturnPaymentGiven_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.F1)
            {
                FrmLedgerMaster frmCnt = new FrmLedgerMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPLedger(LueLedger);
            }
        }
    }
}
