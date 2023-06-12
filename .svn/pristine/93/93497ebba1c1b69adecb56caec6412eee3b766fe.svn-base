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
            Request.AddParams("@rate_type_id", GlobalDec.gEmployeeProperty.rate_type_id, DbType.Int32);
            Request.AddParams("@currency_id", GlobalDec.gEmployeeProperty.currency_id, DbType.Int32);

            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request);
            return DTab;
        }
        public DataTable GetPunchMissReport(ReportParams_Property ReportParams_Property, string pStrSPName)
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
            Request.AddParams("@rate_type_id", GlobalDec.gEmployeeProperty.rate_type_id, DbType.Int32);
            Request.AddParams("@currency_id", GlobalDec.gEmployeeProperty.currency_id, DbType.Int32);
            Request.AddParams("@punch_miss_flag", ReportParams_Property.punch_miss_flag, DbType.Int32);

            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request);
            return DTab;
        }

        public DataTable GetIssuePendingStock(ReportParams_Property ReportParams_Property, string pStrSPName)
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();
            Request.CommandText = pStrSPName;
            //Request.AddParams("@Group_By", ReportParams_Property.Group_By_Tag, DbType.String);
            Request.AddParams("@company_id", ReportParams_Property.company_id, DbType.String);
            Request.AddParams("@branch_id", ReportParams_Property.branch_id, DbType.String);
            Request.AddParams("@location_id", ReportParams_Property.location_id, DbType.String);
            Request.AddParams("@department_id", ReportParams_Property.department_id, DbType.String);
            Request.AddParams("@cut_id", ReportParams_Property.cut_id, DbType.String);
            Request.AddParams("@kapan_id", ReportParams_Property.kapan_id, DbType.String);
            Request.AddParams("@fromDate", ReportParams_Property.From_Date, DbType.Date);
            Request.AddParams("@toDate", ReportParams_Property.To_Date, DbType.Date);
            //Request.AddParams("@rate_type_id", GlobalDec.gEmployeeProperty.rate_type_id, DbType.Int32);
            //Request.AddParams("@currency_id", GlobalDec.gEmployeeProperty.currency_id, DbType.Int32);

            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request);
            return DTab;
        }


        public DataTable GetPriceList(ReportParams_Property ReportParams_Property, string pStrSPName)
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();
            Request.CommandText = pStrSPName;
            Request.AddParams("@rate_date", ReportParams_Property.rate_date, DbType.Date);
            Request.AddParams("@rate_type_id", ReportParams_Property.rate_type_id, DbType.Int32);
            Request.AddParams("@currency_id", ReportParams_Property.currency_id, DbType.Int32);

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
        public DataTable Get_Employee_Salary_Report(ReportParams_Property pClsProperty, string pStrSPName)
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.AddParams("@group_by", pClsProperty.Group_By_Tag, DbType.String);
            Request.AddParams("@from_issue_date_", pClsProperty.From_Date, DbType.Date);
            Request.AddParams("@to_issue_date_", pClsProperty.To_Date, DbType.Date);
            Request.AddParams("@fromMonth", pClsProperty.fMonth, DbType.String);
            Request.AddParams("@toMonth", pClsProperty.tMonth, DbType.String);
            Request.AddParams("@fromYear", pClsProperty.fYear, DbType.String);
            Request.AddParams("@toYear", pClsProperty.tYear, DbType.String);
            Request.AddParams("@company_id", pClsProperty.company_id, DbType.String);
            Request.AddParams("@branch_id", pClsProperty.branch_id, DbType.String);
            Request.AddParams("@location_id", pClsProperty.location_id, DbType.String);
            Request.AddParams("@department_id", pClsProperty.department_id, DbType.String);

            Request.CommandText = pStrSPName;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request);

            return DTab;
        }
    }
}
