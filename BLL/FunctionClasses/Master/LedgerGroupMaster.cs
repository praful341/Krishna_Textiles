using BLL.PropertyClasses.Master;
using DLL;
using System;
using System.Data;

namespace BLL.FunctionClasses.Master
{
    public class LedgerGroupMaster
    {
        InterfaceLayer Ope = new InterfaceLayer();
        Validation Val = new Validation();

        #region Other Function

        public int Save(Ledger_Group_MasterProperty pClsProperty)
        {
            Request Request = new Request();

            Request.AddParams("@ledger_group_id", pClsProperty.ledger_group_id, DbType.Int64);
            Request.AddParams("@ledger_group_name", pClsProperty.ledger_group_name, DbType.String);
            Request.AddParams("@remark", pClsProperty.remark, DbType.String);
            Request.AddParams("@active", pClsProperty.active, DbType.Int32);

            Request.AddParams("@user_id", GlobalDec.gEmployeeProperty.user_id, DbType.Int32);
            Request.AddParams("@ip_address", GlobalDec.gStrComputerIP, DbType.String);
            Request.AddParams("@entry_date", Val.DBDate(GlobalDec.gStr_SystemDate), DbType.Date);
            Request.AddParams("@entry_time", GlobalDec.gStr_SystemTime, DbType.String);
            Request.AddParams("@type", pClsProperty.type, DbType.String);

            Request.CommandText = BLL.TPV.SProc.MST_Ledger_Group_Master_Save;
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }
        public DataTable GetData()
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.AddParams("@active", 1, DbType.Int32);

            Request.CommandText = BLL.TPV.SProc.MST_Ledger_Group_Master_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request);
            return DTab;
        }
        public DataTable GetData_Search()
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.CommandText = BLL.TPV.SProc.MST_Ledger_Group_Master_Search_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request);
            return DTab;
        }

        public string ISExists(string type, string LedgerGroupName, Int64 LedgerGroupID)
        {
            Validation Val = new Validation();
            return Val.ToString(Ope.FindText(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, "MST_Ledger_Group", "ledger_group_name", "AND ledger_group_name = '" + LedgerGroupName + "' AND type = '" + type + "' AND NOT ledger_group_id =" + LedgerGroupID));
        }
        #endregion
    }
}
