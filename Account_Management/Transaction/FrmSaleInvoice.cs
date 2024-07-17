using Account_Management.Class;
using Account_Management.Master;
using Account_Management.Report;
using BLL;
using BLL.FunctionClasses.Master;
using BLL.FunctionClasses.Transaction;
using BLL.FunctionClasses.Utility;
using BLL.PropertyClasses.Master;
using BLL.PropertyClasses.Transaction;
using DevExpress.XtraEditors;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using static Account_Management.Class.Global;


namespace Account_Management.Transaction
{
    public partial class FrmSaleInvoice : DevExpress.XtraEditors.XtraForm
    {
        #region Data Member
        BLL.BeginTranConnection Conn;
        BLL.FormEvents objBOFormEvents;
        BLL.FormPer ObjPer;
        BLL.Validation Val;

        Control _NextEnteredControl;
        private List<Control> _tabControls;
        public delegate void SetControlValueCallback(Control oControl, string propName, object propValue);

        SaleInvoice objSaleInvoice = new SaleInvoice();
        UserAuthentication objUserAuthentication = new UserAuthentication();
        //AssortMaster objAssort = new AssortMaster();
        //SieveMaster objSieve = new SieveMaster();
        //RateMaster objRate = new RateMaster();

        DataTable DtControlSettings = new DataTable();
        DataTable m_dtbSaleDetails = new DataTable();
        DataTable m_dtbDetails = new DataTable();
        DataSet m_dtbVoucher_JangedDetail = new DataSet();
        DataTable m_dtbBarcode;

        int m_invoice_detail_id;
        int m_srno;
        int m_update_srno;
        int m_numForm_id;
        int IntRes;
        decimal m_numSummSaleDetAmount;
        decimal m_numSummPurchaseDetAmount;
        decimal m_numTotalPcs;
        bool m_blnadd;
        bool m_blnsave;
        bool m_blncheckevents;
        bool m_IsUpdate;
        string Form_Clear = string.Empty;
        DataTable m_dtbParty = new DataTable();
        DataTable m_dtbPurchaseFirm = new DataTable();

        #endregion

        #region Constructor
        public FrmSaleInvoice()
        {
            InitializeComponent();

            objBOFormEvents = new BLL.FormEvents();
            ObjPer = new BLL.FormPer();
            Val = new BLL.Validation();

            _NextEnteredControl = new Control();
            _tabControls = new List<Control>();

            objSaleInvoice = new SaleInvoice();
            objUserAuthentication = new UserAuthentication();

            DtControlSettings = new DataTable();
            m_dtbDetails = new DataTable();

            m_invoice_detail_id = 0;
            m_srno = 0;
            m_update_srno = 0;
            m_numForm_id = 0;
            IntRes = 0;
            m_blnadd = new bool();
            m_blnsave = new bool();
            m_blncheckevents = new bool();
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

            // for Dynamic Setting By Praful On 01022020

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

            // End for Dynamic Setting By Praful On 01022020

            this.Show();
        }

        public void ShowForm_New(Int64 Invoice_ID)
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

            // for Dynamic Setting By Praful On 01022020

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

            // End for Dynamic Setting By Praful On 01022020

            Form_Clear = "Sale Invoice";

            this.Show();

            objSaleInvoice = new SaleInvoice();
            DataTable DTab_Sale_Invocie = objSaleInvoice.Sale_Invocie_Popup_GetData(Val.ToInt64(Invoice_ID));

            if (DTab_Sale_Invocie.Rows.Count > 0)
            {
                lblMode.Text = "Edit Mode";
                lblMode.Tag = Val.ToInt64(DTab_Sale_Invocie.Rows[0]["invoice_id"]);

                m_dtbSaleDetails = objSaleInvoice.GetDataDetails(Val.ToInt(lblMode.Tag));
                grdSaleDetails.DataSource = m_dtbSaleDetails;

                dtpInvoiceDate.Text = Val.DBDate(DTab_Sale_Invocie.Rows[0]["invoice_date"].ToString());
                txtOrderNo.Text = Val.ToString(DTab_Sale_Invocie.Rows[0]["order_no"]);
                lueGSTRate.EditValue = Val.ToInt64(DTab_Sale_Invocie.Rows[0]["gst_id"]);
                lueParty.EditValue = Val.ToInt64(DTab_Sale_Invocie.Rows[0]["ledger_id"]);
                LueSaleType.Text = Val.ToString(DTab_Sale_Invocie.Rows[0]["sale_type"]);
                LueEmployee.EditValue = Val.ToInt64(DTab_Sale_Invocie.Rows[0]["employee_id"]);
                luePurchaseFirm.EditValue = Val.ToInt64(DTab_Sale_Invocie.Rows[0]["firm_id"]);
                txtRemark.Text = Val.ToString(DTab_Sale_Invocie.Rows[0]["remarks"]);
                txtWeight.Text = Val.ToString(DTab_Sale_Invocie.Rows[0]["weight"]);
                txtPinCode.Text = Val.ToString(DTab_Sale_Invocie.Rows[0]["pin_code"]);
                txtRoundOff.Text = Val.ToString(DTab_Sale_Invocie.Rows[0]["round_of_amount"]);
                txtDiscountPer.Text = Val.ToString(DTab_Sale_Invocie.Rows[0]["discount_per"]);
                txtDiscountAmount.Text = Val.ToString(DTab_Sale_Invocie.Rows[0]["discount_amount"]);
                txtCGSTPer.Text = Val.ToString(DTab_Sale_Invocie.Rows[0]["cgst_per"]);
                txtCGSTAmount.Text = Val.ToString(DTab_Sale_Invocie.Rows[0]["cgst_amount"]);
                txtSGSTPer.Text = Val.ToString(DTab_Sale_Invocie.Rows[0]["sgst_per"]);
                txtSGSTAmount.Text = Val.ToString(DTab_Sale_Invocie.Rows[0]["sgst_amount"]);
                txtIGSTPer.Text = Val.ToString(DTab_Sale_Invocie.Rows[0]["igst_per"]);
                txtIGSTAmount.Text = Val.ToString(DTab_Sale_Invocie.Rows[0]["igst_amount"]);

                txtShippingCharge.Text = Val.ToString(DTab_Sale_Invocie.Rows[0]["shipping_amount"]);
                txtShippingAddress.Text = Val.ToString(DTab_Sale_Invocie.Rows[0]["shipping_address"]);

                txtNetAmount.Text = Val.ToString(DTab_Sale_Invocie.Rows[0]["net_amount"]);
                txtTermDays.Text = Val.ToString(DTab_Sale_Invocie.Rows[0]["term_days"]);
                DTPDueDate.Text = Val.ToString(DTab_Sale_Invocie.Rows[0]["due_date"]);

                ttlbSaleInvoice.SelectedTabPage = tblSaledetail;
                txtWeight.Focus();
                txtOrderNo.Enabled = false;
                m_IsUpdate = true;
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
        private void AttachFormEvents()
        {
            objBOFormEvents.CurForm = this;
            objBOFormEvents.FormKeyPress = true;
            objBOFormEvents.FormKeyDown = true;
            objBOFormEvents.FormResize = true;
            objBOFormEvents.FormClosing = true;
            objBOFormEvents.ObjToDispose.Add(objSaleInvoice);
            objBOFormEvents.ObjToDispose.Add(Val);
            objBOFormEvents.ObjToDispose.Add(objBOFormEvents);

        }

        #endregion

        #region Events
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (AddInGrid())
            {
                lueItem.Focus();
                lueItem.ShowPopup();
                lueItem.EditValue = DBNull.Value;
                LueColor.EditValue = DBNull.Value;
                LueSize.EditValue = DBNull.Value;
                LueUnit.EditValue = DBNull.Value;
                txtPcs.Text = string.Empty;
                txtSaleRate.Text = string.Empty;
                txtSaleAmount.Text = string.Empty;
                txtPurchaseRate.Text = string.Empty;
                txtPurchaseAmount.Text = string.Empty;
                m_blncheckevents = false;
                txtDiscountPer_EditValueChanged(null, null);
                m_blncheckevents = true;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            ObjPer.SetFormPer();

            if (lblMode.Text == "Add Mode")
            {
                if (ObjPer.AllowInsert == false)
                {
                    Global.Message(BLL.GlobalDec.gStrPermissionInsUpdMsg);
                    return;
                }
            }
            else if (lblMode.Text == "Edit Mode")
            {
                if (ObjPer.AllowUpdate == false)
                {
                    Global.Message(BLL.GlobalDec.gStrPermissionInsUpdMsg);
                    return;
                }
            }

            List<ListError> lstError = new List<ListError>();
            Dictionary<Control, string> rtnCtrls = new Dictionary<Control, string>();
            rtnCtrls = Global.CheckCompulsoryControls(Val.ToInt(ObjPer.form_id), this);
            if (rtnCtrls.Count > 0)
            {
                foreach (KeyValuePair<Control, string> entry in rtnCtrls)
                {
                    if (entry.Key is DevExpress.XtraEditors.LookUpEdit || entry.Key is DevExpress.XtraEditors.DateEdit)
                    {
                        lstError.Add(new ListError(13, entry.Value));
                    }
                    else if (entry.Key is DevExpress.XtraEditors.TextEdit)
                    {
                        lstError.Add(new ListError(12, entry.Value));
                    }
                }
                rtnCtrls.First().Key.Focus();
                BLL.General.ShowErrors(lstError);
                Cursor.Current = Cursors.Arrow;
                return;
            }

            btnSave.Enabled = false;

            m_blnsave = true;
            m_blnadd = false;
            if (!ValidateDetails())
            {
                m_blnsave = false;
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
            panelProgress.Visible = true;
            backgroundWorker_SaleInvoice.RunWorkerAsync();

            btnSave.Enabled = true;
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!PopulateDetails())
                return;
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            ObjPer.SetFormPer();
            if (ObjPer.AllowDelete == false)
            {
                Global.Message(BLL.GlobalDec.gStrPermissionDelMsg);
                return;
            }
            btnDelete.Enabled = false;

            if (Val.ToInt(lblMode.Tag) == 0)
            {
                Global.Message("Deleted Data Not Found..");
                btnDelete.Enabled = true;
                return;
            }

            DialogResult result = MessageBox.Show("Do you want to Delete data?", "Confirmation", MessageBoxButtons.YesNoCancel);
            if (result != DialogResult.Yes)
            {
                btnDelete.Enabled = true;
                return;
            }

            DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = true;
            panelProgress.Visible = true;
            backgroundWorker_SaleInvoiceDelete.RunWorkerAsync();

            btnDelete.Enabled = true;
        }
        private void txtDiscountPer_EditValueChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    if (!m_blncheckevents)
            //    {
            //        decimal Dis_amount = Math.Round(Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue) * Val.ToDecimal(txtDiscountPer.Text) / 100, 0);
            //        txtDiscountAmount.Text = Dis_amount.ToString();
            //        decimal Net_Amount = Math.Round((Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue) + Val.ToDecimal(txtCGSTAmount.Text) + Val.ToDecimal(txtSGSTAmount.Text) + Val.ToDecimal(txtIGSTAmount.Text) - Val.ToDecimal(txtDiscountAmount.Text)) + Val.ToDecimal(txtRoundOff.Text), 2);
            //        txtNetAmount.Text = Net_Amount.ToString();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    General.ShowErrors(ex.ToString());
            //    return;
            //}
        }
        private void txtShippingCharge_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (Val.ToDecimal(clmRSSaleAmount.SummaryItem.SummaryValue) != 0)
                {
                    decimal Shipping_Charge = Math.Round((Val.ToDecimal(clmRSSaleAmount.SummaryItem.SummaryValue) + Val.ToDecimal(txtCGSTAmount.Text) + Val.ToDecimal(txtSGSTAmount.Text) + Val.ToDecimal(txtShippingCharge.Text) + Val.ToDecimal(txtIGSTAmount.Text)) - (Val.ToDecimal(txtDiscountAmount.Text)) + Val.ToDecimal(txtRoundOff.Text), 2);
                    txtNetAmount.Text = Shipping_Charge.ToString();
                }
            }
            catch (Exception ex)
            {
                General.ShowErrors(ex.ToString());
                return;
            }
        }
        private void txtCGSTPer_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                decimal GrossAmount = Val.ToDecimal(clmRSSaleAmount.SummaryItem.SummaryValue);
                decimal DiscountAmount = Val.ToDecimal(txtDiscountAmount.Text);

                decimal CGST_amount = Math.Round(Val.ToDecimal(GrossAmount - DiscountAmount) * Val.ToDecimal(txtCGSTPer.Text) / 100, 2);
                txtCGSTAmount.Text = CGST_amount.ToString();

                decimal Net_Amount = Math.Round((Val.ToDecimal(GrossAmount) + Val.ToDecimal(txtCGSTAmount.Text) + Val.ToDecimal(txtSGSTAmount.Text) + Val.ToDecimal(txtIGSTAmount.Text) + Val.ToDecimal(txtShippingCharge.Text) - Val.ToDecimal(txtDiscountAmount.Text)) + Val.ToDecimal(txtRoundOff.Text), 2);
                txtNetAmount.Text = Net_Amount.ToString();
            }
            catch (Exception ex)
            {
                General.ShowErrors(ex.ToString());
                return;
            }
        }
        private void txtSGSTPer_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                decimal GrossAmount = Val.ToDecimal(clmRSSaleAmount.SummaryItem.SummaryValue);
                decimal DiscountAmount = Val.ToDecimal(txtDiscountAmount.Text);

                decimal SGST_amount = Math.Round(Val.ToDecimal(GrossAmount - DiscountAmount) * Val.ToDecimal(txtSGSTPer.Text) / 100, 2);
                txtSGSTAmount.Text = SGST_amount.ToString();
                decimal Net_Amount = Math.Round((Val.ToDecimal(GrossAmount) + Val.ToDecimal(txtCGSTAmount.Text) + Val.ToDecimal(txtSGSTAmount.Text) + Val.ToDecimal(txtIGSTAmount.Text) + Val.ToDecimal(txtShippingCharge.Text) - Val.ToDecimal(txtDiscountAmount.Text)) + Val.ToDecimal(txtRoundOff.Text), 2);
                txtNetAmount.Text = Net_Amount.ToString();
            }
            catch (Exception ex)
            {
                General.ShowErrors(ex.ToString());
                return;
            }
        }
        private void txtIGSTPer_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                decimal GrossAmount = Val.ToDecimal(clmRSSaleAmount.SummaryItem.SummaryValue);
                decimal DiscountAmount = Val.ToDecimal(txtDiscountAmount.Text);

                decimal IGST_amount = Math.Round(Val.ToDecimal(GrossAmount - DiscountAmount) * Val.ToDecimal(txtIGSTPer.Text) / 100, 2);
                txtIGSTAmount.Text = IGST_amount.ToString();
                decimal Net_Amount = Math.Round((Val.ToDecimal(GrossAmount) + Val.ToDecimal(txtCGSTAmount.Text) + Val.ToDecimal(txtSGSTAmount.Text) + Val.ToDecimal(txtIGSTAmount.Text) + Val.ToDecimal(txtShippingCharge.Text) - Val.ToDecimal(txtDiscountAmount.Text)) + Val.ToDecimal(txtRoundOff.Text), 2);
                txtNetAmount.Text = Net_Amount.ToString();
            }
            catch (Exception ex)
            {
                General.ShowErrors(ex.ToString());
                return;
            }
        }
        private void txtCGSTPer_KeyUp(object sender, KeyEventArgs e)
        {
            txtCGSTPer.Select();
        }
        private void txtDiscountPer_KeyDown(object sender, KeyEventArgs e)
        {
            m_blncheckevents = false;
        }
        private void txtDiscountAmt_KeyDown(object sender, KeyEventArgs e)
        {
            m_blncheckevents = false;
        }
        private void txtBrokeragePer_KeyDown(object sender, KeyEventArgs e)
        {
            m_blncheckevents = false;
        }
        private void txtBrokerageAmt_KeyDown(object sender, KeyEventArgs e)
        {

            m_blncheckevents = false;
        }
        private void txtInterestPer_KeyDown(object sender, KeyEventArgs e)
        {
            m_blncheckevents = false;
        }
        private void txtInterestAmt_KeyDown(object sender, KeyEventArgs e)
        {
            m_blncheckevents = false;
        }
        private void panelControl4_Paint(object sender, PaintEventArgs e)
        {
            //Pen pen = new Pen(Color.FromArgb(255, 191, 219, 255), 2);
            //e.Graphics.DrawLine(pen, 0, 65, 1500, 65);
        }

        #region "Grid Events" 

        #endregion

        #endregion

        #region Functions
        private bool LoadDefaults()
        {
            bool blnReturn = true;
            try
            {
                Global.LOOKUPGSTRate(lueGSTRate);
                Global.LOOKUPEmployee(LueEmployee);
                Global.LOOKUPCashBankWithoutLedger(lueParty);
                Global.LOOKUPItem(lueItem);
                Global.LOOKUPColor(LueColor);
                Global.LOOKUPSize(LueSize);
                Global.LOOKUPUnit(LueUnit);
                Global.LOOKUPFirm(luePurchaseFirm);
                Global.LOOKUPCashBankWithoutLedger(lueJangedLedger);

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

                dtpInvoiceDate.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
                dtpInvoiceDate.Properties.Mask.EditMask = "dd-MM-yyyy";
                dtpInvoiceDate.Properties.Mask.UseMaskAsDisplayFormat = true;
                dtpInvoiceDate.Properties.CharacterCasing = CharacterCasing.Upper;
                dtpInvoiceDate.EditValue = DateTime.Now;

                DataTable DTab_CashType = new DataTable();

                DTab_CashType.Columns.Add("cash_type");

                if (GlobalDec.gEmployeeProperty.role_name == "B2B")
                {
                    DTab_CashType.Rows.Add("B2B");
                    LueSaleType.Properties.DataSource = DTab_CashType;
                    LueSaleType.Properties.ValueMember = "cash_type";
                    LueSaleType.Properties.DisplayMember = "cash_type";
                    //B2B SALE

                    m_dtbParty = (((DataTable)lueParty.Properties.DataSource).Copy());
                    m_dtbParty = m_dtbParty.Select("ledger_name='B2B SALE'").CopyToDataTable();

                    m_dtbPurchaseFirm = (((DataTable)luePurchaseFirm.Properties.DataSource).Copy());
                    m_dtbPurchaseFirm = m_dtbPurchaseFirm.Select("firm_name='SAURASHTRA SAREES'").CopyToDataTable();
                }
                else if (GlobalDec.gEmployeeProperty.role_name == "B2C")
                {
                    DTab_CashType.Rows.Add("B2C");
                    LueSaleType.Properties.DataSource = DTab_CashType;
                    LueSaleType.Properties.ValueMember = "cash_type";
                    LueSaleType.Properties.DisplayMember = "cash_type";
                }
                else
                {
                    DTab_CashType.Rows.Add("B2C");
                    DTab_CashType.Rows.Add("B2B");
                    LueSaleType.Properties.DataSource = DTab_CashType;
                    LueSaleType.Properties.ValueMember = "cash_type";
                    LueSaleType.Properties.DisplayMember = "cash_type";
                }

                if (Form_Clear != "Sale Invoice")
                {
                    btnClear_Click(null, null);
                }
                else
                {
                    LueEmployee.Focus();
                }
                Form_Clear = "";
                btnSearch_Click(null, null);
            }
            catch (Exception ex)
            {
                BLL.General.ShowErrors(ex);
                blnReturn = false;
            }
            finally
            {
                //objAssort = null;
                //objSieve = null;
            }

            return blnReturn;
        }
        private bool AddInGrid()
        {
            bool blnReturn = true;

            try
            {
                m_blnadd = true;
                m_blnsave = false;

                if (!ValidateDetails())
                {
                    m_blnadd = false;
                    blnReturn = false;
                    return blnReturn;
                }

                //objJangedEntry = new JangedEntry();
                //DataTable p_dtbDetail = new DataTable();

                ////p_dtbDetail = objSaleInvoice.GetCheckPriceList(m_numCurrency_id, Val.ToInt(GlobalDec.gEmployeeProperty.rate_type_id));
                //p_dtbDetail = objJangedEntry.GetCheckPriceList(Val.ToInt(GlobalDec.gEmployeeProperty.currency_id), Val.ToInt(GlobalDec.gEmployeeProperty.rate_type_id));

                //if (p_dtbDetail.Rows.Count <= 0)
                //{
                //    Global.Message("Selected currency type price not found in master please check", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    blnReturn = false;
                //    return blnReturn;
                //}

                //decimal numStockCarat = 0;
                if (btnAdd.Text == "&Add")
                {
                    //DataTable m_dtbStockCarat = new DataTable();
                    objSaleInvoice = new SaleInvoice();
                    //m_dtbStockCarat = objSaleInvoice.GetStockCarat(GlobalDec.gEmployeeProperty.company_id, GlobalDec.gEmployeeProperty.branch_id, GlobalDec.gEmployeeProperty.location_id, GlobalDec.gEmployeeProperty.department_id, Val.ToInt(lueAssortName.EditValue), Val.ToInt(lueSieveName.EditValue));                    
                    //if (m_dtbStockCarat.Rows.Count > 0)
                    //{
                    //    numStockCarat = Val.ToDecimal(m_dtbStockCarat.Rows[0]["stock_carat"]);
                    //}

                    DataRow[] dr = m_dtbSaleDetails.Select("item_id = " + Val.ToInt(lueItem.EditValue) + " AND color_id = " + Val.ToInt(LueColor.EditValue) + " AND size_id = " + Val.ToInt(LueSize.EditValue) + " AND unit_id = " + Val.ToInt(LueUnit.EditValue));

                    if (dr.Count() == 1)
                    {
                        Global.Message("Record already exists in grid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lueItem.Focus();
                        blnReturn = false;
                        return blnReturn;
                    }
                    DataRow drwNew = m_dtbSaleDetails.NewRow();
                    decimal numRate = Val.ToDecimal(txtSaleRate.Text);
                    decimal numAmount = Val.ToDecimal(txtSaleAmount.Text);
                    decimal numPcs = Val.ToDecimal(txtPcs.Text);

                    drwNew["invoice_id"] = Val.ToInt(0);
                    drwNew["invoice_detail_id"] = Val.ToInt(0);

                    drwNew["color_id"] = Val.ToInt(LueColor.EditValue);
                    drwNew["color_name"] = Val.ToString(LueColor.Text);

                    drwNew["item_id"] = Val.ToInt(lueItem.EditValue);
                    drwNew["item_name"] = Val.ToString(lueItem.Text);

                    drwNew["size_id"] = Val.ToInt(LueSize.EditValue);
                    drwNew["size_name"] = Val.ToString(LueSize.Text);

                    drwNew["unit_id"] = Val.ToInt(LueUnit.EditValue);
                    drwNew["unit_name"] = Val.ToString(LueUnit.Text);

                    drwNew["pcs"] = numPcs;
                    drwNew["sale_rate"] = Val.ToDecimal(txtSaleRate.Text);
                    drwNew["sale_amount"] = Math.Round(Val.ToDecimal(txtPcs.Text) * Val.ToDecimal(txtSaleRate.Text), 2);
                    drwNew["purchase_rate"] = Val.ToDecimal(txtPurchaseRate.Text);
                    drwNew["purchase_amount"] = Math.Round(Val.ToDecimal(txtPcs.Text) * Val.ToDecimal(txtPurchaseRate.Text), 2);
                    drwNew["old_pcs"] = Val.ToDecimal(0);
                    drwNew["flag"] = Val.ToInt(0);
                    m_srno = m_srno + 1;
                    drwNew["sr_no"] = Val.ToInt(m_srno);

                    m_dtbSaleDetails.Rows.Add(drwNew);

                    dgvSaleDetails.MoveLast();

                    if (Val.ToDecimal(txtDiscountAmount.Text) > 0)
                    {
                        decimal CGST_amount = Math.Round((Val.ToDecimal(clmRSSaleAmount.SummaryItem.SummaryValue) - Val.ToDecimal(txtDiscountAmount.Text)) * Val.ToDecimal(txtCGSTPer.Text) / 100, 2);
                        txtCGSTAmount.Text = CGST_amount.ToString();
                        decimal SGST_amount = Math.Round((Val.ToDecimal(clmRSSaleAmount.SummaryItem.SummaryValue) - Val.ToDecimal(txtDiscountAmount.Text)) * Val.ToDecimal(txtSGSTPer.Text) / 100, 2);
                        txtSGSTAmount.Text = SGST_amount.ToString();
                        decimal IGST_amount = Math.Round((Val.ToDecimal(clmRSSaleAmount.SummaryItem.SummaryValue) - Val.ToDecimal(txtDiscountAmount.Text)) * Val.ToDecimal(txtIGSTPer.Text) / 100, 2);
                        txtIGSTAmount.Text = IGST_amount.ToString();
                    }
                    else
                    {
                        decimal CGST_amount = Math.Round(Val.ToDecimal(clmRSSaleAmount.SummaryItem.SummaryValue) * Val.ToDecimal(txtCGSTPer.Text) / 100, 2);
                        txtCGSTAmount.Text = CGST_amount.ToString();
                        decimal SGST_amount = Math.Round(Val.ToDecimal(clmRSSaleAmount.SummaryItem.SummaryValue) * Val.ToDecimal(txtSGSTPer.Text) / 100, 2);
                        txtSGSTAmount.Text = SGST_amount.ToString();
                        decimal IGST_amount = Math.Round(Val.ToDecimal(clmRSSaleAmount.SummaryItem.SummaryValue) * Val.ToDecimal(txtIGSTPer.Text) / 100, 2);
                        txtIGSTAmount.Text = IGST_amount.ToString();
                    }

                    //decimal CGST_amount = Math.Round(Val.ToDecimal(clmRSSaleAmount.SummaryItem.SummaryValue) * Val.ToDecimal(txtCGSTPer.Text) / 100, 2);
                    //txtCGSTAmount.Text = CGST_amount.ToString();
                    //decimal SGST_amount = Math.Round(Val.ToDecimal(clmRSSaleAmount.SummaryItem.SummaryValue) * Val.ToDecimal(txtSGSTPer.Text) / 100, 2);
                    //txtSGSTAmount.Text = SGST_amount.ToString();
                    //decimal IGST_amount = Math.Round(Val.ToDecimal(clmRSSaleAmount.SummaryItem.SummaryValue) * Val.ToDecimal(txtIGSTPer.Text) / 100, 2);
                    //txtIGSTAmount.Text = IGST_amount.ToString();

                    decimal Net_Amount = Math.Round((Val.ToDecimal(clmRSSaleAmount.SummaryItem.SummaryValue) + Val.ToDecimal(txtCGSTAmount.Text) + Val.ToDecimal(txtSGSTAmount.Text) + Val.ToDecimal(txtIGSTAmount.Text) + Val.ToDecimal(txtShippingCharge.Text) - Val.ToDecimal(txtDiscountAmount.Text)) + Val.ToDecimal(txtRoundOff.Text), 2);
                    txtNetAmount.Text = Net_Amount.ToString();

                    DialogResult result = MessageBox.Show("Do you want to Add data?", "Confirmation", MessageBoxButtons.YesNoCancel);
                    if (result != DialogResult.Yes)
                    {
                        m_blnadd = false;
                        blnReturn = false;
                        txtDiscountAmount.Focus();
                        return blnReturn;
                    }
                }
                else if (btnAdd.Text == "&Update")
                {
                    if (!m_IsUpdate)
                    {
                        Global.Message("You can't update this record", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        blnReturn = false;
                        return blnReturn;
                    }

                    objSaleInvoice = new SaleInvoice();

                    if (m_dtbSaleDetails.Select("item_id ='" + Val.ToInt(lueItem.EditValue) + "' AND color_id ='" + Val.ToInt(LueColor.EditValue) + "' AND size_id ='" + Val.ToInt(LueSize.EditValue) + "' AND unit_id ='" + Val.ToInt(LueUnit.EditValue) + "'").Length > 0)
                    {
                        for (int i = 0; i < m_dtbSaleDetails.Rows.Count; i++)
                        {
                            if (m_dtbSaleDetails.Select("invoice_detail_id ='" + m_invoice_detail_id + "' AND sr_no = '" + m_update_srno + "'").Length > 0)
                            {
                                if (m_dtbSaleDetails.Rows[m_update_srno - 1]["invoice_detail_id"].ToString() == m_invoice_detail_id.ToString())
                                {
                                    m_dtbSaleDetails.Rows[m_update_srno - 1]["pcs"] = Val.ToDecimal(txtPcs.Text);
                                    m_dtbSaleDetails.Rows[m_update_srno - 1]["sale_rate"] = Val.ToDecimal(txtSaleRate.Text);
                                    m_dtbSaleDetails.Rows[m_update_srno - 1]["purchase_rate"] = Val.ToDecimal(txtPurchaseRate.Text);
                                    m_dtbSaleDetails.Rows[m_update_srno - 1]["flag"] = 1;
                                    m_dtbSaleDetails.Rows[m_update_srno - 1]["sale_amount"] = Math.Round(Val.ToDecimal(txtPcs.Text) * Val.ToDecimal(txtSaleRate.Text), 3);
                                    m_dtbSaleDetails.Rows[m_update_srno - 1]["purchase_amount"] = Math.Round(Val.ToDecimal(txtPcs.Text) * Val.ToDecimal(txtPurchaseRate.Text), 3);

                                    m_dtbSaleDetails.Rows[m_update_srno - 1]["item_id"] = Val.ToInt(lueItem.EditValue);
                                    m_dtbSaleDetails.Rows[m_update_srno - 1]["item_name"] = Val.ToString(lueItem.Text);

                                    m_dtbSaleDetails.Rows[m_update_srno - 1]["color_id"] = Val.ToInt(LueColor.EditValue);
                                    m_dtbSaleDetails.Rows[m_update_srno - 1]["color_name"] = Val.ToString(LueColor.Text);

                                    m_dtbSaleDetails.Rows[m_update_srno - 1]["size_id"] = Val.ToInt(LueSize.EditValue);
                                    m_dtbSaleDetails.Rows[m_update_srno - 1]["size_name"] = Val.ToString(LueSize.Text);

                                    m_dtbSaleDetails.Rows[m_update_srno - 1]["unit_id"] = Val.ToInt(LueUnit.EditValue);
                                    m_dtbSaleDetails.Rows[m_update_srno - 1]["unit_name"] = Val.ToString(LueUnit.Text);

                                    break;
                                }
                            }
                        }
                        btnAdd.Text = "&Add";
                    }
                    else
                    {
                        for (int i = 0; i < m_dtbSaleDetails.Rows.Count; i++)
                        {
                            if (m_dtbSaleDetails.Select("invoice_detail_id ='" + m_invoice_detail_id + "' AND sr_no = '" + m_update_srno + "'").Length > 0)
                            {
                                if (m_dtbSaleDetails.Rows[m_update_srno - 1]["invoice_detail_id"].ToString() == m_invoice_detail_id.ToString())
                                {
                                    m_dtbSaleDetails.Rows[m_update_srno - 1]["pcs"] = Val.ToDecimal(txtPcs.Text);
                                    m_dtbSaleDetails.Rows[m_update_srno - 1]["sale_rate"] = Val.ToDecimal(txtSaleRate.Text);
                                    m_dtbSaleDetails.Rows[m_update_srno - 1]["purchase_rate"] = Val.ToDecimal(txtPurchaseRate.Text);
                                    m_dtbSaleDetails.Rows[m_update_srno - 1]["flag"] = 1;
                                    m_dtbSaleDetails.Rows[m_update_srno - 1]["item_id"] = Val.ToInt(lueItem.EditValue);
                                    m_dtbSaleDetails.Rows[m_update_srno - 1]["color_id"] = Val.ToInt(LueColor.EditValue);
                                    m_dtbSaleDetails.Rows[m_update_srno - 1]["size_id"] = Val.ToInt(LueSize.EditValue);
                                    m_dtbSaleDetails.Rows[m_update_srno - 1]["unit_id"] = Val.ToInt(LueUnit.EditValue);
                                    m_dtbSaleDetails.Rows[m_update_srno - 1]["item_name"] = Val.ToString(lueItem.Text);
                                    m_dtbSaleDetails.Rows[m_update_srno - 1]["color_name"] = Val.ToString(LueColor.Text);
                                    m_dtbSaleDetails.Rows[m_update_srno - 1]["size_name"] = Val.ToString(LueSize.Text);
                                    m_dtbSaleDetails.Rows[m_update_srno - 1]["unit_name"] = Val.ToString(LueUnit.Text);

                                    m_dtbSaleDetails.Rows[m_update_srno - 1]["sale_amount"] = Math.Round(Val.ToDecimal(txtPcs.Text) * Val.ToDecimal(txtSaleRate.Text), 3);
                                    m_dtbSaleDetails.Rows[m_update_srno - 1]["purchase_amount"] = Math.Round(Val.ToDecimal(txtPcs.Text) * Val.ToDecimal(txtPurchaseRate.Text), 3);
                                }
                            }
                        }
                        btnAdd.Text = "&Add";
                    }
                    dgvSaleDetails.MoveLast();
                    m_IsUpdate = false;

                    if (Val.ToDecimal(txtDiscountAmount.Text) > 0)
                    {
                        decimal CGST_amount = Math.Round((Val.ToDecimal(clmRSSaleAmount.SummaryItem.SummaryValue) - Val.ToDecimal(txtDiscountAmount.Text)) * Val.ToDecimal(txtCGSTPer.Text) / 100, 2);
                        txtCGSTAmount.Text = CGST_amount.ToString();
                        decimal SGST_amount = Math.Round((Val.ToDecimal(clmRSSaleAmount.SummaryItem.SummaryValue) - Val.ToDecimal(txtDiscountAmount.Text)) * Val.ToDecimal(txtSGSTPer.Text) / 100, 2);
                        txtSGSTAmount.Text = SGST_amount.ToString();
                        decimal IGST_amount = Math.Round((Val.ToDecimal(clmRSSaleAmount.SummaryItem.SummaryValue) - Val.ToDecimal(txtDiscountAmount.Text)) * Val.ToDecimal(txtIGSTPer.Text) / 100, 2);
                        txtIGSTAmount.Text = IGST_amount.ToString();
                    }
                    else
                    {
                        decimal CGST_amount = Math.Round(Val.ToDecimal(clmRSSaleAmount.SummaryItem.SummaryValue) * Val.ToDecimal(txtCGSTPer.Text) / 100, 2);
                        txtCGSTAmount.Text = CGST_amount.ToString();
                        decimal SGST_amount = Math.Round(Val.ToDecimal(clmRSSaleAmount.SummaryItem.SummaryValue) * Val.ToDecimal(txtSGSTPer.Text) / 100, 2);
                        txtSGSTAmount.Text = SGST_amount.ToString();
                        decimal IGST_amount = Math.Round(Val.ToDecimal(clmRSSaleAmount.SummaryItem.SummaryValue) * Val.ToDecimal(txtIGSTPer.Text) / 100, 2);
                        txtIGSTAmount.Text = IGST_amount.ToString();
                    }

                    decimal Net_Amount = Math.Round((Val.ToDecimal(clmRSSaleAmount.SummaryItem.SummaryValue) + Val.ToDecimal(txtCGSTAmount.Text) + Val.ToDecimal(txtSGSTAmount.Text) + Val.ToDecimal(txtIGSTAmount.Text) + Val.ToDecimal(txtShippingCharge.Text) - Val.ToDecimal(txtDiscountAmount.Text)) + Val.ToDecimal(txtRoundOff.Text), 2);
                    txtNetAmount.Text = Net_Amount.ToString();
                }
            }
            catch (Exception ex)
            {
                BLL.General.ShowErrors(ex);
                blnReturn = false;
            }
            return blnReturn;
        }
        private bool ValidateDetails()
        {
            bool blnFocus = false;
            List<ListError> lstError = new List<ListError>();

            try
            {
                if (m_blnsave)
                {
                    if (m_dtbSaleDetails.Rows.Count == 0)
                    {
                        lstError.Add(new ListError(22, "Record"));
                        if (!blnFocus)
                        {
                            blnFocus = true;
                        }
                    }
                    if (dgvSaleDetails == null)
                    {
                        lstError.Add(new ListError(22, "Record"));
                        if (!blnFocus)
                        {
                            blnFocus = true;
                        }
                    }
                    //var result = DateTime.Compare(Convert.ToDateTime(dtpInvoiceDate.Text), DateTime.Today);
                    //if (result > 0)
                    //{
                    //    lstError.Add(new ListError(5, " Invoice Date Not Be Greater Than Today Date"));
                    //    if (!blnFocus)
                    //    {
                    //        blnFocus = true;
                    //        dtpInvoiceDate.Focus();
                    //    }
                    //}

                    if (GlobalDec.gEmployeeProperty.role_name != "B2C")
                    {
                        if (LueEmployee.Text == "")
                        {
                            lstError.Add(new ListError(13, "Employee"));
                            if (!blnFocus)
                            {
                                blnFocus = true;
                                LueEmployee.Focus();
                            }
                        }
                    }
                }

                if (m_blnadd)
                {
                    if (lueItem.Text == "")
                    {
                        lstError.Add(new ListError(13, "Item"));
                        if (!blnFocus)
                        {
                            blnFocus = true;
                            lueItem.Focus();
                        }
                    }
                    if (LueColor.Text == "")
                    {
                        lstError.Add(new ListError(13, "Color"));
                        if (!blnFocus)
                        {
                            blnFocus = true;
                            LueColor.Focus();
                        }
                    }
                    if (LueSize.Text == "")
                    {
                        lstError.Add(new ListError(13, "Size"));
                        if (!blnFocus)
                        {
                            blnFocus = true;
                            LueSize.Focus();
                        }
                    }
                    if (LueUnit.Text == "")
                    {
                        lstError.Add(new ListError(13, "Unit"));
                        if (!blnFocus)
                        {
                            blnFocus = true;
                            LueUnit.Focus();
                        }
                    }
                    if (Val.ToDouble(txtPcs.Text) == 0)
                    {
                        lstError.Add(new ListError(12, "Pcs"));
                        if (!blnFocus)
                        {
                            blnFocus = true;
                            txtPcs.Focus();
                        }
                    }
                    if (Val.ToDouble(txtSaleRate.Text) == 0)
                    {
                        lstError.Add(new ListError(12, "Sale Rate"));
                        if (!blnFocus)
                        {
                            blnFocus = true;
                            txtSaleRate.Focus();
                        }
                    }
                    if (Val.ToDouble(txtSaleAmount.Text) == 0)
                    {
                        lstError.Add(new ListError(12, "Sale Amount"));
                        if (!blnFocus)
                        {
                            blnFocus = true;
                            txtSaleAmount.Focus();
                        }
                    }
                    if (GlobalDec.gEmployeeProperty.role_name != "B2C")
                    {
                        if (LueEmployee.Text == "")
                        {
                            lstError.Add(new ListError(13, "Employee"));
                            if (!blnFocus)
                            {
                                blnFocus = true;
                                LueEmployee.Focus();
                            }
                        }
                    }
                    //if (Val.ToDouble(txtPurchaseRate.Text) == 0)
                    //{
                    //    lstError.Add(new ListError(12, "Purchase Rate"));
                    //    if (!blnFocus)
                    //    {
                    //        blnFocus = true;
                    //        txtPurchaseRate.Focus();
                    //    }
                    //}
                    //if (Val.ToDouble(txtPurchaseAmount.Text) == 0)
                    //{
                    //    lstError.Add(new ListError(12, "Purchase Amount"));
                    //    if (!blnFocus)
                    //    {
                    //        blnFocus = true;
                    //        txtPurchaseAmount.Focus();
                    //    }
                    //}
                    if (lueGSTRate.Text == "")
                    {
                        lstError.Add(new ListError(13, "GST Rate"));
                        if (!blnFocus)
                        {
                            blnFocus = true;
                            lueGSTRate.Focus();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lstError.Add(new ListError(ex));
            }
            return (!(BLL.General.ShowErrors(lstError)));
        }
        private bool ClearDetails()
        {
            bool blnReturn = true;
            try
            {
                if (!GenerateJangedEntryDetails())
                {
                    blnReturn = false;
                    return blnReturn;
                }
                lblMode.Tag = null;
                lueGSTRate.EditValue = System.DBNull.Value;
                lueParty.EditValue = System.DBNull.Value;

                txtOrderNo.Text = string.Empty;
                LueSaleType.EditValue = System.DBNull.Value;
                LueEmployee.EditValue = System.DBNull.Value;
                lueItem.EditValue = System.DBNull.Value;
                LueColor.EditValue = System.DBNull.Value;
                LueSize.EditValue = System.DBNull.Value;
                LueUnit.EditValue = System.DBNull.Value;
                txtSearchOrderNo.Text = string.Empty;
                lueJangedLedger.EditValue = System.DBNull.Value;
                dtpInvoiceDate.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
                dtpInvoiceDate.Properties.Mask.EditMask = "dd-MM-yyyy";
                dtpInvoiceDate.Properties.Mask.UseMaskAsDisplayFormat = true;
                dtpInvoiceDate.Properties.CharacterCasing = CharacterCasing.Upper;
                dtpInvoiceDate.EditValue = DateTime.Now;
                luePurchaseFirm.EditValue = System.DBNull.Value;
                txtPcs.Text = string.Empty;
                txtSaleRate.Text = string.Empty;
                txtSaleAmount.Text = string.Empty;
                txtPurchaseRate.Text = string.Empty;
                txtPurchaseAmount.Text = string.Empty;
                txtDiscountPer.Text = string.Empty;
                txtDiscountAmount.Text = string.Empty;
                txtRoundOff.Text = string.Empty;
                txtNetAmount.Text = string.Empty;
                txtShippingCharge.Text = string.Empty;
                txtCGSTPer.Text = string.Empty;
                txtCGSTAmount.Text = string.Empty;
                txtSGSTPer.Text = string.Empty;
                txtSGSTAmount.Text = string.Empty;
                txtIGSTPer.Text = string.Empty;
                txtIGSTAmount.Text = string.Empty;
                txtRemark.Text = string.Empty;
                txtWeight.Text = string.Empty;
                txtPinCode.Text = string.Empty;
                txtShippingAddress.Text = string.Empty;
                txtMobile.Text = string.Empty;
                //txtOrderNo.Enabled = true;
                txtTermDays.Text = "";
                btnAdd.Text = "&Add";
                LueEmployee.Focus();
                m_srno = 0;
                //objPurchase = new Purchase();
                //txtVoucherNo.Text = objPurchase.FindNewID().ToString();
                m_IsUpdate = true;
                lblMode.Text = "Add Mode";

                //txtPurchaseBill.Enabled = true;
                //lueGSTRate.Enabled = true;
                //lueParty.Enabled = true;
            }
            catch (Exception ex)
            {
                BLL.General.ShowErrors(ex);
                blnReturn = false;
            }
            return blnReturn;
        }
        private bool GenerateJangedEntryDetails()
        {
            bool blnReturn = true;
            try
            {
                if (m_dtbSaleDetails.Rows.Count > 0)
                    m_dtbSaleDetails.Rows.Clear();

                m_dtbSaleDetails = new DataTable();

                m_dtbSaleDetails.Columns.Add("sr_no", typeof(int));
                m_dtbSaleDetails.Columns.Add("invoice_detail_id", typeof(int));
                m_dtbSaleDetails.Columns.Add("invoice_id", typeof(int));
                m_dtbSaleDetails.Columns.Add("item_id", typeof(int));
                m_dtbSaleDetails.Columns.Add("item_name", typeof(string));
                m_dtbSaleDetails.Columns.Add("color_id", typeof(int));
                m_dtbSaleDetails.Columns.Add("color_name", typeof(string));
                m_dtbSaleDetails.Columns.Add("size_id", typeof(int));
                m_dtbSaleDetails.Columns.Add("size_name", typeof(string));
                m_dtbSaleDetails.Columns.Add("unit_id", typeof(int));
                m_dtbSaleDetails.Columns.Add("unit_name", typeof(string));
                m_dtbSaleDetails.Columns.Add("pcs", typeof(decimal)).DefaultValue = 0;
                m_dtbSaleDetails.Columns.Add("sale_rate", typeof(decimal)).DefaultValue = 0;
                m_dtbSaleDetails.Columns.Add("sale_amount", typeof(decimal)).DefaultValue = 0;
                m_dtbSaleDetails.Columns.Add("purchase_rate", typeof(decimal)).DefaultValue = 0;
                m_dtbSaleDetails.Columns.Add("purchase_amount", typeof(decimal)).DefaultValue = 0;
                m_dtbSaleDetails.Columns.Add("remarks", typeof(string));
                m_dtbSaleDetails.Columns.Add("old_pcs", typeof(decimal)).DefaultValue = 0;
                m_dtbSaleDetails.Columns.Add("flag", typeof(int)).DefaultValue = 0;
                m_dtbSaleDetails.Columns.Add("old_item_id", typeof(int));
                m_dtbSaleDetails.Columns.Add("old_color_id", typeof(int));
                m_dtbSaleDetails.Columns.Add("old_size_id", typeof(int));
                m_dtbSaleDetails.Columns.Add("old_unit_id", typeof(int));
                m_dtbSaleDetails.Columns.Add("old_item_name", typeof(string));
                m_dtbSaleDetails.Columns.Add("old_color_name", typeof(string));
                m_dtbSaleDetails.Columns.Add("old_size_name", typeof(string));
                m_dtbSaleDetails.Columns.Add("old_unit_name", typeof(string));

                grdSaleDetails.DataSource = m_dtbSaleDetails;
                grdSaleDetails.Refresh();
            }
            catch (Exception ex)
            {
                BLL.General.ShowErrors(ex);
                blnReturn = false;
            }
            return blnReturn;
        }
        private bool PopulateDetails()
        {
            objSaleInvoice = new SaleInvoice();
            bool blnReturn = true;
            DateTime datFromDate = DateTime.MinValue;
            DateTime datToDate = DateTime.MinValue;
            try
            {
                m_dtbDetails = objSaleInvoice.GetData(Val.DBDate(dtpFromDate.Text), Val.DBDate(dtpToDate.Text), Val.ToInt64(txtSearchOrderNo.Text), Val.ToInt32(lueJangedLedger.EditValue), Val.ToString(GlobalDec.gEmployeeProperty.role_name));

                grdSaleEntry.DataSource = m_dtbDetails;
                dgvSaleEntry.BestFitColumns();
            }
            catch (Exception ex)
            {
                BLL.General.ShowErrors(ex);
                blnReturn = false;
            }
            finally
            {
                objSaleInvoice = null;
            }

            return blnReturn;
        }
        public void SetControlPropertyValue(Control oControl, string propName, object propValue)
        {
            if (oControl.InvokeRequired)
            {
                SetControlValueCallback d = new SetControlValueCallback(SetControlPropertyValue);
                oControl.Invoke(d, new object[]
                        {
                            oControl,
                            propName,
                            propValue
                        });
            }
            else
            {
                Type t = oControl.GetType();
                PropertyInfo[] props = t.GetProperties();
                foreach (PropertyInfo p in props)
                {
                    if ((p.Name.ToUpper() == propName.ToUpper()))
                    {
                        p.SetValue(oControl, propValue, null);
                    }
                }
            }
        }
        public System.Data.DataTable WorksheetToDataTable(ExcelWorksheet ws, bool hasHeader = true)
        {
            System.Data.DataTable dt = new System.Data.DataTable(ws.Name);
            int totalCols = ws.Dimension.End.Column;
            int totalRows = ws.Dimension.End.Row;
            int startRow = hasHeader ? 2 : 1;
            ExcelRange wsRow;
            DataRow dr;
            foreach (var firstRowCell in ws.Cells[1, 1, 1, totalCols])
            {
                dt.Columns.Add(hasHeader ? firstRowCell.Text : string.Format("Column {0}", firstRowCell.Start.Column));
            }

            for (int rowNum = startRow; rowNum <= totalRows; rowNum++)
            {
                wsRow = ws.Cells[rowNum, 1, rowNum, totalCols];
                dr = dt.NewRow();
                foreach (var cell in wsRow)
                {
                    dr[cell.Start.Column - 1] = cell.Text;
                }

                dt.Rows.Add(dr);
            }

            return dt;
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
                            dgvSaleEntry.ExportToPdf(Filepath);
                            break;
                        case "xls":
                            dgvSaleEntry.ExportToXls(Filepath);
                            break;
                        case "xlsx":
                            dgvSaleEntry.ExportToXlsx(Filepath);
                            break;
                        case "rtf":
                            dgvSaleEntry.ExportToRtf(Filepath);
                            break;
                        case "txt":
                            dgvSaleEntry.ExportToText(Filepath);
                            break;
                        case "html":
                            dgvSaleEntry.ExportToHtml(Filepath);
                            break;
                        case "csv":
                            dgvSaleEntry.ExportToCsv(Filepath);
                            break;
                    }

                    if (format.Equals(Exports.xlsx.ToString()))
                    {
                        if (Global.Confirm("Export Done\n\nYou Want To Open Excel File ?", "Account Management", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start(Filepath);
                        }
                    }
                    else if (format.Equals(Exports.pdf.ToString()))
                    {
                        if (Global.Confirm("Export Done\n\nYou Want To Open PDF File ?", "Account Management", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start(Filepath);
                        }
                    }
                    else
                    {
                        if (Global.Confirm("Export Done\n\nYou Want To Open File ?", "Account Management", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
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

        #region Export Grid
        private void MNExportExcel_Click(object sender, EventArgs e)
        {
            //Global.Export("xlsx", dgvRoughClarityMaster);
            Export("xlsx", "Export to Excel", "Excel files 97-2003 (Excel files 2007(*.xlsx)|*.xlsx|All files (*.*)|*.*");
        }
        private void MNExportPDF_Click(object sender, EventArgs e)
        {
            // Global.Export("pdf", dgvRoughClarityMaster);
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
        private void lueParty_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmLedgerMaster frmCnt = new FrmLedgerMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPLedger(lueParty);
            }
        }
        private void lueGSTRate_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmGSTMaster frmCnt = new FrmGSTMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPGSTRate(lueGSTRate);
            }
        }
        private void backgroundWorker_SaleInvoice_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.Default;
                Conn = new BeginTranConnection(true, false);

                SaleInvoice_Property objSaleProperty = new SaleInvoice_Property();
                SaleInvoice objSaleInvoice = new SaleInvoice();
                try
                {
                    IntRes = 0;

                    objSaleProperty.invoice_id = Val.ToInt(lblMode.Tag);
                    objSaleProperty.invoice_date = Val.DBDate(dtpInvoiceDate.Text);
                    objSaleProperty.gst_id = Val.ToInt(lueGSTRate.EditValue);
                    objSaleProperty.remarks = Val.ToString(txtRemark.Text);

                    objSaleProperty.form_id = m_numForm_id;

                    if (GlobalDec.gEmployeeProperty.role_name == "B2B")
                    {
                        objSaleProperty.ledger_id = Val.ToInt64(m_dtbParty.Rows[0]["ledger_id"]);
                    }
                    else
                    {
                        objSaleProperty.ledger_id = Val.ToInt64(lueParty.EditValue);
                    }
                    objSaleProperty.employee_id = Val.ToInt64(LueEmployee.EditValue);
                    objSaleProperty.total_pcs = Val.ToDecimal(clmPcs.SummaryItem.SummaryValue);

                    if (GlobalDec.gEmployeeProperty.role_name == "B2B")
                    {
                        objSaleProperty.firm_id = Val.ToInt64(m_dtbPurchaseFirm.Rows[0]["firm_id"]);
                    }
                    else
                    {
                        objSaleProperty.firm_id = Val.ToInt64(luePurchaseFirm.EditValue);
                    }

                    objSaleProperty.gross_amount = Math.Round(Val.ToDecimal(clmRSSaleAmount.SummaryItem.SummaryValue), 3);

                    objSaleProperty.cgst_rate = Val.ToDecimal(txtCGSTPer.Text);
                    objSaleProperty.cgst_amount = Val.ToDecimal(txtCGSTAmount.Text);
                    objSaleProperty.sgst_rate = Val.ToDecimal(txtSGSTPer.Text);
                    objSaleProperty.sgst_amount = Val.ToDecimal(txtSGSTAmount.Text);
                    objSaleProperty.igst_rate = Val.ToDecimal(txtIGSTPer.Text);
                    objSaleProperty.igst_amount = Val.ToDecimal(txtIGSTAmount.Text);

                    objSaleProperty.discount_per = Val.ToDecimal(txtDiscountPer.Text);
                    objSaleProperty.discount_amount = Val.ToDecimal(txtDiscountAmount.Text);
                    objSaleProperty.round_of_amount = Val.ToDecimal(txtRoundOff.Text);
                    objSaleProperty.shipping_amount = Val.ToDecimal(txtShippingCharge.Text);

                    objSaleProperty.order_no = Val.ToString(txtOrderNo.Text);
                    objSaleProperty.sale_type = Val.ToString(LueSaleType.Text);
                    objSaleProperty.weight = Val.ToDecimal(txtWeight.Text);
                    objSaleProperty.pin_code = Val.ToInt64(txtPinCode.Text);
                    objSaleProperty.shipping_address = Val.ToString(txtShippingAddress.Text);
                    objSaleProperty.purchase_amount = Val.ToDecimal(clmRSPurhaseAmount.SummaryItem.SummaryValue);

                    objSaleProperty.net_amount = Val.ToDecimal(txtNetAmount.Text);

                    objSaleProperty.term_days = Val.ToInt32(txtTermDays.Text);
                    objSaleProperty.due_date = Val.DBDate(DTPDueDate.Text);
                    objSaleProperty.mobile_no = Val.ToInt64(txtMobile.Text);

                    objSaleProperty = objSaleInvoice.Save(objSaleProperty, DLL.GlobalDec.EnumTran.Start, Conn);

                    Int64 NewmInvoiceid = Val.ToInt64(objSaleProperty.invoice_id);

                    int IntCounter = 0;
                    int Count = 0;
                    int TotalCount = m_dtbSaleDetails.Rows.Count;

                    foreach (DataRow drw in m_dtbSaleDetails.Rows)
                    {
                        objSaleProperty = new SaleInvoice_Property();
                        objSaleProperty.invoice_id = Val.ToInt64(NewmInvoiceid);
                        objSaleProperty.invoice_detail_id = Val.ToInt64(drw["invoice_detail_id"]);
                        objSaleProperty.sr_no = Val.ToInt(drw["sr_no"]);
                        objSaleProperty.item_id = Val.ToInt64(drw["item_id"]);
                        objSaleProperty.color_id = Val.ToInt64(drw["color_id"]);
                        objSaleProperty.size_id = Val.ToInt64(drw["size_id"]);
                        objSaleProperty.unit_id = Val.ToInt64(drw["unit_id"]);
                        objSaleProperty.pcs = Val.ToDecimal(drw["pcs"]);
                        objSaleProperty.sale_rate = Val.ToDecimal(drw["sale_rate"]);
                        objSaleProperty.sale_amount = Val.ToDecimal(drw["Sale_amount"]);
                        objSaleProperty.purchase_rate = Val.ToDecimal(drw["purchase_rate"]);
                        objSaleProperty.purchase_amount = Val.ToDecimal(drw["purchase_amount"]);

                        objSaleProperty.old_item_id = Val.ToInt64(drw["old_item_id"]);
                        objSaleProperty.old_color_id = Val.ToInt64(drw["old_color_id"]);
                        objSaleProperty.old_size_id = Val.ToInt64(drw["old_size_id"]);

                        objSaleProperty.old_pcs = Val.ToDecimal(drw["old_pcs"]);
                        objSaleProperty.flag = Val.ToInt(drw["flag"]);
                        objSaleProperty.form_id = m_numForm_id;

                        IntRes = objSaleInvoice.Save_Detail(objSaleProperty, DLL.GlobalDec.EnumTran.Continue, Conn);

                        Count++;
                        IntCounter++;
                        IntRes++;
                        SetControlPropertyValue(lblProgressCount, "Text", Count.ToString() + "" + "/" + "" + TotalCount.ToString() + " Completed....");
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
                    objSaleInvoice = null;
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
        private void backgroundWorker_SaleInvoice_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            try
            {
                panelProgress.Visible = false;
                if (IntRes > 0)
                {
                    if (Val.ToInt(lblMode.Tag) == 0)
                    {
                        Global.Confirm("Sale Invoice Data Save Successfully");
                        ClearDetails();
                        PopulateDetails();
                    }
                    else
                    {
                        Global.Confirm("Sale Invoice Data Update Successfully");
                        ClearDetails();
                        PopulateDetails();
                    }
                }
                else
                {
                    Global.Confirm("Error In Sale Invoice Data");
                    LueEmployee.Focus();
                }
            }
            catch (Exception ex)
            {
                Global.Message(ex.ToString());
                Global.Message(ex.InnerException.ToString());
            }
        }
        private void backgroundWorker_SaleInvoiceDelete_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Conn = new BeginTranConnection(true, false);

            SaleInvoice_Property objSaleInvoiceProperty = new SaleInvoice_Property();
            SaleInvoice objSaleInvoice = new SaleInvoice();
            DataTable dtbMemoRecDelete = new DataTable();
            try
            {
                if (Val.ToInt(lblMode.Tag) != 0)
                {
                    IntRes = 0;
                    objSaleInvoiceProperty.invoice_id = Val.ToInt64(lblMode.Tag);

                    int IntCounter = 0;
                    int Count = 0;
                    int FlagCount = 1;
                    int TotalCount = m_dtbSaleDetails.Rows.Count;
                    Int32 Flag = 0;
                    foreach (DataRow drw in m_dtbSaleDetails.Rows)
                    {
                        objSaleInvoiceProperty.invoice_detail_id = Val.ToInt64(drw["invoice_detail_id"]);
                        objSaleInvoiceProperty.item_id = Val.ToInt64(drw["item_id"]);
                        objSaleInvoiceProperty.color_id = Val.ToInt64(drw["color_id"]);
                        objSaleInvoiceProperty.size_id = Val.ToInt64(drw["size_id"]);
                        objSaleInvoiceProperty.pcs = Val.ToDecimal(drw["pcs"]);

                        if (FlagCount == TotalCount)
                        {
                            Flag = 1;
                        }

                        IntRes = objSaleInvoice.Delete(objSaleInvoiceProperty, Flag, DLL.GlobalDec.EnumTran.Continue, Conn);

                        FlagCount++;
                        Count++;
                        IntCounter++;
                        IntRes++;
                        SetControlPropertyValue(lblProgressCount, "Text", Count.ToString() + "" + "/" + "" + TotalCount.ToString() + " Completed....");
                    }

                    Conn.Inter1.Commit();
                }
                else
                {
                    Global.Message("Sale Invoice ID not found");
                    Conn.Inter1.Rollback();
                    Conn = null;
                    return;
                }
            }
            catch (Exception ex)
            {
                IntRes = -1;
                Conn.Inter1.Rollback();
                Conn = null;
                General.ShowErrors(ex.ToString());
                if (ex.InnerException != null)
                {
                    Global.Message(ex.InnerException.ToString());
                }
            }
            finally
            {
                objSaleInvoiceProperty = null;
            }
        }
        private void backgroundWorker_SaleInvoiceDelete_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            try
            {
                panelProgress.Visible = false;
                if (IntRes > 0)
                {
                    if (Val.ToInt(lblMode.Tag) == 0)
                    {
                        Global.Confirm("Sale Invoice Data Delete Successfully");
                        ClearDetails();
                        btnSearch_Click(null, null);
                    }
                    else
                    {
                        Global.Confirm("Sale Invoice Data Delete Successfully");
                        ClearDetails();
                        btnSearch_Click(null, null);
                    }
                }
                else
                {
                    Global.Confirm("Error In Sale Invoice Data Delete");
                    LueEmployee.Focus();
                }
            }
            catch (Exception ex)
            {
                Global.Message(ex.ToString());
                Global.Message(ex.InnerException.ToString());
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearDetails();
        }
        private void lueGSTRate_Validated(object sender, EventArgs e)
        {
            GSTMaster objGSTRate = new GSTMaster();
            DataTable GSTRate = objGSTRate.GetData();

            DataRow[] Dr = GSTRate.Select("gst_id = '" + Val.ToInt64(lueGSTRate.EditValue) + "'");

            if (Dr.Length > 0)
            {
                DataTable DTab_ProductionType = GSTRate.Select("gst_id = '" + Val.ToInt64(lueGSTRate.EditValue) + "'").CopyToDataTable();

                if (DTab_ProductionType.Rows[0]["type"].ToString() == "InterState")
                {
                    txtIGSTPer.Text = DTab_ProductionType.Rows[0]["gst_rate"].ToString();
                    txtCGSTPer.Text = "0";
                    txtCGSTAmount.Text = "0";
                    txtSGSTPer.Text = "0";
                    txtSGSTAmount.Text = "0";
                    txtCGSTPer.Enabled = false;
                    txtCGSTAmount.Enabled = false;
                    txtSGSTPer.Enabled = false;
                    txtSGSTAmount.Enabled = false;
                }
                else if (DTab_ProductionType.Rows[0]["type"].ToString() == "LocalState")
                {
                    decimal Local_Per = Val.ToDecimal(DTab_ProductionType.Rows[0]["gst_rate"]) / 2;
                    txtCGSTPer.Text = Local_Per.ToString();
                    txtSGSTPer.Text = Local_Per.ToString();
                    txtIGSTPer.Text = "0";
                    txtIGSTAmount.Text = "0";
                    txtIGSTPer.Enabled = false;
                    txtIGSTAmount.Enabled = false;
                }
            }
        }
        private void txtDiscountAmount_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (!m_blncheckevents)
                {
                    if (Val.ToDecimal(txtDiscountAmount.Text) > 0)
                    {
                        decimal CGST_amount = Math.Round((Val.ToDecimal(clmRSSaleAmount.SummaryItem.SummaryValue) - Val.ToDecimal(txtDiscountAmount.Text)) * Val.ToDecimal(txtCGSTPer.Text) / 100, 2);
                        txtCGSTAmount.Text = CGST_amount.ToString();
                        decimal SGST_amount = Math.Round((Val.ToDecimal(clmRSSaleAmount.SummaryItem.SummaryValue) - Val.ToDecimal(txtDiscountAmount.Text)) * Val.ToDecimal(txtSGSTPer.Text) / 100, 2);
                        txtSGSTAmount.Text = SGST_amount.ToString();
                        decimal IGST_amount = Math.Round((Val.ToDecimal(clmRSSaleAmount.SummaryItem.SummaryValue) - Val.ToDecimal(txtDiscountAmount.Text)) * Val.ToDecimal(txtIGSTPer.Text) / 100, 2);
                        txtIGSTAmount.Text = IGST_amount.ToString();

                        decimal Dis_Per = Math.Round(Val.ToDecimal(txtDiscountAmount.Text) * 100 / Val.ToDecimal(clmRSSaleAmount.SummaryItem.SummaryValue), 2);
                        txtDiscountPer.Text = Dis_Per.ToString();
                        decimal Net_Amount = Math.Round((Val.ToDecimal(clmRSSaleAmount.SummaryItem.SummaryValue) + Val.ToDecimal(txtCGSTAmount.Text) + Val.ToDecimal(txtSGSTAmount.Text) + Val.ToDecimal(txtIGSTAmount.Text) + Val.ToDecimal(txtShippingCharge.Text) - Val.ToDecimal(txtDiscountAmount.Text)) + Val.ToDecimal(txtRoundOff.Text), 2);
                        txtNetAmount.Text = Net_Amount.ToString();
                    }
                    else
                    {
                        decimal CGST_amount = Math.Round(Val.ToDecimal(clmRSSaleAmount.SummaryItem.SummaryValue) * Val.ToDecimal(txtCGSTPer.Text) / 100, 2);
                        txtCGSTAmount.Text = CGST_amount.ToString();
                        decimal SGST_amount = Math.Round(Val.ToDecimal(clmRSSaleAmount.SummaryItem.SummaryValue) * Val.ToDecimal(txtSGSTPer.Text) / 100, 2);
                        txtSGSTAmount.Text = SGST_amount.ToString();
                        decimal IGST_amount = Math.Round(Val.ToDecimal(clmRSSaleAmount.SummaryItem.SummaryValue) * Val.ToDecimal(txtIGSTPer.Text) / 100, 2);
                        txtIGSTAmount.Text = IGST_amount.ToString();

                        txtDiscountPer.Text = "0";
                        decimal Net_Amount = Math.Round((Val.ToDecimal(clmRSSaleAmount.SummaryItem.SummaryValue) + Val.ToDecimal(txtCGSTAmount.Text) + Val.ToDecimal(txtSGSTAmount.Text) + Val.ToDecimal(txtIGSTAmount.Text) + Val.ToDecimal(txtShippingCharge.Text) - Val.ToDecimal(txtDiscountAmount.Text)) + Val.ToDecimal(txtRoundOff.Text), 2);
                        txtNetAmount.Text = Net_Amount.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                General.ShowErrors(ex.ToString());
                return;
            }
        }
        private void txtTermDays_EditValueChanged(object sender, EventArgs e)
        {
            if (dtpInvoiceDate.Text.Length <= 0 || txtTermDays.Text == "")
            {
                txtTermDays.Text = "";
                DTPDueDate.EditValue = null;
            }
            else
            {
                DateTime Date = Convert.ToDateTime(dtpInvoiceDate.EditValue).AddDays(Val.ToDouble(txtTermDays.Text));
                DTPDueDate.EditValue = Val.DBDDDate(Date.ToShortDateString());
            }
        }
        private void txtTermDays_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void LueEmployee_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmEmployeeMaster frmCnt = new FrmEmployeeMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPEmployee(LueEmployee);
            }
        }

        private void txtSaleRate_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtSaleAmount.Text = string.Format("{0:0.00}", Val.ToDecimal(txtPcs.Text) * Val.ToDecimal(txtSaleRate.Text));
            }
            catch (Exception ex)
            {
                General.ShowErrors(ex.ToString());
                return;
            }
        }

        private void txtPurchaseRate_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtPurchaseAmount.Text = string.Format("{0:0.00}", Val.ToDecimal(txtPcs.Text) * Val.ToDecimal(txtPurchaseRate.Text));
            }
            catch (Exception ex)
            {
                General.ShowErrors(ex.ToString());
                return;
            }
        }

        private void txtPcs_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (Val.ToDecimal(txtPurchaseRate.Text) != 0)
                {
                    txtPurchaseAmount.Text = string.Format("{0:0.00}", Val.ToDecimal(txtPcs.Text) * Val.ToDecimal(txtPurchaseRate.Text));
                }
                if (Val.ToDecimal(txtSaleRate.Text) != 0)
                {
                    txtSaleAmount.Text = string.Format("{0:0.00}", Val.ToDecimal(txtPcs.Text) * Val.ToDecimal(txtSaleRate.Text));
                }
            }
            catch (Exception ex)
            {
                General.ShowErrors(ex.ToString());
                return;
            }
        }

        private void FrmSaleInvoice_Load(object sender, EventArgs e)
        {
            try
            {
                if (!LoadDefaults())
                {
                    btnAdd.Enabled = false;
                    btnClear.Enabled = false;
                    btnSave.Enabled = false;
                }
                else
                {
                    ClearDetails();
                    ttlbSaleInvoice.SelectedTabPage = tblSaledetail;
                }
            }
            catch (Exception ex)
            {
                Global.Message(ex.ToString());
                return;
            }
        }

        private void dgvSaleDetails_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                if (e.RowHandle >= 0)
                {
                    if (e.Clicks == 2)
                    {
                        DataRow Drow = dgvSaleDetails.GetDataRow(e.RowHandle);
                        btnAdd.Text = "&Update";
                        //lueSieveName.Text = Val.ToString(Drow["sieve_name"]);
                        LueColor.EditValue = Val.ToInt64(Drow["color_id"]);
                        LueSize.EditValue = Val.ToInt64(Drow["size_id"]);
                        LueUnit.EditValue = Val.ToInt64(Drow["unit_id"]);
                        lueItem.EditValue = Val.ToInt64(Drow["item_id"]);
                        txtPcs.Text = Val.ToString(Drow["pcs"]);
                        txtSaleRate.Text = Val.ToString(Drow["sale_rate"]);
                        txtSaleAmount.Text = Val.ToString(Drow["sale_amount"]);
                        txtPurchaseRate.Text = Val.ToString(Drow["purchase_rate"]);
                        txtPurchaseAmount.Text = Val.ToString(Drow["purchase_amount"]);

                        m_invoice_detail_id = Val.ToInt(Drow["invoice_detail_id"]);

                        m_update_srno = Val.ToInt(Drow["sr_no"]);
                    }
                }
            }
            catch (Exception ex)
            {
                BLL.General.ShowErrors(ex);
                return;
            }
        }

        private void dgvSaleDetails_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            try
            {
                m_numTotalPcs = Val.ToDecimal(clmPcs.SummaryItem.SummaryValue);
                if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName == "sale_rate")
                {
                    if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Start)
                        m_numSummSaleDetAmount = 0;
                    else if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Calculate)
                        m_numSummSaleDetAmount += (Val.ToDecimal(e.GetValue("pcs")) * Val.ToDecimal(e.GetValue("sale_rate")));
                    else if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize)
                    {
                        if (m_numSummSaleDetAmount > 0 && m_numTotalPcs > 0)
                            e.TotalValue = Math.Round((m_numSummSaleDetAmount / m_numTotalPcs), 2, MidpointRounding.AwayFromZero);
                        else
                            e.TotalValue = 0;
                    }
                }
                if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName == "purchase_rate")
                {
                    if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Start)
                        m_numSummPurchaseDetAmount = 0;
                    else if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Calculate)
                        m_numSummPurchaseDetAmount += (Val.ToDecimal(e.GetValue("pcs")) * Val.ToDecimal(e.GetValue("purchase_rate")));
                    else if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize)
                    {
                        if (m_numSummPurchaseDetAmount > 0 && m_numTotalPcs > 0)
                            e.TotalValue = Math.Round((m_numSummPurchaseDetAmount / m_numTotalPcs), 2, MidpointRounding.AwayFromZero);
                        else
                            e.TotalValue = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                BLL.General.ShowErrors(ex);
            }
        }
        private void dgvSaleEntry_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (Val.ToInt(dgvSaleEntry.GetRowCellValue(e.RowHandle, "flag_color")) == 1)
                {
                    e.Appearance.BackColor = Color.FromArgb(248, 210, 210);
                }
            }
        }
        private void dgvSaleEntry_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                objSaleInvoice = new SaleInvoice();
                if (e.RowHandle >= 0)
                {
                    if (e.Clicks == 2)
                    {
                        m_blncheckevents = true;

                        DataRow Drow = dgvSaleEntry.GetDataRow(e.RowHandle);
                        lblMode.Text = "Edit Mode";
                        lblMode.Tag = Val.ToInt64(Drow["invoice_id"]);

                        dtpInvoiceDate.Text = Val.DBDate(Val.ToString(Drow["invoice_date"]));
                        txtOrderNo.Text = Val.ToString(Drow["order_no"]);
                        lueGSTRate.EditValue = Val.ToInt64(Drow["gst_id"]);
                        lueParty.EditValue = Val.ToInt64(Drow["ledger_id"]);
                        LueSaleType.Text = Val.ToString(Drow["sale_type"]);
                        LueEmployee.EditValue = Val.ToInt64(Drow["employee_id"]);
                        luePurchaseFirm.EditValue = Val.ToInt64(Drow["firm_id"]);
                        txtRemark.Text = Val.ToString(Drow["remarks"]);
                        txtWeight.Text = Val.ToString(Drow["weight"]);
                        txtPinCode.Text = Val.ToString(Drow["pin_code"]);
                        txtMobile.Text = Val.ToString(Drow["mobile_no"]);
                        txtRoundOff.Text = Val.ToString(Drow["round_of_amount"]);
                        txtDiscountPer.Text = Val.ToString(Drow["discount_per"]);
                        txtDiscountAmount.Text = Val.ToString(Drow["discount_amount"]);
                        txtCGSTPer.Text = Val.ToString(Drow["cgst_per"]);
                        txtCGSTAmount.Text = Val.ToString(Drow["cgst_amount"]);
                        txtSGSTPer.Text = Val.ToString(Drow["sgst_per"]);
                        txtSGSTAmount.Text = Val.ToString(Drow["sgst_amount"]);
                        txtIGSTPer.Text = Val.ToString(Drow["igst_per"]);
                        txtIGSTAmount.Text = Val.ToString(Drow["igst_amount"]);

                        txtShippingCharge.Text = Val.ToString(Drow["shipping_amount"]);
                        txtShippingAddress.Text = Val.ToString(Drow["shipping_address"]);

                        txtNetAmount.Text = Val.ToString(Drow["net_amount"]);
                        txtTermDays.Text = Val.ToString(Drow["term_days"]);
                        DTPDueDate.Text = Val.ToString(Drow["due_date"]);

                        m_dtbSaleDetails = objSaleInvoice.GetDataDetails(Val.ToInt(lblMode.Tag));
                        grdSaleDetails.DataSource = m_dtbSaleDetails;

                        ttlbSaleInvoice.SelectedTabPage = tblSaledetail;
                        txtWeight.Focus();
                        txtOrderNo.Enabled = false;
                        m_IsUpdate = true;
                    }
                }
            }
            catch (Exception ex)
            {
                BLL.General.ShowErrors(ex);
                return;
            }
        }
        private void txtPcs_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.' && (sender as DevExpress.XtraEditors.TextEdit).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }
        private void txtShippingCharge_KeyDown(object sender, KeyEventArgs e)
        {
            m_blncheckevents = false;
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            SaleInvoice objSaleInvoice = new SaleInvoice();
            DataTable DTab_Sale_Invoice = objSaleInvoice.Sale_Invoice_Print_GetData(Val.ToInt64(lblMode.Tag));

            for (int i = DTab_Sale_Invoice.Rows.Count; i < 18; i++)
            {
                DTab_Sale_Invoice.Rows.Add();
                if (i == 12)
                {
                    DTab_Sale_Invoice.Rows[i]["firm_name"] = DTab_Sale_Invoice.Rows[0]["firm_name"];
                    DTab_Sale_Invoice.Rows[i]["address"] = DTab_Sale_Invoice.Rows[0]["address"];
                    DTab_Sale_Invoice.Rows[i]["phone1"] = DTab_Sale_Invoice.Rows[0]["phone1"];
                    DTab_Sale_Invoice.Rows[i]["phone2"] = DTab_Sale_Invoice.Rows[0]["phone2"];
                    DTab_Sale_Invoice.Rows[i]["pincode"] = DTab_Sale_Invoice.Rows[0]["pincode"];
                    DTab_Sale_Invoice.Rows[i]["email"] = DTab_Sale_Invoice.Rows[0]["email"];
                    DTab_Sale_Invoice.Rows[i]["bank_name"] = DTab_Sale_Invoice.Rows[0]["bank_name"];
                    DTab_Sale_Invoice.Rows[i]["bank_branch"] = DTab_Sale_Invoice.Rows[0]["bank_branch"];
                    DTab_Sale_Invoice.Rows[i]["bank_ifsc"] = DTab_Sale_Invoice.Rows[0]["bank_ifsc"];
                    DTab_Sale_Invoice.Rows[i]["bank_acc_no"] = DTab_Sale_Invoice.Rows[0]["bank_acc_no"];
                    DTab_Sale_Invoice.Rows[i]["gst_no"] = DTab_Sale_Invoice.Rows[0]["gst_no"];
                    DTab_Sale_Invoice.Rows[i]["account_type"] = DTab_Sale_Invoice.Rows[0]["account_type"];
                    DTab_Sale_Invoice.Rows[i]["state_name"] = DTab_Sale_Invoice.Rows[0]["state_name"];
                    DTab_Sale_Invoice.Rows[i]["city_name"] = DTab_Sale_Invoice.Rows[0]["city_name"];
                    DTab_Sale_Invoice.Rows[i]["invoice_date"] = DTab_Sale_Invoice.Rows[0]["invoice_date"];
                    DTab_Sale_Invoice.Rows[i]["invoice_no"] = DTab_Sale_Invoice.Rows[0]["invoice_no"];
                    DTab_Sale_Invoice.Rows[i]["party_name"] = DTab_Sale_Invoice.Rows[0]["party_name"];
                    DTab_Sale_Invoice.Rows[i]["party_address"] = DTab_Sale_Invoice.Rows[0]["party_address"];
                    DTab_Sale_Invoice.Rows[i]["party_gst"] = DTab_Sale_Invoice.Rows[0]["party_gst"];
                    DTab_Sale_Invoice.Rows[i]["party_mobile1"] = DTab_Sale_Invoice.Rows[0]["party_mobile1"];
                    DTab_Sale_Invoice.Rows[i]["discount_amount"] = DTab_Sale_Invoice.Rows[0]["discount_amount"];
                    DTab_Sale_Invoice.Rows[i]["cgst"] = DTab_Sale_Invoice.Rows[0]["cgst"];
                    DTab_Sale_Invoice.Rows[i]["sgst"] = DTab_Sale_Invoice.Rows[0]["sgst"];
                    DTab_Sale_Invoice.Rows[i]["igst"] = DTab_Sale_Invoice.Rows[0]["igst"];
                    DTab_Sale_Invoice.Rows[i]["netamount"] = DTab_Sale_Invoice.Rows[0]["netamount"];
                    DTab_Sale_Invoice.Rows[i]["state_code"] = DTab_Sale_Invoice.Rows[0]["state_code"];
                }
                else
                {
                    DTab_Sale_Invoice.Rows[i]["firm_name"] = DTab_Sale_Invoice.Rows[0]["firm_name"];
                    DTab_Sale_Invoice.Rows[i]["address"] = DTab_Sale_Invoice.Rows[0]["address"];
                    DTab_Sale_Invoice.Rows[i]["phone1"] = DTab_Sale_Invoice.Rows[0]["phone1"];
                    DTab_Sale_Invoice.Rows[i]["phone2"] = DTab_Sale_Invoice.Rows[0]["phone2"];
                    DTab_Sale_Invoice.Rows[i]["pincode"] = DTab_Sale_Invoice.Rows[0]["pincode"];
                    DTab_Sale_Invoice.Rows[i]["email"] = DTab_Sale_Invoice.Rows[0]["email"];
                    DTab_Sale_Invoice.Rows[i]["bank_name"] = DTab_Sale_Invoice.Rows[0]["bank_name"];
                    DTab_Sale_Invoice.Rows[i]["bank_branch"] = DTab_Sale_Invoice.Rows[0]["bank_branch"];
                    DTab_Sale_Invoice.Rows[i]["bank_ifsc"] = DTab_Sale_Invoice.Rows[0]["bank_ifsc"];
                    DTab_Sale_Invoice.Rows[i]["bank_acc_no"] = DTab_Sale_Invoice.Rows[0]["bank_acc_no"];
                    DTab_Sale_Invoice.Rows[i]["gst_no"] = DTab_Sale_Invoice.Rows[0]["gst_no"];
                    DTab_Sale_Invoice.Rows[i]["account_type"] = DTab_Sale_Invoice.Rows[0]["account_type"];
                    DTab_Sale_Invoice.Rows[i]["state_name"] = DTab_Sale_Invoice.Rows[0]["state_name"];
                    DTab_Sale_Invoice.Rows[i]["city_name"] = DTab_Sale_Invoice.Rows[0]["city_name"];
                    DTab_Sale_Invoice.Rows[i]["invoice_date"] = DTab_Sale_Invoice.Rows[0]["invoice_date"];
                    DTab_Sale_Invoice.Rows[i]["invoice_no"] = DTab_Sale_Invoice.Rows[0]["invoice_no"];
                    DTab_Sale_Invoice.Rows[i]["party_name"] = DTab_Sale_Invoice.Rows[0]["party_name"];
                    DTab_Sale_Invoice.Rows[i]["party_address"] = DTab_Sale_Invoice.Rows[0]["party_address"];
                    DTab_Sale_Invoice.Rows[i]["party_gst"] = DTab_Sale_Invoice.Rows[0]["party_gst"];
                    DTab_Sale_Invoice.Rows[i]["party_mobile1"] = DTab_Sale_Invoice.Rows[0]["party_mobile1"];
                    DTab_Sale_Invoice.Rows[i]["discount_amount"] = DTab_Sale_Invoice.Rows[0]["discount_amount"];
                    DTab_Sale_Invoice.Rows[i]["cgst"] = DTab_Sale_Invoice.Rows[0]["cgst"];
                    DTab_Sale_Invoice.Rows[i]["sgst"] = DTab_Sale_Invoice.Rows[0]["sgst"];
                    DTab_Sale_Invoice.Rows[i]["igst"] = DTab_Sale_Invoice.Rows[0]["igst"];
                    DTab_Sale_Invoice.Rows[i]["netamount"] = DTab_Sale_Invoice.Rows[0]["netamount"];
                    DTab_Sale_Invoice.Rows[i]["state_code"] = DTab_Sale_Invoice.Rows[0]["state_code"];

                    //dtpur.Rows[i]["insurance_meter"] = dtpur.Rows[0]["insurance_meter"];
                    //dtpur.Rows[i]["insurance_meter_rate"] = dtpur.Rows[0]["insurance_meter_rate"];
                    //dtpur.Rows[i]["insurance_meter_amount"] = dtpur.Rows[0]["insurance_meter_amount"];
                    //dtpur.Rows[i]["insurance_bale"] = dtpur.Rows[0]["insurance_bale"];
                    //dtpur.Rows[i]["insurance_bale_rate"] = dtpur.Rows[0]["insurance_bale_rate"];
                    //dtpur.Rows[i]["insurance_bale_amount"] = dtpur.Rows[0]["insurance_bale_amount"];
                    //dtpur.Rows[i]["cash_discount"] = dtpur.Rows[0]["cash_discount"];
                    //dtpur.Rows[i]["job_card_no"] = dtpur.Rows[0]["job_card_no"];
                    //dtpur.Rows[i]["job_card_date"] = dtpur.Rows[0]["job_card_date"];
                    //dtpur.Rows[i]["program"] = dtpur.Rows[0]["program"];
                    //dtpur.Rows[i]["process_type_name"] = dtpur.Rows[0]["process_type_name"];
                    //dtpur.Rows[i]["fold"] = dtpur.Rows[0]["fold"];
                    //dtpur.Rows[i]["width"] = dtpur.Rows[0]["width"];
                    //dtpur.Rows[i]["mark"] = dtpur.Rows[0]["mark"];
                    //dtpur.Rows[i]["bale_no"] = dtpur.Rows[0]["bale_no"];
                    //dtpur.Rows[i]["sample_meter"] = dtpur.Rows[0]["sample_meter"];
                    //dtpur.Rows[i]["sample_rate"] = dtpur.Rows[0]["sample_rate"];
                    //dtpur.Rows[i]["sample_amount"] = dtpur.Rows[0]["sample_amount"];
                    //dtpur.Rows[i]["net_amount"] = dtpur.Rows[0]["net_amount"];
                    //dtpur.Rows[i]["is_igst"] = dtpur.Rows[0]["is_igst"];
                    //dtpur.Rows[i]["other_charge"] = dtpur.Rows[0]["other_charge"];
                    //dtpur.Rows[i]["round_off"] = dtpur.Rows[0]["round_off"];
                    //dtpur.Rows[i]["is_cgst"] = dtpur.Rows[0]["is_cgst"];
                }
            }

            FrmReportViewer FrmReportViewer = new FrmReportViewer();
            FrmReportViewer.DS.Tables.Add(DTab_Sale_Invoice);
            FrmReportViewer.GroupBy = "";
            FrmReportViewer.RepName = "";
            FrmReportViewer.RepPara = "";
            this.Cursor = Cursors.Default;
            FrmReportViewer.AllowSetFormula = true;

            FrmReportViewer.ShowForm("Bill_Detail", 120, FrmReportViewer.ReportFolder.SALE_INVOICE);

            DTab_Sale_Invoice = null;
            FrmReportViewer.DS.Tables.Clear();
            FrmReportViewer.DS.Clear();
            FrmReportViewer = null;
        }
        private void lueItem_Validated(object sender, EventArgs e)
        {
            try
            {
                SaleInvoice objSaleInvoice = new SaleInvoice();
                DataTable DTab_SaleRate = objSaleInvoice.SaleRate_GetData(Val.ToInt64(lueItem.EditValue));
                txtPurchaseRate.Text = Val.ToDecimal(DTab_SaleRate.Rows[0]["last_purchase_rate"]).ToString();
                txtSaleRate.Text = Val.ToDecimal(DTab_SaleRate.Rows[0]["sale_rate"]).ToString();
            }
            catch (Exception ex)
            {
            }
        }
        private void LueSaleType_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable m_dtb = new DataTable();
                objSaleInvoice = new SaleInvoice();

                if (lblMode.Text == "Add Mode")
                {
                    m_dtb = objSaleInvoice.GetOrderData(LueSaleType.Text, "AA");

                    if (m_dtb.Rows.Count > 0)
                    {
                        txtOrderNo.Text = Val.ToString(m_dtb.Rows[0]["order_no"]);
                    }
                }
            }
            catch (Exception ex)
            {
                BLL.General.ShowErrors(ex);
                return;
            }
        }
        private void txtMobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }
        private void txtBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtBarcode_Validated(object sender, EventArgs e)
        {
            try
            {
                m_dtbBarcode = new DataTable();
                m_dtbBarcode.AcceptChanges();

                if (txtbarcode.Text.Length == 0)
                {
                    return;
                }
                SaleInvoice objSaleInvoice = new SaleInvoice();

                m_dtbBarcode = objSaleInvoice.Sale_Invocie_Barcode_GetData(Val.ToInt64(txtbarcode.Text));

                if (m_dtbBarcode.Rows.Count > 0)
                {
                    lueItem.EditValue = Val.ToInt64(m_dtbBarcode.Rows[0]["item_id"]);
                    LueColor.EditValue = Val.ToInt64(m_dtbBarcode.Rows[0]["color_id"]);
                    LueSize.EditValue = Val.ToInt64(m_dtbBarcode.Rows[0]["size_id"]);
                    txtPcs.Text = Val.ToString(m_dtbBarcode.Rows[0]["balance_pcs"]);
                    LueUnit.EditValue = Val.ToInt64(m_dtbBarcode.Rows[0]["unit_id"]);
                    txtbarcode.Text = "";
                    txtPcs.Focus();
                }
                else
                {
                    Global.Message("Barcode Not Found In Stock");
                    txtbarcode.Text = "";
                    lueItem.EditValue = System.DBNull.Value;
                    LueColor.EditValue = System.DBNull.Value;
                    LueSize.EditValue = System.DBNull.Value;
                    LueUnit.EditValue = System.DBNull.Value;
                    txtPcs.Text = string.Empty;
                    txtbarcode.Focus();
                    return;
                }

            }
            catch (Exception ex)
            {
                BLL.General.ShowErrors(ex);
                return;
            }
        }
        private void FrmSaleInvoice_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.F1)
            {
                FrmLedgerMaster frmCnt = new FrmLedgerMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPCashBankWithoutLedger(lueParty);
            }
            else if (e.KeyCode == Keys.F8)
            {
                btnDelete_Click(null, null);
            }
        }
    }
}