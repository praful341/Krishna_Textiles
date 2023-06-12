using BLL.PropertyClasses.Master;
using DLL;
using System;
using System.Data;

namespace BLL.FunctionClasses.Master
{
    public class CompanyMaster
    {
        InterfaceLayer Ope = new InterfaceLayer();
        Validation Val = new Validation();
        public int Save(Company_MasterProperty pClsProperty)
        {
            Request Request = new Request();

            Request.AddParams("@company_id", pClsProperty.company_id, DbType.Int64);
            Request.AddParams("@company_shortname", pClsProperty.company_shortname, DbType.String);
            Request.AddParams("@company_name", pClsProperty.company_name, DbType.String);
            Request.AddParams("@city_id", pClsProperty.city_id, DbType.Int64);
            Request.AddParams("@state_id", pClsProperty.state_id, DbType.Int32);
            Request.AddParams("@country_id", pClsProperty.country_id, DbType.Int32);
            Request.AddParams("@active", pClsProperty.active, DbType.Int32);
            Request.AddParams("@remarks", pClsProperty.remarks, DbType.String);
            Request.AddParams("@owner_name", pClsProperty.owner_name, DbType.String);
            Request.AddParams("@website", pClsProperty.website, DbType.String);
            Request.AddParams("@email", pClsProperty.email, DbType.String);
            Request.AddParams("@pincode", pClsProperty.pincode, DbType.String);
            Request.AddParams("@address", pClsProperty.address, DbType.String);
            Request.AddParams("@phone1", pClsProperty.phone1, DbType.String);
            Request.AddParams("@phone2", pClsProperty.phone2, DbType.String);
            Request.AddParams("@nature_of_business", pClsProperty.nature_of_business, DbType.String);
            Request.AddParams("@service_tax_no", pClsProperty.service_tax_no, DbType.String);
            Request.AddParams("@cst_no", pClsProperty.cst_no, DbType.String);
            Request.AddParams("@tan_no", pClsProperty.tan_no, DbType.String);
            Request.AddParams("@tds_circle", pClsProperty.tds_circle, DbType.String);
            Request.AddParams("@bank_acc_no", pClsProperty.bank_acc_no, DbType.String);
            Request.AddParams("@service_tax_date", pClsProperty.service_tax_date, DbType.String);
            Request.AddParams("@cst_date", pClsProperty.cst_date, DbType.String);
            Request.AddParams("@tan_date", pClsProperty.tan_date, DbType.String);
            Request.AddParams("@registration_no", pClsProperty.registration_no, DbType.String);
            Request.AddParams("@fax", pClsProperty.fax, DbType.String);
            Request.AddParams("@gst_date", pClsProperty.gst_date, DbType.String);
            Request.AddParams("@gst_no", pClsProperty.gst_no, DbType.String);
            Request.AddParams("@user_id", GlobalDec.gEmployeeProperty.user_id, DbType.Int32);
            Request.AddParams("@ip_address", GlobalDec.gStrComputerIP, DbType.String);
            Request.AddParams("@pancard_no", pClsProperty.pancard_no, DbType.String);
            Request.AddParams("@bank_name", pClsProperty.bank_name, DbType.String);
            Request.AddParams("@bank_branch", pClsProperty.bank_branch, DbType.String);
            Request.AddParams("@bank_ifsc", pClsProperty.bank_ifsc, DbType.String);
            Request.AddParams("@entry_date", Val.DBDate(GlobalDec.gStr_SystemDate), DbType.Date);
            Request.AddParams("@entry_time", GlobalDec.gStr_SystemTime, DbType.String);

            Request.CommandText = BLL.TPV.SProc.MST_Company_Save;
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }
        public DataTable GetData(int active = 0)
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.AddParams("@Active", active, DbType.Int32);

            Request.CommandText = BLL.TPV.SProc.MST_Company_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request);
            return DTab;
        }
        public string ISExists(string CompanyName, Int64 CompanyId)
        {
            Validation Val = new Validation();
            return Val.ToString(Ope.FindText(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, "MST_Company", "company_name", "AND company_name = '" + CompanyName + "' AND NOT company_id =" + CompanyId));
        }
    }
}
