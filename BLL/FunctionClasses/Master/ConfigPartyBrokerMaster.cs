using BLL.PropertyClasses.Master;
using DLL;
using System.Data;

namespace BLL.FunctionClasses.Master
{
    public class ConfigPartyBrokerMaster
    {
        InterfaceLayer Ope = new InterfaceLayer();
        Validation Val = new Validation();
        public int Save(ConfigPartyBroker_MasterProperty pClsProperty)
        {
            Request Request = new Request();

            Request.AddParams("@type", pClsProperty.type, DbType.String);
            Request.AddParams("@party_id", pClsProperty.party_id, DbType.Int32);
            Request.AddParams("@broker_id", pClsProperty.broker_id, DbType.String);
            Request.AddParams("@active", pClsProperty.active, DbType.Int32);
            Request.AddParams("@user_id", GlobalDec.gEmployeeProperty.user_id, DbType.Int32);
            Request.AddParams("@ip_address", GlobalDec.gStrComputerIP, DbType.String);
            Request.AddParams("@entry_date", Val.DBDate(GlobalDec.gStr_SystemDate), DbType.Date);
            Request.AddParams("@entry_time", GlobalDec.gStr_SystemTime, DbType.String);

            Request.CommandText = BLL.TPV.SProc.MST_Config_PartyBroker_Save;
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }
        public object GetBrokerData(int PartyId)
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();
            Request.AddParams("@party_id", PartyId, DbType.Int32);
            Request.CommandText = TPV.SProc.MST_Config_PartyBroker_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request);
            DataTable DTab1 = new DataTable();
            DataRow DRow = DTab1.NewRow();
            DRow.Table.Columns.Add("broker_id");
            DRow.Table.Columns.Add("broker_name");

            string StrId = "";
            string StrName = "";
            foreach (DataRow DR in DTab.Rows)
            {
                StrId = StrId + DR["broker_id"] + ",";
                StrName = StrName + DR["broker_name"] + ",";
            }

            if (StrId != "")
            {
                StrId = StrId.Substring(0, StrId.Length - 1);
                StrName = StrName.Substring(0, StrName.Length - 1);
            }
            DRow["broker_id"] = StrId;
            DRow["broker_name"] = StrName;
            return DRow;
        }
        public DataTable GetConfigPartyBroker(int party_id)
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.CommandText = BLL.TPV.SProc.MST_Config_PartyBroker_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Request.AddParams("@party_id", party_id, DbType.Int32);
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request);
            return DTab;
        }
        public int Delete(ConfigPartyBroker_MasterProperty pClsProperty)
        {
            Request Request = new Request();
            Request.AddParams("@party_id", pClsProperty.party_id, DbType.Int32);
            Request.AddParams("@type", pClsProperty.type, DbType.String);
            Request.CommandText = BLL.TPV.SProc.MST_Config_PartyBroker_Save;
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }

    }
}
