using BLL.PropertyClasses.Master;
using DLL;
using System;
using System.Data;

namespace BLL.FunctionClasses.Master
{
    public class CountryMaster
    {
        InterfaceLayer Ope = new InterfaceLayer();
        Validation Val = new Validation();
        public int Save(Country_MasterProperty pClsProperty)
        {
            Request Request = new Request();

            Request.AddParams("@country_id", pClsProperty.country_id, DbType.Int64);
            Request.AddParams("@country_shortname", pClsProperty.country_shortname, DbType.String);
            Request.AddParams("@country_name", pClsProperty.country_name, DbType.Int32);
            Request.AddParams("@active", pClsProperty.active, DbType.Int32);
            Request.AddParams("@sequence_no", pClsProperty.sequence_no, DbType.Int32);
            Request.AddParams("@user_id", GlobalDec.gEmployeeProperty.user_id, DbType.Int32);
            Request.AddParams("@ip_address", GlobalDec.gStrComputerIP, DbType.String);
            Request.AddParams("@entry_date", Val.DBDate(GlobalDec.gStr_SystemDate), DbType.Date);
            Request.AddParams("@entry_time", GlobalDec.gStr_SystemTime, DbType.String);

            Request.CommandText = BLL.TPV.SProc.MST_Country_Save;
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }
        public DataTable GetData(int active = 0)
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.AddParams("@Active", active, DbType.Int32);

            Request.CommandText = BLL.TPV.SProc.MST_Country_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request);
            return DTab;
        }
        public string ISExists(string CountryName, Int64 CountryId)
        {
            Validation Val = new Validation();
            return Val.ToString(Ope.FindText(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, "MST_Country", "country_name", "AND country_name = '" + CountryName + "' AND NOT country_id =" + CountryId));
        }
    }
}
