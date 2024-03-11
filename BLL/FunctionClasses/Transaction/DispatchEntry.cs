using BLL.PropertyClasses.Transaction;
using DLL;
using System;
using System.Data;

namespace BLL.FunctionClasses.Transaction
{
    public class DispatchEntry
    {
        InterfaceLayer Ope = new InterfaceLayer();
        BLL.Validation Val = new BLL.Validation();

        public Int64 Save(DispatchEntry_Property pClsProperty, DLL.GlobalDec.EnumTran pEnum = DLL.GlobalDec.EnumTran.WithCommit, BeginTranConnection Conn = null)
        {
            Int64 IntRes = 0;
            try
            {
                Request Request = new Request();

                Request.AddParams("@dispatch_id", pClsProperty.dispatch_id, DbType.Int64);
                Request.AddParams("@fin_year_id", GlobalDec.gEmployeeProperty.gFinancialYear_Code, DbType.String);
                Request.AddParams("@company_id", GlobalDec.gEmployeeProperty.company_id, DbType.Int32);
                Request.AddParams("@branch_id", GlobalDec.gEmployeeProperty.branch_id, DbType.Int32);
                Request.AddParams("@location_id", GlobalDec.gEmployeeProperty.location_id, DbType.Int32);
                Request.AddParams("@department_id", GlobalDec.gEmployeeProperty.department_id, DbType.Int32);
                Request.AddParams("@invoice_id", pClsProperty.invoice_id, DbType.Int64);

                Request.AddParams("@order_date", pClsProperty.order_date, DbType.Date);
                Request.AddParams("@order_no", pClsProperty.order_no, DbType.String);
                Request.AddParams("@employee_id", pClsProperty.employee_id, DbType.Int64);

                Request.AddParams("@dispatch_date", pClsProperty.dispatch_date, DbType.Date);
                Request.AddParams("@dispatch_time", GlobalDec.gStr_SystemTime, DbType.String);

                Request.AddParams("@from_courier_id", pClsProperty.from_courier_id, DbType.Int64);
                Request.AddParams("@to_courier_id", pClsProperty.to_courier_id, DbType.Int64);
                Request.AddParams("@awb_no", pClsProperty.awb_no, DbType.String);
                Request.AddParams("@paid_amount", pClsProperty.paid_amount, DbType.Decimal);
                Request.AddParams("@shipping_amount", pClsProperty.shipping_amount, DbType.Decimal);

                Request.AddParams("@status", pClsProperty.status, DbType.String);
                Request.AddParams("@remarks", pClsProperty.remarks, DbType.String);

                Request.AddParams("@entry_user_id", GlobalDec.gEmployeeProperty.user_id, DbType.Int32);
                Request.AddParams("@entry_date", Val.DBDate(BLL.GlobalDec.gStrServerDate), DbType.Date);
                Request.AddParams("@entry_time", GlobalDec.gStr_SystemTime, DbType.String);
                Request.AddParams("@entry_ip_address", GlobalDec.gStrComputerIP, DbType.String);

                Request.AddParams("@form_id", pClsProperty.form_id, DbType.Int64);

                Request.CommandText = BLL.TPV.SProc.TRN_Dispatch_Save;
                Request.CommandType = CommandType.StoredProcedure;

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
        public int Save_Detail(SaleInvoice_Property pClsProperty, DLL.GlobalDec.EnumTran pEnum = DLL.GlobalDec.EnumTran.WithCommit, BeginTranConnection Conn = null)
        {
            try
            {
                int IntRes = 0;
                Request RequestDetails = new Request();

                RequestDetails.AddParams("@invoice_detail_id", pClsProperty.invoice_detail_id, DbType.Int64);
                RequestDetails.AddParams("@invoice_id", pClsProperty.invoice_id, DbType.Int64);
                RequestDetails.AddParams("@company_id", GlobalDec.gEmployeeProperty.company_id, DbType.Int64);
                RequestDetails.AddParams("@branch_id", GlobalDec.gEmployeeProperty.branch_id, DbType.Int64);
                RequestDetails.AddParams("@location_id", GlobalDec.gEmployeeProperty.location_id, DbType.Int64);
                RequestDetails.AddParams("@department_id", GlobalDec.gEmployeeProperty.department_id, DbType.Int64);
                RequestDetails.AddParams("@sr_no", pClsProperty.sr_no, DbType.Int32);
                RequestDetails.AddParams("@item_id", pClsProperty.item_id, DbType.Int64);
                RequestDetails.AddParams("@color_id", pClsProperty.color_id, DbType.Int64);
                RequestDetails.AddParams("@size_id", pClsProperty.size_id, DbType.Int64);
                RequestDetails.AddParams("@old_item_id", pClsProperty.old_item_id, DbType.Int64);
                RequestDetails.AddParams("@old_size_id", pClsProperty.old_size_id, DbType.Int64);
                RequestDetails.AddParams("@old_color_id", pClsProperty.old_color_id, DbType.Int64);
                RequestDetails.AddParams("@old_pcs", pClsProperty.old_pcs, DbType.Int32);
                RequestDetails.AddParams("@pcs", pClsProperty.pcs, DbType.Int32);
                RequestDetails.AddParams("@unit_id", pClsProperty.unit_id, DbType.Int64);
                RequestDetails.AddParams("@purchase_rate", pClsProperty.purchase_rate, DbType.Decimal);
                RequestDetails.AddParams("@purchase_amount", pClsProperty.purchase_amount, DbType.Decimal);
                RequestDetails.AddParams("@sale_rate", pClsProperty.sale_rate, DbType.Decimal);
                RequestDetails.AddParams("@sale_amount", pClsProperty.sale_amount, DbType.Decimal);
                RequestDetails.AddParams("@flag", pClsProperty.flag, DbType.Int32);
                RequestDetails.AddParams("@entry_user_id", GlobalDec.gEmployeeProperty.user_id, DbType.Int32);
                RequestDetails.AddParams("@entry_date", Val.DBDate(BLL.GlobalDec.gStrServerDate), DbType.Date);
                RequestDetails.AddParams("@entry_time", GlobalDec.gStr_SystemTime, DbType.String);
                RequestDetails.AddParams("@entry_ip_address", GlobalDec.gStrComputerIP, DbType.String);
                RequestDetails.AddParams("@form_id", pClsProperty.form_id, DbType.Int32);

                RequestDetails.CommandText = BLL.TPV.SProc.TRN_SaleInvoice_Details_Save;
                RequestDetails.CommandType = CommandType.StoredProcedure;

                IntRes = Conn.Inter1.ExecuteNonQuery(DBConnections.ConnectionString, DBConnections.ProviderName, RequestDetails, pEnum);
                return IntRes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable GetData(DispatchEntry_Property pClsProperty)
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();
            Request.CommandText = BLL.TPV.SProc.TRN_Dispatch_SearchData;
            Request.CommandType = CommandType.StoredProcedure;
            Request.AddParams("@from_date", pClsProperty.from_date, DbType.Date);
            Request.AddParams("@to_date", pClsProperty.to_date, DbType.Date);
            Request.AddParams("@status", pClsProperty.status, DbType.String);
            Request.AddParams("@company_id", GlobalDec.gEmployeeProperty.company_id, DbType.Int32);
            Request.AddParams("@branch_id", GlobalDec.gEmployeeProperty.branch_id, DbType.Int32);
            Request.AddParams("@location_id", GlobalDec.gEmployeeProperty.location_id, DbType.Int32);
            Request.AddParams("@department_id", GlobalDec.gEmployeeProperty.department_id, DbType.Int32);

            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request);
            return DTab;
        }

        public DataTable Get_Courier_Rate(Int64 To_Courier_ID, decimal Weight)
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();
            Request.CommandText = BLL.TPV.SProc.MST_Courier_Collect_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Request.AddParams("@courier_id", To_Courier_ID, DbType.Int64);
            Request.AddParams("@weight", Weight, DbType.Decimal);

            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request);
            return DTab;
        }
    }
}
