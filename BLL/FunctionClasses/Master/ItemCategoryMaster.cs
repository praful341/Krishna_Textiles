using BLL.PropertyClasses.Master;
using DLL;
using System;
using System.Data;
namespace BLL.FunctionClasses.Master
{
    public class ItemCategoryMaster
    {
        InterfaceLayer Ope = new InterfaceLayer();

        #region Other Function

        public int Save(Item_Category_MasterProperty pClsProperty)
        {
            Request Request = new Request();

            Request.AddParams("@item_category_id", pClsProperty.item_category_id, DbType.Int32);
            Request.AddParams("@item_category_name", pClsProperty.item_category_name, DbType.String);
            Request.AddParams("@remark", pClsProperty.remark, DbType.String);
            Request.AddParams("@active", pClsProperty.active, DbType.Int32);
            Request.AddParams("@is_consumable", pClsProperty.is_consumable, DbType.Int32);
            Request.AddParams("@is_repairable", pClsProperty.is_repairable, DbType.Int32);

            Request.CommandText = BLL.TPV.SProc.MST_Item_Cat_Master_Save;
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }


        public DataTable GetData()
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.AddParams("@active", 1, DbType.Int32);

            Request.CommandText = BLL.TPV.SProc.MST_Item_Cat_Master_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request);
            return DTab;
        }

        public DataTable GetData_Search()
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.CommandText = BLL.TPV.SProc.MST_Item_Cat_Master_Search_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request);
            return DTab;
        }

        public string ISExists(string ItemCategoryName, Int64 ItemCategoryID)
        {
            Validation Val = new Validation();
            return Val.ToString(Ope.FindText(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, "MST_Item_Category", "item_category_name", "AND item_category_name = '" + ItemCategoryName + "' AND NOT item_category_id =" + ItemCategoryID));
        }

        #endregion
    }
}
