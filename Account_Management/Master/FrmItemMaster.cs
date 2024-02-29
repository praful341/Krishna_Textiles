using Account_Management.Class;
using BLL.FunctionClasses.Master;
using BLL.PropertyClasses.Master;
using System;
using System.Data;
using System.Windows.Forms;

namespace Account_Management.Master
{
    public partial class FrmItemMaster : DevExpress.XtraEditors.XtraForm
    {
        BLL.FormEvents objBOFormEvents = new BLL.FormEvents();

        BLL.Validation Val = new BLL.Validation();
        CountryMaster objCountry = new CountryMaster();
        StateMaster objState = new StateMaster();
        CityMaster objCity = new CityMaster();
        CompanyMaster objCompany = new CompanyMaster();
        ItemMaster ObjItem = new ItemMaster();

        public FrmItemMaster()
        {
            InitializeComponent();
        }

        public void ShowForm()
        {
            Val.frmGenSet(this);
            AttachFormEvents();
            this.Show();
            GetData();
            btnClear_Click(btnClear, null);
        }

        private void GetData()
        {
            ObjItem.GetData();
            MainGrdItemMaster.DataSource = ObjItem.DTab;
            MainGrdItemMaster.RefreshDataSource();
            GrdDetItemMaster.BestFitColumns();
            // GetItemDetail();
        }

        private void AttachFormEvents()
        {
            objBOFormEvents.CurForm = this;
            objBOFormEvents.FormKeyPress = true;
            objBOFormEvents.FormKeyDown = true;
            objBOFormEvents.FormResize = true;
            objBOFormEvents.FormClosing = true;
            objBOFormEvents.ObjToDispose.Add(Val);
            objBOFormEvents.ObjToDispose.Add(objBOFormEvents);
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtItemCode.Text = "0";
            txtItemName.Text = "";
            txtRemark.Text = "";
            lookUpCategoryName.EditValue = null;
            LookupItemGroup.EditValue = null;
            txtLastPurchase.Text = "";
            txtItemCodification.Text = "";
            txtShortName.Text = "";
            CmbUnitType.EditValue = null;
            RbtStatus.SelectedIndex = 0;
            txtDiscPer.Text = "";

            LookupCompany.EditValue = null;
            LookupBranch.EditValue = null;
            LookupLocation.EditValue = null;
            LookupHSNCode.EditValue = null;

            dgvItemGrid.DataSource = null;
            dgvOpeningStock.DataSource = null;
            // GetItemDetail();
            TabRegisterDetail.SelectedTabPageIndex = 0;
            txtItemName.Focus();
            txtSaleRate.Text = string.Empty;
            txtStockLimit.Text = string.Empty;
            txtPCSInBox.Text = string.Empty;
        }

        #region Validation

        private bool ValSave()
        {
            if (txtItemName.Text.Length == 0)
            {
                Global.Confirm("Item Name Is Required");
                txtItemName.Focus();
                return false;
            }
            if (!ObjItem.ISExists(txtItemName.Text, Val.ToInt(txtItemCode.Text)).ToString().Trim().Equals(string.Empty))
            {
                Global.Confirm("Item Name Already Exist.");
                txtItemName.Focus();
                txtItemName.SelectAll();
                return false;
            }

            //if (LookupItemGroup.EditValue == null)
            //{
            //    Global.Confirm("Item Group Name Is Required");
            //    LookupItemGroup.Focus();
            //    return false;
            //}

            //if (lookUpCategoryName.EditValue == null)
            //{
            //    Global.Confirm("Item Category Name Is Required");
            //    lookUpCategoryName.Focus();
            //    return false;
            //}

            //if (txtItemCodification.Text.Length == 0)
            //{
            //    Global.Confirm("Item Codification Is Required");
            //    txtItemCodification.Focus();
            //    return false;
            //}

            //if (CmbUnitType.Text.Length == 0 || CmbUnitType.Text.ToString() == "SELECT")
            //{
            //    Global.Confirm("Unit Type Is Required");
            //    CmbUnitType.Focus();
            //    return false;
            //}
            return true;
        }

        private bool ValDuplicate()
        {
            System.Data.DataTable DTab = (System.Data.DataTable)dgvOpeningStock.DataSource;
            DTab.AcceptChanges();
            int j = 0;
            foreach (DataRow DRowMain in DTab.Rows)
            {
                if (Val.Val(DRowMain["QUANTITY"]) == 0)
                {
                    continue;
                }
                j = j + 1;
                int i = 0;
                foreach (DataRow DRow in DTab.Rows)
                {
                    i = i + 1;
                    if (i != j
                        && Val.ToInt64(DRow["COMPANY_CODE"]) == Val.ToInt64(DRowMain["COMPANY_CODE"])
                        && Val.ToInt64(DRow["BRANCH_CODE"]) == Val.ToInt64(DRowMain["BRANCH_CODE"])
                        && Val.ToInt64(DRow["LOCATION_CODE"]) == Val.ToInt64(DRowMain["LOCATION_CODE"])
                        )
                    {
                        Global.Confirm("Row : " + i.ToString() + " Company-Branch-Location Already Exists In Previous Record");
                        TabRegisterDetail.SelectedTabPageIndex = 1;
                        GrdOpeningStock.FocusedRowHandle = i;
                        GrdOpeningStock.FocusedColumn = GrdOpeningStock.Columns["COMPANY_CODE"];
                        GrdOpeningStock.ShowEditor();
                        GrdOpeningStock.Focus();
                        return false;
                    }
                }
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
            Item_MasterProperty ItemMasterProperty = new Item_MasterProperty();

            ItemMasterProperty.item_id = Val.ToInt(txtItemCode.Text);
            ItemMasterProperty.item_id = Val.ToInt64(txtItemCode.EditValue);
            ItemMasterProperty.item_name = txtItemName.Text;
            ItemMasterProperty.item_shortname = Val.ToString(txtShortName.Text);
            ItemMasterProperty.item_group_id = Val.ToInt64(LookupItemGroup.EditValue);
            ItemMasterProperty.active = Val.ToInt(RbtStatus.Text);
            ItemMasterProperty.remark = txtRemark.Text;
            ItemMasterProperty.unit_id = Val.ToInt64(CmbUnitType.EditValue);
            ItemMasterProperty.last_purchase_rate = Val.ToDecimal(txtLastPurchase.Text);
            ItemMasterProperty.hsn_id = Val.ToInt64(LookupHSNCode.EditValue);
            ItemMasterProperty.sale_rate = Val.ToDecimal(txtSaleRate.Text);

            int IntRes = ObjItem.SaveItem(ItemMasterProperty);

            ItemMasterProperty = null;
            if (IntRes != 0)
            {
                Global.Message("Item Is Saved Successfully");
                btnClear_Click(sender, e);
                GetData();
            }
            else
            {
                Global.Message("Erro In Item Save");
            }
        }
        private void LookupItemGroup_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmItemGroupMaster frmCnt = new FrmItemGroupMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPItemGroup(LookupItemGroup);
            }
        }
        private void LookupCategory_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmItemCategoryMaster frmCnt = new FrmItemCategoryMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPItemCategory(lookUpCategoryName);
            }
        }
        private void LookupCompany_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmCompanyMaster frmCnt = new FrmCompanyMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPCompany(LookupCompany);
            }
        }
        private void LookupBranch_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmBranchMaster frmCnt = new FrmBranchMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPBranch(LookupBranch);
            }
        }
        private void LookupLocation_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmLocationMaster frmCnt = new FrmLocationMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPLocation(LookupLocation);
            }
        }
        private void FrmItemMaster_Shown(object sender, EventArgs e)
        {
            GetData();

            Global.LOOKUPItemGroup(LookupItemGroup);
            Global.LOOKUPItemCategory(lookUpCategoryName);
            Global.LOOKUPCompany(LookupCompany);
            Global.LOOKUPLocation(LookupLocation);
            Global.LOOKUPBranch(LookupBranch);
            //Global.LOOKUPCompanyRep(LookUpRepCompany);
            Global.LOOKUPItemHSN(LookupHSNCode);
            Global.LOOKUPUnitType(CmbUnitType);
            txtItemName.Focus();
        }

        //private void GetItemDetail()
        //{
        //    this.Cursor = Cursors.WaitCursor;
        //    //dgvOpeningStock.DataSource = null;
        //    //DataTable DTab = ObjItem.GetItemOpeningDetail(Val.ToInt(txtItemCode.Text));

        //    //dgvOpeningStock.DataSource = DTab;

        //    ObjItem = new ItemMaster();
        //    DataTable DTab1 = ObjItem.GetItemDetail(Val.ToInt(txtItemCode.Text));

        //    dgvItemGrid.DataSource = DTab1;

        //    this.Cursor = Cursors.Default;
        //}
        //private void LookUpRepCompany_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        //{
        //    //if (e.Button.Index == 1)
        //    //{
        //    //    FrmCompanyMaster frmCnt = new FrmCompanyMaster();
        //    //    frmCnt.ShowDialog();
        //    //    Global.LOOKUPCompanyRep(LookUpRepCompany);
        //    //}
        //}
        private void GrdDetItemMaster_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (e.Clicks == 2)
                {
                    DataRow DRow = GrdDetItemMaster.GetDataRow(e.RowHandle);

                    txtItemCode.Text = Val.ToString(DRow["item_id"]);
                    txtItemName.Text = Val.ToString(DRow["item_name"]);
                    txtShortName.Text = Val.ToString(DRow["item_shortname"]);
                    LookupItemGroup.EditValue = Val.ToInt64(DRow["item_group_id"]);
                    lookUpCategoryName.EditValue = Val.ToInt64(DRow["item_category_id"]);
                    txtItemCodification.Text = Val.ToString(DRow["item_codification"]);
                    CmbUnitType.EditValue = Val.ToInt64(DRow["unit_id"]);
                    txtLastPurchase.Text = Val.ToString(DRow["last_purchase_rate"]);
                    RbtStatus.EditValue = Convert.ToInt32(DRow["active"]);
                    txtRemark.Text = Val.ToString(DRow["remark"]);
                    txtDiscPer.Text = Val.ToString(DRow["disc_per"]);
                    LookupCompany.EditValue = Val.ToInt32(DRow["company_id"]);
                    LookupBranch.EditValue = Val.ToInt32(DRow["branch_id"]);
                    LookupLocation.EditValue = Val.ToInt32(DRow["location_id"]);
                    LookupHSNCode.EditValue = Val.ToInt64(DRow["hsn_id"]);

                    txtSaleRate.Text = Val.ToString(DRow["sale_rate"]);
                    txtStockLimit.Text = Val.ToString(DRow["stock_limit"]);
                    txtPCSInBox.Text = Val.ToString(DRow["pcs_in_box"]);
                    //GetItemDetail();
                    txtItemName.Focus();
                }
            }
        }
        private void txtItemName_Validated(object sender, EventArgs e)
        {
            GrdItemGrid.SetRowCellValue(0, "item_name", txtItemName.Text);
        }
        private void LookupHSNCode_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmItemHSNMaster frmCnt = new FrmItemHSNMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPItemHSN(LookupHSNCode);
            }
        }
        private void LookupHSNCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TabRegisterDetail.SelectedTabPageIndex = TabRegisterDetail.SelectedTabPageIndex + 1;
            }
        }

        private void txtLastPurchase_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.' && (sender as DevExpress.XtraEditors.TextEdit).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void txtSaleRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.' && (sender as DevExpress.XtraEditors.TextEdit).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }
    }
}
