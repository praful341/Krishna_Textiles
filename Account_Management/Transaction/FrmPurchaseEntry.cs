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
    public partial class FrmPurchaseEntry : DevExpress.XtraEditors.XtraForm
    {
        #region Data Member
        BLL.BeginTranConnection Conn;
        BLL.FormEvents objBOFormEvents;
        BLL.FormPer ObjPer;
        BLL.Validation Val;

        Control _NextEnteredControl;
        private List<Control> _tabControls;
        public delegate void SetControlValueCallback(Control oControl, string propName, object propValue);

        PurchaseEntry objPurchaseEntry = new PurchaseEntry();
        UserAuthentication objUserAuthentication = new UserAuthentication();

        DataTable DtControlSettings = new DataTable();
        DataTable m_dtbJangedDetails = new DataTable();
        DataTable m_dtbDetails = new DataTable();
        DataSet m_dtbVoucher_JangedDetail = new DataSet();

        int m_janged_detail_id;
        int m_srno;
        int m_update_srno;
        int m_numForm_id;
        int IntRes;

        decimal m_numSummDetRate;

        bool m_blnadd;
        bool m_blnsave;
        bool m_blncheckevents;
        bool m_IsUpdate;

        #endregion

        #region Constructor
        public FrmPurchaseEntry()
        {
            InitializeComponent();

            objBOFormEvents = new BLL.FormEvents();
            ObjPer = new BLL.FormPer();
            Val = new BLL.Validation();

            _NextEnteredControl = new Control();
            _tabControls = new List<Control>();

            objPurchaseEntry = new PurchaseEntry();
            objUserAuthentication = new UserAuthentication();

            DtControlSettings = new DataTable();
            m_dtbDetails = new DataTable();

            m_janged_detail_id = 0;
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
            this.KeyPreview = true;

            TabControlsToList(this.Controls);
            _tabControls = _tabControls.OrderBy(x => x.TabIndex).ToList();

            // End for Dynamic Setting By Praful On 01022020

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
            objBOFormEvents.ObjToDispose.Add(objPurchaseEntry);
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
            backgroundWorker_JangedEntry.RunWorkerAsync();

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
            backgroundWorker_JangedDelete.RunWorkerAsync();

            btnDelete.Enabled = true;
        }
        private void txtDiscountPer_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (!m_blncheckevents)
                {
                    decimal Dis_amount = Math.Round(Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue) * Val.ToDecimal(txtDiscountPer.Text) / 100, 0);
                    txtDiscountAmount.Text = Dis_amount.ToString();
                    decimal Net_Amount = Math.Round((Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue) + Val.ToDecimal(txtCGSTAmount.Text) + Val.ToDecimal(txtSGSTAmount.Text) + Val.ToDecimal(txtIGSTAmount.Text) - Val.ToDecimal(txtDiscountAmount.Text)) + Val.ToDecimal(txtRoundOff.Text), 0);
                    txtNetAmount.Text = Net_Amount.ToString();
                }
            }
            catch (Exception ex)
            {
                General.ShowErrors(ex.ToString());
                return;
            }
        }
        private void txtShippingCharge_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue) != 0)
                {
                    decimal Shipping_Charge = Math.Round((Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue) + Val.ToDecimal(txtCGSTAmount.Text) + Val.ToDecimal(txtSGSTAmount.Text) + Val.ToDecimal(txtIGSTAmount.Text)) - (Val.ToDecimal(txtDiscountAmount.Text)) + Val.ToDecimal(txtRoundOff.Text), 0);
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

                decimal CGST_amount = Math.Round(Val.ToDecimal(GrossAmount - DiscountAmount) * Val.ToDecimal(txtCGSTPer.Text) / 100, 0);
                txtCGSTAmount.Text = CGST_amount.ToString();

                decimal Net_Amount = Math.Round((Val.ToDecimal(GrossAmount) + Val.ToDecimal(txtCGSTAmount.Text) + Val.ToDecimal(txtSGSTAmount.Text) + Val.ToDecimal(txtIGSTAmount.Text) - Val.ToDecimal(txtDiscountAmount.Text)) + Val.ToDecimal(txtRoundOff.Text), 0);
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

                decimal SGST_amount = Math.Round(Val.ToDecimal(GrossAmount - DiscountAmount) * Val.ToDecimal(txtSGSTPer.Text) / 100, 0);
                txtSGSTAmount.Text = SGST_amount.ToString();
                decimal Net_Amount = Math.Round((Val.ToDecimal(GrossAmount) + Val.ToDecimal(txtCGSTAmount.Text) + Val.ToDecimal(txtSGSTAmount.Text) + Val.ToDecimal(txtIGSTAmount.Text) - Val.ToDecimal(txtDiscountAmount.Text)) + Val.ToDecimal(txtRoundOff.Text), 0);
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

                decimal IGST_amount = Math.Round(Val.ToDecimal(GrossAmount - DiscountAmount) * Val.ToDecimal(txtIGSTPer.Text) / 100, 0);
                txtIGSTAmount.Text = IGST_amount.ToString();
                decimal Net_Amount = Math.Round((Val.ToDecimal(GrossAmount) + Val.ToDecimal(txtCGSTAmount.Text) + Val.ToDecimal(txtSGSTAmount.Text) + Val.ToDecimal(txtIGSTAmount.Text) - Val.ToDecimal(txtDiscountAmount.Text)) + Val.ToDecimal(txtRoundOff.Text), 0);
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
            Pen pen = new Pen(Color.FromArgb(255, 191, 219, 255), 2);
            e.Graphics.DrawLine(pen, 0, 85, 1500, 85);
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
                Global.LOOKUPLedger(lueParty);
                Global.LOOKUPItem(lueItem);
                Global.LOOKUPColor(LueColor);
                Global.LOOKUPSize(LueSize);
                Global.LOOKUPUnit(LueUnit);

                dtpFromDate.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
                dtpFromDate.Properties.Mask.EditMask = "dd/MMM/yyyy";
                dtpFromDate.Properties.Mask.UseMaskAsDisplayFormat = true;
                dtpFromDate.Properties.CharacterCasing = CharacterCasing.Upper;
                dtpFromDate.EditValue = DateTime.Now;

                dtpToDate.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
                dtpToDate.Properties.Mask.EditMask = "dd/MMM/yyyy";
                dtpToDate.Properties.Mask.UseMaskAsDisplayFormat = true;
                dtpToDate.Properties.CharacterCasing = CharacterCasing.Upper;
                dtpToDate.EditValue = DateTime.Now;

                dtpJangedDate.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
                dtpJangedDate.Properties.Mask.EditMask = "dd/MMM/yyyy";
                dtpJangedDate.Properties.Mask.UseMaskAsDisplayFormat = true;
                dtpJangedDate.Properties.CharacterCasing = CharacterCasing.Upper;
                dtpJangedDate.EditValue = DateTime.Now;

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
                    objPurchaseEntry = new PurchaseEntry();
                    //m_dtbStockCarat = objSaleInvoice.GetStockCarat(GlobalDec.gEmployeeProperty.company_id, GlobalDec.gEmployeeProperty.branch_id, GlobalDec.gEmployeeProperty.location_id, GlobalDec.gEmployeeProperty.department_id, Val.ToInt(lueAssortName.EditValue), Val.ToInt(lueSieveName.EditValue));                    
                    //if (m_dtbStockCarat.Rows.Count > 0)
                    //{
                    //    numStockCarat = Val.ToDecimal(m_dtbStockCarat.Rows[0]["stock_carat"]);
                    //}

                    DataRow[] dr = m_dtbJangedDetails.Select("item_id = " + Val.ToInt(lueItem.EditValue) + " AND color_id = " + Val.ToInt(LueColor.EditValue) + " AND size_id = " + Val.ToInt(LueSize.EditValue));

                    if (dr.Count() == 1)
                    {
                        Global.Message("Record already exists in grid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lueItem.Focus();
                        blnReturn = false;
                        return blnReturn;
                    }
                    DataRow drwNew = m_dtbJangedDetails.NewRow();
                    decimal numRate = Val.ToDecimal(txtRate.Text);
                    decimal numAmount = Val.ToDecimal(txtAmount.Text);
                    int numPcs = Val.ToInt(txtPcs.Text);

                    drwNew["janged_id"] = Val.ToInt(0);
                    drwNew["janged_detail_id"] = Val.ToInt(0);

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
                    drwNew["old_pcs"] = Val.ToDecimal(0);
                    drwNew["amount"] = Math.Round(Val.ToDecimal(txtPcs.Text) * Val.ToDecimal(txtRate.Text), 2);
                    drwNew["old_pcs"] = Val.ToDecimal(0);
                    drwNew["flag"] = Val.ToInt(0);
                    m_srno = m_srno + 1;
                    drwNew["sr_no"] = Val.ToInt(m_srno);

                    m_dtbJangedDetails.Rows.Add(drwNew);

                    dgvJangedDetails.MoveLast();

                    decimal CGST_amount = Math.Round(Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue) * Val.ToDecimal(txtCGSTPer.Text) / 100, 0);
                    txtCGSTAmount.Text = CGST_amount.ToString();
                    decimal SGST_amount = Math.Round(Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue) * Val.ToDecimal(txtSGSTPer.Text) / 100, 0);
                    txtSGSTAmount.Text = SGST_amount.ToString();
                    decimal IGST_amount = Math.Round(Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue) * Val.ToDecimal(txtIGSTPer.Text) / 100, 0);
                    txtIGSTAmount.Text = IGST_amount.ToString();

                    //decimal Shipping_Charge = Math.Round((Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue) + Val.ToDecimal(txtInterestAmount.Text) + Val.ToDecimal(txtCGSTAmount.Text) + Val.ToDecimal(txtSGSTAmount.Text) + Val.ToDecimal(txtIGSTAmount.Text)) - (Val.ToDecimal(txtDiscountAmount.Text)) + Val.ToDecimal(txtShippingCharge.Text), 0);
                    //txtNetAmount.Text = Shipping_Charge.ToString();
                }
                else if (btnAdd.Text == "&Update")
                {
                    if (!m_IsUpdate)
                    {
                        Global.Message("You can't update this record", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        blnReturn = false;
                        return blnReturn;
                    }

                    objPurchaseEntry = new PurchaseEntry();

                    if (m_dtbJangedDetails.Select("item_id ='" + Val.ToInt(lueItem.EditValue) + "' AND color_id ='" + Val.ToInt(LueColor.EditValue) + "' AND size_id ='" + Val.ToInt(LueSize.EditValue) + "'").Length > 0)
                    {
                        for (int i = 0; i < m_dtbJangedDetails.Rows.Count; i++)
                        {
                            if (m_dtbJangedDetails.Select("janged_detail_id ='" + m_janged_detail_id + "' AND sr_no = '" + m_update_srno + "'").Length > 0)
                            {
                                if (m_dtbJangedDetails.Rows[m_update_srno - 1]["janged_detail_id"].ToString() == m_janged_detail_id.ToString())
                                {
                                    m_dtbJangedDetails.Rows[m_update_srno - 1]["pcs"] = Val.ToInt(txtPcs.Text);
                                    m_dtbJangedDetails.Rows[m_update_srno - 1]["rate"] = Val.ToDecimal(txtRate.Text);
                                    m_dtbJangedDetails.Rows[m_update_srno - 1]["flag"] = 1;
                                    m_dtbJangedDetails.Rows[m_update_srno - 1]["amount"] = Math.Round(Val.ToDecimal(txtPcs.Text) * Val.ToDecimal(txtRate.Text), 3);

                                    m_dtbJangedDetails.Rows[m_update_srno - 1]["item_id"] = Val.ToInt(lueItem.EditValue);
                                    m_dtbJangedDetails.Rows[m_update_srno - 1]["item_name"] = Val.ToString(lueItem.Text);

                                    m_dtbJangedDetails.Rows[m_update_srno - 1]["color_id"] = Val.ToInt(LueColor.EditValue);
                                    m_dtbJangedDetails.Rows[m_update_srno - 1]["color_name"] = Val.ToString(LueColor.Text);

                                    m_dtbJangedDetails.Rows[m_update_srno - 1]["size_id"] = Val.ToInt(LueSize.EditValue);
                                    m_dtbJangedDetails.Rows[m_update_srno - 1]["size_name"] = Val.ToString(LueSize.Text);

                                    m_dtbJangedDetails.Rows[m_update_srno - 1]["unit_id"] = Val.ToInt(LueUnit.EditValue);
                                    m_dtbJangedDetails.Rows[m_update_srno - 1]["unit_name"] = Val.ToString(LueUnit.Text);

                                    //decimal Shipping_Charge = Math.Round((Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue) + Val.ToDecimal(txtInterestAmount.Text) + Val.ToDecimal(txtCGSTAmount.Text) + Val.ToDecimal(txtSGSTAmount.Text) + Val.ToDecimal(txtIGSTAmount.Text)) - (Val.ToDecimal(txtDiscountAmount.Text)) + Val.ToDecimal(txtShippingCharge.Text), 0);
                                    //txtNetAmount.Text = Shipping_Charge.ToString();
                                    break;
                                }
                            }
                        }
                        btnAdd.Text = "&Add";
                    }
                    else
                    {
                        for (int i = 0; i < m_dtbJangedDetails.Rows.Count; i++)
                        {
                            if (m_dtbJangedDetails.Select("janged_detail_id ='" + m_janged_detail_id + "' AND sr_no = '" + m_update_srno + "'").Length > 0)
                            {
                                if (m_dtbJangedDetails.Rows[m_update_srno - 1]["janged_detail_id"].ToString() == m_janged_detail_id.ToString())
                                {
                                    m_dtbJangedDetails.Rows[m_update_srno - 1]["pcs"] = Val.ToInt(txtPcs.Text);
                                    m_dtbJangedDetails.Rows[m_update_srno - 1]["rate"] = Val.ToDecimal(txtRate.Text);
                                    m_dtbJangedDetails.Rows[m_update_srno - 1]["flag"] = 1;
                                    m_dtbJangedDetails.Rows[m_update_srno - 1]["item_id"] = Val.ToInt(lueItem.EditValue);
                                    m_dtbJangedDetails.Rows[m_update_srno - 1]["color_id"] = Val.ToInt(LueColor.EditValue);
                                    m_dtbJangedDetails.Rows[m_update_srno - 1]["size_id"] = Val.ToInt(LueSize.EditValue);
                                    m_dtbJangedDetails.Rows[m_update_srno - 1]["unit_id"] = Val.ToInt(LueUnit.EditValue);
                                    m_dtbJangedDetails.Rows[m_update_srno - 1]["item_name"] = Val.ToString(lueItem.Text);
                                    m_dtbJangedDetails.Rows[m_update_srno - 1]["color_name"] = Val.ToString(LueColor.Text);
                                    m_dtbJangedDetails.Rows[m_update_srno - 1]["size_name"] = Val.ToString(LueSize.Text);
                                    m_dtbJangedDetails.Rows[m_update_srno - 1]["unit_name"] = Val.ToString(LueUnit.Text);

                                    m_dtbJangedDetails.Rows[m_update_srno - 1]["amount"] = Math.Round(Val.ToDecimal(txtPcs.Text) * Val.ToDecimal(txtRate.Text), 3);

                                    //decimal Shipping_Charge = Math.Round((Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue) + Val.ToDecimal(txtInterestAmount.Text) + Val.ToDecimal(txtCGSTAmount.Text) + Val.ToDecimal(txtSGSTAmount.Text) + Val.ToDecimal(txtIGSTAmount.Text)) - (Val.ToDecimal(txtDiscountAmount.Text)) + Val.ToDecimal(txtShippingCharge.Text), 0);
                                    //txtNetAmount.Text = Shipping_Charge.ToString();
                                }
                            }
                        }
                        btnAdd.Text = "&Add";
                    }
                    dgvJangedDetails.MoveLast();
                    m_IsUpdate = false;
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
                    if (m_dtbJangedDetails.Rows.Count == 0)
                    {
                        lstError.Add(new ListError(22, "Record"));
                        if (!blnFocus)
                        {
                            blnFocus = true;
                        }
                    }
                    if (dgvJangedDetails == null)
                    {
                        lstError.Add(new ListError(22, "Record"));
                        if (!blnFocus)
                        {
                            blnFocus = true;
                        }
                    }
                    var result = DateTime.Compare(Convert.ToDateTime(dtpJangedDate.Text), DateTime.Today);
                    if (result > 0)
                    {
                        lstError.Add(new ListError(5, " Janged Date Not Be Greater Than Today Date"));
                        if (!blnFocus)
                        {
                            blnFocus = true;
                            dtpJangedDate.Focus();
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
                txtSearchVoucherNo.Text = string.Empty;
                lueJangedLedger.EditValue = System.DBNull.Value;
                dtpJangedDate.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
                dtpJangedDate.Properties.Mask.EditMask = "dd/MMM/yyyy";
                dtpJangedDate.Properties.Mask.UseMaskAsDisplayFormat = true;
                dtpJangedDate.Properties.CharacterCasing = CharacterCasing.Upper;
                dtpJangedDate.EditValue = DateTime.Now;
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
                btnAdd.Text = "&Add";
                txtVoucherNo.Focus();
                m_srno = 0;
                m_IsUpdate = true;
                lblMode.Text = "Add Mode";
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
                if (m_dtbJangedDetails.Rows.Count > 0)
                    m_dtbJangedDetails.Rows.Clear();

                m_dtbJangedDetails = new DataTable();

                m_dtbJangedDetails.Columns.Add("sr_no", typeof(int));
                m_dtbJangedDetails.Columns.Add("janged_detail_id", typeof(int));
                m_dtbJangedDetails.Columns.Add("janged_id", typeof(int));
                m_dtbJangedDetails.Columns.Add("item_id", typeof(int));
                m_dtbJangedDetails.Columns.Add("item_name", typeof(string));
                m_dtbJangedDetails.Columns.Add("color_id", typeof(int));
                m_dtbJangedDetails.Columns.Add("color_name", typeof(string));
                m_dtbJangedDetails.Columns.Add("size_id", typeof(int));
                m_dtbJangedDetails.Columns.Add("size_name", typeof(string));
                m_dtbJangedDetails.Columns.Add("unit_id", typeof(int));
                m_dtbJangedDetails.Columns.Add("unit_name", typeof(string));
                m_dtbJangedDetails.Columns.Add("pcs", typeof(int)).DefaultValue = 0;
                m_dtbJangedDetails.Columns.Add("rate", typeof(decimal)).DefaultValue = 0;
                m_dtbJangedDetails.Columns.Add("amount", typeof(decimal)).DefaultValue = 0;
                m_dtbJangedDetails.Columns.Add("remarks", typeof(string));
                m_dtbJangedDetails.Columns.Add("old_pcs", typeof(int)).DefaultValue = 0;
                m_dtbJangedDetails.Columns.Add("flag", typeof(int)).DefaultValue = 0;
                m_dtbJangedDetails.Columns.Add("old_item_id", typeof(int));
                m_dtbJangedDetails.Columns.Add("old_color_id", typeof(int));
                m_dtbJangedDetails.Columns.Add("old_size_id", typeof(int));
                m_dtbJangedDetails.Columns.Add("old_unit_id", typeof(int));
                m_dtbJangedDetails.Columns.Add("old_item_name", typeof(string));
                m_dtbJangedDetails.Columns.Add("old_color_name", typeof(string));
                m_dtbJangedDetails.Columns.Add("old_size_name", typeof(string));
                m_dtbJangedDetails.Columns.Add("old_unit_name", typeof(string));

                grdJangedDetails.DataSource = m_dtbJangedDetails;
                grdJangedDetails.Refresh();
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
            objPurchaseEntry = new PurchaseEntry();
            bool blnReturn = true;
            DateTime datFromDate = DateTime.MinValue;
            DateTime datToDate = DateTime.MinValue;
            try
            {
                m_dtbDetails = objPurchaseEntry.GetData(Val.DBDate(dtpFromDate.Text), Val.DBDate(dtpToDate.Text), Val.ToInt64(txtSearchVoucherNo.Text), Val.ToInt32(lueJangedLedger.EditValue));

                if (m_dtbDetails.Rows.Count == 0)
                {
                    Global.Message("Data Not Found");
                    blnReturn = false;
                }

                grdJangedEntry.DataSource = m_dtbDetails;
                dgvJangedEntry.BestFitColumns();
            }
            catch (Exception ex)
            {
                BLL.General.ShowErrors(ex);
                blnReturn = false;
            }
            finally
            {
                objPurchaseEntry = null;
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
                            dgvJangedEntry.ExportToPdf(Filepath);
                            break;
                        case "xls":
                            dgvJangedEntry.ExportToXls(Filepath);
                            break;
                        case "xlsx":
                            dgvJangedEntry.ExportToXlsx(Filepath);
                            break;
                        case "rtf":
                            dgvJangedEntry.ExportToRtf(Filepath);
                            break;
                        case "txt":
                            dgvJangedEntry.ExportToText(Filepath);
                            break;
                        case "html":
                            dgvJangedEntry.ExportToHtml(Filepath);
                            break;
                        case "csv":
                            dgvJangedEntry.ExportToCsv(Filepath);
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
        private void dgvJangedDetails_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                if (e.RowHandle >= 0)
                {
                    if (e.Clicks == 2)
                    {
                        DataRow Drow = dgvJangedDetails.GetDataRow(e.RowHandle);
                        btnAdd.Text = "&Update";
                        //lueSieveName.Text = Val.ToString(Drow["sieve_name"]);
                        LueColor.EditValue = Val.ToInt32(Drow["color_id"]);
                        LueSize.EditValue = Val.ToInt32(Drow["size_id"]);
                        LueUnit.EditValue = Val.ToInt64(Drow["unit_id"]);
                        lueItem.EditValue = Val.ToInt32(Drow["item_id"]);
                        txtPcs.Text = Val.ToString(Drow["pcs"]);
                        txtRate.Text = Val.ToString(Drow["rate"]);
                        txtAmount.Text = Val.ToString(Drow["amount"]);

                        //m_numcarat = Val.ToDecimal(Drow["carat"]);
                        m_janged_detail_id = Val.ToInt(Drow["janged_detail_id"]);
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

        private void dgvJangedDetails_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            try
            {
                //if (Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue) > 0 && Val.ToDecimal(clmDetCarat.SummaryItem.SummaryValue) > 0)
                //{
                //    m_numSummDetRate = Math.Round((Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue) / Val.ToDecimal(clmDetCarat.SummaryItem.SummaryValue)), 2, MidpointRounding.AwayFromZero);

                //}
                //else
                //{
                //    m_numSummDetRate = 0;
                //}
                if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName == "rate")
                {
                    if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize)
                        e.TotalValue = m_numSummDetRate;
                }

            }
            catch (Exception ex)
            {
                BLL.General.ShowErrors(ex);
            }
        }

        private void FrmJangedEntry_Load(object sender, EventArgs e)
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
                    ttlbJagedInvoice.SelectedTabPage = tblJangeddetail;
                }
            }
            catch (Exception ex)
            {
                Global.Message(ex.ToString());
                return;
            }
        }

        private void backgroundWorker_JangedEntry_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.Default;
                Conn = new BeginTranConnection(true, false);

                Janged_EntryProperty objJangedEntryProperty = new Janged_EntryProperty();
                JangedEntry objJangedEntry = new JangedEntry();
                try
                {
                    IntRes = 0;

                    objJangedEntryProperty.janged_id = Val.ToInt(lblMode.Tag);
                    objJangedEntryProperty.voucher_no = Val.ToInt32(txtVoucherNo.Text);
                    objJangedEntryProperty.company_id = Val.ToInt(GlobalDec.gEmployeeProperty.company_id);
                    objJangedEntryProperty.branch_id = Val.ToInt(GlobalDec.gEmployeeProperty.branch_id);
                    objJangedEntryProperty.location_id = Val.ToInt(GlobalDec.gEmployeeProperty.location_id);
                    objJangedEntryProperty.department_id = Val.ToInt(GlobalDec.gEmployeeProperty.department_id);

                    objJangedEntryProperty.janged_date = Val.DBDate(dtpJangedDate.Text);
                    objJangedEntryProperty.gst_id = Val.ToInt(lueGSTRate.EditValue);
                    objJangedEntryProperty.purchase_bill_no = Val.ToString(txtPurchaseBill.Text);
                    objJangedEntryProperty.remarks = Val.ToString(txtRemark.Text);
                    objJangedEntryProperty.form_id = m_numForm_id;
                    objJangedEntryProperty.ledger_id = Val.ToInt(lueParty.EditValue);

                    objJangedEntryProperty.total_pcs = Val.ToInt64(clmPcs.SummaryItem.SummaryValue);

                    objJangedEntryProperty.gross_amount = Math.Round(Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue), 3);

                    objJangedEntryProperty.cgst_rate = Val.ToDecimal(txtCGSTPer.Text);
                    objJangedEntryProperty.cgst_amount = Val.ToDecimal(txtCGSTAmount.Text);
                    objJangedEntryProperty.sgst_rate = Val.ToDecimal(txtSGSTPer.Text);
                    objJangedEntryProperty.sgst_amount = Val.ToDecimal(txtSGSTAmount.Text);
                    objJangedEntryProperty.igst_rate = Val.ToDecimal(txtIGSTPer.Text);
                    objJangedEntryProperty.igst_amount = Val.ToDecimal(txtIGSTAmount.Text);

                    objJangedEntryProperty.discount_per = Val.ToDecimal(txtDiscountPer.Text);
                    objJangedEntryProperty.discount_amount = Val.ToDecimal(txtDiscountAmount.Text);
                    objJangedEntryProperty.round_of_amount = Val.ToDecimal(txtRoundOff.Text);

                    objJangedEntryProperty.net_amount = Val.ToDecimal(txtNetAmount.Text);
                    objJangedEntryProperty = objJangedEntry.Save(objJangedEntryProperty, DLL.GlobalDec.EnumTran.Start, Conn);

                    Int64 NewmJangedid = Val.ToInt64(objJangedEntryProperty.janged_id);

                    int IntCounter = 0;
                    int Count = 0;
                    int TotalCount = m_dtbJangedDetails.Rows.Count;

                    foreach (DataRow drw in m_dtbJangedDetails.Rows)
                    {
                        objJangedEntryProperty = new Janged_EntryProperty();
                        objJangedEntryProperty.janged_id = Val.ToInt32(NewmJangedid);
                        objJangedEntryProperty.janged_detail_id = Val.ToInt(drw["janged_detail_id"]);
                        objJangedEntryProperty.sr_no = Val.ToInt(drw["sr_no"]);
                        objJangedEntryProperty.item_id = Val.ToInt(drw["item_id"]);
                        objJangedEntryProperty.color_id = Val.ToInt(drw["color_id"]);
                        objJangedEntryProperty.size_id = Val.ToInt(drw["size_id"]);
                        objJangedEntryProperty.unit_id = Val.ToInt(drw["unit_id"]);
                        objJangedEntryProperty.pcs = Val.ToInt(drw["pcs"]);
                        objJangedEntryProperty.rate = Val.ToDecimal(drw["rate"]);
                        objJangedEntryProperty.amount = Val.ToDecimal(drw["amount"]);

                        objJangedEntryProperty.old_pcs = Val.ToInt(drw["old_pcs"]);
                        objJangedEntryProperty.flag = Val.ToInt(drw["flag"]);

                        IntRes = objJangedEntry.Save_Detail(objJangedEntryProperty, DLL.GlobalDec.EnumTran.Continue, Conn);

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
                    objJangedEntryProperty = null;
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

        private void backgroundWorker_JangedEntry_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            try
            {
                panelProgress.Visible = false;
                if (IntRes > 0)
                {
                    if (Val.ToInt(lblMode.Tag) == 0)
                    {
                        Global.Confirm("Janged Entry Data Save Successfully");
                        ClearDetails();
                        PopulateDetails();
                    }
                    else
                    {
                        Global.Confirm("Janged Entry Data Update Successfully");
                        ClearDetails();
                        PopulateDetails();
                    }
                }
                else
                {
                    Global.Confirm("Error In Janged Entry");
                    txtVoucherNo.Focus();
                }
            }
            catch (Exception ex)
            {
                Global.Message(ex.ToString());
                Global.Message(ex.InnerException.ToString());
            }
        }

        private void backgroundWorker_JangedDelete_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Conn = new BeginTranConnection(true, false);

            Janged_EntryProperty objJangedEntryProperty = new Janged_EntryProperty();
            JangedEntry objJangedEntry = new JangedEntry();
            DataTable dtbMemoRecDelete = new DataTable();
            try
            {
                if (Val.ToInt(lblMode.Tag) != 0)
                {
                    IntRes = 0;
                    objJangedEntryProperty.janged_id = Val.ToInt(lblMode.Tag);

                    int IntCounter = 0;
                    int Count = 0;
                    int FlagCount = 1;
                    int TotalCount = m_dtbJangedDetails.Rows.Count;
                    Int32 Flag = 0;
                    foreach (DataRow drw in m_dtbJangedDetails.Rows)
                    {
                        objJangedEntryProperty.janged_detail_id = Val.ToInt(drw["janged_detail_id"]);

                        if (FlagCount == TotalCount)
                        {
                            Flag = 1;
                        }

                        IntRes = objJangedEntry.Delete(objJangedEntryProperty, Flag, DLL.GlobalDec.EnumTran.Continue, Conn);

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
                    Global.Message("Invoice ID not found");
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
                objJangedEntryProperty = null;
            }
        }
        private void backgroundWorker_JangedDelete_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            try
            {
                panelProgress.Visible = false;
                if (IntRes > 0)
                {
                    if (Val.ToInt(lblMode.Tag) == 0)
                    {
                        Global.Confirm("Janged Data Delete Successfully");
                        ClearDetails();
                        btnSearch_Click(null, null);
                    }
                    else
                    {
                        Global.Confirm("Janged Data Delete Successfully");
                        ClearDetails();
                        btnSearch_Click(null, null);
                    }
                }
                else
                {
                    Global.Confirm("Error In Janged Entry Delete");
                    txtVoucherNo.Focus();
                }
            }
            catch (Exception ex)
            {
                Global.Message(ex.ToString());
                Global.Message(ex.InnerException.ToString());
            }
        }
        private void dgvJangedEntry_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                objPurchaseEntry = new PurchaseEntry();
                if (e.RowHandle >= 0)
                {
                    if (e.Clicks == 2)
                    {
                        m_blncheckevents = true;

                        DataRow Drow = dgvJangedEntry.GetDataRow(e.RowHandle);
                        lblMode.Text = "Edit Mode";
                        lblMode.Tag = Val.ToInt32(Drow["janged_id"]);

                        dtpJangedDate.Text = Val.DBDate(Val.ToString(Drow["janged_date"]));
                        txtVoucherNo.Text = Val.ToString(Drow["voucher_no"]);
                        lueGSTRate.EditValue = Val.ToInt64(Drow["gst_id"]);
                        lueParty.EditValue = Val.ToInt64(Drow["ledger_id"]);

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

                        m_dtbJangedDetails = objPurchaseEntry.GetDataDetails(Val.ToInt(lblMode.Tag));
                        grdJangedDetails.DataSource = m_dtbJangedDetails;

                        ttlbJagedInvoice.SelectedTabPage = tblJangeddetail;
                        txtPurchaseBill.Focus();
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
        private void dgvJangedEntry_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (Val.ToInt(dgvJangedEntry.GetRowCellValue(e.RowHandle, "flag_color")) == 1)
                {
                    e.Appearance.BackColor = Color.FromArgb(248, 210, 210);
                }
            }
        }
        private void dgvJangedEntry_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            try
            {
                //if (Val.ToDecimal(clmTotalAmount.SummaryItem.SummaryValue) > 0 && Val.ToDecimal(clmTotalCarat.SummaryItem.SummaryValue) > 0)
                //{
                //    m_numSummRate = Math.Round((Val.ToDecimal(clmTotalAmount.SummaryItem.SummaryValue) / Val.ToDecimal(clmTotalCarat.SummaryItem.SummaryValue)), 2, MidpointRounding.AwayFromZero);

                //}
                //else
                //{
                //    m_numSummRate = 0;
                //}
                //if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName == "rate")
                //{
                //    if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize)
                //        e.TotalValue = m_numSummRate;
                //}

            }
            catch (Exception ex)
            {
                BLL.General.ShowErrors(ex);
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
            DataTable DTab_ProductionType = GSTRate.Select("gst_id = '" + Val.ToInt64(lueGSTRate.EditValue) + "'").CopyToDataTable();

            if (DTab_ProductionType.Rows[0]["gst_name"].ToString() == "IGST")
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
            else if (DTab_ProductionType.Rows[0]["gst_name"].ToString() == "CGST/SGST")
            {
                txtCGSTPer.Text = DTab_ProductionType.Rows[0]["gst_rate"].ToString();
                txtSGSTPer.Text = DTab_ProductionType.Rows[0]["gst_rate"].ToString();
                txtIGSTPer.Text = "0";
                txtIGSTAmount.Text = "0";
                txtIGSTPer.Enabled = false;
                txtIGSTAmount.Enabled = false;
            }
        }

        private void txtVoucherNo_Validated(object sender, EventArgs e)
        {
            if (txtVoucherNo.Text != "")
            {
                m_dtbVoucher_JangedDetail = objPurchaseEntry.Janged_Voucher_GetData(Val.ToInt64(txtVoucherNo.Text));

                if (m_dtbVoucher_JangedDetail.Tables[0].Rows.Count > 0)
                {
                    lblMode.Tag = Val.ToInt32(m_dtbVoucher_JangedDetail.Tables[0].Rows[0]["janged_id"]);

                    lueGSTRate.EditValue = Val.ToInt64(m_dtbVoucher_JangedDetail.Tables[0].Rows[0]["gst_id"]);
                    lueParty.EditValue = Val.ToInt64(m_dtbVoucher_JangedDetail.Tables[0].Rows[0]["ledger_id"]);

                    //txtRemark.Text = Val.ToString(m_dtbVoucher_JangedDetail.Tables[0].Rows[0]["remarks"]);
                    //txtPurchaseBill.Text = Val.ToString(m_dtbVoucher_JangedDetail.Tables[0].Rows[0]["purchase_bill_no"]);
                    //txtRoundOff.Text = Val.ToString(Drow["round_of_amount"]);
                    //txtDiscountPer.Text = Val.ToString(Drow["discount_per"]);
                    //txtDiscountAmount.Text = Val.ToString(Drow["discount_amount"]);
                    //txtCGSTPer.Text = Val.ToString(Drow["cgst_per"]);
                    //txtCGSTAmount.Text = Val.ToString(Drow["cgst_amount"]);
                    //txtSGSTPer.Text = Val.ToString(Drow["sgst_per"]);
                    //txtSGSTAmount.Text = Val.ToString(Drow["sgst_amount"]);
                    //txtIGSTPer.Text = Val.ToString(Drow["igst_per"]);
                    //txtIGSTAmount.Text = Val.ToString(Drow["igst_amount"]);
                    //txtNetAmount.Text = Val.ToString(Drow["net_amount"]);

                    grdJangedDetails.DataSource = m_dtbVoucher_JangedDetail.Tables[1];
                }
                else
                {
                    Global.Message("Voucher No Data Not Found");
                    return;
                }
            }
            else
            {
                txtVoucherNo.Focus();
            }
        }
    }
}