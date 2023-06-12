using BLL.PropertyClasses.Master;
using DLL;
using System;
using System.Data;

namespace BLL.FunctionClasses.Master
{
    public class PreferenceMaster
    {
        InterfaceLayer Ope = new InterfaceLayer();
        Validation Val = new Validation();
        public int Save(Preference_MasterProperty pClsProperty)
        {
            Request Request = new Request();

            Request.AddParams("@user_preference_id", pClsProperty.user_preference_id, DbType.Int64);
            Request.AddParams("@default_rate_type_id", pClsProperty.default_rate_type_id, DbType.Int64);
            Request.AddParams("@default_currency_id", pClsProperty.default_currency_id, DbType.Int64);
            Request.AddParams("@secondary_currency_id", pClsProperty.secondary_currency_id, DbType.Int64);
            Request.AddParams("@user_id", pClsProperty.user_id, DbType.Int64);
            Request.AddParams("@format_weight", pClsProperty.format_weight, DbType.String);
            Request.AddParams("@format_rate", pClsProperty.format_rate, DbType.String);
            Request.AddParams("@format_percent", pClsProperty.format_percent, DbType.String);
            Request.AddParams("@format_amount", pClsProperty.format_amount, DbType.String);
            Request.AddParams("@entry_user_id", GlobalDec.gEmployeeProperty.user_id, DbType.Int32);
            Request.AddParams("@ip_address", GlobalDec.gStrComputerIP, DbType.String);
            Request.AddParams("@entry_date", Val.DBDate(GlobalDec.gStr_SystemDate), DbType.Date);
            Request.AddParams("@entry_time", GlobalDec.gStr_SystemTime, DbType.String);
            Request.AddParams("@delivery_type_id", pClsProperty.delivery_type_id, DbType.Int32);

            Request.CommandText = BLL.TPV.SProc.MST_Preference_Save;
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }
        public DataTable GetData(int active = 0)
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.AddParams("@Active", active, DbType.Int32);

            Request.CommandText = BLL.TPV.SProc.MST_User_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request);
            return DTab;
        }
        public DataTable GetPreferData(int userId)
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.AddParams("@user_id", userId, DbType.Int32);

            Request.CommandText = BLL.TPV.SProc.MST_Preference_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request);
            return DTab;
        }
    }
}
