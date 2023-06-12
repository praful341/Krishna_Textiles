using BLL;
using BLL.FunctionClasses.Master;
using BLL.FunctionClasses.Utility;
using BLL.PropertyClasses.Master;
using DevExpress.XtraEditors;
using Krishna_Textiles.Class;
using Krishna_Textiles.Search;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
namespace Krishna_Textiles.Transaction
{
    public partial class FrmSingle_Setting : DevExpress.XtraEditors.XtraForm
    {
        #region Data Member
        BLL.BeginTranConnection Conn;
        BLL.FormEvents objBOFormEvents;
        BLL.FormPer ObjPer;
        BLL.Validation Val;

        Single_SettingProperty SingleSetting;
        FillCombo combo;
        FrmSearchNew FrmSearchNew;
        UserAuthentication objUser;
        Single_Setting ObjSingleSettings;

        DataTable dtSettings;
        DataTable DTab;
        public DataRow DRow { get; set; }

        int IntRes;
        #endregion

        #region Constructor
        public FrmSingle_Setting()
        {
            InitializeComponent();

            objBOFormEvents = new BLL.FormEvents();
            ObjPer = new BLL.FormPer();
            Val = new BLL.Validation();

            SingleSetting = new Single_SettingProperty();
            combo = new FillCombo();
            objUser = new UserAuthentication();
            ObjSingleSettings = new Single_Setting();

            dtSettings = new DataTable();
            DTab = new DataTable();

            IntRes = 0;
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
            this.Show();
            clear();
        }

        private void AttachFormEvents()
        {
            this.KeyPreview = true;
            objBOFormEvents.CurForm = this;
            objBOFormEvents.FormKeyDown = true;
            objBOFormEvents.FormKeyPress = false;
            objBOFormEvents.FormResize = false;
            objBOFormEvents.FormClosing = true;

            objBOFormEvents.ObjToDispose.Add(objBOFormEvents);
            objBOFormEvents.ObjToDispose.Add(Val);
        }

        #endregion

        #region Validation
        public Boolean ValSave()
        {
            try
            {
                if (txtFormName.Text == string.Empty)
                {
                    Global.ErrorMessage("Please Select Form Name.");
                    return false;
                }
                if (CheckColumn("column_name <> '' AND caption=''", "caption", "Please Insert Caption At Row "))
                    return false;

                if (CheckColumn("column_name <> '' AND tab_index IS NULL", "tab_index", "Please Insert Tab Order At Row "))
                    return false;

                return true;
            }
            catch (Exception ex)
            {
                Global.Message(ex.ToString());
                return true;
            }
        }
        private bool CheckColumn(string StrCriterea, string StrFocusedColumn, string StrMsg)
        {
            bool Flag = false;
            try
            {
                DataRow[] Dr = DTab.Select(StrCriterea);
                if (Dr != null && Dr.Count() > 0)
                {
                    int IntRowIndex = Dr[0].Table.Rows.IndexOf(Dr[0]);
                    GrdSingleSettings.FocusedRowHandle = IntRowIndex;
                    GrdSingleSettings.FocusedColumn = GrdSingleSettings.Columns[StrFocusedColumn];
                    Global.Message(StrMsg + " : " + (IntRowIndex + 1));
                    Flag = true;
                }
                return Flag;
            }
            catch (Exception ex)
            {
                Global.Message(ex.ToString());
                return Flag;
            }
        }
        private bool CheckDuplicateColumnName()
        {
            bool Flag = false;
            try
            {
                foreach (DataRow Drow in DTab.Rows)
                {
                    if (Val.ToString(Drow["column_name"]).Trim().Equals(string.Empty))
                        continue;

                    string StrColumnName = Val.ToString(Drow["column_name"]);
                    string StrFieldNo = Val.ToString(Drow["field_no"]);

                    if (CheckColumn("field_no <> " + StrFieldNo + " AND column_name='" + StrColumnName + "'", "column_name", "Duplicate [" + StrColumnName + "] Column Name At Row"))
                    {
                        Flag = true;
                        break;
                    }
                }

                return Flag;
            }
            catch (Exception ex)
            {
                Global.Message(ex.ToString());
                return Flag;
            }
        }

        #endregion

        #region TextBox Events

        private void txtFormName_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                if (Global.OnKeyPressToOpenPopup(e))
                {
                    FrmSearchNew = new FrmSearchNew();

                    FrmSearchNew.SearchText = e.KeyChar.ToString();
                    dt = new FillCombo().FillCmb(FillCombo.TABLE.Form_Master);

                    FrmSearchNew.DTab = dt;
                    FrmSearchNew.SearchField = "form_name";
                    FrmSearchNew.ColumnsToHide = "form_id";
                    FrmSearchNew.ColumnHeaderCaptions = "form_name=Form Name";
                    FrmSearchNew.ShowDialog();
                    e.Handled = true;
                    if (FrmSearchNew.DRow != null)
                    {
                        txtFormName.Text = Val.ToString(FrmSearchNew.DRow["form_name"]);
                        txtFormName.Tag = Val.ToString(FrmSearchNew.DRow["form_id"]);
                        GetData();
                    }
                    FrmSearchNew.Hide();
                    FrmSearchNew.Dispose();
                    FrmSearchNew = null;
                }
            }
            catch (Exception ex)
            {
                Global.Message(ex.ToString());
                return;
            }
        }

        #endregion

        #region Button Events

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (ValSave() == false)
                {
                    return;
                }

                if (CheckDuplicateColumnName())
                    return;

                DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = true;
                backgroundWorker_SingleSetting.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                Global.Message(this.Name, ex.Message);
            }
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Other Operation
        public void clear()
        {
            txtFormName.Text = string.Empty;
            txtFormName.Tag = string.Empty;
            LookupRole.EditValue = null;
            LookupCopyRole.EditValue = null;
            lblMode.Text = "Add Mode";

            dtSettings.Rows.Clear();
            GetData();
            lblMode.Visible = false;
        }
        private void GetData()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Single_SettingProperty Property = new Single_SettingProperty();
                Property.role_id = Val.ToInt32(LookupRole.EditValue);
                Property.form_id = Val.ToInt32(txtFormName.Tag);
                DataTable DTTemp = ObjSingleSettings.GetData(Property);
                DTab = DTTemp.Clone();
                DTab.Columns["is_visible"].DataType = typeof(bool);
                DTab.Columns["is_compulsory"].DataType = typeof(bool);
                DTab.Columns["is_editable"].DataType = typeof(bool);
                DTab.Columns["is_newrow"].DataType = typeof(bool);
                DTab.Columns["is_control"].DataType = typeof(bool);

                if (!DTab.Columns.Contains("any_change"))
                {
                    DTab.Columns.Add("any_change", typeof(bool));
                }

                if (!DTTemp.Columns.Contains("any_change"))
                {
                    DTTemp.Columns.Add("any_change", typeof(bool));
                }

                foreach (DataRow Drow in DTTemp.Rows)
                {
                    Drow["is_visible"] = Val.ToBooleanToInt(Drow["is_visible"]).Equals(1);
                    Drow["is_compulsory"] = Val.ToBooleanToInt(Drow["is_compulsory"]).Equals(1);
                    Drow["is_editable"] = Val.ToBooleanToInt(Drow["is_editable"]).Equals(1);
                    Drow["is_newrow"] = Val.ToBooleanToInt(Drow["is_newrow"]).Equals(1);
                    Drow["is_control"] = Val.ToBooleanToInt(Drow["is_control"]).Equals(1);
                    Drow["any_change"] = Val.ToBooleanToInt(Drow["any_change"]).Equals(1);
                    DTab.ImportRow(Drow);
                }

                AddRows();

                MainGrdSingleSettings.DataSource = DTab;
                MainGrdSingleSettings.RefreshDataSource();
                GrdSingleSettings.BestFitColumns();

                GrdSingleSettings.FocusedColumn = GrdSingleSettings.Columns["column_name"];
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Global.Message(ex.ToString());
                Cursor.Current = Cursors.Default;
                return;
            }
        }
        private void AddRows()
        {
            try
            {
                if (DTab == null || DTab.Rows.Count == 0)
                {
                    DataRow Drow = DTab.NewRow();
                    Drow["field_no"] = 1;
                    DTab.Rows.Add(Drow);
                }
            }
            catch (Exception ex)
            {
                Global.Message(ex.ToString());
                return;
            }
        }
        #endregion

        #region Repository Events
        private void repTxtTab_Index_Leave(object sender, EventArgs e)
        {
            try
            {
                DataRow Drow = GrdSingleSettings.GetFocusedDataRow();
                if (!Val.ToString(Drow["column_name"]).Trim().Equals(string.Empty) && !Val.ToString(Drow["caption"]).Trim().Equals(string.Empty) && !Val.ToString(Drow["tab_index"]).Trim().Equals(string.Empty) && GrdSingleSettings.IsLastRow)
                {
                    DataRow DrowNew = DTab.NewRow();
                    DrowNew["field_no"] = Val.ToInt(DTab.Compute("MAX(field_no)", "")) + 1;
                    DTab.Rows.Add(DrowNew);
                }
            }
            catch (Exception ex)
            {
                Global.Message(ex.ToString());
                return;
            }
        }
        #endregion

        #region Context Menu Events
        private void MNUDeleteSetting_Click(object sender, EventArgs e)
        {
            if (Global.Confirm("Are You Sure, To Delete Selected Column Rows ?", "DERP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    Single_SettingProperty Property = new Single_SettingProperty();
                    Property.role_id = Val.ToInt32(LookupRole.EditValue);
                    Property.form_id = Val.ToInt32(txtFormName.Tag);
                    Property.field_no = Val.ToInt(GrdSingleSettings.GetFocusedRowCellValue("field_no"));

                    int Res = ObjSingleSettings.DeleteSingleSettings(Property);

                    if (Res > 0)
                    {
                        GrdSingleSettings.DeleteRow(GrdSingleSettings.FocusedRowHandle);
                        AddRows();
                        Global.Message("Column Settings Deleted Successfully.");
                    }
                    else
                    {
                        Global.Message("Error In Deleting Columns Settings");
                    }
                    Cursor.Current = Cursors.Default;
                }
                catch (Exception Ex)
                {
                    Global.Message(Ex.Message);
                }
            }
        }
        #endregion
        private void BtnTransfer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(LookupRole.Text.Trim()))
            {
                Global.Confirm("Role Name Is Required");
                LookupRole.Focus();
                return;
            }
            if (string.IsNullOrEmpty(LookupCopyRole.Text.Trim()))
            {
                Global.Confirm("Copy Role Name Is Required");
                LookupCopyRole.Focus();
                return;
            }
            if (txtFormName.Text.ToString().Trim() == string.Empty)
            {
                txtFormName.Tag = 0;
            }
            if (XtraMessageBox.Show("Are You Sure Want To Save ?", "", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            Conn = new BeginTranConnection(true, false);
            try
            {
                IntRes = ObjSingleSettings.CopySingleSettings(Val.ToInt32(LookupRole.EditValue), Val.ToInt32(LookupCopyRole.EditValue), Val.ToInt(txtFormName.Tag), DLL.GlobalDec.EnumTran.Continue, Conn);
                Conn.Inter1.Commit();
            }
            catch (Exception ex)
            {
                IntRes = -1;
                Conn = null;
                General.ShowErrors(ex.ToString());
            }
            finally
            {
            }
            if (IntRes > 0)
            {
                Global.Message("Transfer Successfully");
                //clear();
                LookupRole.Focus();
                LookupCopyRole.EditValue = null;
                txtFormName.Focus();
                lblMode.Text = "Add Mode";

                dtSettings.Rows.Clear();

                GetData();
                lblMode.Visible = false;
            }
            else
            {
                Global.ErrorMessage("Save Fail");
                return;
            }
        }
        private void BtnUp_Click(object sender, EventArgs e)
        {
            try
            {
                int idx = GrdSingleSettings.FocusedRowHandle;
                if (idx == 0)
                    return;

                DataRow row = DTab.Rows[idx];

                DataRow oldRow = row;
                DataRow newRow = DTab.NewRow();

                newRow.ItemArray = oldRow.ItemArray;

                int oldRowIndex = DTab.Rows.IndexOf(row);

                int newRowIndex = oldRowIndex - 1;

                if (oldRowIndex > 0)
                {
                    DTab.Rows.Remove(oldRow);
                    DTab.Rows.InsertAt(newRow, newRowIndex);
                    DTab.Rows.IndexOf(newRow);
                }

                DTab.AcceptChanges();
                GrdSingleSettings.FocusedRowHandle = newRowIndex;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void BtnDown_Click(object sender, EventArgs e)
        {
            try
            {
                int totalRows = DTab.Rows.Count;
                int idx = GrdSingleSettings.FocusedRowHandle;
                if (idx == totalRows - 1)
                    return;

                DataRow row = DTab.Rows[idx];

                DataRow oldRow = row;
                DataRow newRow = DTab.NewRow();

                newRow.ItemArray = oldRow.ItemArray;

                int oldRowIndex = DTab.Rows.IndexOf(row);

                int newRowIndex = oldRowIndex + 1;

                if (oldRowIndex < (DTab.Rows.Count))
                {
                    DTab.Rows.Remove(oldRow);
                    DTab.Rows.InsertAt(newRow, newRowIndex);
                    DTab.Rows.IndexOf(newRow);
                }

                DTab.AcceptChanges();
                GrdSingleSettings.FocusedRowHandle = newRowIndex;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void BtnSetSequence_Click(object sender, EventArgs e)
        {
            DTab.AcceptChanges();

            Int64 IntSrNo = 0;
            foreach (DataRow DRow in DTab.Rows)
            {
                if (Val.ToString(DRow["column_name"]) == "")
                {
                    continue;
                }

                DRow["tab_index"] = Val.ToString(IntSrNo + 1);
                IntSrNo++;
                DRow["any_change"] = 1;
            }
            DTab.AcceptChanges();

            MainGrdSingleSettings.DataSource = DTab;
            MainGrdSingleSettings.RefreshDataSource();
            GrdSingleSettings.BestFitColumns();
        }
        private void GrdSingleSettings_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column.FieldName == "any_change")
                {
                    return;
                }
                DataRow DRow = GrdSingleSettings.GetDataRow(e.RowHandle);

                String OldStr = GrdSingleSettings.ActiveEditor.OldEditValue.ToString();

                String NewStr = GrdSingleSettings.ActiveEditor.EditValue.ToString();

                if (OldStr.ToUpper() != NewStr.ToUpper())
                    GrdSingleSettings.SetRowCellValue(e.RowHandle, "any_change", Val.ToInt32("1"));

            }
            catch (Exception ex)
            { }

        }
        private void FrmSingle_Setting_Shown(object sender, EventArgs e)
        {
            Global.LOOKUPPermission(LookupRole);
            Global.LOOKUPPermission(LookupCopyRole);
        }
        private void LookupRole_EditValueChanged(object sender, EventArgs e)
        {
            GetData();
        }
        private void backgroundWorker_SingleSetting_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                Conn = new BeginTranConnection(true, false);
                Single_SettingProperty SingleSetting = new Single_SettingProperty();
                try
                {
                    IntRes = 0;

                    foreach (DataRow Drow in DTab.Rows)
                    {
                        if (Val.ToString(Drow["column_name"]).Trim().Equals(string.Empty) || Val.ToString(Drow["caption"]).Trim().Equals(string.Empty))
                            continue;

                        //if (Val.ToInt32(Drow["any_change"]) == 0)
                        //    continue;

                        SingleSetting.role_id = Val.ToInt(LookupRole.EditValue);
                        SingleSetting.form_id = Val.ToInt(txtFormName.Tag);
                        SingleSetting.field_no = Val.ToInt(Drow["field_no"]);
                        SingleSetting.column_name = Val.ToString(Drow["column_name"]);
                        SingleSetting.caption = Val.ToString(Drow["caption"]);
                        SingleSetting.is_visible = Val.ToBooleanToInt(Drow["is_visible"]);
                        SingleSetting.is_compulsory = Val.ToBooleanToInt(Drow["is_compulsory"]);
                        SingleSetting.is_editable = Val.ToBooleanToInt(Drow["is_editable"]);
                        SingleSetting.is_newrow = Val.ToBooleanToInt(Drow["is_newrow"]);
                        SingleSetting.is_control = Val.ToBooleanToInt(Drow["is_control"]);
                        SingleSetting.tab_index = Val.ToInt(Drow["tab_index"]);
                        SingleSetting.column_type = Val.ToString(Drow["column_type"]);
                        SingleSetting.gridname = Val.ToString(Drow["grid_name"]);

                        IntRes = ObjSingleSettings.SaveSingleSettings(SingleSetting, DLL.GlobalDec.EnumTran.Continue, Conn);
                    }
                    Conn.Inter1.Commit();
                }
                catch (Exception ex)
                {
                    IntRes = -1;
                    Conn = null;
                    General.ShowErrors(ex.ToString());
                    return;
                }
                finally
                {
                    SingleSetting = null;
                }
            }
            catch (Exception ex)
            {
                IntRes = -1;
                Conn = null;
                Global.Message(ex.ToString());
                if (ex.InnerException != null)
                {
                    Global.Message(ex.InnerException.ToString());
                }
            }
        }
        private void backgroundWorker_SingleSetting_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (IntRes > 0)
                {
                    Cursor.Current = Cursors.Default;
                    Global.Message("Settings Saved Successfully");
                    return;
                }
                else
                {
                    Cursor.Current = Cursors.Default;
                    Global.ErrorMessage("Settings Save Fail !!!");
                    return;
                }
            }
            catch (Exception ex)
            {
                Global.Message(ex.ToString());
                Global.Message(ex.InnerException.ToString());
            }
        }
    }
}