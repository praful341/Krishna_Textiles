using BLL.PropertyClasses.Transaction;
using DLL;
using System;
using System.Data;

namespace BLL.FunctionClasses.Transaction
{
    public class Purchase
    {
        InterfaceLayer Ope = new InterfaceLayer();
        BLL.Validation Val = new BLL.Validation();

        public Purchase_Property Save(Purchase_Property pClsProperty, DLL.GlobalDec.EnumTran pEnum = DLL.GlobalDec.EnumTran.WithCommit, BeginTranConnection Conn = null)
        {
            try
            {
                Request Request = new Request();

                Request.AddParams("@purchase_id", pClsProperty.purchase_id, DbType.Int64);
                Request.AddParams("@fin_year_id", GlobalDec.gEmployeeProperty.gFinancialYear_Code, DbType.Int64);
                Request.AddParams("@janged_id", pClsProperty.janged_id, DbType.Int64);
                Request.AddParams("@voucher_No", pClsProperty.voucher_no, DbType.Int64);
                Request.AddParams("@firm_id", pClsProperty.firm_id, DbType.Int64);
                Request.AddParams("@purchase_date", pClsProperty.purchase_date, DbType.Date);
                Request.AddParams("@purchase_time", GlobalDec.gStr_SystemTime, DbType.String);
                Request.AddParams("@company_id", GlobalDec.gEmployeeProperty.company_id, DbType.Int32);
                Request.AddParams("@branch_id", GlobalDec.gEmployeeProperty.branch_id, DbType.Int32);
                Request.AddParams("@location_id", GlobalDec.gEmployeeProperty.location_id, DbType.Int32);
                Request.AddParams("@department_id", GlobalDec.gEmployeeProperty.department_id, DbType.Int32);
                Request.AddParams("@purchase_bill_no", pClsProperty.purchase_bill_no, DbType.String);
                Request.AddParams("@gst_id", pClsProperty.gst_id, DbType.Int32);
                Request.AddParams("@ledger_id", pClsProperty.ledger_id, DbType.Int32);
                Request.AddParams("@total_pcs", pClsProperty.total_pcs, DbType.Decimal);
                Request.AddParams("@igst_per", pClsProperty.igst_rate, DbType.Decimal);
                Request.AddParams("@igst_amount", pClsProperty.igst_amount, DbType.Decimal);
                Request.AddParams("@cgst_per", pClsProperty.cgst_rate, DbType.Decimal);
                Request.AddParams("@cgst_amount", pClsProperty.cgst_amount, DbType.Decimal);
                Request.AddParams("@sgst_per", pClsProperty.sgst_rate, DbType.Decimal);
                Request.AddParams("@sgst_amount", pClsProperty.sgst_amount, DbType.Decimal);
                Request.AddParams("@discount_per", pClsProperty.discount_per, DbType.Decimal);
                Request.AddParams("@discount_amount", pClsProperty.discount_amount, DbType.Decimal);
                Request.AddParams("@gross_amount", pClsProperty.gross_amount, DbType.Decimal);
                Request.AddParams("@round_of_amount", pClsProperty.round_of_amount, DbType.Decimal);
                Request.AddParams("@net_amount", pClsProperty.net_amount, DbType.Decimal);
                Request.AddParams("@remarks", pClsProperty.remarks, DbType.String);

                Request.AddParams("@entry_user_id", GlobalDec.gEmployeeProperty.user_id, DbType.Int32);
                Request.AddParams("@entry_date", Val.DBDate(BLL.GlobalDec.gStrServerDate), DbType.Date);
                Request.AddParams("@entry_time", GlobalDec.gStr_SystemTime, DbType.String);
                Request.AddParams("@entry_ip_address", GlobalDec.gStrComputerIP, DbType.String);

                Request.AddParams("@update_user_id", GlobalDec.gEmployeeProperty.user_id, DbType.Int32);
                Request.AddParams("@update_date", Val.DBDate(BLL.GlobalDec.gStrServerDate), DbType.Date);
                Request.AddParams("@update_time", GlobalDec.gStr_SystemTime, DbType.String);
                Request.AddParams("@update_ip_address", GlobalDec.gStrComputerIP, DbType.String);

                Request.AddParams("@form_id", pClsProperty.form_id, DbType.Int64);
                Request.AddParams("@term_days", pClsProperty.term_days, DbType.Int32);
                Request.AddParams("@due_date", pClsProperty.due_date, DbType.Date);

                Request.CommandText = BLL.TPV.SProc.TRN_Purchase_Save;
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
                        pClsProperty.purchase_id = Convert.ToInt32(p_dtbMasterId.Rows[0][0]);
                    }
                }
                else
                {
                    pClsProperty.purchase_id = 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return pClsProperty;
        }
        public int Save_Detail(Purchase_Property pClsProperty, DLL.GlobalDec.EnumTran pEnum = DLL.GlobalDec.EnumTran.WithCommit, BeginTranConnection Conn = null)
        {
            try
            {
                int IntRes = 0;
                Request RequestDetails = new Request();

                RequestDetails.AddParams("@purchase_detail_id", pClsProperty.purchase_detail_id, DbType.Int64);
                RequestDetails.AddParams("@purchase_id", pClsProperty.purchase_id, DbType.Int64);
                RequestDetails.AddParams("@lot_srno", pClsProperty.sr_no, DbType.Int32);
                RequestDetails.AddParams("@company_id", GlobalDec.gEmployeeProperty.company_id, DbType.Int32);
                RequestDetails.AddParams("@branch_id", GlobalDec.gEmployeeProperty.branch_id, DbType.Int32);
                RequestDetails.AddParams("@location_id", GlobalDec.gEmployeeProperty.location_id, DbType.Int32);
                RequestDetails.AddParams("@department_id", GlobalDec.gEmployeeProperty.department_id, DbType.Int32);
                RequestDetails.AddParams("@item_id", pClsProperty.item_id, DbType.Int64);
                RequestDetails.AddParams("@color_id", pClsProperty.color_id, DbType.Int64);
                RequestDetails.AddParams("@size_id", pClsProperty.size_id, DbType.Int64);
                RequestDetails.AddParams("@pcs", pClsProperty.pcs, DbType.Decimal);
                RequestDetails.AddParams("@unit_id", pClsProperty.unit_id, DbType.Int64);
                RequestDetails.AddParams("@rate", pClsProperty.rate, DbType.Decimal);
                RequestDetails.AddParams("@amount", pClsProperty.amount, DbType.Decimal);

                RequestDetails.AddParams("@old_item_id", pClsProperty.old_item_id, DbType.Int64);
                RequestDetails.AddParams("@old_size_id", pClsProperty.old_size_id, DbType.Int64);
                RequestDetails.AddParams("@old_color_id", pClsProperty.old_color_id, DbType.Int64);
                RequestDetails.AddParams("@old_pcs", pClsProperty.old_pcs, DbType.Decimal);
                RequestDetails.AddParams("@flag", pClsProperty.flag, DbType.Int32);

                RequestDetails.AddParams("@entry_user_id", GlobalDec.gEmployeeProperty.user_id, DbType.Int32);
                RequestDetails.AddParams("@entry_date", Val.DBDate(BLL.GlobalDec.gStrServerDate), DbType.Date);
                RequestDetails.AddParams("@entry_time", GlobalDec.gStr_SystemTime, DbType.String);
                RequestDetails.AddParams("@entry_ip_address", GlobalDec.gStrComputerIP, DbType.String);

                RequestDetails.AddParams("@update_user_id", GlobalDec.gEmployeeProperty.user_id, DbType.Int32);
                RequestDetails.AddParams("@update_date", Val.DBDate(BLL.GlobalDec.gStrServerDate), DbType.Date);
                RequestDetails.AddParams("@update_time", GlobalDec.gStr_SystemTime, DbType.String);
                RequestDetails.AddParams("@update_ip_address", GlobalDec.gStrComputerIP, DbType.String);

                //RequestDetails.AddParams("@janged_id", pClsProperty.janged_id, DbType.Int64);
                //RequestDetails.AddParams("@janged_detail_id", pClsProperty.janged_detail_id, DbType.Int64);
                //RequestDetails.AddParams("@sr_no", pClsProperty.sr_no, DbType.Int32);

                RequestDetails.AddParams("@form_id", pClsProperty.form_id, DbType.Int32);

                RequestDetails.CommandText = BLL.TPV.SProc.TRN_Purchase_Detail_Save;
                RequestDetails.CommandType = CommandType.StoredProcedure;

                IntRes = Conn.Inter1.ExecuteNonQuery(DBConnections.ConnectionString, DBConnections.ProviderName, RequestDetails, pEnum);
                return IntRes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Delete(Purchase_Property pClsProperty, Int32 flag, DLL.GlobalDec.EnumTran pEnum = DLL.GlobalDec.EnumTran.WithCommit, BeginTranConnection Conn = null)
        {
            try
            {
                Request Request = new Request();
                int IntRes = 0;
                Request RequestDetails = new Request();

                RequestDetails.AddParams("@purchase_id", pClsProperty.purchase_id, DbType.Int64);
                RequestDetails.AddParams("@purchase_detail_id", pClsProperty.purchase_detail_id, DbType.Int64);
                RequestDetails.AddParams("@item_id", pClsProperty.item_id, DbType.Int64);
                RequestDetails.AddParams("@color_id", pClsProperty.color_id, DbType.Int64);
                RequestDetails.AddParams("@size_id", pClsProperty.size_id, DbType.Int64);
                RequestDetails.AddParams("@flag", flag, DbType.Int32);
                RequestDetails.AddParams("@pcs", pClsProperty.pcs, DbType.Decimal);
                RequestDetails.AddParams("@company_id", GlobalDec.gEmployeeProperty.company_id, DbType.Int32);
                RequestDetails.AddParams("@branch_id", GlobalDec.gEmployeeProperty.branch_id, DbType.Int32);
                RequestDetails.AddParams("@location_id", GlobalDec.gEmployeeProperty.location_id, DbType.Int32);
                RequestDetails.AddParams("@department_id", GlobalDec.gEmployeeProperty.department_id, DbType.Int32);

                RequestDetails.CommandText = BLL.TPV.SProc.TRN_Purchase_Delete;
                RequestDetails.CommandType = CommandType.StoredProcedure;

                if (Conn != null)
                    IntRes = Conn.Inter1.ExecuteNonQuery(DBConnections.ConnectionString, DBConnections.ProviderName, RequestDetails, pEnum);
                else
                    IntRes = Ope.ExecuteNonQuery(DBConnections.ConnectionString, DBConnections.ProviderName, RequestDetails);
                return IntRes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable GetData(string p_dtpFromDate, string p_dtpToDate, Int64 voucher_no, int Ledger_ID)
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();
            Request.CommandText = BLL.TPV.SProc.TRN_Purchase_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Request.AddParams("@from_date", p_dtpFromDate, DbType.Int32);
            Request.AddParams("@to_date", p_dtpToDate, DbType.Int32);
            Request.AddParams("@voucher_no", voucher_no, DbType.Int64);
            Request.AddParams("@ledger_id", Ledger_ID, DbType.Int32);
            Request.AddParams("@company_id", GlobalDec.gEmployeeProperty.company_id, DbType.Int32);
            Request.AddParams("@branch_id", GlobalDec.gEmployeeProperty.branch_id, DbType.Int32);
            Request.AddParams("@location_id", GlobalDec.gEmployeeProperty.location_id, DbType.Int32);
            Request.AddParams("@department_id", GlobalDec.gEmployeeProperty.department_id, DbType.Int32);

            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request);
            return DTab;
        }
        public DataTable GetDataDetails(int p_numID)
        {
            DataTable DTab = new DataTable();
            try
            {
                Request Request = new Request();
                Request.CommandText = BLL.TPV.SProc.TRN_Purchase_GetDetailsData;
                Request.CommandType = CommandType.StoredProcedure;
                Request.AddParams("@p_numPurchase_ID", p_numID, DbType.Int64);

                Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request);
                return DTab;
            }
            catch (Exception ex)
            {
                BLL.General.ShowErrors(ex);
                return DTab;
            }
        }
        public DataSet Janged_Voucher_GetData(Int64 voucher_no)
        {
            DataSet DTab = new DataSet();
            Request Request = new Request();
            Request.CommandText = BLL.TPV.SProc.TRN_Janged_Voucher_Entry_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Request.AddParams("@voucher_no", voucher_no, DbType.Int64);
            Request.AddParams("@company_id", GlobalDec.gEmployeeProperty.company_id, DbType.Int32);
            Request.AddParams("@branch_id", GlobalDec.gEmployeeProperty.branch_id, DbType.Int32);
            Request.AddParams("@location_id", GlobalDec.gEmployeeProperty.location_id, DbType.Int32);
            Request.AddParams("@department_id", GlobalDec.gEmployeeProperty.department_id, DbType.Int32);

            Ope.GetDataSet(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, "", Request);
            return DTab;
        }
        public DataTable Purchase_Invocie_Popup_GetData(Int64 Purchase_ID)
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();
            Request.CommandText = BLL.TPV.SProc.TRN_Purchase_Popup_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Request.AddParams("@purchase_id", Purchase_ID, DbType.Int64);
            Request.AddParams("@company_id", GlobalDec.gEmployeeProperty.company_id, DbType.Int32);
            Request.AddParams("@branch_id", GlobalDec.gEmployeeProperty.branch_id, DbType.Int32);
            Request.AddParams("@location_id", GlobalDec.gEmployeeProperty.location_id, DbType.Int32);
            Request.AddParams("@department_id", GlobalDec.gEmployeeProperty.department_id, DbType.Int32);

            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request);
            return DTab;
        }
        //public DataTable Purchase_Voucher_No_GetData(Int64 voucher_no)
        //{
        //    DataTable DTab = new DataTable();
        //    Request Request = new Request();
        //    Request.CommandText = BLL.TPV.SProc.TRN_Janged_Voucher_Entry_GetData;
        //    Request.CommandType = CommandType.StoredProcedure;
        //    Request.AddParams("@voucher_no", voucher_no, DbType.Int64);

        //    Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request);
        //    return DTab;
        //}
        public DataTable Barcode_Print_GetData(string Item_ID, string Color_ID, string Size_ID)
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();
            Request.CommandText = BLL.TPV.SProc.TRN_Barcode_Print_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Request.AddParams("@item_id", Item_ID, DbType.String);
            Request.AddParams("@color_id", Color_ID, DbType.String);
            Request.AddParams("@size_id", Size_ID, DbType.String);
            Request.AddParams("@company_id", GlobalDec.gEmployeeProperty.company_id, DbType.Int32);
            Request.AddParams("@branch_id", GlobalDec.gEmployeeProperty.branch_id, DbType.Int32);
            Request.AddParams("@location_id", GlobalDec.gEmployeeProperty.location_id, DbType.Int32);
            Request.AddParams("@department_id", GlobalDec.gEmployeeProperty.department_id, DbType.Int32);

            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request);
            return DTab;
        }
    }
}
