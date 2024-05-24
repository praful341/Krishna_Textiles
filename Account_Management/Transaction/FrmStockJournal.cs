using Account_Management.Class;
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
using System.Linq;
using System.Reflection;
using System.Windows.Forms;


namespace Account_Management.Transaction
{
    public partial class FrmStockJournal : DevExpress.XtraEditors.XtraForm
    {
        #region Data Member
        BLL.BeginTranConnection Conn;
        BLL.FormEvents objBOFormEvents;
        BLL.FormPer ObjPer;
        BLL.Validation Val;

        Control _NextEnteredControl;
        private List<Control> _tabControls;
        public delegate void SetControlValueCallback(Control oControl, string propName, object propValue);

        StockJournal objStockJournal = new StockJournal();
        UserAuthentication objUserAuthentication = new UserAuthentication();
        DataTable DtControlSettings = new DataTable();
        DataTable m_dtbFromStockJournal = new DataTable();
        DataTable m_dtbToStockJournal = new DataTable();
        DataTable m_dtbDetails = new DataTable();

        int m_from_stock_journal_id;
        int m_to_stock_journal_id;
        int m_from_srno;
        int m_To_srno;
        int m_update_srno;
        int m_numForm_id;
        int IntRes;

        bool m_blnadd;
        bool m_blnsave;
        bool m_IsUpdate;
        Int64 Union_ID = 0;

        #endregion

        #region Constructor
        public FrmStockJournal()
        {
            InitializeComponent();

            objBOFormEvents = new BLL.FormEvents();
            ObjPer = new BLL.FormPer();
            Val = new BLL.Validation();

            _NextEnteredControl = new Control();
            _tabControls = new List<Control>();

            objStockJournal = new StockJournal();
            objUserAuthentication = new UserAuthentication();

            DtControlSettings = new DataTable();
            m_dtbDetails = new DataTable();

            m_from_stock_journal_id = 0;
            m_to_stock_journal_id = 0;
            m_from_srno = 0;
            m_To_srno = 0;
            m_update_srno = 0;
            m_numForm_id = 0;
            IntRes = 0;
            m_blnadd = new bool();
            m_blnsave = new bool();
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
            objBOFormEvents.ObjToDispose.Add(objStockJournal);
            objBOFormEvents.ObjToDispose.Add(Val);
            objBOFormEvents.ObjToDispose.Add(objBOFormEvents);
        }
        #endregion

        #region Events       
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
        private void txtRate_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtFromAmount.Text = string.Format("{0:0.00}", Val.ToDecimal(txtFromPcs.Text) * Val.ToDecimal(txtFromRate.Text));
            }
            catch (Exception ex)
            {
                General.ShowErrors(ex.ToString());
                return;
            }
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
                Global.LOOKUPItem(lueFromItem);
                Global.LOOKUPColor(lueFromColor);
                Global.LOOKUPSize(lueFromSize);

                Global.LOOKUPItem(lueToItem);
                Global.LOOKUPColor(lueToColor);
                Global.LOOKUPSize(lueToSize);

                dtpJNDate.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
                dtpJNDate.Properties.Mask.EditMask = "dd-MM-yyyy";
                dtpJNDate.Properties.Mask.UseMaskAsDisplayFormat = true;
                dtpJNDate.Properties.CharacterCasing = CharacterCasing.Upper;
                dtpJNDate.EditValue = DateTime.Now;

                btnClear_Click(null, null);
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
        private bool AddInFromGrid()
        {
            bool blnReturn = true;

            try
            {
                m_blnadd = true;
                m_blnsave = false;

                if (!ValidateFromDetails())
                {
                    m_blnadd = false;
                    blnReturn = false;
                    return blnReturn;
                }

                if (btnFromAdd.Text == "&Add")
                {
                    objStockJournal = new StockJournal();

                    DataRow[] dr = m_dtbFromStockJournal.Select("item_id = " + Val.ToInt(lueFromItem.EditValue) + " AND color_id = " + Val.ToInt(lueFromColor.EditValue) + " AND size_id = " + Val.ToInt(lueFromSize.EditValue));

                    if (dr.Count() == 1)
                    {
                        Global.Message("Record already exists in grid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lueFromItem.Focus();
                        blnReturn = false;
                        return blnReturn;
                    }
                    DataRow drwNew = m_dtbFromStockJournal.NewRow();
                    decimal numRate = Val.ToDecimal(txtFromRate.Text);
                    decimal numAmount = Val.ToDecimal(txtFromAmount.Text);
                    decimal numPcs = Val.ToDecimal(txtFromPcs.Text);

                    drwNew["color_id"] = Val.ToInt(lueFromColor.EditValue);
                    drwNew["color_name"] = Val.ToString(lueFromColor.Text);

                    drwNew["item_id"] = Val.ToInt(lueFromItem.EditValue);
                    drwNew["item_name"] = Val.ToString(lueFromItem.Text);

                    drwNew["size_id"] = Val.ToInt(lueFromSize.EditValue);
                    drwNew["size_name"] = Val.ToString(lueFromSize.Text);
                    drwNew["pcs"] = numPcs;
                    drwNew["rate"] = Val.ToDecimal(txtFromRate.Text);
                    drwNew["amount"] = Math.Round(Val.ToDecimal(txtFromPcs.Text) * Val.ToDecimal(txtFromRate.Text), 2);
                    drwNew["flag"] = Val.ToInt(0);
                    m_from_srno = m_from_srno + 1;
                    drwNew["sr_no"] = Val.ToInt(m_from_srno);

                    m_dtbFromStockJournal.Rows.Add(drwNew);

                    dgvFromStockJournal.MoveLast();

                    //DialogResult result = MessageBox.Show("Do you want to Add data?", "Confirmation", MessageBoxButtons.YesNoCancel);
                    //if (result != DialogResult.Yes)
                    //{
                    //    m_blnadd = false;
                    //    blnReturn = false;
                    //    return blnReturn;
                    //}
                }
                else if (btnFromAdd.Text == "&Update")
                {
                    if (!m_IsUpdate)
                    {
                        Global.Message("You can't update this record", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        blnReturn = false;
                        return blnReturn;
                    }

                    objStockJournal = new StockJournal();

                    if (m_dtbFromStockJournal.Select("item_id ='" + Val.ToInt(lueFromItem.EditValue) + "' AND color_id ='" + Val.ToInt(lueFromColor.EditValue) + "' AND size_id ='" + Val.ToInt(lueFromSize.EditValue) + "'").Length > 0)
                    {
                        for (int i = 0; i < m_dtbFromStockJournal.Rows.Count; i++)
                        {
                            if (m_dtbFromStockJournal.Select("stock_journal_id ='" + m_from_stock_journal_id + "' AND sr_no = '" + m_update_srno + "'").Length > 0)
                            {
                                if (m_dtbFromStockJournal.Rows[m_update_srno - 1]["stock_journal_id"].ToString() == m_from_stock_journal_id.ToString())
                                {
                                    m_dtbFromStockJournal.Rows[m_update_srno - 1]["pcs"] = Val.ToDecimal(txtFromPcs.Text);
                                    m_dtbFromStockJournal.Rows[m_update_srno - 1]["rate"] = Val.ToDecimal(txtFromRate.Text);
                                    m_dtbFromStockJournal.Rows[m_update_srno - 1]["flag"] = 1;
                                    m_dtbFromStockJournal.Rows[m_update_srno - 1]["amount"] = Math.Round(Val.ToDecimal(txtFromPcs.Text) * Val.ToDecimal(txtFromRate.Text), 3);

                                    m_dtbFromStockJournal.Rows[m_update_srno - 1]["item_id"] = Val.ToInt(lueFromItem.EditValue);
                                    m_dtbFromStockJournal.Rows[m_update_srno - 1]["item_name"] = Val.ToString(lueFromItem.Text);

                                    m_dtbFromStockJournal.Rows[m_update_srno - 1]["color_id"] = Val.ToInt(lueFromColor.EditValue);
                                    m_dtbFromStockJournal.Rows[m_update_srno - 1]["color_name"] = Val.ToString(lueFromColor.Text);

                                    m_dtbFromStockJournal.Rows[m_update_srno - 1]["size_id"] = Val.ToInt(lueFromSize.EditValue);
                                    m_dtbFromStockJournal.Rows[m_update_srno - 1]["size_name"] = Val.ToString(lueFromSize.Text);
                                    break;
                                }
                            }
                        }
                        btnFromAdd.Text = "&Add";
                    }
                    else
                    {
                        for (int i = 0; i < m_dtbFromStockJournal.Rows.Count; i++)
                        {
                            if (m_dtbFromStockJournal.Select("stock_journal_id ='" + m_from_stock_journal_id + "' AND sr_no = '" + m_update_srno + "'").Length > 0)
                            {
                                if (m_dtbFromStockJournal.Rows[m_update_srno - 1]["stock_journal_id"].ToString() == m_from_stock_journal_id.ToString())
                                {
                                    m_dtbFromStockJournal.Rows[m_update_srno - 1]["pcs"] = Val.ToDecimal(txtFromPcs.Text);
                                    m_dtbFromStockJournal.Rows[m_update_srno - 1]["rate"] = Val.ToDecimal(txtFromRate.Text);
                                    m_dtbFromStockJournal.Rows[m_update_srno - 1]["flag"] = 1;
                                    m_dtbFromStockJournal.Rows[m_update_srno - 1]["item_id"] = Val.ToInt(lueFromItem.EditValue);
                                    m_dtbFromStockJournal.Rows[m_update_srno - 1]["color_id"] = Val.ToInt(lueFromColor.EditValue);
                                    m_dtbFromStockJournal.Rows[m_update_srno - 1]["size_id"] = Val.ToInt(lueFromSize.EditValue);
                                    m_dtbFromStockJournal.Rows[m_update_srno - 1]["item_name"] = Val.ToString(lueFromItem.Text);
                                    m_dtbFromStockJournal.Rows[m_update_srno - 1]["color_name"] = Val.ToString(lueFromColor.Text);
                                    m_dtbFromStockJournal.Rows[m_update_srno - 1]["size_name"] = Val.ToString(lueFromSize.Text);

                                    m_dtbFromStockJournal.Rows[m_update_srno - 1]["amount"] = Math.Round(Val.ToDecimal(txtFromPcs.Text) * Val.ToDecimal(txtFromRate.Text), 3);
                                }
                            }
                        }
                        btnFromAdd.Text = "&Add";
                    }
                    dgvFromStockJournal.MoveLast();
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
                    if (m_dtbFromStockJournal.Rows.Count == 0 && m_dtbToStockJournal.Rows.Count == 0)
                    {
                        lstError.Add(new ListError(22, "Record"));
                        if (!blnFocus)
                        {
                            blnFocus = true;
                        }
                    }
                    if (dgvFromStockJournal == null && dgvToStockJournal == null)
                    {
                        lstError.Add(new ListError(22, "Record"));
                        if (!blnFocus)
                        {
                            blnFocus = true;
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
        private bool ValidateFromDetails()
        {
            bool blnFocus = false;
            List<ListError> lstError = new List<ListError>();

            try
            {
                if (m_blnadd)
                {
                    if (lueFromItem.Text == "")
                    {
                        lstError.Add(new ListError(13, "From Item"));
                        if (!blnFocus)
                        {
                            blnFocus = true;
                            lueFromItem.Focus();
                        }
                    }
                    if (lueFromColor.Text == "")
                    {
                        lstError.Add(new ListError(13, "From Color"));
                        if (!blnFocus)
                        {
                            blnFocus = true;
                            lueFromColor.Focus();
                        }
                    }
                    if (lueFromSize.Text == "")
                    {
                        lstError.Add(new ListError(13, "From Size"));
                        if (!blnFocus)
                        {
                            blnFocus = true;
                            lueFromSize.Focus();
                        }
                    }
                    if (Val.ToDouble(txtFromPcs.Text) == 0)
                    {
                        lstError.Add(new ListError(12, "From Pcs"));
                        if (!blnFocus)
                        {
                            blnFocus = true;
                            txtFromPcs.Focus();
                        }
                    }
                    if (Val.ToDouble(txtFromRate.Text) == 0)
                    {
                        lstError.Add(new ListError(12, "From Rate"));
                        if (!blnFocus)
                        {
                            blnFocus = true;
                            txtFromRate.Focus();
                        }
                    }
                    if (Val.ToDouble(txtFromAmount.Text) == 0)
                    {
                        lstError.Add(new ListError(12, "From Amount"));
                        if (!blnFocus)
                        {
                            blnFocus = true;
                            txtFromAmount.Focus();
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
        private bool ValidateToDetails()
        {
            bool blnFocus = false;
            List<ListError> lstError = new List<ListError>();

            try
            {
                if (m_blnadd)
                {
                    if (lueToItem.Text == "")
                    {
                        lstError.Add(new ListError(13, "To Item"));
                        if (!blnFocus)
                        {
                            blnFocus = true;
                            lueToItem.Focus();
                        }
                    }
                    if (lueToColor.Text == "")
                    {
                        lstError.Add(new ListError(13, "To Color"));
                        if (!blnFocus)
                        {
                            blnFocus = true;
                            lueToColor.Focus();
                        }
                    }
                    if (lueToSize.Text == "")
                    {
                        lstError.Add(new ListError(13, "To Size"));
                        if (!blnFocus)
                        {
                            blnFocus = true;
                            lueToSize.Focus();
                        }
                    }
                    if (Val.ToDouble(txtToPcs.Text) == 0)
                    {
                        lstError.Add(new ListError(12, "To Pcs"));
                        if (!blnFocus)
                        {
                            blnFocus = true;
                            txtToPcs.Focus();
                        }
                    }
                    if (Val.ToDouble(txtToRate.Text) == 0)
                    {
                        lstError.Add(new ListError(12, "To Rate"));
                        if (!blnFocus)
                        {
                            blnFocus = true;
                            txtToRate.Focus();
                        }
                    }
                    if (Val.ToDouble(txtToAmount.Text) == 0)
                    {
                        lstError.Add(new ListError(12, "To Amount"));
                        if (!blnFocus)
                        {
                            blnFocus = true;
                            txtToAmount.Focus();
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
                if (!GenerateFromStockJournalDetails())
                {
                    blnReturn = false;
                    return blnReturn;
                }
                if (!GenerateToStockJournalDetails())
                {
                    blnReturn = false;
                    return blnReturn;
                }
                lblMode.Tag = null;
                lueFromItem.EditValue = System.DBNull.Value;
                lueFromColor.EditValue = System.DBNull.Value;
                lueFromSize.EditValue = System.DBNull.Value;

                lueToItem.EditValue = System.DBNull.Value;
                lueToColor.EditValue = System.DBNull.Value;
                lueToSize.EditValue = System.DBNull.Value;

                dtpJNDate.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
                dtpJNDate.Properties.Mask.EditMask = "dd-MM-yyyy";
                dtpJNDate.Properties.Mask.UseMaskAsDisplayFormat = true;
                dtpJNDate.Properties.CharacterCasing = CharacterCasing.Upper;
                dtpJNDate.EditValue = DateTime.Now;
                txtFromPcs.Text = string.Empty;
                txtFromRate.Text = string.Empty;
                txtFromAmount.Text = string.Empty;
                txtToPcs.Text = string.Empty;
                txtToRate.Text = string.Empty;
                txtToAmount.Text = string.Empty;
                txtRemark.Text = string.Empty;
                btnFromAdd.Text = "&Add";
                btnToAdd.Text = "&Add";
                m_from_srno = 0;
                m_To_srno = 0;
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
        private bool GenerateFromStockJournalDetails()
        {
            bool blnReturn = true;
            try
            {
                if (m_dtbFromStockJournal.Rows.Count > 0)
                    m_dtbFromStockJournal.Rows.Clear();

                m_dtbFromStockJournal = new DataTable();

                m_dtbFromStockJournal.Columns.Add("sr_no", typeof(int));
                m_dtbFromStockJournal.Columns.Add("stock_journal_id", typeof(int));
                m_dtbFromStockJournal.Columns.Add("item_id", typeof(int));
                m_dtbFromStockJournal.Columns.Add("item_name", typeof(string));
                m_dtbFromStockJournal.Columns.Add("color_id", typeof(int));
                m_dtbFromStockJournal.Columns.Add("color_name", typeof(string));
                m_dtbFromStockJournal.Columns.Add("size_id", typeof(int));
                m_dtbFromStockJournal.Columns.Add("size_name", typeof(string));
                m_dtbFromStockJournal.Columns.Add("pcs", typeof(decimal)).DefaultValue = 0;
                m_dtbFromStockJournal.Columns.Add("rate", typeof(decimal)).DefaultValue = 0;
                m_dtbFromStockJournal.Columns.Add("amount", typeof(decimal)).DefaultValue = 0;
                m_dtbFromStockJournal.Columns.Add("flag", typeof(int)).DefaultValue = 0;

                grdFromStockJournal.DataSource = m_dtbFromStockJournal;
                grdFromStockJournal.Refresh();
            }
            catch (Exception ex)
            {
                BLL.General.ShowErrors(ex);
                blnReturn = false;
            }
            return blnReturn;
        }

        private bool GenerateToStockJournalDetails()
        {
            bool blnReturn = true;
            try
            {
                if (m_dtbToStockJournal.Rows.Count > 0)
                    m_dtbToStockJournal.Rows.Clear();

                m_dtbToStockJournal = new DataTable();

                m_dtbToStockJournal.Columns.Add("sr_no", typeof(int));
                m_dtbToStockJournal.Columns.Add("stock_journal_id", typeof(int));
                m_dtbToStockJournal.Columns.Add("item_id", typeof(int));
                m_dtbToStockJournal.Columns.Add("item_name", typeof(string));
                m_dtbToStockJournal.Columns.Add("color_id", typeof(int));
                m_dtbToStockJournal.Columns.Add("color_name", typeof(string));
                m_dtbToStockJournal.Columns.Add("size_id", typeof(int));
                m_dtbToStockJournal.Columns.Add("size_name", typeof(string));
                m_dtbToStockJournal.Columns.Add("pcs", typeof(decimal)).DefaultValue = 0;
                m_dtbToStockJournal.Columns.Add("rate", typeof(decimal)).DefaultValue = 0;
                m_dtbToStockJournal.Columns.Add("amount", typeof(decimal)).DefaultValue = 0;
                m_dtbToStockJournal.Columns.Add("flag", typeof(int)).DefaultValue = 0;

                grdToStockJournal.DataSource = m_dtbToStockJournal;
                grdToStockJournal.Refresh();
            }
            catch (Exception ex)
            {
                BLL.General.ShowErrors(ex);
                blnReturn = false;
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
        #endregion   
        private void backgroundWorker_JangedEntry_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.Default;
                Conn = new BeginTranConnection(true, false);

                StockJournalProperty objStockJournalProperty = new StockJournalProperty();
                StockJournal objStockJournal = new StockJournal();
                try
                {
                    Union_ID = 0;

                    foreach (DataRow drw in m_dtbFromStockJournal.Rows)
                    {
                        objStockJournalProperty = new StockJournalProperty();
                        objStockJournalProperty.stock_journal_id = Val.ToInt(lblMode.Tag);
                        objStockJournalProperty.journal_date = Val.DBDate(dtpJNDate.Text);
                        objStockJournalProperty.remarks = Val.ToString(txtRemark.Text);
                        objStockJournalProperty.form_id = m_numForm_id;
                        objStockJournalProperty.union_id = Union_ID;
                        objStockJournalProperty.from_srno = Val.ToInt(drw["sr_no"]);
                        objStockJournalProperty.from_item_id = Val.ToInt(drw["item_id"]);
                        objStockJournalProperty.from_color_id = Val.ToInt(drw["color_id"]);
                        objStockJournalProperty.from_size_id = Val.ToInt(drw["size_id"]);
                        objStockJournalProperty.from_pcs = Val.ToDecimal(drw["pcs"]);
                        objStockJournalProperty.from_rate = Val.ToDecimal(drw["rate"]);
                        objStockJournalProperty.from_amount = Val.ToDecimal(drw["amount"]);
                        objStockJournalProperty.flag = Val.ToInt(drw["flag"]);

                        objStockJournalProperty = objStockJournal.Save(objStockJournalProperty, DLL.GlobalDec.EnumTran.Continue, Conn);

                        Union_ID = Val.ToInt64(objStockJournalProperty.union_id);
                    }

                    foreach (DataRow drw in m_dtbToStockJournal.Rows)
                    {
                        objStockJournalProperty = new StockJournalProperty();
                        objStockJournalProperty.stock_journal_id = Val.ToInt(lblMode.Tag);
                        objStockJournalProperty.journal_date = Val.DBDate(dtpJNDate.Text);
                        objStockJournalProperty.remarks = Val.ToString(txtRemark.Text);
                        objStockJournalProperty.form_id = m_numForm_id;
                        objStockJournalProperty.union_id = Union_ID;
                        objStockJournalProperty.to_srno = Val.ToInt(drw["sr_no"]);
                        objStockJournalProperty.to_item_id = Val.ToInt(drw["item_id"]);
                        objStockJournalProperty.to_color_id = Val.ToInt(drw["color_id"]);
                        objStockJournalProperty.to_size_id = Val.ToInt(drw["size_id"]);
                        objStockJournalProperty.to_pcs = Val.ToDecimal(drw["pcs"]);
                        objStockJournalProperty.to_rate = Val.ToDecimal(drw["rate"]);
                        objStockJournalProperty.to_amount = Val.ToDecimal(drw["amount"]);
                        objStockJournalProperty.flag = Val.ToInt(drw["flag"]);

                        objStockJournalProperty = objStockJournal.Save(objStockJournalProperty, DLL.GlobalDec.EnumTran.Continue, Conn);

                        Union_ID = Val.ToInt64(objStockJournalProperty.union_id);
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
                    objStockJournalProperty = null;
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
                if (Union_ID > 0)
                {
                    if (Val.ToInt(lblMode.Tag) == 0)
                    {
                        Global.Confirm("Stock Journal Data Save Successfully");
                        ClearDetails();
                    }
                    else
                    {
                        Global.Confirm("Stock Journal Data Update Successfully");
                        ClearDetails();
                    }
                }
                else
                {
                    Global.Confirm("Error In Stock Journal");
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

        private void FrmStockJournal_Load(object sender, EventArgs e)
        {
            try
            {
                if (!LoadDefaults())
                {
                    btnFromAdd.Enabled = false;
                    btnToAdd.Enabled = false;
                    btnClear.Enabled = false;
                    btnSave.Enabled = false;
                }
                else
                {
                    ClearDetails();
                }
            }
            catch (Exception ex)
            {
                Global.Message(ex.ToString());
                return;
            }
        }

        private void btnFromAdd_Click(object sender, EventArgs e)
        {
            if (AddInFromGrid())
            {
                lueFromItem.Focus();
                lueFromItem.ShowPopup();
                lueFromItem.EditValue = DBNull.Value;
                lueFromColor.EditValue = DBNull.Value;
                lueFromSize.EditValue = DBNull.Value;
                txtFromPcs.Text = string.Empty;
                txtFromRate.Text = string.Empty;
                txtFromAmount.Text = string.Empty;
            }
        }

        private void btnToAdd_Click(object sender, EventArgs e)
        {
            if (AddInToGrid())
            {
                lueToItem.Focus();
                lueToItem.ShowPopup();
                lueToItem.EditValue = DBNull.Value;
                lueToColor.EditValue = DBNull.Value;
                lueToSize.EditValue = DBNull.Value;
                txtToPcs.Text = string.Empty;
                txtToRate.Text = string.Empty;
                txtToAmount.Text = string.Empty;
            }
        }

        private bool AddInToGrid()
        {
            bool blnReturn = true;

            try
            {
                m_blnadd = true;
                m_blnsave = false;

                if (!ValidateToDetails())
                {
                    m_blnadd = false;
                    blnReturn = false;
                    return blnReturn;
                }

                if (btnToAdd.Text == "&Add")
                {
                    objStockJournal = new StockJournal();

                    DataRow[] dr = m_dtbToStockJournal.Select("item_id = " + Val.ToInt(lueToItem.EditValue) + " AND color_id = " + Val.ToInt(lueToColor.EditValue) + " AND size_id = " + Val.ToInt(lueToSize.EditValue));

                    if (dr.Count() == 1)
                    {
                        Global.Message("Record already exists in grid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lueFromItem.Focus();
                        blnReturn = false;
                        return blnReturn;
                    }
                    DataRow drwNew = m_dtbToStockJournal.NewRow();
                    decimal numRate = Val.ToDecimal(txtToRate.Text);
                    decimal numAmount = Val.ToDecimal(txtToAmount.Text);
                    decimal numPcs = Val.ToDecimal(txtToPcs.Text);

                    drwNew["color_id"] = Val.ToInt(lueToColor.EditValue);
                    drwNew["color_name"] = Val.ToString(lueToColor.Text);

                    drwNew["item_id"] = Val.ToInt(lueToItem.EditValue);
                    drwNew["item_name"] = Val.ToString(lueToItem.Text);

                    drwNew["size_id"] = Val.ToInt(lueToSize.EditValue);
                    drwNew["size_name"] = Val.ToString(lueToSize.Text);
                    drwNew["pcs"] = numPcs;
                    drwNew["rate"] = Val.ToDecimal(txtToRate.Text);
                    drwNew["amount"] = Math.Round(Val.ToDecimal(txtToPcs.Text) * Val.ToDecimal(txtToRate.Text), 2);
                    drwNew["flag"] = Val.ToInt(0);
                    m_To_srno = m_To_srno + 1;
                    drwNew["sr_no"] = Val.ToInt(m_To_srno);

                    m_dtbToStockJournal.Rows.Add(drwNew);

                    dgvToStockJournal.MoveLast();

                    //DialogResult result = MessageBox.Show("Do you want to Add data?", "Confirmation", MessageBoxButtons.YesNoCancel);
                    //if (result != DialogResult.Yes)
                    //{
                    //    m_blnadd = false;
                    //    blnReturn = false;
                    //    return blnReturn;
                    //}
                }
                else if (btnToAdd.Text == "&Update")
                {
                    if (!m_IsUpdate)
                    {
                        Global.Message("You can't update this record", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        blnReturn = false;
                        return blnReturn;
                    }
                    objStockJournal = new StockJournal();

                    if (m_dtbToStockJournal.Select("item_id ='" + Val.ToInt(lueToItem.EditValue) + "' AND color_id ='" + Val.ToInt(lueToColor.EditValue) + "' AND size_id ='" + Val.ToInt(lueToSize.EditValue) + "'").Length > 0)
                    {
                        for (int i = 0; i < m_dtbToStockJournal.Rows.Count; i++)
                        {
                            if (m_dtbToStockJournal.Select("stock_journal_id ='" + m_to_stock_journal_id + "' AND sr_no = '" + m_update_srno + "'").Length > 0)
                            {
                                if (m_dtbToStockJournal.Rows[m_update_srno - 1]["stock_journal_id"].ToString() == m_to_stock_journal_id.ToString())
                                {
                                    m_dtbToStockJournal.Rows[m_update_srno - 1]["pcs"] = Val.ToDecimal(txtToPcs.Text);
                                    m_dtbToStockJournal.Rows[m_update_srno - 1]["rate"] = Val.ToDecimal(txtToRate.Text);
                                    m_dtbToStockJournal.Rows[m_update_srno - 1]["flag"] = 1;
                                    m_dtbToStockJournal.Rows[m_update_srno - 1]["to_amount"] = Math.Round(Val.ToDecimal(txtToPcs.Text) * Val.ToDecimal(txtToRate.Text), 3);

                                    m_dtbToStockJournal.Rows[m_update_srno - 1]["item_id"] = Val.ToInt(lueToItem.EditValue);
                                    m_dtbToStockJournal.Rows[m_update_srno - 1]["item_name"] = Val.ToString(lueToItem.Text);

                                    m_dtbToStockJournal.Rows[m_update_srno - 1]["color_id"] = Val.ToInt(lueToColor.EditValue);
                                    m_dtbToStockJournal.Rows[m_update_srno - 1]["color_name"] = Val.ToString(lueToColor.Text);

                                    m_dtbToStockJournal.Rows[m_update_srno - 1]["size_id"] = Val.ToInt(lueToSize.EditValue);
                                    m_dtbToStockJournal.Rows[m_update_srno - 1]["size_name"] = Val.ToString(lueToSize.Text);
                                    break;
                                }
                            }
                        }
                        btnToAdd.Text = "&Add";
                    }
                    else
                    {
                        for (int i = 0; i < m_dtbToStockJournal.Rows.Count; i++)
                        {
                            if (m_dtbToStockJournal.Select("stock_journal_id ='" + m_to_stock_journal_id + "' AND sr_no = '" + m_update_srno + "'").Length > 0)
                            {
                                if (m_dtbToStockJournal.Rows[m_update_srno - 1]["stock_journal_id"].ToString() == m_to_stock_journal_id.ToString())
                                {
                                    m_dtbToStockJournal.Rows[m_update_srno - 1]["pcs"] = Val.ToDecimal(txtToPcs.Text);
                                    m_dtbToStockJournal.Rows[m_update_srno - 1]["rate"] = Val.ToDecimal(txtToRate.Text);
                                    m_dtbToStockJournal.Rows[m_update_srno - 1]["flag"] = 1;
                                    m_dtbToStockJournal.Rows[m_update_srno - 1]["item_id"] = Val.ToInt(lueToItem.EditValue);
                                    m_dtbToStockJournal.Rows[m_update_srno - 1]["color_id"] = Val.ToInt(lueToColor.EditValue);
                                    m_dtbToStockJournal.Rows[m_update_srno - 1]["size_id"] = Val.ToInt(lueToSize.EditValue);
                                    m_dtbToStockJournal.Rows[m_update_srno - 1]["item_name"] = Val.ToString(lueToItem.Text);
                                    m_dtbToStockJournal.Rows[m_update_srno - 1]["color_name"] = Val.ToString(lueToColor.Text);
                                    m_dtbToStockJournal.Rows[m_update_srno - 1]["size_name"] = Val.ToString(lueToSize.Text);

                                    m_dtbToStockJournal.Rows[m_update_srno - 1]["amount"] = Math.Round(Val.ToDecimal(txtToPcs.Text) * Val.ToDecimal(txtToRate.Text), 3);
                                }
                            }
                        }
                        btnToAdd.Text = "&Add";
                    }
                    dgvToStockJournal.MoveLast();
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
        private void dgvFromStockJournal_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                if (e.RowHandle >= 0)
                {
                    if (e.Clicks == 2)
                    {
                        DataRow Drow = dgvFromStockJournal.GetDataRow(e.RowHandle);
                        btnFromAdd.Text = "&Update";
                        lueFromColor.EditValue = Val.ToInt64(Drow["color_id"]);
                        lueFromSize.EditValue = Val.ToInt64(Drow["size_id"]);
                        lueFromItem.EditValue = Val.ToInt64(Drow["item_id"]);
                        txtFromPcs.Text = Val.ToString(Drow["pcs"]);
                        txtFromRate.Text = Val.ToString(Drow["rate"]);
                        txtFromAmount.Text = Val.ToString(Drow["amount"]);
                        m_from_stock_journal_id = Val.ToInt(Drow["stock_journal_id"]);
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
        private void dgvToStockJournal_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                if (e.RowHandle >= 0)
                {
                    if (e.Clicks == 2)
                    {
                        DataRow Drow = dgvToStockJournal.GetDataRow(e.RowHandle);
                        btnToAdd.Text = "&Update";
                        lueToColor.EditValue = Val.ToInt64(Drow["color_id"]);
                        lueToSize.EditValue = Val.ToInt64(Drow["size_id"]);
                        lueToItem.EditValue = Val.ToInt64(Drow["item_id"]);
                        txtToPcs.Text = Val.ToString(Drow["pcs"]);
                        txtToRate.Text = Val.ToString(Drow["rate"]);
                        txtToAmount.Text = Val.ToString(Drow["amount"]);
                        m_from_stock_journal_id = Val.ToInt(Drow["stock_journal_id"]);
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

        private void txtToPcs_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtToRate_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtToAmount.Text = string.Format("{0:0.00}", Val.ToDecimal(txtToPcs.Text) * Val.ToDecimal(txtToRate.Text));
            }
            catch (Exception ex)
            {
                General.ShowErrors(ex.ToString());
                return;
            }
        }
    }
}