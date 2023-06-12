using BLL.PropertyClasses.Master;
using DLL;
using System.Data;

namespace BLL.FunctionClasses.Master
{
    public class ConfigMenuPermissionMaster
    {
        InterfaceLayer Ope = new InterfaceLayer();
        Validation Val = new Validation();
        public int Save(ConfigMenuPermission_MasterProperty pClsProperty)
        {
            Request Request = new Request();

            Request.AddParams("@menu_detail_id", pClsProperty.menu_detail_id, DbType.Int64);
            Request.AddParams("@role_id", pClsProperty.menu_id, DbType.Int32);
            Request.AddParams("@menu_id", pClsProperty.menu_id, DbType.Int32);
            Request.AddParams("@is_permisson", pClsProperty.is_permisson, DbType.Int32);
            Request.AddParams("@user_id", GlobalDec.gEmployeeProperty.user_id, DbType.Int32);
            Request.AddParams("@ip_address", GlobalDec.gStrComputerIP, DbType.String);
            Request.AddParams("@entry_date", Val.DBDate(GlobalDec.gStr_SystemDate), DbType.Date);
            Request.AddParams("@entry_time", GlobalDec.gStr_SystemTime, DbType.String);

            Request.CommandText = BLL.TPV.SProc.Config_Menu_Permission_Save;
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }
        public DataTable Start_Menu_Permission_GetData()
        {
            Request Request = new Request();
            DataTable DTab = new DataTable();

            Request.CommandText = BLL.TPV.SProc.Config_Menu_Permission_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(DBConnections.ConnectionString, DBConnections.ProviderName, DTab, Request);
            return DTab;
        }
    }
}
