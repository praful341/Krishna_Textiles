using Account_Management.Class;
using BLL;
using BLL.FunctionClasses.Master;
using BLL.PropertyClasses.Master;
using BLL.PropertyClasses.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Account_Management.Class.Global;

namespace Account_Management.Master
{
    public partial class FrmConfigRolePermissionMaster : DevExpress.XtraEditors.XtraForm
    {
        #region Data Member

        BLL.BeginTranConnection Conn;
        BLL.FormEvents objBOFormEvents;
        BLL.Validation Val;
        BLL.FormPer ObjPer;

        ConfigRoleMaster objConfigRole;
        List<Task> tList = new List<Task>();

        int IntRes;

        #endregion

        #region Constructor
        public FrmConfigRolePermissionMaster()
        {
            InitializeComponent();

            objBOFormEvents = new BLL.FormEvents();
            Val = new BLL.Validation();
            ObjPer = new BLL.FormPer();

            objConfigRole = new ConfigRoleMaster();

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
        }
        private void AttachFormEvents()
        {
            objBOFormEvents.CurForm = this;
            objBOFormEvents.FormKeyPress = true;
            objBOFormEvents.FormKeyDown = true;
            objBOFormEvents.FormResize = true;
            objBOFormEvents.FormClosing = true;
            objBOFormEvents.ObjToDispose.Add(objConfigRole);
            objBOFormEvents.ObjToDispose.Add(Val);
            objBOFormEvents.ObjToDispose.Add(objBOFormEvents);
        }
        #endregion

        #region Events
        private void FrmConfigRolePermissionMaster_Shown(object sender, System.EventArgs e)
        {
            try
            {
                Task.Run(() => Global.LOOKUPPermission(LookupRole));
                Task.Run(() => Global.LOOKUPPermission(LookupCopyUser));
                Task.Run(() => Global.LOOKUPPermission(CmbReportRoleName));
                Task.Run(() => Global.LOOKUPPermission(CmbReportCopyUser));
            }
            catch (Exception ex)
            {
                General.ShowErrors(ex.ToString());
                return;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            Conn = new BeginTranConnection(true, false);
            ConfigRole_MasterProperty ConfigRoleProperty = new ConfigRole_MasterProperty();
            UserAuthenticationProperty UserAuthenticationProperty = new UserAuthenticationProperty();
            try
            {
                ObjPer.SetFormPer();
                if (ObjPer.AllowUpdate == false || ObjPer.AllowInsert == false)
                {
                    Global.Message(BLL.GlobalDec.gStrPermissionInsUpdMsg);
                    return;
                }
                if (TabBar.SelectedTabPageIndex == 0)
                {
                    if (ValSave() == false)
                    {
                        return;
                    }
                    try
                    {
                        for (int i = 0; i < dgvRolePermissionMaster.RowCount - 1; i++)
                        {
                            DataRow DRow = dgvRolePermissionMaster.GetDataRow(i);
                            if (Val.ToString(DRow["form_name"]) == "")
                            {
                                continue;
                            }

                            ConfigRoleProperty = new ConfigRole_MasterProperty();

                            ConfigRoleProperty.role_id = Val.ToInt(LookupRole.EditValue);
                            ConfigRoleProperty.form_id = Val.ToInt(DRow["form_id"]);
                            ConfigRoleProperty.role_permission_id = Val.ToInt(DRow["role_permission_id"]);
                            ConfigRoleProperty.allow_view = Val.ToBooleanToInt(DRow["alw_view"]);
                            ConfigRoleProperty.allow_add = Val.ToBooleanToInt(DRow["alw_add"]);
                            ConfigRoleProperty.allow_edit = Val.ToBooleanToInt(DRow["alw_edit"]);
                            ConfigRoleProperty.allow_delete = Val.ToBooleanToInt(DRow["alw_delete"]);
                            ConfigRoleProperty.allow_export = Val.ToBooleanToInt(DRow["alw_export"]);
                            ConfigRoleProperty.allow_print = Val.ToBooleanToInt(DRow["alw_print"]);
                            ConfigRoleProperty.allow_email = Val.ToBooleanToInt(DRow["alw_email"]);
                            ConfigRoleProperty.allow_attachment = Val.ToBooleanToInt(DRow["alw_attachment"]);
                            ConfigRoleProperty.allow_password = Val.ToString(DRow["allow_password"]);

                            IntRes = objConfigRole.User_Permission_Save(ConfigRoleProperty, DLL.GlobalDec.EnumTran.Continue, Conn);
                        }
                        Conn.Inter1.Commit();
                    }
                    catch (Exception ex)
                    {
                        IntRes = -1;
                        Conn.Inter1.Rollback();
                        Conn = null;
                        General.ShowErrors(ex.ToString());
                    }
                    finally
                    {
                        ConfigRoleProperty = null;
                    }
                    if (IntRes > 0)
                    {
                        Global.Message("Saved Successfully");
                        btnClear_Click(null, null);
                        return;
                    }
                    else
                    {
                        IntRes = -1;
                        Conn.Inter1.Rollback();
                        Conn = null;
                        Global.Message("Error.. In Save Permission");
                        return;
                    }
                }
                if (TabBar.SelectedTabPageIndex == 1)
                {
                    if (ValSave() == false)
                    {
                        return;
                    }
                    try
                    {
                        for (int i = 0; i < grdReport.RowCount; i++)
                        {

                            DataRow DRow = grdReport.GetDataRow(i);
                            if (Val.ToString(DRow["report_name"]) == "")
                            {
                                break;
                            }

                            UserAuthenticationProperty = new UserAuthenticationProperty();

                            UserAuthenticationProperty.role_id = Val.ToInt(CmbReportRoleName.EditValue);
                            UserAuthenticationProperty.Report_Code = Val.ToInt(DRow["report_code"]);
                            UserAuthenticationProperty.Viw = Val.ToBooleanToInt(DRow["alw_view"]);
                            UserAuthenticationProperty.Print = Val.ToBooleanToInt(DRow["alw_print"]);
                            UserAuthenticationProperty.Export = Val.ToBooleanToInt(DRow["alw_export"]);
                            UserAuthenticationProperty.Email = Val.ToBooleanToInt(DRow["alw_email"]);

                            IntRes = objConfigRole.SaveReport(UserAuthenticationProperty, DLL.GlobalDec.EnumTran.Continue, Conn);
                        }
                        Conn.Inter1.Commit();
                    }
                    catch (Exception ex)
                    {
                        IntRes = -1;
                        Conn.Inter1.Rollback();
                        Conn = null;
                        General.ShowErrors(ex.ToString());
                    }
                    finally
                    {
                        UserAuthenticationProperty = null;
                    }
                    if (IntRes > 0)
                    {
                        Global.Message("Saved Successfully");
                        return;
                    }
                    else
                    {
                        IntRes = -1;
                        Conn.Inter1.Rollback();
                        Conn = null;
                        Global.Message("Error.. In Save Permission");
                        return;
                    }
                }
            }
            catch (Exception Ex)
            {
                IntRes = -1;
                Conn.Inter1.Rollback();
                Conn = null;
                Global.Message(Ex.ToString());
                if (Ex.InnerException != null)
                {
                    Global.Message(Ex.InnerException.ToString());
                }
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                if (TabBar.SelectedTabPageIndex == 0)
                {
                    LookupRole.EditValue = null;
                    LookupCopyUser.EditValue = null;
                    grdRolePermissionMaster.DataSource = null;
                    LookupRole.Focus();
                }
                if (TabBar.SelectedTabPageIndex == 1)
                {
                    CmbReportRoleName.EditValue = null;
                    CmbReportCopyUser.EditValue = null;
                    MainGridReport.DataSource = null;
                    CmbReportRoleName.Focus();
                }
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
        private void LookupRole_EditValueChanged(object sender, System.EventArgs e)
        {
            FillGrid();
        }
        private void BtnReportCopy_Click(object sender, EventArgs e)
        {
            UserAuthenticationProperty UserAuthenticationProperty = new UserAuthenticationProperty();
            Conn = new BeginTranConnection(true, false);
            try
            {
                if (string.IsNullOrEmpty(CmbReportRoleName.Text.Trim()))
                {
                    Global.Confirm("Role Name Is Required");
                    CmbReportRoleName.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(CmbReportCopyUser.Text.Trim()))
                {
                    Global.Confirm("Copy Role Name Is Required");
                    CmbReportCopyUser.Focus();
                    return;
                }
                if (Global.Confirm("Are You Sure You Want To Copy Data ? ", "DREP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }
                try
                {
                    int IntRes = 0;
                    for (int i = 0; i < grdReport.RowCount; i++)
                    {
                        DataRow DRow = grdReport.GetDataRow(i);
                        if (Val.ToString(DRow["report_name"]) == "")
                        {
                            break;
                        }

                        UserAuthenticationProperty = new UserAuthenticationProperty();
                        UserAuthenticationProperty.role_id = Val.ToInt(CmbReportCopyUser.EditValue);
                        UserAuthenticationProperty.Report_Code = Val.ToInt(DRow["report_code"]);
                        UserAuthenticationProperty.Viw = Val.ToBooleanToInt(DRow["alw_view"]);
                        UserAuthenticationProperty.Print = Val.ToBooleanToInt(DRow["alw_print"]);
                        UserAuthenticationProperty.Export = Val.ToBooleanToInt(DRow["alw_export"]);
                        UserAuthenticationProperty.Email = Val.ToBooleanToInt(DRow["alw_print"]);

                        IntRes = objConfigRole.SaveReport(UserAuthenticationProperty, DLL.GlobalDec.EnumTran.Continue, Conn);
                    }
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
                    UserAuthenticationProperty = null;
                }
                if (IntRes > 0)
                {
                    Global.Message("Copy Permission Successfully Done");
                    btnClear_Click(null, null);
                }
                else
                {
                    Global.Message("Error In Copy The Permisision");
                    return;
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
        private void CmbReportRoleName_EditValueChanged(object sender, EventArgs e)
        {
            FillReportGrid();
        }
        private void btnCopy_Click(object sender, EventArgs e)
        {
            ConfigRole_MasterProperty ConfigRoleProperty = new ConfigRole_MasterProperty();
            Conn = new BeginTranConnection(true, false);
            try
            {

                if (string.IsNullOrEmpty(LookupRole.Text.Trim()))
                {
                    Global.Confirm("Role Name Is Required");
                    LookupRole.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(LookupCopyUser.Text.Trim()))
                {
                    Global.Confirm("Copy Role Name Is Required");
                    LookupCopyUser.Focus();
                    return;
                }
                if (Global.Confirm("Are You Sure You Want To Copy Data ? ", "Account_Management", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }
                try
                {
                    for (int i = 0; i < dgvRolePermissionMaster.RowCount - 1; i++)
                    {
                        DataRow DRow = dgvRolePermissionMaster.GetDataRow(i);
                        if (Val.ToString(DRow["form_name"]) == "")
                        {
                            break;
                        }

                        ConfigRoleProperty = new ConfigRole_MasterProperty();

                        ConfigRoleProperty.role_id = Val.ToInt(LookupCopyUser.EditValue);
                        ConfigRoleProperty.form_id = Val.ToInt(DRow["form_id"]);
                        ConfigRoleProperty.role_permission_id = Val.ToInt(DRow["role_permission_id"]);
                        ConfigRoleProperty.allow_view = Val.ToBooleanToInt(DRow["alw_view"]);
                        ConfigRoleProperty.allow_add = Val.ToBooleanToInt(DRow["alw_add"]);
                        ConfigRoleProperty.allow_edit = Val.ToBooleanToInt(DRow["alw_edit"]);
                        ConfigRoleProperty.allow_delete = Val.ToBooleanToInt(DRow["alw_delete"]);
                        ConfigRoleProperty.allow_export = Val.ToBooleanToInt(DRow["alw_export"]);
                        ConfigRoleProperty.allow_print = Val.ToBooleanToInt(DRow["alw_print"]);
                        ConfigRoleProperty.allow_email = Val.ToBooleanToInt(DRow["alw_email"]);
                        ConfigRoleProperty.allow_attachment = Val.ToBooleanToInt(DRow["alw_attachment"]);

                        IntRes = objConfigRole.Save(ConfigRoleProperty, DLL.GlobalDec.EnumTran.Continue, Conn);
                    }
                    Conn.Inter1.Commit();
                }
                catch (Exception ex)
                {
                    IntRes = -1;
                    Conn.Inter1.Rollback();
                    Conn = null;
                    General.ShowErrors(ex.ToString());
                }
                finally
                {
                    ConfigRoleProperty = null;
                }
                if (IntRes > 0)
                {
                    Global.Message("Copy Permission Successfully Done");
                    btnClear_Click(null, null);
                }
                else
                {
                    IntRes = -1;
                    Conn.Inter1.Rollback();
                    Conn = null;
                    Global.Message("Error In Copy The Permisision");
                    return;
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

        #endregion

        #region Functions
        public Boolean ValSave()
        {
            try
            {
                if (TabBar.SelectedTabPageIndex == 0)
                {
                    if (string.IsNullOrEmpty(LookupRole.Text.Trim()))
                    {
                        Global.Confirm("Role Name Is Required");
                        LookupRole.Focus();
                        return false;
                    }
                }
                if (TabBar.SelectedTabPageIndex == 1)
                {
                    if (string.IsNullOrEmpty(CmbReportRoleName.Text.Trim()))
                    {
                        Global.Confirm("Report Role Name Is Required");
                        CmbReportRoleName.Focus();
                        return false;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                General.ShowErrors(ex.ToString());
                return true;
            }
        }
        public void FillGrid()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = objConfigRole.getUserPermision(Val.ToInt32(LookupRole.EditValue));

                if ((dt.Columns.Contains("alw_view") == false))
                {
                    dt.Columns.Add(new DataColumn("alw_view", typeof(Boolean)));
                }
                if ((dt.Columns.Contains("alw_add") == false))
                {
                    dt.Columns.Add(new DataColumn("alw_add", typeof(Boolean)));
                }
                if ((dt.Columns.Contains("alw_edit") == false))
                {
                    dt.Columns.Add(new DataColumn("alw_edit", typeof(Boolean)));
                }
                if ((dt.Columns.Contains("alw_delete") == false))
                {
                    dt.Columns.Add(new DataColumn("alw_delete", typeof(Boolean)));
                }
                if ((dt.Columns.Contains("alw_export") == false))
                {
                    dt.Columns.Add(new DataColumn("alw_export", typeof(Boolean)));
                }
                if ((dt.Columns.Contains("alw_print") == false))
                {
                    dt.Columns.Add(new DataColumn("alw_print", typeof(Boolean)));
                }
                if ((dt.Columns.Contains("alw_email") == false))
                {
                    dt.Columns.Add(new DataColumn("alw_email", typeof(Boolean)));
                }
                if ((dt.Columns.Contains("alw_attachment") == false))
                {
                    dt.Columns.Add(new DataColumn("alw_attachment", typeof(Boolean)));
                }
                if ((dt.Columns.Contains("alw_password") == false))
                {
                    dt.Columns.Add(new DataColumn("alw_password", typeof(Boolean)));
                }

                foreach (DataRow DRowApp in dt.Rows)
                {
                    if (Val.ToInt(DRowApp["allow_view"]) == 1)
                    {
                        DRowApp["alw_view"] = true;
                    }
                    else
                    {
                        DRowApp["alw_view"] = false;
                    }

                    if (Val.ToInt(DRowApp["allow_add"]) == 1)
                    {
                        DRowApp["alw_add"] = true;
                    }
                    else
                    {
                        DRowApp["alw_add"] = false;
                    }

                    if (Val.ToInt(DRowApp["allow_edit"]) == 1)
                    {
                        DRowApp["alw_edit"] = true;
                    }
                    else
                    {
                        DRowApp["alw_edit"] = false;
                    }
                    if (Val.ToInt(DRowApp["allow_delete"]) == 1)
                    {
                        DRowApp["alw_delete"] = true;
                    }
                    else
                    {
                        DRowApp["alw_delete"] = false;
                    }
                    if (Val.ToInt(DRowApp["allow_export"]) == 1)
                    {
                        DRowApp["alw_export"] = true;
                    }
                    else
                    {
                        DRowApp["alw_export"] = false;
                    }
                    if (Val.ToInt(DRowApp["allow_print"]) == 1)
                    {
                        DRowApp["alw_print"] = true;
                    }
                    else
                    {
                        DRowApp["alw_print"] = false;
                    }
                    if (Val.ToInt(DRowApp["allow_email"]) == 1)
                    {
                        DRowApp["alw_email"] = true;
                    }
                    else
                    {
                        DRowApp["alw_email"] = false;
                    }
                    if (Val.ToInt(DRowApp["allow_attachment"]) == 1)
                    {
                        DRowApp["alw_attachment"] = true;
                    }
                    else
                    {
                        DRowApp["alw_attachment"] = false;
                    }
                    if (Val.ToInt(DRowApp["allow_password"]) == 1)
                    {
                        DRowApp["alw_password"] = true;
                    }
                    else
                    {
                        DRowApp["alw_password"] = false;
                    }
                }
                dt.AcceptChanges();
                grdRolePermissionMaster.DataSource = dt;
                grdRolePermissionMaster.RefreshDataSource();
                dgvRolePermissionMaster.BestFitColumns();
            }
            catch (Exception ex)
            {
                General.ShowErrors(ex.ToString());
                return;
            }
        }
        public void FillReportGrid()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = objConfigRole.GetRportDetail(Val.ToInt32(CmbReportRoleName.EditValue));

                if ((dt.Columns.Contains("alw_view") == false))
                {
                    dt.Columns.Add(new DataColumn("alw_view", typeof(Boolean)));
                }
                if ((dt.Columns.Contains("alw_export") == false))
                {
                    dt.Columns.Add(new DataColumn("alw_export", typeof(Boolean)));
                }
                if ((dt.Columns.Contains("alw_print") == false))
                {
                    dt.Columns.Add(new DataColumn("alw_print", typeof(Boolean)));
                }
                if ((dt.Columns.Contains("alw_email") == false))
                {
                    dt.Columns.Add(new DataColumn("alw_email", typeof(Boolean)));
                }

                foreach (DataRow DRowApp in dt.Rows)
                {
                    if (Val.ToInt(DRowApp["allow_view"]) == 1 || Val.ToString(DRowApp["allow_view"]) == "True")
                    {
                        DRowApp["alw_view"] = true;
                    }
                    else
                    {
                        DRowApp["alw_view"] = false;
                    }

                    if (Val.ToInt(DRowApp["allow_export"]) == 1 || Val.ToString(DRowApp["allow_export"]) == "True")
                    {
                        DRowApp["alw_export"] = true;
                    }
                    else
                    {
                        DRowApp["alw_export"] = false;
                    }
                    if (Val.ToInt(DRowApp["allow_print"]) == 1 || Val.ToString(DRowApp["allow_print"]) == "True")
                    {
                        DRowApp["alw_print"] = true;
                    }
                    else
                    {
                        DRowApp["alw_print"] = false;
                    }
                    if (Val.ToInt(DRowApp["allow_email"]) == 1 || Val.ToString(DRowApp["allow_email"]) == "True")
                    {
                        DRowApp["alw_email"] = true;
                    }
                    else
                    {
                        DRowApp["alw_email"] = false;
                    }
                }
                dt.AcceptChanges();
                MainGridReport.DataSource = dt;
                MainGridReport.RefreshDataSource();
                grdReport.BestFitColumns();
            }
            catch (Exception ex)
            {
                General.ShowErrors(ex.ToString());
                return;
            }
        }
        private void Export(string format, string dlgHeader, string dlgFilter, int grid2 = 0)
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
                    if (grid2 == 0)
                    {
                        switch (format)
                        {

                            case "pdf":
                                dgvRolePermissionMaster.ExportToPdf(Filepath);
                                break;
                            case "xls":
                                dgvRolePermissionMaster.ExportToXls(Filepath);
                                break;
                            case "xlsx":
                                dgvRolePermissionMaster.ExportToXlsx(Filepath);
                                break;
                            case "rtf":
                                dgvRolePermissionMaster.ExportToRtf(Filepath);
                                break;
                            case "txt":
                                dgvRolePermissionMaster.ExportToText(Filepath);
                                break;
                            case "html":
                                dgvRolePermissionMaster.ExportToHtml(Filepath);
                                break;
                            case "csv":
                                dgvRolePermissionMaster.ExportToCsv(Filepath);
                                break;
                        }
                    }
                    if (grid2 == 1)
                    {
                        switch (format)
                        {

                            case "pdf":
                                grdReport.ExportToPdf(Filepath);
                                break;
                            case "xls":
                                grdReport.ExportToXls(Filepath);
                                break;
                            case "xlsx":
                                grdReport.ExportToXlsx(Filepath);
                                break;
                            case "rtf":
                                grdReport.ExportToRtf(Filepath);
                                break;
                            case "txt":
                                grdReport.ExportToText(Filepath);
                                break;
                            case "html":
                                grdReport.ExportToHtml(Filepath);
                                break;
                            case "csv":
                                grdReport.ExportToCsv(Filepath);
                                break;
                        }
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
        private void MNExportExcel1_Click(object sender, EventArgs e)
        {
            //Global.Export("xlsx", dgvRoughClarityMaster);
            Export("xlsx", "Export to Excel", "Excel files 97-2003 (Excel files 2007(*.xlsx)|*.xlsx|All files (*.*)|*.*", 1);
        }
        private void MNExportPDF1_Click(object sender, EventArgs e)
        {
            // Global.Export("pdf", dgvRoughClarityMaster);
            Export("pdf", "Export Report to PDF", "PDF (*.PDF)|*.PDF", 1);
        }
        private void MNExportTEXT1_Click(object sender, EventArgs e)
        {
            Export("txt", "Export to Text", "Text files (*.txt)|*.txt|All files (*.*)|*.*", 1);
        }

        private void MNExportHTML1_Click(object sender, EventArgs e)
        {
            Export("html", "Export to HTML", "Html files (*.html)|*.html|Htm files (*.htm)|*.htm", 1);
        }

        private void MNExportRTF1_Click(object sender, EventArgs e)
        {
            Export("rtf", "Export to RTF", "Word (*.doc) |*.doc;*.rtf|(*.txt) |*.txt|(*.*) |*.*", 1);
        }

        private void MNExportCSV1_Click(object sender, EventArgs e)
        {
            Export("csv", "Export Report to CSVB", "csv (*.csv)|*.csv", 1);
        }
        #endregion


    }
}
