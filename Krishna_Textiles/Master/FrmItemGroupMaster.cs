using BLL.FunctionClasses.Master;
using BLL.PropertyClasses.Master;
using Krishna_Textiles.Class;
using System;
using System.Data;
using System.Windows.Forms;

namespace Krishna_Textiles.Master
{
    public partial class FrmItemGroupMaster : DevExpress.XtraEditors.XtraForm
    {
        BLL.FormEvents objBOFormEvents = new BLL.FormEvents();
        BLL.Validation Val = new BLL.Validation();
        ItemGroupMaster ObjItemGroup = new ItemGroupMaster();

        public FrmItemGroupMaster()
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
            txtItemGroupCode.Text = "0";
            txtItemGroupName.Text = "";
            txtRemark.Text = "";
            RBtnStatus.SelectedIndex = 0;
            txtItemGroupName.Focus();
        }

        #region Validation

        private bool ValSave()
        {
            if (txtItemGroupName.Text.Length == 0)
            {
                Global.Confirm("Item Group Name Is Required");
                txtItemGroupName.Focus();
                return false;
            }
            if (!ObjItemGroup.ISExists(txtItemGroupName.Text, Val.ToInt64(txtItemGroupCode.EditValue)).ToString().Trim().Equals(string.Empty))
            {
                Global.Confirm("Item Group Name Already Exist.");
                txtItemGroupName.Focus();
                txtItemGroupName.SelectAll();
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

            Item_Group_MasterProperty AccountIteamGroupMasterProperty = new Item_Group_MasterProperty();
            int Code = Val.ToInt(txtItemGroupCode.Text);
            AccountIteamGroupMasterProperty.item_group_id = Val.ToInt64(Code);
            AccountIteamGroupMasterProperty.item_group_name = txtItemGroupName.Text;
            AccountIteamGroupMasterProperty.remark = txtRemark.Text;
            AccountIteamGroupMasterProperty.active = Val.ToInt(RBtnStatus.Text);

            int IntRes = ObjItemGroup.Save(AccountIteamGroupMasterProperty);
            if (IntRes == -1)
            {
                Global.Confirm("Error In Save Item Group Master Data");
                txtItemGroupName.Focus();
            }
            else
            {
                if (Code == 0)
                {
                    Global.Confirm("Item Group Master Data Save Successfully");
                }
                else
                {
                    Global.Confirm("Item Group Master Data Update Successfully");
                }

                GetData();
                btnClear_Click(sender, e);
            }
            AccountIteamGroupMasterProperty = null;
        }

        public void GetData()
        {
            DataTable DTab = ObjItemGroup.GetData_Search();
            grdItemGroupMaster.DataSource = DTab;
        }

        private void FrmCountryMaster_Load(object sender, EventArgs e)
        {
            GetData();
            btnClear_Click(btnClear, null);
        }

        private void dgvItemGroupMaster_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (e.Clicks == 2)
                {
                    DataRow Drow = dgvItemGroupMaster.GetDataRow(e.RowHandle);
                    txtItemGroupCode.Text = Convert.ToString(Drow["item_group_id"]);
                    txtItemGroupName.Text = Convert.ToString(Drow["item_group_name"]);
                    RBtnStatus.EditValue = Convert.ToInt32(Drow["active"]);
                    txtRemark.Text = Convert.ToString(Drow["remark"]);
                }
            }
        }
    }
}
