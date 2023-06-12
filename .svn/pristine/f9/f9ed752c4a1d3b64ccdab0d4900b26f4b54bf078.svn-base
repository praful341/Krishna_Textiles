using BLL.PropertyClasses.Master;
using DLL;
using System.Data;

namespace BLL.FunctionClasses.Master
{ 
    public class BankMaster
    {
        InterfaceLayer Ope = new InterfaceLayer();
        Validation Val = new Validation();


        #region Params Region

        public int Save(Bank_MasterProperty pClsProperty)
        {
            Request Request = new Request();

            Request.AddParams("@bank_id", pClsProperty.bank_id, DbType.Int64);
            Request.AddParams("@bank_name", pClsProperty.bank_name, DbType.String);
            Request.AddParams("@bank_account_name", pClsProperty.bank_account_name, DbType.String);
            Request.AddParams("@bank_account_no", pClsProperty.bank_account_no, DbType.String);
            Request.AddParams("@bank_ifsc", pClsProperty.bank_ifsc, DbType.String);
            Request.AddParams("@bank_cheque", pClsProperty.bank_cheque, DbType.String);
            Request.AddParams("@bank_atm", pClsProperty.bank_atm, DbType.String);
            Request.AddParams("@user_id", GlobalDec.gEmployeeProperty.employee_id, DbType.Int32);
            Request.AddParams("@ip_address", GlobalDec.gStrComputerIP, DbType.String);
            Request.AddParams("@entry_date", Val.DBDate(GlobalDec.gStr_SystemDate), DbType.Date);
            Request.AddParams("@entry_time", GlobalDec.gStr_SystemTime, DbType.String);
            Request.AddParams("@branch_id", pClsProperty.branch_id, DbType.Int64);

            Request.CommandText = BLL.TPV.SProc.MST_Bank_Save;
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }

        public DataTable GetData()
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.CommandText = BLL.TPV.SProc.MST_Bank_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request);
            return DTab;
        }

        #endregion
    }
}
