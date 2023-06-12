using BLL;
using BLL.FunctionClasses.Master;
using BLL.PropertyClasses.Master;
using DevExpress.XtraEditors;
using Krishna_Textiles.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Krishna_Textiles.Class.Global;

namespace Krishna_Textiles.Master
{
    public partial class FrmEmployeeMaster : DevExpress.XtraEditors.XtraForm
    {
        #region Data Member

        BLL.FormEvents objBOFormEvents = new BLL.FormEvents();
        BLL.Validation Val = new BLL.Validation();
        BLL.FormPer ObjPer = new BLL.FormPer();
        EmployeeMaster objEmp = new EmployeeMaster();
        private byte[] m_barrImg;
        private long m_lImageFileLength = 0;
        Control _NextEnteredControl;
        private List<Control> _tabControls;
        DataTable DtControlSettings;
        DataTable m_dtbSalaryType = new DataTable();
        DataTable m_dtbWagesType = new DataTable();
        Int64 m_numForm_id;
        List<Task> tList = new List<Task>();

        #endregion

        #region Constructor
        public FrmEmployeeMaster()
        {
            InitializeComponent();
            _NextEnteredControl = new Control();
            _tabControls = new List<Control>();
            DtControlSettings = new DataTable();
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
            if (Global.HideFormControls(Val.ToInt(ObjPer.form_id), this) != "")
            {
                Global.Message("Select First User Setting...Please Contact to Administrator...");
                return;
            }

            ControlSettingDT(Val.ToInt(ObjPer.form_id), this);
            AddGotFocusListener(this);
            this.KeyPreview = true;

            TabControlsToList(this.Controls);
            _tabControls = _tabControls.OrderBy(x => x.TabIndex).ToList();
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
                Task.Run(() => Global.LOOKUPCompany(lueCompany));
                Task.Run(() => Global.LOOKUPBranch(lueBranch));
                Task.Run(() => Global.LOOKUPLocation(lueLocation));
                Task.Run(() => Global.LOOKUPDepartment(lueDepartment));
                Task.Run(() => Global.LOOKUPDesignation(lueDesignation));
                Task.Run(() => GetData());

                // GetData();
                btnClear_Click(btnClear, null);
                txtFName.Focus();

                m_dtbSalaryType.Columns.Add("salary_type");
                m_dtbSalaryType.Rows.Add("Fixed");
                m_dtbSalaryType.Rows.Add("Wages");

                lueSalarytype.Properties.DataSource = m_dtbSalaryType;
                lueSalarytype.Properties.ValueMember = "salary_type";
                lueSalarytype.Properties.DisplayMember = "salary_type";

                m_dtbWagesType.Columns.Add("wages_type");
                m_dtbWagesType.Rows.Add("Per Carat");
                m_dtbWagesType.Rows.Add("Per Pcs");
                m_dtbWagesType.Rows.Add("Per Hrs");

                lueWagesType.Properties.DataSource = m_dtbWagesType;
                lueWagesType.Properties.ValueMember = "wages_type";
                lueWagesType.Properties.DisplayMember = "wages_type";
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
            List<ListError> lstError = new List<ListError>();
            Dictionary<Control, string> rtnCtrls = new Dictionary<Control, string>();
            rtnCtrls = Global.CheckCompulsoryControls(Val.ToInt(ObjPer.form_id), this);
            if (rtnCtrls.Count > 0)
            {
                foreach (KeyValuePair<Control, string> entry in rtnCtrls)
                {
                    if (entry.Key is DevExpress.XtraEditors.LookUpEdit || entry.Key is DevExpress.XtraEditors.DateEdit || entry.Key is DevExpress.XtraEditors.TextEdit)
                    {
                        lstError.Add(new ListError(13, entry.Value));
                    }
                }
                rtnCtrls.First().Key.Focus();
                BLL.General.ShowErrors(lstError);
                Cursor.Current = Cursors.Arrow;
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
                dtpBirthDate.EditValue = null;
                txtCurrentAddress.Text = "";
                txtVillage.Text = "";
                txtTaluka.Text = "";
                txtDistrict.Text = "";
                txtMobileno.Text = "";
                txtPhoneNo.Text = "";
                txtRefMobileNo.Text = "";
                txtRefrenceBy.Text = "";
                txtAadharNo.Text = "";
                txtRemark.Text = "";
                //txtSalary.Text = "0.000";
                txtEnrollmentNo.Text = "0";
                txtTotalHrs.Text = "0";
                txtPagarNo.Text = "0";
                lueWagesType.EditValue = null;
                lueSalarytype.EditValue = null;
                //lueWagesType.Visible = false;
                lueCompany.EditValue = null;
                lueBranch.EditValue = null;
                lueLocation.EditValue = null;
                lueDepartment.EditValue = null;
                lueDesignation.EditValue = null;
                lueManager.EditValue = null;
                lueSubManager.EditValue = null;
                lueBuilding.EditValue = null;
                lueFloor.EditValue = null;
                pictureEmp.Image = null;
                lueShift.EditValue = null;
                chkActive.Checked = true;
                txtFName.Focus();
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
        private void LookupCompany_EditValueChanged(object sender, EventArgs e)
        {
            //lueCompany.EditValue = lueBranch.GetColumnValue("company_id");
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
        private void lueBuilding_EditValueChanged(object sender, EventArgs e)
        {
            if (lueBuilding.Text != "")
            {
                //Global.LOOKUPFloor(lueFloor, Val.ToInt(lueBuilding.EditValue));
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
                        txtFName.Text = Val.ToString(Drow["first_name"]);
                        txtMName.Text = Val.ToString(Drow["middle_name"]);
                        txtSurname.Text = Val.ToString(Drow["last_name"]);
                        txtShortName.Text = Val.ToString(Drow["short_name"]);
                        dtpBirthDate.Text = Val.ToString(Drow["birth_date"]);
                        txtCurrentAddress.Text = Val.ToString(Drow["current_address"]);
                        txtVillage.Text = Val.ToString(Drow["village"]);
                        txtTaluka.Text = Val.ToString(Drow["taluka"]);
                        txtDistrict.Text = Val.ToString(Drow["district"]);
                        txtMobileno.Text = Val.ToString(Drow["mobile_no"]);
                        txtPhoneNo.Text = Val.ToString(Drow["phone_no"]);
                        txtRefrenceBy.Text = Val.ToString(Drow["refrence_by_name"]);
                        txtRefMobileNo.Text = Val.ToString(Drow["refrence_by_no"]);
                        txtAadharNo.Text = Val.ToString(Drow["addhar_no"]);
                        lueCompany.EditValue = Val.ToInt(Drow["company_id"]);
                        lueBranch.EditValue = Val.ToInt32(Drow["branch_id"]);
                        lueDepartment.EditValue = Val.ToInt32(Drow["department_id"]);
                        lueShift.EditValue = Val.ToInt32(Drow["shift_id"]);
                        lueDesignation.EditValue = Val.ToInt32(Drow["designation_id"]);
                        lueManager.EditValue = Val.ToInt32(Drow["manager_id"]);
                        lueSubManager.EditValue = Val.ToInt32(Drow["sub_manager_id"]);
                        txtPagarNo.Text = Val.ToString(Drow["pagar_no"]);
                        lueBuilding.EditValue = Val.ToInt32(Drow["building_id"]);
                        lueFloor.EditValue = Val.ToInt32(Drow["floor_id"]);
                        lueLocation.EditValue = Val.ToInt32(Drow["location_id"]);
                        txtRemark.Text = Val.ToString(Drow["remarks"]);
                        txtSalesPrem.Text = Val.ToString(Drow["sale_premium"]);
                        txtSalesDisc.Text = Val.ToString(Drow["sale_discount"]);
                        txtEmailID.Text = Val.ToString(Drow["email"]);
                        txtEnrollmentNo.Text = Val.ToString(Drow["enrollment_no"]);
                        //txtSalary.Text = Val.ToString(Drow["salary"]);
                        txtTotalHrs.Text = Val.ToString(Drow["total_hrs"]);
                        lueSalarytype.EditValue = Val.ToString(Drow["salary_type"]);
                        lueWagesType.EditValue = Val.ToString(Drow["wages_type"]);
                        txtEmailPass.Text = Val.ToString(Drow["email_password"]);
                        chkActive.Checked = Val.ToBoolean(Drow["active"]);
                        if (Val.ToString(Drow["emp_image"]) != "")
                        {
                            m_barrImg = (byte[])Drow["emp_image"];
                            string strfn = Convert.ToString(DateTime.Now.ToFileTime());
                            FileStream fs = new FileStream(strfn, FileMode.CreateNew, FileAccess.Write);
                            fs.Write(m_barrImg, 0, m_barrImg.Length);
                            fs.Flush();
                            fs.Close();

                            pictureEmp.Image = Image.FromFile(strfn);
                        }
                        else
                        {
                            pictureEmp.Image = null;
                        }


                        //imgEmp.Image = new Bitmap(image.FileName);
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
                EmpMasterProperty.first_name = Val.ToString(txtFName.Text).ToUpper();
                EmpMasterProperty.middle_name = Val.ToString(txtMName.Text).ToUpper();
                EmpMasterProperty.last_name = Val.ToString(txtSurname.Text).ToUpper();
                EmpMasterProperty.short_name = Val.ToString(txtShortName.Text).ToUpper();
                EmpMasterProperty.birth_date = Val.ToString(dtpBirthDate.Text);
                EmpMasterProperty.current_address = Val.ToString(txtCurrentAddress.Text);
                EmpMasterProperty.village = Val.ToString(txtVillage.Text);
                EmpMasterProperty.taluka = Val.ToString(txtTaluka.Text);
                EmpMasterProperty.district = Val.ToString(txtDistrict.Text);
                EmpMasterProperty.mobile_no = Val.ToString(txtMobileno.Text);
                EmpMasterProperty.phone_no = Val.ToString(txtPhoneNo.Text);
                EmpMasterProperty.refrence_by_name = Val.ToString(txtRefrenceBy.Text);
                EmpMasterProperty.refrence_by_no = Val.ToString(txtRefMobileNo.Text);
                EmpMasterProperty.addhar_no = Val.ToString(txtAadharNo.Text);
                EmpMasterProperty.location_id = Val.ToInt32(lueLocation.EditValue);
                EmpMasterProperty.company_id = Val.ToInt32(lueCompany.EditValue);
                EmpMasterProperty.branch_id = Val.ToInt32(lueBranch.EditValue);
                EmpMasterProperty.department_id = Val.ToInt32(lueDepartment.EditValue);
                EmpMasterProperty.shift_id = Val.ToInt32(lueShift.EditValue);
                EmpMasterProperty.designation_id = Val.ToInt32(lueDesignation.EditValue);
                EmpMasterProperty.manager_id = Val.ToInt32(lueManager.EditValue);
                EmpMasterProperty.sub_manager_id = Val.ToInt32(lueSubManager.EditValue);
                EmpMasterProperty.pagar_no = Val.ToString(txtPagarNo.Text);
                EmpMasterProperty.building_id = Val.ToInt32(lueBuilding.EditValue);
                EmpMasterProperty.floor_id = Val.ToInt32(lueFloor.EditValue);
                EmpMasterProperty.email = Val.ToString(txtEmailID.Text).ToUpper();
                EmpMasterProperty.email_password = Val.ToString(txtEmailPass.Text).ToUpper();
                EmpMasterProperty.sale_premium = Val.ToInt32(txtSalesPrem.Text);
                EmpMasterProperty.sale_discount = Val.ToInt32(txtSalesDisc.Text);
                EmpMasterProperty.enrollment_no = Val.ToInt32(txtEnrollmentNo.Text);
                EmpMasterProperty.total_hrs = Val.ToDecimal(txtTotalHrs.Text);
                EmpMasterProperty.salary = Val.ToDecimal(0);
                EmpMasterProperty.remarks = Val.ToString(txtRemark.Text).ToUpper();
                EmpMasterProperty.active = Val.ToBoolean(chkActive.Checked);
                EmpMasterProperty.emp_image = (m_barrImg);
                EmpMasterProperty.Wages_Type = Val.ToString(lueWagesType.Text);
                EmpMasterProperty.Salary_Type = Val.ToString(lueSalarytype.Text);

                int IntRes = objEmp.Save(EmpMasterProperty);
                //saveDirectory = @"D:\SavedImages\";
                //if (Convert.ToString(srcpathEmp) != string.Empty)
                //{
                //    if (!Directory.Exists(saveDirectory))
                //    {
                //        Directory.CreateDirectory(saveDirectory);
                //    }
                //    string fileSavePath = Path.Combine(saveDirectory, fileName);
                //    File.Copy(srcpathEmp, fileSavePath, true);
                //}

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
                //if (txtFName.Text == string.Empty)
                //{
                //    lstError.Add(new ListError(12, "First Name"));
                //    if (!blnFocus)
                //    {
                //        blnFocus = true;
                //        txtFName.Focus();
                //    }
                //}
                //if (txtMName.Text == string.Empty)
                //{
                //    lstError.Add(new ListError(12, "Middle Name"));
                //    if (!blnFocus)
                //    {
                //        blnFocus = true;
                //        txtMName.Focus();
                //    }
                //}
                //if (txtSurname.Text == string.Empty)
                //{
                //    lstError.Add(new ListError(12, "Surname"));
                //    if (!blnFocus)
                //    {
                //        blnFocus = true;
                //        txtSurname.Focus();
                //    }
                //}
                //if (txtShortName.Text == string.Empty)
                //{
                //    lstError.Add(new ListError(12, "Short Name"));
                //    if (!blnFocus)
                //    {
                //        blnFocus = true;
                //        txtShortName.Focus();
                //    }
                //}

                if (!objEmp.ISExists(txtShortName.Text, Val.ToInt64(lblMode.Tag)).ToString().Trim().Equals(string.Empty))
                {
                    lstError.Add(new ListError(23, "Short Name"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                        txtShortName.Focus();
                    }

                }
                //if (!objEmp.ISEnoExists(Val.ToInt64(txtEnrollmentNo.Text)).ToString().Trim().Equals(string.Empty))
                //{
                //    lstError.Add(new ListError(23, "Enrollment No."));
                //    if (!blnFocus)
                //    {
                //        blnFocus = true;
                //        txtEnrollmentNo.Focus();
                //    }

                //}
                //if (dtpBirthDate.Text == string.Empty)
                //{
                //    lstError.Add(new ListError(12, "Birth Date"));
                //    if (!blnFocus)
                //    {
                //        blnFocus = true;
                //        dtpBirthDate.Focus();
                //    }
                //}
                //if (txtCurrentAddress.Text == string.Empty)
                //{
                //    lstError.Add(new ListError(12, "Current Address"));
                //    if (!blnFocus)
                //    {
                //        blnFocus = true;
                //        txtCurrentAddress.Focus();
                //    }
                //}
                //if (txtVillage.Text == string.Empty)
                //{
                //    lstError.Add(new ListError(12, "Village"));
                //    if (!blnFocus)
                //    {
                //        blnFocus = true;
                //        txtVillage.Focus();
                //    }
                //}
                //if (txtTaluka.Text == string.Empty)
                //{
                //    lstError.Add(new ListError(12, "Taluka"));
                //    if (!blnFocus)
                //    {
                //        blnFocus = true;
                //        txtTaluka.Focus();
                //    }
                //}
                //if (txtDistrict.Text == string.Empty)
                //{
                //    lstError.Add(new ListError(12, "District"));
                //    if (!blnFocus)
                //    {
                //        blnFocus = true;
                //        txtDistrict.Focus();
                //    }
                //}
                //if (txtPhoneNo.Text == string.Empty)
                //{
                //    lstError.Add(new ListError(12, "Phone No"));
                //    if (!blnFocus)
                //    {
                //        blnFocus = true;
                //        txtPhoneNo.Focus();
                //    }
                //}
                //if (txtMobileno.Text == string.Empty)
                //{
                //    lstError.Add(new ListError(12, "Mobile No"));
                //    if (!blnFocus)
                //    {
                //        blnFocus = true;
                //        txtMobileno.Focus();
                //    }
                //}
                //if (txtRefrenceBy.Text == string.Empty)
                //{
                //    lstError.Add(new ListError(12, "Reference By"));
                //    if (!blnFocus)
                //    {
                //        blnFocus = true;
                //        txtRefrenceBy.Focus();
                //    }
                //}
                //if (txtRefMobileNo.Text == string.Empty)
                //{
                //    lstError.Add(new ListError(12, "Reference Mobile no"));
                //    if (!blnFocus)
                //    {
                //        blnFocus = true;
                //        txtRefMobileNo.Focus();
                //    }
                //}
                //if (txtAadharNo.Text.Length != 12)
                //{
                //    lstError.Add(new ListError(5, "Invalid Aadhar No."));
                //    if (!blnFocus)
                //    {
                //        blnFocus = true;
                //        txtAadharNo.Focus();
                //    }
                //}

                //if (lueCompany.ItemIndex < 0)
                //{
                //    lstError.Add(new ListError(13, "Company"));
                //    if (!blnFocus)
                //    {
                //        blnFocus = true;
                //        lueCompany.Focus();
                //    }
                //}
                //if (lueBranch.ItemIndex < 0)
                //{
                //    lstError.Add(new ListError(13, "Branch"));
                //    if (!blnFocus)
                //    {
                //        blnFocus = true;
                //        lueBranch.Focus();
                //    }
                //}
                //if (lueDepartment.ItemIndex < 0)
                //{
                //    lstError.Add(new ListError(13, "Department"));
                //    if (!blnFocus)
                //    {
                //        blnFocus = true;
                //        lueDepartment.Focus();
                //    }
                //}
                //if (lueDesignation.ItemIndex < 0)
                //{
                //    lstError.Add(new ListError(13, "Designation"));
                //    if (!blnFocus)
                //    {
                //        blnFocus = true;
                //        lueDesignation.Focus();
                //    }
                //}
                //if (lueLocation.ItemIndex < 0)
                //{
                //    lstError.Add(new ListError(13, "Location"));
                //    if (!blnFocus)
                //    {
                //        blnFocus = true;
                //        lueLocation.Focus();
                //    }
                //}

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
                grdEmployeeMaster.InvokeEx(t =>
                {
                    t.DataSource = DTab;
                    dgvEmployeeMaster.BestFitColumns();
                });
                //grdEmployeeMaster.DataSource = DTab;
                //dgvEmployeeMaster.BestFitColumns();
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
        protected void LoadImage()
        {

            try
            {
                //this.openFileDialog1.ShowDialog(this);
                // OpenFileDialog openFileDialog1 = new OpenFileDialog();
                // openFileDialog1.ShowDialog(this);
                OpenFileDialog OpenDialog = new OpenFileDialog();
                if (OpenDialog.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                {
                    return;
                }
                //txtFileName.Text = OpenDialog.FileName;

                string strFn = OpenDialog.FileName; //"D:\\DAshvin_l.png"; 
                OpenDialog.Dispose();
                OpenDialog = null;
                this.pictureEmp.Image = Image.FromFile(strFn);
                FileInfo fiImage = new FileInfo(strFn);
                this.m_lImageFileLength = fiImage.Length;
                FileStream fs = new FileStream(strFn, FileMode.Open, FileAccess.Read, FileShare.Read);
                m_barrImg = new byte[Convert.ToInt32(this.m_lImageFileLength)];
                int iBytesRead = fs.Read(m_barrImg, 0, Convert.ToInt32(this.m_lImageFileLength));
                fs.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

        private void tblGeneralDetail_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnImageUpload_Click(object sender, EventArgs e)
        {
            LoadImage();
            //OpenFileDialog OpenDialog = new OpenFileDialog();
            //// image filters  
            //OpenDialog.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            //if (OpenDialog.ShowDialog() == DialogResult.OK)
            //{
            //    // display image in picture box  
            //    fileName = Path.GetFileName(OpenDialog.FileName);
            //    imgEmp.Image = new Bitmap(OpenDialog.FileName);
            //    lblEmpPath.Text = OpenDialog.FileName;
            //    OpenDialog.Dispose();
            //    OpenDialog = null;
            //    if (File.Exists(lblEmpPath.Text) == false)
            //    {
            //        Global.Message("File Is Not Exists To The Path");
            //        return;
            //    }
            //}
        }

        private void lueSalarytype_EditValueChanged(object sender, EventArgs e)
        {
            //if (lueSalarytype.Text != "")
            //{
            //    if (lueSalarytype.Text != "Wages")
            //    {
            //        lueWagesType.Visible = false;
            //    }
            //    else
            //    {
            //        lueWagesType.Visible = true;
            //    }
            //}
            //else
            //{
            //    lueWagesType.Visible = false;
            //}
        }


    }
}
