using BLL;
using BLL.FunctionClasses.Master;
using BLL.PropertyClasses.Master;
using Account_Management.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Account_Management.Class.Global;

namespace Account_Management.Master
{
    public partial class FrmDepartmentMaster : DevExpress.XtraEditors.XtraForm
    {
        #region Data Member

        FormEvents objBOFormEvents;
        Validation Val;
        BLL.FormPer ObjPer;

        DepartmentMaster objDepartment;
        List<Task> tList = new List<Task>();

        DataTable m_department_type;

        #endregion

        #region Constructor
        public FrmDepartmentMaster()
        {
            InitializeComponent();

            objBOFormEvents = new FormEvents();
            Val = new Validation();
            ObjPer = new BLL.FormPer();

            objDepartment = new DepartmentMaster();

            m_department_type = new DataTable();
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
            objBOFormEvents.ObjToDispose.Add(objDepartment);
            objBOFormEvents.ObjToDispose.Add(Val);
            objBOFormEvents.ObjToDispose.Add(objBOFormEvents);
        }

        #endregion

        #region Events
        private void FrmDepartmentMaster_Load(object sender, System.EventArgs e)
        {
            try
            {
                Task.Run(() => GetData());
                Task.Run(() => Global.LOOKUPEmployee(lueEmployee));
                Task.Run(() => Global.LOOKUPDeptType(lueDepartmentType));
                btnClear_Click(btnClear, null);
            }
            catch (Exception ex)
            {
                BLL.General.ShowErrors(ex);
                return;
            }
        }
        private void btnSave_Click(object sender, System.EventArgs e)
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
        private void btnClear_Click(object sender, System.EventArgs e)
        {
            try
            {
                lblMode.Tag = 0;
                lblMode.Text = "Add Mode";
                txtDeptName.Text = "";
                txtDepartmentShortName.Text = "";
                lueEmployee.EditValue = null;
                lueDepartmentType.EditValue = null;
                txtRemark.Text = "";
                txtSequenceNo.Text = "";
                chkActive.Checked = false;
                txtDepartmentShortName.Focus();
            }
            catch (Exception ex)
            {
                BLL.General.ShowErrors(ex);
                return;
            }
        }
        private void btnExit_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        #region GridEvents               
        private void dgvDepartmentMaster_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            try
            {
                if (e.RowHandle >= 0)
                {
                    if (e.Clicks == 2)
                    {
                        DataRow Drow = dgvDepartmentMaster.GetDataRow(e.RowHandle);
                        lblMode.Text = "Edit Mode";
                        lblMode.Tag = Val.ToInt32(Drow["department_id"]);
                        txtDeptName.Text = Val.ToString(Drow["department_name"]);
                        txtDepartmentShortName.Text = Val.ToString(Drow["department_shortname"]);
                        lueEmployee.EditValue = Val.ToInt32(Drow["employee_id"]);
                        lueDepartmentType.EditValue = Val.ToInt32(Drow["department_type_id"]);
                        txtRemark.Text = Val.ToString(Drow["remarks"]);
                        txtSequenceNo.Text = Val.ToString(Drow["sequence_no"]);
                        chkActive.Checked = Val.ToBoolean(Drow["active"]);
                        txtDeptName.Focus();
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
        private bool SaveDetails()
        {
            bool blnReturn = true;
            Department_MasterProperty DepartmentMasterProperty = new Department_MasterProperty();
            DepartmentMaster objDepartment = new DepartmentMaster();

            try
            {
                if (!ValidateDetails())
                {
                    blnReturn = false;
                    return blnReturn;
                }

                DepartmentMasterProperty.Department_Id = Val.ToInt32(lblMode.Tag);
                DepartmentMasterProperty.Department_Name = txtDeptName.Text.ToUpper();
                DepartmentMasterProperty.Department_ShortName = txtDepartmentShortName.Text.ToUpper();
                DepartmentMasterProperty.Employee_Id = Val.ToInt(lueEmployee.EditValue);
                DepartmentMasterProperty.department_type_id = Val.ToInt(lueDepartmentType.EditValue);
                DepartmentMasterProperty.Active = Val.ToBooleanToInt(chkActive.Checked);
                DepartmentMasterProperty.Remark = txtRemark.Text.ToUpper();
                DepartmentMasterProperty.Sequence_No = Val.ToInt(txtSequenceNo.Text);

                int IntRes = objDepartment.Save(DepartmentMasterProperty);
                if (IntRes == -1)
                {
                    Global.Confirm("Error In Save Department Data");
                    txtDeptName.Focus();
                }
                else
                {
                    if (Val.ToInt(lblMode.Tag) == 0)
                    {
                        Global.Confirm("Department Data Save Successfully");
                    }
                    else
                    {
                        Global.Confirm("Department Data Update Successfully");
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
                DepartmentMasterProperty = null;
            }

            return blnReturn;
        }
        private bool ValidateDetails()
        {
            bool blnFocus = false;
            List<ListError> lstError = new List<ListError>();
            try
            {
                if (txtDeptName.Text == string.Empty)
                {
                    lstError.Add(new ListError(12, "Department Name"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                        txtDeptName.Focus();
                    }
                }

                if (txtDepartmentShortName.Text == string.Empty)
                {
                    lstError.Add(new ListError(12, "Short Name"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                        txtDepartmentShortName.Focus();
                    }
                }

                if (!objDepartment.ISExists(txtDepartmentShortName.Text, Val.ToInt64(lblMode.Tag)).ToString().Trim().Equals(string.Empty))
                {
                    lstError.Add(new ListError(23, "Short Name"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                        txtDepartmentShortName.Focus();
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
                DataTable DTab = objDepartment.GetData();
                grdDepartmentMaster.InvokeEx(t =>
                {
                    t.DataSource = DTab;
                    dgvDepartmentMaster.BestFitColumns();
                });
            }
            catch (Exception ex)
            {
                BLL.General.ShowErrors(ex);
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
                            dgvDepartmentMaster.ExportToPdf(Filepath);
                            break;
                        case "xls":
                            dgvDepartmentMaster.ExportToXls(Filepath);
                            break;
                        case "xlsx":
                            dgvDepartmentMaster.ExportToXlsx(Filepath);
                            break;
                        case "rtf":
                            dgvDepartmentMaster.ExportToRtf(Filepath);
                            break;
                        case "txt":
                            dgvDepartmentMaster.ExportToText(Filepath);
                            break;
                        case "html":
                            dgvDepartmentMaster.ExportToHtml(Filepath);
                            break;
                        case "csv":
                            dgvDepartmentMaster.ExportToCsv(Filepath);
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
