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
    public partial class FrmCompanyMaster : Form
    {
        #region Data Member

        BLL.FormEvents objBOFormEvents;
        BLL.Validation Val;
        BLL.FormPer ObjPer;

        CompanyMaster objCompany;
        List<Task> tList = new List<Task>();
        #endregion

        #region Constructor
        public FrmCompanyMaster()
        {
            InitializeComponent();

            objBOFormEvents = new BLL.FormEvents();
            Val = new BLL.Validation();
            ObjPer = new BLL.FormPer();

            objCompany = new CompanyMaster();
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
            objBOFormEvents.ObjToDispose.Add(objCompany);
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
                Task.Run(() => GetData());


                dtpCST.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
                dtpCST.Properties.Mask.EditMask = "dd/MMM/yyyy";
                dtpCST.Properties.Mask.UseMaskAsDisplayFormat = true;
                dtpCST.Properties.CharacterCasing = CharacterCasing.Upper;

                dtpGst.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
                dtpGst.Properties.Mask.EditMask = "dd/MMM/yyyy";
                dtpGst.Properties.Mask.UseMaskAsDisplayFormat = true;
                dtpGst.Properties.CharacterCasing = CharacterCasing.Upper;

                dtpST.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
                dtpST.Properties.Mask.EditMask = "dd/MMM/yyyy";
                dtpST.Properties.Mask.UseMaskAsDisplayFormat = true;
                dtpST.Properties.CharacterCasing = CharacterCasing.Upper;

                dtpTAN.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
                dtpTAN.Properties.Mask.EditMask = "dd/MMM/yyyy";
                dtpTAN.Properties.Mask.UseMaskAsDisplayFormat = true;
                dtpTAN.Properties.CharacterCasing = CharacterCasing.Upper;
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
                txtShortName.Text = "";
                txtCompanyName.Text = "";
                txtRemark.Text = "";
                txtOwnerPerson.Text = "";
                txtWebsite.Text = "";
                txtEmailID.Text = "";
                txtZipCode.Text = "";
                txtAddress1.Text = "";
                lueCountry.EditValue = null;
                lueState.EditValue = null;
                lueCity.EditValue = null;
                txtPhone1.Text = "";
                txtPhone2.Text = "";
                txtSTNo.Text = "";
                txtNatOfBuss.Text = "";
                txtCSTNo.Text = "";
                txtTANNo.Text = "";
                txtAccNo.Text = "";
                txtTDSNo.Text = "";
                dtpST.Text = "";
                dtpCST.Text = "";
                dtpTAN.Text = "";
                txtRegNo.Text = "";
                txtFax.Text = "";
                dtpGst.Text = "";
                txtGstNo.Text = "";
                txtPancardNo.Text = "";
                txtBankAccNo.Text = "";
                txtBankBranch.Text = "";
                txtBankIFSC.Text = "";
                txtBankName.Text = "";
                txtAddress2.Text = "";
                txtAddress3.Text = "";
                txtAddress4.Text = "";

                TabRegisterDetail.SelectedTabPageIndex = 0;
                txtCompanyName.Focus();
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
        private void LookupState_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                lueCity.EditValue = lueCity.GetColumnValue("state_id");
            }
            catch (Exception ex)
            {
                General.ShowErrors(ex.ToString());
                return;
            }
        }
        private void LookupCity_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                lueCountry.EditValue = lueCity.GetColumnValue("country_id");
                lueState.EditValue = lueCity.GetColumnValue("state_id");
            }
            catch (Exception ex)
            {
                General.ShowErrors(ex.ToString());
                return;
            }
        }
        private void lueCountry_EditValueChanged(object sender, EventArgs e)
        {
            lueState.EditValue = lueCountry.GetColumnValue("state_id");
        }

        #region GridEvents
        private void dgvCompanyMaster_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                if (e.RowHandle >= 0)
                {
                    if (e.Clicks == 2)
                    {
                        DataRow Drow = dgvCompanyMaster.GetDataRow(e.RowHandle);
                        lblMode.Text = "Edit Mode";
                        lblMode.Tag = Val.ToInt64(Drow["company_id"]);
                        txtShortName.Text = Val.ToString(Drow["company_shortname"]);
                        txtCompanyName.Text = Val.ToString(Drow["company_name"]);
                        txtOwnerPerson.Text = Val.ToString(Drow["owner_name"]);
                        lueCountry.EditValue = Val.ToInt32(Drow["country_id"]);
                        lueState.EditValue = Val.ToInt32(Drow["state_id"]);
                        lueCity.EditValue = Val.ToInt32(Drow["city_id"]);
                        txtRemark.Text = Val.ToString(Drow["remarks"]);
                        chkActive.Checked = Val.ToBoolean(Drow["active"]);
                        txtWebsite.Text = Val.ToString(Drow["website"]);
                        txtEmailID.Text = Val.ToString(Drow["email"]);
                        txtZipCode.Text = Val.ToString(Drow["pincode"]);
                        txtAddress1.Text = Val.ToString(Drow["address"]);
                        txtPhone1.Text = Val.ToString(Drow["phone1"]);
                        txtPhone2.Text = Val.ToString(Drow["phone2"]);
                        txtNatOfBuss.Text = Val.ToString(Drow["nature_of_business"]);
                        txtSTNo.Text = Val.ToString(Drow["service_tax_no"]);
                        txtCSTNo.Text = Val.ToString(Drow["cst_no"]);
                        txtTANNo.Text = Val.ToString(Drow["tan_no"]);
                        txtTDSNo.Text = Val.ToString(Drow["tds_circle"]);
                        txtBankAccNo.Text = Val.ToString(Drow["bank_acc_no"]);
                        txtRegNo.Text = Val.ToString(Drow["registration_no"]);
                        txtFax.Text = Val.ToString(Drow["fax"]);
                        dtpST.Text = Val.ToString(Drow["service_tax_date"]);
                        dtpCST.Text = Val.ToString(Drow["cst_date"]);
                        dtpTAN.Text = Val.ToString(Drow["tan_date"]);
                        dtpGst.Text = Val.ToString(Drow["gst_date"]);
                        txtGstNo.Text = Val.ToString(Drow["gst_no"]);

                        txtBankBranch.Text = Val.ToString(Drow["bank_branch"]);
                        txtBankName.Text = Val.ToString(Drow["bank_name"]);
                        txtBankIFSC.Text = Val.ToString(Drow["bank_ifsc"]);
                        txtPancardNo.Text = Val.ToString(Drow["pancard_no"]);

                        txtAddress2.Text = Val.ToString(Drow["address2"]);
                        txtAddress3.Text = Val.ToString(Drow["address3"]);
                        txtAddress4.Text = Val.ToString(Drow["address4"]);

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
            Company_MasterProperty CompMasterProperty = new Company_MasterProperty();
            CompanyMaster objCompany = new CompanyMaster();

            try
            {
                if (!ValidateDetails())
                {
                    blnReturn = false;
                    return blnReturn;
                }
                CompMasterProperty.company_id = Val.ToInt32(lblMode.Tag);
                CompMasterProperty.company_shortname = Val.ToString(txtShortName.Text).ToUpper();
                CompMasterProperty.company_name = Val.ToString(txtCompanyName.Text).ToUpper();
                CompMasterProperty.owner_name = Val.ToString(txtOwnerPerson.Text).ToUpper();
                CompMasterProperty.state_id = Val.ToInt(lueState.EditValue);
                CompMasterProperty.country_id = Val.ToInt(lueCountry.EditValue);
                CompMasterProperty.city_id = Val.ToInt(lueCity.EditValue);
                CompMasterProperty.active = Val.ToBoolean(chkActive.Checked);
                CompMasterProperty.remarks = Val.ToString(txtRemark.Text).ToUpper();
                CompMasterProperty.website = Val.ToString(txtWebsite.Text).ToUpper();
                CompMasterProperty.email = Val.ToString(txtEmailID.Text).ToUpper();
                CompMasterProperty.address = Val.ToString(txtAddress1.Text).ToUpper();
                CompMasterProperty.pincode = Val.ToString(txtZipCode.Text).ToUpper();
                CompMasterProperty.phone1 = Val.ToString(txtPhone1.Text).ToUpper();
                CompMasterProperty.phone2 = Val.ToString(txtPhone2.Text).ToUpper();
                CompMasterProperty.service_tax_no = Val.ToString(txtSTNo.Text).ToUpper();
                CompMasterProperty.cst_no = Val.ToString(txtCSTNo.Text).ToUpper();
                CompMasterProperty.nature_of_business = Val.ToString(txtNatOfBuss.Text).ToUpper();
                CompMasterProperty.tan_no = Val.ToString(txtTANNo.Text).ToUpper();
                CompMasterProperty.tds_circle = Val.ToString(txtTDSNo.Text).ToUpper();
                CompMasterProperty.service_tax_date = Val.DBDate(dtpST.Text).ToUpper();
                CompMasterProperty.cst_date = Val.DBDate(dtpCST.Text).ToUpper();
                CompMasterProperty.tan_date = Val.DBDate(dtpTAN.Text).ToUpper();
                CompMasterProperty.registration_no = Val.ToString(txtRegNo.Text).ToUpper();
                CompMasterProperty.fax = Val.ToString(txtFax.Text).ToUpper();
                CompMasterProperty.gst_no = Val.ToString(txtGstNo.Text).ToUpper();
                CompMasterProperty.gst_date = Val.DBDate(dtpGst.Text).ToUpper();

                CompMasterProperty.pancard_no = Val.ToString(txtPancardNo.Text).ToUpper();
                CompMasterProperty.bank_name = Val.ToString(txtBankName.Text);
                CompMasterProperty.bank_branch = Val.ToString(txtBankBranch.Text);
                CompMasterProperty.bank_ifsc = Val.ToString(txtBankIFSC.Text);
                CompMasterProperty.bank_acc_no = Val.ToString(txtBankAccNo.Text);

                CompMasterProperty.address1 = Val.ToString(txtAddress1.Text).ToUpper();
                CompMasterProperty.address2 = Val.ToString(txtAddress2.Text).ToUpper();
                CompMasterProperty.address3 = Val.ToString(txtAddress3.Text).ToUpper();
                CompMasterProperty.address4 = Val.ToString(txtAddress4.Text).ToUpper();

                int IntRes = objCompany.Save(CompMasterProperty);
                if (IntRes == -1)
                {
                    Global.Confirm("Error In Save Company Details");
                    TabRegisterDetail.SelectedTabPageIndex = 0;
                    txtCompanyName.Focus();
                }
                else
                {
                    if (Val.ToInt(lblMode.Tag) == 0)
                    {
                        Global.Confirm("Company Details Data Save Successfully");
                        TabRegisterDetail.SelectedTabPageIndex = 0;
                        txtCompanyName.Focus();
                    }
                    else
                    {
                        Global.Confirm("Company Details Data Update Successfully");
                        TabRegisterDetail.SelectedTabPageIndex = 0;
                        txtCompanyName.Focus();
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
                CompMasterProperty = null;
            }

            return blnReturn;
        }
        private void BtnNext_Click(object sender, EventArgs e)
        {
            TabRegisterDetail.SelectedTabPageIndex = TabRegisterDetail.SelectedTabPageIndex + 1;
        }
        private bool ValidateDetails()
        {
            bool blnFocus = false;
            List<ListError> lstError = new List<ListError>();
            try
            {
                //if (txtShortName.Text == string.Empty)
                //{
                //    lstError.Add(new ListError(12, "Short Name"));
                //    if (!blnFocus)
                //    {
                //        blnFocus = true;
                //        txtShortName.Focus();
                //    }
                //}

                if (txtCompanyName.Text == string.Empty)
                {
                    lstError.Add(new ListError(12, "Company Name"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                        txtCompanyName.Focus();
                    }
                }

                if (!objCompany.ISExists(txtCompanyName.Text, Val.ToInt64(lblMode.Tag)).ToString().Trim().Equals(string.Empty))
                {
                    lstError.Add(new ListError(23, "Company Name"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                        txtCompanyName.Focus();
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
                DataTable DTab = objCompany.GetData();
                grdCompanyMaster.InvokeEx(t =>
                {
                    t.DataSource = DTab;
                    dgvCompanyMaster.BestFitColumns();
                });
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
                            dgvCompanyMaster.ExportToPdf(Filepath);
                            break;
                        case "xls":
                            dgvCompanyMaster.ExportToXls(Filepath);
                            break;
                        case "xlsx":
                            dgvCompanyMaster.ExportToXlsx(Filepath);
                            break;
                        case "rtf":
                            dgvCompanyMaster.ExportToRtf(Filepath);
                            break;
                        case "txt":
                            dgvCompanyMaster.ExportToText(Filepath);
                            break;
                        case "html":
                            dgvCompanyMaster.ExportToHtml(Filepath);
                            break;
                        case "csv":
                            dgvCompanyMaster.ExportToCsv(Filepath);
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

        private void txtPhone1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnNext_Click(null, null);
                txtSTNo.Focus();
            }
        }

        private void txtPhone1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
