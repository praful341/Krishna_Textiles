using BLL.PropertyClasses.Transaction;
using DLL;
using System;
using System.Data;

namespace BLL.FunctionClasses.Transaction
{
    public class JournalEntry
    {
        InterfaceLayer Ope = new InterfaceLayer();
        BLL.Validation Val = new BLL.Validation();

        public Journal_EntryProperty Save(Journal_EntryProperty pClsProperty, DLL.GlobalDec.EnumTran pEnum = DLL.GlobalDec.EnumTran.WithCommit, BeginTranConnection Conn = null)
        {
            try
            {
                Request Request = new Request();

                Request.AddParams("@payment_id", pClsProperty.payment_id, DbType.Int64);
                Request.AddParams("@voucher_no", pClsProperty.voucher_no, DbType.Int64);
                Request.AddParams("@company_id", pClsProperty.company_id, DbType.Int32);
                Request.AddParams("@branch_id", pClsProperty.branch_id, DbType.Int32);
                Request.AddParams("@location_id", pClsProperty.location_id, DbType.Int32);
                Request.AddParams("@department_id", pClsProperty.department_id, DbType.Int32);
                Request.AddParams("@union_id", pClsProperty.union_id, DbType.Int64);
                Request.AddParams("@transaction_date", pClsProperty.Journal_date, DbType.Date);
                Request.AddParams("@transaction_time", GlobalDec.gStr_SystemTime, DbType.String);
                Request.AddParams("@flag", pClsProperty.flag, DbType.String);
                Request.AddParams("@sr_no", pClsProperty.sr_no, DbType.Int32);
                Request.AddParams("@ledger_id", pClsProperty.ledger_id, DbType.Int64);
                Request.AddParams("@credit_amount", pClsProperty.credit_amount, DbType.Decimal);
                Request.AddParams("@debit_amount", pClsProperty.debit_amount, DbType.Decimal);
                Request.AddParams("@remarks", pClsProperty.remarks, DbType.String);
                Request.AddParams("@form_id", pClsProperty.form_id, DbType.Int32);
                Request.AddParams("@entry_user_id", GlobalDec.gEmployeeProperty.user_id, DbType.Int32);
                Request.AddParams("@entry_ip_address", GlobalDec.gStrComputerIP, DbType.String);
                Request.AddParams("@entry_date", Val.DBDate(BLL.GlobalDec.gStrServerDate), DbType.Date);
                Request.AddParams("@entry_time", GlobalDec.gStr_SystemTime, DbType.String);

                Request.AddParams("@purchase_id", pClsProperty.purchase_id, DbType.Int64);
                Request.AddParams("@purchase_return_id", pClsProperty.purchase_return_id, DbType.Int64);
                Request.AddParams("@invoice_id", pClsProperty.invoice_id, DbType.Int64);
                Request.AddParams("@sale_return_id", pClsProperty.sale_return_id, DbType.Int64);
                Request.AddParams("@against_ledger_id", pClsProperty.against_ledger_id, DbType.Int64);

                Request.CommandText = BLL.TPV.SProc.TRN_Journal_Entry_Save;
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
        public DataTable GetData(Int64 Union_ID)
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();
            Request.CommandText = BLL.TPV.SProc.TRN_Journal_Entry_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Request.AddParams("@union_id", Union_ID, DbType.Int64);
            Request.AddParams("@company_id", GlobalDec.gEmployeeProperty.company_id, DbType.Int32);
            Request.AddParams("@branch_id", GlobalDec.gEmployeeProperty.branch_id, DbType.Int32);
            Request.AddParams("@location_id", GlobalDec.gEmployeeProperty.location_id, DbType.Int32);
            Request.AddParams("@department_id", GlobalDec.gEmployeeProperty.department_id, DbType.Int32);

            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request);
            return DTab;
        }
        public int FindNewID()
        {
            int IntRes = 0;
            IntRes = Ope.FindNewID(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, "TRN_Journal_Entry", "isnull(MAX(voucher_no),0)", "");
            return IntRes;
        }
    }
}
