using BLL;
using BLL.FunctionClasses.Master;
using BLL.PropertyClasses.Master;
using Account_Management.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Account_Management.Master
{
    public partial class FrmConfigRoleMaster : DevExpress.XtraEditors.XtraForm
    {
        #region Data Member

        FormEvents objBOFormEvents;
        Validation Val;
        BLL.FormPer ObjPer;

        ConfigRoleMaster objConfigRole;
        List<Task> tList = new List<Task>();

        #endregion

        #region Constructor
        public FrmConfigRoleMaster()
        {
            InitializeComponent();

            objBOFormEvents = new FormEvents();
            Val = new Validation();
            ObjPer = new BLL.FormPer();

            objConfigRole = new ConfigRoleMaster();
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
            objBOFormEvents.ObjToDispose.Add(objConfigRole);
            objBOFormEvents.ObjToDispose.Add(Val);
            objBOFormEvents.ObjToDispose.Add(objBOFormEvents);
        }

        #endregion

        #region Events
        private void FrmConfigRoleMaster_Load(object sender, EventArgs e)
        {
            try
            {
                Task.Run(() => GetData());
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
                txtRoleName.Text = "";
                cmbRoleType.Text = "";
                chkActive.Checked = false;
                txtRoleName.Focus();
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

        #region GridEvents
        private void dgvRoleMaster_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            try
            {
                if (e.RowHandle >= 0)
                {
                    if (e.Clicks == 2)
                    {
                        DataRow Drow = dgvRoleMaster.GetDataRow(e.RowHandle);
                        lblMode.Text = "Edit Mode";
                        lblMode.Tag = Val.ToInt32(Drow["role_id"]);
                        txtRoleName.Text = Val.ToString(Drow["role_name"]);
                        cmbRoleType.Text = Val.ToString(Drow["role_type"]);
                        chkActive.Checked = Val.ToBoolean(Drow["active"]);
                        txtRoleName.Focus();
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
                if (txtRoleName.Text == string.Empty)
                {
                    lstError.Add(new ListError(12, "Role Name"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                        txtRoleName.Focus();
                    }
                }
                if (cmbRoleType.Text == string.Empty)
                {
                    lstError.Add(new ListError(12, "Role Type"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                        cmbRoleType.Focus();
                    }
                }

                if (!objConfigRole.ISExists(txtRoleName.Text, cmbRoleType.Text, Val.ToInt64(lblMode.Tag)).ToString().Trim().Equals(string.Empty))
                {
                    lstError.Add(new ListError(23, "Role Name"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                        txtRoleName.Focus();
                    }

                }

            }
            catch (Exception ex)
            {
                lstError.Add(new ListError(ex));
            }
            return (!(BLL.General.ShowErrors(lstError)));

        }
        private bool SaveDetails()
        {
            bool blnReturn = true;
            ConfigRole_MasterProperty ConfigRoleMasterProperty = new ConfigRole_MasterProperty();
            ConfigRoleMaster objConfigRole = new ConfigRoleMaster();

            try
            {
                if (!ValidateDetails())
                {
                    blnReturn = false;
                    return blnReturn;
                }


                ConfigRoleMasterProperty.role_id = Val.ToInt32(lblMode.Tag);
                ConfigRoleMasterProperty.role_name = txtRoleName.Text.ToUpper();
                ConfigRoleMasterProperty.active = Val.ToBoolean(chkActive.Checked);
                ConfigRoleMasterProperty.role_type = Val.ToString(cmbRoleType.Text);

                int IntRes = objConfigRole.Save_Role(ConfigRoleMasterProperty);
                if (IntRes == -1)
                {
                    Global.Confirm("Error In Save Role Details");
                    txtRoleName.Focus();
                }
                else
                {
                    if (Val.ToInt(lblMode.Tag) == 0)
                    {
                        Global.Confirm("Role Details Data Save Successfully");
                    }
                    else
                    {
                        Global.Confirm("Role Details Data Update Successfully");
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
                ConfigRoleMasterProperty = null;
            }

            return blnReturn;
        }
        public void GetData()
        {
            try
            {
                DataTable DTab = objConfigRole.GetData();
                grdRoleMaster.InvokeEx(t =>
                {
                    t.DataSource = DTab;
                    dgvRoleMaster.BestFitColumns();
                });
            }
            catch (Exception ex)
            {
                General.ShowErrors(ex.ToString());
                return;
            }
        }

        #endregion
    }
}
