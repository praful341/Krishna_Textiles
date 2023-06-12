using BLL.PropertyClasses.Master;
using DLL;
using System;
using System.Data;

namespace BLL.FunctionClasses.Master
{
    public class UserMaster
    {
        InterfaceLayer Ope = new InterfaceLayer();
        Validation Val = new Validation();
        public int Save(User_MasterProperty pClsProperty)
        {
            Request Request = new Request();

            Request.AddParams("@user_id", pClsProperty.user_id, DbType.Int64);
            Request.AddParams("@user_name", pClsProperty.user_name, DbType.String);
            Request.AddParams("@password", pClsProperty.password, DbType.String);
            Request.AddParams("@theme", pClsProperty.theme, DbType.String);
            Request.AddParams("@sequence_no", pClsProperty.sequence_no, DbType.String);
            Request.AddParams("@user_type", pClsProperty.user_type, DbType.Int64);
            Request.AddParams("@employee_id", pClsProperty.employee_id, DbType.Int64);
            Request.AddParams("@role_id", pClsProperty.role_id, DbType.Int64);
            Request.AddParams("@party_id", pClsProperty.party_id, DbType.Int64);
            Request.AddParams("@default_company_id", pClsProperty.company_id, DbType.Int64);
            Request.AddParams("@default_branch_id", pClsProperty.branch_id, DbType.Int64);
            Request.AddParams("@default_location_id", pClsProperty.location_id, DbType.Int64);
            Request.AddParams("@default_department_id", pClsProperty.department_id, DbType.Int64);
            Request.AddParams("@active", pClsProperty.active, DbType.Int32);
            Request.AddParams("@entry_user_id", GlobalDec.gEmployeeProperty.user_id, DbType.Int32);
            Request.AddParams("@ip_address", GlobalDec.gStrComputerIP, DbType.String);
            Request.AddParams("@entry_date", Val.DBDate(GlobalDec.gStr_SystemDate), DbType.Date);
            Request.AddParams("@entry_time", GlobalDec.gStr_SystemTime, DbType.String);

            Request.CommandText = BLL.TPV.SProc.MST_User_Save;
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
        public string ISExists(string UserName, Int64 UserId)
        {
            Validation Val = new Validation();
            return Val.ToString(Ope.FindText(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, "MST_User", "user_name", "AND user_name = '" + UserName + "' AND NOT user_id =" + UserId));
        }
        public DataTable UserType_GetData(int active = 0)
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.AddParams("@Active", active, DbType.Int32);

            Request.CommandText = BLL.TPV.SProc.MST_User_Type_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request);
            return DTab;
        }
    }
}
