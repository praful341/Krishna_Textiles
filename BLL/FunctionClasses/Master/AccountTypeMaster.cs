using DLL;
using System;

namespace BLL.FunctionClasses.Master
{ 
    public class AccountTypeMaster
    {
        InterfaceLayer Ope = new InterfaceLayer();
        Validation Val = new Validation();
        //public int Save(Assort_MasterProperty pClsProperty)
        //{
        //    Request Request = new Request();

        //    Request.AddParams("@assort_id", pClsProperty.assort_id, DbType.Int32);
        //    Request.AddParams("@assort_name", pClsProperty.assortname, DbType.String);
        //    Request.AddParams("@active", pClsProperty.active, DbType.Int32);
        //    Request.AddParams("@remarks", pClsProperty.remarks, DbType.String);
        //    Request.AddParams("@sequence_no", pClsProperty.sequence_no, DbType.Int32);
        //    Request.AddParams("@user_id", GlobalDec.gEmployeeProperty.user_id, DbType.Int32);
        //    Request.AddParams("@ip_address", GlobalDec.gStrComputerIP, DbType.String);
        //    Request.AddParams("@entry_date", Val.DBDate(GlobalDec.gStr_SystemDate), DbType.Date);
        //    Request.AddParams("@entry_time", GlobalDec.gStr_SystemTime, DbType.String);

        //    Request.CommandText = BLL.TPV.SProc.MST_AccountType_Save;
        //    Request.CommandType = CommandType.StoredProcedure;
        //    return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        //}
        //public DataTable GetData(int active = 0)
        //{
        //    DataTable DTab = new DataTable();
        //    Request Request = new Request();
        //    Request.CommandText = BLL.TPV.SProc.MST_AccountType_GetData;
        //    Request.CommandType = CommandType.StoredProcedure;
        //    Request.AddParams("@Active", active, DbType.Int32);
        //    Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request);
        //    return DTab;
        //}

        public string ISExists(string AssortName, Int64 AssortId)
        {
            Validation Val = new Validation();
            return Val.ToString(Ope.FindText(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, "MST_Assorts", "assort_name", "AND assort_name = '" + AssortName + "' AND NOT assort_id =" + AssortId));
        }

    }
}
