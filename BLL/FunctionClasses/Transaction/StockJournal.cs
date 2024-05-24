using BLL.PropertyClasses.Transaction;
using DLL;
using System;
using System.Data;

namespace BLL.FunctionClasses.Transaction
{
    public class StockJournal
    {
        InterfaceLayer Ope = new InterfaceLayer();
        BLL.Validation Val = new BLL.Validation();

        public StockJournalProperty Save(StockJournalProperty pClsProperty, DLL.GlobalDec.EnumTran pEnum = DLL.GlobalDec.EnumTran.WithCommit, BeginTranConnection Conn = null)
        {
            try
            {
                Request Request = new Request();

                Request.AddParams("@stock_journal_id", pClsProperty.stock_journal_id, DbType.Int64);
                Request.AddParams("@journal_date", pClsProperty.journal_date, DbType.Date);
                Request.AddParams("@company_id", GlobalDec.gEmployeeProperty.company_id, DbType.Int64);
                Request.AddParams("@branch_id", GlobalDec.gEmployeeProperty.branch_id, DbType.Int64);
                Request.AddParams("@location_id", GlobalDec.gEmployeeProperty.location_id, DbType.Int64);
                Request.AddParams("@department_id", GlobalDec.gEmployeeProperty.department_id, DbType.Int64);
                Request.AddParams("@remarks", pClsProperty.remarks, DbType.String);
                Request.AddParams("@form_id", pClsProperty.form_id, DbType.Int64);
                Request.AddParams("@union_id", pClsProperty.union_id, DbType.Int64);

                Request.AddParams("@from_srno", pClsProperty.from_srno, DbType.Int32);
                Request.AddParams("@from_item_id", pClsProperty.from_item_id, DbType.Int32);
                Request.AddParams("@from_color_id", pClsProperty.from_color_id, DbType.Int32);
                Request.AddParams("@from_size_id", pClsProperty.from_size_id, DbType.Int32);
                Request.AddParams("@from_pcs", pClsProperty.from_pcs, DbType.Decimal);
                Request.AddParams("@from_rate", pClsProperty.from_rate, DbType.Decimal);
                Request.AddParams("@from_amount", pClsProperty.from_amount, DbType.Decimal);
                Request.AddParams("@to_srno", pClsProperty.to_srno, DbType.Int32);
                Request.AddParams("@to_item_id", pClsProperty.to_item_id, DbType.Int32);
                Request.AddParams("@to_color_id", pClsProperty.to_color_id, DbType.Int32);
                Request.AddParams("@to_size_id", pClsProperty.to_size_id, DbType.Int32);
                Request.AddParams("@to_pcs", pClsProperty.to_pcs, DbType.Decimal);
                Request.AddParams("@to_rate", pClsProperty.to_rate, DbType.Decimal);
                Request.AddParams("@to_amount", pClsProperty.to_amount, DbType.Decimal);

                Request.AddParams("@entry_user_id", GlobalDec.gEmployeeProperty.user_id, DbType.Int32);
                Request.AddParams("@entry_date", Val.DBDate(BLL.GlobalDec.gStrServerDate), DbType.Date);
                Request.AddParams("@entry_time", GlobalDec.gStr_SystemTime, DbType.String);
                Request.AddParams("@entry_ip_address", GlobalDec.gStrComputerIP, DbType.String);

                Request.CommandText = BLL.TPV.SProc.TRN_Stock_Journal_Save;
                Request.CommandType = CommandType.StoredProcedure;

                DataTable p_dtbMasterId = new DataTable();

                if (Conn != null)
                    Conn.Inter1.GetDataTable(DBConnections.ConnectionString, DBConnections.ProviderName, p_dtbMasterId, Request, pEnum);
                else
                    Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, p_dtbMasterId, Request);

                if (p_dtbMasterId != null)
                {
                    if (p_dtbMasterId.Rows.Count > 0)
                    {
                        pClsProperty.union_id = Convert.ToInt32(p_dtbMasterId.Rows[0][0]);
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
    }
}
