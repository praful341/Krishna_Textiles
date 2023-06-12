using BLL.PropertyClasses.Master;
using BLL.PropertyClasses.Utility;
using DLL;
using System;
using System.Data;

namespace BLL.FunctionClasses.Master
{
    public class ConfigRoleMaster
    {
        InterfaceLayer Ope = new InterfaceLayer();
        Validation Val = new Validation();
        public DataTable GetData(int active = 0)
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.AddParams("@Active", active, DbType.Int32);
            Request.AddParams("@role_type", "", DbType.String);

            Request.CommandText = BLL.TPV.SProc.MST_Config_Role_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request);
            return DTab;
        }
        public DataTable GetData_Lookup(int active = 0)
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.AddParams("@Active", active, DbType.Int32);
            Request.AddParams("@role_type", "DESKTOP", DbType.String);

            Request.CommandText = BLL.TPV.SProc.MST_Config_Role_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request);
            return DTab;
        }
        public DataTable getUserPermision(int role_id)
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.AddParams("@role_id", role_id, DbType.Int32);

            Request.CommandText = BLL.TPV.SProc.User_Perm_Master_GetFullDetail;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request);
            return DTab;
        }
        public DataTable GetRportDetail(int role_id)
        {
            Request Request = new Request();
            DataTable DTDATA = new DataTable();
            Request.AddParams("@role_id", role_id, DbType.Int32);

            Request.CommandText = BLL.TPV.SProc.MST_Report_Authentication_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTDATA, Request);

            return DTDATA;
        }
        public int User_Permission_Save(ConfigRole_MasterProperty pClsProperty, DLL.GlobalDec.EnumTran pEnum = DLL.GlobalDec.EnumTran.WithCommit, BeginTranConnection Conn = null)
        {
            try
            {
                int IntRes = 0;
                Request Request = new Request();

                Request.AddParams("@ID", pClsProperty.role_permission_id, DbType.Int32);
                Request.AddParams("@role_id", pClsProperty.role_id, DbType.Int64);
                Request.AddParams("@form_id", pClsProperty.form_id, DbType.Int64);
                Request.AddParams("@permission_id", pClsProperty.permission_id, DbType.Int32);
                Request.AddParams("@allow_view", pClsProperty.allow_view, DbType.Int32);
                Request.AddParams("@allow_add", pClsProperty.allow_add, DbType.Int32);
                Request.AddParams("@allow_edit", pClsProperty.allow_edit, DbType.Int32);
                Request.AddParams("@allow_delete", pClsProperty.allow_delete, DbType.Int32);
                Request.AddParams("@allow_export", pClsProperty.allow_export, DbType.Int32);
                Request.AddParams("@allow_print", pClsProperty.allow_print, DbType.Int32);
                Request.AddParams("@allow_email", pClsProperty.allow_email, DbType.Int32);
                Request.AddParams("@allow_attachment", pClsProperty.allow_attachment, DbType.Int32);
                Request.AddParams("@allow_password", pClsProperty.allow_password, DbType.String);
                Request.AddParams("@user_id", GlobalDec.gEmployeeProperty.user_id, DbType.Int64);
                Request.AddParams("@ip_address", GlobalDec.gStrComputerIP, DbType.String);
                Request.AddParams("@entry_date", Val.DBDate(GlobalDec.gStr_SystemDate), DbType.Date);
                Request.AddParams("@entry_time", GlobalDec.gStr_SystemTime, DbType.String);

                Request.CommandText = BLL.TPV.SProc.User_Permission_Save;
                Request.CommandType = CommandType.StoredProcedure;
                if (Conn != null)
                    IntRes = Conn.Inter1.ExecuteNonQuery(DBConnections.ConnectionString, DBConnections.ProviderName, Request, pEnum);
                else
                    IntRes = Ope.ExecuteNonQuery(DBConnections.ConnectionString, DBConnections.ProviderName, Request);
                return IntRes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int SaveReport(UserAuthenticationProperty pClsProperty, DLL.GlobalDec.EnumTran pEnum = DLL.GlobalDec.EnumTran.WithCommit, BeginTranConnection Conn = null)
        {
            try
            {
                int IntRes = 0;
                Request Request = new Request();
                Request.AddParams("@role_id", pClsProperty.role_id, DbType.Int32);
                Request.AddParams("@report_code", pClsProperty.Report_Code, DbType.Int32);
                Request.AddParams("@allow_view", pClsProperty.Viw, DbType.Int32);
                Request.AddParams("@allow_print", pClsProperty.Print, DbType.Int32);
                Request.AddParams("@allow_email", pClsProperty.Email, DbType.Int32);
                Request.AddParams("@allow_export", pClsProperty.Export, DbType.Int32);
                Request.AddParams("@user_id", GlobalDec.gEmployeeProperty.user_id, DbType.Int32);

                Request.CommandText = BLL.TPV.SProc.MST_Report_Authentication_Save;
                Request.CommandType = CommandType.StoredProcedure;
                if (Conn != null)
                    IntRes += Conn.Inter1.ExecuteNonQuery(DBConnections.ConnectionString, DBConnections.ProviderName, Request, pEnum);
                else
                    IntRes += Ope.ExecuteNonQuery(DBConnections.ConnectionString, DBConnections.ProviderName, Request);
                return IntRes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Save(ConfigRole_MasterProperty pClsProperty, DLL.GlobalDec.EnumTran pEnum = DLL.GlobalDec.EnumTran.WithCommit, BeginTranConnection Conn = null)
        {
            try
            {
                int IntRes = 0;
                Request Request = new Request();
                Request.AddParams("@ID", pClsProperty.role_permission_id, DbType.Int32);
                Request.AddParams("@role_id", pClsProperty.role_id, DbType.Int64);
                Request.AddParams("@form_id", pClsProperty.form_id, DbType.Int64);
                Request.AddParams("@permission_id", pClsProperty.permission_id, DbType.Int32);
                Request.AddParams("@allow_view", pClsProperty.allow_view, DbType.Int32);
                Request.AddParams("@allow_add", pClsProperty.allow_add, DbType.Int32);
                Request.AddParams("@allow_edit", pClsProperty.allow_edit, DbType.Int32);
                Request.AddParams("@allow_delete", pClsProperty.allow_delete, DbType.Int32);
                Request.AddParams("@allow_export", pClsProperty.allow_export, DbType.Int32);
                Request.AddParams("@allow_print", pClsProperty.allow_print, DbType.Int32);
                Request.AddParams("@allow_email", pClsProperty.allow_email, DbType.Int32);
                Request.AddParams("@allow_attachment", pClsProperty.allow_attachment, DbType.Int32);
                Request.AddParams("@allow_password", pClsProperty.allow_password, DbType.String);
                Request.AddParams("@user_id", GlobalDec.gEmployeeProperty.user_id, DbType.Int64);
                Request.AddParams("@ip_address", GlobalDec.gStrComputerIP, DbType.String);
                Request.AddParams("@entry_date", Val.DBDate(GlobalDec.gStr_SystemDate), DbType.Date);
                Request.AddParams("@entry_time", GlobalDec.gStr_SystemTime, DbType.String);

                Request.CommandText = BLL.TPV.SProc.User_Permission_Copy_Save;
                Request.CommandType = CommandType.StoredProcedure;
                if (Conn != null)
                    IntRes = Conn.Inter1.ExecuteNonQuery(DBConnections.ConnectionString, DBConnections.ProviderName, Request, pEnum);
                else
                    IntRes = Ope.ExecuteNonQuery(DBConnections.ConnectionString, DBConnections.ProviderName, Request);
                return IntRes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string ISExists(string RoleName, string Role_Type, Int64 RoleId)
        {
            Validation Val = new Validation();
            return Val.ToString(Ope.FindText(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, "Config_Role", "role_name", "AND role_name = '" + RoleName + "' AND role_type = '" + Role_Type + "' AND NOT role_id =" + RoleId));
        }

        public int Save_Role(ConfigRole_MasterProperty pClsProperty)
        {
            Request Request = new Request();
            Request.AddParams("@role_id", pClsProperty.role_id, DbType.Int64);
            Request.AddParams("@role_name", pClsProperty.role_name, DbType.String);
            Request.AddParams("@role_type", pClsProperty.role_type, DbType.String);
            Request.AddParams("@active", pClsProperty.active, DbType.Int32);
            Request.AddParams("@user_id", GlobalDec.gEmployeeProperty.user_id, DbType.Int64);
            Request.AddParams("@ip_address", GlobalDec.gStrComputerIP, DbType.String);
            Request.AddParams("@entry_date", Val.DBDate(GlobalDec.gStr_SystemDate), DbType.Date);
            Request.AddParams("@entry_time", GlobalDec.gStr_SystemTime, DbType.String);

            Request.CommandText = BLL.TPV.SProc.MST_Config_Role_Save;
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }
    }
}
