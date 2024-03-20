using Account_Management.Class;
using BLL;
using BLL.FunctionClasses.Master;
using BLL.PropertyClasses.Master;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using static Account_Management.Class.Global;

namespace Account_Management
{
    public partial class FrmLedgerMaster : DevExpress.XtraEditors.XtraForm
    {
        #region Data Member

        BLL.FormEvents objBOFormEvents;
        BLL.Validation Val;
        BLL.FormPer ObjPer;

        LedgerMaster objLedger;

        DataTable DtControlSettings;
        DataTable m_dtbBussinesstype;
        DataTable m_dtbBrokerCategory;
        DataTable m_dtbBehaviour;
        DataTable m_dtbInitName;
        DataTable m_dtbLedgerType;
        DataTable m_dtbRegSource;
        FillCombo ObjFillCombo = new FillCombo();

        #endregion

        #region Constructor
        public FrmLedgerMaster()
        {
            InitializeComponent();

            objBOFormEvents = new BLL.FormEvents();
            Val = new BLL.Validation();
            ObjPer = new BLL.FormPer();
            objLedger = new LedgerMaster();
            DtControlSettings = new DataTable();
            m_dtbBussinesstype = new DataTable();
            m_dtbBrokerCategory = new DataTable();
            m_dtbBehaviour = new DataTable();
            m_dtbInitName = new DataTable();
            m_dtbLedgerType = new DataTable();
            m_dtbRegSource = new DataTable();
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

            TabRegisterDetail.SelectedTabPageIndex = 0;
            txtLedgerName.Focus();
            this.Show();
        }
        private void AttachFormEvents()
        {
            objBOFormEvents.CurForm = this;
            objBOFormEvents.FormKeyPress = true;
            objBOFormEvents.FormKeyDown = true;

            objBOFormEvents.FormResize = true;
            objBOFormEvents.FormClosing = true;
            objBOFormEvents.ObjToDispose.Add(objLedger);
            objBOFormEvents.ObjToDispose.Add(Val);
            objBOFormEvents.ObjToDispose.Add(objBOFormEvents);
        }

        #endregion

        #region Events
        private void FrmLedgerMaster_Load(object sender, EventArgs e)
        {
            try
            {
                ObjPer.FormName = this.Name.ToUpper();

                m_dtbBussinesstype = new DataTable();
                m_dtbInitName = new DataTable();
                m_dtbLedgerType = new DataTable();
                m_dtbRegSource = new DataTable();

                GetData();
                btnClear_Click(btnClear, null);

                Global.LOOKUPCountry(lueCountry);
                Global.LOOKUPState(lueState);
                Global.LOOKUPCity(lueCity);
                Global.LOOKUPLedgerGroup(lueLedgerGroup);

                m_dtbLedgerType.Columns.Add("ledger_type");
                m_dtbLedgerType.Rows.Add("Registered");
                m_dtbLedgerType.Rows.Add("Un-Registered");
                m_dtbLedgerType.Rows.Add("Composition");
                m_dtbLedgerType.Rows.Add("UIN Holder");

                lueLedgerType.Properties.DataSource = m_dtbLedgerType;
                lueLedgerType.Properties.ValueMember = "ledger_type";
                lueLedgerType.Properties.DisplayMember = "ledger_type";

                chkActive.Checked = true;
                txtLedgerName.Focus();
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
                txtLedgerName.Text = string.Empty;
                txtAddress1.Text = string.Empty;
                txtAddress2.Text = string.Empty;
                txtAddress3.Text = string.Empty;
                txtAddress4.Text = string.Empty;
                txtLedgerPrintName.Text = string.Empty;
                lueLedgerGroup.EditValue = null;
                lueLedgerType.EditValue = null;
                txtMobileNo1.Text = string.Empty;
                txtMobileNo2.Text = string.Empty;
                lueCity.EditValue = null;
                lueState.EditValue = null;
                lueCountry.EditValue = null;

                txtEmailID.Text = string.Empty;
                txtZipCode.Text = string.Empty;
                txtRemark.Text = string.Empty;
                chkActive.Checked = true;
                TabRegisterDetail.SelectedTabPageIndex = 0;
                txtLedgerName.Focus();
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
        private void txtRemark_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnSave.Focus();
                }
            }
            catch (Exception ex)
            {
                General.ShowErrors(ex.ToString());
                return;
            }
        }

        #region GridEvents
        private void dgvLedgerMaster_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                if (e.RowHandle >= 0)
                {
                    if (e.Clicks == 2)
                    {
                        DataRow Drow = dgvLedgerMaster.GetDataRow(e.RowHandle);
                        lblMode.Text = "Edit Mode";
                        lblMode.Tag = Val.ToInt64(Drow["ledger_id"]);
                        txtLedgerName.Text = Val.ToString(Drow["ledger_name"]);
                        txtEmailID.Text = Val.ToString(Drow["party_email"]);
                        lueLedgerType.Text = Val.ToString(Drow["ledger_type"]);
                        lueLedgerGroup.EditValue = Val.ToInt64(Drow["ledger_group_id"]);
                        lueCountry.EditValue = Val.ToInt32(Drow["party_county_id"]);
                        lueState.EditValue = Val.ToInt32(Drow["party_state_id"]);
                        lueCity.EditValue = Val.ToInt32(Drow["party_city_id"]);
                        txtRemark.Text = Val.ToString(Drow["remark"]);
                        chkActive.Checked = Val.ToBoolean(Drow["active"]);
                        txtZipCode.Text = Val.ToString(Drow["party_pincode"]);
                        txtAddress1.Text = Val.ToString(Drow["party_address1"]);
                        txtAddress2.Text = Val.ToString(Drow["party_address2"]);
                        txtAddress3.Text = Val.ToString(Drow["party_address3"]);
                        txtAddress4.Text = Val.ToString(Drow["party_address4"]);
                        txtMobileNo1.Text = Val.ToString(Drow["party_mobile1"]);
                        txtMobileNo2.Text = Val.ToString(Drow["party_mobile2"]);
                        txtLedgerPrintName.Text = Val.ToString(Drow["ledger_print_name"]);
                        txtGSTNo.Text = Val.ToString(Drow["gst_no"]);
                        txtPanNo.Text = Val.ToString(Drow["party_pan_no"]);
                        txtOpeningBalance.Text = Val.ToString(Drow["opening_balance"]);
                        txtBankName.Text = Val.ToString(Drow["bank_name"]);
                        txtBankBranch.Text = Val.ToString(Drow["bank_branch"]);
                        txtBankIFSC.Text = Val.ToString(Drow["bank_ifsc"]);
                        txtBankAccNo.Text = Val.ToString(Drow["bank_account_no"]);
                        txtLedgerName.Focus();
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
            Ledger_MasterProperty LedgerMasterProperty = new Ledger_MasterProperty();
            LedgerMaster objLedger = new LedgerMaster();
            int IntRes = 0;
            try
            {
                if (!ValidateDetails())
                {
                    blnReturn = false;
                    return blnReturn;
                }

                LedgerMasterProperty.ledger_id = Val.ToInt32(lblMode.Tag);
                LedgerMasterProperty.ledger_name = Val.ToString(txtLedgerName.Text).ToUpper();
                LedgerMasterProperty.ledger_group_id = Val.ToInt64(lueLedgerGroup.EditValue);
                LedgerMasterProperty.ledger_type = Val.ToString(lueLedgerType.EditValue);
                LedgerMasterProperty.opening_balance = Val.ToDecimal(txtOpeningBalance.Text);
                LedgerMasterProperty.ledger_print_name = Val.ToString(txtLedgerPrintName.Text);
                LedgerMasterProperty.party_address1 = Val.ToString(txtAddress1.Text);
                LedgerMasterProperty.party_address2 = Val.ToString(txtAddress2.Text);
                LedgerMasterProperty.party_address3 = Val.ToString(txtAddress3.Text);
                LedgerMasterProperty.party_address4 = Val.ToString(txtAddress4.Text);
                LedgerMasterProperty.party_mobile1 = Val.ToString(txtMobileNo1.Text);
                LedgerMasterProperty.party_mobile2 = Val.ToString(txtMobileNo2.Text);
                LedgerMasterProperty.party_email = Val.ToString(txtEmailID.Text);
                LedgerMasterProperty.bank_branch = Val.ToString(txtBankBranch.Text);
                LedgerMasterProperty.bank_name = Val.ToString(txtBankName.Text);
                LedgerMasterProperty.bank_ifsc = Val.ToString(txtBankIFSC.Text);
                LedgerMasterProperty.bank_account_no = Val.ToString(txtBankAccNo.Text);
                LedgerMasterProperty.party_pincode = Val.ToString(txtZipCode.Text);
                LedgerMasterProperty.party_county_id = Val.ToInt64(lueCountry.EditValue);
                LedgerMasterProperty.party_city_id = Val.ToInt64(lueCity.EditValue);
                LedgerMasterProperty.party_state_id = Val.ToInt64(lueState.EditValue);
                LedgerMasterProperty.party_pan_no = Val.ToString(txtPanNo.Text);
                LedgerMasterProperty.gst_no = Val.ToString(txtGSTNo.Text);
                LedgerMasterProperty.remark = Val.ToString(txtRemark.Text).ToUpper();
                LedgerMasterProperty.active = Val.ToBoolean(chkActive.Checked);

                IntRes = objLedger.Save(LedgerMasterProperty);

                if (IntRes == -1)
                {
                    Global.Confirm("Error In Save Ledger Details");
                    TabRegisterDetail.SelectedTabPageIndex = 0;
                    txtLedgerName.Focus();
                }
                else
                {
                    Global.Confirm("Ledger Details Data Save Successfully");
                    TabRegisterDetail.SelectedTabPageIndex = 0;
                    txtLedgerName.Focus();
                }
            }
            catch (Exception ex)
            {
                General.ShowErrors(ex.ToString());
                blnReturn = false;
            }
            finally
            {
                LedgerMasterProperty = null;
            }
            return blnReturn;
        }
        private bool ValidateDetails()
        {
            bool blnFocus = false;
            List<ListError> lstError = new List<ListError>();
            try
            {
                if (txtLedgerName.Text == string.Empty)
                {
                    lstError.Add(new ListError(12, "Ledger Name"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                        txtLedgerName.Focus();
                    }
                }

                if (!objLedger.ISExists(txtLedgerName.Text, Val.ToInt64(lblMode.Tag)).ToString().Trim().Equals(string.Empty))
                {
                    lstError.Add(new ListError(23, "Ledger Name"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                        txtLedgerName.Focus();
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
                DataTable DTab = new DataTable();
                DTab = objLedger.GetData();
                grdLedgerMaster.DataSource = DTab;
                dgvLedgerMaster.BestFitColumns();
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
                            dgvLedgerMaster.ExportToPdf(Filepath);
                            break;
                        case "xls":
                            dgvLedgerMaster.ExportToXls(Filepath);
                            break;
                        case "xlsx":
                            dgvLedgerMaster.ExportToXlsx(Filepath);
                            break;
                        case "rtf":
                            dgvLedgerMaster.ExportToRtf(Filepath);
                            break;
                        case "txt":
                            dgvLedgerMaster.ExportToText(Filepath);
                            break;
                        case "html":
                            dgvLedgerMaster.ExportToHtml(Filepath);
                            break;
                        case "csv":
                            dgvLedgerMaster.ExportToCsv(Filepath);
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
