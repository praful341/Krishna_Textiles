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
    public partial class FrmIDProofMaster : DevExpress.XtraEditors.XtraForm
    {
        #region Data Member

        FormEvents objBOFormEvents = new FormEvents();
        Validation Val = new Validation();
        BLL.FormPer ObjPer = new BLL.FormPer();
        IDProofMaster objIDProof = new IDProofMaster();
        List<Task> tList = new List<Task>();

        #endregion

        #region Constructor
        public FrmIDProofMaster()
        {
            InitializeComponent();
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
            objBOFormEvents.ObjToDispose.Add(objIDProof);
            objBOFormEvents.ObjToDispose.Add(Val);
            objBOFormEvents.ObjToDispose.Add(objBOFormEvents);
        }

        #endregion

        #region Validation
        private bool ValidateDetails()
        {
            bool blnFocus = false;
            List<ListError> lstError = new List<ListError>();
            try
            {
                if (txtIDProofName.Text == string.Empty)
                {
                    lstError.Add(new ListError(12, "ID Proof Name"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                        txtIDProofName.Focus();
                    }
                }

                if (!objIDProof.ISExists(txtIDProofName.Text, Val.ToInt64(lblMode.Tag)).ToString().Trim().Equals(string.Empty))
                {
                    lstError.Add(new ListError(23, "ID Proof Name"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                        txtIDProofName.Focus();
                    }
                }

                if (txtSequenceNo.Text == string.Empty || txtSequenceNo.Text == "0")
                {
                    lstError.Add(new ListError(12, "Sequence No"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                        txtSequenceNo.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                lstError.Add(new ListError(ex));
            }
            return (!(BLL.General.ShowErrors(lstError)));

        }
        #endregion

        #region Events

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblMode.Tag = 0;
            lblMode.Text = "Add Mode";
            txtIDProofName.Text = "";
            txtRemark.Text = "";
            txtSequenceNo.Text = "";
            chkActive.Checked = false;
            txtIDProofName.Focus();
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

        private void FrmCountryMaster_Load(object sender, EventArgs e)
        {
            Task.Run(() => GetData());
            btnClear_Click(btnClear, null);
        }

        #endregion

        #region Functions
        public void GetData()
        {
            try
            {
                DataTable DTab = objIDProof.GetData();
                grdIDProofMaster.InvokeEx(t =>
                {
                    t.DataSource = DTab;
                    dgvIDProofMaster.BestFitColumns();
                });
            }
            catch (Exception ex)
            {
                General.ShowErrors(ex.ToString());
                return;
            }
        }
        private bool SaveDetails()
        {
            bool blnReturn = true;
            IDProof_MasterProperty IDProofMasterProperty = new IDProof_MasterProperty();
            IDProofMaster objIDProof = new IDProofMaster();

            try
            {
                if (!ValidateDetails())
                {
                    blnReturn = false;
                    return blnReturn;
                }

                IDProofMasterProperty.idproof_id = Val.ToInt32(lblMode.Tag);
                IDProofMasterProperty.idproof_name = txtIDProofName.Text.ToUpper();
                IDProofMasterProperty.active = Val.ToBoolean(chkActive.Checked);
                IDProofMasterProperty.remarks = txtRemark.Text.ToUpper();
                IDProofMasterProperty.sequence_no = Val.ToInt(txtSequenceNo.Text);

                int IntRes = objIDProof.Save(IDProofMasterProperty);
                if (IntRes == -1)
                {
                    Global.Confirm("Error In Save ID Proof Details");
                    txtIDProofName.Focus();
                }
                else
                {
                    if (Val.ToInt(lblMode.Tag) == 0)
                    {
                        Global.Confirm("ID Proof Details Data Save Successfully");
                    }
                    else
                    {
                        Global.Confirm("ID Proof Data Update Successfully");
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
                IDProofMasterProperty = null;
            }

            return blnReturn;
        }

        private void MNExportExcel_Click(object sender, EventArgs e)
        {
            Global.Export("xlsx", dgvIDProofMaster);
        }

        private void dgvIDProofMaster_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                if (e.RowHandle >= 0)
                {
                    if (e.Clicks == 2)
                    {
                        DataRow Drow = dgvIDProofMaster.GetDataRow(e.RowHandle);
                        lblMode.Text = "Edit Mode";
                        lblMode.Tag = Val.ToInt32(Drow["idproof_id"]);
                        txtIDProofName.Text = Val.ToString(Drow["idproof_name"]);
                        txtRemark.Text = Val.ToString(Drow["remarks"]);
                        txtSequenceNo.Text = Val.ToString(Drow["sequence_no"]);
                        chkActive.Checked = Val.ToBoolean(Drow["active"]);
                        txtIDProofName.Focus();
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
    }
}
