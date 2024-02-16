using Account_Management.Class;
using BLL.FunctionClasses.Master;
using BLL.PropertyClasses.Master;
using System;
using System.Data;
using System.Windows.Forms;
using static Account_Management.Class.Global;

namespace Account_Management.Master
{
    public partial class FrmItemGroupMaster : DevExpress.XtraEditors.XtraForm
    {
        BLL.FormEvents objBOFormEvents = new BLL.FormEvents();
        BLL.Validation Val = new BLL.Validation();
        ItemGroupMaster ObjItemGroup = new ItemGroupMaster();

        public FrmItemGroupMaster()
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
            txtItemGroupCode.Text = "0";
            txtItemGroupName.Text = "";
            txtRemark.Text = "";
            RBtnStatus.SelectedIndex = 0;
            txtItemGroupName.Focus();
        }

        #region Validation

        private bool ValSave()
        {
            if (txtItemGroupName.Text.Length == 0)
            {
                Global.Confirm("Item Group Name Is Required");
                txtItemGroupName.Focus();
                return false;
            }
            if (!ObjItemGroup.ISExists(txtItemGroupName.Text, Val.ToInt64(txtItemGroupCode.EditValue)).ToString().Trim().Equals(string.Empty))
            {
                Global.Confirm("Item Group Name Already Exist.");
                txtItemGroupName.Focus();
                txtItemGroupName.SelectAll();
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

            Item_Group_MasterProperty AccountIteamGroupMasterProperty = new Item_Group_MasterProperty();
            int Code = Val.ToInt(txtItemGroupCode.Text);
            AccountIteamGroupMasterProperty.item_group_id = Val.ToInt64(Code);
            AccountIteamGroupMasterProperty.item_group_name = txtItemGroupName.Text;
            AccountIteamGroupMasterProperty.remark = txtRemark.Text;
            AccountIteamGroupMasterProperty.active = Val.ToInt(RBtnStatus.Text);

            int IntRes = ObjItemGroup.Save(AccountIteamGroupMasterProperty);
            if (IntRes == -1)
            {
                Global.Confirm("Error In Save Item Group Master Data");
                txtItemGroupName.Focus();
            }
            else
            {
                if (Code == 0)
                {
                    Global.Confirm("Item Group Master Data Save Successfully");
                }
                else
                {
                    Global.Confirm("Item Group Master Data Update Successfully");
                }

                GetData();
                btnClear_Click(sender, e);
            }
            AccountIteamGroupMasterProperty = null;
        }

        public void GetData()
        {
            DataTable DTab = ObjItemGroup.GetData_Search();
            grdItemGroupMaster.DataSource = DTab;
        }

        private void FrmCountryMaster_Load(object sender, EventArgs e)
        {
            GetData();
            btnClear_Click(btnClear, null);
        }

        private void dgvItemGroupMaster_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (e.Clicks == 2)
                {
                    DataRow Drow = dgvItemGroupMaster.GetDataRow(e.RowHandle);
                    txtItemGroupCode.Text = Val.ToString(Drow["item_group_id"]);
                    txtItemGroupName.Text = Val.ToString(Drow["item_group_name"]);
                    RBtnStatus.EditValue = Val.ToInt32(Drow["active"]);
                    txtRemark.Text = Val.ToString(Drow["remark"]);
                }
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
                            dgvItemGroupMaster.ExportToPdf(Filepath);
                            break;
                        case "xls":
                            dgvItemGroupMaster.ExportToXls(Filepath);
                            break;
                        case "xlsx":
                            dgvItemGroupMaster.ExportToXlsx(Filepath);
                            break;
                        case "rtf":
                            dgvItemGroupMaster.ExportToRtf(Filepath);
                            break;
                        case "txt":
                            dgvItemGroupMaster.ExportToText(Filepath);
                            break;
                        case "html":
                            dgvItemGroupMaster.ExportToHtml(Filepath);
                            break;
                        case "csv":
                            dgvItemGroupMaster.ExportToCsv(Filepath);
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
    }
}
