using BLL;
using BLL.FunctionClasses.Master;
using BLL.PropertyClasses.Master;
using Krishna_Textiles.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Krishna_Textiles.Master
{
    public partial class FrmPreferenceMaster : DevExpress.XtraEditors.XtraForm
    {
        #region Data Member

        FormEvents objBOFormEvents;
        Validation Val;
        BLL.FormPer ObjPer;

        PreferenceMaster objPrefer;
        List<Task> tList = new List<Task>();

        int m_IntRes;

        bool blnReturn;
        #endregion

        #region Constructor
        public FrmPreferenceMaster()
        {
            InitializeComponent();

            objBOFormEvents = new FormEvents();
            Val = new Validation();
            ObjPer = new BLL.FormPer();

            objPrefer = new PreferenceMaster();

            m_IntRes = 0;

            blnReturn = true;
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
            objBOFormEvents.ObjToDispose.Add(objPrefer);
            objBOFormEvents.ObjToDispose.Add(Val);
            objBOFormEvents.ObjToDispose.Add(objBOFormEvents);
        }
        #endregion

        #region Events
        private void FrmPreferenceMaster_Load(object sender, EventArgs e)
        {
            try
            {
                Task.Run(() => Global.LOOKUPUser(lueUser));
                Task.Run(() => GetData());
                lueUser.Focus();
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
                lueDRateType.EditValue = null;
                lueDCurrency.EditValue = null;
                lueSecCurrency.EditValue = null;
                lueDeliveryType.EditValue = null;
                txtAmount.Text = "";
                txtPercent.Text = "";
                txtRate.Text = "";
                txtWeight.Text = "";
                lueUser.EditValue = null;
                lueUser.Focus();
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
        private void lueUser_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                int user_id = Val.ToInt32(lueUser.EditValue);
                getUserPreference(user_id);
            }
            catch (Exception ex)
            {
                General.ShowErrors(ex.ToString());
                return;
            }
        }
        #endregion

        #region Functions
        private bool SaveDetails()
        {
            bool blnReturn = true;
            Preference_MasterProperty PreferProperty = new Preference_MasterProperty();

            try
            {
                if (!ValidateDetails())
                {
                    blnReturn = false;
                    return blnReturn;
                }
                PreferProperty.user_id = Val.ToInt32(lueUser.EditValue);
                PreferProperty.default_rate_type_id = Val.ToInt32(lueDRateType.EditValue);
                PreferProperty.default_currency_id = Val.ToInt32(lueDCurrency.EditValue);
                PreferProperty.secondary_currency_id = Val.ToInt32(lueSecCurrency.EditValue);
                PreferProperty.format_rate = Val.ToString(txtRate.Text).ToUpper();
                PreferProperty.format_amount = Val.ToString(txtAmount.Text).ToUpper();
                PreferProperty.format_percent = Val.ToString(txtPercent.Text).ToUpper();
                PreferProperty.format_weight = Val.ToString(txtWeight.Text);
                PreferProperty.delivery_type_id = Val.ToInt(lueDeliveryType.EditValue);
                int IntRes = objPrefer.Save(PreferProperty);
                if (m_IntRes == -1)
                {
                    Global.Confirm("Error In Save User Preference");
                    lueUser.Focus();
                }
                else
                {
                    if (Val.ToInt(lblMode.Tag) == 0)
                    {
                        Global.Confirm("User Preference Data Save Successfully");
                    }
                    else
                    {
                        Global.Confirm("User Preference Data Update Successfully");
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
                PreferProperty = null;
            }

            return blnReturn;
        }
        private bool ValidateDetails()
        {
            bool blnFocus = false;
            List<ListError> lstError = new List<ListError>();
            try
            {
                if (lueUser.ItemIndex < 0)
                {
                    lstError.Add(new ListError(13, "User Name"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                        lueUser.Focus();
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
                DataTable DTab = objPrefer.GetData();
            }
            catch (Exception ex)
            {
                General.ShowErrors(ex.ToString());
                return;
            }
        }
        public void getUserPreference(int p_UserID)
        {

            try
            {
                if (Val.Val(p_UserID) == 0)
                {
                    return;
                }
                if (p_UserID > 0)
                {
                    DataTable DTab = objPrefer.GetPreferData(p_UserID);
                    if (DTab.Rows.Count > 0)
                    {
                        lblMode.Text = "Edit Mode";
                        lblMode.Tag = Val.ToInt64(DTab.Rows[0]["user_id"]);
                        //txtUName.Text = Val.ToString(DTab.Rows[0]["user_name"]);
                        lueUser.Tag = Val.ToInt64(DTab.Rows[0]["user_id"]);
                        lueDRateType.EditValue = Val.ToInt32(DTab.Rows[0]["default_rate_type_id"]);
                        lueDCurrency.EditValue = Val.ToInt32(DTab.Rows[0]["dcurrency_id"]);
                        lueSecCurrency.EditValue = Val.ToInt32(DTab.Rows[0]["scurrency_id"]);
                        txtWeight.Text = Val.ToString(DTab.Rows[0]["format_weight"]);
                        txtPercent.Text = Val.ToString(DTab.Rows[0]["format_percent"]);
                        txtAmount.Text = Val.ToString(DTab.Rows[0]["format_amount"]);
                        txtRate.Text = Val.ToString(DTab.Rows[0]["format_rate"]);
                        lueDeliveryType.EditValue = Val.ToInt(DTab.Rows[0]["delivery_type_id"]);
                    }

                }
            }
            catch (Exception ex)
            {
                General.ShowErrors(ex.ToString());
                blnReturn = false;
            }
        }
        #endregion


    }
}
