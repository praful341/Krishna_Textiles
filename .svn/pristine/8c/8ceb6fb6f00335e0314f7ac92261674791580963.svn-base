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
using Global = Krishna_Textiles.Class.Global;

namespace Krishna_Textiles.Master
{
    public partial class FrmConfigMenuPermission : DevExpress.XtraEditors.XtraForm
    {
        BLL.FormEvents objBOFormEvents = new BLL.FormEvents();
        BLL.FormPer ObjPer = new BLL.FormPer();
        BLL.Validation Val = new BLL.Validation();

        ConfigMenuPermissionMaster objMenuPermission = new ConfigMenuPermissionMaster();
        List<Task> tList = new List<Task>();

        #region Constructor
        public FrmConfigMenuPermission()
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
            objBOFormEvents.FormResize = true;
            objBOFormEvents.FormClosing = true;
            objBOFormEvents.ObjToDispose.Add(objMenuPermission);
            objBOFormEvents.ObjToDispose.Add(Val);
            objBOFormEvents.ObjToDispose.Add(objBOFormEvents);
        }

        #endregion

        #region Events

        private void BtnSave_Click(object sender, EventArgs e)
        {
            ObjPer.SetFormPer();
            if (ObjPer.AllowUpdate == false || ObjPer.AllowInsert == false)
            {
                Global.Message(BLL.GlobalDec.gStrPermissionInsUpdMsg);
                return;
            }
            BtnSave.Enabled = false;

            if (SaveDetails())
            {
                GetData();
                BtnClear_Click(sender, e);
            }

            BtnSave.Enabled = true;
        }

        private bool ValidateDetails()
        {
            bool blnFocus = false;
            List<ListError> lstError = new List<ListError>();
            try
            {
                if (lueRoleID.ItemIndex < 0)
                {
                    lstError.Add(new ListError(13, "Role"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                        lueRoleID.Focus();
                    }
                }
                if (lueStartMenu.ItemIndex < 0)
                {
                    lstError.Add(new ListError(13, "Menu"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                        lueStartMenu.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                lstError.Add(new ListError(ex));
            }
            return (!(BLL.General.ShowErrors(lstError)));

        }

        private bool SaveDetails()
        {
            bool blnReturn = true;
            ConfigMenuPermission_MasterProperty MenuPermissionMasterProperty = new ConfigMenuPermission_MasterProperty();
            try
            {
                if (!ValidateDetails())
                {
                    blnReturn = false;
                    return blnReturn;
                }

                MenuPermissionMasterProperty.menu_detail_id = Val.ToInt64(lblMode.Tag);
                MenuPermissionMasterProperty.menu_id = Val.ToInt(lueStartMenu.EditValue);
                MenuPermissionMasterProperty.role_id = Val.ToInt(lueRoleID.EditValue);
                MenuPermissionMasterProperty.is_permisson = Val.ToBoolean(ChkISPermission.Checked);

                int IntRes = objMenuPermission.Save(MenuPermissionMasterProperty);
                if (IntRes == -1)
                {
                    Global.Confirm("Error In Save Menu Permission Details");
                    lueRoleID.Focus();
                }
                else
                {
                    if (Val.ToInt(lblMode.Tag) == 0)
                    {
                        Global.Confirm("Menu Permission Details Data Save Successfully");
                    }
                    else
                    {
                        Global.Confirm("Menu Permission Details Data Update Successfully");
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
                MenuPermissionMasterProperty = null;
            }

            return blnReturn;
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            lblMode.Tag = 0;
            lblMode.Text = "Add Mode";
            lueStartMenu.EditValue = null;
            lueRoleID.EditValue = null;
            ChkISPermission.Checked = false;
            lueStartMenu.Focus();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
        private void GetData()
        {
            DataTable DTab = objMenuPermission.Start_Menu_Permission_GetData();
            dgvMenuPermission.InvokeEx(t =>
            {
                t.DataSource = DTab;
                GrdMenuPermission.BestFitColumns();
            });
        }

        private void GrdMenuPermission_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.Clicks == 2)
            {
                DataRow Drow = GrdMenuPermission.GetDataRow(e.RowHandle);

                lblMode.Text = "Edit Mode";
                lblMode.Tag = Val.ToInt64(Drow["menu_detail_id"]);
                lueStartMenu.EditValue = Val.ToInt32(Drow["menu_id"]);
                lueRoleID.EditValue = Val.ToInt32(Drow["role_id"]);
                ChkISPermission.Checked = Val.ToBoolean(Drow["is_permisson"]);
                lueStartMenu.Focus();
            }
        }

        private void FrmMenuPermission_Load(object sender, EventArgs e)
        {
            try
            {
                Task.Run(() => Global.LOOKUPRole(lueRoleID));
                Task.Run(() => Global.LOOKUPMenu(lueStartMenu));
                Task.Run(() => GetData());
                BtnClear_Click(BtnClear, null);
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
                            dgvMenuPermission.ExportToPdf(Filepath);
                            break;
                        case "xls":
                            dgvMenuPermission.ExportToXls(Filepath);
                            break;
                        case "xlsx":
                            dgvMenuPermission.ExportToXlsx(Filepath);
                            break;
                        case "rtf":
                            dgvMenuPermission.ExportToRtf(Filepath);
                            break;
                        case "txt":
                            dgvMenuPermission.ExportToText(Filepath);
                            break;
                        case "html":
                            dgvMenuPermission.ExportToHtml(Filepath);
                            break;
                        case "csv":
                            dgvMenuPermission.ExportToCsv(Filepath);
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
