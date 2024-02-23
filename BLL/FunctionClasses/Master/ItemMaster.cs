using BLL.PropertyClasses.Master;
using DLL;
using System;
using System.Data;

namespace BLL.FunctionClasses.Master
{
    public class ItemMaster
    {
        InterfaceLayer Ope = new InterfaceLayer();

        #region Property Settings

        private DataTable _DTab = new DataTable("Item_Master");

        public DataTable DTab
        {
            get { return _DTab; }
            set { _DTab = value; }
        }
        private DataSet _DS = new DataSet();

        public DataSet DS
        {
            get { return _DS; }
            set { _DS = value; }
        }


        public string ItemDetail
        {
            get { return "Item_Detail"; }
        }

        #endregion

        #region Other Function

        public int SaveItem(Item_MasterProperty pClsProperty)
        {
            int IntRes = 0;

            try
            {
                Request Request = new Request();

                Request.AddParams("@item_id", pClsProperty.item_id, DbType.Int64);
                Request.AddParams("@item_name", pClsProperty.item_name, DbType.String);
                Request.AddParams("@item_shortname", pClsProperty.item_shortname, DbType.String);
                Request.AddParams("@item_group_id", pClsProperty.item_group_id, DbType.Int64);
                Request.AddParams("@item_category_id", pClsProperty.item_category_id, DbType.Int64);
                Request.AddParams("@active", pClsProperty.active, DbType.Int64);
                Request.AddParams("@remark", pClsProperty.remark, DbType.String);
                Request.AddParams("@unit_id", pClsProperty.unit_id, DbType.Int64);
                Request.AddParams("@last_purchase_rate", pClsProperty.last_purchase_rate, DbType.Double);
                Request.AddParams("@item_codification", pClsProperty.item_codification, DbType.String);
                Request.AddParams("@disc_per", pClsProperty.disc_per, DbType.Double);
                Request.AddParams("@company_id", pClsProperty.company_id, DbType.Int64);
                Request.AddParams("@branch_id", pClsProperty.branch_id, DbType.Int64);
                Request.AddParams("@location_id", pClsProperty.location_id, DbType.Int64);
                Request.AddParams("@hsn_id", pClsProperty.hsn_id, DbType.Int64);
                Request.AddParams("@sale_rate", pClsProperty.sale_rate, DbType.Decimal);
                Request.AddParams("@stock_limit", pClsProperty.sale_rate, DbType.Decimal);
                Request.AddParams("@pcs_in_box", pClsProperty.sale_rate, DbType.Decimal);

                Request.CommandText = BLL.TPV.SProc.MST_Item_Master_Save;
                Request.CommandType = CommandType.StoredProcedure;
                IntRes = Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
            }
            catch
            {
                Ope.Rollback(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName);
                IntRes = 0;
            }
            return IntRes;
        }

        public string ISExists(string ItemName, Int64 ItemID)
        {
            Validation Val = new Validation();
            return Val.ToString(Ope.FindText(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, "MST_Item", "item_name", "AND item_name = '" + ItemName + "' AND NOT item_id =" + ItemID));
        }

        public void GetData()
        {
            Request Request = new Request();
            Request.CommandText = BLL.TPV.SProc.MST_Item_Master_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request);
        }

        public DataTable Item_GetData()
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.CommandText = BLL.TPV.SProc.MST_Item_Master_GetData;
            Request.CommandType = CommandType.StoredProcedure;

            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request);
            return DTab;
        }

        public int Delete(Item_MasterProperty pClsProperty)
        {
            Request Request = new Request();
            Request.AddParams("@item_id", pClsProperty.item_id, DbType.Int64);
            Request.CommandText = BLL.TPV.SProc.MST_Item_Master_Delete;
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }
        #endregion
    }
}
