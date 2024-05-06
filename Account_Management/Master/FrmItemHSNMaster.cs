using Account_Management.Class;
using BLL.FunctionClasses.Master;
using BLL.PropertyClasses.Master;
using System;
using System.Data;

namespace Account_Management.Master
{
    public partial class FrmItemHSNMaster : DevExpress.XtraEditors.XtraForm
    {

        BLL.FormEvents objBOFormEvents = new BLL.FormEvents();

        BLL.Validation Val = new BLL.Validation();
        CountryMaster objCountry = new CountryMaster();
        StateMaster objState = new StateMaster();
        CityMaster objCity = new CityMaster();
        ItemHSNMaster objItemHSN = new ItemHSNMaster();

        public FrmItemHSNMaster()
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
            objBOFormEvents.ObjToDispose.Add(Val);
            objBOFormEvents.ObjToDispose.Add(objBOFormEvents);
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtHSNID.Text = "0";
            txtHSNName.Text = "";
            txtRemark.Text = "";
            RBtnStatus.SelectedIndex = 0;
            txtHSNCode.Text = "";
            txtGSTRate.Text = "";
            DTCGSTDate.EditValue = null;
            DTIGSTDate.EditValue = null;
            DTSGSTDate.EditValue = null;
            txtCGSTRate.Text = "";
            txtIGSTRate.Text = "";
            txtSGSTRate.Text = "";
            txtHSNCode.Focus();
        }

        #region Validation

        private bool ValSave()
        {
            //if (txtHSNName.Text.Length == 0)
            //{
            //    Global.Confirm("HSN Name Is Required");
            //    txtHSNName.Focus();
            //    return false;
            //}

            if (txtHSNCode.Text.Length == 0)
            {
                Global.Confirm("HSN Code Is Required");
                txtHSNCode.Focus();
                return false;
            }

            //if (DTCGSTDate.Text.ToString() == "")
            //{
            //    Global.Message("IGST Date Is Required");
            //    DTCGSTDate.Focus();
            //    return false;
            //}
            //if (DTCGSTDate.Text.ToString() == "")
            //{
            //    Global.Message("CGST Date Is Required");
            //    DTCGSTDate.Focus();
            //    return false;
            //}
            //if (DTSGSTDate.Text.ToString() == "")
            //{
            //    Global.Message("SGST Date Is Required");
            //    txtSGSTRate.Focus();
            //    return false;
            //}
            //if (txtIGSTRate.Text.Length == 0)
            //{
            //    Global.Message("IGST Rate Is Required");
            //    txtIGSTRate.Focus();
            //    return false;
            //}
            //if (txtCGSTRate.Text.Length == 0)
            //{
            //    Global.Message("CGST Rate Is Required");
            //    txtCGSTRate.Focus();
            //    return false;
            //}
            //if (txtSGSTRate.Text.Length == 0)
            //{
            //    Global.Message("SGST Rate Is Required");
            //    txtSGSTRate.Focus();
            //    return false;
            //}

            if (!objItemHSN.ISExists(txtHSNCode.Text, Val.ToInt64(txtHSNID.EditValue)).ToString().Trim().Equals(string.Empty))
            {
                Global.Confirm("HSN Name Already Exist.");
                txtHSNName.Focus();
                txtHSNName.SelectAll();
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

            ItemHSN_MasterProperty ItemHSNMasterProperty = new ItemHSN_MasterProperty();
            int Code = Val.ToInt(txtHSNID.Text);
            ItemHSNMasterProperty.hsn_id = Val.ToInt64(Code);
            ItemHSNMasterProperty.hsn_name = txtHSNName.Text;
            ItemHSNMasterProperty.active = Val.ToInt(RBtnStatus.Text);
            ItemHSNMasterProperty.remark = txtRemark.Text;
            ItemHSNMasterProperty.hsn_code = Val.ToString(txtHSNCode.Text);
            ItemHSNMasterProperty.igst_date = Val.DBDate(DTIGSTDate.Text);
            ItemHSNMasterProperty.igst_rate = Val.Val(txtIGSTRate.Text);
            ItemHSNMasterProperty.cgst_date = Val.DBDate(DTCGSTDate.Text);
            ItemHSNMasterProperty.cgst_rate = Val.Val(txtCGSTRate.Text);
            ItemHSNMasterProperty.sgst_date = Val.DBDate(DTSGSTDate.Text);
            ItemHSNMasterProperty.sgst_rate = Val.Val(txtSGSTRate.Text);
            ItemHSNMasterProperty.gst_rate = Val.ToDecimal(txtGSTRate.Text);

            int IntRes = objItemHSN.Save(ItemHSNMasterProperty);
            if (IntRes == -1)
            {
                Global.Confirm("Error In Save HSN Details");
                txtHSNName.Focus();
            }
            else
            {
                if (Code == 0)
                {
                    Global.Confirm("Item HSN Details Data Save Successfully");
                }
                else
                {
                    Global.Confirm("Item HSN Details Data Update Successfully");
                }
                GetData();
                btnClear_Click(sender, e);
            }
            ItemHSNMasterProperty = null;
        }

        public void GetData()
        {
            DataTable DTab = objItemHSN.GetData_Search();
            grdItemHSNMaster.DataSource = DTab;
            dgvItemHSNMaster.BestFitColumns();
        }

        private void FrmItemHSNMaster_Load(object sender, EventArgs e)
        {
            GetData();
            btnClear_Click(btnClear, null);
            txtHSNName.Focus();
        }

        private void dgvItemHSNMaster_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (e.Clicks == 2)
                {
                    DataRow Drow = dgvItemHSNMaster.GetDataRow(e.RowHandle);
                    txtHSNID.Text = Val.ToString(Drow["hsn_id"]);
                    txtHSNName.Text = Val.ToString(Drow["hsn_name"]);
                    RBtnStatus.EditValue = Val.ToInt32(Drow["active"]);
                    txtRemark.Text = Val.ToString(Drow["remark"]);
                    txtHSNCode.Text = Val.ToString(Drow["hsn_code"]);
                    txtGSTRate.Text = Val.ToString(Drow["gst_rate"]);
                    txtIGSTRate.Text = Val.ToString(Drow["igst_rate"].ToString());
                    DTIGSTDate.Text = Val.ToString(Drow["igst_DATE"].ToString());
                    txtSGSTRate.Text = Val.ToString(Drow["sgst_rate"].ToString());
                    DTSGSTDate.Text = Val.ToString(Drow["sgst_DATE"].ToString());
                    txtCGSTRate.Text = Val.ToString(Drow["cgst_rate"].ToString());
                    DTCGSTDate.Text = Val.ToString(Drow["cgst_DATE"].ToString());
                    txtHSNCode.Focus();
                }
            }
        }
    }
}
