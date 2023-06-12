using BLL.PropertyClasses.Master;
using DLL;
using System;
using System.Data;
namespace BLL.FunctionClasses.Master
{
    public class ItemHSNMaster
    {
        InterfaceLayer Ope = new InterfaceLayer();
        Validation Val = new Validation();

        #region Other Function

        public int Save(ItemHSN_MasterProperty pClsProperty)
        {
            Request Request = new Request();

            Request.AddParams("@hsn_id", pClsProperty.hsn_id, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@hsn_code", pClsProperty.hsn_code, DbType.String, ParameterDirection.Input);
            Request.AddParams("@hsn_name", pClsProperty.hsn_name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@igst_date", pClsProperty.igst_date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@igst_rate", pClsProperty.igst_rate, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@sgst_date", pClsProperty.sgst_date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@sgst_rate", pClsProperty.sgst_rate, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@cgst_date", pClsProperty.cgst_date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@cgst_rate", pClsProperty.cgst_rate, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@remark", pClsProperty.remark, DbType.String, ParameterDirection.Input);
            Request.AddParams("@active", pClsProperty.active, DbType.Int32, ParameterDirection.Input);

            Request.CommandText = "HSN_Master_Save";
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }

        public DataTable GetData()
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.AddParams("@active", 1, DbType.Int32, ParameterDirection.Input);

            Request.CommandText = "HSN_Master_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request);
            return DTab;
        }

        public DataTable GetData_UnitType()
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

            Request.CommandText = "HSN_Master_Search_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request);
            return DTab;
        }

        public string ISExists(string HSNCode, Int64 HSNID)
        {
            Validation Val = new Validation();
            return Val.ToString(Ope.FindText(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, "MST_Item_HSN", "hsn_code", "AND hsn_code = '" + HSNCode + "' AND NOT hsn_id =" + HSNID));
        }

        #endregion

    }
}

