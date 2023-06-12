using BLL.PropertyClasses.Master;
using DLL;
using System;
using System.Data;

namespace BLL.FunctionClasses.Master
{
    public class FinancialYearMaster
    {
        InterfaceLayer Ope = new InterfaceLayer();
        Validation Val = new Validation();

        #region Other Function

        public int Save(Financial_Year_MasterProperty pClsProperty)
        {
            Request Request = new Request();
            Request.AddParams("@fin_year_id", pClsProperty.Fin_Year_ID, DbType.Int64);
            Request.AddParams("@start_date", pClsProperty.Start_Date, DbType.String);
            Request.AddParams("@end_date", pClsProperty.End_Date, DbType.Date);
            Request.AddParams("@short_name", pClsProperty.Short_Name, DbType.Date);
            Request.AddParams("@active", pClsProperty.Active, DbType.Int64);
            Request.AddParams("@financial_year", pClsProperty.Financial_year, DbType.String);
            Request.AddParams("@start_yearmonth", pClsProperty.Start_YearMonth, DbType.Int64);
            Request.AddParams("@end_yearmonth", pClsProperty.End_YearMonth, DbType.Int64);
            Request.AddParams("@entry_date", Val.DBDate(GlobalDec.gStr_SystemDate), DbType.Date);
            Request.AddParams("@entry_time", GlobalDec.gStr_SystemTime, DbType.String);

            Request.CommandText = BLL.TPV.SProc.MST_Financial_Year_Save;
            Request.CommandType = CommandType.StoredProcedure;

            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }
        public DataTable GetData(int active = 0)
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.AddParams("@Active", active, DbType.Int32);

            Request.CommandText = BLL.TPV.SProc.MST_Financial_Year_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request);
            return DTab;
        }

        public string ISExists(string FinYear, Int64 FinYearId)
        {
            Validation Val = new Validation();
            return Val.ToString(Ope.FindText(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, "MST_Financial_Year", "financial_year", "AND financial_year = '" + FinYear + "' AND NOT fin_year_id =" + FinYearId));
        }
        #endregion
    }
}
