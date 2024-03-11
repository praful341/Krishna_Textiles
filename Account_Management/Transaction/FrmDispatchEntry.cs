using Account_Management.Class;
using BLL;
using BLL.FunctionClasses.Transaction;
using BLL.PropertyClasses.Transaction;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using static Account_Management.Class.Global;

namespace Account_Management.Transaction
{
    public partial class FrmDispatchEntry : DevExpress.XtraEditors.XtraForm
    {
        #region Data Member

        FormEvents objBOFormEvents = new FormEvents();
        BLL.BeginTranConnection Conn;
        Validation Val = new Validation();
        BLL.FormPer ObjPer = new BLL.FormPer();
        DataTable m_DTab;
        DataTable m_DTabDispatch;
        double OS_Amount = 0;
        double termDiscAmt = 0;
        double payAmt = 0;
        DispatchEntry objDispatchEntry = new DispatchEntry();
        Int64 IntRes = 0;
        int m_numForm_id = 0;
        DataTable m_dtbStatus;
        decimal Collect_Rate = 0;
        #endregion

        #region Constructor
        public FrmDispatchEntry()
        {
            InitializeComponent();
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
            objBOFormEvents.ObjToDispose.Add("");
            objBOFormEvents.ObjToDispose.Add(Val);
            objBOFormEvents.ObjToDispose.Add(objBOFormEvents);
        }
        #endregion

        #region Events

        private bool ValidateDetails()
        {
            bool blnFocus = false;
            List<ListError> lstError = new List<ListError>();
            try
            {
                //if (grdDispatchEntry.DataSource != null)
                //{
                //    m_DTab = (DataTable)grdDispatchEntry.DataSource;

                //    foreach (DataRow drw in m_DTab.Rows)
                //    {
                //        if (Val.ToDecimal(drw["payable"]) > 0)
                //        {
                //            if (Val.ToString(drw["payment_type"]) == "")
                //            {
                //                lstError.Add(new ListError(13, "Payment Type"));
                //                if (!blnFocus)
                //                {
                //                    blnFocus = true;
                //                }
                //            }
                //            if (Val.ToString(drw["Receive_date"]) == "")
                //            {
                //                lstError.Add(new ListError(13, "Receive Date"));
                //                if (!blnFocus)
                //                {
                //                    blnFocus = true;
                //                }
                //            }
                //            if (Val.ToInt(drw["currency_id"]) == 0)
                //            {
                //                lstError.Add(new ListError(13, "Currency"));
                //                if (!blnFocus)
                //                {
                //                    blnFocus = true;
                //                }
                //            }
                //            if (Val.ToDecimal(drw["exchange_rate"]) == 0)
                //            {
                //                lstError.Add(new ListError(12, "Exchange Rate"));
                //                if (!blnFocus)
                //                {
                //                    blnFocus = true;
                //                }
                //            }
                //            var result = DateTime.Compare(Convert.ToDateTime(drw["Receive_date"]), DateTime.Today);
                //            if (result > 0)
                //            {
                //                lstError.Add(new ListError(5, "Receive Date Not Be Greater Than Today Date"));
                //                if (!blnFocus)
                //                {
                //                    blnFocus = true;
                //                }
                //            }
                //        }
                //    }
                //}
            }
            catch (Exception ex)
            {
                lstError.Add(new ListError(ex));
            }
            return (!(BLL.General.ShowErrors(lstError)));
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

            //if (!ValidateDetails())
            //{
            //    btnSave.Enabled = true;
            //    return;
            //}
            DialogResult result = MessageBox.Show("Do you want to save data?", "Confirmation", MessageBoxButtons.YesNoCancel);
            if (result != DialogResult.Yes)
            {
                btnSave.Enabled = true;
                return;
            }
            DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = true;
            backgroundWorker_DispatchEntry.RunWorkerAsync();

            btnSave.Enabled = true;
            //if (!ValidateDetails())
            //{
            //    blnReturn = false;
            //    return;
            //}
        }

        #endregion
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            dtpFromDate.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
            dtpFromDate.Properties.Mask.EditMask = "dd/MMM/yyyy";
            dtpFromDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            dtpFromDate.Properties.CharacterCasing = CharacterCasing.Upper;
            dtpFromDate.EditValue = DateTime.Now;

            dtpToDate.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
            dtpToDate.Properties.Mask.EditMask = "dd/MMM/yyyy";
            dtpToDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            dtpToDate.Properties.CharacterCasing = CharacterCasing.Upper;
            dtpToDate.EditValue = DateTime.Now;
            CmbStatus.SelectedIndex = -1;
            grdDispatchEntry.DataSource = null;
            dtpFromDate.Focus();
        }
        private void backgroundWorker_DispatchEntry_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.Default;
                Conn = new BeginTranConnection(true, false);
                DispatchEntry objDispatchEntry = new DispatchEntry();
                DispatchEntry_Property DispatchEntryProperty = new DispatchEntry_Property();
                IntRes = 0;
                try
                {
                    m_DTab = (DataTable)grdDispatchEntry.DataSource;
                    m_DTab.AcceptChanges();

                    foreach (DataRow drw in m_DTab.Rows)
                    {
                        DispatchEntryProperty.dispatch_id = Val.ToInt64(drw["dispatch_id"]);
                        DispatchEntryProperty.invoice_id = Val.ToInt64(drw["invoice_id"]);
                        DispatchEntryProperty.order_date = Val.DBDate(drw["invoice_date"].ToString());
                        DispatchEntryProperty.order_no = Val.ToString(drw["order_no"]);

                        DispatchEntryProperty.employee_id = Val.ToInt64(drw["employee_id"]);
                        DispatchEntryProperty.dispatch_date = Val.DBDate(drw["dispatch_date"].ToString());
                        DispatchEntryProperty.dispatch_time = Val.ToString(GlobalDec.gStr_SystemTime);

                        DispatchEntryProperty.from_courier_id = Val.ToInt64(drw["from_courier_id"]);
                        DispatchEntryProperty.to_courier_id = Val.ToInt64(drw["to_courier_id"]);

                        DispatchEntryProperty.awb_no = Val.ToString(drw["awb_no"]);
                        DispatchEntryProperty.paid_amount = Val.ToDecimal(drw["collect_rate"]);
                        DispatchEntryProperty.shipping_amount = Val.ToDecimal(drw["shipping_amount"]);

                        DispatchEntryProperty.status = Val.ToString(drw["status"]);
                        DispatchEntryProperty.remarks = Val.ToString(drw["remarks"]);
                        DispatchEntryProperty.form_id = m_numForm_id;

                        IntRes = objDispatchEntry.Save(DispatchEntryProperty, DLL.GlobalDec.EnumTran.Continue, Conn);
                    }
                    Conn.Inter1.Commit();
                }
                catch (Exception ex)
                {
                    IntRes = -1;
                    Conn.Inter1.Rollback();
                    Conn = null;
                    General.ShowErrors(ex.ToString());
                    return;
                }
                finally
                {
                    DispatchEntryProperty = null;
                }
            }
            catch (Exception ex)
            {
                IntRes = -1;
                Conn.Inter1.Rollback();
                Conn = null;
                Global.Message(ex.ToString());
                if (ex.InnerException != null)
                {
                    Global.Message(ex.InnerException.ToString());
                }
            }
        }
        private void backgroundWorker_DispatchEntry_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (IntRes > 0)
                {
                    Global.Confirm("Dispatch Entry Save Succesfully");
                    btnClear_Click(null, null);
                }
                else
                {
                    Global.Confirm("Error In Save Dispatch Entry");
                }
            }
            catch (Exception ex)
            {
                Global.Message(ex.ToString());
                Global.Message(ex.InnerException.ToString());
            }
        }
        private void FrmDispatchEntry_Load(object sender, EventArgs e)
        {
            Global.LOOKUPFromCourierRep(RepFromCourier);
            Global.LOOKUPToCourierRep(RepToCourier);

            btnClear_Click(null, null);

            m_dtbStatus = new DataTable();
            m_dtbStatus.Columns.Add("status");
            m_dtbStatus.Rows.Add("ALL");
            m_dtbStatus.Rows.Add("PENDING");
            m_dtbStatus.Rows.Add("COMPLETED");
            RepStatus.DataSource = m_dtbStatus;
            RepStatus.ValueMember = "status";
            RepStatus.DisplayMember = "status";
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
                            dgvDispatchEntry.ExportToPdf(Filepath);
                            break;
                        case "xls":
                            dgvDispatchEntry.ExportToXls(Filepath);
                            break;
                        case "xlsx":
                            dgvDispatchEntry.ExportToXlsx(Filepath);
                            break;
                        case "rtf":
                            dgvDispatchEntry.ExportToRtf(Filepath);
                            break;
                        case "txt":
                            dgvDispatchEntry.ExportToText(Filepath);
                            break;
                        case "html":
                            dgvDispatchEntry.ExportToHtml(Filepath);
                            break;
                        case "csv":
                            dgvDispatchEntry.ExportToCsv(Filepath);
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
            Export("xlsx", "Export to Excel", "Excel files 97-2003 (Excel files 2007(*.xlsx)|*.xlsx|All files (*.*)|*.*");
        }
        private void MNExportPDF_Click(object sender, EventArgs e)
        {
            Export("pdf", "Export Report to PDF", "PDF (*.PDF)|*.PDF");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DispatchEntry objDispatchEntry = new DispatchEntry();
            DispatchEntry_Property DispatchEntry_Property = new DispatchEntry_Property();
            DispatchEntry_Property.from_date = Val.DBDate(dtpFromDate.Text);
            DispatchEntry_Property.to_date = Val.DBDate(dtpToDate.Text);
            DispatchEntry_Property.status = Val.ToString(CmbStatus.Text);

            m_DTabDispatch = objDispatchEntry.GetData(DispatchEntry_Property);
            grdDispatchEntry.DataSource = m_DTabDispatch;
        }

        private void CalculateGridAmount(int rowindex)
        {
            try
            {
                decimal weight = Math.Round(Val.ToDecimal(dgvDispatchEntry.GetRowCellValue(rowindex, "weight")), 3);
                Int64 Courier_ID = Val.ToInt64(dgvDispatchEntry.GetRowCellValue(rowindex, "to_courier_id"));

                DataTable DTab_Courier_Rate = objDispatchEntry.Get_Courier_Rate(Val.ToInt64(dgvDispatchEntry.GetRowCellValue(rowindex, "to_courier_id")), Val.ToDecimal(dgvDispatchEntry.GetRowCellValue(rowindex, "weight")));

                if (DTab_Courier_Rate.Rows.Count > 0)
                {
                    Collect_Rate = Val.ToDecimal(DTab_Courier_Rate.Rows[0]["collect_rate"].ToString());
                    dgvDispatchEntry.SetRowCellValue(rowindex, "collect_rate", Collect_Rate);
                }
                else
                {
                    dgvDispatchEntry.SetRowCellValue(rowindex, "collect_rate", 0);
                }



                //dgvDispatchEntry.SetRowCellValue(dgvDispatchEntry.FocusedRowHandle, "collect_rate", type.GetColumnValue("collect_rate"));
                //double amount = Math.Round(Val.ToDouble(dgvPurchase.GetRowCellValue(rowindex, "SGST_Rate")) + Val.ToDouble(dgvPurchase.GetRowCellValue(rowindex, "IGST_Rate")) + Val.ToDouble(dgvPurchase.GetRowCellValue(rowindex, "CGST_Rate")), 2);
                //dgvPurchase.SetRowCellValue(rowindex, "NetAmount", Math.Round(Val.ToDouble(dgvPurchase.GetRowCellValue(rowindex, "Gross_Amt")) - Val.ToDouble(dgvPurchase.GetRowCellValue(rowindex, "Discount")) , 2));

            }
            catch (Exception ex)
            {
            }
        }

        private void dgvDispatchEntry_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            if (e.PrevFocusedColumn != null && e.PrevFocusedColumn.FieldName == "to_courier_id")
            {
                CalculateGridAmount(dgvDispatchEntry.FocusedRowHandle);
            }
        }
    }
}
