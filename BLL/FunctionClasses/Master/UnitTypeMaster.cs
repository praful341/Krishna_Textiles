using BLL.PropertyClasses.Master;
using DLL;
using System;
using System.Data;
namespace BLL.FunctionClasses.Master
{
    public class UnitTypeMaster
    {
        InterfaceLayer Ope = new InterfaceLayer();

        #region Other Function

        public int Save(UnitType_MasterProperty pClsProperty)
        {
            Request Request = new Request();

            Request.AddParams("@unit_id", pClsProperty.unit_id, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@unit_name", pClsProperty.unit_name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@active", pClsProperty.active, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@remark", pClsProperty.remark, DbType.String, ParameterDirection.Input);

            Request.CommandText = "Unit_Master_Save";
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }

        public DataTable GetData()
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.AddParams("@active", 1, DbType.Int32, ParameterDirection.Input);

            Request.CommandText = "Unit_Master_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request);
            return DTab;
        }

        public DataTable GetData_Search()
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.CommandText = "Unit_Master_Search_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request);
            return DTab;
        }

        public string ISExists(string UnitName, Int64 UnitID)
        {
            Validation Val = new Validation();
            return Val.ToString(Ope.FindText(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, "MST_Unit", "unit_name", "AND unit_name = '" + UnitName + "' AND NOT unit_id =" + UnitID));
        }

        #endregion
    }
}
