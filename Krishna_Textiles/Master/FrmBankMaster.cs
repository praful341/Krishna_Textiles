using BLL.FunctionClasses.Master;
using BLL.PropertyClasses.Master;
using Krishna_Textiles.Class;
using System;
using System.Data;
using System.Windows.Forms;

namespace Krishna_Textiles
{  
    public partial class FrmBankMaster : DevExpress.XtraEditors.XtraForm
    {
        BLL.FormEvents objBOFormEvents = new BLL.FormEvents();
        BLL.Validation Val = new BLL.Validation();
        BankMaster objBank = new BankMaster();

        public FrmBankMaster()
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
            lblMode.Tag = 0;
            lblMode.Text = "Add Mode";
            txtBankName.Text = "";
            txtBankAccNo.Text = "";
            txtBankATM.Text = "";
            txtBankAccName.Text = "";
            txtBankCheque.Text = "";
            txtBankIFSC.Text = "";
            lueBranch.EditValue = null;
            txtBankName.Focus();
        }

        #region Validation

        private bool ValSave()
        {
            if (txtBankName.Text.Length == 0)
            {
                Global.Confirm("Bank Name Is Required");
                txtBankName.Focus();
                return false;
            }
            return true;
        }

        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            Bank_MasterProperty BankMasterProperty = new Bank_MasterProperty();
            try
            {
                if (ValSave() == false)
                {
                    return;
                }

                BankMasterProperty.bank_id = Val.ToInt32(lblMode.Tag);
                BankMasterProperty.bank_name = Val.ToString(txtBankName.Text);
                BankMasterProperty.bank_account_no = Val.ToString(txtBankAccNo.Text);
                BankMasterProperty.bank_atm = Val.ToString(txtBankATM.Text);
                BankMasterProperty.bank_account_name = Val.ToString(txtBankAccName.Text);
                BankMasterProperty.bank_ifsc = Val.ToString(txtBankIFSC.Text);
                BankMasterProperty.bank_cheque = Val.ToString(txtBankCheque.Text);
                BankMasterProperty.branch_id = Val.ToInt64(lueBranch.EditValue);

                int IntRes = objBank.Save(BankMasterProperty);

                if (IntRes == -1)
                {
                    Global.Confirm("Error In Save Bank Master Details");
                    txtBankName.Focus();
                }
                else
                {
                    if (Val.ToInt(lblMode.Tag) == 0)
                    {
                        Global.Confirm("Bank Master Details Data Save Successfully");
                    }
                    else
                    {
                        Global.Confirm("Bank Master Details Data Update Successfully");
                    }
                    btnClear_Click(null, null);
                    GetData();
                }
            }
            catch (Exception ex)
            {
                Global.Message(ex.ToString());
            }
            finally
            {
                BankMasterProperty = null;
            }
        }
        public void GetData()
        {
            DataTable DTab = objBank.GetData();
            grdBankMaster.DataSource = DTab;
            dgvBankMaster.BestFitColumns();
        }
        private void FrmBankMaster_Load(object sender, EventArgs e)
        {
            Global.LOOKUPBranch(lueBranch);
            GetData();
            btnClear_Click(btnClear, null);
            txtBankName.Focus();
        }
        private void txtMobileNo1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void txtMobileNo2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void textEdit1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dgvBankMaster_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (e.Clicks == 2)
                {
                    DataRow Drow = dgvBankMaster.GetDataRow(e.RowHandle);
                    lblMode.Text = "Edit Mode";
                    lblMode.Tag = Val.ToInt64(Drow["bank_id"]);
                    txtBankName.Text = Val.ToString(Drow["bank_name"]);
                    txtBankAccNo.Text = Val.ToString(Drow["bank_account_no"]);
                    txtBankATM.Text = Val.ToString(Drow["bank_atm"]);
                    txtBankAccName.Text = Val.ToString(Drow["bank_account_name"]);
                    txtBankIFSC.Text = Val.ToString(Drow["bank_ifsc"]);
                    txtBankCheque.Text = Val.ToString(Drow["bank_cheque"]);
                    lueBranch.EditValue = Val.ToInt32(Drow["branch_id"]);
                    txtBankName.Focus();
                }
            }
        }
    }
}
