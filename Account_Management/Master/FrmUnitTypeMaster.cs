using Account_Management.Class;
using BLL.FunctionClasses.Master;
using BLL.PropertyClasses.Master;
using System;
using System.Data;

namespace Account_Management.Master
{
    public partial class FrmUnitTypeMaster : DevExpress.XtraEditors.XtraForm
    {
        BLL.FormEvents objBOFormEvents = new BLL.FormEvents();
        BLL.Validation Val = new BLL.Validation();
        UnitTypeMaster objUnitType = new UnitTypeMaster();

        public FrmUnitTypeMaster()
        {
            InitializeComponent();
        }
        public void ShowForm()
        {
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
            //objBOFormEvents.ObjToDispose.Add(ObjGroup);
            objBOFormEvents.ObjToDispose.Add(Val);
            objBOFormEvents.ObjToDispose.Add(objBOFormEvents);
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUnitTypeCode.Text = "0";
            txtUnitTypeName.Text = "";
            txtRemark.Text = "";
            RBtnStatus.SelectedIndex = 0;
            txtUnitTypeName.Focus();
        }

        #region Validation

        private bool ValSave()
        {
            if (txtUnitTypeName.Text.Length == 0)
            {
                Global.Confirm("Unit Name Is Required");
                txtUnitTypeName.Focus();
                return false;
            }
            if (!objUnitType.ISExists(txtUnitTypeName.Text, Val.ToInt64(txtUnitTypeCode.EditValue)).ToString().Trim().Equals(string.Empty))
            {
                Global.Confirm("Unit Name Already Exist.");
                txtUnitTypeName.Focus();
                txtUnitTypeName.SelectAll();
                return false;
            }
            return true;
        }

        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValSave() == false)
            {
                return;
            }

            UnitType_MasterProperty UnitTypeMasterProperty = new UnitType_MasterProperty();
            int Code = Val.ToInt(txtUnitTypeCode.Text);
            UnitTypeMasterProperty.unit_id = Val.ToInt64(Code);
            UnitTypeMasterProperty.unit_name = txtUnitTypeName.Text;
            UnitTypeMasterProperty.active = Val.ToInt(RBtnStatus.Text);
            UnitTypeMasterProperty.remark = txtRemark.Text;

            int IntRes = objUnitType.Save(UnitTypeMasterProperty);
            if (IntRes == -1)
            {
                Global.Confirm("Error In Save Unit Type Details");
                txtUnitTypeName.Focus();
            }
            else
            {
                if (Code == 0)
                {
                    Global.Confirm("Unit Type Details Data Save Successfully");
                }
                else
                {
                    Global.Confirm("Unit Type Details Data Update Successfully");
                }
                GetData();
                btnClear_Click(sender, e);
            }
            UnitTypeMasterProperty = null;
        }
        public void GetData()
        {
            DataTable DTab = objUnitType.GetData_Search();
            grdUnitTypeMaster.DataSource = DTab;
        }
        private void FrmCountryMaster_Load(object sender, EventArgs e)
        {
            GetData();
            btnClear_Click(btnClear, null);
        }
        private void dgvUnitTypeMaster_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (e.Clicks == 2)
                {
                    DataRow Drow = dgvUnitTypeMaster.GetDataRow(e.RowHandle);
                    txtUnitTypeCode.Text = Convert.ToString(Drow["unit_id"]);
                    txtUnitTypeName.Text = Convert.ToString(Drow["unit_name"]);
                    RBtnStatus.EditValue = Convert.ToInt32(Drow["active"]);
                    txtRemark.Text = Convert.ToString(Drow["remark"]);
                    txtUnitTypeName.Focus();
                }
            }
        }
    }
}
