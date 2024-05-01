using Account_Management.Class;
using Account_Management.Report.Barcode_Print;
using BLL;
using BLL.FunctionClasses.Master;
using BLL.FunctionClasses.Transaction;
using BLL.PropertyClasses.Master;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Account_Management.Transaction.MFG
{
    public partial class FrmMFGBarcodePrint : DevExpress.XtraEditors.XtraForm
    {
        #region Declaration

        Validation Val = new Validation();
        DataTable dtPrint = new DataTable();

        FormPer ObjPer = new FormPer();
        public DataTable DTab = new DataTable();
        public string ColumnsToHide = "";
        public bool AllowMultiSelect = false;
        public string ColumnHeaderCaptions = "";
        public string SearchText = "";
        public string SearchField = "";
        public string ValueMember = "";
        public string SelectedValue = "";
        DataTable m_dtbParam = new DataTable();
        DataTable m_dtbKapan = new DataTable();
        FormEvents objBOFormEvents = new FormEvents();
        Control _NextEnteredControl;
        private List<Control> _tabControls;
        DataTable m_dtbDetails = new DataTable();
        Purchase objPurchase = new Purchase();

        DataTable DtControlSettings = new DataTable();

        #endregion

        #region Constructor
        public FrmMFGBarcodePrint()
        {
            InitializeComponent();

            _NextEnteredControl = new Control();
            _tabControls = new List<Control>();

            DtControlSettings = new DataTable();
            m_dtbDetails = new DataTable();
        }
        public void ShowForm()
        {
            ObjPer.FormName = this.Name.ToUpper();
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
            DataTable DtControlSettings = new DataTable();
            ControlSettingDT(Val.ToInt(ObjPer.form_id), this);
            AddGotFocusListener(this);
            AddKeyPressListener(this);
            this.KeyPreview = true;

            TabControlsToList(this.Controls);
            _tabControls = _tabControls.OrderBy(x => x.TabIndex).ToList();

            //End for Dynamic Setting By Praful On 01022020


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
            objBOFormEvents.FormResize = true;
            objBOFormEvents.FormClosing = true;
            objBOFormEvents.ObjToDispose.Add(Val);
            objBOFormEvents.ObjToDispose.Add(objBOFormEvents);
        }

        #endregion

        #region Form Events
        private void FrmMFGBarcodePrint_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        #endregion

        #region Events
        private void BtnPrint_Click(object sender, EventArgs e)
        {

            if (ObjPer.AllowPrint == false)
            {
                Global.Message(BLL.GlobalDec.gStrPermissionPrintMsg);
                return;
            }
            BtnPrint.Enabled = false;
            DialogResult result = MessageBox.Show("Do you want to Barcode Print?", "Confirmation", MessageBoxButtons.YesNoCancel);
            if (result != DialogResult.Yes)
            {
                BtnPrint.Enabled = true;
                return;
            }

            BarcodePrint printBarCode = new BarcodePrint();

            DataTable dtCheckedBarcode = (DataTable)GrdBarcodePrint.DataSource;
            dtCheckedBarcode.AcceptChanges();
            if (dtCheckedBarcode.Select("SEL = 'True' ").Length > 0)
            {
                dtCheckedBarcode = dtCheckedBarcode.Select("SEL = 'True' ").CopyToDataTable();
                for (int i = 0; i < dtCheckedBarcode.Rows.Count; i++)
                {
                    //string Sub_lot_no = Val.ToString(dtCheckedBarcode.Rows[i]["sr_no"].ToString());
                    //if (Sub_lot_no.ToString() != "")
                    //{
                    if (Val.ToInt64(dtCheckedBarcode.Rows[i]["stock_id"]) != 0 && Val.ToDecimal(dtCheckedBarcode.Rows[i]["balance_pcs"]) != 0)
                    {
                        printBarCode.Stock_AddPkt(dtCheckedBarcode.Rows[i]["item_name"].ToString(), dtCheckedBarcode.Rows[i]["color_name"].ToString(), dtCheckedBarcode.Rows[i]["size_name"].ToString(),
                            Val.ToInt(dtCheckedBarcode.Rows[i]["stock_id"]), Val.ToDecimal(dtCheckedBarcode.Rows[i]["balance_pcs"]), true);
                    }
                    //}
                    //else
                    //{
                    //    printBarCode.AddPkt(dtCheckedBarcode.Rows[i]["rough_cut_no"].ToString(), Val.ToString(i + 1), Val.DBDate(dtCheckedBarcode.Rows[i]["entry_date"].ToString()),
                    //            Val.ToInt(dtCheckedBarcode.Rows[i]["lot_id"]), Val.ToInt(dtCheckedBarcode.Rows[i]["balance_pcs"]), Val.ToDecimal(dtCheckedBarcode.Rows[i]["carat"]), true);
                    //}

                }
                printBarCode.Stock_PrintTSC(Val.ToInt64(txtBarcodeCount.Text));
            }
            else
            {
                Global.Message("Please Select One Lot Atleast.");
                BtnPrint.Enabled = true;
                return;
            }
            BtnPrint.Enabled = true;
        }
        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FrmMFGBarcodePrint_Load(object sender, EventArgs e)
        {
            try
            {
                Global.LOOKUPCheckedItem(LueItem);
                Global.LOOKUPCheckedColor(LueColor);
                Global.LOOKUPCheckedSize(LueSize);

                LueItem.Focus();
                // Add By Praful On 29072021

                //DTab_KapanWiseData = Global.GetRoughStockWise(Val.ToInt(0), Val.ToInt32(0));

                // End By Praful On 29072021
            }
            catch (Exception ex)
            {
                Global.ErrorMessage(ex.Message);
            }
        }

        #endregion

        #region Grid Events
        private void GrdDet_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "SEL")
            {
                if (Val.ToBoolean(DgvBarcodePrint.GetRowCellValue(e.RowHandle, "SEL")) == true)
                {
                    DgvBarcodePrint.SetRowCellValue(e.RowHandle, "SEL", false);
                }
                else
                {
                    DgvBarcodePrint.SetRowCellValue(e.RowHandle, "SEL", true);
                }
            }
        }
        private void GrdDet_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        #endregion

        #region Other Function

        private void GetSummary()
        {
            try
            {
                double IntSelPcs = 0; double IntSelLot = 0; double DouSelCarat = 0;
                System.Data.DataTable DtTransfer = (System.Data.DataTable)GrdBarcodePrint.DataSource;
                DgvBarcodePrint.PostEditor();
                Global.DtTransfer.AcceptChanges();

                if (DtTransfer != null)
                {
                    if (DtTransfer.Rows.Count > 0)
                    {
                        foreach (DataRow DRow in DtTransfer.Rows)
                        {
                            if (Val.ToString(DRow["SEL"]) == "True")
                            {
                                IntSelLot = IntSelLot + 1;
                                IntSelPcs = IntSelPcs + Val.Val(DRow["balance_pcs"]);
                            }
                        }
                    }
                }
                txtSelLot.Text = IntSelLot.ToString();
                txtSelPcs.Text = IntSelPcs.ToString();
            }
            catch
            {
            }
        }

        #endregion

        #region Repository Events
        private void repSelect_CheckedChanged(object sender, EventArgs e)
        {
            GetSummary();
        }

        private void repSelect_MouseUp(object sender, MouseEventArgs e)
        {
            GetSummary();
        }

        private void GrdDet_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Q)
            {
                try
                {
                    if (ChkAll.Checked)
                    {
                        ChkAll.Checked = false;
                    }
                    else
                    {
                        ChkAll.Checked = true;
                    }
                    for (int i = 0; i < DgvBarcodePrint.RowCount; i++)
                    {
                        if (ChkAll.Checked == true)
                        {
                            bool b = true;
                            DgvBarcodePrint.SetRowCellValue(i, "SEL", b);
                        }
                        else
                        {
                            bool b = false;
                            DgvBarcodePrint.SetRowCellValue(i, "SEL", b);
                        }
                    }
                    GetSummary();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        #endregion

        #region Checkbox Events

        private void ChkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < DgvBarcodePrint.RowCount; i++)
                {
                    if (ChkAll.Checked == true)
                    {
                        bool b = true;
                        DgvBarcodePrint.SetRowCellValue(i, "SEL", b);
                    }
                    else
                    {
                        bool b = false;
                        DgvBarcodePrint.SetRowCellValue(i, "SEL", b);
                    }
                }
                GetSummary();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        private void BtnShow_Click(object sender, EventArgs e)
        {
            m_dtbDetails = objPurchase.Barcode_Print_GetData(Val.Trim(LueItem.Properties.GetCheckedItems()), Val.Trim(LueColor.Properties.GetCheckedItems()), Val.Trim(LueSize.Properties.GetCheckedItems()));

            ChkAll.Visible = true;
            if (m_dtbDetails.Columns.Contains("SEL") == false)
            {
                if (m_dtbDetails.Columns.Contains("SEL") == false)
                {
                    DataColumn Col = new DataColumn();
                    Col.ColumnName = "SEL";
                    Col.DataType = typeof(bool);
                    Col.DefaultValue = false;
                    m_dtbDetails.Columns.Add(Col);
                }
            }
            m_dtbDetails.Columns["SEL"].SetOrdinal(0);

            GrdBarcodePrint.DataSource = m_dtbDetails;
            DgvBarcodePrint.BestFitColumns();
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < LueItem.Properties.Items.Count; i++)
                LueItem.Properties.Items[i].CheckState = CheckState.Unchecked;
            for (int i = 0; i < LueColor.Properties.Items.Count; i++)
                LueColor.Properties.Items[i].CheckState = CheckState.Unchecked;
            for (int i = 0; i < LueSize.Properties.Items.Count; i++)
                LueSize.Properties.Items[i].CheckState = CheckState.Unchecked;
            GrdBarcodePrint.DataSource = null;
            txtSelLot.Text = "0";
            txtSelPcs.Text = "0";
            LueItem.Focus();
        }

        private void txtBarcodeCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}