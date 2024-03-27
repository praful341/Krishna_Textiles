using BLL.PropertyClasses.Master;
using DLL;
using System;
using System.Data;

namespace BLL.FunctionClasses.Master
{
    public class LedgerMaster
    {
        InterfaceLayer Ope = new InterfaceLayer();
        Validation Val = new Validation();
        public int Save(Ledger_MasterProperty pClsProperty)
        {
            int IntRes = 0;
            try
            {
                Request Request = new Request();

                Request.AddParams("@ledger_id", pClsProperty.ledger_id, DbType.Int64);
                Request.AddParams("@ledger_name", pClsProperty.ledger_name, DbType.String);
                Request.AddParams("@ledger_group_id", pClsProperty.ledger_group_id, DbType.Int64);
                Request.AddParams("@ledger_type", pClsProperty.ledger_type, DbType.String);
                Request.AddParams("@opening_balance", pClsProperty.opening_balance, DbType.Decimal);
                Request.AddParams("@ledger_print_name", pClsProperty.ledger_print_name, DbType.String);
                Request.AddParams("@party_address1", pClsProperty.party_address1, DbType.String);
                Request.AddParams("@party_address2", pClsProperty.party_address2, DbType.String);
                Request.AddParams("@party_address3", pClsProperty.party_address3, DbType.String);
                Request.AddParams("@party_address4", pClsProperty.party_address4, DbType.String);
                Request.AddParams("@party_pincode", pClsProperty.party_pincode, DbType.String);
                Request.AddParams("@party_county_id", pClsProperty.party_county_id, DbType.Int64);
                Request.AddParams("@party_city_id", pClsProperty.party_city_id, DbType.Int64);
                Request.AddParams("@party_state_id", pClsProperty.party_state_id, DbType.Int64);
                Request.AddParams("@party_mobile1", pClsProperty.party_mobile1, DbType.String);
                Request.AddParams("@party_mobile2", pClsProperty.party_mobile2, DbType.String);
                Request.AddParams("@party_email", pClsProperty.party_email, DbType.String);
                Request.AddParams("@bank_name", pClsProperty.bank_name, DbType.String);
                Request.AddParams("@bank_branch", pClsProperty.bank_branch, DbType.String);
                Request.AddParams("@bank_ifsc", pClsProperty.bank_ifsc, DbType.String);
                Request.AddParams("@bank_account_no", pClsProperty.bank_account_no, DbType.String);
                Request.AddParams("@party_pan_no", pClsProperty.party_pan_no, DbType.String);
                Request.AddParams("@gst_no", pClsProperty.gst_no, DbType.String);
                Request.AddParams("@active", pClsProperty.active, DbType.Int32);
                Request.AddParams("@remark", pClsProperty.remark, DbType.String);
                Request.AddParams("@user_id", GlobalDec.gEmployeeProperty.user_id, DbType.Int32);
                Request.AddParams("@ip_address", GlobalDec.gStrComputerIP, DbType.String);
                Request.AddParams("@entry_date", Val.DBDate(GlobalDec.gStr_SystemDate), DbType.Date);
                Request.AddParams("@entry_time", GlobalDec.gStr_SystemTime, DbType.String);

                Request.CommandText = BLL.TPV.SProc.MST_Ledger_Save;
                Request.CommandType = CommandType.StoredProcedure;

                IntRes = Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
            }
            catch (Exception ex)
            {
                General.ShowErrors(ex.ToString());
            }
            return IntRes;
        }
        public DataTable GetData(int active = 0)
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.AddParams("@active", active, DbType.Int32);

            Request.CommandText = BLL.TPV.SProc.MST_Ledger_GetData;
            Request.CommandType = CommandType.StoredProcedure;

            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request);
            return DTab;
        }
        public DataTable CashBank_Ledger_GetData(int active = 0)
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.AddParams("@active", active, DbType.Int32);

            Request.CommandText = BLL.TPV.SProc.MST_CashBank_Ledger_GetData;
            Request.CommandType = CommandType.StoredProcedure;

            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request);
            return DTab;
        }

        public string ISExists(string Ledger, Int64 LedgerId)
        {
            Validation Val = new Validation();
            return Val.ToString(Ope.FindText(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, "MST_Ledger", "ledger_name", "AND ledger_name = '" + Ledger + "' AND NOT ledger_id =" + LedgerId));
        }
    }
}
