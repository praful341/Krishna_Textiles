using Account_Management.Class;
using Account_Management.Master;
using BLL;
using BLL.FunctionClasses.Account;
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
    public partial class FrmSaleReturn : DevExpress.XtraEditors.XtraForm
    {
        #region Data Member
        BLL.BeginTranConnection Conn;
        BLL.FormEvents objBOFormEvents;
        BLL.FormPer ObjPer;
        BLL.Validation Val;

        Control _NextEnteredControl;
        private List<Control> _tabControls;
        public delegate void SetControlValueCallback(Control oControl, string propName, object propValue);

        SaleReturn objSaleReturn = new SaleReturn();
        UserAuthentication objUserAuthentication = new UserAuthentication();

        DataTable DtControlSettings = new DataTable();
        DataTable m_dtbSaleDetails = new DataTable();
        DataTable m_dtbDetails = new DataTable();
        DataSet m_dtbVoucher_JangedDetail = new DataSet();
        DataTable DtPaymentGiven = new DataTable();

        int m_return_detail_id;
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

        #endregion

        #region Constructor
        public FrmSaleReturn()
        {
            InitializeComponent();

            objBOFormEvents = new BLL.FormEvents();
            ObjPer = new BLL.FormPer();
            Val = new BLL.Validation();

            _NextEnteredControl = new Control();
            _tabControls = new List<Control>();

            objSaleReturn = new SaleReturn();
            objUserAuthentication = new UserAuthentication();

            DtControlSettings = new DataTable();
            m_dtbDetails = new DataTable();

            m_return_detail_id = 0;
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
            if (Global.CheckDefault() == 0)
            {
                Global.Message("Please Check User Default Setting");
                this.Close();
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
        public void ShowForm_New(Int64 Sale_Return_ID)
        {
            ObjPer.FormName = this.Name.ToUpper();
            m_numForm_id = ObjPer.form_id;
            if (ObjPer.CheckPermission() == false)
            {
                Global.Message(BLL.GlobalDec.gStrPermissionViwMsg);
                return;
            }
            if (Global.CheckDefault() == 0)
            {
                Global.Message("Please Check User Default Setting");
                this.Close();
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

            objSaleReturn = new SaleReturn();
            DataTable DTab_Sale_Return = objSaleReturn.Sale_Return_Popup_GetData(Val.ToInt64(Sale_Return_ID));

            if (DTab_Sale_Return.Rows.Count > 0)
            {
                lblMode.Text = "Edit Mode";
                lblMode.Tag = Val.ToInt64(DTab_Sale_Return.Rows[0]["sale_return_id"]);
                dtpReturnDate.Text = Val.DBDate(Val.ToString(DTab_Sale_Return.Rows[0]["return_date"]));
                txtOrderNo.Text = Val.ToString(DTab_Sale_Return.Rows[0]["order_no"]);
                lueGSTRate.EditValue = Val.ToInt64(DTab_Sale_Return.Rows[0]["gst_id"]);
                lueParty.EditValue = Val.ToInt64(DTab_Sale_Return.Rows[0]["ledger_id"]);
                CmbSaleType.Text = Val.ToString(DTab_Sale_Return.Rows[0]["sale_type"]);
                LueEmployee.EditValue = Val.ToInt64(DTab_Sale_Return.Rows[0]["employee_id"]);
                luePurchaseFirm.EditValue = Val.ToInt64(DTab_Sale_Return.Rows[0]["firm_id"]);
                txtRemark.Text = Val.ToString(DTab_Sale_Return.Rows[0]["remarks"]);
                txtWeight.Text = Val.ToString(DTab_Sale_Return.Rows[0]["weight"]);
                txtPinCode.Text = Val.ToString(DTab_Sale_Return.Rows[0]["pin_code"]);
                txtRoundOff.Text = Val.ToString(DTab_Sale_Return.Rows[0]["round_of_amount"]);
                txtDiscountPer.Text = Val.ToString(DTab_Sale_Return.Rows[0]["discount_per"]);
                txtDiscountAmount.Text = Val.ToString(DTab_Sale_Return.Rows[0]["discount_amount"]);
                txtCGSTPer.Text = Val.ToString(DTab_Sale_Return.Rows[0]["cgst_per"]);
                txtCGSTAmount.Text = Val.ToString(DTab_Sale_Return.Rows[0]["cgst_amount"]);
                txtSGSTPer.Text = Val.ToString(DTab_Sale_Return.Rows[0]["sgst_per"]);
                txtSGSTAmount.Text = Val.ToString(DTab_Sale_Return.Rows[0]["sgst_amount"]);
                txtIGSTPer.Text = Val.ToString(DTab_Sale_Return.Rows[0]["igst_per"]);
                txtIGSTAmount.Text = Val.ToString(DTab_Sale_Return.Rows[0]["igst_amount"]);
                txtShippingCharge.Text = Val.ToString(DTab_Sale_Return.Rows[0]["shipping_amount"]);
                txtShippingAddress.Text = Val.ToString(DTab_Sale_Return.Rows[0]["shipping_address"]);
                txtNetAmount.Text = Val.ToString(DTab_Sale_Return.Rows[0]["net_amount"]);
                txtTermDays.Text = Val.ToString(DTab_Sale_Return.Rows[0]["term_days"]);
                DTPDueDate.Text = Val.ToString(DTab_Sale_Return.Rows[0]["due_date"]);

                m_dtbSaleDetails = objSaleReturn.GetDataDetails(Val.ToInt(lblMode.Tag));
                grdSaleReturnDetails.DataSource = m_dtbSaleDetails;

                ttlbSaleReturn.SelectedTabPage = tblSaledetail;
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
            objBOFormEvents.ObjToDispose.Add(objSaleReturn);
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
            backgroundWorker_SaleReturn.RunWorkerAsync();

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


            DialogResult result = MessageBox.Show("Do you want to Delete data?", "Confirmation", MessageBoxButtons.YesNoCancel);
            if (result != DialogResult.Yes)
            {
                btnDelete.Enabled = true;
                return;
            }

            DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = true;
            panelProgress.Visible = true;
            backgroundWorker_SaleReturnDelete.RunWorkerAsync();

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

                dtpReturnDate.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
                dtpReturnDate.Properties.Mask.EditMask = "dd-MM-yyyy";
                dtpReturnDate.Properties.Mask.UseMaskAsDisplayFormat = true;
                dtpReturnDate.Properties.CharacterCasing = CharacterCasing.Upper;
                dtpReturnDate.EditValue = DateTime.Now;

                btnClear_Click(null, null);
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

                if (btnAdd.Text == "&Add")
                {
                    objSaleReturn = new SaleReturn();

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

                    drwNew["sale_return_id"] = Val.ToInt(0);
                    drwNew["return_detail_id"] = Val.ToInt(0);

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

                    dgvSaleReturnDetails.MoveLast();

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

                    DialogResult result = MessageBox.Show("Do you want to Add data?", "Confirmation", MessageBoxButtons.YesNoCancel);
                    if (result != DialogResult.Yes)
                    {
                        m_blnadd = false;
                        blnReturn = false;
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

                    objSaleReturn = new SaleReturn();

                    if (m_dtbSaleDetails.Select("item_id ='" + Val.ToInt(lueItem.EditValue) + "' AND color_id ='" + Val.ToInt(LueColor.EditValue) + "' AND size_id ='" + Val.ToInt(LueSize.EditValue) + "' AND unit_id ='" + Val.ToInt(LueUnit.EditValue) + "'").Length > 0)
                    {
                        for (int i = 0; i < m_dtbSaleDetails.Rows.Count; i++)
                        {
                            if (m_dtbSaleDetails.Select("return_detail_id ='" + m_return_detail_id + "' AND sr_no = '" + m_update_srno + "'").Length > 0)
                            {
                                if (m_dtbSaleDetails.Rows[m_update_srno - 1]["return_detail_id"].ToString() == m_return_detail_id.ToString())
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
                            if (m_dtbSaleDetails.Select("return_detail_id ='" + m_return_detail_id + "' AND sr_no = '" + m_update_srno + "'").Length > 0)
                            {
                                if (m_dtbSaleDetails.Rows[m_update_srno - 1]["return_detail_id"].ToString() == m_return_detail_id.ToString())
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
                    dgvSaleReturnDetails.MoveLast();
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
                    if (dgvSaleReturnDetails == null)
                    {
                        lstError.Add(new ListError(22, "Record"));
                        if (!blnFocus)
                        {
                            blnFocus = true;
                        }
                    }
                    //var result = DateTime.Compare(Convert.ToDateTime(dtpReturnDate.Text), DateTime.Today);
                    //if (result > 0)
                    //{
                    //    lstError.Add(new ListError(5, " Return Date Not Be Greater Than Today Date"));
                    //    if (!blnFocus)
                    //    {
                    //        blnFocus = true;
                    //        dtpReturnDate.Focus();
                    //    }
                    //}
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
                        lstError.Add(new ListError(12, "Rate"));
                        if (!blnFocus)
                        {
                            blnFocus = true;
                            txtSaleRate.Focus();
                        }
                    }
                    if (Val.ToDouble(txtSaleAmount.Text) == 0)
                    {
                        lstError.Add(new ListError(12, "Amount"));
                        if (!blnFocus)
                        {
                            blnFocus = true;
                            txtSaleAmount.Focus();
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
                CmbSaleType.SelectedIndex = -1;
                LueEmployee.EditValue = System.DBNull.Value;
                lueItem.EditValue = System.DBNull.Value;
                LueColor.EditValue = System.DBNull.Value;
                LueSize.EditValue = System.DBNull.Value;
                LueUnit.EditValue = System.DBNull.Value;
                txtSearchOrderNo.Text = string.Empty;
                luePurchaseFirm.EditValue = System.DBNull.Value;
                lueJangedLedger.EditValue = System.DBNull.Value;
                dtpReturnDate.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
                dtpReturnDate.Properties.Mask.EditMask = "dd-MM-yyyy";
                dtpReturnDate.Properties.Mask.UseMaskAsDisplayFormat = true;
                dtpReturnDate.Properties.CharacterCasing = CharacterCasing.Upper;
                dtpReturnDate.EditValue = DateTime.Now;
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
                //txtOrderNo.Enabled = true;
                txtTermDays.Text = "";
                btnAdd.Text = "&Add";
                LueEmployee.Focus();
                m_srno = 0;
                m_IsUpdate = true;
                lblMode.Text = "Add Mode";
                lueInvoiceNo.Text = string.Empty;
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
                m_dtbSaleDetails.Columns.Add("return_detail_id", typeof(int));
                m_dtbSaleDetails.Columns.Add("sale_return_id", typeof(int));
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

                grdSaleReturnDetails.DataSource = m_dtbSaleDetails;
                grdSaleReturnDetails.Refresh();
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
            objSaleReturn = new SaleReturn();
            bool blnReturn = true;
            DateTime datFromDate = DateTime.MinValue;
            DateTime datToDate = DateTime.MinValue;
            try
            {
                m_dtbDetails = objSaleReturn.GetData(Val.DBDate(dtpFromDate.Text), Val.DBDate(dtpToDate.Text), Val.ToInt64(txtSearchOrderNo.Text), Val.ToInt32(lueJangedLedger.EditValue));
                grdSaleReturnEntry.DataSource = m_dtbDetails;
                dgvSaleReturnEntry.BestFitColumns();
            }
            catch (Exception ex)
            {
                BLL.General.ShowErrors(ex);
                blnReturn = false;
            }
            finally
            {
                objSaleReturn = null;
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
                            dgvSaleReturnEntry.ExportToPdf(Filepath);
                            break;
                        case "xls":
                            dgvSaleReturnEntry.ExportToXls(Filepath);
                            break;
                        case "xlsx":
                            dgvSaleReturnEntry.ExportToXlsx(Filepath);
                            break;
                        case "rtf":
                            dgvSaleReturnEntry.ExportToRtf(Filepath);
                            break;
                        case "txt":
                            dgvSaleReturnEntry.ExportToText(Filepath);
                            break;
                        case "html":
                            dgvSaleReturnEntry.ExportToHtml(Filepath);
                            break;
                        case "csv":
                            dgvSaleReturnEntry.ExportToCsv(Filepath);
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
        private void backgroundWorker_SaleReturn_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.Default;
                Conn = new BeginTranConnection(true, false);

                SaleReturn_Property objSaleReturnProperty = new SaleReturn_Property();
                SaleReturn objSaleReturn = new SaleReturn();
                try
                {
                    IntRes = 0;

                    objSaleReturnProperty.sale_return_id = Val.ToInt(lblMode.Tag);
                    objSaleReturnProperty.invoice_id = Val.ToInt(lueInvoiceNo.EditValue);
                    objSaleReturnProperty.return_date = Val.DBDate(dtpReturnDate.Text);
                    objSaleReturnProperty.gst_id = Val.ToInt(lueGSTRate.EditValue);
                    objSaleReturnProperty.remarks = Val.ToString(txtRemark.Text);
                    objSaleReturnProperty.form_id = m_numForm_id;
                    objSaleReturnProperty.firm_id = Val.ToInt64(luePurchaseFirm.EditValue);
                    objSaleReturnProperty.ledger_id = Val.ToInt64(lueParty.EditValue);
                    objSaleReturnProperty.employee_id = Val.ToInt64(LueEmployee.EditValue);
                    objSaleReturnProperty.total_pcs = Val.ToDecimal(clmPcs.SummaryItem.SummaryValue);
                    objSaleReturnProperty.gross_amount = Math.Round(Val.ToDecimal(clmRSSaleAmount.SummaryItem.SummaryValue), 3);
                    objSaleReturnProperty.cgst_rate = Val.ToDecimal(txtCGSTPer.Text);
                    objSaleReturnProperty.cgst_amount = Val.ToDecimal(txtCGSTAmount.Text);
                    objSaleReturnProperty.sgst_rate = Val.ToDecimal(txtSGSTPer.Text);
                    objSaleReturnProperty.sgst_amount = Val.ToDecimal(txtSGSTAmount.Text);
                    objSaleReturnProperty.igst_rate = Val.ToDecimal(txtIGSTPer.Text);
                    objSaleReturnProperty.igst_amount = Val.ToDecimal(txtIGSTAmount.Text);
                    objSaleReturnProperty.discount_per = Val.ToDecimal(txtDiscountPer.Text);
                    objSaleReturnProperty.discount_amount = Val.ToDecimal(txtDiscountAmount.Text);
                    objSaleReturnProperty.round_of_amount = Val.ToDecimal(txtRoundOff.Text);
                    objSaleReturnProperty.shipping_amount = Val.ToDecimal(txtShippingCharge.Text);
                    objSaleReturnProperty.order_no = Val.ToString(txtOrderNo.Text);
                    objSaleReturnProperty.sale_type = Val.ToString(CmbSaleType.Text);
                    objSaleReturnProperty.weight = Val.ToDecimal(txtWeight.Text);
                    objSaleReturnProperty.pin_code = Val.ToInt64(txtPinCode.Text);
                    objSaleReturnProperty.shipping_address = Val.ToString(txtShippingAddress.Text);
                    objSaleReturnProperty.purchase_amount = Val.ToDecimal(clmRSPurhaseAmount.SummaryItem.SummaryValue);
                    objSaleReturnProperty.net_amount = Val.ToDecimal(txtNetAmount.Text);
                    objSaleReturnProperty.term_days = Val.ToInt32(txtTermDays.Text);
                    objSaleReturnProperty.due_date = Val.DBDate(DTPDueDate.Text);

                    objSaleReturnProperty = objSaleReturn.Save(objSaleReturnProperty, DLL.GlobalDec.EnumTran.Start, Conn);

                    Int64 NewmSaleReturnId = Val.ToInt64(objSaleReturnProperty.sale_return_id);

                    int IntCounter = 0;
                    int Count = 0;
                    int TotalCount = m_dtbSaleDetails.Rows.Count;

                    foreach (DataRow drw in m_dtbSaleDetails.Rows)
                    {
                        objSaleReturnProperty = new SaleReturn_Property();
                        objSaleReturnProperty.sale_return_id = Val.ToInt64(NewmSaleReturnId);
                        objSaleReturnProperty.return_detail_id = Val.ToInt64(drw["return_detail_id"]);
                        objSaleReturnProperty.sr_no = Val.ToInt(drw["sr_no"]);
                        objSaleReturnProperty.item_id = Val.ToInt64(drw["item_id"]);
                        objSaleReturnProperty.color_id = Val.ToInt64(drw["color_id"]);
                        objSaleReturnProperty.size_id = Val.ToInt64(drw["size_id"]);
                        objSaleReturnProperty.unit_id = Val.ToInt64(drw["unit_id"]);
                        objSaleReturnProperty.pcs = Val.ToDecimal(drw["pcs"]);
                        objSaleReturnProperty.sale_rate = Val.ToDecimal(drw["sale_rate"]);
                        objSaleReturnProperty.sale_amount = Val.ToDecimal(drw["Sale_amount"]);
                        objSaleReturnProperty.purchase_rate = Val.ToDecimal(drw["purchase_rate"]);
                        objSaleReturnProperty.purchase_amount = Val.ToDecimal(drw["purchase_amount"]);
                        objSaleReturnProperty.old_item_id = Val.ToInt64(drw["old_item_id"]);
                        objSaleReturnProperty.old_color_id = Val.ToInt64(drw["old_color_id"]);
                        objSaleReturnProperty.old_size_id = Val.ToInt64(drw["old_size_id"]);
                        objSaleReturnProperty.old_pcs = Val.ToDecimal(drw["old_pcs"]);
                        objSaleReturnProperty.flag = Val.ToInt(drw["flag"]);
                        objSaleReturnProperty.form_id = m_numForm_id;

                        IntRes = objSaleReturn.Save_Detail(objSaleReturnProperty, DLL.GlobalDec.EnumTran.Continue, Conn);

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
                    objSaleReturn = null;
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
        private void backgroundWorker_SaleReturn_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            try
            {
                panelProgress.Visible = false;
                if (IntRes > 0)
                {
                    if (Val.ToInt(lblMode.Tag) == 0)
                    {
                        Global.Confirm("Sale Return Data Save Successfully");
                        ClearDetails();
                        PopulateDetails();
                    }
                    else
                    {
                        Global.Confirm("Sale Return Data Update Successfully");
                        ClearDetails();
                        PopulateDetails();
                    }
                }
                else
                {
                    Global.Confirm("Error In Sale Return Data");
                    LueEmployee.Focus();
                }
            }
            catch (Exception ex)
            {
                Global.Message(ex.ToString());
                Global.Message(ex.InnerException.ToString());
            }
        }
        private void backgroundWorker_SaleReturnDelete_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Conn = new BeginTranConnection(true, false);

            SaleReturn_Property objSaleReturnProperty = new SaleReturn_Property();
            SaleReturn objSaleReturn = new SaleReturn();
            DataTable dtbMemoRecDelete = new DataTable();
            try
            {
                if (Val.ToInt(lblMode.Tag) != 0)
                {
                    IntRes = 0;
                    objSaleReturnProperty.sale_return_id = Val.ToInt64(lblMode.Tag);

                    int IntCounter = 0;
                    int Count = 0;
                    int FlagCount = 1;
                    int TotalCount = m_dtbSaleDetails.Rows.Count;
                    Int32 Flag = 0;
                    foreach (DataRow drw in m_dtbSaleDetails.Rows)
                    {
                        objSaleReturnProperty.return_detail_id = Val.ToInt64(drw["return_detail_id"]);
                        objSaleReturnProperty.item_id = Val.ToInt64(drw["item_id"]);
                        objSaleReturnProperty.color_id = Val.ToInt64(drw["color_id"]);
                        objSaleReturnProperty.size_id = Val.ToInt64(drw["size_id"]);
                        objSaleReturnProperty.pcs = Val.ToDecimal(drw["pcs"]);

                        if (FlagCount == TotalCount)
                        {
                            Flag = 1;
                        }
                        IntRes = objSaleReturn.Delete(objSaleReturnProperty, Flag, DLL.GlobalDec.EnumTran.Continue, Conn);

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
                    Global.Message("Sale Return ID not found");
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
                objSaleReturnProperty = null;
            }
        }
        private void backgroundWorker_SaleReturnDelete_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            try
            {
                panelProgress.Visible = false;
                if (IntRes > 0)
                {
                    if (Val.ToInt(lblMode.Tag) == 0)
                    {
                        Global.Confirm("Sale Return Data Delete Successfully");
                        ClearDetails();
                        btnSearch_Click(null, null);
                    }
                    else
                    {
                        Global.Confirm("Sale Return Data Delete Successfully");
                        ClearDetails();
                        btnSearch_Click(null, null);
                    }
                }
                else
                {
                    Global.Confirm("Error In Sale Return Data Delete");
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
            if (dtpReturnDate.Text.Length <= 0 || txtTermDays.Text == "")
            {
                txtTermDays.Text = "";
                DTPDueDate.EditValue = null;
            }
            else
            {
                DateTime Date = Convert.ToDateTime(dtpReturnDate.EditValue).AddDays(Val.ToDouble(txtTermDays.Text));
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
        private void FrmSaleReturn_Load(object sender, EventArgs e)
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
                    ttlbSaleReturn.SelectedTabPage = tblSaledetail;
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
                        DataRow Drow = dgvSaleReturnDetails.GetDataRow(e.RowHandle);
                        btnAdd.Text = "&Update";
                        LueColor.EditValue = Val.ToInt64(Drow["color_id"]);
                        LueSize.EditValue = Val.ToInt64(Drow["size_id"]);
                        LueUnit.EditValue = Val.ToInt64(Drow["unit_id"]);
                        lueItem.EditValue = Val.ToInt64(Drow["item_id"]);
                        txtPcs.Text = Val.ToString(Drow["pcs"]);
                        txtSaleRate.Text = Val.ToString(Drow["sale_rate"]);
                        txtSaleAmount.Text = Val.ToString(Drow["sale_amount"]);
                        txtPurchaseRate.Text = Val.ToString(Drow["purchase_rate"]);
                        txtPurchaseAmount.Text = Val.ToString(Drow["purchase_amount"]);
                        m_return_detail_id = Val.ToInt(Drow["return_detail_id"]);
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
        private void dgvSaleEntry_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                objSaleReturn = new SaleReturn();
                if (e.RowHandle >= 0)
                {
                    if (e.Clicks == 2)
                    {
                        m_blncheckevents = true;

                        DataRow Drow = dgvSaleReturnEntry.GetDataRow(e.RowHandle);
                        lblMode.Text = "Edit Mode";
                        lblMode.Tag = Val.ToInt64(Drow["sale_return_id"]);
                        dtpReturnDate.Text = Val.DBDate(Val.ToString(Drow["return_date"]));
                        txtOrderNo.Text = Val.ToString(Drow["order_no"]);
                        lueGSTRate.EditValue = Val.ToInt64(Drow["gst_id"]);
                        lueParty.EditValue = Val.ToInt64(Drow["ledger_id"]);
                        CmbSaleType.Text = Val.ToString(Drow["sale_type"]);
                        LueEmployee.EditValue = Val.ToInt64(Drow["employee_id"]);
                        luePurchaseFirm.EditValue = Val.ToInt64(Drow["firm_id"]);
                        txtRemark.Text = Val.ToString(Drow["remarks"]);
                        txtWeight.Text = Val.ToString(Drow["weight"]);
                        txtPinCode.Text = Val.ToString(Drow["pin_code"]);
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

                        m_dtbSaleDetails = objSaleReturn.GetDataDetails(Val.ToInt(lblMode.Tag));
                        grdSaleReturnDetails.DataSource = m_dtbSaleDetails;

                        ttlbSaleReturn.SelectedTabPage = tblSaledetail;
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
        private void CmbSaleType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable m_dtb = new DataTable();
                objSaleReturn = new SaleReturn();

                m_dtb = objSaleReturn.GetOrderData(CmbSaleType.Text, "AA");

                if (m_dtb.Rows.Count > 0)
                {
                    txtOrderNo.Text = Val.ToString(m_dtb.Rows[0]["order_no"]);
                }
            }
            catch (Exception ex)
            {
                BLL.General.ShowErrors(ex);
                return;
            }
        }
        private void dgvSaleReturnEntry_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (Val.ToInt(dgvSaleReturnEntry.GetRowCellValue(e.RowHandle, "flag_color")) == 1)
                {
                    e.Appearance.BackColor = Color.FromArgb(248, 210, 210);
                }
            }
        }
        private void lueParty_Validated(object sender, EventArgs e)
        {
            try
            {
                DataTable m_dtb = new DataTable();
                SaleReturn objSaleReturn = new SaleReturn();

                if (Val.ToInt64(lueParty.EditValue) != 0)
                {
                    m_dtb = objSaleReturn.GetInvoiceNo(Convert.ToInt32(lueParty.EditValue));

                    if (m_dtb.Rows.Count > 0)
                    {
                        lueInvoiceNo.Properties.DataSource = m_dtb;
                        lueInvoiceNo.Properties.ValueMember = "invoice_id";
                        lueInvoiceNo.Properties.DisplayMember = "order_no";
                        lueInvoiceNo.ClosePopup();
                    }
                }
            }
            catch (Exception ex)
            {
                BLL.General.ShowErrors(ex);
                return;
            }
        }

        private bool Validate()
        {
            bool blnFocus = false;
            List<ListError> lstError = new List<ListError>();
            try
            {
                if (m_dtbSaleDetails.Rows.Count == 0)
                {
                    lstError.Add(new ListError(22, "Record"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                    }
                }
                if (dgvSaleReturnDetails == null)
                {
                    lstError.Add(new ListError(22, "Record"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                    }
                }
                //var result = DateTime.Compare(Convert.ToDateTime(dtpReturnDate.Text), DateTime.Today);
                //if (result > 0)
                //{
                //    lstError.Add(new ListError(5, " Return Date Not Be Greater Than Today Date"));
                //    if (!blnFocus)
                //    {
                //        blnFocus = true;
                //        dtpReturnDate.Focus();
                //    }
                //}
            }
            catch (Exception ex)
            {
                lstError.Add(new ListError(ex));
            }
            return (!(BLL.General.ShowErrors(lstError)));
        }
        private void txtRemark_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (!Validate())
                {
                    btnSave.Enabled = true;
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

                FrmSaleReturnPaymentGivenSearch FrmSaleReturnPaymentGivenSearch = new FrmSaleReturnPaymentGivenSearch();
                FrmSaleReturnPaymentGivenSearch.FrmSaleReturn = this;
                FrmSaleReturnPaymentGivenSearch.DTab = DtPaymentGiven;
                FrmSaleReturnPaymentGivenSearch.ShowForm(this, Val.ToInt64(lueParty.EditValue), Val.ToDecimal(txtNetAmount.Text));

                //FrmSaleReturnPaymentGiven objSaleReturnPaymentGiven = new FrmSaleReturnPaymentGiven();
                //Assembly frmAssembly = Assembly.LoadFile(Application.ExecutablePath);

                //foreach (Type type in frmAssembly.GetTypes())
                //{
                //    string type1 = type.Name.ToString().ToUpper();
                //    if (type.BaseType == typeof(DevExpress.XtraEditors.XtraForm))
                //    {
                //        if (type.Name.ToString().ToUpper() == "FRMSALERETURNPAYMENTGIVEN")
                //        {
                //            XtraForm frmShow = (XtraForm)frmAssembly.CreateInstance(type.ToString());
                //            frmShow.MdiParent = Global.gMainFormRef;

                //            frmShow.GetType().GetMethod("ShowForm_SaleReturnPaymentNew").Invoke(frmShow, new object[] { });
                //            break;
                //        }
                //    }
                //}
            }
        }
        public void GetPaymentGivenData(string Entry_date, string Remark, Int64 Voucher_No, Int64 Cash_Bank, Int64 Ledger_ID, DataTable Payment_Given_Data)
        {
            try
            {
                IntRes = 0;
                SaleReturnPaymentGiven_Property SaleReturnPaymentGiven_Property = new SaleReturnPaymentGiven_Property();
                SaleReturnPaymentGiven objSaleReturnPaymentGiven = new SaleReturnPaymentGiven();
                Int64 Union_ID = 0;
                Conn = new BeginTranConnection(true, false);

                SaleReturn_Property objSaleReturnProperty = new SaleReturn_Property();
                SaleReturn objSaleReturn = new SaleReturn();
                try
                {
                    IntRes = 0;

                    objSaleReturnProperty.sale_return_id = Val.ToInt(lblMode.Tag);
                    objSaleReturnProperty.invoice_id = Val.ToInt(lueInvoiceNo.EditValue);
                    objSaleReturnProperty.return_date = Val.DBDate(dtpReturnDate.Text);
                    objSaleReturnProperty.gst_id = Val.ToInt(lueGSTRate.EditValue);
                    objSaleReturnProperty.remarks = Val.ToString(txtRemark.Text);
                    objSaleReturnProperty.form_id = m_numForm_id;
                    objSaleReturnProperty.firm_id = Val.ToInt64(luePurchaseFirm.EditValue);
                    objSaleReturnProperty.ledger_id = Val.ToInt64(lueParty.EditValue);
                    objSaleReturnProperty.employee_id = Val.ToInt64(LueEmployee.EditValue);
                    objSaleReturnProperty.total_pcs = Val.ToDecimal(clmPcs.SummaryItem.SummaryValue);
                    objSaleReturnProperty.gross_amount = Math.Round(Val.ToDecimal(clmRSSaleAmount.SummaryItem.SummaryValue), 3);
                    objSaleReturnProperty.cgst_rate = Val.ToDecimal(txtCGSTPer.Text);
                    objSaleReturnProperty.cgst_amount = Val.ToDecimal(txtCGSTAmount.Text);
                    objSaleReturnProperty.sgst_rate = Val.ToDecimal(txtSGSTPer.Text);
                    objSaleReturnProperty.sgst_amount = Val.ToDecimal(txtSGSTAmount.Text);
                    objSaleReturnProperty.igst_rate = Val.ToDecimal(txtIGSTPer.Text);
                    objSaleReturnProperty.igst_amount = Val.ToDecimal(txtIGSTAmount.Text);
                    objSaleReturnProperty.discount_per = Val.ToDecimal(txtDiscountPer.Text);
                    objSaleReturnProperty.discount_amount = Val.ToDecimal(txtDiscountAmount.Text);
                    objSaleReturnProperty.round_of_amount = Val.ToDecimal(txtRoundOff.Text);
                    objSaleReturnProperty.shipping_amount = Val.ToDecimal(txtShippingCharge.Text);
                    objSaleReturnProperty.order_no = Val.ToString(txtOrderNo.Text);
                    objSaleReturnProperty.sale_type = Val.ToString(CmbSaleType.Text);
                    objSaleReturnProperty.weight = Val.ToDecimal(txtWeight.Text);
                    objSaleReturnProperty.pin_code = Val.ToInt64(txtPinCode.Text);
                    objSaleReturnProperty.shipping_address = Val.ToString(txtShippingAddress.Text);
                    objSaleReturnProperty.purchase_amount = Val.ToDecimal(clmRSPurhaseAmount.SummaryItem.SummaryValue);
                    objSaleReturnProperty.net_amount = Val.ToDecimal(txtNetAmount.Text);
                    objSaleReturnProperty.term_days = Val.ToInt32(txtTermDays.Text);
                    objSaleReturnProperty.due_date = Val.DBDate(DTPDueDate.Text);

                    objSaleReturnProperty = objSaleReturn.Save(objSaleReturnProperty, DLL.GlobalDec.EnumTran.Start, Conn);

                    Int64 NewmSaleReturnId = Val.ToInt64(objSaleReturnProperty.sale_return_id);

                    int IntCounter = 0;
                    int Count = 0;
                    int TotalCount = m_dtbSaleDetails.Rows.Count;

                    foreach (DataRow drw in m_dtbSaleDetails.Rows)
                    {
                        objSaleReturnProperty = new SaleReturn_Property();
                        objSaleReturnProperty.sale_return_id = Val.ToInt64(NewmSaleReturnId);
                        objSaleReturnProperty.return_detail_id = Val.ToInt64(drw["return_detail_id"]);
                        objSaleReturnProperty.sr_no = Val.ToInt(drw["sr_no"]);
                        objSaleReturnProperty.item_id = Val.ToInt64(drw["item_id"]);
                        objSaleReturnProperty.color_id = Val.ToInt64(drw["color_id"]);
                        objSaleReturnProperty.size_id = Val.ToInt64(drw["size_id"]);
                        objSaleReturnProperty.unit_id = Val.ToInt64(drw["unit_id"]);
                        objSaleReturnProperty.pcs = Val.ToDecimal(drw["pcs"]);
                        objSaleReturnProperty.sale_rate = Val.ToDecimal(drw["sale_rate"]);
                        objSaleReturnProperty.sale_amount = Val.ToDecimal(drw["Sale_amount"]);
                        objSaleReturnProperty.purchase_rate = Val.ToDecimal(drw["purchase_rate"]);
                        objSaleReturnProperty.purchase_amount = Val.ToDecimal(drw["purchase_amount"]);
                        objSaleReturnProperty.old_item_id = Val.ToInt64(drw["old_item_id"]);
                        objSaleReturnProperty.old_color_id = Val.ToInt64(drw["old_color_id"]);
                        objSaleReturnProperty.old_size_id = Val.ToInt64(drw["old_size_id"]);
                        objSaleReturnProperty.old_pcs = Val.ToDecimal(drw["old_pcs"]);
                        objSaleReturnProperty.flag = Val.ToInt(drw["flag"]);
                        objSaleReturnProperty.form_id = m_numForm_id;

                        IntRes = objSaleReturn.Save_Detail(objSaleReturnProperty, DLL.GlobalDec.EnumTran.Continue, Conn);

                        Count++;
                        IntCounter++;
                        IntRes++;
                        SetControlPropertyValue(lblProgressCount, "Text", Count.ToString() + "" + "/" + "" + TotalCount.ToString() + " Completed....");
                    }

                    for (int i = 0; i < Payment_Given_Data.Rows.Count; i++)
                    {
                        if (Val.ToString(Payment_Given_Data.Rows[i]["method"]) != "")
                        {
                            SaleReturnPaymentGiven_Property.payment_id = Val.ToInt64(Payment_Given_Data.Rows[i]["payment_id"]);
                            SaleReturnPaymentGiven_Property.union_id = Val.ToInt64(Union_ID);
                            SaleReturnPaymentGiven_Property.payment_date = Val.DBDate(dtpReturnDate.Text);
                            SaleReturnPaymentGiven_Property.sr_no = Val.ToInt32(Payment_Given_Data.Rows[i]["sr_no"]);
                            SaleReturnPaymentGiven_Property.method = Val.ToString(Payment_Given_Data.Rows[i]["method"]);
                            SaleReturnPaymentGiven_Property.invoice_id = Val.ToInt64(Payment_Given_Data.Rows[i]["invoice_id"]);
                            SaleReturnPaymentGiven_Property.sale_return_id = Val.ToInt64(NewmSaleReturnId);
                            SaleReturnPaymentGiven_Property.reference = Val.ToString(Payment_Given_Data.Rows[i]["order_no"]);
                            SaleReturnPaymentGiven_Property.ledger_id = Val.ToInt64(lueParty.EditValue);
                            SaleReturnPaymentGiven_Property.credit_amount = Val.ToDecimal(Payment_Given_Data.Rows[i]["amount"]);
                            SaleReturnPaymentGiven_Property.debit_amount = Val.ToDecimal(Payment_Given_Data.Rows[i]["amount"]);
                            SaleReturnPaymentGiven_Property.remarks = Val.ToString(txtRemark.Text);
                            SaleReturnPaymentGiven_Property.form_id = m_numForm_id;
                            SaleReturnPaymentGiven_Property.voucher_no = Val.ToInt64(0);

                            SaleReturnPaymentGiven_Property.against_ledger_id = Val.ToInt64(Cash_Bank);
                            SaleReturnPaymentGiven_Property = objSaleReturnPaymentGiven.PaymentGiven_Save(SaleReturnPaymentGiven_Property, DLL.GlobalDec.EnumTran.Continue, Conn);

                            Union_ID = SaleReturnPaymentGiven_Property.union_id;
                        }
                    }
                    Conn.Inter1.Commit();

                    if (IntRes == -1)
                    {
                        Global.Confirm("Error In Sale Return");
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
                finally
                {
                    objSaleReturn = null;
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
    }
}