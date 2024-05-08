using BLL.PropertyClasses.Master;
using DLL;
using System;
using System.Data;

namespace BLL.FunctionClasses.Master
{
    public class PurchaseFirmMaster
    {
        InterfaceLayer Ope = new InterfaceLayer();
        Validation Val = new Validation();
        public int Save(PurchaseFirm_MasterProperty pClsProperty)
        {
            Request Request = new Request();

            Request.AddParams("@firm_id", pClsProperty.firm_id, DbType.Int64);
            Request.AddParams("@firm_name", pClsProperty.firm_name, DbType.String);
            Request.AddParams("@city_id", pClsProperty.city_id, DbType.Int64);
            Request.AddParams("@state_id", pClsProperty.state_id, DbType.Int32);
            Request.AddParams("@country_id", pClsProperty.country_id, DbType.Int32);
            Request.AddParams("@active", pClsProperty.active, DbType.Int32);
            Request.AddParams("@website", pClsProperty.website, DbType.String);
            Request.AddParams("@email", pClsProperty.email, DbType.String);
            Request.AddParams("@pincode", pClsProperty.pincode, DbType.String);
            Request.AddParams("@phone1", pClsProperty.phone1, DbType.String);
            Request.AddParams("@phone2", pClsProperty.phone2, DbType.String);
            Request.AddParams("@bank_acc_no", pClsProperty.bank_acc_no, DbType.String);
            Request.AddParams("@gst_no", pClsProperty.gst_no, DbType.String);
            Request.AddParams("@user_id", GlobalDec.gEmployeeProperty.user_id, DbType.Int32);
            Request.AddParams("@ip_address", GlobalDec.gStrComputerIP, DbType.String);
            Request.AddParams("@pancard_no", pClsProperty.pancard_no, DbType.String);
            Request.AddParams("@bank_name", pClsProperty.bank_name, DbType.String);
            Request.AddParams("@bank_branch", pClsProperty.bank_branch, DbType.String);
            Request.AddParams("@bank_ifsc", pClsProperty.bank_ifsc, DbType.String);
            Request.AddParams("@entry_date", Val.DBDate(GlobalDec.gStr_SystemDate), DbType.Date);
            Request.AddParams("@entry_time", GlobalDec.gStr_SystemTime, DbType.String);

            Request.AddParams("@address1", pClsProperty.address1, DbType.String);
            Request.AddParams("@address2", pClsProperty.address2, DbType.String);
            Request.AddParams("@address3", pClsProperty.address3, DbType.String);
            Request.AddParams("@address4", pClsProperty.address4, DbType.String);

            Request.AddParams("@bank_account_type", pClsProperty.bank_account_type, DbType.String);

            Request.CommandText = BLL.TPV.SProc.MST_Purchase_Firm_Save;
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }
        public DataTable GetData(int active = 0)
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.AddParams("@Active", active, DbType.Int32);

            Request.CommandText = BLL.TPV.SProc.MST_Purchase_Firm_All_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request);
            return DTab;
        }
        public string ISExists(string FirmName, Int64 FirmId)
        {
            Validation Val = new Validation();
            return Val.ToString(Ope.FindText(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, "MST_Purchase_Firm_Master", "firm_name", "AND firm_name = '" + FirmName + "' AND NOT firm_id =" + FirmId));
        }
    }
}
