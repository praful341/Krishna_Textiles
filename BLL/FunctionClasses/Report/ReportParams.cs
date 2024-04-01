using BLL.PropertyClasses.Report;
using DLL;
using System.Data;

namespace BLL.FunctionClasses.Report
{
    public class ReportParams
    {
        InterfaceLayer Ope = new InterfaceLayer();
        Validation Val = new Validation();
        ReportParams_Property ReportParams_Property = new ReportParams_Property();
        public DataTable GetLiveStock(ReportParams_Property ReportParams_Property, string pStrSPName)
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();
            Request.CommandText = pStrSPName;
            Request.AddParams("@Group_By", ReportParams_Property.Group_By_Tag, DbType.String);
            Request.AddParams("@company_id", ReportParams_Property.company_id, DbType.String);
            Request.AddParams("@branch_id", ReportParams_Property.branch_id, DbType.String);
            Request.AddParams("@location_id", ReportParams_Property.location_id, DbType.String);
            Request.AddParams("@department_id", ReportParams_Property.department_id, DbType.String);
            Request.AddParams("@datFromDate", ReportParams_Property.From_Date, DbType.Date);
            Request.AddParams("@datToDate", ReportParams_Property.To_Date, DbType.Date);

            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request);
            return DTab;
        }
        public DataTable Get_Transaction_View_Report(ReportParams_Property pClsProperty, string pStrSPName)
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.AddParams("@group_by_", pClsProperty.Group_By_Tag, DbType.String);
            Request.AddParams("@from_issue_date_", pClsProperty.From_Date, DbType.Date);
            Request.AddParams("@to_issue_date_", pClsProperty.To_Date, DbType.Date);
            Request.AddParams("@cash_type_", pClsProperty.Cash_Type, DbType.String);
            Request.AddParams("@ledger_id_", pClsProperty.party_id, DbType.String);
            Request.AddParams("@company_id", pClsProperty.company_id, DbType.String);
            Request.AddParams("@branch_id", pClsProperty.branch_id, DbType.String);
            Request.AddParams("@location_id", pClsProperty.location_id, DbType.String);
            Request.AddParams("@department_id", pClsProperty.department_id, DbType.String);

            Request.CommandText = pStrSPName;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request);

            return DTab;
        }
        public DataTable GetAccountLedgerReport(ReportParams_Property ReportParams_Property, string pStrSPName)
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();
            Request.CommandText = pStrSPName;
            Request.AddParams("@from_date", ReportParams_Property.From_Date, DbType.Date);
            Request.AddParams("@to_date", ReportParams_Property.To_Date, DbType.Date);
            Request.AddParams("@ledger_id", ReportParams_Property.ledger_id, DbType.Int64);
            Request.AddParams("@company_id", GlobalDec.gEmployeeProperty.company_id, DbType.String);
            Request.AddParams("@branch_id", GlobalDec.gEmployeeProperty.branch_id, DbType.String);
            Request.AddParams("@location_id", GlobalDec.gEmployeeProperty.location_id, DbType.String);
            Request.AddParams("@department_id", GlobalDec.gEmployeeProperty.department_id, DbType.String);

            Request.CommandType = CommandType.StoredProcedure;

            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request);
            return DTab;
        }
    }
}
