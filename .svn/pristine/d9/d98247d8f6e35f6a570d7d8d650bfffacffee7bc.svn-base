using BLL.PropertyClasses.Master;
using DLL;
using System;
using System.Data;

namespace BLL.FunctionClasses.Master
{
    public class EmployeeMaster
    {
        InterfaceLayer Ope = new InterfaceLayer();
        Validation Val = new Validation();

        public int Save(Employee_MasterProperty pClsProperty)
        {
            Request Request = new Request();

            Request.AddParams("@employee_id", pClsProperty.employee_id, DbType.Int64);
            Request.AddParams("@first_name", pClsProperty.first_name, DbType.String);
            Request.AddParams("@middle_name", pClsProperty.middle_name, DbType.String);
            Request.AddParams("@last_name", pClsProperty.last_name, DbType.String);
            Request.AddParams("@short_name", pClsProperty.short_name, DbType.String);
            Request.AddParams("@birth_date", pClsProperty.birth_date, DbType.String);
            Request.AddParams("@current_address", pClsProperty.current_address, DbType.String);
            Request.AddParams("@village", pClsProperty.village, DbType.String);
            Request.AddParams("@taluka", pClsProperty.taluka, DbType.String);
            Request.AddParams("@district", pClsProperty.district, DbType.String);
            Request.AddParams("@mobile_no", pClsProperty.mobile_no, DbType.String);
            Request.AddParams("@phone_no", pClsProperty.phone_no, DbType.String);
            Request.AddParams("@refrence_by_name", pClsProperty.refrence_by_name, DbType.String);
            Request.AddParams("@refrence_by_no", pClsProperty.refrence_by_no, DbType.String);
            Request.AddParams("@addhar_no", pClsProperty.addhar_no, DbType.String);
            Request.AddParams("@image_path", pClsProperty.emp_image, DbType.Byte);
            Request.AddParams("@location_id", pClsProperty.location_id, DbType.Int64);
            Request.AddParams("@company_id", pClsProperty.company_id, DbType.Int64);
            Request.AddParams("@branch_id", pClsProperty.branch_id, DbType.Int64);
            Request.AddParams("@department_id", pClsProperty.department_id, DbType.Int32);
            Request.AddParams("@shift_id", pClsProperty.shift_id, DbType.Int32);
            Request.AddParams("@designation_id", pClsProperty.designation_id, DbType.Int32);
            Request.AddParams("@manager_id", pClsProperty.manager_id, DbType.Int32);
            Request.AddParams("@building_id", pClsProperty.building_id, DbType.Int32);
            Request.AddParams("@floor_id", pClsProperty.floor_id, DbType.Int32);
            Request.AddParams("@active", pClsProperty.active, DbType.Int32);
            Request.AddParams("@remarks", pClsProperty.remarks, DbType.String);
            Request.AddParams("@email", pClsProperty.email, DbType.String);
            Request.AddParams("@email_password", pClsProperty.email_password, DbType.String);
            Request.AddParams("@enrollment_no", pClsProperty.enrollment_no, DbType.Int32);
            Request.AddParams("@salary", pClsProperty.salary, DbType.Decimal);
            Request.AddParams("@total_hrs", pClsProperty.total_hrs, DbType.Decimal);
            Request.AddParams("@sale_premium", pClsProperty.sale_premium, DbType.String);
            Request.AddParams("@sale_discount", pClsProperty.sale_discount, DbType.String);
            Request.AddParams("@user_id", GlobalDec.gEmployeeProperty.user_id, DbType.Int32);
            Request.AddParams("@ip_address", GlobalDec.gStrComputerIP, DbType.String);
            Request.AddParams("@entry_date", Val.DBDate(GlobalDec.gStr_SystemDate), DbType.Date);
            Request.AddParams("@entry_time", GlobalDec.gStr_SystemTime, DbType.String);

            Request.AddParams("@salary_type", pClsProperty.Salary_Type, DbType.String);
            Request.AddParams("@wages_type", pClsProperty.Wages_Type, DbType.String);
            Request.AddParams("@sub_manager_id", pClsProperty.sub_manager_id, DbType.Int32);
            Request.AddParams("@pagar_no", pClsProperty.pagar_no, DbType.String);

            Request.CommandText = BLL.TPV.SProc.MST_Employee_Save;
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }
        public DataTable GetData(int active = 0, string designation = "")
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.AddParams("@active", active, DbType.Int32);
            Request.AddParams("@designation", designation, DbType.String);

            Request.CommandText = BLL.TPV.SProc.MST_HrEmployee_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request);
            return DTab;
        }

        public DataTable GetCompanyWiseEmpData(int company, int branch, int location, int department, int active = 0)
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.AddParams("@active", active, DbType.Int32);
            Request.AddParams("@company_id", company, DbType.Int32);
            Request.AddParams("@branch_id", branch, DbType.Int32);
            Request.AddParams("@location_id", location, DbType.Int32);
            Request.AddParams("@department_id", department, DbType.Int32);
            Request.CommandText = BLL.TPV.SProc.MST_Employee_GetCompanyWiseData;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request);
            return DTab;
        }
        public string ISExists(string ShortName, Int64 EmpId)
        {
            Validation Val = new Validation();
            return Val.ToString(Ope.FindText(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, "MST_Employee", "short_name", "AND short_name = '" + ShortName + "' AND NOT employee_id =" + EmpId));
        }
        public string ISEnoExists(Int64 Eno)
        {
            Validation Val = new Validation();
            return Val.ToString(Ope.FindText(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, "MST_Employee", "enrollment_no", "AND enrollment_no = " + Eno));
        }
        public DataTable GetDataForSearchNew(Employee_MasterProperty pclsProperty, int active = 0)
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.AddParams("@company_id", pclsProperty.Company_Multi, DbType.String);
            Request.AddParams("@branch_id", pclsProperty.Branch_Multi, DbType.String);
            Request.AddParams("@location_id", pclsProperty.Location_Multi, DbType.String);
            Request.AddParams("@department_id", pclsProperty.Department_Multi, DbType.String);
            Request.AddParams("@active", active, DbType.Int32);

            Request.CommandText = TPV.SProc.MST_HR_Employee_Master_GetByParam;
            Request.CommandType = CommandType.StoredProcedure;

            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request);
            return DTab;
        }
    }
}
