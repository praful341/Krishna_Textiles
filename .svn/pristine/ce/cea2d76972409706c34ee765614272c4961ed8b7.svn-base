using BLL;
using BLL.FunctionClasses.Report;
using BLL.PropertyClasses.Report;
using Krishna_Textiles.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Krishna_Textiles.Report
{
    public partial class FrmStockReport : DevExpress.XtraEditors.XtraForm
    {
        #region "Data Member"
        BLL.FormEvents objBOFormEvents = new BLL.FormEvents();
        BLL.Validation Val = new BLL.Validation();
        string mStrReportGroup = string.Empty;
        int mIntReportCode = 0;
        int mIntPivot = 0;
        ReportParams ObjReportParams = new ReportParams();
        New_Report_MasterProperty ObjReportMasterProperty = new New_Report_MasterProperty();
        New_Report_DetailProperty ObjReportDetailProperty = new New_Report_DetailProperty();
        NewReportMaster ObjReportMaster = new NewReportMaster();
        DataTable mDTDetail = new DataTable(BLL.TPV.Table.New_Report_Detail);
        DataTable dtAllvalues = new DataTable();
        DataColumn dc_Unique = new DataColumn("Unique", typeof(string));
        DataColumn dc_Parent = new DataColumn("Parent", typeof(string));
        DataColumn dc_Data = new DataColumn("Data", typeof(string));
        FillCombo ObjFillCombo = new FillCombo();
        string StrColumnName = string.Empty;
        DataTable DTab = new DataTable();
        DataTable m_opDate = new DataTable();
        ReportParams_Property ReportParams_Property = new BLL.PropertyClasses.Report.ReportParams_Property();
        List<Task> tList = new List<Task>();

        #endregion

        #region Counstructor

        public FrmStockReport()
        {
            InitializeComponent();
        }

        private void AttachFormEvents()
        {
            objBOFormEvents.CurForm = this;
            objBOFormEvents.FormKeyDown = true;
            objBOFormEvents.FormKeyPress = true;
            objBOFormEvents.FormResize = true;
            objBOFormEvents.FormClosing = true;
            objBOFormEvents.ObjToDispose.Add(Val);
            objBOFormEvents.ObjToDispose.Add(objBOFormEvents);
        }

        #endregion

        #region "Events" 
        private void FrmReportList_Load(object sender, EventArgs e)
        {
            if (dtAllvalues.Columns.Count == 0)
            {
                dtAllvalues.Columns.Add(dc_Unique);
                dtAllvalues.Columns.Add(dc_Parent);
                dtAllvalues.Columns.Add(dc_Data);
            }

            AttachFormEvents();

            this.Show();

            mIntReportCode = Val.ToInt(this.Tag);

            FillControls();
            //RbtReportType_EditValueChanged(null, null);
            FillListControls();
            //m_opDate = Global.GetDate();

            Task.Run(() => GetData());

            DTPFromDate.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
            DTPFromDate.Properties.Mask.EditMask = "dd/MMM/yyyy";
            DTPFromDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            DTPFromDate.Properties.CharacterCasing = CharacterCasing.Upper;
            //string From_Date = Val.DBDate(m_opDate.Rows[0]["opening_date"].ToString());
            string From_Date = "";
            if (From_Date != "")
            {
                DTPFromDate.EditValue = Val.DBDate(m_opDate.Rows[0]["opening_date"].ToString());
            }
            else
            {
                DTPFromDate.EditValue = DateTime.Now;
            }

            DTPToDate.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
            DTPToDate.Properties.Mask.EditMask = "dd/MMM/yyyy";
            DTPToDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            DTPToDate.Properties.CharacterCasing = CharacterCasing.Upper;

            DTPToDate.EditValue = DateTime.Now;
            DTPFromDate.Focus();
        }

        private void GetData()
        {
            DataTable DTabCompany = ObjFillCombo.FillCmb(FillCombo.TABLE.Company_Master);
            DTabCompany.DefaultView.Sort = "Company_Name";
            DTabCompany = DTabCompany.DefaultView.ToTable();

            ListCompany.InvokeEx(t =>
            {
                t.Properties.DataSource = DTabCompany;
                t.Properties.DisplayMember = "Company_Name";
                t.Properties.ValueMember = "company_id";
                t.SetEditValue(BLL.GlobalDec.gEmployeeProperty.company_id);
            });

            DataTable DTabBranch = ObjFillCombo.FillCmb(FillCombo.TABLE.Branch_Master);
            DTabBranch.DefaultView.Sort = "Branch_Name";
            DTabBranch = DTabBranch.DefaultView.ToTable();

            ListBranch.InvokeEx(t =>
            {
                t.Properties.DataSource = DTabBranch;
                t.Properties.DisplayMember = "Branch_Name";
                t.Properties.ValueMember = "branch_id";
                t.SetEditValue(BLL.GlobalDec.gEmployeeProperty.branch_id);
            });

            DataTable DTabLocation = ObjFillCombo.FillCmb(FillCombo.TABLE.Location_Master);
            DTabLocation.DefaultView.Sort = "Location_Name";
            DTabLocation = DTabLocation.DefaultView.ToTable();

            ListLocation.InvokeEx(t =>
            {
                t.Properties.DataSource = DTabLocation;
                t.Properties.DisplayMember = "Location_Name";
                t.Properties.ValueMember = "location_id";
                t.SetEditValue(BLL.GlobalDec.gEmployeeProperty.location_id);
            });

            DataTable DTabDepartment = ObjFillCombo.FillCmb(FillCombo.TABLE.Department_Master);
            DTabDepartment.DefaultView.Sort = "Department_Name";
            DTabDepartment = DTabDepartment.DefaultView.ToTable();

            ListDepartment.InvokeEx(t =>
            {
                t.Properties.DataSource = DTabDepartment;
                t.Properties.DisplayMember = "Department_Name";
                t.Properties.ValueMember = "department_id";
                t.SetEditValue(BLL.GlobalDec.gEmployeeProperty.department_id);
            });
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            DTPFromDate.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
            DTPFromDate.Properties.Mask.EditMask = "dd/MMM/yyyy";
            DTPFromDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            DTPFromDate.Properties.CharacterCasing = CharacterCasing.Upper;
            DTPFromDate.EditValue = Val.DBDate(m_opDate.Rows[0]["opening_date"].ToString());

            DTPToDate.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
            DTPToDate.Properties.Mask.EditMask = "dd/MMM/yyyy";
            DTPToDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            DTPToDate.Properties.CharacterCasing = CharacterCasing.Upper;


            DTPToDate.EditValue = DateTime.Now;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnGenerateReport_Click(object sender, EventArgs e)
        {
            var result = DateTime.Compare(Convert.ToDateTime(DTPFromDate.Text), Convert.ToDateTime(DTPToDate.Text.ToString()));
            if (result > 0)
            {
                Global.Message(" Transaction From Date Not Be Greater Than Transaction To Date");
                return;
            }

            PanelLoading.Visible = true;
            ReportParams_Property.Group_By_Tag = ListGroupBy.GetTagValue;
            ReportParams_Property.From_Date = Val.DBDate(DTPFromDate.Text);
            ReportParams_Property.To_Date = Val.DBDate(DTPToDate.Text);
            ReportParams_Property.company_id = Val.Trim(ListCompany.Properties.GetCheckedItems());
            ReportParams_Property.branch_id = Val.Trim(ListBranch.Properties.GetCheckedItems());
            ReportParams_Property.location_id = Val.Trim(ListLocation.Properties.GetCheckedItems());
            ReportParams_Property.department_id = Val.Trim(ListDepartment.Properties.GetCheckedItems());
            ReportParams_Property.IsCurrent = Val.ToBoolean(chkIsCurrent.Checked);

            if (this.backgroundWorker1.IsBusy)
            {

            }
            else
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            DTab = ObjReportParams.GetLiveStock(ReportParams_Property, ObjReportDetailProperty.Procedure_Name);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            PanelLoading.Visible = false;
            if (mIntPivot == 0)
            {
                FrmGReportViewerBand FrmGReportViewer = new Report.FrmGReportViewerBand();

                if (chkPivot.Checked == true)
                {
                    FrmGReportViewer.IsPivot = true;
                }
                else
                {
                    FrmGReportViewer.IsPivot = false;
                }

                FrmGReportViewer.Group_By_Tag = ListGroupBy.GetTagValue;
                FrmGReportViewer.Group_By_Text = ListGroupBy.GetTextValue;
                FrmGReportViewer.ObjReportDetailProperty = ObjReportDetailProperty;
                FrmGReportViewer.mDTDetail = mDTDetail;
                FrmGReportViewer.Report_Type = Val.ToString(RbtReportType.EditValue);
                FrmGReportViewer.Report_Code = ObjReportDetailProperty.Report_code;

                FrmGReportViewer.Remark = ObjReportDetailProperty.Remark;
                FrmGReportViewer.ReportParams_Property = ReportParams_Property;
                FrmGReportViewer.Procedure_Name = ObjReportDetailProperty.Procedure_Name;
                FrmGReportViewer.FilterByFormName = this.Name;

                FrmGReportViewer.ReportHeaderName = ObjReportDetailProperty.Report_Header_Name;
                FrmGReportViewer.FilterBy = GetFilterByValue();
                FrmGReportViewer.DTab = DTab;
                if (FrmGReportViewer.DTab == null || FrmGReportViewer.DTab.Rows.Count == 0)
                {
                    this.Cursor = Cursors.Default;
                    FrmGReportViewer.Dispose();
                    FrmGReportViewer = null;
                    Global.Message("Data Not Found");
                    return;
                }
                this.Cursor = Cursors.Default;
                FrmGReportViewer.ShowForm();
            }
            else
            {
                FrmPReportViewer FrmPReportViewer = new Report.FrmPReportViewer();
                FrmPReportViewer.Group_By_Tag = ListGroupBy.GetTagValue;
                FrmPReportViewer.Group_By_Text = ListGroupBy.GetTextValue;
                FrmPReportViewer.ObjReportDetailProperty = ObjReportDetailProperty;
                FrmPReportViewer.mDTDetail = mDTDetail;
                FrmPReportViewer.Report_Type = Val.ToString(RbtReportType.EditValue);
                FrmPReportViewer.Report_Code = ObjReportDetailProperty.Report_code;

                FrmPReportViewer.ReportHeaderName = ObjReportDetailProperty.Report_Header_Name;
                FrmPReportViewer.FilterBy = GetFilterByValue();
                FrmPReportViewer.DTab = DTab;
                if (FrmPReportViewer.DTab == null || FrmPReportViewer.DTab.Rows.Count == 0)
                {
                    this.Cursor = Cursors.Default;
                    FrmPReportViewer.Dispose();
                    FrmPReportViewer = null;
                    Global.Message("Data Not Found");
                    this.Enabled = true;
                    return;
                }
                this.Cursor = Cursors.Default;
                FrmPReportViewer.ShowForm();
            }
        }

        private void ListCompany_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable DeTemp = new DataTable();
                var temp = ListCompany.Properties.GetCheckedItems().ToString().Replace(" ", "").Replace("  ", "").Trim();
                if (temp != "")
                    DeTemp = (DataTable)ListCompany.Properties.DataSource;

                if (temp.Length > 0)
                    DeTemp = DeTemp.Select("company_id in (" + temp + ")").CopyToDataTable();

                StrColumnName = "Company ";
                string StrFieldName = "company_name";
                TreeView_List(DeTemp, StrColumnName, StrFieldName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void RbtReportType_EditValueChanged(object sender, EventArgs e)
        {
            ObjReportDetailProperty = ObjReportMaster.GetReportDetailProperty(mIntReportCode, Val.ToString(RbtReportType.EditValue));
            mDTDetail = ObjReportMaster.GetDataForSearchSettings(mIntReportCode, Val.ToString(RbtReportType.EditValue));

            if (ListGroupBy.GetTextValue != "")
            {
                ObjReportDetailProperty.Default_Group_By = ListGroupBy.GetTextValue;
            }

            ListGroupBy.DTab = mDTDetail;
            ListGroupBy.Default = ObjReportDetailProperty.Default_Group_By;
            if (ObjReportDetailProperty.Remark == "Punch_Miss_Report")
            {
                DTPToDate.Enabled = false;
            }
            else
            {
                DTPToDate.Enabled = true;
            }

        }

        private void ListDepartment_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable DeTemp = new DataTable();
                var temp = ListDepartment.Properties.GetCheckedItems().ToString().Replace(" ", "").Replace("  ", "").Trim();
                if (temp != "")
                    DeTemp = (DataTable)ListDepartment.Properties.DataSource;

                if (temp.Length > 0)
                    DeTemp = DeTemp.Select("department_id in (" + temp + ")").CopyToDataTable();

                StrColumnName = "Department ";
                string StrFieldName = "department_name";
                TreeView_List(DeTemp, StrColumnName, StrFieldName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ListBranch_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable DeTemp = new DataTable();
                var temp = ListBranch.Properties.GetCheckedItems().ToString().Replace(" ", "").Replace("  ", "").Trim();
                if (temp != "")
                    DeTemp = (DataTable)ListBranch.Properties.DataSource;

                if (temp.Length > 0)
                    DeTemp = DeTemp.Select("branch_id in (" + temp + ")").CopyToDataTable();

                StrColumnName = "Branch ";
                string StrFieldName = "branch_name";
                TreeView_List(DeTemp, StrColumnName, StrFieldName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ListLocation_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable DeTemp = new DataTable();
                var temp = ListLocation.Properties.GetCheckedItems().ToString().Replace(" ", "").Replace("  ", "").Trim();
                if (temp != "")
                    DeTemp = (DataTable)ListLocation.Properties.DataSource;

                if (temp.Length > 0)
                    DeTemp = DeTemp.Select("Location_id in (" + temp + ")").CopyToDataTable();

                StrColumnName = "Location ";
                string StrFieldName = "location_name";
                TreeView_List(DeTemp, StrColumnName, StrFieldName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {

            chkPivot.Checked = false;
            for (int i = 0; i < ListCompany.Properties.Items.Count; i++)
                ListCompany.Properties.Items[i].CheckState = CheckState.Unchecked;

            for (int i = 0; i < ListBranch.Properties.Items.Count; i++)
                ListBranch.Properties.Items[i].CheckState = CheckState.Unchecked;

            for (int i = 0; i < ListLocation.Properties.Items.Count; i++)
                ListLocation.Properties.Items[i].CheckState = CheckState.Unchecked;

            for (int i = 0; i < ListDepartment.Properties.Items.Count; i++)
                ListDepartment.Properties.Items[i].CheckState = CheckState.Unchecked;

            DTPFromDate.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
            DTPFromDate.Properties.Mask.EditMask = "dd/MMM/yyyy";
            DTPFromDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            DTPFromDate.Properties.CharacterCasing = CharacterCasing.Upper;
            DTPFromDate.EditValue = DateTime.Now;

            DTPToDate.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
            DTPToDate.Properties.Mask.EditMask = "dd/MMM/yyyy";
            DTPToDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            DTPToDate.Properties.CharacterCasing = CharacterCasing.Upper;
            DTPToDate.EditValue = DateTime.Now;
            DTPFromDate.Focus();
        }


        #endregion

        #region "Functions"
        private void FillListControls()
        {
            ObjFillCombo.user_id = GlobalDec.gEmployeeProperty.user_id;

            DataRow r = dtAllvalues.NewRow();
            r[dc_Unique] = BLL.GlobalDec.gEmployeeProperty.company_name;
            r[dc_Parent] = "Company ";
            r[dc_Data] = BLL.GlobalDec.gEmployeeProperty.company_name;
            dtAllvalues.Rows.Add(r);

            r = dtAllvalues.NewRow();
            r[dc_Unique] = BLL.GlobalDec.gEmployeeProperty.branch_name;
            r[dc_Parent] = "Branch ";
            r[dc_Data] = BLL.GlobalDec.gEmployeeProperty.branch_name;
            dtAllvalues.Rows.Add(r);

            r = dtAllvalues.NewRow();
            r[dc_Unique] = BLL.GlobalDec.gEmployeeProperty.location_name;
            r[dc_Parent] = "Location ";
            r[dc_Data] = BLL.GlobalDec.gEmployeeProperty.location_name;
            dtAllvalues.Rows.Add(r);

            treeView_Condition.ParentFieldName = "Parent";
            treeView_Condition.KeyFieldName = "Unique";
            treeView_Condition.RootValue = string.Empty;
            treeView_Condition.DataSource = dtAllvalues;
            treeView_Condition.ExpandAll();
        }

        private string GetFilterByValue()
        {
            string Str = "Filter By : ";

            if (DTPFromDate.Text != "")
            {
                Str += "From Issue Date : " + DTPFromDate.Text;
            }
            if (DTPToDate.Text != "")
            {
                Str += " & As On Date : " + DTPToDate.Text;
            }
            return Str;
        }

        private void TreeView_List(DataTable DeTemp, string StrColumnName, string StrFieldName)
        {
            try
            {
                for (int i = dtAllvalues.Rows.Count - 1; i >= 0; i--)
                {

                    if (dtAllvalues.Rows[i][dc_Parent].ToString() == StrColumnName)
                    {
                        dtAllvalues.Rows.Remove(dtAllvalues.Rows[i]);
                    }
                }

                if (dtAllvalues.Rows.Count == 0)
                {
                    DataRow r = dtAllvalues.NewRow();
                    r[dc_Unique] = StrColumnName;
                    r[dc_Parent] = "";
                    r[dc_Data] = StrColumnName;
                    dtAllvalues.Rows.Add(r);
                }
                else
                {
                    int chk = 0;
                    for (int i = 0; i < dtAllvalues.Rows.Count; i++)
                    {
                        if (dtAllvalues.Rows[i][dc_Unique].ToString() == StrColumnName)
                        {
                            chk = 1;
                        }
                    }
                    if (chk == 0)
                    {
                        DataRow r = dtAllvalues.NewRow();
                        r[dc_Unique] = StrColumnName;
                        r[dc_Parent] = "";
                        r[dc_Data] = StrColumnName;
                        dtAllvalues.Rows.Add(r);
                    }
                }

                for (int j = 0; j < DeTemp.Rows.Count; j++)
                {

                    int chk = 0;
                    for (int i = 0; i < dtAllvalues.Rows.Count; i++)
                    {
                        if (dtAllvalues.Rows[i][dc_Unique].ToString() == DeTemp.Rows[j][StrFieldName].ToString())
                        {
                            chk = 1;
                        }
                    }
                    if (chk == 0)
                    {
                        DataRow r = dtAllvalues.NewRow();
                        r[dc_Unique] = DeTemp.Rows[j][StrFieldName].ToString();
                        r[dc_Parent] = StrColumnName;
                        r[dc_Data] = DeTemp.Rows[j][StrFieldName].ToString();
                        dtAllvalues.Rows.Add(r);
                    }
                }
                treeView_Condition.ParentFieldName = "Parent";
                treeView_Condition.KeyFieldName = "Unique";
                treeView_Condition.RootValue = string.Empty;
                treeView_Condition.DataSource = dtAllvalues;
                treeView_Condition.ExpandAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FillControls()
        {
            DataTable DTab = ObjReportMaster.GetDataForSearchDetailReport(mIntReportCode);

            foreach (DataRow DRow in DTab.Rows)
            {
                if (Val.ToInt(DRow["is_pivot"].ToString()) == 1)
                {
                    mIntPivot = 1;
                }

                DevExpress.XtraEditors.Controls.RadioGroupItem rd = new DevExpress.XtraEditors.Controls.RadioGroupItem();
                rd.Tag = Val.ToString(DRow["report_type"]);
                rd.Value = Val.ToString(DRow["report_type"]);
                rd.Description = Val.ToString(DRow["report_type"]);
                RbtReportType.Properties.Items.Add(rd);

            }
            RbtReportType.SelectedIndex = 0;
            ObjReportMasterProperty = ObjReportMaster.GetReportMasterProperty(mIntReportCode);
            lblTitle.Text = ObjReportMasterProperty.Report_Name;
        }

        #endregion
    }
}
