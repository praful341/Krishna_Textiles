using BLL.PropertyClasses.Master;
using DLL;
using System.Data;

namespace BLL.FunctionClasses.Master
{
    public class ConfigPermission
    {
        InterfaceLayer Ope = new InterfaceLayer();
        Validation Val = new Validation();
        public int Delete(Config_PermissionMasterProperty pClsProperty)
        {
            Request Request = new Request();
            Request.AddParams("@user_id", pClsProperty.user_id, DbType.Int32);
            Request.AddParams("@type", pClsProperty.type, DbType.String);
            Request.AddParams("@entry_date", Val.DBDate(GlobalDec.gStr_SystemDate), DbType.Date);
            Request.AddParams("@entry_time", GlobalDec.gStr_SystemTime, DbType.String);
            Request.CommandText = BLL.TPV.SProc.MST_Config_Permission_Save;
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }
        public int Save(Config_PermissionMasterProperty pClsProperty)
        {
            Request Request = new Request();

            Request.AddParams("@config_company_id", pClsProperty.config_company_id, DbType.Int32);
            Request.AddParams("@config_branch_id", pClsProperty.config_branch_id, DbType.Int32);
            Request.AddParams("@config_location_id", pClsProperty.config_location_id, DbType.Int32);
            Request.AddParams("@type", pClsProperty.type, DbType.String);
            Request.AddParams("@config_department_id", pClsProperty.config_department_id, DbType.Int32);
            Request.AddParams("@user_id", pClsProperty.user_id, DbType.Int32);
            Request.AddParams("@entry_user_id", GlobalDec.gEmployeeProperty.user_id, DbType.Int32);
            Request.AddParams("@ip_address", GlobalDec.gStrComputerIP, DbType.String);
            Request.AddParams("@entry_date", Val.DBDate(GlobalDec.gStr_SystemDate), DbType.Date);
            Request.AddParams("@entry_time", GlobalDec.gStr_SystemTime, DbType.String);

            Request.CommandText = BLL.TPV.SProc.MST_Config_Permission_Save;
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }
        public DataTable UserGetData(int active = 0)
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.AddParams("@Active", active, DbType.Int32);

            Request.CommandText = BLL.TPV.SProc.MST_User_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request);
            return DTab;
        }
        public object GetEmployeeBranch(int pIntUserID)
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();
            Request.AddParams("@user_id", pIntUserID, DbType.Int32);
            Request.CommandText = TPV.SProc.Branch_Permission_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request);
            DataTable DTab1 = new DataTable();
            DataRow DRow = DTab1.NewRow();
            DRow.Table.Columns.Add("branch_id");
            DRow.Table.Columns.Add("branch_name");

            string StrId = "";
            string StrName = "";
            foreach (DataRow DR in DTab.Rows)
            {
                StrId = StrId + DR["branch_id"] + ",";
                StrName = StrName + DR["branch_name"] + ",";
            }

            if (StrId != "")
            {
                StrId = StrId.Substring(0, StrId.Length - 1);
                StrName = StrName.Substring(0, StrName.Length - 1);
            }
            DRow["branch_id"] = StrId;
            DRow["branch_name"] = StrName;
            return DRow;
        }
        public object GetEmployeeCompany(int pIntUserID)
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();
            Request.AddParams("@user_id", pIntUserID, DbType.Int32);
            Request.CommandText = TPV.SProc.Company_Permission_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request);
            DataTable DTab1 = new DataTable();
            DataRow DRow = DTab1.NewRow();
            DRow.Table.Columns.Add("company_id");
            DRow.Table.Columns.Add("company_name");

            string StrId = "";
            string StrName = "";
            foreach (DataRow DR in DTab.Rows)
            {
                StrId = StrId + DR["company_id"] + ",";
                StrName = StrName + DR["company_name"] + ",";
            }

            if (StrId != "")
            {
                StrId = StrId.Substring(0, StrId.Length - 1);
                StrName = StrName.Substring(0, StrName.Length - 1);
            }
            DRow["company_id"] = StrId;
            DRow["company_name"] = StrName;
            return DRow;
        }
        public object GetEmployeeLocation(int pIntUserID)
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();
            Request.AddParams("@user_id", pIntUserID, DbType.Int32);
            Request.CommandText = TPV.SProc.Location_Permission_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request);
            DataTable DTab1 = new DataTable();
            DataRow DRow = DTab1.NewRow();
            DRow.Table.Columns.Add("location_id");
            DRow.Table.Columns.Add("location_name");

            string StrId = "";
            string StrName = "";
            foreach (DataRow DR in DTab.Rows)
            {
                StrId = StrId + DR["location_id"] + ",";
                StrName = StrName + DR["location_name"] + ",";
            }

            if (StrId != "")
            {
                StrId = StrId.Substring(0, StrId.Length - 1);
                StrName = StrName.Substring(0, StrName.Length - 1);
            }
            DRow["location_id"] = StrId;
            DRow["location_name"] = StrName;
            return DRow;
        }
        public object GetEmployeeDepartment(int pIntUserID)
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();
            Request.AddParams("@user_id", pIntUserID, DbType.Int32);
            Request.CommandText = TPV.SProc.Department_Permission_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request);
            DataTable DTab1 = new DataTable();
            DataRow DRow = DTab1.NewRow();
            DRow.Table.Columns.Add("department_id");
            DRow.Table.Columns.Add("department_name");

            string StrId = "";
            string StrName = "";
            foreach (DataRow DR in DTab.Rows)
            {
                StrId = StrId + DR["department_id"] + ",";
                StrName = StrName + DR["department_name"] + ",";
            }

            if (StrId != "")
            {
                StrId = StrId.Substring(0, StrId.Length - 1);
                StrName = StrName.Substring(0, StrName.Length - 1);
            }
            DRow["department_id"] = StrId;
            DRow["department_name"] = StrName;
            return DRow;
        }
    }
}
