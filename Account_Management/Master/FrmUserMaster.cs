using Account_Management.Class;
using BLL;
using BLL.FunctionClasses.Master;
using BLL.PropertyClasses.Master;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Account_Management.Class.Global;

namespace Account_Management.Master
{
    public partial class FrmUserMaster : DevExpress.XtraEditors.XtraForm
    {
        #region Data Member

        BLL.FormEvents objBOFormEvents;
        BLL.Validation Val;
        BLL.FormPer ObjPer;

        UserMaster objUser;
        List<Task> tList = new List<Task>();

        #endregion

        #region Constructor

        public FrmUserMaster()
        {
            InitializeComponent();

            objBOFormEvents = new BLL.FormEvents();
            Val = new BLL.Validation();
            ObjPer = new BLL.FormPer();

            objUser = new UserMaster();
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
            objBOFormEvents.ObjToDispose.Add(objUser);
            objBOFormEvents.ObjToDispose.Add(Val);
            objBOFormEvents.ObjToDispose.Add(objBOFormEvents);
        }

        #endregion

        #region Events
        private void FrmUserMaster_Load(object sender, EventArgs e)
        {
            try
            {
                Task.Run(() => Global.LOOKUPCompany(lueCompany));
                Task.Run(() => Global.LOOKUPBranch(lueBranch));
                Task.Run(() => Global.LOOKUPLocation(lueLocation));
                Task.Run(() => Global.LOOKUPDepartment(lueDepartment));
                Task.Run(() => Global.LOOKUPRole(lueRoleId));
                Task.Run(() => Global.LOOKUPUserType(lueUserType));
                Task.Run(() => GetData());
                btnClear_Click(btnClear, null);
                txtUserName.Focus();
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
                txtUserName.Text = "";
                txtPassword.Text = "";
                txtTheme.Text = "";
                txtSequenceNo.Text = "";
                txtPassword.Text = "";
                lueEmpId.EditValue = null;
                lueRoleId.EditValue = null;
                luePartyId.EditValue = null;
                lueCompany.EditValue = null;
                lueBranch.EditValue = null;
                lueLocation.EditValue = null;
                lueDepartment.EditValue = null;
                lueUserType.EditValue = null;
                chkActive.Checked = false;
                chkPasswordShow.Checked = false;
                txtUserName.Focus();
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
        private void chkPasswordShow_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.Properties.PasswordChar = chkPasswordShow.Checked ? '\0' : '*';
            if (chkPasswordShow.Checked)
            {
                chkPasswordShow.Text = "Hide";
            }
            else
            {
                chkPasswordShow.Text = "Show";
            }
        }
        #region GridEvents       
        private void dgvUserMaster_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                if (e.RowHandle >= 0)
                {
                    if (e.Clicks == 2)
                    {
                        DataRow Drow = dgvUserMaster.GetDataRow(e.RowHandle);
                        lblMode.Text = "Edit Mode";
                        lblMode.Tag = Val.ToInt64(Drow["user_id"]);
                        txtUserName.Text = Val.ToString(Drow["user_name"]);
                        txtPassword.Text = GlobalDec.Decrypt(Drow["password"].ToString(), true);
                        txtTheme.Text = Val.ToString(Drow["theme"]);
                        txtSequenceNo.Text = Val.ToString(Drow["sequence_no"]);
                        lueEmpId.EditValue = Val.ToInt32(Drow["employee_id"]);
                        lueUserType.EditValue = Val.ToInt32(Drow["usertype_id"]);
                        luePartyId.EditValue = Val.ToInt32(Drow["party_id"]);
                        lueRoleId.EditValue = Val.ToInt32(Drow["role_id"]);
                        lueUserType.EditValue = Val.ToString(Drow["user_type"]);
                        lueCompany.EditValue = Val.ToInt32(Drow["default_company_id"]);
                        lueBranch.EditValue = Val.ToInt32(Drow["default_branch_id"]);
                        lueLocation.EditValue = Val.ToInt32(Drow["default_location_id"]);
                        lueDepartment.EditValue = Val.ToInt32(Drow["default_department_id"]);
                        chkActive.Checked = Val.ToBoolean(Drow["active"]);
                        txtUserName.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                BLL.General.ShowErrors(ex);
                return;
            }
        }
        #endregion

        #endregion

        #region Functions
        private bool ValidateDetails()
        {
            bool blnFocus = false;
            List<ListError> lstError = new List<ListError>();
            try
            {
                if (txtUserName.Text == string.Empty)
                {
                    lstError.Add(new ListError(12, "User Name"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                        txtUserName.Focus();
                    }
                }

                if (!objUser.ISExists(txtUserName.Text, Val.ToInt64(lblMode.Tag)).ToString().Trim().Equals(string.Empty))
                {
                    lstError.Add(new ListError(23, "User Name"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                        txtUserName.Focus();
                    }

                }

                if (txtPassword.Text == string.Empty)
                {
                    lstError.Add(new ListError(12, "Password"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                        txtPassword.Focus();
                    }
                }

                //if (lueEmpId.ItemIndex < 0)
                //{
                //    lstError.Add(new ListError(13, "Employee"));
                //    if (!blnFocus)
                //    {
                //        blnFocus = true;
                //        lueEmpId.Focus();
                //    }
                //}
                //if (luePartyId.ItemIndex < 0)
                //{
                //    lstError.Add(new ListError(13, "Party"));
                //    if (!blnFocus)
                //    {
                //        blnFocus = true;
                //        luePartyId.Focus();
                //    }
                //}
                if (lueCompany.ItemIndex < 0)
                {
                    lstError.Add(new ListError(13, "Company"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                        lueCompany.Focus();
                    }
                }
                if (lueBranch.ItemIndex < 0)
                {
                    lstError.Add(new ListError(13, "Branch"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                        lueBranch.Focus();
                    }
                }
                if (lueLocation.ItemIndex < 0)
                {
                    lstError.Add(new ListError(13, "Location"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                        lueLocation.Focus();
                    }
                }
                if (lueDepartment.ItemIndex < 0)
                {
                    lstError.Add(new ListError(13, "Department"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                        lueDepartment.Focus();
                    }
                }

            }
            catch (Exception ex)
            {
                lstError.Add(new ListError(ex));
            }
            return (!(BLL.General.ShowErrors(lstError)));

        }
        public void GetData()
        {
            try
            {
                DataTable DTab = objUser.GetData();
                grdEmployeeMaster.InvokeEx(t =>
                {
                    t.DataSource = DTab;
                    dgvUserMaster.BestFitColumns();
                });
            }
            catch (Exception ex)
            {
                General.ShowErrors(ex.ToString());
                return;
            }
        }
        private bool SaveDetails()
        {
            bool blnReturn = true;
            UserMaster objUser = new UserMaster();
            User_MasterProperty UserMasterProperty = new User_MasterProperty();
            try
            {
                if (!ValidateDetails())
                {
                    blnReturn = false;
                    return blnReturn;
                }

                UserMasterProperty.user_id = Val.ToInt32(lblMode.Tag);
                UserMasterProperty.user_name = Val.ToString(txtUserName.Text).ToUpper();
                UserMasterProperty.password = GlobalDec.Encrypt(txtPassword.Text, true);
                UserMasterProperty.theme = Val.ToString(txtTheme.Text).ToUpper();
                UserMasterProperty.sequence_no = Val.ToInt32(txtSequenceNo.Text);
                UserMasterProperty.user_type = Val.ToString(lueUserType.EditValue).ToUpper();
                UserMasterProperty.employee_id = Val.ToInt32(lueEmpId.EditValue);
                UserMasterProperty.role_id = Val.ToInt32(lueRoleId.EditValue);
                UserMasterProperty.party_id = Val.ToInt32(luePartyId.EditValue);
                UserMasterProperty.company_id = Val.ToInt32(lueCompany.EditValue);
                UserMasterProperty.branch_id = Val.ToInt32(lueBranch.EditValue);
                UserMasterProperty.location_id = Val.ToInt32(lueLocation.EditValue);
                UserMasterProperty.department_id = Val.ToInt32(lueDepartment.EditValue);
                UserMasterProperty.active = Val.ToBoolean(chkActive.Checked);

                int IntRes = objUser.Save(UserMasterProperty);
                if (IntRes == -1)
                {
                    Global.Confirm("Error In Save User Details");
                    txtUserName.Focus();
                }
                else
                {
                    if (Val.ToInt(lblMode.Tag) == 0)
                    {
                        Global.Confirm("User Details Data Save Successfully");
                    }
                    else
                    {
                        Global.Confirm("User Details Data Update Successfully");
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
                UserMasterProperty = null;
            }

            return blnReturn;
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
                            dgvUserMaster.ExportToPdf(Filepath);
                            break;
                        case "xls":
                            dgvUserMaster.ExportToXls(Filepath);
                            break;
                        case "xlsx":
                            dgvUserMaster.ExportToXlsx(Filepath);
                            break;
                        case "rtf":
                            dgvUserMaster.ExportToRtf(Filepath);
                            break;
                        case "txt":
                            dgvUserMaster.ExportToText(Filepath);
                            break;
                        case "html":
                            dgvUserMaster.ExportToHtml(Filepath);
                            break;
                        case "csv":
                            dgvUserMaster.ExportToCsv(Filepath);
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

    }
}
