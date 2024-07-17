using Account_Management.Class;
using Account_Management.Report;
using BLL;
using BLL.FunctionClasses.Account;
using BLL.PropertyClasses.Transaction;
using System;
using System.Data;
using System.Windows.Forms;

namespace Account_Management.Transaction
{
    public partial class FrmPaymentReceiptPrintSearch : DevExpress.XtraEditors.XtraForm
    {
        #region Declaration

        Validation Val = new Validation();
        public DataTable DTab = new DataTable();
        public DataTable DTab_Payment_Receipt_Data = new DataTable();
        PaymentReceipt objPaymentReceipt = new PaymentReceipt();
        FormEvents objBOFormEvents = new FormEvents();
        public FrmPaymentReceipt FrmPaymentReceipt = new FrmPaymentReceipt();

        #endregion

        #region Constructor
        public FrmPaymentReceiptPrintSearch()
        {
            InitializeComponent();
        }

        public void ShowForm(FrmPaymentReceipt ObjForm, string Type)
        {
            FrmPaymentReceipt = new FrmPaymentReceipt();
            FrmPaymentReceipt = ObjForm;
            Val.frmGenSetForPopup(this);
            AttachFormEvents();
            this.ShowDialog();
        }
        private void AttachFormEvents()
        {
            objBOFormEvents.CurForm = this;
            objBOFormEvents.FormKeyPress = true;
            objBOFormEvents.FormResize = true;
            objBOFormEvents.FormClosing = true;
            objBOFormEvents.ObjToDispose.Add(Val);
            objBOFormEvents.ObjToDispose.Add(objBOFormEvents);
        }
        #endregion

        #region Form Events
        private void FrmPaymentReceiptPrintSearch_Load(object sender, EventArgs e)
        {
            try
            {
                Global.LOOKUPCashBankWithoutLedger(lueParty);

                DTPFromDate.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
                DTPFromDate.Properties.Mask.EditMask = "dd-MM-yyyy";
                DTPFromDate.Properties.Mask.UseMaskAsDisplayFormat = true;
                DTPFromDate.Properties.CharacterCasing = CharacterCasing.Upper;
                DTPFromDate.EditValue = DateTime.Now;

                DTPToDate.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
                DTPToDate.Properties.Mask.EditMask = "dd-MM-yyyy";
                DTPToDate.Properties.Mask.UseMaskAsDisplayFormat = true;
                DTPToDate.Properties.CharacterCasing = CharacterCasing.Upper;

                DTPToDate.EditValue = DateTime.Now;
                DTPFromDate.Focus();
            }
            catch (Exception ex)
            {
                Global.ErrorMessage(ex.Message);
            }
        }
        private void FrmPaymentReceiptPrintSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PaymentReceipt_Property PaymentReceiptProperty = new PaymentReceipt_Property();

            PaymentReceiptProperty.voucher_no_trim = Val.Trim(lueVoucherNo.EditValue);
            PaymentReceiptProperty.ledger_id = Val.ToInt64(lueParty.EditValue);
            PaymentReceiptProperty.from_date = Val.DBDate(DTPFromDate.Text);
            PaymentReceiptProperty.to_date = Val.DBDate(DTPToDate.Text);

            DataTable DTab_Payment_Rec = objPaymentReceipt.Payment_Receipt_Print_GetData(PaymentReceiptProperty);

            if (DTab_Payment_Rec.Rows.Count > 0)
            {
                FrmReportViewer FrmReportViewer = new FrmReportViewer();
                FrmReportViewer.DS.Tables.Add(DTab_Payment_Rec);
                FrmReportViewer.GroupBy = "";
                FrmReportViewer.RepName = "";
                FrmReportViewer.RepPara = "";
                this.Cursor = Cursors.Default;
                FrmReportViewer.AllowSetFormula = true;

                FrmReportViewer.ShowForm("Payment_Receipt", 120, FrmReportViewer.ReportFolder.PAYMENT_RECEIPT);

                DTab_Payment_Rec = null;
                FrmReportViewer.DS.Tables.Clear();
                FrmReportViewer.DS.Clear();
                FrmReportViewer = null;
            }
            else
            {
                Global.Message("Data Not Found..");
                return;
            }
        }
        private void lueParty_Validated(object sender, EventArgs e)
        {
            DataTable DTab_Payment_Rec = objPaymentReceipt.Payment_Receipt_Voucher_No_GetData(Val.ToInt64(lueParty.EditValue), Val.ToString("PAYMENT_RECEIPT"));

            lueVoucherNo.Properties.DataSource = DTab_Payment_Rec;
            lueVoucherNo.Properties.DisplayMember = "voucher_no";
            lueVoucherNo.Properties.ValueMember = "voucher_no";
        }

        private void FrmPaymentReceiptPrintSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.F1)
            {
                FrmLedgerMaster frmCnt = new FrmLedgerMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPCashBankWithoutLedger(lueParty);
            }
        }
    }
}