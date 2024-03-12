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
    public partial class FrmBranchMaster : DevExpress.XtraEditors.XtraForm
    {
        #region Data Member

        FormEvents objBOFormEvents;
        Validation Val;
        BLL.FormPer ObjPer;

        BranchMaster objBranch;
        List<Task> tList = new List<Task>();
        #endregion

        #region Constructor
        public FrmBranchMaster()
        {
            InitializeComponent();

            objBOFormEvents = new FormEvents();
            Val = new Validation();
            ObjPer = new BLL.FormPer();

            objBranch = new BranchMaster();
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
            objBOFormEvents.ObjToDispose.Add(objBranch);
            objBOFormEvents.ObjToDispose.Add(Val);
            objBOFormEvents.ObjToDispose.Add(objBOFormEvents);
        }

        #endregion

        #region Events
        private void FrmCompanyMaster_Load(object sender, EventArgs e)
        {
            try
            {
                Task.Run(() => Global.LOOKUPCountry(lueCountry));
                Task.Run(() => Global.LOOKUPState(lueState));
                Task.Run(() => Global.LOOKUPCity(lueCity));
                Task.Run(() => Global.LOOKUPCompany(lueCompany));
                Task.Run(() => Global.LOOKUPLocation(lueLocation));
                Task.Run(() => GetData());

                dtpESICCovDate.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
                dtpESICCovDate.Properties.Mask.EditMask = "dd/MMM/yyyy";
                dtpESICCovDate.Properties.Mask.UseMaskAsDisplayFormat = true;
                dtpESICCovDate.Properties.CharacterCasing = CharacterCasing.Upper;
                btnClear_Click(btnClear, null);
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
                txtBranchName.Text = "";
                txtShortName.Text = "";
                lueCompany.EditValue = null;
                lueLocation.EditValue = null;
                lueCity.EditValue = null;
                lueCountry.EditValue = null;
                txtZipCode.Text = "";
                txtRemark.Text = "";
                txtAddress.Text = "";
                txtPhone.Text = "";
                txtSTNo.Text = "";
                txtCSTNo.Text = "";
                txtEPCGNo.Text = "";
                txtWardNo.Text = "";
                txtTINNo.Text = "";
                txtESICNo.Text = "";
                txtPTNo.Text = "";
                txtTDSNo.Text = "";
                txtRegNo.Text = "";
                txtESICLocalOff.Text = "";
                txtCINNo.Text = "";
                txtPANNo.Text = "";
                txtVATNo.Text = "";
                txtPFNo.Text = "";
                txtExciseNo.Text = "";
                txtTANNo.Text = "";
                txtLicenceNo.Text = "";
                txtCPTNo.Text = "";
                txtITPANo.Text = "";
                txtPFGrpCode.Text = "";
                dtpESICCovDate.Text = "";
                txtShortName.Focus();
                chkActive.Checked = false;
                txtGSTNo.Text = "";
                txtCGSTPer.Text = "";
                txtSGSTPer.Text = "";
                txtIGSTPer.Text = "";
                lueLedger.EditValue = null;
            }
            catch (Exception ex)
            {
                Global.Message(ex.ToString());
                return;
            }

        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LookupState_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                lueCountry.EditValue = lueState.GetColumnValue("country_id");
            }
            catch (Exception ex)
            {
                Global.Message(ex.ToString());
                return;
            }

        }
        private void LookupCity_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                lueState.EditValue = lueCity.GetColumnValue("state_id");
                lueCountry.EditValue = lueCity.GetColumnValue("country_id");
            }
            catch (Exception ex)
            {
                Global.Message(ex.ToString());
                return;
            }

        }

        #region GridEvents
        private void dgvBranchMaster_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                if (e.RowHandle >= 0)
                {
                    if (e.Clicks == 2)
                    {
                        DataRow Drow = dgvBranchMaster.GetDataRow(e.RowHandle);
                        lblMode.Text = "Edit Mode";
                        lblMode.Tag = Val.ToInt64(Drow["branch_id"]);
                        txtShortName.Text = Val.ToString(Drow["branch_shortname"]);
                        txtBranchName.Text = Val.ToString(Drow["branch_name"]);
                        lueLocation.EditValue = Val.ToInt32(Drow["location_id"]);
                        lueCompany.EditValue = Val.ToInt32(Drow["company_id"]);
                        lueCountry.EditValue = Val.ToInt32(Drow["country_id"]);
                        lueState.EditValue = Val.ToInt32(Drow["state_id"]);
                        lueCity.EditValue = Val.ToInt32(Drow["city_id"]);
                        txtRemark.Text = Val.ToString(Drow["remarks"]);
                        chkActive.Checked = Val.ToBoolean(Drow["active"]);
                        txtZipCode.Text = Val.ToString(Drow["pincode"]);
                        txtAddress.Text = Val.ToString(Drow["address"]);
                        txtPhone.Text = Val.ToString(Drow["phone_no"]);
                        txtSTNo.Text = Val.ToString(Drow["st_no"]);
                        txtCSTNo.Text = Val.ToString(Drow["cst_no"]);
                        txtEPCGNo.Text = Val.ToString(Drow["epcg_no"]);
                        txtWardNo.Text = Val.ToString(Drow["ward_no"]);
                        txtTINNo.Text = Val.ToString(Drow["tin_no"]);
                        txtRegNo.Text = Val.ToString(Drow["reg_no"]);
                        txtTDSNo.Text = Val.ToString(Drow["tds_no"]);
                        txtESICNo.Text = Val.ToString(Drow["esic_no"]);
                        txtPTNo.Text = Val.ToString(Drow["pt_no"]);
                        txtESICLocalOff.Text = Val.ToString(Drow["esic_local_office"]);
                        txtCINNo.Text = Val.ToString(Drow["cin_no"]);
                        txtTANNo.Text = Val.ToString(Drow["tan_no"]);
                        txtPANNo.Text = Val.ToString(Drow["pan_no"]);
                        txtVATNo.Text = Val.ToString(Drow["vat_no"]);
                        txtPFNo.Text = Val.ToString(Drow["pf_no"]);
                        txtExciseNo.Text = Val.ToString(Drow["excise_no"]);
                        txtLicenceNo.Text = Val.ToString(Drow["licence_no"]);
                        txtCPTNo.Text = Val.ToString(Drow["cpt_no"]);
                        txtITPANo.Text = Val.ToString(Drow["it_pa_no"]);
                        txtPFGrpCode.Text = Val.ToString(Drow["pf_group_code"]);
                        dtpESICCovDate.Text = Val.ToString(Drow["esic_coverage_date"]);

                        lueLedger.EditValue = Val.ToInt32(Drow["ledger_id"]);
                        txtCGSTPer.Text = Val.ToString(Drow["cgst_per"]);
                        txtSGSTPer.Text = Val.ToString(Drow["sgst_per"]);
                        txtIGSTPer.Text = Val.ToString(Drow["igst_per"]);
                        txtGSTNo.Text = Val.ToString(Drow["gst_no"]);
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
            Branch_MasterProperty BranchMasterProperty = new Branch_MasterProperty();
            BranchMaster objBranch = new BranchMaster();

            try
            {
                if (!ValidateDetails())
                {
                    blnReturn = false;
                    return blnReturn;
                }

                BranchMasterProperty.branch_id = Val.ToInt32(lblMode.Tag);
                BranchMasterProperty.branch_shortname = Val.ToString(txtShortName.Text).ToUpper();
                BranchMasterProperty.branch_name = Val.ToString(txtBranchName.Text).ToUpper();
                BranchMasterProperty.location_id = Val.ToInt32(lueLocation.EditValue);
                BranchMasterProperty.company_id = Val.ToInt32(lueCompany.EditValue);
                BranchMasterProperty.country_id = Val.ToInt32(lueCountry.EditValue);
                BranchMasterProperty.city_id = Val.ToInt32(lueCity.EditValue);
                BranchMasterProperty.state_id = Val.ToInt32(lueState.EditValue);
                BranchMasterProperty.pincode = Val.ToString(txtZipCode.Text);
                BranchMasterProperty.remarks = Val.ToString(txtRemark.Text).ToUpper();
                BranchMasterProperty.active = Val.ToBoolean(chkActive.Checked);
                BranchMasterProperty.address = Val.ToString(txtAddress.Text).ToUpper();
                BranchMasterProperty.phone_no = Val.ToString(txtPhone.Text);
                BranchMasterProperty.cst_no = Val.ToString(txtCSTNo.Text).ToUpper();
                BranchMasterProperty.st_no = Val.ToString(txtSTNo.Text).ToUpper();
                BranchMasterProperty.epcg_no = Val.ToString(txtEPCGNo.Text).ToUpper();
                BranchMasterProperty.ward_no = Val.ToString(txtWardNo.Text).ToUpper();
                BranchMasterProperty.tin_no = Val.ToString(txtTINNo.Text).ToUpper();
                BranchMasterProperty.esic_no = Val.ToString(txtESICNo.Text).ToUpper();
                BranchMasterProperty.pt_no = Val.ToString(txtPTNo.Text).ToUpper();
                BranchMasterProperty.tds_no = Val.ToString(txtTDSNo.Text).ToUpper();
                BranchMasterProperty.reg_no = Val.ToString(txtRegNo.Text).ToUpper();
                BranchMasterProperty.esic_local_office = Val.ToString(txtESICLocalOff.Text).ToUpper();
                BranchMasterProperty.cin_no = Val.ToString(txtCINNo.Text).ToUpper();
                BranchMasterProperty.pan_no = Val.ToString(txtPANNo.Text).ToUpper();
                BranchMasterProperty.vat_no = Val.ToString(txtVATNo.Text).ToUpper();
                BranchMasterProperty.pf_no = Val.ToString(txtPFNo.Text).ToUpper();
                BranchMasterProperty.excise_no = Val.ToString(txtExciseNo.Text).ToUpper();
                BranchMasterProperty.tan_no = Val.ToString(txtTANNo.Text).ToUpper();
                BranchMasterProperty.licence_no = Val.ToString(txtLicenceNo.Text).ToUpper();
                BranchMasterProperty.cpt_no = Val.ToString(txtCPTNo.Text).ToUpper();
                BranchMasterProperty.it_pa_no = Val.ToString(txtITPANo.Text).ToUpper();
                BranchMasterProperty.pf_group_code = Val.ToString(txtPFGrpCode.Text).ToUpper();
                BranchMasterProperty.esic_coverage_date = Val.DBDate(dtpESICCovDate.Text).ToUpper();

                BranchMasterProperty.gst_no = Val.ToString(txtGSTNo.Text).ToUpper();
                BranchMasterProperty.cgst_per = Val.ToDecimal(txtCGSTPer.Text);
                BranchMasterProperty.sgst_per = Val.ToDecimal(txtSGSTPer.Text);
                BranchMasterProperty.igst_per = Val.ToDecimal(txtIGSTPer.Text);
                BranchMasterProperty.ledger_id = Val.ToInt(lueLedger.EditValue);


                int IntRes = objBranch.Save(BranchMasterProperty);
                if (IntRes == -1)
                {
                    Global.Confirm("Error In Save Branch Details");
                    TabRegisterDetail.SelectedTabPageIndex = 0;
                    txtBranchName.Focus();
                }
                else
                {
                    if (Val.ToInt(lblMode.Tag) == 0)
                    {
                        Global.Confirm("Branch Details Data Save Successfully");
                    }
                    else
                    {
                        Global.Confirm("Branch Details Data Update Successfully");
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
                BranchMasterProperty = null;
            }

            return blnReturn;
        }
        private bool ValidateDetails()
        {
            bool blnFocus = false;
            List<ListError> lstError = new List<ListError>();
            try
            {
                if (txtShortName.Text == string.Empty)
                {
                    lstError.Add(new ListError(12, "Short Name"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                        txtShortName.Focus();
                    }
                }
                if (txtBranchName.Text == string.Empty)
                {
                    lstError.Add(new ListError(12, "Branch Name"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                        txtBranchName.Focus();
                    }
                }

                if (!objBranch.ISExists(txtBranchName.Text, Val.ToInt64(lblMode.Tag)).ToString().Trim().Equals(string.Empty))
                {
                    lstError.Add(new ListError(23, "Form Name"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                        txtBranchName.Focus();
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

                if (lueCompany.ItemIndex < 0)
                {
                    lstError.Add(new ListError(13, "Company"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                        lueCompany.Focus();
                    }
                }
                if (lueCountry.ItemIndex < 0)
                {
                    lstError.Add(new ListError(13, "Country"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                        lueCountry.Focus();
                    }
                }
                if (lueState.ItemIndex < 0)
                {
                    lstError.Add(new ListError(13, "State"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                        lueState.Focus();
                    }
                }
                if (lueCity.ItemIndex < 0)
                {
                    lstError.Add(new ListError(13, "City"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                        lueCity.Focus();
                    }
                }
                if (txtAddress.Text == string.Empty)
                {
                    lstError.Add(new ListError(12, "Address"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                        txtAddress.Focus();
                    }
                }
                if (txtZipCode.Text == string.Empty)
                {
                    lstError.Add(new ListError(12, "Pincode"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                        txtZipCode.Focus();
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
                DataTable DTab = objBranch.GetData();
                grdBranchMaster.InvokeEx(t =>
                {
                    t.DataSource = DTab;
                    dgvBranchMaster.BestFitColumns();
                });
            }
            catch (Exception ex)
            {
                Global.Message(ex.ToString());
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
                            dgvBranchMaster.ExportToPdf(Filepath);
                            break;
                        case "xls":
                            dgvBranchMaster.ExportToXls(Filepath);
                            break;
                        case "xlsx":
                            dgvBranchMaster.ExportToXlsx(Filepath);
                            break;
                        case "rtf":
                            dgvBranchMaster.ExportToRtf(Filepath);
                            break;
                        case "txt":
                            dgvBranchMaster.ExportToText(Filepath);
                            break;
                        case "html":
                            dgvBranchMaster.ExportToHtml(Filepath);
                            break;
                        case "csv":
                            dgvBranchMaster.ExportToCsv(Filepath);
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
