using Account_Management.Class;
using BLL;
using BLL.FunctionClasses.Master;
using BLL.PropertyClasses.Master;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static Account_Management.Class.Global;

namespace Account_Management
{
    public partial class FrmPartyMaster : DevExpress.XtraEditors.XtraForm
    {
        #region Data Member

        BLL.FormEvents objBOFormEvents;
        BLL.Validation Val;
        BLL.FormPer ObjPer;

        PartyMaster objParty;

        DataTable DtControlSettings;
        DataTable m_dtbBussinesstype;
        DataTable m_dtbBrokerCategory;
        DataTable m_dtbBehaviour;
        DataTable m_dtbInitName;
        DataTable m_dtbPartyType;
        DataTable m_dtbRegSource;
        FillCombo ObjFillCombo = new FillCombo();

        string m_OldAadharPath;
        string m_OldPanPath;
        Int64 Party_id = 0;
        Control _NextEnteredControl;
        private List<Control> _tabControls;
        public delegate void SetControlValueCallback(Control oControl, string propName, object propValue);
        #endregion

        #region Constructor
        public FrmPartyMaster()
        {
            InitializeComponent();

            objBOFormEvents = new BLL.FormEvents();
            Val = new BLL.Validation();
            ObjPer = new BLL.FormPer();
            _NextEnteredControl = new Control();
            _tabControls = new List<Control>();


            objParty = new PartyMaster();

            DtControlSettings = new DataTable();
            m_dtbBussinesstype = new DataTable();
            m_dtbBrokerCategory = new DataTable();
            m_dtbBehaviour = new DataTable();
            m_dtbInitName = new DataTable();
            m_dtbPartyType = new DataTable();
            m_dtbRegSource = new DataTable();

            m_OldAadharPath = null;
            m_OldPanPath = null;
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
            // for Dynamic Setting By Praful On 01022020

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

            TabRegisterDetail.SelectedTabPageIndex = 0;
            txtPartyName.Focus();
            this.Show();
        }
        private void AttachFormEvents()
        {
            objBOFormEvents.CurForm = this;
            objBOFormEvents.FormKeyPress = true;
            objBOFormEvents.FormKeyDown = true;

            objBOFormEvents.FormResize = true;
            objBOFormEvents.FormClosing = true;
            objBOFormEvents.ObjToDispose.Add(objParty);
            objBOFormEvents.ObjToDispose.Add(Val);
            objBOFormEvents.ObjToDispose.Add(objBOFormEvents);
        }

        #endregion

        #region Events
        private void FrmPartyMaster_Load(object sender, EventArgs e)
        {
            try
            {
                ObjPer.FormName = this.Name.ToUpper();
                // for Dynamic Setting By Praful On 01022020

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

                m_dtbBussinesstype = new DataTable();
                m_dtbInitName = new DataTable();
                m_dtbPartyType = new DataTable();
                m_dtbRegSource = new DataTable();

                GetData();
                btnClear_Click(btnClear, null);

                Global.LOOKUPCountry(lueCountry);
                Global.LOOKUPState(lueState);
                Global.LOOKUPCity(lueCity);
                Global.LOOKUPCountry(luePhnCountry);
                Global.LOOKUPCountry(lueMobCountry);
                Global.LOOKUPCity(luePhnCity);
                //Global.LOOKUPCategory(lueCategory);
                Global.LOOKUPIDProof(lueIDProof);
                //Global.LOOKUPBroker(lueBroker);

                //DataTable DTabManager = ObjFillCombo.FillCmb(FillCombo.TABLE.Manager_Master);
                //DTabManager.DefaultView.Sort = "employee_name";
                //DTabManager = DTabManager.DefaultView.ToTable();

                //lueManager.Properties.DataSource = DTabManager;
                //lueManager.Properties.ValueMember = "employee_id";
                //lueManager.Properties.DisplayMember = "employee_name";
                //lueManager.ClosePopup();

                //Global.LOOKUPManager(lueManager);

                m_dtbBussinesstype.Columns.Add("business_type");
                m_dtbBussinesstype.Rows.Add("BUYER");
                m_dtbBussinesstype.Rows.Add("SELLER");

                m_dtbBehaviour.Columns.Add("behavior");
                m_dtbBehaviour.Rows.Add("A");
                m_dtbBehaviour.Rows.Add("B");
                m_dtbBehaviour.Rows.Add("C");

                m_dtbBrokerCategory.Columns.Add("broker_category");
                m_dtbBrokerCategory.Rows.Add("A");
                m_dtbBrokerCategory.Rows.Add("B");
                m_dtbBrokerCategory.Rows.Add("C");

                lueBehaviour.Properties.DataSource = m_dtbBehaviour;
                lueBehaviour.Properties.ValueMember = "behavior";
                lueBehaviour.Properties.DisplayMember = "behavior";

                lueBrokerCategory.Properties.DataSource = m_dtbBrokerCategory;
                lueBrokerCategory.Properties.ValueMember = "broker_category";
                lueBrokerCategory.Properties.DisplayMember = "broker_category";

                lueBusinessType.Properties.DataSource = m_dtbBussinesstype;
                lueBusinessType.Properties.ValueMember = "business_type";
                lueBusinessType.Properties.DisplayMember = "business_type";

                lueBusinessType.EditValue = Val.ToString(m_dtbBussinesstype.Rows[1]["business_type"].ToString());

                m_dtbInitName.Columns.Add("init_name");
                m_dtbInitName.Rows.Add("Mr.");
                m_dtbInitName.Rows.Add("Mrs.");

                lueInitName.Properties.DataSource = m_dtbInitName;
                lueInitName.Properties.ValueMember = "init_name";
                lueInitName.Properties.DisplayMember = "init_name";

                m_dtbPartyType.Columns.Add("party_type");
                m_dtbPartyType.Rows.Add("Inhouse");
                m_dtbPartyType.Rows.Add("Outside");
                m_dtbPartyType.Rows.Add("Outside-OW");

                luePartyType.Properties.DataSource = m_dtbPartyType;
                luePartyType.Properties.ValueMember = "party_type";
                luePartyType.Properties.DisplayMember = "party_type";

                m_dtbRegSource.Columns.Add("registration_source");
                m_dtbRegSource.Rows.Add("App");
                m_dtbRegSource.Rows.Add("Software");
                m_dtbRegSource.Rows.Add("Web");
                m_dtbRegSource.Rows.Add("IPad");

                lueRegSource.Properties.DataSource = m_dtbRegSource;
                lueRegSource.Properties.ValueMember = "registration_source";
                lueRegSource.Properties.DisplayMember = "registration_source";
                chkActive.Checked = true;
                txtPartyName.Focus();
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
                txtPartyName.Text = string.Empty;
                txtShortName.Text = string.Empty;
                txtFName.Text = string.Empty;
                txtLName.Text = string.Empty;
                lueInitName.EditValue = null;
                lueCategory.EditValue = null;
                lueBusinessType.EditValue = Val.ToString("BUYER");
                lueCity.EditValue = null;
                lueState.EditValue = null;
                lueCountry.EditValue = null;
                luePartyType.EditValue = null;
                lueManager.EditValue = null;
                lueBroker.EditValue = null;
                txtEmailID.Text = string.Empty;
                txtZipCode.Text = string.Empty;
                txtRemark.Text = string.Empty;
                txtAddress.Text = string.Empty;
                txtPhone1.Text = string.Empty;
                txtMobileNo.Text = string.Empty;
                txtCSTNo.Text = string.Empty;
                luePhnCity.EditValue = null;
                lueMobCountry.EditValue = null;
                luePhnCountry.EditValue = null;
                txtFaxNo.Text = string.Empty;
                txtWebsite.Text = string.Empty;
                txtSecEmail.Text = string.Empty;
                txtDiscount.Text = string.Empty;
                txtAadharNo.Text = string.Empty;
                txtPanCardNo.Text = string.Empty;
                txtTdsCircle.Text = string.Empty;
                txtSequenceNo.Text = string.Empty;
                txtVatNo.Text = string.Empty;
                txtGSTNo.Text = string.Empty;
                txtTANNo.Text = string.Empty;
                txtCSTNo.Text = string.Empty;
                txtSerTax.Text = string.Empty;
                dtpVat.Text = string.Empty;
                dtpGSTDate.Text = string.Empty;
                dtpTANDate.Text = string.Empty;
                dtpCSTDate.Text = string.Empty;
                dtpSerTaxDate.Text = string.Empty;
                lblAadharPath.Text = string.Empty;
                lblPanPath.Text = string.Empty;
                lueRegSource.EditValue = null;
                chkActive.Checked = true;
                txtQbc.Text = string.Empty;
                chkFactory.Checked = false;
                ChkISOutSide.Checked = false;
                ChkisAutoConfirm.Checked = false;
                chkIsRej.Checked = false;
                chkIsImpExpParty.Checked = false;
                lueIDProof.EditValue = null;
                txtIDProofNo.Text = string.Empty;
                txtPartyBusinessType.Text = string.Empty;
                lueBrokerCategory.EditValue = null;
                lueBehaviour.EditValue = null;
                Party_id = 0;
                TabRegisterDetail.SelectedTabPageIndex = 0;
                txtPartyName.Focus();
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
        private void btnAadhar_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog OpenDialog = new OpenFileDialog();
                if (OpenDialog.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                {
                    return;
                }
                lblAadharPath.Text = OpenDialog.FileName;
                OpenDialog.Dispose();
                OpenDialog = null;

                if (File.Exists(lblAadharPath.Text) == false)
                {
                    Global.Message("File Is Not Exists To The Path");
                    return;
                }
            }
            catch (Exception ex)
            {
                General.ShowErrors(ex.ToString());
                return;
            }
        }
        private void btnPan_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog OpenDialog = new OpenFileDialog();
                if (OpenDialog.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                {
                    return;
                }
                lblPanPath.Text = OpenDialog.FileName;
                OpenDialog.Dispose();
                OpenDialog = null;

                if (File.Exists(lblPanPath.Text) == false)
                {
                    Global.Message("File Is Not Exists To The Path");
                    return;
                }
            }
            catch (Exception ex)
            {
                General.ShowErrors(ex.ToString());
                return;
            }
        }
        private void lblAadharPath_Click(object sender, EventArgs e)
        {
            //Global.CopyFormat(lblAadharPath.Text, txtPartyName.Text + "_AADHAR", Path.GetExtension(lblAadharPath.Text));
        }
        private void lblPanPath_Click(object sender, EventArgs e)
        {
            //Global.CopyFormat(lblPanPath.Text, txtPartyName.Text + "_PANCARD", Path.GetExtension(lblPanPath.Text));
        }
        private void btnAadharDownload_Click(object sender, EventArgs e)
        {
            try
            {
                btnAadharDownload.Tag = lblPanPath.Text;
                if (lblPanPath.Text != string.Empty)
                {
                    Global.CopyFormat(Convert.ToString(btnAadharDownload.Tag), txtPartyName.Text + "_AADHAR", Path.GetExtension(lblAadharPath.Text));
                }
                else
                {
                    Global.Message("File Is Not Exists To The Path");
                    return;
                }
            }
            catch (Exception ex)
            {
                General.ShowErrors(ex.ToString());
                return;
            }
        }
        private void btnPanDownload_Click(object sender, EventArgs e)
        {
            try
            {
                btnPanDownload.Tag = lblPanPath.Text;
                if (lblPanPath.Text != string.Empty)
                {
                    Global.CopyFormat(Convert.ToString(btnPanDownload.Tag), txtPartyName.Text + "_PANCARD", Path.GetExtension(lblPanPath.Text));
                }
                else
                {
                    Global.Message("File Is Not Exists To The Path");
                    return;
                }
            }
            catch (Exception ex)
            {
                General.ShowErrors(ex.ToString());
                return;
            }
        }

        #region GridEvents
        private void dgvPartyMaster_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                if (e.RowHandle >= 0)
                {
                    if (e.Clicks == 2)
                    {
                        DataRow Drow = dgvPartyMaster.GetDataRow(e.RowHandle);
                        lblMode.Text = "Edit Mode";
                        lblMode.Tag = Val.ToInt64(Drow["party_id"]);
                        txtPartyName.Text = Val.ToString(Drow["party_name"]);
                        Party_id = Val.ToInt64(objParty.FindPartyID(Val.ToString(Drow["party_name"])));
                        txtShortName.Text = Val.ToString(Drow["party_shortname"]);
                        txtFName.Text = Val.ToString(Drow["first_name"]);
                        txtLName.Text = Val.ToString(Drow["last_name"]);
                        lueInitName.Text = Val.ToString(Drow["init_name"]);
                        txtEmailID.Text = Val.ToString(Drow["primary_email"]);
                        lueBusinessType.Text = Val.ToString(Drow["business_type"]);
                        luePartyType.Text = Val.ToString(Drow["party_type"]);
                        lueManager.EditValue = Val.ToInt32(Drow["manager_id"]);
                        lueBroker.EditValue = Val.ToInt32(Drow["broker_id"]);
                        lueCountry.EditValue = Val.ToInt32(Drow["country_id"]);
                        lueState.EditValue = Val.ToInt32(Drow["state_id"]);
                        lueCity.EditValue = Val.ToInt32(Drow["city_id"]);
                        txtRemark.Text = Val.ToString(Drow["remarks"]);
                        chkActive.Checked = Val.ToBoolean(Drow["active"]);
                        txtZipCode.Text = Val.ToString(Drow["pincode"]);
                        txtAddress.Text = Val.ToString(Drow["address"]);
                        txtPhone1.Text = Val.ToString(Drow["phone1"]);
                        txtFaxNo.Text = Val.ToString(Drow["fax"]);
                        txtMobileNo.Text = Val.ToString(Drow["mobile1"]);
                        lueMobCountry.EditValue = Val.ToInt32(Drow["mobcountry_id"]);
                        txtWebsite.Text = Val.ToString(Drow["website"]);
                        luePhnCountry.EditValue = Val.ToInt32(Drow["phncountry_id"]);
                        luePhnCity.EditValue = Val.ToInt32(Drow["phncity_id"]);
                        txtSecEmail.Text = Val.ToString(Drow["secondary_email"]);
                        txtDiscount.Text = Val.ToString(Drow["discount"]);
                        lueCategory.EditValue = Val.ToInt32(Drow["category_id"]);
                        txtAadharNo.Text = Val.ToString(Drow["aadhar_no"]);
                        txtPanCardNo.Text = Val.ToString(Drow["pancard_no"]);
                        txtTdsCircle.Text = Val.ToString(Drow["tds_circle"]);
                        lueRegSource.Text = Val.ToString(Drow["registration_source"]);
                        txtSequenceNo.Text = Val.ToString(Drow["sequence_no"]);
                        txtSerTax.Text = Val.ToString(Drow["service_tax_no"]);
                        dtpSerTaxDate.Text = Val.DBDate(Val.ToString(Drow["service_tax_date"]));
                        txtVatNo.Text = Val.ToString(Drow["vat_no"]);
                        dtpVat.Text = Val.DBDate(Val.ToString(Drow["vat_date"]));
                        txtTANNo.Text = Val.ToString(Drow["tan_no"]);
                        dtpTANDate.Text = Val.DBDate(Val.ToString(Drow["tan_date"]));
                        txtGSTNo.Text = Val.ToString(Drow["gst_no"]);
                        dtpGSTDate.Text = Val.DBDate(Val.ToString(Drow["gst_date"]));
                        txtCSTNo.Text = Val.ToString(Drow["cst_no"]);
                        dtpCSTDate.Text = Val.DBDate(Val.ToString(Drow["cst_date"]));
                        lblAadharPath.Text = Val.ToString(Drow["aadhar_path"]);
                        lblPanPath.Text = Val.ToString(Drow["pancard_path"]);
                        m_OldAadharPath = Val.ToString(Drow["aadhar_path"]);
                        m_OldPanPath = Val.ToString(Drow["pancard_path"]);
                        txtQbc.Text = Val.ToString(Drow["qbc"]);
                        chkFactory.Checked = Val.ToBoolean(Drow["factory"]);
                        ChkISOutSide.Checked = Val.ToBoolean(Drow["is_outside"]);
                        ChkisAutoConfirm.Checked = Val.ToBoolean(Drow["is_autoconfirm"]);
                        chkIsRej.Checked = Val.ToBoolean(Drow["is_rejection"]);
                        chkIsImpExpParty.Checked = Val.ToBoolean(Drow["is_imp_exp_party"]);
                        lueIDProof.EditValue = Val.ToInt(Drow["idproof_id"]);
                        txtIDProofNo.Text = Val.ToString(Drow["idproof_no"]);
                        lueBrokerCategory.EditValue = Val.ToString(Drow["broker_category"]);
                        lueBehaviour.EditValue = Val.ToString(Drow["behavior"]);
                        txtPartyBusinessType.Text = Val.ToString(Drow["party_bussiness_type"]);
                        txtPartyName.Focus();
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
            //string appPath = Application.StartupPath.ToString();
            //ClassINI iniCl = new ClassINI(appPath + "\\DERP.CONFIG");

            //string gStrPath = System.Configuration.ConfigurationManager.AppSettings["ServerPath"].ToString(); //iniCl.IniReadValue("LOGIN", "ServerPath");
            //string pathString = System.IO.Path.Combine(gStrPath, "Party Document");
            //System.IO.Directory.CreateDirectory(pathString);
            string gStrPath = string.Empty;
            string pathString = string.Empty;
            string srcpathAadhar = lblAadharPath.Text;
            string srcpathPan = lblPanPath.Text;

            bool blnReturn = true;
            Party_MasterProperty PartyMasterProperty = new Party_MasterProperty();
            PartyMaster objParty = new PartyMaster();
            int IntRes = 0;
            try
            {
                if (!ValidateDetails())
                {
                    blnReturn = false;
                    return blnReturn;
                }

                if (lueIDProof.Text == "" || txtIDProofNo.Text == string.Empty)
                {
                    DialogResult result = MessageBox.Show("ID Proof Not Found Do you want to save Party?", "Confirmation", MessageBoxButtons.YesNoCancel);
                    if (result != DialogResult.Yes)
                    {
                        btnSave.Enabled = true;
                        return false;
                    }
                }


                PartyMasterProperty.party_id = Val.ToInt32(lblMode.Tag);
                PartyMasterProperty.party_name = Val.ToString(txtPartyName.Text).ToUpper();
                PartyMasterProperty.party_shortname = Val.ToString(txtShortName.Text).ToUpper();
                PartyMasterProperty.init_name = Val.ToString(lueInitName.EditValue).ToUpper();
                PartyMasterProperty.first_name = Val.ToString(txtFName.Text).ToUpper();
                PartyMasterProperty.last_name = Val.ToString(txtLName.Text).ToUpper();
                PartyMasterProperty.primary_email = Val.ToString(txtEmailID.Text).ToUpper();
                PartyMasterProperty.business_type = Val.ToString(lueBusinessType.EditValue).ToUpper();
                PartyMasterProperty.party_type = Val.ToString(luePartyType.EditValue).ToUpper();
                PartyMasterProperty.country_id = Val.ToInt32(lueCountry.EditValue) == 0 ? 1 : Val.ToInt32(lueCountry.EditValue);
                PartyMasterProperty.city_id = Val.ToInt32(lueCity.EditValue) == 0 ? 1 : Val.ToInt32(lueCity.EditValue);
                PartyMasterProperty.state_id = Val.ToInt32(lueState.EditValue) == 0 ? 6 : Val.ToInt32(lueState.EditValue);
                PartyMasterProperty.pincode = Val.ToString(txtZipCode.Text).ToUpper();
                PartyMasterProperty.remarks = Val.ToString(txtRemark.Text).ToUpper();
                PartyMasterProperty.active = Val.ToBoolean(chkActive.Checked);
                PartyMasterProperty.address = Val.ToString(txtAddress.Text).ToUpper();
                PartyMasterProperty.phone1 = Val.ToString(txtPhone1.Text).ToUpper();
                PartyMasterProperty.fax = Val.ToString(txtFaxNo.Text).ToUpper();
                PartyMasterProperty.mobile1 = Val.ToString(txtMobileNo.Text).ToUpper();
                PartyMasterProperty.mobile1country = Val.ToString(lueMobCountry.EditValue).ToUpper();
                PartyMasterProperty.website = Val.ToString(txtWebsite.Text).ToUpper();
                PartyMasterProperty.phone1country = Val.ToString(luePhnCountry.EditValue).ToUpper();
                PartyMasterProperty.phone1city = Val.ToString(luePhnCity.EditValue).ToUpper();
                PartyMasterProperty.secondary_email = Val.ToString(txtSecEmail.Text).ToUpper();
                PartyMasterProperty.discount = Val.ToInt32(txtDiscount.Text);
                PartyMasterProperty.category_id = Val.ToInt32(lueCategory.EditValue);
                PartyMasterProperty.aadhar_no = Val.ToString(txtAadharNo.Text).ToUpper();
                PartyMasterProperty.pancard_no = Val.ToString(txtPanCardNo.Text).ToUpper();
                PartyMasterProperty.tds_circle = Val.ToString(txtTdsCircle.Text).ToUpper();
                PartyMasterProperty.registration_source = Val.ToString(lueRegSource.EditValue).ToUpper();
                PartyMasterProperty.sequence_no = Val.ToInt32(txtSequenceNo.Text);
                PartyMasterProperty.service_tax_no = Val.ToString(txtSerTax.Text).ToUpper();
                PartyMasterProperty.service_tax_date = Val.DBDate(dtpSerTaxDate.Text).ToUpper();
                PartyMasterProperty.vat_no = Val.ToString(txtVatNo.Text).ToUpper();
                PartyMasterProperty.vat_date = Val.DBDate(dtpVat.Text).ToUpper();
                PartyMasterProperty.gst_no = Val.ToString(txtGSTNo.Text).ToUpper();
                PartyMasterProperty.gst_date = Val.DBDate(dtpGSTDate.Text).ToUpper();
                PartyMasterProperty.cst_no = Val.ToString(txtCSTNo.Text).ToUpper();
                PartyMasterProperty.cst_date = Val.DBDate(dtpCSTDate.Text).ToUpper();
                PartyMasterProperty.tan_no = Val.ToString(txtTANNo.Text).ToUpper();
                PartyMasterProperty.tan_date = Val.DBDate(dtpTANDate.Text).ToUpper();
                PartyMasterProperty.aadhar_path = Val.ToString(lblAadharPath.Text).ToUpper();
                PartyMasterProperty.pan_path = Val.ToString(lblPanPath.Text).ToUpper();
                PartyMasterProperty.qbc = Val.ToString(txtQbc.Text);
                PartyMasterProperty.factory = Val.ToBoolean(chkFactory.Checked);
                PartyMasterProperty.is_outside = Val.ToBoolean(ChkISOutSide.Checked);
                PartyMasterProperty.is_autoconfirm = Val.ToBoolean(ChkisAutoConfirm.Checked);
                PartyMasterProperty.is_rejection = Val.ToBoolean(chkIsRej.Checked);
                PartyMasterProperty.is_imp_exp_party = Val.ToBoolean(chkIsImpExpParty.Checked);
                PartyMasterProperty.broker_id = Val.ToInt32(lueBroker.EditValue);
                PartyMasterProperty.manager_id = Val.ToInt32(lueManager.EditValue);

                PartyMasterProperty.IDProof_ID = Val.ToInt32(lueIDProof.EditValue);
                PartyMasterProperty.IDProof_No = Val.ToString(txtIDProofNo.Text).ToUpper();
                PartyMasterProperty.broker_category = Val.ToString(lueBrokerCategory.EditValue);
                PartyMasterProperty.behavior = Val.ToString(lueBehaviour.EditValue);
                PartyMasterProperty.party_bussiness_type = Val.ToString(txtPartyBusinessType.Text).ToUpper();
                DataTable p_dtbPartyId = new DataTable();


                p_dtbPartyId = objParty.Save(PartyMasterProperty, Party_id);
                if (p_dtbPartyId.Rows.Count > 0 && (Convert.ToString(srcpathAadhar) != string.Empty || Convert.ToString(srcpathPan) != string.Empty))
                {
                    PartyMasterProperty.party_id = Convert.ToInt32(p_dtbPartyId.Rows[0][0]);
                    if (Convert.ToString(srcpathAadhar) != string.Empty)
                    {
                        PartyMasterProperty.aadhar_path = pathString + "\\" + PartyMasterProperty.party_id + "_AADHAR" + Path.GetExtension(srcpathAadhar);
                    }
                    if (Convert.ToString(srcpathPan) != string.Empty)
                    {
                        PartyMasterProperty.pan_path = pathString + "\\" + PartyMasterProperty.party_id + "_PANCARD" + Path.GetExtension(srcpathPan);
                    }
                    IntRes = objParty.Update(PartyMasterProperty);
                }
                else
                {
                    if (Val.ToInt(lblMode.Tag) > 0)
                    {

                        if (string.Equals(m_OldAadharPath, Val.ToString(lblAadharPath.Text)) == false)
                        {
                            PartyMasterProperty.aadhar_path = null;

                            File.Delete(pathString + "\\" + PartyMasterProperty.party_id + "_AADHAR" + Path.GetExtension(m_OldAadharPath));
                            PartyMasterProperty.party_id = Convert.ToInt32(Val.ToInt(lblMode.Tag));
                            if (Convert.ToString(srcpathAadhar) != string.Empty)
                            {
                                PartyMasterProperty.aadhar_path = pathString + "\\" + PartyMasterProperty.party_id + "_AADHAR" + Path.GetExtension(srcpathAadhar);
                            }


                        }
                        if (string.Equals(m_OldPanPath, Val.ToString(lblPanPath.Text)) == false)
                        {
                            PartyMasterProperty.pan_path = null;
                            File.Delete(pathString + "\\" + PartyMasterProperty.party_id + "_PANCARD" + Path.GetExtension(m_OldPanPath));
                            if (Convert.ToString(srcpathPan) != string.Empty)
                            {
                                PartyMasterProperty.pan_path = pathString + "\\" + PartyMasterProperty.party_id + "_PANCARD" + Path.GetExtension(srcpathPan);
                            }
                        }
                        IntRes = objParty.Update(PartyMasterProperty);
                    }
                }

                if (IntRes == -1)
                {
                    Global.Confirm("Error In Save Party Details");
                    TabRegisterDetail.SelectedTabPageIndex = 0;
                    txtPartyName.Focus();
                }
                else
                {
                    if (Val.ToInt(lblMode.Tag) == 0)
                    {
                        if (srcpathAadhar != string.Empty)
                        {
                            File.Copy(srcpathAadhar, pathString + "\\" + PartyMasterProperty.party_id + "_AADHAR" + Path.GetExtension(srcpathAadhar));
                        }
                        if (srcpathPan != string.Empty)
                        {
                            File.Copy(srcpathPan, pathString + "\\" + PartyMasterProperty.party_id + "_PANCARD" + Path.GetExtension(srcpathPan));
                        }
                        Global.Confirm("Party Details Data Save Successfully");
                        TabRegisterDetail.SelectedTabPageIndex = 0;
                        txtPartyName.Focus();
                    }
                    else
                    {
                        if (string.Equals(m_OldAadharPath, Val.ToString(lblAadharPath.Text)) == false)
                        {
                            if (srcpathAadhar != string.Empty)
                            {
                                File.Copy(srcpathAadhar, pathString + "\\" + PartyMasterProperty.party_id + "_AADHAR" + Path.GetExtension(srcpathAadhar));
                            }

                        }
                        if (string.Equals(m_OldPanPath, Val.ToString(lblPanPath.Text)) == false)
                        {
                            if (srcpathPan != string.Empty)
                            {
                                File.Copy(srcpathPan, pathString + "\\" + PartyMasterProperty.party_id + "_PANCARD" + Path.GetExtension(srcpathPan));
                            }
                        }
                        Global.Confirm("Party Details Data Update Successfully");
                        TabRegisterDetail.SelectedTabPageIndex = 0;
                        txtPartyName.Focus();
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
                PartyMasterProperty = null;
            }

            return blnReturn;
        }
        private bool ValidateDetails()
        {
            bool blnFocus = false;
            List<ListError> lstError = new List<ListError>();
            try
            {
                if (txtPartyName.Text == string.Empty)
                {
                    lstError.Add(new ListError(12, "Party Name"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                        txtPartyName.Focus();
                    }
                }

                if (GlobalDec.gEmployeeProperty.role_name != "SURAT ROUGH")
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
                }

                if (!objParty.ISExists(txtPartyName.Text, Val.ToInt64(lblMode.Tag)).ToString().Trim().Equals(string.Empty))
                {
                    lstError.Add(new ListError(23, "Party Name"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                        txtPartyName.Focus();
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
                DTab = objParty.GetData();
                grdPartyMaster.DataSource = DTab;
                dgvPartyMaster.BestFitColumns();
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
                            dgvPartyMaster.ExportToPdf(Filepath);
                            break;
                        case "xls":
                            dgvPartyMaster.ExportToXls(Filepath);
                            break;
                        case "xlsx":
                            dgvPartyMaster.ExportToXlsx(Filepath);
                            break;
                        case "rtf":
                            dgvPartyMaster.ExportToRtf(Filepath);
                            break;
                        case "txt":
                            dgvPartyMaster.ExportToText(Filepath);
                            break;
                        case "html":
                            dgvPartyMaster.ExportToHtml(Filepath);
                            break;
                        case "csv":
                            dgvPartyMaster.ExportToCsv(Filepath);
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
