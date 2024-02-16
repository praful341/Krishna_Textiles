using BLL.PropertyClasses.Master;
using DLL;
using System;
using System.Data;

namespace BLL.FunctionClasses.Master
{
    public class CourierMaster
    {
        InterfaceLayer Ope = new InterfaceLayer();
        Validation Val = new Validation();
        public int Save(Courier_MasterProperty pClsProperty)
        {
            Request Request = new Request();

            Request.AddParams("@courier_id", pClsProperty.courier_id, DbType.Int32);
            Request.AddParams("@courier_name", pClsProperty.courier_name, DbType.String);
            Request.AddParams("@mobile_no_1", pClsProperty.mobile_no_1, DbType.Int64);
            Request.AddParams("@mobile_no_2", pClsProperty.mobile_no_2, DbType.Int64);
            Request.AddParams("@tracking_link", pClsProperty.tracking_link, DbType.String);
            Request.AddParams("@weight", pClsProperty.weight, DbType.Decimal);
            Request.AddParams("@rate", pClsProperty.rate, DbType.Decimal);
            Request.AddParams("@user_id", GlobalDec.gEmployeeProperty.user_id, DbType.Int32);
            Request.AddParams("@ip_address", GlobalDec.gStrComputerIP, DbType.String);
            Request.AddParams("@entry_date", Val.DBDate(GlobalDec.gStr_SystemDate), DbType.Date);
            Request.AddParams("@entry_time", GlobalDec.gStr_SystemTime, DbType.String);
            Request.AddParams("@active", pClsProperty.active, DbType.Int32);

            Request.CommandText = BLL.TPV.SProc.MST_Courier_Save;
            Request.CommandType = CommandType.StoredProcedure;

            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }
        public DataTable GetData(int active = 0)
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();
            Request.CommandText = BLL.TPV.SProc.MST_Courier_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Request.AddParams("@active", active, DbType.Int32);

            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request);
            return DTab;
        }
        public string ISExists(string CourierName, decimal Weight, decimal Rate, Int64 CourierId)
        {
            Validation Val = new Validation();
            return Val.ToString(Ope.FindText(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, "MST_Courier", "courier_name", "AND courier_name = '" + CourierName + "' AND weight = '" + Weight + "' AND rate = '" + Rate + "' AND NOT courier_id =" + CourierId));
        }
    }
}
