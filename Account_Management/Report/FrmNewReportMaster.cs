using Account_Management.Search;
using BLL.FunctionClasses.Report;
using BLL.PropertyClasses.Report;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Global = Account_Management.Class.Global;

namespace Account_Management.Report
{
    public partial class FrmNewReportMaster : DevExpress.XtraEditors.XtraForm
    {
        BLL.FormEvents objBOFormEvents = new BLL.FormEvents();
        BLL.Validation Val = new BLL.Validation();
        int mIntReportCode = 0;
        FrmSearchNew FrmSearchNew;
        FrmExpressionEditor FrmExpressionEditor;
        BLL.FormPer ObjPer = new BLL.FormPer();

        public static string StrReportGroupName = string.Empty;
        string CurrentThemesName = string.Empty;
        NewReportMaster objNewReport = new NewReportMaster();
        DataTable dt = new DataTable();

        #region Constructor
        public FrmNewReportMaster()
        {
            InitializeComponent();
        }

        public void ShowForm(int pIntReportCode)
        {
            try
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

                if (pIntReportCode == 0)
                {
                    BtnClear_Click(null, null);
                }
                else
                {
                    mIntReportCode = pIntReportCode;
                    txtReportCode.Text = mIntReportCode.ToString();
                    if (mIntReportCode != 0)
                    {
                        New_Report_MasterProperty MasterProperty = objNewReport.GetReportMasterProperty(mIntReportCode, StrReportGroupName);
                        txtReportCode.Text = Val.ToString(MasterProperty.Report_code);
                        txtReportName.Text = Val.ToString(MasterProperty.Report_Name);
                        txtRptGroupName.Text = Val.ToString(MasterProperty.Report_Group_Name);
                        txtFormName.Text = Val.ToString(MasterProperty.Form_Name);
                        ChkRepMastActive.Checked = Val.ToInt(MasterProperty.Active) == 1 ? true : false;
                        txtSequenceNo.Text = Val.ToString(MasterProperty.Sequence_No);

                        CmbDisplayIn.SelectedItem = Val.ToString(MasterProperty.Disp_In);
                        txtSection.Text = Val.ToString(MasterProperty.Section_Name);

                        MasterProperty = null;
                    }
                    BtnSearchDet_Click(null, null);
                }
                ChkPivot_CheckedChanged(null, null);
                AddRow();
                txtReportCode.Focus();

                txtPass_TextChanged(null, null);

                if (dgvNewReportMain.DataSource == null)
                {
                    dt = new DataTable();
                    dt.Columns.Add("report_code", typeof(Int32));
                    dt.Columns.Add("report_type");
                    dt.Columns.Add("field_no", typeof(Int32));
                    dt.Columns.Add("field_name");
                    dt.Columns.Add("column_name");
                    dt.Columns.Add("sequence_no", typeof(Int32));
                    dt.Columns.Add("aggregate");
                    dt.Columns.Add("width", typeof(decimal));
                    dt.Columns.Add("visible", typeof(Boolean));
                    dt.Columns.Add("ismerge", typeof(Boolean));
                    dt.Columns.Add("mergeon");
                    dt.Columns.Add("active", typeof(decimal));
                    dt.Columns.Add("remark");
                    dt.Columns.Add("type");
                    dt.Columns.Add("is_group", typeof(Boolean));
                    dt.Columns.Add("is_row_area", typeof(Boolean));
                    dt.Columns.Add("is_column_area", typeof(Boolean));
                    dt.Columns.Add("is_data_area", typeof(Boolean));
                    dt.Columns.Add("is_unbound", typeof(Boolean));
                    dt.Columns.Add("expression");
                    dt.Columns.Add("order_by");
                    dt.Columns.Add("bands");
                    dt.Columns.Add("column_width", typeof(decimal));
                    dt.Columns.Add("alignment");
                    dt.Columns.Add("format");
                    dt.Columns.Add("theme_name");
                    dt.Columns.Add("user_id", typeof(Int32));

                    dgvNewReportMain.DataSource = dt;
                    dgvNewReportMain.RefreshDataSource();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void ShowDialogs(int pIntReportCode, string ThemesName)
        {
            try
            {
                ObjPer.FormName = this.Name.ToUpper();
                if (ObjPer.CheckPermission() == false)
                {
                    Global.Message(BLL.GlobalDec.gStrPermissionViwMsg);
                    return;
                }
                CurrentThemesName = ThemesName;
                dgvNewReportt.Columns["column_width"].Visible = true;

                panel6.Visible = false;
                BtnAddNew.Visible = false;
                BtnClear.Visible = false;
                BtnDeleteDet.Visible = false;
                BtnDeleteMast.Visible = false;
                BtnSearchDet.Visible = false;
                BtnSearchMast.Visible = false;

                Val.frmGenSetForPopup(this);
                AttachFormEvents();

                if (pIntReportCode == 0)
                {
                    BtnClear_Click(null, null);
                }
                else
                {
                    mIntReportCode = pIntReportCode;
                    txtReportCode.Text = mIntReportCode.ToString();
                    if (mIntReportCode != 0)
                    {
                        New_Report_MasterProperty MasterProperty = objNewReport.GetReportMasterProperty_ForTemplate(mIntReportCode, StrReportGroupName);
                        txtReportCode.Text = Val.ToString(MasterProperty.Report_code);
                        txtReportName.Text = Val.ToString(MasterProperty.Report_Name);
                        txtRptGroupName.Text = Val.ToString(MasterProperty.Report_Group_Name);
                        txtFormName.Text = Val.ToString(MasterProperty.Form_Name);
                        ChkRepMastActive.Checked = Val.ToInt(MasterProperty.Active) == 1 ? true : false;
                        CmbDisplayIn.SelectedItem = Val.ToString(MasterProperty.Disp_In);
                        txtSection.Text = Val.ToString(MasterProperty.Section_Name);

                        txtSequenceNo.Text = Val.ToString(MasterProperty.Sequence_No);
                        MasterProperty = null;
                    }
                    SearchDetails();
                }
                AddRow();
                txtReportCode.Focus();
                this.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void SearchDetails()
        {
            try
            {
                DataTable DTTemp = new DataTable();

                DTTemp = objNewReport.GetDataForSearchDetail(mIntReportCode);

                if (DTTemp != null)
                {
                    CmbReportType.SelectedItem = Val.ToString(DTTemp.Rows[0]["report_type"]).ToUpper();
                    txtProcedureName.Text = Val.ToString(DTTemp.Rows[0]["procedure_name"]);
                    txtReportHeaderName.Text = Val.ToString(DTTemp.Rows[0]["report_header_name"]);

                    txtDefaultOrder.Text = Val.ToString(DTTemp.Rows[0]["default_order_by"]);
                    txtDefaultGroup.Text = Val.ToString(DTTemp.Rows[0]["default_group_by"]);
                    txtRptName.Text = Val.ToString(DTTemp.Rows[0]["rpt_name"]);
                    txtRemark.Text = Val.ToString(DTTemp.Rows[0]["remark"]);

                    ChkRepDetActive.Checked = Val.ToInt(DTTemp.Rows[0]["active"]) == 1 ? true : false;
                    ChkPivot.Checked = Val.ToInt(DTTemp.Rows[0]["is_pivot"]) == 1 ? true : false;

                    txtFontName.Text = Val.ToString(DTTemp.Rows[0]["font_name"]);
                    txtFontSize.Text = Val.ToString(DTTemp.Rows[0]["font_size"]);
                    CmbPageOrientation.SelectedItem = Val.ToString(DTTemp.Rows[0]["page_orientation"]);
                    CmbPageKind.SelectedItem = Val.ToString(DTTemp.Rows[0]["page_kind"]);
                    txtAutoFit.Text = Val.ToString(DTTemp.Rows[0]["autofit"]);

                    dt.Rows.Clear();

                    DataTable DtTab = new DataTable();
                    DtTab = objNewReport.GetReportSettings_For_Template(Val.ToInt(txtReportCode.Text), CmbReportType.SelectedItem.ToString().ToUpper());
                    DtTab = DtTab.Select("theme_name='" + CurrentThemesName + "'").Count() > 0 ? DtTab.Select("theme_name='" + CurrentThemesName + "'").CopyToDataTable() : null;

                    dgvNewReportMain.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void FillTempDataTable()
        {
            try
            {
                if (mIntReportCode != 0)
                {
                    New_Report_MasterProperty MasterProperty = new New_Report_MasterProperty();

                    if (panel6.Visible)
                        MasterProperty = objNewReport.GetReportMasterProperty(mIntReportCode);
                    else
                        MasterProperty = objNewReport.GetReportMasterProperty(mIntReportCode, StrReportGroupName);
                    txtReportCode.Text = Val.ToString(MasterProperty.Report_code);
                    txtReportName.Text = Val.ToString(MasterProperty.Report_Name);
                    txtRptGroupName.Text = Val.ToString(MasterProperty.Report_Group_Name);
                    txtFormName.Text = Val.ToString(MasterProperty.Form_Name);
                    ChkRepMastActive.Checked = Val.ToInt(MasterProperty.Active) == 1 ? true : false;
                    CmbDisplayIn.SelectedItem = Val.ToString(MasterProperty.Disp_In);
                    txtSection.Text = Val.ToString(MasterProperty.Section_Name);

                    txtSequenceNo.Text = Val.ToString(MasterProperty.Sequence_No);
                    MasterProperty = null;
                }

                DataTable DTab2 = new DataTable(BLL.TPV.Table.Temp);
                DTab2.Columns.Add("alignment");
                DTab2.Rows.Add("LEFT");
                DTab2.Rows.Add("RIGHT");
                DTab2.Rows.Add("CENTER");

                objNewReport.DS.Tables.Add(DTab2);

                DataTable DTab = new DataTable(BLL.TPV.Table.AggregateType);
                DTab.Columns.Add("aggregate");
                DTab.Rows.Add("SUM");
                DTab.Rows.Add("AVG");
                DTab.Rows.Add("WEI.AVG");
                DTab.Rows.Add("MAX");
                DTab.Rows.Add("MIN");
                DTab.Rows.Add("COUNT");
                DTab.Rows.Add("CUSTOME");

                objNewReport.DS.Tables.Add(DTab);

                DataTable DTab1 = new DataTable(BLL.TPV.Table.MasterDetail);
                DTab1.Columns.Add("Type");
                DTab1.Columns.Add("Name");
                DTab1.Rows.Add("S", "String (Varchar,Date DataType)");
                DTab1.Rows.Add("F", "Float (Number(10,2) DataType)");
                DTab1.Rows.Add("I", "Integer (Number(10,0) DataType)");
                DTab1.Rows.Add("D", "Date (Date DataType)");
                DTab1.Rows.Add("T", "Time (Varchar DataType)");
                objNewReport.DS.Tables.Add(DTab1);

                CmbPageKind.Properties.Items.Clear();

                int IntIndex = 0;

                foreach (System.Drawing.Printing.PaperKind foo in Enum.GetValues(typeof(System.Drawing.Printing.PaperKind)))
                {
                    CmbPageKind.Properties.Items.Add(foo.ToString());
                    if (foo.ToString() == "A4")
                    {
                        CmbPageKind.SelectedIndex = IntIndex;
                    }
                    IntIndex++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void AttachFormEvents()
        {
            objBOFormEvents.CurForm = this;
            objBOFormEvents.FormResize = true;
            objBOFormEvents.FormClosing = true;
            objBOFormEvents.ObjToDispose.Add(objNewReport);
            objBOFormEvents.ObjToDispose.Add(Val);
            objBOFormEvents.ObjToDispose.Add(objBOFormEvents);
        }

        #endregion

        #region Validation

        private bool ValSave()
        {
            if (txtReportCode.Text.Length == 0)
            {
                Global.Message("Report Copde Is Required");
                return false;
            }
            if (txtReportName.Text.Length == 0)
            {
                Global.Message("Report Name Is Required");
                return false;
            }

            if (txtRptGroupName.Text.Length == 0)
            {
                Global.Message("Report Group Name Is Required");
                return false;
            }
            return true;
        }

        private bool ValDelete()
        {
            if (txtReportCode.Text.Length == 0)
            {
                Global.Message("Report Code  Is Required");
                return false;
            }
            return true;
        }

        #endregion

        #region Events

        private void BtnAddNew_Click(object sender, EventArgs e)
        {
            dt.Rows.Add();
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (Global.Confirm("Are You Sure To Save Report Detail ? ", "DREP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            if (ValSave() == false)
            {
                return;
            }

            if (txtReportCode.Text == "")
            {
                txtReportCode.Tag = "";
            }
            if (txtRptGroupName.Text == "")
            {
                txtRptGroupName.Tag = "";
            }
            if (txtProcedureName.Text == "")
            {
                txtProcedureName.Tag = "";
            }

            if (CmbReportType.SelectedIndex == 0)
            {
                Global.Message("Enter Valid Report Type");
                return;
            }

            New_Report_MasterProperty NewReportMasterProperty = new New_Report_MasterProperty();

            NewReportMasterProperty.Report_code = Val.ToInt(txtReportCode.Text);
            NewReportMasterProperty.Report_Name = txtReportName.Text;
            NewReportMasterProperty.Report_Group_Name = txtRptGroupName.Text;
            NewReportMasterProperty.Form_Name = txtFormName.Text;
            NewReportMasterProperty.Sequence_No = Val.ToInt(txtSequenceNo.Text);
            NewReportMasterProperty.Active = ChkRepMastActive.Checked == true ? 1 : 0;
            NewReportMasterProperty.Disp_In = Val.ToString(CmbDisplayIn.SelectedItem);
            NewReportMasterProperty.Remark = txtRemark.Text;
            NewReportMasterProperty.Section_Name = txtSection.Text;

            //int IntRes = objNewReport.Save(NewReportMasterProperty);
            NewReportMasterProperty = objNewReport.Save(NewReportMasterProperty);
            Int64 NewReport_Code = Val.ToInt64(NewReportMasterProperty.Report_code);
            if (NewReport_Code == 0)
            {
                Global.Message("Error In Save Report Master Details");
                txtReportName.Focus();
            }
            else
            {
                SaveReportDetail(NewReport_Code);
                SaveReportSettings(NewReport_Code);
                Global.Message("Record Saved SuccessFully");
                if (!panel6.Visible)
                    BtnExit_Click(null, null);
            }
            NewReportMasterProperty = null;
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            CmbReportType.SelectedIndex = 0;
            txtReportCode.Text = "";
            txtRptGroupName.Text = "";
            txtReportName.Text = "";
            txtSequenceNo.Text = "";
            txtProcedureName.Text = "";
            txtReportHeaderName.Text = "";
            txtFormName.Text = "";
            ChkRepMastActive.Checked = false;
            ChkRepDetActive.Checked = false;
            ChkPivot.Checked = false;
            CmbDisplayIn.SelectedIndex = 0;
            txtDefaultOrder.Text = "";
            txtDefaultGroup.Text = "";
            txtRptName.Text = "";
            txtRemark.Text = "";
            dt.Rows.Clear();
            txtReportCode.Text = objNewReport.FindNewID().ToString();
            txtReportCode.Focus();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSearchDet_Click(object sender, EventArgs e)
        {
            FrmSearchNew = new FrmSearchNew();

            FrmSearchNew.DTab = objNewReport.GetDataForSearchDetail(mIntReportCode);
            FrmSearchNew.ColumnsToHide = "";
            FrmSearchNew.SearchField = "report_code,report_type";
            FrmSearchNew.ShowDialog();
            if (FrmSearchNew.DRow != null)
            {
                CmbReportType.Text = Val.ToString(FrmSearchNew.DRow["report_type"]).ToUpper();
                txtProcedureName.Text = Val.ToString(FrmSearchNew.DRow["procedure_name"]);
                txtReportHeaderName.Text = Val.ToString(FrmSearchNew.DRow["report_header_name"]);

                txtDefaultOrder.Text = Val.ToString(FrmSearchNew.DRow["default_order_by"]);
                txtDefaultGroup.Text = Val.ToString(FrmSearchNew.DRow["default_group_by"]);
                txtRptName.Text = Val.ToString(FrmSearchNew.DRow["rpt_name"]);
                txtRemark.Text = Val.ToString(FrmSearchNew.DRow["remark"]);

                ChkRepDetActive.Checked = Val.ToInt(FrmSearchNew.DRow["active"]) == 1 ? true : false;
                ChkPivot.Checked = Val.ToInt(FrmSearchNew.DRow["is_pivot"]) == 1 ? true : false;

                txtFontName.Text = Val.ToString(FrmSearchNew.DRow["font_name"]);
                txtFontSize.Text = Val.ToString(FrmSearchNew.DRow["font_size"]);
                CmbPageOrientation.SelectedItem = Val.ToString(FrmSearchNew.DRow["page_orientation"]);
                CmbPageKind.SelectedItem = Val.ToString(FrmSearchNew.DRow["page_kind"]);
                txtAutoFit.Text = Val.ToString(FrmSearchNew.DRow["autofit"]);

                dt.Rows.Clear();

                DataTable DtTab = new DataTable();
                DtTab.Rows.Clear();
                if (this.Modal)
                    DtTab = objNewReport.GetReportSettings_For_Template(Val.ToInt(txtReportCode.Text), CmbReportType.SelectedItem.ToString().ToUpper());
                else
                {
                    objNewReport.GetReportSettings(Val.ToInt(txtReportCode.Text), CmbReportType.SelectedItem.ToString().ToUpper(), Val.ToInt(BLL.GlobalDec.gEmployeeProperty.user_id));
                    DtTab = objNewReport.DS.Tables[3];
                }
                //DtTab = DtTab.Select("theme_name='DEFAULT' AND ( user_id=0 OR user_id=" + BLL.GlobalDec.gEmployeeProperty.user_id + " )").Count() > 0 ? DtTab.Select("theme_name='DEFAULT' AND (user_id = 0 OR user_id=" + BLL.GlobalDec.gEmployeeProperty.user_id + " )").CopyToDataTable() : null;
                DtTab = DtTab.Select("theme_name='DEFAULT'").Count() > 0 ? DtTab.Select("theme_name='DEFAULT'").CopyToDataTable() : null;
                dgvNewReportMain.DataSource = DtTab;
                dt = DtTab;
                AddRow();
            }
            FrmSearchNew.Hide();
            FrmSearchNew.Dispose();
            FrmSearchNew = null;
        }

        private void BtnSearchMast_Click(object sender, EventArgs e)
        {
            FrmSearchNew = new FrmSearchNew();

            FrmSearchNew.DTab = objNewReport.GetDataForSearchMaster(mIntReportCode);
            FrmSearchNew.ColumnsToHide = "";

            FrmSearchNew.SearchField = "report_code";
            FrmSearchNew.ShowDialog();
            if (FrmSearchNew.DRow != null)
            {
                if (FrmSearchNew.DRow != null)
                {
                    txtReportCode.Text = Val.ToString(FrmSearchNew.DRow["report_code"]);
                    txtReportName.Text = Val.ToString(FrmSearchNew.DRow["report_name"]);
                    txtRptGroupName.Text = Val.ToString(FrmSearchNew.DRow["report_group_name"]);
                    txtFormName.Text = Val.ToString(FrmSearchNew.DRow["form_name"]);
                    ChkRepMastActive.Checked = Val.ToInt(FrmSearchNew.DRow["active"]) == 1 ? true : false;
                    txtSequenceNo.Text = Val.ToString(FrmSearchNew.DRow["sequence_no"]);

                    FrmSearchNew.Hide();
                    FrmSearchNew.Dispose();
                    FrmSearchNew = null;
                    BtnSearchDet_Click(null, null);
                }
                else
                {
                    FrmSearchNew.Hide();
                    FrmSearchNew.Dispose();
                    FrmSearchNew = null;
                }
            }
            else
            {
                FrmSearchNew.Hide();
                FrmSearchNew.Dispose();
                FrmSearchNew = null;
            }
        }

        private void txtRemark_Validated(object sender, EventArgs e)
        {
            AddRow();
            dgvNewReportt.Focus();
        }

        private void BtnDeleteMast_Click(object sender, EventArgs e)
        {
            if (ValDelete() == false)
            {
                return;
            }
            if (Global.Confirm("Are You Sure Delete ? ", "DREP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
            {
                return;
            }
            int IntRes = 0;
            New_Report_MasterProperty New_Report_Master = new New_Report_MasterProperty();
            New_Report_Master.Report_code = Val.ToInt(txtReportCode.Text);

            IntRes = objNewReport.Delete(Val.ToInt(txtReportCode.Text));

            if (IntRes == 1)
            {
                Global.Message("Your Report Master Data Successfully Deleted");
                BtnClear_Click(null, null);
            }
        }

        private void BtnDeleteDet_Click(object sender, EventArgs e)
        {
            if (ValDelete() == false)
            {
                return;
            }
            if (Global.Confirm("Are You Sure Delete ? ", "DREP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
            {
                return;
            }
            int IntRes = 0;

            New_Report_DetailProperty New_Report_Detail = new New_Report_DetailProperty();
            New_Report_Detail.Report_code = Val.ToInt(txtReportCode.Text);
            New_Report_Detail.Report_Type = CmbReportType.SelectedItem.ToString().ToUpper();

            IntRes = objNewReport.DeleteDetail(New_Report_Detail);

            if (IntRes == 1)
            {

                Global.Message("Your Report Detail Successfully Deleted");
                BtnClear_Click(null, null);
            }
        }

        private void MNUDeleteSetting_Click(object sender, EventArgs e)
        {
            if (dgvNewReportt.FocusedRowHandle < 0)
            {
                return;
            }

            if (Global.Confirm("Are You Sure Delete ? ", "DREP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
            {
                return;
            }
            int IntRes = 0;

            New_Report_SettingsProperty New_Report_Settings = new New_Report_SettingsProperty();
            New_Report_Settings.Report_code = Val.ToInt(txtReportCode.Text);
            New_Report_Settings.Report_Type = CmbReportType.Text.ToUpper();
            New_Report_Settings.Field_No = Val.ToInt(dgvNewReportt.GetRowCellValue(dgvNewReportt.FocusedRowHandle, "field_no"));

            IntRes = objNewReport.DeleteReportSettings_Template(New_Report_Settings);
            if (IntRes == 1)
            {
                Global.Message("Report Setting SuccessFully Deleted");
                dt.Rows.RemoveAt(dgvNewReportt.FocusedRowHandle);
                dt.AcceptChanges();
            }
        }

        private void BtnUp_Click(object sender, EventArgs e)
        {
            try
            {
                int idx = dgvNewReportt.FocusedRowHandle;
                if (idx == 0)
                    return;

                DataRow row = dt.Rows[idx];

                DataRow oldRow = row;
                DataRow newRow = dt.NewRow();

                newRow.ItemArray = oldRow.ItemArray;

                int oldRowIndex = dt.Rows.IndexOf(row);

                int newRowIndex = oldRowIndex - 1;

                if (oldRowIndex > 0)
                {
                    dt.Rows.Remove(oldRow);
                    dt.Rows.InsertAt(newRow, newRowIndex);
                    dt.Rows.IndexOf(newRow);
                }

                dt.AcceptChanges();
                dgvNewReportt.FocusedRowHandle = newRowIndex;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ChkPivot_CheckedChanged_1(object sender, EventArgs e)
        {
            if (ChkPivot.Checked == true)
            {
                dgvNewReportt.Columns["is_row_area"].Visible = true;
                dgvNewReportt.Columns["is_column_area"].Visible = true;
                dgvNewReportt.Columns["is_data_area"].Visible = true;
            }
            else
            {
                dgvNewReportt.Columns["is_row_area"].Visible = false;
                dgvNewReportt.Columns["is_column_area"].Visible = false;
                dgvNewReportt.Columns["is_data_area"].Visible = false;
            }
        }

        private void BtnDown_Click(object sender, EventArgs e)
        {
            try
            {
                int totalRows = dt.Rows.Count;
                int idx = dgvNewReportt.FocusedRowHandle;
                if (idx == totalRows - 1)
                    return;

                DataRow row = dt.Rows[idx];

                DataRow oldRow = row;
                DataRow newRow = dt.NewRow();

                newRow.ItemArray = oldRow.ItemArray;

                int oldRowIndex = dt.Rows.IndexOf(row);

                int newRowIndex = oldRowIndex + 1;

                if (oldRowIndex < (dt.Rows.Count))
                {
                    dt.Rows.Remove(oldRow);
                    dt.Rows.InsertAt(newRow, newRowIndex);
                    dt.Rows.IndexOf(newRow);
                }

                dt.AcceptChanges();
                dgvNewReportt.FocusedRowHandle = newRowIndex;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnSetSequence_Click(object sender, EventArgs e)
        {
            dt.AcceptChanges();

            Int64 IntSrNo = 0;
            foreach (DataRow DRow in dt.Rows)
            {
                if (Val.ToString(DRow["column_name"]) == "")
                {
                    continue;
                }

                DRow["sequence_no"] = Val.ToString(IntSrNo + 1);
                IntSrNo++;
            }
            dt.AcceptChanges();

            dgvNewReportMain.DataSource = dt;
            dgvNewReportMain.RefreshDataSource();
            dgvNewReportt.BestFitColumns();
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {
            if (ObjPer.CheckFormPass(txtPass.Text))
            {
                lblDisplayIn.Visible = true;
                CmbDisplayIn.Visible = true;
            }
            else
            {
                lblDisplayIn.Visible = false;
                CmbDisplayIn.Visible = false;
            }
        }

        private void ChkPivot_CheckedChanged(object sender, EventArgs e)
        {

            if (ChkPivot.Checked == true)
            {
                dgvNewReportt.Columns["is_row_area"].Visible = true;
                dgvNewReportt.Columns["is_column_area"].Visible = true;
                dgvNewReportt.Columns["is_data_area"].Visible = true;
            }
            else
            {
                dgvNewReportt.Columns["is_row_area"].Visible = false;
                dgvNewReportt.Columns["is_column_area"].Visible = false;
                dgvNewReportt.Columns["is_data_area"].Visible = false;
            }
        }

        private void txtAggregate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Global.OnKeyPressToOpenPopup(e))
            {
                FrmSearchNew = new FrmSearchNew();
                FrmSearchNew.DTab = objNewReport.DS.Tables[BLL.TPV.Table.AggregateType];
                FrmSearchNew.SearchField = "aggregate";
                FrmSearchNew.ShowDialog();
                e.Handled = true;
                if (FrmSearchNew.DRow != null)
                {
                    dgvNewReportt.SetRowCellValue(dgvNewReportt.FocusedRowHandle, "aggregate", Val.ToString(FrmSearchNew.DRow["aggregate"]));

                }
                FrmSearchNew.Hide();
                FrmSearchNew.Dispose();
                FrmSearchNew = null;
            }
        }

        private void txtFormat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Global.OnKeyPressToOpenPopup(e))
            {
                FrmSearchNew = new FrmSearchNew();
                FrmSearchNew.DTab = Global.DTabNumericFormat();
                FrmSearchNew.SearchField = "format";
                FrmSearchNew.ShowDialog();
                e.Handled = true;
                if (FrmSearchNew.DRow != null)
                {
                    dgvNewReportt.SetRowCellValue(dgvNewReportt.FocusedRowHandle, "format", Val.ToString(FrmSearchNew.DRow["format"]));
                }
                FrmSearchNew.Hide();
                FrmSearchNew.Dispose();
                FrmSearchNew = null;
            }
        }

        private void txtDataType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Global.OnKeyPressToOpenPopup(e))
            {
                FrmSearchNew = new FrmSearchNew();
                FrmSearchNew.DTab = objNewReport.DS.Tables[BLL.TPV.Table.MasterDetail];
                FrmSearchNew.SearchField = "type";
                FrmSearchNew.ShowDialog();
                e.Handled = true;
                if (FrmSearchNew.DRow != null)
                {
                    dgvNewReportt.SetRowCellValue(dgvNewReportt.FocusedRowHandle, "type", Val.ToString(FrmSearchNew.DRow["type"]));
                }
                FrmSearchNew.Hide();
                FrmSearchNew.Dispose();
                FrmSearchNew = null;
            }
        }

        private void txtExpression_KeyPress(object sender, KeyPressEventArgs e)
        {
            string finalName = string.Empty;
            foreach (DataRow Dr in dt.Rows)
            {
                finalName += Val.ToString(Dr["field_name"]) + ",";
            }
            FrmExpressionEditor = new FrmExpressionEditor();
            FrmExpressionEditor.FieldName = finalName;
            FrmExpressionEditor.ShowDialog();
            FrmExpressionEditor.Dispose();
            FrmExpressionEditor = null;

            e.Handled = true;
        }

        private void txtAlignment_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Global.OnKeyPressToOpenPopup(e))
            {
                FrmSearchNew = new FrmSearchNew();
                FrmSearchNew.DTab = objNewReport.DS.Tables[BLL.TPV.Table.Temp];
                FrmSearchNew.SearchField = "alignment";
                FrmSearchNew.ShowDialog();
                e.Handled = true;
                if (FrmSearchNew.DRow != null)
                {
                    dgvNewReportt.SetRowCellValue(dgvNewReportt.FocusedRowHandle, "alignment", Val.ToString(FrmSearchNew.DRow["alignment"]));
                }
                FrmSearchNew.Hide();
                FrmSearchNew.Dispose();
                FrmSearchNew = null;
            }
        }

        #endregion

        #region Other Function

        private void SaveReportDetail(Int64 Report_Code = 0)
        {

            New_Report_DetailProperty New_Report_Detail = new New_Report_DetailProperty();

            //New_Report_Detail.Report_code = Val.ToInt(txtReportCode.Text);
            New_Report_Detail.Report_code = Val.ToInt(Report_Code);
            New_Report_Detail.Report_Type = CmbReportType.SelectedItem.ToString().ToUpper();
            New_Report_Detail.Procedure_Name = txtProcedureName.Text;
            New_Report_Detail.Report_Header_Name = txtReportHeaderName.Text;
            New_Report_Detail.Rpt_Name = txtRptName.Text;
            New_Report_Detail.Remark = txtRemark.Text;
            New_Report_Detail.Default_Order_By = txtDefaultOrder.Text;
            New_Report_Detail.Default_Group_By = txtDefaultGroup.Text;
            New_Report_Detail.Font_Name = txtFontName.Text;
            New_Report_Detail.Font_Size = Val.Val(txtFontSize.Text);
            New_Report_Detail.Page_Orientation = Val.ToString(CmbPageOrientation.SelectedItem);
            New_Report_Detail.Page_Kind = Val.ToString(CmbPageKind.SelectedItem);
            New_Report_Detail.Autofit = Val.Val(txtAutoFit.Text);
            New_Report_Detail.Font_Size = Val.Val(txtFontSize.Text);

            New_Report_Detail.Is_Pivot = ChkPivot.Checked == true ? 1 : 0;
            New_Report_Detail.Active = ChkRepDetActive.Checked == true ? 1 : 0;

            objNewReport.SaveReportDetail(New_Report_Detail);

            New_Report_Detail = null;

        }

        private void SaveReportSettings(Int64 Report_Code = 0)
        {
            New_Report_SettingsProperty New_Report_SettingsProperty = new New_Report_SettingsProperty();
            //New_Report_SettingsProperty.Report_code = Val.ToInt(txtReportCode.Text);
            New_Report_SettingsProperty.Report_code = Val.ToInt(Report_Code);
            New_Report_SettingsProperty.Report_Type = CmbReportType.SelectedItem.ToString().ToUpper();

            for (int IntI = 0; IntI < dgvNewReportt.RowCount - 1; IntI++)
            {
                DataRow DRow = dgvNewReportt.GetDataRow(IntI);

                if (Val.ToString(DRow["column_name"]) == "")
                {
                    break;
                }

                if (Val.ToString(DRow["field_name"]) != "CHK" && Val.ToString(DRow["column_name"]) == "")
                {
                    continue;
                }

                New_Report_SettingsProperty New_Report_Settings = new New_Report_SettingsProperty();

                //New_Report_Settings.Report_code = Val.ToInt(txtReportCode.Text);
                New_Report_Settings.Report_code = Val.ToInt(Report_Code);
                New_Report_Settings.Report_Type = CmbReportType.SelectedItem.ToString().ToUpper();

                int IntField_No = Val.ToInt32(DRow["field_no"]);
                if (IntField_No == 0)
                {
                    IntField_No = Val.ToInt32(DRow.Table.Compute("MAX(field_no)", "")) + 1;
                    DRow["field_no"] = IntField_No;
                }
                New_Report_Settings.Field_No = IntField_No;


                if (panel6.Visible)
                    New_Report_Settings.Themes_Name = "DEFAULT";
                else
                    New_Report_Settings.Themes_Name = CurrentThemesName;

                New_Report_Settings.Field_Name = Val.ToString(DRow["field_name"]);
                New_Report_Settings.Column_Name = Val.ToString(DRow["column_name"]);
                New_Report_Settings.Sequence_No = Val.ToInt(DRow["sequence_no"]);
                New_Report_Settings.Aggregate = Val.ToString(DRow["aggregate"]);
                New_Report_Settings.Width = Val.ToInt(DRow["width"]);
                New_Report_Settings.Visible = Val.ToBooleanToInt(DRow["visible"]);
                New_Report_Settings.IsMerge = Val.ToBooleanToInt(DRow["ismerge"]);
                New_Report_Settings.MergeOn = Val.ToString(DRow["mergeon"]);
                New_Report_Settings.Active = Val.ToBooleanToInt(DRow["active"]);
                New_Report_Settings.Remark = Val.ToString(DRow["remark"]);
                New_Report_Settings.Type = Val.ToString(DRow["type"]);
                New_Report_Settings.Is_Group = Val.ToBooleanToInt(DRow["is_group"]);
                New_Report_Settings.Is_Row_Area = Val.ToBooleanToInt(DRow["is_row_area"]);
                New_Report_Settings.Is_Column_Area = Val.ToBooleanToInt(DRow["is_column_area"]);
                New_Report_Settings.Is_Data_Area = Val.ToBooleanToInt(DRow["is_data_area"]);
                New_Report_Settings.Order_By = Val.ToString(DRow["order_by"]);
                New_Report_Settings.Is_Unbound = Val.ToBooleanToInt(DRow["is_unbound"]);
                New_Report_Settings.Expression = Val.ToString(DRow["expression"]);
                New_Report_Settings.Bands = Val.ToString(DRow["bands"]);
                New_Report_Settings.Column_Width = Val.ToInt(DRow["column_width"]);
                New_Report_Settings.Format = Val.ToString(DRow["format"]);
                New_Report_Settings.Alignment = Val.ToString(DRow["alignment"]);

                objNewReport.SaveReportSettings(New_Report_Settings);
                New_Report_Settings = null;
                DRow.Table.AcceptChanges();
                dgvNewReportMain.RefreshDataSource();

            }
        }

        private void AddRow()
        {
            if (dt != null && dt.Rows.Count == 1)
            {
                dgvNewReportt.AddNewRow();
                string Field = Val.ToString(dgvNewReportt.GetRowCellValue(dgvNewReportt.FocusedRowHandle, "field_name"));
                dgvNewReportt.SetRowCellValue(dgvNewReportt.FocusedRowHandle, "field_name", Field);
            }
        }

        #endregion        

        private void FrmNewReportMaster_Load(object sender, EventArgs e)
        {
            try
            {
                FillTempDataTable();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void dgvNewReportt_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (Val.ToString(dgvNewReportt.GetRowCellValue(dgvNewReportt.FocusedRowHandle, "alignment")) != "")
            {
                DataRow dr = dt.NewRow();
                dt.Rows.Add(dr);
            }
        }
    }
}
