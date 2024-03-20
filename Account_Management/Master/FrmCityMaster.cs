using Account_Management.Class;
using BLL;
using BLL.FunctionClasses.Master;
using BLL.PropertyClasses.Master;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Account_Management.Class.Global;

namespace Account_Management.Master
{
    public partial class FrmCityMaster : DevExpress.XtraEditors.XtraForm
    {
        #region Data Member

        FormEvents objBOFormEvents;
        Validation Val;
        BLL.FormPer ObjPer;
        CityMaster objCity;

        #endregion

        #region Constructor
        public FrmCityMaster()
        {
            InitializeComponent();
            objBOFormEvents = new FormEvents();
            Val = new Validation();
            ObjPer = new BLL.FormPer();
            objCity = new CityMaster();
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
            this.KeyPreview = true;
            objBOFormEvents.CurForm = this;
            objBOFormEvents.FormKeyPress = true;
            objBOFormEvents.FormKeyDown = true;
            objBOFormEvents.FormResize = true;
            objBOFormEvents.FormClosing = true;
            objBOFormEvents.ObjToDispose.Add(objCity);
            objBOFormEvents.ObjToDispose.Add(Val);
            objBOFormEvents.ObjToDispose.Add(objBOFormEvents);
        }

        #endregion

        #region Events
        private void FrmCityMaster_Load(object sender, EventArgs e)
        {
            try
            {
                Task.Run(() => Global.LOOKUPCountry(lueCountry));
                Task.Run(() => Global.LOOKUPState(lueState));
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
                txtCityName.Text = "";
                txtRemark.Text = "";
                lueState.EditValue = null;
                lueCountry.EditValue = null;
                txtSequenceNo.Text = "";
                chkActive.Checked = false;
                txtCityName.Focus();
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
        private void LookupState_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                lueCountry.EditValue = lueState.GetColumnValue("country_id");
            }
            catch (Exception ex)
            {
                General.ShowErrors(ex.ToString());
                return;
            }
        }

        #region GridEvents
        private void dgvCityMaster_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                if (e.RowHandle >= 0)
                {
                    if (e.Clicks == 2)
                    {
                        DataRow Drow = dgvCityMaster.GetDataRow(e.RowHandle);
                        lblMode.Text = "Edit Mode";
                        lblMode.Tag = Val.ToInt64(Drow["city_id"]);
                        lueState.EditValue = Val.ToInt32(Drow["state_id"]);
                        lueCountry.EditValue = Val.ToInt32(Drow["country_id"]);
                        txtCityName.Text = Val.ToString(Drow["city_name"]);
                        txtRemark.Text = Val.ToString(Drow["remarks"]);
                        txtSequenceNo.Text = Val.ToString(Drow["sequence_no"]);
                        chkActive.Checked = Val.ToBoolean(Drow["active"]);
                        txtCityName.Focus();
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
            City_MasterProperty CityMasterProperty = new City_MasterProperty();
            CityMaster ConfigFormMaster = new CityMaster();

            try
            {
                if (!ValidateDetails())
                {
                    blnReturn = false;
                    return blnReturn;
                }


                CityMasterProperty.city_id = Val.ToInt64(lblMode.Tag);
                CityMasterProperty.city_name = txtCityName.Text.ToUpper();
                CityMasterProperty.state_id = Val.ToInt(lueState.EditValue);
                CityMasterProperty.country_id = Val.ToInt(lueCountry.EditValue);
                CityMasterProperty.active = Val.ToBoolean(chkActive.Checked);
                CityMasterProperty.remarks = txtRemark.Text.ToUpper();
                CityMasterProperty.sequence_no = Val.ToInt(txtSequenceNo.Text);

                int IntRes = objCity.Save(CityMasterProperty);
                if (IntRes == -1)
                {
                    Global.Confirm("Error In Save City Details");
                    txtCityName.Focus();
                }
                else
                {
                    if (Val.ToInt(lblMode.Tag) == 0)
                    {
                        Global.Confirm("City Details Data Save Successfully");
                    }
                    else
                    {
                        Global.Confirm("City Details Data Update Successfully");
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
                CityMasterProperty = null;
            }

            return blnReturn;
        }
        private bool ValidateDetails()
        {
            bool blnFocus = false;
            List<ListError> lstError = new List<ListError>();
            try
            {
                if (txtCityName.Text.ToString() == "")
                {
                    lstError.Add(new ListError(12, "City Name"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                        txtCityName.Focus();
                    }
                }
                if (lueCountry.EditValue.ToString() == "")
                {
                    lstError.Add(new ListError(13, "Country Name"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                        lueCountry.Focus();
                    }
                }
                if (lueState.EditValue.ToString() == "")
                {
                    lstError.Add(new ListError(13, "State Name"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                        lueState.Focus();
                    }
                }

                if (!objCity.ISExists(txtCityName.Text, Val.ToInt64(lblMode.Tag)).ToString().Trim().Equals(string.Empty))
                {
                    lstError.Add(new ListError(23, "City Name"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                        txtCityName.Focus();
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
                DataTable DTab = objCity.GetData();
                grdCityMaster.InvokeEx(t =>
                {
                    grdCityMaster.DataSource = DTab;
                    dgvCityMaster.BestFitColumns();
                });
            }
            catch (Exception ex)
            {
                Global.Message(ex.ToString());
                return;
            }
        }

        #endregion

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
                            dgvCityMaster.ExportToPdf(Filepath);
                            break;
                        case "xls":
                            dgvCityMaster.ExportToXls(Filepath);
                            break;
                        case "xlsx":
                            dgvCityMaster.ExportToXlsx(Filepath);
                            break;
                        case "rtf":
                            dgvCityMaster.ExportToRtf(Filepath);
                            break;
                        case "txt":
                            dgvCityMaster.ExportToText(Filepath);
                            break;
                        case "html":
                            dgvCityMaster.ExportToHtml(Filepath);
                            break;
                        case "csv":
                            dgvCityMaster.ExportToCsv(Filepath);
                            break;
                    }

                    if (format.Equals(Exports.xlsx.ToString()))
                    {
                        if (Global.Confirm("Export Done\n\nYou Want To Open Excel File ?", "Account Management", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start(Filepath);
                        }
                    }
                    else if (format.Equals(Exports.pdf.ToString()))
                    {
                        if (Global.Confirm("Export Done\n\nYou Want To Open PDF File ?", "Account Management", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start(Filepath);
                        }
                    }
                    else
                    {
                        if (Global.Confirm("Export Done\n\nYou Want To Open File ?", "Account Management", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
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
