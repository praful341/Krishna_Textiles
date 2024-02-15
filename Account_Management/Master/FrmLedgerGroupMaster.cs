using Account_Management.Class;
using BLL.FunctionClasses.Master;
using BLL.PropertyClasses.Master;
using System;
using System.Data;
using System.Windows.Forms;
using static Account_Management.Class.Global;

namespace Account_Management.Master
{
    public partial class FrmLedgerGroupMaster : DevExpress.XtraEditors.XtraForm
    {
        BLL.FormEvents objBOFormEvents = new BLL.FormEvents();
        BLL.Validation Val = new BLL.Validation();
        LedgerGroupMaster ObjLedgerGroup = new LedgerGroupMaster();

        public FrmLedgerGroupMaster()
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
            txtLedgerGroupCode.Text = "0";
            txtLedgerGroupName.Text = "";
            txtRemark.Text = "";
            RBtnStatus.SelectedIndex = 0;
            txtLedgerGroupName.Focus();
        }

        #region Validation

        private bool ValSave()
        {
            if (txtLedgerGroupName.Text.Length == 0)
            {
                Global.Confirm("Ledger Group Name Is Required");
                txtLedgerGroupName.Focus();
                return false;
            }
            if (!ObjLedgerGroup.ISExists(txtLedgerGroupName.Text, Val.ToInt64(txtLedgerGroupCode.EditValue)).ToString().Trim().Equals(string.Empty))
            {
                Global.Confirm("Ledger Group Name Already Exist.");
                txtLedgerGroupName.Focus();
                txtLedgerGroupName.SelectAll();
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

            Ledger_Group_MasterProperty LedgerGroupMasterProperty = new Ledger_Group_MasterProperty();
            int Code = Val.ToInt(txtLedgerGroupCode.Text);
            LedgerGroupMasterProperty.ledger_group_id = Val.ToInt64(Code);
            LedgerGroupMasterProperty.ledger_group_name = txtLedgerGroupName.Text;
            LedgerGroupMasterProperty.remark = txtRemark.Text;
            LedgerGroupMasterProperty.active = Val.ToInt(RBtnStatus.Text);

            int IntRes = ObjLedgerGroup.Save(LedgerGroupMasterProperty);
            if (IntRes == -1)
            {
                Global.Confirm("Error In Save Ledger Group Master Data");
                txtLedgerGroupName.Focus();
            }
            else
            {
                if (Code == 0)
                {
                    Global.Confirm("Ledger Group Master Data Save Successfully");
                }
                else
                {
                    Global.Confirm("Ledger Group Master Data Update Successfully");
                }

                GetData();
                btnClear_Click(sender, e);
            }
            LedgerGroupMasterProperty = null;
        }

        public void GetData()
        {
            DataTable DTab = ObjLedgerGroup.GetData_Search();
            grdLedgerGroupMaster.DataSource = DTab;
        }

        private void FrmCountryMaster_Load(object sender, EventArgs e)
        {
            GetData();
            btnClear_Click(btnClear, null);
        }

        private void dgvItemGroupMaster_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {

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
                            dgvLedgerGroupMaster.ExportToPdf(Filepath);
                            break;
                        case "xls":
                            dgvLedgerGroupMaster.ExportToXls(Filepath);
                            break;
                        case "xlsx":
                            dgvLedgerGroupMaster.ExportToXlsx(Filepath);
                            break;
                        case "rtf":
                            dgvLedgerGroupMaster.ExportToRtf(Filepath);
                            break;
                        case "txt":
                            dgvLedgerGroupMaster.ExportToText(Filepath);
                            break;
                        case "html":
                            dgvLedgerGroupMaster.ExportToHtml(Filepath);
                            break;
                        case "csv":
                            dgvLedgerGroupMaster.ExportToCsv(Filepath);
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

        private void dgvLedgerGroupMaster_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (e.Clicks == 2)
                {
                    DataRow Drow = dgvLedgerGroupMaster.GetDataRow(e.RowHandle);
                    txtLedgerGroupCode.Text = Convert.ToString(Drow["ledger_group_id"]);
                    txtLedgerGroupName.Text = Convert.ToString(Drow["ledger_group_name"]);
                    RBtnStatus.EditValue = Convert.ToInt32(Drow["active"]);
                    txtRemark.Text = Convert.ToString(Drow["remark"]);
                }
            }
        }
    }
}
