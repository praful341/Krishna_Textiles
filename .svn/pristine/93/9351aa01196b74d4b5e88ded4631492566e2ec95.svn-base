using BLL.PropertyClasses.Master;
using DLL;
using System;
using System.Data;

namespace BLL.FunctionClasses.Master
{
    public class LocationMaster
    {
        InterfaceLayer Ope = new InterfaceLayer();
        Validation Val = new Validation();
        public int Save(Location_MasterProperty pClsProperty)
        {
            Request Request = new Request();

            Request.AddParams("@location_id", pClsProperty.location_id, DbType.Int64);
            Request.AddParams("@location_shortname", pClsProperty.location_shortname, DbType.String);
            Request.AddParams("@location_name", pClsProperty.location_name, DbType.String);
            Request.AddParams("@city_id", pClsProperty.city_id, DbType.Int64);
            Request.AddParams("@state_id", pClsProperty.state_id, DbType.Int32);
            Request.AddParams("@country_id", pClsProperty.country_id, DbType.Int32);
            Request.AddParams("@active", pClsProperty.active, DbType.Int32);
            Request.AddParams("@remarks", pClsProperty.remarks, DbType.String);
            Request.AddParams("@user_id", GlobalDec.gEmployeeProperty.user_id, DbType.Int32);
            Request.AddParams("@ip_address", GlobalDec.gStrComputerIP, DbType.String);
            Request.AddParams("@entry_date", Val.DBDate(GlobalDec.gStr_SystemDate), DbType.Date);
            Request.AddParams("@entry_time", GlobalDec.gStr_SystemTime, DbType.String);

            Request.CommandText = BLL.TPV.SProc.MST_Location_Save;
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }
        public DataTable GetData(int active = 0)
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.AddParams("@Active", active, DbType.Int32);

            Request.CommandText = BLL.TPV.SProc.MST_Location_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request);
            return DTab;
        }
        public DataTable GetLocationWiseCompanyBranch()
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            //Request.AddParams("@Active", active, DbType.Int32);

            Request.CommandText = "MST_LocationWiseCompanyBranch";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request);
            return DTab;
        }
        public string ISExists(string LocName, Int64 LocId)
        {
            Validation Val = new Validation();
            return Val.ToString(Ope.FindText(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, "MST_Location", "location_name", "AND location_name = '" + LocName + "' AND NOT location_id =" + LocId));
        }
    }
}
