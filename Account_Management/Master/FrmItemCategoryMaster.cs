using BLL.FunctionClasses.Master;
using BLL.PropertyClasses.Master;
using Account_Management.Class;
using System;
using System.Data;

namespace Account_Management.Master
{
    public partial class FrmItemCategoryMaster : DevExpress.XtraEditors.XtraForm
    {
        BLL.FormEvents objBOFormEvents = new BLL.FormEvents();
        BLL.Validation Val = new BLL.Validation();
        ItemCategoryMaster objAccountCat = new ItemCategoryMaster();

        public FrmItemCategoryMaster()
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
            txtItemCategoryCode.Text = "0";
            txtItemCategoryName.Text = "";
            txtRemark.Text = "";
            RbtnConsumable.SelectedIndex = 0;
            RbtnRepairable.SelectedIndex = 0;
            RBtnStatus.SelectedIndex = 0;
            txtItemCategoryName.Focus();
        }

        #region Validation

        private bool ValSave()
        {
            if (txtItemCategoryName.Text.Length == 0)
            {
                Global.Confirm("Item Category Name Is Required");
                txtItemCategoryName.Focus();
                return false;
            }
            if (!objAccountCat.ISExists(txtItemCategoryName.Text, Val.ToInt64(txtItemCategoryCode.EditValue)).ToString().Trim().Equals(string.Empty))
            {
                Global.Confirm("Item Category Name Already Exist.");
                txtItemCategoryName.Focus();
                txtItemCategoryName.SelectAll();
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

            Item_Category_MasterProperty Account_Item_Category_MasterProperty = new Item_Category_MasterProperty();
            int Code = Val.ToInt(txtItemCategoryCode.Text);
            Account_Item_Category_MasterProperty.item_category_id = Val.ToInt64(Code);
            Account_Item_Category_MasterProperty.item_category_name = txtItemCategoryName.Text;
            Account_Item_Category_MasterProperty.remark = txtRemark.Text;
            Account_Item_Category_MasterProperty.active = Val.ToInt(RBtnStatus.Text);
            Account_Item_Category_MasterProperty.is_consumable = Val.ToInt(RbtnConsumable.Text);
            Account_Item_Category_MasterProperty.is_repairable = Val.ToInt(RbtnRepairable.Text);

            int IntRes = objAccountCat.Save(Account_Item_Category_MasterProperty);
            if (IntRes == -1)
            {
                Global.Confirm("Error In Save Item Category Master Data");
                txtItemCategoryName.Focus();
            }
            else
            {
                if (Code == 0)
                {
                    Global.Confirm("Item Category Master Data Save Successfully");
                }
                else
                {
                    Global.Confirm("Item Category Master Data Update Successfully");
                }

                GetData();
                btnClear_Click(sender, e);
            }
            Account_Item_Category_MasterProperty = null;
        }

        public void GetData()
        {
            DataTable DTab = objAccountCat.GetData_Search();
            grdItemCategoryMaster.DataSource = DTab;
        }

        private void FrmCountryMaster_Load(object sender, EventArgs e)
        {
            GetData();
            btnClear_Click(btnClear, null);
        }

        private void dgvItemCategoryMaster_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (e.Clicks == 2)
                {
                    DataRow Drow = dgvItemCategoryMaster.GetDataRow(e.RowHandle);
                    txtItemCategoryCode.Text = Convert.ToString(Drow["item_category_id"]);
                    txtItemCategoryName.Text = Convert.ToString(Drow["item_category_name"]);
                    RBtnStatus.EditValue = Convert.ToInt32(Drow["active"]);
                    RbtnConsumable.EditValue = Convert.ToInt32(Drow["is_consumable"]);
                    RbtnRepairable.EditValue = Convert.ToInt32(Drow["is_repairable"]);
                    txtRemark.Text = Convert.ToString(Drow["remark"]);
                    txtItemCategoryName.Focus();
                }
            }
        }
    }
}
