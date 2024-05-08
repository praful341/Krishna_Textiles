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
    public partial class FrmPurchaseFirmMaster : Form
    {
        #region Data Member

        BLL.FormEvents objBOFormEvents;
        BLL.Validation Val;
        BLL.FormPer ObjPer;

        PurchaseFirmMaster objPurchaseFirm;
        List<Task> tList = new List<Task>();
        #endregion

        #region Constructor
        public FrmPurchaseFirmMaster()
        {
            InitializeComponent();

            objBOFormEvents = new BLL.FormEvents();
            Val = new BLL.Validation();
            ObjPer = new BLL.FormPer();

            objPurchaseFirm = new PurchaseFirmMaster();
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
            objBOFormEvents.ObjToDispose.Add(objPurchaseFirm);
            objBOFormEvents.ObjToDispose.Add(Val);
            objBOFormEvents.ObjToDispose.Add(objBOFormEvents);
        }
        #endregion

        #region Events
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
                txtFirmName.Text = "";
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
                txtAddress3.Text = "";
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
                CmbBankAccType.SelectedIndex = -1;
                txtAddress2.Text = "";
                txtAddress3.Text = "";
                txtAddress4.Text = "";
                txtFirmName.Focus();
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
        private void dgvPurchaseFirmMaster_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                if (e.RowHandle >= 0)
                {
                    if (e.Clicks == 2)
                    {
                        DataRow Drow = dgvPurchaseFirmMaster.GetDataRow(e.RowHandle);
                        lblMode.Text = "Edit Mode";
                        lblMode.Tag = Val.ToInt64(Drow["firm_id"]);
                        txtFirmName.Text = Val.ToString(Drow["firm_name"]);
                        lueCountry.EditValue = Val.ToInt32(Drow["country_id"]);
                        lueState.EditValue = Val.ToInt32(Drow["state_id"]);
                        lueCity.EditValue = Val.ToInt32(Drow["city_id"]);
                        chkActive.Checked = Val.ToBoolean(Drow["active"]);
                        txtWebsite.Text = Val.ToString(Drow["website"]);
                        txtEmailID.Text = Val.ToString(Drow["email"]);
                        txtZipCode.Text = Val.ToString(Drow["pincode"]);
                        txtPhone1.Text = Val.ToString(Drow["phone1"]);
                        txtPhone2.Text = Val.ToString(Drow["phone2"]);
                        txtBankAccNo.Text = Val.ToString(Drow["bank_acc_no"]);
                        txtGstNo.Text = Val.ToString(Drow["gst_no"]);

                        txtBankBranch.Text = Val.ToString(Drow["bank_branch"]);
                        txtBankName.Text = Val.ToString(Drow["bank_name"]);
                        txtBankIFSC.Text = Val.ToString(Drow["bank_ifsc"]);
                        txtPancardNo.Text = Val.ToString(Drow["pancard_no"]);
                        CmbBankAccType.Text = Val.ToString(Drow["account_type"]);
                        txtAddress1.Text = Val.ToString(Drow["address1"]);
                        txtAddress2.Text = Val.ToString(Drow["address2"]);
                        txtAddress3.Text = Val.ToString(Drow["address3"]);
                        txtAddress4.Text = Val.ToString(Drow["address4"]);
                        txtFirmName.Focus();
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
            PurchaseFirm_MasterProperty PurchaseFirmMasterProperty = new PurchaseFirm_MasterProperty();
            PurchaseFirmMaster objPurchaseFirm = new PurchaseFirmMaster();

            try
            {
                if (!ValidateDetails())
                {
                    blnReturn = false;
                    return blnReturn;
                }
                PurchaseFirmMasterProperty.firm_id = Val.ToInt32(lblMode.Tag);
                PurchaseFirmMasterProperty.firm_name = Val.ToString(txtFirmName.Text).ToUpper();
                PurchaseFirmMasterProperty.owner_name = Val.ToString(txtOwnerPerson.Text).ToUpper();
                PurchaseFirmMasterProperty.state_id = Val.ToInt(lueState.EditValue);
                PurchaseFirmMasterProperty.country_id = Val.ToInt(lueCountry.EditValue);
                PurchaseFirmMasterProperty.city_id = Val.ToInt(lueCity.EditValue);
                PurchaseFirmMasterProperty.active = Val.ToBoolean(chkActive.Checked);
                PurchaseFirmMasterProperty.remarks = Val.ToString(txtRemark.Text).ToUpper();
                PurchaseFirmMasterProperty.website = Val.ToString(txtWebsite.Text).ToUpper();
                PurchaseFirmMasterProperty.email = Val.ToString(txtEmailID.Text).ToUpper();
                PurchaseFirmMasterProperty.address = Val.ToString(txtAddress1.Text).ToUpper();
                PurchaseFirmMasterProperty.pincode = Val.ToString(txtZipCode.Text).ToUpper();
                PurchaseFirmMasterProperty.phone1 = Val.ToString(txtPhone1.Text).ToUpper();
                PurchaseFirmMasterProperty.phone2 = Val.ToString(txtPhone2.Text).ToUpper();
                PurchaseFirmMasterProperty.service_tax_no = Val.ToString(txtSTNo.Text).ToUpper();
                PurchaseFirmMasterProperty.cst_no = Val.ToString(txtCSTNo.Text).ToUpper();
                PurchaseFirmMasterProperty.nature_of_business = Val.ToString(txtAddress3.Text).ToUpper();
                PurchaseFirmMasterProperty.tan_no = Val.ToString(txtTANNo.Text).ToUpper();
                PurchaseFirmMasterProperty.tds_circle = Val.ToString(txtTDSNo.Text).ToUpper();
                PurchaseFirmMasterProperty.service_tax_date = Val.DBDate(dtpST.Text).ToUpper();
                PurchaseFirmMasterProperty.cst_date = Val.DBDate(dtpCST.Text).ToUpper();
                PurchaseFirmMasterProperty.tan_date = Val.DBDate(dtpTAN.Text).ToUpper();
                PurchaseFirmMasterProperty.registration_no = Val.ToString(txtRegNo.Text).ToUpper();
                PurchaseFirmMasterProperty.fax = Val.ToString(txtFax.Text).ToUpper();
                PurchaseFirmMasterProperty.gst_no = Val.ToString(txtGstNo.Text).ToUpper();
                PurchaseFirmMasterProperty.gst_date = Val.DBDate(dtpGst.Text).ToUpper();

                PurchaseFirmMasterProperty.pancard_no = Val.ToString(txtPancardNo.Text).ToUpper();
                PurchaseFirmMasterProperty.bank_name = Val.ToString(txtBankName.Text);
                PurchaseFirmMasterProperty.bank_branch = Val.ToString(txtBankBranch.Text);
                PurchaseFirmMasterProperty.bank_ifsc = Val.ToString(txtBankIFSC.Text);
                PurchaseFirmMasterProperty.bank_acc_no = Val.ToString(txtBankAccNo.Text);

                PurchaseFirmMasterProperty.address1 = Val.ToString(txtAddress1.Text).ToUpper();
                PurchaseFirmMasterProperty.address2 = Val.ToString(txtAddress2.Text).ToUpper();
                PurchaseFirmMasterProperty.address3 = Val.ToString(txtAddress3.Text).ToUpper();
                PurchaseFirmMasterProperty.address4 = Val.ToString(txtAddress4.Text).ToUpper();

                PurchaseFirmMasterProperty.bank_account_type = Val.ToString(CmbBankAccType.Text).ToUpper();

                int IntRes = objPurchaseFirm.Save(PurchaseFirmMasterProperty);
                if (IntRes == -1)
                {
                    Global.Confirm("Error In Save Purchase Firm Details");
                    txtFirmName.Focus();
                }
                else
                {
                    if (Val.ToInt(lblMode.Tag) == 0)
                    {
                        Global.Confirm("Purchase Firm Details Data Save Successfully");
                        txtFirmName.Focus();
                    }
                    else
                    {
                        Global.Confirm("Purchase Firm Details Data Update Successfully");
                        txtFirmName.Focus();
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
                PurchaseFirmMasterProperty = null;
            }

            return blnReturn;
        }
        private void BtnNext_Click(object sender, EventArgs e)
        {
            //TabRegisterDetail.SelectedTabPageIndex = TabRegisterDetail.SelectedTabPageIndex + 1;
        }
        private bool ValidateDetails()
        {
            bool blnFocus = false;
            List<ListError> lstError = new List<ListError>();
            try
            {
                if (txtFirmName.Text == string.Empty)
                {
                    lstError.Add(new ListError(12, "Firm Name"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                        txtFirmName.Focus();
                    }
                }
                if (!objPurchaseFirm.ISExists(txtFirmName.Text, Val.ToInt64(lblMode.Tag)).ToString().Trim().Equals(string.Empty))
                {
                    lstError.Add(new ListError(23, "Firm Name"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                        txtFirmName.Focus();
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
                DataTable DTab = objPurchaseFirm.GetData();
                grdPurchaseFirmMaster.InvokeEx(t =>
                {
                    t.DataSource = DTab;
                    dgvPurchaseFirmMaster.BestFitColumns();
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
                            dgvPurchaseFirmMaster.ExportToPdf(Filepath);
                            break;
                        case "xls":
                            dgvPurchaseFirmMaster.ExportToXls(Filepath);
                            break;
                        case "xlsx":
                            dgvPurchaseFirmMaster.ExportToXlsx(Filepath);
                            break;
                        case "rtf":
                            dgvPurchaseFirmMaster.ExportToRtf(Filepath);
                            break;
                        case "txt":
                            dgvPurchaseFirmMaster.ExportToText(Filepath);
                            break;
                        case "html":
                            dgvPurchaseFirmMaster.ExportToHtml(Filepath);
                            break;
                        case "csv":
                            dgvPurchaseFirmMaster.ExportToCsv(Filepath);
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

        private void txtPhone1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void FrmPurchaseFirmMaster_Load(object sender, EventArgs e)
        {
            try
            {
                Task.Run(() => Global.LOOKUPCountry(lueCountry));
                Task.Run(() => Global.LOOKUPState(lueState));
                Task.Run(() => Global.LOOKUPCity(lueCity));
                Task.Run(() => GetData());


                dtpCST.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
                dtpCST.Properties.Mask.EditMask = "dd-MM-yyyy";
                dtpCST.Properties.Mask.UseMaskAsDisplayFormat = true;
                dtpCST.Properties.CharacterCasing = CharacterCasing.Upper;

                dtpGst.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
                dtpGst.Properties.Mask.EditMask = "dd-MM-yyyy";
                dtpGst.Properties.Mask.UseMaskAsDisplayFormat = true;
                dtpGst.Properties.CharacterCasing = CharacterCasing.Upper;

                dtpST.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
                dtpST.Properties.Mask.EditMask = "dd-MM-yyyy";
                dtpST.Properties.Mask.UseMaskAsDisplayFormat = true;
                dtpST.Properties.CharacterCasing = CharacterCasing.Upper;

                dtpTAN.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
                dtpTAN.Properties.Mask.EditMask = "dd-MM-yyyy";
                dtpTAN.Properties.Mask.UseMaskAsDisplayFormat = true;
                dtpTAN.Properties.CharacterCasing = CharacterCasing.Upper;
                txtFirmName.Focus();
                btnClear_Click(btnClear, null);
            }
            catch (Exception ex)
            {
                General.ShowErrors(ex.ToString());
                return;
            }
        }
    }
}
