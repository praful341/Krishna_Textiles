using BLL;
using BLL.FunctionClasses.Master;
using BLL.PropertyClasses.Master;
using Krishna_Textiles.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Krishna_Textiles.Class.Global;

namespace Krishna_Textiles.Master
{
    public partial class FrmConfigPermission : DevExpress.XtraEditors.XtraForm
    {
        #region Data Member

        FormEvents objBOFormEvents;
        Validation Val;
        BLL.FormPer ObjPer;

        DepartmentMaster objDept;
        CompanyMaster objComp;
        BranchMaster objBranch;
        LocationMaster objLoc;
        ConfigPermission objConfig;
        List<Task> tList = new List<Task>();

        int m_IntRes;

        bool blnReturn;
        #endregion

        #region Constructor
        public FrmConfigPermission()
        {
            InitializeComponent();

            objBOFormEvents = new FormEvents();
            Val = new Validation();
            ObjPer = new BLL.FormPer();

            objDept = new DepartmentMaster();
            objComp = new CompanyMaster();
            objBranch = new BranchMaster();
            objLoc = new LocationMaster();
            objConfig = new ConfigPermission();

            m_IntRes = 0;

            blnReturn = true;

            txtUName.Enabled = false;
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
        }
        private void AttachFormEvents()
        {
            objBOFormEvents.CurForm = this;
            objBOFormEvents.FormKeyPress = true;
            objBOFormEvents.FormKeyDown = true;
            objBOFormEvents.FormResize = true;
            objBOFormEvents.FormClosing = true;
            objBOFormEvents.ObjToDispose.Add(objConfig);
            objBOFormEvents.ObjToDispose.Add(Val);
            objBOFormEvents.ObjToDispose.Add(objBOFormEvents);
        }
        #endregion

        #region Events
        private void FrmConfigPermission_Load(object sender, EventArgs e)
        {
            try
            {
                Task.Run(() => GetData());
                txtUName.Focus();
                FillControl();
            }
            catch (Exception ex)
            {
                General.ShowErrors(ex.ToString());
                return;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            ObjPer.SetFormPer();
            if (ObjPer.AllowUpdate == false || ObjPer.AllowInsert == false)
            {
                Global.Message(BLL.GlobalDec.gStrPermissionInsUpdMsg);
                return;
            }
            btnSave.Enabled = false;

            if (SaveDetails())
            {
                GetData();
                btnClear_Click(sender, e);
            }

            btnSave.Enabled = true;
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                lblMode.Tag = 0;
                lblMode.Text = "Add Mode";
                lueCompany.SetEditValue(-1);
                lueBranch.SetEditValue(-1);
                lueLocation.SetEditValue(-1);
                lueDepartment.SetEditValue(-1);
                txtUName.Text = "";
                txtUName.Focus();
            }
            catch (Exception ex)
            {
                General.ShowErrors(ex.ToString());
                return;
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region GridEvents
        private void dgvConfigCompanyRights_FocusedRowChanged_1(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

            try
            {
                int StrUserId = Val.ToInt(Val.ToString(dgvConfigCompanyRights.GetRowCellValue(dgvConfigCompanyRights.FocusedRowHandle, "user_id")));
                txtUName.Text = Val.ToString(dgvConfigCompanyRights.GetRowCellValue(dgvConfigCompanyRights.FocusedRowHandle, "user_name"));
                txtUName.Tag = StrUserId;
                getUserPermission(StrUserId);
            }
            catch (Exception ex)
            {
                General.ShowErrors(ex.ToString());
                blnReturn = false;
            }
        }
        #endregion

        #endregion

        #region Functions
        private bool SaveDetails()
        {
            bool blnReturn = true;
            Config_PermissionMasterProperty configPermissionProperty = new Config_PermissionMasterProperty();

            try
            {
                if (!ValidateDetails())
                {
                    blnReturn = false;
                    return blnReturn;

                }

                var StrCompany = lueCompany.Properties.GetCheckedItems().ToString().Replace(" ", "").Replace("  ", "").Trim();
                string[] array = StrCompany.Split(',');

                var StrBranch = lueBranch.Properties.GetCheckedItems().ToString().Replace(" ", "").Replace("  ", "").Trim();
                string[] array1 = StrBranch.Split(',');

                var StrLocation = lueLocation.Properties.GetCheckedItems().ToString().Replace(" ", "").Replace("  ", "").Trim();
                string[] array2 = StrLocation.Split(',');

                var StrDepartment = lueDepartment.Properties.GetCheckedItems().ToString().Replace(" ", "").Replace("  ", "").Trim();
                string[] array3 = StrDepartment.Split(',');

                if (!string.IsNullOrEmpty(StrCompany))
                {
                    configPermissionProperty.type = "Delete";
                    configPermissionProperty.user_id = Val.ToInt32(txtUName.Tag);
                    m_IntRes = objConfig.Delete(configPermissionProperty);
                    foreach (var item in array)
                    {
                        configPermissionProperty.type = "Company";
                        configPermissionProperty.config_company_id = Val.ToInt32(item);
                        configPermissionProperty.user_id = Val.ToInt32(txtUName.Tag);
                        m_IntRes = objConfig.Save(configPermissionProperty);
                    }

                }
                if (!string.IsNullOrEmpty(StrBranch))
                {
                    foreach (var item in array1)
                    {

                        configPermissionProperty.type = "Branch";
                        configPermissionProperty.config_branch_id = Val.ToInt32(item);
                        configPermissionProperty.user_id = Val.ToInt32(txtUName.Tag);
                        m_IntRes = objConfig.Save(configPermissionProperty);
                    }

                }
                if (!string.IsNullOrEmpty(StrLocation))
                {
                    foreach (var item in array2)
                    {
                        configPermissionProperty.type = "Location";
                        configPermissionProperty.config_location_id = Val.ToInt32(item);
                        configPermissionProperty.user_id = Val.ToInt32(txtUName.Tag);
                        m_IntRes = objConfig.Save(configPermissionProperty);
                    }

                }
                if (!string.IsNullOrEmpty(StrDepartment))
                {
                    foreach (var item in array3)
                    {
                        configPermissionProperty.type = "Department";
                        configPermissionProperty.config_department_id = Val.ToInt32(item);
                        configPermissionProperty.user_id = Val.ToInt32(txtUName.Tag);
                        m_IntRes = objConfig.Save(configPermissionProperty);
                    }

                }
                if (m_IntRes == -1)
                {
                    Global.Confirm("Error In Save User Rights");
                    txtUName.Focus();
                }
                else
                {
                    if (Val.ToInt(lblMode.Tag) == 0)
                    {
                        Global.Confirm("User Rights Data Save Successfully");
                    }
                    else
                    {
                        Global.Confirm("User Rights Data Update Successfully");
                    }
                }

            }
            catch (Exception ex)
            {
                General.ShowErrors(ex.ToString());
                blnReturn = false;
            }
            finally
            {
                configPermissionProperty = null;
            }

            return blnReturn;
        }
        private bool ValidateDetails()
        {
            bool blnFocus = false;
            List<ListError> lstError = new List<ListError>();
            try
            {
                if (txtUName.Text.Length == 0)
                {
                    lstError.Add(new ListError(13, "User Name"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                        txtUName.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                lstError.Add(new ListError(ex));
            }
            return (!(BLL.General.ShowErrors(lstError)));

        }
        public void FillControl()
        {
            try
            {
                DataTable dtbDept = new DataTable();
                dtbDept = objDept.GetData();
                lueDepartment.InvokeEx(t =>
                {
                    t.Properties.DataSource = dtbDept;
                    t.Properties.ValueMember = "department_id";
                    t.Properties.DisplayMember = "department_name";
                });

                DataTable dtbComp = new DataTable();
                dtbComp = objComp.GetData();
                lueCompany.InvokeEx(t =>
                {
                    t.Properties.DataSource = dtbComp;
                    t.Properties.ValueMember = "company_id";
                    t.Properties.DisplayMember = "company_name";
                });

                DataTable dtbBranch = new DataTable();
                dtbBranch = objBranch.GetData();
                lueBranch.InvokeEx(t =>
                {
                    t.Properties.DataSource = dtbBranch;
                    t.Properties.ValueMember = "branch_id";
                    t.Properties.DisplayMember = "branch_name";
                });

                DataTable dtbLoc = new DataTable();
                dtbLoc = objLoc.GetData();
                lueLocation.InvokeEx(t =>
                {
                    t.Properties.DataSource = dtbLoc;
                    t.Properties.ValueMember = "location_id";
                    t.Properties.DisplayMember = "location_name";
                });
            }
            catch (Exception ex)
            {
                General.ShowErrors(ex.ToString());
                return;
            }
        }
        public void GetData()
        {
            try
            {
                DataTable DTab = objConfig.UserGetData();
                grdConfigCompanyRights.InvokeEx(t =>
                {
                    t.DataSource = DTab;
                    dgvConfigCompanyRights.BestFitColumns();
                });
            }
            catch (Exception ex)
            {
                General.ShowErrors(ex.ToString());
                return;
            }
        }
        public void getUserPermission(int p_UserID)
        {
            try
            {
                if (Val.Val(p_UserID) == 0)
                {
                    return;
                }
                if (p_UserID > 0)
                {
                    DataRow DR = (DataRow)objConfig.GetEmployeeCompany(p_UserID);
                    if (DR != null)
                    {
                        lueCompany.SetEditValue(Val.ToString(DR["company_id"]));
                        lueCompany.Tag = Val.ToString(DR["company_id"]);
                    }
                    DR = (DataRow)objConfig.GetEmployeeBranch(p_UserID);
                    if (DR != null)
                    {
                        lueBranch.SetEditValue(Val.ToString(DR["branch_id"]));
                        lueBranch.Tag = Val.ToString(DR["branch_id"]);
                    }
                    DR = (DataRow)objConfig.GetEmployeeLocation(p_UserID);
                    if (DR != null)
                    {
                        lueLocation.SetEditValue(Val.ToString(DR["location_id"]));
                        lueLocation.Tag = Val.ToString(DR["location_id"]);
                    }
                    DR = (DataRow)objConfig.GetEmployeeDepartment(p_UserID);
                    if (DR != null)
                    {
                        lueDepartment.SetEditValue(Val.ToString(DR["department_id"]));
                        lueDepartment.Tag = Val.ToString(DR["department_id"]);
                    }
                }

            }
            catch (Exception ex)
            {
                General.ShowErrors(ex.ToString());
                blnReturn = false;
            }
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
                            dgvConfigCompanyRights.ExportToPdf(Filepath);
                            break;
                        case "xls":
                            dgvConfigCompanyRights.ExportToXls(Filepath);
                            break;
                        case "xlsx":
                            dgvConfigCompanyRights.ExportToXlsx(Filepath);
                            break;
                        case "rtf":
                            dgvConfigCompanyRights.ExportToRtf(Filepath);
                            break;
                        case "txt":
                            dgvConfigCompanyRights.ExportToText(Filepath);
                            break;
                        case "html":
                            dgvConfigCompanyRights.ExportToHtml(Filepath);
                            break;
                        case "csv":
                            dgvConfigCompanyRights.ExportToCsv(Filepath);
                            break;
                    }

                    if (format.Equals(Exports.xlsx.ToString()))
                    {
                        if (Global.Confirm("Export Done\n\nYou Want To Open Excel File ?", "Krishna_Textiles", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start(Filepath);
                        }
                    }
                    else if (format.Equals(Exports.pdf.ToString()))
                    {
                        if (Global.Confirm("Export Done\n\nYou Want To Open PDF File ?", "Krishna_Textiles", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start(Filepath);
                        }
                    }
                    else
                    {
                        if (Global.Confirm("Export Done\n\nYou Want To Open File ?", "Krishna_Textiles", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
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
    }
}
