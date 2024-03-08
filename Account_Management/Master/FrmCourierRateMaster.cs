using Account_Management.Class;
using BLL;
using BLL.FunctionClasses.Master;
using BLL.PropertyClasses.Master;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using static Account_Management.Class.Global;

namespace Account_Management.Master
{
    public partial class FrmCourierRateMaster : DevExpress.XtraEditors.XtraForm
    {
        #region Data Member

        FormEvents objBOFormEvents;
        Validation Val;
        BLL.FormPer ObjPer;
        CourierMaster objCourier;
        int m_numForm_id;

        #endregion

        #region Constructor
        public FrmCourierRateMaster()
        {
            InitializeComponent();

            objBOFormEvents = new FormEvents();
            Val = new Validation();
            ObjPer = new BLL.FormPer();
            objCourier = new CourierMaster();
            m_numForm_id = 0;
        }
        public void ShowForm()
        {
            ObjPer.FormName = this.Name.ToUpper();
            m_numForm_id = ObjPer.form_id;
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
            objBOFormEvents.ObjToDispose.Add(objCourier);
            objBOFormEvents.ObjToDispose.Add(Val);
            objBOFormEvents.ObjToDispose.Add(objBOFormEvents);
        }

        #endregion

        #region Events
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
                btnClear_Click(sender, e);
            }
            btnSave.Enabled = true;
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                LueCourierName.EditValue = null;
                GrdCourierRate.DataSource = null;
                LueCourierName.Focus();
            }
            catch (Exception ex)
            {
                BLL.General.ShowErrors(ex);
                return;
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region GridEvent
        #endregion        
        #endregion

        #region Functions
        private bool SaveDetails()
        {
            bool blnReturn = true;
            Courier_MasterProperty CourierMasterProperty = new Courier_MasterProperty();
            CourierMaster objCourier = new CourierMaster();

            try
            {
                if (!ValidateDetails())
                {
                    blnReturn = false;
                    return blnReturn;
                }
                int IntRes = 0;
                DataTable DTab = (System.Data.DataTable)GrdCourierRate.DataSource;
                DTab.AcceptChanges();

                foreach (DataRow DRow in DTab.Rows)
                {
                    CourierMasterProperty = new Courier_MasterProperty();

                    CourierMasterProperty.courier_rate_id = Val.ToInt64(DRow["courier_rate_id"]);
                    CourierMasterProperty.courier_id = Val.ToInt64(LueCourierName.EditValue);
                    CourierMasterProperty.form_id = m_numForm_id;

                    CourierMasterProperty.weight = Val.ToDecimal(DRow["weight"]);
                    CourierMasterProperty.rate = Val.ToDecimal(DRow["rate"]);

                    IntRes = objCourier.Courier_Rate_Save(CourierMasterProperty);
                }

                if (IntRes == -1)
                {
                    Global.Confirm("Error In Save Courier Rate Details");
                    LueCourierName.Focus();
                }
                else
                {
                    Global.Confirm("Courier Rate Details Data Save Successfully");
                }

            }
            catch (Exception ex)
            {
                General.ShowErrors(ex.ToString());
                blnReturn = false;
            }
            finally
            {
                CourierMasterProperty = null;
            }

            return blnReturn;
        }
        private bool ValidateDetails()
        {
            bool blnFocus = false;
            List<ListError> lstError = new List<ListError>();
            try
            {
                if (LueCourierName.Text == string.Empty)
                {
                    lstError.Add(new ListError(12, "Courier Name"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                        LueCourierName.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                lstError.Add(new ListError(ex));
            }
            return (!(BLL.General.ShowErrors(lstError)));

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
                            dgvCourierRate.ExportToPdf(Filepath);
                            break;
                        case "xls":
                            dgvCourierRate.ExportToXls(Filepath);
                            break;
                        case "xlsx":
                            dgvCourierRate.ExportToXlsx(Filepath);
                            break;
                        case "rtf":
                            dgvCourierRate.ExportToRtf(Filepath);
                            break;
                        case "txt":
                            dgvCourierRate.ExportToText(Filepath);
                            break;
                        case "html":
                            dgvCourierRate.ExportToHtml(Filepath);
                            break;
                        case "csv":
                            dgvCourierRate.ExportToCsv(Filepath);
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
            Export("xlsx", "Export to Excel", "Excel files 97-2003 (Excel files 2007(*.xlsx)|*.xlsx|All files (*.*)|*.*");
        }
        private void MNExportPDF_Click(object sender, EventArgs e)
        {
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

        private void LueCourierName_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmCourierMaster frmCnt = new FrmCourierMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPCourier(LueCourierName);
            }
        }
        private void FrmCourierRateMaster_Load(object sender, EventArgs e)
        {
            try
            {
                Global.LOOKUPCourier(LueCourierName);
                btnClear_Click(btnClear, null);
            }
            catch (Exception ex)
            {
                BLL.General.ShowErrors(ex);
                return;
            }
        }

        private void LueCourierName_Validated(object sender, EventArgs e)
        {
            if (LueCourierName.Text != "")
            {
                DataTable DTab = objCourier.Courier_Rate_GetData(Val.ToInt64(LueCourierName.EditValue));
                GrdCourierRate.DataSource = DTab;
                dgvCourierRate.FocusedColumn = dgvCourierRate.Columns["rate"];
                dgvCourierRate.ShowEditor();
            }
        }
    }
}
