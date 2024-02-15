using Account_Management.Class;
using BLL;
using BLL.FunctionClasses.Master;
using BLL.PropertyClasses.Master;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using static Account_Management.Class.Global;

namespace Account_Management.Master
{
    public partial class FrmEmployeeMaster : DevExpress.XtraEditors.XtraForm
    {
        #region Data Member

        BLL.FormEvents objBOFormEvents = new BLL.FormEvents();
        BLL.Validation Val = new BLL.Validation();
        BLL.FormPer ObjPer = new BLL.FormPer();
        EmployeeMaster objEmp = new EmployeeMaster();

        #endregion

        #region Constructor
        public FrmEmployeeMaster()
        {
            InitializeComponent();
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
            objBOFormEvents.ObjToDispose.Add(objEmp);
            objBOFormEvents.ObjToDispose.Add(Val);
            objBOFormEvents.ObjToDispose.Add(objBOFormEvents);
        }

        #endregion

        #region Events
        private void FrmEmployeeMaster_Load(object sender, EventArgs e)
        {
            try
            {
                GetData();
                btnClear_Click(btnClear, null);
                txtEmployeeCode.Focus();
                Global.LOOKUPCompany(lueCompany);
                Global.LOOKUPBranch(lueBranch);
                Global.LOOKUPLocation(lueLocation);
                Global.LOOKUPDepartment(lueDepartment);
                Global.LOOKUPDesignation(lueDesignation);

                lueCompany.EditValue = Val.ToInt(GlobalDec.gEmployeeProperty.company_id);
                lueBranch.EditValue = Val.ToInt(GlobalDec.gEmployeeProperty.branch_id);
                lueLocation.EditValue = Val.ToInt(GlobalDec.gEmployeeProperty.location_id);
                lueDepartment.EditValue = Val.ToInt(GlobalDec.gEmployeeProperty.department_id);
            }
            catch (Exception ex)
            {
                General.ShowErrors(ex.ToString());
                return;
            }

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            ObjPer.FormName = this.Name.ToUpper();
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
                txtFName.Text = "";
                txtMName.Text = "";
                txtSurname.Text = "";
                txtShortName.Text = "";
                txtEmailID.Text = "";
                txtEmailPass.Text = "";
                txtSalesPrem.Text = "";
                txtSalesDisc.Text = "";
                txtRemark.Text = "";
                txtEmployeeCode.Text = "";
                lueCompany.EditValue = null;
                lueBranch.EditValue = null;
                lueLocation.EditValue = null;
                lueDepartment.EditValue = null;
                lueDesignation.EditValue = null;
                lueSubProcess.EditValue = null;
                txtAddress.Text = "";
                txtRefBy.Text = "";
                txtRefMob.Text = "";
                txtMobile.Text = "";
                txtAadharNo.Text = "";
                txtSalary.Text = "";
                dtpJoiningDate.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
                dtpJoiningDate.Properties.Mask.EditMask = "dd/MMM/yyyy";
                dtpJoiningDate.Properties.Mask.UseMaskAsDisplayFormat = true;
                dtpJoiningDate.Properties.CharacterCasing = CharacterCasing.Upper;
                dtpJoiningDate.EditValue = DateTime.Now;

                dtpLeaveDate.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
                dtpLeaveDate.Properties.Mask.EditMask = "dd/MMM/yyyy";
                dtpLeaveDate.Properties.Mask.UseMaskAsDisplayFormat = true;
                dtpLeaveDate.Properties.CharacterCasing = CharacterCasing.Upper;

                dtpDOB.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
                dtpDOB.Properties.Mask.EditMask = "dd/MMM/yyyy";
                dtpDOB.Properties.Mask.UseMaskAsDisplayFormat = true;
                dtpDOB.Properties.CharacterCasing = CharacterCasing.Upper;

                txtAge.Text = string.Empty;

                dtpLeaveDate.EditValue = null;
                dtpDOB.EditValue = null;
                chkActive.Checked = true;
                txtEmployeeCode.Focus();
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
        private void LookupBranch_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                lueLocation.EditValue = lueBranch.GetColumnValue("location_id");
            }
            catch (Exception ex)
            {
                General.ShowErrors(ex.ToString());
                return;
            }

        }
        private void dtpDOB_EditValueChanged(object sender, EventArgs e)
        {
            if (dtpDOB.Text.ToString() != "")
            {
                DateTime dob = Convert.ToDateTime(dtpDOB.Text.ToString());
                TimeSpan tm = (DateTime.Now - dob);
                int age = (tm.Days / 365);
                txtAge.Text = age.ToString();

                //if (age < 18)
                //{
                //    Global.Message("Emplyee must not less then 18 year");
                //    dtpDOB.Focus();
                //    return;
                //}
            }
            else
            {
                txtAge.Text = string.Empty;
            }
        }

        #region GridEvents
        private void dgvEmployeeMaster_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                if (e.RowHandle >= 0)
                {
                    if (e.Clicks == 2)
                    {
                        DataRow Drow = dgvEmployeeMaster.GetDataRow(e.RowHandle);
                        lblMode.Text = "Edit Mode";
                        lblMode.Tag = Val.ToInt64(Drow["employee_id"]);
                        txtEmployeeCode.Text = Val.ToString(Drow["employee_code"]);
                        txtFName.Text = Val.ToString(Drow["first_name"]);
                        txtMName.Text = Val.ToString(Drow["middle_name"]);
                        txtSurname.Text = Val.ToString(Drow["last_name"]);
                        txtShortName.Text = Val.ToString(Drow["short_name"]);
                        lueCompany.EditValue = Val.ToInt(Drow["company_id"]);
                        lueBranch.EditValue = Val.ToInt32(Drow["branch_id"]);
                        lueDepartment.EditValue = Val.ToInt32(Drow["department_id"]);
                        lueDesignation.EditValue = Val.ToInt32(Drow["designation_id"]);
                        lueSubProcess.EditValue = Val.ToInt32(Drow["sub_process_id"]);
                        lueLocation.EditValue = Val.ToInt32(Drow["location_id"]);
                        txtRemark.Text = Val.ToString(Drow["remarks"]);
                        txtSalesPrem.Text = Val.ToString(Drow["sale_premium"]);
                        txtSalesDisc.Text = Val.ToString(Drow["sale_discount"]);
                        txtEmailID.Text = Val.ToString(Drow["email"]);
                        txtEmailPass.Text = Val.ToString(Drow["email_password"]);
                        txtAddress.Text = Val.ToString(Drow["emp_address"]);
                        dtpJoiningDate.EditValue = Val.DBDate(Drow["joining_date"].ToString());
                        txtRefBy.Text = Val.ToString(Drow["reference_by"]);
                        txtRefMob.Text = Val.ToString(Drow["reference_mobile"]);
                        txtMobile.Text = Val.ToString(Drow["employee_mobile"]);
                        chkActive.Checked = Val.ToBoolean(Drow["active"]);
                        txtAadharNo.Text = Val.ToString(Drow["aadhar_no"]);
                        dtpLeaveDate.EditValue = Val.DBDate(Drow["leave_date"].ToString());
                        dtpDOB.EditValue = Val.DBDate(Drow["dob"].ToString());
                        txtAge.EditValue = Val.ToInt(Drow["age"]);
                        txtSalary.EditValue = Val.ToInt(Drow["salary"]);
                        txtShortName.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                BLL.General.ShowErrors(ex);
                return;
            }
        }
        private void dgvEmployeeMaster_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                string StrCategory = Val.ToString(dgvEmployeeMaster.GetRowCellDisplayText(e.RowHandle, dgvEmployeeMaster.Columns["active"]));

                if (StrCategory == "Unchecked")
                {
                    e.Appearance.BackColor = BLL.GlobalDec.ABColor;
                    e.Appearance.BackColor2 = BLL.GlobalDec.ABColor2;
                    //e.Appearance.BackColor2 = Color.White;
                }
                else if (StrCategory == "Checked")
                {
                    e.Appearance.BackColor = Color.Transparent;
                    e.Appearance.BackColor2 = Color.Transparent;
                }
            }
        }
        #endregion

        #endregion

        #region Functions
        private bool SaveDetails()
        {
            bool blnReturn = true;
            Employee_MasterProperty EmpMasterProperty = new Employee_MasterProperty();
            EmployeeMaster objEmp = new EmployeeMaster();

            try
            {
                if (!ValidateDetails())
                {
                    blnReturn = false;
                    return blnReturn;
                }

                EmpMasterProperty.employee_id = Val.ToInt32(lblMode.Tag);
                EmpMasterProperty.employee_code = Val.ToString(txtEmployeeCode.Text).ToUpper();
                EmpMasterProperty.first_name = Val.ToString(txtFName.Text).ToUpper();
                EmpMasterProperty.middle_name = Val.ToString(txtMName.Text).ToUpper();
                EmpMasterProperty.last_name = Val.ToString(txtSurname.Text).ToUpper();
                EmpMasterProperty.short_name = Val.ToString(txtShortName.Text).ToUpper();
                EmpMasterProperty.location_id = Val.ToInt32(lueLocation.EditValue);
                EmpMasterProperty.company_id = Val.ToInt32(lueCompany.EditValue);
                EmpMasterProperty.branch_id = Val.ToInt32(lueBranch.EditValue);
                EmpMasterProperty.department_id = Val.ToInt32(lueDepartment.EditValue);
                EmpMasterProperty.designation_id = Val.ToInt32(lueDesignation.EditValue);
                EmpMasterProperty.sub_process_id = Val.ToInt32(lueSubProcess.EditValue);
                EmpMasterProperty.email = Val.ToString(txtEmailID.Text).ToUpper();
                EmpMasterProperty.email_password = Val.ToString(txtEmailPass.Text).ToUpper();
                EmpMasterProperty.aadhar_no = Val.ToString(txtAadharNo.Text).ToUpper();
                EmpMasterProperty.sale_premium = Val.ToInt32(txtSalesPrem.Text);
                EmpMasterProperty.sale_discount = Val.ToInt32(txtSalesDisc.Text);
                EmpMasterProperty.remarks = Val.ToString(txtRemark.Text).ToUpper();
                EmpMasterProperty.emp_address = Val.ToString(txtAddress.Text);
                EmpMasterProperty.joining_date = Val.DBDate(dtpJoiningDate.Text);
                EmpMasterProperty.reference_by = Val.ToString(txtRefBy.Text);
                EmpMasterProperty.reference_mobile = Val.ToString(txtRefMob.Text);
                EmpMasterProperty.employee_mobile = Val.ToString(txtMobile.Text);
                EmpMasterProperty.active = Val.ToBoolean(chkActive.Checked);
                EmpMasterProperty.leave_date = Val.DBDate(dtpLeaveDate.Text);
                EmpMasterProperty.dob = Val.DBDate(dtpDOB.Text);
                EmpMasterProperty.age = Val.ToInt(txtAge.Text);
                EmpMasterProperty.salary = Val.ToInt64(txtSalary.Text);

                int IntRes = objEmp.Save(EmpMasterProperty);
                if (IntRes == -1)
                {
                    Global.Confirm("Error In Save Employee Details");
                    txtFName.Focus();
                }
                else
                {
                    if (Val.ToInt(lblMode.Tag) == 0)
                    {
                        Global.Confirm("Employee Details Data Save Successfully");
                    }
                    else
                    {
                        Global.Confirm("Employee Details Data Update Successfully");
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
                EmpMasterProperty = null;
            }

            return blnReturn;
        }
        private bool ValidateDetails()
        {
            bool blnFocus = false;
            List<ListError> lstError = new List<ListError>();
            try
            {
                if (txtEmployeeCode.Text == string.Empty)
                {
                    lstError.Add(new ListError(12, "Employee Code"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                        txtEmployeeCode.Focus();
                    }
                }
                if (txtFName.Text == string.Empty)
                {
                    lstError.Add(new ListError(12, "First Name"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                        txtFName.Focus();
                    }
                }
                if (txtMName.Text == string.Empty)
                {
                    lstError.Add(new ListError(12, "Middle Name"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                        txtMName.Focus();
                    }
                }
                if (txtSurname.Text == string.Empty)
                {
                    lstError.Add(new ListError(12, "Surname"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                        txtSurname.Focus();
                    }
                }
                if (txtShortName.Text == string.Empty)
                {
                    lstError.Add(new ListError(12, "Short Name"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                        txtShortName.Focus();
                    }
                }

                //if (!objEmp.ISExists(txtShortName.Text, Val.ToInt64(lblMode.Tag)).ToString().Trim().Equals(string.Empty))
                //{
                //    lstError.Add(new ListError(23, "Short Name"));
                //    if (!blnFocus)
                //    {
                //        blnFocus = true;
                //        txtShortName.Focus();
                //    }

                //}
                if (!objEmp.ISExistsCode(txtEmployeeCode.Text, Val.ToInt64(lblMode.Tag)).ToString().Trim().Equals(string.Empty))
                {
                    lstError.Add(new ListError(23, "Employee Code"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                        txtEmployeeCode.Focus();
                    }

                }
                if (lueCompany.Text == "")
                {
                    lstError.Add(new ListError(13, "Company"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                        lueCompany.Focus();
                    }
                }
                if (lueBranch.Text == "")
                {
                    lstError.Add(new ListError(13, "Branch"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                        lueBranch.Focus();
                    }
                }
                if (lueDepartment.Text == "")
                {
                    lstError.Add(new ListError(13, "Department"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                        lueDepartment.Focus();
                    }
                }
                if (lueDesignation.Text == "")
                {
                    lstError.Add(new ListError(13, "Designation"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                        lueDesignation.Focus();
                    }
                }
                if (lueLocation.Text == "")
                {
                    lstError.Add(new ListError(13, "Location"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                        lueLocation.Focus();
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
            List<ListError> lstError = new List<ListError>();
            try
            {
                DataTable DTab = objEmp.GetData(1, null);
                grdEmployeeMaster.DataSource = DTab;
                dgvEmployeeMaster.BestFitColumns();
            }
            catch (Exception ex)
            {
                General.ShowErrors(ex.ToString());
                return;
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
                            dgvEmployeeMaster.ExportToPdf(Filepath);
                            break;
                        case "xls":
                            dgvEmployeeMaster.ExportToXls(Filepath);
                            break;
                        case "xlsx":
                            dgvEmployeeMaster.ExportToXlsx(Filepath);
                            break;
                        case "rtf":
                            dgvEmployeeMaster.ExportToRtf(Filepath);
                            break;
                        case "txt":
                            dgvEmployeeMaster.ExportToText(Filepath);
                            break;
                        case "html":
                            dgvEmployeeMaster.ExportToHtml(Filepath);
                            break;
                        case "csv":
                            dgvEmployeeMaster.ExportToCsv(Filepath);
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
            Export("xlsx", "Export to Excel", "Excel files 97-2003 (Excel files 2007(*.xlsx)|*.xlsx|All files (*.*)|*.*");
        }
        private void MNExportPDF_Click(object sender, EventArgs e)
        {
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

        private void txtSalary_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtMobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
