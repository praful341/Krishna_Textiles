using BLL.PropertyClasses.Transaction;
using DLL;
using System;
using System.Data;
namespace BLL.FunctionClasses.Account
{
    public class SaleReturnPaymentGiven
    {
        InterfaceLayer Ope = new InterfaceLayer();
        Validation Val = new Validation();

        #region Other Function

        public SaleReturnPaymentGiven_Property PaymentGiven_Save(SaleReturnPaymentGiven_Property pClsProperty, DLL.GlobalDec.EnumTran pEnum = DLL.GlobalDec.EnumTran.WithCommit, BeginTranConnection Conn = null)
        {
            try
            {
                Request Request = new Request();

                Request.AddParams("@payment_id", pClsProperty.payment_id, DbType.Int64);
                Request.AddParams("@voucher_no", pClsProperty.voucher_no, DbType.Int64);
                Request.AddParams("@company_id", GlobalDec.gEmployeeProperty.company_id, DbType.Int64);
                Request.AddParams("@branch_id", GlobalDec.gEmployeeProperty.branch_id, DbType.Int64);
                Request.AddParams("@location_id", GlobalDec.gEmployeeProperty.location_id, DbType.Int64);
                Request.AddParams("@department_id", GlobalDec.gEmployeeProperty.department_id, DbType.Int64);
                Request.AddParams("@union_id", pClsProperty.union_id, DbType.Int64);
                Request.AddParams("@payment_date", pClsProperty.payment_date, DbType.Date);
                Request.AddParams("@payment_time", GlobalDec.gStr_SystemTime, DbType.String);
                Request.AddParams("@payment_type", pClsProperty.payment_type, DbType.String);
                Request.AddParams("@sr_no", pClsProperty.sr_no, DbType.Int64);
                Request.AddParams("@method", pClsProperty.method, DbType.String);
                Request.AddParams("@purchase_id", pClsProperty.purchase_id, DbType.Int64);
                Request.AddParams("@invoice_id", pClsProperty.invoice_id, DbType.Int64);
                Request.AddParams("@sale_return_id", pClsProperty.sale_return_id, DbType.Int64);
                Request.AddParams("@reference", pClsProperty.reference, DbType.String);
                Request.AddParams("@bank_id", pClsProperty.bank_id, DbType.Int64);
                Request.AddParams("@ledger_id", pClsProperty.ledger_id, DbType.Int64);
                Request.AddParams("@credit_amount", pClsProperty.credit_amount, DbType.Decimal);
                Request.AddParams("@against_ledger_id", pClsProperty.against_ledger_id, DbType.Int64);
                Request.AddParams("@debit_amount", pClsProperty.debit_amount, DbType.Decimal);
                Request.AddParams("@remarks", pClsProperty.remarks, DbType.String);
                Request.AddParams("@entry_user_id", GlobalDec.gEmployeeProperty.user_id, DbType.Int32);
                Request.AddParams("@entry_date", Val.DBDate(BLL.GlobalDec.gStrServerDate), DbType.Date);
                Request.AddParams("@entry_time", GlobalDec.gStr_SystemTime, DbType.String);
                Request.AddParams("@entry_ip_address", GlobalDec.gStrComputerIP, DbType.String);
                Request.AddParams("@form_id", pClsProperty.form_id, DbType.Int64);

                Request.CommandText = BLL.TPV.SProc.TRN_Payment_Given_Save;
                Request.CommandType = CommandType.StoredProcedure;
                DataTable p_dtbUnionId = new DataTable();

                if (Conn != null)
                    Conn.Inter1.GetDataTable(DBConnections.ConnectionString, DBConnections.ProviderName, p_dtbUnionId, Request, pEnum);
                else
                    Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, p_dtbUnionId, Request);

                if (p_dtbUnionId != null)
                {
                    if (p_dtbUnionId.Rows.Count > 0)
                    {
                        pClsProperty.union_id = Val.ToInt64(p_dtbUnionId.Rows[0][0]);
                    }
                }
                else
                {
                    pClsProperty.union_id = 0;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return pClsProperty;
        }
        public Int64 ISLadgerName_GetData(string pLedger_Name)
        {
            Int64 IntLedgerId = 0;
            IntLedgerId = Val.ToInt64(Ope.FindText(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, "MST_Ledger", "ledger_id", " And ledger_name = '" + pLedger_Name + "'"));

            if (IntLedgerId == 0)
            {
                return 0;
            }
            else
            {
                return IntLedgerId;
            }
        }
        public int FindNewID()
        {
            int IntRes = 0;
            IntRes = Ope.FindNewID(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, "TRN_Payment_Given", "isnull(MAX(voucher_no),0)", "");
            return IntRes;
        }
        public DataTable Sale_Invoice_Search_GetData(Int64 Ledger_ID)
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();
            Request.CommandText = BLL.TPV.SProc.TRN_Payment_OS_Sale_Wise;
            Request.CommandType = CommandType.StoredProcedure;
            Request.AddParams("@ledger_id", Ledger_ID, DbType.Int64);

            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request);
            return DTab;
        }
        public DataTable PaymentGiven_Search_GetData(Int64 Ledger_ID, string Type)
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();
            Request.CommandText = BLL.TPV.SProc.TRN_Referance_PaymentGiven_SearchData;
            Request.CommandType = CommandType.StoredProcedure;
            Request.AddParams("@ledger_id", Ledger_ID, DbType.Int64);
            Request.AddParams("@company_id", GlobalDec.gEmployeeProperty.company_id, DbType.Int64);
            Request.AddParams("@branch_id", GlobalDec.gEmployeeProperty.branch_id, DbType.Int64);
            Request.AddParams("@location_id", GlobalDec.gEmployeeProperty.location_id, DbType.Int64);
            Request.AddParams("@department_id", GlobalDec.gEmployeeProperty.department_id, DbType.Int64);
            Request.AddParams("@type", Type, DbType.String);

            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request);
            return DTab;
        }

        public Int64 Ref_PaymentGiven_Update(SaleReturnPaymentGiven_Property pClsProperty, DLL.GlobalDec.EnumTran pEnum = DLL.GlobalDec.EnumTran.WithCommit, BeginTranConnection Conn = null)
        {
            Int64 IntRes = 0;
            try
            {
                Request Request = new Request();

                Request.AddParams("@payment_id", pClsProperty.payment_id, DbType.Int64);
                Request.AddParams("@company_id", GlobalDec.gEmployeeProperty.company_id, DbType.Int64);
                Request.AddParams("@branch_id", GlobalDec.gEmployeeProperty.branch_id, DbType.Int64);
                Request.AddParams("@location_id", GlobalDec.gEmployeeProperty.location_id, DbType.Int64);
                Request.AddParams("@department_id", GlobalDec.gEmployeeProperty.department_id, DbType.Int64);
                Request.AddParams("@method", pClsProperty.method, DbType.String);
                Request.AddParams("@purchase_id", pClsProperty.purchase_id, DbType.Int64);

                Request.CommandText = BLL.TPV.SProc.TRN_Referance_Payment_Update;
                Request.CommandType = CommandType.StoredProcedure;
                DataTable p_dtbUnionId = new DataTable();

                if (Conn != null)
                    IntRes = Conn.Inter1.ExecuteNonQuery(DBConnections.ConnectionString, DBConnections.ProviderName, Request, pEnum);
                else
                    IntRes = Ope.ExecuteNonQuery(DBConnections.ConnectionString, DBConnections.ProviderName, Request);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return IntRes;
        }
        public DataSet Account_Ledger_GetData(Int64 Union_ID)
        {
            DataSet DTab = new DataSet();
            Request Request = new Request();
            Request.CommandText = BLL.TPV.SProc.TRN_Payment_GivenFillData;
            Request.CommandType = CommandType.StoredProcedure;
            Request.AddParams("@union_id", Union_ID, DbType.Int64);
            Request.AddParams("@company_id", GlobalDec.gEmployeeProperty.company_id, DbType.Int64);
            Request.AddParams("@branch_id", GlobalDec.gEmployeeProperty.branch_id, DbType.Int64);
            Request.AddParams("@location_id", GlobalDec.gEmployeeProperty.location_id, DbType.Int64);
            Request.AddParams("@department_id", GlobalDec.gEmployeeProperty.department_id, DbType.Int64);

            Ope.GetDataSet(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, "", Request);
            return DTab;
        }
        #endregion
    }
}
