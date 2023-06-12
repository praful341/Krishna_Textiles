using BLL;
using BLL.FunctionClasses.Master;
using BLL.PropertyClasses.Master;
using Krishna_Textiles.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Krishna_Textiles.Class.Global;

namespace Krishna_Textiles.Master
{
    public partial class FrmStateMaster : DevExpress.XtraEditors.XtraForm
    {
        #region Data Member

        BLL.FormEvents objBOFormEvents;
        BLL.Validation Val;
        BLL.FormPer ObjPer;

        StateMaster objState;
        List<Task> tList = new List<Task>();

        #endregion

        #region Constructor
        public FrmStateMaster()
        {
            InitializeComponent();

            objBOFormEvents = new BLL.FormEvents();
            Val = new BLL.Validation();
            ObjPer = new BLL.FormPer();

            objState = new StateMaster();
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
            objBOFormEvents.ObjToDispose.Add(objState);
            objBOFormEvents.ObjToDispose.Add(Val);
            objBOFormEvents.ObjToDispose.Add(objBOFormEvents);
        }
        #endregion

        #region Events
        private void FrmStateMaster_Load(object sender, EventArgs e)
        {
            try
            {
                Task.Run(() => Global.LOOKUPCountry(lueCountry));
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
                txtStateName.Text = "";
                txtRemark.Text = "";
                lueCountry.EditValue = null;
                txtSequenceNo.Text = "";
                chkActive.Checked = false;
                txtStateName.Focus();
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
        private void lueCountry_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                lueCountry.EditValue = lueCountry.GetColumnValue("country_id");
            }
            catch (Exception ex)
            {
                General.ShowErrors(ex.ToString());
                return;
            }
        }

        #region GridEvents
        private void dgvStateMaster_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                if (e.RowHandle >= 0)
                {
                    if (e.Clicks == 2)
                    {
                        DataRow Drow = dgvStateMaster.GetDataRow(e.RowHandle);
                        lblMode.Text = "Edit Mode";
                        lblMode.Tag = Val.ToInt64(Drow["State_id"]);
                        lueCountry.EditValue = Val.ToInt32(Drow["country_id"]);
                        txtStateName.Text = Val.ToString(Drow["state_name"]);
                        txtRemark.Text = Val.ToString(Drow["remarks"]);
                        txtSequenceNo.Text = Val.ToString(Drow["sequence_no"]);
                        chkActive.Checked = Val.ToBoolean(Drow["active"]);
                        txtStateName.Focus();
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

        #region Functions
        private bool SaveDetails()
        {
            bool blnReturn = true;
            StateMaster objState = new StateMaster();
            State_MasterProperty StateMasterProperty = new State_MasterProperty();

            try
            {
                if (!ValidateDetails())
                {
                    blnReturn = false;
                    return blnReturn;
                }

                StateMasterProperty.state_id = Val.ToInt32(lblMode.Tag);
                StateMasterProperty.state_name = txtStateName.Text.ToUpper();
                StateMasterProperty.country_id = Val.ToInt(lueCountry.EditValue);
                StateMasterProperty.active = Val.ToBoolean(chkActive.Checked);
                StateMasterProperty.remarks = txtRemark.Text.ToUpper();
                StateMasterProperty.sequence_no = Val.ToInt(txtSequenceNo.Text);

                int IntRes = objState.Save(StateMasterProperty);
                if (IntRes == -1)
                {
                    Global.Confirm("Error In Save State Details");
                    txtStateName.Focus();
                }
                else
                {
                    if (Val.ToInt(lblMode.Tag) == 0)
                    {
                        Global.Confirm("State Details Data Save Successfully");
                    }
                    else
                    {
                        Global.Confirm("State Details Data Update Successfully");
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
                StateMasterProperty = null;
            }

            return blnReturn;
        }
        private bool ValidateDetails()
        {
            bool blnFocus = false;
            List<ListError> lstError = new List<ListError>();
            try
            {
                if (txtStateName.Text == string.Empty)
                {
                    lstError.Add(new ListError(12, "State Name"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                        txtStateName.Focus();
                    }
                }

                if (!objState.ISExists(txtStateName.Text, Val.ToInt64(lblMode.Tag)).ToString().Trim().Equals(string.Empty))
                {
                    lstError.Add(new ListError(23, "State Name"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                        txtStateName.Focus();
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
                DataTable DTab = objState.GetData();
                grdStateMaster.InvokeEx(t =>
                {
                    t.DataSource = DTab;
                    dgvStateMaster.BestFitColumns();
                });
            }
            catch (Exception ex)
            {
                General.ShowErrors(ex.ToString());
                return;
            }
        }
        private void Export(string format, string dlgHeader, string dlgFilter)
        {
            try
            {
                SaveFileDialog svDialog = new SaveFileDialog();
                svDialog.DefaultExt = format;
                svDialog.Title = dlgHeader;
                svDialog.FileName = "Report";
                svDialog.Filter = dlgFilter;
                if ((svDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK))
                {
                    string Filepath = svDialog.FileName;

                    switch (format)
                    {
                        case "pdf":
                            dgvStateMaster.ExportToPdf(Filepath);
                            break;
                        case "xls":
                            dgvStateMaster.ExportToXls(Filepath);
                            break;
                        case "xlsx":
                            dgvStateMaster.ExportToXlsx(Filepath);
                            break;
                        case "rtf":
                            dgvStateMaster.ExportToRtf(Filepath);
                            break;
                        case "txt":
                            dgvStateMaster.ExportToText(Filepath);
                            break;
                        case "html":
                            dgvStateMaster.ExportToHtml(Filepath);
                            break;
                        case "csv":
                            dgvStateMaster.ExportToCsv(Filepath);
                            break;
                    }

                    if (format.Equals(Exports.xlsx.ToString()))
                    {
                        if (Global.Confirm("Export Done\n\nYou Want To Open Excel File ?", "DERP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start(Filepath);
                        }
                    }
                    else if (format.Equals(Exports.pdf.ToString()))
                    {
                        if (Global.Confirm("Export Done\n\nYou Want To Open PDF File ?", "DERP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start(Filepath);
                        }
                    }
                    else
                    {
                        if (Global.Confirm("Export Done\n\nYou Want To Open File ?", "DERP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start(Filepath);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Global.Message(ex.Message.ToString(), "Error in Export");
            }
        }
        #endregion

        #region Export Grid
        private void MNExportExcel_Click(object sender, EventArgs e)
        {
            //Global.Export("xlsx", dgvRoughClarityMaster);
            Export("xlsx", "Export to Excel", "Excel files 97-2003 (Excel files 2007(*.xlsx)|*.xlsx|All files (*.*)|*.*");
        }
        private void MNExportPDF_Click(object sender, EventArgs e)
        {
            // Global.Export("pdf", dgvRoughClarityMaster);
            Export("pdf", "Export Report to PDF", "PDF (*.PDF)|*.PDF");
        }
        private void MNExportTEXT_Click(object sender, EventArgs e)
        {
            Export("txt", "Export to Text", "Text files (*.txt)|*.txt|All files (*.*)|*.*");
        }

        private void MNExportHTML_Click(object sender, EventArgs e)
        {
            Export("html", "Export to HTML", "Html files (*.html)|*.html|Htm files (*.htm)|*.htm");
        }

        private void MNExportRTF_Click(object sender, EventArgs e)
        {
            Export("rtf", "Export to RTF", "Word (*.doc) |*.doc;*.rtf|(*.txt) |*.txt|(*.*) |*.*");
        }

        private void MNExportCSV_Click(object sender, EventArgs e)
        {
            Export("csv", "Export Report to CSVB", "csv (*.csv)|*.csv");
        }
        #endregion
    }
}
