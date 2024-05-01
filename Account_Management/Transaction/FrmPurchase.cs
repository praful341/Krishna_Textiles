using Account_Management.Class;
using Account_Management.Master;
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
    public partial class FrmPurchase : DevExpress.XtraEditors.XtraForm
    {
        #region Data Member
        BLL.BeginTranConnection Conn;
        BLL.FormEvents objBOFormEvents;
        BLL.FormPer ObjPer;
        BLL.Validation Val;

        Control _NextEnteredControl;
        private List<Control> _tabControls;
        public delegate void SetControlValueCallback(Control oControl, string propName, object propValue);

        Purchase objPurchase = new Purchase();
        UserAuthentication objUserAuthentication = new UserAuthentication();

        DataTable DtControlSettings = new DataTable();
        DataTable m_dtbPurchaseDetails = new DataTable();
        DataTable m_dtbDetails = new DataTable();
        DataSet m_dtbVoucher_JangedDetail = new DataSet();

        int m_purchase_detail_id;
        int m_srno;
        int m_update_srno;
        int m_numForm_id;
        int IntRes;
        bool m_blnadd;
        bool m_blnsave;
        bool m_blncheckevents;
        bool m_IsUpdate;
        string Form_Clear = string.Empty;

        #endregion

        #region Constructor
        public FrmPurchase()
        {
            InitializeComponent();

            objBOFormEvents = new BLL.FormEvents();
            ObjPer = new BLL.FormPer();
            Val = new BLL.Validation();

            _NextEnteredControl = new Control();
            _tabControls = new List<Control>();

            objPurchase = new Purchase();
            objUserAuthentication = new UserAuthentication();

            DtControlSettings = new DataTable();
            m_dtbDetails = new DataTable();

            m_purchase_detail_id = 0;
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
        public void ShowForm_New(Int64 Purchase_ID)
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

            objPurchase = new Purchase();
            DataTable DTab_Purchase = objPurchase.Purchase_Invocie_Popup_GetData(Val.ToInt64(Purchase_ID));

            if (DTab_Purchase.Rows.Count > 0)
            {
                lblMode.Text = "Edit Mode";
                lblMode.Tag = Val.ToInt64(DTab_Purchase.Rows[0]["purchase_id"]);

                m_dtbPurchaseDetails = objPurchase.GetDataDetails(Val.ToInt(lblMode.Tag));
                grdPurchaseDetails.DataSource = m_dtbPurchaseDetails;

                lblJanged_ID.Text = Val.ToString(DTab_Purchase.Rows[0]["janged_id"]);
                dtpPurchaseDate.Text = Val.DBDate(Val.ToString(DTab_Purchase.Rows[0]["janged_date"]));
                txtVoucherNo.Text = Val.ToString(DTab_Purchase.Rows[0]["voucher_no"]);
                lueGSTRate.EditValue = Val.ToInt64(DTab_Purchase.Rows[0]["gst_id"]);
                lueParty.EditValue = Val.ToInt64(DTab_Purchase.Rows[0]["ledger_id"]);
                luePurchaseFirm.EditValue = Val.ToInt64(DTab_Purchase.Rows[0]["firm_id"]);

                txtRemark.Text = Val.ToString(DTab_Purchase.Rows[0]["remarks"]);
                txtPurchaseBill.Text = Val.ToString(DTab_Purchase.Rows[0]["purchase_bill_no"]);
                txtRoundOff.Text = Val.ToString(DTab_Purchase.Rows[0]["round_of_amount"]);
                txtDiscountPer.Text = Val.ToString(DTab_Purchase.Rows[0]["discount_per"]);
                txtDiscountAmount.Text = Val.ToString(DTab_Purchase.Rows[0]["discount_amount"]);
                txtCGSTPer.Text = Val.ToString(DTab_Purchase.Rows[0]["cgst_per"]);
                txtCGSTAmount.Text = Val.ToString(DTab_Purchase.Rows[0]["cgst_amount"]);
                txtSGSTPer.Text = Val.ToString(DTab_Purchase.Rows[0]["sgst_per"]);
                txtSGSTAmount.Text = Val.ToString(DTab_Purchase.Rows[0]["sgst_amount"]);
                txtIGSTPer.Text = Val.ToString(DTab_Purchase.Rows[0]["igst_per"]);
                txtIGSTAmount.Text = Val.ToString(DTab_Purchase.Rows[0]["igst_amount"]);
                txtNetAmount.Text = Val.ToString(DTab_Purchase.Rows[0]["net_amount"]);
                txtTermDays.Text = Val.ToString(DTab_Purchase.Rows[0]["term_days"]);
                DTPDueDate.Text = Val.ToString(DTab_Purchase.Rows[0]["due_date"]);

                ttlbPurchaseInvoice.SelectedTabPage = tblPurchasedetail;
                dtpPurchaseDate.Focus();
                txtVoucherNo.Enabled = false;
                m_IsUpdate = true;
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
        private void AttachFormEvents()
        {
            objBOFormEvents.CurForm = this;
            objBOFormEvents.FormKeyPress = true;
            objBOFormEvents.FormKeyDown = true;
            objBOFormEvents.FormResize = true;
            objBOFormEvents.FormClosing = true;
            objBOFormEvents.ObjToDispose.Add(objPurchase);
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
                txtRate.Text = string.Empty;
                txtAmount.Text = string.Empty;
                m_blncheckevents = false;
                txtDiscountPer_EditValueChanged(null, null);
                m_blncheckevents = true;
                txtPurchaseBill.Enabled = false;
                lueGSTRate.Enabled = false;
                lueParty.Enabled = false;
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
            backgroundWorker_PurchaseEntry.RunWorkerAsync();

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
        private void txtRate_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtAmount.Text = string.Format("{0:0.00}", Val.ToDecimal(txtPcs.Text) * Val.ToDecimal(txtRate.Text));
            }
            catch (Exception ex)
            {
                General.ShowErrors(ex.ToString());
                return;
            }
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
            backgroundWorker_PurchaseDelete.RunWorkerAsync();

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
                if (Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue) != 0)
                {
                    decimal Shipping_Charge = Math.Round((Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue) + Val.ToDecimal(txtCGSTAmount.Text) + Val.ToDecimal(txtSGSTAmount.Text) + Val.ToDecimal(txtIGSTAmount.Text)) - (Val.ToDecimal(txtDiscountAmount.Text)) + Val.ToDecimal(txtRoundOff.Text), 2);
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
                decimal GrossAmount = Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue);
                decimal DiscountAmount = Val.ToDecimal(txtDiscountAmount.Text);

                decimal CGST_amount = Math.Round(Val.ToDecimal(GrossAmount - DiscountAmount) * Val.ToDecimal(txtCGSTPer.Text) / 100, 2);
                txtCGSTAmount.Text = CGST_amount.ToString();

                decimal Net_Amount = Math.Round((Val.ToDecimal(GrossAmount) + Val.ToDecimal(txtCGSTAmount.Text) + Val.ToDecimal(txtSGSTAmount.Text) + Val.ToDecimal(txtIGSTAmount.Text) - Val.ToDecimal(txtDiscountAmount.Text)) + Val.ToDecimal(txtRoundOff.Text), 2);
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
                decimal GrossAmount = Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue);
                decimal DiscountAmount = Val.ToDecimal(txtDiscountAmount.Text);

                decimal SGST_amount = Math.Round(Val.ToDecimal(GrossAmount - DiscountAmount) * Val.ToDecimal(txtSGSTPer.Text) / 100, 2);
                txtSGSTAmount.Text = SGST_amount.ToString();
                decimal Net_Amount = Math.Round((Val.ToDecimal(GrossAmount) + Val.ToDecimal(txtCGSTAmount.Text) + Val.ToDecimal(txtSGSTAmount.Text) + Val.ToDecimal(txtIGSTAmount.Text) - Val.ToDecimal(txtDiscountAmount.Text)) + Val.ToDecimal(txtRoundOff.Text), 2);
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
                decimal GrossAmount = Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue);
                decimal DiscountAmount = Val.ToDecimal(txtDiscountAmount.Text);

                decimal IGST_amount = Math.Round(Val.ToDecimal(GrossAmount - DiscountAmount) * Val.ToDecimal(txtIGSTPer.Text) / 100, 2);
                txtIGSTAmount.Text = IGST_amount.ToString();
                decimal Net_Amount = Math.Round((Val.ToDecimal(GrossAmount) + Val.ToDecimal(txtCGSTAmount.Text) + Val.ToDecimal(txtSGSTAmount.Text) + Val.ToDecimal(txtIGSTAmount.Text) - Val.ToDecimal(txtDiscountAmount.Text)) + Val.ToDecimal(txtRoundOff.Text), 2);
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
            //e.Graphics.DrawLine(pen, 0, 62, 1500, 62);
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
                //Global.LOOKUPParty(lueBilledToParty);
                //Global.LOOKUPParty(lueShippedToParty);
                //Global.LOOKUPParty(lueReferance);

                //Global.LOOKUPBroker(lueBroker);
                //Global.LOOKUPDeliveryType(lueDeliveryType);
                //Global.LOOKUPParty(lueBillToParty);

                Global.LOOKUPGSTRate(lueGSTRate);
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

                dtpPurchaseDate.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
                dtpPurchaseDate.Properties.Mask.EditMask = "dd-MM-yyyy";
                dtpPurchaseDate.Properties.Mask.UseMaskAsDisplayFormat = true;
                dtpPurchaseDate.Properties.CharacterCasing = CharacterCasing.Upper;
                dtpPurchaseDate.EditValue = DateTime.Now;

                btnClear_Click(null, null);
                btnSearch_Click(null, null);
                dtpPurchaseDate.Focus();
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
                    objPurchase = new Purchase();

                    DataRow[] dr = m_dtbPurchaseDetails.Select("item_id = " + Val.ToInt(lueItem.EditValue) + " AND color_id = " + Val.ToInt(LueColor.EditValue) + " AND size_id = " + Val.ToInt(LueSize.EditValue) + " AND unit_id = " + Val.ToInt(LueUnit.EditValue));

                    if (dr.Count() == 1)
                    {
                        Global.Message("Record already exists in grid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lueItem.Focus();
                        blnReturn = false;
                        return blnReturn;
                    }
                    DataRow drwNew = m_dtbPurchaseDetails.NewRow();
                    decimal numRate = Val.ToDecimal(txtRate.Text);
                    decimal numAmount = Val.ToDecimal(txtAmount.Text);
                    decimal numPcs = Val.ToDecimal(txtPcs.Text);

                    drwNew["purchase_id"] = Val.ToInt(0);
                    drwNew["purchase_detail_id"] = Val.ToInt(0);

                    drwNew["janged_id"] = Val.ToInt(lblJanged_ID.Text);

                    drwNew["color_id"] = Val.ToInt(LueColor.EditValue);
                    drwNew["color_name"] = Val.ToString(LueColor.Text);

                    drwNew["item_id"] = Val.ToInt(lueItem.EditValue);
                    drwNew["item_name"] = Val.ToString(lueItem.Text);

                    drwNew["size_id"] = Val.ToInt(LueSize.EditValue);
                    drwNew["size_name"] = Val.ToString(LueSize.Text);

                    drwNew["unit_id"] = Val.ToInt(LueUnit.EditValue);
                    drwNew["unit_name"] = Val.ToString(LueUnit.Text);

                    drwNew["pcs"] = numPcs;
                    drwNew["rate"] = Val.ToDecimal(txtRate.Text);
                    drwNew["amount"] = Math.Round(Val.ToDecimal(txtPcs.Text) * Val.ToDecimal(txtRate.Text), 2);
                    drwNew["old_pcs"] = Val.ToDecimal(0);
                    drwNew["flag"] = Val.ToInt(0);
                    m_srno = m_srno + 1;
                    drwNew["sr_no"] = Val.ToInt(m_srno);

                    m_dtbPurchaseDetails.Rows.Add(drwNew);

                    dgvPurchaseDetails.MoveLast();

                    if (Val.ToDecimal(txtDiscountAmount.Text) > 0)
                    {
                        decimal CGST_amount = Math.Round((Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue) - Val.ToDecimal(txtDiscountAmount.Text)) * Val.ToDecimal(txtCGSTPer.Text) / 100, 2);
                        txtCGSTAmount.Text = CGST_amount.ToString();
                        decimal SGST_amount = Math.Round((Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue) - Val.ToDecimal(txtDiscountAmount.Text)) * Val.ToDecimal(txtSGSTPer.Text) / 100, 2);
                        txtSGSTAmount.Text = SGST_amount.ToString();
                        decimal IGST_amount = Math.Round((Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue) - Val.ToDecimal(txtDiscountAmount.Text)) * Val.ToDecimal(txtIGSTPer.Text) / 100, 2);
                        txtIGSTAmount.Text = IGST_amount.ToString();
                    }
                    else
                    {
                        decimal CGST_amount = Math.Round(Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue) * Val.ToDecimal(txtCGSTPer.Text) / 100, 2);
                        txtCGSTAmount.Text = CGST_amount.ToString();
                        decimal SGST_amount = Math.Round(Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue) * Val.ToDecimal(txtSGSTPer.Text) / 100, 2);
                        txtSGSTAmount.Text = SGST_amount.ToString();
                        decimal IGST_amount = Math.Round(Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue) * Val.ToDecimal(txtIGSTPer.Text) / 100, 2);
                        txtIGSTAmount.Text = IGST_amount.ToString();
                    }

                    //decimal CGST_amount = Math.Round(Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue) * Val.ToDecimal(txtCGSTPer.Text) / 100, 2);
                    //txtCGSTAmount.Text = CGST_amount.ToString();
                    //decimal SGST_amount = Math.Round(Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue) * Val.ToDecimal(txtSGSTPer.Text) / 100, 2);
                    //txtSGSTAmount.Text = SGST_amount.ToString();
                    //decimal IGST_amount = Math.Round(Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue) * Val.ToDecimal(txtIGSTPer.Text) / 100, 2);
                    //txtIGSTAmount.Text = IGST_amount.ToString();

                    //decimal Shipping_Charge = Math.Round((Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue) + Val.ToDecimal(txtInterestAmount.Text) + Val.ToDecimal(txtCGSTAmount.Text) + Val.ToDecimal(txtSGSTAmount.Text) + Val.ToDecimal(txtIGSTAmount.Text)) - (Val.ToDecimal(txtDiscountAmount.Text)) + Val.ToDecimal(txtShippingCharge.Text), 0);
                    //txtNetAmount.Text = Shipping_Charge.ToString();

                    decimal Net_Amount = Math.Round((Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue) + Val.ToDecimal(txtCGSTAmount.Text) + Val.ToDecimal(txtSGSTAmount.Text) + Val.ToDecimal(txtIGSTAmount.Text) - Val.ToDecimal(txtDiscountAmount.Text)) + Val.ToDecimal(txtRoundOff.Text), 2);
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

                    objPurchase = new Purchase();

                    if (m_dtbPurchaseDetails.Select("item_id ='" + Val.ToInt(lueItem.EditValue) + "' AND color_id ='" + Val.ToInt(LueColor.EditValue) + "' AND size_id ='" + Val.ToInt(LueSize.EditValue) + "' AND unit_id ='" + Val.ToInt(LueUnit.EditValue) + "'").Length > 0)
                    {
                        for (int i = 0; i < m_dtbPurchaseDetails.Rows.Count; i++)
                        {
                            if (m_dtbPurchaseDetails.Select("purchase_detail_id ='" + m_purchase_detail_id + "' AND sr_no = '" + m_update_srno + "'").Length > 0)
                            {
                                if (m_dtbPurchaseDetails.Rows[m_update_srno - 1]["purchase_detail_id"].ToString() == m_purchase_detail_id.ToString())
                                {
                                    m_dtbPurchaseDetails.Rows[m_update_srno - 1]["pcs"] = Val.ToDecimal(txtPcs.Text);
                                    m_dtbPurchaseDetails.Rows[m_update_srno - 1]["rate"] = Val.ToDecimal(txtRate.Text);
                                    m_dtbPurchaseDetails.Rows[m_update_srno - 1]["flag"] = 1;
                                    m_dtbPurchaseDetails.Rows[m_update_srno - 1]["amount"] = Math.Round(Val.ToDecimal(txtPcs.Text) * Val.ToDecimal(txtRate.Text), 3);

                                    m_dtbPurchaseDetails.Rows[m_update_srno - 1]["item_id"] = Val.ToInt(lueItem.EditValue);
                                    m_dtbPurchaseDetails.Rows[m_update_srno - 1]["item_name"] = Val.ToString(lueItem.Text);

                                    m_dtbPurchaseDetails.Rows[m_update_srno - 1]["color_id"] = Val.ToInt(LueColor.EditValue);
                                    m_dtbPurchaseDetails.Rows[m_update_srno - 1]["color_name"] = Val.ToString(LueColor.Text);

                                    m_dtbPurchaseDetails.Rows[m_update_srno - 1]["size_id"] = Val.ToInt(LueSize.EditValue);
                                    m_dtbPurchaseDetails.Rows[m_update_srno - 1]["size_name"] = Val.ToString(LueSize.Text);

                                    m_dtbPurchaseDetails.Rows[m_update_srno - 1]["unit_id"] = Val.ToInt(LueUnit.EditValue);
                                    m_dtbPurchaseDetails.Rows[m_update_srno - 1]["unit_name"] = Val.ToString(LueUnit.Text);

                                    break;
                                }
                            }
                        }
                        btnAdd.Text = "&Add";
                    }
                    else
                    {
                        for (int i = 0; i < m_dtbPurchaseDetails.Rows.Count; i++)
                        {
                            if (m_dtbPurchaseDetails.Select("purchase_detail_id ='" + m_purchase_detail_id + "' AND sr_no = '" + m_update_srno + "'").Length > 0)
                            {
                                if (m_dtbPurchaseDetails.Rows[m_update_srno - 1]["purchase_detail_id"].ToString() == m_purchase_detail_id.ToString())
                                {
                                    m_dtbPurchaseDetails.Rows[m_update_srno - 1]["pcs"] = Val.ToDecimal(txtPcs.Text);
                                    m_dtbPurchaseDetails.Rows[m_update_srno - 1]["rate"] = Val.ToDecimal(txtRate.Text);
                                    m_dtbPurchaseDetails.Rows[m_update_srno - 1]["flag"] = 1;
                                    m_dtbPurchaseDetails.Rows[m_update_srno - 1]["item_id"] = Val.ToInt(lueItem.EditValue);
                                    m_dtbPurchaseDetails.Rows[m_update_srno - 1]["color_id"] = Val.ToInt(LueColor.EditValue);
                                    m_dtbPurchaseDetails.Rows[m_update_srno - 1]["size_id"] = Val.ToInt(LueSize.EditValue);
                                    m_dtbPurchaseDetails.Rows[m_update_srno - 1]["unit_id"] = Val.ToInt(LueUnit.EditValue);
                                    m_dtbPurchaseDetails.Rows[m_update_srno - 1]["item_name"] = Val.ToString(lueItem.Text);
                                    m_dtbPurchaseDetails.Rows[m_update_srno - 1]["color_name"] = Val.ToString(LueColor.Text);
                                    m_dtbPurchaseDetails.Rows[m_update_srno - 1]["size_name"] = Val.ToString(LueSize.Text);
                                    m_dtbPurchaseDetails.Rows[m_update_srno - 1]["unit_name"] = Val.ToString(LueUnit.Text);

                                    m_dtbPurchaseDetails.Rows[m_update_srno - 1]["amount"] = Math.Round(Val.ToDecimal(txtPcs.Text) * Val.ToDecimal(txtRate.Text), 3);
                                }
                            }
                        }
                        btnAdd.Text = "&Add";
                    }
                    dgvPurchaseDetails.MoveLast();
                    m_IsUpdate = false;

                    if (Val.ToDecimal(txtDiscountAmount.Text) > 0)
                    {
                        decimal CGST_amount = Math.Round((Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue) - Val.ToDecimal(txtDiscountAmount.Text)) * Val.ToDecimal(txtCGSTPer.Text) / 100, 2);
                        txtCGSTAmount.Text = CGST_amount.ToString();
                        decimal SGST_amount = Math.Round((Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue) - Val.ToDecimal(txtDiscountAmount.Text)) * Val.ToDecimal(txtSGSTPer.Text) / 100, 2);
                        txtSGSTAmount.Text = SGST_amount.ToString();
                        decimal IGST_amount = Math.Round((Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue) - Val.ToDecimal(txtDiscountAmount.Text)) * Val.ToDecimal(txtIGSTPer.Text) / 100, 2);
                        txtIGSTAmount.Text = IGST_amount.ToString();
                    }
                    else
                    {
                        decimal CGST_amount = Math.Round(Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue) * Val.ToDecimal(txtCGSTPer.Text) / 100, 2);
                        txtCGSTAmount.Text = CGST_amount.ToString();
                        decimal SGST_amount = Math.Round(Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue) * Val.ToDecimal(txtSGSTPer.Text) / 100, 2);
                        txtSGSTAmount.Text = SGST_amount.ToString();
                        decimal IGST_amount = Math.Round(Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue) * Val.ToDecimal(txtIGSTPer.Text) / 100, 2);
                        txtIGSTAmount.Text = IGST_amount.ToString();
                    }
                    decimal Net_Amount = Math.Round((Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue) + Val.ToDecimal(txtCGSTAmount.Text) + Val.ToDecimal(txtSGSTAmount.Text) + Val.ToDecimal(txtIGSTAmount.Text) - Val.ToDecimal(txtDiscountAmount.Text)) + Val.ToDecimal(txtRoundOff.Text), 2);
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
                    if (m_dtbPurchaseDetails.Rows.Count == 0)
                    {
                        lstError.Add(new ListError(22, "Record"));
                        if (!blnFocus)
                        {
                            blnFocus = true;
                        }
                    }
                    if (dgvPurchaseDetails == null)
                    {
                        lstError.Add(new ListError(22, "Record"));
                        if (!blnFocus)
                        {
                            blnFocus = true;
                        }
                    }
                    //var result = DateTime.Compare(Convert.ToDateTime(dtpPurchaseDate.Text), DateTime.Today);
                    //if (result > 0)
                    //{
                    //    lstError.Add(new ListError(5, " Purchase Date Not Be Greater Than Today Date"));
                    //    if (!blnFocus)
                    //    {
                    //        blnFocus = true;
                    //        dtpPurchaseDate.Focus();
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

                    if (Val.ToDouble(txtRate.Text) == 0)
                    {
                        lstError.Add(new ListError(12, "Rate"));
                        if (!blnFocus)
                        {
                            blnFocus = true;
                            txtRate.Focus();
                        }
                    }

                    if (Val.ToDouble(txtAmount.Text) == 0)
                    {
                        lstError.Add(new ListError(12, "Amount"));
                        if (!blnFocus)
                        {
                            blnFocus = true;
                            txtAmount.Focus();
                        }
                    }
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

                txtVoucherNo.Text = string.Empty;
                lueItem.EditValue = System.DBNull.Value;
                LueColor.EditValue = System.DBNull.Value;
                LueSize.EditValue = System.DBNull.Value;
                LueUnit.EditValue = System.DBNull.Value;
                luePurchaseFirm.EditValue = System.DBNull.Value;
                txtSearchVoucherNo.Text = string.Empty;
                lueJangedLedger.EditValue = System.DBNull.Value;
                dtpPurchaseDate.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
                dtpPurchaseDate.Properties.Mask.EditMask = "dd-MM-yyyy";
                dtpPurchaseDate.Properties.Mask.UseMaskAsDisplayFormat = true;
                dtpPurchaseDate.Properties.CharacterCasing = CharacterCasing.Upper;
                dtpPurchaseDate.EditValue = DateTime.Now;
                lblJanged_ID.Text = "0";
                txtPcs.Text = string.Empty;
                txtRate.Text = string.Empty;
                txtAmount.Text = string.Empty;
                txtDiscountPer.Text = string.Empty;
                txtDiscountAmount.Text = string.Empty;
                txtRoundOff.Text = string.Empty;
                txtNetAmount.Text = string.Empty;
                txtCGSTPer.Text = string.Empty;
                txtCGSTAmount.Text = string.Empty;
                txtSGSTPer.Text = string.Empty;
                txtSGSTAmount.Text = string.Empty;
                txtIGSTPer.Text = string.Empty;
                txtIGSTAmount.Text = string.Empty;
                txtRemark.Text = string.Empty;
                txtPurchaseBill.Text = string.Empty;
                txtVoucherNo.Enabled = true;
                txtTermDays.Text = "";
                btnAdd.Text = "&Add";
                dtpPurchaseDate.Focus();
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
                if (m_dtbPurchaseDetails.Rows.Count > 0)
                    m_dtbPurchaseDetails.Rows.Clear();

                m_dtbPurchaseDetails = new DataTable();

                m_dtbPurchaseDetails.Columns.Add("sr_no", typeof(int));
                m_dtbPurchaseDetails.Columns.Add("purchase_detail_id", typeof(int));
                m_dtbPurchaseDetails.Columns.Add("purchase_id", typeof(int));
                m_dtbPurchaseDetails.Columns.Add("janged_detail_id", typeof(int));
                m_dtbPurchaseDetails.Columns.Add("janged_id", typeof(int));
                m_dtbPurchaseDetails.Columns.Add("item_id", typeof(int));
                m_dtbPurchaseDetails.Columns.Add("item_name", typeof(string));
                m_dtbPurchaseDetails.Columns.Add("color_id", typeof(int));
                m_dtbPurchaseDetails.Columns.Add("color_name", typeof(string));
                m_dtbPurchaseDetails.Columns.Add("size_id", typeof(int));
                m_dtbPurchaseDetails.Columns.Add("size_name", typeof(string));
                m_dtbPurchaseDetails.Columns.Add("unit_id", typeof(int));
                m_dtbPurchaseDetails.Columns.Add("unit_name", typeof(string));
                m_dtbPurchaseDetails.Columns.Add("pcs", typeof(decimal)).DefaultValue = 0;
                m_dtbPurchaseDetails.Columns.Add("rate", typeof(decimal)).DefaultValue = 0;
                m_dtbPurchaseDetails.Columns.Add("amount", typeof(decimal)).DefaultValue = 0;
                m_dtbPurchaseDetails.Columns.Add("remarks", typeof(string));
                m_dtbPurchaseDetails.Columns.Add("old_pcs", typeof(decimal)).DefaultValue = 0;
                m_dtbPurchaseDetails.Columns.Add("flag", typeof(int)).DefaultValue = 0;
                m_dtbPurchaseDetails.Columns.Add("old_item_id", typeof(int));
                m_dtbPurchaseDetails.Columns.Add("old_color_id", typeof(int));
                m_dtbPurchaseDetails.Columns.Add("old_size_id", typeof(int));
                m_dtbPurchaseDetails.Columns.Add("old_unit_id", typeof(int));
                m_dtbPurchaseDetails.Columns.Add("old_item_name", typeof(string));
                m_dtbPurchaseDetails.Columns.Add("old_color_name", typeof(string));
                m_dtbPurchaseDetails.Columns.Add("old_size_name", typeof(string));
                m_dtbPurchaseDetails.Columns.Add("old_unit_name", typeof(string));

                grdPurchaseDetails.DataSource = m_dtbPurchaseDetails;
                grdPurchaseDetails.Refresh();
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
            objPurchase = new Purchase();
            bool blnReturn = true;
            DateTime datFromDate = DateTime.MinValue;
            DateTime datToDate = DateTime.MinValue;
            try
            {
                m_dtbDetails = objPurchase.GetData(Val.DBDate(dtpFromDate.Text), Val.DBDate(dtpToDate.Text), Val.ToInt64(txtSearchVoucherNo.Text), Val.ToInt32(lueJangedLedger.EditValue));

                grdPurchaseEntry.DataSource = m_dtbDetails;
                dgvPurchaseEntry.BestFitColumns();
            }
            catch (Exception ex)
            {
                BLL.General.ShowErrors(ex);
                blnReturn = false;
            }
            finally
            {
                objPurchase = null;
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
                            dgvPurchaseEntry.ExportToPdf(Filepath);
                            break;
                        case "xls":
                            dgvPurchaseEntry.ExportToXls(Filepath);
                            break;
                        case "xlsx":
                            dgvPurchaseEntry.ExportToXlsx(Filepath);
                            break;
                        case "rtf":
                            dgvPurchaseEntry.ExportToRtf(Filepath);
                            break;
                        case "txt":
                            dgvPurchaseEntry.ExportToText(Filepath);
                            break;
                        case "html":
                            dgvPurchaseEntry.ExportToHtml(Filepath);
                            break;
                        case "csv":
                            dgvPurchaseEntry.ExportToCsv(Filepath);
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
        private void dgvPurchaseDetails_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                if (e.RowHandle >= 0)
                {
                    if (e.Clicks == 2)
                    {
                        DataRow Drow = dgvPurchaseDetails.GetDataRow(e.RowHandle);
                        btnAdd.Text = "&Update";
                        //lueSieveName.Text = Val.ToString(Drow["sieve_name"]);
                        LueColor.EditValue = Val.ToInt64(Drow["color_id"]);
                        LueSize.EditValue = Val.ToInt64(Drow["size_id"]);
                        LueUnit.EditValue = Val.ToInt64(Drow["unit_id"]);
                        lueItem.EditValue = Val.ToInt64(Drow["item_id"]);
                        txtPcs.Text = Val.ToString(Drow["pcs"]);
                        txtRate.Text = Val.ToString(Drow["rate"]);
                        txtAmount.Text = Val.ToString(Drow["amount"]);

                        //m_numcarat = Val.ToDecimal(Drow["carat"]);
                        m_purchase_detail_id = Val.ToInt(Drow["purchase_detail_id"]);
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
        private void dgvPurchaseDetails_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            try
            {
                //if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName == "rate")
                //{
                //    if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize)
                //        e.TotalValue = m_numSummDetRate;
                //}
            }
            catch (Exception ex)
            {
                BLL.General.ShowErrors(ex);
            }
        }
        private void FrmPurchase_Load(object sender, EventArgs e)
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
                    ttlbPurchaseInvoice.SelectedTabPage = tblPurchasedetail;
                }
            }
            catch (Exception ex)
            {
                Global.Message(ex.ToString());
                return;
            }
        }
        private void backgroundWorker_PurchaseEntry_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.Default;
                Conn = new BeginTranConnection(true, false);

                Purchase_Property objPurchaseProperty = new Purchase_Property();
                Purchase objPurchase = new Purchase();
                try
                {
                    IntRes = 0;

                    objPurchaseProperty.purchase_id = Val.ToInt(lblMode.Tag);
                    objPurchaseProperty.janged_id = Val.ToInt(lblJanged_ID.Text);
                    objPurchaseProperty.voucher_no = Val.ToInt32(txtVoucherNo.Text);
                    objPurchaseProperty.purchase_date = Val.DBDate(dtpPurchaseDate.Text);
                    objPurchaseProperty.gst_id = Val.ToInt(lueGSTRate.EditValue);
                    objPurchaseProperty.purchase_bill_no = Val.ToString(txtPurchaseBill.Text);
                    objPurchaseProperty.remarks = Val.ToString(txtRemark.Text);
                    objPurchaseProperty.firm_id = Val.ToInt64(luePurchaseFirm.EditValue);

                    objPurchaseProperty.form_id = m_numForm_id;

                    objPurchaseProperty.ledger_id = Val.ToInt(lueParty.EditValue);

                    objPurchaseProperty.total_pcs = Val.ToDecimal(clmPcs.SummaryItem.SummaryValue);

                    objPurchaseProperty.gross_amount = Math.Round(Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue), 3);

                    objPurchaseProperty.cgst_rate = Val.ToDecimal(txtCGSTPer.Text);
                    objPurchaseProperty.cgst_amount = Val.ToDecimal(txtCGSTAmount.Text);
                    objPurchaseProperty.sgst_rate = Val.ToDecimal(txtSGSTPer.Text);
                    objPurchaseProperty.sgst_amount = Val.ToDecimal(txtSGSTAmount.Text);
                    objPurchaseProperty.igst_rate = Val.ToDecimal(txtIGSTPer.Text);
                    objPurchaseProperty.igst_amount = Val.ToDecimal(txtIGSTAmount.Text);

                    objPurchaseProperty.discount_per = Val.ToDecimal(txtDiscountPer.Text);
                    objPurchaseProperty.discount_amount = Val.ToDecimal(txtDiscountAmount.Text);
                    objPurchaseProperty.round_of_amount = Val.ToDecimal(txtRoundOff.Text);

                    objPurchaseProperty.net_amount = Val.ToDecimal(txtNetAmount.Text);

                    objPurchaseProperty.term_days = Val.ToInt32(txtTermDays.Text);
                    objPurchaseProperty.due_date = Val.DBDate(DTPDueDate.Text);

                    objPurchaseProperty = objPurchase.Save(objPurchaseProperty, DLL.GlobalDec.EnumTran.Start, Conn);

                    Int64 NewmPurchaseid = Val.ToInt64(objPurchaseProperty.purchase_id);

                    int IntCounter = 0;
                    int Count = 0;
                    int TotalCount = m_dtbPurchaseDetails.Rows.Count;

                    foreach (DataRow drw in m_dtbPurchaseDetails.Rows)
                    {
                        objPurchaseProperty = new Purchase_Property();
                        objPurchaseProperty.purchase_id = Val.ToInt64(NewmPurchaseid);
                        objPurchaseProperty.janged_id = Val.ToInt64(lblJanged_ID.Text);
                        objPurchaseProperty.purchase_detail_id = Val.ToInt64(drw["purchase_detail_id"]);
                        //objPurchaseProperty.janged_detail_id = Val.ToInt64(drw["janged_detail_id"]);
                        objPurchaseProperty.sr_no = Val.ToInt(drw["sr_no"]);
                        objPurchaseProperty.item_id = Val.ToInt64(drw["item_id"]);
                        objPurchaseProperty.color_id = Val.ToInt64(drw["color_id"]);
                        objPurchaseProperty.size_id = Val.ToInt64(drw["size_id"]);
                        objPurchaseProperty.unit_id = Val.ToInt64(drw["unit_id"]);
                        objPurchaseProperty.pcs = Val.ToDecimal(drw["pcs"]);
                        objPurchaseProperty.rate = Val.ToDecimal(drw["rate"]);
                        objPurchaseProperty.amount = Val.ToDecimal(drw["amount"]);

                        objPurchaseProperty.old_item_id = Val.ToInt64(drw["old_item_id"]);
                        objPurchaseProperty.old_color_id = Val.ToInt64(drw["old_color_id"]);
                        objPurchaseProperty.old_size_id = Val.ToInt64(drw["old_size_id"]);

                        objPurchaseProperty.old_pcs = Val.ToDecimal(drw["old_pcs"]);
                        objPurchaseProperty.flag = Val.ToInt(drw["flag"]);

                        IntRes = objPurchase.Save_Detail(objPurchaseProperty, DLL.GlobalDec.EnumTran.Continue, Conn);

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
                    objPurchaseProperty = null;
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

        private void backgroundWorker_PurchaseEntry_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            try
            {
                panelProgress.Visible = false;
                if (IntRes > 0)
                {
                    if (Val.ToInt(lblMode.Tag) == 0)
                    {
                        Global.Confirm("Purchase Data Save Successfully");
                        ClearDetails();
                        PopulateDetails();
                    }
                    else
                    {
                        Global.Confirm("Purchase Data Update Successfully");
                        ClearDetails();
                        PopulateDetails();
                    }
                }
                else
                {
                    Global.Confirm("Error In Purchase Data");
                    dtpPurchaseDate.Focus();
                }
            }
            catch (Exception ex)
            {
                Global.Message(ex.ToString());
                Global.Message(ex.InnerException.ToString());
            }
        }
        private void backgroundWorker_PurchaseDelete_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Conn = new BeginTranConnection(true, false);

            Purchase_Property objPurchaseProperty = new Purchase_Property();
            Purchase objPurchase = new Purchase();
            DataTable dtbMemoRecDelete = new DataTable();
            try
            {
                if (Val.ToInt(lblMode.Tag) != 0)
                {
                    IntRes = 0;
                    objPurchaseProperty.purchase_id = Val.ToInt64(lblMode.Tag);

                    int IntCounter = 0;
                    int Count = 0;
                    int FlagCount = 1;
                    int TotalCount = m_dtbPurchaseDetails.Rows.Count;
                    Int32 Flag = 0;
                    foreach (DataRow drw in m_dtbPurchaseDetails.Rows)
                    {
                        objPurchaseProperty.purchase_detail_id = Val.ToInt64(drw["purchase_detail_id"]);
                        objPurchaseProperty.item_id = Val.ToInt64(drw["item_id"]);
                        objPurchaseProperty.color_id = Val.ToInt64(drw["color_id"]);
                        objPurchaseProperty.size_id = Val.ToInt64(drw["size_id"]);
                        objPurchaseProperty.pcs = Val.ToDecimal(drw["pcs"]);

                        if (FlagCount == TotalCount)
                        {
                            Flag = 1;
                        }

                        IntRes = objPurchase.Delete(objPurchaseProperty, Flag, DLL.GlobalDec.EnumTran.Continue, Conn);

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
                    Global.Message("Purchase ID not found");
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
                objPurchaseProperty = null;
            }
        }

        private void backgroundWorker_PurchaseDelete_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            try
            {
                panelProgress.Visible = false;
                if (IntRes > 0)
                {
                    if (Val.ToInt(lblMode.Tag) == 0)
                    {
                        Global.Confirm("Purchase Data Delete Successfully");
                        ClearDetails();
                        btnSearch_Click(null, null);
                    }
                    else
                    {
                        Global.Confirm("Purchase Data Delete Successfully");
                        ClearDetails();
                        btnSearch_Click(null, null);
                    }
                }
                else
                {
                    Global.Confirm("Error In Purchase Data Delete");
                    dtpPurchaseDate.Focus();
                }
            }
            catch (Exception ex)
            {
                Global.Message(ex.ToString());
                Global.Message(ex.InnerException.ToString());
            }
        }
        private void dgvPurchaseEntry_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                objPurchase = new Purchase();
                if (e.RowHandle >= 0)
                {
                    if (e.Clicks == 2)
                    {
                        m_blncheckevents = true;

                        DataRow Drow = dgvPurchaseEntry.GetDataRow(e.RowHandle);
                        lblMode.Text = "Edit Mode";
                        lblMode.Tag = Val.ToInt64(Drow["purchase_id"]);

                        lblJanged_ID.Text = Val.ToString(Drow["janged_id"]);
                        dtpPurchaseDate.Text = Val.DBDate(Val.ToString(Drow["janged_date"]));
                        txtVoucherNo.Text = Val.ToString(Drow["voucher_no"]);
                        lueGSTRate.EditValue = Val.ToInt64(Drow["gst_id"]);
                        lueParty.EditValue = Val.ToInt64(Drow["ledger_id"]);
                        luePurchaseFirm.EditValue = Val.ToInt64(Drow["firm_id"]);

                        txtRemark.Text = Val.ToString(Drow["remarks"]);
                        txtPurchaseBill.Text = Val.ToString(Drow["purchase_bill_no"]);
                        txtRoundOff.Text = Val.ToString(Drow["round_of_amount"]);
                        txtDiscountPer.Text = Val.ToString(Drow["discount_per"]);
                        txtDiscountAmount.Text = Val.ToString(Drow["discount_amount"]);
                        txtCGSTPer.Text = Val.ToString(Drow["cgst_per"]);
                        txtCGSTAmount.Text = Val.ToString(Drow["cgst_amount"]);
                        txtSGSTPer.Text = Val.ToString(Drow["sgst_per"]);
                        txtSGSTAmount.Text = Val.ToString(Drow["sgst_amount"]);
                        txtIGSTPer.Text = Val.ToString(Drow["igst_per"]);
                        txtIGSTAmount.Text = Val.ToString(Drow["igst_amount"]);
                        txtNetAmount.Text = Val.ToString(Drow["net_amount"]);
                        txtTermDays.Text = Val.ToString(Drow["term_days"]);
                        DTPDueDate.Text = Val.ToString(Drow["due_date"]);

                        m_dtbPurchaseDetails = objPurchase.GetDataDetails(Val.ToInt(lblMode.Tag));
                        grdPurchaseDetails.DataSource = m_dtbPurchaseDetails;

                        ttlbPurchaseInvoice.SelectedTabPage = tblPurchasedetail;
                        dtpPurchaseDate.Focus();
                        txtVoucherNo.Enabled = false;
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
        private void dgvPurchaseEntry_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (Val.ToInt(dgvPurchaseEntry.GetRowCellValue(e.RowHandle, "flag_color")) == 1)
                {
                    e.Appearance.BackColor = Color.FromArgb(248, 210, 210);
                }
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
                        decimal CGST_amount = Math.Round((Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue) - Val.ToDecimal(txtDiscountAmount.Text)) * Val.ToDecimal(txtCGSTPer.Text) / 100, 2);
                        txtCGSTAmount.Text = CGST_amount.ToString();
                        decimal SGST_amount = Math.Round((Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue) - Val.ToDecimal(txtDiscountAmount.Text)) * Val.ToDecimal(txtSGSTPer.Text) / 100, 2);
                        txtSGSTAmount.Text = SGST_amount.ToString();
                        decimal IGST_amount = Math.Round((Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue) - Val.ToDecimal(txtDiscountAmount.Text)) * Val.ToDecimal(txtIGSTPer.Text) / 100, 2);
                        txtIGSTAmount.Text = IGST_amount.ToString();

                        decimal Dis_Per = Math.Round(Val.ToDecimal(txtDiscountAmount.Text) * 100 / Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue), 2);
                        txtDiscountPer.Text = Dis_Per.ToString();
                        decimal Net_Amount = Math.Round((Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue) + Val.ToDecimal(txtCGSTAmount.Text) + Val.ToDecimal(txtSGSTAmount.Text) + Val.ToDecimal(txtIGSTAmount.Text) - Val.ToDecimal(txtDiscountAmount.Text)) + Val.ToDecimal(txtRoundOff.Text), 2);
                        txtNetAmount.Text = Net_Amount.ToString();
                    }
                    else
                    {
                        decimal CGST_amount = Math.Round(Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue) * Val.ToDecimal(txtCGSTPer.Text) / 100, 2);
                        txtCGSTAmount.Text = CGST_amount.ToString();
                        decimal SGST_amount = Math.Round(Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue) * Val.ToDecimal(txtSGSTPer.Text) / 100, 2);
                        txtSGSTAmount.Text = SGST_amount.ToString();
                        decimal IGST_amount = Math.Round(Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue) * Val.ToDecimal(txtIGSTPer.Text) / 100, 2);
                        txtIGSTAmount.Text = IGST_amount.ToString();

                        txtDiscountPer.Text = "0";
                        decimal Net_Amount = Math.Round((Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue) + Val.ToDecimal(txtCGSTAmount.Text) + Val.ToDecimal(txtSGSTAmount.Text) + Val.ToDecimal(txtIGSTAmount.Text) - Val.ToDecimal(txtDiscountAmount.Text)) + Val.ToDecimal(txtRoundOff.Text), 2);
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
        private void txtVoucherNo_Validated(object sender, EventArgs e)
        {
            if (txtVoucherNo.Text != "")
            {
                objPurchase = new Purchase();

                //DataTable DTab_Purchase_Vch_No = objPurchase.Purchase_Voucher_No_GetData(Val.ToInt64(txtVoucherNo.Text)); 

                m_dtbVoucher_JangedDetail = objPurchase.Janged_Voucher_GetData(Val.ToInt64(txtVoucherNo.Text));
                if (m_dtbVoucher_JangedDetail.Tables[2].Rows[0]["voucher_no"].ToString() == "0")
                {
                    if (m_dtbVoucher_JangedDetail.Tables[0].Rows.Count > 0)
                    {
                        lblMode.Text = "Add Mode";
                        lblMode.Tag = Val.ToInt32(0);

                        lblJanged_ID.Text = Val.ToString(m_dtbVoucher_JangedDetail.Tables[0].Rows[0]["janged_id"]);
                        txtPurchaseBill.Text = Val.ToString(m_dtbVoucher_JangedDetail.Tables[0].Rows[0]["purchase_bill_no"]);
                        lueGSTRate.EditValue = Val.ToInt64(m_dtbVoucher_JangedDetail.Tables[0].Rows[0]["gst_id"]);
                        lueParty.EditValue = Val.ToInt64(m_dtbVoucher_JangedDetail.Tables[0].Rows[0]["ledger_id"]);
                        txtRemark.Text = Val.ToString(m_dtbVoucher_JangedDetail.Tables[0].Rows[0]["remarks"]);
                        txtTermDays.Text = Val.ToString(m_dtbVoucher_JangedDetail.Tables[0].Rows[0]["term_days"]);
                        DTPDueDate.Text = Val.ToString(m_dtbVoucher_JangedDetail.Tables[0].Rows[0]["due_date"]);
                        luePurchaseFirm.EditValue = Val.ToInt64(m_dtbVoucher_JangedDetail.Tables[0].Rows[0]["firm_id"]);

                        grdPurchaseDetails.DataSource = m_dtbVoucher_JangedDetail.Tables[1];
                        m_dtbPurchaseDetails = m_dtbVoucher_JangedDetail.Tables[1];

                        txtCGSTPer.Text = Val.ToString(m_dtbVoucher_JangedDetail.Tables[0].Rows[0]["cgst_per"]);
                        txtCGSTAmount.Text = Val.ToString(m_dtbVoucher_JangedDetail.Tables[0].Rows[0]["cgst_amount"]);
                        txtSGSTPer.Text = Val.ToString(m_dtbVoucher_JangedDetail.Tables[0].Rows[0]["sgst_per"]);
                        txtSGSTAmount.Text = Val.ToString(m_dtbVoucher_JangedDetail.Tables[0].Rows[0]["sgst_amount"]);
                        txtIGSTPer.Text = Val.ToString(m_dtbVoucher_JangedDetail.Tables[0].Rows[0]["igst_per"]);
                        txtIGSTAmount.Text = Val.ToString(m_dtbVoucher_JangedDetail.Tables[0].Rows[0]["igst_amount"]);
                        txtDiscountPer.Text = Val.ToString(m_dtbVoucher_JangedDetail.Tables[0].Rows[0]["discount_per"]);
                        txtDiscountAmount.Text = Val.ToString(m_dtbVoucher_JangedDetail.Tables[0].Rows[0]["discount_amount"]);
                        txtRoundOff.Text = Val.ToString(m_dtbVoucher_JangedDetail.Tables[0].Rows[0]["round_of_amount"]);
                        txtNetAmount.Text = Val.ToString(m_dtbVoucher_JangedDetail.Tables[0].Rows[0]["net_amount"]);
                    }
                    else
                    {
                        Global.Message("Voucher No Data Not Found");
                        btnClear_Click(null, null);
                        txtPurchaseBill.Focus();
                        return;
                    }
                }
                else
                {
                    Global.Message("Voucher No Already Purchase.");
                    btnClear_Click(null, null);
                    txtPurchaseBill.Focus();
                    return;
                }
            }
            else
            {
                txtPurchaseBill.Focus();
            }
        }
        private void txtTermDays_EditValueChanged(object sender, EventArgs e)
        {
            if (dtpPurchaseDate.Text.Length <= 0 || txtTermDays.Text == "")
            {
                txtTermDays.Text = "";
                DTPDueDate.EditValue = null;
            }
            else
            {
                DateTime Date = Convert.ToDateTime(dtpPurchaseDate.EditValue).AddDays(Val.ToDouble(txtTermDays.Text));
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
    }
}