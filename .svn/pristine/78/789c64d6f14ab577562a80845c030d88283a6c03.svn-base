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
    public partial class FrmCountryMaster : DevExpress.XtraEditors.XtraForm
    {
        #region Data Member
        BLL.FormEvents objBOFormEvents;
        BLL.Validation Val;
        BLL.FormPer ObjPer;

        CountryMaster objCountry;
        List<Task> tList = new List<Task>();
        #endregion

        #region Constructor
        public FrmCountryMaster()
        {
            InitializeComponent();

            objBOFormEvents = new BLL.FormEvents();
            Val = new BLL.Validation();
            ObjPer = new BLL.FormPer();

            objCountry = new CountryMaster();
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
            objBOFormEvents.ObjToDispose.Add(objCountry);
            objBOFormEvents.ObjToDispose.Add(Val);
            objBOFormEvents.ObjToDispose.Add(objBOFormEvents);
        }
        #endregion

        #region Events
        private void FrmCountryMaster_Load(object sender, EventArgs e)
        {
            try
            {
                Task.Run(() => GetData());
                btnClear_Click(btnClear, null);
            }
            catch (Exception ex)
            {
                Global.Message(ex.ToString());
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
                txtShortName.Text = "";
                txtCountryName.EditValue = null;
                txtSequenceNo.Text = "";
                chkActive.Checked = false;
                txtShortName.Focus();
            }
            catch (Exception ex)
            {
                Global.Message(ex.ToString());
                return;
            }

        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region GridEvents
        private void dgvCountryMaster_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                if (e.RowHandle >= 0)
                {
                    if (e.Clicks == 2)
                    {
                        DataRow Drow = dgvCountryMaster.GetDataRow(e.RowHandle);
                        lblMode.Text = "Edit Mode";
                        lblMode.Tag = Val.ToInt64(Drow["country_id"]);
                        txtCountryName.Text = Val.ToString(Drow["country_name"]);
                        txtShortName.Text = Val.ToString(Drow["country_shortname"]);
                        txtSequenceNo.Text = Val.ToString(Drow["sequence_no"]);
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
            Country_MasterProperty CountryMasterProperty = new Country_MasterProperty();
            CountryMaster objCountry = new CountryMaster();

            try
            {
                if (!ValidateDetails())
                {
                    blnReturn = false;
                    return blnReturn;
                }
                CountryMasterProperty.country_id = Val.ToInt32(lblMode.Tag);
                CountryMasterProperty.country_shortname = txtShortName.Text.ToUpper();
                CountryMasterProperty.country_name = txtCountryName.Text.ToUpper();
                CountryMasterProperty.active = Val.ToBoolean(chkActive.Checked);
                CountryMasterProperty.sequence_no = Val.ToInt(txtSequenceNo.Text);

                int IntRes = objCountry.Save(CountryMasterProperty);
                if (IntRes == -1)
                {
                    Global.Confirm("Error In Save Country Details");
                    txtShortName.Focus();
                }
                else
                {
                    if (Val.ToInt(lblMode.Tag) == 0)
                    {
                        Global.Confirm("Country Details Data Save Successfully");
                    }
                    else
                    {
                        Global.Confirm("Country Details Data Update Successfully");
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
                CountryMasterProperty = null;
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

                if (txtCountryName.Text == string.Empty)
                {
                    lstError.Add(new ListError(12, "Country Name"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                        txtCountryName.Focus();
                    }
                }


                if (!objCountry.ISExists(txtShortName.Text, Val.ToInt64(lblMode.Tag)).ToString().Trim().Equals(string.Empty))
                {
                    lstError.Add(new ListError(23, "Short Name"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                        txtShortName.Focus();
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
                DataTable DTab = objCountry.GetData();
                grdCountryMaster.InvokeEx(t =>
                {
                    t.DataSource = DTab;
                    dgvCountryMaster.BestFitColumns();
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
                            dgvCountryMaster.ExportToPdf(Filepath);
                            break;
                        case "xls":
                            dgvCountryMaster.ExportToXls(Filepath);
                            break;
                        case "xlsx":
                            dgvCountryMaster.ExportToXlsx(Filepath);
                            break;
                        case "rtf":
                            dgvCountryMaster.ExportToRtf(Filepath);
                            break;
                        case "txt":
                            dgvCountryMaster.ExportToText(Filepath);
                            break;
                        case "html":
                            dgvCountryMaster.ExportToHtml(Filepath);
                            break;
                        case "csv":
                            dgvCountryMaster.ExportToCsv(Filepath);
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
