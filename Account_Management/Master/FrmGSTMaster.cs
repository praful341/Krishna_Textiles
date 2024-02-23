using Account_Management.Class;
using BLL.FunctionClasses.Master;
using BLL.PropertyClasses.Master;
using System;
using System.Data;

namespace Account_Management.Master
{
    public partial class FrmGSTMaster : DevExpress.XtraEditors.XtraForm
    {
        BLL.FormEvents objBOFormEvents = new BLL.FormEvents();
        BLL.Validation Val = new BLL.Validation();
        GSTMaster objGSTMaster = new GSTMaster();
        DataTable m_dtbType;

        public FrmGSTMaster()
        {
            InitializeComponent();
            m_dtbType = new DataTable();
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
            txtGSTCode.Text = "0";
            txtGSTName.Text = "";
            txtGSTRate.Text = "";
            lueType.EditValue = null;
            RBtnStatus.SelectedIndex = 0;
            txtGSTName.Focus();
        }

        #region Validation

        private bool ValSave()
        {
            if (txtGSTName.Text.Length == 0)
            {
                Global.Confirm("GST Name Is Required");
                txtGSTName.Focus();
                return false;
            }
            if (lueType.Text == "")
            {
                Global.Confirm("Type Is Required");
                lueType.Focus();
                return false;
            }
            if (!objGSTMaster.ISExists(txtGSTName.Text, Val.ToInt64(txtGSTCode.EditValue)).ToString().Trim().Equals(string.Empty))
            {
                Global.Confirm("GST Name Already Exist.");
                txtGSTName.Focus();
                txtGSTName.SelectAll();
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

            GST_MasterProperty GSTMasterProperty = new GST_MasterProperty();
            int Code = Val.ToInt(txtGSTCode.Text);
            GSTMasterProperty.gst_id = Val.ToInt64(Code);
            GSTMasterProperty.gst_name = txtGSTName.Text;
            GSTMasterProperty.active = Val.ToInt(RBtnStatus.Text);
            GSTMasterProperty.gst_rate = Val.ToDecimal(txtGSTRate.Text);
            GSTMasterProperty.type = Val.ToString(lueType.Text);

            int IntRes = objGSTMaster.Save(GSTMasterProperty);
            if (IntRes == -1)
            {
                Global.Confirm("Error In Save GST Details");
                txtGSTName.Focus();
            }
            else
            {
                if (Code == 0)
                {
                    Global.Confirm("GST Details Data Save Successfully");
                }
                else
                {
                    Global.Confirm("GST Details Data Update Successfully");
                }
                GetData();
                btnClear_Click(sender, e);
            }
            GSTMasterProperty = null;
        }

        public void GetData()
        {
            DataTable DTab = objGSTMaster.GetData_Search();
            grdGSTMaster.DataSource = DTab;
        }

        private void FrmCountryMaster_Load(object sender, EventArgs e)
        {
            m_dtbType.Columns.Add("type");
            m_dtbType.Rows.Add("LocalState");
            m_dtbType.Rows.Add("InterState");

            lueType.Properties.DataSource = m_dtbType;
            lueType.Properties.ValueMember = "type";
            lueType.Properties.DisplayMember = "type";

            GetData();
            btnClear_Click(btnClear, null);
        }

        private void dgvGSTMaster_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (e.Clicks == 2)
                {
                    DataRow Drow = dgvGSTMaster.GetDataRow(e.RowHandle);
                    txtGSTCode.Text = Val.ToString(Drow["gst_id"]);
                    txtGSTName.Text = Val.ToString(Drow["gst_name"]);
                    txtGSTRate.Text = Val.ToString(Drow["gst_rate"]);
                    RBtnStatus.EditValue = Val.ToInt32(Drow["active"]);
                    lueType.Text = Val.ToString(Drow["type"]);
                    txtGSTName.Focus();
                }
            }
        }

        private void txtGSTRate_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
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
