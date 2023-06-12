using BLL.PropertyClasses.Master;
using DLL;
using System;
using System.Data;

namespace BLL.FunctionClasses.Master
{
    public class DepartmentMaster
    {
        InterfaceLayer Ope = new InterfaceLayer();
        Validation Val = new Validation();

        public int Save(Department_MasterProperty pClsProperty)
        {
            Request Request = new Request();

            Request.AddParams("@department_id", pClsProperty.Department_Id, DbType.Int32);
            Request.AddParams("@department_name", pClsProperty.Department_Name, DbType.String);
            Request.AddParams("@department_shortname", pClsProperty.Department_ShortName, DbType.String);
            Request.AddParams("@employee_id", pClsProperty.Employee_Id, DbType.Int32);
            Request.AddParams("@department_type_id", pClsProperty.department_type_id, DbType.Int32);
            Request.AddParams("@active", pClsProperty.Active, DbType.Int32);
            Request.AddParams("@remarks", pClsProperty.Remark, DbType.String);
            Request.AddParams("@sequence_no", pClsProperty.Sequence_No, DbType.Int32);
            Request.AddParams("@user_id", GlobalDec.gEmployeeProperty.user_id, DbType.Int32);
            Request.AddParams("@ip_address", GlobalDec.gStrComputerIP, DbType.String);
            Request.AddParams("@entry_date", Val.DBDate(GlobalDec.gStr_SystemDate), DbType.Date);
            Request.AddParams("@entry_time", GlobalDec.gStr_SystemTime, DbType.String);

            Request.CommandText = BLL.TPV.SProc.MST_Department_Save;
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }
        public DataTable GetData(int active = 0)
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();
            Request.AddParams("@Active", active, DbType.Int32);

            Request.CommandText = BLL.TPV.SProc.MST_Department_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request);
            return DTab;
        }
        public string ISExists(string DeptName, Int64 DeptId)
        {
            Validation Val = new Validation();
            return Val.ToString(Ope.FindText(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, "MST_Department", "department_name", "AND department_name = '" + DeptName + "' AND NOT department_id =" + DeptId));
        }
    }
}
