using BLL;
using BLL.FunctionClasses.Master;
using BLL.PropertyClasses.Master;
using Account_Management.Class;
using Account_Management.Search;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Account_Management.Class.Global;

namespace Account_Management.Master
{
    public partial class FrmConfigFormMaster : DevExpress.XtraEditors.XtraForm
    {
        #region Data Member

        FormEvents objBOFormEvents;
        Validation Val;
        BLL.FormPer ObjPer;

        ConfigFormMaster objConfigForm;
        FrmSearchNew FrmSearchNew;
        List<Task> tList = new List<Task>();
        #endregion

        #region Constructor
        public FrmConfigFormMaster()
        {
            InitializeComponent();

            objBOFormEvents = new FormEvents();
            Val = new Validation();
            ObjPer = new BLL.FormPer();

            objConfigForm = new ConfigFormMaster();
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
            objBOFormEvents.ObjToDispose.Add(objConfigForm);
            objBOFormEvents.ObjToDispose.Add(Val);
            objBOFormEvents.ObjToDispose.Add(objBOFormEvents);
        }

        #endregion

        #region Events
        private void FrmConfigFormMaster_Load(object sender, EventArgs e)
        {
            try
            {
                Task.Run(() => Global.LOOKUPMenuHeader(lueMenuHeader));
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
                txtFormName.Text = "";
                txtFormGroup.Text = "";
                txtCaption.Text = "";
                lueMenuHeader.EditValue = null;
                txtSubMenu.Text = "";
                txtMenu.Text = "";
                txtparam.Text = "";
                txtIcon.Text = "";
                txtLevel1.Text = "";
                txtLevel2.Text = "";
                txtRemark.Text = "";
                txtSequenceNo.Text = "";
                chkActive.Checked = true;
                txtFormName.Focus();
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
        private void txtFormGroup_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            try
            {
                if (Global.OnKeyPressToOpenPopup(e))
                {
                    FrmSearchNew = new Search.FrmSearchNew();
                    FrmSearchNew.SearchText = e.KeyChar.ToString();
                    DataTable Dtab = objConfigForm.GetData(1);
                    FrmSearchNew.DTab = Dtab.DefaultView.ToTable(true, "form_group_name");
                    FrmSearchNew.SearchField = "form_group_name";
                    FrmSearchNew.ShowDialog();
                    e.Handled = true;
                    if (FrmSearchNew.DRow != null)
                    {
                        txtFormGroup.Text = Val.ToString(FrmSearchNew.DRow["form_group_name"]);
                    }
                    else
                    {
                        txtFormGroup.Text = FrmSearchNew.SearchText;
                    }
                    FrmSearchNew.Hide();
                    FrmSearchNew.Dispose();
                    FrmSearchNew = null;
                }
            }
            catch (Exception ex)
            {
                General.ShowErrors(ex.ToString());
                return;
            }
        }
        #region GridEvents    
        private void dgvConfigFormMaster_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            try
            {
                if (e.RowHandle >= 0)
                {
                    if (e.Clicks == 2)
                    {
                        DataRow Drow = dgvConfigFormMaster.GetDataRow(e.RowHandle);
                        lblMode.Text = "Edit Mode";
                        lblMode.Tag = Val.ToInt32(Drow["form_id"]);
                        txtFormName.Text = Val.ToString(Drow["form_name"]);
                        txtFormGroup.Text = Val.ToString(Drow["form_group_name"]);
                        txtCaption.Text = Val.ToString(Drow["caption"]);
                        lueMenuHeader.EditValue = Val.ToInt32(Drow["main_menu"]);
                        txtSubMenu.Text = Val.ToString(Drow["sub_menu"]);
                        txtMenu.Text = Val.ToString(Drow["menu"]);
                        txtIcon.Text = Val.ToString(Drow["icon"]);
                        txtLevel1.Text = Val.ToString(Drow["level1"]);
                        txtLevel2.Text = Val.ToString(Drow["level2"]);
                        txtparam.Text = Val.ToString(Drow["param"]);
                        txtRemark.Text = Val.ToString(Drow["remarks"]);
                        txtSequenceNo.Text = Val.ToString(Drow["sequence_no"]);
                        chkActive.Checked = Val.ToBoolean(Drow["active"]);
                        txtFormName.Focus();
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

        #region Functions
        private bool SaveDetails()
        {
            bool blnReturn = true;
            ConfigForm_MasterProperty ConfigFormMasterProperty = new ConfigForm_MasterProperty();
            ConfigFormMaster ConfigFormMaster = new ConfigFormMaster();

            try
            {
                if (!ValidateDetails())
                {
                    blnReturn = false;
                    return blnReturn;
                }

                ConfigFormMasterProperty.form_id = Val.ToInt32(lblMode.Tag);
                ConfigFormMasterProperty.form_name = txtFormName.Text.ToUpper();
                ConfigFormMasterProperty.form_group_name = txtFormGroup.Text.ToUpper();
                ConfigFormMasterProperty.caption = txtCaption.Text;
                ConfigFormMasterProperty.main_menu = Val.ToInt32(lueMenuHeader.EditValue);
                ConfigFormMasterProperty.sub_menu = txtSubMenu.Text;
                ConfigFormMasterProperty.menu = txtMenu.Text;
                ConfigFormMasterProperty.active = Val.ToBoolean(chkActive.Checked);
                ConfigFormMasterProperty.remarks = txtRemark.Text;
                ConfigFormMasterProperty.Icon = txtIcon.Text;
                ConfigFormMasterProperty.Param = Val.ToString(txtparam.Text);
                ConfigFormMasterProperty.Level1 = txtLevel1.Text;
                ConfigFormMasterProperty.Level2 = txtLevel2.Text;
                ConfigFormMasterProperty.sequenceno = Val.ToInt(txtSequenceNo.Text);

                int IntRes = objConfigForm.Save(ConfigFormMasterProperty);

                if (IntRes == -1)
                {
                    Global.Confirm("Error In Save Config Form Details");
                    txtFormName.Focus();
                }
                else
                {
                    if (Val.ToInt(lblMode.Tag) == 0)
                    {
                        Global.Confirm("Config Form Details Data Save Successfully");
                    }
                    else
                    {
                        Global.Confirm("Config Form Details Data Update Successfully");
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
                ConfigFormMasterProperty = null;
            }

            return blnReturn;
        }
        private bool ValidateDetails()
        {
            bool blnFocus = false;
            List<ListError> lstError = new List<ListError>();
            try
            {
                if (txtFormName.Text == string.Empty)
                {
                    lstError.Add(new ListError(12, "Form Name"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                        txtFormName.Focus();
                    }
                }

                if (!objConfigForm.ISExists(txtFormName.Text, Val.ToInt64(lblMode.Tag)).ToString().Trim().Equals(string.Empty))
                {
                    lstError.Add(new ListError(23, "Form Name"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                        txtFormName.Focus();
                    }
                }

                if (txtFormGroup.Text == string.Empty)
                {
                    lstError.Add(new ListError(12, "Form Group"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                        txtFormGroup.Focus();
                    }
                }

                if (txtCaption.Text == string.Empty)
                {
                    lstError.Add(new ListError(12, "Caption Name"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                        txtCaption.Focus();
                    }
                }

                if (lueMenuHeader.ItemIndex < 0)
                {
                    lstError.Add(new ListError(13, "Main Menu"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                        lueMenuHeader.Focus();
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
                DataTable DTab = objConfigForm.GetData();
                grdConfigFormMaster.InvokeEx(t =>
                {
                    t.DataSource = DTab;
                    dgvConfigFormMaster.BestFitColumns();
                });
            }
            catch (Exception ex)
            {
                General.ShowErrors(ex.ToString());
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
                            dgvConfigFormMaster.ExportToPdf(Filepath);
                            break;
                        case "xls":
                            dgvConfigFormMaster.ExportToXls(Filepath);
                            break;
                        case "xlsx":
                            dgvConfigFormMaster.ExportToXlsx(Filepath);
                            break;
                        case "rtf":
                            dgvConfigFormMaster.ExportToRtf(Filepath);
                            break;
                        case "txt":
                            dgvConfigFormMaster.ExportToText(Filepath);
                            break;
                        case "html":
                            dgvConfigFormMaster.ExportToHtml(Filepath);
                            break;
                        case "csv":
                            dgvConfigFormMaster.ExportToCsv(Filepath);
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
