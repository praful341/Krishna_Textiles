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
    public partial class FrmJangedEntry : DevExpress.XtraEditors.XtraForm
    {
        #region Data Member
        BLL.BeginTranConnection Conn;
        BLL.FormEvents objBOFormEvents;
        BLL.FormPer ObjPer;
        BLL.Validation Val;

        Control _NextEnteredControl;
        private List<Control> _tabControls;
        public delegate void SetControlValueCallback(Control oControl, string propName, object propValue);

        JangedEntry objJangedEntry = new JangedEntry();
        UserAuthentication objUserAuthentication = new UserAuthentication();
        //AssortMaster objAssort = new AssortMaster();
        //SieveMaster objSieve = new SieveMaster();
        //RateMaster objRate = new RateMaster();

        DataTable DtControlSettings = new DataTable();
        DataTable m_dtbSievecheck = new DataTable();
        DataTable m_dtbSubSievecheck = new DataTable();
        DataTable m_dtbAssortscheck = new DataTable();
        DataTable m_dtbSievedtl = new DataTable();
        DataTable m_dtbAssortsdtl = new DataTable();
        DataTable m_dtbSubSievedtl = new DataTable();
        DataTable m_dtbMemoData = new DataTable();
        DataTable m_opDate = new DataTable();
        DataTable m_dtbMemoNo = new DataTable();
        DataTable m_dtbDemandNo = new DataTable();
        DataTable m_dtbStockCarat = new DataTable();
        DataTable m_dtbAssorts = new DataTable();
        DataTable m_dtbSieve = new DataTable();
        DataTable m_dtbSaleDetails = new DataTable();
        DataTable m_dtbCurrencyType = new DataTable();
        DataTable m_dtbDetails = new DataTable();
        DataTable m_dtbSeller = new DataTable();


        int m_invoice_detail_id;
        int m_srno;
        int m_update_srno;
        int m_numCurrency_id;
        int m_numForm_id;
        int IntRes;

        decimal m_numcarat;
        decimal m_current_rate;
        decimal m_current_amount;
        decimal m_numSummRate;
        decimal m_numSummDetRate;

        bool m_blnadd;
        bool m_blnsave;
        bool m_blncheckevents;

        bool m_IsValid;
        bool m_IsUpdate;

        #endregion

        #region Constructor
        public FrmJangedEntry()
        {
            InitializeComponent();

            objBOFormEvents = new BLL.FormEvents();
            ObjPer = new BLL.FormPer();
            Val = new BLL.Validation();

            _NextEnteredControl = new Control();
            _tabControls = new List<Control>();

            objJangedEntry = new JangedEntry();
            objUserAuthentication = new UserAuthentication();
            //objAssort = new AssortMaster();
            //objSieve = new SieveMaster();
            //objRate = new RateMaster();
            //opstk = new OpeningStock();

            DtControlSettings = new DataTable();
            m_dtbSievecheck = new DataTable();
            m_dtbSubSievecheck = new DataTable();
            m_dtbAssortscheck = new DataTable();
            m_dtbSievedtl = new DataTable();
            m_dtbAssortsdtl = new DataTable();
            m_dtbSubSievedtl = new DataTable();
            m_dtbMemoData = new DataTable();
            m_opDate = new DataTable();
            m_dtbMemoNo = new DataTable();
            m_dtbDemandNo = new DataTable();
            m_dtbStockCarat = new DataTable();
            m_dtbAssorts = new DataTable();
            m_dtbSieve = new DataTable();
            m_dtbSaleDetails = new DataTable();
            m_dtbCurrencyType = new DataTable();
            m_dtbDetails = new DataTable();

            m_invoice_detail_id = 0;
            m_srno = 0;
            m_update_srno = 0;
            m_numCurrency_id = 0;
            m_numForm_id = 0;
            IntRes = 0;

            m_numcarat = 0;
            m_current_rate = 0;
            m_current_amount = 0;

            m_blnadd = new bool();
            m_blnsave = new bool();
            m_blncheckevents = new bool();
            m_IsValid = new bool();
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

            //if (Global.HideFormControls(Val.ToInt(ObjPer.form_id), this) != "")
            //{
            //    Global.Message("Select First User Setting...Please Contact to Administrator...");
            //    return;
            //}

            //ControlSettingDT(Val.ToInt(ObjPer.form_id), this);
            //AddGotFocusListener(this);
            //this.KeyPreview = true;

            //TabControlsToList(this.Controls);
            //_tabControls = _tabControls.OrderBy(x => x.TabIndex).ToList();

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
            objBOFormEvents.ObjToDispose.Add(objJangedEntry);
            objBOFormEvents.ObjToDispose.Add(Val);
            objBOFormEvents.ObjToDispose.Add(objBOFormEvents);

        }

        #endregion

        #region Events
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
                m_IsValid = true;
                m_blncheckevents = false;
                txtDiscountPer_EditValueChanged(null, null);
                txtBrokeragePer_EditValueChanged(null, null);
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

            while (objJangedEntry.ISExistsInvoiceNo(Val.ToString(txtInvoiceNo.Text)) == true && lblMode.Text == "Add Mode" && Val.ToInt(lblMode.Tag) == 0)
            {
                Global.Message("this Invoice No already Created please check invoice No");
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
        private void btnClear_Click_1(object sender, EventArgs e)
        {
            ClearDetails();
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
            backgroundWorker_SaleDelete.RunWorkerAsync();

            btnDelete.Enabled = true;
        }
        private void txtDiscountPer_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (!m_blncheckevents)
                {
                    decimal Dis_amt = Math.Round(Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue) * Val.ToDecimal(txtDiscountPer.Text) / 100, 0);
                    txtDiscountAmt.Text = Dis_amt.ToString();
                    decimal Net_Amount = Math.Round((Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue) + Val.ToDecimal(txtCGSTAmt.Text) + Val.ToDecimal(txtSGSTAmt.Text) + Val.ToDecimal(txtIGSTAmt.Text) - Val.ToDecimal(txtDiscountAmt.Text)) + Val.ToDecimal(txtInterestAmt.Text) + Val.ToDecimal(txtShippingCharge.Text), 0);
                    txtNetAmount.Text = Net_Amount.ToString();

                    txtBrokeragePer_EditValueChanged(null, null);
                }
            }
            catch (Exception ex)
            {
                General.ShowErrors(ex.ToString());
                return;
            }
        }
        private void txtBrokeragePer_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (!m_blncheckevents)
                {
                    decimal Brokerage_amt = Math.Round((Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue) - Val.ToDecimal(txtDiscountAmt.Text)) * Val.ToDecimal(txtBrokeragePer.Text) / 100, 0);
                    txtBrokerageAmt.Text = Brokerage_amt.ToString();
                }
            }
            catch (Exception ex)
            {
                General.ShowErrors(ex.ToString());
                return;
            }
        }
        private void txtInterestPer_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (!m_blncheckevents)
                {
                    decimal Interest_amt = Math.Round((Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue) - Val.ToDecimal(txtDiscountAmt.Text)) * Val.ToDecimal(txtInterestPer.Text) / 100, 0);
                    txtInterestAmt.Text = Interest_amt.ToString();
                    decimal Net_Amount = Math.Round((Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue) + Val.ToDecimal(txtCGSTAmt.Text) + Val.ToDecimal(txtSGSTAmt.Text) + Val.ToDecimal(txtIGSTAmt.Text) - Val.ToDecimal(txtDiscountAmt.Text)) + Val.ToDecimal(txtInterestAmt.Text) + Val.ToDecimal(txtShippingCharge.Text), 0);
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
                    decimal Shipping_Charge = Math.Round((Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue) + Val.ToDecimal(txtInterestAmt.Text) + Val.ToDecimal(txtCGSTAmt.Text) + Val.ToDecimal(txtSGSTAmt.Text) + Val.ToDecimal(txtIGSTAmt.Text)) - (Val.ToDecimal(txtDiscountAmt.Text)) + Val.ToDecimal(txtShippingCharge.Text), 0);
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
                decimal GrossAmt = Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue);
                decimal DiscountAmt = Val.ToDecimal(txtDiscountAmt.Text);

                decimal CGST_amt = Math.Round(Val.ToDecimal(GrossAmt - DiscountAmt) * Val.ToDecimal(txtCGSTPer.Text) / 100, 0);
                txtCGSTAmt.Text = CGST_amt.ToString();

                decimal Net_Amount = Math.Round((Val.ToDecimal(GrossAmt) + Val.ToDecimal(txtCGSTAmt.Text) + Val.ToDecimal(txtSGSTAmt.Text) + Val.ToDecimal(txtIGSTAmt.Text) - Val.ToDecimal(txtDiscountAmt.Text)) + Val.ToDecimal(txtInterestAmt.Text) + Val.ToDecimal(txtShippingCharge.Text), 0);
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
                decimal GrossAmt = Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue);
                decimal DiscountAmt = Val.ToDecimal(txtDiscountAmt.Text);

                decimal SGST_amt = Math.Round(Val.ToDecimal(GrossAmt - DiscountAmt) * Val.ToDecimal(txtSGSTPer.Text) / 100, 0);
                txtSGSTAmt.Text = SGST_amt.ToString();
                decimal Net_Amount = Math.Round((Val.ToDecimal(GrossAmt) + Val.ToDecimal(txtCGSTAmt.Text) + Val.ToDecimal(txtSGSTAmt.Text) + Val.ToDecimal(txtIGSTAmt.Text) - Val.ToDecimal(txtDiscountAmt.Text)) + Val.ToDecimal(txtInterestAmt.Text) + Val.ToDecimal(txtShippingCharge.Text), 0);
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
                decimal GrossAmt = Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue);
                decimal DiscountAmt = Val.ToDecimal(txtDiscountAmt.Text);

                decimal IGST_amt = Math.Round(Val.ToDecimal(GrossAmt - DiscountAmt) * Val.ToDecimal(txtIGSTPer.Text) / 100, 0);
                txtIGSTAmt.Text = IGST_amt.ToString();
                decimal Net_Amount = Math.Round((Val.ToDecimal(GrossAmt) + Val.ToDecimal(txtCGSTAmt.Text) + Val.ToDecimal(txtSGSTAmt.Text) + Val.ToDecimal(txtIGSTAmt.Text) - Val.ToDecimal(txtDiscountAmt.Text)) + Val.ToDecimal(txtInterestAmt.Text) + Val.ToDecimal(txtShippingCharge.Text), 0);
                txtNetAmount.Text = Net_Amount.ToString();
            }
            catch (Exception ex)
            {
                General.ShowErrors(ex.ToString());
                return;
            }
        }
        private void lblFormatSample_Click(object sender, EventArgs e)
        {
            Global.CopyFormat(System.Windows.Forms.Application.StartupPath + @"\FORMAT\Sale_Invoice.xlsx", "Sale_Invoice.xlsx", "xlsx");
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
        private void backgroundWorker_SaleDelete_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
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
                    objJangedEntryProperty.invoice_id = Val.ToInt(lblMode.Tag);
                    dtbMemoRecDelete = objJangedEntry.GetMemoReceiveData(Val.ToInt(lblMode.Tag));


                    int IntCounter = 0;
                    int Count = 0;
                    int FlagCount = 1;
                    int TotalCount = m_dtbSaleDetails.Rows.Count;
                    Int32 Flag = 0;
                    foreach (DataRow drw in m_dtbSaleDetails.Rows)
                    {
                        objJangedEntryProperty.invoice_detail_id = Val.ToInt(drw["invoice_detail_id"]);
                        objJangedEntryProperty.assort_id = Val.ToInt(drw["assort_id"]);
                        objJangedEntryProperty.sieve_id = Val.ToInt(drw["sieve_id"]);
                        objJangedEntryProperty.pcs = Val.ToInt(drw["pcs"]);
                        objJangedEntryProperty.carat = Val.ToDecimal(drw["carat"]);

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

                    if (IntRes > 0)
                    {
                        objJangedEntry = new JangedEntry();
                        objJangedEntryProperty = new Janged_EntryProperty();

                        foreach (DataRow drw in dtbMemoRecDelete.Rows)
                        {
                            objJangedEntryProperty.memo_id = Val.ToInt(drw["memo_id"]);
                            objJangedEntryProperty.rej_carat = Val.ToDecimal(drw["rejection_carat"]);
                            objJangedEntryProperty.carat = Val.ToDecimal(drw["return_carat"]);
                            objJangedEntryProperty.assort_id = Val.ToInt(drw["assort_id"]);
                            objJangedEntryProperty.sieve_id = Val.ToInt(drw["sieve_id"]);

                            IntRes = objJangedEntry.Delete_MemoRecive_Details(objJangedEntryProperty, Flag, DLL.GlobalDec.EnumTran.Continue, Conn);
                        }
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
        private void backgroundWorker_SaleDelete_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
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
                    }
                    else
                    {
                        Global.Confirm("Sale Invoice Data Delete Successfully");
                        ClearDetails();
                    }
                }
                else
                {
                    Global.Confirm("Error In Sale Invoice Delete");
                    txtInvoiceNo.Focus();
                }
            }
            catch (Exception ex)
            {
                Global.Message(ex.ToString());
                Global.Message(ex.InnerException.ToString());
            }
        }
        private void backgroundWorker_SaleInvoice_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
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

                    objJangedEntryProperty.invoice_id = Val.ToInt(lblMode.Tag);
                    objJangedEntryProperty.invoice_No = Val.ToString(txtInvoiceNo.Text);
                    objJangedEntryProperty.company_id = Val.ToInt(GlobalDec.gEmployeeProperty.company_id);
                    objJangedEntryProperty.branch_id = Val.ToInt(GlobalDec.gEmployeeProperty.branch_id);
                    objJangedEntryProperty.location_id = Val.ToInt(GlobalDec.gEmployeeProperty.location_id);
                    objJangedEntryProperty.department_id = Val.ToInt(GlobalDec.gEmployeeProperty.department_id);

                    objJangedEntryProperty.invoice_date = Val.DBDate(dtpJangedDate.Text);
                    //objJangedEntryProperty.delivery_type_id = Val.ToInt(lueDeliveryType.EditValue);
                    //objJangedEntryProperty.remarks = Val.ToString(txtEntry.Text);

                    objJangedEntryProperty.form_id = m_numForm_id;

                    objJangedEntryProperty.Bill_To_Party_Id = Val.ToInt(lueGSTRate.EditValue);
                    objJangedEntryProperty.Shipped_To_Party_Id = Val.ToInt(lueParty.EditValue);
                    //objJangedEntryProperty.Refrenace_Id = Val.ToInt(lueReferance.EditValue);

                    //objJangedEntryProperty.Broker_Id = Val.ToInt(lueBroker.EditValue);
                    //objJangedEntryProperty.Term_Days = Val.ToInt(txtTermDays.EditValue);
                    //objJangedEntryProperty.Add_On_Days = Val.ToInt(txtAddOnDays.EditValue);
                    //objJangedEntryProperty.due_date = Val.DBDate(dtpDueDate.Text);
                    //objJangedEntryProperty.demand_master_id = Val.ToInt(lblDemandNo.Tag);
                    //objJangedEntryProperty.memo_master_id = Val.ToInt(lueMemoNo.EditValue);

                    //objJangedEntryProperty.final_Term_Days = Val.ToInt(txtFinalTermDays.EditValue);
                    //objJangedEntryProperty.final_due_date = Val.DBDate(dtpFinalDueDate.Text);


                    objJangedEntryProperty.total_pcs = Math.Round(Val.ToDecimal(clmPcs.SummaryItem.SummaryValue), 3);
                    objJangedEntryProperty.total_carat = Math.Round(Val.ToDecimal(clmDetCarat.SummaryItem.SummaryValue), 3);

                    objJangedEntryProperty.Gross_Amount = Math.Round(Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue), 3);

                    objJangedEntryProperty.cgst_rate = Val.ToDecimal(txtCGSTPer.Text);
                    objJangedEntryProperty.cgst_amount = Val.ToDecimal(txtCGSTAmt.Text);
                    objJangedEntryProperty.sgst_rate = Val.ToDecimal(txtSGSTPer.Text);
                    objJangedEntryProperty.sgst_amount = Val.ToDecimal(txtSGSTAmt.Text);
                    objJangedEntryProperty.igst_rate = Val.ToDecimal(txtIGSTPer.Text);
                    objJangedEntryProperty.igst_amount = Val.ToDecimal(txtIGSTAmt.Text);

                    objJangedEntryProperty.Brokerage_Per = Val.ToDecimal(txtBrokeragePer.Text);
                    objJangedEntryProperty.Brokerage_Amt = Val.ToDecimal(txtBrokerageAmt.Text);
                    objJangedEntryProperty.Discount_Per = Val.ToDecimal(txtDiscountPer.Text);
                    objJangedEntryProperty.Discount_Amt = Val.ToDecimal(txtDiscountAmt.Text);
                    objJangedEntryProperty.Interest_Per = Val.ToDecimal(txtInterestPer.Text);
                    objJangedEntryProperty.Interest_Amt = Val.ToDecimal(txtInterestAmt.Text);
                    objJangedEntryProperty.Shipping_Charge = Val.ToDecimal(txtShippingCharge.Text);

                    objJangedEntryProperty.net_amount = Val.ToDecimal(txtNetAmount.Text);
                    //objJangedEntryProperty.Currency_Type = lueCurrency.Text;
                    objJangedEntryProperty.Currency_ID = Val.ToInt(m_numCurrency_id);
                    //objJangedEntryProperty.exchange_rate = Val.ToDecimal(txtExchangeRate.Text);
                    //objJangedEntryProperty.Seller_ID = Val.ToInt(lueSeller.EditValue);

                    //int IntRes = objSaleInvoice.Save(objSaleInvoiceProperty, m_dtbSaleDetails);
                    objJangedEntryProperty = objJangedEntry.Save(objJangedEntryProperty, DLL.GlobalDec.EnumTran.Start, Conn);

                    Int64 NewmInvoiceid = Val.ToInt64(objJangedEntryProperty.invoice_id);

                    int IntCounter = 0;
                    int Count = 0;
                    int TotalCount = m_dtbSaleDetails.Rows.Count;

                    foreach (DataRow drw in m_dtbSaleDetails.Rows)
                    {
                        objJangedEntryProperty = new Janged_EntryProperty();
                        objJangedEntryProperty.invoice_id = Val.ToInt32(NewmInvoiceid);
                        objJangedEntryProperty.invoice_detail_id = Val.ToInt(drw["invoice_detail_id"]);
                        objJangedEntryProperty.assort_id = Val.ToInt(drw["assort_id"]);
                        objJangedEntryProperty.sieve_id = Val.ToInt(drw["sieve_id"]);
                        objJangedEntryProperty.sub_sieve_id = Val.ToInt(drw["sub_sieve_id"]);
                        objJangedEntryProperty.pcs = Val.ToInt(drw["pcs"]);
                        objJangedEntryProperty.carat = Val.ToDecimal(drw["carat"]);
                        objJangedEntryProperty.rate = Val.ToDecimal(drw["rate"]);
                        objJangedEntryProperty.amount = Val.ToDecimal(drw["amount"]);
                        objJangedEntryProperty.discount = Val.ToDecimal(drw["discount"]);

                        objJangedEntryProperty.rej_carat = Val.ToDecimal(drw["rej_carat"]);
                        objJangedEntryProperty.rej_percentage = Val.ToDecimal(drw["rej_percentage"]);

                        objJangedEntryProperty.old_carat = Val.ToDecimal(drw["old_carat"]);
                        objJangedEntryProperty.old_pcs = Val.ToInt(drw["old_pcs"]);
                        objJangedEntryProperty.old_rej_carat = Val.ToDecimal(drw["old_rej_carat"]);
                        objJangedEntryProperty.old_rej_percentage = Val.ToInt(drw["old_rej_percentage"]);
                        objJangedEntryProperty.flag = Val.ToInt(drw["flag"]);
                        objJangedEntryProperty.old_assort_id = Val.ToInt(drw["old_assort_id"]);
                        objJangedEntryProperty.old_sieve_id = Val.ToInt(drw["old_sieve_id"]);
                        objJangedEntryProperty.old_sub_sieve_id = Val.ToInt(drw["old_sub_sieve_id"]);
                        objJangedEntryProperty.current_rate = Val.ToDecimal(drw["current_rate"]);
                        objJangedEntryProperty.current_amount = Val.ToDecimal(drw["current_amount"]);
                        objJangedEntryProperty.old_sieve_id = Val.ToInt(drw["old_sieve_id"]);
                        objJangedEntryProperty.Currency_ID = Val.ToInt(m_numCurrency_id);
                        objJangedEntryProperty.loss_carat = Val.ToDecimal(drw["loss_carat"]);
                        objJangedEntryProperty.old_loss_carat = Val.ToDecimal(drw["old_loss_carat"]);
                        objJangedEntryProperty.is_memo = Val.ToInt(drw["is_memo"]);

                        objJangedEntryProperty.purchase_rate = Val.ToDecimal(drw["purchase_rate"]);
                        objJangedEntryProperty.purchase_amount = Val.ToDecimal(drw["purchase_amount"]);


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
                    Global.Confirm("Error In Sale Invoice");
                    txtInvoiceNo.Focus();
                }
            }
            catch (Exception ex)
            {
                Global.Message(ex.ToString());
                Global.Message(ex.InnerException.ToString());
            }
        }

        #region "Grid Events" 
        private void dgvSalesDetails_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            try
            {
                if (Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue) > 0 && Val.ToDecimal(clmDetCarat.SummaryItem.SummaryValue) > 0)
                {
                    m_numSummDetRate = Math.Round((Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue) / Val.ToDecimal(clmDetCarat.SummaryItem.SummaryValue)), 2, MidpointRounding.AwayFromZero);

                }
                else
                {
                    m_numSummDetRate = 0;
                }
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
        private void dgvSaleInvoice_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                objJangedEntry = new JangedEntry();
                if (e.RowHandle >= 0)
                {
                    if (e.Clicks == 2)
                    {
                        m_blncheckevents = true;

                        DataRow Drow = dgvJangedInvoice.GetDataRow(e.RowHandle);
                        lblMode.Text = "Edit Mode";
                        lblMode.Tag = Val.ToInt32(Drow["invoice_id"]);

                        dtpJangedDate.Text = Val.DBDate(Val.ToString(Drow["invoice_date"]));
                        txtInvoiceNo.Text = Val.ToString(Drow["invoice_no"]);
                        lueGSTRate.EditValue = Val.ToInt(Drow["billed_to_party_id"]);
                        lueParty.EditValue = Val.ToInt(Drow["shipped_to_party_id"]);


                        txtShippingCharge.Text = Val.ToString(Drow["shipping"]);
                        txtBrokeragePer.Text = Val.ToString(Drow["brokerage_per"]);
                        txtBrokerageAmt.Text = Val.ToString(Drow["brokerage_amount"]);
                        txtDiscountPer.Text = Val.ToString(Drow["discount_per"]);
                        txtDiscountAmt.Text = Val.ToString(Drow["discount_amount"]);
                        txtInterestPer.Text = Val.ToString(Drow["interest_per"]);
                        txtInterestAmt.Text = Val.ToString(Drow["interest_amount"]);
                        txtCGSTPer.Text = Val.ToString(Drow["cgst_per"]);
                        txtCGSTAmt.Text = Val.ToString(Drow["cgst_amount"]);
                        txtSGSTPer.Text = Val.ToString(Drow["sgst_per"]);
                        txtSGSTAmt.Text = Val.ToString(Drow["sgst_amount"]);
                        txtIGSTPer.Text = Val.ToString(Drow["igst_per"]);
                        txtIGSTAmt.Text = Val.ToString(Drow["igst_amount"]);
                        txtNetAmount.Text = Val.ToString(Drow["net_amount"]);

                        m_dtbSaleDetails = objJangedEntry.GetDataDetails(Val.ToInt(lblMode.Tag));
                        grdJangedDetails.DataSource = m_dtbSaleDetails;

                        ttlbSaleInvoice.SelectedTabPage = tblSaledetail;
                        txtInvoiceNo.Focus();
                        m_IsValid = false;
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
        private void dgvSalesDetails_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
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
                        LueUnit.EditValue = Val.ToInt32(Drow["unit_id"]);
                        lueItem.EditValue = Val.ToInt32(Drow["item_id"]);
                        txtPcs.Text = Val.ToString(Drow["pcs"]);
                        txtRate.Text = Val.ToString(Drow["rate"]);
                        txtAmount.Text = Val.ToString(Drow["amount"]);

                        m_numcarat = Val.ToDecimal(Drow["carat"]);
                        m_invoice_detail_id = Val.ToInt(Drow["invoice_detail_id"]);
                        m_update_srno = Val.ToInt(Drow["sr_no"]);
                        m_IsValid = true;
                    }
                }
            }
            catch (Exception ex)
            {
                BLL.General.ShowErrors(ex);
                return;
            }
        }
        private void dgvSaleInvoice_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            try
            {
                if (Val.ToDecimal(clmTotalAmount.SummaryItem.SummaryValue) > 0 && Val.ToDecimal(clmTotalCarat.SummaryItem.SummaryValue) > 0)
                {
                    m_numSummRate = Math.Round((Val.ToDecimal(clmTotalAmount.SummaryItem.SummaryValue) / Val.ToDecimal(clmTotalCarat.SummaryItem.SummaryValue)), 2, MidpointRounding.AwayFromZero);

                }
                else
                {
                    m_numSummRate = 0;
                }
                if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName == "rate")
                {
                    if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize)
                        e.TotalValue = m_numSummRate;
                }

            }
            catch (Exception ex)
            {
                BLL.General.ShowErrors(ex);
            }
        }
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
                objJangedEntry = new JangedEntry();
                DataTable p_dtbDetail = new DataTable();

                //p_dtbDetail = objSaleInvoice.GetCheckPriceList(m_numCurrency_id, Val.ToInt(GlobalDec.gEmployeeProperty.rate_type_id));
                p_dtbDetail = objJangedEntry.GetCheckPriceList(Val.ToInt(GlobalDec.gEmployeeProperty.currency_id), Val.ToInt(GlobalDec.gEmployeeProperty.rate_type_id));

                if (p_dtbDetail.Rows.Count <= 0)
                {
                    Global.Message("Selected currency type price not found in master please check", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    blnReturn = false;
                    return blnReturn;
                }

                decimal numStockCarat = 0;
                if (btnAdd.Text == "&Add")
                {
                    //DataTable m_dtbStockCarat = new DataTable();
                    objJangedEntry = new JangedEntry();
                    //m_dtbStockCarat = objSaleInvoice.GetStockCarat(GlobalDec.gEmployeeProperty.company_id, GlobalDec.gEmployeeProperty.branch_id, GlobalDec.gEmployeeProperty.location_id, GlobalDec.gEmployeeProperty.department_id, Val.ToInt(lueAssortName.EditValue), Val.ToInt(lueSieveName.EditValue));                    
                    if (m_dtbStockCarat.Rows.Count > 0)
                    {
                        numStockCarat = Val.ToDecimal(m_dtbStockCarat.Rows[0]["stock_carat"]);
                    }

                    DataRow[] dr = m_dtbSaleDetails.Select("item_id = " + Val.ToInt(lueItem.EditValue) + " AND color_id = " + Val.ToInt(LueColor.EditValue) + " AND size_id = " + Val.ToInt(LueSize.EditValue));

                    if (dr.Count() == 1)
                    {
                        Global.Message("Record already exists in grid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lueItem.Focus();
                        blnReturn = false;
                        return blnReturn;
                    }
                    DataRow drwNew = m_dtbSaleDetails.NewRow();
                    decimal numRate = Val.ToDecimal(txtRate.Text);
                    decimal numAmount = Val.ToDecimal(txtAmount.Text);
                    int numPcs = Val.ToInt(txtPcs.Text);

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
                    drwNew["rate"] = Val.ToDecimal(txtRate.Text);
                    drwNew["amount"] = Math.Round(Val.ToDecimal(txtPcs.Text) * Val.ToDecimal(txtRate.Text), 2);
                    drwNew["old_pcs"] = Val.ToDecimal(0);
                    drwNew["flag"] = Val.ToInt(0);
                    m_srno = m_srno + 1;
                    drwNew["sr_no"] = Val.ToInt(m_srno);

                    m_dtbSaleDetails.Rows.Add(drwNew);

                    dgvJangedDetails.MoveLast();

                    decimal CGST_amt = Math.Round(Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue) * Val.ToDecimal(txtCGSTPer.Text) / 100, 0);
                    txtCGSTAmt.Text = CGST_amt.ToString();
                    decimal SGST_amt = Math.Round(Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue) * Val.ToDecimal(txtSGSTPer.Text) / 100, 0);
                    txtSGSTAmt.Text = SGST_amt.ToString();
                    decimal IGST_amt = Math.Round(Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue) * Val.ToDecimal(txtIGSTPer.Text) / 100, 0);
                    txtIGSTAmt.Text = IGST_amt.ToString();

                    decimal Shipping_Charge = Math.Round((Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue) + Val.ToDecimal(txtInterestAmt.Text) + Val.ToDecimal(txtCGSTAmt.Text) + Val.ToDecimal(txtSGSTAmt.Text) + Val.ToDecimal(txtIGSTAmt.Text)) - (Val.ToDecimal(txtDiscountAmt.Text)) + Val.ToDecimal(txtShippingCharge.Text), 0);
                    txtNetAmount.Text = Shipping_Charge.ToString();
                }
                else if (btnAdd.Text == "&Update")
                {
                    if (!m_IsUpdate)
                    {
                        Global.Message("You can't update this record", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        blnReturn = false;
                        return blnReturn;
                    }

                    objJangedEntry = new JangedEntry();

                    if (m_dtbSaleDetails.Select("item_id ='" + Val.ToInt(lueItem.EditValue) + "' AND color_id ='" + Val.ToInt(LueColor.EditValue) + "'").Length > 0)
                    {
                        for (int i = 0; i < m_dtbSaleDetails.Rows.Count; i++)
                        {
                            if (m_dtbSaleDetails.Select("invoice_detail_id ='" + m_invoice_detail_id + "' AND sr_no = '" + m_update_srno + "'").Length > 0)
                            {
                                if (m_dtbSaleDetails.Rows[m_update_srno - 1]["invoice_detail_id"].ToString() == m_invoice_detail_id.ToString())
                                {
                                    m_dtbSaleDetails.Rows[m_update_srno - 1]["pcs"] = Val.ToInt(txtPcs.Text);
                                    m_dtbSaleDetails.Rows[m_update_srno - 1]["rate"] = Val.ToDecimal(txtRate.Text);
                                    m_dtbSaleDetails.Rows[m_update_srno - 1]["flag"] = 1;
                                    m_dtbSaleDetails.Rows[m_update_srno - 1]["amount"] = Math.Round(Val.ToDecimal(txtPcs.Text) * Val.ToDecimal(txtRate.Text), 3);

                                    m_dtbSaleDetails.Rows[m_update_srno - 1]["item_id"] = Val.ToInt(lueItem.EditValue);
                                    m_dtbSaleDetails.Rows[m_update_srno - 1]["item_name"] = Val.ToString(lueItem.Text);

                                    m_dtbSaleDetails.Rows[m_update_srno - 1]["color_id"] = Val.ToInt(LueColor.EditValue);
                                    m_dtbSaleDetails.Rows[m_update_srno - 1]["color_name"] = Val.ToString(LueColor.Text);

                                    m_dtbSaleDetails.Rows[m_update_srno - 1]["size_id"] = Val.ToInt(LueSize.EditValue);
                                    m_dtbSaleDetails.Rows[m_update_srno - 1]["size_name"] = Val.ToString(LueSize.Text);

                                    m_dtbSaleDetails.Rows[m_update_srno - 1]["unit_id"] = Val.ToInt(LueUnit.EditValue);
                                    m_dtbSaleDetails.Rows[m_update_srno - 1]["unit_name"] = Val.ToString(LueUnit.Text);

                                    decimal Shipping_Charge = Math.Round((Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue) + Val.ToDecimal(txtInterestAmt.Text) + Val.ToDecimal(txtCGSTAmt.Text) + Val.ToDecimal(txtSGSTAmt.Text) + Val.ToDecimal(txtIGSTAmt.Text)) - (Val.ToDecimal(txtDiscountAmt.Text)) + Val.ToDecimal(txtShippingCharge.Text), 0);
                                    txtNetAmount.Text = Shipping_Charge.ToString();
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
                                    m_dtbSaleDetails.Rows[m_update_srno - 1]["pcs"] = Val.ToInt(txtPcs.Text);
                                    m_dtbSaleDetails.Rows[m_update_srno - 1]["rate"] = Val.ToDecimal(txtRate.Text);
                                    m_dtbSaleDetails.Rows[m_update_srno - 1]["flag"] = 1;
                                    m_dtbSaleDetails.Rows[m_update_srno - 1]["item_id"] = Val.ToInt(lueItem.EditValue);
                                    m_dtbSaleDetails.Rows[m_update_srno - 1]["color_id"] = Val.ToInt(LueColor.EditValue);
                                    m_dtbSaleDetails.Rows[m_update_srno - 1]["size_id"] = Val.ToInt(LueSize.EditValue);
                                    m_dtbSaleDetails.Rows[m_update_srno - 1]["unit_id"] = Val.ToInt(LueUnit.EditValue);
                                    m_dtbSaleDetails.Rows[m_update_srno - 1]["item_name"] = Val.ToString(lueItem.Text);
                                    m_dtbSaleDetails.Rows[m_update_srno - 1]["color_name"] = Val.ToString(LueColor.Text);
                                    m_dtbSaleDetails.Rows[m_update_srno - 1]["size_name"] = Val.ToString(LueSize.Text);
                                    m_dtbSaleDetails.Rows[m_update_srno - 1]["unit_name"] = Val.ToString(LueUnit.Text);

                                    m_dtbSaleDetails.Rows[m_update_srno - 1]["amount"] = Math.Round(Val.ToDecimal(txtPcs.Text) * Val.ToDecimal(txtRate.Text), 3);

                                    decimal Shipping_Charge = Math.Round((Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue) + Val.ToDecimal(txtInterestAmt.Text) + Val.ToDecimal(txtCGSTAmt.Text) + Val.ToDecimal(txtSGSTAmt.Text) + Val.ToDecimal(txtIGSTAmt.Text)) - (Val.ToDecimal(txtDiscountAmt.Text)) + Val.ToDecimal(txtShippingCharge.Text), 0);
                                    txtNetAmount.Text = Shipping_Charge.ToString();
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
                    if (m_dtbSaleDetails.Rows.Count == 0)
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
                        lstError.Add(new ListError(5, " Invoice Date Not Be Greater Than Today Date"));
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
                if (!GenerateSaleInvoiceDetails())
                {
                    blnReturn = false;
                    return blnReturn;
                }

                lblMode.Tag = null;
                lueGSTRate.EditValue = System.DBNull.Value;
                lueParty.EditValue = System.DBNull.Value;

                txtInvoiceNo.Text = string.Empty;
                lueItem.EditValue = System.DBNull.Value;
                LueColor.EditValue = System.DBNull.Value;
                LueSize.EditValue = System.DBNull.Value;
                LueUnit.EditValue = System.DBNull.Value;
                txtSearchInvoice.Text = string.Empty;
                lueBillToParty.EditValue = System.DBNull.Value;
                dtpJangedDate.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
                dtpJangedDate.Properties.Mask.EditMask = "dd/MMM/yyyy";
                dtpJangedDate.Properties.Mask.UseMaskAsDisplayFormat = true;
                dtpJangedDate.Properties.CharacterCasing = CharacterCasing.Upper;
                dtpJangedDate.EditValue = DateTime.Now;
                txtPcs.Text = string.Empty;
                txtRate.Text = string.Empty;
                txtAmount.Text = string.Empty;
                txtBrokerageAmt.Text = string.Empty;
                txtDiscountPer.Text = string.Empty;
                txtDiscountAmt.Text = string.Empty;
                txtInterestPer.Text = string.Empty;
                txtInterestAmt.Text = string.Empty;
                txtShippingCharge.Text = string.Empty;
                txtNetAmount.Text = string.Empty;
                txtCGSTPer.Text = string.Empty;
                txtCGSTAmt.Text = string.Empty;
                txtSGSTPer.Text = string.Empty;
                txtSGSTAmt.Text = string.Empty;
                txtIGSTPer.Text = string.Empty;
                txtIGSTAmt.Text = string.Empty;
                btnAdd.Text = "&Add";
                txtInvoiceNo.Focus();
                m_srno = 0;
                m_IsValid = false;

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
        private bool GenerateSaleInvoiceDetails()
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
                m_dtbSaleDetails.Columns.Add("assort_id", typeof(int));
                m_dtbSaleDetails.Columns.Add("assort_name", typeof(string));
                m_dtbSaleDetails.Columns.Add("sieve_id", typeof(int));
                m_dtbSaleDetails.Columns.Add("sieve_name", typeof(string));
                m_dtbSaleDetails.Columns.Add("sub_sieve_id", typeof(int));
                m_dtbSaleDetails.Columns.Add("sub_sieve_name", typeof(string));
                m_dtbSaleDetails.Columns.Add("pcs", typeof(int)).DefaultValue = 0;
                m_dtbSaleDetails.Columns.Add("carat", typeof(decimal)).DefaultValue = 0;
                m_dtbSaleDetails.Columns.Add("rate", typeof(decimal)).DefaultValue = 0;
                m_dtbSaleDetails.Columns.Add("amount", typeof(decimal)).DefaultValue = 0;
                m_dtbSaleDetails.Columns.Add("discount", typeof(decimal)).DefaultValue = 0;
                m_dtbSaleDetails.Columns.Add("remarks", typeof(string));
                m_dtbSaleDetails.Columns.Add("old_pcs", typeof(int)).DefaultValue = 0;
                m_dtbSaleDetails.Columns.Add("old_carat", typeof(decimal));
                m_dtbSaleDetails.Columns.Add("flag", typeof(int)).DefaultValue = 0;
                m_dtbSaleDetails.Columns.Add("old_assort_id", typeof(int));
                m_dtbSaleDetails.Columns.Add("old_sieve_id", typeof(int));
                m_dtbSaleDetails.Columns.Add("old_sub_sieve_id", typeof(int));
                m_dtbSaleDetails.Columns.Add("old_assort_name", typeof(string));
                m_dtbSaleDetails.Columns.Add("old_sieve_name", typeof(string));
                m_dtbSaleDetails.Columns.Add("old_sub_sieve_name", typeof(string));
                m_dtbSaleDetails.Columns.Add("current_rate", typeof(decimal)).DefaultValue = 0;
                m_dtbSaleDetails.Columns.Add("current_amount", typeof(decimal)).DefaultValue = 0;

                m_dtbSaleDetails.Columns.Add("rej_carat", typeof(decimal)).DefaultValue = 0;
                m_dtbSaleDetails.Columns.Add("rej_percentage", typeof(decimal)).DefaultValue = 0;
                m_dtbSaleDetails.Columns.Add("old_rej_carat", typeof(decimal)).DefaultValue = 0;
                m_dtbSaleDetails.Columns.Add("old_rej_percentage", typeof(decimal)).DefaultValue = 0;
                m_dtbSaleDetails.Columns.Add("loss_carat", typeof(decimal)).DefaultValue = 0;
                m_dtbSaleDetails.Columns.Add("old_loss_carat", typeof(decimal)).DefaultValue = 0;
                m_dtbSaleDetails.Columns.Add("is_memo", typeof(int)).DefaultValue = 0;

                m_dtbSaleDetails.Columns.Add("purchase_rate", typeof(decimal)).DefaultValue = 0;
                m_dtbSaleDetails.Columns.Add("purchase_amount", typeof(decimal)).DefaultValue = 0;

                grdJangedDetails.DataSource = m_dtbSaleDetails;
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
            //objJangedEntry = new JangedEntry();
            bool blnReturn = true;
            //DateTime datFromDate = DateTime.MinValue;
            //DateTime datToDate = DateTime.MinValue;
            //try
            //{
            //    m_dtbDetails = objJangedEntry.GetData(Val.DBDate(dtpFromDate.Text), Val.DBDate(dtpToDate.Text), Val.ToString(txtSearchInvoice.Text), Val.ToInt32(lueBillToParty.EditValue));

            //    if (m_dtbDetails.Rows.Count == 0)
            //    {
            //        Global.Message("Data Not Found");
            //        blnReturn = false;
            //    }

            //    grdJangedInvoice.DataSource = m_dtbDetails;
            //    dgvJangedInvoice.BestFitColumns();
            //}
            //catch (Exception ex)
            //{
            //    BLL.General.ShowErrors(ex);
            //blnReturn = false;
            //}
            //finally
            //{
            //    objJangedEntry = null;
            //}

            return blnReturn;
        }
        private void FillMemoToSale()
        {
            try
            {
                objJangedEntry = new JangedEntry();
                if (m_dtbMemoData.Rows.Count > 0)
                {
                    DataTable SaleDet = new DataTable();

                    SaleDet.Columns.Add("invoice_detail_id");
                    SaleDet.Columns.Add("assort_id");
                    SaleDet.Columns.Add("assort_name");
                    SaleDet.Columns.Add("sieve_id");
                    SaleDet.Columns.Add("sieve_name");
                    SaleDet.Columns.Add("sub_sieve_id");
                    SaleDet.Columns.Add("sub_sieve_name");
                    SaleDet.Columns.Add("pcs");
                    SaleDet.Columns.Add("carat");
                    SaleDet.Columns.Add("rate");
                    SaleDet.Columns.Add("amount");
                    SaleDet.Columns.Add("old_carat");
                    SaleDet.Columns.Add("old_pcs");
                    SaleDet.Columns.Add("flag");
                    SaleDet.Columns.Add("sr_no");
                    SaleDet.Columns.Add("old_assort_id");
                    SaleDet.Columns.Add("old_sieve_id");
                    SaleDet.Columns.Add("old_sub_sieve_id");
                    SaleDet.Columns.Add("current_rate");
                    SaleDet.Columns.Add("current_amount");
                    SaleDet.Columns.Add("discount");

                    SaleDet.Columns.Add("rej_pcs");
                    SaleDet.Columns.Add("rej_carat");

                    SaleDet.Columns.Add("old_rej_carat");
                    SaleDet.Columns.Add("rej_percentage");
                    SaleDet.Columns.Add("old_rej_percentage");

                    SaleDet.Columns.Add("loss_carat");
                    SaleDet.Columns.Add("old_loss_carat");
                    SaleDet.Columns.Add("is_memo");

                    SaleDet.Columns.Add("purchase_rate");
                    SaleDet.Columns.Add("purchase_amount");

                    SaleDet.Columns.Add("broker_per");
                    SaleDet.Columns.Add("broker_amt");

                    lueGSTRate.EditValue = Convert.ToInt32(m_dtbMemoData.Rows[0]["party_id"]);
                    lueParty.EditValue = Convert.ToInt32(m_dtbMemoData.Rows[0]["party_id"]);
                    txtInvoiceNo.Text = Convert.ToString(m_dtbMemoData.Rows[0]["memo_no"]);
                    txtDiscountPer.Text = Convert.ToString(m_dtbMemoData.Rows[0]["discount_per"]);
                    txtDiscountAmt.Text = Convert.ToString(m_dtbMemoData.Rows[0]["discount_amt"]);

                    lblMode.Tag = Convert.ToInt32(m_dtbMemoData.Rows[0]["invoice_id"]);

                    int i = 0;
                    foreach (DataRow DRow in m_dtbMemoData.Rows)
                    {
                        if (Convert.ToDecimal(DRow["rec_carat"]) > 0)
                        {
                            SaleDet.Rows.Add();
                            SaleDet.Rows[i]["invoice_detail_id"] = Val.ToInt(DRow["invoice_detail_id"]);
                            SaleDet.Rows[i]["assort_id"] = Val.ToInt(DRow["assort_id"]);
                            SaleDet.Rows[i]["sieve_id"] = Val.ToInt(DRow["sieve_id"]);
                            SaleDet.Rows[i]["sub_sieve_id"] = Val.ToInt(DRow["sub_sieve_id"]);
                            SaleDet.Rows[i]["assort_name"] = Val.ToString(DRow["assort_name"]);
                            SaleDet.Rows[i]["sieve_name"] = Val.ToString(DRow["sieve_name"]);
                            SaleDet.Rows[i]["sub_sieve_name"] = Val.ToString(DRow["sub_sieve_name"]);
                            SaleDet.Rows[i]["pcs"] = Val.ToInt(DRow["rec_pcs"]);
                            SaleDet.Rows[i]["carat"] = Val.ToDecimal(DRow["rec_carat"]);
                            SaleDet.Rows[i]["rate"] = Val.ToDecimal(DRow["rate"]);
                            SaleDet.Rows[i]["amount"] = Val.ToDecimal(DRow["sale_amount"]);
                            SaleDet.Rows[i]["old_carat"] = 0;
                            SaleDet.Rows[i]["old_pcs"] = 0;
                            SaleDet.Rows[i]["old_rej_carat"] = 0;
                            SaleDet.Rows[i]["old_rej_percentage"] = 0;
                            SaleDet.Rows[i]["flag"] = Convert.ToInt32(DRow["invoice_id"]) == 0 ? 0 : 1;
                            SaleDet.Rows[i]["sr_no"] = i + 1;
                            SaleDet.Rows[i]["old_assort_id"] = Val.ToInt(0);
                            SaleDet.Rows[i]["old_sieve_id"] = Val.ToInt(0);
                            SaleDet.Rows[i]["old_sub_sieve_id"] = Val.ToInt(0);
                            SaleDet.Rows[i]["current_rate"] = Val.ToDecimal(DRow["current_rate"]);
                            SaleDet.Rows[i]["current_amount"] = Math.Round(Val.ToDecimal(DRow["rec_carat"]) * Val.ToDecimal(DRow["current_rate"]), 3);
                            SaleDet.Rows[i]["discount"] = 0;

                            SaleDet.Rows[i]["rej_pcs"] = 0;
                            SaleDet.Rows[i]["rej_carat"] = 0;
                            SaleDet.Rows[i]["rej_percentage"] = 0;

                            SaleDet.Rows[i]["loss_carat"] = Val.ToDecimal(DRow["loss_carat"]);
                            SaleDet.Rows[i]["old_loss_carat"] = Val.ToDecimal(0);
                            SaleDet.Rows[i]["is_memo"] = Val.ToInt(1);

                            SaleDet.Rows[i]["purchase_rate"] = Val.ToDecimal(DRow["purchase_rate"]);
                            SaleDet.Rows[i]["purchase_amount"] = Val.ToDecimal(DRow["purchase_amount"]);
                            if (Convert.ToInt32(DRow["invoice_id"]) > 0)
                            {
                                lblMode.Tag = lblMode.Tag = Convert.ToInt32(DRow["invoice_id"]);
                            }

                            i++;
                        }
                    }

                    grdJangedDetails.DataSource = SaleDet;

                    ttlbSaleInvoice.SelectedTabPage = tblSaledetail;
                    m_dtbSaleDetails = SaleDet;
                    txtInvoiceNo.Focus();

                    txtCGSTPer_EditValueChanged(null, null);
                    txtSGSTPer_EditValueChanged(null, null);
                    txtDiscountPer_EditValueChanged(null, null);
                    txtBrokeragePer_EditValueChanged(null, null);

                    m_IsValid = true;
                }
            }
            catch (Exception ex)
            {
                BLL.General.ShowErrors(ex);
                return;
            }
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
                            dgvJangedInvoice.ExportToPdf(Filepath);
                            break;
                        case "xls":
                            dgvJangedInvoice.ExportToXls(Filepath);
                            break;
                        case "xlsx":
                            dgvJangedInvoice.ExportToXlsx(Filepath);
                            break;
                        case "rtf":
                            dgvJangedInvoice.ExportToRtf(Filepath);
                            break;
                        case "txt":
                            dgvJangedInvoice.ExportToText(Filepath);
                            break;
                        case "html":
                            dgvJangedInvoice.ExportToHtml(Filepath);
                            break;
                        case "csv":
                            dgvJangedInvoice.ExportToCsv(Filepath);
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

        private void dgvSaleInvoice_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (Val.ToInt(dgvJangedInvoice.GetRowCellValue(e.RowHandle, "flag_color")) == 1)
                {
                    e.Appearance.BackColor = Color.FromArgb(248, 210, 210);
                }
            }
        }
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
    }
}