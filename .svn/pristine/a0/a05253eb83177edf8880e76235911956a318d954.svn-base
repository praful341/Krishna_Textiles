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
    public partial class FrmLocationMaster : DevExpress.XtraEditors.XtraForm
    {
        #region Data Member

        BLL.FormEvents objBOFormEvents;
        BLL.Validation Val;
        BLL.FormPer ObjPer;

        LocationMaster objLoc;
        List<Task> tList = new List<Task>();
        #endregion

        #region Constructor
        public FrmLocationMaster()
        {
            InitializeComponent();

            objBOFormEvents = new BLL.FormEvents();
            Val = new BLL.Validation();
            ObjPer = new BLL.FormPer();

            objLoc = new LocationMaster();
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
            objBOFormEvents.ObjToDispose.Add(objLoc);
            objBOFormEvents.ObjToDispose.Add(Val);
            objBOFormEvents.ObjToDispose.Add(objBOFormEvents);
        }

        #endregion

        #region Events
        private void FrmLocationMaster_Load(object sender, EventArgs e)
        {
            try
            {
                Task.Run(() => Global.LOOKUPCountry(lueCountry));
                Task.Run(() => Global.LOOKUPState(lueState));
                Task.Run(() => Global.LOOKUPCity(lueCity));
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
            lblMode.Tag = 0;
            lblMode.Text = "Add Mode";
            txtShortName.Text = "";
            txtLocationName.Text = "";
            txtRemark.Text = "";
            lueCity.EditValue = null;
            lueCountry.EditValue = null;
            lueState.EditValue = null;
            chkActive.Checked = false;
            txtShortName.Focus();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LookupState_EditValueChanged(object sender, EventArgs e)
        {
            //lueCity.EditValue = lueCity.GetColumnValue("state_id");
        }
        private void LookupCity_EditValueChanged(object sender, EventArgs e)
        {
            //lueCountry.EditValue = lueCity.GetColumnValue("country_id");
            //lueState.EditValue = lueCity.GetColumnValue("state_id");
        }
        private void lueCountry_EditValueChanged(object sender, EventArgs e)
        {
            //lueState.EditValue = lueCountry.GetColumnValue("state_id");
        }

        #region GridEvents
        private void dgvLocationMaster_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                if (e.RowHandle >= 0)
                {
                    if (e.Clicks == 2)
                    {
                        DataRow Drow = dgvLocationMaster.GetDataRow(e.RowHandle);
                        lblMode.Text = "Edit Mode";
                        lblMode.Tag = Val.ToInt64(Drow["location_id"]);
                        txtShortName.Text = Val.ToString(Drow["location_shortname"]);
                        txtLocationName.Text = Val.ToString(Drow["location_name"]);
                        lueState.EditValue = Val.ToInt32(Drow["state_id"]);
                        lueCountry.EditValue = Val.ToInt32(Drow["country_id"]);
                        lueCity.EditValue = Val.ToInt32(Drow["city_id"]);
                        txtRemark.Text = Val.ToString(Drow["remarks"]);
                        chkActive.Checked = Val.ToBoolean(Drow["active"]);
                        txtShortName.Focus();
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
            Location_MasterProperty LocMasterProperty = new Location_MasterProperty();
            LocationMaster objLoc = new LocationMaster();
            try
            {
                if (!ValidateDetails())
                {
                    blnReturn = false;
                    return blnReturn;
                }

                LocMasterProperty.location_id = Val.ToInt32(lblMode.Tag);
                LocMasterProperty.location_name = Val.ToString(txtLocationName.Text).ToUpper();
                LocMasterProperty.location_shortname = Val.ToString(txtShortName.Text).ToUpper();
                LocMasterProperty.state_id = Val.ToInt(lueState.EditValue);
                LocMasterProperty.country_id = Val.ToInt(lueCountry.EditValue);
                LocMasterProperty.city_id = Val.ToInt(lueCity.EditValue);
                LocMasterProperty.active = Val.ToBoolean(chkActive.Checked);
                LocMasterProperty.remarks = Val.ToString(txtRemark.Text);

                int IntRes = objLoc.Save(LocMasterProperty);
                if (IntRes == -1)
                {
                    Global.Confirm("Error In Save Location Details");
                    txtShortName.Focus();
                }
                else
                {
                    if (Val.ToInt(lblMode.Tag) == 0)
                    {
                        Global.Confirm("Location Details Data Save Successfully");
                    }
                    else
                    {
                        Global.Confirm("Location Details Data Update Successfully");
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
                LocMasterProperty = null;
            }

            return blnReturn;
        }
        private bool ValidateDetails()
        {
            bool blnFocus = false;
            List<ListError> lstError = new List<ListError>();
            try
            {
                if (txtShortName.Text == string.Empty)
                {
                    lstError.Add(new ListError(12, "Short Name"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                        txtShortName.Focus();
                    }
                }

                if (!objLoc.ISExists(txtLocationName.Text, Val.ToInt64(lblMode.Tag)).ToString().Trim().Equals(string.Empty))
                {
                    lstError.Add(new ListError(23, "Location Name"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                        txtLocationName.Focus();
                    }

                }

                if (txtLocationName.Text == string.Empty)
                {
                    lstError.Add(new ListError(12, "Location Name"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                        txtLocationName.Focus();
                    }
                }

                if (lueCity.ItemIndex < 0)
                {
                    lstError.Add(new ListError(13, "City"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                        lueCity.Focus();
                    }
                }

                if (lueState.ItemIndex < 0)
                {
                    lstError.Add(new ListError(13, "State"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                        lueState.Focus();
                    }
                }

                if (lueCountry.ItemIndex < 0)
                {
                    lstError.Add(new ListError(13, "Country"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                        lueCountry.Focus();
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
                DataTable DTab = objLoc.GetData();
                grdLocationMaster.InvokeEx(t =>
                {
                    t.DataSource = DTab;
                    dgvLocationMaster.BestFitColumns();
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
                            dgvLocationMaster.ExportToPdf(Filepath);
                            break;
                        case "xls":
                            dgvLocationMaster.ExportToXls(Filepath);
                            break;
                        case "xlsx":
                            dgvLocationMaster.ExportToXlsx(Filepath);
                            break;
                        case "rtf":
                            dgvLocationMaster.ExportToRtf(Filepath);
                            break;
                        case "txt":
                            dgvLocationMaster.ExportToText(Filepath);
                            break;
                        case "html":
                            dgvLocationMaster.ExportToHtml(Filepath);
                            break;
                        case "csv":
                            dgvLocationMaster.ExportToCsv(Filepath);
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
