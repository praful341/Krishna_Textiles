using BLL.PropertyClasses.Master;
using DLL;
using System;
using System.Data;

namespace BLL.FunctionClasses.Master
{
    public class IDProofMaster
    {
        InterfaceLayer Ope = new InterfaceLayer();
        Validation Val = new Validation();
        public int Save(IDProof_MasterProperty pClsProperty)
        {
            Request Request = new Request();

            Request.AddParams("@idproof_id", pClsProperty.idproof_id, DbType.Int32);
            Request.AddParams("@idproof_name", pClsProperty.idproof_name, DbType.String);
            Request.AddParams("@active", pClsProperty.active, DbType.Int32);
            Request.AddParams("@remarks", pClsProperty.remarks, DbType.String);
            Request.AddParams("@sequence_no", pClsProperty.sequence_no, DbType.Int32);
            Request.AddParams("@user_id", GlobalDec.gEmployeeProperty.user_id, DbType.Int32);
            Request.AddParams("@ip_address", GlobalDec.gStrComputerIP, DbType.String);
            Request.AddParams("@entry_date", Val.DBDate(GlobalDec.gStr_SystemDate), DbType.Date);
            Request.AddParams("@entry_time", GlobalDec.gStr_SystemTime, DbType.String);

            Request.CommandText = BLL.TPV.SProc.MST_IDProof_Save;
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }
        public DataTable GetData(int active = 0)
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();
            Request.CommandText = BLL.TPV.SProc.MST_IDProof_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Request.AddParams("@Active", active, DbType.Int32);
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request);
            return DTab;
        }
        public string ISExists(string IDProofName, Int64 IDProofId)
        {
            Validation Val = new Validation();
            return Val.ToString(Ope.FindText(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, "MST_ID_Proof", "idproof_name", "AND idproof_name = '" + IDProofName + "' AND NOT idproof_id =" + IDProofId));
        }
    }
}
